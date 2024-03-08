using System;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using NLog.Config;

namespace NLog.LayoutRenderers
{
	/// <summary>
	/// Current date and time.
	/// </summary>
	// Token: 0x0200009D RID: 157
	[ThreadAgnostic]
	[LayoutRenderer("date")]
	public class DateLayoutRenderer : LayoutRenderer
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.LayoutRenderers.DateLayoutRenderer" /> class.
		/// </summary>
		// Token: 0x060003B3 RID: 947 RVA: 0x0000E2A0 File Offset: 0x0000C4A0
		public DateLayoutRenderer()
		{
			this.Format = "G";
			this.Culture = CultureInfo.InvariantCulture;
		}

		/// <summary>
		/// Gets or sets the culture used for rendering. 
		/// </summary>
		/// <docgen category="Rendering Options" order="10" />
		// Token: 0x170000BF RID: 191
		// (get) Token: 0x060003B4 RID: 948 RVA: 0x0000E2C4 File Offset: 0x0000C4C4
		// (set) Token: 0x060003B5 RID: 949 RVA: 0x0000E2DB File Offset: 0x0000C4DB
		public CultureInfo Culture { get; set; }

		/// <summary>
		/// Gets or sets the date format. Can be any argument accepted by DateTime.ToString(format).
		/// </summary>
		/// <docgen category="Rendering Options" order="10" />
		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x060003B6 RID: 950 RVA: 0x0000E2E4 File Offset: 0x0000C4E4
		// (set) Token: 0x060003B7 RID: 951 RVA: 0x0000E2FB File Offset: 0x0000C4FB
		[DefaultParameter]
		public string Format { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether to output UTC time instead of local time.
		/// </summary>
		/// <docgen category="Rendering Options" order="10" />
		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x060003B8 RID: 952 RVA: 0x0000E304 File Offset: 0x0000C504
		// (set) Token: 0x060003B9 RID: 953 RVA: 0x0000E31B File Offset: 0x0000C51B
		[DefaultValue(false)]
		public bool UniversalTime { get; set; }

		/// <summary>
		/// Renders the current date and appends it to the specified <see cref="T:System.Text.StringBuilder" />.
		/// </summary>
		/// <param name="builder">The <see cref="T:System.Text.StringBuilder" /> to append the rendered data to.</param>
		/// <param name="logEvent">Logging event.</param>
		// Token: 0x060003BA RID: 954 RVA: 0x0000E324 File Offset: 0x0000C524
		protected override void Append(StringBuilder builder, LogEventInfo logEvent)
		{
			DateTime dateTime = logEvent.TimeStamp;
			if (this.UniversalTime)
			{
				dateTime = dateTime.ToUniversalTime();
			}
			builder.Append(dateTime.ToString(this.Format, this.Culture));
		}
	}
}
