using System;

namespace NLog.Config
{
	/// <summary>
	/// Marks the class or a member as advanced. Advanced classes and members are hidden by 
	/// default in generated documentation.
	/// </summary>
	// Token: 0x02000023 RID: 35
	[AttributeUsage(AttributeTargets.Property)]
	public sealed class AdvancedAttribute : Attribute
	{
	}
}
