using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using NLog.Config;

namespace NLog.Targets
{
	/// <summary>
	/// Writes log messages to the console with customizable coloring.
	/// </summary>
	/// <seealso href="http://nlog-project.org/wiki/ColoredConsole_target">Documentation on NLog Wiki</seealso>
	// Token: 0x02000105 RID: 261
	[Target("ColoredConsole")]
	public sealed class ColoredConsoleTarget : TargetWithLayoutHeaderAndFooter
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Targets.ColoredConsoleTarget" /> class.
		/// </summary>
		/// <remarks>
		/// The default value of the layout is: <code>${longdate}|${level:uppercase=true}|${logger}|${message}</code>
		/// </remarks>
		// Token: 0x06000814 RID: 2068 RVA: 0x0001C9B0 File Offset: 0x0001ABB0
		public ColoredConsoleTarget()
		{
			this.WordHighlightingRules = new List<ConsoleWordHighlightingRule>();
			this.RowHighlightingRules = new List<ConsoleRowHighlightingRule>();
			this.UseDefaultRowHighlightingRules = true;
		}

		/// <summary>
		/// Gets or sets a value indicating whether the error stream (stderr) should be used instead of the output stream (stdout).
		/// </summary>
		/// <docgen category="Output Options" order="10" />
		// Token: 0x17000185 RID: 389
		// (get) Token: 0x06000815 RID: 2069 RVA: 0x0001C9DC File Offset: 0x0001ABDC
		// (set) Token: 0x06000816 RID: 2070 RVA: 0x0001C9F3 File Offset: 0x0001ABF3
		[DefaultValue(false)]
		public bool ErrorStream { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether to use default row highlighting rules.
		/// </summary>
		/// <remarks>
		/// The default rules are:
		/// <table>
		/// <tr>
		/// <th>Condition</th>
		/// <th>Foreground Color</th>
		/// <th>Background Color</th>
		/// </tr>
		/// <tr>
		/// <td>level == LogLevel.Fatal</td>
		/// <td>Red</td>
		/// <td>NoChange</td>
		/// </tr>
		/// <tr>
		/// <td>level == LogLevel.Error</td>
		/// <td>Yellow</td>
		/// <td>NoChange</td>
		/// </tr>
		/// <tr>
		/// <td>level == LogLevel.Warn</td>
		/// <td>Magenta</td>
		/// <td>NoChange</td>
		/// </tr>
		/// <tr>
		/// <td>level == LogLevel.Info</td>
		/// <td>White</td>
		/// <td>NoChange</td>
		/// </tr>
		/// <tr>
		/// <td>level == LogLevel.Debug</td>
		/// <td>Gray</td>
		/// <td>NoChange</td>
		/// </tr>
		/// <tr>
		/// <td>level == LogLevel.Trace</td>
		/// <td>DarkGray</td>
		/// <td>NoChange</td>
		/// </tr>
		/// </table>
		/// </remarks>
		/// <docgen category="Highlighting Rules" order="9" />
		// Token: 0x17000186 RID: 390
		// (get) Token: 0x06000817 RID: 2071 RVA: 0x0001C9FC File Offset: 0x0001ABFC
		// (set) Token: 0x06000818 RID: 2072 RVA: 0x0001CA13 File Offset: 0x0001AC13
		[DefaultValue(true)]
		public bool UseDefaultRowHighlightingRules { get; set; }

		/// <summary>
		/// Gets the row highlighting rules.
		/// </summary>
		/// <docgen category="Highlighting Rules" order="10" />
		// Token: 0x17000187 RID: 391
		// (get) Token: 0x06000819 RID: 2073 RVA: 0x0001CA1C File Offset: 0x0001AC1C
		// (set) Token: 0x0600081A RID: 2074 RVA: 0x0001CA33 File Offset: 0x0001AC33
		[ArrayParameter(typeof(ConsoleRowHighlightingRule), "highlight-row")]
		public IList<ConsoleRowHighlightingRule> RowHighlightingRules { get; private set; }

		/// <summary>
		/// Gets the word highlighting rules.
		/// </summary>
		/// <docgen category="Highlighting Rules" order="11" />
		// Token: 0x17000188 RID: 392
		// (get) Token: 0x0600081B RID: 2075 RVA: 0x0001CA3C File Offset: 0x0001AC3C
		// (set) Token: 0x0600081C RID: 2076 RVA: 0x0001CA53 File Offset: 0x0001AC53
		[ArrayParameter(typeof(ConsoleWordHighlightingRule), "highlight-word")]
		public IList<ConsoleWordHighlightingRule> WordHighlightingRules { get; private set; }

		/// <summary>
		/// Initializes the target.
		/// </summary>
		// Token: 0x0600081D RID: 2077 RVA: 0x0001CA5C File Offset: 0x0001AC5C
		protected override void InitializeTarget()
		{
			base.InitializeTarget();
			if (base.Header != null)
			{
				LogEventInfo logEventInfo = LogEventInfo.CreateNullEvent();
				this.Output(logEventInfo, base.Header.Render(logEventInfo));
			}
		}

		/// <summary>
		/// Closes the target and releases any unmanaged resources.
		/// </summary>
		// Token: 0x0600081E RID: 2078 RVA: 0x0001CA9C File Offset: 0x0001AC9C
		protected override void CloseTarget()
		{
			if (base.Footer != null)
			{
				LogEventInfo logEventInfo = LogEventInfo.CreateNullEvent();
				this.Output(logEventInfo, base.Footer.Render(logEventInfo));
			}
			base.CloseTarget();
		}

		/// <summary>
		/// Writes the specified log event to the console highlighting entries
		/// and words based on a set of defined rules.
		/// </summary>
		/// <param name="logEvent">Log event.</param>
		// Token: 0x0600081F RID: 2079 RVA: 0x0001CADA File Offset: 0x0001ACDA
		protected override void Write(LogEventInfo logEvent)
		{
			this.Output(logEvent, this.Layout.Render(logEvent));
		}

		// Token: 0x06000820 RID: 2080 RVA: 0x0001CAF4 File Offset: 0x0001ACF4
		private static void ColorizeEscapeSequences(TextWriter output, string message, ColoredConsoleTarget.ColorPair startingColor, ColoredConsoleTarget.ColorPair defaultColor)
		{
			Stack<ColoredConsoleTarget.ColorPair> stack = new Stack<ColoredConsoleTarget.ColorPair>();
			stack.Push(startingColor);
			int i = 0;
			while (i < message.Length)
			{
				int num = i;
				while (num < message.Length && message[num] >= ' ')
				{
					num++;
				}
				if (num != i)
				{
					output.Write(message.Substring(i, num - i));
				}
				if (num >= message.Length)
				{
					i = num;
					break;
				}
				char c = message[num];
				char c2 = '\0';
				if (num + 1 < message.Length)
				{
					c2 = message[num + 1];
				}
				if (c == '\a' && c2 == '\a')
				{
					output.Write('\a');
					i = num + 2;
				}
				else if (c == '\r' || c == '\n')
				{
					Console.ForegroundColor = defaultColor.ForegroundColor;
					Console.BackgroundColor = defaultColor.BackgroundColor;
					output.Write(c);
					Console.ForegroundColor = stack.Peek().ForegroundColor;
					Console.BackgroundColor = stack.Peek().BackgroundColor;
					i = num + 1;
				}
				else if (c == '\a')
				{
					if (c2 == 'X')
					{
						stack.Pop();
						Console.ForegroundColor = stack.Peek().ForegroundColor;
						Console.BackgroundColor = stack.Peek().BackgroundColor;
						i = num + 2;
					}
					else
					{
						ConsoleOutputColor consoleOutputColor = (ConsoleOutputColor)(c2 - 'A');
						ConsoleOutputColor consoleOutputColor2 = (ConsoleOutputColor)(message[num + 2] - 'A');
						if (consoleOutputColor != ConsoleOutputColor.NoChange)
						{
							Console.ForegroundColor = (ConsoleColor)consoleOutputColor;
						}
						if (consoleOutputColor2 != ConsoleOutputColor.NoChange)
						{
							Console.BackgroundColor = (ConsoleColor)consoleOutputColor2;
						}
						stack.Push(new ColoredConsoleTarget.ColorPair(Console.ForegroundColor, Console.BackgroundColor));
						i = num + 3;
					}
				}
				else
				{
					output.Write(c);
					i = num + 1;
				}
			}
			if (i < message.Length)
			{
				output.Write(message.Substring(i));
			}
		}

		// Token: 0x06000821 RID: 2081 RVA: 0x0001CD30 File Offset: 0x0001AF30
		private void Output(LogEventInfo logEvent, string message)
		{
			ConsoleColor foregroundColor = Console.ForegroundColor;
			ConsoleColor backgroundColor = Console.BackgroundColor;
			try
			{
				ConsoleRowHighlightingRule consoleRowHighlightingRule = null;
				foreach (ConsoleRowHighlightingRule consoleRowHighlightingRule2 in this.RowHighlightingRules)
				{
					if (consoleRowHighlightingRule2.CheckCondition(logEvent))
					{
						consoleRowHighlightingRule = consoleRowHighlightingRule2;
						break;
					}
				}
				if (this.UseDefaultRowHighlightingRules && consoleRowHighlightingRule == null)
				{
					foreach (ConsoleRowHighlightingRule consoleRowHighlightingRule2 in ColoredConsoleTarget.defaultConsoleRowHighlightingRules)
					{
						if (consoleRowHighlightingRule2.CheckCondition(logEvent))
						{
							consoleRowHighlightingRule = consoleRowHighlightingRule2;
							break;
						}
					}
				}
				if (consoleRowHighlightingRule == null)
				{
					consoleRowHighlightingRule = ConsoleRowHighlightingRule.Default;
				}
				if (consoleRowHighlightingRule.ForegroundColor != ConsoleOutputColor.NoChange)
				{
					Console.ForegroundColor = (ConsoleColor)consoleRowHighlightingRule.ForegroundColor;
				}
				if (consoleRowHighlightingRule.BackgroundColor != ConsoleOutputColor.NoChange)
				{
					Console.BackgroundColor = (ConsoleColor)consoleRowHighlightingRule.BackgroundColor;
				}
				message = message.Replace("\a", "\a\a");
				foreach (ConsoleWordHighlightingRule consoleWordHighlightingRule in this.WordHighlightingRules)
				{
					message = consoleWordHighlightingRule.ReplaceWithEscapeSequences(message);
				}
				ColoredConsoleTarget.ColorizeEscapeSequences(this.ErrorStream ? Console.Error : Console.Out, message, new ColoredConsoleTarget.ColorPair(Console.ForegroundColor, Console.BackgroundColor), new ColoredConsoleTarget.ColorPair(foregroundColor, backgroundColor));
			}
			finally
			{
				Console.ForegroundColor = foregroundColor;
				Console.BackgroundColor = backgroundColor;
			}
			if (this.ErrorStream)
			{
				Console.Error.WriteLine();
			}
			else
			{
				Console.WriteLine();
			}
		}

		// Token: 0x0400024F RID: 591
		private static readonly IList<ConsoleRowHighlightingRule> defaultConsoleRowHighlightingRules = new List<ConsoleRowHighlightingRule>
		{
			new ConsoleRowHighlightingRule("level == LogLevel.Fatal", ConsoleOutputColor.Red, ConsoleOutputColor.NoChange),
			new ConsoleRowHighlightingRule("level == LogLevel.Error", ConsoleOutputColor.Yellow, ConsoleOutputColor.NoChange),
			new ConsoleRowHighlightingRule("level == LogLevel.Warn", ConsoleOutputColor.Magenta, ConsoleOutputColor.NoChange),
			new ConsoleRowHighlightingRule("level == LogLevel.Info", ConsoleOutputColor.White, ConsoleOutputColor.NoChange),
			new ConsoleRowHighlightingRule("level == LogLevel.Debug", ConsoleOutputColor.Gray, ConsoleOutputColor.NoChange),
			new ConsoleRowHighlightingRule("level == LogLevel.Trace", ConsoleOutputColor.DarkGray, ConsoleOutputColor.NoChange)
		};

		/// <summary>
		/// Color pair (foreground and background).
		/// </summary>
		// Token: 0x02000106 RID: 262
		internal struct ColorPair
		{
			// Token: 0x06000823 RID: 2083 RVA: 0x0001D03F File Offset: 0x0001B23F
			internal ColorPair(ConsoleColor foregroundColor, ConsoleColor backgroundColor)
			{
				this.foregroundColor = foregroundColor;
				this.backgroundColor = backgroundColor;
			}

			// Token: 0x17000189 RID: 393
			// (get) Token: 0x06000824 RID: 2084 RVA: 0x0001D050 File Offset: 0x0001B250
			internal ConsoleColor BackgroundColor
			{
				get
				{
					return this.backgroundColor;
				}
			}

			// Token: 0x1700018A RID: 394
			// (get) Token: 0x06000825 RID: 2085 RVA: 0x0001D068 File Offset: 0x0001B268
			internal ConsoleColor ForegroundColor
			{
				get
				{
					return this.foregroundColor;
				}
			}

			// Token: 0x04000254 RID: 596
			private readonly ConsoleColor foregroundColor;

			// Token: 0x04000255 RID: 597
			private readonly ConsoleColor backgroundColor;
		}
	}
}
