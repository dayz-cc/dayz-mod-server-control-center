using System;
using NLog.Config;

namespace NLog.Layouts
{
	/// <summary>
	/// A specialized layout that supports header and footer.
	/// </summary>
	// Token: 0x020000DA RID: 218
	[Layout("LayoutWithHeaderAndFooter")]
	[ThreadAgnostic]
	public class LayoutWithHeaderAndFooter : Layout
	{
		/// <summary>
		/// Gets or sets the body layout (can be repeated multiple times).
		/// </summary>
		/// <docgen category="Layout Options" order="10" />
		// Token: 0x17000120 RID: 288
		// (get) Token: 0x06000517 RID: 1303 RVA: 0x00011AB0 File Offset: 0x0000FCB0
		// (set) Token: 0x06000518 RID: 1304 RVA: 0x00011AC7 File Offset: 0x0000FCC7
		public Layout Layout { get; set; }

		/// <summary>
		/// Gets or sets the header layout.
		/// </summary>
		/// <docgen category="Layout Options" order="10" />
		// Token: 0x17000121 RID: 289
		// (get) Token: 0x06000519 RID: 1305 RVA: 0x00011AD0 File Offset: 0x0000FCD0
		// (set) Token: 0x0600051A RID: 1306 RVA: 0x00011AE7 File Offset: 0x0000FCE7
		public Layout Header { get; set; }

		/// <summary>
		/// Gets or sets the footer layout.
		/// </summary>
		/// <docgen category="Layout Options" order="10" />
		// Token: 0x17000122 RID: 290
		// (get) Token: 0x0600051B RID: 1307 RVA: 0x00011AF0 File Offset: 0x0000FCF0
		// (set) Token: 0x0600051C RID: 1308 RVA: 0x00011B07 File Offset: 0x0000FD07
		public Layout Footer { get; set; }

		/// <summary>
		/// Renders the layout for the specified logging event by invoking layout renderers.
		/// </summary>
		/// <param name="logEvent">The logging event.</param>
		/// <returns>The rendered layout.</returns>
		// Token: 0x0600051D RID: 1309 RVA: 0x00011B10 File Offset: 0x0000FD10
		protected override string GetFormattedMessage(LogEventInfo logEvent)
		{
			return this.Layout.Render(logEvent);
		}
	}
}
