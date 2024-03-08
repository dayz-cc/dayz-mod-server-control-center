using System;

namespace NLog.LayoutRenderers
{
	/// <summary>
	/// Format of the ${stacktrace} layout renderer output.
	/// </summary>
	// Token: 0x020000C0 RID: 192
	public enum StackTraceFormat
	{
		/// <summary>
		/// Raw format (multiline - as returned by StackFrame.ToString() method).
		/// </summary>
		// Token: 0x04000195 RID: 405
		Raw,
		/// <summary>
		/// Flat format (class and method names displayed in a single line).
		/// </summary>
		// Token: 0x04000196 RID: 406
		Flat,
		/// <summary>
		/// Detailed flat format (method signatures displayed in a single line).
		/// </summary>
		// Token: 0x04000197 RID: 407
		DetailedFlat
	}
}
