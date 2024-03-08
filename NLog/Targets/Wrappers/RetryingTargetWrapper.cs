﻿using System;
using System.ComponentModel;
using System.Threading;
using NLog.Common;

namespace NLog.Targets.Wrappers
{
	/// <summary>
	/// Retries in case of write error.
	/// </summary>
	/// <seealso href="http://nlog-project.org/wiki/RetryingWrapper_target">Documentation on NLog Wiki</seealso>
	/// <example>
	/// <p>This example causes each write attempt to be repeated 3 times, 
	/// sleeping 1 second between attempts if first one fails.</p>
	/// <p>
	/// To set up the target in the <a href="config.html">configuration file</a>, 
	/// use the following syntax:
	/// </p>
	/// <code lang="XML" source="examples/targets/Configuration File/RetryingWrapper/NLog.config" />
	/// <p>
	/// The above examples assume just one target and a single rule. See below for
	/// a programmatic configuration that's equivalent to the above config file:
	/// </p>
	/// <code lang="C#" source="examples/targets/Configuration API/RetryingWrapper/Simple/Example.cs" />
	/// </example>
	// Token: 0x0200013E RID: 318
	[Target("RetryingWrapper", IsWrapper = true)]
	public class RetryingTargetWrapper : WrapperTargetBase
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Targets.Wrappers.RetryingTargetWrapper" /> class.
		/// </summary>
		// Token: 0x06000A77 RID: 2679 RVA: 0x000251E2 File Offset: 0x000233E2
		public RetryingTargetWrapper()
			: this(null, 3, 100)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Targets.Wrappers.RetryingTargetWrapper" /> class.
		/// </summary>
		/// <param name="wrappedTarget">The wrapped target.</param>
		/// <param name="retryCount">The retry count.</param>
		/// <param name="retryDelayMilliseconds">The retry delay milliseconds.</param>
		// Token: 0x06000A78 RID: 2680 RVA: 0x000251F1 File Offset: 0x000233F1
		public RetryingTargetWrapper(Target wrappedTarget, int retryCount, int retryDelayMilliseconds)
		{
			base.WrappedTarget = wrappedTarget;
			this.RetryCount = retryCount;
			this.RetryDelayMilliseconds = retryDelayMilliseconds;
		}

		/// <summary>
		/// Gets or sets the number of retries that should be attempted on the wrapped target in case of a failure.
		/// </summary>
		/// <docgen category="Retrying Options" order="10" />
		// Token: 0x1700023F RID: 575
		// (get) Token: 0x06000A79 RID: 2681 RVA: 0x00025214 File Offset: 0x00023414
		// (set) Token: 0x06000A7A RID: 2682 RVA: 0x0002522B File Offset: 0x0002342B
		[DefaultValue(3)]
		public int RetryCount { get; set; }

		/// <summary>
		/// Gets or sets the time to wait between retries in milliseconds.
		/// </summary>
		/// <docgen category="Retrying Options" order="10" />
		// Token: 0x17000240 RID: 576
		// (get) Token: 0x06000A7B RID: 2683 RVA: 0x00025234 File Offset: 0x00023434
		// (set) Token: 0x06000A7C RID: 2684 RVA: 0x0002524B File Offset: 0x0002344B
		[DefaultValue(100)]
		public int RetryDelayMilliseconds { get; set; }

		/// <summary>
		/// Writes the specified log event to the wrapped target, retrying and pausing in case of an error.
		/// </summary>
		/// <param name="logEvent">The log event.</param>
		// Token: 0x06000A7D RID: 2685 RVA: 0x00025344 File Offset: 0x00023544
		protected override void Write(AsyncLogEventInfo logEvent)
		{
			AsyncContinuation continuation = null;
			int counter = 0;
			continuation = delegate(Exception ex)
			{
				if (ex == null)
				{
					logEvent.Continuation(null);
				}
				else
				{
					int num = Interlocked.Increment(ref counter);
					InternalLogger.Warn("Error while writing to '{0}': {1}. Try {2}/{3}", new object[] { this.WrappedTarget, ex, num, this.RetryCount });
					if (num >= this.RetryCount)
					{
						InternalLogger.Warn("Too many retries. Aborting.");
						logEvent.Continuation(ex);
					}
					else
					{
						Thread.Sleep(this.RetryDelayMilliseconds);
						this.WrappedTarget.WriteAsyncLogEvent(logEvent.LogEvent.WithContinuation(continuation));
					}
				}
			};
			base.WrappedTarget.WriteAsyncLogEvent(logEvent.LogEvent.WithContinuation(continuation));
		}
	}
}
