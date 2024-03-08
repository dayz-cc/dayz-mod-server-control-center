using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Crosire.Controlcenter.Classes
{
	// Token: 0x02000004 RID: 4
	public static class SingleInstance
	{
		// Token: 0x06000023 RID: 35
		[DllImport("user32.dll")]
		private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

		// Token: 0x06000024 RID: 36
		[DllImport("user32.dll")]
		private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

		// Token: 0x06000025 RID: 37
		[DllImport("user32.dll")]
		private static extern bool SetForegroundWindow(IntPtr hWnd);

		// Token: 0x06000026 RID: 38 RVA: 0x00006B18 File Offset: 0x00004D18
		private static void ShowToFront(string windowName)
		{
			IntPtr intPtr = SingleInstance.FindWindow(null, windowName);
			SingleInstance.ShowWindow(intPtr, 1);
			SingleInstance.SetForegroundWindow(intPtr);
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00006B40 File Offset: 0x00004D40
		public static bool Start()
		{
			object[] customAttributes = Assembly.GetEntryAssembly().GetCustomAttributes(typeof(GuidAttribute), false);
			if (customAttributes.Length == 0)
			{
				SingleInstance.guid = string.Empty;
			}
			else
			{
				SingleInstance.guid = ((GuidAttribute)customAttributes[0]).Value;
			}
			bool flag = false;
			SingleInstance.mutex = new Mutex(true, SingleInstance.guid, out flag);
			return flag;
		}

		// Token: 0x06000028 RID: 40 RVA: 0x00006BAC File Offset: 0x00004DAC
		public static void ShowFirst()
		{
			SingleInstance.ShowToFront(Application.ProductName + " " + Application.ProductVersion);
		}

		// Token: 0x06000029 RID: 41 RVA: 0x00006BC9 File Offset: 0x00004DC9
		public static void Stop()
		{
			SingleInstance.mutex.ReleaseMutex();
		}

		// Token: 0x04000048 RID: 72
		private static Mutex mutex;

		// Token: 0x04000049 RID: 73
		internal static string guid;
	}
}
