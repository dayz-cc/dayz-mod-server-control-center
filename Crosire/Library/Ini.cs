using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Crosire.Library
{
	// Token: 0x02000008 RID: 8
	public class Ini
	{
		// Token: 0x06000020 RID: 32
		[DllImport("kernel32")]
		private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

		// Token: 0x06000021 RID: 33
		[DllImport("kernel32")]
		private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

		// Token: 0x06000022 RID: 34 RVA: 0x000029C5 File Offset: 0x00000BC5
		public static void Write(string path, string section, string key, string value)
		{
			Ini.WritePrivateProfileString(section, key, value, path);
		}

		// Token: 0x06000023 RID: 35 RVA: 0x000029D4 File Offset: 0x00000BD4
		public static string Read(string path, string section, string key)
		{
			StringBuilder stringBuilder = new StringBuilder(255);
			Ini.GetPrivateProfileString(section, key, "", stringBuilder, 255, path);
			return stringBuilder.ToString();
		}
	}
}
