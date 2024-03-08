using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using NLog.Common;
using NLog.Internal;
using NLog.Targets;

namespace NLog.Config
{
	/// <summary>
	/// Keeps logging configuration and provides simple API
	/// to modify it.
	/// </summary>
	// Token: 0x02000030 RID: 48
	public class LoggingConfiguration
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Config.LoggingConfiguration" /> class.
		/// </summary>
		// Token: 0x0600013F RID: 319 RVA: 0x00006006 File Offset: 0x00004206
		public LoggingConfiguration()
		{
			this.LoggingRules = new List<LoggingRule>();
		}

		/// <summary>
		/// Gets a collection of named targets specified in the configuration.
		/// </summary>
		/// <returns>
		/// A list of named targets.
		/// </returns>
		/// <remarks>
		/// Unnamed targets (such as those wrapped by other targets) are not returned.
		/// </remarks>
		// Token: 0x17000044 RID: 68
		// (get) Token: 0x06000140 RID: 320 RVA: 0x00006030 File Offset: 0x00004230
		public ReadOnlyCollection<Target> ConfiguredNamedTargets
		{
			get
			{
				return new List<Target>(this.targets.Values).AsReadOnly();
			}
		}

		/// <summary>
		/// Gets the collection of file names which should be watched for changes by NLog.
		/// </summary>
		// Token: 0x17000045 RID: 69
		// (get) Token: 0x06000141 RID: 321 RVA: 0x00006058 File Offset: 0x00004258
		public virtual IEnumerable<string> FileNamesToWatch
		{
			get
			{
				return new string[0];
			}
		}

		/// <summary>
		/// Gets the collection of logging rules.
		/// </summary>
		// Token: 0x17000046 RID: 70
		// (get) Token: 0x06000142 RID: 322 RVA: 0x00006070 File Offset: 0x00004270
		// (set) Token: 0x06000143 RID: 323 RVA: 0x00006087 File Offset: 0x00004287
		public IList<LoggingRule> LoggingRules { get; private set; }

		/// <summary>
		/// Gets or sets the default culture info use.
		/// </summary>
		// Token: 0x17000047 RID: 71
		// (get) Token: 0x06000144 RID: 324 RVA: 0x00006090 File Offset: 0x00004290
		// (set) Token: 0x06000145 RID: 325 RVA: 0x000060CC File Offset: 0x000042CC
		public CultureInfo DefaultCultureInfo
		{
			get
			{
				return LogManager.DefaultCultureInfo();
			}
			set
			{
				LogManager.DefaultCultureInfo = () => value;
			}
		}

		/// <summary>
		/// Gets all targets.
		/// </summary>
		// Token: 0x17000048 RID: 72
		// (get) Token: 0x06000146 RID: 326 RVA: 0x000060FC File Offset: 0x000042FC
		public ReadOnlyCollection<Target> AllTargets
		{
			get
			{
				return this.configItems.OfType<Target>().ToList<Target>().AsReadOnly();
			}
		}

		/// <summary>
		/// Registers the specified target object under a given name.
		/// </summary>
		/// <param name="name">
		/// Name of the target.
		/// </param>
		/// <param name="target">
		/// The target object.
		/// </param>
		// Token: 0x06000147 RID: 327 RVA: 0x00006124 File Offset: 0x00004324
		public void AddTarget(string name, Target target)
		{
			if (name == null)
			{
				throw new ArgumentException("Target name cannot be null", "name");
			}
			InternalLogger.Debug("Registering target {0}: {1}", new object[]
			{
				name,
				target.GetType().FullName
			});
			this.targets[name] = target;
		}

		/// <summary>
		/// Finds the target with the specified name.
		/// </summary>
		/// <param name="name">
		/// The name of the target to be found.
		/// </param>
		/// <returns>
		/// Found target or <see langword="null" /> when the target is not found.
		/// </returns>
		// Token: 0x06000148 RID: 328 RVA: 0x00006184 File Offset: 0x00004384
		public Target FindTargetByName(string name)
		{
			Target target;
			Target target2;
			if (!this.targets.TryGetValue(name, out target))
			{
				target2 = null;
			}
			else
			{
				target2 = target;
			}
			return target2;
		}

		/// <summary>
		/// Called by LogManager when one of the log configuration files changes.
		/// </summary>
		/// <returns>
		/// A new instance of <see cref="T:NLog.Config.LoggingConfiguration" /> that represents the updated configuration.
		/// </returns>
		// Token: 0x06000149 RID: 329 RVA: 0x000061B0 File Offset: 0x000043B0
		public virtual LoggingConfiguration Reload()
		{
			return this;
		}

		/// <summary>
		/// Removes the specified named target.
		/// </summary>
		/// <param name="name">
		/// Name of the target.
		/// </param>
		// Token: 0x0600014A RID: 330 RVA: 0x000061C3 File Offset: 0x000043C3
		public void RemoveTarget(string name)
		{
			this.targets.Remove(name);
		}

		/// <summary>
		/// Installs target-specific objects on current system.
		/// </summary>
		/// <param name="installationContext">The installation context.</param>
		/// <remarks>
		/// Installation typically runs with administrative permissions.
		/// </remarks>
		// Token: 0x0600014B RID: 331 RVA: 0x000061D4 File Offset: 0x000043D4
		public void Install(InstallationContext installationContext)
		{
			if (installationContext == null)
			{
				throw new ArgumentNullException("installationContext");
			}
			this.InitializeAll();
			foreach (IInstallable installable in this.configItems.OfType<IInstallable>())
			{
				installationContext.Info("Installing '{0}'", new object[] { installable });
				try
				{
					installable.Install(installationContext);
					installationContext.Info("Finished installing '{0}'.", new object[] { installable });
				}
				catch (Exception ex)
				{
					if (ex.MustBeRethrown())
					{
						throw;
					}
					installationContext.Error("'{0}' installation failed: {1}.", new object[] { installable, ex });
				}
			}
		}

