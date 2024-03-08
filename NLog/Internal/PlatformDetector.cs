using System;

namespace NLog.Internal
{
	/// <summary>
	/// Detects the platform the NLog is running on.
	/// </summary>
	// Token: 0x0200007E RID: 126
	internal static class PlatformDetector
	{
		/// <summary>
		/// Gets the current runtime OS.
		/// </summary>
		// Token: 0x17000095 RID: 149
		// (get) Token: 0x06000319 RID: 793 RVA: 0x0000C314 File Offset: 0x0000A514
		public static RuntimeOS CurrentOS
		{
			get
			{
				return PlatformDetector.currentOS;
			}
		}

		/// <summary>
		/// Gets a value indicating whether current OS is a desktop version of Windows.
		/// </summary>
		// Token: 0x17000096 RID: 150
		// (get) Token: 0x0600031A RID: 794 RVA: 0x0000C32C File Offset: 0x0000A52C
		public static bool IsDesktopWin32
		{
			get
			{
				return PlatformDetector.currentOS == RuntimeOS.Windows || PlatformDetector.currentOS == RuntimeOS.WindowsNT;
			}
		}

		/// <summary>
		/// Gets a value indicating whether current OS is Win32-based (desktop or mobile).
		/// </summary>
		// Token: 0x17000097 RID: 151
		// (get) Token: 0x0600031B RID: 795 RVA: 0x0000C354 File Offset: 0x0000A554
		public static bool IsWin32
		{
			get
			{
				return PlatformDetector.currentOS == RuntimeOS.Windows || PlatformDetector.currentOS == RuntimeOS.WindowsNT || PlatformDetector.currentOS == RuntimeOS.WindowsCE;
			}
		}

		/// <summary>
		/// Gets a value indicating whether current OS is Unix-based.
		/// </summary>
		// Token: 0x17000098 RID: 152
		// (get) Token: 0x0600031C RID: 796 RVA: 0x0000C384 File Offset: 0x0000A584
		public static bool IsUnix
		{
			get
			{
				return PlatformDetector.currentOS == RuntimeOS.Unix;
			}
		}

		// Token: 0x0600031D RID: 797 RVA: 0x0000C3A0 File Offset: 0x0000A5A0
		private static RuntimeOS GetCurrentRuntimeOS()
		{
			PlatformID platform = Environment.OSVersion.Platform;
			RuntimeOS runtimeOS;
			if (platform == PlatformID.Unix || platform == (PlatformID)128)
			{
				runtimeOS = RuntimeOS.Unix;
			}
			else if (platform == PlatformID.WinCE)
			{
				runtimeOS = RuntimeOS.WindowsCE;
			}
			else if (platform == PlatformID.Win32Windows)
			{
				runtimeOS = RuntimeOS.Windows;
			}
			else if (platform == PlatformID.Win32NT)
			{
				runtimeOS = RuntimeOS.WindowsNT;
			}
			else
			{
				runtimeOS = RuntimeOS.Unknown;
			}
			return runtimeOS;
		}

		// Token: 0x040000CD RID: 205
		private static RuntimeOS currentOS = PlatformDetector.GetCurrentRuntimeOS();
	}
}
