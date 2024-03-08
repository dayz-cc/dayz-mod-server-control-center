using System;

namespace NLog.Internal
{
	/// <summary>
	/// Logger configuration.
	/// </summary>
	// Token: 0x0200006E RID: 110
	internal class LoggerConfiguration
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Internal.LoggerConfiguration" /> class.
		/// </summary>
		/// <param name="targetsByLevel">The targets by level.</param>
		// Token: 0x060002BC RID: 700 RVA: 0x0000AF54 File Offset: 0x00009154
		public LoggerConfiguration(TargetWithFilterChain[] targetsByLevel)
		{
			this.targetsByLevel = targetsByLevel;
		}

		/// <summary>
		/// Gets targets for the specified level.
		/// </summary>
		/// <param name="level">The level.</param>
		/// <returns>Chain of targets with attached filters.</returns>
		// Token: 0x060002BD RID: 701 RVA: 0x0000AF68 File Offset: 0x00009168
		public TargetWithFilterChain GetTargetsForLevel(LogLevel level)
		{
			return this.targetsByLevel[level.Ordinal];
		}

		/// <summary>
		/// Determines whether the specified level is enabled.
		/// </summary>
		/// <param name="level">The level.</param>
		/// <returns>
		/// A value of <c>true</c> if the specified level is enabled; otherwise, <c>false</c>.
		/// </returns>
		// Token: 0x060002BE RID: 702 RVA: 0x0000AF88 File Offset: 0x00009188
		public bool IsEnabled(LogLevel level)
		{
			return this.targetsByLevel[level.Ordinal] != null;
		}

		// Token: 0x040000B9 RID: 185
		private readonly TargetWithFilterChain[] targetsByLevel;
	}
}
