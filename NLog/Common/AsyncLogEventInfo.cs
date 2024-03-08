using System;

namespace NLog.Common
{
	/// <summary>
	/// Represents the logging event with asynchronous continuation.
	/// </summary>
	// Token: 0x0200000A RID: 10
	public struct AsyncLogEventInfo
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Common.AsyncLogEventInfo" /> struct.
		/// </summary>
		/// <param name="logEvent">The log event.</param>
		/// <param name="continuation">The continuation.</param>
		// Token: 0x0600004A RID: 74 RVA: 0x00002A53 File Offset: 0x00000C53
		public AsyncLogEventInfo(LogEventInfo logEvent, AsyncContinuation continuation)
		{
			this = default(AsyncLogEventInfo);
			this.LogEvent = logEvent;
			this.Continuation = continuation;
		}

		/// <summary>
		/// Gets the log event.
		/// </summary>
		// Token: 0x17000015 RID: 21
		// (get) Token: 0x0600004B RID: 75 RVA: 0x00002A70 File Offset: 0x00000C70
		// (set) Token: 0x0600004C RID: 76 RVA: 0x00002A87 File Offset: 0x00000C87
		public LogEventInfo LogEvent { get; private set; }

		/// <summary>
		/// Gets the continuation.
		/// </summary>
		// Token: 0x17000016 RID: 22
		// (get) Token: 0x0600004D RID: 77 RVA: 0x00002A90 File Offset: 0x00000C90
		// (set) Token: 0x0600004E RID: 78 RVA: 0x00002AA7 File Offset: 0x00000CA7
		public AsyncContinuation Continuation { get; internal set; }

		/// <summary>
		/// Implements the operator ==.
		/// </summary>
		/// <param name="eventInfo1">The event info1.</param>
		/// <param name="eventInfo2">The event info2.</param>
		/// <returns>The result of the operator.</returns>
		// Token: 0x0600004F RID: 79 RVA: 0x00002AB0 File Offset: 0x00000CB0
		public static bool operator ==(AsyncLogEventInfo eventInfo1, AsyncLogEventInfo eventInfo2)
		{
			return object.ReferenceEquals(eventInfo1.Continuation, eventInfo2.Continuation) && object.ReferenceEquals(eventInfo1.LogEvent, eventInfo2.LogEvent);
		}

		/// <summary>
		/// Implements the operator ==.
		/// </summary>
		/// <param name="eventInfo1">The event info1.</param>
		/// <param name="eventInfo2">The event info2.</param>
		/// <returns>The result of the operator.</returns>
		// Token: 0x06000050 RID: 80 RVA: 0x00002AF0 File Offset: 0x00000CF0
		public static bool operator !=(AsyncLogEventInfo eventInfo1, AsyncLogEventInfo eventInfo2)
		{
			return !object.ReferenceEquals(eventInfo1.Continuation, eventInfo2.Continuation) || !object.ReferenceEquals(eventInfo1.LogEvent, eventInfo2.LogEvent);
		}

		/// <summary>
		/// Determines whether the specified <see cref="T:System.Object" /> is equal to this instance.
		/// </summary>
		/// <param name="obj">The <see cref="T:System.Object" /> to compare with this instance.</param>
		/// <returns>
		/// A value of <c>true</c> if the specified <see cref="T:System.Object" /> is equal to this instance; otherwise, <c>false</c>.
		/// </returns>
		// Token: 0x06000051 RID: 81 RVA: 0x00002B34 File Offset: 0x00000D34
		public override bool Equals(object obj)
		{
			AsyncLogEventInfo asyncLogEventInfo = (AsyncLogEventInfo)obj;
			return this == asyncLogEventInfo;
		}

		/// <summary>
		/// Returns a hash code for this instance.
		/// </summary>
		/// <returns>
		/// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
		/// </returns>
		// Token: 0x06000052 RID: 82 RVA: 0x00002B5C File Offset: 0x00000D5C
		public override int GetHashCode()
		{
			return this.LogEvent.GetHashCode() ^ this.Continuation.GetHashCode();
		}
	}
}
