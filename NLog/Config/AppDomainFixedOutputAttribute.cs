using System;

namespace NLog.Config
{
	/// <summary>
	/// Identifies that the output of layout or layout render does not change for the lifetime of the current appdomain.
	/// </summary>
	// Token: 0x02000024 RID: 36
	[AttributeUsage(AttributeTargets.Class)]
	public sealed class AppDomainFixedOutputAttribute : Attribute
	{
	}
}
