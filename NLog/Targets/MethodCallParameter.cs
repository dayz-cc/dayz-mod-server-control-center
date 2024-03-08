using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using NLog.Config;
using NLog.Layouts;

namespace NLog.Targets
{
	/// <summary>
	/// A parameter to MethodCall.
	/// </summary>
	// Token: 0x0200011B RID: 283
	[NLogConfigurationItem]
	public class MethodCallParameter
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Targets.MethodCallParameter" /> class.
		/// </summary>
		// Token: 0x06000960 RID: 2400 RVA: 0x00021A1C File Offset: 0x0001FC1C
		public MethodCallParameter()
		{
			this.Type = typeof(string);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Targets.MethodCallParameter" /> class.
		/// </summary>
		/// <param name="layout">The layout to use for parameter value.</param>
		// Token: 0x06000961 RID: 2401 RVA: 0x00021A38 File Offset: 0x0001FC38
		public MethodCallParameter(Layout layout)
		{
			this.Type = typeof(string);
			this.Layout = layout;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Targets.MethodCallParameter" /> class.
		/// </summary>
		/// <param name="parameterName">Name of the parameter.</param>
		/// <param name="layout">The layout.</param>
		// Token: 0x06000962 RID: 2402 RVA: 0x00021A5C File Offset: 0x0001FC5C
		public MethodCallParameter(string parameterName, Layout layout)
		{
			this.Type = typeof(string);
			this.Name = parameterName;
			this.Layout = layout;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Targets.MethodCallParameter" /> class.
		/// </summary>
		/// <param name="name">The name of the parameter.</param>
		/// <param name="layout">The layout.</param>
		/// <param name="type">The type of the parameter.</param>
		// Token: 0x06000963 RID: 2403 RVA: 0x00021A88 File Offset: 0x0001FC88
		public MethodCallParameter(string name, Layout layout, Type type)
		{
			this.Type = type;
			this.Name = name;
			this.Layout = layout;
		}

		/// <summary>
		/// Gets or sets the name of the parameter.
		/// </summary>
		/// <docgen category="Parameter Options" order="10" />
		// Token: 0x170001F1 RID: 497
		// (get) Token: 0x06000964 RID: 2404 RVA: 0x00021AAC File Offset: 0x0001FCAC
		// (set) Token: 0x06000965 RID: 2405 RVA: 0x00021AC3 File Offset: 0x0001FCC3
		public string Name { get; set; }

		/// <summary>
		/// Gets or sets the type of the parameter.
		/// </summary>
		/// <docgen category="Parameter Options" order="10" />
		// Token: 0x170001F2 RID: 498
		// (get) Token: 0x06000966 RID: 2406 RVA: 0x00021ACC File Offset: 0x0001FCCC
		// (set) Token: 0x06000967 RID: 2407 RVA: 0x00021AE3 File Offset: 0x0001FCE3
		[SuppressMessage("Microsoft.Naming", "CA1721:PropertyNamesShouldNotMatchGetMethods", Justification = "Backwards compatibility")]
		public Type Type { get; set; }

		/// <summary>
		/// Gets or sets the layout that should be use to calcuate the value for the parameter.
		/// </summary>
		/// <docgen category="Parameter Options" order="10" />
		// Token: 0x170001F3 RID: 499
		// (get) Token: 0x06000968 RID: 2408 RVA: 0x00021AEC File Offset: 0x0001FCEC
		// (set) Token: 0x06000969 RID: 2409 RVA: 0x00021B03 File Offset: 0x0001FD03
		[RequiredParameter]
		public Layout Layout { get; set; }

		// Token: 0x0600096A RID: 2410 RVA: 0x00021B0C File Offset: 0x0001FD0C
		internal object GetValue(LogEventInfo logEvent)
		{
			return Convert.ChangeType(this.Layout.Render(logEvent), this.Type, CultureInfo.InvariantCulture);
		}
	}
}
