using System;

namespace NLog.Layouts
{
	/// <summary>
	/// Specifies allowes CSV quoting modes.
	/// </summary>
	// Token: 0x020000DD RID: 221
	public enum CsvQuotingMode
	{
		/// <summary>
		/// Quote all column.
		/// </summary>
		// Token: 0x040001D3 RID: 467
		All,
		/// <summary>
		/// Quote nothing.
		/// </summary>
		// Token: 0x040001D4 RID: 468
		Nothing,
		/// <summary>
		/// Quote only whose values contain the quote symbol or
		/// the separator.
		/// </summary>
		// Token: 0x040001D5 RID: 469
		Auto
	}
}
