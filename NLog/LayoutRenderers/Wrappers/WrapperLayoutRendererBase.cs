using System;
using System.Text;
using NLog.Config;
using NLog.Layouts;

namespace NLog.LayoutRenderers.Wrappers
{
	/// <summary>
	/// Decodes text "encrypted" with ROT-13.
	/// </summary>
	/// <remarks>
	/// See <a href="http://en.wikipedia.org/wiki/ROT13">http://en.wikipedia.org/wiki/ROT13</a>.
	/// </remarks>
	// Token: 0x020000C8 RID: 200
	public abstract class WrapperLayoutRendererBase : LayoutRenderer
	{
		/// <summary>
		/// Gets or sets the wrapped layout.
		/// </summary>
		/// <docgen category="Transformation Options" order="10" />
		// Token: 0x17000106 RID: 262
		// (get) Token: 0x060004A8 RID: 1192 RVA: 0x00010D04 File Offset: 0x0000EF04
		// (set) Token: 0x060004A9 RID: 1193 RVA: 0x00010D1B File Offset: 0x0000EF1B
		[DefaultParameter]
		public Layout Inner { get; set; }

		/// <summary>
		/// Renders the inner message, processes it and appends it to the specified <see cref="T:System.Text.StringBuilder" />.
		/// </summary>
		/// <param name="builder">The <see cref="T:System.Text.StringBuilder" /> to append the rendered data to.</param>
		/// <param name="logEvent">Logging event.</param>
		// Token: 0x060004AA RID: 1194 RVA: 0x00010D24 File Offset: 0x0000EF24
		protected override void Append(StringBuilder builder, LogEventInfo logEvent)
		{
			string text = this.RenderInner(logEvent);
			builder.Append(this.Transform(text));
		}

		/// <summary>
		/// Transforms the output of another layout.
		/// </summary>
		/// <param name="text">Output to be transform.</param>
		/// <returns>Transformed text.</returns>
		// Token: 0x060004AB RID: 1195
		protected abstract string Transform(string text);

		/// <summary>
		/// Renders the inner layout contents.
		/// </summary>
		/// <param name="logEvent">The log event.</param>
		/// <returns>Contents of inner layout.</returns>
		// Token: 0x060004AC RID: 1196 RVA: 0x00010D48 File Offset: 0x0000EF48
		protected virtual string RenderInner(LogEventInfo logEvent)
		{
			return this.Inner.Render(logEvent);
		}
	}
}
