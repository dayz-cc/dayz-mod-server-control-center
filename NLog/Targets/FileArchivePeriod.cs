using System;

namespace NLog.Targets
{
	/// <summary>
	/// Modes of archiving files based on time.
	/// </summary>
	// Token: 0x02000111 RID: 273
	public enum FileArchivePeriod
	{
		/// <summary>
		/// Don't archive based on time.
		/// </summary>
		// Token: 0x0400029B RID: 667
		None,
		/// <summary>
		/// Archive every year.
		/// </summary>
		// Token: 0x0400029C RID: 668
		Year,
		/// <summary>
		/// Archive every month.
		/// </summary>
		// Token: 0x0400029D RID: 669
		Month,
		/// <summary>
		/// Archive daily.
		/// </summary>
		// Token: 0x0400029E RID: 670
		Day,
		/// <summary>
		/// Archive every hour.
		/// </summary>
		// Token: 0x0400029F RID: 671
		Hour,
		/// <summary>
		/// Archive every minute.
		/// </summary>
		// Token: 0x040002A0 RID: 672
		Minute
	}
}
