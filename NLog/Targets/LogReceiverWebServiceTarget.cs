using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using NLog.Common;
using NLog.Config;
using NLog.Layouts;
using NLog.LogReceiverService;

namespace NLog.Targets
{
	/// <summary>
	/// Sends log messages to a NLog Receiver Service (using WCF or Web Services).
	/// </summary>
	/// <seealso href="http://nlog-project.org/wiki/LogReceiverService_target">Documentation on NLog Wiki</seealso>
	// Token: 0x02000117 RID: 279
	[Target("LogReceiverService")]
	public class LogReceiverWebServiceTarget : Target
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Targets.LogReceiverWebServiceTarget" /> class.
		/// </summary>
		// Token: 0x06000914 RID: 2324 RVA: 0x00020682 File Offset: 0x0001E882
		public LogReceiverWebServiceTarget()
		{
			this.Parameters = new List<MethodCallParameter>();
		}

		/// <summary>
		/// Gets or sets the endpoint address.
		/// </summary>
		/// <value>The endpoint address.</value>
		/// <docgen category="Connection Options" order="10" />
		// Token: 0x170001D7 RID: 471
		// (get) Token: 0x06000915 RID: 2325 RVA: 0x000206B0 File Offset: 0x0001E8B0
		// (set) Token: 0x06000916 RID: 2326 RVA: 0x000206C7 File Offset: 0x0001E8C7
		[RequiredParameter]
		public string EndpointAddress { get; set; }

