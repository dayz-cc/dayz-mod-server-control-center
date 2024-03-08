using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using NLog.Common;
using NLog.Config;
using NLog.Internal;
using NLog.Internal.Fakeables;
using NLog.Targets;

namespace NLog
{
	/// <summary>
	/// Creates and manages instances of <see cref="T:NLog.Logger" /> objects.
	/// </summary>
	// Token: 0x020000EA RID: 234
	public sealed class LogManager
	{
		/// <summary>
		/// Initializes static members of the LogManager class.
		/// </summary>
		// Token: 0x0600070E RID: 1806 RVA: 0x0001991C File Offset: 0x00017B1C
		[SuppressMessage("Microsoft.Performance", "CA1810:InitializeReferenceTypeStaticFieldsInline", Justification = "Significant logic in .cctor()")]
		static LogManager()
		{
			try
			{
				LogManager.SetupTerminationEvents();
			}
			catch (Exception ex)
			{
				if (ex.MustBeRethrown())
				{
					throw;
				}
				InternalLogger.Warn("Error setting up termiation events: {0}", new object[] { ex });
			}
		}

		/// <summary>
		/// Prevents a default instance of the LogManager class from being created.
		/// </summary>
		// Token: 0x0600070F RID: 1807 RVA: 0x000199A0 File Offset: 0x00017BA0
		private LogManager()
		{
		}

		/// <summary>
		/// Occurs when logging <see cref="P:NLog.LogManager.Configuration" /> changes.
		/// </summary>
		// Token: 0x14000009 RID: 9
		// (add) Token: 0x06000710 RID: 1808 RVA: 0x000199AB File Offset: 0x00017BAB
		// (remove) Token: 0x06000711 RID: 1809 RVA: 0x000199BA File Offset: 0x00017BBA
		public static event EventHandler<LoggingConfigurationChangedEventArgs> ConfigurationChanged
		{
			add
			{
				LogManager.globalFactory.ConfigurationChanged += value;
			}
			remove
			{
				LogManager.globalFactory.ConfigurationChanged -= value;
			}
		}

