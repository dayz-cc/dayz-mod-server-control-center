using System;

namespace NLog.Internal
{
	/// <summary>
	/// Parameter validation utilities.
	/// </summary>
	// Token: 0x0200007D RID: 125
	internal static class ParameterUtils
	{
		/// <summary>
		/// Asserts that the value is not null and throws <see cref="T:System.ArgumentNullException" /> otherwise.
		/// </summary>
		/// <param name="value">The value to check.</param>
		/// <param name="parameterName">Name of the parameter.</param>
		// Token: 0x06000318 RID: 792 RVA: 0x0000C2F0 File Offset: 0x0000A4F0
		public static void AssertNotNull(object value, string parameterName)
		{
			if (value == null)
			{
				throw new ArgumentNullException(parameterName);
			}
		}
	}
}
