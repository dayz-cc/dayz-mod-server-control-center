using System;

namespace NLog.Config
{
	/// <summary>
	/// Arguments for <see cref="E:NLog.LogFactory.ConfigurationReloaded" />.
	/// </summary>
	// Token: 0x02000032 RID: 50
	public class LoggingConfigurationReloadedEventArgs : EventArgs
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Config.LoggingConfigurationReloadedEventArgs" /> class.
		/// </summary>
		/// <param name="succeeded">Whether configuration reload has succeeded.</param>
		/// <param name="exception">The exception during configuration reload.</param>
		// Token: 0x06000159 RID: 345 RVA: 0x000068FC File Offset: 0x00004AFC
		internal LoggingConfigurationReloadedEventArgs(bool succeeded, Exception exception)
		{
			this.Succeeded = succeeded;
			this.Exception = exception;
		}

		/// <summary>
		/// Gets a value indicating whether configuration reload has succeeded.
		/// </summary>
		/// <value>A value of <c>true</c> if succeeded; otherwise, <c>false</c>.</value>
		// Token: 0x1700004B RID: 75
		// (get) Token: 0x0600015A RID: 346 RVA: 0x00006918 File Offset: 0x00004B18
		// (set) Token: 0x0600015B RID: 347 RVA: 0x0000692F File Offset: 0x00004B2F
		public bool Succeeded { get; private set; }

		/// <summary>
		/// Gets the exception which occurred during configuration reload.
		/// </summary>
		/// <value>The exception.</value>
		// Token: 0x1700004C RID: 76
		// (get) Token: 0x0600015C RID: 348 RVA: 0x00006938 File Offset: 0x00004B38
		// (set) Token: 0x0600015D RID: 349 RVA: 0x0000694F File Offset: 0x00004B4F
		public Exception Exception { get; private set; }
	}
}
