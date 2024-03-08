using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.Xml;
using NLog.Time;

namespace NLog
{
	/// <summary>
	/// TraceListener which routes all messages through NLog.
	/// </summary>
	// Token: 0x020000FC RID: 252
	public class NLogTraceListener : TraceListener
	{
		/// <summary>
		/// Gets or sets the log factory to use when outputting messages (null - use LogManager).
		/// </summary>
		// Token: 0x17000163 RID: 355
		// (get) Token: 0x0600079D RID: 1949 RVA: 0x0001AA6C File Offset: 0x00018C6C
		// (set) Token: 0x0600079E RID: 1950 RVA: 0x0001AA8B File Offset: 0x00018C8B
		public LogFactory LogFactory
		{
			get
			{
				this.InitAttributes();
				return this.logFactory;
			}
			set
			{
				this.attributesLoaded = true;
				this.logFactory = value;
			}
		}

		/// <summary>
		/// Gets or sets the default log level.
		/// </summary>
		// Token: 0x17000164 RID: 356
		// (get) Token: 0x0600079F RID: 1951 RVA: 0x0001AA9C File Offset: 0x00018C9C
		// (set) Token: 0x060007A0 RID: 1952 RVA: 0x0001AABB File Offset: 0x00018CBB
		public LogLevel DefaultLogLevel
		{
			get
			{
				this.InitAttributes();
				return this.defaultLogLevel;
			}
			set
			{
				this.attributesLoaded = true;
				this.defaultLogLevel = value;
			}
		}

		/// <summary>
		/// Gets or sets the log which should be always used regardless of source level.
		/// </summary>
		// Token: 0x17000165 RID: 357
		// (get) Token: 0x060007A1 RID: 1953 RVA: 0x0001AACC File Offset: 0x00018CCC
		// (set) Token: 0x060007A2 RID: 1954 RVA: 0x0001AAEB File Offset: 0x00018CEB
		public LogLevel ForceLogLevel
		{
			get
			{
				this.InitAttributes();
				return this.forceLogLevel;
			}
			set
			{
				this.attributesLoaded = true;
				this.forceLogLevel = value;
			}
		}

