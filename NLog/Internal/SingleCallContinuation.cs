using System;
using System.Threading;
using NLog.Common;

namespace NLog.Internal
{
	/// <summary>
	/// Implements a single-call guard around given continuation function.
	/// </summary>
	// Token: 0x02000086 RID: 134
	internal class SingleCallContinuation
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Internal.SingleCallContinuation" /> class.
		/// </summary>
		/// <param name="asyncContinuation">The asynchronous continuation.</param>
		// Token: 0x06000344 RID: 836 RVA: 0x0000D00D File Offset: 0x0000B20D
		public SingleCallContinuation(AsyncContinuation asyncContinuation)
		{
			this.asyncContinuation = asyncContinuation;
		}

		/// <summary>
		/// Continuation function which implements the single-call guard.
		/// </summary>
		/// <param name="exception">The exception.</param>
		// Token: 0x06000345 RID: 837 RVA: 0x0000D020 File Offset: 0x0000B220
		public void Function(Exception exception)
		{
			try
			{
				AsyncContinuation asyncContinuation = Interlocked.Exchange<AsyncContinuation>(ref this.asyncContinuation, null);
				if (asyncContinuation != null)
				{
					asyncContinuation(exception);
				}
			}
			catch (Exception ex)
			{
				if (ex.MustBeRethrown())
				{
					throw;
				}
				if (LogManager.ThrowExceptions)
				{
					throw;
				}
				SingleCallContinuation.ReportExceptionInHandler(ex);
			}
		}

		// Token: 0x06000346 RID: 838 RVA: 0x0000D090 File Offset: 0x0000B290
		private static void ReportExceptionInHandler(Exception exception)
		{
			InternalLogger.Error("Exception in asynchronous handler {0}", new object[] { exception });
		}

		// Token: 0x040000DD RID: 221
		private AsyncContinuation asyncContinuation;
	}
}
