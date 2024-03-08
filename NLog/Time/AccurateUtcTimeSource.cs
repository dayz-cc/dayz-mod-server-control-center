using System;

namespace NLog.Time
{
	/// <summary>
	/// Current UTC time retrieved directly from DateTime.UtcNow.
	/// </summary>
	// Token: 0x02000145 RID: 325
	[TimeSource("AccurateUTC")]
	public class AccurateUtcTimeSource : TimeSource
	{
		/// <summary>
		/// Gets current UTC time directly from DateTime.UtcNow.
		/// </summary>
		// Token: 0x17000244 RID: 580
		// (get) Token: 0x06000A8E RID: 2702 RVA: 0x000257B4 File Offset: 0x000239B4
		public override DateTime Time
		{
			get
			{
				return DateTime.UtcNow;
			}
		}
	}
}
