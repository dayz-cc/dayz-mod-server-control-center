using System;

namespace NLog.Time
{
	/// <summary>
	/// Current local time retrieved directly from DateTime.Now.
	/// </summary>
	// Token: 0x02000144 RID: 324
	[TimeSource("AccurateLocal")]
	public class AccurateLocalTimeSource : TimeSource
	{
		/// <summary>
		/// Gets current local time directly from DateTime.Now.
		/// </summary>
		// Token: 0x17000243 RID: 579
		// (get) Token: 0x06000A8C RID: 2700 RVA: 0x00025794 File Offset: 0x00023994
		public override DateTime Time
		{
			get
			{
				return DateTime.Now;
			}
		}
	}
}
