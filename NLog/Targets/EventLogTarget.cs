using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using NLog.Common;
using NLog.Config;
using NLog.Internal;
using NLog.Internal.Fakeables;
using NLog.Layouts;

namespace NLog.Targets
{
	/// <summary>
	/// Writes log message to the Event Log.
	/// </summary>
	/// <seealso href="http://nlog-project.org/wiki/EventLog_target">Documentation on NLog Wiki</seealso>
	/// <example>
	/// <p>
	/// To set up the target in the <a href="config.html">configuration file</a>, 
	/// use the following syntax:
	/// </p>
	/// <code lang="XML" source="examples/targets/Configuration File/EventLog/NLog.config" />
	/// <p>
	/// This assumes just one target and a single rule. More configuration
	/// options are described <a href="config.html">here</a>.
	/// </p>
	/// <p>
	/// To set up the log target programmatically use code like this:
	/// </p>
	/// <code lang="C#" source="examples/targets/Configuration API/EventLog/Simple/Example.cs" />
	/// </example>
	// Token: 0x02000110 RID: 272
	[Target("EventLog")]
	public class EventLogTarget : TargetWithLayout, IInstallable
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Targets.EventLogTarget" /> class.
		/// </summary>
		// Token: 0x0600089D RID: 2205 RVA: 0x0001E465 File Offset: 0x0001C665
		public EventLogTarget()
			: this(AppDomainWrapper.CurrentDomain)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Targets.EventLogTarget" /> class.
		/// </summary>
		// Token: 0x0600089E RID: 2206 RVA: 0x0001E475 File Offset: 0x0001C675
		public EventLogTarget(IAppDomain appDomain)
		{
			this.Source = appDomain.FriendlyName;
			this.Log = "Application";
			this.MachineName = ".";
		}

		/// <summary>
		/// Gets or sets the name of the machine on which Event Log service is running.
		/// </summary>
		/// <docgen category="Event Log Options" order="10" />
		// Token: 0x170001B4 RID: 436
		// (get) Token: 0x0600089F RID: 2207 RVA: 0x0001E4A8 File Offset: 0x0001C6A8
		// (set) Token: 0x060008A0 RID: 2208 RVA: 0x0001E4BF File Offset: 0x0001C6BF
		[DefaultValue(".")]
		public string MachineName { get; set; }

		/// <summary>
		/// Gets or sets the layout that renders event ID.
		/// </summary>
		/// <docgen category="Event Log Options" order="10" />
		// Token: 0x170001B5 RID: 437
		// (get) Token: 0x060008A1 RID: 2209 RVA: 0x0001E4C8 File Offset: 0x0001C6C8
		// (set) Token: 0x060008A2 RID: 2210 RVA: 0x0001E4DF File Offset: 0x0001C6DF
		public Layout EventId { get; set; }

		/// <summary>
		/// Gets or sets the layout that renders event Category.
		/// </summary>
		/// <docgen category="Event Log Options" order="10" />
		// Token: 0x170001B6 RID: 438
		// (get) Token: 0x060008A3 RID: 2211 RVA: 0x0001E4E8 File Offset: 0x0001C6E8
		// (set) Token: 0x060008A4 RID: 2212 RVA: 0x0001E4FF File Offset: 0x0001C6FF
		public Layout Category { get; set; }

		/// <summary>
		/// Gets or sets the value to be used as the event Source.
		/// </summary>
		/// <remarks>
		/// By default this is the friendly name of the current AppDomain.
		/// </remarks>
		/// <docgen category="Event Log Options" order="10" />
		// Token: 0x170001B7 RID: 439
		// (get) Token: 0x060008A5 RID: 2213 RVA: 0x0001E508 File Offset: 0x0001C708
		// (set) Token: 0x060008A6 RID: 2214 RVA: 0x0001E51F File Offset: 0x0001C71F
		public string Source { get; set; }

		/// <summary>
		/// Gets or sets the name of the Event Log to write to. This can be System, Application or 
		/// any user-defined name.
		/// </summary>
		/// <docgen category="Event Log Options" order="10" />
		// Token: 0x170001B8 RID: 440
		// (get) Token: 0x060008A7 RID: 2215 RVA: 0x0001E528 File Offset: 0x0001C728
		// (set) Token: 0x060008A8 RID: 2216 RVA: 0x0001E53F File Offset: 0x0001C73F
		[DefaultValue("Application")]
		public string Log { get; set; }

