using System;
using System.Text;
using NLog.Config;
using NLog.Internal;

namespace NLog.LayoutRenderers
{
	/// <summary>
	/// The formatted log message.
	/// </summary>
	// Token: 0x020000B2 RID: 178
	[LayoutRenderer("message")]
	[ThreadAgnostic]
	public class MessageLayoutRenderer : LayoutRenderer
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.LayoutRenderers.MessageLayoutRenderer" /> class.
		/// </summary>
		// Token: 0x06000432 RID: 1074 RVA: 0x0000FA0A File Offset: 0x0000DC0A
		public MessageLayoutRenderer()
		{
			this.ExceptionSeparator = EnvironmentHelper.NewLine;
		}

		/// <summary>
		/// Gets or sets a value indicating whether to log exception along with message.
		/// </summary>
		/// <docgen category="Layout Options" order="10" />
		// Token: 0x170000E3 RID: 227
		// (get) Token: 0x06000433 RID: 1075 RVA: 0x0000FA24 File Offset: 0x0000DC24
		// (set) Token: 0x06000434 RID: 1076 RVA: 0x0000FA3B File Offset: 0x0000DC3B
		public bool WithException { get; set; }

		/// <summary>
		/// Gets or sets the string that separates message from the exception.
		/// </summary>
		/// <docgen category="Layout Options" order="10" />
		// Token: 0x170000E4 RID: 228
		// (get) Token: 0x06000435 RID: 1077 RVA: 0x0000FA44 File Offset: 0x0000DC44
		// (set) Token: 0x06000436 RID: 1078 RVA: 0x0000FA5B File Offset: 0x0000DC5B
		public string ExceptionSeparator { get; set; }

		/// <summary>
		/// Renders the log message including any positional parameters and appends it to the specified <see cref="T:System.Text.StringBuilder" />.
		/// </summary>
		/// <param name="builder">The <see cref="T:System.Text.StringBuilder" /> to append the rendered data to.</param>
		/// <param name="logEvent">Logging event.</param>
		// Token: 0x06000437 RID: 1079 RVA: 0x0000FA64 File Offset: 0x0000DC64
		protected override void Append(StringBuilder builder, LogEventInfo logEvent)
		{
			builder.Append(logEvent.FormattedMessage);
			if (this.WithException && logEvent.Exception != null)
			{
				builder.Append(this.ExceptionSeparator);
				builder.Append(logEvent.Exception.ToString());
			}
		}
	}
}