		/// <summary>
		/// Gets or sets the name of the endpoint configuration in WCF configuration file.
		/// </summary>
		/// <value>The name of the endpoint configuration.</value>
		/// <docgen category="Connection Options" order="10" />
		// Token: 0x170001D8 RID: 472
		// (get) Token: 0x06000917 RID: 2327 RVA: 0x000206D0 File Offset: 0x0001E8D0
		// (set) Token: 0x06000918 RID: 2328 RVA: 0x000206E7 File Offset: 0x0001E8E7
		public string EndpointConfigurationName { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether to use binary message encoding.
		/// </summary>
		/// <docgen category="Payload Options" order="10" />
		// Token: 0x170001D9 RID: 473
		// (get) Token: 0x06000919 RID: 2329 RVA: 0x000206F0 File Offset: 0x0001E8F0
		// (set) Token: 0x0600091A RID: 2330 RVA: 0x00020707 File Offset: 0x0001E907
		public bool UseBinaryEncoding { get; set; }

		/// <summary>
		/// Gets or sets the client ID.
		/// </summary>
		/// <value>The client ID.</value>
		/// <docgen category="Payload Options" order="10" />
		// Token: 0x170001DA RID: 474
		// (get) Token: 0x0600091B RID: 2331 RVA: 0x00020710 File Offset: 0x0001E910
		// (set) Token: 0x0600091C RID: 2332 RVA: 0x00020727 File Offset: 0x0001E927
		public Layout ClientId { get; set; }

		/// <summary>
		/// Gets the list of parameters.
		/// </summary>
		/// <value>The parameters.</value>
		/// <docgen category="Payload Options" order="10" />
		// Token: 0x170001DB RID: 475
		// (get) Token: 0x0600091D RID: 2333 RVA: 0x00020730 File Offset: 0x0001E930
		// (set) Token: 0x0600091E RID: 2334 RVA: 0x00020747 File Offset: 0x0001E947
		[ArrayParameter(typeof(MethodCallParameter), "parameter")]
		public IList<MethodCallParameter> Parameters { get; private set; }

		/// <summary>
		/// Gets or sets a value indicating whether to include per-event properties in the payload sent to the server.
		/// </summary>
		/// <docgen category="Payload Options" order="10" />
		// Token: 0x170001DC RID: 476
		// (get) Token: 0x0600091F RID: 2335 RVA: 0x00020750 File Offset: 0x0001E950
		// (set) Token: 0x06000920 RID: 2336 RVA: 0x00020767 File Offset: 0x0001E967
		public bool IncludeEventProperties { get; set; }

		/// <summary>
		/// Called when log events are being sent (test hook).
		/// </summary>
		/// <param name="events">The events.</param>
		/// <param name="asyncContinuations">The async continuations.</param>
		/// <returns>True if events should be sent, false to stop processing them.</returns>
		// Token: 0x06000921 RID: 2337 RVA: 0x00020770 File Offset: 0x0001E970
		protected internal virtual bool OnSend(NLogEvents events, IEnumerable<AsyncLogEventInfo> asyncContinuations)
		{
			return true;
		}

		/// <summary>
		/// Writes logging event to the log target. Must be overridden in inheriting
		/// classes.
		/// </summary>
		/// <param name="logEvent">Logging event to be written out.</param>
		// Token: 0x06000922 RID: 2338 RVA: 0x00020784 File Offset: 0x0001E984
		protected override void Write(AsyncLogEventInfo logEvent)
		{
			this.Write(new AsyncLogEventInfo[] { logEvent });
		}

		/// <summary>
		/// Writes an array of logging events to the log target. By default it iterates on all
		/// events and passes them to "Append" method. Inheriting classes can use this method to
		/// optimize batch writes.
		/// </summary>
		/// <param name="logEvents">Logging events to be written out.</param>
		// Token: 0x06000923 RID: 2339 RVA: 0x000207B0 File Offset: 0x0001E9B0
		protected override void Write(AsyncLogEventInfo[] logEvents)
		{
			if (this.inCall)
			{
				foreach (AsyncLogEventInfo asyncLogEventInfo in logEvents)
				{
					this.buffer.Append(asyncLogEventInfo);
				}
			}
			else
			{
				NLogEvents nlogEvents = this.TranslateLogEvents(logEvents);
				this.Send(nlogEvents, logEvents);
			}
		}

		// Token: 0x06000924 RID: 2340 RVA: 0x00020818 File Offset: 0x0001EA18
		private static int GetStringOrdinal(NLogEvents context, Dictionary<string, int> stringTable, string value)
		{
			int count;
			if (!stringTable.TryGetValue(value, out count))
			{
				count = context.Strings.Count;
				stringTable.Add(value, count);
				context.Strings.Add(value);
			}
			return count;
		}

		// Token: 0x06000925 RID: 2341 RVA: 0x0002085C File Offset: 0x0001EA5C
		private NLogEvents TranslateLogEvents(AsyncLogEventInfo[] logEvents)
		{
			NLogEvents nlogEvents;
			if (logEvents.Length == 0 && !LogManager.ThrowExceptions)
			{
				InternalLogger.Error("LogEvents array is empty, sending empty event...");
				nlogEvents = new NLogEvents();
			}
			else
			{
				string text = string.Empty;
				if (this.ClientId != null)
				{
					text = this.ClientId.Render(logEvents[0].LogEvent);
				}
				NLogEvents nlogEvents2 = new NLogEvents
				{
					ClientName = text,
					LayoutNames = new StringCollection(),
					Strings = new StringCollection(),
					BaseTimeUtc = logEvents[0].LogEvent.TimeStamp.ToUniversalTime().Ticks
				};
				Dictionary<string, int> dictionary = new Dictionary<string, int>();
				for (int i = 0; i < this.Parameters.Count; i++)
				{
					nlogEvents2.LayoutNames.Add(this.Parameters[i].Name);
				}
				if (this.IncludeEventProperties)
				{
					for (int i = 0; i < logEvents.Length; i++)
					{
						LogEventInfo logEvent = logEvents[i].LogEvent;
						foreach (KeyValuePair<object, object> keyValuePair in logEvent.Properties)
						{
							string text2 = keyValuePair.Key as string;
							if (text2 != null)
							{
								if (!nlogEvents2.LayoutNames.Contains(text2))
								{
									nlogEvents2.LayoutNames.Add(text2);
								}
							}
						}
					}
				}
				nlogEvents2.Events = new NLogEvent[logEvents.Length];
				for (int i = 0; i < logEvents.Length; i++)
				{
					nlogEvents2.Events[i] = this.TranslateEvent(logEvents[i].LogEvent, nlogEvents2, dictionary);
				}
				nlogEvents = nlogEvents2;
			}
			return nlogEvents;
		}

		// Token: 0x06000926 RID: 2342 RVA: 0x00020AF0 File Offset: 0x0001ECF0
		[SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "Client is disposed asynchronously.")]
		private void Send(NLogEvents events, IEnumerable<AsyncLogEventInfo> asyncContinuations)
		{
			if (this.OnSend(events, asyncContinuations))
			{
				WcfLogReceiverClient wcfLogReceiverClient = this.CreateWcfLogReceiverClient();
				wcfLogReceiverClient.ProcessLogMessagesCompleted += delegate(object sender, AsyncCompletedEventArgs e)
				{
					foreach (AsyncLogEventInfo asyncLogEventInfo in asyncContinuations)
					{
						asyncLogEventInfo.Continuation(e.Error);
					}
					this.SendBufferedEvents();
				};
				this.inCall = true;
				wcfLogReceiverClient.ProcessLogMessagesAsync(events);
			}
		}

