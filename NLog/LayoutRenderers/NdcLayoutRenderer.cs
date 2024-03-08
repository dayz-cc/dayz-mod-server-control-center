using System;
using System.Text;

namespace NLog.LayoutRenderers
{
	/// <summary>
	/// Nested Diagnostic Context item. Provided for compatibility with log4net.
	/// </summary>
	// Token: 0x020000B3 RID: 179
	[LayoutRenderer("ndc")]
	public class NdcLayoutRenderer : LayoutRenderer
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.LayoutRenderers.NdcLayoutRenderer" /> class.
		/// </summary>
		// Token: 0x06000438 RID: 1080 RVA: 0x0000FAB9 File Offset: 0x0000DCB9
		public NdcLayoutRenderer()
		{
			this.Separator = " ";
			this.BottomFrames = -1;
			this.TopFrames = -1;
		}

		/// <summary>
		/// Gets or sets the number of top stack frames to be rendered.
		/// </summary>
		/// <docgen category="Rendering Options" order="10" />
		// Token: 0x170000E5 RID: 229
		// (get) Token: 0x06000439 RID: 1081 RVA: 0x0000FAE0 File Offset: 0x0000DCE0
		// (set) Token: 0x0600043A RID: 1082 RVA: 0x0000FAF7 File Offset: 0x0000DCF7
		public int TopFrames { get; set; }

		/// <summary>
		/// Gets or sets the number of bottom stack frames to be rendered.
		/// </summary>
		/// <docgen category="Rendering Options" order="10" />
		// Token: 0x170000E6 RID: 230
		// (get) Token: 0x0600043B RID: 1083 RVA: 0x0000FB00 File Offset: 0x0000DD00
		// (set) Token: 0x0600043C RID: 1084 RVA: 0x0000FB17 File Offset: 0x0000DD17
		public int BottomFrames { get; set; }

		/// <summary>
		/// Gets or sets the separator to be used for concatenating nested diagnostics context output.
		/// </summary>
		/// <docgen category="Rendering Options" order="10" />
		// Token: 0x170000E7 RID: 231
		// (get) Token: 0x0600043D RID: 1085 RVA: 0x0000FB20 File Offset: 0x0000DD20
		// (set) Token: 0x0600043E RID: 1086 RVA: 0x0000FB37 File Offset: 0x0000DD37
		public string Separator { get; set; }

		/// <summary>
		/// Renders the specified Nested Diagnostics Context item and appends it to the specified <see cref="T:System.Text.StringBuilder" />.
		/// </summary>
		/// <param name="builder">The <see cref="T:System.Text.StringBuilder" /> to append the rendered data to.</param>
		/// <param name="logEvent">Logging event.</param>
		// Token: 0x0600043F RID: 1087 RVA: 0x0000FB40 File Offset: 0x0000DD40
		protected override void Append(StringBuilder builder, LogEventInfo logEvent)
		{
			string[] allMessages = NestedDiagnosticsContext.GetAllMessages();
			int num = 0;
			int num2 = allMessages.Length;
			if (this.TopFrames != -1)
			{
				num2 = Math.Min(this.TopFrames, allMessages.Length);
			}
			else if (this.BottomFrames != -1)
			{
				num = allMessages.Length - Math.Min(this.BottomFrames, allMessages.Length);
			}
			int num3 = 0;
			int num4 = 0;
			for (int i = num2 - 1; i >= num; i--)
			{
				num3 += num4 + allMessages[i].Length;
				num4 = this.Separator.Length;
			}
			string text = string.Empty;
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = num2 - 1; i >= num; i--)
			{
				stringBuilder.Append(text);
				stringBuilder.Append(allMessages[i]);
				text = this.Separator;
			}
			builder.Append(stringBuilder.ToString());
		}
	}
}
