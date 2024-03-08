using System;

namespace NLog.Conditions
{
	/// <summary>
	/// Marks the class as containing condition methods.
	/// </summary>
	// Token: 0x02000019 RID: 25
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
	public sealed class ConditionMethodsAttribute : Attribute
	{
	}
}
