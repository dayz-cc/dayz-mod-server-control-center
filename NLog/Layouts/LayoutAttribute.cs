using System;
using NLog.Config;

namespace NLog.Layouts
{
	/// <summary>
	/// Marks class as a layout renderer and assigns a format string to it.
	/// </summary>
	// Token: 0x020000DE RID: 222
	[AttributeUsage(AttributeTargets.Class)]
	public sealed class LayoutAttribute : NameBaseAttribute
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Layouts.LayoutAttribute" /> class.
		/// </summary>
		/// <param name="name">Layout name.</param>
		// Token: 0x06000531 RID: 1329 RVA: 0x00012055 File Offset: 0x00010255
		public LayoutAttribute(string name)
			: base(name)
		{
		}
	}
}
