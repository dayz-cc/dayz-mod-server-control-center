using System;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;

namespace SmartAssembly.Zip
{
	// Token: 0x02000012 RID: 18
	public sealed class AESCryptoIndirector : IDisposable
	{
		// Token: 0x06000128 RID: 296 RVA: 0x0001089C File Offset: 0x0000EA9C
		public AESCryptoIndirector()
		{
			try
			{
				Assembly assembly = Assembly.Load("System.Core, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e");
				this.m_AcspType = assembly.GetType("System.Security.Cryptography.AesManaged");
			}
			catch (FileNotFoundException)
			{
				Assembly assembly = Assembly.Load("mscorlib");
				this.m_AcspType = assembly.GetType("System.Security.Cryptography.RijndaelManaged");
			}
			this.m_AESCryptoServiceProvider = Activator.CreateInstance(this.m_AcspType);
		}

		// Token: 0x06000129 RID: 297 RVA: 0x00010910 File Offset: 0x0000EB10
		public ICryptoTransform GetAESCryptoTransform(byte[] key, byte[] iv, bool decrypt)
		{
			this.m_AcspType.GetProperty("Key").GetSetMethod().Invoke(this.m_AESCryptoServiceProvider, new object[] { key });
			this.m_AcspType.GetProperty("IV").GetSetMethod().Invoke(this.m_AESCryptoServiceProvider, new object[] { iv });
			MethodInfo method = this.m_AcspType.GetMethod(decrypt ? "CreateDecryptor" : "CreateEncryptor", new Type[0]);
			return (ICryptoTransform)method.Invoke(this.m_AESCryptoServiceProvider, new object[0]);
		}

		// Token: 0x0600012A RID: 298 RVA: 0x000109B0 File Offset: 0x0000EBB0
		public void Clear()
		{
			this.m_AcspType.GetMethod("Clear").Invoke(this.m_AESCryptoServiceProvider, new object[0]);
		}

		// Token: 0x0600012B RID: 299 RVA: 0x000109D4 File Offset: 0x0000EBD4
		public void Dispose()
		{
			this.Clear();
		}

		// Token: 0x040000AD RID: 173
		private readonly Type m_AcspType;

		// Token: 0x040000AE RID: 174
		private readonly object m_AESCryptoServiceProvider;
	}
}
