using System;
using System.ComponentModel;
using NLog.Config;
using NLog.Layouts;

namespace NLog.Targets
{
	/// <summary>
	/// Represents a parameter to a Database target.
	/// </summary>
	// Token: 0x0200010C RID: 268
	[NLogConfigurationItem]
	public class DatabaseParameterInfo
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Targets.DatabaseParameterInfo" /> class.
		/// </summary>
		// Token: 0x06000855 RID: 2133 RVA: 0x0001D564 File Offset: 0x0001B764
		public DatabaseParameterInfo()
			: this(null, null)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Targets.DatabaseParameterInfo" /> class.
		/// </summary>
		/// <param name="parameterName">Name of the parameter.</param>
		/// <param name="parameterLayout">The parameter layout.</param>
		// Token: 0x06000856 RID: 2134 RVA: 0x0001D571 File Offset: 0x0001B771
		public DatabaseParameterInfo(string parameterName, Layout parameterLayout)
		{
			this.Name = parameterName;
			this.Layout = parameterLayout;
		}

		/// <summary>
		/// Gets or sets the database parameter name.
		/// </summary>
		/// <docgen category="Parameter Options" order="10" />
		// Token: 0x1700019C RID: 412
		// (get) Token: 0x06000857 RID: 2135 RVA: 0x0001D58C File Offset: 0x0001B78C
		// (set) Token: 0x06000858 RID: 2136 RVA: 0x0001D5A3 File Offset: 0x0001B7A3
		[RequiredParameter]
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the layout that should be use to calcuate the value for the parameter.
		/// </summary>
		/// <docgen category="Parameter Options" order="10" />
		// Token: 0x1700019D RID: 413
		// (get) Token: 0x06000859 RID: 2137 RVA: 0x0001D5AC File Offset: 0x0001B7AC
		// (set) Token: 0x0600085A RID: 2138 RVA: 0x0001D5C3 File Offset: 0x0001B7C3
		[RequiredParameter]
		public Layout Layout { get; set; }

		/// <summary>
		/// Gets or sets the database parameter size.
		/// </summary>
		/// <docgen category="Parameter Options" order="10" />
		// Token: 0x1700019E RID: 414
		// (get) Token: 0x0600085B RID: 2139 RVA: 0x0001D5CC File Offset: 0x0001B7CC
		// (set) Token: 0x0600085C RID: 2140 RVA: 0x0001D5E3 File Offset: 0x0001B7E3
		[DefaultValue(0)]
		public int Size { get; set; }

		/// <summary>
		/// Gets or sets the database parameter precision.
		/// </summary>
		/// <docgen category="Parameter Options" order="10" />
		// Token: 0x1700019F RID: 415
		// (get) Token: 0x0600085D RID: 2141 RVA: 0x0001D5EC File Offset: 0x0001B7EC
		// (set) Token: 0x0600085E RID: 2142 RVA: 0x0001D603 File Offset: 0x0001B803
		[DefaultValue(0)]
		public byte Precision { get; set; }

		/// <summary>
		/// Gets or sets the database parameter scale.
		/// </summary>
		/// <docgen category="Parameter Options" order="10" />
		// Token: 0x170001A0 RID: 416
		// (get) Token: 0x0600085F RID: 2143 RVA: 0x0001D60C File Offset: 0x0001B80C
		// (set) Token: 0x06000860 RID: 2144 RVA: 0x0001D623 File Offset: 0x0001B823
		[DefaultValue(0)]
		public byte Scale { get; set; }
	}
}
