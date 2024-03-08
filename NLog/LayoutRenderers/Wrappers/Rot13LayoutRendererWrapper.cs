using System;
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
	// Token: 0x020000D0 RID: 208
	[LayoutRenderer("rot13")]
	[AppDomainFixedOutput]
	[ThreadAgnostic]
	public sealed class Rot13LayoutRendererWrapper : WrapperLayoutRendererBase
	{
		/// <summary>
		/// Gets or sets the layout to be wrapped.
		/// </summary>
		/// <value>The layout to be wrapped.</value>
		/// <remarks>This variable is for backwards compatibility</remarks>
		/// <docgen category="Transformation Options" order="10" />
		// Token: 0x17000114 RID: 276
		// (get) Token: 0x060004DE RID: 1246 RVA: 0x00011410 File Offset: 0x0000F610
		// (set) Token: 0x060004DF RID: 1247 RVA: 0x00011428 File Offset: 0x0000F628
		public Layout Text
		{
			get
			{
				return base.Inner;
			}
			set
			{
				base.Inner = value;
			}
		}

		/// <summary>
		/// Encodes/Decodes ROT-13-encoded string.
		/// </summary>
		/// <param name="encodedValue">The string to be encoded/decoded.</param>
		/// <returns>Encoded/Decoded text.</returns>
		// Token: 0x060004E0 RID: 1248 RVA: 0x00011434 File Offset: 0x0000F634
		public static string DecodeRot13(string encodedValue)
		{
			string text;
			if (encodedValue == null)
			{
				text = null;
			}
			else
			{
				char[] array = encodedValue.ToCharArray();
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = Rot13LayoutRendererWrapper.DecodeRot13Char(array[i]);
				}
				text = new string(array);
			}
			return text;
		}

		/// <summary>
		/// Transforms the output of another layout.
		/// </summary>
		/// <param name="text">Output to be transform.</param>
		/// <returns>Transformed text.</returns>
		// Token: 0x060004E1 RID: 1249 RVA: 0x00011484 File Offset: 0x0000F684
		protected override string Transform(string text)
		{
			return Rot13LayoutRendererWrapper.DecodeRot13(text);
		}

		// Token: 0x060004E2 RID: 1250 RVA: 0x0001149C File Offset: 0x0000F69C
		private static char DecodeRot13Char(char c)
		{
			char c2;
			if (c >= 'A' && c <= 'M')
			{
				c2 = 'N' + (c - 'A');
			}
			else if (c >= 'a' && c <= 'm')
			{
				c2 = 'n' + (c - 'a');
			}
			else if (c >= 'N' && c <= 'Z')
			{
				c2 = 'A' + (c - 'N');
			}
			else if (c >= 'n' && c <= 'z')
			{
				c2 = 'a' + (c - 'n');
			}
			else
			{
				c2 = c;
			}
			return c2;
		}
	}
}
