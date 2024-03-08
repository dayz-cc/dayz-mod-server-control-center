using System;

namespace Crosire.Library
{
	public class Text
	{
		public static string SubString(string input, string start, string end)
		{
			if (!string.IsNullOrEmpty(input))
			{
				if (input.Contains(start) && input.Contains(end))
				{
					int num = input.IndexOf(start);
					int num2 = input.LastIndexOf(end);
					if (!string.IsNullOrEmpty(input.Substring(num + 1, num2 - num - 1)))
					{
						return input.Substring(num + 1, num2 - num - 1);
					}
					return string.Empty;
				}
				return string.Empty;
			}
			return string.Empty;
		}

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
