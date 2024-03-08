using System;
using System.Collections.Generic;
using NLog.Internal;

namespace NLog
{
	/// <summary>
	/// Mapped Diagnostics Context - a thread-local structure that keeps a dictionary
	/// of strings and provides methods to output them in layouts. 
	/// Mostly for compatibility with log4net.
	/// </summary>
	// Token: 0x020000F5 RID: 245
	public static class MappedDiagnosticsContext
	{
		// Token: 0x1700015F RID: 351
		// (get) Token: 0x0600077A RID: 1914 RVA: 0x0001A754 File Offset: 0x00018954
		internal static IDictionary<string, string> ThreadDictionary
		{
			get
			{
				return ThreadLocalStorageHelper.GetDataForSlot<Dictionary<string, string>>(MappedDiagnosticsContext.dataSlot);
			}
		}

		/// <summary>
		/// Sets the current thread MDC item to the specified value.
		/// </summary>
		/// <param name="item">Item name.</param>
		/// <param name="value">Item value.</param>
		// Token: 0x0600077B RID: 1915 RVA: 0x0001A770 File Offset: 0x00018970
		public static void Set(string item, string value)
		{
			MappedDiagnosticsContext.ThreadDictionary[item] = value;
		}

		/// <summary>
		/// Gets the current thread MDC named item.
		/// </summary>
		/// <param name="item">Item name.</param>
		/// <returns>The item value of string.Empty if the value is not present.</returns>
		// Token: 0x0600077C RID: 1916 RVA: 0x0001A780 File Offset: 0x00018980
		public static string Get(string item)
		{
			string empty;
			if (!MappedDiagnosticsContext.ThreadDictionary.TryGetValue(item, out empty))
			{
				empty = string.Empty;
			}
			return empty;
		}

		/// <summary>
		/// Checks whether the specified item exists in current thread MDC.
		/// </summary>
		/// <param name="item">Item name.</param>
		/// <returns>A boolean indicating whether the specified item exists in current thread MDC.</returns>
		// Token: 0x0600077D RID: 1917 RVA: 0x0001A7AC File Offset: 0x000189AC
		public static bool Contains(string item)
		{
			return MappedDiagnosticsContext.ThreadDictionary.ContainsKey(item);
		}

		/// <summary>
		/// Removes the specified item from current thread MDC.
		/// </summary>
		/// <param name="item">Item name.</param>
		// Token: 0x0600077E RID: 1918 RVA: 0x0001A7C9 File Offset: 0x000189C9
		public static void Remove(string item)
		{
			MappedDiagnosticsContext.ThreadDictionary.Remove(item);
		}

		/// <summary>
		/// Clears the content of current thread MDC.
		/// </summary>
		// Token: 0x0600077F RID: 1919 RVA: 0x0001A7D8 File Offset: 0x000189D8
		public static void Clear()
		{
			MappedDiagnosticsContext.ThreadDictionary.Clear();
		}

		// Token: 0x0400022A RID: 554
		private static readonly object dataSlot = ThreadLocalStorageHelper.AllocateDataSlot();
	}
}
