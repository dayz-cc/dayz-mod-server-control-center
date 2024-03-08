using System;
using System.IO;
using System.Text;
using NLog.Config;

namespace NLog.LayoutRenderers
{
	/// <summary>
	/// A temporary directory.
	/// </summary>
	// Token: 0x020000C2 RID: 194
	[AppDomainFixedOutput]
	[LayoutRenderer("tempdir")]
	public class TempDirLayoutRenderer : LayoutRenderer
	{
		/// <summary>
		/// Gets or sets the name of the file to be Path.Combine()'d with the directory name.
		/// </summary>
		/// <docgen category="Advanced Options" order="10" />
		// Token: 0x17000101 RID: 257
		// (get) Token: 0x0600048F RID: 1167 RVA: 0x00010968 File Offset: 0x0000EB68
		// (set) Token: 0x06000490 RID: 1168 RVA: 0x0001097F File Offset: 0x0000EB7F
		public string File { get; set; }

		/// <summary>
		/// Gets or sets the name of the directory to be Path.Combine()'d with the directory name.
		/// </summary>
		/// <docgen category="Advanced Options" order="10" />
		// Token: 0x17000102 RID: 258
		// (get) Token: 0x06000491 RID: 1169 RVA: 0x00010988 File Offset: 0x0000EB88
		// (set) Token: 0x06000492 RID: 1170 RVA: 0x0001099F File Offset: 0x0000EB9F
		public string Dir { get; set; }

		/// <summary>
		/// Renders the directory where NLog is located and appends it to the specified <see cref="T:System.Text.StringBuilder" />.
		/// </summary>
		/// <param name="builder">The <see cref="T:System.Text.StringBuilder" /> to append the rendered data to.</param>
		/// <param name="logEvent">Logging event.</param>
		// Token: 0x06000493 RID: 1171 RVA: 0x000109A8 File Offset: 0x0000EBA8
		protected override void Append(StringBuilder builder, LogEventInfo logEvent)
		{
			string text = TempDirLayoutRenderer.tempDir;
			if (this.File != null)
			{
				builder.Append(Path.Combine(text, this.File));
			}
			else if (this.Dir != null)
			{
				builder.Append(Path.Combine(text, this.Dir));
			}
			else
			{
				builder.Append(text);
			}
		}

		// Token: 0x0400019B RID: 411
		private static string tempDir = Path.GetTempPath();
	}
}