		/// <summary>
		/// Gets a value indicating whether the trace listener is thread safe.
		/// </summary>
		/// <value></value>
		/// <returns>true if the trace listener is thread safe; otherwise, false. The default is false.</returns>
		// Token: 0x17000166 RID: 358
		// (get) Token: 0x060007A3 RID: 1955 RVA: 0x0001AAFC File Offset: 0x00018CFC
		public override bool IsThreadSafe
		{
			get
			{
				return true;
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether to use auto logger name detected from the stack trace.
		/// </summary>
		// Token: 0x17000167 RID: 359
		// (get) Token: 0x060007A4 RID: 1956 RVA: 0x0001AB10 File Offset: 0x00018D10
		// (set) Token: 0x060007A5 RID: 1957 RVA: 0x0001AB2F File Offset: 0x00018D2F
		public bool AutoLoggerName
		{
			get
			{
				this.InitAttributes();
				return this.autoLoggerName;
			}
			set
			{
				this.attributesLoaded = true;
				this.autoLoggerName = value;
			}
		}

		/// <summary>
		/// When overridden in a derived class, writes the specified message to the listener you create in the derived class.
		/// </summary>
		/// <param name="message">A message to write.</param>
		// Token: 0x060007A6 RID: 1958 RVA: 0x0001AB40 File Offset: 0x00018D40
		public override void Write(string message)
		{
			this.ProcessLogEventInfo(this.DefaultLogLevel, null, message, null, null, new TraceEventType?(TraceEventType.Resume), null);
		}

		/// <summary>
		/// When overridden in a derived class, writes a message to the listener you create in the derived class, followed by a line terminator.
		/// </summary>
		/// <param name="message">A message to write.</param>
		// Token: 0x060007A7 RID: 1959 RVA: 0x0001AB7C File Offset: 0x00018D7C
		public override void WriteLine(string message)
		{
			this.ProcessLogEventInfo(this.DefaultLogLevel, null, message, null, null, new TraceEventType?(TraceEventType.Resume), null);
		}

		/// <summary>
		/// When overridden in a derived class, closes the output stream so it no longer receives tracing or debugging output.
		/// </summary>
		// Token: 0x060007A8 RID: 1960 RVA: 0x0001ABB6 File Offset: 0x00018DB6
		public override void Close()
		{
		}

		/// <summary>
		/// Emits an error message.
		/// </summary>
		/// <param name="message">A message to emit.</param>
		// Token: 0x060007A9 RID: 1961 RVA: 0x0001ABBC File Offset: 0x00018DBC
		public override void Fail(string message)
		{
			this.ProcessLogEventInfo(LogLevel.Error, null, message, null, null, new TraceEventType?(TraceEventType.Error), null);
		}

		/// <summary>
		/// Emits an error message and a detailed error message.
		/// </summary>
		/// <param name="message">A message to emit.</param>
		/// <param name="detailMessage">A detailed message to emit.</param>
		// Token: 0x060007AA RID: 1962 RVA: 0x0001ABF4 File Offset: 0x00018DF4
		public override void Fail(string message, string detailMessage)
		{
			this.ProcessLogEventInfo(LogLevel.Error, null, message + " " + detailMessage, null, null, new TraceEventType?(TraceEventType.Error), null);
		}

		/// <summary>
		/// Flushes the output buffer.
		/// </summary>
		// Token: 0x060007AB RID: 1963 RVA: 0x0001AC34 File Offset: 0x00018E34
		public override void Flush()
		{
			if (this.LogFactory != null)
			{
				this.LogFactory.Flush();
			}
			else
			{
				LogManager.Flush();
			}
		}

		/// <summary>
		/// Writes trace information, a data object and event information to the listener specific output.
		/// </summary>
		/// <param name="eventCache">A <see cref="T:System.Diagnostics.TraceEventCache" /> object that contains the current process ID, thread ID, and stack trace information.</param>
		/// <param name="source">A name used to identify the output, typically the name of the application that generated the trace event.</param>
		/// <param name="eventType">One of the <see cref="T:System.Diagnostics.TraceEventType" /> values specifying the type of event that has caused the trace.</param>
		/// <param name="id">A numeric identifier for the event.</param>
		/// <param name="data">The trace data to emit.</param>
		// Token: 0x060007AC RID: 1964 RVA: 0x0001AC68 File Offset: 0x00018E68
		public override void TraceData(TraceEventCache eventCache, string source, TraceEventType eventType, int id, object data)
		{
			this.TraceData(eventCache, source, eventType, id, new object[] { data });
		}

		/// <summary>
		/// Writes trace information, an array of data objects and event information to the listener specific output.
		/// </summary>
		/// <param name="eventCache">A <see cref="T:System.Diagnostics.TraceEventCache" /> object that contains the current process ID, thread ID, and stack trace information.</param>
		/// <param name="source">A name used to identify the output, typically the name of the application that generated the trace event.</param>
		/// <param name="eventType">One of the <see cref="T:System.Diagnostics.TraceEventType" /> values specifying the type of event that has caused the trace.</param>
		/// <param name="id">A numeric identifier for the event.</param>
		/// <param name="data">An array of objects to emit as data.</param>
		// Token: 0x060007AD RID: 1965 RVA: 0x0001AC90 File Offset: 0x00018E90
		public override void TraceData(TraceEventCache eventCache, string source, TraceEventType eventType, int id, params object[] data)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < data.Length; i++)
			{
				if (i > 0)
				{
					stringBuilder.Append(", ");
				}
				stringBuilder.Append("{");
				stringBuilder.Append(i);
				stringBuilder.Append("}");
			}
			this.ProcessLogEventInfo(NLogTraceListener.TranslateLogLevel(eventType), source, stringBuilder.ToString(), data, new int?(id), new TraceEventType?(eventType), null);
		}

		/// <summary>
		/// Writes trace and event information to the listener specific output.
		/// </summary>
		/// <param name="eventCache">A <see cref="T:System.Diagnostics.TraceEventCache" /> object that contains the current process ID, thread ID, and stack trace information.</param>
		/// <param name="source">A name used to identify the output, typically the name of the application that generated the trace event.</param>
		/// <param name="eventType">One of the <see cref="T:System.Diagnostics.TraceEventType" /> values specifying the type of event that has caused the trace.</param>
		/// <param name="id">A numeric identifier for the event.</param>
		// Token: 0x060007AE RID: 1966 RVA: 0x0001AD20 File Offset: 0x00018F20
		public override void TraceEvent(TraceEventCache eventCache, string source, TraceEventType eventType, int id)
		{
			this.ProcessLogEventInfo(NLogTraceListener.TranslateLogLevel(eventType), source, string.Empty, null, new int?(id), new TraceEventType?(eventType), null);
		}

