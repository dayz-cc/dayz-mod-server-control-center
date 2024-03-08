using System;
using System.ComponentModel;
using NLog.Common;

namespace NLog.Targets.Wrappers
{
	/// <summary>
	/// Repeats each log event the specified number of times.
	/// </summary>
	/// <seealso href="http://nlog-project.org/wiki/RepeatingWrapper_target">Documentation on NLog Wiki</seealso>
	/// <example>
	/// <p>This example causes each log message to be repeated 3 times.</p>
	/// <p>
	/// To set up the target in the <a href="config.html">configuration file</a>, 
	/// use the following syntax:
	/// </p>
	/// <code lang="XML" source="examples/targets/Configuration File/RepeatingWrapper/NLog.config" />
	/// <p>
	/// The above examples assume just one target and a single rule. See below for
	/// a programmatic configuration that's equivalent to the above config file:
	/// </p>
	/// <code lang="C#" source="examples/targets/Configuration API/RepeatingWrapper/Simple/Example.cs" />
	/// </example>
	// Token: 0x0200013D RID: 317
	[Target("RepeatingWrapper", IsWrapper = true)]
	public class RepeatingTargetWrapper : WrapperTargetBase
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Targets.Wrappers.RepeatingTargetWrapper" /> class.
		/// </summary>
		// Token: 0x06000A72 RID: 2674 RVA: 0x00025128 File Offset: 0x00023328
		public RepeatingTargetWrapper()
			: this(null, 3)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Targets.Wrappers.RepeatingTargetWrapper" /> class.
		/// </summary>
		/// <param name="wrappedTarget">The wrapped target.</param>
		/// <param name="repeatCount">The repeat count.</param>
		// Token: 0x06000A73 RID: 2675 RVA: 0x00025135 File Offset: 0x00023335
		public RepeatingTargetWrapper(Target wrappedTarget, int repeatCount)
		{
			base.WrappedTarget = wrappedTarget;
			this.RepeatCount = repeatCount;
		}

		/// <summary>
		/// Gets or sets the number of times to repeat each log message.
		/// </summary>
		/// <docgen category="Repeating Options" order="10" />
		// Token: 0x1700023E RID: 574
		// (get) Token: 0x06000A74 RID: 2676 RVA: 0x00025150 File Offset: 0x00023350
		// (set) Token: 0x06000A75 RID: 2677 RVA: 0x00025167 File Offset: 0x00023367
		[DefaultValue(3)]
		public int RepeatCount { get; set; }

		/// <summary>
		/// Forwards the log message to the <see cref="P:NLog.Targets.Wrappers.WrapperTargetBase.WrappedTarget" /> by calling the <see cref="M:NLog.Targets.Target.Write(NLog.LogEventInfo)" /> method <see cref="P:NLog.Targets.Wrappers.RepeatingTargetWrapper.RepeatCount" /> times.
		/// </summary>
		/// <param name="logEvent">The log event.</param>
		// Token: 0x06000A76 RID: 2678 RVA: 0x0002519C File Offset: 0x0002339C
		protected override void Write(AsyncLogEventInfo logEvent)
		{
			AsyncHelpers.Repeat(this.RepeatCount, logEvent.Continuation, delegate(AsyncContinuation cont)
			{
				this.WrappedTarget.WriteAsyncLogEvent(logEvent.LogEvent.WithContinuation(cont));
			});
		}
	}
}
