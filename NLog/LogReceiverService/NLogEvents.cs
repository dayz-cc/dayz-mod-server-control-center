using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace NLog.LogReceiverService
{
	/// <summary>
	/// Wire format for NLog event package.
	/// </summary>
	// Token: 0x020000F2 RID: 242
	[XmlRoot("events", Namespace = "http://nlog-project.org/ws/")]
	[DebuggerDisplay("Count = {Events.Length}")]
	[DataContract(Name = "events", Namespace = "http://nlog-project.org/ws/")]
	[XmlType(Namespace = "http://nlog-project.org/ws/")]
	public class NLogEvents
	{
		/// <summary>
		/// Gets or sets the name of the client.
		/// </summary>
		/// <value>The name of the client.</value>
		// Token: 0x1700015A RID: 346
		// (get) Token: 0x06000750 RID: 1872 RVA: 0x0001A210 File Offset: 0x00018410
		// (set) Token: 0x06000751 RID: 1873 RVA: 0x0001A227 File Offset: 0x00018427
		[XmlElement("cli", Order = 0)]
		[DataMember(Name = "cli", Order = 0)]
		public string ClientName { get; set; }

		/// <summary>
		/// Gets or sets the base time (UTC ticks) for all events in the package.
		/// </summary>
		/// <value>The base time UTC.</value>
		// Token: 0x1700015B RID: 347
		// (get) Token: 0x06000752 RID: 1874 RVA: 0x0001A230 File Offset: 0x00018430
		// (set) Token: 0x06000753 RID: 1875 RVA: 0x0001A247 File Offset: 0x00018447
		[DataMember(Name = "bts", Order = 1)]
		[XmlElement("bts", Order = 1)]
		public long BaseTimeUtc { get; set; }

		/// <summary>
		/// Gets or sets the collection of layout names which are shared among all events.
		/// </summary>
		/// <value>The layout names.</value>
		// Token: 0x1700015C RID: 348
		// (get) Token: 0x06000754 RID: 1876 RVA: 0x0001A250 File Offset: 0x00018450
		// (set) Token: 0x06000755 RID: 1877 RVA: 0x0001A267 File Offset: 0x00018467
		[XmlArray("lts", Order = 100)]
		[SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly", Justification = "This is needed for serialization.")]
		[XmlArrayItem("l")]
		[DataMember(Name = "lts", Order = 100)]
		public StringCollection LayoutNames { get; set; }

		/// <summary>
		/// Gets or sets the collection of logger names.
		/// </summary>
		/// <value>The logger names.</value>
		// Token: 0x1700015D RID: 349
		// (get) Token: 0x06000756 RID: 1878 RVA: 0x0001A270 File Offset: 0x00018470
		// (set) Token: 0x06000757 RID: 1879 RVA: 0x0001A287 File Offset: 0x00018487
		[SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly", Justification = "Setter is needed for serialization.")]
		[DataMember(Name = "str", Order = 200)]
		[XmlArray("str", Order = 200)]
		[XmlArrayItem("l")]
		public StringCollection Strings { get; set; }

		/// <summary>
		/// Gets or sets the list of events.
		/// </summary>
		/// <value>The events.</value>
		// Token: 0x1700015E RID: 350
		// (get) Token: 0x06000758 RID: 1880 RVA: 0x0001A290 File Offset: 0x00018490
		// (set) Token: 0x06000759 RID: 1881 RVA: 0x0001A2A7 File Offset: 0x000184A7
		[XmlArrayItem("e")]
		[XmlArray("ev", Order = 1000)]
		[SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays", Justification = "This is for serialization")]
		[DataMember(Name = "ev", Order = 1000)]
		[SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly", Justification = "Setter is needed for serialization.")]
		public NLogEvent[] Events { get; set; }

		/// <summary>
		/// Converts the events to sequence of <see cref="T:NLog.LogEventInfo" /> objects suitable for routing through NLog.
		/// </summary>
		/// <param name="loggerNamePrefix">The logger name prefix to prepend in front of each logger name.</param>
		/// <returns>
		/// Sequence of <see cref="T:NLog.LogEventInfo" /> objects.
		/// </returns>
		// Token: 0x0600075A RID: 1882 RVA: 0x0001A2B0 File Offset: 0x000184B0
		public IList<LogEventInfo> ToEventInfo(string loggerNamePrefix)
		{
			LogEventInfo[] array = new LogEventInfo[this.Events.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = this.Events[i].ToEventInfo(this, loggerNamePrefix);
			}
			return array;
		}

		/// <summary>
		/// Converts the events to sequence of <see cref="T:NLog.LogEventInfo" /> objects suitable for routing through NLog.
		/// </summary>
		/// <returns>
		/// Sequence of <see cref="T:NLog.LogEventInfo" /> objects.
		/// </returns>
		// Token: 0x0600075B RID: 1883 RVA: 0x0001A2F8 File Offset: 0x000184F8
		public IList<LogEventInfo> ToEventInfo()
		{
			return this.ToEventInfo(string.Empty);
		}
	}
}
