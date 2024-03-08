using System;

namespace NLog.Filters
{
	/// <summary>
	/// Filter result.
	/// </summary>
	// Token: 0x02000040 RID: 64
	public enum FilterResult
	{
		/// <summary>
		/// The filter doesn't want to decide whether to log or discard the message.
		/// </summary>
		// Token: 0x04000090 RID: 144
		Neutral,
		/// <summary>
		/// The message should be logged.
		/// </summary>
		// Token: 0x04000091 RID: 145
		Log,
		/// <summary>
		/// The message should not be logged.
		/// </summary>
		// Token: 0x04000092 RID: 146
		Ignore,
		/// <summary>
		/// The message should be logged and processing should be finished.
		/// </summary>
		// Token: 0x04000093 RID: 147
		LogFinal,
		/// <summary>
		/// The message should not be logged and processing should be finished.
		/// </summary>
		// Token: 0x04000094 RID: 148
		IgnoreFinal
	}
}
