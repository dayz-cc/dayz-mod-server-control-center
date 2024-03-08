using System;

namespace NLog.Config
{
	/// <summary>
	/// Marks the object as configuration item for NLog.
	/// </summary>
	// Token: 0x02000036 RID: 54
	[AttributeUsage(AttributeTargets.Class)]
	public sealed class NLogConfigurationItemAttribute : Attribute
	{
	}
}
