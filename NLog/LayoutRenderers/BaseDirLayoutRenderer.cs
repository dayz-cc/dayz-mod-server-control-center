using System;
using System.IO;
using System.Text;
using NLog.Config;
using NLog.Internal.Fakeables;

namespace NLog.LayoutRenderers
{
	/// <summary>
	/// The current application domain's base directory.
	/// </summary>
	// Token: 0x0200009A RID: 154
	[AppDomainFixedOutput]
	[LayoutRenderer("basedir")]
	public class BaseDirLayoutRenderer : LayoutRenderer
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.LayoutRenderers.BaseDirLayoutRenderer" /> class.
		/// </summary>
		// Token: 0x06000393 RID: 915 RVA: 0x0000DD1A File Offset: 0x0000BF1A
		public BaseDirLayoutRenderer()
			: this(AppDomainWrapper.CurrentDomain)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.LayoutRenderers.BaseDirLayoutRenderer" /> class.
		/// </summary>
		// Token: 0x06000394 RID: 916 RVA: 0x0000DD2A File Offset: 0x0000BF2A
		public BaseDirLayoutRenderer(IAppDomain appDomain)
		{
			this.baseDir = appDomain.BaseDirectory;
		}

		/// <summary>
		/// Gets or sets the name of the file to be Path.Combine()'d with with the base directory.
		/// </summary>
		/// <docgen category="Advanced Options" order="10" />
		// Token: 0x170000B3 RID: 179
		// (get) Token: 0x06000395 RID: 917 RVA: 0x0000DD44 File Offset: 0x0000BF44
		// (set) Token: 0x06000396 RID: 918 RVA: 0x0000DD5B File Offset: 0x0000BF5B
		public string File { get; set; }

		/// <summary>
		/// Gets or sets the name of the directory to be Path.Combine()'d with with the base directory.
		/// </summary>
		/// <docgen category="Advanced Options" order="10" />
		// Token: 0x170000B4 RID: 180
		// (get) Token: 0x06000397 RID: 919 RVA: 0x0000DD64 File Offset: 0x0000BF64
		// (set) Token: 0x06000398 RID: 920 RVA: 0x0000DD7B File Offset: 0x0000BF7B
		public string Dir { get; set; }

		/// <summary>
		/// Renders the application base directory and appends it to the specified <see cref="T:System.Text.StringBuilder" />.
		/// </summary>
		/// <param name="builder">The <see cref="T:System.Text.StringBuilder" /> to append the rendered data to.</param>
		/// <param name="logEvent">Logging event.</param>
		// Token: 0x06000399 RID: 921 RVA: 0x0000DD84 File Offset: 0x0000BF84
		protected override void Append(StringBuilder builder, LogEventInfo logEvent)
		{
			if (this.File != null)
			{
				builder.Append(Path.Combine(this.baseDir, this.File));
			}
			else if (this.Dir != null)
			{
				builder.Append(Path.Combine(this.baseDir, this.Dir));
			}
			else
			{
				builder.Append(this.baseDir);
			}
		}

		// Token: 0x0400010C RID: 268
		private string baseDir;
	}
}
