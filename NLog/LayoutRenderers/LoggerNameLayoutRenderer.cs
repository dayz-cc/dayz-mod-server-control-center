using System;
using System.ComponentModel;
using System.Text;
using NLog.Config;

namespace NLog.LayoutRenderers
{
	/// <summary>
	/// The logger name.
	/// </summary>
	// Token: 0x020000AE RID: 174
	[ThreadAgnostic]
	[LayoutRenderer("logger")]
	public class LoggerNameLayoutRenderer : LayoutRenderer
	{
		/// <summary>
		/// Gets or sets a value indicating whether to render short logger name (the part after the trailing dot character).
		/// </summary>
		/// <docgen category="Rendering Options" order="10" />
		// Token: 0x170000DF RID: 223
		// (get) Token: 0x0600041F RID: 1055 RVA: 0x0000F70C File Offset: 0x0000D90C
		// (set) Token: 0x06000420 RID: 1056 RVA: 0x0000F723 File Offset: 0x0000D923
		[DefaultValue(false)]
		public bool ShortName { get; set; }

		/// <summary>
		/// Renders the logger name and appends it to the specified <see cref="T:System.Text.StringBuilder" />.
		/// </summary>
		/// <param name="builder">The <see cref="T:System.Text.StringBuilder" /> to append the rendered data to.</param>
		/// <param name="logEvent">Logging event.</param>
		// Token: 0x06000421 RID: 1057 RVA: 0x0000F72C File Offset: 0x0000D92C
		protected override void Append(StringBuilder builder, LogEventInfo logEvent)
		{
			if (this.ShortName)
			{
				int num = logEvent.LoggerName.LastIndexOf('.');
				if (num < 0)
				{
					builder.Append(logEvent.LoggerName);
				}
				else
				{
					builder.Append(logEvent.LoggerName.Substring(num + 1));
				}
			}
			else
			{
				builder.Append(logEvent.LoggerName);
			}
		}
	}
}
