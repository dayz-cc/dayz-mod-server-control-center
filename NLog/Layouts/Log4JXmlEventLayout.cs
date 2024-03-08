using System;
using NLog.LayoutRenderers;

namespace NLog.Layouts
{
	/// <summary>
	/// A specialized layout that renders Log4j-compatible XML events.
	/// </summary>
	/// <remarks>
	/// This layout is not meant to be used explicitly. Instead you can use ${log4jxmlevent} layout renderer.
	/// </remarks>
	// Token: 0x020000E0 RID: 224
	[Layout("Log4JXmlEventLayout")]
	public class Log4JXmlEventLayout : Layout
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Layouts.Log4JXmlEventLayout" /> class.
		/// </summary>
		// Token: 0x0600053C RID: 1340 RVA: 0x000127E2 File Offset: 0x000109E2
		public Log4JXmlEventLayout()
		{
			this.Renderer = new Log4JXmlEventLayoutRenderer();
		}

		/// <summary>
		/// Gets the <see cref="T:NLog.LayoutRenderers.Log4JXmlEventLayoutRenderer" /> instance that renders log events.
		/// </summary>
		// Token: 0x17000129 RID: 297
		// (get) Token: 0x0600053D RID: 1341 RVA: 0x000127FC File Offset: 0x000109FC
		// (set) Token: 0x0600053E RID: 1342 RVA: 0x00012813 File Offset: 0x00010A13
		public Log4JXmlEventLayoutRenderer Renderer { get; private set; }

		/// <summary>
		/// Renders the layout for the specified logging event by invoking layout renderers.
		/// </summary>
		/// <param name="logEvent">The logging event.</param>
		/// <returns>The rendered layout.</returns>
		// Token: 0x0600053F RID: 1343 RVA: 0x0001281C File Offset: 0x00010A1C
		protected override string GetFormattedMessage(LogEventInfo logEvent)
		{
			string text;
			string text2;
			if (logEvent.TryGetCachedLayoutValue(this, out text))
			{
				text2 = text;
			}
			else
			{
				text2 = logEvent.AddCachedLayoutValue(this, this.Renderer.Render(logEvent));
			}
			return text2;
		}
	}
}
