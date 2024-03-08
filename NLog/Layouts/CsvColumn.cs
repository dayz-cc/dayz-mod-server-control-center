using System;
using NLog.Config;

namespace NLog.Layouts
{
	/// <summary>
	/// A column in the CSV.
	/// </summary>
	// Token: 0x020000D7 RID: 215
	[ThreadAgnostic]
	[NLogConfigurationItem]
	public class CsvColumn
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Layouts.CsvColumn" /> class.
		/// </summary>
		// Token: 0x06000501 RID: 1281 RVA: 0x0001187E File Offset: 0x0000FA7E
		public CsvColumn()
			: this(null, null)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Layouts.CsvColumn" /> class.
		/// </summary>
		/// <param name="name">The name of the column.</param>
		/// <param name="layout">The layout of the column.</param>
		// Token: 0x06000502 RID: 1282 RVA: 0x0001188B File Offset: 0x0000FA8B
		public CsvColumn(string name, Layout layout)
		{
			this.Name = name;
			this.Layout = layout;
		}

		/// <summary>
		/// Gets or sets the name of the column.
		/// </summary>
		/// <docgen category="CSV Column Options" order="10" />
		// Token: 0x1700011C RID: 284
		// (get) Token: 0x06000503 RID: 1283 RVA: 0x000118A8 File Offset: 0x0000FAA8
		// (set) Token: 0x06000504 RID: 1284 RVA: 0x000118BF File Offset: 0x0000FABF
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the layout of the column.
		/// </summary>
		/// <docgen category="CSV Column Options" order="10" />
		// Token: 0x1700011D RID: 285
		// (get) Token: 0x06000505 RID: 1285 RVA: 0x000118C8 File Offset: 0x0000FAC8
		// (set) Token: 0x06000506 RID: 1286 RVA: 0x000118DF File Offset: 0x0000FADF
		[RequiredParameter]
		public Layout Layout { get; set; }
	}
}
