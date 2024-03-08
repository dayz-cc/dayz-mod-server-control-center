using System;

namespace NLog.Targets
{
	/// <summary>
	/// Mock target - useful for testing.
	/// </summary>
	/// <seealso href="http://nlog-project.org/wiki/Debug_target">Documentation on NLog Wiki</seealso>
	/// <example>
	/// <p>
	/// To set up the target in the <a href="config.html">configuration file</a>, 
	/// use the following syntax:
	/// </p>
	/// <code lang="XML" source="examples/targets/Configuration File/Debug/NLog.config" />
	/// <p>
	/// This assumes just one target and a single rule. More configuration
	/// options are described <a href="config.html">here</a>.
	/// </p>
	/// <p>
	/// To set up the log target programmatically use code like this:
	/// </p>
	/// <code lang="C#" source="examples/targets/Configuration API/Debug/Simple/Example.cs" />
	/// </example>
	// Token: 0x0200010F RID: 271
	[Target("Debug")]
	public sealed class DebugTarget : TargetWithLayout
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Targets.DebugTarget" /> class.
		/// </summary>
		/// <remarks>
		/// The default value of the layout is: <code>${longdate}|${level:uppercase=true}|${logger}|${message}</code>
		/// </remarks>
		// Token: 0x06000897 RID: 2199 RVA: 0x0001E3E1 File Offset: 0x0001C5E1
		public DebugTarget()
		{
			this.LastMessage = string.Empty;
			this.Counter = 0;
		}

		/// <summary>
		/// Gets the number of times this target has been called.
		/// </summary>
		/// <docgen category="Debugging Options" order="10" />
		// Token: 0x170001B2 RID: 434
		// (get) Token: 0x06000898 RID: 2200 RVA: 0x0001E400 File Offset: 0x0001C600
		// (set) Token: 0x06000899 RID: 2201 RVA: 0x0001E417 File Offset: 0x0001C617
		public int Counter { get; private set; }

		/// <summary>
		/// Gets the last message rendered by this target.
		/// </summary>
		/// <docgen category="Debugging Options" order="10" />
		// Token: 0x170001B3 RID: 435
		// (get) Token: 0x0600089A RID: 2202 RVA: 0x0001E420 File Offset: 0x0001C620
		// (set) Token: 0x0600089B RID: 2203 RVA: 0x0001E437 File Offset: 0x0001C637
		public string LastMessage { get; private set; }

		/// <summary>
		/// Increases the number of messages.
		/// </summary>
		/// <param name="logEvent">The logging event.</param>
		// Token: 0x0600089C RID: 2204 RVA: 0x0001E440 File Offset: 0x0001C640
		protected override void Write(LogEventInfo logEvent)
		{
			this.Counter++;
			this.LastMessage = this.Layout.Render(logEvent);
		}
	}
}
