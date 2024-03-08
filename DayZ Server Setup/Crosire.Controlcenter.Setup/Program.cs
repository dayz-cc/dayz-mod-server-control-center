using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using NLog;

namespace Crosire.Controlcenter.Setup
{
	internal static class Program
	{
		private static Logger logger = LogManager.GetCurrentClassLogger();

		[STAThread]
		private static void Main()
		{
			AppDomain.CurrentDomain.UnhandledException += Application_UnhandledException;
			Application.ThreadException += Application_ThreadException;
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new frmSetup());
		}

		private static void Application_UnhandledException(object sender, UnhandledExceptionEventArgs e)
		{
			try
			{
				Exception ex = (Exception)e.ExceptionObject;
				logger.Log(LogLevel.Fatal, ex.ToString() + " [" + ex.Message + "]");
				if (ex.StackTrace != null)
				{
					logger.Log(LogLevel.Trace, ex.StackTrace);
				}
				MessageBox.Show("A fatal error occured! Please contact us with the following information:" + Environment.NewLine + Environment.NewLine + "Exception:" + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine + "StackTrace:" + Environment.NewLine + ex.StackTrace, "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			finally
			{
				Application.Exit();
			}
		}

		private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
		{
			logger.Log(LogLevel.Fatal, e.Exception.ToString() + " [" + e.Exception.Message + "]");
			if (e.Exception.StackTrace != null)
			{
				logger.Log(LogLevel.Trace, e.Exception.StackTrace);
			}
			if (e.Exception is FileNotFoundException || e.Exception is FileLoadException)
			{
				MessageBox.Show("A fatal error occured! One of the dependencies is missing:" + Environment.NewLine + Environment.NewLine + e.Exception.Message, "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				Application.Exit();
			}
			else if (MessageBox.Show("An error occured! Please contact us with the following information:" + Environment.NewLine + Environment.NewLine + "Exception:" + Environment.NewLine + e.Exception.Message + Environment.NewLine + Environment.NewLine + "StackTrace:" + Environment.NewLine + e.Exception.StackTrace, "Application Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Hand) == DialogResult.Abort)
			{
				Application.Exit();
			}
		}
	}
}
