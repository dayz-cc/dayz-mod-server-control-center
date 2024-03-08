using System;
using System.Threading;

namespace NLog.Internal
{
	/// <summary>
	/// Helper class for dealing with exceptions.
	/// </summary>
	// Token: 0x02000059 RID: 89
	internal static class ExceptionHelper
	{
		/// <summary>
		/// Determines whether the exception must be rethrown.
		/// </summary>
		/// <param name="exception">The exception.</param>
		/// <returns>True if the exception must be rethrown, false otherwise.</returns>
		// Token: 0x06000249 RID: 585 RVA: 0x00009E48 File Offset: 0x00008048
		public static bool MustBeRethrown(this Exception exception)
		{
			return exception is StackOverflowException || exception is ThreadAbortException || exception is OutOfMemoryException || exception is NLogConfigurationException;
		}
	}
}
