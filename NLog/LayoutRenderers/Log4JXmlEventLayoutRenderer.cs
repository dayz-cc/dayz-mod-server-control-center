using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Xml;
using NLog.Config;
using NLog.Internal;
using NLog.Internal.Fakeables;
using NLog.Targets;

namespace NLog.LayoutRenderers
{
	/// <summary>
	/// XML event description compatible with log4j, Chainsaw and NLogViewer.
	/// </summary>
	// Token: 0x020000AD RID: 173
	[LayoutRenderer("log4jxmlevent")]
	public class Log4JXmlEventLayoutRenderer : LayoutRenderer, IUsesStackTrace
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.LayoutRenderers.Log4JXmlEventLayoutRenderer" /> class.
		/// </summary>
		// Token: 0x06000407 RID: 1031 RVA: 0x0000EE64 File Offset: 0x0000D064
		public Log4JXmlEventLayoutRenderer()
			: this(AppDomainWrapper.CurrentDomain)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.LayoutRenderers.Log4JXmlEventLayoutRenderer" /> class.
		/// </summary>
		// Token: 0x06000408 RID: 1032 RVA: 0x0000EE74 File Offset: 0x0000D074
		public Log4JXmlEventLayoutRenderer(IAppDomain appDomain)
		{
			this.IncludeNLogData = true;
			this.NdcItemSeparator = " ";
			this.AppInfo = string.Format(CultureInfo.InvariantCulture, "{0}({1})", new object[]
			{
				appDomain.FriendlyName,
				ThreadIDHelper.Instance.CurrentProcessID
			});
			this.Parameters = new List<NLogViewerParameterInfo>();
		}

