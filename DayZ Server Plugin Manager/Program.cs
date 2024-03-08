using System;
using System.Windows.Forms;

namespace Crosire.Controlcenter.Plugin
{
	// Token: 0x02000005 RID: 5
	internal static class Program
	{
		// Token: 0x06000017 RID: 23 RVA: 0x000037C0 File Offset: 0x000019C0
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new frmMain());
		}
	}
}