		/// <summary>
		/// Writes trace information, a formatted array of objects and event information to the listener specific output.
		/// </summary>
		/// <param name="eventCache">A <see cref="T:System.Diagnostics.TraceEventCache" /> object that contains the current process ID, thread ID, and stack trace information.</param>
		/// <param name="source">A name used to identify the output, typically the name of the application that generated the trace event.</param>
		/// <param name="eventType">One of the <see cref="T:System.Diagnostics.TraceEventType" /> values specifying the type of event that has caused the trace.</param>
		/// <param name="id">A numeric identifier for the event.</param>
		/// <param name="format">A format string that contains zero or more format items, which correspond to objects in the <paramref name="args" /> array.</param>
		/// <param name="args">An object array containing zero or more objects to format.</param>
		// Token: 0x060007AF RID: 1967 RVA: 0x0001AD58 File Offset: 0x00018F58
		public override void TraceEvent(TraceEventCache eventCache, string source, TraceEventType eventType, int id, string format, params object[] args)
		{
			this.ProcessLogEventInfo(NLogTraceListener.TranslateLogLevel(eventType), source, format, args, new int?(id), new TraceEventType?(eventType), null);
		}

		/// <summary>
		/// Writes trace information, a message, and event information to the listener specific output.
		/// </summary>
		/// <param name="eventCache">A <see cref="T:System.Diagnostics.TraceEventCache" /> object that contains the current process ID, thread ID, and stack trace information.</param>
		/// <param name="source">A name used to identify the output, typically the name of the application that generated the trace event.</param>
		/// <param name="eventType">One of the <see cref="T:System.Diagnostics.TraceEventType" /> values specifying the type of event that has caused the trace.</param>
		/// <param name="id">A numeric identifier for the event.</param>
		/// <param name="message">A message to write.</param>
		// Token: 0x060007B0 RID: 1968 RVA: 0x0001AD90 File Offset: 0x00018F90
		public override void TraceEvent(TraceEventCache eventCache, string source, TraceEventType eventType, int id, string message)
		{
			this.ProcessLogEventInfo(NLogTraceListener.TranslateLogLevel(eventType), source, message, null, new int?(id), new TraceEventType?(eventType), null);
		}

		/// <summary>
		/// Writes trace information, a message, a related activity identity and event information to the listener specific output.
		/// </summary>
		/// <param name="eventCache">A <see cref="T:System.Diagnostics.TraceEventCache" /> object that contains the current process ID, thread ID, and stack trace information.</param>
		/// <param name="source">A name used to identify the output, typically the name of the application that generated the trace event.</param>
		/// <param name="id">A numeric identifier for the event.</param>
		/// <param name="message">A message to write.</param>
		/// <param name="relatedActivityId">A <see cref="T:System.Guid" />  object identifying a related activity.</param>
		// Token: 0x060007B1 RID: 1969 RVA: 0x0001ADC5 File Offset: 0x00018FC5
		public override void TraceTransfer(TraceEventCache eventCache, string source, int id, string message, Guid relatedActivityId)
		{
			this.ProcessLogEventInfo(LogLevel.Debug, source, message, null, new int?(id), new TraceEventType?(TraceEventType.Transfer), new Guid?(relatedActivityId));
		}

		/// <summary>
		/// Gets the custom attributes supported by the trace listener.
		/// </summary>
		/// <returns>
		/// A string array naming the custom attributes supported by the trace listener, or null if there are no custom attributes.
		/// </returns>
		// Token: 0x060007B2 RID: 1970 RVA: 0x0001ADF0 File Offset: 0x00018FF0
		protected override string[] GetSupportedAttributes()
		{
			return new string[] { "defaultLogLevel", "autoLoggerName", "forceLogLevel" };
		}

