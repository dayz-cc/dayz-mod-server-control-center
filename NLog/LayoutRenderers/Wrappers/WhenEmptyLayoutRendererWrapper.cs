using System;
using NLog.Config;
using NLog.Layouts;

namespace NLog.LayoutRenderers.Wrappers
{
	/// <summary>
	/// Outputs alternative layout when the inner layout produces empty result.
	/// </summary>
	// Token: 0x020000D4 RID: 212
	[LayoutRenderer("whenEmpty")]
	[AmbientProperty("WhenEmpty")]
	[ThreadAgnostic]
	public sealed class WhenEmptyLayoutRendererWrapper : WrapperLayoutRendererBase
	{
		/// <summary>
		/// Gets or sets the layout to be rendered when original layout produced empty result.
		/// </summary>
		/// <docgen category="Transformation Options" order="10" />
		// Token: 0x17000119 RID: 281
		// (get) Token: 0x060004F2 RID: 1266 RVA: 0x00011668 File Offset: 0x0000F868
		// (set) Token: 0x060004F3 RID: 1267 RVA: 0x0001167F File Offset: 0x0000F87F
		[RequiredParameter]
		public Layout WhenEmpty { get; set; }

		/// <summary>
		/// Transforms the output of another layout.
		/// </summary>
		/// <param name="text">Output to be transform.</param>
		/// <returns>Transformed text.</returns>
		// Token: 0x060004F4 RID: 1268 RVA: 0x00011688 File Offset: 0x0000F888
		protected override string Transform(string text)
		{
			return text;
		}

		/// <summary>
		/// Renders the inner layout contents.
		/// </summary>
		/// <param name="logEvent">The log event.</param>
		/// <returns>
		/// Contents of inner layout.
		/// </returns>
		// Token: 0x060004F5 RID: 1269 RVA: 0x0001169C File Offset: 0x0000F89C
		protected override string RenderInner(LogEventInfo logEvent)
		{
			string text = base.RenderInner(logEvent);
			string text2;
			if (!string.IsNullOrEmpty(text))
			{
				text2 = text;
			}
			else
			{
				text2 = this.WhenEmpty.Render(logEvent);
			}
			return text2;
		}
	}
}
