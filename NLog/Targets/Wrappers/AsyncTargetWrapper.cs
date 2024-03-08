using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using NLog.Common;
using NLog.Internal;

namespace NLog.Targets.Wrappers
{
	/// <summary>
	/// Provides asynchronous, buffered execution of target writes.
	/// </summary>
	/// <seealso href="http://nlog-project.org/wiki/AsyncWrapper_target">Documentation on NLog Wiki</seealso>
	/// <remarks>
	/// <p>
	/// Asynchronous target wrapper allows the logger code to execute more quickly, by queueing
	/// messages and processing them in a separate thread. You should wrap targets
	/// that spend a non-trivial amount of time in their Write() method with asynchronous
	/// target to speed up logging.
	/// </p>
	/// <p>
	/// Because asynchronous logging is quite a common scenario, NLog supports a
	/// shorthand notation for wrapping all targets with AsyncWrapper. Just add async="true" to
	/// the &lt;targets/&gt; element in the configuration file.
	/// </p>
	/// <code lang="XML">
	/// <![CDATA[
	/// <targets async="true">
	///    ... your targets go here ...
	/// </targets>
	/// ]]></code>
	/// </remarks>
	/// <example>
	/// <p>
	/// To set up the target in the <a href="config.html">configuration file</a>, 
	/// use the following syntax:
	/// </p>
	/// <code lang="XML" source="examples/targets/Configuration File/AsyncWrapper/NLog.config" />
	/// <p>
	/// The above examples assume just one target and a single rule. See below for
	/// a programmatic configuration that's equivalent to the above config file:
	/// </p>
	/// <code lang="C#" source="examples/targets/Configuration API/AsyncWrapper/Wrapping File/Example.cs" />
	/// </example>
	// Token: 0x02000130 RID: 304
	[Target("AsyncWrapper", IsWrapper = true)]
	public class AsyncTargetWrapper : WrapperTargetBase
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Targets.Wrappers.AsyncTargetWrapper" /> class.
		/// </summary>
		// Token: 0x06000A11 RID: 2577 RVA: 0x00023C1A File Offset: 0x00021E1A
		public AsyncTargetWrapper()
			: this(null)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Targets.Wrappers.AsyncTargetWrapper" /> class.
		/// </summary>
		/// <param name="wrappedTarget">The wrapped target.</param>
		// Token: 0x06000A12 RID: 2578 RVA: 0x00023C26 File Offset: 0x00021E26
		public AsyncTargetWrapper(Target wrappedTarget)
			: this(wrappedTarget, 10000, AsyncTargetWrapperOverflowAction.Discard)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Targets.Wrappers.AsyncTargetWrapper" /> class.
		/// </summary>
		/// <param name="wrappedTarget">The wrapped target.</param>
		/// <param name="queueLimit">Maximum number of requests in the queue.</param>
		/// <param name="overflowAction">The action to be taken when the queue overflows.</param>
		// Token: 0x06000A13 RID: 2579 RVA: 0x00023C38 File Offset: 0x00021E38
		public AsyncTargetWrapper(Target wrappedTarget, int queueLimit, AsyncTargetWrapperOverflowAction overflowAction)
		{
			this.RequestQueue = new AsyncRequestQueue(10000, AsyncTargetWrapperOverflowAction.Discard);
			this.TimeToSleepBetweenBatches = 50;
			this.BatchSize = 100;
			base.WrappedTarget = wrappedTarget;
			this.QueueLimit = queueLimit;
			this.OverflowAction = overflowAction;
		}

		/// <summary>
		/// Gets or sets the number of log events that should be processed in a batch
		/// by the lazy writer thread.
		/// </summary>
		/// <docgen category="Buffering Options" order="100" />
		// Token: 0x17000228 RID: 552
		// (get) Token: 0x06000A14 RID: 2580 RVA: 0x00023CAC File Offset: 0x00021EAC
		// (set) Token: 0x06000A15 RID: 2581 RVA: 0x00023CC3 File Offset: 0x00021EC3
		[DefaultValue(100)]
		public int BatchSize { get; set; }

