using System;
using System.Text;
using NLog.Internal;

namespace NLog.LayoutRenderers
{
	/// <summary>
	/// A newline literal.
	/// </summary>
	// Token: 0x020000B4 RID: 180
	[LayoutRenderer("newline")]
	public class NewLineLayoutRenderer : LayoutRenderer
	{
		/// <summary>
		/// Renders the specified string literal and appends it to the specified <see cref="T:System.Text.StringBuilder" />.
		/// </summary>
		/// <param name="builder">The <see cref="T:System.Text.StringBuilder" /> to append the rendered data to.</param>
		/// <param name="logEvent">Logging event.</param>
		// Token: 0x06000440 RID: 1088 RVA: 0x0000FC35 File Offset: 0x0000DE35
		protected override void Append(StringBuilder builder, LogEventInfo logEvent)
		{
			builder.Append(EnvironmentHelper.NewLine);
		}
	}
}
