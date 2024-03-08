using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace NLog.ComInterop
{
	/// <summary>
	/// NLog COM Interop LogManager interface.
	/// </summary>
	// Token: 0x02000004 RID: 4
	[Guid("7ee3af3b-ba37-45b6-8f5d-cc23bb46c698")]
	[ComVisible(true)]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	public interface IComLogManager
	{
		/// <summary>
		/// Loads NLog configuration from the specified file.
		/// </summary>
		/// <param name="fileName">The name of the file to load NLog configuration from.</param>
		// Token: 0x06000023 RID: 35
		[SuppressMessage("Microsoft.StyleCop.CSharp.OrderingRules", "SA1201:ElementsMustAppearInTheCorrectOrder", Justification = "Cannot change this, this is for backwards compatibility.")]
		void LoadConfigFromFile(string fileName);

		/// <summary>
		/// Gets or sets a value indicating whether internal messages should be written to the console.
		/// </summary>
		// Token: 0x1700000F RID: 15
		// (get) Token: 0x06000024 RID: 36
		// (set) Token: 0x06000025 RID: 37
		bool InternalLogToConsole { get; set; }

		/// <summary>
		/// Gets or sets the name of the internal log file.
		/// </summary>
		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000026 RID: 38
		// (set) Token: 0x06000027 RID: 39
		string InternalLogFile { get; set; }

		/// <summary>
		/// Gets or sets the name of the internal log level.
		/// </summary>
		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000028 RID: 40
		// (set) Token: 0x06000029 RID: 41
		string InternalLogLevel { get; set; }

		/// <summary>
		/// Creates the specified logger object and assigns a LoggerName to it.
		/// </summary>
		/// <param name="loggerName">Logger name.</param>
		/// <returns>The new logger instance.</returns>
		// Token: 0x0600002A RID: 42
		IComLogger GetLogger(string loggerName);
	}
}
