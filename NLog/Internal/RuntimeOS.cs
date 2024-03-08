using System;

namespace NLog.Internal
{
	/// <summary>
	/// Supported operating systems.
	/// </summary>
	/// <remarks>
	/// If you add anything here, make sure to add the appropriate detection
	/// code to <see cref="T:NLog.Internal.PlatformDetector" />
	/// </remarks>
	// Token: 0x02000084 RID: 132
	internal enum RuntimeOS
	{
		/// <summary>
		/// Any operating system.
		/// </summary>
		// Token: 0x040000D5 RID: 213
		Any,
		/// <summary>
		/// Unix/Linux operating systems.
		/// </summary>
		// Token: 0x040000D6 RID: 214
		Unix,
		/// <summary>
		/// Windows CE.
		/// </summary>
		// Token: 0x040000D7 RID: 215
		WindowsCE,
		/// <summary>
		/// Desktop versions of Windows (95,98,ME).
		/// </summary>
		// Token: 0x040000D8 RID: 216
		Windows,
		/// <summary>
		/// Windows NT, 2000, 2003 and future versions based on NT technology.
		/// </summary>
		// Token: 0x040000D9 RID: 217
		WindowsNT,
		/// <summary>
		/// Unknown operating system.
		/// </summary>
		// Token: 0x040000DA RID: 218
		Unknown
	}
}
