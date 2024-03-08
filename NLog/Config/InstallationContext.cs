using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;

namespace NLog.Config
{
	/// <summary>
	/// Provides context for install/uninstall operations.
	/// </summary>
	// Token: 0x0200002F RID: 47
	public sealed class InstallationContext : IDisposable
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Config.InstallationContext" /> class.
		/// </summary>
		// Token: 0x0600012C RID: 300 RVA: 0x00005D4D File Offset: 0x00003F4D
		public InstallationContext()
			: this(TextWriter.Null)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Config.InstallationContext" /> class.
		/// </summary>
		/// <param name="logOutput">The log output.</param>
		// Token: 0x0600012D RID: 301 RVA: 0x00005D5D File Offset: 0x00003F5D
		public InstallationContext(TextWriter logOutput)
		{
			this.LogOutput = logOutput;
			this.Parameters = new Dictionary<string, string>();
			this.LogLevel = LogLevel.Info;
		}

		/// <summary>
		/// Gets or sets the installation log level.
		/// </summary>
		// Token: 0x17000040 RID: 64
		// (get) Token: 0x0600012E RID: 302 RVA: 0x00005D88 File Offset: 0x00003F88
		// (set) Token: 0x0600012F RID: 303 RVA: 0x00005D9F File Offset: 0x00003F9F
		public LogLevel LogLevel { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether to ignore failures during installation.
		/// </summary>
		// Token: 0x17000041 RID: 65
		// (get) Token: 0x06000130 RID: 304 RVA: 0x00005DA8 File Offset: 0x00003FA8
		// (set) Token: 0x06000131 RID: 305 RVA: 0x00005DBF File Offset: 0x00003FBF
		public bool IgnoreFailures { get; set; }

		/// <summary>
		/// Gets the installation parameters.
		/// </summary>
		// Token: 0x17000042 RID: 66
		// (get) Token: 0x06000132 RID: 306 RVA: 0x00005DC8 File Offset: 0x00003FC8
		// (set) Token: 0x06000133 RID: 307 RVA: 0x00005DDF File Offset: 0x00003FDF
		public IDictionary<string, string> Parameters { get; private set; }

		/// <summary>
		/// Gets or sets the log output.
		/// </summary>
		// Token: 0x17000043 RID: 67
		// (get) Token: 0x06000134 RID: 308 RVA: 0x00005DE8 File Offset: 0x00003FE8
		// (set) Token: 0x06000135 RID: 309 RVA: 0x00005DFF File Offset: 0x00003FFF
		public TextWriter LogOutput { get; set; }

		/// <summary>
		/// Logs the specified trace message.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="arguments">The arguments.</param>
		// Token: 0x06000136 RID: 310 RVA: 0x00005E08 File Offset: 0x00004008
		public void Trace([Localizable(false)] string message, params object[] arguments)
		{
			this.Log(LogLevel.Trace, message, arguments);
		}

		/// <summary>
		/// Logs the specified debug message.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="arguments">The arguments.</param>
		// Token: 0x06000137 RID: 311 RVA: 0x00005E19 File Offset: 0x00004019
		public void Debug([Localizable(false)] string message, params object[] arguments)
		{
			this.Log(LogLevel.Debug, message, arguments);
		}

		/// <summary>
		/// Logs the specified informational message.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="arguments">The arguments.</param>
		// Token: 0x06000138 RID: 312 RVA: 0x00005E2A File Offset: 0x0000402A
		public void Info([Localizable(false)] string message, params object[] arguments)
		{
			this.Log(LogLevel.Info, message, arguments);
		}

		/// <summary>
		/// Logs the specified warning message.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="arguments">The arguments.</param>
		// Token: 0x06000139 RID: 313 RVA: 0x00005E3B File Offset: 0x0000403B
		public void Warning([Localizable(false)] string message, params object[] arguments)
		{
			this.Log(LogLevel.Warn, message, arguments);
		}

		/// <summary>
		/// Logs the specified error message.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="arguments">The arguments.</param>
		// Token: 0x0600013A RID: 314 RVA: 0x00005E4C File Offset: 0x0000404C
		public void Error([Localizable(false)] string message, params object[] arguments)
		{
			this.Log(LogLevel.Error, message, arguments);
		}

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		// Token: 0x0600013B RID: 315 RVA: 0x00005E60 File Offset: 0x00004060
		public void Dispose()
		{
			if (this.LogOutput != null)
			{
				this.LogOutput.Close();
				this.LogOutput = null;
			}
		}

		/// <summary>
		/// Creates the log event which can be used to render layouts during installation/uninstallations.
		/// </summary>
		/// <returns>Log event info object.</returns>
		// Token: 0x0600013C RID: 316 RVA: 0x00005E94 File Offset: 0x00004094
		public LogEventInfo CreateLogEvent()
		{
			LogEventInfo logEventInfo = LogEventInfo.CreateNullEvent();
			foreach (KeyValuePair<string, string> keyValuePair in this.Parameters)
			{
				logEventInfo.Properties.Add(keyValuePair.Key, keyValuePair.Value);
			}
			return logEventInfo;
		}

		// Token: 0x0600013D RID: 317 RVA: 0x00005F10 File Offset: 0x00004110
		private void Log(LogLevel logLevel, [Localizable(false)] string message, object[] arguments)
		{
			if (logLevel >= this.LogLevel)
			{
				if (arguments != null && arguments.Length > 0)
				{
					message = string.Format(CultureInfo.InvariantCulture, message, arguments);
				}
				ConsoleColor foregroundColor = Console.ForegroundColor;
				Console.ForegroundColor = InstallationContext.logLevel2ConsoleColor[logLevel];
				try
				{
					this.LogOutput.WriteLine(message);
				}
				finally
				{
					Console.ForegroundColor = foregroundColor;
				}
			}
		}

		/// <summary>
		/// Mapping between log levels and console output colors.
		/// </summary>
		// Token: 0x04000061 RID: 97
		private static readonly Dictionary<LogLevel, ConsoleColor> logLevel2ConsoleColor = new Dictionary<LogLevel, ConsoleColor>
		{
			{
				LogLevel.Trace,
				ConsoleColor.DarkGray
			},
			{
				LogLevel.Debug,
				ConsoleColor.Gray
			},
			{
				LogLevel.Info,
				ConsoleColor.White
			},
			{
				LogLevel.Warn,
				ConsoleColor.Yellow
			},
			{
				LogLevel.Error,
				ConsoleColor.Red
			},
			{
				LogLevel.Fatal,
				ConsoleColor.DarkRed
			}
		};
	}
}
