using System;
using System.Diagnostics;

namespace NLog.Targets
{
	/// <summary>
	/// Writes log messages to the attached managed debugger.
	/// </summary>
	/// <example>
	/// <p>
	/// To set up the target in the <a href="config.html">configuration file</a>, 
	/// use the following syntax:
	/// </p>
	/// <code lang="XML" source="examples/targets/Configuration File/Debugger/NLog.config" />
	/// <p>
	/// This assumes just one target and a single rule. More configuration
	/// options are described <a href="config.html">here</a>.
	/// </p>
	/// <p>
	/// To set up the log target programmatically use code like this:
	/// </p>
	/// <code lang="C#" source="examples/targets/Configuration API/Debugger/Simple/Example.cs" />
	/// </example>
	// Token: 0x0200010E RID: 270
	[Target("Debugger")]
	public sealed class DebuggerTarget : TargetWithLayoutHeaderAndFooter
	{
		/// <summary>
		/// Initializes the target.
		/// </summary>
		// Token: 0x06000893 RID: 2195 RVA: 0x0001E2E8 File Offset: 0x0001C4E8
		protected override void InitializeTarget()
		{
			base.InitializeTarget();
			if (base.Header != null)
			{
				Debugger.Log(LogLevel.Off.Ordinal, string.Empty, base.Header.Render(LogEventInfo.CreateNullEvent()) + "\n");
			}
		}

		/// <summary>
		/// Closes the target and releases any unmanaged resources.
		/// </summary>
		// Token: 0x06000894 RID: 2196 RVA: 0x0001E33C File Offset: 0x0001C53C
		protected override void CloseTarget()
		{
			if (base.Footer != null)
			{
				Debugger.Log(LogLevel.Off.Ordinal, string.Empty, base.Footer.Render(LogEventInfo.CreateNullEvent()) + "\n");
			}
			base.CloseTarget();
		}

		/// <summary>
		/// Writes the specified logging event to the attached debugger.
		/// </summary>
		/// <param name="logEvent">The logging event.</param>
		// Token: 0x06000895 RID: 2197 RVA: 0x0001E390 File Offset: 0x0001C590
		protected override void Write(LogEventInfo logEvent)
		{
			if (Debugger.IsLogging())
			{
				Debugger.Log(logEvent.Level.Ordinal, logEvent.LoggerName, this.Layout.Render(logEvent) + "\n");
			}
		}
	}
}
