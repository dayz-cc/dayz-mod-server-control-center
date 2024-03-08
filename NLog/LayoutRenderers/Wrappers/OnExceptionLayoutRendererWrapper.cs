using System;
using NLog.Config;

namespace NLog.LayoutRenderers.Wrappers
{
	/// <summary>
	/// Only outputs the inner layout when exception has been defined for log message.
	/// </summary>
	// Token: 0x020000CD RID: 205
	[LayoutRenderer("onexception")]
	[ThreadAgnostic]
	public sealed class OnExceptionLayoutRendererWrapper : WrapperLayoutRendererBase
	{
		/// <summary>
		/// Transforms the output of another layout.
		/// </summary>
		/// <param name="text">Output to be transform.</param>
		/// <returns>Transformed text.</returns>
		// Token: 0x060004C6 RID: 1222 RVA: 0x00011168 File Offset: 0x0000F368
		protected override string Transform(string text)
		{
			return text;
		}

		/// <summary>
		/// Renders the inner layout contents.
		/// </summary>
		/// <param name="logEvent">The log event.</param>
		/// <returns>
		/// Contents of inner layout.
		/// </returns>
		// Token: 0x060004C7 RID: 1223 RVA: 0x0001117C File Offset: 0x0000F37C
		protected override string RenderInner(LogEventInfo logEvent)
		{
			string text;
			if (logEvent.Exception != null)
			{
				text = base.RenderInner(logEvent);
			}
			else
			{
				text = string.Empty;
			}
			return text;
		}
	}
}
