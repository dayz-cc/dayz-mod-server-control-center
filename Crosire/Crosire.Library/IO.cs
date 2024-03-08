using System;
using System.Diagnostics;
using System.IO;

namespace Crosire.Library
{
	public class IO
	{
		public static long lLastFileSize;

		public static long lNewLength;

		public static void CopyFolder(string srcpath, string destpath, bool subfolders, bool overwrite)
		{
			if (!Directory.Exists(destpath))
			{
				Directory.CreateDirectory(destpath);
			}
			string[] files = Directory.GetFiles(srcpath);
			string text = null;
			for (int i = 0; i <= files.Length - 1; i++)
			{
				text = files[i].Substring(files[i].LastIndexOf("\\") + 1);
				if (overwrite | !File.Exists(destpath + "\\" + text))
				{
					File.Copy(files[i], destpath + "\\" + text, true);
				}
			}
			if (!subfolders)
			{
				return;
			}
			string[] directories = Directory.GetDirectories(srcpath);
			string text2 = null;
			for (int j = 0; j <= directories.Length - 1; j++)
			{
				if (directories[j] != destpath)
				{
					text2 = directories[j].Substring(directories[j].LastIndexOf("\\") + 1);
					CopyFolder(directories[j], destpath + "\\" + text2, true, overwrite);
				}
			}
		}

		public static string GetFileVersion(string path)
		{
			if (File.Exists(path))
			{
				return FileVersionInfo.GetVersionInfo(path).ProductVersion;
			}
			return null;
		}

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
						lNewLength = fileStream.Length;
						if (lNewLength >= lLastFileSize)
						{
							fileStream.Position = lLastFileSize;
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
			lLastFileSize = lNewLength;
			lLastFileSize.ToString();
			string text2 = lastWriteTime.ToShortDateString() + " " + lastWriteTime.ToLongTimeString();
			if (text.Length == 0)
			{
				int num = text.LastIndexOf("\r");
				if (-1 == num && 0 < num && text[num - 1] == '\r')
				{
					text = text.Replace("\r", "\r\n");
				}
			}
			return text;
		}

		public static bool GetProcessState(string name)
		{
			Process[] processes = Process.GetProcesses();
			foreach (Process process in processes)
			{
				if (process.ProcessName.StartsWith(name))
				{
					return true;
				}
			}
			return false;
		}
	}
}
