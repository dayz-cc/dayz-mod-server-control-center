using System;
using System.ComponentModel;
using NLog.Config;

namespace NLog.Filters
{
	/// <summary>
	/// Matches when the calculated layout is NOT equal to the specified substring.
	/// This filter is deprecated in favour of <c>&lt;when /&gt;</c> which is based on <a href="conditions.html">contitions</a>.
	/// </summary>
	// Token: 0x02000045 RID: 69
	[Filter("whenNotEqual")]
	public class WhenNotEqualFilter : LayoutBasedFilter
	{
		/// <summary>
		/// Gets or sets a string to compare the layout to.
		/// </summary>
		/// <docgen category="Filtering Options" order="10" />
		// Token: 0x17000064 RID: 100
		// (get) Token: 0x060001DA RID: 474 RVA: 0x00009364 File Offset: 0x00007564
		// (set) Token: 0x060001DB RID: 475 RVA: 0x0000937B File Offset: 0x0000757B
		[RequiredParameter]
		public string CompareTo { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether to ignore case when comparing strings.
		/// </summary>
		/// <docgen category="Filtering Options" order="10" />
		// Token: 0x17000065 RID: 101
		// (get) Token: 0x060001DC RID: 476 RVA: 0x00009384 File Offset: 0x00007584
		// (set) Token: 0x060001DD RID: 477 RVA: 0x0000939B File Offset: 0x0000759B
		[DefaultValue(false)]
		public bool IgnoreCase { get; set; }

		/// <summary>
		/// Checks whether log event should be logged or not.
		/// </summary>
		/// <param name="logEvent">Log event.</param>
		/// <returns>
		/// <see cref="F:NLog.Filters.FilterResult.Ignore" /> - if the log event should be ignored<br />
		/// <see cref="F:NLog.Filters.FilterResult.Neutral" /> - if the filter doesn't want to decide<br />
		/// <see cref="F:NLog.Filters.FilterResult.Log" /> - if the log event should be logged<br />
		/// .</returns>
		// Token: 0x060001DE RID: 478 RVA: 0x000093A4 File Offset: 0x000075A4
		protected override FilterResult Check(LogEventInfo logEvent)
		{
			StringComparison stringComparison = (this.IgnoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);
			FilterResult filterResult;
			if (!base.Layout.Render(logEvent).Equals(this.CompareTo, stringComparison))
			{
				filterResult = base.Action;
			}
			else
			{
				filterResult = FilterResult.Neutral;
			}
			return filterResult;
		}
	}
}
