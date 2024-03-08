using System;

namespace NLog.Targets
{
	/// <summary>
	/// Line ending mode.
	/// </summary>
	// Token: 0x02000116 RID: 278
	public enum LineEndingMode
	{
		/// <summary>
		/// Insert platform-dependent end-of-line sequence after each line.
		/// </summary>
		// Token: 0x040002C7 RID: 711
		Default,
		/// <summary>
		/// Insert CR LF sequence (ASCII 13, ASCII 10) after each line.
		/// </summary>
		// Token: 0x040002C8 RID: 712
		CRLF,
		/// <summary>
		/// Insert CR character (ASCII 13) after each line.
		/// </summary>
		// Token: 0x040002C9 RID: 713
		CR,
		/// <summary>
		/// Insert LF character (ASCII 10) after each line.
		/// </summary>
		// Token: 0x040002CA RID: 714
		LF,
		/// <summary>
		/// Don't insert any line ending.
		/// </summary>
		// Token: 0x040002CB RID: 715
		None
	}
}
