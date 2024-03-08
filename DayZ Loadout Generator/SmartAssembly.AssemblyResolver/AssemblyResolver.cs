using System;

namespace SmartAssembly.AssemblyResolver
{
	public sealed class AssemblyResolver
	{
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
