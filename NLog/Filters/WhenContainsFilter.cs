using System;
using System.ComponentModel;
using NLog.Config;

namespace NLog.Filters
{
	/// <summary>
	/// Matches when the calculated layout contains the specified substring. 
	/// This filter is deprecated in favour of <c>&lt;when /&gt;</c> which is based on <a href="conditions.html">contitions</a>.
	/// </summary>
	// Token: 0x02000042 RID: 66
	[Filter("whenContains")]
	public class WhenContainsFilter : LayoutBasedFilter
	{
		/// <summary>
		/// Gets or sets a value indicating whether to ignore case when comparing strings.
		/// </summary>
		/// <docgen category="Filtering Options" order="10" />
		// Token: 0x1700005E RID: 94
		// (get) Token: 0x060001C7 RID: 455 RVA: 0x00009198 File Offset: 0x00007398
		// (set) Token: 0x060001C8 RID: 456 RVA: 0x000091AF File Offset: 0x000073AF
		[DefaultValue(false)]
		public bool IgnoreCase { get; set; }

		/// <summary>
		/// Gets or sets the substring to be matched.
		/// </summary>
		/// <docgen category="Filtering Options" order="10" />
		// Token: 0x1700005F RID: 95
		// (get) Token: 0x060001C9 RID: 457 RVA: 0x000091B8 File Offset: 0x000073B8
		// (set) Token: 0x060001CA RID: 458 RVA: 0x000091CF File Offset: 0x000073CF
		[RequiredParameter]
		public string Substring { get; set; }

		/// <summary>
		/// Checks whether log event should be logged or not.
		/// </summary>
		/// <param name="logEvent">Log event.</param>
		/// <returns>
		/// <see cref="F:NLog.Filters.FilterResult.Ignore" /> - if the log event should be ignored<br />
		/// <see cref="F:NLog.Filters.FilterResult.Neutral" /> - if the filter doesn't want to decide<br />
		/// <see cref="F:NLog.Filters.FilterResult.Log" /> - if the log event should be logged<br />
		/// .</returns>
		// Token: 0x060001CB RID: 459 RVA: 0x000091D8 File Offset: 0x000073D8
		protected override FilterResult Check(LogEventInfo logEvent)
		{
			StringComparison stringComparison = (this.IgnoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);
			FilterResult filterResult;
			if (base.Layout.Render(logEvent).IndexOf(this.Substring, stringComparison) >= 0)
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
