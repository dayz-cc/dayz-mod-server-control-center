using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using NLog.Common;
using NLog.Config;
using NLog.Internal;

namespace NLog.Targets
{
	/// <summary>
	/// Increments specified performance counter on each write.
	/// </summary>
	/// <seealso href="http://nlog-project.org/wiki/PerformanceCounter_target">Documentation on NLog Wiki</seealso>
	/// <example>
	/// <p>
	/// To set up the target in the <a href="config.html">configuration file</a>, 
	/// use the following syntax:
	/// </p>
	/// <code lang="XML" source="examples/targets/Configuration File/PerfCounter/NLog.config" />
	/// <p>
	/// This assumes just one target and a single rule. More configuration
	/// options are described <a href="config.html">here</a>.
	/// </p>
	/// <p>
	/// To set up the log target programmatically use code like this:
	/// </p>
	/// <code lang="C#" source="examples/targets/Configuration API/PerfCounter/Simple/Example.cs" />
	/// </example>
	/// <remarks>
	/// TODO:
	/// 1. Unable to create a category allowing multiple counter instances (.Net 2.0 API only, probably)
	/// 2. Is there any way of adding new counters without deleting the whole category?
	/// 3. There should be some mechanism of resetting the counter (e.g every day starts from 0), or auto-switching to 
	///    another counter instance (with dynamic creation of new instance). This could be done with layouts. 
	/// </remarks>
	// Token: 0x02000122 RID: 290
	[Target("PerfCounter")]
	public class PerformanceCounterTarget : Target, IInstallable
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Targets.PerformanceCounterTarget" /> class.
		/// </summary>
		// Token: 0x06000985 RID: 2437 RVA: 0x00021E03 File Offset: 0x00020003
		public PerformanceCounterTarget()
		{
			this.CounterType = PerformanceCounterType.NumberOfItems32;
			this.InstanceName = string.Empty;
			this.CounterHelp = string.Empty;
		}

		/// <summary>
		/// Gets or sets a value indicating whether performance counter should be automatically created.
		/// </summary>
		/// <docgen category="Performance Counter Options" order="10" />
		// Token: 0x170001FB RID: 507
		// (get) Token: 0x06000986 RID: 2438 RVA: 0x00021E34 File Offset: 0x00020034
		// (set) Token: 0x06000987 RID: 2439 RVA: 0x00021E4B File Offset: 0x0002004B
		public bool AutoCreate { get; set; }

		/// <summary>
		/// Gets or sets the name of the performance counter category.
		/// </summary>
		/// <docgen category="Performance Counter Options" order="10" />
		// Token: 0x170001FC RID: 508
		// (get) Token: 0x06000988 RID: 2440 RVA: 0x00021E54 File Offset: 0x00020054
		// (set) Token: 0x06000989 RID: 2441 RVA: 0x00021E6B File Offset: 0x0002006B
		[RequiredParameter]
		public string CategoryName { get; set; }

		/// <summary>
		/// Gets or sets the name of the performance counter.
		/// </summary>
		/// <docgen category="Performance Counter Options" order="10" />
		// Token: 0x170001FD RID: 509
		// (get) Token: 0x0600098A RID: 2442 RVA: 0x00021E74 File Offset: 0x00020074
		// (set) Token: 0x0600098B RID: 2443 RVA: 0x00021E8B File Offset: 0x0002008B
		[RequiredParameter]
		public string CounterName { get; set; }

		/// <summary>
		/// Gets or sets the performance counter instance name.
		/// </summary>
		/// <docgen category="Performance Counter Options" order="10" />
		// Token: 0x170001FE RID: 510
		// (get) Token: 0x0600098C RID: 2444 RVA: 0x00021E94 File Offset: 0x00020094
		// (set) Token: 0x0600098D RID: 2445 RVA: 0x00021EAB File Offset: 0x000200AB
		public string InstanceName { get; set; }

