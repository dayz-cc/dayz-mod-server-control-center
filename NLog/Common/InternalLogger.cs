using System;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Text;
using NLog.Internal;
using NLog.Time;

namespace NLog.Common
{
	/// <summary>
	/// NLog internal logger.
	/// </summary>
	// Token: 0x0200000B RID: 11
	public static class InternalLogger
	{
		/// <summary>
		/// Initializes static members of the InternalLogger class.
		/// </summary>
		// Token: 0x06000053 RID: 83 RVA: 0x00002B88 File Offset: 0x00000D88
		[SuppressMessage("Microsoft.Performance", "CA1810:InitializeReferenceTypeStaticFieldsInline", Justification = "Significant logic in .cctor()")]
		static InternalLogger()
		{
			InternalLogger.Info("NLog internal logger initialized.");
			InternalLogger.IncludeTimestamp = true;
		}

		/// <summary>
		/// Gets or sets the internal log level.
		/// </summary>
		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000054 RID: 84 RVA: 0x00002C14 File Offset: 0x00000E14
		// (set) Token: 0x06000055 RID: 85 RVA: 0x00002C2A File Offset: 0x00000E2A
		public static LogLevel LogLevel { get; set; } = InternalLogger.GetSetting("nlog.internalLogLevel", "NLOG_INTERNAL_LOG_LEVEL", LogLevel.Info);

		/// <summary>
		/// Gets or sets a value indicating whether internal messages should be written to the console output stream.
		/// </summary>
		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000056 RID: 86 RVA: 0x00002C34 File Offset: 0x00000E34
		// (set) Token: 0x06000057 RID: 87 RVA: 0x00002C4A File Offset: 0x00000E4A
		public static bool LogToConsole { get; set; } = InternalLogger.GetSetting<bool>("nlog.internalLogToConsole", "NLOG_INTERNAL_LOG_TO_CONSOLE", false);

		/// <summary>
		/// Gets or sets a value indicating whether internal messages should be written to the console error stream.
		/// </summary>
		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000058 RID: 88 RVA: 0x00002C54 File Offset: 0x00000E54
		// (set) Token: 0x06000059 RID: 89 RVA: 0x00002C6A File Offset: 0x00000E6A
		public static bool LogToConsoleError { get; set; } = InternalLogger.GetSetting<bool>("nlog.internalLogToConsoleError", "NLOG_INTERNAL_LOG_TO_CONSOLE_ERROR", false);

		/// <summary>
		/// Gets or sets the name of the internal log file.
		/// </summary>
		/// <remarks>A value of <see langword="null" /> value disables internal logging to a file.</remarks>
		// Token: 0x1700001A RID: 26
		// (get) Token: 0x0600005A RID: 90 RVA: 0x00002C74 File Offset: 0x00000E74
		// (set) Token: 0x0600005B RID: 91 RVA: 0x00002C8A File Offset: 0x00000E8A
		public static string LogFile { get; set; } = InternalLogger.GetSetting<string>("nlog.internalLogFile", "NLOG_INTERNAL_LOG_FILE", string.Empty);

