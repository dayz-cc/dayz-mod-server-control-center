using System;
using NLog.Common;

namespace NLog.Targets.Wrappers
{
	/// <summary>
	/// Distributes log events to targets in a round-robin fashion.
	/// </summary>
	/// <seealso href="http://nlog-project.org/wiki/RoundRobinGroup_target">Documentation on NLog Wiki</seealso>
	/// <example>
	/// <p>This example causes the messages to be written to either file1.txt or file2.txt.
	/// Each odd message is written to file2.txt, each even message goes to file1.txt.
	/// </p>
	/// <p>
	/// To set up the target in the <a href="config.html">configuration file</a>, 
	/// use the following syntax:
	/// </p>
	/// <code lang="XML" source="examples/targets/Configuration File/RoundRobinGroup/NLog.config" />
	/// <p>
	/// The above examples assume just one target and a single rule. See below for
	/// a programmatic configuration that's equivalent to the above config file:
	/// </p>
	/// <code lang="C#" source="examples/targets/Configuration API/RoundRobinGroup/Simple/Example.cs" />
	/// </example>
	// Token: 0x0200013F RID: 319
	[Target("RoundRobinGroup", IsCompound = true)]
	public class RoundRobinGroupTarget : CompoundTargetBase
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Targets.Wrappers.RoundRobinGroupTarget" /> class.
		/// </summary>
		// Token: 0x06000A7E RID: 2686 RVA: 0x000253A9 File Offset: 0x000235A9
		public RoundRobinGroupTarget()
			: this(new Target[0])
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Targets.Wrappers.RoundRobinGroupTarget" /> class.
		/// </summary>
		/// <param name="targets">The targets.</param>
		// Token: 0x06000A7F RID: 2687 RVA: 0x000253BA File Offset: 0x000235BA
		public RoundRobinGroupTarget(params Target[] targets)
			: base(targets)
		{
		}

		/// <summary>
		/// Forwards the write to one of the targets from
		/// the <see cref="N:NLog.Targets" /> collection.
		/// </summary>
		/// <param name="logEvent">The log event.</param>
		/// <remarks>
		/// The writes are routed in a round-robin fashion.
		/// The first log event goes to the first target, the second
		/// one goes to the second target and so on looping to the
		/// first target when there are no more targets available.
		/// In general request N goes to Targets[N % Targets.Count].
		/// </remarks>
		// Token: 0x06000A80 RID: 2688 RVA: 0x000253D8 File Offset: 0x000235D8
		protected override void Write(AsyncLogEventInfo logEvent)
		{
			if (base.Targets.Count == 0)
			{
				logEvent.Continuation(null);
			}
			else
			{
				int num;
				lock (this.lockObject)
				{
					num = this.currentTarget;
					this.currentTarget = (this.currentTarget + 1) % base.Targets.Count;
				}
				base.Targets[num].WriteAsyncLogEvent(logEvent);
			}
		}

		// Token: 0x04000370 RID: 880
		private int currentTarget = 0;

		// Token: 0x04000371 RID: 881
		private object lockObject = new object();
	}
}
