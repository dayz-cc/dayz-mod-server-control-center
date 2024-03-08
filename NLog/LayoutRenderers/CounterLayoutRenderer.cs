using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text;

namespace NLog.LayoutRenderers
{
	/// <summary>
	/// A counter value (increases on each layout rendering).
	/// </summary>
	// Token: 0x0200009C RID: 156
	[LayoutRenderer("counter")]
	public class CounterLayoutRenderer : LayoutRenderer
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.LayoutRenderers.CounterLayoutRenderer" /> class.
		/// </summary>
		// Token: 0x060003A9 RID: 937 RVA: 0x0000E13B File Offset: 0x0000C33B
		public CounterLayoutRenderer()
		{
			this.Increment = 1;
			this.Value = 1;
		}

		/// <summary>
		/// Gets or sets the initial value of the counter.
		/// </summary>
		/// <docgen category="Counter Options" order="10" />
		// Token: 0x170000BC RID: 188
		// (get) Token: 0x060003AA RID: 938 RVA: 0x0000E158 File Offset: 0x0000C358
		// (set) Token: 0x060003AB RID: 939 RVA: 0x0000E16F File Offset: 0x0000C36F
		[DefaultValue(1)]
		public int Value { get; set; }

		/// <summary>
		/// Gets or sets the value to be added to the counter after each layout rendering.
		/// </summary>
		/// <docgen category="Counter Options" order="10" />
		// Token: 0x170000BD RID: 189
		// (get) Token: 0x060003AC RID: 940 RVA: 0x0000E178 File Offset: 0x0000C378
		// (set) Token: 0x060003AD RID: 941 RVA: 0x0000E18F File Offset: 0x0000C38F
		[DefaultValue(1)]
		public int Increment { get; set; }

		/// <summary>
		/// Gets or sets the name of the sequence. Different named sequences can have individual values.
		/// </summary>
		/// <docgen category="Counter Options" order="10" />
		// Token: 0x170000BE RID: 190
		// (get) Token: 0x060003AE RID: 942 RVA: 0x0000E198 File Offset: 0x0000C398
		// (set) Token: 0x060003AF RID: 943 RVA: 0x0000E1AF File Offset: 0x0000C3AF
		public string Sequence { get; set; }

		/// <summary>
		/// Renders the specified counter value and appends it to the specified <see cref="T:System.Text.StringBuilder" />.
		/// </summary>
		/// <param name="builder">The <see cref="T:System.Text.StringBuilder" /> to append the rendered data to.</param>
		/// <param name="logEvent">Logging event.</param>
		// Token: 0x060003B0 RID: 944 RVA: 0x0000E1B8 File Offset: 0x0000C3B8
		protected override void Append(StringBuilder builder, LogEventInfo logEvent)
		{
			int num;
			if (this.Sequence != null)
			{
				num = CounterLayoutRenderer.GetNextSequenceValue(this.Sequence, this.Value, this.Increment);
			}
			else
			{
				num = this.Value;
				this.Value += this.Increment;
			}
			builder.Append(num.ToString(CultureInfo.InvariantCulture));
		}

		// Token: 0x060003B1 RID: 945 RVA: 0x0000E220 File Offset: 0x0000C420
		private static int GetNextSequenceValue(string sequenceName, int defaultValue, int increment)
		{
			int num3;
			lock (CounterLayoutRenderer.sequences)
			{
				int num;
				if (!CounterLayoutRenderer.sequences.TryGetValue(sequenceName, out num))
				{
					num = defaultValue;
				}
				int num2 = num;
				num += increment;
				CounterLayoutRenderer.sequences[sequenceName] = num;
				num3 = num2;
			}
			return num3;
		}

		// Token: 0x04000115 RID: 277
		private static Dictionary<string, int> sequences = new Dictionary<string, int>();
	}
}
