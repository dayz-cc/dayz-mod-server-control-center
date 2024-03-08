using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
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
	// Token: 0x020000E3 RID: 227
	public class LogFactory : IDisposable
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.LogFactory" /> class.
		/// </summary>
		// Token: 0x0600057C RID: 1404 RVA: 0x000132A4 File Offset: 0x000114A4
		public LogFactory()
		{
			this.watcher = new MultiFileWatcher();
			this.watcher.OnChange += this.ConfigFileChanged;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.LogFactory" /> class.
		/// </summary>
		/// <param name="config">The config.</param>
		// Token: 0x0600057D RID: 1405 RVA: 0x000132F3 File Offset: 0x000114F3
		public LogFactory(LoggingConfiguration config)
			: this()
		{
			this.Configuration = config;
		}

		/// <summary>
		/// Occurs when logging <see cref="P:NLog.LogFactory.Configuration" /> changes.
		/// </summary>
		// Token: 0x14000006 RID: 6
		// (add) Token: 0x0600057E RID: 1406 RVA: 0x00013308 File Offset: 0x00011508
		// (remove) Token: 0x0600057F RID: 1407 RVA: 0x00013344 File Offset: 0x00011544
		public event EventHandler<LoggingConfigurationChangedEventArgs> ConfigurationChanged;

		/// <summary>
		/// Occurs when logging <see cref="P:NLog.LogFactory.Configuration" /> gets reloaded.
		/// </summary>
		// Token: 0x14000007 RID: 7
		// (add) Token: 0x06000580 RID: 1408 RVA: 0x00013380 File Offset: 0x00011580
		// (remove) Token: 0x06000581 RID: 1409 RVA: 0x000133BC File Offset: 0x000115BC
		public event EventHandler<LoggingConfigurationReloadedEventArgs> ConfigurationReloaded;

		/// <summary>
		/// Gets the current <see cref="T:NLog.Internal.Fakeables.IAppDomain" />.
		/// </summary>
		// Token: 0x1700013C RID: 316
		// (get) Token: 0x06000582 RID: 1410 RVA: 0x000133F8 File Offset: 0x000115F8
		// (set) Token: 0x06000583 RID: 1411 RVA: 0x0001341E File Offset: 0x0001161E
		public static IAppDomain CurrentAppDomain
		{
			get
			{
				IAppDomain appDomain;
				if ((appDomain = LogFactory.currentAppDomain) == null)
				{
					appDomain = (LogFactory.currentAppDomain = AppDomainWrapper.CurrentDomain);
				}
				return appDomain;
			}
			set
			{
				LogFactory.currentAppDomain = value;
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether exceptions should be thrown.
		/// </summary>
		/// <value>A value of <c>true</c> if exceptiosn should be thrown; otherwise, <c>false</c>.</value>
		/// <remarks>By default exceptions
		/// are not thrown under any circumstances.
		/// </remarks>
		// Token: 0x1700013D RID: 317
		// (get) Token: 0x06000584 RID: 1412 RVA: 0x00013428 File Offset: 0x00011628
		// (set) Token: 0x06000585 RID: 1413 RVA: 0x0001343F File Offset: 0x0001163F
		public bool ThrowExceptions { get; set; }

		/// <summary>
		/// Gets or sets the current logging configuration.
		/// </summary>
		// Token: 0x1700013E RID: 318
		// (get) Token: 0x06000586 RID: 1414 RVA: 0x00013448 File Offset: 0x00011648
		// (set) Token: 0x06000587 RID: 1415 RVA: 0x00013610 File Offset: 0x00011810
		public LoggingConfiguration Configuration
		{
			get
			{
				LoggingConfiguration loggingConfiguration;
				lock (this)
				{
					if (this.configLoaded)
					{
						loggingConfiguration = this.config;
					}
					else
					{
						this.configLoaded = true;
						if (this.config == null)
						{
							this.config = XmlLoggingConfiguration.AppConfig;
						}
						if (this.config == null)
						{
							foreach (string text in LogFactory.GetCandidateFileNames())
							{
								if (File.Exists(text))
								{
									InternalLogger.Debug("Attempting to load config from {0}", new object[] { text });
									this.config = new XmlLoggingConfiguration(text);
									break;
								}
							}
						}
						if (this.config != null)
						{
							LogFactory.Dump(this.config);
							try
							{
								this.watcher.Watch(this.config.FileNamesToWatch);
							}
							catch (Exception ex)
							{
								InternalLogger.Warn("Cannot start file watching: {0}. File watching is disabled", new object[] { ex });
							}
						}
						if (this.config != null)
						{
							this.config.InitializeAll();
						}
						loggingConfiguration = this.config;
					}
				}
				return loggingConfiguration;
			}
			set
			{
				try
				{
					this.watcher.StopWatching();
				}
				catch (Exception ex)
				{
					if (ex.MustBeRethrown())
					{
						throw;
					}
					InternalLogger.Error("Cannot stop file watching: {0}", new object[] { ex });
				}
				lock (this)
				{
					LoggingConfiguration loggingConfiguration = this.config;
					if (loggingConfiguration != null)
					{
						InternalLogger.Info("Closing old configuration.");
						this.Flush();
						loggingConfiguration.Close();
					}
					this.config = value;
					this.configLoaded = true;
					if (this.config != null)
					{
						LogFactory.Dump(this.config);
						this.config.InitializeAll();
						this.ReconfigExistingLoggers(this.config);
						try
						{
							this.watcher.Watch(this.config.FileNamesToWatch);
						}
						catch (Exception ex)
						{
							if (ex.MustBeRethrown())
							{
								throw;
							}
							InternalLogger.Warn("Cannot start file watching: {0}", new object[] { ex });
						}
					}
					EventHandler<LoggingConfigurationChangedEventArgs> configurationChanged = this.ConfigurationChanged;
					if (configurationChanged != null)
					{
						configurationChanged(this, new LoggingConfigurationChangedEventArgs(loggingConfiguration, value));
					}
				}
			}
		}

		/// <summary>
		/// Gets or sets the global log threshold. Log events below this threshold are not logged.
		/// </summary>
		// Token: 0x1700013F RID: 319
		// (get) Token: 0x06000588 RID: 1416 RVA: 0x00013790 File Offset: 0x00011990
		// (set) Token: 0x06000589 RID: 1417 RVA: 0x000137A8 File Offset: 0x000119A8
		public LogLevel GlobalThreshold
		{
			get
			{
				return this.globalThreshold;
			}
			set
			{
				lock (this)
				{
					this.globalThreshold = value;
					this.ReconfigExistingLoggers();
				}
			}
		}

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		// Token: 0x0600058A RID: 1418 RVA: 0x000137F8 File Offset: 0x000119F8
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// Creates a logger that discards all log messages.
		/// </summary>
		/// <returns>Null logger instance.</returns>
		// Token: 0x0600058B RID: 1419 RVA: 0x0001380C File Offset: 0x00011A0C
		public Logger CreateNullLogger()
		{
			TargetWithFilterChain[] array = new TargetWithFilterChain[LogLevel.MaxLevel.Ordinal + 1];
			Logger logger = new Logger();
			logger.Initialize(string.Empty, new LoggerConfiguration(array), this);
			return logger;
		}

		/// <summary>
		/// Gets the logger named after the currently-being-initialized class.
		/// </summary>
		/// <returns>The logger.</returns>
		/// <remarks>This is a slow-running method. 
		/// Make sure you're not doing this in a loop.</remarks>
		// Token: 0x0600058C RID: 1420 RVA: 0x0001384C File Offset: 0x00011A4C
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Logger GetCurrentClassLogger()
		{
			StackFrame stackFrame = new StackFrame(1, false);
			return this.GetLogger(stackFrame.GetMethod().DeclaringType.FullName);
		}

		/// <summary>
		/// Gets the logger named after the currently-being-initialized class.
		/// </summary>
		/// <param name="loggerType">The type of the logger to create. The type must inherit from NLog.Logger.</param>
		/// <returns>The logger.</returns>
		/// <remarks>This is a slow-running method. 
		/// Make sure you're not doing this in a loop.</remarks>
		// Token: 0x0600058D RID: 1421 RVA: 0x0001387C File Offset: 0x00011A7C
		[MethodImpl(MethodImplOptions.NoInlining)]
		public Logger GetCurrentClassLogger(Type loggerType)
		{
			StackFrame stackFrame = new StackFrame(1, false);
			return this.GetLogger(stackFrame.GetMethod().DeclaringType.FullName, loggerType);
		}

		/// <summary>
		/// Gets the specified named logger.
		/// </summary>
		/// <param name="name">Name of the logger.</param>
		/// <returns>The logger reference. Multiple calls to <c>GetLogger</c> with the same argument aren't guaranteed to return the same logger reference.</returns>
		// Token: 0x0600058E RID: 1422 RVA: 0x000138B0 File Offset: 0x00011AB0
		public Logger GetLogger(string name)
		{
			return this.GetLogger(new LogFactory.LoggerCacheKey(typeof(Logger), name));
		}

		/// <summary>
		/// Gets the specified named logger.
		/// </summary>
		/// <param name="name">Name of the logger.</param>
		/// <param name="loggerType">The type of the logger to create. The type must inherit from NLog.Logger.</param>
		/// <returns>The logger reference. Multiple calls to <c>GetLogger</c> with the 
		/// same argument aren't guaranteed to return the same logger reference.</returns>
		// Token: 0x0600058F RID: 1423 RVA: 0x000138D8 File Offset: 0x00011AD8
		public Logger GetLogger(string name, Type loggerType)
		{
			return this.GetLogger(new LogFactory.LoggerCacheKey(loggerType, name));
		}

		/// <summary>
		/// Loops through all loggers previously returned by GetLogger
		/// and recalculates their target and filter list. Useful after modifying the configuration programmatically
		/// to ensure that all loggers have been properly configured.
		/// </summary>
		// Token: 0x06000590 RID: 1424 RVA: 0x000138F7 File Offset: 0x00011AF7
		public void ReconfigExistingLoggers()
		{
			this.ReconfigExistingLoggers(this.config);
		}

		/// <summary>
		/// Flush any pending log messages (in case of asynchronous targets).
		/// </summary>
		// Token: 0x06000591 RID: 1425 RVA: 0x00013907 File Offset: 0x00011B07
		public void Flush()
		{
			this.Flush(LogFactory.defaultFlushTimeout);
		}

		/// <summary>
		/// Flush any pending log messages (in case of asynchronous targets).
		/// </summary>
		/// <param name="timeout">Maximum time to allow for the flush. Any messages after that time will be discarded.</param>
		// Token: 0x06000592 RID: 1426 RVA: 0x00013934 File Offset: 0x00011B34
		public void Flush(TimeSpan timeout)
		{
			try
			{
				AsyncHelpers.RunSynchronously(delegate(AsyncContinuation cb)
				{
					this.Flush(cb, timeout);
				});
			}
			catch (Exception ex)
			{
				if (this.ThrowExceptions)
				{
					throw;
				}
				InternalLogger.Error(ex.ToString());
			}
		}

		/// <summary>
		/// Flush any pending log messages (in case of asynchronous targets).
		/// </summary>
		/// <param name="timeoutMilliseconds">Maximum time to allow for the flush. Any messages after that time will be discarded.</param>
		// Token: 0x06000593 RID: 1427 RVA: 0x000139A8 File Offset: 0x00011BA8
		public void Flush(int timeoutMilliseconds)
		{
			this.Flush(TimeSpan.FromMilliseconds((double)timeoutMilliseconds));
		}

		/// <summary>
		/// Flush any pending log messages (in case of asynchronous targets).
		/// </summary>
		/// <param name="asyncContinuation">The asynchronous continuation.</param>
		// Token: 0x06000594 RID: 1428 RVA: 0x000139B9 File Offset: 0x00011BB9
		public void Flush(AsyncContinuation asyncContinuation)
		{
			this.Flush(asyncContinuation, TimeSpan.MaxValue);
		}

		/// <summary>
		/// Flush any pending log messages (in case of asynchronous targets).
		/// </summary>
		/// <param name="asyncContinuation">The asynchronous continuation.</param>
		/// <param name="timeoutMilliseconds">Maximum time to allow for the flush. Any messages after that time will be discarded.</param>
		// Token: 0x06000595 RID: 1429 RVA: 0x000139C9 File Offset: 0x00011BC9
		public void Flush(AsyncContinuation asyncContinuation, int timeoutMilliseconds)
		{
			this.Flush(asyncContinuation, TimeSpan.FromMilliseconds((double)timeoutMilliseconds));
		}

		/// <summary>
		/// Flush any pending log messages (in case of asynchronous targets).
		/// </summary>
		/// <param name="asyncContinuation">The asynchronous continuation.</param>
		/// <param name="timeout">Maximum time to allow for the flush. Any messages after that time will be discarded.</param>
		// Token: 0x06000596 RID: 1430 RVA: 0x000139DC File Offset: 0x00011BDC
		public void Flush(AsyncContinuation asyncContinuation, TimeSpan timeout)
		{
			try
			{
				InternalLogger.Trace("LogFactory.Flush({0})", new object[] { timeout });
				LoggingConfiguration configuration = this.Configuration;
				if (configuration != null)
				{
					InternalLogger.Trace("Flushing all targets...");
					configuration.FlushAllTargets(AsyncHelpers.WithTimeout(asyncContinuation, timeout));
				}
				else
				{
					asyncContinuation(null);
				}
			}
			catch (Exception ex)
			{
				if (this.ThrowExceptions)
				{
					throw;
				}
				InternalLogger.Error(ex.ToString());
			}
		}

		/// <summary>Decreases the log enable counter and if it reaches -1 
		/// the logs are disabled.</summary>
		/// <remarks>Logging is enabled if the number of <see cref="M:NLog.LogFactory.EnableLogging" /> calls is greater 
		/// than or equal to <see cref="M:NLog.LogFactory.DisableLogging" /> calls.</remarks>
		/// <returns>An object that iplements IDisposable whose Dispose() method
		/// reenables logging. To be used with C# <c>using ()</c> statement.</returns>
		// Token: 0x06000597 RID: 1431 RVA: 0x00013A74 File Offset: 0x00011C74
		public IDisposable DisableLogging()
		{
			lock (this)
			{
				this.logsEnabled--;
				if (this.logsEnabled == -1)
				{
					this.ReconfigExistingLoggers();
				}
			}
			return new LogFactory.LogEnabler(this);
		}

		/// <summary>Increases the log enable counter and if it reaches 0 the logs are disabled.</summary>
		/// <remarks>Logging is enabled if the number of <see cref="M:NLog.LogFactory.EnableLogging" /> calls is greater 
		/// than or equal to <see cref="M:NLog.LogFactory.DisableLogging" /> calls.</remarks>
		// Token: 0x06000598 RID: 1432 RVA: 0x00013AE8 File Offset: 0x00011CE8
		public void EnableLogging()
		{
			lock (this)
			{
				this.logsEnabled++;
				if (this.logsEnabled == 0)
				{
					this.ReconfigExistingLoggers();
				}
			}
		}

		/// <summary>
		/// Returns <see langword="true" /> if logging is currently enabled.
		/// </summary>
		/// <returns>A value of <see langword="true" /> if logging is currently enabled, 
		/// <see langword="false" /> otherwise.</returns>
		/// <remarks>Logging is enabled if the number of <see cref="M:NLog.LogFactory.EnableLogging" /> calls is greater 
		/// than or equal to <see cref="M:NLog.LogFactory.DisableLogging" /> calls.</remarks>
		// Token: 0x06000599 RID: 1433 RVA: 0x00013B50 File Offset: 0x00011D50
		public bool IsLoggingEnabled()
		{
			return this.logsEnabled >= 0;
		}

		// Token: 0x0600059A RID: 1434 RVA: 0x00013B70 File Offset: 0x00011D70
		internal void ReloadConfigOnTimer(object state)
		{
			LoggingConfiguration loggingConfiguration = (LoggingConfiguration)state;
			InternalLogger.Info("Reloading configuration...");
			lock (this)
			{
				if (this.reloadTimer != null)
				{
					this.reloadTimer.Dispose();
					this.reloadTimer = null;
				}
				this.watcher.StopWatching();
				try
				{
					if (this.Configuration != loggingConfiguration)
					{
						throw new NLogConfigurationException("Config changed in between. Not reloading.");
					}
					LoggingConfiguration loggingConfiguration2 = loggingConfiguration.Reload();
					if (loggingConfiguration2 == null)
					{
						throw new NLogConfigurationException("Configuration.Reload() returned null. Not reloading.");
					}
					this.Configuration = loggingConfiguration2;
					if (this.ConfigurationReloaded != null)
					{
						this.ConfigurationReloaded(true, null);
					}
				}
				catch (Exception ex)
				{
					if (ex.MustBeRethrown())
					{
						throw;
					}
					this.watcher.Watch(loggingConfiguration.FileNamesToWatch);
					EventHandler<LoggingConfigurationReloadedEventArgs> configurationReloaded = this.ConfigurationReloaded;
					if (configurationReloaded != null)
					{
						configurationReloaded(this, new LoggingConfigurationReloadedEventArgs(false, ex));
					}
				}
			}
		}

		// Token: 0x0600059B RID: 1435 RVA: 0x00013CBC File Offset: 0x00011EBC
		internal void ReconfigExistingLoggers(LoggingConfiguration configuration)
		{
			if (configuration != null)
			{
				configuration.EnsureInitialized();
			}
			foreach (WeakReference weakReference in this.loggerCache.Values.ToList<WeakReference>())
			{
				Logger logger = weakReference.Target as Logger;
				if (logger != null)
				{
					logger.SetConfiguration(this.GetConfigurationForLogger(logger.Name, configuration));
				}
			}
		}

		// Token: 0x0600059C RID: 1436 RVA: 0x00013D58 File Offset: 0x00011F58
		internal void GetTargetsByLevelForLogger(string name, IList<LoggingRule> rules, TargetWithFilterChain[] targetsByLevel, TargetWithFilterChain[] lastTargetsByLevel)
		{
			foreach (LoggingRule loggingRule in rules)
			{
				if (loggingRule.NameMatches(name))
				{
					for (int i = 0; i <= LogLevel.MaxLevel.Ordinal; i++)
					{
						if (i >= this.GlobalThreshold.Ordinal && loggingRule.IsLoggingEnabledForLevel(LogLevel.FromOrdinal(i)))
						{
							foreach (Target target in loggingRule.Targets)
							{
								TargetWithFilterChain targetWithFilterChain = new TargetWithFilterChain(target, loggingRule.Filters);
								if (lastTargetsByLevel[i] != null)
								{
									lastTargetsByLevel[i].NextInChain = targetWithFilterChain;
								}
								else
								{
									targetsByLevel[i] = targetWithFilterChain;
								}
								lastTargetsByLevel[i] = targetWithFilterChain;
							}
						}
					}
					this.GetTargetsByLevelForLogger(name, loggingRule.ChildRules, targetsByLevel, lastTargetsByLevel);
					if (loggingRule.Final)
					{
						break;
					}
				}
			}
			for (int i = 0; i <= LogLevel.MaxLevel.Ordinal; i++)
			{
				TargetWithFilterChain targetWithFilterChain2 = targetsByLevel[i];
				if (targetWithFilterChain2 != null)
				{
					targetWithFilterChain2.PrecalculateStackTraceUsage();
				}
			}
		}

		// Token: 0x0600059D RID: 1437 RVA: 0x00013F08 File Offset: 0x00012108
		internal LoggerConfiguration GetConfigurationForLogger(string name, LoggingConfiguration configuration)
		{
			TargetWithFilterChain[] array = new TargetWithFilterChain[LogLevel.MaxLevel.Ordinal + 1];
			TargetWithFilterChain[] array2 = new TargetWithFilterChain[LogLevel.MaxLevel.Ordinal + 1];
			if (configuration != null && this.IsLoggingEnabled())
			{
				this.GetTargetsByLevelForLogger(name, configuration.LoggingRules, array, array2);
			}
			InternalLogger.Debug("Targets for {0} by level:", new object[] { name });
			for (int i = 0; i <= LogLevel.MaxLevel.Ordinal; i++)
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "{0} =>", new object[] { LogLevel.FromOrdinal(i) });
				for (TargetWithFilterChain targetWithFilterChain = array[i]; targetWithFilterChain != null; targetWithFilterChain = targetWithFilterChain.NextInChain)
				{
					stringBuilder.AppendFormat(CultureInfo.InvariantCulture, " {0}", new object[] { targetWithFilterChain.Target.Name });
					if (targetWithFilterChain.FilterChain.Count > 0)
					{
						stringBuilder.AppendFormat(CultureInfo.InvariantCulture, " ({0} filters)", new object[] { targetWithFilterChain.FilterChain.Count });
					}
				}
				InternalLogger.Debug(stringBuilder.ToString());
			}
			return new LoggerConfiguration(array);
		}

		/// <summary>
		/// Releases unmanaged and - optionally - managed resources.
		/// </summary>
		/// <param name="disposing">True to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
		// Token: 0x0600059E RID: 1438 RVA: 0x00014080 File Offset: 0x00012280
		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				this.watcher.Dispose();
				if (this.reloadTimer != null)
				{
					this.reloadTimer.Dispose();
					this.reloadTimer = null;
				}
			}
		}

		// Token: 0x0600059F RID: 1439 RVA: 0x000143F0 File Offset: 0x000125F0
		private static IEnumerable<string> GetCandidateFileNames()
		{
			yield return Path.Combine(LogFactory.CurrentAppDomain.BaseDirectory, "NLog.config");
			string cf = LogFactory.CurrentAppDomain.ConfigurationFile;
			if (cf != null)
			{
				yield return Path.ChangeExtension(cf, ".nlog");
				IEnumerable<string> privateBinPaths = LogFactory.CurrentAppDomain.PrivateBinPath;
				if (privateBinPaths != null)
				{
					foreach (string path in privateBinPaths)
					{
						yield return Path.Combine(path, "NLog.config");
					}
				}
			}
			Assembly nlogAssembly = typeof(LogFactory).Assembly;
			if (!nlogAssembly.GlobalAssemblyCache)
			{
				if (!string.IsNullOrEmpty(nlogAssembly.Location))
				{
					yield return nlogAssembly.Location + ".nlog";
				}
			}
			yield break;
		}

		// Token: 0x060005A0 RID: 1440 RVA: 0x0001440C File Offset: 0x0001260C
		private static void Dump(LoggingConfiguration config)
		{
			if (InternalLogger.IsDebugEnabled)
			{
				config.Dump();
			}
		}

		// Token: 0x060005A1 RID: 1441 RVA: 0x00014430 File Offset: 0x00012630
		private Logger GetLogger(LogFactory.LoggerCacheKey cacheKey)
		{
			Logger logger3;
			lock (this)
			{
				WeakReference weakReference;
				if (this.loggerCache.TryGetValue(cacheKey, out weakReference))
				{
					Logger logger = weakReference.Target as Logger;
					if (logger != null)
					{
						return logger;
					}
				}
				Logger logger2;
				if (cacheKey.ConcreteType != null && cacheKey.ConcreteType != typeof(Logger))
				{
					try
					{
						logger2 = (Logger)FactoryHelper.CreateInstance(cacheKey.ConcreteType);
					}
					catch (Exception ex)
					{
						if (ex.MustBeRethrown())
						{
							throw;
						}
						if (this.ThrowExceptions)
						{
							throw;
						}
						InternalLogger.Error("Cannot create instance of specified type. Proceeding with default type instance. Exception : {0}", new object[] { ex });
						cacheKey = new LogFactory.LoggerCacheKey(typeof(Logger), cacheKey.Name);
						logger2 = new Logger();
					}
				}
				else
				{
					logger2 = new Logger();
				}
				if (cacheKey.ConcreteType != null)
				{
					logger2.Initialize(cacheKey.Name, this.GetConfigurationForLogger(cacheKey.Name, this.Configuration), this);
				}
				this.loggerCache[cacheKey] = new WeakReference(logger2);
				logger3 = logger2;
			}
			return logger3;
		}

		// Token: 0x060005A2 RID: 1442 RVA: 0x000145D4 File Offset: 0x000127D4
		private void ConfigFileChanged(object sender, EventArgs args)
		{
			InternalLogger.Info("Configuration file change detected! Reloading in {0}ms...", new object[] { 1000 });
			lock (this)
			{
				if (this.reloadTimer == null)
				{
					this.reloadTimer = new Timer(new TimerCallback(this.ReloadConfigOnTimer), this.Configuration, 1000, -1);
				}
				else
				{
					this.reloadTimer.Change(1000, -1);
				}
			}
		}

		// Token: 0x040001EE RID: 494
		private const int ReconfigAfterFileChangedTimeout = 1000;

		// Token: 0x040001EF RID: 495
		private readonly MultiFileWatcher watcher;

		// Token: 0x040001F0 RID: 496
		private static IAppDomain currentAppDomain;

		// Token: 0x040001F1 RID: 497
		private readonly Dictionary<LogFactory.LoggerCacheKey, WeakReference> loggerCache = new Dictionary<LogFactory.LoggerCacheKey, WeakReference>();

		// Token: 0x040001F2 RID: 498
		private static TimeSpan defaultFlushTimeout = TimeSpan.FromSeconds(15.0);

		// Token: 0x040001F3 RID: 499
		private Timer reloadTimer;

		// Token: 0x040001F4 RID: 500
		private LoggingConfiguration config;

		// Token: 0x040001F5 RID: 501
		private LogLevel globalThreshold = LogLevel.MinLevel;

		// Token: 0x040001F6 RID: 502
		private bool configLoaded;

		// Token: 0x040001F7 RID: 503
		private int logsEnabled;

		/// <summary>
		/// Logger cache key.
		/// </summary>
		// Token: 0x020000E4 RID: 228
		internal class LoggerCacheKey
		{
			// Token: 0x060005A4 RID: 1444 RVA: 0x00014695 File Offset: 0x00012895
			internal LoggerCacheKey(Type loggerConcreteType, string name)
			{
				this.ConcreteType = loggerConcreteType;
				this.Name = name;
			}

			// Token: 0x17000140 RID: 320
			// (get) Token: 0x060005A5 RID: 1445 RVA: 0x000146B0 File Offset: 0x000128B0
			// (set) Token: 0x060005A6 RID: 1446 RVA: 0x000146C7 File Offset: 0x000128C7
			internal Type ConcreteType { get; private set; }

			// Token: 0x17000141 RID: 321
			// (get) Token: 0x060005A7 RID: 1447 RVA: 0x000146D0 File Offset: 0x000128D0
			// (set) Token: 0x060005A8 RID: 1448 RVA: 0x000146E7 File Offset: 0x000128E7
			internal string Name { get; private set; }

			/// <summary>
			/// Serves as a hash function for a particular type.
			/// </summary>
			/// <returns>
			/// A hash code for the current <see cref="T:System.Object" />.
			/// </returns>
			// Token: 0x060005A9 RID: 1449 RVA: 0x000146F0 File Offset: 0x000128F0
			public override int GetHashCode()
			{
				return this.ConcreteType.GetHashCode() ^ this.Name.GetHashCode();
			}

			/// <summary>
			/// Determines if two objects are equal in value.
			/// </summary>
			/// <param name="o">Other object to compare to.</param>
			/// <returns>True if objects are equal, false otherwise.</returns>
			// Token: 0x060005AA RID: 1450 RVA: 0x0001471C File Offset: 0x0001291C
			public override bool Equals(object o)
			{
				LogFactory.LoggerCacheKey loggerCacheKey = o as LogFactory.LoggerCacheKey;
				return !object.ReferenceEquals(loggerCacheKey, null) && this.ConcreteType == loggerCacheKey.ConcreteType && loggerCacheKey.Name == this.Name;
			}
		}

		/// <summary>
		/// Enables logging in <see cref="M:System.IDisposable.Dispose" /> implementation.
		/// </summary>
		// Token: 0x020000E5 RID: 229
		private class LogEnabler : IDisposable
		{
			/// <summary>
			/// Initializes a new instance of the <see cref="T:NLog.LogFactory.LogEnabler" /> class.
			/// </summary>
			/// <param name="factory">The factory.</param>
			// Token: 0x060005AB RID: 1451 RVA: 0x00014770 File Offset: 0x00012970
			public LogEnabler(LogFactory factory)
			{
				this.factory = factory;
			}

			/// <summary>
			/// Enables logging.
			/// </summary>
			// Token: 0x060005AC RID: 1452 RVA: 0x00014782 File Offset: 0x00012982
			void IDisposable.Dispose()
			{
				this.factory.EnableLogging();
			}

			// Token: 0x040001FD RID: 509
			private LogFactory factory;
		}
	}
}
