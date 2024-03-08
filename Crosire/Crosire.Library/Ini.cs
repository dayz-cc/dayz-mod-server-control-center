using System.Runtime.InteropServices;
using System.Text;

namespace Crosire.Library
{
	public class Ini
	{
		[DllImport("kernel32")]
		private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

		[DllImport("kernel32")]
		private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

		public static void Write(string path, string section, string key, string value)
		{
			WritePrivateProfileString(section, key, value, path);
		}

		public static string Read(string path, string section, string key)
		{
			StringBuilder stringBuilder = new StringBuilder(255);
			GetPrivateProfileString(section, key, "", stringBuilder, 255, path);
			return stringBuilder.ToString();
		}
	}
}
