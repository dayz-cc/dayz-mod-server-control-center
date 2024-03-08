using System;

namespace SmartAssembly.Attributes
{
	// Token: 0x0200000E RID: 14
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method)]
	internal sealed class ObfuscateControlFlowAttribute : Attribute
	{
	}
}
