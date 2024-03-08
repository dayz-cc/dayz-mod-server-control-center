using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SmartAssembly.MemoryManagement
{
	// Token: 0x0200000F RID: 15
	public sealed class MemoryManager
	{
		// Token: 0x0600011C RID: 284
		[DllImport("kernel32", EntryPoint = "SetProcessWorkingSetSize")]
		private static extern int \u0001(IntPtr \u0002, int \u0003, int \u0004);

		// Token: 0x0600011D RID: 285 RVA: 0x00010604 File Offset: 0x0000E804
		private void \u0001()
		{
			try
			{
				using (Process currentProcess = Process.GetCurrentProcess())
				{
					MemoryManager.\u0001(currentProcess.Handle, -1, -1);
				}
			}
			catch
			{
			}
		}

		// Token: 0x0600011E RID: 286 RVA: 0x00010654 File Offset: 0x0000E854
		private void \u0001(object \u0002, EventArgs \u0003)
		{
			try
			{
				long ticks = DateTime.Now.Ticks;
				if (ticks - this.\u0001 > 10000000L)
				{
					this.\u0001 = ticks;
					this.\u0001();
				}
			}
			catch
			{
			}
		}

		// Token: 0x0600011F RID: 287 RVA: 0x000106A4 File Offset: 0x0000E8A4
		private MemoryManager()
		{
			Application.Idle += this.\u0001;
			this.\u0001();
		}

		// Token: 0x06000120 RID: 288 RVA: 0x000106E4 File Offset: 0x0000E8E4
		public static void AttachApp()
		{
			try
			{
				if (Environment.OSVersion.Platform == PlatformID.Win32NT)
				{
					MemoryManager.\u0001 = new MemoryManager();
				}
			}
			catch
			{
			}
		}

		// Token: 0x040000A9 RID: 169
		private static MemoryManager \u0001;

		// Token: 0x040000AA RID: 170
		private long \u0001 = DateTime.Now.Ticks;
	}
}
