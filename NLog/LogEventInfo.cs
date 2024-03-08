using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Threading;
using NLog.Common;
using NLog.Internal;
using NLog.Layouts;
using NLog.Time;

namespace NLog
{
	/// <summary>
	/// Represents the logging event.
	/// </summary>
	// Token: 0x020000E2 RID: 226
	public class LogEventInfo
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.LogEventInfo" /> class.
		/// </summary>
		// Token: 0x0600054F RID: 1359 RVA: 0x00012B94 File Offset: 0x00010D94
		public LogEventInfo()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.LogEventInfo" /> class.
		/// </summary>
		/// <param name="level">Log level.</param>
		/// <param name="loggerName">Logger name.</param>
		/// <param name="message">Log message including parameter placeholders.</param>
		// Token: 0x06000550 RID: 1360 RVA: 0x00012BAA File Offset: 0x00010DAA
		public LogEventInfo(LogLevel level, string loggerName, [Localizable(false)] string message)
			: this(level, loggerName, null, message, null, null)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.LogEventInfo" /> class.
		/// </summary>
		/// <param name="level">Log level.</param>
		/// <param name="loggerName">Logger name.</param>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">Log message including parameter placeholders.</param>
		/// <param name="parameters">Parameter array.</param>
		// Token: 0x06000551 RID: 1361 RVA: 0x00012BBB File Offset: 0x00010DBB
		public LogEventInfo(LogLevel level, string loggerName, IFormatProvider formatProvider, [Localizable(false)] string message, object[] parameters)
			: this(level, loggerName, formatProvider, message, parameters, null)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.LogEventInfo" /> class.
		/// </summary>
		/// <param name="level">Log level.</param>
		/// <param name="loggerName">Logger name.</param>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">Log message including parameter placeholders.</param>
		/// <param name="parameters">Parameter array.</param>
		/// <param name="exception">Exception information.</param>
		// Token: 0x06000552 RID: 1362 RVA: 0x00012BD0 File Offset: 0x00010DD0
		public LogEventInfo(LogLevel level, string loggerName, IFormatProvider formatProvider, [Localizable(false)] string message, object[] parameters, Exception exception)
		{
			this.TimeStamp = TimeSource.Current.Time;
			this.Level = level;
			this.LoggerName = loggerName;
			this.Message = message;
			this.Parameters = parameters;
			this.FormatProvider = formatProvider;
			this.Exception = exception;
			this.SequenceID = Interlocked.Increment(ref LogEventInfo.globalSequenceId);
			if (LogEventInfo.NeedToPreformatMessage(parameters))
			{
				this.CalcFormattedMessage();
			}
		}

		/// <summary>
		/// Gets the unique identifier of log event which is automatically generated
		/// and monotonously increasing.
		/// </summary>
		// Token: 0x1700012C RID: 300
		// (get) Token: 0x06000553 RID: 1363 RVA: 0x00012C60 File Offset: 0x00010E60
		// (set) Token: 0x06000554 RID: 1364 RVA: 0x00012C77 File Offset: 0x00010E77
		[SuppressMessage("Microsoft.Naming", "CA1709:IdentifiersShouldBeCasedCorrectly", MessageId = "ID", Justification = "Backwards compatibility")]
		public int SequenceID { get; private set; }

