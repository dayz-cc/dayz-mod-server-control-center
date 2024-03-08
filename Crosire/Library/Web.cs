using System;
using System.IO;
using System.Net;

namespace Crosire.Library
{
	// Token: 0x02000005 RID: 5
	public class Web
	{
		// Token: 0x0600000F RID: 15 RVA: 0x000023BC File Offset: 0x000005BC
		public static string httpRead(string url)
		{
			string text2;
			try
			{
				WebRequest webRequest = WebRequest.Create(url);
				webRequest.Method = "GET";
				WebResponse response = webRequest.GetResponse();
				StreamReader streamReader = new StreamReader(response.GetResponseStream());
				string text = streamReader.ReadToEnd();
				streamReader.Close();
				response.Close();
				text2 = text;
			}
			catch
			{
				text2 = null;
			}
			return text2;
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002420 File Offset: 0x00000620
		public static string ftpRead(string url)
		{
			return Web.ftpRead(url, null, null);
		}

		// Token: 0x06000011 RID: 17 RVA: 0x0000242C File Offset: 0x0000062C
		public static string ftpRead(string url, string user, string pass)
		{
			string text2;
			try
			{
				FtpWebRequest ftpWebRequest = WebRequest.Create(url) as FtpWebRequest;
				ftpWebRequest.Method = "RETR";
				ftpWebRequest.KeepAlive = false;
				if (user != null && pass != null)
				{
					ftpWebRequest.Credentials = new NetworkCredential(user, pass);
				}
				FtpWebResponse ftpWebResponse = ftpWebRequest.GetResponse() as FtpWebResponse;
				Stream responseStream = ftpWebResponse.GetResponseStream();
				StreamReader streamReader = new StreamReader(responseStream);
				string text = streamReader.ReadToEnd();
				streamReader.Close();
				ftpWebResponse.Close();
				text2 = text;
			}
			catch
			{
				text2 = null;
			}
			return text2;
		}

		// Token: 0x06000012 RID: 18 RVA: 0x000024B8 File Offset: 0x000006B8
		public static void ftpDownload(string url, string destination)
		{
			Web.ftpDownload(url, destination, null, null);
		}

		// Token: 0x06000013 RID: 19 RVA: 0x000024C4 File Offset: 0x000006C4
		public static void ftpDownload(string url, string destination, string user, string pass)
		{
			FtpWebRequest ftpWebRequest = WebRequest.Create(url) as FtpWebRequest;
			ftpWebRequest.UseBinary = true;
			ftpWebRequest.KeepAlive = false;
			ftpWebRequest.Method = "RETR";
			if (user != null && pass != null)
			{
				ftpWebRequest.Credentials = new NetworkCredential(user, pass);
			}
			FtpWebResponse ftpWebResponse = ftpWebRequest.GetResponse() as FtpWebResponse;
			Stream responseStream = ftpWebResponse.GetResponseStream();
			FileStream fileStream = new FileStream(destination, FileMode.Create);
			int num = 1024;
			byte[] array = new byte[num];
			for (int i = responseStream.Read(array, 0, num); i > 0; i = responseStream.Read(array, 0, num))
			{
				fileStream.Write(array, 0, i);
			}
			responseStream.Close();
			fileStream.Close();
			ftpWebResponse.Close();
		}
	}
}
