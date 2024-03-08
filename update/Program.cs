using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Crosire.Controlcenter.Updater
{
	// Token: 0x02000002 RID: 2
	internal class Program
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		private static void Main(string[] args)
		{
			string startupPath = Application.StartupPath;
			string text = Path.Combine(startupPath, Path.GetFileNameWithoutExtension(Application.ExecutablePath));
			if (Directory.Exists(text))
			{
				if (Directory.GetFiles(text).Length != 0 || Directory.GetDirectories(text).Length != 0)
				{
					Thread.Sleep(3000);
					try
					{
						foreach (string text2 in Directory.GetDirectories(text, "*", SearchOption.AllDirectories))
						{
							if (!Directory.Exists(text2.Replace(text, startupPath)))
							{
								Directory.CreateDirectory(text2.Replace(text, startupPath));
							}
						}
						foreach (string text3 in Directory.GetFiles(text, "*.*", SearchOption.AllDirectories))
						{
							File.Copy(text3, text3.Replace(text, startupPath), true);
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show(string.Concat(new string[]
						{
							"An error occured! Please contact us with the following information:",
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
						}), "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					}
					finally
					{
						Directory.Delete(text, true);
					}
				}
			}
			if (File.Exists(Path.Combine(startupPath, "DayZ Server Setup.exe")))
			{
				Process.Start(Path.Combine(startupPath, "DayZ Server Setup.exe"));
			}
		}
	}
}
