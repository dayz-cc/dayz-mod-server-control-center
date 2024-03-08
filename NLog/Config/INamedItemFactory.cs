using System;

namespace NLog.Config
{
	/// <summary>
	/// Represents a factory of named items (such as targets, layouts, layout renderers, etc.).
	/// </summary>
	/// <typeparam name="TInstanceType">Base type for each item instance.</typeparam>
	/// <typeparam name="TDefinitionType">Item definition type (typically <see cref="T:System.Type" /> or <see cref="T:System.Reflection.MethodInfo" />).</typeparam>
	// Token: 0x0200002A RID: 42
	public interface INamedItemFactory<TInstanceType, TDefinitionType> where TInstanceType : class
	{
		/// <summary>
		/// Registers new item definition.
		/// </summary>
		/// <param name="itemName">Name of the item.</param>
		/// <param name="itemDefinition">Item definition.</param>
		// Token: 0x06000115 RID: 277
		void RegisterDefinition(string itemName, TDefinitionType itemDefinition);

		/// <summary>
		/// Tries to get registed item definition.
		/// </summary>
		/// <param name="itemName">Name of the item.</param>
		/// <param name="result">Reference to a variable which will store the item definition.</param>
		/// <returns>Item definition.</returns>
		// Token: 0x06000116 RID: 278
		bool TryGetDefinition(string itemName, out TDefinitionType result);

		/// <summary>
		/// Creates item instance.
		/// </summary>
		/// <param name="itemName">Name of the item.</param>
		/// <returns>Newly created item instance.</returns>
		// Token: 0x06000117 RID: 279
		TInstanceType CreateInstance(string itemName);

		/// <summary>
		/// Tries to create an item instance.
		/// </summary>
		/// <param name="itemName">Name of the item.</param>
		/// <param name="result">The result.</param>
		/// <returns>True if instance was created successfully, false otherwise.</returns>
		// Token: 0x06000118 RID: 280
		bool TryCreateInstance(string itemName, out TInstanceType result);
	}
}
