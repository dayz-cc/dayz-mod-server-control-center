using System;
using System.Text;
using NLog.Config;
using NLog.Internal;
using NLog.Layouts;

namespace NLog.LayoutRenderers
{
	/// <summary>
	/// The environment variable.
	/// </summary>
	// Token: 0x0200009E RID: 158
	[LayoutRenderer("environment")]
	public class EnvironmentLayoutRenderer : LayoutRenderer
	{
		/// <summary>
		/// Gets or sets the name of the environment variable.
		/// </summary>
		/// <docgen category="Rendering Options" order="10" />
		// Token: 0x170000C2 RID: 194
		// (get) Token: 0x060003BB RID: 955 RVA: 0x0000E36C File Offset: 0x0000C56C
		// (set) Token: 0x060003BC RID: 956 RVA: 0x0000E383 File Offset: 0x0000C583
		[RequiredParameter]
		[DefaultParameter]
		public string Variable { get; set; }

		/// <summary>
		/// Renders the specified environment variable and appends it to the specified <see cref="T:System.Text.StringBuilder" />.
		/// </summary>
		/// <param name="builder">The <see cref="T:System.Text.StringBuilder" /> to append the rendered data to.</param>
		/// <param name="logEvent">Logging event.</param>
		// Token: 0x060003BD RID: 957 RVA: 0x0000E38C File Offset: 0x0000C58C
		protected override void Append(StringBuilder builder, LogEventInfo logEvent)
		{
			if (this.Variable != null)
			{
				SimpleLayout simpleLayout = new SimpleLayout(EnvironmentHelper.GetSafeEnvironmentVariable(this.Variable));
				builder.Append(simpleLayout.Render(logEvent));
			}
		}
	}
}
