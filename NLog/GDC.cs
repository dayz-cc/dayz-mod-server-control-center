using System;

namespace NLog
{
	/// <summary>
	/// Global Diagnostics Context - used for log4net compatibility.
	/// </summary>
	// Token: 0x02000046 RID: 70
	[Obsolete("Use GlobalDiagnosticsContext instead")]
	public static class GDC
	{
		/// <summary>
		/// Sets the Global Diagnostics Context item to the specified value.
		/// </summary>
		/// <param name="item">Item name.</param>
		/// <param name="value">Item value.</param>
		// Token: 0x060001DF RID: 479 RVA: 0x000093EB File Offset: 0x000075EB
		public static void Set(string item, string value)
		{
			GlobalDiagnosticsContext.Set(item, value);
		}

		/// <summary>
		/// Gets the Global Diagnostics Context named item.
		/// </summary>
		/// <param name="item">Item name.</param>
		/// <returns>The item value of string.Empty if the value is not present.</returns>
		// Token: 0x060001E0 RID: 480 RVA: 0x000093F8 File Offset: 0x000075F8
		public static string Get(string item)
		{
			return GlobalDiagnosticsContext.Get(item);
		}

		/// <summary>
		/// Checks whether the specified item exists in the Global Diagnostics Context.
		/// </summary>
		/// <param name="item">Item name.</param>
		/// <returns>A boolean indicating whether the specified item exists in current thread GDC.</returns>
		// Token: 0x060001E1 RID: 481 RVA: 0x00009410 File Offset: 0x00007610
		public static bool Contains(string item)
		{
			return GlobalDiagnosticsContext.Contains(item);
		}

		/// <summary>
		/// Removes the specified item from the Global Diagnostics Context.
		/// </summary>
		/// <param name="item">Item name.</param>
		// Token: 0x060001E2 RID: 482 RVA: 0x00009428 File Offset: 0x00007628
		public static void Remove(string item)
		{
			GlobalDiagnosticsContext.Remove(item);
		}

		/// <summary>
		/// Clears the content of the GDC.
		/// </summary>
		// Token: 0x060001E3 RID: 483 RVA: 0x00009432 File Offset: 0x00007632
		public static void Clear()
		{
			GlobalDiagnosticsContext.Clear();
		}
	}
}
