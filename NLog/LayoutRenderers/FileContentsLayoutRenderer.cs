using System;
using System.IO;
using System.Text;
using NLog.Common;
using NLog.Config;
using NLog.Internal;
using NLog.Layouts;

namespace NLog.LayoutRenderers
{
	/// <summary>
	/// Renders contents of the specified file.
	/// </summary>
	// Token: 0x020000A3 RID: 163
	[LayoutRenderer("file-contents")]
	public class FileContentsLayoutRenderer : LayoutRenderer
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.LayoutRenderers.FileContentsLayoutRenderer" /> class.
		/// </summary>
		// Token: 0x060003DE RID: 990 RVA: 0x0000E90F File Offset: 0x0000CB0F
		public FileContentsLayoutRenderer()
		{
			this.Encoding = Encoding.Default;
			this.lastFileName = string.Empty;
		}

		/// <summary>
		/// Gets or sets the name of the file.
		/// </summary>
		/// <docgen category="File Options" order="10" />
		// Token: 0x170000CA RID: 202
		// (get) Token: 0x060003DF RID: 991 RVA: 0x0000E934 File Offset: 0x0000CB34
		// (set) Token: 0x060003E0 RID: 992 RVA: 0x0000E94B File Offset: 0x0000CB4B
		[DefaultParameter]
		public Layout FileName { get; set; }

		/// <summary>
		/// Gets or sets the encoding used in the file.
		/// </summary>
		/// <value>The encoding.</value>
		/// <docgen category="File Options" order="10" />
		// Token: 0x170000CB RID: 203
		// (get) Token: 0x060003E1 RID: 993 RVA: 0x0000E954 File Offset: 0x0000CB54
		// (set) Token: 0x060003E2 RID: 994 RVA: 0x0000E96B File Offset: 0x0000CB6B
		public Encoding Encoding { get; set; }

		/// <summary>
		/// Renders the contents of the specified file and appends it to the specified <see cref="T:System.Text.StringBuilder" />.
		/// </summary>
		/// <param name="builder">The <see cref="T:System.Text.StringBuilder" /> to append the rendered data to.</param>
		/// <param name="logEvent">Logging event.</param>
		// Token: 0x060003E3 RID: 995 RVA: 0x0000E974 File Offset: 0x0000CB74
		protected override void Append(StringBuilder builder, LogEventInfo logEvent)
		{
			lock (this)
			{
				string text = this.FileName.Render(logEvent);
				if (text != this.lastFileName)
				{
					this.currentFileContents = this.ReadFileContents(text);
					this.lastFileName = text;
				}
			}
			builder.Append(this.currentFileContents);
		}

		// Token: 0x060003E4 RID: 996 RVA: 0x0000E9F8 File Offset: 0x0000CBF8
		private string ReadFileContents(string fileName)
		{
			string text;
			try
			{
				using (StreamReader streamReader = new StreamReader(fileName, this.Encoding))
				{
					text = streamReader.ReadToEnd();
				}
			}
			catch (Exception ex)
			{
				if (ex.MustBeRethrown())
				{
					throw;
				}
				InternalLogger.Error("Cannot read file contents: {0} {1}", new object[] { fileName, ex });
				text = string.Empty;
			}
			return text;
		}

		// Token: 0x04000126 RID: 294
		private string lastFileName;

		// Token: 0x04000127 RID: 295
		private string currentFileContents;
	}
}
