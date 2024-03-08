using System;
using NLog.Config;

namespace NLog.Targets
{
	/// <summary>
	/// Marks class as a logging target and assigns a name to it.
	/// </summary>
	// Token: 0x02000129 RID: 297
	[AttributeUsage(AttributeTargets.Class)]
	public sealed class TargetAttribute : NameBaseAttribute
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Targets.TargetAttribute" /> class.
		/// </summary>
		/// <param name="name">Name of the target.</param>
		// Token: 0x060009E9 RID: 2537 RVA: 0x00023010 File Offset: 0x00021210
		public TargetAttribute(string name)
			: base(name)
		{
		}

		/// <summary>
		/// Gets or sets a value indicating whether to the target is a wrapper target (used to generate the target summary documentation page).
		/// </summary>
		// Token: 0x1700021D RID: 541
		// (get) Token: 0x060009EA RID: 2538 RVA: 0x0002301C File Offset: 0x0002121C
		// (set) Token: 0x060009EB RID: 2539 RVA: 0x00023033 File Offset: 0x00021233
		public bool IsWrapper { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether to the target is a compound target (used to generate the target summary documentation page).
		/// </summary>
		// Token: 0x1700021E RID: 542
		// (get) Token: 0x060009EC RID: 2540 RVA: 0x0002303C File Offset: 0x0002123C
		// (set) Token: 0x060009ED RID: 2541 RVA: 0x00023053 File Offset: 0x00021253
		public bool IsCompound { get; set; }
	}
}