		/// <summary>
		/// Gets or sets the counter help text.
		/// </summary>
		/// <docgen category="Performance Counter Options" order="10" />
		// Token: 0x170001FF RID: 511
		// (get) Token: 0x0600098E RID: 2446 RVA: 0x00021EB4 File Offset: 0x000200B4
		// (set) Token: 0x0600098F RID: 2447 RVA: 0x00021ECB File Offset: 0x000200CB
		public string CounterHelp { get; set; }

		/// <summary>
		/// Gets or sets the performance counter type.
		/// </summary>
		/// <docgen category="Performance Counter Options" order="10" />
		// Token: 0x17000200 RID: 512
		// (get) Token: 0x06000990 RID: 2448 RVA: 0x00021ED4 File Offset: 0x000200D4
		// (set) Token: 0x06000991 RID: 2449 RVA: 0x00021EEB File Offset: 0x000200EB
		[DefaultValue(PerformanceCounterType.NumberOfItems32)]
		public PerformanceCounterType CounterType { get; set; }

		/// <summary>
		/// Performs installation which requires administrative permissions.
		/// </summary>
		/// <param name="installationContext">The installation context.</param>
		// Token: 0x06000992 RID: 2450 RVA: 0x00021F24 File Offset: 0x00020124
		public void Install(InstallationContext installationContext)
		{
			Dictionary<string, List<PerformanceCounterTarget>> dictionary = base.LoggingConfiguration.AllTargets.OfType<PerformanceCounterTarget>().BucketSort((PerformanceCounterTarget c) => c.CategoryName);
			string categoryName = this.CategoryName;
			if (dictionary[categoryName].Any((PerformanceCounterTarget c) => c.created))
			{
				installationContext.Trace("Category '{0}' has already been installed.", new object[] { categoryName });
			}
			else
			{
				try
				{
					PerformanceCounterCategoryType performanceCounterCategoryType;
					CounterCreationDataCollection counterCreationDataCollection = PerformanceCounterTarget.GetCounterCreationDataCollection(dictionary[this.CategoryName], out performanceCounterCategoryType);
					if (PerformanceCounterCategory.Exists(categoryName))
					{
						installationContext.Debug("Deleting category '{0}'", new object[] { categoryName });
						PerformanceCounterCategory.Delete(categoryName);
					}
					installationContext.Debug("Creating category '{0}' with {1} counter(s) (Type: {2})", new object[] { categoryName, counterCreationDataCollection.Count, performanceCounterCategoryType });
					foreach (object obj in counterCreationDataCollection)
					{
						CounterCreationData counterCreationData = (CounterCreationData)obj;
						installationContext.Trace("  Counter: '{0}' Type: ({1}) Help: {2}", new object[] { counterCreationData.CounterName, counterCreationData.CounterType, counterCreationData.CounterHelp });
					}
					PerformanceCounterCategory.Create(categoryName, "Category created by NLog", performanceCounterCategoryType, counterCreationDataCollection);
				}
				catch (Exception ex)
				{
					if (ex.MustBeRethrown())
					{
						throw;
					}
					if (!installationContext.IgnoreFailures)
					{
						installationContext.Error("Error creating category '{0}': {1}", new object[] { categoryName, ex.Message });
						throw;
					}
					installationContext.Warning("Error creating category '{0}': {1}", new object[] { categoryName, ex.Message });
				}
				finally
				{
					foreach (PerformanceCounterTarget performanceCounterTarget in dictionary[categoryName])
					{
						performanceCounterTarget.created = true;
					}
				}
			}
		}

		/// <summary>
		/// Performs uninstallation which requires administrative permissions.
		/// </summary>
		/// <param name="installationContext">The installation context.</param>
		// Token: 0x06000993 RID: 2451 RVA: 0x00022200 File Offset: 0x00020400
		public void Uninstall(InstallationContext installationContext)
		{
			string categoryName = this.CategoryName;
			if (PerformanceCounterCategory.Exists(categoryName))
			{
				installationContext.Debug("Deleting category '{0}'", new object[] { categoryName });
				PerformanceCounterCategory.Delete(categoryName);
			}
			else
			{
				installationContext.Debug("Category '{0}' does not exist.", new object[] { categoryName });
			}
		}

