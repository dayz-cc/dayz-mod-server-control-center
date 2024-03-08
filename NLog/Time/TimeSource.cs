using System;
using NLog.Config;

namespace NLog.Time
{
	/// <summary>
	/// Defines source of current time.
	/// </summary>
	// Token: 0x02000143 RID: 323
	[NLogConfigurationItem]
	public abstract class TimeSource
	{
		/// <summary>
		/// Gets current time.
		/// </summary>
		// Token: 0x17000241 RID: 577
		// (get) Token: 0x06000A86 RID: 2694
		public abstract DateTime Time { get; }

		/// <summary>
		/// Gets or sets current global time source used in all log events.
		/// </summary>
		/// <remarks>
		/// Default time source is <see cref="T:NLog.Time.FastLocalTimeSource" />.
		/// </remarks>
		// Token: 0x17000242 RID: 578
		// (get) Token: 0x06000A87 RID: 2695 RVA: 0x0002570C File Offset: 0x0002390C
		// (set) Token: 0x06000A88 RID: 2696 RVA: 0x00025723 File Offset: 0x00023923
		public static TimeSource Current
		{
			get
			{
				return TimeSource.currentSource;
			}
			set
			{
				TimeSource.currentSource = value;
			}
		}

		/// <summary>
		/// Returns a <see cref="T:System.String" /> that represents this instance.
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.String" /> that represents this instance.
		/// </returns>
		// Token: 0x06000A89 RID: 2697 RVA: 0x0002572C File Offset: 0x0002392C
		public override string ToString()
		{
			TimeSourceAttribute timeSourceAttribute = (TimeSourceAttribute)Attribute.GetCustomAttribute(base.GetType(), typeof(TimeSourceAttribute));
			string text;
			if (timeSourceAttribute != null)
			{
				text = timeSourceAttribute.Name + " (time source)";
			}
			else
			{
				text = base.GetType().Name;
			}
			return text;
		}

		// Token: 0x0400037E RID: 894
		private static TimeSource currentSource = new FastLocalTimeSource();
	}
}
