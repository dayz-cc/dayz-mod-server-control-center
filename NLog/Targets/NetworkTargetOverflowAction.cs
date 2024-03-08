using System;

namespace NLog.Targets
{
	/// <summary>
	/// Action that should be taken if the message overflows.
	/// </summary>
	// Token: 0x0200011E RID: 286
	public enum NetworkTargetOverflowAction
	{
		/// <summary>
		/// Report an error.
		/// </summary>
		// Token: 0x040002EF RID: 751
		Error,
		/// <summary>
		/// Split the message into smaller pieces.
		/// </summary>
		// Token: 0x040002F0 RID: 752
		Split,
		/// <summary>
		/// Discard the entire message.
		/// </summary>
		// Token: 0x040002F1 RID: 753
		Discard
	}
}
