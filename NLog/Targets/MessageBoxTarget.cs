using System;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using NLog.Common;
using NLog.Internal;
using NLog.Layouts;

namespace NLog.Targets
{
	/// <summary>
	/// Pops up log messages as message boxes.
	/// </summary>
	/// <seealso href="http://nlog-project.org/wiki/MessageBox_target">Documentation on NLog Wiki</seealso>
	/// <example>
	/// <p>
	/// To set up the target in the <a href="config.html">configuration file</a>, 
	/// use the following syntax:
	/// </p>
	/// <code lang="XML" source="examples/targets/Configuration File/MessageBox/NLog.config" />
	/// <p>
	/// This assumes just one target and a single rule. More configuration
	/// options are described <a href="config.html">here</a>.
	/// </p>
	/// <p>
	/// The result is a message box:
	/// </p>
	/// <img src="examples/targets/Screenshots/MessageBox/MessageBoxTarget.gif" />
	/// <p>
	/// To set up the log target programmatically use code like this:
	/// </p>
	/// <code lang="C#" source="examples/targets/Configuration API/MessageBox/Simple/Example.cs" />
	/// </example>
	// Token: 0x0200011A RID: 282
	[Target("MessageBox")]
	public sealed class MessageBoxTarget : TargetWithLayout
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Targets.MessageBoxTarget" /> class.
		/// </summary>
		/// <remarks>
		/// The default value of the layout is: <code>${longdate}|${level:uppercase=true}|${logger}|${message}</code>
		/// </remarks>
		// Token: 0x0600095B RID: 2395 RVA: 0x000218E8 File Offset: 0x0001FAE8
		public MessageBoxTarget()
		{
			this.Caption = "NLog";
		}

		/// <summary>
		/// Gets or sets the message box title.
		/// </summary>
		/// <docgen category="UI Options" order="10" />
		// Token: 0x170001F0 RID: 496
		// (get) Token: 0x0600095C RID: 2396 RVA: 0x00021904 File Offset: 0x0001FB04
		// (set) Token: 0x0600095D RID: 2397 RVA: 0x0002191B File Offset: 0x0001FB1B
		public Layout Caption { get; set; }

		/// <summary>
		/// Displays the message box with the log message and caption specified in the Caption
		/// parameter.
		/// </summary>
		/// <param name="logEvent">The logging event.</param>
		// Token: 0x0600095E RID: 2398 RVA: 0x00021924 File Offset: 0x0001FB24
		[SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions", Justification = "This is just debugging output.")]
		protected override void Write(LogEventInfo logEvent)
		{
			MessageBoxHelper.Show(this.Layout.Render(logEvent), this.Caption.Render(logEvent));
		}

		/// <summary>
		/// Displays the message box with the array of rendered logs messages and caption specified in the Caption
		/// parameter.
		/// </summary>
		/// <param name="logEvents">The array of logging events.</param>
		// Token: 0x0600095F RID: 2399 RVA: 0x00021948 File Offset: 0x0001FB48
		[SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions", Justification = "This is just debugging output.")]
		protected override void Write(AsyncLogEventInfo[] logEvents)
		{
			if (logEvents.Length != 0)
			{
				StringBuilder stringBuilder = new StringBuilder();
				AsyncLogEventInfo asyncLogEventInfo = logEvents[logEvents.Length - 1];
				foreach (AsyncLogEventInfo asyncLogEventInfo2 in logEvents)
				{
					stringBuilder.Append(this.Layout.Render(asyncLogEventInfo2.LogEvent));
					stringBuilder.Append("\n");
				}
				MessageBoxHelper.Show(stringBuilder.ToString(), this.Caption.Render(asyncLogEventInfo.LogEvent));
				for (int j = 0; j < logEvents.Length; j++)
				{
					logEvents[j].Continuation(null);
				}
			}
		}
	}
}
