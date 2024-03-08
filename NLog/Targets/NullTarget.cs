using System;
using System.ComponentModel;

namespace NLog.Targets
{
	/// <summary>
	/// Discards log messages. Used mainly for debugging and benchmarking.
	/// </summary>
	/// <seealso href="http://nlog-project.org/wiki/Null_target">Documentation on NLog Wiki</seealso>
	/// <example>
	/// <p>
	/// To set up the target in the <a href="config.html">configuration file</a>, 
	/// use the following syntax:
	/// </p>
	/// <code lang="XML" source="examples/targets/Configuration File/Null/NLog.config" />
	/// <p>
	/// This assumes just one target and a single rule. More configuration
	/// options are described <a href="config.html">here</a>.
	/// </p>
	/// <p>
	/// To set up the log target programmatically use code like this:
	/// </p>
	/// <code lang="C#" source="examples/targets/Configuration API/Null/Simple/Example.cs" />
	/// </example>
	// Token: 0x02000120 RID: 288
	[Target("Null")]
	public sealed class NullTarget : TargetWithLayout
	{
		/// <summary>
		/// Gets or sets a value indicating whether to perform layout calculation.
		/// </summary>
		/// <docgen category="Layout Options" order="10" />
		// Token: 0x170001FA RID: 506
		// (get) Token: 0x0600097F RID: 2431 RVA: 0x00021D94 File Offset: 0x0001FF94
		// (set) Token: 0x06000980 RID: 2432 RVA: 0x00021DAB File Offset: 0x0001FFAB
		[DefaultValue(false)]
		public bool FormatMessage { get; set; }

		/// <summary>
		/// Does nothing. Optionally it calculates the layout text but
		/// discards the results.
		/// </summary>
		/// <param name="logEvent">The logging event.</param>
		// Token: 0x06000981 RID: 2433 RVA: 0x00021DB4 File Offset: 0x0001FFB4
		protected override void Write(LogEventInfo logEvent)
		{
			if (this.FormatMessage)
			{
				this.Layout.Render(logEvent);
			}
		}
	}
}
