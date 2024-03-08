using System;
using System.Text;
using NLog.Config;

namespace NLog.LayoutRenderers
{
	/// <summary>
	/// A string literal.
	/// </summary>
	/// <remarks>
	/// This is used to escape '${' sequence 
	/// as ;${literal:text=${}'
	/// </remarks>
	// Token: 0x020000AC RID: 172
	[LayoutRenderer("literal")]
	[ThreadAgnostic]
	[AppDomainFixedOutput]
	public class LiteralLayoutRenderer : LayoutRenderer
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.LayoutRenderers.LiteralLayoutRenderer" /> class.
		/// </summary>
		// Token: 0x06000402 RID: 1026 RVA: 0x0000EE15 File Offset: 0x0000D015
		public LiteralLayoutRenderer()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.LayoutRenderers.LiteralLayoutRenderer" /> class.
		/// </summary>
		/// <param name="text">The literal text value.</param>
		/// <remarks>This is used by the layout compiler.</remarks>
		// Token: 0x06000403 RID: 1027 RVA: 0x0000EE20 File Offset: 0x0000D020
		public LiteralLayoutRenderer(string text)
		{
			this.Text = text;
		}

		/// <summary>
		/// Gets or sets the literal text.
		/// </summary>
		/// <docgen category="Rendering Options" order="10" />
		// Token: 0x170000D4 RID: 212
		// (get) Token: 0x06000404 RID: 1028 RVA: 0x0000EE34 File Offset: 0x0000D034
		// (set) Token: 0x06000405 RID: 1029 RVA: 0x0000EE4B File Offset: 0x0000D04B
		public string Text { get; set; }

		/// <summary>
		/// Renders the specified string literal and appends it to the specified <see cref="T:System.Text.StringBuilder" />.
		/// </summary>
		/// <param name="builder">The <see cref="T:System.Text.StringBuilder" /> to append the rendered data to.</param>
		/// <param name="logEvent">Logging event.</param>
		// Token: 0x06000406 RID: 1030 RVA: 0x0000EE54 File Offset: 0x0000D054
		protected override void Append(StringBuilder builder, LogEventInfo logEvent)
		{
			builder.Append(this.Text);
		}
	}
}
