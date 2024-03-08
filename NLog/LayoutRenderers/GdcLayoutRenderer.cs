using System;
using System.Text;
using NLog.Config;

namespace NLog.LayoutRenderers
{
	/// <summary>
	/// Global Diagnostics Context item. Provided for compatibility with log4net.
	/// </summary>
	// Token: 0x020000A6 RID: 166
	[LayoutRenderer("gdc")]
	public class GdcLayoutRenderer : LayoutRenderer
	{
		/// <summary>
		/// Gets or sets the name of the item.
		/// </summary>
		/// <docgen category="Rendering Options" order="10" />
		// Token: 0x170000CD RID: 205
		// (get) Token: 0x060003E9 RID: 1001 RVA: 0x0000EB58 File Offset: 0x0000CD58
		// (set) Token: 0x060003EA RID: 1002 RVA: 0x0000EB6F File Offset: 0x0000CD6F
		[RequiredParameter]
		[DefaultParameter]
		public string Item { get; set; }

		/// <summary>
		/// Renders the specified Global Diagnostics Context item and appends it to the specified <see cref="T:System.Text.StringBuilder" />.
		/// </summary>
		/// <param name="builder">The <see cref="T:System.Text.StringBuilder" /> to append the rendered data to.</param>
		/// <param name="logEvent">Logging event.</param>
		// Token: 0x060003EB RID: 1003 RVA: 0x0000EB78 File Offset: 0x0000CD78
		protected override void Append(StringBuilder builder, LogEventInfo logEvent)
		{
			string text = GlobalDiagnosticsContext.Get(this.Item);
			builder.Append(text);
		}
	}
}
