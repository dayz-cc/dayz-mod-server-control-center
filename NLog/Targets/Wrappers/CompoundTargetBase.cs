using System;
using System.Collections.Generic;
using System.Text;
using NLog.Common;

namespace NLog.Targets.Wrappers
{
	/// <summary>
	/// A base class for targets which wrap other (multiple) targets
	/// and provide various forms of target routing.
	/// </summary>
	// Token: 0x02000134 RID: 308
	public abstract class CompoundTargetBase : Target
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Targets.Wrappers.CompoundTargetBase" /> class.
		/// </summary>
		/// <param name="targets">The targets.</param>
		// Token: 0x06000A37 RID: 2615 RVA: 0x00024484 File Offset: 0x00022684
		protected CompoundTargetBase(params Target[] targets)
		{
			this.Targets = new List<Target>(targets);
		}

		/// <summary>
		/// Gets the collection of targets managed by this compound target.
		/// </summary>
		// Token: 0x17000230 RID: 560
		// (get) Token: 0x06000A38 RID: 2616 RVA: 0x0002449C File Offset: 0x0002269C
		// (set) Token: 0x06000A39 RID: 2617 RVA: 0x000244B3 File Offset: 0x000226B3
		public IList<Target> Targets { get; private set; }

		/// <summary>
		/// Returns the text representation of the object. Used for diagnostics.
		/// </summary>
		/// <returns>A string that describes the target.</returns>
		// Token: 0x06000A3A RID: 2618 RVA: 0x000244BC File Offset: 0x000226BC
		public override string ToString()
		{
			string text = string.Empty;
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(base.ToString());
			stringBuilder.Append("(");
			foreach (Target target in this.Targets)
			{
				stringBuilder.Append(text);
				stringBuilder.Append(target.ToString());
				text = ", ";
			}
			stringBuilder.Append(")");
			return stringBuilder.ToString();
		}

		/// <summary>
		/// Writes logging event to the log target.
		/// </summary>
		/// <param name="logEvent">Logging event to be written out.</param>
		// Token: 0x06000A3B RID: 2619 RVA: 0x00024570 File Offset: 0x00022770
		protected override void Write(LogEventInfo logEvent)
		{
			throw new NotSupportedException("This target must not be invoked in a synchronous way.");
		}

		/// <summary>
		/// Flush any pending log messages for all wrapped targets.
		/// </summary>
		/// <param name="asyncContinuation">The asynchronous continuation.</param>
		// Token: 0x06000A3C RID: 2620 RVA: 0x00024587 File Offset: 0x00022787
		protected override void FlushAsync(AsyncContinuation asyncContinuation)
		{
			AsyncHelpers.ForEachItemInParallel<Target>(this.Targets, asyncContinuation, delegate(Target t, AsyncContinuation c)
			{
				t.Flush(c);
			});
		}
	}
}
