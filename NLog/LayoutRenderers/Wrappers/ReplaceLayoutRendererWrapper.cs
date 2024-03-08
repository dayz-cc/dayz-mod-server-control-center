using System;
using System.Text.RegularExpressions;
using NLog.Config;

namespace NLog.LayoutRenderers.Wrappers
{
	/// <summary>
	/// Replaces a string in the output of another layout with another string.
	/// </summary>
	// Token: 0x020000CF RID: 207
	[LayoutRenderer("replace")]
	[ThreadAgnostic]
	public sealed class ReplaceLayoutRendererWrapper : WrapperLayoutRendererBase
	{
		/// <summary>
		/// Gets or sets the text to search for.
		/// </summary>
		/// <value>The text search for.</value>
		/// <docgen category="Search/Replace Options" order="10" />
		// Token: 0x1700010F RID: 271
		// (get) Token: 0x060004D1 RID: 1233 RVA: 0x000112D0 File Offset: 0x0000F4D0
		// (set) Token: 0x060004D2 RID: 1234 RVA: 0x000112E7 File Offset: 0x0000F4E7
		public string SearchFor { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether regular expressions should be used.
		/// </summary>
		/// <value>A value of <c>true</c> if regular expressions should be used otherwise, <c>false</c>.</value>
		/// <docgen category="Search/Replace Options" order="10" />
		// Token: 0x17000110 RID: 272
		// (get) Token: 0x060004D3 RID: 1235 RVA: 0x000112F0 File Offset: 0x0000F4F0
		// (set) Token: 0x060004D4 RID: 1236 RVA: 0x00011307 File Offset: 0x0000F507
		public bool Regex { get; set; }

		/// <summary>
		/// Gets or sets the replacement string.
		/// </summary>
		/// <value>The replacement string.</value>
		/// <docgen category="Search/Replace Options" order="10" />
		// Token: 0x17000111 RID: 273
		// (get) Token: 0x060004D5 RID: 1237 RVA: 0x00011310 File Offset: 0x0000F510
		// (set) Token: 0x060004D6 RID: 1238 RVA: 0x00011327 File Offset: 0x0000F527
		public string ReplaceWith { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether to ignore case.
		/// </summary>
		/// <value>A value of <c>true</c> if case should be ignored when searching; otherwise, <c>false</c>.</value>
		/// <docgen category="Search/Replace Options" order="10" />
		// Token: 0x17000112 RID: 274
		// (get) Token: 0x060004D7 RID: 1239 RVA: 0x00011330 File Offset: 0x0000F530
		// (set) Token: 0x060004D8 RID: 1240 RVA: 0x00011347 File Offset: 0x0000F547
		public bool IgnoreCase { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether to search for whole words.
		/// </summary>
		/// <value>A value of <c>true</c> if whole words should be searched for; otherwise, <c>false</c>.</value>
		/// <docgen category="Search/Replace Options" order="10" />
		// Token: 0x17000113 RID: 275
		// (get) Token: 0x060004D9 RID: 1241 RVA: 0x00011350 File Offset: 0x0000F550
		// (set) Token: 0x060004DA RID: 1242 RVA: 0x00011367 File Offset: 0x0000F567
		public bool WholeWords { get; set; }

		/// <summary>
		/// Initializes the layout renderer.
		/// </summary>
		// Token: 0x060004DB RID: 1243 RVA: 0x00011370 File Offset: 0x0000F570
		protected override void InitializeLayoutRenderer()
		{
			base.InitializeLayoutRenderer();
			string text = this.SearchFor;
			if (!this.Regex)
			{
				text = global::System.Text.RegularExpressions.Regex.Escape(text);
			}
			RegexOptions regexOptions = RegexOptions.Compiled;
			if (this.IgnoreCase)
			{
				regexOptions |= RegexOptions.IgnoreCase;
			}
			if (this.WholeWords)
			{
				text = "\\b" + text + "\\b";
			}
			this.regex = new Regex(text, regexOptions);
		}

		/// <summary>
		/// Post-processes the rendered message. 
		/// </summary>
		/// <param name="text">The text to be post-processed.</param>
		/// <returns>Post-processed text.</returns>
		// Token: 0x060004DC RID: 1244 RVA: 0x000113E4 File Offset: 0x0000F5E4
		protected override string Transform(string text)
		{
			return this.regex.Replace(text, this.ReplaceWith);
		}

		// Token: 0x040001AB RID: 427
		private Regex regex;
	}
}
