using System;

namespace NLog.Targets
{
	/// <summary>
	/// Specifies the way archive numbering is performed.
	/// </summary>
	// Token: 0x020000FD RID: 253
	public enum ArchiveNumberingMode
	{
		/// <summary>
		/// Sequence style numbering. The most recent archive has the highest number.
		/// </summary>
		// Token: 0x04000235 RID: 565
		Sequence,
		/// <summary>
		/// Rolling style numbering (the most recent is always #0 then #1, ..., #N.
		/// </summary>
		// Token: 0x04000236 RID: 566
		Rolling,
		/// <summary>
		/// Date style numbering.  Archives will be stamped with the prior period (Year, Month, Day, Hour, Minute) datetime.
		/// </summary>
		// Token: 0x04000237 RID: 567
		Date
	}
}
