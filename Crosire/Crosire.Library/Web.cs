using System.IO;
using System.Net;

namespace Crosire.Library
{
	public class Web
	{
		public static string httpRead(string url)
		{
			try
			{
				WebRequest webRequest = WebRequest.Create(url);
				webRequest.Method = "GET";
				WebResponse response = webRequest.GetResponse();
				StreamReader streamReader = new StreamReader(response.GetResponseStream());
				string result = streamReader.ReadToEnd();
				streamReader.Close();
				response.Close();
				return result;
			}
			catch
			{
				return null;
			}
		}

		public static string ftpRead(string url)
		{
			return ftpRead(url, null, null);
		}

		public static string ftpRead(string url, string user, string pass)
		{
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
				string result = streamReader.ReadToEnd();
				streamReader.Close();
				ftpWebResponse.Close();
				return result;
			}
			catch
			{
				return null;
			}
		}

		public static void ftpDownload(string url, string destination)
		{
			ftpDownload(url, destination, null, null);
		}

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
			byte[] buffer = new byte[num];
			for (int num2 = responseStream.Read(buffer, 0, num); num2 > 0; num2 = responseStream.Read(buffer, 0, num))
			{
				fileStream.Write(buffer, 0, num2);
			}
			responseStream.Close();
			fileStream.Close();
			ftpWebResponse.Close();
		}
	}
}
