using System;
using System.Diagnostics.CodeAnalysis;
using NLog.Targets;

namespace NLog.Config
{
	/// <summary>
	/// Provides simple programmatic configuration API used for trivial logging cases.
	/// </summary>
	// Token: 0x02000039 RID: 57
	public static class SimpleConfigurator
	{
		/// <summary>
		/// Configures NLog for console logging so that all messages above and including
		/// the <see cref="F:NLog.LogLevel.Info" /> level are output to the console.
		/// </summary>
		// Token: 0x0600018D RID: 397 RVA: 0x000074EE File Offset: 0x000056EE
		public static void ConfigureForConsoleLogging()
		{
			SimpleConfigurator.ConfigureForConsoleLogging(LogLevel.Info);
		}

		/// <summary>
		/// Configures NLog for console logging so that all messages above and including
		/// the specified level are output to the console.
		/// </summary>
		/// <param name="minLevel">The minimal logging level.</param>
		// Token: 0x0600018E RID: 398 RVA: 0x000074FC File Offset: 0x000056FC
		[SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "Target is disposed elsewhere.")]
		public static void ConfigureForConsoleLogging(LogLevel minLevel)
		{
			ConsoleTarget consoleTarget = new ConsoleTarget();
			LoggingConfiguration loggingConfiguration = new LoggingConfiguration();
			LoggingRule loggingRule = new LoggingRule("*", minLevel, consoleTarget);
			loggingConfiguration.LoggingRules.Add(loggingRule);
			LogManager.Configuration = loggingConfiguration;
		}

		/// <summary>
		/// Configures NLog for to log to the specified target so that all messages 
		/// above and including the <see cref="F:NLog.LogLevel.Info" /> level are output.
		/// </summary>
		/// <param name="target">The target to log all messages to.</param>
		// Token: 0x0600018F RID: 399 RVA: 0x00007537 File Offset: 0x00005737
		public static void ConfigureForTargetLogging(Target target)
		{
			SimpleConfigurator.ConfigureForTargetLogging(target, LogLevel.Info);
		}

		/// <summary>
		/// Configures NLog for to log to the specified target so that all messages 
		/// above and including the specified level are output.
		/// </summary>
		/// <param name="target">The target to log all messages to.</param>
		/// <param name="minLevel">The minimal logging level.</param>
		// Token: 0x06000190 RID: 400 RVA: 0x00007548 File Offset: 0x00005748
		public static void ConfigureForTargetLogging(Target target, LogLevel minLevel)
		{
			LoggingConfiguration loggingConfiguration = new LoggingConfiguration();
			LoggingRule loggingRule = new LoggingRule("*", minLevel, target);
			loggingConfiguration.LoggingRules.Add(loggingRule);
			LogManager.Configuration = loggingConfiguration;
		}

		/// <summary>
		/// Configures NLog for file logging so that all messages above and including
		/// the <see cref="F:NLog.LogLevel.Info" /> level are written to the specified file.
		/// </summary>
		/// <param name="fileName">Log file name.</param>
		// Token: 0x06000191 RID: 401 RVA: 0x0000757D File Offset: 0x0000577D
		public static void ConfigureForFileLogging(string fileName)
		{
			SimpleConfigurator.ConfigureForFileLogging(fileName, LogLevel.Info);
		}

		/// <summary>
		/// Configures NLog for file logging so that all messages above and including
		/// the specified level are written to the specified file.
		/// </summary>
		/// <param name="fileName">Log file name.</param>
		/// <param name="minLevel">The minimal logging level.</param>
		// Token: 0x06000192 RID: 402 RVA: 0x0000758C File Offset: 0x0000578C
		[SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "Target is disposed elsewhere.")]
		public static void ConfigureForFileLogging(string fileName, LogLevel minLevel)
		{
			SimpleConfigurator.ConfigureForTargetLogging(new FileTarget
			{
				FileName = fileName
			}, minLevel);
		}
	}
}
