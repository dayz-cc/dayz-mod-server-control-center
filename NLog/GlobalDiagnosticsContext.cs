using System;
using System.Collections.Generic;

namespace NLog
{
	/// <summary>
	/// Global Diagnostics Context - a dictionary structure to hold per-application-instance values.
	/// </summary>
	// Token: 0x02000047 RID: 71
	public static class GlobalDiagnosticsContext
	{
		/// <summary>
		/// Sets the Global Diagnostics Context item to the specified value.
		/// </summary>
		/// <param name="item">Item name.</param>
		/// <param name="value">Item value.</param>
		// Token: 0x060001E4 RID: 484 RVA: 0x0000943C File Offset: 0x0000763C
		public static void Set(string item, string value)
		{
			lock (GlobalDiagnosticsContext.dict)
			{
				GlobalDiagnosticsContext.dict[item] = value;
			}
		}

		/// <summary>
		/// Gets the Global Diagnostics Context named item.
		/// </summary>
		/// <param name="item">Item name.</param>
		/// <returns>The item value of string.Empty if the value is not present.</returns>
		// Token: 0x060001E5 RID: 485 RVA: 0x00009490 File Offset: 0x00007690
		public static string Get(string item)
		{
			string text;
			lock (GlobalDiagnosticsContext.dict)
			{
				string empty;
				if (!GlobalDiagnosticsContext.dict.TryGetValue(item, out empty))
				{
					empty = string.Empty;
				}
				text = empty;
			}
			return text;
		}

		/// <summary>
		/// Checks whether the specified item exists in the Global Diagnostics Context.
		/// </summary>
		/// <param name="item">Item name.</param>
		/// <returns>A boolean indicating whether the specified item exists in current thread GDC.</returns>
		// Token: 0x060001E6 RID: 486 RVA: 0x000094F4 File Offset: 0x000076F4
		public static bool Contains(string item)
		{
			bool flag2;
			lock (GlobalDiagnosticsContext.dict)
			{
				flag2 = GlobalDiagnosticsContext.dict.ContainsKey(item);
			}
			return flag2;
		}

		/// <summary>
		/// Removes the specified item from the Global Diagnostics Context.
		/// </summary>
		/// <param name="item">Item name.</param>
		// Token: 0x060001E7 RID: 487 RVA: 0x00009544 File Offset: 0x00007744
		public static void Remove(string item)
		{
			lock (GlobalDiagnosticsContext.dict)
			{
				GlobalDiagnosticsContext.dict.Remove(item);
			}
		}

		/// <summary>
		/// Clears the content of the GDC.
		/// </summary>
		// Token: 0x060001E8 RID: 488 RVA: 0x00009594 File Offset: 0x00007794
		public static void Clear()
		{
			lock (GlobalDiagnosticsContext.dict)
			{
				GlobalDiagnosticsContext.dict.Clear();
			}
		}

		// Token: 0x0400009E RID: 158
		private static Dictionary<string, string> dict = new Dictionary<string, string>();
	}
}
