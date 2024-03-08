using System;
using NLog.Common;
using NLog.Conditions;
using NLog.Config;

namespace NLog.Targets.Wrappers
{
	/// <summary>
	/// Filters log entries based on a condition.
	/// </summary>
	/// <seealso href="http://nlog-project.org/wiki/FilteringWrapper_target">Documentation on NLog Wiki</seealso>
	/// <example>
	/// <p>This example causes the messages not contains the string '1' to be ignored.</p>
	/// <p>
	/// To set up the target in the <a href="config.html">configuration file</a>, 
	/// use the following syntax:
	/// </p>
	/// <code lang="XML" source="examples/targets/Configuration File/FilteringWrapper/NLog.config" />
	/// <p>
	/// The above examples assume just one target and a single rule. See below for
	/// a programmatic configuration that's equivalent to the above config file:
	/// </p>
	/// <code lang="C#" source="examples/targets/Configuration API/FilteringWrapper/Simple/Example.cs" />
	/// </example>
	// Token: 0x02000137 RID: 311
	[Target("FilteringWrapper", IsWrapper = true)]
	public class FilteringTargetWrapper : WrapperTargetBase
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Targets.Wrappers.FilteringTargetWrapper" /> class.
		/// </summary>
		// Token: 0x06000A49 RID: 2633 RVA: 0x00024934 File Offset: 0x00022B34
		public FilteringTargetWrapper()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Targets.Wrappers.FilteringTargetWrapper" /> class.
		/// </summary>
		/// <param name="wrappedTarget">The wrapped target.</param>
		/// <param name="condition">The condition.</param>
		// Token: 0x06000A4A RID: 2634 RVA: 0x0002493F File Offset: 0x00022B3F
		public FilteringTargetWrapper(Target wrappedTarget, ConditionExpression condition)
		{
			base.WrappedTarget = wrappedTarget;
			this.Condition = condition;
		}

		/// <summary>
		/// Gets or sets the condition expression. Log events who meet this condition will be forwarded 
		/// to the wrapped target.
		/// </summary>
		/// <docgen category="Filtering Options" order="10" />
		// Token: 0x17000234 RID: 564
		// (get) Token: 0x06000A4B RID: 2635 RVA: 0x0002495C File Offset: 0x00022B5C
		// (set) Token: 0x06000A4C RID: 2636 RVA: 0x00024973 File Offset: 0x00022B73
		[RequiredParameter]
		public ConditionExpression Condition { get; set; }

		/// <summary>
		/// Checks the condition against the passed log event.
		/// If the condition is met, the log event is forwarded to
		/// the wrapped target.
		/// </summary>
		/// <param name="logEvent">Log event.</param>
		// Token: 0x06000A4D RID: 2637 RVA: 0x0002497C File Offset: 0x00022B7C
		protected override void Write(AsyncLogEventInfo logEvent)
		{
			object obj = this.Condition.Evaluate(logEvent.LogEvent);
			if (FilteringTargetWrapper.boxedBooleanTrue.Equals(obj))
			{
				base.WrappedTarget.WriteAsyncLogEvent(logEvent);
			}
			else
			{
				logEvent.Continuation(null);
			}
		}

		// Token: 0x0400035B RID: 859
		private static readonly object boxedBooleanTrue = true;
	}
}
