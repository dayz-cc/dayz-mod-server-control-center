using System;
using NLog.Config;

namespace NLog.Internal
{
	/// <summary>
	/// Allows components to request stack trace information to be provided in the <see cref="T:NLog.LogEventInfo" />.
	/// </summary>
	// Token: 0x0200006D RID: 109
	internal interface IUsesStackTrace
	{
		/// <summary>
		/// Gets the level of stack trace information required by the implementing class.
		/// </summary>
		// Token: 0x1700008F RID: 143
		// (get) Token: 0x060002BB RID: 699
		StackTraceUsage StackTraceUsage { get; }
	}
}
