using System;
using System.Globalization;
using System.Text;
using NLog.Config;
using NLog.Internal;

namespace NLog.LayoutRenderers
{
	/// <summary>
	/// The identifier of the current process.
	/// </summary>
	// Token: 0x020000B7 RID: 183
	[AppDomainFixedOutput]
	[ThreadAgnostic]
	[LayoutRenderer("processid")]
	public class ProcessIdLayoutRenderer : LayoutRenderer
	{
		/// <summary>
		/// Renders the current process ID.
		/// </summary>
		/// <param name="builder">The <see cref="T:System.Text.StringBuilder" /> to append the rendered data to.</param>
		/// <param name="logEvent">Logging event.</param>
		// Token: 0x06000457 RID: 1111 RVA: 0x0000FE9C File Offset: 0x0000E09C
		protected override void Append(StringBuilder builder, LogEventInfo logEvent)
		{
			builder.Append(ThreadIDHelper.Instance.CurrentProcessID.ToString(CultureInfo.InvariantCulture));
		}
	}
}
