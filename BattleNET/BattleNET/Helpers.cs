using System;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Text;

namespace BattleNET
{
	internal class Helpers
	{
		public static string Hex2Ascii(string hexString)
		{
			int num = 0;
			byte[] array = new byte[hexString.Length / 2];
			for (int i = 0; i <= hexString.Length - 2; i += 2)
			{
				array[num] = (byte)Convert.ToChar(int.Parse(hexString.Substring(i, 2), NumberStyles.HexNumber));
				num++;
			}
			return Bytes2String(array);
		}

		public static byte[] String2Bytes(string s)
		{
			return Encoding.GetEncoding(1252).GetBytes(s);
		}

		public static string Bytes2String(byte[] bytes)
		{
			return Encoding.GetEncoding(1252).GetString(bytes);
		}

		public static string Bytes2String(byte[] bytes, int index, int count)
		{
			return Encoding.UTF8.GetString(bytes, index, count);
		}

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

		public static object EnumValueOf(string value, Type enumType)
		{
			string[] names = Enum.GetNames(enumType);
			string[] array = names;
			foreach (string value2 in array)
			{
				if (StringValueOf((Enum)Enum.Parse(enumType, value2)).Equals(value))
				{
					return Enum.Parse(enumType, value2);
				}
			}
			throw new ArgumentException("The string is not a description or value of the specified enum.");
		}
	}
}
