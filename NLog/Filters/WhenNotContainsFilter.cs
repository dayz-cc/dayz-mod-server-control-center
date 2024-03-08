using System;
using System.ComponentModel;
using NLog.Config;

namespace NLog.Filters
{
	/// <summary>
	/// Matches when the calculated layout does NOT contain the specified substring.
	/// This filter is deprecated in favour of <c>&lt;when /&gt;</c> which is based on <a href="conditions.html">contitions</a>.
	/// </summary>
	// Token: 0x02000044 RID: 68
	[Filter("whenNotContains")]
	public class WhenNotContainsFilter : LayoutBasedFilter
	{
		/// <summary>
		/// Gets or sets the substring to be matched.
		/// </summary>
		/// <docgen category="Filtering Options" order="10" />
		// Token: 0x17000062 RID: 98
		// (get) Token: 0x060001D3 RID: 467 RVA: 0x000092C0 File Offset: 0x000074C0
		// (set) Token: 0x060001D4 RID: 468 RVA: 0x000092D7 File Offset: 0x000074D7
		[RequiredParameter]
		public string Substring { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether to ignore case when comparing strings.
		/// </summary>
		/// <docgen category="Filtering Options" order="10" />
		// Token: 0x17000063 RID: 99
		// (get) Token: 0x060001D5 RID: 469 RVA: 0x000092E0 File Offset: 0x000074E0
		// (set) Token: 0x060001D6 RID: 470 RVA: 0x000092F7 File Offset: 0x000074F7
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
		// Token: 0x060001D7 RID: 471 RVA: 0x00009300 File Offset: 0x00007500
		protected override FilterResult Check(LogEventInfo logEvent)
		{
			StringComparison stringComparison = (this.IgnoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);
			string text = base.Layout.Render(logEvent);
			FilterResult filterResult;
			if (text.IndexOf(this.Substring, stringComparison) < 0)
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
