using System;
using System.Text;
using NLog.Config;

namespace NLog.LayoutRenderers
{
	/// <summary>
	/// The log level.
	/// </summary>
	// Token: 0x020000AB RID: 171
	[LayoutRenderer("level")]
	[ThreadAgnostic]
	public class LevelLayoutRenderer : LayoutRenderer
	{
		/// <summary>
		/// Renders the current log level and appends it to the specified <see cref="T:System.Text.StringBuilder" />.
		/// </summary>
		/// <param name="builder">The <see cref="T:System.Text.StringBuilder" /> to append the rendered data to.</param>
		/// <param name="logEvent">Logging event.</param>
		// Token: 0x06000400 RID: 1024 RVA: 0x0000EDF8 File Offset: 0x0000CFF8
		protected override void Append(StringBuilder builder, LogEventInfo logEvent)
		{
			builder.Append(logEvent.Level.ToString());
		}
	}
}
