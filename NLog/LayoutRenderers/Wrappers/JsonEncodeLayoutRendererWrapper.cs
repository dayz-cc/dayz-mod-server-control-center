using System;
using System.ComponentModel;
using System.Text;
using NLog.Config;

namespace NLog.LayoutRenderers.Wrappers
{
	/// <summary>
	/// Escapes output of another layout using JSON rules.
	/// </summary>
	// Token: 0x020000CB RID: 203
	[LayoutRenderer("json-encode")]
	[AmbientProperty("JsonEncode")]
	[ThreadAgnostic]
	public sealed class JsonEncodeLayoutRendererWrapper : WrapperLayoutRendererBase
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.LayoutRenderers.Wrappers.JsonEncodeLayoutRendererWrapper" /> class.
		/// </summary>
		// Token: 0x060004BA RID: 1210 RVA: 0x00010F0B File Offset: 0x0000F10B
		public JsonEncodeLayoutRendererWrapper()
		{
			this.JsonEncode = true;
		}

		/// <summary>
		/// Gets or sets a value indicating whether to apply JSON encoding.
		/// </summary>
		/// <docgen category="Transformation Options" order="10" />
		// Token: 0x17000109 RID: 265
		// (get) Token: 0x060004BB RID: 1211 RVA: 0x00010F20 File Offset: 0x0000F120
		// (set) Token: 0x060004BC RID: 1212 RVA: 0x00010F37 File Offset: 0x0000F137
		[DefaultValue(true)]
		public bool JsonEncode { get; set; }

		/// <summary>
		/// Post-processes the rendered message. 
		/// </summary>
		/// <param name="text">The text to be post-processed.</param>
		/// <returns>JSON-encoded string.</returns>
		// Token: 0x060004BD RID: 1213 RVA: 0x00010F40 File Offset: 0x0000F140
		protected override string Transform(string text)
		{
			return this.JsonEncode ? JsonEncodeLayoutRendererWrapper.DoJsonEscape(text) : text;
		}

		// Token: 0x060004BE RID: 1214 RVA: 0x00010F64 File Offset: 0x0000F164
		private static string DoJsonEscape(string text)
		{
			StringBuilder stringBuilder = new StringBuilder(text.Length);
			int i = 0;
			while (i < text.Length)
			{
				char c = text[i];
				if (c <= '"')
				{
					switch (c)
					{
					case '\b':
						stringBuilder.Append("\\b");
						break;
					case '\t':
						stringBuilder.Append("\\t");
						break;
					case '\n':
						stringBuilder.Append("\\n");
						break;
					case '\v':
						goto IL_D4;
					case '\f':
						stringBuilder.Append("\\f");
						break;
					case '\r':
						stringBuilder.Append("\\r");
						break;
					default:
						if (c != '"')
						{
							goto IL_D4;
						}
						stringBuilder.Append("\\\"");
						break;
					}
				}
				else if (c != '/')
				{
					if (c != '\\')
					{
						goto IL_D4;
					}
					stringBuilder.Append("\\\\");
				}
				else
				{
					stringBuilder.Append("\\/");
				}
				IL_128:
				i++;
				continue;
				IL_D4:
				if (JsonEncodeLayoutRendererWrapper.NeedsEscaping(text[i]))
				{
					stringBuilder.Append("\\u");
					stringBuilder.Append(Convert.ToString((int)text[i], 16).PadLeft(4, '0'));
				}
				else
				{
					stringBuilder.Append(text[i]);
				}
				goto IL_128;
			}
			return stringBuilder.ToString();
		}

		// Token: 0x060004BF RID: 1215 RVA: 0x000110BC File Offset: 0x0000F2BC
		private static bool NeedsEscaping(char ch)
		{
			return ch < ' ' || ch > '\u007f';
		}
	}
}
