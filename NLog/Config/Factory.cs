using System;
using System.Collections.Generic;
using System.Reflection;
using NLog.Common;
using NLog.Internal;

namespace NLog.Config
{
	/// <summary>
	/// Factory for class-based items.
	/// </summary>
	/// <typeparam name="TBaseType">The base type of each item.</typeparam>
	/// <typeparam name="TAttributeType">The type of the attribute used to annotate itemss.</typeparam>
	// Token: 0x0200002C RID: 44
	internal class Factory<TBaseType, TAttributeType> : INamedItemFactory<TBaseType, Type>, IFactory where TBaseType : class where TAttributeType : NameBaseAttribute
	{
		// Token: 0x0600011C RID: 284 RVA: 0x00005A35 File Offset: 0x00003C35
		internal Factory(ConfigurationItemFactory parentFactory)
		{
			this.parentFactory = parentFactory;
		}

		/// <summary>
		/// Scans the assembly.
		/// </summary>
		/// <param name="theAssembly">The assembly.</param>
		/// <param name="prefix">The prefix.</param>
		// Token: 0x0600011D RID: 285 RVA: 0x00005A58 File Offset: 0x00003C58
		public void ScanAssembly(Assembly theAssembly, string prefix)
		{
			try
			{
				InternalLogger.Debug("ScanAssembly('{0}','{1}','{2}')", new object[]
				{
					theAssembly.FullName,
					typeof(TAttributeType),
					typeof(TBaseType)
				});
				foreach (Type type in theAssembly.SafeGetTypes())
				{
					this.RegisterType(type, prefix);
				}
			}
			catch (Exception ex)
			{
				if (ex.MustBeRethrown())
				{
					throw;
				}
				InternalLogger.Error("Failed to add targets from '" + theAssembly.FullName + "': {0}", new object[] { ex });
			}
		}

		/// <summary>
		/// Registers the type.
		/// </summary>
		/// <param name="type">The type to register.</param>
		/// <param name="itemNamePrefix">The item name prefix.</param>
		// Token: 0x0600011E RID: 286 RVA: 0x00005B20 File Offset: 0x00003D20
		public void RegisterType(Type type, string itemNamePrefix)
		{
			TAttributeType[] array = (TAttributeType[])type.GetCustomAttributes(typeof(TAttributeType), false);
			if (array != null)
			{
				foreach (TAttributeType tattributeType in array)
				{
					this.RegisterDefinition(itemNamePrefix + tattributeType.Name, type);
				}
			}
		}

		/// <summary>
		/// Registers the item based on a type name.
		/// </summary>
		/// <param name="itemName">Name of the item.</param>
		/// <param name="typeName">Name of the type.</param>
		// Token: 0x0600011F RID: 287 RVA: 0x00005BB8 File Offset: 0x00003DB8
		public void RegisterNamedType(string itemName, string typeName)
		{
			this.items[itemName] = () => Type.GetType(typeName, false);
		}

		/// <summary>
		/// Clears the contents of the factory.
		/// </summary>
		// Token: 0x06000120 RID: 288 RVA: 0x00005BED File Offset: 0x00003DED
		public void Clear()
		{
			this.items.Clear();
		}

		/// <summary>
		/// Registers a single type definition.
		/// </summary>
		/// <param name="name">The item name.</param>
		/// <param name="type">The type of the item.</param>
		// Token: 0x06000121 RID: 289 RVA: 0x00005C1C File Offset: 0x00003E1C
		public void RegisterDefinition(string name, Type type)
		{
			this.items[name] = () => type;
		}

		/// <summary>
		/// Tries to get registed item definition.
		/// </summary>
		/// <param name="itemName">Name of the item.</param>
		/// <param name="result">Reference to a variable which will store the item definition.</param>
		/// <returns>Item definition.</returns>
		// Token: 0x06000122 RID: 290 RVA: 0x00005C54 File Offset: 0x00003E54
		public bool TryGetDefinition(string itemName, out Type result)
		{
			Factory<TBaseType, TAttributeType>.GetTypeDelegate getTypeDelegate;
			bool flag;
			if (!this.items.TryGetValue(itemName, out getTypeDelegate))
			{
				result = null;
				flag = false;
			}
			else
			{
				try
				{
					result = getTypeDelegate();
					flag = result != null;
				}
				catch (Exception ex)
				{
					if (ex.MustBeRethrown())
					{
						throw;
					}
					result = null;
					flag = false;
				}
			}
			return flag;
		}

		/// <summary>
		/// Tries to create an item instance.
		/// </summary>
		/// <param name="itemName">Name of the item.</param>
		/// <param name="result">The result.</param>
		/// <returns>True if instance was created successfully, false otherwise.</returns>
		// Token: 0x06000123 RID: 291 RVA: 0x00005CBC File Offset: 0x00003EBC
		public bool TryCreateInstance(string itemName, out TBaseType result)
		{
			Type type;
			bool flag;
			if (!this.TryGetDefinition(itemName, out type))
			{
				result = default(TBaseType);
				flag = false;
			}
			else
			{
				result = (TBaseType)((object)this.parentFactory.CreateInstance(type));
				flag = true;
			}
			return flag;
		}

		/// <summary>
		/// Creates an item instance.
		/// </summary>
		/// <param name="name">The name of the item.</param>
		/// <returns>Created item.</returns>
		// Token: 0x06000124 RID: 292 RVA: 0x00005D04 File Offset: 0x00003F04
		public TBaseType CreateInstance(string name)
		{
			TBaseType tbaseType;
			if (this.TryCreateInstance(name, out tbaseType))
			{
				return tbaseType;
			}
			throw new ArgumentException(typeof(TBaseType).Name + " cannot be found: '" + name + "'");
		}

		// Token: 0x0400005F RID: 95
		private readonly Dictionary<string, Factory<TBaseType, TAttributeType>.GetTypeDelegate> items = new Dictionary<string, Factory<TBaseType, TAttributeType>.GetTypeDelegate>(StringComparer.OrdinalIgnoreCase);

		// Token: 0x04000060 RID: 96
		private ConfigurationItemFactory parentFactory;

		// Token: 0x0200002D RID: 45
		// (Invoke) Token: 0x06000126 RID: 294
		private delegate Type GetTypeDelegate();
	}
}
