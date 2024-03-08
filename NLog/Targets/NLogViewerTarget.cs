using System;
using System.Collections.Generic;
using NLog.Config;
using NLog.LayoutRenderers;
using NLog.Layouts;

namespace NLog.Targets
{
	/// <summary>
	/// Sends log messages to the remote instance of NLog Viewer. 
	/// </summary>
	/// <seealso href="http://nlog-project.org/wiki/NLogViewer_target">Documentation on NLog Wiki</seealso>
	/// <example>
	/// <p>
	/// To set up the target in the <a href="config.html">configuration file</a>, 
	/// use the following syntax:
	/// </p>
	/// <code lang="XML" source="examples/targets/Configuration File/NLogViewer/NLog.config" />
	/// <p>
	/// This assumes just one target and a single rule. More configuration
	/// options are described <a href="config.html">here</a>.
	/// </p>
	/// <p>
	/// To set up the log target programmatically use code like this:
	/// </p>
	/// <code lang="C#" source="examples/targets/Configuration API/NLogViewer/Simple/Example.cs" />
	/// <p>
	/// NOTE: If your receiver application is ever likely to be off-line, don't use TCP protocol
	/// or you'll get TCP timeouts and your application will crawl. 
	/// Either switch to UDP transport or use <a href="target.AsyncWrapper.html">AsyncWrapper</a> target
	/// so that your application threads will not be blocked by the timing-out connection attempts.
	/// </p>
	/// </example>
	// Token: 0x02000102 RID: 258
	[Target("NLogViewer")]
	public class NLogViewerTarget : NetworkTarget
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Targets.NLogViewerTarget" /> class.
		/// </summary>
		/// <remarks>
		/// The default value of the layout is: <code>${longdate}|${level:uppercase=true}|${logger}|${message}</code>
		/// </remarks>
		// Token: 0x060007F6 RID: 2038 RVA: 0x0001C69C File Offset: 0x0001A89C
		public NLogViewerTarget()
		{
			this.Parameters = new List<NLogViewerParameterInfo>();
			this.Renderer.Parameters = this.Parameters;
			base.NewLine = false;
		}

		/// <summary>
		/// Gets or sets a value indicating whether to include NLog-specific extensions to log4j schema.
		/// </summary>
		/// <docgen category="Payload Options" order="10" />
		// Token: 0x17000177 RID: 375
		// (get) Token: 0x060007F7 RID: 2039 RVA: 0x0001C6D8 File Offset: 0x0001A8D8
		// (set) Token: 0x060007F8 RID: 2040 RVA: 0x0001C6F5 File Offset: 0x0001A8F5
		public bool IncludeNLogData
		{
			get
			{
				return this.Renderer.IncludeNLogData;
			}
			set
			{
				this.Renderer.IncludeNLogData = value;
			}
		}

