using System;
using System.ComponentModel;
using NLog.Conditions;
using NLog.Config;

namespace NLog.Targets
{
	/// <summary>
	/// The row-highlighting condition.
	/// </summary>
	// Token: 0x02000108 RID: 264
	[NLogConfigurationItem]
	public class ConsoleRowHighlightingRule
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Targets.ConsoleRowHighlightingRule" /> class.
		/// </summary>
		// Token: 0x06000827 RID: 2087 RVA: 0x0001D093 File Offset: 0x0001B293
		public ConsoleRowHighlightingRule()
			: this(null, ConsoleOutputColor.NoChange, ConsoleOutputColor.NoChange)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Targets.ConsoleRowHighlightingRule" /> class.
		/// </summary>
		/// <param name="condition">The condition.</param>
		/// <param name="foregroundColor">Color of the foreground.</param>
		/// <param name="backgroundColor">Color of the background.</param>
		// Token: 0x06000828 RID: 2088 RVA: 0x0001D0A3 File Offset: 0x0001B2A3
		public ConsoleRowHighlightingRule(ConditionExpression condition, ConsoleOutputColor foregroundColor, ConsoleOutputColor backgroundColor)
		{
			this.Condition = condition;
			this.ForegroundColor = foregroundColor;
			this.BackgroundColor = backgroundColor;
		}

		/// <summary>
		/// Gets the default highlighting rule. Doesn't change the color.
		/// </summary>
		// Token: 0x1700018B RID: 395
		// (get) Token: 0x06000829 RID: 2089 RVA: 0x0001D0C8 File Offset: 0x0001B2C8
		// (set) Token: 0x0600082A RID: 2090 RVA: 0x0001D0DE File Offset: 0x0001B2DE
		public static ConsoleRowHighlightingRule Default { get; private set; } = new ConsoleRowHighlightingRule(null, ConsoleOutputColor.NoChange, ConsoleOutputColor.NoChange);

		/// <summary>
		/// Gets or sets the condition that must be met in order to set the specified foreground and background color.
		/// </summary>
		/// <docgen category="Rule Matching Options" order="10" />
		// Token: 0x1700018C RID: 396
		// (get) Token: 0x0600082B RID: 2091 RVA: 0x0001D0E8 File Offset: 0x0001B2E8
		// (set) Token: 0x0600082C RID: 2092 RVA: 0x0001D0FF File Offset: 0x0001B2FF
		[RequiredParameter]
		public ConditionExpression Condition { get; set; }

		/// <summary>
		/// Gets or sets the foreground color.
		/// </summary>
		/// <docgen category="Formatting Options" order="10" />
		// Token: 0x1700018D RID: 397
		// (get) Token: 0x0600082D RID: 2093 RVA: 0x0001D108 File Offset: 0x0001B308
		// (set) Token: 0x0600082E RID: 2094 RVA: 0x0001D11F File Offset: 0x0001B31F
		[DefaultValue("NoChange")]
		public ConsoleOutputColor ForegroundColor { get; set; }

		/// <summary>
		/// Gets or sets the background color.
		/// </summary>
		/// <docgen category="Formatting Options" order="10" />
		// Token: 0x1700018E RID: 398
		// (get) Token: 0x0600082F RID: 2095 RVA: 0x0001D128 File Offset: 0x0001B328
		// (set) Token: 0x06000830 RID: 2096 RVA: 0x0001D13F File Offset: 0x0001B33F
		[DefaultValue("NoChange")]
		public ConsoleOutputColor BackgroundColor { get; set; }

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
		// Token: 0x06000831 RID: 2097 RVA: 0x0001D148 File Offset: 0x0001B348
		public bool CheckCondition(LogEventInfo logEvent)
		{
			return this.Condition == null || true.Equals(this.Condition.Evaluate(logEvent));
		}
	}
}
