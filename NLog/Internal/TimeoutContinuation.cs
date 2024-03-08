using System;
using System.Threading;
using NLog.Common;

namespace NLog.Internal
{
	/// <summary>
	/// Wraps <see cref="T:NLog.Common.AsyncContinuation" /> with a timeout.
	/// </summary>
	// Token: 0x0200008C RID: 140
	internal class TimeoutContinuation : IDisposable
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Internal.TimeoutContinuation" /> class.
		/// </summary>
		/// <param name="asyncContinuation">The asynchronous continuation.</param>
		/// <param name="timeout">The timeout.</param>
		// Token: 0x06000359 RID: 857 RVA: 0x0000D2EA File Offset: 0x0000B4EA
		public TimeoutContinuation(AsyncContinuation asyncContinuation, TimeSpan timeout)
		{
			this.asyncContinuation = asyncContinuation;
			this.timeoutTimer = new Timer(new TimerCallback(this.TimerElapsed), null, timeout, TimeSpan.FromMilliseconds(-1.0));
		}

		/// <summary>
		/// Continuation function which implements the timeout logic.
		/// </summary>
		/// <param name="exception">The exception.</param>
		// Token: 0x0600035A RID: 858 RVA: 0x0000D324 File Offset: 0x0000B524
		public void Function(Exception exception)
		{
			try
			{
				this.StopTimer();
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
				TimeoutContinuation.ReportExceptionInHandler(ex);
			}
		}

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		// Token: 0x0600035B RID: 859 RVA: 0x0000D38C File Offset: 0x0000B58C
		public void Dispose()
		{
			this.StopTimer();
			GC.SuppressFinalize(this);
		}

		// Token: 0x0600035C RID: 860 RVA: 0x0000D3A0 File Offset: 0x0000B5A0
		private static void ReportExceptionInHandler(Exception exception)
		{
			InternalLogger.Error("Exception in asynchronous handler {0}", new object[] { exception });
		}

		// Token: 0x0600035D RID: 861 RVA: 0x0000D3C8 File Offset: 0x0000B5C8
		private void StopTimer()
		{
			lock (this)
			{
				if (this.timeoutTimer != null)
				{
					this.timeoutTimer.Dispose();
					this.timeoutTimer = null;
				}
			}
		}

		// Token: 0x0600035E RID: 862 RVA: 0x0000D42C File Offset: 0x0000B62C
		private void TimerElapsed(object state)
		{
			this.Function(new TimeoutException("Timeout."));
		}

		// Token: 0x040000E2 RID: 226
		private AsyncContinuation asyncContinuation;

		// Token: 0x040000E3 RID: 227
		private Timer timeoutTimer;
	}
}
