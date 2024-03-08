using System;
using System.Runtime.InteropServices;
using NLog.Common;
using NLog.Config;

namespace NLog.ComInterop
{
	/// <summary>
	/// NLog COM Interop LogManager implementation.
	/// </summary>
	// Token: 0x02000005 RID: 5
	[ComVisible(true)]
	[Guid("9a7e8d84-72e4-478a-9a05-23c7ef0cfca8")]
	[ClassInterface(ClassInterfaceType.None)]
	[ProgId("NLog.LogManager")]
	public class ComLogManager : IComLogManager
	{
		/// <summary>
		/// Gets or sets a value indicating whether to log internal messages to the console.
		/// </summary>
		/// <value>
		/// A value of <c>true</c> if internal messages should be logged to the console; otherwise, <c>false</c>.
		/// </value>
		// Token: 0x17000012 RID: 18
		// (get) Token: 0x0600002B RID: 43 RVA: 0x00002284 File Offset: 0x00000484
		// (set) Token: 0x0600002C RID: 44 RVA: 0x0000229B File Offset: 0x0000049B
		public bool InternalLogToConsole
		{
			get
			{
				return InternalLogger.LogToConsole;
			}
			set
			{
				InternalLogger.LogToConsole = value;
			}
		}

		/// <summary>
		/// Gets or sets the name of the internal log level.
		/// </summary>
		/// <value></value>
		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600002D RID: 45 RVA: 0x000022A8 File Offset: 0x000004A8
		// (set) Token: 0x0600002E RID: 46 RVA: 0x000022C4 File Offset: 0x000004C4
		public string InternalLogLevel
		{
			get
			{
				return InternalLogger.LogLevel.ToString();
			}
			set
			{
				InternalLogger.LogLevel = LogLevel.FromString(value);
			}
		}

		/// <summary>
		/// Gets or sets the name of the internal log file.
		/// </summary>
		/// <value></value>
		// Token: 0x17000014 RID: 20
		// (get) Token: 0x0600002F RID: 47 RVA: 0x000022D4 File Offset: 0x000004D4
		// (set) Token: 0x06000030 RID: 48 RVA: 0x000022EB File Offset: 0x000004EB
		public string InternalLogFile
		{
			get
			{
				return InternalLogger.LogFile;
			}
			set
			{
				InternalLogger.LogFile = value;
			}
		}

		/// <summary>
		/// Creates the specified logger object and assigns a LoggerName to it.
		/// </summary>
		/// <param name="loggerName">The name of the logger.</param>
		/// <returns>The new logger instance.</returns>
		// Token: 0x06000031 RID: 49 RVA: 0x000022F8 File Offset: 0x000004F8
		public IComLogger GetLogger(string loggerName)
		{
			return new ComLogger
			{
				LoggerName = loggerName
			};
		}

		/// <summary>
		/// Loads NLog configuration from the specified file.
		/// </summary>
		/// <param name="fileName">The name of the file to load NLog configuration from.</param>
		// Token: 0x06000032 RID: 50 RVA: 0x0000231B File Offset: 0x0000051B
		public void LoadConfigFromFile(string fileName)
		{
			LogManager.Configuration = new XmlLoggingConfiguration(fileName);
		}
	}
}
