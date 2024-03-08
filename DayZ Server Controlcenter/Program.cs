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
		// Token: 0x06000084 RID: 132 RVA: 0x000184F4 File Offset: 0x000166F4
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

		// Token: 0x06000085 RID: 133 RVA: 0x00018594 File Offset: 0x00016794
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

		// Token: 0x06000086 RID: 134 RVA: 0x000186E8 File Offset: 0x000168E8
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

		// Token: 0x0400014D RID: 333
		private static Logger logger = LogManager.GetCurrentClassLogger();
	}
}
