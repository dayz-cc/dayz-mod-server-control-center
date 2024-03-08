using System;
using NLog.Common;

namespace NLog.Targets.Wrappers
{
	/// <summary>
	/// Sends log messages to a randomly selected target.
	/// </summary>
	/// <seealso href="http://nlog-project.org/wiki/RandomizeGroup_target">Documentation on NLog Wiki</seealso>
	/// <example>
	/// <p>This example causes the messages to be written to either file1.txt or file2.txt 
	/// chosen randomly on a per-message basis.
	/// </p>
	/// <p>
	/// To set up the target in the <a href="config.html">configuration file</a>, 
	/// use the following syntax:
	/// </p>
	/// <code lang="XML" source="examples/targets/Configuration File/RandomizeGroup/NLog.config" />
	/// <p>
	/// The above examples assume just one target and a single rule. See below for
	/// a programmatic configuration that's equivalent to the above config file:
	/// </p>
	/// <code lang="C#" source="examples/targets/Configuration API/RandomizeGroup/Simple/Example.cs" />
	/// </example>
	// Token: 0x0200013C RID: 316
	[Target("RandomizeGroup", IsCompound = true)]
	public class RandomizeGroupTarget : CompoundTargetBase
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Targets.Wrappers.RandomizeGroupTarget" /> class.
		/// </summary>
		// Token: 0x06000A6F RID: 2671 RVA: 0x00025065 File Offset: 0x00023265
		public RandomizeGroupTarget()
			: this(new Target[0])
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Targets.Wrappers.RandomizeGroupTarget" /> class.
		/// </summary>
		/// <param name="targets">The targets.</param>
		// Token: 0x06000A70 RID: 2672 RVA: 0x00025076 File Offset: 0x00023276
		public RandomizeGroupTarget(params Target[] targets)
			: base(targets)
		{
		}

		/// <summary>
		/// Forwards the log event to one of the sub-targets.
		/// The sub-target is randomly chosen.
		/// </summary>
		/// <param name="logEvent">The log event.</param>
		// Token: 0x06000A71 RID: 2673 RVA: 0x00025090 File Offset: 0x00023290
		protected override void Write(AsyncLogEventInfo logEvent)
		{
			if (base.Targets.Count == 0)
			{
				logEvent.Continuation(null);
			}
			else
			{
				int num;
				lock (this.random)
				{
					num = this.random.Next(base.Targets.Count);
				}
				base.Targets[num].WriteAsyncLogEvent(logEvent);
			}
		}

		// Token: 0x0400036C RID: 876
		private readonly Random random = new Random();
	}
}
