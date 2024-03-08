using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using NLog.Config;
using NLog.Internal;

namespace NLog.LayoutRenderers
{
	/// <summary>
	/// ASP Session variable.
	/// </summary>
	// Token: 0x02000098 RID: 152
	[LayoutRenderer("asp-session")]
	public class AspSessionValueLayoutRenderer : LayoutRenderer
	{
		/// <summary>
		/// Gets or sets the session variable name.
		/// </summary>
		/// <docgen category="Rendering Options" order="10" />
		// Token: 0x170000B2 RID: 178
		// (get) Token: 0x0600038D RID: 909 RVA: 0x0000DC58 File Offset: 0x0000BE58
		// (set) Token: 0x0600038E RID: 910 RVA: 0x0000DC6F File Offset: 0x0000BE6F
		[RequiredParameter]
		[DefaultParameter]
		public string Variable { get; set; }

		/// <summary>
		/// Renders the specified ASP Session variable and appends it to the specified <see cref="T:System.Text.StringBuilder" />.
		/// </summary>
		/// <param name="builder">The <see cref="T:System.Text.StringBuilder" /> to append the rendered data to.</param>
		/// <param name="logEvent">Logging event.</param>
		// Token: 0x0600038F RID: 911 RVA: 0x0000DC78 File Offset: 0x0000BE78
		protected override void Append(StringBuilder builder, LogEventInfo logEvent)
		{
			AspHelper.ISessionObject sessionObject = AspHelper.GetSessionObject();
			if (sessionObject != null)
			{
				if (this.Variable != null)
				{
					object value = sessionObject.GetValue(this.Variable);
					builder.Append(Convert.ToString(value, CultureInfo.InvariantCulture));
				}
				Marshal.ReleaseComObject(sessionObject);
			}
		}
	}
}