		/// <summary>
		/// Gets or sets the timestamp of the logging event.
		/// </summary>
		// Token: 0x1700012D RID: 301
		// (get) Token: 0x06000555 RID: 1365 RVA: 0x00012C80 File Offset: 0x00010E80
		// (set) Token: 0x06000556 RID: 1366 RVA: 0x00012C97 File Offset: 0x00010E97
		[SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "TimeStamp", Justification = "Backwards compatibility.")]
		public DateTime TimeStamp { get; set; }

		/// <summary>
		/// Gets or sets the level of the logging event.
		/// </summary>
		// Token: 0x1700012E RID: 302
		// (get) Token: 0x06000557 RID: 1367 RVA: 0x00012CA0 File Offset: 0x00010EA0
		// (set) Token: 0x06000558 RID: 1368 RVA: 0x00012CB7 File Offset: 0x00010EB7
		public LogLevel Level { get; set; }

		/// <summary>
		/// Gets a value indicating whether stack trace has been set for this event.
		/// </summary>
		// Token: 0x1700012F RID: 303
		// (get) Token: 0x06000559 RID: 1369 RVA: 0x00012CC0 File Offset: 0x00010EC0
		public bool HasStackTrace
		{
			get
			{
				return this.StackTrace != null;
			}
		}

		/// <summary>
		/// Gets the stack frame of the method that did the logging.
		/// </summary>
		// Token: 0x17000130 RID: 304
		// (get) Token: 0x0600055A RID: 1370 RVA: 0x00012CE0 File Offset: 0x00010EE0
		public StackFrame UserStackFrame
		{
			get
			{
				return (this.StackTrace != null) ? this.StackTrace.GetFrame(this.UserStackFrameNumber) : null;
			}
		}

		/// <summary>
		/// Gets the number index of the stack frame that represents the user
		/// code (not the NLog code).
		/// </summary>
		// Token: 0x17000131 RID: 305
		// (get) Token: 0x0600055B RID: 1371 RVA: 0x00012D10 File Offset: 0x00010F10
		// (set) Token: 0x0600055C RID: 1372 RVA: 0x00012D27 File Offset: 0x00010F27
		public int UserStackFrameNumber { get; private set; }

		/// <summary>
		/// Gets the entire stack trace.
		/// </summary>
		// Token: 0x17000132 RID: 306
		// (get) Token: 0x0600055D RID: 1373 RVA: 0x00012D30 File Offset: 0x00010F30
		// (set) Token: 0x0600055E RID: 1374 RVA: 0x00012D47 File Offset: 0x00010F47
		public StackTrace StackTrace { get; private set; }

		/// <summary>
		/// Gets or sets the exception information.
		/// </summary>
		// Token: 0x17000133 RID: 307
		// (get) Token: 0x0600055F RID: 1375 RVA: 0x00012D50 File Offset: 0x00010F50
		// (set) Token: 0x06000560 RID: 1376 RVA: 0x00012D67 File Offset: 0x00010F67
		public Exception Exception { get; set; }

		/// <summary>
		/// Gets or sets the logger name.
		/// </summary>
		// Token: 0x17000134 RID: 308
		// (get) Token: 0x06000561 RID: 1377 RVA: 0x00012D70 File Offset: 0x00010F70
		// (set) Token: 0x06000562 RID: 1378 RVA: 0x00012D87 File Offset: 0x00010F87
		public string LoggerName { get; set; }

		/// <summary>
		/// Gets the logger short name.
		/// </summary>
		// Token: 0x17000135 RID: 309
		// (get) Token: 0x06000563 RID: 1379 RVA: 0x00012D90 File Offset: 0x00010F90
		[Obsolete("This property should not be used.")]
		public string LoggerShortName
		{
			get
			{
				int num = this.LoggerName.LastIndexOf('.');
				string text;
				if (num >= 0)
				{
					text = this.LoggerName.Substring(num + 1);
				}
				else
				{
					text = this.LoggerName;
				}
				return text;
			}
		}

		/// <summary>
		/// Gets or sets the log message including any parameter placeholders.
		/// </summary>
		// Token: 0x17000136 RID: 310
		// (get) Token: 0x06000564 RID: 1380 RVA: 0x00012DD0 File Offset: 0x00010FD0
		// (set) Token: 0x06000565 RID: 1381 RVA: 0x00012DE7 File Offset: 0x00010FE7
		public string Message { get; set; }

		/// <summary>
		/// Gets or sets the parameter values or null if no parameters have been specified.
		/// </summary>
		// Token: 0x17000137 RID: 311
		// (get) Token: 0x06000566 RID: 1382 RVA: 0x00012DF0 File Offset: 0x00010FF0
		// (set) Token: 0x06000567 RID: 1383 RVA: 0x00012E07 File Offset: 0x00011007
		[SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays", Justification = "For backwards compatibility.")]
		public object[] Parameters { get; set; }

		/// <summary>
		/// Gets or sets the format provider that was provided while logging or <see langword="null" />
		/// when no formatProvider was specified.
		/// </summary>
		// Token: 0x17000138 RID: 312
		// (get) Token: 0x06000568 RID: 1384 RVA: 0x00012E10 File Offset: 0x00011010
		// (set) Token: 0x06000569 RID: 1385 RVA: 0x00012E27 File Offset: 0x00011027
		public IFormatProvider FormatProvider { get; set; }

		/// <summary>
		/// Gets the formatted message.
		/// </summary>
		// Token: 0x17000139 RID: 313
		// (get) Token: 0x0600056A RID: 1386 RVA: 0x00012E30 File Offset: 0x00011030
		public string FormattedMessage
		{
			get
			{
				if (this.formattedMessage == null)
				{
					this.CalcFormattedMessage();
				}
				return this.formattedMessage;
			}
		}

		/// <summary>
		/// Gets the dictionary of per-event context properties.
		/// </summary>
		// Token: 0x1700013A RID: 314
		// (get) Token: 0x0600056B RID: 1387 RVA: 0x00012E64 File Offset: 0x00011064
		public IDictionary<object, object> Properties
		{
			get
			{
				if (this.properties == null)
				{
					this.InitEventContext();
				}
				return this.properties;
			}
		}

		/// <summary>
		/// Gets the dictionary of per-event context properties.
		/// </summary>
		// Token: 0x1700013B RID: 315
		// (get) Token: 0x0600056C RID: 1388 RVA: 0x00012E98 File Offset: 0x00011098
		[Obsolete("Use LogEventInfo.Properties instead.", true)]
		public IDictionary Context
		{
			get
			{
				if (this.eventContextAdapter == null)
				{
					this.InitEventContext();
				}
				return this.eventContextAdapter;
			}
		}

		/// <summary>
		/// Creates the null event.
		/// </summary>
		/// <returns>Null log event.</returns>
		// Token: 0x0600056D RID: 1389 RVA: 0x00012ECC File Offset: 0x000110CC
		public static LogEventInfo CreateNullEvent()
		{
			return new LogEventInfo(LogLevel.Off, string.Empty, string.Empty);
		}

		/// <summary>
		/// Creates the log event.
		/// </summary>
		/// <param name="logLevel">The log level.</param>
		/// <param name="loggerName">Name of the logger.</param>
		/// <param name="message">The message.</param>
		/// <returns>Instance of <see cref="T:NLog.LogEventInfo" />.</returns>
		// Token: 0x0600056E RID: 1390 RVA: 0x00012EF4 File Offset: 0x000110F4
		public static LogEventInfo Create(LogLevel logLevel, string loggerName, [Localizable(false)] string message)
		{
			return new LogEventInfo(logLevel, loggerName, null, message, null);
		}

		/// <summary>
		/// Creates the log event.
		/// </summary>
		/// <param name="logLevel">The log level.</param>
		/// <param name="loggerName">Name of the logger.</param>
		/// <param name="formatProvider">The format provider.</param>
		/// <param name="message">The message.</param>
		/// <param name="parameters">The parameters.</param>
		/// <returns>Instance of <see cref="T:NLog.LogEventInfo" />.</returns>
		// Token: 0x0600056F RID: 1391 RVA: 0x00012F10 File Offset: 0x00011110
		public static LogEventInfo Create(LogLevel logLevel, string loggerName, IFormatProvider formatProvider, [Localizable(false)] string message, object[] parameters)
		{
			return new LogEventInfo(logLevel, loggerName, formatProvider, message, parameters);
		}

		/// <summary>
		/// Creates the log event.
		/// </summary>
		/// <param name="logLevel">The log level.</param>
		/// <param name="loggerName">Name of the logger.</param>
		/// <param name="formatProvider">The format provider.</param>
		/// <param name="message">The message.</param>
		/// <returns>Instance of <see cref="T:NLog.LogEventInfo" />.</returns>
		// Token: 0x06000570 RID: 1392 RVA: 0x00012F30 File Offset: 0x00011130
		public static LogEventInfo Create(LogLevel logLevel, string loggerName, IFormatProvider formatProvider, object message)
		{
			return new LogEventInfo(logLevel, loggerName, formatProvider, "{0}", new object[] { message });
		}

		/// <summary>
		/// Creates the log event.
		/// </summary>
		/// <param name="logLevel">The log level.</param>
		/// <param name="loggerName">Name of the logger.</param>
		/// <param name="message">The message.</param>
		/// <param name="exception">The exception.</param>
		/// <returns>Instance of <see cref="T:NLog.LogEventInfo" />.</returns>
		// Token: 0x06000571 RID: 1393 RVA: 0x00012F5C File Offset: 0x0001115C
		public static LogEventInfo Create(LogLevel logLevel, string loggerName, [Localizable(false)] string message, Exception exception)
		{
			return new LogEventInfo(logLevel, loggerName, null, message, null, exception);
		}

		/// <summary>
		/// Creates <see cref="T:NLog.Common.AsyncLogEventInfo" /> from this <see cref="T:NLog.LogEventInfo" /> by attaching the specified asynchronous continuation.
		/// </summary>
		/// <param name="asyncContinuation">The asynchronous continuation.</param>
		/// <returns>Instance of <see cref="T:NLog.Common.AsyncLogEventInfo" /> with attached continuation.</returns>
		// Token: 0x06000572 RID: 1394 RVA: 0x00012F7C File Offset: 0x0001117C
		public AsyncLogEventInfo WithContinuation(AsyncContinuation asyncContinuation)
		{
			return new AsyncLogEventInfo(this, asyncContinuation);
		}

		/// <summary>
		/// Returns a string representation of this log event.
		/// </summary>
		/// <returns>String representation of the log event.</returns>
		// Token: 0x06000573 RID: 1395 RVA: 0x00012F98 File Offset: 0x00011198
		public override string ToString()
		{
			return string.Concat(new object[] { "Log Event: Logger='", this.LoggerName, "' Level=", this.Level, " Message='", this.FormattedMessage, "' SequenceID=", this.SequenceID });
		}

		/// <summary>
		/// Sets the stack trace for the event info.
		/// </summary>
		/// <param name="stackTrace">The stack trace.</param>
		/// <param name="userStackFrame">Index of the first user stack frame within the stack trace.</param>
		// Token: 0x06000574 RID: 1396 RVA: 0x00013000 File Offset: 0x00011200
		public void SetStackTrace(StackTrace stackTrace, int userStackFrame)
		{
			this.StackTrace = stackTrace;
			this.UserStackFrameNumber = userStackFrame;
		}

		// Token: 0x06000575 RID: 1397 RVA: 0x00013014 File Offset: 0x00011214
		internal string AddCachedLayoutValue(Layout layout, string value)
		{
			lock (this.layoutCacheLock)
			{
				if (this.layoutCache == null)
				{
					this.layoutCache = new Dictionary<Layout, string>();
				}
				this.layoutCache[layout] = value;
			}
			return value;
		}

		// Token: 0x06000576 RID: 1398 RVA: 0x0001308C File Offset: 0x0001128C
		internal bool TryGetCachedLayoutValue(Layout layout, out string value)
		{
			bool flag2;
			lock (this.layoutCacheLock)
			{
				if (this.layoutCache == null)
				{
					value = null;
					flag2 = false;
				}
				else
				{
					flag2 = this.layoutCache.TryGetValue(layout, out value);
				}
			}
			return flag2;
		}

		// Token: 0x06000577 RID: 1399 RVA: 0x000130F8 File Offset: 0x000112F8
		private static bool NeedToPreformatMessage(object[] parameters)
		{
			bool flag;
			if (parameters == null || parameters.Length == 0)
			{
				flag = false;
			}
			else if (parameters.Length > 3)
			{
				flag = true;
			}
			else if (!LogEventInfo.IsSafeToDeferFormatting(parameters[0]))
			{
				flag = true;
			}
			else
			{
				if (parameters.Length >= 2)
				{
					if (!LogEventInfo.IsSafeToDeferFormatting(parameters[1]))
					{
						return true;
					}
				}
				if (parameters.Length >= 3)
				{
					if (!LogEventInfo.IsSafeToDeferFormatting(parameters[2]))
					{
						return true;
					}
				}
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000578 RID: 1400 RVA: 0x00013184 File Offset: 0x00011384
		private static bool IsSafeToDeferFormatting(object value)
		{
			return value == null || value.GetType().IsPrimitive || value is string;
		}

		// Token: 0x06000579 RID: 1401 RVA: 0x000131C0 File Offset: 0x000113C0
		private void CalcFormattedMessage()
		{
			if (this.Parameters == null || this.Parameters.Length == 0)
			{
				this.formattedMessage = this.Message;
			}
			else
			{
				try
				{
					this.formattedMessage = string.Format(this.FormatProvider ?? LogManager.DefaultCultureInfo(), this.Message, this.Parameters);
				}
				catch (Exception ex)
				{
					this.formattedMessage = this.Message;
					if (ex.MustBeRethrown())
					{
						throw;
					}
					InternalLogger.Warn("Error when formatting a message: {0}", new object[] { ex });
				}
			}
		}

		// Token: 0x0600057A RID: 1402 RVA: 0x00013278 File Offset: 0x00011478
		private void InitEventContext()
		{
			this.properties = new Dictionary<object, object>();
			this.eventContextAdapter = new DictionaryAdapter<object, object>(this.properties);
		}

		/// <summary>
		/// Gets the date of the first log event created.
		/// </summary>
		// Token: 0x040001DD RID: 477
		public static readonly DateTime ZeroDate = DateTime.UtcNow;

		// Token: 0x040001DE RID: 478
		private static int globalSequenceId;

		// Token: 0x040001DF RID: 479
		private readonly object layoutCacheLock = new object();

		// Token: 0x040001E0 RID: 480
		private string formattedMessage;

		// Token: 0x040001E1 RID: 481
		private IDictionary<Layout, string> layoutCache;

		// Token: 0x040001E2 RID: 482
		private IDictionary<object, object> properties;

		// Token: 0x040001E3 RID: 483
		private IDictionary eventContextAdapter;
	}
}
