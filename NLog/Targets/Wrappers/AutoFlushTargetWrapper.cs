using System;
using NLog.Common;

namespace NLog.Targets.Wrappers
{
	/// <summary>
	/// Causes a flush after each write on a wrapped target.
	/// </summary>
	/// <seealso href="http://nlog-project.org/wiki/AutoFlushWrapper_target">Documentation on NLog Wiki</seealso>
	/// <example>
	/// <p>
	/// To set up the target in the <a href="config.html">configuration file</a>, 
	/// use the following syntax:
	/// </p>
	/// <code lang="XML" source="examples/targets/Configuration File/AutoFlushWrapper/NLog.config" />
	/// <p>
	/// The above examples assume just one target and a single rule. See below for
	/// a programmatic configuration that's equivalent to the above config file:
	/// </p>
	/// <code lang="C#" source="examples/targets/Configuration API/AutoFlushWrapper/Simple/Example.cs" />
	/// </example>
	// Token: 0x02000132 RID: 306
	[Target("AutoFlushWrapper", IsWrapper = true)]
	public class AutoFlushTargetWrapper : WrapperTargetBase
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Targets.Wrappers.AutoFlushTargetWrapper" /> class.
		/// </summary>
		/// <remarks>
		/// The default value of the layout is: <code>${longdate}|${level:uppercase=true}|${logger}|${message}</code>
		/// </remarks>
		// Token: 0x06000A25 RID: 2597 RVA: 0x00024158 File Offset: 0x00022358
		public AutoFlushTargetWrapper()
			: this(null)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Targets.Wrappers.AutoFlushTargetWrapper" /> class.
		/// </summary>
		/// <param name="wrappedTarget">The wrapped target.</param>
		// Token: 0x06000A26 RID: 2598 RVA: 0x00024164 File Offset: 0x00022364
		public AutoFlushTargetWrapper(Target wrappedTarget)
		{
			base.WrappedTarget = wrappedTarget;
		}

		/// <summary>
		/// Forwards the call to the <see cref="P:NLog.Targets.Wrappers.WrapperTargetBase.WrappedTarget" />.Write()
		/// and calls <see cref="M:NLog.Targets.Target.Flush(NLog.Common.AsyncContinuation)" /> on it.
		/// </summary>
		/// <param name="logEvent">Logging event to be written out.</param>
		// Token: 0x06000A27 RID: 2599 RVA: 0x00024177 File Offset: 0x00022377
		protected override void Write(AsyncLogEventInfo logEvent)
		{
			base.WrappedTarget.WriteAsyncLogEvent(logEvent.LogEvent.WithContinuation(AsyncHelpers.PrecededBy(logEvent.Continuation, new AsynchronousAction(base.WrappedTarget.Flush))));
		}
	}
}
