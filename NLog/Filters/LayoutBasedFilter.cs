using System;
using NLog.Config;
using NLog.Layouts;

namespace NLog.Filters
{
	/// <summary>
	/// A base class for filters that are based on comparing a value to a layout.
	/// </summary>
	// Token: 0x02000041 RID: 65
	public abstract class LayoutBasedFilter : Filter
	{
		/// <summary>
		/// Gets or sets the layout to be used to filter log messages.
		/// </summary>
		/// <value>The layout.</value>
		/// <docgen category="Filtering Options" order="10" />
		// Token: 0x1700005D RID: 93
		// (get) Token: 0x060001C5 RID: 453 RVA: 0x00009178 File Offset: 0x00007378
		// (set) Token: 0x060001C6 RID: 454 RVA: 0x0000918F File Offset: 0x0000738F
		[RequiredParameter]
		public Layout Layout { get; set; }
	}
}
