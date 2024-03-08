using System;

namespace NLog.Layouts
{
	/// <summary>
	/// Specifies allowed column delimiters.
	/// </summary>
	// Token: 0x020000D8 RID: 216
	public enum CsvColumnDelimiterMode
	{
		/// <summary>
		/// Automatically detect from regional settings.
		/// </summary>
		// Token: 0x040001BB RID: 443
		Auto,
		/// <summary>
		/// Comma (ASCII 44).
		/// </summary>
		// Token: 0x040001BC RID: 444
		Comma,
		/// <summary>
		/// Semicolon (ASCII 59).
		/// </summary>
		// Token: 0x040001BD RID: 445
		Semicolon,
		/// <summary>
		/// Tab character (ASCII 9).
		/// </summary>
		// Token: 0x040001BE RID: 446
		Tab,
		/// <summary>
		/// Pipe character (ASCII 124).
		/// </summary>
		// Token: 0x040001BF RID: 447
		Pipe,
		/// <summary>
		/// Space character (ASCII 32).
		/// </summary>
		// Token: 0x040001C0 RID: 448
		Space,
		/// <summary>
		/// Custom string, specified by the CustomDelimiter.
		/// </summary>
		// Token: 0x040001C1 RID: 449
		Custom
	}
}
