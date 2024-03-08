using System;

namespace NLog.Common
{
	/// <summary>
	/// Asynchronous continuation delegate - function invoked at the end of asynchronous
	/// processing.
	/// </summary>
	/// <param name="exception">Exception during asynchronous processing or null if no exception
	/// was thrown.</param>
	// Token: 0x02000006 RID: 6
	// (Invoke) Token: 0x06000035 RID: 53
	public delegate void AsyncContinuation(Exception exception);
}
