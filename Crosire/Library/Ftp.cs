using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace Crosire.Library
{
	// Token: 0x02000006 RID: 6
	public class Ftp
	{
		// Token: 0x06000015 RID: 21 RVA: 0x0000257C File Offset: 0x0000077C
		public static List<Ftp.FtpData> DownloadList(string requestUri, DirectoryInfo workingDirectory, bool recursive)
		{
			List<Ftp.FtpData> list = new List<Ftp.FtpData>();
			List<Ftp.FtpData> list2 = new List<Ftp.FtpData>();
			FtpWebRequest ftpWebRequest = (FtpWebRequest)WebRequest.Create(requestUri);
			ftpWebRequest.Proxy = new WebProxy();
			ftpWebRequest.Method = "LIST";
			ftpWebRequest.KeepAlive = false;
			using (FtpWebResponse ftpWebResponse = (FtpWebResponse)ftpWebRequest.GetResponse())
			{
				using (Stream responseStream = ftpWebResponse.GetResponseStream())
				{
					using (StreamReader streamReader = new StreamReader(responseStream))
					{
						while (!streamReader.EndOfStream)
						{
							string text = streamReader.ReadLine();
							if (text.ToLower().Contains("<dir>"))
							{
								string entryName = Ftp.GetEntryName(text);
								if (entryName != "." && entryName != ".." && recursive)
								{
									DirectoryInfo directoryInfo = Directory.CreateDirectory(workingDirectory.FullName + "\\" + entryName);
									list2.Add(new Ftp.FtpData(requestUri + "/" + entryName, "", directoryInfo));
								}
							}
							else
							{
								list.Add(new Ftp.FtpData(requestUri + "/" + Ftp.GetEntryName(text), Ftp.GetEntryName(text), workingDirectory));
							}
						}
					}
				}
			}
			foreach (Ftp.FtpData ftpData in list2)
			{
				list.AddRange(Ftp.DownloadList(ftpData.requestUri, ftpData.directory, true));
			}
			return list;
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002734 File Offset: 0x00000934
		public static void DownloadFileAsync(Ftp.FtpData file)
		{
			Ftp.DownloadFileAsync(file, new DownloadProgressChangedEventHandler(Ftp.wDownloadProgressChanged), new DownloadDataCompletedEventHandler(Ftp.wDownloadDataCompleted));
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002754 File Offset: 0x00000954
		public static void DownloadFileAsync(Ftp.FtpData file, DownloadProgressChangedEventHandler fChanged)
		{
			Ftp.DownloadFileAsync(file, fChanged, new DownloadDataCompletedEventHandler(Ftp.wDownloadDataCompleted));
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002769 File Offset: 0x00000969
		public static void DownloadFileAsync(Ftp.FtpData file, DownloadDataCompletedEventHandler fCompleted)
		{
			Ftp.DownloadFileAsync(file, new DownloadProgressChangedEventHandler(Ftp.wDownloadProgressChanged), fCompleted);
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00002780 File Offset: 0x00000980
		public static void DownloadFileAsync(Ftp.FtpData file, DownloadProgressChangedEventHandler fChanged, DownloadDataCompletedEventHandler fCompleted)
		{
			FtpWebRequest ftpWebRequest = WebRequest.Create(file.requestUri) as FtpWebRequest;
			ftpWebRequest.Method = "SIZE";
			FtpWebResponse ftpWebResponse = ftpWebRequest.GetResponse() as FtpWebResponse;
			file.fileSize = (double)ftpWebResponse.ContentLength;
			ftpWebResponse.Close();
			using (WebClient webClient = new WebClient())
			{
				webClient.Proxy = new WebProxy();
				webClient.DownloadProgressChanged += fChanged;
				webClient.DownloadDataCompleted += fCompleted;
				file.downloadAttemps++;
				webClient.DownloadDataAsync(new Uri(file.requestUri), file);
			}
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00002824 File Offset: 0x00000A24
		public static void DownloadFile(Ftp.FtpData file)
		{
			using (WebClient webClient = new WebClient())
			{
				file.downloadAttemps++;
				webClient.DownloadFile(new Uri(file.requestUri), Path.Combine(file.directory.FullName, file.fileName));
			}
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002888 File Offset: 0x00000A88
		private static string GetEntryName(string entry)
		{
			string text = entry.Substring(entry.LastIndexOf(":"));
			return text.Substring(text.IndexOf(" ") + 22);
		}

		// Token: 0x0600001C RID: 28 RVA: 0x000028C0 File Offset: 0x00000AC0
		private static void wDownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
		{
			Ftp.FtpData ftpData = e.UserState as Ftp.FtpData;
			if (e.Error == null)
			{
				ftpData.downloadProgress = 100.0;
				File.WriteAllBytes(ftpData.directory.FullName + "\\" + ftpData.fileName, e.Result);
				return;
			}
			if (ftpData.downloadAttemps <= 3)
			{
				Ftp.DownloadFileAsync(ftpData);
				return;
			}
			throw new WebException();
		}

		// Token: 0x0600001D RID: 29 RVA: 0x0000292C File Offset: 0x00000B2C
		private static void wDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
		{
			Ftp.FtpData ftpData = e.UserState as Ftp.FtpData;
			ftpData.downloadProgress = (double)Convert.ToInt32(Math.Round((double)e.BytesReceived / ftpData.fileSize * 100.0));
		}

		// Token: 0x02000007 RID: 7
		public class FtpData
		{
			// Token: 0x0600001F RID: 31 RVA: 0x00002978 File Offset: 0x00000B78
			public FtpData(string requestUri, string fileName, DirectoryInfo directory)
			{
				this.requestUri = requestUri;
				this.fileName = fileName;
				this.fileSize = 0.0;
				this.directory = directory;
				this.downloadAttemps = 0;
				this.downloadProgress = 0.0;
			}

			// Token: 0x04000003 RID: 3
			public string requestUri;

			// Token: 0x04000004 RID: 4
			public string fileName;

			// Token: 0x04000005 RID: 5
			public double fileSize;

			// Token: 0x04000006 RID: 6
			public DirectoryInfo directory;

			// Token: 0x04000007 RID: 7
			public int downloadAttemps;

			// Token: 0x04000008 RID: 8
			public double downloadProgress;
		}
	}
}
