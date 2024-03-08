using System;

namespace Crosire.Library
{
	// Token: 0x02000009 RID: 9
	public class Text
	{
		// Token: 0x06000025 RID: 37 RVA: 0x00002A10 File Offset: 0x00000C10
		public static string SubString(string input, string start, string end)
		{
			if (string.IsNullOrEmpty(input))
			{
				return string.Empty;
			}
			if (!input.Contains(start) || !input.Contains(end))
			{
				return string.Empty;
			}
			int num = input.IndexOf(start);
			int num2 = input.LastIndexOf(end);
			if (!string.IsNullOrEmpty(input.Substring(num + 1, num2 - num - 1)))
			{
				return input.Substring(num + 1, num2 - num - 1);
			}
			return string.Empty;
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00002A7C File Offset: 0x00000C7C
		public static string RandomString(int length)
		{
			string text = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789!@$?_-";
			char[] array = new char[length];
			Random random = new Random();
			for (int i = 0; i < length; i++)
			{
				array[i] = text[random.Next(0, text.Length)];
			}
			return new string(array);
		}
	}
}
