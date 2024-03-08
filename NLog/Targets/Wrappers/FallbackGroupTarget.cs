using System;
using NLog.Common;

namespace NLog.Targets.Wrappers
{
	/// <summary>
	/// Provides fallback-on-error.
	/// </summary>
	/// <seealso href="http://nlog-project.org/wiki/FallbackGroup_target">Documentation on NLog Wiki</seealso>
	/// <example>
	/// <p>This example causes the messages to be written to server1, 
	/// and if it fails, messages go to server2.</p>
	/// <p>
	/// To set up the target in the <a href="config.html">configuration file</a>, 
	/// use the following syntax:
	/// </p>
	/// <code lang="XML" source="examples/targets/Configuration File/FallbackGroup/NLog.config" />
	/// <p>
	/// The above examples assume just one target and a single rule. See below for
	/// a programmatic configuration that's equivalent to the above config file:
	/// </p>
	/// <code lang="C#" source="examples/targets/Configuration API/FallbackGroup/Simple/Example.cs" />
	/// </example>
	// Token: 0x02000135 RID: 309
	[Target("FallbackGroup", IsCompound = true)]
	public class FallbackGroupTarget : CompoundTargetBase
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Targets.Wrappers.FallbackGroupTarget" /> class.
		/// </summary>
		// Token: 0x06000A3E RID: 2622 RVA: 0x000245B6 File Offset: 0x000227B6
		public FallbackGroupTarget()
			: this(new Target[0])
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Targets.Wrappers.FallbackGroupTarget" /> class.
		/// </summary>
		/// <param name="targets">The targets.</param>
		// Token: 0x06000A3F RID: 2623 RVA: 0x000245C7 File Offset: 0x000227C7
		public FallbackGroupTarget(params Target[] targets)
			: base(targets)
		{
		}

		/// <summary>
		/// Gets or sets a value indicating whether to return to the first target after any successful write.
		/// </summary>
		/// <docgen category="Fallback Options" order="10" />
		// Token: 0x17000231 RID: 561
		// (get) Token: 0x06000A40 RID: 2624 RVA: 0x000245E0 File Offset: 0x000227E0
		// (set) Token: 0x06000A41 RID: 2625 RVA: 0x000245F7 File Offset: 0x000227F7
		public bool ReturnToFirstOnSuccess { get; set; }

		/// <summary>
		/// Forwards the log event to the sub-targets until one of them succeeds.
		/// </summary>
		/// <param name="logEvent">The log event.</param>
		/// <remarks>
		/// The method remembers the last-known-successful target
		/// and starts the iteration from it.
		/// If <see cref="P:NLog.Targets.Wrappers.FallbackGroupTarget.ReturnToFirstOnSuccess" /> is set, the method
		/// resets the target to the first target
		/// stored in <see cref="N:NLog.Targets" />.
		/// </remarks>
		// Token: 0x06000A42 RID: 2626 RVA: 0x00024818 File Offset: 0x00022A18
		protected override void Write(AsyncLogEventInfo logEvent)
		{
			AsyncContinuation continuation = null;
			int tryCounter = 0;
			int targetToInvoke;
			continuation = delegate(Exception ex)
			{
				if (ex == null)
				{
					lock (this.lockObject)
					{
						if (this.currentTarget != 0)
						{
							if (this.ReturnToFirstOnSuccess)
							{
								InternalLogger.Debug("Fallback: target '{0}' succeeded. Returning to the first one.", new object[] { this.Targets[this.currentTarget] });
								this.currentTarget = 0;
							}
						}
					}
					logEvent.Continuation(null);
				}
				else
				{
					lock (this.lockObject)
					{
						InternalLogger.Warn("Fallback: target '{0}' failed. Proceeding to the next one. Error was: {1}", new object[]
						{
							this.Targets[this.currentTarget],
							ex
						});
						this.currentTarget = (this.currentTarget + 1) % this.Targets.Count;
						tryCounter++;
						targetToInvoke = this.currentTarget;
						if (tryCounter >= this.Targets.Count)
						{
							targetToInvoke = -1;
						}
					}
					if (targetToInvoke >= 0)
					{
						this.Targets[targetToInvoke].WriteAsyncLogEvent(logEvent.LogEvent.WithContinuation(continuation));
					}
					else
					{
						logEvent.Continuation(ex);
					}
				}
			};
			lock (this.lockObject)
			{
				targetToInvoke = this.currentTarget;
			}
			base.Targets[targetToInvoke].WriteAsyncLogEvent(logEvent.LogEvent.WithContinuation(continuation));
		}

		// Token: 0x04000356 RID: 854
		private int currentTarget;

		// Token: 0x04000357 RID: 855
		private object lockObject = new object();
	}
}
