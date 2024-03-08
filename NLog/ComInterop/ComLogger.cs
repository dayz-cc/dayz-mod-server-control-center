using System;
using System.Runtime.InteropServices;

namespace NLog.ComInterop
{
	/// <summary>
	/// NLog COM Interop logger implementation.
	/// </summary>
	// Token: 0x02000003 RID: 3
	[ClassInterface(ClassInterfaceType.None)]
	[ComVisible(true)]
	[ProgId("NLog.Logger")]
	[Guid("181f39a8-41a8-4e35-91b6-5f8d96f5e61c")]
	public class ComLogger : IComLogger
	{
		/// <summary>
		/// Gets a value indicating whether the Trace level is enabled.
		/// </summary>
		/// <value></value>
		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000011 RID: 17 RVA: 0x000020D0 File Offset: 0x000002D0
		public bool IsTraceEnabled
		{
			get
			{
				return this.logger.IsTraceEnabled;
			}
		}

		/// <summary>
		/// Gets a value indicating whether the Debug level is enabled.
		/// </summary>
		/// <value></value>
		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000012 RID: 18 RVA: 0x000020F0 File Offset: 0x000002F0
		public bool IsDebugEnabled
		{
			get
			{
				return this.logger.IsDebugEnabled;
			}
		}

		/// <summary>
		/// Gets a value indicating whether the Info level is enabled.
		/// </summary>
		/// <value></value>
		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000013 RID: 19 RVA: 0x00002110 File Offset: 0x00000310
		public bool IsInfoEnabled
		{
			get
			{
				return this.logger.IsInfoEnabled;
			}
		}

		/// <summary>
		/// Gets a value indicating whether the Warn level is enabled.
		/// </summary>
		/// <value></value>
		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000014 RID: 20 RVA: 0x00002130 File Offset: 0x00000330
		public bool IsWarnEnabled
		{
			get
			{
				return this.logger.IsWarnEnabled;
			}
		}

		/// <summary>
		/// Gets a value indicating whether the Error level is enabled.
		/// </summary>
		/// <value></value>
		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000015 RID: 21 RVA: 0x00002150 File Offset: 0x00000350
		public bool IsErrorEnabled
		{
			get
			{
				return this.logger.IsErrorEnabled;
			}
		}

		/// <summary>
		/// Gets a value indicating whether the Fatal level is enabled.
		/// </summary>
		/// <value></value>
		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000016 RID: 22 RVA: 0x00002170 File Offset: 0x00000370
		public bool IsFatalEnabled
		{
			get
			{
				return this.logger.IsFatalEnabled;
			}
		}

		/// <summary>
		/// Gets or sets the logger name.
		/// </summary>
		/// <value></value>
		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000017 RID: 23 RVA: 0x00002190 File Offset: 0x00000390
		// (set) Token: 0x06000018 RID: 24 RVA: 0x000021A8 File Offset: 0x000003A8
		public string LoggerName
		{
			get
			{
				return this.loggerName;
			}
			set
			{
				this.loggerName = value;
				this.logger = LogManager.GetLogger(value);
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the specified level.
		/// </summary>
		/// <param name="level">The log level.</param>
		/// <param name="message">A <see langword="string" /> to be written.</param>
		// Token: 0x06000019 RID: 25 RVA: 0x000021BE File Offset: 0x000003BE
		public void Log(string level, string message)
		{
			this.logger.Log(LogLevel.FromString(level), message);
		}

		/// <summary>
		/// Writes the diagnostic message at the Trace level.
		/// </summary>
		/// <param name="message">A <see langword="string" /> to be written.</param>
		// Token: 0x0600001A RID: 26 RVA: 0x000021D4 File Offset: 0x000003D4
		public void Trace(string message)
		{
			this.logger.Trace(message);
		}

		/// <summary>
		/// Writes the diagnostic message at the Debug level.
		/// </summary>
		/// <param name="message">A <see langword="string" /> to be written.</param>
		// Token: 0x0600001B RID: 27 RVA: 0x000021E4 File Offset: 0x000003E4
		public void Debug(string message)
		{
			this.logger.Debug(message);
		}

		/// <summary>
		/// Writes the diagnostic message at the Info level.
		/// </summary>
		/// <param name="message">A <see langword="string" /> to be written.</param>
		// Token: 0x0600001C RID: 28 RVA: 0x000021F4 File Offset: 0x000003F4
		public void Info(string message)
		{
			this.logger.Info(message);
		}

		/// <summary>
		/// Writes the diagnostic message at the Warn level.
		/// </summary>
		/// <param name="message">A <see langword="string" /> to be written.</param>
		// Token: 0x0600001D RID: 29 RVA: 0x00002204 File Offset: 0x00000404
		public void Warn(string message)
		{
			this.logger.Warn(message);
		}

		/// <summary>
		/// Writes the diagnostic message at the Error level.
		/// </summary>
		/// <param name="message">A <see langword="string" /> to be written.</param>
		// Token: 0x0600001E RID: 30 RVA: 0x00002214 File Offset: 0x00000414
		public void Error(string message)
		{
			this.logger.Error(message);
		}

		/// <summary>
		/// Writes the diagnostic message at the Fatal level.
		/// </summary>
		/// <param name="message">A <see langword="string" /> to be written.</param>
		// Token: 0x0600001F RID: 31 RVA: 0x00002224 File Offset: 0x00000424
		public void Fatal(string message)
		{
			this.logger.Fatal(message);
		}

		/// <summary>
		/// Checks if the specified log level is enabled.
		/// </summary>
		/// <param name="level">The log level.</param>
		/// <returns>
		/// A value indicating whether the specified log level is enabled.
		/// </returns>
		// Token: 0x06000020 RID: 32 RVA: 0x00002234 File Offset: 0x00000434
		public bool IsEnabled(string level)
		{
			return this.logger.IsEnabled(LogLevel.FromString(level));
		}

		// Token: 0x04000001 RID: 1
		private static readonly Logger DefaultLogger = LogManager.CreateNullLogger();

		// Token: 0x04000002 RID: 2
		private Logger logger = ComLogger.DefaultLogger;

		// Token: 0x04000003 RID: 3
		private string loggerName = string.Empty;
	}
}
