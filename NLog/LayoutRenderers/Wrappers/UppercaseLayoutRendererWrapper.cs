using System;
using System.ComponentModel;
using System.Globalization;
using NLog.Config;

namespace NLog.LayoutRenderers.Wrappers
{
	/// <summary>
	/// Converts the result of another layout output to upper case.
	/// </summary>
	// Token: 0x020000D2 RID: 210
	[LayoutRenderer("uppercase")]
	[AmbientProperty("Uppercase")]
	[ThreadAgnostic]
	public sealed class UppercaseLayoutRendererWrapper : WrapperLayoutRendererBase
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.LayoutRenderers.Wrappers.UppercaseLayoutRendererWrapper" /> class.
		/// </summary>
		// Token: 0x060004E8 RID: 1256 RVA: 0x00011588 File Offset: 0x0000F788
		public UppercaseLayoutRendererWrapper()
		{
			this.Culture = CultureInfo.InvariantCulture;
			this.Uppercase = true;
		}

		/// <summary>
		/// Gets or sets a value indicating whether upper case conversion should be applied.
		/// </summary>
		/// <value>A value of <c>true</c> if upper case conversion should be applied otherwise, <c>false</c>.</value>
		/// <docgen category="Transformation Options" order="10" />
		// Token: 0x17000116 RID: 278
		// (get) Token: 0x060004E9 RID: 1257 RVA: 0x000115A8 File Offset: 0x0000F7A8
		// (set) Token: 0x060004EA RID: 1258 RVA: 0x000115BF File Offset: 0x0000F7BF
		[DefaultValue(true)]
		public bool Uppercase { get; set; }

		/// <summary>
		/// Gets or sets the culture used for rendering. 
		/// </summary>
		/// <docgen category="Transformation Options" order="10" />
		// Token: 0x17000117 RID: 279
		// (get) Token: 0x060004EB RID: 1259 RVA: 0x000115C8 File Offset: 0x0000F7C8
		// (set) Token: 0x060004EC RID: 1260 RVA: 0x000115DF File Offset: 0x0000F7DF
		public CultureInfo Culture { get; set; }

		/// <summary>
		/// Post-processes the rendered message. 
		/// </summary>
		/// <param name="text">The text to be post-processed.</param>
		/// <returns>Padded and trimmed string.</returns>
		// Token: 0x060004ED RID: 1261 RVA: 0x000115E8 File Offset: 0x0000F7E8
		protected override string Transform(string text)
		{
			return this.Uppercase ? text.ToUpper(this.Culture) : text;
		}
	}
}
