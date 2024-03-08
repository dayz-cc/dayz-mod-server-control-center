using System;

namespace NLog.Common
{
	/// <summary>
	/// A cyclic buffer of <see cref="T:NLog.LogEventInfo" /> object.
	/// </summary>
	// Token: 0x0200000C RID: 12
	public class LogEventInfoBuffer
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Common.LogEventInfoBuffer" /> class.
		/// </summary>
		/// <param name="size">Buffer size.</param>
		/// <param name="growAsNeeded">Whether buffer should grow as it becomes full.</param>
		/// <param name="growLimit">The maximum number of items that the buffer can grow to.</param>
		// Token: 0x06000078 RID: 120 RVA: 0x000031BC File Offset: 0x000013BC
		public LogEventInfoBuffer(int size, bool growAsNeeded, int growLimit)
		{
			this.growAsNeeded = growAsNeeded;
			this.buffer = new AsyncLogEventInfo[size];
			this.growLimit = growLimit;
			this.getPointer = 0;
			this.putPointer = 0;
		}

		/// <summary>
		/// Gets the number of items in the array.
		/// </summary>
		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000079 RID: 121 RVA: 0x000031F0 File Offset: 0x000013F0
		public int Size
		{
			get
			{
				return this.buffer.Length;
			}
		}

		/// <summary>
		/// Adds the specified log event to the buffer.
		/// </summary>
		/// <param name="eventInfo">Log event.</param>
		/// <returns>The number of items in the buffer.</returns>
		// Token: 0x0600007A RID: 122 RVA: 0x0000320C File Offset: 0x0000140C
		public int Append(AsyncLogEventInfo eventInfo)
		{
			int num2;
			lock (this)
			{
				if (this.count >= this.buffer.Length)
				{
					if (this.growAsNeeded && this.buffer.Length < this.growLimit)
					{
						int num = this.buffer.Length * 2;
						if (num >= this.growLimit)
						{
							num = this.growLimit;
						}
						AsyncLogEventInfo[] array = new AsyncLogEventInfo[num];
						Array.Copy(this.buffer, 0, array, 0, this.buffer.Length);
						this.buffer = array;
					}
					else
					{
						this.getPointer++;
					}
				}
				this.putPointer %= this.buffer.Length;
				this.buffer[this.putPointer] = eventInfo;
				this.putPointer++;
				this.count++;
				if (this.count >= this.buffer.Length)
				{
					this.count = this.buffer.Length;
				}
				num2 = this.count;
			}
			return num2;
		}

		/// <summary>
		/// Gets the array of events accumulated in the buffer and clears the buffer as one atomic operation.
		/// </summary>
		/// <returns>Events in the buffer.</returns>
		// Token: 0x0600007B RID: 123 RVA: 0x00003370 File Offset: 0x00001570
		public AsyncLogEventInfo[] GetEventsAndClear()
		{
			AsyncLogEventInfo[] array2;
			lock (this)
			{
				int num = this.count;
				AsyncLogEventInfo[] array = new AsyncLogEventInfo[num];
				for (int i = 0; i < num; i++)
				{
					int num2 = (this.getPointer + i) % this.buffer.Length;
					AsyncLogEventInfo asyncLogEventInfo = this.buffer[num2];
					this.buffer[num2] = default(AsyncLogEventInfo);
					array[i] = asyncLogEventInfo;
				}
				this.count = 0;
				this.getPointer = 0;
				this.putPointer = 0;
				array2 = array;
			}
			return array2;
		}

		// Token: 0x0400000D RID: 13
		private readonly bool growAsNeeded;

		// Token: 0x0400000E RID: 14
		private readonly int growLimit;

		// Token: 0x0400000F RID: 15
		private AsyncLogEventInfo[] buffer;

		// Token: 0x04000010 RID: 16
		private int getPointer;

		// Token: 0x04000011 RID: 17
		private int putPointer;

		// Token: 0x04000012 RID: 18
		private int count;
	}
}
