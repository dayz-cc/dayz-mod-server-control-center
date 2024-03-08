using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace Crosire.Library
{
	public class Ftp
	{
		public class FtpData
		{
			public string requestUri;

			public string fileName;

			public double fileSize;

			public DirectoryInfo directory;

			public int downloadAttemps;

			public double downloadProgress;

			public FtpData(string requestUri, string fileName, DirectoryInfo directory)
			{
				this.requestUri = requestUri;
				this.fileName = fileName;
				fileSize = 0.0;
				this.directory = directory;
				downloadAttemps = 0;
				downloadProgress = 0.0;
			}
		}

		public static List<FtpData> DownloadList(string requestUri, DirectoryInfo workingDirectory, bool recursive)
		{
			List<FtpData> list = new List<FtpData>();
			List<FtpData> list2 = new List<FtpData>();
			FtpWebRequest ftpWebRequest = (FtpWebRequest)WebRequest.Create(requestUri);
			ftpWebRequest.Proxy = new WebProxy();
			ftpWebRequest.Method = "LIST";
			ftpWebRequest.KeepAlive = false;
			using (FtpWebResponse ftpWebResponse = (FtpWebResponse)ftpWebRequest.GetResponse())
			{
				using (Stream stream = ftpWebResponse.GetResponseStream())
				{
					using (StreamReader streamReader = new StreamReader(stream))
					{
						while (!streamReader.EndOfStream)
						{
							string text = streamReader.ReadLine();
							if (text.ToLower().Contains("<dir>"))
							{
								string entryName = GetEntryName(text);
								if (entryName != "." && entryName != ".." && recursive)
								{
									DirectoryInfo directory = Directory.CreateDirectory(workingDirectory.FullName + "\\" + entryName);
									list2.Add(new FtpData(requestUri + "/" + entryName, "", directory));
								}
							}
							else
							{
								list.Add(new FtpData(requestUri + "/" + GetEntryName(text), GetEntryName(text), workingDirectory));
							}
						}
					}
				}
			}
			foreach (FtpData item in list2)
			{
				list.AddRange(DownloadList(item.requestUri, item.directory, true));
			}
			return list;
		}

		public static void DownloadFileAsync(FtpData file)
		{
			DownloadFileAsync(file, wDownloadProgressChanged, wDownloadDataCompleted);
		}

		public static void DownloadFileAsync(FtpData file, DownloadProgressChangedEventHandler fChanged)
		{
			DownloadFileAsync(file, fChanged, wDownloadDataCompleted);
		}

		public static void DownloadFileAsync(FtpData file, DownloadDataCompletedEventHandler fCompleted)
		{
			DownloadFileAsync(file, wDownloadProgressChanged, fCompleted);
		}

		public static void DownloadFileAsync(FtpData file, DownloadProgressChangedEventHandler fChanged, DownloadDataCompletedEventHandler fCompleted)
		{
			FtpWebRequest ftpWebRequest = WebRequest.Create(file.requestUri) as FtpWebRequest;
			ftpWebRequest.Method = "SIZE";
			FtpWebResponse ftpWebResponse = ftpWebRequest.GetResponse() as FtpWebResponse;
			file.fileSize = ftpWebResponse.ContentLength;
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

		public static void DownloadFile(FtpData file)
		{
			using (WebClient webClient = new WebClient())
			{
				file.downloadAttemps++;
				webClient.DownloadFile(new Uri(file.requestUri), Path.Combine(file.directory.FullName, file.fileName));
			}
		}

		private static string GetEntryName(string entry)
		{
			string text = entry.Substring(entry.LastIndexOf(":"));
			return text.Substring(text.IndexOf(" ") + 22);
		}

		private static void wDownloadDataCompleted(object sender, DownloadDataCompletedEventArgs e)
		{
			FtpData ftpData = e.UserState as FtpData;
			if (e.Error == null)
			{
				ftpData.downloadProgress = 100.0;
				File.WriteAllBytes(ftpData.directory.FullName + "\\" + ftpData.fileName, e.Result);
				return;
			}
			if (ftpData.downloadAttemps <= 3)
			{
				DownloadFileAsync(ftpData);
				return;
			}
			throw new WebException();
		}

		private static void wDownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
		{
			FtpData ftpData = e.UserState as FtpData;
			ftpData.downloadProgress = Convert.ToInt32(Math.Round((double)e.BytesReceived / ftpData.fileSize * 100.0));
		}
	}
}
