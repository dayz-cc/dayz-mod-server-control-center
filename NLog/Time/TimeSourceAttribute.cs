using System;
using NLog.Config;

namespace NLog.Time
{
	/// <summary>
	/// Marks class as a time source and assigns a name to it.
	/// </summary>
	// Token: 0x02000149 RID: 329
	[AttributeUsage(AttributeTargets.Class)]
	public sealed class TimeSourceAttribute : NameBaseAttribute
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Time.TimeSourceAttribute" /> class.
		/// </summary>
		/// <param name="name">Name of the time source.</param>
		// Token: 0x06000A97 RID: 2711 RVA: 0x00025877 File Offset: 0x00023A77
		public TimeSourceAttribute(string name)
			: base(name)
		{
		}
	}
}
