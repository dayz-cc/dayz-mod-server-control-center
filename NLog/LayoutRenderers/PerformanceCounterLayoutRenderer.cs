using System;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using NLog.Config;

namespace NLog.LayoutRenderers
{
	/// <summary>
	/// The performance counter.
	/// </summary>
	// Token: 0x020000B6 RID: 182
	[LayoutRenderer("performancecounter")]
	public class PerformanceCounterLayoutRenderer : LayoutRenderer
	{
		/// <summary>
		/// Gets or sets the name of the counter category.
		/// </summary>
		/// <docgen category="Performance Counter Options" order="10" />
		// Token: 0x170000EB RID: 235
		// (get) Token: 0x0600044B RID: 1099 RVA: 0x0000FD40 File Offset: 0x0000DF40
		// (set) Token: 0x0600044C RID: 1100 RVA: 0x0000FD57 File Offset: 0x0000DF57
		[RequiredParameter]
		public string Category { get; set; }

		/// <summary>
		/// Gets or sets the name of the performance counter.
		/// </summary>
		/// <docgen category="Performance Counter Options" order="10" />
		// Token: 0x170000EC RID: 236
		// (get) Token: 0x0600044D RID: 1101 RVA: 0x0000FD60 File Offset: 0x0000DF60
		// (set) Token: 0x0600044E RID: 1102 RVA: 0x0000FD77 File Offset: 0x0000DF77
		[RequiredParameter]
		public string Counter { get; set; }

		/// <summary>
		/// Gets or sets the name of the performance counter instance (e.g. this.Global_).
		/// </summary>
		/// <docgen category="Performance Counter Options" order="10" />
		// Token: 0x170000ED RID: 237
		// (get) Token: 0x0600044F RID: 1103 RVA: 0x0000FD80 File Offset: 0x0000DF80
		// (set) Token: 0x06000450 RID: 1104 RVA: 0x0000FD97 File Offset: 0x0000DF97
		public string Instance { get; set; }

		/// <summary>
		/// Gets or sets the name of the machine to read the performance counter from.
		/// </summary>
		/// <docgen category="Performance Counter Options" order="10" />
		// Token: 0x170000EE RID: 238
		// (get) Token: 0x06000451 RID: 1105 RVA: 0x0000FDA0 File Offset: 0x0000DFA0
		// (set) Token: 0x06000452 RID: 1106 RVA: 0x0000FDB7 File Offset: 0x0000DFB7
		public string MachineName { get; set; }

		/// <summary>
		/// Initializes the layout renderer.
		/// </summary>
		// Token: 0x06000453 RID: 1107 RVA: 0x0000FDC0 File Offset: 0x0000DFC0
		protected override void InitializeLayoutRenderer()
		{
			base.InitializeLayoutRenderer();
			if (this.MachineName != null)
			{
				this.perfCounter = new PerformanceCounter(this.Category, this.Counter, this.Instance, this.MachineName);
			}
			else
			{
				this.perfCounter = new PerformanceCounter(this.Category, this.Counter, this.Instance, true);
			}
		}

		/// <summary>
		/// Closes the layout renderer.
		/// </summary>
		// Token: 0x06000454 RID: 1108 RVA: 0x0000FE2C File Offset: 0x0000E02C
		protected override void CloseLayoutRenderer()
		{
			base.CloseLayoutRenderer();
			if (this.perfCounter != null)
			{
				this.perfCounter.Close();
				this.perfCounter = null;
			}
		}

		/// <summary>
		/// Renders the specified environment variable and appends it to the specified <see cref="T:System.Text.StringBuilder" />.
		/// </summary>
		/// <param name="builder">The <see cref="T:System.Text.StringBuilder" /> to append the rendered data to.</param>
		/// <param name="logEvent">Logging event.</param>
		// Token: 0x06000455 RID: 1109 RVA: 0x0000FE64 File Offset: 0x0000E064
		protected override void Append(StringBuilder builder, LogEventInfo logEvent)
		{
			builder.Append(this.perfCounter.NextValue().ToString(CultureInfo.InvariantCulture));
		}

		// Token: 0x04000152 RID: 338
		private PerformanceCounter perfCounter;
	}
}
