using System;

namespace NLog.Config
{
	/// <summary>
	/// Attaches a simple name to an item (such as <see cref="T:NLog.Targets.Target" />, 
	/// <see cref="T:NLog.LayoutRenderers.LayoutRenderer" />, <see cref="T:NLog.Layouts.Layout" />, etc.).
	/// </summary>
	// Token: 0x02000015 RID: 21
	public abstract class NameBaseAttribute : Attribute
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Config.NameBaseAttribute" /> class.
		/// </summary>
		/// <param name="name">The name of the item.</param>
		// Token: 0x060000A0 RID: 160 RVA: 0x00003790 File Offset: 0x00001990
		protected NameBaseAttribute(string name)
		{
			this.Name = name;
		}

		/// <summary>
		/// Gets the name of the item.
		/// </summary>
		/// <value>The name of the item.</value>
		// Token: 0x17000028 RID: 40
		// (get) Token: 0x060000A1 RID: 161 RVA: 0x000037A4 File Offset: 0x000019A4
		// (set) Token: 0x060000A2 RID: 162 RVA: 0x000037BB File Offset: 0x000019BB
		public string Name { get; private set; }
	}
}
