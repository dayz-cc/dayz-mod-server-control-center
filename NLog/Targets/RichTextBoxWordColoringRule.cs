using System;
using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;
using NLog.Config;

namespace NLog.Targets
{
	/// <summary>
	/// Highlighting rule for Win32 colorful console.
	/// </summary>
	// Token: 0x02000127 RID: 295
	[NLogConfigurationItem]
	public class RichTextBoxWordColoringRule
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Targets.RichTextBoxWordColoringRule" /> class.
		/// </summary>
		// Token: 0x060009D7 RID: 2519 RVA: 0x00022E24 File Offset: 0x00021024
		public RichTextBoxWordColoringRule()
		{
			this.FontColor = "Empty";
			this.BackgroundColor = "Empty";
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Targets.RichTextBoxWordColoringRule" /> class.
		/// </summary>
		/// <param name="text">The text to be matched..</param>
		/// <param name="fontColor">Color of the text.</param>
		/// <param name="backgroundColor">Color of the background.</param>
		// Token: 0x060009D8 RID: 2520 RVA: 0x00022E47 File Offset: 0x00021047
		public RichTextBoxWordColoringRule(string text, string fontColor, string backgroundColor)
		{
			this.Text = text;
			this.FontColor = fontColor;
			this.BackgroundColor = backgroundColor;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Targets.RichTextBoxWordColoringRule" /> class.
		/// </summary>
		/// <param name="text">The text to be matched..</param>
		/// <param name="textColor">Color of the text.</param>
		/// <param name="backgroundColor">Color of the background.</param>
		/// <param name="fontStyle">The font style.</param>
		// Token: 0x060009D9 RID: 2521 RVA: 0x00022E6A File Offset: 0x0002106A
		public RichTextBoxWordColoringRule(string text, string textColor, string backgroundColor, FontStyle fontStyle)
		{
			this.Text = text;
			this.FontColor = textColor;
			this.BackgroundColor = backgroundColor;
			this.Style = fontStyle;
		}

		/// <summary>
		/// Gets or sets the regular expression to be matched. You must specify either <c>text</c> or <c>regex</c>.
		/// </summary>
		/// <docgen category="Rule Matching Options" order="10" />
		// Token: 0x17000215 RID: 533
		// (get) Token: 0x060009DA RID: 2522 RVA: 0x00022E98 File Offset: 0x00021098
		// (set) Token: 0x060009DB RID: 2523 RVA: 0x00022EAF File Offset: 0x000210AF
		public string Regex { get; set; }

		/// <summary>
		/// Gets or sets the text to be matched. You must specify either <c>text</c> or <c>regex</c>.
		/// </summary>
		/// <docgen category="Rule Matching Options" order="10" />
		// Token: 0x17000216 RID: 534
		// (get) Token: 0x060009DC RID: 2524 RVA: 0x00022EB8 File Offset: 0x000210B8
		// (set) Token: 0x060009DD RID: 2525 RVA: 0x00022ECF File Offset: 0x000210CF
		public string Text { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether to match whole words only.
		/// </summary>
		/// <docgen category="Rule Matching Options" order="10" />
		// Token: 0x17000217 RID: 535
		// (get) Token: 0x060009DE RID: 2526 RVA: 0x00022ED8 File Offset: 0x000210D8
		// (set) Token: 0x060009DF RID: 2527 RVA: 0x00022EEF File Offset: 0x000210EF
		[DefaultValue(false)]
		public bool WholeWords { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether to ignore case when comparing texts.
		/// </summary>
		/// <docgen category="Rule Matching Options" order="10" />
		// Token: 0x17000218 RID: 536
		// (get) Token: 0x060009E0 RID: 2528 RVA: 0x00022EF8 File Offset: 0x000210F8
		// (set) Token: 0x060009E1 RID: 2529 RVA: 0x00022F0F File Offset: 0x0002110F
		[DefaultValue(false)]
		public bool IgnoreCase { get; set; }

		/// <summary>
		/// Gets or sets the font style of matched text. 
		/// Possible values are the same as in <c>FontStyle</c> enum in <c>System.Drawing</c>.
		/// </summary>
		/// <docgen category="Formatting Options" order="10" />
		// Token: 0x17000219 RID: 537
		// (get) Token: 0x060009E2 RID: 2530 RVA: 0x00022F18 File Offset: 0x00021118
		// (set) Token: 0x060009E3 RID: 2531 RVA: 0x00022F2F File Offset: 0x0002112F
		public FontStyle Style { get; set; }

		/// <summary>
		/// Gets the compiled regular expression that matches either Text or Regex property.
		/// </summary>
		// Token: 0x1700021A RID: 538
		// (get) Token: 0x060009E4 RID: 2532 RVA: 0x00022F38 File Offset: 0x00021138
		public Regex CompiledRegex
		{
			get
			{
				if (this.compiledRegex == null)
				{
					string text = this.Regex;
					if (text == null && this.Text != null)
					{
						text = global::System.Text.RegularExpressions.Regex.Escape(this.Text);
						if (this.WholeWords)
						{
							text = "\b" + text + "\b";
						}
					}
					RegexOptions regexOptions = RegexOptions.Compiled;
					if (this.IgnoreCase)
					{
						regexOptions |= RegexOptions.IgnoreCase;
					}
					this.compiledRegex = new Regex(text, regexOptions);
				}
				return this.compiledRegex;
			}
		}

		/// <summary>
		/// Gets or sets the font color.
		/// Names are identical with KnownColor enum extended with Empty value which means that font color won't be changed.
		/// </summary>
		/// <docgen category="Formatting Options" order="10" />
		// Token: 0x1700021B RID: 539
		// (get) Token: 0x060009E5 RID: 2533 RVA: 0x00022FD0 File Offset: 0x000211D0
		// (set) Token: 0x060009E6 RID: 2534 RVA: 0x00022FE7 File Offset: 0x000211E7
		[DefaultValue("Empty")]
		public string FontColor { get; set; }

		/// <summary>
		/// Gets or sets the background color. 
		/// Names are identical with KnownColor enum extended with Empty value which means that background color won't be changed.
		/// </summary>
		/// <docgen category="Formatting Options" order="10" />
		// Token: 0x1700021C RID: 540
		// (get) Token: 0x060009E7 RID: 2535 RVA: 0x00022FF0 File Offset: 0x000211F0
		// (set) Token: 0x060009E8 RID: 2536 RVA: 0x00023007 File Offset: 0x00021207
		[DefaultValue("Empty")]
		public string BackgroundColor { get; set; }

		// Token: 0x04000315 RID: 789
		private Regex compiledRegex;
	}
}
