using System;

namespace NLog.Conditions
{
	/// <summary>
	/// Relational operators used in conditions.
	/// </summary>
	// Token: 0x0200001F RID: 31
	internal enum ConditionRelationalOperator
	{
		/// <summary>
		/// Equality (==).
		/// </summary>
		// Token: 0x04000029 RID: 41
		Equal,
		/// <summary>
		/// Inequality (!=).
		/// </summary>
		// Token: 0x0400002A RID: 42
		NotEqual,
		/// <summary>
		/// Less than (&lt;).
		/// </summary>
		// Token: 0x0400002B RID: 43
		Less,
		/// <summary>
		/// Greater than (&gt;).
		/// </summary>
		// Token: 0x0400002C RID: 44
		Greater,
		/// <summary>
		/// Less than or equal (&lt;=).
		/// </summary>
		// Token: 0x0400002D RID: 45
		LessOrEqual,
		/// <summary>
		/// Greater than or equal (&gt;=).
		/// </summary>
		// Token: 0x0400002E RID: 46
		GreaterOrEqual
	}
}
