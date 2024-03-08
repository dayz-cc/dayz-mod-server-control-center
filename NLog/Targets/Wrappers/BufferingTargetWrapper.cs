using System;
using System.ComponentModel;
using System.Threading;
using NLog.Common;

namespace NLog.Targets.Wrappers
{
	/// <summary>
	/// A target that buffers log events and sends them in batches to the wrapped target.
	/// </summary>
	/// <seealso href="http://nlog-project.org/wiki/BufferingWrapper_target">Documentation on NLog Wiki</seealso>
	// Token: 0x02000133 RID: 307
	[Target("BufferingWrapper", IsWrapper = true)]
	public class BufferingTargetWrapper : WrapperTargetBase
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Targets.Wrappers.BufferingTargetWrapper" /> class.
		/// </summary>
		// Token: 0x06000A28 RID: 2600 RVA: 0x000241AF File Offset: 0x000223AF
		public BufferingTargetWrapper()
			: this(null)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Targets.Wrappers.BufferingTargetWrapper" /> class.
		/// </summary>
		/// <param name="wrappedTarget">The wrapped target.</param>
		// Token: 0x06000A29 RID: 2601 RVA: 0x000241BB File Offset: 0x000223BB
		public BufferingTargetWrapper(Target wrappedTarget)
			: this(wrappedTarget, 100)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Targets.Wrappers.BufferingTargetWrapper" /> class.
		/// </summary>
		/// <param name="wrappedTarget">The wrapped target.</param>
		/// <param name="bufferSize">Size of the buffer.</param>
		// Token: 0x06000A2A RID: 2602 RVA: 0x000241C9 File Offset: 0x000223C9
		public BufferingTargetWrapper(Target wrappedTarget, int bufferSize)
			: this(wrappedTarget, bufferSize, -1)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Targets.Wrappers.BufferingTargetWrapper" /> class.
		/// </summary>
		/// <param name="wrappedTarget">The wrapped target.</param>
		/// <param name="bufferSize">Size of the buffer.</param>
		/// <param name="flushTimeout">The flush timeout.</param>
		// Token: 0x06000A2B RID: 2603 RVA: 0x000241D7 File Offset: 0x000223D7
		public BufferingTargetWrapper(Target wrappedTarget, int bufferSize, int flushTimeout)
		{
			base.WrappedTarget = wrappedTarget;
			this.BufferSize = bufferSize;
			this.FlushTimeout = flushTimeout;
			this.SlidingTimeout = true;
		}

		/// <summary>
		/// Gets or sets the number of log events to be buffered.
		/// </summary>
		/// <docgen category="Buffering Options" order="100" />
		// Token: 0x1700022D RID: 557
		// (get) Token: 0x06000A2C RID: 2604 RVA: 0x00024204 File Offset: 0x00022404
		// (set) Token: 0x06000A2D RID: 2605 RVA: 0x0002421B File Offset: 0x0002241B
		[DefaultValue(100)]
		public int BufferSize { get; set; }

		/// <summary>
		/// Gets or sets the timeout (in milliseconds) after which the contents of buffer will be flushed 
		/// if there's no write in the specified period of time. Use -1 to disable timed flushes.
		/// </summary>
		/// <docgen category="Buffering Options" order="100" />
		// Token: 0x1700022E RID: 558
		// (get) Token: 0x06000A2E RID: 2606 RVA: 0x00024224 File Offset: 0x00022424
		// (set) Token: 0x06000A2F RID: 2607 RVA: 0x0002423B File Offset: 0x0002243B
		[DefaultValue(-1)]
		public int FlushTimeout { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether to use sliding timeout.
		/// </summary>
		/// <remarks>
		/// This value determines how the inactivity period is determined. If sliding timeout is enabled,
		/// the inactivity timer is reset after each write, if it is disabled - inactivity timer will 
		/// count from the first event written to the buffer. 
		/// </remarks>
		/// <docgen category="Buffering Options" order="100" />
		// Token: 0x1700022F RID: 559
		// (get) Token: 0x06000A30 RID: 2608 RVA: 0x00024244 File Offset: 0x00022444
		// (set) Token: 0x06000A31 RID: 2609 RVA: 0x0002425B File Offset: 0x0002245B
		[DefaultValue(true)]
		public bool SlidingTimeout { get; set; }

		/// <summary>
		/// Flushes pending events in the buffer (if any).
		/// </summary>
		/// <param name="asyncContinuation">The asynchronous continuation.</param>
		// Token: 0x06000A32 RID: 2610 RVA: 0x00024288 File Offset: 0x00022488
		protected override void FlushAsync(AsyncContinuation asyncContinuation)
		{
			AsyncLogEventInfo[] eventsAndClear = this.buffer.GetEventsAndClear();
			if (eventsAndClear.Length == 0)
			{
				base.WrappedTarget.Flush(asyncContinuation);
			}
			else
			{
				base.WrappedTarget.WriteAsyncLogEvents(eventsAndClear, delegate(Exception ex)
				{
					this.WrappedTarget.Flush(asyncContinuation);
				});
			}
		}

		/// <summary>
		/// Initializes the target.
		/// </summary>
		// Token: 0x06000A33 RID: 2611 RVA: 0x000242FE File Offset: 0x000224FE
		protected override void InitializeTarget()
		{
			base.InitializeTarget();
			this.buffer = new LogEventInfoBuffer(this.BufferSize, false, 0);
			this.flushTimer = new Timer(new TimerCallback(this.FlushCallback), null, -1, -1);
		}

		/// <summary>
		/// Closes the target by flushing pending events in the buffer (if any).
		/// </summary>
		// Token: 0x06000A34 RID: 2612 RVA: 0x00024338 File Offset: 0x00022538
		protected override void CloseTarget()
		{
			base.CloseTarget();
			if (this.flushTimer != null)
			{
				this.flushTimer.Dispose();
				this.flushTimer = null;
			}
		}

		/// <summary>
		/// Adds the specified log event to the buffer and flushes
		/// the buffer in case the buffer gets full.
		/// </summary>
		/// <param name="logEvent">The log event.</param>
		// Token: 0x06000A35 RID: 2613 RVA: 0x00024370 File Offset: 0x00022570
		protected override void Write(AsyncLogEventInfo logEvent)
		{
			base.WrappedTarget.PrecalculateVolatileLayouts(logEvent.LogEvent);
			int num = this.buffer.Append(logEvent);
			if (num >= this.BufferSize)
			{
				AsyncLogEventInfo[] eventsAndClear = this.buffer.GetEventsAndClear();
				base.WrappedTarget.WriteAsyncLogEvents(eventsAndClear);
			}
			else if (this.FlushTimeout > 0)
			{
				if (this.SlidingTimeout || num == 1)
				{
					this.flushTimer.Change(this.FlushTimeout, -1);
				}
			}
		}

		// Token: 0x06000A36 RID: 2614 RVA: 0x00024408 File Offset: 0x00022608
		private void FlushCallback(object state)
		{
			lock (base.SyncRoot)
			{
				if (base.IsInitialized)
				{
					AsyncLogEventInfo[] eventsAndClear = this.buffer.GetEventsAndClear();
					if (eventsAndClear.Length > 0)
					{
						base.WrappedTarget.WriteAsyncLogEvents(eventsAndClear);
					}
				}
			}
		}

		// Token: 0x0400034F RID: 847
		private LogEventInfoBuffer buffer;

		// Token: 0x04000350 RID: 848
		private Timer flushTimer;
	}
}
