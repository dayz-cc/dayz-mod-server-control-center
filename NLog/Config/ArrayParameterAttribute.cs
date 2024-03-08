using System;

namespace NLog.Config
{
	/// <summary>
	/// Used to mark configurable parameters which are arrays. 
	/// Specifies the mapping between XML elements and .NET types.
	/// </summary>
	// Token: 0x02000025 RID: 37
	[AttributeUsage(AttributeTargets.Property)]
	public sealed class ArrayParameterAttribute : Attribute
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Config.ArrayParameterAttribute" /> class.
		/// </summary>
		/// <param name="itemType">The type of the array item.</param>
		/// <param name="elementName">The XML element name that represents the item.</param>
		// Token: 0x060000F5 RID: 245 RVA: 0x00005421 File Offset: 0x00003621
		public ArrayParameterAttribute(Type itemType, string elementName)
		{
			this.ItemType = itemType;
			this.ElementName = elementName;
		}

		/// <summary>
		/// Gets the .NET type of the array item.
		/// </summary>
		// Token: 0x17000035 RID: 53
		// (get) Token: 0x060000F6 RID: 246 RVA: 0x0000543C File Offset: 0x0000363C
		// (set) Token: 0x060000F7 RID: 247 RVA: 0x00005453 File Offset: 0x00003653
		public Type ItemType { get; private set; }

		/// <summary>
		/// Gets the XML element name.
		/// </summary>
		// Token: 0x17000036 RID: 54
		// (get) Token: 0x060000F8 RID: 248 RVA: 0x0000545C File Offset: 0x0000365C
		// (set) Token: 0x060000F9 RID: 249 RVA: 0x00005473 File Offset: 0x00003673
		public string ElementName { get; private set; }
	}
}
