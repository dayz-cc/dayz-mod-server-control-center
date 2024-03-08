using System;
using NLog.Conditions;
using NLog.Config;

namespace NLog.Filters
{
	/// <summary>
	/// Matches when the specified condition is met.
	/// </summary>
	/// <remarks>
	/// Conditions are expressed using a simple language 
	/// described <a href="conditions.html">here</a>.
	/// </remarks>
	// Token: 0x0200003E RID: 62
	[Filter("when")]
	public class ConditionBasedFilter : Filter
	{
		/// <summary>
		/// Gets or sets the condition expression.
		/// </summary>
		/// <docgen category="Filtering Options" order="10" />
		// Token: 0x1700005C RID: 92
		// (get) Token: 0x060001BE RID: 446 RVA: 0x000090F0 File Offset: 0x000072F0
		// (set) Token: 0x060001BF RID: 447 RVA: 0x00009107 File Offset: 0x00007307
		[RequiredParameter]
		public ConditionExpression Condition { get; set; }

		/// <summary>
		/// Checks whether log event should be logged or not.
		/// </summary>
		/// <param name="logEvent">Log event.</param>
		/// <returns>
		/// <see cref="F:NLog.Filters.FilterResult.Ignore" /> - if the log event should be ignored<br />
		/// <see cref="F:NLog.Filters.FilterResult.Neutral" /> - if the filter doesn't want to decide<br />
		/// <see cref="F:NLog.Filters.FilterResult.Log" /> - if the log event should be logged<br />
		/// .</returns>
		// Token: 0x060001C0 RID: 448 RVA: 0x00009110 File Offset: 0x00007310
		protected override FilterResult Check(LogEventInfo logEvent)
		{
			object obj = this.Condition.Evaluate(logEvent);
			FilterResult filterResult;
			if (ConditionBasedFilter.boxedTrue.Equals(obj))
			{
				filterResult = base.Action;
			}
			else
			{
				filterResult = FilterResult.Neutral;
			}
			return filterResult;
		}

		// Token: 0x0400008D RID: 141
		private static readonly object boxedTrue = true;
	}
}
