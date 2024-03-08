using System;

namespace NLog.Targets.Wrappers
{
	/// <summary>
	/// The action to be taken when the queue overflows.
	/// </summary>
	// Token: 0x02000131 RID: 305
	public enum AsyncTargetWrapperOverflowAction
	{
		/// <summary>
		/// Grow the queue.
		/// </summary>
		// Token: 0x0400034C RID: 844
		Grow,
		/// <summary>
		/// Discard the overflowing item.
		/// </summary>
		// Token: 0x0400034D RID: 845
		Discard,
		/// <summary>
		/// Block until there's more room in the queue.
		/// </summary>
		// Token: 0x0400034E RID: 846
		Block
	}
}
