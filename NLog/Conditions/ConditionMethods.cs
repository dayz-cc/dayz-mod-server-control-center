using System;
using System.Diagnostics.CodeAnalysis;

namespace NLog.Conditions
{
	/// <summary>
	/// A bunch of utility methods (mostly predicates) which can be used in
	/// condition expressions. Parially inspired by XPath 1.0.
	/// </summary>
	// Token: 0x02000018 RID: 24
	[ConditionMethods]
	public static class ConditionMethods
	{
		/// <summary>
		/// Compares two values for equality.
		/// </summary>
		/// <param name="firstValue">The first value.</param>
		/// <param name="secondValue">The second value.</param>
		/// <returns><b>true</b> when two objects are equal, <b>false</b> otherwise.</returns>
		// Token: 0x060000AB RID: 171 RVA: 0x00003B24 File Offset: 0x00001D24
		[ConditionMethod("equals")]
		public static bool Equals2(object firstValue, object secondValue)
		{
			return firstValue.Equals(secondValue);
		}

		/// <summary>
		/// Compares two strings for equality.
		/// </summary>
		/// <param name="firstValue">The first string.</param>
		/// <param name="secondValue">The second string.</param>
		/// <param name="ignoreCase">Optional. If <c>true</c>, case is ignored; if <c>false</c> (default), case is significant.</param>
		/// <returns><b>true</b> when two strings are equal, <b>false</b> otherwise.</returns>
		// Token: 0x060000AC RID: 172 RVA: 0x00003B40 File Offset: 0x00001D40
		[ConditionMethod("strequals")]
		[SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Not called directly, only ever Invoked.")]
		public static bool Equals2(string firstValue, string secondValue, bool ignoreCase = false)
		{
			return firstValue.Equals(secondValue, ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);
		}

		/// <summary>
		/// Gets or sets a value indicating whether the second string is a substring of the first one.
		/// </summary>
		/// <param name="haystack">The first string.</param>
		/// <param name="needle">The second string.</param>
		/// <param name="ignoreCase">Optional. If <c>true</c> (default), case is ignored; if <c>false</c>, case is significant.</param>
		/// <returns><b>true</b> when the second string is a substring of the first string, <b>false</b> otherwise.</returns>
		// Token: 0x060000AD RID: 173 RVA: 0x00003B64 File Offset: 0x00001D64
		[SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Not called directly, only ever Invoked.")]
		[ConditionMethod("contains")]
		public static bool Contains(string haystack, string needle, bool ignoreCase = true)
		{
			return haystack.IndexOf(needle, ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal) >= 0;
		}

		/// <summary>
		/// Gets or sets a value indicating whether the second string is a prefix of the first one.
		/// </summary>
		/// <param name="haystack">The first string.</param>
		/// <param name="needle">The second string.</param>
		/// <param name="ignoreCase">Optional. If <c>true</c> (default), case is ignored; if <c>false</c>, case is significant.</param>
		/// <returns><b>true</b> when the second string is a prefix of the first string, <b>false</b> otherwise.</returns>
		// Token: 0x060000AE RID: 174 RVA: 0x00003B90 File Offset: 0x00001D90
		[SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Not called directly, only ever Invoked.")]
		[ConditionMethod("starts-with")]
		public static bool StartsWith(string haystack, string needle, bool ignoreCase = true)
		{
			return haystack.StartsWith(needle, ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);
		}

		/// <summary>
		/// Gets or sets a value indicating whether the second string is a suffix of the first one.
		/// </summary>
		/// <param name="haystack">The first string.</param>
		/// <param name="needle">The second string.</param>
		/// <param name="ignoreCase">Optional. If <c>true</c> (default), case is ignored; if <c>false</c>, case is significant.</param>
		/// <returns><b>true</b> when the second string is a prefix of the first string, <b>false</b> otherwise.</returns>
		// Token: 0x060000AF RID: 175 RVA: 0x00003BB4 File Offset: 0x00001DB4
		[SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Justification = "Not called directly, only ever Invoked.")]
		[ConditionMethod("ends-with")]
		public static bool EndsWith(string haystack, string needle, bool ignoreCase = true)
		{
			return haystack.EndsWith(needle, ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);
		}

		/// <summary>
		/// Returns the length of a string.
		/// </summary>
		/// <param name="text">A string whose lengths is to be evaluated.</param>
		/// <returns>The length of the string.</returns>
		// Token: 0x060000B0 RID: 176 RVA: 0x00003BD8 File Offset: 0x00001DD8
		[ConditionMethod("length")]
		public static int Length(string text)
		{
			return text.Length;
		}
	}
}
