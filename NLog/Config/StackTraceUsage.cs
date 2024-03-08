using System;

namespace NLog.Config
{
	/// <summary>
	/// Value indicating how stack trace should be captured when processing the log event.
	/// </summary>
	// Token: 0x0200003A RID: 58
	public enum StackTraceUsage
	{
		/// <summary>
		/// Stack trace should not be captured.
		/// </summary>
		// Token: 0x04000083 RID: 131
		None,
		/// <summary>
		/// Stack trace should be captured without source-level information.
		/// </summary>
		// Token: 0x04000084 RID: 132
		WithoutSource,
		/// <summary>
		/// Stack trace should be captured including source-level information such as line numbers.
		/// </summary>
		// Token: 0x04000085 RID: 133
		WithSource,
		/// <summary>
		/// Capture maximum amount of the stack trace information supported on the plaform.
		/// </summary>
		// Token: 0x04000086 RID: 134
		Max = 2
	}
}
