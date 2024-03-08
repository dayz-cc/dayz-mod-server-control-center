using System;

namespace NLog.Time
{
	/// <summary>
	/// Fast UTC time source that is updated once per tick (15.6 milliseconds).
	/// </summary>
	// Token: 0x02000148 RID: 328
	[TimeSource("FastUTC")]
	public class FastUtcTimeSource : CachedTimeSource
	{
		/// <summary>
		/// Gets uncached UTC time directly from DateTime.UtcNow.
		/// </summary>
		// Token: 0x17000248 RID: 584
		// (get) Token: 0x06000A95 RID: 2709 RVA: 0x00025858 File Offset: 0x00023A58
		protected override DateTime FreshTime
		{
			get
			{
				return DateTime.UtcNow;
			}
		}
	}
}
