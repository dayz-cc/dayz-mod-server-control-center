using System;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using NLog.Config;

namespace NLog.LayoutRenderers
{
	/// <summary>
	/// The short date in a sortable format yyyy-MM-dd.
	/// </summary>
	// Token: 0x020000BE RID: 190
	[LayoutRenderer("shortdate")]
	[ThreadAgnostic]
	public class ShortDateLayoutRenderer : LayoutRenderer
	{
		/// <summary>
		/// Gets or sets a value indicating whether to output UTC time instead of local time.
		/// </summary>
		/// <docgen category="Rendering Options" order="10" />
		// Token: 0x170000F9 RID: 249
		// (get) Token: 0x0600047A RID: 1146 RVA: 0x000105E0 File Offset: 0x0000E7E0
		// (set) Token: 0x0600047B RID: 1147 RVA: 0x000105F7 File Offset: 0x0000E7F7
		[DefaultValue(false)]
		public bool UniversalTime { get; set; }

		/// <summary>
		/// Renders the current short date string (yyyy-MM-dd) and appends it to the specified <see cref="T:System.Text.StringBuilder" />.
		/// </summary>
		/// <param name="builder">The <see cref="T:System.Text.StringBuilder" /> to append the rendered data to.</param>
		/// <param name="logEvent">Logging event.</param>
		// Token: 0x0600047C RID: 1148 RVA: 0x00010600 File Offset: 0x0000E800
		protected override void Append(StringBuilder builder, LogEventInfo logEvent)
		{
			DateTime dateTime = logEvent.TimeStamp;
			if (this.UniversalTime)
			{
				dateTime = dateTime.ToUniversalTime();
			}
			builder.Append(dateTime.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture));
		}
	}
}
