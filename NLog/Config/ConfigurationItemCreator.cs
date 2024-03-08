using System;

namespace NLog.Config
{
	/// <summary>
	/// Constructs a new instance the configuration item (target, layout, layout renderer, etc.) given its type.
	/// </summary>
	/// <param name="itemType">Type of the item.</param>
	/// <returns>Created object of the specified type.</returns>
	// Token: 0x02000027 RID: 39
	// (Invoke) Token: 0x060000FE RID: 254
	public delegate object ConfigurationItemCreator(Type itemType);
}
