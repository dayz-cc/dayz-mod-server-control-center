using System;
using System.Collections.Generic;
using System.Reflection;
using NLog.Common;
using NLog.Internal;

namespace NLog.Config
{
	/// <summary>
	/// Factory for locating methods.
	/// </summary>
	/// <typeparam name="TClassAttributeType">The type of the class marker attribute.</typeparam>
	/// <typeparam name="TMethodAttributeType">The type of the method marker attribute.</typeparam>
	// Token: 0x02000035 RID: 53
	internal class MethodFactory<TClassAttributeType, TMethodAttributeType> : INamedItemFactory<MethodInfo, MethodInfo>, IFactory where TClassAttributeType : Attribute where TMethodAttributeType : NameBaseAttribute
	{
		/// <summary>
		/// Gets a collection of all registered items in the factory.
		/// </summary>
		/// <returns>
		/// Sequence of key/value pairs where each key represents the name
		/// of the item and value is the <see cref="T:System.Reflection.MethodInfo" /> of
		/// the item.
		/// </returns>
		// Token: 0x17000053 RID: 83
		// (get) Token: 0x06000171 RID: 369 RVA: 0x00006EDC File Offset: 0x000050DC
		public IDictionary<string, MethodInfo> AllRegisteredItems
		{
			get
			{
				return this.nameToMethodInfo;
			}
		}

		/// <summary>
		/// Scans the assembly for classes marked with <typeparamref name="TClassAttributeType" />
		/// and methods marked with <typeparamref name="TMethodAttributeType" /> and adds them 
		/// to the factory.
		/// </summary>
		/// <param name="theAssembly">The assembly.</param>
		/// <param name="prefix">The prefix to use for names.</param>
		// Token: 0x06000172 RID: 370 RVA: 0x00006EF4 File Offset: 0x000050F4
		public void ScanAssembly(Assembly theAssembly, string prefix)
		{
			try
			{
				InternalLogger.Debug("ScanAssembly('{0}','{1}','{2}')", new object[]
				{
					theAssembly.FullName,
					typeof(TClassAttributeType),
					typeof(TMethodAttributeType)
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
		// Token: 0x06000173 RID: 371 RVA: 0x00006FBC File Offset: 0x000051BC
		public void RegisterType(Type type, string itemNamePrefix)
		{
			if (type.IsDefined(typeof(TClassAttributeType), false))
			{
				foreach (MethodInfo methodInfo in type.GetMethods())
				{
					TMethodAttributeType[] array = (TMethodAttributeType[])methodInfo.GetCustomAttributes(typeof(TMethodAttributeType), false);
					foreach (TMethodAttributeType tmethodAttributeType in array)
					{
						this.RegisterDefinition(itemNamePrefix + tmethodAttributeType.Name, methodInfo);
					}
				}
			}
		}

		/// <summary>
		/// Clears contents of the factory.
		/// </summary>
		// Token: 0x06000174 RID: 372 RVA: 0x00007068 File Offset: 0x00005268
		public void Clear()
		{
			this.nameToMethodInfo.Clear();
		}

		/// <summary>
		/// Registers the definition of a single method.
		/// </summary>
		/// <param name="name">The method name.</param>
		/// <param name="methodInfo">The method info.</param>
		// Token: 0x06000175 RID: 373 RVA: 0x00007077 File Offset: 0x00005277
		public void RegisterDefinition(string name, MethodInfo methodInfo)
		{
			this.nameToMethodInfo[name] = methodInfo;
		}

		/// <summary>
		/// Tries to retrieve method by name.
		/// </summary>
		/// <param name="name">The method name.</param>
		/// <param name="result">The result.</param>
		/// <returns>A value of <c>true</c> if the method was found, <c>false</c> otherwise.</returns>
		// Token: 0x06000176 RID: 374 RVA: 0x00007088 File Offset: 0x00005288
		public bool TryCreateInstance(string name, out MethodInfo result)
		{
			return this.nameToMethodInfo.TryGetValue(name, out result);
		}

		/// <summary>
		/// Retrieves method by name.
		/// </summary>
		/// <param name="name">Method name.</param>
		/// <returns>MethodInfo object.</returns>
		// Token: 0x06000177 RID: 375 RVA: 0x000070A8 File Offset: 0x000052A8
		public MethodInfo CreateInstance(string name)
		{
			MethodInfo methodInfo;
			if (this.TryCreateInstance(name, out methodInfo))
			{
				return methodInfo;
			}
			throw new NLogConfigurationException("Unknown function: '" + name + "'");
		}

		/// <summary>
		/// Tries to get method definition.
		/// </summary>
		/// <param name="name">The method .</param>
		/// <param name="result">The result.</param>
		/// <returns>A value of <c>true</c> if the method was found, <c>false</c> otherwise.</returns>
		// Token: 0x06000178 RID: 376 RVA: 0x000070E4 File Offset: 0x000052E4
		public bool TryGetDefinition(string name, out MethodInfo result)
		{
			return this.nameToMethodInfo.TryGetValue(name, out result);
		}

		// Token: 0x0400007D RID: 125
		private readonly Dictionary<string, MethodInfo> nameToMethodInfo = new Dictionary<string, MethodInfo>();
	}
}
