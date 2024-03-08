using System;
using System.Reflection;
using System.Security.Cryptography;

namespace SmartAssembly.Zip
{
	// Token: 0x02000013 RID: 19
	public sealed class DESCryptoIndirector : IDisposable
	{
		// Token: 0x0600012C RID: 300 RVA: 0x000109DC File Offset: 0x0000EBDC
		public DESCryptoIndirector()
		{
			Assembly assembly = Assembly.Load("mscorlib");
			this.m_DcspType = assembly.GetType("System.Security.Cryptography.DESCryptoServiceProvider");
			this.m_DESCryptoServiceProvider = Activator.CreateInstance(this.m_DcspType);
		}

		// Token: 0x0600012D RID: 301 RVA: 0x00010A1C File Offset: 0x0000EC1C
		public ICryptoTransform GetDESCryptoTransform(byte[] key, byte[] iv, bool decrypt)
		{
			this.m_DcspType.GetProperty("Key").GetSetMethod().Invoke(this.m_DESCryptoServiceProvider, new object[] { key });
			this.m_DcspType.GetProperty("IV").GetSetMethod().Invoke(this.m_DESCryptoServiceProvider, new object[] { iv });
			MethodInfo method = this.m_DcspType.GetMethod(decrypt ? "CreateDecryptor" : "CreateEncryptor", new Type[0]);
			return (ICryptoTransform)method.Invoke(this.m_DESCryptoServiceProvider, new object[0]);
		}

		// Token: 0x0600012E RID: 302 RVA: 0x00010ABC File Offset: 0x0000ECBC
		public void Clear()
		{
			this.m_DcspType.GetMethod("Clear").Invoke(this.m_DESCryptoServiceProvider, new object[0]);
		}

		// Token: 0x0600012F RID: 303 RVA: 0x00010AE0 File Offset: 0x0000ECE0
		public void Dispose()
		{
			this.Clear();
		}

		// Token: 0x040000AF RID: 175
		private readonly Type m_DcspType;

		// Token: 0x040000B0 RID: 176
		private readonly object m_DESCryptoServiceProvider;
	}
}