		/// <summary>
		/// Occurs when logging <see cref="P:NLog.LogManager.Configuration" /> gets reloaded.
		/// </summary>
		// Token: 0x1400000A RID: 10
		// (add) Token: 0x06000712 RID: 1810 RVA: 0x000199C9 File Offset: 0x00017BC9
		// (remove) Token: 0x06000713 RID: 1811 RVA: 0x000199D8 File Offset: 0x00017BD8
		public static event EventHandler<LoggingConfigurationReloadedEventArgs> ConfigurationReloaded
		{
			add
			{
				LogManager.globalFactory.ConfigurationReloaded += value;
			}
			remove
			{
				LogManager.globalFactory.ConfigurationReloaded -= value;
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether NLog should throw exceptions. 
		/// By default exceptions are not thrown under any circumstances.
		/// </summary>
		// Token: 0x1700014E RID: 334
		// (get) Token: 0x06000714 RID: 1812 RVA: 0x000199E8 File Offset: 0x00017BE8
		// (set) Token: 0x06000715 RID: 1813 RVA: 0x00019A04 File Offset: 0x00017C04
		public static bool ThrowExceptions
		{
			get
			{
				return LogManager.globalFactory.ThrowExceptions;
			}
			set
			{
				LogManager.globalFactory.ThrowExceptions = value;
			}
		}

		// Token: 0x1700014F RID: 335
		// (get) Token: 0x06000716 RID: 1814 RVA: 0x00019A14 File Offset: 0x00017C14
		// (set) Token: 0x06000717 RID: 1815 RVA: 0x00019A3A File Offset: 0x00017C3A
		internal static IAppDomain CurrentAppDomain
		{
			get
			{
				IAppDomain appDomain;
				if ((appDomain = LogManager._currentAppDomain) == null)
				{
					appDomain = (LogManager._currentAppDomain = AppDomainWrapper.CurrentDomain);
				}
				return appDomain;
			}
			set
			{
				LogManager._currentAppDomain = value;
			}
		}

		/// <summary>
		/// Gets or sets the current logging configuration.
		/// </summary>
		// Token: 0x17000150 RID: 336
		// (get) Token: 0x06000718 RID: 1816 RVA: 0x00019A44 File Offset: 0x00017C44
		// (set) Token: 0x06000719 RID: 1817 RVA: 0x00019A60 File Offset: 0x00017C60
		public static LoggingConfiguration Configuration
		{
			get
			{
				return LogManager.globalFactory.Configuration;
			}
			set
			{
				LogManager.globalFactory.Configuration = value;
			}
		}

		/// <summary>
		/// Gets or sets the global log threshold. Log events below this threshold are not logged.
		/// </summary>
		// Token: 0x17000151 RID: 337
		// (get) Token: 0x0600071A RID: 1818 RVA: 0x00019A70 File Offset: 0x00017C70
		// (set) Token: 0x0600071B RID: 1819 RVA: 0x00019A8C File Offset: 0x00017C8C
		public static LogLevel GlobalThreshold
		{
			get
			{
				return LogManager.globalFactory.GlobalThreshold;
			}
			set
			{
				LogManager.globalFactory.GlobalThreshold = value;
			}
		}

		/// <summary>
		/// Gets or sets the default culture to use.
		/// </summary>
		// Token: 0x17000152 RID: 338
		// (get) Token: 0x0600071C RID: 1820 RVA: 0x00019A9C File Offset: 0x00017C9C
		// (set) Token: 0x0600071D RID: 1821 RVA: 0x00019AB3 File Offset: 0x00017CB3
		public static LogManager.GetCultureInfo DefaultCultureInfo
		{
			get
			{
				return LogManager._defaultCultureInfo;
			}
			set
			{
				LogManager._defaultCultureInfo = value;
			}
		}

		/// <summary>
		/// Gets the logger named after the currently-being-initialized class.
		/// </summary>
		/// <returns>The logger.</returns>
		/// <remarks>This is a slow-running method. 
		/// Make sure you're not doing this in a loop.</remarks>
		// Token: 0x0600071E RID: 1822 RVA: 0x00019ABC File Offset: 0x00017CBC
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Logger GetCurrentClassLogger()
		{
			int num = 1;
			MethodBase method;
			string text;
			for (;;)
			{
				StackFrame stackFrame = new StackFrame(num, false);
				method = stackFrame.GetMethod();
				Type declaringType = method.DeclaringType;
				if (declaringType == null)
				{
					break;
				}
				num++;
				text = declaringType.FullName;
				if (!declaringType.Module.Name.Equals("mscorlib.dll", StringComparison.OrdinalIgnoreCase))
				{
					goto IL_5F;
				}
			}
			text = method.Name;
			IL_5F:
			return LogManager.globalFactory.GetLogger(text);
		}

		/// <summary>
		/// Gets the logger named after the currently-being-initialized class.
		/// </summary>
		/// <param name="loggerType">The logger class. The class must inherit from <see cref="T:NLog.Logger" />.</param>
		/// <returns>The logger.</returns>
		/// <remarks>This is a slow-running method. 
		/// Make sure you're not doing this in a loop.</remarks>
		// Token: 0x0600071F RID: 1823 RVA: 0x00019B3C File Offset: 0x00017D3C
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static Logger GetCurrentClassLogger(Type loggerType)
		{
			int num = 1;
			Type declaringType;
			do
			{
				StackFrame stackFrame = new StackFrame(num, false);
				declaringType = stackFrame.GetMethod().DeclaringType;
				num++;
			}
			while (declaringType.Module.Name.Equals("mscorlib.dll", StringComparison.OrdinalIgnoreCase));
			return LogManager.globalFactory.GetLogger(declaringType.FullName, loggerType);
		}

		/// <summary>
		/// Creates a logger that discards all log messages.
		/// </summary>
		/// <returns>Null logger which discards all log messages.</returns>
		// Token: 0x06000720 RID: 1824 RVA: 0x00019B98 File Offset: 0x00017D98
		public static Logger CreateNullLogger()
		{
			return LogManager.globalFactory.CreateNullLogger();
		}

		/// <summary>
		/// Gets the specified named logger.
		/// </summary>
		/// <param name="name">Name of the logger.</param>
		/// <returns>The logger reference. Multiple calls to <c>GetLogger</c> with the same argument aren't guaranteed to return the same logger reference.</returns>
		// Token: 0x06000721 RID: 1825 RVA: 0x00019BB4 File Offset: 0x00017DB4
		public static Logger GetLogger(string name)
		{
			return LogManager.globalFactory.GetLogger(name);
		}

		/// <summary>
		/// Gets the specified named logger.
		/// </summary>
		/// <param name="name">Name of the logger.</param>
		/// <param name="loggerType">The logger class. The class must inherit from <see cref="T:NLog.Logger" />.</param>
		/// <returns>The logger reference. Multiple calls to <c>GetLogger</c> with the same argument aren't guaranteed to return the same logger reference.</returns>
		// Token: 0x06000722 RID: 1826 RVA: 0x00019BD4 File Offset: 0x00017DD4
		public static Logger GetLogger(string name, Type loggerType)
		{
			return LogManager.globalFactory.GetLogger(name, loggerType);
		}

		/// <summary>
		/// Loops through all loggers previously returned by GetLogger.
		/// and recalculates their target and filter list. Useful after modifying the configuration programmatically
		/// to ensure that all loggers have been properly configured.
		/// </summary>
		// Token: 0x06000723 RID: 1827 RVA: 0x00019BF2 File Offset: 0x00017DF2
		public static void ReconfigExistingLoggers()
		{
			LogManager.globalFactory.ReconfigExistingLoggers();
		}

		/// <summary>
		/// Flush any pending log messages (in case of asynchronous targets).
		/// </summary>
		// Token: 0x06000724 RID: 1828 RVA: 0x00019C00 File Offset: 0x00017E00
		public static void Flush()
		{
			LogManager.globalFactory.Flush();
		}

		/// <summary>
		/// Flush any pending log messages (in case of asynchronous targets).
		/// </summary>
		/// <param name="timeout">Maximum time to allow for the flush. Any messages after that time will be discarded.</param>
		// Token: 0x06000725 RID: 1829 RVA: 0x00019C0E File Offset: 0x00017E0E
		public static void Flush(TimeSpan timeout)
		{
			LogManager.globalFactory.Flush(timeout);
		}

		/// <summary>
		/// Flush any pending log messages (in case of asynchronous targets).
		/// </summary>
		/// <param name="timeoutMilliseconds">Maximum time to allow for the flush. Any messages after that time will be discarded.</param>
		// Token: 0x06000726 RID: 1830 RVA: 0x00019C1D File Offset: 0x00017E1D
		public static void Flush(int timeoutMilliseconds)
		{
			LogManager.globalFactory.Flush(timeoutMilliseconds);
		}

		/// <summary>
		/// Flush any pending log messages (in case of asynchronous targets).
		/// </summary>
		/// <param name="asyncContinuation">The asynchronous continuation.</param>
		// Token: 0x06000727 RID: 1831 RVA: 0x00019C2C File Offset: 0x00017E2C
		public static void Flush(AsyncContinuation asyncContinuation)
		{
			LogManager.globalFactory.Flush(asyncContinuation);
		}

		/// <summary>
		/// Flush any pending log messages (in case of asynchronous targets).
		/// </summary>
		/// <param name="asyncContinuation">The asynchronous continuation.</param>
		/// <param name="timeout">Maximum time to allow for the flush. Any messages after that time will be discarded.</param>
		// Token: 0x06000728 RID: 1832 RVA: 0x00019C3B File Offset: 0x00017E3B
		public static void Flush(AsyncContinuation asyncContinuation, TimeSpan timeout)
		{
			LogManager.globalFactory.Flush(asyncContinuation, timeout);
		}

		/// <summary>
		/// Flush any pending log messages (in case of asynchronous targets).
		/// </summary>
		/// <param name="asyncContinuation">The asynchronous continuation.</param>
		/// <param name="timeoutMilliseconds">Maximum time to allow for the flush. Any messages after that time will be discarded.</param>
		// Token: 0x06000729 RID: 1833 RVA: 0x00019C4B File Offset: 0x00017E4B
		public static void Flush(AsyncContinuation asyncContinuation, int timeoutMilliseconds)
		{
			LogManager.globalFactory.Flush(asyncContinuation, timeoutMilliseconds);
		}

		/// <summary>Decreases the log enable counter and if it reaches -1 
		/// the logs are disabled.</summary>
		/// <remarks>Logging is enabled if the number of <see cref="M:NLog.LogManager.EnableLogging" /> calls is greater 
		/// than or equal to <see cref="M:NLog.LogManager.DisableLogging" /> calls.</remarks>
		/// <returns>An object that iplements IDisposable whose Dispose() method
		/// reenables logging. To be used with C# <c>using ()</c> statement.</returns>
		// Token: 0x0600072A RID: 1834 RVA: 0x00019C5C File Offset: 0x00017E5C
		public static IDisposable DisableLogging()
		{
			return LogManager.globalFactory.DisableLogging();
		}

		/// <summary>Increases the log enable counter and if it reaches 0 the logs are disabled.</summary>
		/// <remarks>Logging is enabled if the number of <see cref="M:NLog.LogManager.EnableLogging" /> calls is greater 
		/// than or equal to <see cref="M:NLog.LogManager.DisableLogging" /> calls.</remarks>
		// Token: 0x0600072B RID: 1835 RVA: 0x00019C78 File Offset: 0x00017E78
		public static void EnableLogging()
		{
			LogManager.globalFactory.EnableLogging();
		}

		/// <summary>
		/// Returns <see langword="true" /> if logging is currently enabled.
		/// </summary>
		/// <returns>A value of <see langword="true" /> if logging is currently enabled, 
		/// <see langword="false" /> otherwise.</returns>
		/// <remarks>Logging is enabled if the number of <see cref="M:NLog.LogManager.EnableLogging" /> calls is greater 
		/// than or equal to <see cref="M:NLog.LogManager.DisableLogging" /> calls.</remarks>
		// Token: 0x0600072C RID: 1836 RVA: 0x00019C88 File Offset: 0x00017E88
		public static bool IsLoggingEnabled()
		{
			return LogManager.globalFactory.IsLoggingEnabled();
		}

		/// <summary>
		/// Dispose all targets, and shutdown logging.
		/// </summary>
		// Token: 0x0600072D RID: 1837 RVA: 0x00019CA4 File Offset: 0x00017EA4
		public static void Shutdown()
		{
			foreach (Target target in LogManager.Configuration.AllTargets)
			{
				target.Dispose();
			}
		}

		// Token: 0x0600072E RID: 1838 RVA: 0x00019D04 File Offset: 0x00017F04
		private static void SetupTerminationEvents()
		{
			LogManager.CurrentAppDomain.ProcessExit += LogManager.TurnOffLogging;
			LogManager.CurrentAppDomain.DomainUnload += LogManager.TurnOffLogging;
		}

		// Token: 0x0600072F RID: 1839 RVA: 0x00019D35 File Offset: 0x00017F35
		private static void TurnOffLogging(object sender, EventArgs args)
		{
			InternalLogger.Info("Shutting down logging...");
			LogManager.Configuration = null;
			InternalLogger.Info("Logger has been shut down.");
		}

		// Token: 0x04000216 RID: 534
		private static readonly LogFactory globalFactory = new LogFactory();

		// Token: 0x04000217 RID: 535
		private static IAppDomain _currentAppDomain;

		// Token: 0x04000218 RID: 536
		private static LogManager.GetCultureInfo _defaultCultureInfo = () => Thread.CurrentThread.CurrentCulture;

		/// <summary>
		/// Delegate used to the the culture to use.
		/// </summary>
		/// <returns></returns>
		// Token: 0x020000EB RID: 235
		// (Invoke) Token: 0x06000732 RID: 1842
		public delegate CultureInfo GetCultureInfo();
	}
}
