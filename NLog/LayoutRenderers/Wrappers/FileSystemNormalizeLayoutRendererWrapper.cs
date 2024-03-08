using System;
using System.ComponentModel;
using System.Text;
using NLog.Config;

namespace NLog.LayoutRenderers.Wrappers
{
	/// <summary>
	/// Filters characters not allowed in the file names by replacing them with safe character.
	/// </summary>
	// Token: 0x020000CA RID: 202
	[LayoutRenderer("filesystem-normalize")]
	[ThreadAgnostic]
	[AmbientProperty("FSNormalize")]
	public sealed class FileSystemNormalizeLayoutRendererWrapper : WrapperLayoutRendererBase
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.LayoutRenderers.Wrappers.FileSystemNormalizeLayoutRendererWrapper" /> class.
		/// </summary>
		// Token: 0x060004B5 RID: 1205 RVA: 0x00010E2C File Offset: 0x0000F02C
		public FileSystemNormalizeLayoutRendererWrapper()
		{
			this.FSNormalize = true;
		}

		/// <summary>
		/// Gets or sets a value indicating whether to modify the output of this renderer so it can be used as a part of file path
		/// (illegal characters are replaced with '_').
		/// </summary>
		/// <docgen category="Advanced Options" order="10" />
		// Token: 0x17000108 RID: 264
		// (get) Token: 0x060004B6 RID: 1206 RVA: 0x00010E40 File Offset: 0x0000F040
		// (set) Token: 0x060004B7 RID: 1207 RVA: 0x00010E57 File Offset: 0x0000F057
		[DefaultValue(true)]
		public bool FSNormalize { get; set; }

		/// <summary>
		/// Post-processes the rendered message. 
		/// </summary>
		/// <param name="text">The text to be post-processed.</param>
		/// <returns>Padded and trimmed string.</returns>
		// Token: 0x060004B8 RID: 1208 RVA: 0x00010E60 File Offset: 0x0000F060
		protected override string Transform(string text)
		{
			string text2;
			if (this.FSNormalize)
			{
				StringBuilder stringBuilder = new StringBuilder(text);
				for (int i = 0; i < stringBuilder.Length; i++)
				{
					char c = stringBuilder[i];
					if (!FileSystemNormalizeLayoutRendererWrapper.IsSafeCharacter(c))
					{
						stringBuilder[i] = '_';
					}
				}
				text2 = stringBuilder.ToString();
			}
			else
			{
				text2 = text;
			}
			return text2;
		}

		// Token: 0x060004B9 RID: 1209 RVA: 0x00010ECC File Offset: 0x0000F0CC
		private static bool IsSafeCharacter(char c)
		{
			return char.IsLetterOrDigit(c) || c == '_' || c == '-' || c == '.' || c == ' ';
		}
	}
}
