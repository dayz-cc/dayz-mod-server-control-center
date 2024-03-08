using System;
using NLog.Common;
using NLog.Config;

namespace NLog.Targets.Wrappers
{
	/// <summary>
	/// Base class for targets wrap other (single) targets.
	/// </summary>
	// Token: 0x0200012F RID: 303
	public abstract class WrapperTargetBase : Target
	{
		/// <summary>
		/// Gets or sets the target that is wrapped by this target.
		/// </summary>
		/// <docgen category="General Options" order="11" />
		// Token: 0x17000227 RID: 551
		// (get) Token: 0x06000A0B RID: 2571 RVA: 0x00023B94 File Offset: 0x00021D94
		// (set) Token: 0x06000A0C RID: 2572 RVA: 0x00023BAB File Offset: 0x00021DAB
		[RequiredParameter]
		public Target WrappedTarget { get; set; }

		/// <summary>
		/// Returns the text representation of the object. Used for diagnostics.
		/// </summary>
		/// <returns>A string that describes the target.</returns>
		// Token: 0x06000A0D RID: 2573 RVA: 0x00023BB4 File Offset: 0x00021DB4
		public override string ToString()
		{
			return string.Concat(new object[]
			{
				base.ToString(),
				"(",
				this.WrappedTarget,
				")"
			});
		}

		/// <summary>
		/// Flush any pending log messages (in case of asynchronous targets).
		/// </summary>
		/// <param name="asyncContinuation">The asynchronous continuation.</param>
		// Token: 0x06000A0E RID: 2574 RVA: 0x00023BF5 File Offset: 0x00021DF5
		protected override void FlushAsync(AsyncContinuation asyncContinuation)
		{
			this.WrappedTarget.Flush(asyncContinuation);
		}

		/// <summary>
		/// Writes logging event to the log target. Must be overridden in inheriting
		/// classes.
		/// </summary>
		/// <param name="logEvent">Logging event to be written out.</param>
		// Token: 0x06000A0F RID: 2575 RVA: 0x00023C05 File Offset: 0x00021E05
		protected sealed override void Write(LogEventInfo logEvent)
		{
			throw new NotSupportedException("This target must not be invoked in a synchronous way.");
		}
	}
}
