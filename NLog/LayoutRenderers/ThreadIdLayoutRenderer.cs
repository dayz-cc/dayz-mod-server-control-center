using System;
using System.Globalization;
using System.Text;
using System.Threading;

namespace NLog.LayoutRenderers
{
	/// <summary>
	/// The identifier of the current thread.
	/// </summary>
	// Token: 0x020000C3 RID: 195
	[LayoutRenderer("threadid")]
	public class ThreadIdLayoutRenderer : LayoutRenderer
	{
		/// <summary>
		/// Renders the current thread identifier and appends it to the specified <see cref="T:System.Text.StringBuilder" />.
		/// </summary>
		/// <param name="builder">The <see cref="T:System.Text.StringBuilder" /> to append the rendered data to.</param>
		/// <param name="logEvent">Logging event.</param>
		// Token: 0x06000496 RID: 1174 RVA: 0x00010A24 File Offset: 0x0000EC24
		protected override void Append(StringBuilder builder, LogEventInfo logEvent)
		{
			builder.Append(Thread.CurrentThread.ManagedThreadId.ToString(CultureInfo.InvariantCulture));
		}
	}
}