		/// <summary>
		/// Gets or sets the AppInfo field. By default it's the friendly name of the current AppDomain.
		/// </summary>
		/// <docgen category="Payload Options" order="10" />
		// Token: 0x17000178 RID: 376
		// (get) Token: 0x060007F9 RID: 2041 RVA: 0x0001C708 File Offset: 0x0001A908
		// (set) Token: 0x060007FA RID: 2042 RVA: 0x0001C725 File Offset: 0x0001A925
		public string AppInfo
		{
			get
			{
				return this.Renderer.AppInfo;
			}
			set
			{
				this.Renderer.AppInfo = value;
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether to include call site (class and method name) in the information sent over the network.
		/// </summary>
		/// <docgen category="Payload Options" order="10" />
		// Token: 0x17000179 RID: 377
		// (get) Token: 0x060007FB RID: 2043 RVA: 0x0001C738 File Offset: 0x0001A938
		// (set) Token: 0x060007FC RID: 2044 RVA: 0x0001C755 File Offset: 0x0001A955
		public bool IncludeCallSite
		{
			get
			{
				return this.Renderer.IncludeCallSite;
			}
			set
			{
				this.Renderer.IncludeCallSite = value;
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether to include source info (file name and line number) in the information sent over the network.
		/// </summary>
		/// <docgen category="Payload Options" order="10" />
		// Token: 0x1700017A RID: 378
		// (get) Token: 0x060007FD RID: 2045 RVA: 0x0001C768 File Offset: 0x0001A968
		// (set) Token: 0x060007FE RID: 2046 RVA: 0x0001C785 File Offset: 0x0001A985
		public bool IncludeSourceInfo
		{
			get
			{
				return this.Renderer.IncludeSourceInfo;
			}
			set
			{
				this.Renderer.IncludeSourceInfo = value;
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether to include <see cref="T:NLog.MappedDiagnosticsContext" /> dictionary contents.
		/// </summary>
		/// <docgen category="Payload Options" order="10" />
		// Token: 0x1700017B RID: 379
		// (get) Token: 0x060007FF RID: 2047 RVA: 0x0001C798 File Offset: 0x0001A998
		// (set) Token: 0x06000800 RID: 2048 RVA: 0x0001C7B5 File Offset: 0x0001A9B5
		public bool IncludeMdc
		{
			get
			{
				return this.Renderer.IncludeMdc;
			}
			set
			{
				this.Renderer.IncludeMdc = value;
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether to include <see cref="T:NLog.NestedDiagnosticsContext" /> stack contents.
		/// </summary>
		/// <docgen category="Payload Options" order="10" />
		// Token: 0x1700017C RID: 380
		// (get) Token: 0x06000801 RID: 2049 RVA: 0x0001C7C8 File Offset: 0x0001A9C8
		// (set) Token: 0x06000802 RID: 2050 RVA: 0x0001C7E5 File Offset: 0x0001A9E5
		public bool IncludeNdc
		{
			get
			{
				return this.Renderer.IncludeNdc;
			}
			set
			{
				this.Renderer.IncludeNdc = value;
			}
		}

		/// <summary>
		/// Gets or sets the NDC item separator.
		/// </summary>
		/// <docgen category="Payload Options" order="10" />
		// Token: 0x1700017D RID: 381
		// (get) Token: 0x06000803 RID: 2051 RVA: 0x0001C7F8 File Offset: 0x0001A9F8
		// (set) Token: 0x06000804 RID: 2052 RVA: 0x0001C815 File Offset: 0x0001AA15
		public string NdcItemSeparator
		{
			get
			{
				return this.Renderer.NdcItemSeparator;
			}
			set
			{
				this.Renderer.NdcItemSeparator = value;
			}
		}

		/// <summary>
		/// Gets the collection of parameters. Each parameter contains a mapping
		/// between NLog layout and a named parameter.
		/// </summary>
		/// <docgen category="Payload Options" order="10" />
		// Token: 0x1700017E RID: 382
		// (get) Token: 0x06000805 RID: 2053 RVA: 0x0001C828 File Offset: 0x0001AA28
		// (set) Token: 0x06000806 RID: 2054 RVA: 0x0001C83F File Offset: 0x0001AA3F
		[ArrayParameter(typeof(NLogViewerParameterInfo), "parameter")]
		public IList<NLogViewerParameterInfo> Parameters { get; private set; }

		/// <summary>
		/// Gets the layout renderer which produces Log4j-compatible XML events.
		/// </summary>
		// Token: 0x1700017F RID: 383
		// (get) Token: 0x06000807 RID: 2055 RVA: 0x0001C848 File Offset: 0x0001AA48
		public Log4JXmlEventLayoutRenderer Renderer
		{
			get
			{
				return this.layout.Renderer;
			}
		}

		/// <summary>
		/// Gets or sets the instance of <see cref="T:NLog.Layouts.Log4JXmlEventLayout" /> that is used to format log messages.
		/// </summary>
		/// <docgen category="Layout Options" order="10" />
		// Token: 0x17000180 RID: 384
		// (get) Token: 0x06000808 RID: 2056 RVA: 0x0001C868 File Offset: 0x0001AA68
		// (set) Token: 0x06000809 RID: 2057 RVA: 0x0001C880 File Offset: 0x0001AA80
		public override Layout Layout
		{
			get
			{
				return this.layout;
			}
			set
			{
			}
		}

		// Token: 0x0400024D RID: 589
		private readonly Log4JXmlEventLayout layout = new Log4JXmlEventLayout();
	}
}
