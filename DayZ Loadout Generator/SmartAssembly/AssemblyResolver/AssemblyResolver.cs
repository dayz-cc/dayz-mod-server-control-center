using System;

namespace SmartAssembly.AssemblyResolver
{
	// Token: 0x0200000B RID: 11
	public sealed class AssemblyResolver
	{
		// Token: 0x06000111 RID: 273 RVA: 0x00010098 File Offset: 0x0000E298
		public static void AttachApp()
		{
			try
			{
				AssemblyResolverHelper.Attach();
			}
			catch (Exception)
			{
			}
		}
	}
}
