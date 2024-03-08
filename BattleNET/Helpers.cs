using System;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Text;

namespace BattleNET
{
	// Token: 0x0200000E RID: 14
	internal class Helpers
	{
		// Token: 0x0600003D RID: 61 RVA: 0x00002D90 File Offset: 0x00000F90
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

		// Token: 0x0600003E RID: 62 RVA: 0x00002DE5 File Offset: 0x00000FE5
		public static byte[] String2Bytes(string s)
		{
			return Encoding.GetEncoding(1252).GetBytes(s);
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00002DF7 File Offset: 0x00000FF7
		public static string Bytes2String(byte[] bytes)
		{
			return Encoding.GetEncoding(1252).GetString(bytes);
		}

		// Token: 0x06000040 RID: 64 RVA: 0x00002E09 File Offset: 0x00001009
		public static string Bytes2String(byte[] bytes, int index, int count)
		{
			return Encoding.UTF8.GetString(bytes, index, count);
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00002E18 File Offset: 0x00001018
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

		// Token: 0x06000042 RID: 66 RVA: 0x00002E64 File Offset: 0x00001064
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
