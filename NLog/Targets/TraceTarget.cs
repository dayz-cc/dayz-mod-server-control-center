using System;
using System.Diagnostics;

namespace NLog.Targets
{
	/// <summary>
	/// Sends log messages through System.Diagnostics.Trace.
	/// </summary>
	/// <seealso href="http://nlog-project.org/wiki/Trace_target">Documentation on NLog Wiki</seealso>
	/// <example>
	/// <p>
	/// To set up the target in the <a href="config.html">configuration file</a>, 
	/// use the following syntax:
	/// </p>
	/// <code lang="XML" source="examples/targets/Configuration File/Trace/NLog.config" />
	/// <p>
	/// This assumes just one target and a single rule. More configuration
	/// options are described <a href="config.html">here</a>.
	/// </p>
	/// <p>
	/// To set up the log target programmatically use code like this:
	/// </p>
	/// <code lang="C#" source="examples/targets/Configuration API/Trace/Simple/Example.cs" />
	/// </example>
	// Token: 0x0200012A RID: 298
	[Target("Trace")]
	public sealed class TraceTarget : TargetWithLayout
	{
		/// <summary>
		/// Writes the specified logging event to the <see cref="T:System.Diagnostics.Trace" /> facility.
		/// If the log level is greater than or equal to <see cref="F:NLog.LogLevel.Error" /> it uses the
		/// <see cref="M:System.Diagnostics.Trace.Fail(System.String)" /> method, otherwise it uses
		/// <see cref="M:System.Diagnostics.Trace.Write(System.String)" /> method.
		/// </summary>
		/// <param name="logEvent">The logging event.</param>
		// Token: 0x060009EE RID: 2542 RVA: 0x0002305C File Offset: 0x0002125C
		protected override void Write(LogEventInfo logEvent)
		{
			if (logEvent.Level <= LogLevel.Debug)
			{
				Trace.WriteLine(this.Layout.Render(logEvent));
			}
			else if (logEvent.Level == LogLevel.Info)
			{
				Trace.TraceInformation(this.Layout.Render(logEvent));
			}
			else if (logEvent.Level == LogLevel.Warn)
			{
				Trace.TraceWarning(this.Layout.Render(logEvent));
			}
			else if (logEvent.Level == LogLevel.Error)
			{
				Trace.TraceError(this.Layout.Render(logEvent));
			}
			else if (logEvent.Level >= LogLevel.Fatal)
			{
				Trace.Fail(this.Layout.Render(logEvent));
			}
			else
			{
				Trace.WriteLine(this.Layout.Render(logEvent));
			}
		}
	}
}
