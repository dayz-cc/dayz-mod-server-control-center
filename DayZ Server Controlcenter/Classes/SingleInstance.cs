using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace Crosire.Controlcenter.Classes
{
	public static class SingleInstance
	{
		private static Mutex mutex;

		internal static string guid;

		[DllImport("user32.dll")]
		private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

		[DllImport("user32.dll")]
		private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

		[DllImport("user32.dll")]
		private static extern bool SetForegroundWindow(IntPtr hWnd);

		private static void ShowToFront(string windowName)
		{
			IntPtr intPtr = FindWindow(null, windowName);
			ShowWindow(intPtr, 1);
			SetForegroundWindow(intPtr);
		}

		public static bool Start()
		{
			object[] customAttributes = Assembly.GetEntryAssembly().GetCustomAttributes(typeof(GuidAttribute), false);
			if (customAttributes.Length == 0)
			{
				guid = string.Empty;
			}
			else
			{
				guid = ((GuidAttribute)customAttributes[0]).Value;
			}
			bool createdNew = false;
			mutex = new Mutex(true, guid, out createdNew);
			return createdNew;
		}

		public static void ShowFirst()
		{
			ShowToFront(Application.ProductName + " " + Application.ProductVersion);
		}

		public static void Stop()
		{
			mutex.ReleaseMutex();
		}
	}
}
