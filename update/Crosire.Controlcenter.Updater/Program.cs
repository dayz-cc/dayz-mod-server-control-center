using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Crosire.Controlcenter.Updater
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			string startupPath = Application.StartupPath;
			string text = Path.Combine(startupPath, Path.GetFileNameWithoutExtension(Application.ExecutablePath));
			if (Directory.Exists(text) && (Directory.GetFiles(text).Length != 0 || Directory.GetDirectories(text).Length != 0))
			{
				Thread.Sleep(3000);
				try
				{
					string[] directories = Directory.GetDirectories(text, "*", SearchOption.AllDirectories);
					foreach (string text2 in directories)
					{
						if (!Directory.Exists(text2.Replace(text, startupPath)))
						{
							Directory.CreateDirectory(text2.Replace(text, startupPath));
						}
					}
					directories = Directory.GetFiles(text, "*.*", SearchOption.AllDirectories);
					foreach (string text3 in directories)
					{
						File.Copy(text3, text3.Replace(text, startupPath), true);
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("An error occured! Please contact us with the following information:" + Environment.NewLine + Environment.NewLine + "Exception:" + Environment.NewLine + ex.Message + Environment.NewLine + Environment.NewLine + "StackTrace:" + Environment.NewLine + ex.StackTrace, "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				finally
				{
					Directory.Delete(text, true);
				}
			}
			if (File.Exists(Path.Combine(startupPath, "DayZ Server Setup.exe")))
			{
				Process.Start(Path.Combine(startupPath, "DayZ Server Setup.exe"));
			}
		}
	}
}
