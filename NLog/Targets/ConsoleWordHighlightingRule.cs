using System;
using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;
using NLog.Config;

namespace NLog.Targets
{
	/// <summary>
	/// Highlighting rule for Win32 colorful console.
	/// </summary>
	// Token: 0x0200010A RID: 266
	[NLogConfigurationItem]
	public class ConsoleWordHighlightingRule
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Targets.ConsoleWordHighlightingRule" /> class.
		/// </summary>
		// Token: 0x06000839 RID: 2105 RVA: 0x0001D275 File Offset: 0x0001B475
		public ConsoleWordHighlightingRule()
		{
			this.BackgroundColor = ConsoleOutputColor.NoChange;
			this.ForegroundColor = ConsoleOutputColor.NoChange;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Targets.ConsoleWordHighlightingRule" /> class.
		/// </summary>
		/// <param name="text">The text to be matched..</param>
		/// <param name="foregroundColor">Color of the foreground.</param>
		/// <param name="backgroundColor">Color of the background.</param>
		// Token: 0x0600083A RID: 2106 RVA: 0x0001D292 File Offset: 0x0001B492
		public ConsoleWordHighlightingRule(string text, ConsoleOutputColor foregroundColor, ConsoleOutputColor backgroundColor)
		{
			this.Text = text;
			this.ForegroundColor = foregroundColor;
			this.BackgroundColor = backgroundColor;
		}

		/// <summary>
		/// Gets or sets the regular expression to be matched. You must specify either <c>text</c> or <c>regex</c>.
		/// </summary>
		/// <docgen category="Rule Matching Options" order="10" />
		// Token: 0x17000190 RID: 400
		// (get) Token: 0x0600083B RID: 2107 RVA: 0x0001D2B8 File Offset: 0x0001B4B8
		// (set) Token: 0x0600083C RID: 2108 RVA: 0x0001D2CF File Offset: 0x0001B4CF
		public string Regex { get; set; }

		/// <summary>
		/// Gets or sets the text to be matched. You must specify either <c>text</c> or <c>regex</c>.
		/// </summary>
		/// <docgen category="Rule Matching Options" order="10" />
		// Token: 0x17000191 RID: 401
		// (get) Token: 0x0600083D RID: 2109 RVA: 0x0001D2D8 File Offset: 0x0001B4D8
		// (set) Token: 0x0600083E RID: 2110 RVA: 0x0001D2EF File Offset: 0x0001B4EF
		public string Text { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether to match whole words only.
		/// </summary>
		/// <docgen category="Rule Matching Options" order="10" />
		// Token: 0x17000192 RID: 402
		// (get) Token: 0x0600083F RID: 2111 RVA: 0x0001D2F8 File Offset: 0x0001B4F8
		// (set) Token: 0x06000840 RID: 2112 RVA: 0x0001D30F File Offset: 0x0001B50F
		[DefaultValue(false)]
		public bool WholeWords { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether to ignore case when comparing texts.
		/// </summary>
		/// <docgen category="Rule Matching Options" order="10" />
		// Token: 0x17000193 RID: 403
		// (get) Token: 0x06000841 RID: 2113 RVA: 0x0001D318 File Offset: 0x0001B518
		// (set) Token: 0x06000842 RID: 2114 RVA: 0x0001D32F File Offset: 0x0001B52F
		[DefaultValue(false)]
		public bool IgnoreCase { get; set; }

		/// <summary>
		/// Gets the compiled regular expression that matches either Text or Regex property.
		/// </summary>
		// Token: 0x17000194 RID: 404
		// (get) Token: 0x06000843 RID: 2115 RVA: 0x0001D338 File Offset: 0x0001B538
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
		/// Gets or sets the foreground color.
		/// </summary>
		/// <docgen category="Formatting Options" order="10" />
		// Token: 0x17000195 RID: 405
		// (get) Token: 0x06000844 RID: 2116 RVA: 0x0001D3D0 File Offset: 0x0001B5D0
		// (set) Token: 0x06000845 RID: 2117 RVA: 0x0001D3E7 File Offset: 0x0001B5E7
		[DefaultValue("NoChange")]
		public ConsoleOutputColor ForegroundColor { get; set; }

		/// <summary>
		/// Gets or sets the background color.
		/// </summary>
		/// <docgen category="Formatting Options" order="10" />
		// Token: 0x17000196 RID: 406
		// (get) Token: 0x06000846 RID: 2118 RVA: 0x0001D3F0 File Offset: 0x0001B5F0
		// (set) Token: 0x06000847 RID: 2119 RVA: 0x0001D407 File Offset: 0x0001B607
		[DefaultValue("NoChange")]
		public ConsoleOutputColor BackgroundColor { get; set; }

		// Token: 0x06000848 RID: 2120 RVA: 0x0001D410 File Offset: 0x0001B610
		internal string MatchEvaluator(Match m)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append('\a');
			stringBuilder.Append((char)(this.ForegroundColor + 65));
			stringBuilder.Append((char)(this.BackgroundColor + 65));
			stringBuilder.Append(m.Value);
			stringBuilder.Append('\a');
			stringBuilder.Append('X');
			return stringBuilder.ToString();
		}

		// Token: 0x06000849 RID: 2121 RVA: 0x0001D478 File Offset: 0x0001B678
		internal string ReplaceWithEscapeSequences(string message)
		{
			return this.CompiledRegex.Replace(message, new MatchEvaluator(this.MatchEvaluator));
		}

		// Token: 0x0400026D RID: 621
		private Regex compiledRegex;
	}
}
