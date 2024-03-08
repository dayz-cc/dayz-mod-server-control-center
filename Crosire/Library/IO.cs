using System;
using System.Diagnostics;
using System.IO;

namespace Crosire.Library
{
	// Token: 0x02000004 RID: 4
	public class IO
	{
		// Token: 0x06000009 RID: 9 RVA: 0x00002170 File Offset: 0x00000370
		public static void CopyFolder(string srcpath, string destpath, bool subfolders, bool overwrite)
		{
			if (!Directory.Exists(destpath))
			{
				Directory.CreateDirectory(destpath);
			}
			string[] files = Directory.GetFiles(srcpath);
			for (int i = 0; i <= files.Length - 1; i++)
			{
				string text = files[i].Substring(files[i].LastIndexOf("\\") + 1);
				if (overwrite | !File.Exists(destpath + "\\" + text))
				{
					File.Copy(files[i], destpath + "\\" + text, true);
				}
			}
			if (subfolders)
			{
				string[] directories = Directory.GetDirectories(srcpath);
				for (int j = 0; j <= directories.Length - 1; j++)
				{
					if (directories[j] != destpath)
					{
						string text2 = directories[j].Substring(directories[j].LastIndexOf("\\") + 1);
						IO.CopyFolder(directories[j], destpath + "\\" + text2, true, overwrite);
					}
				}
			}
		}

		// Token: 0x0600000A RID: 10 RVA: 0x0000224A File Offset: 0x0000044A
		public static string GetFileVersion(string path)
		{
			if (File.Exists(path))
			{
				return FileVersionInfo.GetVersionInfo(path).ProductVersion;
			}
			return null;
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002264 File Offset: 0x00000464
		public static object GetNewLines(string path)
		{
			string text = string.Empty;
			DateTime lastWriteTime = File.GetLastWriteTime(path);
			if (File.Exists(path))
			{
				try
				{
					using (FileStream fileStream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
					{
						IO.lNewLength = fileStream.Length;
						if (IO.lNewLength >= IO.lLastFileSize)
						{
							fileStream.Position = IO.lLastFileSize;
						}
						using (StreamReader streamReader = new StreamReader(fileStream))
						{
							text = streamReader.ReadToEnd();
						}
					}
				}
				catch
				{
				}
			}
			IO.lLastFileSize = IO.lNewLength;
			IO.lLastFileSize.ToString();
			lastWriteTime.ToShortDateString() + " " + lastWriteTime.ToLongTimeString();
			if (text.Length == 0)
			{
				int num = text.LastIndexOf("\r");
				if (((-1 == num) & (0 < num)) && text[num - 1] == '\r')
				{
					text = text.Replace("\r", "\r\n");
				}
			}
			return text;
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00002378 File Offset: 0x00000578
		public static bool GetProcessState(string name)
		{
			foreach (Process process in Process.GetProcesses())
			{
				if (process.ProcessName.StartsWith(name))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x04000001 RID: 1
		public static long lLastFileSize;

		// Token: 0x04000002 RID: 2
		public static long lNewLength;
	}
}
