using System;

namespace NLog.Time
{
	/// <summary>
	/// Fast local time source that is updated once per tick (15.6 milliseconds).
	/// </summary>
	// Token: 0x02000147 RID: 327
	[TimeSource("FastLocal")]
	public class FastLocalTimeSource : CachedTimeSource
	{
		/// <summary>
		/// Gets uncached local time directly from DateTime.Now.
		/// </summary>
		// Token: 0x17000247 RID: 583
		// (get) Token: 0x06000A93 RID: 2707 RVA: 0x00025838 File Offset: 0x00023A38
		protected override DateTime FreshTime
		{
			get
			{
				return DateTime.Now;
			}
		}
	}
}
