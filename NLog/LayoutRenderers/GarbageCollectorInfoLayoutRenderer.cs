using System;
using System.ComponentModel;
using System.Globalization;
using System.Text;

namespace NLog.LayoutRenderers
{
	/// <summary>
	/// The information about the garbage collector.
	/// </summary>
	// Token: 0x020000A4 RID: 164
	[LayoutRenderer("gc")]
	public class GarbageCollectorInfoLayoutRenderer : LayoutRenderer
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.LayoutRenderers.GarbageCollectorInfoLayoutRenderer" /> class.
		/// </summary>
		// Token: 0x060003E5 RID: 997 RVA: 0x0000EA88 File Offset: 0x0000CC88
		public GarbageCollectorInfoLayoutRenderer()
		{
			this.Property = GarbageCollectorProperty.TotalMemory;
		}

		/// <summary>
		/// Gets or sets the property to retrieve.
		/// </summary>
		/// <docgen category="Rendering Options" order="10" />
		// Token: 0x170000CC RID: 204
		// (get) Token: 0x060003E6 RID: 998 RVA: 0x0000EA9C File Offset: 0x0000CC9C
		// (set) Token: 0x060003E7 RID: 999 RVA: 0x0000EAB3 File Offset: 0x0000CCB3
		[DefaultValue("TotalMemory")]
		public GarbageCollectorProperty Property { get; set; }

		/// <summary>
		/// Renders the selected process information.
		/// </summary>
		/// <param name="builder">The <see cref="T:System.Text.StringBuilder" /> to append the rendered data to.</param>
		/// <param name="logEvent">Logging event.</param>
		// Token: 0x060003E8 RID: 1000 RVA: 0x0000EABC File Offset: 0x0000CCBC
		protected override void Append(StringBuilder builder, LogEventInfo logEvent)
		{
			object obj = null;
			switch (this.Property)
			{
			case GarbageCollectorProperty.TotalMemory:
				obj = GC.GetTotalMemory(false);
				break;
			case GarbageCollectorProperty.TotalMemoryForceCollection:
				obj = GC.GetTotalMemory(true);
				break;
			case GarbageCollectorProperty.CollectionCount0:
				obj = GC.CollectionCount(0);
				break;
			case GarbageCollectorProperty.CollectionCount1:
				obj = GC.CollectionCount(1);
				break;
			case GarbageCollectorProperty.CollectionCount2:
				obj = GC.CollectionCount(2);
				break;
			case GarbageCollectorProperty.MaxGeneration:
				obj = GC.MaxGeneration;
				break;
			}
			builder.Append(Convert.ToString(obj, CultureInfo.InvariantCulture));
		}
	}
}
