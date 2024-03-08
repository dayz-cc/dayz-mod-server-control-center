using System;
using NLog.Config;

namespace NLog.Conditions
{
	/// <summary>
	/// Marks class as a log event Condition and assigns a name to it.
	/// </summary>
	// Token: 0x02000016 RID: 22
	[AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
	public sealed class ConditionMethodAttribute : NameBaseAttribute
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Conditions.ConditionMethodAttribute" /> class.
		/// </summary>
		/// <param name="name">Condition method name.</param>
		// Token: 0x060000A3 RID: 163 RVA: 0x000037C4 File Offset: 0x000019C4
		public ConditionMethodAttribute(string name)
			: base(name)
		{
		}
	}
}
