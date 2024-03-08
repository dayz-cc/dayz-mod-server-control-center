using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using NLog;

namespace Crosire.Controlcenter.Setup
{
	// Token: 0x02000007 RID: 7
	internal static class Program
	{
		// Token: 0x06000026 RID: 38 RVA: 0x0000645D File Offset: 0x0000465D
		[STAThread]
		private static void Main()
		{
			AppDomain.CurrentDomain.UnhandledException += Program.Application_UnhandledException;
			Application.ThreadException += Program.Application_ThreadException;
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new frmSetup());
		}

		// Token: 0x06000027 RID: 39 RVA: 0x0000649C File Offset: 0x0000469C
		private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
		{
			Program.logger.Log(LogLevel.Fatal, e.Exception.ToString() + " [" + e.Exception.Message + "]");
			if (e.Exception.StackTrace != null)
			{
				Program.logger.Log(LogLevel.Trace, e.Exception.StackTrace);
			}
			if (e.Exception is FileNotFoundException || e.Exception is FileLoadException)
			{
				MessageBox.Show("A fatal error occured! One of the dependencies is missing:" + Environment.NewLine + Environment.NewLine + e.Exception.Message, "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				Application.Exit();
				return;
			}
			if (MessageBox.Show(string.Concat(new string[]
			{
				"An error occured! Please contact us with the following information:",
				Environment.NewLine,
				Environment.NewLine,
				"Exception:",
				Environment.NewLine,
				e.Exception.Message,
				Environment.NewLine,
				Environment.NewLine,
				"StackTrace:",
				Environment.NewLine,
				e.Exception.StackTrace
			}), "Application Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Hand) == DialogResult.Abort)
			{
				Application.Exit();
			}
		}

		// Token: 0x06000028 RID: 40 RVA: 0x000065DC File Offset: 0x000047DC
		private static void Application_UnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			try
			{
				Exception ex = (Exception)e.ExceptionObject;
				Program.logger.Log(LogLevel.Fatal, ex.ToString() + " [" + ex.Message + "]");
				if (ex.StackTrace != null)
				{
					Program.logger.Log(LogLevel.Trace, ex.StackTrace);
				}
				MessageBox.Show(string.Concat(new string[]
				{
					"A fatal error occured! Please contact us with the following information:",
					Environment.NewLine,
					Environment.NewLine,
					"Exception:",
					Environment.NewLine,
					ex.Message,
					Environment.NewLine,
					Environment.NewLine,
					"StackTrace:",
					Environment.NewLine,
					ex.StackTrace
				}), "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			finally
			{
				Application.Exit();
			}
		}

		// Token: 0x04000059 RID: 89
		private static Logger logger = LogManager.GetCurrentClassLogger();
	}
}
