using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Threading;
using NLog.Internal;

namespace NLog.Common
{
	/// <summary>
	/// Helpers for asynchronous operations.
	/// </summary>
	// Token: 0x02000007 RID: 7
	public static class AsyncHelpers
	{
		/// <summary>
		/// Iterates over all items in the given collection and runs the specified action
		/// in sequence (each action executes only after the preceding one has completed without an error).
		/// </summary>
		/// <typeparam name="T">Type of each item.</typeparam>
		/// <param name="items">The items to iterate.</param>
		/// <param name="asyncContinuation">The asynchronous continuation to invoke once all items
		/// have been iterated.</param>
		/// <param name="action">The action to invoke for each item.</param>
		// Token: 0x06000038 RID: 56 RVA: 0x000023A4 File Offset: 0x000005A4
		public static void ForEachItemSequentially<T>(IEnumerable<T> items, AsyncContinuation asyncContinuation, AsynchronousAction<T> action)
		{
			action = AsyncHelpers.ExceptionGuard<T>(action);
			AsyncContinuation invokeNext = null;
			IEnumerator<T> enumerator = items.GetEnumerator();
			invokeNext = delegate(Exception ex)
			{
				if (ex != null)
				{
					asyncContinuation(ex);
				}
				else if (!enumerator.MoveNext())
				{
					asyncContinuation(null);
				}
				else
				{
					action(enumerator.Current, AsyncHelpers.PreventMultipleCalls(invokeNext));
				}
			};
			invokeNext(null);
		}

		/// <summary>
		/// Repeats the specified asynchronous action multiple times and invokes asynchronous continuation at the end.
		/// </summary>
		/// <param name="repeatCount">The repeat count.</param>
		/// <param name="asyncContinuation">The asynchronous continuation to invoke at the end.</param>
		/// <param name="action">The action to invoke.</param>
		// Token: 0x06000039 RID: 57 RVA: 0x0000247C File Offset: 0x0000067C
		public static void Repeat(int repeatCount, AsyncContinuation asyncContinuation, AsynchronousAction action)
		{
			action = AsyncHelpers.ExceptionGuard(action);
			AsyncContinuation invokeNext = null;
			int remaining = repeatCount;
			invokeNext = delegate(Exception ex)
			{
				if (ex != null)
				{
					asyncContinuation(ex);
				}
				else if (remaining-- <= 0)
				{
					asyncContinuation(null);
				}
				else
				{
					action(AsyncHelpers.PreventMultipleCalls(invokeNext));
				}
			};
			invokeNext(null);
		}

		/// <summary>
		/// Modifies the continuation by pre-pending given action to execute just before it.
		/// </summary>
		/// <param name="asyncContinuation">The async continuation.</param>
		/// <param name="action">The action to pre-pend.</param>
		/// <returns>Continuation which will execute the given action before forwarding to the actual continuation.</returns>
		// Token: 0x0600003A RID: 58 RVA: 0x00002528 File Offset: 0x00000728
		public static AsyncContinuation PrecededBy(AsyncContinuation asyncContinuation, AsynchronousAction action)
		{
			action = AsyncHelpers.ExceptionGuard(action);
			return delegate(Exception ex)
			{
				if (ex != null)
				{
					asyncContinuation(ex);
				}
				else
				{
					action(AsyncHelpers.PreventMultipleCalls(asyncContinuation));
				}
			};
		}

		/// <summary>
		/// Attaches a timeout to a continuation which will invoke the continuation when the specified
		/// timeout has elapsed.
		/// </summary>
		/// <param name="asyncContinuation">The asynchronous continuation.</param>
		/// <param name="timeout">The timeout.</param>
		/// <returns>Wrapped continuation.</returns>
		// Token: 0x0600003B RID: 59 RVA: 0x00002570 File Offset: 0x00000770
		[SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "Continuation will be disposed of elsewhere.")]
		public static AsyncContinuation WithTimeout(AsyncContinuation asyncContinuation, TimeSpan timeout)
		{
			return new AsyncContinuation(new TimeoutContinuation(asyncContinuation, timeout).Function);
		}

