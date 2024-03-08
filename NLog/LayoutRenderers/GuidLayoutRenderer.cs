using System;
using System.ComponentModel;
using System.Text;

namespace NLog.LayoutRenderers
{
	/// <summary>
	/// Globally-unique identifier (GUID).
	/// </summary>
	// Token: 0x020000A7 RID: 167
	[LayoutRenderer("guid")]
	public class GuidLayoutRenderer : LayoutRenderer
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.LayoutRenderers.GuidLayoutRenderer" /> class.
		/// </summary>
		// Token: 0x060003ED RID: 1005 RVA: 0x0000EBA2 File Offset: 0x0000CDA2
		public GuidLayoutRenderer()
		{
			this.Format = "N";
		}

		/// <summary>
		/// Gets or sets the GUID format as accepted by Guid.ToString() method.
		/// </summary>
		/// <docgen category="Rendering Options" order="10" />
		// Token: 0x170000CE RID: 206
		// (get) Token: 0x060003EE RID: 1006 RVA: 0x0000EBBC File Offset: 0x0000CDBC
		// (set) Token: 0x060003EF RID: 1007 RVA: 0x0000EBD3 File Offset: 0x0000CDD3
		[DefaultValue("N")]
		public string Format { get; set; }

		/// <summary>
		/// Renders a newly generated GUID string and appends it to the specified <see cref="T:System.Text.StringBuilder" />.
		/// </summary>
		/// <param name="builder">The <see cref="T:System.Text.StringBuilder" /> to append the rendered data to.</param>
		/// <param name="logEvent">Logging event.</param>
		// Token: 0x060003F0 RID: 1008 RVA: 0x0000EBDC File Offset: 0x0000CDDC
		protected override void Append(StringBuilder builder, LogEventInfo logEvent)
		{
			builder.Append(Guid.NewGuid().ToString(this.Format));
		}
	}
}
