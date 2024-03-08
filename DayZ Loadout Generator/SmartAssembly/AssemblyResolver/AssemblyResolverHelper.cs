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
	// Token: 0x0200000C RID: 12
	internal sealed class AssemblyResolverHelper
	{
		// Token: 0x06000113 RID: 275
		[DllImport("kernel32")]
		private static extern bool MoveFileEx(string existingFileName, string newFileName, int flags);

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x06000114 RID: 276 RVA: 0x000100C8 File Offset: 0x0000E2C8
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

		// Token: 0x06000115 RID: 277 RVA: 0x00010124 File Offset: 0x0000E324
		internal static void Attach()
		{
			try
			{
				AppDomain.CurrentDomain.AssemblyResolve += AssemblyResolverHelper.ResolveAssembly;
			}
			catch
			{
			}
		}

		// Token: 0x06000116 RID: 278 RVA: 0x0001015C File Offset: 0x0000E35C
		internal static Assembly ResolveAssembly(object sender, ResolveEventArgs e)
		{
			AssemblyResolverHelper.AssemblyInfo assemblyInfo = new AssemblyResolverHelper.AssemblyInfo(e.Name);
			string assemblyFullName = assemblyInfo.GetAssemblyFullName(false);
			string text = Convert.ToBase64String(Encoding.UTF8.GetBytes(assemblyFullName));
			string[] array = "e2U3YzA2YjExLTFhMTEtNDY0Yi1hMWE3LWFjZjIzY2VjYmExY30sIEN1bHR1cmU9bmV1dHJhbCwgUHVibGljS2V5VG9rZW49M2U1NjM1MDY5M2Y3MzU1ZQ==,[z]{73bac200-655c-4090-a2c6-89a80d2150b2},e2U3YzA2YjExLTFhMTEtNDY0Yi1hMWE3LWFjZjIzY2VjYmExY30=,[z]{73bac200-655c-4090-a2c6-89a80d2150b2}".Split(new char[] { ',' });
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
				lock (AssemblyResolverHelper.hashtable)
				{
					if (AssemblyResolverHelper.hashtable.ContainsKey(text2))
					{
						return (Assembly)AssemblyResolverHelper.hashtable[text2];
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
								string text4 = string.Format("{0}{1}\\", Path.GetTempPath(), text2);
								Directory.CreateDirectory(text4);
								string text5 = text4 + assemblyInfo.Name + ".dll";
								if (!File.Exists(text5))
								{
									FileStream fileStream = File.OpenWrite(text5);
									fileStream.Write(array2, 0, array2.Length);
									fileStream.Close();
									AssemblyResolverHelper.MoveFileEx(text5, null, 4);
									AssemblyResolverHelper.MoveFileEx(text4, null, 4);
								}
								assembly = Assembly.LoadFile(text5);
							}
							catch
							{
							}
						}
						AssemblyResolverHelper.hashtable[text2] = assembly;
						return assembly;
					}
				}
			}
			return null;
		}

		// Token: 0x040000A2 RID: 162
		internal const string BindList = "{71461f04-2faa-4bb9-a0dd-28a79101b599}";

		// Token: 0x040000A3 RID: 163
		private const int MOVEFILE_DELAY_UNTIL_REBOOT = 4;

		// Token: 0x040000A4 RID: 164
		private static Hashtable hashtable = new Hashtable();

		// Token: 0x0200000D RID: 13
		internal struct AssemblyInfo
		{
			// Token: 0x06000119 RID: 281 RVA: 0x00010448 File Offset: 0x0000E648
			public string GetAssemblyFullName(bool includeVersion)
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append(this.Name);
				if (includeVersion && this.Version != null)
				{
					stringBuilder.Append(", Version=");
					stringBuilder.Append(this.Version);
				}
				stringBuilder.Append(", Culture=");
				stringBuilder.Append((this.Culture.Length == 0) ? "neutral" : this.Culture);
				stringBuilder.Append(", PublicKeyToken=");
				stringBuilder.Append((this.PublicKeyToken.Length == 0) ? "null" : this.PublicKeyToken);
				return stringBuilder.ToString();
			}

			// Token: 0x0600011A RID: 282 RVA: 0x000104F4 File Offset: 0x0000E6F4
			public AssemblyInfo(string assemblyFullName)
			{
				this.Version = null;
				this.Culture = string.Empty;
				this.PublicKeyToken = string.Empty;
				this.Name = string.Empty;
				foreach (string text in assemblyFullName.Split(new char[] { ',' }))
				{
					string text2 = text.Trim();
					if (text2.StartsWith("Version="))
					{
						this.Version = new Version(text2.Substring(8));
					}
					else if (text2.StartsWith("Culture="))
					{
						this.Culture = text2.Substring(8);
						if (this.Culture == "neutral")
						{
							this.Culture = string.Empty;
						}
					}
					else if (text2.StartsWith("PublicKeyToken="))
					{
						this.PublicKeyToken = text2.Substring(15);
						if (this.PublicKeyToken == "null")
						{
							this.PublicKeyToken = string.Empty;
						}
					}
					else
					{
						this.Name = text2;
					}
				}
			}

			// Token: 0x040000A5 RID: 165
			public string Name;

			// Token: 0x040000A6 RID: 166
			public Version Version;

			// Token: 0x040000A7 RID: 167
			public string Culture;

			// Token: 0x040000A8 RID: 168
			public string PublicKeyToken;
		}
	}
}
