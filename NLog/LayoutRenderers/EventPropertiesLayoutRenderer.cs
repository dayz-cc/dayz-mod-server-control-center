using System;
using System.Globalization;
using System.Text;
using NLog.Config;

namespace NLog.LayoutRenderers
{
	/// <summary>
	/// Log event context data.
	/// </summary>
	// Token: 0x020000A0 RID: 160
	[LayoutRenderer("event-properties")]
	public class EventPropertiesLayoutRenderer : LayoutRenderer
	{
		/// <summary>
		/// Gets or sets the name of the item.
		/// </summary>
		/// <docgen category="Rendering Options" order="10" />
		// Token: 0x170000C4 RID: 196
		// (get) Token: 0x060003C3 RID: 963 RVA: 0x0000E434 File Offset: 0x0000C634
		// (set) Token: 0x060003C4 RID: 964 RVA: 0x0000E44B File Offset: 0x0000C64B
		[DefaultParameter]
		[RequiredParameter]
		public string Item { get; set; }

		/// <summary>
		/// Renders the specified log event context item and appends it to the specified <see cref="T:System.Text.StringBuilder" />.
		/// </summary>
		/// <param name="builder">The <see cref="T:System.Text.StringBuilder" /> to append the rendered data to.</param>
		/// <param name="logEvent">Logging event.</param>
		// Token: 0x060003C5 RID: 965 RVA: 0x0000E454 File Offset: 0x0000C654
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
