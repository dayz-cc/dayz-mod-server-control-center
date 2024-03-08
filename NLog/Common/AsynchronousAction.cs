using System;

namespace NLog.Common
{
	/// <summary>
	/// Asynchronous action.
	/// </summary>
	/// <param name="asyncContinuation">Continuation to be invoked at the end of action.</param>
	// Token: 0x02000008 RID: 8
	// (Invoke) Token: 0x06000043 RID: 67
	public delegate void AsynchronousAction(AsyncContinuation asyncContinuation);
}