		/// <summary>
		/// Performs installation which requires administrative permissions.
		/// </summary>
		/// <param name="installationContext">The installation context.</param>
		// Token: 0x060008A9 RID: 2217 RVA: 0x0001E548 File Offset: 0x0001C748
		public void Install(InstallationContext installationContext)
		{
			if (EventLog.SourceExists(this.Source, this.MachineName))
			{
				string text = EventLog.LogNameFromSourceName(this.Source, this.MachineName);
				if (text != this.Log)
				{
					EventLog.DeleteEventSource(this.Source, this.MachineName);
					EventSourceCreationData eventSourceCreationData = new EventSourceCreationData(this.Source, this.Log)
					{
						MachineName = this.MachineName
					};
					EventLog.CreateEventSource(eventSourceCreationData);
				}
			}
			else
			{
				EventSourceCreationData eventSourceCreationData = new EventSourceCreationData(this.Source, this.Log)
				{
					MachineName = this.MachineName
				};
				EventLog.CreateEventSource(eventSourceCreationData);
			}
		}

		/// <summary>
		/// Performs uninstallation which requires administrative permissions.
		/// </summary>
		/// <param name="installationContext">The installation context.</param>
		// Token: 0x060008AA RID: 2218 RVA: 0x0001E601 File Offset: 0x0001C801
		public void Uninstall(InstallationContext installationContext)
		{
			EventLog.DeleteEventSource(this.Source, this.MachineName);
		}

		/// <summary>
		/// Determines whether the item is installed.
		/// </summary>
		/// <param name="installationContext">The installation context.</param>
		/// <returns>
		/// Value indicating whether the item is installed or null if it is not possible to determine.
		/// </returns>
		// Token: 0x060008AB RID: 2219 RVA: 0x0001E618 File Offset: 0x0001C818
		public bool? IsInstalled(InstallationContext installationContext)
		{
			return new bool?(EventLog.SourceExists(this.Source, this.MachineName));
		}

		/// <summary>
		/// Initializes the target.
		/// </summary>
		// Token: 0x060008AC RID: 2220 RVA: 0x0001E640 File Offset: 0x0001C840
		protected override void InitializeTarget()
		{
			base.InitializeTarget();
			string text = EventLog.LogNameFromSourceName(this.Source, this.MachineName);
			if (text != this.Log)
			{
				this.CreateEventSourceIfNeeded();
			}
		}

		/// <summary>
		/// Writes the specified logging event to the event log. 
		/// </summary>
		/// <param name="logEvent">The logging event.</param>
		// Token: 0x060008AD RID: 2221 RVA: 0x0001E684 File Offset: 0x0001C884
		protected override void Write(LogEventInfo logEvent)
		{
			string text = this.Layout.Render(logEvent);
			if (text.Length > 16384)
			{
				text = text.Substring(0, 16384);
			}
			EventLogEntryType eventLogEntryType;
			if (logEvent.Level >= LogLevel.Error)
			{
				eventLogEntryType = EventLogEntryType.Error;
			}
			else if (logEvent.Level >= LogLevel.Warn)
			{
				eventLogEntryType = EventLogEntryType.Warning;
			}
			else
			{
				eventLogEntryType = EventLogEntryType.Information;
			}
			int num = 0;
			if (this.EventId != null)
			{
				num = Convert.ToInt32(this.EventId.Render(logEvent), CultureInfo.InvariantCulture);
			}
			short num2 = 0;
			if (this.Category != null)
			{
				num2 = Convert.ToInt16(this.Category.Render(logEvent), CultureInfo.InvariantCulture);
			}
			EventLog eventLog = this.GetEventLog();
			eventLog.WriteEntry(text, eventLogEntryType, num, num2);
		}

		// Token: 0x060008AE RID: 2222 RVA: 0x0001E770 File Offset: 0x0001C970
		private EventLog GetEventLog()
		{
			EventLog eventLog;
			if ((eventLog = this.eventLogInstance) == null)
			{
				eventLog = (this.eventLogInstance = new EventLog(this.Log, this.MachineName, this.Source));
			}
			return eventLog;
		}

		// Token: 0x060008AF RID: 2223 RVA: 0x0001E7AC File Offset: 0x0001C9AC
		private void CreateEventSourceIfNeeded()
		{
			try
			{
				if (EventLog.SourceExists(this.Source, this.MachineName))
				{
					string text = EventLog.LogNameFromSourceName(this.Source, this.MachineName);
					if (text != this.Log)
					{
						EventLog.DeleteEventSource(this.Source, this.MachineName);
						EventSourceCreationData eventSourceCreationData = new EventSourceCreationData(this.Source, this.Log)
						{
							MachineName = this.MachineName
						};
						EventLog.CreateEventSource(eventSourceCreationData);
					}
				}
				else
				{
					EventSourceCreationData eventSourceCreationData = new EventSourceCreationData(this.Source, this.Log)
					{
						MachineName = this.MachineName
					};
					EventLog.CreateEventSource(eventSourceCreationData);
				}
			}
			catch (Exception ex)
			{
				if (ex.MustBeRethrown())
				{
					throw;
				}
				InternalLogger.Error("Error when connecting to EventLog: {0}", new object[] { ex });
				throw;
			}
		}

		// Token: 0x04000294 RID: 660
		private EventLog eventLogInstance;
	}
}
