using System;
using System.Globalization;
using System.Text;
using NLog.Config;

namespace NLog.LayoutRenderers
{
	/// <summary>
	/// The Ticks value of current date and time.
	/// </summary>
	// Token: 0x020000C5 RID: 197
	[LayoutRenderer("ticks")]
	[ThreadAgnostic]
	public class TicksLayoutRenderer : LayoutRenderer
	{
		/// <summary>
		/// Renders the ticks value of current time and appends it to the specified <see cref="T:System.Text.StringBuilder" />.
		/// </summary>
		/// <param name="builder">The <see cref="T:System.Text.StringBuilder" /> to append the rendered data to.</param>
		/// <param name="logEvent">Logging event.</param>
		// Token: 0x0600049A RID: 1178 RVA: 0x00010A74 File Offset: 0x0000EC74
		protected override void Append(StringBuilder builder, LogEventInfo logEvent)
		{
			builder.Append(logEvent.TimeStamp.Ticks.ToString(CultureInfo.InvariantCulture));
		}
	}
}
