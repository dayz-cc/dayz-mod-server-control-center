using System;

namespace NLog.Time
{
	/// <summary>
	/// Fast time source that updates current time only once per tick (15.6 milliseconds).
	/// </summary>
	// Token: 0x02000146 RID: 326
	public abstract class CachedTimeSource : TimeSource
	{
		/// <summary>
		/// Gets raw uncached time from derived time source.
		/// </summary>
		// Token: 0x17000245 RID: 581
		// (get) Token: 0x06000A90 RID: 2704
		protected abstract DateTime FreshTime { get; }

		/// <summary>
		/// Gets current time cached for one system tick (15.6 milliseconds).
		/// </summary>
		// Token: 0x17000246 RID: 582
		// (get) Token: 0x06000A91 RID: 2705 RVA: 0x000257D4 File Offset: 0x000239D4
		public override DateTime Time
		{
			get
			{
				int tickCount = Environment.TickCount;
				DateTime dateTime;
				if (tickCount == this.lastTicks)
				{
					dateTime = this.lastTime;
				}
				else
				{
					DateTime freshTime = this.FreshTime;
					this.lastTicks = tickCount;
					this.lastTime = freshTime;
					dateTime = freshTime;
				}
				return dateTime;
			}
		}

		// Token: 0x0400037F RID: 895
		private int lastTicks = -1;

		// Token: 0x04000380 RID: 896
		private DateTime lastTime = DateTime.MinValue;
	}
}
