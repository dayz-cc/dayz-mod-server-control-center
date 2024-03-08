using System;
using System.Globalization;
using System.Text;
using NLog.Config;

namespace NLog.LayoutRenderers
{
	/// <summary>
	/// Installation parameter (passed to InstallNLogConfig).
	/// </summary>
	// Token: 0x020000A9 RID: 169
	[LayoutRenderer("install-context")]
	public class InstallContextLayoutRenderer : LayoutRenderer
	{
		/// <summary>
		/// Gets or sets the name of the parameter.
		/// </summary>
		/// <docgen category="Rendering Options" order="10" />
		// Token: 0x170000D3 RID: 211
		// (get) Token: 0x060003FB RID: 1019 RVA: 0x0000ED88 File Offset: 0x0000CF88
		// (set) Token: 0x060003FC RID: 1020 RVA: 0x0000ED9F File Offset: 0x0000CF9F
		[RequiredParameter]
		[DefaultParameter]
		public string Parameter { get; set; }

		/// <summary>
		/// Renders the specified installation parameter and appends it to the specified <see cref="T:System.Text.StringBuilder" />.
		/// </summary>
		/// <param name="builder">The <see cref="T:System.Text.StringBuilder" /> to append the rendered data to.</param>
		/// <param name="logEvent">Logging event.</param>
		// Token: 0x060003FD RID: 1021 RVA: 0x0000EDA8 File Offset: 0x0000CFA8
		protected override void Append(StringBuilder builder, LogEventInfo logEvent)
		{
			object obj;
			if (logEvent.Properties.TryGetValue(this.Parameter, out obj))
			{
				builder.Append(Convert.ToString(obj, CultureInfo.InvariantCulture));
			}
		}
	}
}
