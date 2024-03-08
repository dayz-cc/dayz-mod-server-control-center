using System;
using System.Collections.Generic;

namespace NLog.Internal
{
	/// <summary>
	/// Provides helpers to sort log events and associated continuations.
	/// </summary>
	// Token: 0x02000087 RID: 135
	internal static class SortHelpers
	{
		/// <summary>
		/// Performs bucket sort (group by) on an array of items and returns a dictionary for easy traversal of the result set.
		/// </summary>
		/// <typeparam name="TValue">The type of the value.</typeparam>
		/// <typeparam name="TKey">The type of the key.</typeparam>
		/// <param name="inputs">The inputs.</param>
		/// <param name="keySelector">The key selector function.</param>
		/// <returns>
		/// Dictonary where keys are unique input keys, and values are lists of <see cref="T:NLog.Common.AsyncLogEventInfo" />.
		/// </returns>
		// Token: 0x06000347 RID: 839 RVA: 0x0000D0B8 File Offset: 0x0000B2B8
		public static Dictionary<TKey, List<TValue>> BucketSort<TValue, TKey>(this IEnumerable<TValue> inputs, SortHelpers.KeySelector<TValue, TKey> keySelector)
		{
			Dictionary<TKey, List<TValue>> dictionary = new Dictionary<TKey, List<TValue>>();
			foreach (TValue tvalue in inputs)
			{
				TKey tkey = keySelector(tvalue);
				List<TValue> list;
				if (!dictionary.TryGetValue(tkey, out list))
				{
					list = new List<TValue>();
					dictionary.Add(tkey, list);
				}
				list.Add(tvalue);
			}
			return dictionary;
		}

		/// <summary>
		/// Key selector delegate.
		/// </summary>
		/// <typeparam name="TValue">The type of the value.</typeparam>
		/// <typeparam name="TKey">The type of the key.</typeparam>
		/// <param name="value">Value to extract key information from.</param>
		/// <returns>Key selected from log event.</returns>
		// Token: 0x02000088 RID: 136
		// (Invoke) Token: 0x06000349 RID: 841
		internal delegate TKey KeySelector<TValue, TKey>(TValue value);
	}
}
