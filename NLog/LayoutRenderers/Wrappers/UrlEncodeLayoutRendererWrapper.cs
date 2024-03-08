using System;
using NLog.Config;
using NLog.Internal;

namespace NLog.LayoutRenderers.Wrappers
{
	/// <summary>
	/// Encodes the result of another layout output for use with URLs.
	/// </summary>
	// Token: 0x020000D3 RID: 211
	[ThreadAgnostic]
	[LayoutRenderer("url-encode")]
	public sealed class UrlEncodeLayoutRendererWrapper : WrapperLayoutRendererBase
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.LayoutRenderers.Wrappers.UrlEncodeLayoutRendererWrapper" /> class.
		/// </summary>
		// Token: 0x060004EE RID: 1262 RVA: 0x00011612 File Offset: 0x0000F812
		public UrlEncodeLayoutRendererWrapper()
		{
			this.SpaceAsPlus = true;
		}

		/// <summary>
		/// Gets or sets a value indicating whether spaces should be translated to '+' or '%20'.
		/// </summary>
		/// <value>A value of <c>true</c> if space should be translated to '+'; otherwise, <c>false</c>.</value>
		/// <docgen category="Transformation Options" order="10" />
		// Token: 0x17000118 RID: 280
		// (get) Token: 0x060004EF RID: 1263 RVA: 0x00011628 File Offset: 0x0000F828
		// (set) Token: 0x060004F0 RID: 1264 RVA: 0x0001163F File Offset: 0x0000F83F
		public bool SpaceAsPlus { get; set; }

		/// <summary>
		/// Transforms the output of another layout.
		/// </summary>
		/// <param name="text">Output to be transform.</param>
		/// <returns>Transformed text.</returns>
		// Token: 0x060004F1 RID: 1265 RVA: 0x00011648 File Offset: 0x0000F848
		protected override string Transform(string text)
		{
			return UrlHelper.UrlEncode(text, this.SpaceAsPlus);
		}
	}
}
