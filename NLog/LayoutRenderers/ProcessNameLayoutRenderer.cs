using System;
using System.ComponentModel;
using System.Text;
using NLog.Config;
using NLog.Internal;

namespace NLog.LayoutRenderers
{
	/// <summary>
	/// The name of the current process.
	/// </summary>
	// Token: 0x020000BA RID: 186
	[AppDomainFixedOutput]
	[LayoutRenderer("processname")]
	[ThreadAgnostic]
	public class ProcessNameLayoutRenderer : LayoutRenderer
	{
		/// <summary>
		/// Gets or sets a value indicating whether to write the full path to the process executable.
		/// </summary>
		/// <docgen category="Rendering Options" order="10" />
		// Token: 0x170000F0 RID: 240
		// (get) Token: 0x0600045F RID: 1119 RVA: 0x0000FFF8 File Offset: 0x0000E1F8
		// (set) Token: 0x06000460 RID: 1120 RVA: 0x0001000F File Offset: 0x0000E20F
		[DefaultValue(false)]
		public bool FullName { get; set; }

		/// <summary>
		/// Renders the current process name (optionally with a full path).
		/// </summary>
		/// <param name="builder">The <see cref="T:System.Text.StringBuilder" /> to append the rendered data to.</param>
		/// <param name="logEvent">Logging event.</param>
		// Token: 0x06000461 RID: 1121 RVA: 0x00010018 File Offset: 0x0000E218
		protected override void Append(StringBuilder builder, LogEventInfo logEvent)
		{
			if (this.FullName)
			{
				builder.Append(ThreadIDHelper.Instance.CurrentProcessName);
			}
			else
			{
				builder.Append(ThreadIDHelper.Instance.CurrentProcessBaseName);
			}
		}
	}
}
