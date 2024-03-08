using System;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using NLog.Internal;

namespace NLog.LayoutRenderers
{
	/// <summary>
	/// High precision timer, based on the value returned from QueryPerformanceCounter() optionally converted to seconds.
	/// </summary>
	// Token: 0x020000BC RID: 188
	[LayoutRenderer("qpc")]
	public class QueryPerformanceCounterLayoutRenderer : LayoutRenderer
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.LayoutRenderers.QueryPerformanceCounterLayoutRenderer" /> class.
		/// </summary>
		// Token: 0x06000465 RID: 1125 RVA: 0x00010197 File Offset: 0x0000E397
		public QueryPerformanceCounterLayoutRenderer()
		{
			this.Normalize = true;
			this.Difference = false;
			this.Precision = 4;
			this.AlignDecimalPoint = true;
		}

		/// <summary>
		/// Gets or sets a value indicating whether to normalize the result by subtracting 
		/// it from the result of the first call (so that it's effectively zero-based).
		/// </summary>
		/// <docgen category="Rendering Options" order="10" />
		// Token: 0x170000F1 RID: 241
		// (get) Token: 0x06000466 RID: 1126 RVA: 0x000101D4 File Offset: 0x0000E3D4
		// (set) Token: 0x06000467 RID: 1127 RVA: 0x000101EB File Offset: 0x0000E3EB
		[DefaultValue(true)]
		public bool Normalize { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether to output the difference between the result 
		/// of QueryPerformanceCounter and the previous one.
		/// </summary>
		/// <docgen category="Rendering Options" order="10" />
		// Token: 0x170000F2 RID: 242
		// (get) Token: 0x06000468 RID: 1128 RVA: 0x000101F4 File Offset: 0x0000E3F4
		// (set) Token: 0x06000469 RID: 1129 RVA: 0x0001020B File Offset: 0x0000E40B
		[DefaultValue(false)]
		public bool Difference { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether to convert the result to seconds by dividing 
		/// by the result of QueryPerformanceFrequency().
		/// </summary>
		/// <docgen category="Rendering Options" order="10" />
		// Token: 0x170000F3 RID: 243
		// (get) Token: 0x0600046A RID: 1130 RVA: 0x00010214 File Offset: 0x0000E414
		// (set) Token: 0x0600046B RID: 1131 RVA: 0x0001022F File Offset: 0x0000E42F
		[DefaultValue(true)]
		public bool Seconds
		{
			get
			{
				return !this.raw;
			}
			set
			{
				this.raw = !value;
			}
		}

		/// <summary>
		/// Gets or sets the number of decimal digits to be included in output.
		/// </summary>
		/// <docgen category="Rendering Options" order="10" />
		// Token: 0x170000F4 RID: 244
		// (get) Token: 0x0600046C RID: 1132 RVA: 0x0001023C File Offset: 0x0000E43C
		// (set) Token: 0x0600046D RID: 1133 RVA: 0x00010253 File Offset: 0x0000E453
		[DefaultValue(4)]
		public int Precision { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether to align decimal point (emit non-significant zeros).
		/// </summary>
		/// <docgen category="Rendering Options" order="10" />
		// Token: 0x170000F5 RID: 245
		// (get) Token: 0x0600046E RID: 1134 RVA: 0x0001025C File Offset: 0x0000E45C
		// (set) Token: 0x0600046F RID: 1135 RVA: 0x00010273 File Offset: 0x0000E473
		[DefaultValue(true)]
		public bool AlignDecimalPoint { get; set; }

		/// <summary>
		/// Initializes the layout renderer.
		/// </summary>
		// Token: 0x06000470 RID: 1136 RVA: 0x0001027C File Offset: 0x0000E47C
		protected override void InitializeLayoutRenderer()
		{
			base.InitializeLayoutRenderer();
			ulong num;
			if (!NativeMethods.QueryPerformanceFrequency(out num))
			{
				throw new InvalidOperationException("Cannot determine high-performance counter frequency.");
			}
			ulong num2;
			if (!NativeMethods.QueryPerformanceCounter(out num2))
			{
				throw new InvalidOperationException("Cannot determine high-performance counter value.");
			}
			this.frequency = num;
			this.firstQpcValue = num2;
			this.lastQpcValue = num2;
		}

		/// <summary>
		/// Renders the ticks value of current time and appends it to the specified <see cref="T:System.Text.StringBuilder" />.
		/// </summary>
		/// <param name="builder">The <see cref="T:System.Text.StringBuilder" /> to append the rendered data to.</param>
		/// <param name="logEvent">Logging event.</param>
		// Token: 0x06000471 RID: 1137 RVA: 0x000102D8 File Offset: 0x0000E4D8
		protected override void Append(StringBuilder builder, LogEventInfo logEvent)
		{
			ulong num;
			if (NativeMethods.QueryPerformanceCounter(out num))
			{
				ulong num2 = num;
				if (this.Difference)
				{
					num -= this.lastQpcValue;
				}
				else if (this.Normalize)
				{
					num -= this.firstQpcValue;
				}
				this.lastQpcValue = num2;
				string text;
				if (this.Seconds)
				{
					double num3 = Math.Round(num / this.frequency, this.Precision);
					text = Convert.ToString(num3, CultureInfo.InvariantCulture);
					if (this.AlignDecimalPoint)
					{
						int num4 = text.IndexOf('.');
						if (num4 == -1)
						{
							text = text + "." + new string('0', this.Precision);
						}
						else
						{
							text += new string('0', this.Precision - (text.Length - 1 - num4));
						}
					}
				}
				else
				{
					text = Convert.ToString(num, CultureInfo.InvariantCulture);
				}
				builder.Append(text);
			}
		}

		// Token: 0x04000183 RID: 387
		private bool raw;

		// Token: 0x04000184 RID: 388
		private ulong firstQpcValue;

		// Token: 0x04000185 RID: 389
		private ulong lastQpcValue;

		// Token: 0x04000186 RID: 390
		private double frequency = 1.0;
	}
}
