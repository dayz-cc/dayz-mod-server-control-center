using System;
using System.ComponentModel;
using NLog.Config;

namespace NLog.Filters
{
	/// <summary>
	/// Matches when the calculated layout is equal to the specified substring.
	/// This filter is deprecated in favour of <c>&lt;when /&gt;</c> which is based on <a href="conditions.html">contitions</a>.
	/// </summary>
	// Token: 0x02000043 RID: 67
	[Filter("whenEqual")]
	public class WhenEqualFilter : LayoutBasedFilter
	{
		/// <summary>
		/// Gets or sets a value indicating whether to ignore case when comparing strings.
		/// </summary>
		/// <docgen category="Filtering Options" order="10" />
		// Token: 0x17000060 RID: 96
		// (get) Token: 0x060001CD RID: 461 RVA: 0x0000922C File Offset: 0x0000742C
		// (set) Token: 0x060001CE RID: 462 RVA: 0x00009243 File Offset: 0x00007443
		[DefaultValue(false)]
		public bool IgnoreCase { get; set; }

		/// <summary>
		/// Gets or sets a string to compare the layout to.
		/// </summary>
		/// <docgen category="Filtering Options" order="10" />
		// Token: 0x17000061 RID: 97
		// (get) Token: 0x060001CF RID: 463 RVA: 0x0000924C File Offset: 0x0000744C
		// (set) Token: 0x060001D0 RID: 464 RVA: 0x00009263 File Offset: 0x00007463
		[RequiredParameter]
		public string CompareTo { get; set; }

		/// <summary>
		/// Checks whether log event should be logged or not.
		/// </summary>
		/// <param name="logEvent">Log event.</param>
		/// <returns>
		/// <see cref="F:NLog.Filters.FilterResult.Ignore" /> - if the log event should be ignored<br />
		/// <see cref="F:NLog.Filters.FilterResult.Neutral" /> - if the filter doesn't want to decide<br />
		/// <see cref="F:NLog.Filters.FilterResult.Log" /> - if the log event should be logged<br />
		/// .</returns>
		// Token: 0x060001D1 RID: 465 RVA: 0x0000926C File Offset: 0x0000746C
		protected override FilterResult Check(LogEventInfo logEvent)
		{
			StringComparison stringComparison = (this.IgnoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);
			FilterResult filterResult;
			if (base.Layout.Render(logEvent).Equals(this.CompareTo, stringComparison))
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
