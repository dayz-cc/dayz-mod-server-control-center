using System;
using System.Collections.Generic;
using NLog.Internal;

namespace NLog
{
	/// <summary>
	/// Nested Diagnostics Context - a thread-local structure that keeps a stack
	/// of strings and provides methods to output them in layouts
	/// Mostly for compatibility with log4net.
	/// </summary>
	// Token: 0x020000F8 RID: 248
	public static class NestedDiagnosticsContext
	{
		/// <summary>
		/// Gets the top NDC message but doesn't remove it.
		/// </summary>
		/// <returns>The top message. .</returns>
		// Token: 0x17000161 RID: 353
		// (get) Token: 0x0600078B RID: 1931 RVA: 0x0001A8AC File Offset: 0x00018AAC
		public static string TopMessage
		{
			get
			{
				Stack<string> threadStack = NestedDiagnosticsContext.ThreadStack;
				string text;
				if (threadStack.Count > 0)
				{
					text = threadStack.Peek();
				}
				else
				{
					text = string.Empty;
				}
				return text;
			}
		}

		// Token: 0x17000162 RID: 354
		// (get) Token: 0x0600078C RID: 1932 RVA: 0x0001A8E4 File Offset: 0x00018AE4
		private static Stack<string> ThreadStack
		{
			get
			{
				return ThreadLocalStorageHelper.GetDataForSlot<Stack<string>>(NestedDiagnosticsContext.dataSlot);
			}
		}

		/// <summary>
		/// Pushes the specified text on current thread NDC.
		/// </summary>
		/// <param name="text">The text to be pushed.</param>
		/// <returns>An instance of the object that implements IDisposable that returns the stack to the previous level when IDisposable.Dispose() is called. To be used with C# using() statement.</returns>
		// Token: 0x0600078D RID: 1933 RVA: 0x0001A900 File Offset: 0x00018B00
		public static IDisposable Push(string text)
		{
			Stack<string> threadStack = NestedDiagnosticsContext.ThreadStack;
			int count = threadStack.Count;
			threadStack.Push(text);
			return new NestedDiagnosticsContext.StackPopper(threadStack, count);
		}

		/// <summary>
		/// Pops the top message off the NDC stack.
		/// </summary>
		/// <returns>The top message which is no longer on the stack.</returns>
		// Token: 0x0600078E RID: 1934 RVA: 0x0001A930 File Offset: 0x00018B30
		public static string Pop()
		{
			Stack<string> threadStack = NestedDiagnosticsContext.ThreadStack;
			string text;
			if (threadStack.Count > 0)
			{
				text = threadStack.Pop();
			}
			else
			{
				text = string.Empty;
			}
			return text;
		}

		/// <summary>
		/// Clears current thread NDC stack.
		/// </summary>
		// Token: 0x0600078F RID: 1935 RVA: 0x0001A968 File Offset: 0x00018B68
		public static void Clear()
		{
			NestedDiagnosticsContext.ThreadStack.Clear();
		}

		/// <summary>
		/// Gets all messages on the stack.
		/// </summary>
		/// <returns>Array of strings on the stack.</returns>
		// Token: 0x06000790 RID: 1936 RVA: 0x0001A978 File Offset: 0x00018B78
		public static string[] GetAllMessages()
		{
			return NestedDiagnosticsContext.ThreadStack.ToArray();
		}

		// Token: 0x0400022B RID: 555
		private static readonly object dataSlot = ThreadLocalStorageHelper.AllocateDataSlot();

		/// <summary>
		/// Resets the stack to the original count during <see cref="M:System.IDisposable.Dispose" />.
		/// </summary>
		// Token: 0x020000F9 RID: 249
		private class StackPopper : IDisposable
		{
			/// <summary>
			/// Initializes a new instance of the <see cref="T:NLog.NestedDiagnosticsContext.StackPopper" /> class.
			/// </summary>
			/// <param name="stack">The stack.</param>
			/// <param name="previousCount">The previous count.</param>
			// Token: 0x06000792 RID: 1938 RVA: 0x0001A9A0 File Offset: 0x00018BA0
			public StackPopper(Stack<string> stack, int previousCount)
			{
				this.stack = stack;
				this.previousCount = previousCount;
			}

			/// <summary>
			/// Reverts the stack to original item count.
			/// </summary>
			// Token: 0x06000793 RID: 1939 RVA: 0x0001A9BC File Offset: 0x00018BBC
			void IDisposable.Dispose()
			{
				while (this.stack.Count > this.previousCount)
				{
					this.stack.Pop();
				}
			}

			// Token: 0x0400022C RID: 556
			private Stack<string> stack;

			// Token: 0x0400022D RID: 557
			private int previousCount;
		}
	}
}
