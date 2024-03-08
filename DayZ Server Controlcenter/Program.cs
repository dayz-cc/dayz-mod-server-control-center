using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Crosire.Controlcenter.Classes;
using NLog;

namespace Crosire.Controlcenter
{
	// Token: 0x0200000B RID: 11
	internal static class Program
	{
		// Token: 0x06000087 RID: 135 RVA: 0x0001888C File Offset: 0x00016A8C
		[STAThread]
		private static void Main(string[] args)
		{
			if (!SingleInstance.Start())
			{
				SingleInstance.ShowFirst();
			}
			Program.logger.Log(LogLevel.Info, "Application: Init [" + Application.ProductVersion + "]");
			AppDomain.CurrentDomain.UnhandledException += Program.Application_UnhandledException;
			Application.ThreadException += Program.Application_ThreadException;
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new frmMain());
			Program.logger.Log(LogLevel.Info, "Application: Exit");
			SingleInstance.Stop();
		}

		// Token: 0x06000088 RID: 136 RVA: 0x0001892C File Offset: 0x00016B2C
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
					"A fatal error occured! Please report it with the following information:",
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

		// Token: 0x06000089 RID: 137 RVA: 0x00018A2C File Offset: 0x00016C2C
		private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
		{
			if (e.Exception != null)
			{
				Exception exception = e.Exception;
				Program.logger.Log(LogLevel.Fatal, exception.ToString() + " [" + exception.Message + "]");
				if (exception.StackTrace != null)
				{
					Program.logger.Log(LogLevel.Trace, exception.StackTrace);
				}
				if (exception is FileNotFoundException || exception is FileLoadException)
				{
					MessageBox.Show("A fatal error occured! One of the dependencies is missing:" + Environment.NewLine + Environment.NewLine + exception.Message, "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					Application.Exit();
				}
				else if (MessageBox.Show(string.Concat(new string[]
				{
					"An error occured! Please report it with the following information:",
					Environment.NewLine,
					Environment.NewLine,
					"Exception:",
					Environment.NewLine,
					exception.Message,
					Environment.NewLine,
					Environment.NewLine,
					"StackTrace:",
					Environment.NewLine,
					exception.StackTrace
				}), "Application Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Hand) == DialogResult.Abort)
				{
					Application.Exit();
				}
			}
		}

		// Token: 0x04000150 RID: 336
		private static Logger logger = LogManager.GetCurrentClassLogger();
	}
}