		/// <summary>
		/// Translates the event type to level from <see cref="T:System.Diagnostics.TraceEventType" />.
		/// </summary>
		/// <param name="eventType">Type of the event.</param>
		/// <returns>Translated log level.</returns>
		// Token: 0x060007B3 RID: 1971 RVA: 0x0001AE24 File Offset: 0x00019024
		private static LogLevel TranslateLogLevel(TraceEventType eventType)
		{
			switch (eventType)
			{
			case TraceEventType.Critical:
				return LogLevel.Fatal;
			case TraceEventType.Error:
				return LogLevel.Error;
			case (TraceEventType)3:
				break;
			case TraceEventType.Warning:
				return LogLevel.Warn;
			default:
				if (eventType == TraceEventType.Information)
				{
					return LogLevel.Info;
				}
				if (eventType == TraceEventType.Verbose)
				{
					return LogLevel.Trace;
				}
				break;
			}
			return LogLevel.Debug;
		}

		// Token: 0x060007B4 RID: 1972 RVA: 0x0001AE88 File Offset: 0x00019088
		private void ProcessLogEventInfo(LogLevel logLevel, string loggerName, [Localizable(false)] string message, object[] arguments, int? eventId, TraceEventType? eventType, Guid? relatedActiviyId)
		{
			LogEventInfo logEventInfo = new LogEventInfo();
			logEventInfo.LoggerName = (loggerName ?? this.Name) ?? string.Empty;
			if (this.AutoLoggerName)
			{
				StackTrace stackTrace = new StackTrace();
				int num = -1;
				MethodBase methodBase = null;
				for (int i = 0; i < stackTrace.FrameCount; i++)
				{
					StackFrame frame = stackTrace.GetFrame(i);
					MethodBase method = frame.GetMethod();
					if (!(method.DeclaringType == base.GetType()))
					{
						if (!(method.DeclaringType.Assembly == NLogTraceListener.systemAssembly))
						{
							num = i;
							methodBase = method;
							break;
						}
					}
				}
				if (num >= 0)
				{
					logEventInfo.SetStackTrace(stackTrace, num);
					if (methodBase.DeclaringType != null)
					{
						logEventInfo.LoggerName = methodBase.DeclaringType.FullName;
					}
				}
			}
			if (eventType != null)
			{
				logEventInfo.Properties.Add("EventType", eventType.Value);
			}
			if (relatedActiviyId != null)
			{
				logEventInfo.Properties.Add("RelatedActivityID", relatedActiviyId.Value);
			}
			logEventInfo.TimeStamp = TimeSource.Current.Time;
			logEventInfo.Message = message;
			logEventInfo.Parameters = arguments;
			logEventInfo.Level = this.forceLogLevel ?? logLevel;
			if (eventId != null)
			{
				logEventInfo.Properties.Add("EventID", eventId.Value);
			}
			Logger logger;
			if (this.LogFactory != null)
			{
				logger = this.LogFactory.GetLogger(logEventInfo.LoggerName);
			}
			else
			{
				logger = LogManager.GetLogger(logEventInfo.LoggerName);
			}
			logger.Log(logEventInfo);
		}

		// Token: 0x060007B5 RID: 1973 RVA: 0x0001B08C File Offset: 0x0001928C
		private void InitAttributes()
		{
			if (!this.attributesLoaded)
			{
				this.attributesLoaded = true;
				foreach (object obj in base.Attributes)
				{
					DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
					string text = (string)dictionaryEntry.Key;
					string text2 = (string)dictionaryEntry.Value;
					string text3 = text.ToUpperInvariant();
					if (text3 != null)
					{
						if (!(text3 == "DEFAULTLOGLEVEL"))
						{
							if (!(text3 == "FORCELOGLEVEL"))
							{
								if (text3 == "AUTOLOGGERNAME")
								{
									this.AutoLoggerName = XmlConvert.ToBoolean(text2);
								}
							}
							else
							{
								this.forceLogLevel = LogLevel.FromString(text2);
							}
						}
						else
						{
							this.defaultLogLevel = LogLevel.FromString(text2);
						}
					}
				}
			}
		}

		// Token: 0x0400022E RID: 558
		private static readonly Assembly systemAssembly = typeof(Trace).Assembly;

		// Token: 0x0400022F RID: 559
		private LogFactory logFactory;

		// Token: 0x04000230 RID: 560
		private LogLevel defaultLogLevel = LogLevel.Debug;

		// Token: 0x04000231 RID: 561
		private bool attributesLoaded;

		// Token: 0x04000232 RID: 562
		private bool autoLoggerName;

		// Token: 0x04000233 RID: 563
		private LogLevel forceLogLevel;
	}
}
