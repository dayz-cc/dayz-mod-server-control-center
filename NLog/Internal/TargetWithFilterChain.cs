using System;
using System.Collections.Generic;
using NLog.Config;
using NLog.Filters;
using NLog.Targets;

namespace NLog.Internal
{
	/// <summary>
	/// Represents target with a chain of filters which determine
	/// whether logging should happen.
	/// </summary>
	// Token: 0x0200008A RID: 138
	[NLogConfigurationItem]
	internal class TargetWithFilterChain
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Internal.TargetWithFilterChain" /> class.
		/// </summary>
		/// <param name="target">The target.</param>
		/// <param name="filterChain">The filter chain.</param>
		// Token: 0x0600034E RID: 846 RVA: 0x0000D16D File Offset: 0x0000B36D
		public TargetWithFilterChain(Target target, IList<Filter> filterChain)
		{
			this.Target = target;
			this.FilterChain = filterChain;
			this.stackTraceUsage = StackTraceUsage.None;
		}

		/// <summary>
		/// Gets the target.
		/// </summary>
		/// <value>The target.</value>
		// Token: 0x170000A4 RID: 164
		// (get) Token: 0x0600034F RID: 847 RVA: 0x0000D198 File Offset: 0x0000B398
		// (set) Token: 0x06000350 RID: 848 RVA: 0x0000D1AF File Offset: 0x0000B3AF
		public Target Target { get; private set; }

		/// <summary>
		/// Gets the filter chain.
		/// </summary>
		/// <value>The filter chain.</value>
		// Token: 0x170000A5 RID: 165
		// (get) Token: 0x06000351 RID: 849 RVA: 0x0000D1B8 File Offset: 0x0000B3B8
		// (set) Token: 0x06000352 RID: 850 RVA: 0x0000D1CF File Offset: 0x0000B3CF
		public IList<Filter> FilterChain { get; private set; }

		/// <summary>
		/// Gets or sets the next <see cref="T:NLog.Internal.TargetWithFilterChain" /> item in the chain.
		/// </summary>
		/// <value>The next item in the chain.</value>
		// Token: 0x170000A6 RID: 166
		// (get) Token: 0x06000353 RID: 851 RVA: 0x0000D1D8 File Offset: 0x0000B3D8
		// (set) Token: 0x06000354 RID: 852 RVA: 0x0000D1EF File Offset: 0x0000B3EF
		public TargetWithFilterChain NextInChain { get; set; }

		/// <summary>
		/// Gets the stack trace usage.
		/// </summary>
		/// <returns>A <see cref="T:NLog.Config.StackTraceUsage" /> value that determines stack trace handling.</returns>
		// Token: 0x06000355 RID: 853 RVA: 0x0000D1F8 File Offset: 0x0000B3F8
		public StackTraceUsage GetStackTraceUsage()
		{
			return this.stackTraceUsage;
		}

		// Token: 0x06000356 RID: 854 RVA: 0x0000D210 File Offset: 0x0000B410
		internal void PrecalculateStackTraceUsage()
		{
			this.stackTraceUsage = StackTraceUsage.None;
			foreach (IUsesStackTrace usesStackTrace in ObjectGraphScanner.FindReachableObjects<IUsesStackTrace>(new object[] { this }))
			{
				StackTraceUsage stackTraceUsage = usesStackTrace.StackTraceUsage;
				if (stackTraceUsage > this.stackTraceUsage)
				{
					this.stackTraceUsage = stackTraceUsage;
					if (this.stackTraceUsage >= StackTraceUsage.WithSource)
					{
						break;
					}
				}
			}
		}

		// Token: 0x040000DE RID: 222
		private StackTraceUsage stackTraceUsage = StackTraceUsage.None;
	}
}
