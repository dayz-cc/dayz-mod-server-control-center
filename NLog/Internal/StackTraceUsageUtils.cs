using System;
using NLog.Config;

namespace NLog.Internal
{
	/// <summary>
	/// Utilities for dealing with <see cref="T:NLog.Config.StackTraceUsage" /> values.
	/// </summary>
	// Token: 0x02000089 RID: 137
	internal class StackTraceUsageUtils
	{
		// Token: 0x0600034C RID: 844 RVA: 0x0000D14C File Offset: 0x0000B34C
		internal static StackTraceUsage Max(StackTraceUsage u1, StackTraceUsage u2)
		{
			return (StackTraceUsage)Math.Max((int)u1, (int)u2);
		}
	}
}
