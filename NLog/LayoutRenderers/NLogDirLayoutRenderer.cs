using System;
using System.IO;
using System.Text;
using NLog.Config;

namespace NLog.LayoutRenderers
{
	/// <summary>
	/// The directory where NLog.dll is located.
	/// </summary>
	// Token: 0x020000B5 RID: 181
	[LayoutRenderer("nlogdir")]
	[ThreadAgnostic]
	[AppDomainFixedOutput]
	public class NLogDirLayoutRenderer : LayoutRenderer
	{
		/// <summary>
		/// Gets or sets the name of the file to be Path.Combine()'d with the directory name.
		/// </summary>
		/// <docgen category="Advanced Options" order="10" />
		// Token: 0x170000E8 RID: 232
		// (get) Token: 0x06000443 RID: 1091 RVA: 0x0000FC70 File Offset: 0x0000DE70
		// (set) Token: 0x06000444 RID: 1092 RVA: 0x0000FC87 File Offset: 0x0000DE87
		public string File { get; set; }

		/// <summary>
		/// Gets or sets the name of the directory to be Path.Combine()'d with the directory name.
		/// </summary>
		/// <docgen category="Advanced Options" order="10" />
		// Token: 0x170000E9 RID: 233
		// (get) Token: 0x06000445 RID: 1093 RVA: 0x0000FC90 File Offset: 0x0000DE90
		// (set) Token: 0x06000446 RID: 1094 RVA: 0x0000FCA7 File Offset: 0x0000DEA7
		public string Dir { get; set; }

		// Token: 0x170000EA RID: 234
		// (get) Token: 0x06000447 RID: 1095 RVA: 0x0000FCB0 File Offset: 0x0000DEB0
		// (set) Token: 0x06000448 RID: 1096 RVA: 0x0000FCC6 File Offset: 0x0000DEC6
		private static string NLogDir { get; set; } = Path.GetDirectoryName(typeof(LogManager).Assembly.Location);

		/// <summary>
		/// Renders the directory where NLog is located and appends it to the specified <see cref="T:System.Text.StringBuilder" />.
		/// </summary>
		/// <param name="builder">The <see cref="T:System.Text.StringBuilder" /> to append the rendered data to.</param>
		/// <param name="logEvent">Logging event.</param>
		// Token: 0x06000449 RID: 1097 RVA: 0x0000FCD0 File Offset: 0x0000DED0
		protected override void Append(StringBuilder builder, LogEventInfo logEvent)
		{
			string nlogDir = NLogDirLayoutRenderer.NLogDir;
			if (this.File != null)
			{
				builder.Append(Path.Combine(nlogDir, this.File));
			}
			else if (this.Dir != null)
			{
				builder.Append(Path.Combine(nlogDir, this.Dir));
			}
			else
			{
				builder.Append(nlogDir);
			}
		}
	}
}
