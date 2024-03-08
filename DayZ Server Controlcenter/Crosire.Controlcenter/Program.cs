using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Crosire.Controlcenter.Classes;
using NLog;

namespace Crosire.Controlcenter
{
	internal static class Program
	{
		private static Logger logger = LogManager.GetCurrentClassLogger();

		[STAThread]
		private static void Main(string[] args)
		{
			if (!SingleInstance.Start())
			{
				SingleInstance.ShowFirst();
			}
			logger.Log(LogLevel.Info, "Application: Init [" + Application.ProductVersion + "]");
			AppDomain.CurrentDomain.UnhandledException += Application_UnhandledException;
			Application.ThreadException += Application_ThreadException;
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new frmMain());
			logger.Log(LogLevel.Info, "Application: Exit");
			SingleInstance.Stop();
		}

		private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
		{
			if (e.Exception != null)
			{
				Exception exception = e.Exception;
				logger.Log(LogLevel.Fatal, exception.ToString() + " [" + exception.Message + "]");
				if (exception.StackTrace != null)
				{
					logger.Log(LogLevel.Trace, exception.StackTrace);
				}
				if (exception is FileNotFoundException || exception is FileLoadException)
				{
					MessageBox.Show("A fatal error occured! One of the dependencies is missing:" + Environment.NewLine + Environment.NewLine + exception.Message, "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					Application.Exit();
				}
				else if (MessageBox.Show("An error occured! Please report it with the following information:" + Environment.NewLine + Environment.NewLine + "Exception:" + Environment.NewLine + exception.Message + Environment.NewLine + Environment.NewLine + "StackTrace:" + Environment.NewLine + exception.StackTrace, "Application Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Hand) == DialogResult.Abort)
				{
					Application.Exit();
				}
			}
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
				MessageBox.Show("A fatal error occured! Please report it with the following information:" + Environment.NewLine + Environment.NewLine + "Exception:" + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine + "StackTrace:" + Environment.NewLine + ex.StackTrace, "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			finally
			{
				Application.Exit();
			}
		}
	}
}
