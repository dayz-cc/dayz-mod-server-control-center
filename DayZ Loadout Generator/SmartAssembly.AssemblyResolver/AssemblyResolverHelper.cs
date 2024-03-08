using System;
using System.Collections;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using SmartAssembly.Zip;

namespace SmartAssembly.AssemblyResolver
{
	internal sealed class AssemblyResolverHelper
	{
		internal struct AssemblyInfo
		{
			public string Name;

			public Version Version;

			public string Culture;

			public string PublicKeyToken;

			public string GetAssemblyFullName(bool includeVersion)
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append(Name);
				if (includeVersion && Version != null)
				{
					stringBuilder.Append(", Version=");
					stringBuilder.Append(Version);
				}
				stringBuilder.Append(", Culture=");
				stringBuilder.Append((Culture.Length == 0) ? "neutral" : Culture);
				stringBuilder.Append(", PublicKeyToken=");
				stringBuilder.Append((PublicKeyToken.Length == 0) ? "null" : PublicKeyToken);
				return stringBuilder.ToString();
			}

			public AssemblyInfo(string assemblyFullName)
			{
				Version = null;
				Culture = string.Empty;
				PublicKeyToken = string.Empty;
				Name = string.Empty;
				string[] array = assemblyFullName.Split(',');
				foreach (string text in array)
				{
					string text2 = text.Trim();
					if (text2.StartsWith("Version="))
					{
						Version = new Version(text2.Substring(8));
					}
					else if (text2.StartsWith("Culture="))
					{
						Culture = text2.Substring(8);
						if (Culture == "neutral")
						{
							Culture = string.Empty;
						}
					}
					else if (text2.StartsWith("PublicKeyToken="))
					{
						PublicKeyToken = text2.Substring(15);
						if (PublicKeyToken == "null")
						{
							PublicKeyToken = string.Empty;
						}
					}
					else
					{
						Name = text2;
					}
				}
			}
		}

		internal const string BindList = "{71461f04-2faa-4bb9-a0dd-28a79101b599}";

		private const int MOVEFILE_DELAY_UNTIL_REBOOT = 4;

		private static Hashtable hashtable = new Hashtable();

		internal static bool IsWebApplication
		{
			get
			{
				try
				{
					string text = Process.GetCurrentProcess().MainModule.ModuleName.ToLower();
					if (text == "w3wp.exe")
					{
						return true;
					}
					if (text == "aspnet_wp.exe")
					{
						return true;
					}
				}
				catch
				{
				}
				return false;
			}
		}

		[DllImport("kernel32")]
		private static extern bool MoveFileEx(string existingFileName, string newFileName, int flags);

		internal static void Attach()
		{
			try
			{
				AppDomain.CurrentDomain.AssemblyResolve += ResolveAssembly;
			}
			catch
			{
			}
		}

		internal static Assembly ResolveAssembly(object sender, ResolveEventArgs e)
		{
			AssemblyInfo assemblyInfo = new AssemblyInfo(e.Name);
			string assemblyFullName = assemblyInfo.GetAssemblyFullName(false);
			string text = Convert.ToBase64String(Encoding.UTF8.GetBytes(assemblyFullName));
			string[] array = "e2U3YzA2YjExLTFhMTEtNDY0Yi1hMWE3LWFjZjIzY2VjYmExY30sIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49M2U1NjM1MDY5M2Y3MzU1ZQ==,[z]{73bac200-655c-4090-a2c6-89a80d2150b2},e2U3YzA2YjExLTFhMTEtNDY0Yi1hMWE3LWFjZjIzY2VjYmExY30=,[z]{73bac200-655c-4090-a2c6-89a80d2150b2}".Split(',');
			string text2 = string.Empty;
			bool flag = false;
			bool flag2 = false;
			for (int i = 0; i < array.Length - 1; i += 2)
			{
				if (array[i] == text)
				{
					text2 = array[i + 1];
					break;
				}
			}
			if (text2.Length == 0 && assemblyInfo.PublicKeyToken.Length == 0)
			{
				text = Convert.ToBase64String(Encoding.UTF8.GetBytes(assemblyInfo.Name));
				for (int j = 0; j < array.Length - 1; j += 2)
				{
					if (array[j] == text)
					{
						text2 = array[j + 1];
						break;
					}
				}
			}
			if (text2.Length > 0)
			{
				if (text2[0] == '[')
				{
					int num = text2.IndexOf(']');
					string text3 = text2.Substring(1, num - 1);
					flag = text3.IndexOf('z') >= 0;
					flag2 = text3.IndexOf('t') >= 0;
					text2 = text2.Substring(num + 1);
				}
				lock (hashtable)
				{
					if (hashtable.ContainsKey(text2))
					{
						return (Assembly)hashtable[text2];
					}
					Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(text2);
					if (manifestResourceStream != null)
					{
						int num2 = (int)manifestResourceStream.Length;
						byte[] array2 = new byte[num2];
						manifestResourceStream.Read(array2, 0, num2);
						if (flag)
						{
							array2 = SimpleZip.Unzip(array2);
						}
						Assembly assembly = null;
						if (!flag2)
						{
							try
							{
								assembly = Assembly.Load(array2);
							}
							catch (FileLoadException)
							{
								flag2 = true;
							}
							catch (BadImageFormatException)
							{
								flag2 = true;
							}
						}
						if (flag2)
						{
							try
							{
								string text4 = $"{Path.GetTempPath()}{text2}\\";
								Directory.CreateDirectory(text4);
								string text5 = text4 + assemblyInfo.Name + ".dll";
								if (!File.Exists(text5))
								{
									FileStream fileStream = File.OpenWrite(text5);
									fileStream.Write(array2, 0, array2.Length);
									fileStream.Close();
									MoveFileEx(text5, null, 4);
									MoveFileEx(text4, null, 4);
								}
								assembly = Assembly.LoadFile(text5);
							}
							catch
							{
							}
						}
						hashtable[text2] = assembly;
						return assembly;
					}
				}
			}
			return null;
		}
	}
}
