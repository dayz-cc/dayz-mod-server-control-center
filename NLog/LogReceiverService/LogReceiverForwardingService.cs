using System;

namespace NLog.LogReceiverService
{
	/// <summary>
	/// Implementation of <see cref="T:NLog.LogReceiverService.ILogReceiverServer" /> which forwards received logs through <see cref="T:NLog.LogManager" /> or a given <see cref="T:NLog.LogFactory" />.
	/// </summary>
	// Token: 0x020000EF RID: 239
	public class LogReceiverForwardingService : ILogReceiverServer
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.LogReceiverService.LogReceiverForwardingService" /> class.
		/// </summary>
		// Token: 0x0600073C RID: 1852 RVA: 0x00019D55 File Offset: 0x00017F55
		public LogReceiverForwardingService()
			: this(null)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.LogReceiverService.LogReceiverForwardingService" /> class.
		/// </summary>
		/// <param name="logFactory">The log factory.</param>
		// Token: 0x0600073D RID: 1853 RVA: 0x00019D61 File Offset: 0x00017F61
		public LogReceiverForwardingService(LogFactory logFactory)
		{
			this.logFactory = logFactory;
		}

		/// <summary>
		/// Processes the log messages.
		/// </summary>
		/// <param name="events">The events to process.</param>
		// Token: 0x0600073E RID: 1854 RVA: 0x00019D74 File Offset: 0x00017F74
		public void ProcessLogMessages(NLogEvents events)
		{
			DateTime dateTime = new DateTime(events.BaseTimeUtc, DateTimeKind.Utc);
			LogEventInfo[] array = new LogEventInfo[events.Events.Length];
			for (int i = 0; i < events.Events.Length; i++)
			{
				NLogEvent nlogEvent = events.Events[i];
				LogLevel logLevel = LogLevel.FromOrdinal(nlogEvent.LevelOrdinal);
				string text = events.Strings[nlogEvent.LoggerOrdinal];
				LogEventInfo logEventInfo = new LogEventInfo();
				logEventInfo.Level = logLevel;
				logEventInfo.LoggerName = text;
				logEventInfo.TimeStamp = dateTime.AddTicks(nlogEvent.TimeDelta).ToLocalTime();
				logEventInfo.Message = events.Strings[nlogEvent.MessageOrdinal];
				logEventInfo.Properties.Add("ClientName", events.ClientName);
				for (int j = 0; j < events.LayoutNames.Count; j++)
				{
					logEventInfo.Properties.Add(events.LayoutNames[j], events.Strings[nlogEvent.ValueIndexes[j]]);
				}
				array[i] = logEventInfo;
			}
			this.ProcessLogMessages(array);
		}

		/// <summary>
		/// Processes the log messages.
		/// </summary>
		/// <param name="logEvents">The log events.</param>
		// Token: 0x0600073F RID: 1855 RVA: 0x00019EB4 File Offset: 0x000180B4
		protected virtual void ProcessLogMessages(LogEventInfo[] logEvents)
		{
			Logger logger = null;
			string text = string.Empty;
			foreach (LogEventInfo logEventInfo in logEvents)
			{
				if (logEventInfo.LoggerName != text)
				{
					if (this.logFactory != null)
					{
						logger = this.logFactory.GetLogger(logEventInfo.LoggerName);
					}
					else
					{
						logger = LogManager.GetLogger(logEventInfo.LoggerName);
					}
					text = logEventInfo.LoggerName;
				}
				logger.Log(logEventInfo);
			}
		}

		// Token: 0x0400021A RID: 538
		private readonly LogFactory logFactory;
	}
}
