using System;
using System.Text;
using NLog.Config;

namespace NLog.LayoutRenderers
{
	/// <summary>
	/// Mapped Diagnostic Context item. Provided for compatibility with log4net.
	/// </summary>
	// Token: 0x020000B1 RID: 177
	[LayoutRenderer("mdc")]
	public class MdcLayoutRenderer : LayoutRenderer
	{
		/// <summary>
		/// Gets or sets the name of the item.
		/// </summary>
		/// <docgen category="Rendering Options" order="10" />
		// Token: 0x170000E2 RID: 226
		// (get) Token: 0x0600042E RID: 1070 RVA: 0x0000F9C0 File Offset: 0x0000DBC0
		// (set) Token: 0x0600042F RID: 1071 RVA: 0x0000F9D7 File Offset: 0x0000DBD7
		[DefaultParameter]
		[RequiredParameter]
		public string Item { get; set; }

		/// <summary>
		/// Renders the specified MDC item and appends it to the specified <see cref="T:System.Text.StringBuilder" />.
		/// </summary>
		/// <param name="builder">The <see cref="T:System.Text.StringBuilder" /> to append the rendered data to.</param>
		/// <param name="logEvent">Logging event.</param>
		// Token: 0x06000430 RID: 1072 RVA: 0x0000F9E0 File Offset: 0x0000DBE0
		protected override void Append(StringBuilder builder, LogEventInfo logEvent)
		{
			string text = MappedDiagnosticsContext.Get(this.Item);
			builder.Append(text);
		}
	}
}