		/// <summary>
		/// Gets or sets the time in milliseconds to sleep between batches.
		/// </summary>
		/// <docgen category="Buffering Options" order="100" />
		// Token: 0x17000229 RID: 553
		// (get) Token: 0x06000A16 RID: 2582 RVA: 0x00023CCC File Offset: 0x00021ECC
		// (set) Token: 0x06000A17 RID: 2583 RVA: 0x00023CE3 File Offset: 0x00021EE3
		[DefaultValue(50)]
		public int TimeToSleepBetweenBatches { get; set; }

		/// <summary>
		/// Gets or sets the action to be taken when the lazy writer thread request queue count
		/// exceeds the set limit.
		/// </summary>
		/// <docgen category="Buffering Options" order="100" />
		// Token: 0x1700022A RID: 554
		// (get) Token: 0x06000A18 RID: 2584 RVA: 0x00023CEC File Offset: 0x00021EEC
		// (set) Token: 0x06000A19 RID: 2585 RVA: 0x00023D09 File Offset: 0x00021F09
		[DefaultValue("Discard")]
		public AsyncTargetWrapperOverflowAction OverflowAction
		{
			get
			{
				return this.RequestQueue.OnOverflow;
			}
			set
			{
				this.RequestQueue.OnOverflow = value;
			}
		}

		/// <summary>
		/// Gets or sets the limit on the number of requests in the lazy writer thread request queue.
		/// </summary>
		/// <docgen category="Buffering Options" order="100" />
		// Token: 0x1700022B RID: 555
		// (get) Token: 0x06000A1A RID: 2586 RVA: 0x00023D1C File Offset: 0x00021F1C
		// (set) Token: 0x06000A1B RID: 2587 RVA: 0x00023D39 File Offset: 0x00021F39
		[DefaultValue(10000)]
		public int QueueLimit
		{
			get
			{
				return this.RequestQueue.RequestLimit;
			}
			set
			{
				this.RequestQueue.RequestLimit = value;
			}
		}

		/// <summary>
		/// Gets the queue of lazy writer thread requests.
		/// </summary>
		// Token: 0x1700022C RID: 556
		// (get) Token: 0x06000A1C RID: 2588 RVA: 0x00023D4C File Offset: 0x00021F4C
		// (set) Token: 0x06000A1D RID: 2589 RVA: 0x00023D63 File Offset: 0x00021F63
		internal AsyncRequestQueue RequestQueue { get; private set; }

		/// <summary>
		/// Waits for the lazy writer thread to finish writing messages.
		/// </summary>
		/// <param name="asyncContinuation">The asynchronous continuation.</param>
		// Token: 0x06000A1E RID: 2590 RVA: 0x00023D6C File Offset: 0x00021F6C
		protected override void FlushAsync(AsyncContinuation asyncContinuation)
		{
			lock (this.continuationQueueLock)
			{
				this.flushAllContinuations.Enqueue(asyncContinuation);
			}
		}

		/// <summary>
		/// Initializes the target by starting the lazy writer timer.
		/// </summary>
		// Token: 0x06000A1F RID: 2591 RVA: 0x00023DC0 File Offset: 0x00021FC0
		protected override void InitializeTarget()
		{
			base.InitializeTarget();
			this.RequestQueue.Clear();
			this.lazyWriterTimer = new Timer(new TimerCallback(this.ProcessPendingEvents), null, -1, -1);
			this.StartLazyWriterTimer();
		}

		/// <summary>
		/// Shuts down the lazy writer timer.
		/// </summary>
		// Token: 0x06000A20 RID: 2592 RVA: 0x00023DF8 File Offset: 0x00021FF8
		protected override void CloseTarget()
		{
			this.StopLazyWriterThread();
			if (this.RequestQueue.RequestCount > 0)
			{
				this.ProcessPendingEvents(null);
			}
			base.CloseTarget();
		}

