using System;

namespace SmartAssembly.Zip
{
	// Token: 0x02000014 RID: 20
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Module | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method)]
	public sealed class DoNotEncodeStringsAttribute : Attribute
	{
	}
}
