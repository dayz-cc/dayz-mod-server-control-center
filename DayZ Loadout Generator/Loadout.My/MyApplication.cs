using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.VisualBasic.ApplicationServices;
using SmartAssembly.MemoryManagement;

namespace Loadout.My
{
	[EditorBrowsable(EditorBrowsableState.Never)]
	[GeneratedCode("MyTemplate", "8.0.0.0")]
	internal sealed class MyApplication : WindowsFormsApplicationBase
	{
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		[DebuggerHidden]
		[STAThread]
		internal static void Main(string[] Args)
		{
			try
			{
				MemoryManager.AttachApp();
				Application.SetCompatibleTextRenderingDefault(WindowsFormsApplicationBase.UseCompatibleTextRendering);
			}
			finally
			{
			}
			MyProject.Application.Run(Args);
		}

		[DebuggerStepThrough]
		public MyApplication()
			: base(AuthenticationMode.Windows)
		{
			IsSingleInstance = false;
			EnableVisualStyles = true;
			SaveMySettingsOnExit = true;
			ShutdownStyle = ShutdownMode.AfterMainFormCloses;
		}

		[DebuggerStepThrough]
		protected override void OnCreateMainForm()
		{
			MainForm = MyProject.Forms.frmMain;
		}
	}
}
