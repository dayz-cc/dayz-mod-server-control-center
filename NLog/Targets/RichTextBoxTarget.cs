using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using NLog.Config;
using NLog.Internal;

namespace NLog.Targets
{
	/// <summary>
	/// Log text a Rich Text Box control in an existing or new form.
	/// </summary>
	/// <seealso href="http://nlog-project.org/wiki/RichTextBox_target">Documentation on NLog Wiki</seealso>
	/// <example>
	/// <p>
	/// To set up the target in the <a href="config.html">configuration file</a>, 
	/// use the following syntax:
	/// </p><code lang="XML" source="examples/targets/Configuration File/RichTextBox/Simple/NLog.config">
	/// </code>
	/// <p>
	/// The result is:
	/// </p><img src="examples/targets/Screenshots/RichTextBox/Simple.gif" /><p>
	/// To set up the target with coloring rules in the <a href="config.html">configuration file</a>, 
	/// use the following syntax:
	/// </p><code lang="XML" source="examples/targets/Configuration File/RichTextBox/RowColoring/NLog.config">
	/// </code>
	/// <code lang="XML" source="examples/targets/Configuration File/RichTextBox/WordColoring/NLog.config">
	/// </code>
	/// <p>
	/// The result is:
	/// </p><img src="examples/targets/Screenshots/RichTextBox/RowColoring.gif" /><img src="examples/targets/Screenshots/RichTextBox/WordColoring.gif" /><p>
	/// To set up the log target programmatically similar to above use code like this:
	/// </p><code lang="C#" source="examples/targets/Configuration API/RichTextBox/Simple/Form1.cs">
	/// </code>
	/// ,
	/// <code lang="C#" source="examples/targets/Configuration API/RichTextBox/RowColoring/Form1.cs">
	/// </code>
	/// for RowColoring,
	/// <code lang="C#" source="examples/targets/Configuration API/RichTextBox/WordColoring/Form1.cs">
	/// </code>
	/// for WordColoring
	/// </example>
	// Token: 0x02000124 RID: 292
	[Target("RichTextBox")]
	public sealed class RichTextBoxTarget : TargetWithLayout
	{
		/// <summary>
		/// Initializes static members of the RichTextBoxTarget class.
		/// </summary>
		/// <remarks>
		/// The default value of the layout is: <code>${longdate}|${level:uppercase=true}|${logger}|${message}</code>
		/// </remarks>
		// Token: 0x060009AA RID: 2474 RVA: 0x000225E8 File Offset: 0x000207E8
		static RichTextBoxTarget()
		{
			List<RichTextBoxRowColoringRule> list = new List<RichTextBoxRowColoringRule>
			{
				new RichTextBoxRowColoringRule("level == LogLevel.Fatal", "White", "Red", FontStyle.Bold),
				new RichTextBoxRowColoringRule("level == LogLevel.Error", "Red", "Empty", FontStyle.Bold | FontStyle.Italic),
				new RichTextBoxRowColoringRule("level == LogLevel.Warn", "Orange", "Empty", FontStyle.Underline),
				new RichTextBoxRowColoringRule("level == LogLevel.Info", "Black", "Empty"),
				new RichTextBoxRowColoringRule("level == LogLevel.Debug", "Gray", "Empty"),
				new RichTextBoxRowColoringRule("level == LogLevel.Trace", "DarkGray", "Empty", FontStyle.Italic)
			};
			RichTextBoxTarget.DefaultRowColoringRules = list.AsReadOnly();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Targets.RichTextBoxTarget" /> class.
		/// </summary>
		/// <remarks>
		/// The default value of the layout is: <code>${longdate}|${level:uppercase=true}|${logger}|${message}</code>
		/// </remarks>
		// Token: 0x060009AB RID: 2475 RVA: 0x000226B0 File Offset: 0x000208B0
		public RichTextBoxTarget()
		{
			this.WordColoringRules = new List<RichTextBoxWordColoringRule>();
			this.RowColoringRules = new List<RichTextBoxRowColoringRule>();
			this.ToolWindow = true;
		}

		/// <summary>
		/// Gets the default set of row coloring rules which applies when <see cref="P:NLog.Targets.RichTextBoxTarget.UseDefaultRowColoringRules" /> is set to true.
		/// </summary>
		// Token: 0x17000206 RID: 518
		// (get) Token: 0x060009AC RID: 2476 RVA: 0x000226DC File Offset: 0x000208DC
		// (set) Token: 0x060009AD RID: 2477 RVA: 0x000226F2 File Offset: 0x000208F2
		public static ReadOnlyCollection<RichTextBoxRowColoringRule> DefaultRowColoringRules { get; private set; }

		/// <summary>
		/// Gets or sets the Name of RichTextBox to which Nlog will write.
		/// </summary>
		/// <docgen category="Form Options" order="10" />
		// Token: 0x17000207 RID: 519
		// (get) Token: 0x060009AE RID: 2478 RVA: 0x000226FC File Offset: 0x000208FC
		// (set) Token: 0x060009AF RID: 2479 RVA: 0x00022713 File Offset: 0x00020913
		public string ControlName { get; set; }

		/// <summary>
		/// Gets or sets the name of the Form on which the control is located. 
		/// If there is no open form of a specified name than NLog will create a new one.
		/// </summary>
		/// <docgen category="Form Options" order="10" />
		// Token: 0x17000208 RID: 520
		// (get) Token: 0x060009B0 RID: 2480 RVA: 0x0002271C File Offset: 0x0002091C
		// (set) Token: 0x060009B1 RID: 2481 RVA: 0x00022733 File Offset: 0x00020933
		public string FormName { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether to use default coloring rules.
		/// </summary>
		/// <docgen category="Highlighting Options" order="10" />
		// Token: 0x17000209 RID: 521
		// (get) Token: 0x060009B2 RID: 2482 RVA: 0x0002273C File Offset: 0x0002093C
		// (set) Token: 0x060009B3 RID: 2483 RVA: 0x00022753 File Offset: 0x00020953
		[DefaultValue(false)]
		public bool UseDefaultRowColoringRules { get; set; }

		/// <summary>
		/// Gets the row coloring rules.
		/// </summary>
		/// <docgen category="Highlighting Options" order="10" />
		// Token: 0x1700020A RID: 522
		// (get) Token: 0x060009B4 RID: 2484 RVA: 0x0002275C File Offset: 0x0002095C
		// (set) Token: 0x060009B5 RID: 2485 RVA: 0x00022773 File Offset: 0x00020973
		[ArrayParameter(typeof(RichTextBoxRowColoringRule), "row-coloring")]
		public IList<RichTextBoxRowColoringRule> RowColoringRules { get; private set; }

		/// <summary>
		/// Gets the word highlighting rules.
		/// </summary>
		/// <docgen category="Highlighting Options" order="10" />
		// Token: 0x1700020B RID: 523
		// (get) Token: 0x060009B6 RID: 2486 RVA: 0x0002277C File Offset: 0x0002097C
		// (set) Token: 0x060009B7 RID: 2487 RVA: 0x00022793 File Offset: 0x00020993
		[ArrayParameter(typeof(RichTextBoxWordColoringRule), "word-coloring")]
		public IList<RichTextBoxWordColoringRule> WordColoringRules { get; private set; }

		/// <summary>
		/// Gets or sets a value indicating whether the created window will be a tool window.
		/// </summary>
		/// <remarks>
		/// This parameter is ignored when logging to existing form control.
		/// Tool windows have thin border, and do not show up in the task bar.
		/// </remarks>
		/// <docgen category="Form Options" order="10" />
		// Token: 0x1700020C RID: 524
		// (get) Token: 0x060009B8 RID: 2488 RVA: 0x0002279C File Offset: 0x0002099C
		// (set) Token: 0x060009B9 RID: 2489 RVA: 0x000227B3 File Offset: 0x000209B3
		[DefaultValue(true)]
		public bool ToolWindow { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether the created form will be initially minimized.
		/// </summary>
		/// <remarks>
		/// This parameter is ignored when logging to existing form control.
		/// </remarks>
		/// <docgen category="Form Options" order="10" />
		// Token: 0x1700020D RID: 525
		// (get) Token: 0x060009BA RID: 2490 RVA: 0x000227BC File Offset: 0x000209BC
		// (set) Token: 0x060009BB RID: 2491 RVA: 0x000227D3 File Offset: 0x000209D3
		public bool ShowMinimized { get; set; }

		/// <summary>
		/// Gets or sets the initial width of the form with rich text box.
		/// </summary>
		/// <remarks>
		/// This parameter is ignored when logging to existing form control.
		/// </remarks>
		/// <docgen category="Form Options" order="10" />
		// Token: 0x1700020E RID: 526
		// (get) Token: 0x060009BC RID: 2492 RVA: 0x000227DC File Offset: 0x000209DC
		// (set) Token: 0x060009BD RID: 2493 RVA: 0x000227F3 File Offset: 0x000209F3
		public int Width { get; set; }

		/// <summary>
		/// Gets or sets the initial height of the form with rich text box.
		/// </summary>
		/// <remarks>
		/// This parameter is ignored when logging to existing form control.
		/// </remarks>
		/// <docgen category="Form Options" order="10" />
		// Token: 0x1700020F RID: 527
		// (get) Token: 0x060009BE RID: 2494 RVA: 0x000227FC File Offset: 0x000209FC
		// (set) Token: 0x060009BF RID: 2495 RVA: 0x00022813 File Offset: 0x00020A13
		public int Height { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether scroll bar will be moved automatically to show most recent log entries.
		/// </summary>
		/// <docgen category="Form Options" order="10" />
		// Token: 0x17000210 RID: 528
		// (get) Token: 0x060009C0 RID: 2496 RVA: 0x0002281C File Offset: 0x00020A1C
		// (set) Token: 0x060009C1 RID: 2497 RVA: 0x00022833 File Offset: 0x00020A33
		public bool AutoScroll { get; set; }

		/// <summary>
		/// Gets or sets the maximum number of lines the rich text box will store (or 0 to disable this feature).
		/// </summary>
		/// <remarks>
		/// After exceeding the maximum number, first line will be deleted. 
		/// </remarks>
		/// <docgen category="Form Options" order="10" />
		// Token: 0x17000211 RID: 529
		// (get) Token: 0x060009C2 RID: 2498 RVA: 0x0002283C File Offset: 0x00020A3C
		// (set) Token: 0x060009C3 RID: 2499 RVA: 0x00022853 File Offset: 0x00020A53
		public int MaxLines { get; set; }

		/// <summary>
		/// Gets or sets the form to log to.
		/// </summary>
		// Token: 0x17000212 RID: 530
		// (get) Token: 0x060009C4 RID: 2500 RVA: 0x0002285C File Offset: 0x00020A5C
		// (set) Token: 0x060009C5 RID: 2501 RVA: 0x00022873 File Offset: 0x00020A73
		internal Form TargetForm { get; set; }

		/// <summary>
		/// Gets or sets the rich text box to log to.
		/// </summary>
		// Token: 0x17000213 RID: 531
		// (get) Token: 0x060009C6 RID: 2502 RVA: 0x0002287C File Offset: 0x00020A7C
		// (set) Token: 0x060009C7 RID: 2503 RVA: 0x00022893 File Offset: 0x00020A93
		internal RichTextBox TargetRichTextBox { get; set; }

		// Token: 0x17000214 RID: 532
		// (get) Token: 0x060009C8 RID: 2504 RVA: 0x0002289C File Offset: 0x00020A9C
		// (set) Token: 0x060009C9 RID: 2505 RVA: 0x000228B3 File Offset: 0x00020AB3
		internal bool CreatedForm { get; set; }

		/// <summary>
		/// Initializes the target. Can be used by inheriting classes
		/// to initialize logging.
		/// </summary>
		// Token: 0x060009CA RID: 2506 RVA: 0x000228BC File Offset: 0x00020ABC
		protected override void InitializeTarget()
		{
			if (this.FormName == null)
			{
				this.FormName = "NLogForm" + Guid.NewGuid().ToString("N");
			}
			Form form = Application.OpenForms[this.FormName];
			if (form != null)
			{
				this.TargetForm = form;
				if (string.IsNullOrEmpty(this.ControlName))
				{
					throw new NLogConfigurationException("Rich text box control name must be specified for " + base.GetType().Name + ".");
				}
				this.CreatedForm = false;
				this.TargetRichTextBox = FormHelper.FindControl<RichTextBox>(this.ControlName, this.TargetForm);
				if (this.TargetRichTextBox == null)
				{
					throw new NLogConfigurationException(string.Concat(new string[] { "Rich text box control '", this.ControlName, "' cannot be found on form '", this.FormName, "'." }));
				}
			}
			else
			{
				this.TargetForm = FormHelper.CreateForm(this.FormName, this.Width, this.Height, true, this.ShowMinimized, this.ToolWindow);
				this.TargetRichTextBox = FormHelper.CreateRichTextBox(this.ControlName, this.TargetForm);
				this.CreatedForm = true;
			}
		}

		/// <summary>
		/// Closes the target and releases any unmanaged resources.
		/// </summary>
		// Token: 0x060009CB RID: 2507 RVA: 0x00022A18 File Offset: 0x00020C18
		protected override void CloseTarget()
		{
			if (this.CreatedForm)
			{
				this.TargetForm.BeginInvoke(new RichTextBoxTarget.FormCloseDelegate(this.TargetForm.Close));
				this.TargetForm = null;
			}
		}

		/// <summary>
		/// Log message to RichTextBox.
		/// </summary>
		/// <param name="logEvent">The logging event.</param>
		// Token: 0x060009CC RID: 2508 RVA: 0x00022A5C File Offset: 0x00020C5C
		protected override void Write(LogEventInfo logEvent)
		{
			RichTextBoxRowColoringRule richTextBoxRowColoringRule = null;
			foreach (RichTextBoxRowColoringRule richTextBoxRowColoringRule2 in this.RowColoringRules)
			{
				if (richTextBoxRowColoringRule2.CheckCondition(logEvent))
				{
					richTextBoxRowColoringRule = richTextBoxRowColoringRule2;
					break;
				}
			}
			if (this.UseDefaultRowColoringRules && richTextBoxRowColoringRule == null)
			{
				foreach (RichTextBoxRowColoringRule richTextBoxRowColoringRule2 in RichTextBoxTarget.DefaultRowColoringRules)
				{
					if (richTextBoxRowColoringRule2.CheckCondition(logEvent))
					{
						richTextBoxRowColoringRule = richTextBoxRowColoringRule2;
						break;
					}
				}
			}
			if (richTextBoxRowColoringRule == null)
			{
				richTextBoxRowColoringRule = RichTextBoxRowColoringRule.Default;
			}
			string text = this.Layout.Render(logEvent);
			this.TargetRichTextBox.BeginInvoke(new RichTextBoxTarget.DelSendTheMessageToRichTextBox(this.SendTheMessageToRichTextBox), new object[] { text, richTextBoxRowColoringRule });
		}

		// Token: 0x060009CD RID: 2509 RVA: 0x00022B8C File Offset: 0x00020D8C
		private static Color GetColorFromString(string color, Color defaultColor)
		{
			Color color2;
			if (color == "Empty")
			{
				color2 = defaultColor;
			}
			else
			{
				color2 = Color.FromName(color);
			}
			return color2;
		}

		// Token: 0x060009CE RID: 2510 RVA: 0x00022BBC File Offset: 0x00020DBC
		private void SendTheMessageToRichTextBox(string logMessage, RichTextBoxRowColoringRule rule)
		{
			RichTextBox targetRichTextBox = this.TargetRichTextBox;
			int length = targetRichTextBox.Text.Length;
			targetRichTextBox.SelectionStart = length;
			targetRichTextBox.SelectionBackColor = RichTextBoxTarget.GetColorFromString(rule.BackgroundColor, targetRichTextBox.BackColor);
			targetRichTextBox.SelectionColor = RichTextBoxTarget.GetColorFromString(rule.FontColor, targetRichTextBox.ForeColor);
			targetRichTextBox.SelectionFont = new Font(targetRichTextBox.SelectionFont, targetRichTextBox.SelectionFont.Style ^ rule.Style);
			targetRichTextBox.AppendText(logMessage + "\n");
			targetRichTextBox.SelectionLength = targetRichTextBox.Text.Length - targetRichTextBox.SelectionStart;
			foreach (RichTextBoxWordColoringRule richTextBoxWordColoringRule in this.WordColoringRules)
			{
				MatchCollection matchCollection = richTextBoxWordColoringRule.CompiledRegex.Matches(targetRichTextBox.Text, length);
				foreach (object obj in matchCollection)
				{
					Match match = (Match)obj;
					targetRichTextBox.SelectionStart = match.Index;
					targetRichTextBox.SelectionLength = match.Length;
					targetRichTextBox.SelectionBackColor = RichTextBoxTarget.GetColorFromString(richTextBoxWordColoringRule.BackgroundColor, targetRichTextBox.BackColor);
					targetRichTextBox.SelectionColor = RichTextBoxTarget.GetColorFromString(richTextBoxWordColoringRule.FontColor, targetRichTextBox.ForeColor);
					targetRichTextBox.SelectionFont = new Font(targetRichTextBox.SelectionFont, targetRichTextBox.SelectionFont.Style ^ richTextBoxWordColoringRule.Style);
				}
			}
			if (this.MaxLines > 0)
			{
				this.lineCount++;
				if (this.lineCount > this.MaxLines)
				{
					int firstCharIndexFromLine = targetRichTextBox.GetFirstCharIndexFromLine(1);
					targetRichTextBox.Select(0, firstCharIndexFromLine);
					targetRichTextBox.SelectedText = string.Empty;
					this.lineCount--;
				}
			}
			if (this.AutoScroll)
			{
				targetRichTextBox.Select(targetRichTextBox.TextLength, 0);
				targetRichTextBox.ScrollToCaret();
			}
		}

		// Token: 0x04000305 RID: 773
		private int lineCount;

		// Token: 0x02000125 RID: 293
		// (Invoke) Token: 0x060009D0 RID: 2512
		private delegate void DelSendTheMessageToRichTextBox(string logMessage, RichTextBoxRowColoringRule rule);

		// Token: 0x02000126 RID: 294
		// (Invoke) Token: 0x060009D4 RID: 2516
		private delegate void FormCloseDelegate();
	}
}