		/// <summary>
		/// Uninstalls target-specific objects from current system.
		/// </summary>
		/// <param name="installationContext">The installation context.</param>
		/// <remarks>
		/// Uninstallation typically runs with administrative permissions.
		/// </remarks>
		// Token: 0x0600014C RID: 332 RVA: 0x000062D4 File Offset: 0x000044D4
		public void Uninstall(InstallationContext installationContext)
		{
			if (installationContext == null)
			{
				throw new ArgumentNullException("installationContext");
			}
			this.InitializeAll();
			foreach (IInstallable installable in this.configItems.OfType<IInstallable>())
			{
				installationContext.Info("Uninstalling '{0}'", new object[] { installable });
				try
				{
					installable.Uninstall(installationContext);
					installationContext.Info("Finished uninstalling '{0}'.", new object[] { installable });
				}
				catch (Exception ex)
				{
					if (ex.MustBeRethrown())
					{
						throw;
					}
					installationContext.Error("Uninstallation of '{0}' failed: {1}.", new object[] { installable, ex });
				}
			}
		}

		/// <summary>
		/// Closes all targets and releases any unmanaged resources.
		/// </summary>
		// Token: 0x0600014D RID: 333 RVA: 0x000063D4 File Offset: 0x000045D4
		internal void Close()
		{
			InternalLogger.Debug("Closing logging configuration...");
			foreach (ISupportsInitialize supportsInitialize in this.configItems.OfType<ISupportsInitialize>())
			{
				InternalLogger.Trace("Closing {0}", new object[] { supportsInitialize });
				try
				{
					supportsInitialize.Close();
				}
				catch (Exception ex)
				{
					if (ex.MustBeRethrown())
					{
						throw;
					}
					InternalLogger.Warn("Exception while closing {0}", new object[] { ex });
				}
			}
			InternalLogger.Debug("Finished closing logging configuration.");
		}

		// Token: 0x0600014E RID: 334 RVA: 0x000064A4 File Offset: 0x000046A4
		internal void Dump()
		{
			InternalLogger.Debug("--- NLog configuration dump. ---");
			InternalLogger.Debug("Targets:");
			foreach (Target target in this.targets.Values)
			{
				InternalLogger.Info("{0}", new object[] { target });
			}
			InternalLogger.Debug("Rules:");
			foreach (LoggingRule loggingRule in this.LoggingRules)
			{
				InternalLogger.Info("{0}", new object[] { loggingRule });
			}
			InternalLogger.Debug("--- End of NLog configuration dump ---");
		}

		/// <summary>
		/// Flushes any pending log messages on all appenders.
		/// </summary>
		/// <param name="asyncContinuation">The asynchronous continuation.</param>
		// Token: 0x0600014F RID: 335 RVA: 0x000065B0 File Offset: 0x000047B0
		internal void FlushAllTargets(AsyncContinuation asyncContinuation)
		{
			List<Target> list = new List<Target>();
			foreach (LoggingRule loggingRule in this.LoggingRules)
			{
				foreach (Target target2 in loggingRule.Targets)
				{
					if (!list.Contains(target2))
					{
						list.Add(target2);
					}
				}
			}
			AsyncHelpers.ForEachItemInParallel<Target>(list, asyncContinuation, delegate(Target target, AsyncContinuation cont)
			{
				target.Flush(cont);
			});
		}

		/// <summary>
		/// Validates the configuration.
		/// </summary>
		// Token: 0x06000150 RID: 336 RVA: 0x00006698 File Offset: 0x00004898
		internal void ValidateConfig()
		{
			List<object> list = new List<object>();
			foreach (LoggingRule loggingRule in this.LoggingRules)
			{
				list.Add(loggingRule);
			}
			foreach (Target target in this.targets.Values)
			{
				list.Add(target);
			}
			this.configItems = ObjectGraphScanner.FindReachableObjects<object>(list.ToArray());
			InternalLogger.Info("Found {0} configuration items", new object[] { this.configItems.Length });
			foreach (object obj in this.configItems)
			{
				PropertyHelper.CheckRequiredParameters(obj);
			}
		}

		// Token: 0x06000151 RID: 337 RVA: 0x000067C4 File Offset: 0x000049C4
		internal void InitializeAll()
		{
			this.ValidateConfig();
			foreach (ISupportsInitialize supportsInitialize in this.configItems.OfType<ISupportsInitialize>().Reverse<ISupportsInitialize>())
			{
				InternalLogger.Trace("Initializing {0}", new object[] { supportsInitialize });
				try
				{
					supportsInitialize.Initialize(this);
				}
				catch (Exception ex)
				{
					if (ex.MustBeRethrown())
					{
						throw;
					}
					if (LogManager.ThrowExceptions)
					{
						throw new NLogConfigurationException("Error during initialization of " + supportsInitialize, ex);
					}
				}
			}
		}

		// Token: 0x06000152 RID: 338 RVA: 0x00006894 File Offset: 0x00004A94
		internal void EnsureInitialized()
		{
			this.InitializeAll();
		}

		// Token: 0x04000066 RID: 102
		private readonly IDictionary<string, Target> targets = new Dictionary<string, Target>(StringComparer.OrdinalIgnoreCase);

		// Token: 0x04000067 RID: 103
		private object[] configItems;
	}
}