		/// <summary>
		/// Starts the lazy writer thread which periodically writes
		/// queued log messages.
		/// </summary>
		// Token: 0x06000A21 RID: 2593 RVA: 0x00023E34 File Offset: 0x00022034
		protected virtual void StartLazyWriterTimer()
		{
			lock (this.lockObject)
			{
				if (this.lazyWriterTimer != null)
				{
					this.lazyWriterTimer.Change(this.TimeToSleepBetweenBatches, -1);
				}
			}
		}

		/// <summary>
		/// Starts the lazy writer thread.
		/// </summary>
		// Token: 0x06000A22 RID: 2594 RVA: 0x00023E9C File Offset: 0x0002209C
		protected virtual void StopLazyWriterThread()
		{
			lock (this.lockObject)
			{
				if (this.lazyWriterTimer != null)
				{
					this.lazyWriterTimer.Change(-1, -1);
					this.lazyWriterTimer = null;
				}
			}
		}

		/// <summary>
		/// Adds the log event to asynchronous queue to be processed by
		/// the lazy writer thread.
		/// </summary>
		/// <param name="logEvent">The log event.</param>
		/// <remarks>
		/// The <see cref="M:NLog.Targets.Target.PrecalculateVolatileLayouts(NLog.LogEventInfo)" /> is called
		/// to ensure that the log event can be processed in another thread.
		/// </remarks>
		// Token: 0x06000A23 RID: 2595 RVA: 0x00023F08 File Offset: 0x00022108
		protected override void Write(AsyncLogEventInfo logEvent)
		{
			base.PrecalculateVolatileLayouts(logEvent.LogEvent);
			this.RequestQueue.Enqueue(logEvent);
		}

		// Token: 0x06000A24 RID: 2596 RVA: 0x00023F48 File Offset: 0x00022148
		private void ProcessPendingEvents(object state)
		{
			AsyncContinuation[] array3;
			lock (this.continuationQueueLock)
			{
				AsyncContinuation[] array2;
				if (this.flushAllContinuations.Count <= 0)
				{
					AsyncContinuation[] array = new AsyncContinuation[1];
					array2 = array;
				}
				else
				{
					array2 = this.flushAllContinuations.ToArray();
				}
				array3 = array2;
				this.flushAllContinuations.Clear();
			}
			try
			{
				AsyncContinuation[] array4 = array3;
				for (int i = 0; i < array4.Length; i++)
				{
					AsyncContinuation continuation = array4[i];
					int num = this.BatchSize;
					if (continuation != null)
					{
						num = this.RequestQueue.RequestCount;
						InternalLogger.Trace("Flushing {0} events.", new object[] { num });
					}
					if (this.RequestQueue.RequestCount == 0)
					{
						if (continuation != null)
						{
							continuation(null);
						}
					}
					AsyncLogEventInfo[] array5 = this.RequestQueue.DequeueBatch(num);
					if (continuation != null)
					{
						base.WrappedTarget.WriteAsyncLogEvents(array5, delegate(Exception ex)
						{
							this.WrappedTarget.Flush(continuation);
						});
					}
					else
					{
						base.WrappedTarget.WriteAsyncLogEvents(array5);
					}
				}
			}
			catch (Exception ex)
			{
				Exception ex2;
				if (ex2.MustBeRethrown())
				{
					throw;
				}
				InternalLogger.Error("Error in lazy writer timer procedure: {0}", new object[] { ex2 });
			}
			finally
			{
				this.StartLazyWriterTimer();
			}
		}

		// Token: 0x04000344 RID: 836
		private readonly object lockObject = new object();

		// Token: 0x04000345 RID: 837
		private Timer lazyWriterTimer;

		// Token: 0x04000346 RID: 838
		private readonly Queue<AsyncContinuation> flushAllContinuations = new Queue<AsyncContinuation>();

		// Token: 0x04000347 RID: 839
		private readonly object continuationQueueLock = new object();
	}
}
