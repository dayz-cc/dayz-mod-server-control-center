using System;
using NLog.Config;

namespace NLog.Internal
{
	/// <summary>
	/// Supports object initialization and termination.
	/// </summary>
	// Token: 0x0200006C RID: 108
	internal interface ISupportsInitialize
	{
		/// <summary>
		/// Initializes this instance.
		/// </summary>
		/// <param name="configuration">The configuration.</param>
		// Token: 0x060002B9 RID: 697
		void Initialize(LoggingConfiguration configuration);

		/// <summary>
		/// Closes this instance.
		/// </summary>
		// Token: 0x060002BA RID: 698
		void Close();
	}
}
