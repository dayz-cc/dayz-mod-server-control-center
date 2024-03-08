using System;
using NLog.Config;

namespace NLog.LayoutRenderers
{
	/// <summary>
	/// Marks class as a layout renderer and assigns a format string to it.
	/// </summary>
	// Token: 0x020000AA RID: 170
	[AttributeUsage(AttributeTargets.Class)]
	public sealed class LayoutRendererAttribute : NameBaseAttribute
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.LayoutRenderers.LayoutRendererAttribute" /> class.
		/// </summary>
		/// <param name="name">Name of the layout renderer.</param>
		// Token: 0x060003FF RID: 1023 RVA: 0x0000EDEC File Offset: 0x0000CFEC
		public LayoutRendererAttribute(string name)
			: base(name)
		{
		}
	}
}