		/// <summary>
		/// Iterates over all items in the given collection and runs the specified action
		/// in parallel (each action executes on a thread from thread pool).
		/// </summary>
		/// <typeparam name="T">Type of each item.</typeparam>
		/// <param name="values">The items to iterate.</param>
		/// <param name="asyncContinuation">The asynchronous continuation to invoke once all items
		/// have been iterated.</param>
		/// <param name="action">The action to invoke for each item.</param>
		// Token: 0x0600003C RID: 60 RVA: 0x00002694 File Offset: 0x00000894
		public static void ForEachItemInParallel<T>(IEnumerable<T> values, AsyncContinuation asyncContinuation, AsynchronousAction<T> action)
		{
			action = AsyncHelpers.ExceptionGuard<T>(action);
			List<T> list = new List<T>(values);
			int remaining = list.Count;
			List<Exception> exceptions = new List<Exception>();
			InternalLogger.Trace("ForEachItemInParallel() {0} items", new object[] { list.Count });
			if (remaining == 0)
			{
				asyncContinuation(null);
			}
			else
			{
				AsyncContinuation continuation = delegate(Exception ex)
				{
					InternalLogger.Trace("Continuation invoked: {0}", new object[] { ex });
					if (ex != null)
					{
						lock (exceptions)
						{
							exceptions.Add(ex);
						}
					}
					int num = Interlocked.Decrement(ref remaining);
					InternalLogger.Trace("Parallel task completed. {0} items remaining", new object[] { num });
					if (num == 0)
					{
						asyncContinuation(AsyncHelpers.GetCombinedException(exceptions));
					}
				};
				foreach (T t in list)
				{
					T itemCopy = t;
					ThreadPool.QueueUserWorkItem(delegate(object s)
					{
						action(itemCopy, AsyncHelpers.PreventMultipleCalls(continuation));
					});
				}
			}
		}

		/// <summary>
		/// Runs the specified asynchronous action synchronously (blocks until the continuation has
		/// been invoked).
		/// </summary>
		/// <param name="action">The action.</param>
		/// <remarks>
		/// Using this method is not recommended because it will block the calling thread.
		/// </remarks>
		// Token: 0x0600003D RID: 61 RVA: 0x000027C8 File Offset: 0x000009C8
		public static void RunSynchronously(AsynchronousAction action)
		{
			ManualResetEvent ev = new ManualResetEvent(false);
			Exception lastException = null;
			action(AsyncHelpers.PreventMultipleCalls(delegate(Exception ex)
			{
				lastException = ex;
				ev.Set();
			}));
			ev.WaitOne();
			if (lastException != null)
			{
				throw new NLogRuntimeException("Asynchronous exception has occurred.", lastException);
			}
		}

		/// <summary>
		/// Wraps the continuation with a guard which will only make sure that the continuation function
		/// is invoked only once.
		/// </summary>
		/// <param name="asyncContinuation">The asynchronous continuation.</param>
		/// <returns>Wrapped asynchronous continuation.</returns>
		// Token: 0x0600003E RID: 62 RVA: 0x00002834 File Offset: 0x00000A34
		public static AsyncContinuation PreventMultipleCalls(AsyncContinuation asyncContinuation)
		{
			AsyncContinuation asyncContinuation2;
			if (asyncContinuation.Target is SingleCallContinuation)
			{
				asyncContinuation2 = asyncContinuation;
			}
			else
			{
				asyncContinuation2 = new AsyncContinuation(new SingleCallContinuation(asyncContinuation).Function);
			}
			return asyncContinuation2;
		}

		/// <summary>
		/// Gets the combined exception from all exceptions in the list.
		/// </summary>
		/// <param name="exceptions">The exceptions.</param>
		/// <returns>Combined exception or null if no exception was thrown.</returns>
		// Token: 0x0600003F RID: 63 RVA: 0x00002874 File Offset: 0x00000A74
		public static Exception GetCombinedException(IList<Exception> exceptions)
		{
			Exception ex;
			if (exceptions.Count == 0)
			{
				ex = null;
			}
			else if (exceptions.Count == 1)
			{
				ex = exceptions[0];
			}
			else
			{
				StringBuilder stringBuilder = new StringBuilder();
				string text = string.Empty;
				string newLine = EnvironmentHelper.NewLine;
				foreach (Exception ex2 in exceptions)
				{
					stringBuilder.Append(text);
					stringBuilder.Append(ex2.ToString());
					stringBuilder.Append(newLine);
					text = newLine;
				}
				ex = new NLogRuntimeException("Got multiple exceptions:\r\n" + stringBuilder);
			}
			return ex;
		}

		// Token: 0x06000040 RID: 64 RVA: 0x000029A4 File Offset: 0x00000BA4
		private static AsynchronousAction ExceptionGuard(AsynchronousAction action)
		{
			return delegate(AsyncContinuation cont)
			{
				try
				{
					action(cont);
				}
				catch (Exception ex)
				{
					if (ex.MustBeRethrown())
					{
						throw;
					}
					cont(ex);
				}
			};
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00002A28 File Offset: 0x00000C28
		private static AsynchronousAction<T> ExceptionGuard<T>(AsynchronousAction<T> action)
		{
			return delegate(T argument, AsyncContinuation cont)
			{
				try
				{
					action(argument, cont);
				}
				catch (Exception ex)
				{
					if (ex.MustBeRethrown())
					{
						throw;
					}
					cont(ex);
				}
			};
		}
	}
}
