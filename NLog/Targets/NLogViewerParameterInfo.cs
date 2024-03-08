using System;
using NLog.Config;
using NLog.Layouts;

namespace NLog.Targets
{
	/// <summary>
	/// Represents a parameter to a NLogViewer target.
	/// </summary>
	// Token: 0x0200011F RID: 287
	[NLogConfigurationItem]
	public class NLogViewerParameterInfo
	{
		/// <summary>
		/// Gets or sets viewer parameter name.
		/// </summary>
		/// <docgen category="Parameter Options" order="10" />
		// Token: 0x170001F8 RID: 504
		// (get) Token: 0x0600097B RID: 2427 RVA: 0x00021D54 File Offset: 0x0001FF54
		// (set) Token: 0x0600097C RID: 2428 RVA: 0x00021D6B File Offset: 0x0001FF6B
		[RequiredParameter]
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the layout that should be use to calcuate the value for the parameter.
		/// </summary>
		/// <docgen category="Parameter Options" order="10" />
		// Token: 0x170001F9 RID: 505
		// (get) Token: 0x0600097D RID: 2429 RVA: 0x00021D74 File Offset: 0x0001FF74
		// (set) Token: 0x0600097E RID: 2430 RVA: 0x00021D8B File Offset: 0x0001FF8B
		[RequiredParameter]
		public Layout Layout { get; set; }
	}
}
