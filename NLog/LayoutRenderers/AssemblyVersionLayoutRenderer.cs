using System;
using System.Reflection;
using System.Text;

namespace NLog.LayoutRenderers
{
	/// <summary>
	/// Assembly version.
	/// </summary>
	// Token: 0x02000099 RID: 153
	[LayoutRenderer("assembly-version")]
	public class AssemblyVersionLayoutRenderer : LayoutRenderer
	{
		/// <summary>
		/// Renders assembly version and appends it to the specified <see cref="T:System.Text.StringBuilder" />.
		/// </summary>
		/// <param name="builder">The <see cref="T:System.Text.StringBuilder" /> to append the rendered data to.</param>
		/// <param name="logEvent">Logging event.</param>
		// Token: 0x06000391 RID: 913 RVA: 0x0000DCD4 File Offset: 0x0000BED4
		protected override void Append(StringBuilder builder, LogEventInfo logEvent)
		{
			Assembly entryAssembly = Assembly.GetEntryAssembly();
			string text = ((entryAssembly == null) ? "Could not find entry assembly" : entryAssembly.GetName().Version.ToString());
			builder.Append(text);
		}
	}
}
