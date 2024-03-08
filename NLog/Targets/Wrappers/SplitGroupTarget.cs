using System;
using System.Collections.Generic;
using System.Threading;
using NLog.Common;

namespace NLog.Targets.Wrappers
{
	/// <summary>
	/// Writes log events to all targets.
	/// </summary>
	/// <seealso href="http://nlog-project.org/wiki/SplitGroup_target">Documentation on NLog Wiki</seealso>
	/// <example>
	/// <p>This example causes the messages to be written to both file1.txt or file2.txt 
	/// </p>
	/// <p>
	/// To set up the target in the <a href="config.html">configuration file</a>, 
	/// use the following syntax:
	/// </p>
	/// <code lang="XML" source="examples/targets/Configuration File/SplitGroup/NLog.config" />
	/// <p>
	/// The above examples assume just one target and a single rule. See below for
	/// a programmatic configuration that's equivalent to the above config file:
	/// </p>
	/// <code lang="C#" source="examples/targets/Configuration API/SplitGroup/Simple/Example.cs" />
	/// </example>
	// Token: 0x02000142 RID: 322
	[Target("SplitGroup", IsCompound = true)]
	public class SplitGroupTarget : CompoundTargetBase
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Targets.Wrappers.SplitGroupTarget" /> class.
		/// </summary>
		// Token: 0x06000A81 RID: 2689 RVA: 0x00025478 File Offset: 0x00023678
		public SplitGroupTarget()
			: this(new Target[0])
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Targets.Wrappers.SplitGroupTarget" /> class.
		/// </summary>
		/// <param name="targets">The targets.</param>
		// Token: 0x06000A82 RID: 2690 RVA: 0x00025489 File Offset: 0x00023689
		public SplitGroupTarget(params Target[] targets)
			: base(targets)
		{
		}

		/// <summary>
		/// Forwards the specified log event to all sub-targets.
		/// </summary>
		/// <param name="logEvent">The log event.</param>
		// Token: 0x06000A83 RID: 2691 RVA: 0x000254B8 File Offset: 0x000236B8
		protected override void Write(AsyncLogEventInfo logEvent)
		{
			AsyncHelpers.ForEachItemSequentially<Target>(base.Targets, logEvent.Continuation, delegate(Target t, AsyncContinuation cont)
			{
				t.WriteAsyncLogEvent(logEvent.LogEvent.WithContinuation(cont));
			});
		}

		/// <summary>
		/// Writes an array of logging events to the log target. By default it iterates on all
		/// events and passes them to "Write" method. Inheriting classes can use this method to
		/// optimize batch writes.
		/// </summary>
		/// <param name="logEvents">Logging events to be written out.</param>
		// Token: 0x06000A84 RID: 2692 RVA: 0x000254F8 File Offset: 0x000236F8
		protected override void Write(AsyncLogEventInfo[] logEvents)
		{
			InternalLogger.Trace("Writing {0} events", new object[] { logEvents.Length });
			for (int i = 0; i < logEvents.Length; i++)
			{
				logEvents[i].Continuation = SplitGroupTarget.CountedWrap(logEvents[i].Continuation, base.Targets.Count);
			}
			foreach (Target target in base.Targets)
			{
				InternalLogger.Trace("Sending {0} events to {1}", new object[] { logEvents.Length, target });
				target.WriteAsyncLogEvents(logEvents);
			}
		}

		// Token: 0x06000A85 RID: 2693 RVA: 0x000256B0 File Offset: 0x000238B0
		private static AsyncContinuation CountedWrap(AsyncContinuation originalContinuation, int counter)
		{
			AsyncContinuation asyncContinuation;
			if (counter == 1)
			{
				asyncContinuation = originalContinuation;
			}
			else
			{
				List<Exception> exceptions = new List<Exception>();
				AsyncContinuation asyncContinuation2 = delegate(Exception ex)
				{
					if (ex != null)
					{
						lock (exceptions)
						{
							exceptions.Add(ex);
						}
					}
					int num = Interlocked.Decrement(ref counter);
					if (num == 0)
					{
						Exception combinedException = AsyncHelpers.GetCombinedException(exceptions);
						InternalLogger.Trace("Combined exception: {0}", new object[] { combinedException });
						originalContinuation(combinedException);
					}
					else
					{
						InternalLogger.Trace("{0} remaining.", new object[] { num });
					}
				};
				asyncContinuation = asyncContinuation2;
			}
			return asyncContinuation;
		}
	}
}
