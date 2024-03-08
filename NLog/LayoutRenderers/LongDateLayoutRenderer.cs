using System;
using System.ComponentModel;
using System.Text;
using NLog.Config;

namespace NLog.LayoutRenderers
{
	/// <summary>
	/// The date and time in a long, sortable format yyyy-MM-dd HH:mm:ss.mmm.
	/// </summary>
	// Token: 0x020000AF RID: 175
	[LayoutRenderer("longdate")]
	[ThreadAgnostic]
	public class LongDateLayoutRenderer : LayoutRenderer
	{
		/// <summary>
		/// Gets or sets a value indicating whether to output UTC time instead of local time.
		/// </summary>
		/// <docgen category="Rendering Options" order="10" />
		// Token: 0x170000E0 RID: 224
		// (get) Token: 0x06000423 RID: 1059 RVA: 0x0000F7A4 File Offset: 0x0000D9A4
		// (set) Token: 0x06000424 RID: 1060 RVA: 0x0000F7BB File Offset: 0x0000D9BB
		[DefaultValue(false)]
		public bool UniversalTime { get; set; }

		/// <summary>
		/// Renders the date in the long format (yyyy-MM-dd HH:mm:ss.mmm) and appends it to the specified <see cref="T:System.Text.StringBuilder" />.
		/// </summary>
		/// <param name="builder">The <see cref="T:System.Text.StringBuilder" /> to append the rendered data to.</param>
		/// <param name="logEvent">Logging event.</param>
		// Token: 0x06000425 RID: 1061 RVA: 0x0000F7C4 File Offset: 0x0000D9C4
		protected override void Append(StringBuilder builder, LogEventInfo logEvent)
		{
			DateTime dateTime = logEvent.TimeStamp;
			if (this.UniversalTime)
			{
				dateTime = dateTime.ToUniversalTime();
			}
			builder.Append(dateTime.Year);
			builder.Append('-');
			LongDateLayoutRenderer.Append2DigitsZeroPadded(builder, dateTime.Month);
			builder.Append('-');
			LongDateLayoutRenderer.Append2DigitsZeroPadded(builder, dateTime.Day);
			builder.Append(' ');
			LongDateLayoutRenderer.Append2DigitsZeroPadded(builder, dateTime.Hour);
			builder.Append(':');
			LongDateLayoutRenderer.Append2DigitsZeroPadded(builder, dateTime.Minute);
			builder.Append(':');
			LongDateLayoutRenderer.Append2DigitsZeroPadded(builder, dateTime.Second);
			builder.Append('.');
			LongDateLayoutRenderer.Append4DigitsZeroPadded(builder, (int)(dateTime.Ticks % 10000000L) / 1000);
		}

		// Token: 0x06000426 RID: 1062 RVA: 0x0000F896 File Offset: 0x0000DA96
		private static void Append2DigitsZeroPadded(StringBuilder builder, int number)
		{
			builder.Append((char)(number / 10 + 48));
			builder.Append((char)(number % 10 + 48));
		}

		// Token: 0x06000427 RID: 1063 RVA: 0x0000F8B8 File Offset: 0x0000DAB8
		private static void Append4DigitsZeroPadded(StringBuilder builder, int number)
		{
			builder.Append((char)(number / 1000 % 10 + 48));
			builder.Append((char)(number / 100 % 10 + 48));
			builder.Append((char)(number / 10 % 10 + 48));
			builder.Append((char)(number / 1 % 10 + 48));
		}
	}
}
