using System;
using System.Collections;
using System.Collections.Generic;

namespace NLog.Internal
{
	/// <summary>
	/// LINQ-like helpers (cannot use LINQ because we must work with .NET 2.0 profile).
	/// </summary>
	// Token: 0x02000057 RID: 87
	internal static class EnumerableHelpers
	{
		/// <summary>
		/// Filters the given enumerable to return only items of the specified type.
		/// </summary>
		/// <typeparam name="T">
		/// Type of the item.
		/// </typeparam>
		/// <param name="enumerable">
		/// The enumerable.
		/// </param>
		/// <returns>
		/// Items of specified type.
		/// </returns>
		// Token: 0x06000243 RID: 579 RVA: 0x00009D10 File Offset: 0x00007F10
		public static IEnumerable<T> OfType<T>(this IEnumerable enumerable) where T : class
		{
			foreach (object o in enumerable)
			{
				T t = o as T;
				if (t != null)
				{
					yield return t;
				}
			}
			yield break;
		}

		/// <summary>
		/// Reverses the specified enumerable.
		/// </summary>
		/// <typeparam name="T">
		/// Type of enumerable item.
		/// </typeparam>
		/// <param name="enumerable">
		/// The enumerable.
		/// </param>
		/// <returns>
		/// Reversed enumerable.
		/// </returns>
		// Token: 0x06000244 RID: 580 RVA: 0x00009D34 File Offset: 0x00007F34
		public static IEnumerable<T> Reverse<T>(this IEnumerable<T> enumerable) where T : class
		{
			List<T> list = new List<T>(enumerable);
			list.Reverse();
			return list;
		}

		/// <summary>
		/// Determines is the given predicate is met by any element of the enumerable.
		/// </summary>
		/// <typeparam name="T">Element type.</typeparam>
		/// <param name="enumerable">The enumerable.</param>
		/// <param name="predicate">The predicate.</param>
		/// <returns>True if predicate returns true for any element of the collection, false otherwise.</returns>
		// Token: 0x06000245 RID: 581 RVA: 0x00009D58 File Offset: 0x00007F58
		public static bool Any<T>(this IEnumerable<T> enumerable, Predicate<T> predicate)
		{
			foreach (T t in enumerable)
			{
				if (predicate(t))
				{
					return true;
				}
			}
			return false;
		}

		/// <summary>
		/// Converts the enumerable to list.
		/// </summary>
		/// <typeparam name="T">Type of the list element.</typeparam>
		/// <param name="enumerable">The enumerable.</param>
		/// <returns>List of elements.</returns>
		// Token: 0x06000246 RID: 582 RVA: 0x00009DC0 File Offset: 0x00007FC0
		public static List<T> ToList<T>(this IEnumerable<T> enumerable)
		{
			return new List<T>(enumerable);
		}
	}
}
