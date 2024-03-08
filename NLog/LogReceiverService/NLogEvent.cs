using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.Serialization;
using System.Text;
using System.Xml.Serialization;

namespace NLog.LogReceiverService
{
	/// <summary>
	/// Wire format for NLog Event.
	/// </summary>
	// Token: 0x020000F1 RID: 241
	[DataContract(Name = "e", Namespace = "http://nlog-project.org/ws/")]
	[XmlType(Namespace = "http://nlog-project.org/ws/")]
	[DebuggerDisplay("Event ID = {Id} Level={LevelName} Values={Values.Count}")]
	public class NLogEvent
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.LogReceiverService.NLogEvent" /> class.
		/// </summary>
		// Token: 0x06000740 RID: 1856 RVA: 0x00019F45 File Offset: 0x00018145
		public NLogEvent()
		{
			this.ValueIndexes = new List<int>();
		}

		/// <summary>
		/// Gets or sets the client-generated identifier of the event.
		/// </summary>
		// Token: 0x17000153 RID: 339
		// (get) Token: 0x06000741 RID: 1857 RVA: 0x00019F5C File Offset: 0x0001815C
		// (set) Token: 0x06000742 RID: 1858 RVA: 0x00019F73 File Offset: 0x00018173
		[DataMember(Name = "id", Order = 0)]
		[XmlElement("id", Order = 0)]
		public int Id { get; set; }

		/// <summary>
		/// Gets or sets the ordinal of the log level.
		/// </summary>
		// Token: 0x17000154 RID: 340
		// (get) Token: 0x06000743 RID: 1859 RVA: 0x00019F7C File Offset: 0x0001817C
		// (set) Token: 0x06000744 RID: 1860 RVA: 0x00019F93 File Offset: 0x00018193
		[DataMember(Name = "lv", Order = 1)]
		[XmlElement("lv", Order = 1)]
		public int LevelOrdinal { get; set; }

		/// <summary>
		/// Gets or sets the logger ordinal (index into <see cref="P:NLog.LogReceiverService.NLogEvents.Strings" />.
		/// </summary>
		/// <value>The logger ordinal.</value>
		// Token: 0x17000155 RID: 341
		// (get) Token: 0x06000745 RID: 1861 RVA: 0x00019F9C File Offset: 0x0001819C
		// (set) Token: 0x06000746 RID: 1862 RVA: 0x00019FB3 File Offset: 0x000181B3
		[DataMember(Name = "lg", Order = 2)]
		[XmlElement("lg", Order = 2)]
		public int LoggerOrdinal { get; set; }

		/// <summary>
		/// Gets or sets the time delta (in ticks) between the time of the event and base time.
		/// </summary>
		// Token: 0x17000156 RID: 342
		// (get) Token: 0x06000747 RID: 1863 RVA: 0x00019FBC File Offset: 0x000181BC
		// (set) Token: 0x06000748 RID: 1864 RVA: 0x00019FD3 File Offset: 0x000181D3
		[XmlElement("ts", Order = 3)]
		[DataMember(Name = "ts", Order = 3)]
		public long TimeDelta { get; set; }

		/// <summary>
		/// Gets or sets the message string index.
		/// </summary>
		// Token: 0x17000157 RID: 343
		// (get) Token: 0x06000749 RID: 1865 RVA: 0x00019FDC File Offset: 0x000181DC
		// (set) Token: 0x0600074A RID: 1866 RVA: 0x00019FF3 File Offset: 0x000181F3
		[DataMember(Name = "m", Order = 4)]
		[XmlElement("m", Order = 4)]
		public int MessageOrdinal { get; set; }

		/// <summary>
		/// Gets or sets the collection of layout values.
		/// </summary>
		// Token: 0x17000158 RID: 344
		// (get) Token: 0x0600074B RID: 1867 RVA: 0x00019FFC File Offset: 0x000181FC
		// (set) Token: 0x0600074C RID: 1868 RVA: 0x0001A098 File Offset: 0x00018298
		[DataMember(Name = "val", Order = 100)]
		[XmlElement("val", Order = 100)]
		public string Values
		{
			get
			{
				StringBuilder stringBuilder = new StringBuilder();
				string text = string.Empty;
				if (this.ValueIndexes != null)
				{
					foreach (int num in this.ValueIndexes)
					{
						stringBuilder.Append(text);
						stringBuilder.Append(num);
						text = "|";
					}
				}
				return stringBuilder.ToString();
			}
			set
			{
				if (this.ValueIndexes != null)
				{
					this.ValueIndexes.Clear();
				}
				else
				{
					this.ValueIndexes = new List<int>();
				}
				if (!string.IsNullOrEmpty(value))
				{
					string[] array = value.Split(new char[] { '|' });
					foreach (string text in array)
					{
						this.ValueIndexes.Add(Convert.ToInt32(text, CultureInfo.InvariantCulture));
					}
				}
			}
		}

		/// <summary>
		/// Gets the collection of indexes into <see cref="P:NLog.LogReceiverService.NLogEvents.Strings" /> array for each layout value.
		/// </summary>
		// Token: 0x17000159 RID: 345
		// (get) Token: 0x0600074D RID: 1869 RVA: 0x0001A12C File Offset: 0x0001832C
		// (set) Token: 0x0600074E RID: 1870 RVA: 0x0001A143 File Offset: 0x00018343
		[XmlIgnore]
		[IgnoreDataMember]
		internal IList<int> ValueIndexes { get; private set; }

		/// <summary>
		/// Converts the <see cref="T:NLog.LogReceiverService.NLogEvent" /> to <see cref="T:NLog.LogEventInfo" />.
		/// </summary>
		/// <param name="context">The <see cref="T:NLog.LogReceiverService.NLogEvent" /> object this <see cref="T:NLog.LogReceiverService.NLogEvent" /> is part of..</param>
		/// <param name="loggerNamePrefix">The logger name prefix to prepend in front of the logger name.</param>
		/// <returns>Converted <see cref="T:NLog.LogEventInfo" />.</returns>
		// Token: 0x0600074F RID: 1871 RVA: 0x0001A14C File Offset: 0x0001834C
		internal LogEventInfo ToEventInfo(NLogEvents context, string loggerNamePrefix)
		{
			LogEventInfo logEventInfo = new LogEventInfo(LogLevel.FromOrdinal(this.LevelOrdinal), loggerNamePrefix + context.Strings[this.LoggerOrdinal], context.Strings[this.MessageOrdinal]);
			logEventInfo.TimeStamp = new DateTime(context.BaseTimeUtc + this.TimeDelta, DateTimeKind.Utc).ToLocalTime();
			for (int i = 0; i < context.LayoutNames.Count; i++)
			{
				string text = context.LayoutNames[i];
				string text2 = context.Strings[this.ValueIndexes[i]];
				logEventInfo.Properties[text] = text2;
			}
			return logEventInfo;
		}
	}
}
