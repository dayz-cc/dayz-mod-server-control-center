using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using NLog.Config;
using NLog.Internal;

namespace NLog.LayoutRenderers
{
	/// <summary>
	/// ASP Application variable.
	/// </summary>
	// Token: 0x02000096 RID: 150
	[LayoutRenderer("asp-application")]
	public class AspApplicationValueLayoutRenderer : LayoutRenderer
	{
		/// <summary>
		/// Gets or sets the ASP Application variable name.
		/// </summary>
		/// <docgen category="Rendering Options" order="10" />
		// Token: 0x170000AC RID: 172
		// (get) Token: 0x0600037C RID: 892 RVA: 0x0000D970 File Offset: 0x0000BB70
		// (set) Token: 0x0600037D RID: 893 RVA: 0x0000D987 File Offset: 0x0000BB87
		[RequiredParameter]
		[DefaultParameter]
		public string Variable { get; set; }

		/// <summary>
		/// Renders the specified ASP Application variable and appends it to the specified <see cref="T:System.Text.StringBuilder" />.
		/// </summary>
		/// <param name="builder">The <see cref="T:System.Text.StringBuilder" /> to append the rendered data to.</param>
		/// <param name="logEvent">Logging event.</param>
		// Token: 0x0600037E RID: 894 RVA: 0x0000D990 File Offset: 0x0000BB90
		protected override void Append(StringBuilder builder, LogEventInfo logEvent)
		{
			AspHelper.IApplicationObject applicationObject = AspHelper.GetApplicationObject();
			if (applicationObject != null)
			{
				if (this.Variable != null)
				{
					object value = applicationObject.GetValue(this.Variable);
					builder.Append(Convert.ToString(value, CultureInfo.InvariantCulture));
				}
				Marshal.ReleaseComObject(applicationObject);
			}
		}
	}
}
