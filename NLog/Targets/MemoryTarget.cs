using System;
using System.Collections.Generic;

namespace NLog.Targets
{
	/// <summary>
	/// Writes log messages to an ArrayList in memory for programmatic retrieval.
	/// </summary>
	/// <seealso href="http://nlog-project.org/wiki/Memory_target">Documentation on NLog Wiki</seealso>
	/// <example>
	/// <p>
	/// To set up the target in the <a href="config.html">configuration file</a>, 
	/// use the following syntax:
	/// </p>
	/// <code lang="XML" source="examples/targets/Configuration File/Memory/NLog.config" />
	/// <p>
	/// This assumes just one target and a single rule. More configuration
	/// options are described <a href="config.html">here</a>.
	/// </p>
	/// <p>
	/// To set up the log target programmatically use code like this:
	/// </p>
	/// <code lang="C#" source="examples/targets/Configuration API/Memory/Simple/Example.cs" />
	/// </example>
	// Token: 0x02000119 RID: 281
	[Target("Memory")]
	public sealed class MemoryTarget : TargetWithLayout
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Targets.MemoryTarget" /> class.
		/// </summary>
		/// <remarks>
		/// The default value of the layout is: <code>${longdate}|${level:uppercase=true}|${logger}|${message}</code>
		/// </remarks>
		// Token: 0x06000957 RID: 2391 RVA: 0x00021888 File Offset: 0x0001FA88
		public MemoryTarget()
		{
			this.Logs = new List<string>();
		}

		/// <summary>
		/// Gets the list of logs gathered in the <see cref="T:NLog.Targets.MemoryTarget" />.
		/// </summary>
		// Token: 0x170001EF RID: 495
		// (get) Token: 0x06000958 RID: 2392 RVA: 0x000218A0 File Offset: 0x0001FAA0
		// (set) Token: 0x06000959 RID: 2393 RVA: 0x000218B7 File Offset: 0x0001FAB7
		public IList<string> Logs { get; private set; }

		/// <summary>
		/// Renders the logging event message and adds it to the internal ArrayList of log messages.
		/// </summary>
		/// <param name="logEvent">The logging event.</param>
		// Token: 0x0600095A RID: 2394 RVA: 0x000218C0 File Offset: 0x0001FAC0
		protected override void Write(LogEventInfo logEvent)
		{
			string text = this.Layout.Render(logEvent);
			this.Logs.Add(text);
		}
	}
}
