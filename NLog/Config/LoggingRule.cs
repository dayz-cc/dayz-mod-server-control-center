using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text;
using NLog.Filters;
using NLog.Targets;

namespace NLog.Config
{
	/// <summary>
	/// Represents a logging rule. An equivalent of &lt;logger /&gt; configuration element.
	/// </summary>
	// Token: 0x02000033 RID: 51
	[NLogConfigurationItem]
	public class LoggingRule
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Config.LoggingRule" /> class.
		/// </summary>
		// Token: 0x0600015E RID: 350 RVA: 0x00006958 File Offset: 0x00004B58
		public LoggingRule()
		{
			this.Filters = new List<Filter>();
			this.ChildRules = new List<LoggingRule>();
			this.Targets = new List<Target>();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Config.LoggingRule" /> class.
		/// </summary>
		/// <param name="loggerNamePattern">Logger name pattern. It may include the '*' wildcard at the beginning, at the end or at both ends.</param>
		/// <param name="minLevel">Minimum log level needed to trigger this rule.</param>
		/// <param name="target">Target to be written to when the rule matches.</param>
		// Token: 0x0600015F RID: 351 RVA: 0x000069AC File Offset: 0x00004BAC
		public LoggingRule(string loggerNamePattern, LogLevel minLevel, Target target)
		{
			this.Filters = new List<Filter>();
			this.ChildRules = new List<LoggingRule>();
			this.Targets = new List<Target>();
			this.LoggerNamePattern = loggerNamePattern;
			this.Targets.Add(target);
			for (int i = minLevel.Ordinal; i <= LogLevel.MaxLevel.Ordinal; i++)
			{
				this.EnableLoggingForLevel(LogLevel.FromOrdinal(i));
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Config.LoggingRule" /> class.
		/// </summary>
		/// <param name="loggerNamePattern">Logger name pattern. It may include the '*' wildcard at the beginning, at the end or at both ends.</param>
		/// <param name="target">Target to be written to when the rule matches.</param>
		/// <remarks>By default no logging levels are defined. You should call <see cref="M:NLog.Config.LoggingRule.EnableLoggingForLevel(NLog.LogLevel)" /> and <see cref="M:NLog.Config.LoggingRule.DisableLoggingForLevel(NLog.LogLevel)" /> to set them.</remarks>
		// Token: 0x06000160 RID: 352 RVA: 0x00006A44 File Offset: 0x00004C44
		public LoggingRule(string loggerNamePattern, Target target)
		{
			this.Filters = new List<Filter>();
			this.ChildRules = new List<LoggingRule>();
			this.Targets = new List<Target>();
			this.LoggerNamePattern = loggerNamePattern;
			this.Targets.Add(target);
		}

		/// <summary>
		/// Gets a collection of targets that should be written to when this rule matches.
		/// </summary>
		// Token: 0x1700004D RID: 77
		// (get) Token: 0x06000161 RID: 353 RVA: 0x00006AAC File Offset: 0x00004CAC
		// (set) Token: 0x06000162 RID: 354 RVA: 0x00006AC3 File Offset: 0x00004CC3
		public IList<Target> Targets { get; private set; }

		/// <summary>
		/// Gets a collection of child rules to be evaluated when this rule matches.
		/// </summary>
		// Token: 0x1700004E RID: 78
		// (get) Token: 0x06000163 RID: 355 RVA: 0x00006ACC File Offset: 0x00004CCC
		// (set) Token: 0x06000164 RID: 356 RVA: 0x00006AE3 File Offset: 0x00004CE3
		public IList<LoggingRule> ChildRules { get; private set; }

		/// <summary>
		/// Gets a collection of filters to be checked before writing to targets.
		/// </summary>
		// Token: 0x1700004F RID: 79
		// (get) Token: 0x06000165 RID: 357 RVA: 0x00006AEC File Offset: 0x00004CEC
		// (set) Token: 0x06000166 RID: 358 RVA: 0x00006B03 File Offset: 0x00004D03
		public IList<Filter> Filters { get; private set; }

		/// <summary>
		/// Gets or sets a value indicating whether to quit processing any further rule when this one matches.
		/// </summary>
		// Token: 0x17000050 RID: 80
		// (get) Token: 0x06000167 RID: 359 RVA: 0x00006B0C File Offset: 0x00004D0C
		// (set) Token: 0x06000168 RID: 360 RVA: 0x00006B23 File Offset: 0x00004D23
		public bool Final { get; set; }

		/// <summary>
		/// Gets or sets logger name pattern.
		/// </summary>
		/// <remarks>
		/// Logger name pattern. It may include the '*' wildcard at the beginning, at the end or at both ends but not anywhere else.
		/// </remarks>
		// Token: 0x17000051 RID: 81
		// (get) Token: 0x06000169 RID: 361 RVA: 0x00006B2C File Offset: 0x00004D2C
		// (set) Token: 0x0600016A RID: 362 RVA: 0x00006B44 File Offset: 0x00004D44
		public string LoggerNamePattern
		{
			get
			{
				return this.loggerNamePattern;
			}
			set
			{
				this.loggerNamePattern = value;
				int num = this.loggerNamePattern.IndexOf('*');
				int num2 = this.loggerNamePattern.LastIndexOf('*');
				if (num < 0)
				{
					this.loggerNameMatchMode = LoggingRule.MatchMode.Equals;
					this.loggerNameMatchArgument = value;
				}
				else if (num == num2)
				{
					string text = this.LoggerNamePattern.Substring(0, num);
					string text2 = this.LoggerNamePattern.Substring(num + 1);
					if (text.Length > 0)
					{
						this.loggerNameMatchMode = LoggingRule.MatchMode.StartsWith;
						this.loggerNameMatchArgument = text;
					}
					else if (text2.Length > 0)
					{
						this.loggerNameMatchMode = LoggingRule.MatchMode.EndsWith;
						this.loggerNameMatchArgument = text2;
					}
				}
				else if (num == 0 && num2 == this.LoggerNamePattern.Length - 1)
				{
					string text3 = this.LoggerNamePattern.Substring(1, this.LoggerNamePattern.Length - 2);
					this.loggerNameMatchMode = LoggingRule.MatchMode.Contains;
					this.loggerNameMatchArgument = text3;
				}
				else
				{
					this.loggerNameMatchMode = LoggingRule.MatchMode.None;
					this.loggerNameMatchArgument = string.Empty;
				}
			}
		}

		/// <summary>
		/// Gets the collection of log levels enabled by this rule.
		/// </summary>
		// Token: 0x17000052 RID: 82
		// (get) Token: 0x0600016B RID: 363 RVA: 0x00006C6C File Offset: 0x00004E6C
		public ReadOnlyCollection<LogLevel> Levels
		{
			get
			{
				List<LogLevel> list = new List<LogLevel>();
				for (int i = LogLevel.MinLevel.Ordinal; i <= LogLevel.MaxLevel.Ordinal; i++)
				{
					if (this.logLevels[i])
					{
						list.Add(LogLevel.FromOrdinal(i));
					}
				}
				return list.AsReadOnly();
			}
		}

		/// <summary>
		/// Enables logging for a particular level.
		/// </summary>
		/// <param name="level">Level to be enabled.</param>
		// Token: 0x0600016C RID: 364 RVA: 0x00006CCF File Offset: 0x00004ECF
		public void EnableLoggingForLevel(LogLevel level)
		{
			this.logLevels[level.Ordinal] = true;
		}

		/// <summary>
		/// Disables logging for a particular level.
		/// </summary>
		/// <param name="level">Level to be disabled.</param>
		// Token: 0x0600016D RID: 365 RVA: 0x00006CE0 File Offset: 0x00004EE0
		public void DisableLoggingForLevel(LogLevel level)
		{
			this.logLevels[level.Ordinal] = false;
		}

		/// <summary>
		/// Returns a string representation of <see cref="T:NLog.Config.LoggingRule" />. Used for debugging.
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.String" /> that represents the current <see cref="T:System.Object" />.
		/// </returns>
		// Token: 0x0600016E RID: 366 RVA: 0x00006CF4 File Offset: 0x00004EF4
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "logNamePattern: ({0}:{1})", new object[] { this.loggerNameMatchArgument, this.loggerNameMatchMode });
			stringBuilder.Append(" levels: [ ");
			for (int i = 0; i < this.logLevels.Length; i++)
			{
				if (this.logLevels[0])
				{
					stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "{0} ", new object[] { LogLevel.FromOrdinal(i).ToString() });
				}
			}
			stringBuilder.Append("] appendTo: [ ");
			foreach (Target target in this.Targets)
			{
				stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "{0} ", new object[] { target.Name });
			}
			stringBuilder.Append("]");
			return stringBuilder.ToString();
		}

		/// <summary>
		/// Checks whether te particular log level is enabled for this rule.
		/// </summary>
		/// <param name="level">Level to be checked.</param>
		/// <returns>A value of <see langword="true" /> when the log level is enabled, <see langword="false" /> otherwise.</returns>
		// Token: 0x0600016F RID: 367 RVA: 0x00006E38 File Offset: 0x00005038
		public bool IsLoggingEnabledForLevel(LogLevel level)
		{
			return this.logLevels[level.Ordinal];
		}

		/// <summary>
		/// Checks whether given name matches the logger name pattern.
		/// </summary>
		/// <param name="loggerName">String to be matched.</param>
		/// <returns>A value of <see langword="true" /> when the name matches, <see langword="false" /> otherwise.</returns>
		// Token: 0x06000170 RID: 368 RVA: 0x00006E58 File Offset: 0x00005058
		public bool NameMatches(string loggerName)
		{
			switch (this.loggerNameMatchMode)
			{
			case LoggingRule.MatchMode.All:
				return true;
			case LoggingRule.MatchMode.Equals:
				return loggerName.Equals(this.loggerNameMatchArgument, StringComparison.Ordinal);
			case LoggingRule.MatchMode.StartsWith:
				return loggerName.StartsWith(this.loggerNameMatchArgument, StringComparison.Ordinal);
			case LoggingRule.MatchMode.EndsWith:
				return loggerName.EndsWith(this.loggerNameMatchArgument, StringComparison.Ordinal);
			case LoggingRule.MatchMode.Contains:
				return loggerName.IndexOf(this.loggerNameMatchArgument, StringComparison.Ordinal) >= 0;
			}
			return false;
		}

		// Token: 0x0400006E RID: 110
		private readonly bool[] logLevels = new bool[LogLevel.MaxLevel.Ordinal + 1];

		// Token: 0x0400006F RID: 111
		private string loggerNamePattern;

		// Token: 0x04000070 RID: 112
		private LoggingRule.MatchMode loggerNameMatchMode;

		// Token: 0x04000071 RID: 113
		private string loggerNameMatchArgument;

		// Token: 0x02000034 RID: 52
		internal enum MatchMode
		{
			// Token: 0x04000077 RID: 119
			All,
			// Token: 0x04000078 RID: 120
			None,
			// Token: 0x04000079 RID: 121
			Equals,
			// Token: 0x0400007A RID: 122
			StartsWith,
			// Token: 0x0400007B RID: 123
			EndsWith,
			// Token: 0x0400007C RID: 124
			Contains
		}
	}
}
