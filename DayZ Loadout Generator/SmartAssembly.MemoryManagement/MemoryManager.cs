using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SmartAssembly.MemoryManagement
{
	public sealed class MemoryManager
	{
		private static MemoryManager m__0001;

		private long m__0001 = DateTime.Now.Ticks;

		[DllImport("kernel32", EntryPoint = "SetProcessWorkingSetSize")]
		private static extern int _0001(IntPtr _0002, int _0003, int _0004);

		private void _0001()
		{
			try
			{
				using (Process process = Process.GetCurrentProcess())
				{
					_0001(process.Handle, -1, -1);
				}
			}
			catch
			{
			}
		}

		private void _0001(object _0002, EventArgs _0003)
		{
			try
			{
				long ticks = DateTime.Now.Ticks;
				if (ticks - this.m__0001 > 10000000)
				{
					this.m__0001 = ticks;
					_0001();
				}
			}
			catch
			{
			}
		}

		private MemoryManager()
		{
			Application.Idle += _0001;
			_0001();
		}

		public static void AttachApp()
		{
			try
			{
				if (Environment.OSVersion.Platform == PlatformID.Win32NT)
				{
					MemoryManager.m__0001 = new MemoryManager();
				}
			}
			catch
			{
			}
		}
	}
}
