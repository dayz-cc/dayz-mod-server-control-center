using System;
using System.ComponentModel;
using System.Globalization;
using NLog.Config;

namespace NLog.LayoutRenderers.Wrappers
{
	/// <summary>
	/// Converts the result of another layout output to lower case.
	/// </summary>
	// Token: 0x020000CC RID: 204
	[ThreadAgnostic]
	[AmbientProperty("Lowercase")]
	[LayoutRenderer("lowercase")]
	public sealed class LowercaseLayoutRendererWrapper : WrapperLayoutRendererBase
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.LayoutRenderers.Wrappers.LowercaseLayoutRendererWrapper" /> class.
		/// </summary>
		// Token: 0x060004C0 RID: 1216 RVA: 0x000110DC File Offset: 0x0000F2DC
		public LowercaseLayoutRendererWrapper()
		{
			this.Culture = CultureInfo.InvariantCulture;
			this.Lowercase = true;
		}

		/// <summary>
		/// Gets or sets a value indicating whether lower case conversion should be applied.
		/// </summary>
		/// <value>A value of <c>true</c> if lower case conversion should be applied; otherwise, <c>false</c>.</value>
		/// <docgen category="Transformation Options" order="10" />
		// Token: 0x1700010A RID: 266
		// (get) Token: 0x060004C1 RID: 1217 RVA: 0x000110FC File Offset: 0x0000F2FC
		// (set) Token: 0x060004C2 RID: 1218 RVA: 0x00011113 File Offset: 0x0000F313
		[DefaultValue(true)]
		public bool Lowercase { get; set; }

		/// <summary>
		/// Gets or sets the culture used for rendering. 
		/// </summary>
		/// <docgen category="Transformation Options" order="10" />
		// Token: 0x1700010B RID: 267
		// (get) Token: 0x060004C3 RID: 1219 RVA: 0x0001111C File Offset: 0x0000F31C
		// (set) Token: 0x060004C4 RID: 1220 RVA: 0x00011133 File Offset: 0x0000F333
		public CultureInfo Culture { get; set; }

		/// <summary>
		/// Post-processes the rendered message. 
		/// </summary>
		/// <param name="text">The text to be post-processed.</param>
		/// <returns>Padded and trimmed string.</returns>
		// Token: 0x060004C5 RID: 1221 RVA: 0x0001113C File Offset: 0x0000F33C
		protected override string Transform(string text)
		{
			return this.Lowercase ? text.ToLower(this.Culture) : text;
		}
	}
}
