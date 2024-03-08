using System;

namespace NLog.Internal
{
	/// <summary>
	/// Returns details about current process and thread in a portable manner.
	/// </summary>
	// Token: 0x02000080 RID: 128
	internal abstract class ThreadIDHelper
	{
		/// <summary>
		/// Initializes static members of the ThreadIDHelper class.
		/// </summary>
		// Token: 0x06000321 RID: 801 RVA: 0x0000C474 File Offset: 0x0000A674
		static ThreadIDHelper()
		{
			if (PlatformDetector.IsWin32)
			{
				ThreadIDHelper.Instance = new Win32ThreadIDHelper();
			}
			else
			{
				ThreadIDHelper.Instance = new PortableThreadIDHelper();
			}
		}

		/// <summary>
		/// Gets the singleton instance of PortableThreadIDHelper or
		/// Win32ThreadIDHelper depending on runtime environment.
		/// </summary>
		/// <value>The instance.</value>
		// Token: 0x17000099 RID: 153
		// (get) Token: 0x06000322 RID: 802 RVA: 0x0000C4AC File Offset: 0x0000A6AC
		// (set) Token: 0x06000323 RID: 803 RVA: 0x0000C4C2 File Offset: 0x0000A6C2
		public static ThreadIDHelper Instance { get; private set; }

		/// <summary>
		/// Gets current thread ID.
		/// </summary>
		// Token: 0x1700009A RID: 154
		// (get) Token: 0x06000324 RID: 804
		public abstract int CurrentThreadID { get; }

		/// <summary>
		/// Gets current process ID.
		/// </summary>
		// Token: 0x1700009B RID: 155
		// (get) Token: 0x06000325 RID: 805
		public abstract int CurrentProcessID { get; }

		/// <summary>
		/// Gets current process name.
		/// </summary>
		// Token: 0x1700009C RID: 156
		// (get) Token: 0x06000326 RID: 806
		public abstract string CurrentProcessName { get; }

		/// <summary>
		/// Gets current process name (excluding filename extension, if any).
		/// </summary>
		// Token: 0x1700009D RID: 157
		// (get) Token: 0x06000327 RID: 807
		public abstract string CurrentProcessBaseName { get; }
	}
}
