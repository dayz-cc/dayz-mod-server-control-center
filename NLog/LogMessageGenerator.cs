using System;

namespace NLog
{
	/// <summary>
	/// Returns a log message. Used to defer calculation of 
	/// the log message until it's actually needed.
	/// </summary>
	/// <returns>Log message.</returns>
	// Token: 0x020000EC RID: 236
	// (Invoke) Token: 0x06000736 RID: 1846
	public delegate string LogMessageGenerator();
}
