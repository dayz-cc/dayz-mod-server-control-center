using System;

namespace NLog.Common
{
	/// <summary>
	/// Asynchronous action with one argument.
	/// </summary>
	/// <typeparam name="T">Type of the argument.</typeparam>
	/// <param name="argument">Argument to the action.</param>
	/// <param name="asyncContinuation">Continuation to be invoked at the end of action.</param>
	// Token: 0x02000009 RID: 9
	// (Invoke) Token: 0x06000047 RID: 71
	public delegate void AsynchronousAction<T>(T argument, AsyncContinuation asyncContinuation);
}
