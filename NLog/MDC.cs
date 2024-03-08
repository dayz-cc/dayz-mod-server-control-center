using System;

namespace NLog
{
	/// <summary>
	/// Mapped Diagnostics Context - used for log4net compatibility.
	/// </summary>
	// Token: 0x020000F6 RID: 246
	[Obsolete("Use MappedDiagnosticsContext instead")]
	public static class MDC
	{
		/// <summary>
		/// Sets the current thread MDC item to the specified value.
		/// </summary>
		/// <param name="item">Item name.</param>
		/// <param name="value">Item value.</param>
		// Token: 0x06000781 RID: 1921 RVA: 0x0001A7F2 File Offset: 0x000189F2
		public static void Set(string item, string value)
		{
			MappedDiagnosticsContext.Set(item, value);
		}

		/// <summary>
		/// Gets the current thread MDC named item.
		/// </summary>
		/// <param name="item">Item name.</param>
		/// <returns>The item value of string.Empty if the value is not present.</returns>
		// Token: 0x06000782 RID: 1922 RVA: 0x0001A800 File Offset: 0x00018A00
		public static string Get(string item)
		{
			return MappedDiagnosticsContext.Get(item);
		}

		/// <summary>
		/// Checks whether the specified item exists in current thread MDC.
		/// </summary>
		/// <param name="item">Item name.</param>
		/// <returns>A boolean indicating whether the specified item exists in current thread MDC.</returns>
		// Token: 0x06000783 RID: 1923 RVA: 0x0001A818 File Offset: 0x00018A18
		public static bool Contains(string item)
		{
			return MappedDiagnosticsContext.Contains(item);
		}

		/// <summary>
		/// Removes the specified item from current thread MDC.
		/// </summary>
		/// <param name="item">Item name.</param>
		// Token: 0x06000784 RID: 1924 RVA: 0x0001A830 File Offset: 0x00018A30
		public static void Remove(string item)
		{
			MappedDiagnosticsContext.Remove(item);
		}

		/// <summary>
		/// Clears the content of current thread MDC.
		/// </summary>
		// Token: 0x06000785 RID: 1925 RVA: 0x0001A83A File Offset: 0x00018A3A
		public static void Clear()
		{
			MappedDiagnosticsContext.Clear();
		}
	}
}
