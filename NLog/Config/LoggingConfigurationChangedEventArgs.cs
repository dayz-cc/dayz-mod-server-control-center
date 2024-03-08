using System;

namespace NLog.Config
{
	/// <summary>
	/// Arguments for <see cref="E:NLog.LogFactory.ConfigurationChanged" /> events.
	/// </summary>
	// Token: 0x02000031 RID: 49
	public class LoggingConfigurationChangedEventArgs : EventArgs
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Config.LoggingConfigurationChangedEventArgs" /> class.
		/// </summary>
		/// <param name="oldConfiguration">The old configuration.</param>
		/// <param name="newConfiguration">The new configuration.</param>
		// Token: 0x06000154 RID: 340 RVA: 0x0000689E File Offset: 0x00004A9E
		internal LoggingConfigurationChangedEventArgs(LoggingConfiguration oldConfiguration, LoggingConfiguration newConfiguration)
		{
			this.OldConfiguration = oldConfiguration;
			this.NewConfiguration = newConfiguration;
		}

		/// <summary>
		/// Gets the old configuration.
		/// </summary>
		/// <value>The old configuration.</value>
		// Token: 0x17000049 RID: 73
		// (get) Token: 0x06000155 RID: 341 RVA: 0x000068BC File Offset: 0x00004ABC
		// (set) Token: 0x06000156 RID: 342 RVA: 0x000068D3 File Offset: 0x00004AD3
		public LoggingConfiguration OldConfiguration { get; private set; }

		/// <summary>
		/// Gets the new configuration.
		/// </summary>
		/// <value>The new configuration.</value>
		// Token: 0x1700004A RID: 74
		// (get) Token: 0x06000157 RID: 343 RVA: 0x000068DC File Offset: 0x00004ADC
		// (set) Token: 0x06000158 RID: 344 RVA: 0x000068F3 File Offset: 0x00004AF3
		public LoggingConfiguration NewConfiguration { get; private set; }
	}
}
