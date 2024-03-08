using System;
using System.Reflection;

namespace NLog.Config
{
	/// <summary>
	/// Provides means to populate factories of named items (such as targets, layouts, layout renderers, etc.).
	/// </summary>
	// Token: 0x0200002B RID: 43
	internal interface IFactory
	{
		// Token: 0x06000119 RID: 281
		void Clear();

		// Token: 0x0600011A RID: 282
		void ScanAssembly(Assembly theAssembly, string prefix);

		// Token: 0x0600011B RID: 283
		void RegisterType(Type type, string itemNamePrefix);
	}
}
