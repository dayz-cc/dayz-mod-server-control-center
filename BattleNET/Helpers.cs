using System;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Text;

namespace BattleNET
{
	// Token: 0x02000005 RID: 5
	internal class Helpers
	{
		// Token: 0x06000006 RID: 6 RVA: 0x00002060 File Offset: 0x00000260
		public static string Hex2Ascii(string hexString)
		{
			int num = 0;
			byte[] array = new byte[hexString.Length / 2];
			for (int i = 0; i <= hexString.Length - 2; i += 2)
			{
				array[num] = (byte)Convert.ToChar(int.Parse(hexString.Substring(i, 2), NumberStyles.HexNumber));
				num++;
			}
			return Helpers.Bytes2String(array);
		}

		// Token: 0x06000007 RID: 7 RVA: 0x000020B5 File Offset: 0x000002B5
		public static byte[] String2Bytes(string s)
		{
			return Encoding.GetEncoding(1252).GetBytes(s);
		}

		// Token: 0x06000008 RID: 8 RVA: 0x000020C7 File Offset: 0x000002C7
		public static string Bytes2String(byte[] bytes)
		{
			return Encoding.GetEncoding(1252).GetString(bytes);
		}

		// Token: 0x06000009 RID: 9 RVA: 0x000020D9 File Offset: 0x000002D9
		public static string Bytes2String(byte[] bytes, int index, int count)
		{
			return Encoding.UTF8.GetString(bytes, index, count);
		}

		// Token: 0x0600000A RID: 10 RVA: 0x000020E8 File Offset: 0x000002E8
		public static string StringValueOf(Enum value)
		{
			FieldInfo field = value.GetType().GetField(value.ToString());
			DescriptionAttribute[] array = (DescriptionAttribute[])field.GetCustomAttributes(typeof(DescriptionAttribute), false);
			if (array.Length > 0)
			{
				return array[0].Description;
			}
			return value.ToString();
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00002134 File Offset: 0x00000334
		public static object EnumValueOf(string value, Type enumType)
		{
			string[] names = Enum.GetNames(enumType);
			foreach (string text in names)
			{
				if (Helpers.StringValueOf((Enum)Enum.Parse(enumType, text)).Equals(value))
				{
					return Enum.Parse(enumType, text);
				}
			}
			throw new ArgumentException("The string is not a description or value of the specified enum.");
		}
	}
}