		/// <summary>
		/// Determines whether the item is installed.
		/// </summary>
		/// <param name="installationContext">The installation context.</param>
		/// <returns>
		/// Value indicating whether the item is installed or null if it is not possible to determine.
		/// </returns>
		// Token: 0x06000994 RID: 2452 RVA: 0x00022260 File Offset: 0x00020460
		public bool? IsInstalled(InstallationContext installationContext)
		{
			bool? flag;
			if (!PerformanceCounterCategory.Exists(this.CategoryName))
			{
				flag = new bool?(false);
			}
			else
			{
				flag = new bool?(PerformanceCounterCategory.CounterExists(this.CounterName, this.CategoryName));
			}
			return flag;
		}

		/// <summary>
		/// Increments the configured performance counter.
		/// </summary>
		/// <param name="logEvent">Log event.</param>
		// Token: 0x06000995 RID: 2453 RVA: 0x000222A4 File Offset: 0x000204A4
		protected override void Write(LogEventInfo logEvent)
		{
			if (this.EnsureInitialized())
			{
				this.perfCounter.Increment();
			}
		}

		/// <summary>
		/// Closes the target and releases any unmanaged resources.
		/// </summary>
		// Token: 0x06000996 RID: 2454 RVA: 0x000222D0 File Offset: 0x000204D0
		protected override void CloseTarget()
		{
			base.CloseTarget();
			if (this.perfCounter != null)
			{
				this.perfCounter.Close();
				this.perfCounter = null;
			}
			this.initialized = false;
		}

		// Token: 0x06000997 RID: 2455 RVA: 0x00022310 File Offset: 0x00020510
		private static CounterCreationDataCollection GetCounterCreationDataCollection(IEnumerable<PerformanceCounterTarget> countersInCategory, out PerformanceCounterCategoryType categoryType)
		{
			categoryType = PerformanceCounterCategoryType.SingleInstance;
			CounterCreationDataCollection counterCreationDataCollection = new CounterCreationDataCollection();
			foreach (PerformanceCounterTarget performanceCounterTarget in countersInCategory)
			{
				if (!string.IsNullOrEmpty(performanceCounterTarget.InstanceName))
				{
					categoryType = PerformanceCounterCategoryType.MultiInstance;
				}
				counterCreationDataCollection.Add(new CounterCreationData(performanceCounterTarget.CounterName, performanceCounterTarget.CounterHelp, performanceCounterTarget.CounterType));
			}
			return counterCreationDataCollection;
		}

		/// <summary>
		/// Ensures that the performance counter has been initialized.
		/// </summary>
		/// <returns>True if the performance counter is operational, false otherwise.</returns>
		// Token: 0x06000998 RID: 2456 RVA: 0x000223A4 File Offset: 0x000205A4
		private bool EnsureInitialized()
		{
			if (!this.initialized)
			{
				this.initialized = true;
				if (this.AutoCreate)
				{
					using (InstallationContext installationContext = new InstallationContext())
					{
						this.Install(installationContext);
					}
				}
				try
				{
					this.perfCounter = new PerformanceCounter(this.CategoryName, this.CounterName, this.InstanceName, false);
				}
				catch (Exception ex)
				{
					if (ex.MustBeRethrown())
					{
						throw;
					}
					InternalLogger.Error("Cannot open performance counter {0}/{1}/{2}: {3}", new object[] { this.CategoryName, this.CounterName, this.InstanceName, ex });
				}
			}
			return this.perfCounter != null;
		}

		// Token: 0x040002F5 RID: 757
		private PerformanceCounter perfCounter;

		// Token: 0x040002F6 RID: 758
		private bool initialized;

		// Token: 0x040002F7 RID: 759
		private bool created;
	}
}
