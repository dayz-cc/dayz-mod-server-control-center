using System;
using System.Threading;

namespace NLog.Internal
{
	/// <summary>
	/// Helper for dealing with thread-local storage.
	/// </summary>
	// Token: 0x0200008B RID: 139
	internal static class ThreadLocalStorageHelper
	{
		/// <summary>
		/// Allocates the data slot for storing thread-local information.
		/// </summary>
		/// <returns>Allocated slot key.</returns>
		// Token: 0x06000357 RID: 855 RVA: 0x0000D28C File Offset: 0x0000B48C
		public static object AllocateDataSlot()
		{
			return Thread.AllocateDataSlot();
		}

		/// <summary>
		/// Gets the data for a slot in thread-local storage.
		/// </summary>
		/// <typeparam name="T">Type of the data.</typeparam>
		/// <param name="slot">The slot to get data for.</param>
		/// <returns>
		/// Slot data (will create T if null).
		/// </returns>
		// Token: 0x06000358 RID: 856 RVA: 0x0000D2A4 File Offset: 0x0000B4A4
		public static T GetDataForSlot<T>(object slot) where T : class, new()
		{
			LocalDataStoreSlot localDataStoreSlot = (LocalDataStoreSlot)slot;
			object obj = Thread.GetData(localDataStoreSlot);
			if (obj == null)
			{
				obj = new T();
				Thread.SetData(localDataStoreSlot, obj);
			}
			return (T)((object)obj);
		}
	}
}
