using System;
using System.IO;
using System.Security;
using System.Text;
using System.Threading;

namespace NLog.Internal
{
	/// <summary>
	/// Win32-optimized implementation of <see cref="T:NLog.Internal.ThreadIDHelper" />.
	/// </summary>
	// Token: 0x02000093 RID: 147
	[SecuritySafeCritical]
	internal class Win32ThreadIDHelper : ThreadIDHelper
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Internal.Win32ThreadIDHelper" /> class.
		/// </summary>
		// Token: 0x06000367 RID: 871 RVA: 0x0000D67C File Offset: 0x0000B87C
		public Win32ThreadIDHelper()
		{
			this.currentProcessID = NativeMethods.GetCurrentProcessId();
			StringBuilder stringBuilder = new StringBuilder(512);
			if (0U == NativeMethods.GetModuleFileName(IntPtr.Zero, stringBuilder, stringBuilder.Capacity))
			{
				throw new InvalidOperationException("Cannot determine program name.");
			}
			this.currentProcessName = stringBuilder.ToString();
			this.currentProcessBaseName = Path.GetFileNameWithoutExtension(this.currentProcessName);
		}

		/// <summary>
		/// Gets current thread ID.
		/// </summary>
		/// <value></value>
		// Token: 0x170000A7 RID: 167
		// (get) Token: 0x06000368 RID: 872 RVA: 0x0000D6EC File Offset: 0x0000B8EC
		public override int CurrentThreadID
		{
			get
			{
				return Thread.CurrentThread.ManagedThreadId;
			}
		}

		/// <summary>
		/// Gets current process ID.
		/// </summary>
		/// <value></value>
		// Token: 0x170000A8 RID: 168
		// (get) Token: 0x06000369 RID: 873 RVA: 0x0000D708 File Offset: 0x0000B908
		public override int CurrentProcessID
		{
			get
			{
				return this.currentProcessID;
			}
		}

		/// <summary>
		/// Gets current process name.
		/// </summary>
		/// <value></value>
		// Token: 0x170000A9 RID: 169
		// (get) Token: 0x0600036A RID: 874 RVA: 0x0000D720 File Offset: 0x0000B920
		public override string CurrentProcessName
		{
			get
			{
				return this.currentProcessName;
			}
		}

		/// <summary>
		/// Gets current process name (excluding filename extension, if any).
		/// </summary>
		/// <value></value>
		// Token: 0x170000AA RID: 170
		// (get) Token: 0x0600036B RID: 875 RVA: 0x0000D738 File Offset: 0x0000B938
		public override string CurrentProcessBaseName
		{
			get
			{
				return this.currentProcessBaseName;
			}
		}

		// Token: 0x040000FE RID: 254
		private readonly int currentProcessID;

		// Token: 0x040000FF RID: 255
		private readonly string currentProcessName;

		// Token: 0x04000100 RID: 256
		private readonly string currentProcessBaseName;
	}
}
