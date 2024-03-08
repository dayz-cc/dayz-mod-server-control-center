using System;
using System.ComponentModel;
using NLog.Config;

namespace NLog.LayoutRenderers.Wrappers
{
	/// <summary>
	/// Trims the whitespace from the result of another layout renderer.
	/// </summary>
	// Token: 0x020000D1 RID: 209
	[LayoutRenderer("trim-whitespace")]
	[ThreadAgnostic]
	[AmbientProperty("TrimWhiteSpace")]
	public sealed class TrimWhiteSpaceLayoutRendererWrapper : WrapperLayoutRendererBase
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.LayoutRenderers.Wrappers.TrimWhiteSpaceLayoutRendererWrapper" /> class.
		/// </summary>
		// Token: 0x060004E4 RID: 1252 RVA: 0x0001152F File Offset: 0x0000F72F
		public TrimWhiteSpaceLayoutRendererWrapper()
		{
			this.TrimWhiteSpace = true;
		}

		/// <summary>
		/// Gets or sets a value indicating whether lower case conversion should be applied.
		/// </summary>
		/// <value>A value of <c>true</c> if lower case conversion should be applied; otherwise, <c>false</c>.</value>
		/// <docgen category="Transformation Options" order="10" />
		// Token: 0x17000115 RID: 277
		// (get) Token: 0x060004E5 RID: 1253 RVA: 0x00011544 File Offset: 0x0000F744
		// (set) Token: 0x060004E6 RID: 1254 RVA: 0x0001155B File Offset: 0x0000F75B
		[DefaultValue(true)]
		public bool TrimWhiteSpace { get; set; }

		/// <summary>
		/// Post-processes the rendered message. 
		/// </summary>
		/// <param name="text">The text to be post-processed.</param>
		/// <returns>Trimmed string.</returns>
		// Token: 0x060004E7 RID: 1255 RVA: 0x00011564 File Offset: 0x0000F764
		protected override string Transform(string text)
		{
			return this.TrimWhiteSpace ? text.Trim() : text;
		}
	}
}