		/// <summary>
		/// Gets or sets a value indicating whether to include NLog-specific extensions to log4j schema.
		/// </summary>
		/// <docgen category="Payload Options" order="10" />
		// Token: 0x170000D5 RID: 213
		// (get) Token: 0x06000409 RID: 1033 RVA: 0x0000EEE4 File Offset: 0x0000D0E4
		// (set) Token: 0x0600040A RID: 1034 RVA: 0x0000EEFB File Offset: 0x0000D0FB
		[DefaultValue(true)]
		public bool IncludeNLogData { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether the XML should use spaces for indentation.
		/// </summary>
		/// <docgen category="Payload Options" order="10" />
		// Token: 0x170000D6 RID: 214
		// (get) Token: 0x0600040B RID: 1035 RVA: 0x0000EF04 File Offset: 0x0000D104
		// (set) Token: 0x0600040C RID: 1036 RVA: 0x0000EF1B File Offset: 0x0000D11B
		public bool IndentXml { get; set; }

		/// <summary>
		/// Gets or sets the AppInfo field. By default it's the friendly name of the current AppDomain.
		/// </summary>
		/// <docgen category="Payload Options" order="10" />
		// Token: 0x170000D7 RID: 215
		// (get) Token: 0x0600040D RID: 1037 RVA: 0x0000EF24 File Offset: 0x0000D124
		// (set) Token: 0x0600040E RID: 1038 RVA: 0x0000EF3B File Offset: 0x0000D13B
		public string AppInfo { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether to include call site (class and method name) in the information sent over the network.
		/// </summary>
		/// <docgen category="Payload Options" order="10" />
		// Token: 0x170000D8 RID: 216
		// (get) Token: 0x0600040F RID: 1039 RVA: 0x0000EF44 File Offset: 0x0000D144
		// (set) Token: 0x06000410 RID: 1040 RVA: 0x0000EF5B File Offset: 0x0000D15B
		public bool IncludeCallSite { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether to include source info (file name and line number) in the information sent over the network.
		/// </summary>
		/// <docgen category="Payload Options" order="10" />
		// Token: 0x170000D9 RID: 217
		// (get) Token: 0x06000411 RID: 1041 RVA: 0x0000EF64 File Offset: 0x0000D164
		// (set) Token: 0x06000412 RID: 1042 RVA: 0x0000EF7B File Offset: 0x0000D17B
		public bool IncludeSourceInfo { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether to include contents of the <see cref="T:NLog.MappedDiagnosticsContext" /> dictionary.
		/// </summary>
		/// <docgen category="Payload Options" order="10" />
		// Token: 0x170000DA RID: 218
		// (get) Token: 0x06000413 RID: 1043 RVA: 0x0000EF84 File Offset: 0x0000D184
		// (set) Token: 0x06000414 RID: 1044 RVA: 0x0000EF9B File Offset: 0x0000D19B
		public bool IncludeMdc { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether to include contents of the <see cref="T:NLog.NestedDiagnosticsContext" /> stack.
		/// </summary>
		/// <docgen category="Payload Options" order="10" />
		// Token: 0x170000DB RID: 219
		// (get) Token: 0x06000415 RID: 1045 RVA: 0x0000EFA4 File Offset: 0x0000D1A4
		// (set) Token: 0x06000416 RID: 1046 RVA: 0x0000EFBB File Offset: 0x0000D1BB
		public bool IncludeNdc { get; set; }

		/// <summary>
		/// Gets or sets the NDC item separator.
		/// </summary>
		/// <docgen category="Payload Options" order="10" />
		// Token: 0x170000DC RID: 220
		// (get) Token: 0x06000417 RID: 1047 RVA: 0x0000EFC4 File Offset: 0x0000D1C4
		// (set) Token: 0x06000418 RID: 1048 RVA: 0x0000EFDB File Offset: 0x0000D1DB
		[DefaultValue(" ")]
		public string NdcItemSeparator { get; set; }

		/// <summary>
		/// Gets the level of stack trace information required by the implementing class.
		/// </summary>
		// Token: 0x170000DD RID: 221
		// (get) Token: 0x06000419 RID: 1049 RVA: 0x0000EFE4 File Offset: 0x0000D1E4
		StackTraceUsage IUsesStackTrace.StackTraceUsage
		{
			get
			{
				StackTraceUsage stackTraceUsage;
				if (this.IncludeSourceInfo)
				{
					stackTraceUsage = StackTraceUsage.WithSource;
				}
				else if (this.IncludeCallSite)
				{
					stackTraceUsage = StackTraceUsage.WithoutSource;
				}
				else
				{
					stackTraceUsage = StackTraceUsage.None;
				}
				return stackTraceUsage;
			}
		}

		// Token: 0x170000DE RID: 222
		// (get) Token: 0x0600041A RID: 1050 RVA: 0x0000F01C File Offset: 0x0000D21C
		// (set) Token: 0x0600041B RID: 1051 RVA: 0x0000F033 File Offset: 0x0000D233
		internal IList<NLogViewerParameterInfo> Parameters { get; set; }

		// Token: 0x0600041C RID: 1052 RVA: 0x0000F03C File Offset: 0x0000D23C
		internal void AppendToStringBuilder(StringBuilder sb, LogEventInfo logEvent)
		{
			this.Append(sb, logEvent);
		}

		/// <summary>
		/// Renders the XML logging event and appends it to the specified <see cref="T:System.Text.StringBuilder" />.
		/// </summary>
		/// <param name="builder">The <see cref="T:System.Text.StringBuilder" /> to append the rendered data to.</param>
		/// <param name="logEvent">Logging event.</param>
		// Token: 0x0600041D RID: 1053 RVA: 0x0000F048 File Offset: 0x0000D248
		protected override void Append(StringBuilder builder, LogEventInfo logEvent)
		{
			XmlWriterSettings xmlWriterSettings = new XmlWriterSettings
			{
				Indent = this.IndentXml,
				ConformanceLevel = ConformanceLevel.Fragment,
				IndentChars = "  "
			};
			StringBuilder stringBuilder = new StringBuilder();
			using (XmlWriter xmlWriter = XmlWriter.Create(stringBuilder, xmlWriterSettings))
			{
				xmlWriter.WriteStartElement("log4j", "event", Log4JXmlEventLayoutRenderer.dummyNamespace);
				xmlWriter.WriteAttributeString("xmlns", "nlog", null, Log4JXmlEventLayoutRenderer.dummyNLogNamespace);
				xmlWriter.WriteAttributeString("logger", logEvent.LoggerName);
				xmlWriter.WriteAttributeString("level", logEvent.Level.Name.ToUpper(CultureInfo.InvariantCulture));
				xmlWriter.WriteAttributeString("timestamp", Convert.ToString((long)(logEvent.TimeStamp.ToUniversalTime() - Log4JXmlEventLayoutRenderer.log4jDateBase).TotalMilliseconds, CultureInfo.InvariantCulture));
				xmlWriter.WriteAttributeString("thread", Thread.CurrentThread.ManagedThreadId.ToString(CultureInfo.InvariantCulture));
				xmlWriter.WriteElementString("log4j", "message", Log4JXmlEventLayoutRenderer.dummyNamespace, logEvent.FormattedMessage);
				if (logEvent.Exception != null)
				{
					xmlWriter.WriteElementString("log4j", "throwable", Log4JXmlEventLayoutRenderer.dummyNamespace, logEvent.Exception.ToString());
				}
				if (this.IncludeNdc)
				{
					xmlWriter.WriteElementString("log4j", "NDC", Log4JXmlEventLayoutRenderer.dummyNamespace, string.Join(this.NdcItemSeparator, NestedDiagnosticsContext.GetAllMessages()));
				}
				if (logEvent.Exception != null)
				{
					xmlWriter.WriteStartElement("log4j", "throwable", Log4JXmlEventLayoutRenderer.dummyNamespace);
					xmlWriter.WriteCData(logEvent.Exception.ToString());
					xmlWriter.WriteEndElement();
				}
				if (this.IncludeCallSite || this.IncludeSourceInfo)
				{
					StackFrame userStackFrame = logEvent.UserStackFrame;
					if (userStackFrame != null)
					{
						MethodBase method = userStackFrame.GetMethod();
						Type declaringType = method.DeclaringType;
						xmlWriter.WriteStartElement("log4j", "locationInfo", Log4JXmlEventLayoutRenderer.dummyNamespace);
						if (declaringType != null)
						{
							xmlWriter.WriteAttributeString("class", declaringType.FullName);
						}
						xmlWriter.WriteAttributeString("method", method.ToString());
						if (this.IncludeSourceInfo)
						{
							xmlWriter.WriteAttributeString("file", userStackFrame.GetFileName());
							xmlWriter.WriteAttributeString("line", userStackFrame.GetFileLineNumber().ToString(CultureInfo.InvariantCulture));
						}
						xmlWriter.WriteEndElement();
						if (this.IncludeNLogData)
						{
							xmlWriter.WriteElementString("nlog", "eventSequenceNumber", Log4JXmlEventLayoutRenderer.dummyNLogNamespace, logEvent.SequenceID.ToString(CultureInfo.InvariantCulture));
							xmlWriter.WriteStartElement("nlog", "locationInfo", Log4JXmlEventLayoutRenderer.dummyNLogNamespace);
							if (declaringType != null)
							{
								xmlWriter.WriteAttributeString("assembly", declaringType.Assembly.FullName);
							}
							xmlWriter.WriteEndElement();
							xmlWriter.WriteStartElement("nlog", "properties", Log4JXmlEventLayoutRenderer.dummyNLogNamespace);
							foreach (KeyValuePair<object, object> keyValuePair in logEvent.Properties)
							{
								xmlWriter.WriteStartElement("nlog", "data", Log4JXmlEventLayoutRenderer.dummyNLogNamespace);
								xmlWriter.WriteAttributeString("name", Convert.ToString(keyValuePair.Key, CultureInfo.InvariantCulture));
								xmlWriter.WriteAttributeString("value", Convert.ToString(keyValuePair.Value, CultureInfo.InvariantCulture));
								xmlWriter.WriteEndElement();
							}
							xmlWriter.WriteEndElement();
						}
					}
				}
				xmlWriter.WriteStartElement("log4j", "properties", Log4JXmlEventLayoutRenderer.dummyNamespace);
				if (this.IncludeMdc)
				{
					foreach (KeyValuePair<string, string> keyValuePair2 in MappedDiagnosticsContext.ThreadDictionary)
					{
						xmlWriter.WriteStartElement("log4j", "data", Log4JXmlEventLayoutRenderer.dummyNamespace);
						xmlWriter.WriteAttributeString("name", keyValuePair2.Key);
						xmlWriter.WriteAttributeString("value", keyValuePair2.Value);
						xmlWriter.WriteEndElement();
					}
				}
				foreach (NLogViewerParameterInfo nlogViewerParameterInfo in this.Parameters)
				{
					xmlWriter.WriteStartElement("log4j", "data", Log4JXmlEventLayoutRenderer.dummyNamespace);
					xmlWriter.WriteAttributeString("name", nlogViewerParameterInfo.Name);
					xmlWriter.WriteAttributeString("value", nlogViewerParameterInfo.Layout.Render(logEvent));
					xmlWriter.WriteEndElement();
				}
				xmlWriter.WriteStartElement("log4j", "data", Log4JXmlEventLayoutRenderer.dummyNamespace);
				xmlWriter.WriteAttributeString("name", "log4japp");
				xmlWriter.WriteAttributeString("value", this.AppInfo);
				xmlWriter.WriteEndElement();
				xmlWriter.WriteStartElement("log4j", "data", Log4JXmlEventLayoutRenderer.dummyNamespace);
				xmlWriter.WriteAttributeString("name", "log4jmachinename");
				xmlWriter.WriteAttributeString("value", Environment.MachineName);
				xmlWriter.WriteEndElement();
				xmlWriter.WriteEndElement();
				xmlWriter.WriteEndElement();
				xmlWriter.Flush();
				stringBuilder.Replace(" xmlns:log4j=\"" + Log4JXmlEventLayoutRenderer.dummyNamespace + "\"", string.Empty);
				stringBuilder.Replace(" xmlns:nlog=\"" + Log4JXmlEventLayoutRenderer.dummyNLogNamespace + "\"", string.Empty);
				builder.Append(stringBuilder.ToString());
			}
		}

		// Token: 0x0400013A RID: 314
		private static readonly DateTime log4jDateBase = new DateTime(1970, 1, 1);

		// Token: 0x0400013B RID: 315
		private static readonly string dummyNamespace = "http://nlog-project.org/dummynamespace/" + Guid.NewGuid();

		// Token: 0x0400013C RID: 316
		private static readonly string dummyNLogNamespace = "http://nlog-project.org/dummynamespace/" + Guid.NewGuid();
	}
}
