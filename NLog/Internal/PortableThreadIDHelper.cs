using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace NLog.Internal
{
	/// <summary>
	/// Portable implementation of <see cref="T:NLog.Internal.ThreadIDHelper" />.
	/// </summary>
	// Token: 0x02000081 RID: 129
	internal class PortableThreadIDHelper : ThreadIDHelper
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Internal.PortableThreadIDHelper" /> class.
		/// </summary>
		// Token: 0x06000329 RID: 809 RVA: 0x0000C4D2 File Offset: 0x0000A6D2
		public PortableThreadIDHelper()
		{
			this.currentProcessID = Process.GetCurrentProcess().Id;
		}

		/// <summary>
		/// Gets current thread ID.
		/// </summary>
		/// <value></value>
		// Token: 0x1700009E RID: 158
		// (get) Token: 0x0600032A RID: 810 RVA: 0x0000C4F0 File Offset: 0x0000A6F0
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
		// Token: 0x1700009F RID: 159
		// (get) Token: 0x0600032B RID: 811 RVA: 0x0000C50C File Offset: 0x0000A70C
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
		// Token: 0x170000A0 RID: 160
		// (get) Token: 0x0600032C RID: 812 RVA: 0x0000C524 File Offset: 0x0000A724
		public override string CurrentProcessName
		{
			get
			{
				this.GetProcessName();
				return this.currentProcessName;
			}
		}

		/// <summary>
		/// Gets current process name (excluding filename extension, if any).
		/// </summary>
		/// <value></value>
		// Token: 0x170000A1 RID: 161
		// (get) Token: 0x0600032D RID: 813 RVA: 0x0000C544 File Offset: 0x0000A744
		public override string CurrentProcessBaseName
		{
			get
			{
				this.GetProcessName();
				return this.currentProcessBaseName;
			}
		}

		/// <summary>
		/// Gets the name of the process.
		/// </summary>
		// Token: 0x0600032E RID: 814 RVA: 0x0000C564 File Offset: 0x0000A764
		private void GetProcessName()
		{
			if (this.currentProcessName == null)
			{
				try
				{
					this.currentProcessName = Process.GetCurrentProcess().MainModule.FileName;
				}
				catch (Exception ex)
				{
					if (ex.MustBeRethrown())
					{
						throw;
					}
					this.currentProcessName = "<unknown>";
				}
				this.currentProcessBaseName = Path.GetFileNameWithoutExtension(this.currentProcessName);
			}
		}

		// Token: 0x040000CF RID: 207
		private const string UnknownProcessName = "<unknown>";

		// Token: 0x040000D0 RID: 208
		private readonly int currentProcessID;

		// Token: 0x040000D1 RID: 209
		private string currentProcessName;

		// Token: 0x040000D2 RID: 210
		private string currentProcessBaseName;
	}
}
