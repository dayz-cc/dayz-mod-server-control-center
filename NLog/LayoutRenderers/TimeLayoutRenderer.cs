using System;
using System.ComponentModel;
using System.Text;
using NLog.Config;

namespace NLog.LayoutRenderers
{
	/// <summary>
	/// The time in a 24-hour, sortable format HH:mm:ss.mmm.
	/// </summary>
	// Token: 0x020000C6 RID: 198
	[LayoutRenderer("time")]
	[ThreadAgnostic]
	public class TimeLayoutRenderer : LayoutRenderer
	{
		/// <summary>
		/// Gets or sets a value indicating whether to output UTC time instead of local time.
		/// </summary>
		/// <docgen category="Rendering Options" order="10" />
		// Token: 0x17000103 RID: 259
		// (get) Token: 0x0600049C RID: 1180 RVA: 0x00010AAC File Offset: 0x0000ECAC
		// (set) Token: 0x0600049D RID: 1181 RVA: 0x00010AC3 File Offset: 0x0000ECC3
		[DefaultValue(false)]
		public bool UniversalTime { get; set; }

		/// <summary>
		/// Renders time in the 24-h format (HH:mm:ss.mmm) and appends it to the specified <see cref="T:System.Text.StringBuilder" />.
		/// </summary>
		/// <param name="builder">The <see cref="T:System.Text.StringBuilder" /> to append the rendered data to.</param>
		/// <param name="logEvent">Logging event.</param>
		// Token: 0x0600049E RID: 1182 RVA: 0x00010ACC File Offset: 0x0000ECCC
		protected override void Append(StringBuilder builder, LogEventInfo logEvent)
		{
			DateTime dateTime = logEvent.TimeStamp;
			if (this.UniversalTime)
			{
				dateTime = dateTime.ToUniversalTime();
			}
			TimeLayoutRenderer.Append2DigitsZeroPadded(builder, dateTime.Hour);
			builder.Append(':');
			TimeLayoutRenderer.Append2DigitsZeroPadded(builder, dateTime.Minute);
			builder.Append(':');
			TimeLayoutRenderer.Append2DigitsZeroPadded(builder, dateTime.Second);
			builder.Append('.');
			TimeLayoutRenderer.Append4DigitsZeroPadded(builder, (int)(dateTime.Ticks % 10000000L) / 1000);
		}

		// Token: 0x0600049F RID: 1183 RVA: 0x00010B59 File Offset: 0x0000ED59
		private static void Append2DigitsZeroPadded(StringBuilder builder, int number)
		{
			builder.Append((char)(number / 10 + 48));
			builder.Append((char)(number % 10 + 48));
		}

		// Token: 0x060004A0 RID: 1184 RVA: 0x00010B7C File Offset: 0x0000ED7C
		private static void Append4DigitsZeroPadded(StringBuilder builder, int number)
		{
			builder.Append((char)(number / 1000 % 10 + 48));
			builder.Append((char)(number / 100 % 10 + 48));
			builder.Append((char)(number / 10 % 10 + 48));
			builder.Append((char)(number / 1 % 10 + 48));
		}
	}
}
