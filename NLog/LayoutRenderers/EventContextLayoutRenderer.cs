using System;
using System.Globalization;
using System.Text;
using NLog.Config;

namespace NLog.LayoutRenderers
{
	/// <summary>
	/// Log event context data.
	/// </summary>
	// Token: 0x0200009F RID: 159
	[LayoutRenderer("event-context")]
	[Obsolete("Use EventPropertiesLayoutRenderer instead.")]
	public class EventContextLayoutRenderer : LayoutRenderer
	{
		/// <summary>
		/// Gets or sets the name of the item.
		/// </summary>
		/// <docgen category="Rendering Options" order="10" />
		// Token: 0x170000C3 RID: 195
		// (get) Token: 0x060003BF RID: 959 RVA: 0x0000E3D0 File Offset: 0x0000C5D0
		// (set) Token: 0x060003C0 RID: 960 RVA: 0x0000E3E7 File Offset: 0x0000C5E7
		[RequiredParameter]
		[DefaultParameter]
		public string Item { get; set; }

		/// <summary>
		/// Renders the specified log event context item and appends it to the specified <see cref="T:System.Text.StringBuilder" />.
		/// </summary>
		/// <param name="builder">The <see cref="T:System.Text.StringBuilder" /> to append the rendered data to.</param>
		/// <param name="logEvent">Logging event.</param>
		// Token: 0x060003C1 RID: 961 RVA: 0x0000E3F0 File Offset: 0x0000C5F0
		protected override void Append(StringBuilder builder, LogEventInfo logEvent)
		{
			object obj;
			if (logEvent.Properties.TryGetValue(this.Item, out obj))
			{
				builder.Append(Convert.ToString(obj, CultureInfo.InvariantCulture));
			}
		}
	}
}
