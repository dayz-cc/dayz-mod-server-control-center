using System;

namespace NLog
{
	/// <summary>
	/// Nested Diagnostics Context - for log4net compatibility.
	/// </summary>
	// Token: 0x020000F7 RID: 247
	[Obsolete("Use NestedDiagnosticsContext")]
	public static class NDC
	{
		/// <summary>
		/// Gets the top NDC message but doesn't remove it.
		/// </summary>
		/// <returns>The top message. .</returns>
		// Token: 0x17000160 RID: 352
		// (get) Token: 0x06000786 RID: 1926 RVA: 0x0001A844 File Offset: 0x00018A44
		public static string TopMessage
		{
			get
			{
				return NestedDiagnosticsContext.TopMessage;
			}
		}

		/// <summary>
		/// Pushes the specified text on current thread NDC.
		/// </summary>
		/// <param name="text">The text to be pushed.</param>
		/// <returns>An instance of the object that implements IDisposable that returns the stack to the previous level when IDisposable.Dispose() is called. To be used with C# using() statement.</returns>
		// Token: 0x06000787 RID: 1927 RVA: 0x0001A85C File Offset: 0x00018A5C
		public static IDisposable Push(string text)
		{
			return NestedDiagnosticsContext.Push(text);
		}

		/// <summary>
		/// Pops the top message off the NDC stack.
		/// </summary>
		/// <returns>The top message which is no longer on the stack.</returns>
		// Token: 0x06000788 RID: 1928 RVA: 0x0001A874 File Offset: 0x00018A74
		public static string Pop()
		{
			return NestedDiagnosticsContext.Pop();
		}

		/// <summary>
		/// Clears current thread NDC stack.
		/// </summary>
		// Token: 0x06000789 RID: 1929 RVA: 0x0001A88B File Offset: 0x00018A8B
		public static void Clear()
		{
			NestedDiagnosticsContext.Clear();
		}

		/// <summary>
		/// Gets all messages on the stack.
		/// </summary>
		/// <returns>Array of strings on the stack.</returns>
		// Token: 0x0600078A RID: 1930 RVA: 0x0001A894 File Offset: 0x00018A94
		public static string[] GetAllMessages()
		{
			return NestedDiagnosticsContext.GetAllMessages();
		}
	}
}
