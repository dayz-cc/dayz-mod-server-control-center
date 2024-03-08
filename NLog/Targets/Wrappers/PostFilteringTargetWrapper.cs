using System;
using System.Collections.Generic;
using NLog.Common;
using NLog.Conditions;
using NLog.Config;

namespace NLog.Targets.Wrappers
{
	/// <summary>
	/// Filters buffered log entries based on a set of conditions that are evaluated on a group of events.
	/// </summary>
	/// <seealso href="http://nlog-project.org/wiki/PostFilteringWrapper_target">Documentation on NLog Wiki</seealso>
	/// <remarks>
	/// PostFilteringWrapper must be used with some type of buffering target or wrapper, such as
	/// AsyncTargetWrapper, BufferingWrapper or ASPNetBufferingWrapper.
	/// </remarks>
	/// <example>
	/// <p>
	/// This example works like this. If there are no Warn,Error or Fatal messages in the buffer
	/// only Info messages are written to the file, but if there are any warnings or errors, 
	/// the output includes detailed trace (levels &gt;= Debug). You can plug in a different type
	/// of buffering wrapper (such as ASPNetBufferingWrapper) to achieve different
	/// functionality.
	/// </p>
	/// <p>
	/// To set up the target in the <a href="config.html">configuration file</a>, 
	/// use the following syntax:
	/// </p>
	/// <code lang="XML" source="examples/targets/Configuration File/PostFilteringWrapper/NLog.config" />
	/// <p>
	/// The above examples assume just one target and a single rule. See below for
	/// a programmatic configuration that's equivalent to the above config file:
	/// </p>
	/// <code lang="C#" source="examples/targets/Configuration API/PostFilteringWrapper/Simple/Example.cs" />
	/// </example>
	// Token: 0x0200013B RID: 315
	[Target("PostFilteringWrapper", IsWrapper = true)]
	public class PostFilteringTargetWrapper : WrapperTargetBase
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Targets.Wrappers.PostFilteringTargetWrapper" /> class.
		/// </summary>
		// Token: 0x06000A68 RID: 2664 RVA: 0x00024DCA File Offset: 0x00022FCA
		public PostFilteringTargetWrapper()
		{
			this.Rules = new List<FilteringRule>();
		}

		/// <summary>
		/// Gets or sets the default filter to be applied when no specific rule matches.
		/// </summary>
		/// <docgen category="Filtering Options" order="10" />
		// Token: 0x1700023C RID: 572
		// (get) Token: 0x06000A69 RID: 2665 RVA: 0x00024DE4 File Offset: 0x00022FE4
		// (set) Token: 0x06000A6A RID: 2666 RVA: 0x00024DFB File Offset: 0x00022FFB
		public ConditionExpression DefaultFilter { get; set; }

		/// <summary>
		/// Gets the collection of filtering rules. The rules are processed top-down
		/// and the first rule that matches determines the filtering condition to
		/// be applied to log events.
		/// </summary>
		/// <docgen category="Filtering Rules" order="10" />
		// Token: 0x1700023D RID: 573
		// (get) Token: 0x06000A6B RID: 2667 RVA: 0x00024E04 File Offset: 0x00023004
		// (set) Token: 0x06000A6C RID: 2668 RVA: 0x00024E1B File Offset: 0x0002301B
		[ArrayParameter(typeof(FilteringRule), "when")]
		public IList<FilteringRule> Rules { get; private set; }

		/// <summary>
		/// Evaluates all filtering rules to find the first one that matches.
		/// The matching rule determines the filtering condition to be applied
		/// to all items in a buffer. If no condition matches, default filter
		/// is applied to the array of log events.
		/// </summary>
		/// <param name="logEvents">Array of log events to be post-filtered.</param>
		// Token: 0x06000A6D RID: 2669 RVA: 0x00024E24 File Offset: 0x00023024
		protected override void Write(AsyncLogEventInfo[] logEvents)
		{
			ConditionExpression conditionExpression = null;
			InternalLogger.Trace("Running {0} on {1} events", new object[] { this, logEvents.Length });
			for (int i = 0; i < logEvents.Length; i++)
			{
				foreach (FilteringRule filteringRule in this.Rules)
				{
					object obj = filteringRule.Exists.Evaluate(logEvents[i].LogEvent);
					if (PostFilteringTargetWrapper.boxedTrue.Equals(obj))
					{
						InternalLogger.Trace("Rule matched: {0}", new object[] { filteringRule.Exists });
						conditionExpression = filteringRule.Filter;
						break;
					}
				}
				if (conditionExpression != null)
				{
					break;
				}
			}
			if (conditionExpression == null)
			{
				conditionExpression = this.DefaultFilter;
			}
			if (conditionExpression == null)
			{
				base.WrappedTarget.WriteAsyncLogEvents(logEvents);
			}
			else
			{
				InternalLogger.Trace("Filter to apply: {0}", new object[] { conditionExpression });
				List<AsyncLogEventInfo> list = new List<AsyncLogEventInfo>();
				for (int i = 0; i < logEvents.Length; i++)
				{
					object obj = conditionExpression.Evaluate(logEvents[i].LogEvent);
					if (PostFilteringTargetWrapper.boxedTrue.Equals(obj))
					{
						list.Add(logEvents[i]);
					}
					else
					{
						logEvents[i].Continuation(null);
					}
				}
				InternalLogger.Trace("After filtering: {0} events.", new object[] { list.Count });
				if (list.Count > 0)
				{
					InternalLogger.Trace("Sending to {0}", new object[] { base.WrappedTarget });
					base.WrappedTarget.WriteAsyncLogEvents(list.ToArray());
				}
			}
		}

		// Token: 0x04000369 RID: 873
		private static object boxedTrue = true;
	}
}
