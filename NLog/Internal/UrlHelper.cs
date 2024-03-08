using System;
using System.Text;

namespace NLog.Internal
{
	/// <summary>
	/// URL Encoding helper.
	/// </summary>
	// Token: 0x0200008D RID: 141
	internal class UrlHelper
	{
		// Token: 0x0600035F RID: 863 RVA: 0x0000D440 File Offset: 0x0000B640
		internal static string UrlEncode(string str, bool spaceAsPlus)
		{
			StringBuilder stringBuilder = new StringBuilder(str.Length + 20);
			foreach (char c in str)
			{
				if (c == ' ' && spaceAsPlus)
				{
					stringBuilder.Append('+');
				}
				else if (UrlHelper.IsSafeUrlCharacter(c))
				{
					stringBuilder.Append(c);
				}
				else if (c < 'Ā')
				{
					stringBuilder.Append('%');
					stringBuilder.Append(UrlHelper.hexChars[(int)((c >> 4) & '\u000f')]);
					stringBuilder.Append(UrlHelper.hexChars[(int)(c & '\u000f')]);
				}
				else
				{
					stringBuilder.Append('%');
					stringBuilder.Append('u');
					stringBuilder.Append(UrlHelper.hexChars[(int)((c >> 12) & '\u000f')]);
					stringBuilder.Append(UrlHelper.hexChars[(int)((c >> 8) & '\u000f')]);
					stringBuilder.Append(UrlHelper.hexChars[(int)((c >> 4) & '\u000f')]);
					stringBuilder.Append(UrlHelper.hexChars[(int)(c & '\u000f')]);
				}
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06000360 RID: 864 RVA: 0x0000D588 File Offset: 0x0000B788
		private static bool IsSafeUrlCharacter(char ch)
		{
			return (ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z') || (ch >= '0' && ch <= '9') || UrlHelper.safeUrlPunctuation.IndexOf(ch) >= 0;
		}

		// Token: 0x040000E4 RID: 228
		private static string safeUrlPunctuation = ".()*-_!'";

		// Token: 0x040000E5 RID: 229
		private static string hexChars = "0123456789abcdef";
	}
}
