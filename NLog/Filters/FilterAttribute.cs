using System;
using NLog.Config;

namespace NLog.Filters
{
	/// <summary>
	/// Marks class as a layout renderer and assigns a name to it.
	/// </summary>
	// Token: 0x0200003F RID: 63
	[AttributeUsage(AttributeTargets.Class)]
	public sealed class FilterAttribute : NameBaseAttribute
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Filters.FilterAttribute" /> class.
		/// </summary>
		/// <param name="name">Name of the filter.</param>
		// Token: 0x060001C3 RID: 451 RVA: 0x00009161 File Offset: 0x00007361
		public FilterAttribute(string name)
			: base(name)
		{
		}
	}
}