		/// <summary>
		/// Creating a new instance of WcfLogReceiverClient
		///
		/// Inheritors can override this method and provide their own 
		/// service configuration - binding and endpoint address
		/// </summary>
		/// <returns></returns>
		// Token: 0x06000927 RID: 2343 RVA: 0x00020B50 File Offset: 0x0001ED50
		protected virtual WcfLogReceiverClient CreateWcfLogReceiverClient()
		{
			WcfLogReceiverClient wcfLogReceiverClient;
			if (string.IsNullOrEmpty(this.EndpointConfigurationName))
			{
				Binding binding;
				if (this.UseBinaryEncoding)
				{
					binding = new CustomBinding(new BindingElement[]
					{
						new BinaryMessageEncodingBindingElement(),
						new HttpTransportBindingElement()
					});
				}
				else
				{
					binding = new BasicHttpBinding();
				}
				wcfLogReceiverClient = new WcfLogReceiverClient(binding, new EndpointAddress(this.EndpointAddress));
			}
			else
			{
				wcfLogReceiverClient = new WcfLogReceiverClient(this.EndpointConfigurationName, new EndpointAddress(this.EndpointAddress));
			}
			return wcfLogReceiverClient;
		}

		// Token: 0x06000928 RID: 2344 RVA: 0x00020BE0 File Offset: 0x0001EDE0
		private void SendBufferedEvents()
		{
			lock (base.SyncRoot)
			{
				AsyncLogEventInfo[] eventsAndClear = this.buffer.GetEventsAndClear();
				if (eventsAndClear.Length > 0)
				{
					NLogEvents nlogEvents = this.TranslateLogEvents(eventsAndClear);
					this.Send(nlogEvents, eventsAndClear);
				}
				else
				{
					this.inCall = false;
				}
			}
		}

		// Token: 0x06000929 RID: 2345 RVA: 0x00020C60 File Offset: 0x0001EE60
		private NLogEvent TranslateEvent(LogEventInfo eventInfo, NLogEvents context, Dictionary<string, int> stringTable)
		{
			NLogEvent nlogEvent = new NLogEvent();
			nlogEvent.Id = eventInfo.SequenceID;
			nlogEvent.MessageOrdinal = LogReceiverWebServiceTarget.GetStringOrdinal(context, stringTable, eventInfo.FormattedMessage);
			nlogEvent.LevelOrdinal = eventInfo.Level.Ordinal;
			nlogEvent.LoggerOrdinal = LogReceiverWebServiceTarget.GetStringOrdinal(context, stringTable, eventInfo.LoggerName);
			nlogEvent.TimeDelta = eventInfo.TimeStamp.ToUniversalTime().Ticks - context.BaseTimeUtc;
			for (int i = 0; i < this.Parameters.Count; i++)
			{
				MethodCallParameter methodCallParameter = this.Parameters[i];
				string text = methodCallParameter.Layout.Render(eventInfo);
				int num = LogReceiverWebServiceTarget.GetStringOrdinal(context, stringTable, text);
				nlogEvent.ValueIndexes.Add(num);
			}
			for (int i = this.Parameters.Count; i < context.LayoutNames.Count; i++)
			{
				string text;
				object obj;
				if (eventInfo.Properties.TryGetValue(context.LayoutNames[i], out obj))
				{
					text = Convert.ToString(obj, CultureInfo.InvariantCulture);
				}
				else
				{
					text = string.Empty;
				}
				int num = LogReceiverWebServiceTarget.GetStringOrdinal(context, stringTable, text);
				nlogEvent.ValueIndexes.Add(num);
			}
			return nlogEvent;
		}

		// Token: 0x040002CC RID: 716
		private LogEventInfoBuffer buffer = new LogEventInfoBuffer(10000, false, 10000);

		// Token: 0x040002CD RID: 717
		private bool inCall;
	}
}
