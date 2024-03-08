using System;
using System.ComponentModel;
using NLog.Config;

namespace NLog.LayoutRenderers.Wrappers
{
	/// <summary>
	/// Applies padding to another layout output.
	/// </summary>
	// Token: 0x020000CE RID: 206
	[AmbientProperty("FixedLength")]
	[ThreadAgnostic]
	[AmbientProperty("Padding")]
	[AmbientProperty("PadCharacter")]
	[LayoutRenderer("pad")]
	public sealed class PaddingLayoutRendererWrapper : WrapperLayoutRendererBase
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.LayoutRenderers.Wrappers.PaddingLayoutRendererWrapper" /> class.
		/// </summary>
		// Token: 0x060004C9 RID: 1225 RVA: 0x000111B3 File Offset: 0x0000F3B3
		public PaddingLayoutRendererWrapper()
		{
			this.PadCharacter = ' ';
		}

		/// <summary>
		/// Gets or sets the number of characters to pad the output to. 
		/// </summary>
		/// <remarks>
		/// Positive padding values cause left padding, negative values 
		/// cause right padding to the desired width.
		/// </remarks>
		/// <docgen category="Transformation Options" order="10" />
		// Token: 0x1700010C RID: 268
		// (get) Token: 0x060004CA RID: 1226 RVA: 0x000111C8 File Offset: 0x0000F3C8
		// (set) Token: 0x060004CB RID: 1227 RVA: 0x000111DF File Offset: 0x0000F3DF
		public int Padding { get; set; }

		/// <summary>
		/// Gets or sets the padding character.
		/// </summary>
		/// <docgen category="Transformation Options" order="10" />
		// Token: 0x1700010D RID: 269
		// (get) Token: 0x060004CC RID: 1228 RVA: 0x000111E8 File Offset: 0x0000F3E8
		// (set) Token: 0x060004CD RID: 1229 RVA: 0x000111FF File Offset: 0x0000F3FF
		[DefaultValue(' ')]
		public char PadCharacter { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether to trim the 
		/// rendered text to the absolute value of the padding length.
		/// </summary>
		/// <docgen category="Transformation Options" order="10" />
		// Token: 0x1700010E RID: 270
		// (get) Token: 0x060004CE RID: 1230 RVA: 0x00011208 File Offset: 0x0000F408
		// (set) Token: 0x060004CF RID: 1231 RVA: 0x0001121F File Offset: 0x0000F41F
		[DefaultValue(false)]
		public bool FixedLength { get; set; }

		/// <summary>
		/// Transforms the output of another layout.
		/// </summary>
		/// <param name="text">Output to be transform.</param>
		/// <returns>Transformed text.</returns>
		// Token: 0x060004D0 RID: 1232 RVA: 0x00011228 File Offset: 0x0000F428
		protected override string Transform(string text)
		{
			string text2 = text ?? string.Empty;
			if (this.Padding != 0)
			{
				if (this.Padding > 0)
				{
					text2 = text2.PadLeft(this.Padding, this.PadCharacter);
				}
				else
				{
					text2 = text2.PadRight(-this.Padding, this.PadCharacter);
				}
				int num = this.Padding;
				if (num < 0)
				{
					num = -num;
				}
				if (this.FixedLength && text2.Length > num)
				{
					text2 = text2.Substring(0, num);
				}
			}
			return text2;
		}
	}
}
