using System;
using System.Text;
using NLog.Config;

namespace NLog.LayoutRenderers
{
	/// <summary>
	/// The process time in format HH:mm:ss.mmm.
	/// </summary>
	// Token: 0x020000BB RID: 187
	[LayoutRenderer("processtime")]
	[ThreadAgnostic]
	public class ProcessTimeLayoutRenderer : LayoutRenderer
	{
		/// <summary>
		/// Renders the current process running time and appends it to the specified <see cref="T:System.Text.StringBuilder" />.
		/// </summary>
		/// <param name="builder">The <see cref="T:System.Text.StringBuilder" /> to append the rendered data to.</param>
		/// <param name="logEvent">Logging event.</param>
		// Token: 0x06000463 RID: 1123 RVA: 0x00010064 File Offset: 0x0000E264
		protected override void Append(StringBuilder builder, LogEventInfo logEvent)
		{
			TimeSpan timeSpan = logEvent.TimeStamp.ToUniversalTime() - LogEventInfo.ZeroDate;
			if (timeSpan.Hours < 10)
			{
				builder.Append('0');
			}
			builder.Append(timeSpan.Hours);
			builder.Append(':');
			if (timeSpan.Minutes < 10)
			{
				builder.Append('0');
			}
			builder.Append(timeSpan.Minutes);
			builder.Append(':');
			if (timeSpan.Seconds < 10)
			{
				builder.Append('0');
			}
			builder.Append(timeSpan.Seconds);
			builder.Append('.');
			if (timeSpan.Milliseconds < 1000)
			{
				builder.Append('0');
			}
			if (timeSpan.Milliseconds < 100)
			{
				builder.Append('0');
			}
			if (timeSpan.Milliseconds < 10)
			{
				builder.Append('0');
			}
			builder.Append(timeSpan.Milliseconds);
		}
	}
}
