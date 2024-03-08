using System;

namespace NLog.Config
{
	/// <summary>
	/// Attribute used to mark the required parameters for targets,
	/// layout targets and filters.
	/// </summary>
	// Token: 0x02000038 RID: 56
	[AttributeUsage(AttributeTargets.Property)]
	public sealed class RequiredParameterAttribute : Attribute
	{
	}
}
