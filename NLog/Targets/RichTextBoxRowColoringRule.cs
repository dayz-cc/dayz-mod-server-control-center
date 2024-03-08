using System;
using System.ComponentModel;
using System.Drawing;
using NLog.Conditions;
using NLog.Config;

namespace NLog.Targets
{
	/// <summary>
	/// The row-coloring condition.
	/// </summary>
	// Token: 0x02000123 RID: 291
	[NLogConfigurationItem]
	public class RichTextBoxRowColoringRule
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Targets.RichTextBoxRowColoringRule" /> class.
		/// </summary>
		// Token: 0x0600099C RID: 2460 RVA: 0x000224A6 File Offset: 0x000206A6
		public RichTextBoxRowColoringRule()
			: this(null, "Empty", "Empty", FontStyle.Regular)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Targets.RichTextBoxRowColoringRule" /> class.
		/// </summary>
		/// <param name="condition">The condition.</param>
		/// <param name="fontColor">Color of the foregroung text.</param>
		/// <param name="backColor">Color of the background text.</param>
		/// <param name="fontStyle">The font style.</param>
		// Token: 0x0600099D RID: 2461 RVA: 0x000224BD File Offset: 0x000206BD
		public RichTextBoxRowColoringRule(string condition, string fontColor, string backColor, FontStyle fontStyle)
		{
			this.Condition = condition;
			this.FontColor = fontColor;
			this.BackgroundColor = backColor;
			this.Style = fontStyle;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Targets.RichTextBoxRowColoringRule" /> class.
		/// </summary>
		/// <param name="condition">The condition.</param>
		/// <param name="fontColor">Color of the text.</param>
		/// <param name="backColor">Color of the background.</param>
		// Token: 0x0600099E RID: 2462 RVA: 0x000224EE File Offset: 0x000206EE
		public RichTextBoxRowColoringRule(string condition, string fontColor, string backColor)
		{
			this.Condition = condition;
			this.FontColor = fontColor;
			this.BackgroundColor = backColor;
			this.Style = FontStyle.Regular;
		}

		/// <summary>
		/// Gets the default highlighting rule. Doesn't change the color.
		/// </summary>
		/// <docgen category="Rule Matching Options" order="10" />
		// Token: 0x17000201 RID: 513
		// (get) Token: 0x0600099F RID: 2463 RVA: 0x00022520 File Offset: 0x00020720
		// (set) Token: 0x060009A0 RID: 2464 RVA: 0x00022536 File Offset: 0x00020736
		public static RichTextBoxRowColoringRule Default { get; private set; } = new RichTextBoxRowColoringRule();

		/// <summary>
		/// Gets or sets the condition that must be met in order to set the specified font color.
		/// </summary>
		/// <docgen category="Rule Matching Options" order="10" />
		// Token: 0x17000202 RID: 514
		// (get) Token: 0x060009A1 RID: 2465 RVA: 0x00022540 File Offset: 0x00020740
		// (set) Token: 0x060009A2 RID: 2466 RVA: 0x00022557 File Offset: 0x00020757
		[RequiredParameter]
		public ConditionExpression Condition { get; set; }

		/// <summary>
		/// Gets or sets the font color.
		/// </summary>
		/// <remarks>
		/// Names are identical with KnownColor enum extended with Empty value which means that background color won't be changed.
		/// </remarks>
		/// <docgen category="Formatting Options" order="10" />
		// Token: 0x17000203 RID: 515
		// (get) Token: 0x060009A3 RID: 2467 RVA: 0x00022560 File Offset: 0x00020760
		// (set) Token: 0x060009A4 RID: 2468 RVA: 0x00022577 File Offset: 0x00020777
		[DefaultValue("Empty")]
		public string FontColor { get; set; }

		/// <summary>
		/// Gets or sets the background color.
		/// </summary>
		/// <remarks>
		/// Names are identical with KnownColor enum extended with Empty value which means that background color won't be changed.
		/// </remarks>
		/// <docgen category="Formatting Options" order="10" />
		// Token: 0x17000204 RID: 516
		// (get) Token: 0x060009A5 RID: 2469 RVA: 0x00022580 File Offset: 0x00020780
		// (set) Token: 0x060009A6 RID: 2470 RVA: 0x00022597 File Offset: 0x00020797
		[DefaultValue("Empty")]
		public string BackgroundColor { get; set; }

		/// <summary>
		/// Gets or sets the font style of matched text. 
		/// </summary>
		/// <remarks>
		/// Possible values are the same as in <c>FontStyle</c> enum in <c>System.Drawing</c>
		/// </remarks>
		/// <docgen category="Formatting Options" order="10" />
		// Token: 0x17000205 RID: 517
		// (get) Token: 0x060009A7 RID: 2471 RVA: 0x000225A0 File Offset: 0x000207A0
		// (set) Token: 0x060009A8 RID: 2472 RVA: 0x000225B7 File Offset: 0x000207B7
		public FontStyle Style { get; set; }

		/// <summary>
		/// Checks whether the specified log event matches the condition (if any).
		/// </summary>
		/// <param name="logEvent">
		/// Log event.
		/// </param>
		/// <returns>
		/// A value of <see langword="true" /> if the condition is not defined or 
		/// if it matches, <see langword="false" /> otherwise.
		/// </returns>
		// Token: 0x060009A9 RID: 2473 RVA: 0x000225C0 File Offset: 0x000207C0
		public bool CheckCondition(LogEventInfo logEvent)
		{
			return true.Equals(this.Condition.Evaluate(logEvent));
		}
	}
}