		/// <summary>
		/// Gets or sets the text writer that will receive internal logs.
		/// </summary>
		// Token: 0x1700001B RID: 27
		// (get) Token: 0x0600005C RID: 92 RVA: 0x00002C94 File Offset: 0x00000E94
		// (set) Token: 0x0600005D RID: 93 RVA: 0x00002CAA File Offset: 0x00000EAA
		public static TextWriter LogWriter { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether timestamp should be included in internal log output.
		/// </summary>
		// Token: 0x1700001C RID: 28
		// (get) Token: 0x0600005E RID: 94 RVA: 0x00002CB4 File Offset: 0x00000EB4
		// (set) Token: 0x0600005F RID: 95 RVA: 0x00002CCA File Offset: 0x00000ECA
		public static bool IncludeTimestamp { get; set; }

		/// <summary>
		/// Gets a value indicating whether internal log includes Trace messages.
		/// </summary>
		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000060 RID: 96 RVA: 0x00002CD4 File Offset: 0x00000ED4
		public static bool IsTraceEnabled
		{
			get
			{
				return LogLevel.Trace >= InternalLogger.LogLevel;
			}
		}

		/// <summary>
		/// Gets a value indicating whether internal log includes Debug messages.
		/// </summary>
		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000061 RID: 97 RVA: 0x00002CF8 File Offset: 0x00000EF8
		public static bool IsDebugEnabled
		{
			get
			{
				return LogLevel.Debug >= InternalLogger.LogLevel;
			}
		}

		/// <summary>
		/// Gets a value indicating whether internal log includes Info messages.
		/// </summary>
		// Token: 0x1700001F RID: 31
		// (get) Token: 0x06000062 RID: 98 RVA: 0x00002D1C File Offset: 0x00000F1C
		public static bool IsInfoEnabled
		{
			get
			{
				return LogLevel.Info >= InternalLogger.LogLevel;
			}
		}

		/// <summary>
		/// Gets a value indicating whether internal log includes Warn messages.
		/// </summary>
		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000063 RID: 99 RVA: 0x00002D40 File Offset: 0x00000F40
		public static bool IsWarnEnabled
		{
			get
			{
				return LogLevel.Warn >= InternalLogger.LogLevel;
			}
		}

		/// <summary>
		/// Gets a value indicating whether internal log includes Error messages.
		/// </summary>
		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000064 RID: 100 RVA: 0x00002D64 File Offset: 0x00000F64
		public static bool IsErrorEnabled
		{
			get
			{
				return LogLevel.Error >= InternalLogger.LogLevel;
			}
		}

		/// <summary>
		/// Gets a value indicating whether internal log includes Fatal messages.
		/// </summary>
		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000065 RID: 101 RVA: 0x00002D88 File Offset: 0x00000F88
		public static bool IsFatalEnabled
		{
			get
			{
				return LogLevel.Fatal >= InternalLogger.LogLevel;
			}
		}

		/// <summary>
		/// Logs the specified message at the specified level.
		/// </summary>
		/// <param name="level">Log level.</param>
		/// <param name="message">Message which may include positional parameters.</param>
		/// <param name="args">Arguments to the message.</param>
		// Token: 0x06000066 RID: 102 RVA: 0x00002DA9 File Offset: 0x00000FA9
		public static void Log(LogLevel level, string message, params object[] args)
		{
			InternalLogger.Write(level, message, args);
		}

		/// <summary>
		/// Logs the specified message at the specified level.
		/// </summary>
		/// <param name="level">Log level.</param>
		/// <param name="message">Log message.</param>
		// Token: 0x06000067 RID: 103 RVA: 0x00002DB5 File Offset: 0x00000FB5
		public static void Log(LogLevel level, [Localizable(false)] string message)
		{
			InternalLogger.Write(level, message, null);
		}

		/// <summary>
		/// Logs the specified message at the Trace level.
		/// </summary>
		/// <param name="message">Message which may include positional parameters.</param>
		/// <param name="args">Arguments to the message.</param>
		// Token: 0x06000068 RID: 104 RVA: 0x00002DC1 File Offset: 0x00000FC1
		public static void Trace([Localizable(false)] string message, params object[] args)
		{
			InternalLogger.Write(LogLevel.Trace, message, args);
		}

		/// <summary>
		/// Logs the specified message at the Trace level.
		/// </summary>
		/// <param name="message">Log message.</param>
		// Token: 0x06000069 RID: 105 RVA: 0x00002DD1 File Offset: 0x00000FD1
		public static void Trace([Localizable(false)] string message)
		{
			InternalLogger.Write(LogLevel.Trace, message, null);
		}

		/// <summary>
		/// Logs the specified message at the Debug level.
		/// </summary>
		/// <param name="message">Message which may include positional parameters.</param>
		/// <param name="args">Arguments to the message.</param>
		// Token: 0x0600006A RID: 106 RVA: 0x00002DE1 File Offset: 0x00000FE1
		public static void Debug([Localizable(false)] string message, params object[] args)
		{
			InternalLogger.Write(LogLevel.Debug, message, args);
		}

		/// <summary>
		/// Logs the specified message at the Debug level.
		/// </summary>
		/// <param name="message">Log message.</param>
		// Token: 0x0600006B RID: 107 RVA: 0x00002DF1 File Offset: 0x00000FF1
		public static void Debug([Localizable(false)] string message)
		{
			InternalLogger.Write(LogLevel.Debug, message, null);
		}

		/// <summary>
		/// Logs the specified message at the Info level.
		/// </summary>
		/// <param name="message">Message which may include positional parameters.</param>
		/// <param name="args">Arguments to the message.</param>
		// Token: 0x0600006C RID: 108 RVA: 0x00002E01 File Offset: 0x00001001
		public static void Info([Localizable(false)] string message, params object[] args)
		{
			InternalLogger.Write(LogLevel.Info, message, args);
		}

		/// <summary>
		/// Logs the specified message at the Info level.
		/// </summary>
		/// <param name="message">Log message.</param>
		// Token: 0x0600006D RID: 109 RVA: 0x00002E11 File Offset: 0x00001011
		public static void Info([Localizable(false)] string message)
		{
			InternalLogger.Write(LogLevel.Info, message, null);
		}

		/// <summary>
		/// Logs the specified message at the Warn level.
		/// </summary>
		/// <param name="message">Message which may include positional parameters.</param>
		/// <param name="args">Arguments to the message.</param>
		// Token: 0x0600006E RID: 110 RVA: 0x00002E21 File Offset: 0x00001021
		public static void Warn([Localizable(false)] string message, params object[] args)
		{
			InternalLogger.Write(LogLevel.Warn, message, args);
		}

		/// <summary>
		/// Logs the specified message at the Warn level.
		/// </summary>
		/// <param name="message">Log message.</param>
		// Token: 0x0600006F RID: 111 RVA: 0x00002E31 File Offset: 0x00001031
		public static void Warn([Localizable(false)] string message)
		{
			InternalLogger.Write(LogLevel.Warn, message, null);
		}

		/// <summary>
		/// Logs the specified message at the Error level.
		/// </summary>
		/// <param name="message">Message which may include positional parameters.</param>
		/// <param name="args">Arguments to the message.</param>
		// Token: 0x06000070 RID: 112 RVA: 0x00002E41 File Offset: 0x00001041
		public static void Error([Localizable(false)] string message, params object[] args)
		{
			InternalLogger.Write(LogLevel.Error, message, args);
		}

		/// <summary>
		/// Logs the specified message at the Error level.
		/// </summary>
		/// <param name="message">Log message.</param>
		// Token: 0x06000071 RID: 113 RVA: 0x00002E51 File Offset: 0x00001051
		public static void Error([Localizable(false)] string message)
		{
			InternalLogger.Write(LogLevel.Error, message, null);
		}

		/// <summary>
		/// Logs the specified message at the Fatal level.
		/// </summary>
		/// <param name="message">Message which may include positional parameters.</param>
		/// <param name="args">Arguments to the message.</param>
		// Token: 0x06000072 RID: 114 RVA: 0x00002E61 File Offset: 0x00001061
		public static void Fatal([Localizable(false)] string message, params object[] args)
		{
			InternalLogger.Write(LogLevel.Fatal, message, args);
		}

		/// <summary>
		/// Logs the specified message at the Fatal level.
		/// </summary>
		/// <param name="message">Log message.</param>
		// Token: 0x06000073 RID: 115 RVA: 0x00002E71 File Offset: 0x00001071
		public static void Fatal([Localizable(false)] string message)
		{
			InternalLogger.Write(LogLevel.Fatal, message, null);
		}

		// Token: 0x06000074 RID: 116 RVA: 0x00002E84 File Offset: 0x00001084
		private static void Write(LogLevel level, string message, object[] args)
		{
			if (!(level < InternalLogger.LogLevel))
			{
				if (!string.IsNullOrEmpty(InternalLogger.LogFile) || InternalLogger.LogToConsole || InternalLogger.LogToConsoleError || InternalLogger.LogWriter != null)
				{
					try
					{
						string text = message;
						if (args != null)
						{
							text = string.Format(CultureInfo.InvariantCulture, message, args);
						}
						StringBuilder stringBuilder = new StringBuilder(message.Length + 32);
						if (InternalLogger.IncludeTimestamp)
						{
							stringBuilder.Append(TimeSource.Current.Time.ToString("yyyy-MM-dd HH:mm:ss.ffff", CultureInfo.InvariantCulture));
							stringBuilder.Append(" ");
						}
						stringBuilder.Append(level.ToString());
						stringBuilder.Append(" ");
						stringBuilder.Append(text);
						string text2 = stringBuilder.ToString();
						string logFile = InternalLogger.LogFile;
						if (!string.IsNullOrEmpty(logFile))
						{
							using (StreamWriter streamWriter = File.AppendText(logFile))
							{
								streamWriter.WriteLine(text2);
							}
						}
						TextWriter logWriter = InternalLogger.LogWriter;
						if (logWriter != null)
						{
							lock (InternalLogger.lockObject)
							{
								logWriter.WriteLine(text2);
							}
						}
						if (InternalLogger.LogToConsole)
						{
							Console.WriteLine(text2);
						}
						if (InternalLogger.LogToConsoleError)
						{
							Console.Error.WriteLine(text2);
						}
					}
					catch (Exception ex)
					{
						if (ex.MustBeRethrown())
						{
							throw;
						}
					}
				}
			}
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00003098 File Offset: 0x00001298
		private static string GetSettingString(string configName, string envName)
		{
			string text = global::System.Configuration.ConfigurationManager.AppSettings[configName];
			if (text == null)
			{
				try
				{
					text = Environment.GetEnvironmentVariable(envName);
				}
				catch (Exception ex)
				{
					if (ex.MustBeRethrown())
					{
						throw;
					}
				}
			}
			return text;
		}

		// Token: 0x06000076 RID: 118 RVA: 0x000030F8 File Offset: 0x000012F8
		private static LogLevel GetSetting(string configName, string envName, LogLevel defaultValue)
		{
			string settingString = InternalLogger.GetSettingString(configName, envName);
			LogLevel logLevel;
			if (settingString == null)
			{
				logLevel = defaultValue;
			}
			else
			{
				try
				{
					logLevel = LogLevel.FromString(settingString);
				}
				catch (Exception ex)
				{
					if (ex.MustBeRethrown())
					{
						throw;
					}
					logLevel = defaultValue;
				}
			}
			return logLevel;
		}

		// Token: 0x06000077 RID: 119 RVA: 0x00003150 File Offset: 0x00001350
		private static T GetSetting<T>(string configName, string envName, T defaultValue)
		{
			string settingString = InternalLogger.GetSettingString(configName, envName);
			T t;
			if (settingString == null)
			{
				t = defaultValue;
			}
			else
			{
				try
				{
					t = (T)((object)Convert.ChangeType(settingString, typeof(T), CultureInfo.InvariantCulture));
				}
				catch (Exception ex)
				{
					if (ex.MustBeRethrown())
					{
						throw;
					}
					t = defaultValue;
				}
			}
			return t;
		}

		// Token: 0x04000006 RID: 6
		private static object lockObject = new object();
	}
}
