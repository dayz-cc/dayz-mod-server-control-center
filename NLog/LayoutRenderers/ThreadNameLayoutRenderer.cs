using System;
using System.Text;
using System.Threading;

namespace NLog.LayoutRenderers
{
	/// <summary>
	/// The name of the current thread.
	/// </summary>
	// Token: 0x020000C4 RID: 196
	[LayoutRenderer("threadname")]
	public class ThreadNameLayoutRenderer : LayoutRenderer
	{
		/// <summary>
		/// Renders the current thread name and appends it to the specified <see cref="T:System.Text.StringBuilder" />.
		/// </summary>
		/// <param name="builder">The <see cref="T:System.Text.StringBuilder" /> to append the rendered data to.</param>
		/// <param name="logEvent">Logging event.</param>
		// Token: 0x06000498 RID: 1176 RVA: 0x00010A58 File Offset: 0x0000EC58
		protected override void Append(StringBuilder builder, LogEventInfo logEvent)
		{
			builder.Append(Thread.CurrentThread.Name);
		}
	}
}
