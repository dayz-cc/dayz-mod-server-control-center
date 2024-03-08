using System;
using System.ComponentModel;

namespace NLog.Targets
{
	/// <summary>
	/// Writes log messages to the console.
	/// </summary>
	/// <seealso href="http://nlog-project.org/wiki/Console_target">Documentation on NLog Wiki</seealso>
	/// <example>
	/// <p>
	/// To set up the target in the <a href="config.html">configuration file</a>, 
	/// use the following syntax:
	/// </p>
	/// <code lang="XML" source="examples/targets/Configuration File/Console/NLog.config" />
	/// <p>
	/// This assumes just one target and a single rule. More configuration
	/// options are described <a href="config.html">here</a>.
	/// </p>
	/// <p>
	/// To set up the log target programmatically use code like this:
	/// </p>
	/// <code lang="C#" source="examples/targets/Configuration API/Console/Simple/Example.cs" />
	/// </example>
	// Token: 0x02000109 RID: 265
	[Target("Console")]
	public sealed class ConsoleTarget : TargetWithLayoutHeaderAndFooter
	{
		/// <summary>
		/// Gets or sets a value indicating whether to send the log messages to the standard error instead of the standard output.
		/// </summary>
		/// <docgen category="Console Options" order="10" />
		// Token: 0x1700018F RID: 399
		// (get) Token: 0x06000832 RID: 2098 RVA: 0x0001D184 File Offset: 0x0001B384
		// (set) Token: 0x06000833 RID: 2099 RVA: 0x0001D19B File Offset: 0x0001B39B
		[DefaultValue(false)]
		public bool Error { get; set; }

		/// <summary>
		/// Initializes the target.
		/// </summary>
		// Token: 0x06000834 RID: 2100 RVA: 0x0001D1A4 File Offset: 0x0001B3A4
		protected override void InitializeTarget()
		{
			base.InitializeTarget();
			if (base.Header != null)
			{
				this.Output(base.Header.Render(LogEventInfo.CreateNullEvent()));
			}
		}

		/// <summary>
		/// Closes the target and releases any unmanaged resources.
		/// </summary>
		// Token: 0x06000835 RID: 2101 RVA: 0x0001D1E0 File Offset: 0x0001B3E0
		protected override void CloseTarget()
		{
			if (base.Footer != null)
			{
				this.Output(base.Footer.Render(LogEventInfo.CreateNullEvent()));
			}
			base.CloseTarget();
		}

		/// <summary>
		/// Writes the specified logging event to the Console.Out or
		/// Console.Error depending on the value of the Error flag.
		/// </summary>
		/// <param name="logEvent">The logging event.</param>
		/// <remarks>
		/// Note that the Error option is not supported on .NET Compact Framework.
		/// </remarks>
		// Token: 0x06000836 RID: 2102 RVA: 0x0001D21B File Offset: 0x0001B41B
		protected override void Write(LogEventInfo logEvent)
		{
			this.Output(this.Layout.Render(logEvent));
		}

		// Token: 0x06000837 RID: 2103 RVA: 0x0001D234 File Offset: 0x0001B434
		private void Output(string s)
		{
			if (this.Error)
			{
				Console.Error.WriteLine(s);
			}
			else
			{
				Console.Out.WriteLine(s);
			}
		}
	}
}
