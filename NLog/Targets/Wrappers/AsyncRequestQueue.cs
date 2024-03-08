using System;
using System.Collections.Generic;
using System.Threading;
using NLog.Common;

namespace NLog.Targets.Wrappers
{
	/// <summary>
	/// Asynchronous request queue.
	/// </summary>
	// Token: 0x0200012E RID: 302
	internal class AsyncRequestQueue
	{
		/// <summary>
		/// Initializes a new instance of the AsyncRequestQueue class.
		/// </summary>
		/// <param name="requestLimit">Request limit.</param>
		/// <param name="overflowAction">The overflow action.</param>
		// Token: 0x06000A02 RID: 2562 RVA: 0x00023914 File Offset: 0x00021B14
		public AsyncRequestQueue(int requestLimit, AsyncTargetWrapperOverflowAction overflowAction)
		{
			this.RequestLimit = requestLimit;
			this.OnOverflow = overflowAction;
		}

		/// <summary>
		/// Gets or sets the request limit.
		/// </summary>
		// Token: 0x17000224 RID: 548
		// (get) Token: 0x06000A03 RID: 2563 RVA: 0x0002393C File Offset: 0x00021B3C
		// (set) Token: 0x06000A04 RID: 2564 RVA: 0x00023953 File Offset: 0x00021B53
		public int RequestLimit { get; set; }

		/// <summary>
		/// Gets or sets the action to be taken when there's no more room in
		/// the queue and another request is enqueued.
		/// </summary>
		// Token: 0x17000225 RID: 549
		// (get) Token: 0x06000A05 RID: 2565 RVA: 0x0002395C File Offset: 0x00021B5C
		// (set) Token: 0x06000A06 RID: 2566 RVA: 0x00023973 File Offset: 0x00021B73
		public AsyncTargetWrapperOverflowAction OnOverflow { get; set; }

		/// <summary>
		/// Gets the number of requests currently in the queue.
		/// </summary>
		// Token: 0x17000226 RID: 550
		// (get) Token: 0x06000A07 RID: 2567 RVA: 0x0002397C File Offset: 0x00021B7C
		public int RequestCount
		{
			get
			{
				return this.logEventInfoQueue.Count;
			}
		}

		/// <summary>
		/// Enqueues another item. If the queue is overflown the appropriate
		/// action is taken as specified by <see cref="P:NLog.Targets.Wrappers.AsyncRequestQueue.OnOverflow" />.
		/// </summary>
		/// <param name="logEventInfo">The log event info.</param>
		// Token: 0x06000A08 RID: 2568 RVA: 0x0002399C File Offset: 0x00021B9C
		public void Enqueue(AsyncLogEventInfo logEventInfo)
		{
			lock (this)
			{
				if (this.logEventInfoQueue.Count >= this.RequestLimit)
				{
					InternalLogger.Debug("Async queue is full");
					switch (this.OnOverflow)
					{
					case AsyncTargetWrapperOverflowAction.Grow:
						InternalLogger.Debug("The overflow action is Grow, adding element anyway");
						break;
					case AsyncTargetWrapperOverflowAction.Discard:
						InternalLogger.Debug("Discarding one element from queue");
						this.logEventInfoQueue.Dequeue();
						break;
					case AsyncTargetWrapperOverflowAction.Block:
						while (this.logEventInfoQueue.Count >= this.RequestLimit)
						{
							InternalLogger.Debug("Blocking because the overflow action is Block...");
							Monitor.Wait(this);
							InternalLogger.Trace("Entered critical section.");
						}
						InternalLogger.Trace("Limit ok.");
						break;
					}
				}
				this.logEventInfoQueue.Enqueue(logEventInfo);
			}
		}

		/// <summary>
		/// Dequeues a maximum of <c>count</c> items from the queue
		/// and adds returns the list containing them.
		/// </summary>
		/// <param name="count">Maximum number of items to be dequeued.</param>
		/// <returns>The array of log events.</returns>
		// Token: 0x06000A09 RID: 2569 RVA: 0x00023A9C File Offset: 0x00021C9C
		public AsyncLogEventInfo[] DequeueBatch(int count)
		{
			List<AsyncLogEventInfo> list = new List<AsyncLogEventInfo>();
			lock (this)
			{
				for (int i = 0; i < count; i++)
				{
					if (this.logEventInfoQueue.Count <= 0)
					{
						break;
					}
					list.Add(this.logEventInfoQueue.Dequeue());
				}
				if (this.OnOverflow == AsyncTargetWrapperOverflowAction.Block)
				{
					Monitor.PulseAll(this);
				}
			}
			return list.ToArray();
		}

		/// <summary>
		/// Clears the queue.
		/// </summary>
		// Token: 0x06000A0A RID: 2570 RVA: 0x00023B48 File Offset: 0x00021D48
		public void Clear()
		{
			lock (this)
			{
				this.logEventInfoQueue.Clear();
			}
		}

		// Token: 0x04000340 RID: 832
		private readonly Queue<AsyncLogEventInfo> logEventInfoQueue = new Queue<AsyncLogEventInfo>();
	}
}
