using System;

namespace NLog.LayoutRenderers
{
	/// <summary>
	/// Gets or sets the property of System.GC to retrieve.
	/// </summary>
	// Token: 0x020000A5 RID: 165
	public enum GarbageCollectorProperty
	{
		/// <summary>
		/// Total memory allocated.
		/// </summary>
		// Token: 0x0400012C RID: 300
		TotalMemory,
		/// <summary>
		/// Total memory allocated (perform full garbage collection first).
		/// </summary>
		// Token: 0x0400012D RID: 301
		TotalMemoryForceCollection,
		/// <summary>
		/// Gets the number of Gen0 collections.
		/// </summary>
		// Token: 0x0400012E RID: 302
		CollectionCount0,
		/// <summary>
		/// Gets the number of Gen1 collections.
		/// </summary>
		// Token: 0x0400012F RID: 303
		CollectionCount1,
		/// <summary>
		/// Gets the number of Gen2 collections.
		/// </summary>
		// Token: 0x04000130 RID: 304
		CollectionCount2,
		/// <summary>
		/// Maximum generation number supported by GC.
		/// </summary>
		// Token: 0x04000131 RID: 305
		MaxGeneration
	}
}
