using System;
using NLog.Config;

namespace NLog.Filters
{
	/// <summary>
	/// An abstract filter class. Provides a way to eliminate log messages
	/// based on properties other than logger name and log level.
	/// </summary>
	// Token: 0x0200003D RID: 61
	[NLogConfigurationItem]
	public abstract class Filter
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Filters.Filter" /> class.
		/// </summary>
		// Token: 0x060001B9 RID: 441 RVA: 0x000090A0 File Offset: 0x000072A0
		protected Filter()
		{
			this.Action = FilterResult.Neutral;
		}

		/// <summary>
		/// Gets or sets the action to be taken when filter matches.
		/// </summary>
		/// <docgen category="Filtering Options" order="10" />
		// Token: 0x1700005B RID: 91
		// (get) Token: 0x060001BA RID: 442 RVA: 0x000090B4 File Offset: 0x000072B4
		// (set) Token: 0x060001BB RID: 443 RVA: 0x000090CB File Offset: 0x000072CB
		[RequiredParameter]
		public FilterResult Action { get; set; }

		/// <summary>
		/// Gets the result of evaluating filter against given log event.
		/// </summary>
		/// <param name="logEvent">The log event.</param>
		/// <returns>Filter result.</returns>
		// Token: 0x060001BC RID: 444 RVA: 0x000090D4 File Offset: 0x000072D4
		internal FilterResult GetFilterResult(LogEventInfo logEvent)
		{
			return this.Check(logEvent);
		}

		/// <summary>
		/// Checks whether log event should be logged or not.
		/// </summary>
		/// <param name="logEvent">Log event.</param>
		/// <returns>
		/// <see cref="F:NLog.Filters.FilterResult.Ignore" /> - if the log event should be ignored<br />
		/// <see cref="F:NLog.Filters.FilterResult.Neutral" /> - if the filter doesn't want to decide<br />
		/// <see cref="F:NLog.Filters.FilterResult.Log" /> - if the log event should be logged<br />
		/// .</returns>
		// Token: 0x060001BD RID: 445
		protected abstract FilterResult Check(LogEventInfo logEvent);
	}
}
