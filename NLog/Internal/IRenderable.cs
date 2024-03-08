using System;

namespace NLog.Internal
{
	/// <summary>
	/// Interface implemented by layouts and layout renderers.
	/// </summary>
	// Token: 0x0200006A RID: 106
	internal interface IRenderable
	{
		/// <summary>
		/// Renders the the value of layout or layout renderer in the context of the specified log event.
		/// </summary>
		/// <param name="logEvent">The log event.</param>
		/// <returns>String representation of a layout.</returns>
		// Token: 0x060002AF RID: 687
		string Render(LogEventInfo logEvent);
	}
}
