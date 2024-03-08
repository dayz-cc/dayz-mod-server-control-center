using System;

namespace NLog.Targets.Wrappers
{
	/// <summary>
	/// Impersonation level.
	/// </summary>
	// Token: 0x02000140 RID: 320
	public enum SecurityImpersonationLevel
	{
		/// <summary>
		/// Anonymous Level.
		/// </summary>
		// Token: 0x04000373 RID: 883
		Anonymous,
		/// <summary>
		/// Identification Level.
		/// </summary>
		// Token: 0x04000374 RID: 884
		Identification,
		/// <summary>
		/// Impersonation Level.
		/// </summary>
		// Token: 0x04000375 RID: 885
		Impersonation,
		/// <summary>
		/// Delegation Level.
		/// </summary>
		// Token: 0x04000376 RID: 886
		Delegation
	}
}
