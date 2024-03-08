using System;

namespace NLog.Targets
{
	/// <summary>
	/// Colored console output color.
	/// </summary>
	/// <remarks>
	/// Note that this enumeration is defined to be binary compatible with 
	/// .NET 2.0 System.ConsoleColor + some additions
	/// </remarks>
	// Token: 0x02000107 RID: 263
	public enum ConsoleOutputColor
	{
		/// <summary>
		/// Black Color (#000000).
		/// </summary>
		// Token: 0x04000257 RID: 599
		Black,
		/// <summary>
		/// Dark blue Color (#000080).
		/// </summary>
		// Token: 0x04000258 RID: 600
		DarkBlue,
		/// <summary>
		/// Dark green Color (#008000).
		/// </summary>
		// Token: 0x04000259 RID: 601
		DarkGreen,
		/// <summary>
		/// Dark Cyan Color (#008080).
		/// </summary>
		// Token: 0x0400025A RID: 602
		DarkCyan,
		/// <summary>
		/// Dark Red Color (#800000).
		/// </summary>
		// Token: 0x0400025B RID: 603
		DarkRed,
		/// <summary>
		/// Dark Magenta Color (#800080).
		/// </summary>
		// Token: 0x0400025C RID: 604
		DarkMagenta,
		/// <summary>
		/// Dark Yellow Color (#808000).
		/// </summary>
		// Token: 0x0400025D RID: 605
		DarkYellow,
		/// <summary>
		/// Gray Color (#C0C0C0).
		/// </summary>
		// Token: 0x0400025E RID: 606
		Gray,
		/// <summary>
		/// Dark Gray Color (#808080).
		/// </summary>
		// Token: 0x0400025F RID: 607
		DarkGray,
		/// <summary>
		/// Blue Color (#0000FF).
		/// </summary>
		// Token: 0x04000260 RID: 608
		Blue,
		/// <summary>
		/// Green Color (#00FF00).
		/// </summary>
		// Token: 0x04000261 RID: 609
		Green,
		/// <summary>
		/// Cyan Color (#00FFFF).
		/// </summary>
		// Token: 0x04000262 RID: 610
		Cyan,
		/// <summary>
		/// Red Color (#FF0000).
		/// </summary>
		// Token: 0x04000263 RID: 611
		Red,
		/// <summary>
		/// Magenta Color (#FF00FF).
		/// </summary>
		// Token: 0x04000264 RID: 612
		Magenta,
		/// <summary>
		/// Yellow Color (#FFFF00).
		/// </summary>
		// Token: 0x04000265 RID: 613
		Yellow,
		/// <summary>
		/// White Color (#FFFFFF).
		/// </summary>
		// Token: 0x04000266 RID: 614
		White,
		/// <summary>
		/// Don't change the color.
		/// </summary>
		// Token: 0x04000267 RID: 615
		NoChange
	}
}
