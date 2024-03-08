using System;
using System.ComponentModel;
using System.Text;
using NLog.Config;

namespace NLog.LayoutRenderers.Wrappers
{
	/// <summary>
	/// Converts the result of another layout output to be XML-compliant.
	/// </summary>
	// Token: 0x020000D6 RID: 214
	[LayoutRenderer("xml-encode")]
	[ThreadAgnostic]
	[AmbientProperty("XmlEncode")]
	public sealed class XmlEncodeLayoutRendererWrapper : WrapperLayoutRendererBase
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.LayoutRenderers.Wrappers.XmlEncodeLayoutRendererWrapper" /> class.
		/// </summary>
		// Token: 0x060004FC RID: 1276 RVA: 0x00011756 File Offset: 0x0000F956
		public XmlEncodeLayoutRendererWrapper()
		{
			this.XmlEncode = true;
		}

		/// <summary>
		/// Gets or sets a value indicating whether to apply XML encoding.
		/// </summary>
		/// <docgen category="Transformation Options" order="10" />
		// Token: 0x1700011B RID: 283
		// (get) Token: 0x060004FD RID: 1277 RVA: 0x0001176C File Offset: 0x0000F96C
		// (set) Token: 0x060004FE RID: 1278 RVA: 0x00011783 File Offset: 0x0000F983
		[DefaultValue(true)]
		public bool XmlEncode { get; set; }

		/// <summary>
		/// Post-processes the rendered message. 
		/// </summary>
		/// <param name="text">The text to be post-processed.</param>
		/// <returns>Padded and trimmed string.</returns>
		// Token: 0x060004FF RID: 1279 RVA: 0x0001178C File Offset: 0x0000F98C
		protected override string Transform(string text)
		{
			return this.XmlEncode ? XmlEncodeLayoutRendererWrapper.DoXmlEscape(text) : text;
		}

		// Token: 0x06000500 RID: 1280 RVA: 0x000117B0 File Offset: 0x0000F9B0
		private static string DoXmlEscape(string text)
		{
			StringBuilder stringBuilder = new StringBuilder(text.Length);
			for (int i = 0; i < text.Length; i++)
			{
				char c = text[i];
				if (c != '"')
				{
					switch (c)
					{
					case '&':
						stringBuilder.Append("&amp;");
						break;
					case '\'':
						stringBuilder.Append("&apos;");
						break;
					default:
						switch (c)
						{
						case '<':
							stringBuilder.Append("&lt;");
							goto IL_A0;
						case '>':
							stringBuilder.Append("&gt;");
							goto IL_A0;
						}
						stringBuilder.Append(text[i]);
						break;
					}
				}
				else
				{
					stringBuilder.Append("&quot;");
				}
				IL_A0:;
			}
			return stringBuilder.ToString();
		}
	}
}
