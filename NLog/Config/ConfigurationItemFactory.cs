using System;
using System.Collections.Generic;
using System.Reflection;
using NLog.Conditions;
using NLog.Filters;
using NLog.Internal;
using NLog.LayoutRenderers;
using NLog.Layouts;
using NLog.Targets;
using NLog.Time;

namespace NLog.Config
{
	/// <summary>
	/// Provides registration information for named items (targets, layouts, layout renderers, etc.) managed by NLog.
	/// </summary>
	// Token: 0x02000028 RID: 40
	public class ConfigurationItemFactory
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Config.ConfigurationItemFactory" /> class.
		/// </summary>
		/// <param name="assemblies">The assemblies to scan for named items.</param>
		// Token: 0x06000102 RID: 258 RVA: 0x00005518 File Offset: 0x00003718
		public ConfigurationItemFactory(params Assembly[] assemblies)
		{
			this.CreateInstance = new ConfigurationItemCreator(FactoryHelper.CreateInstance);
			this.targets = new Factory<Target, TargetAttribute>(this);
			this.filters = new Factory<Filter, FilterAttribute>(this);
			this.layoutRenderers = new Factory<LayoutRenderer, LayoutRendererAttribute>(this);
			this.layouts = new Factory<Layout, LayoutAttribute>(this);
			this.conditionMethods = new MethodFactory<ConditionMethodsAttribute, ConditionMethodAttribute>();
			this.ambientProperties = new Factory<LayoutRenderer, AmbientPropertyAttribute>(this);
			this.timeSources = new Factory<TimeSource, TimeSourceAttribute>(this);
			this.allFactories = new List<object> { this.targets, this.filters, this.layoutRenderers, this.layouts, this.conditionMethods, this.ambientProperties, this.timeSources };
			foreach (Assembly assembly in assemblies)
			{
				this.RegisterItemsFromAssembly(assembly);
			}
		}

		/// <summary>
		/// Gets or sets default singleton instance of <see cref="T:NLog.Config.ConfigurationItemFactory" />.
		/// </summary>
		// Token: 0x17000037 RID: 55
		// (get) Token: 0x06000103 RID: 259 RVA: 0x00005624 File Offset: 0x00003824
		// (set) Token: 0x06000104 RID: 260 RVA: 0x0000563A File Offset: 0x0000383A
		public static ConfigurationItemFactory Default { get; set; } = ConfigurationItemFactory.BuildDefaultFactory();

		/// <summary>
		/// Gets or sets the creator delegate used to instantiate configuration objects.
		/// </summary>
		/// <remarks>
		/// By overriding this property, one can enable dependency injection or interception for created objects.
		/// </remarks>
		// Token: 0x17000038 RID: 56
		// (get) Token: 0x06000105 RID: 261 RVA: 0x00005644 File Offset: 0x00003844
		// (set) Token: 0x06000106 RID: 262 RVA: 0x0000565B File Offset: 0x0000385B
		public ConfigurationItemCreator CreateInstance { get; set; }

		/// <summary>
		/// Gets the <see cref="T:NLog.Targets.Target" /> factory.
		/// </summary>
		/// <value>The target factory.</value>
		// Token: 0x17000039 RID: 57
		// (get) Token: 0x06000107 RID: 263 RVA: 0x00005664 File Offset: 0x00003864
		public INamedItemFactory<Target, Type> Targets
		{
			get
			{
				return this.targets;
			}
		}

		/// <summary>
		/// Gets the <see cref="T:NLog.Filters.Filter" /> factory.
		/// </summary>
		/// <value>The filter factory.</value>
		// Token: 0x1700003A RID: 58
		// (get) Token: 0x06000108 RID: 264 RVA: 0x0000567C File Offset: 0x0000387C
		public INamedItemFactory<Filter, Type> Filters
		{
			get
			{
				return this.filters;
			}
		}

		/// <summary>
		/// Gets the <see cref="T:NLog.LayoutRenderers.LayoutRenderer" /> factory.
		/// </summary>
		/// <value>The layout renderer factory.</value>
		// Token: 0x1700003B RID: 59
		// (get) Token: 0x06000109 RID: 265 RVA: 0x00005694 File Offset: 0x00003894
		public INamedItemFactory<LayoutRenderer, Type> LayoutRenderers
		{
			get
			{
				return this.layoutRenderers;
			}
		}

		/// <summary>
		/// Gets the <see cref="T:NLog.LayoutRenderers.LayoutRenderer" /> factory.
		/// </summary>
		/// <value>The layout factory.</value>
		// Token: 0x1700003C RID: 60
		// (get) Token: 0x0600010A RID: 266 RVA: 0x000056AC File Offset: 0x000038AC
		public INamedItemFactory<Layout, Type> Layouts
		{
			get
			{
				return this.layouts;
			}
		}

		/// <summary>
		/// Gets the ambient property factory.
		/// </summary>
		/// <value>The ambient property factory.</value>
		// Token: 0x1700003D RID: 61
		// (get) Token: 0x0600010B RID: 267 RVA: 0x000056C4 File Offset: 0x000038C4
		public INamedItemFactory<LayoutRenderer, Type> AmbientProperties
		{
			get
			{
				return this.ambientProperties;
			}
		}

		/// <summary>
		/// Gets the time source factory.
		/// </summary>
		/// <value>The time source factory.</value>
		// Token: 0x1700003E RID: 62
		// (get) Token: 0x0600010C RID: 268 RVA: 0x000056DC File Offset: 0x000038DC
		public INamedItemFactory<TimeSource, Type> TimeSources
		{
			get
			{
				return this.timeSources;
			}
		}

		/// <summary>
		/// Gets the condition method factory.
		/// </summary>
		/// <value>The condition method factory.</value>
		// Token: 0x1700003F RID: 63
		// (get) Token: 0x0600010D RID: 269 RVA: 0x000056F4 File Offset: 0x000038F4
		public INamedItemFactory<MethodInfo, MethodInfo> ConditionMethods
		{
			get
			{
				return this.conditionMethods;
			}
		}

		/// <summary>
		/// Registers named items from the assembly.
		/// </summary>
		/// <param name="assembly">The assembly.</param>
		// Token: 0x0600010E RID: 270 RVA: 0x0000570C File Offset: 0x0000390C
		public void RegisterItemsFromAssembly(Assembly assembly)
		{
			this.RegisterItemsFromAssembly(assembly, string.Empty);
		}

		/// <summary>
		/// Registers named items from the assembly.
		/// </summary>
		/// <param name="assembly">The assembly.</param>
		/// <param name="itemNamePrefix">Item name prefix.</param>
		// Token: 0x0600010F RID: 271 RVA: 0x0000571C File Offset: 0x0000391C
		public void RegisterItemsFromAssembly(Assembly assembly, string itemNamePrefix)
		{
			foreach (object obj in this.allFactories)
			{
				IFactory factory = (IFactory)obj;
				factory.ScanAssembly(assembly, itemNamePrefix);
			}
		}

		/// <summary>
		/// Clears the contents of all factories.
		/// </summary>
		// Token: 0x06000110 RID: 272 RVA: 0x00005780 File Offset: 0x00003980
		public void Clear()
		{
			foreach (object obj in this.allFactories)
			{
				IFactory factory = (IFactory)obj;
				factory.Clear();
			}
		}

		/// <summary>
		/// Registers the type.
		/// </summary>
		/// <param name="type">The type to register.</param>
		/// <param name="itemNamePrefix">The item name prefix.</param>
		// Token: 0x06000111 RID: 273 RVA: 0x000057E0 File Offset: 0x000039E0
		public void RegisterType(Type type, string itemNamePrefix)
		{
			foreach (object obj in this.allFactories)
			{
				IFactory factory = (IFactory)obj;
				factory.RegisterType(type, itemNamePrefix);
			}
		}

		/// <summary>
		/// Builds the default configuration item factory.
		/// </summary>
		/// <returns>Default factory.</returns>
		// Token: 0x06000112 RID: 274 RVA: 0x00005844 File Offset: 0x00003A44
		private static ConfigurationItemFactory BuildDefaultFactory()
		{
			ConfigurationItemFactory configurationItemFactory = new ConfigurationItemFactory(new Assembly[] { typeof(Logger).Assembly });
			configurationItemFactory.RegisterExtendedItems();
			return configurationItemFactory;
		}

		/// <summary>
		/// Registers items in NLog.Extended.dll using late-bound types, so that we don't need a reference to NLog.Extended.dll.
		/// </summary>
		// Token: 0x06000113 RID: 275 RVA: 0x00005880 File Offset: 0x00003A80
		private void RegisterExtendedItems()
		{
			string text = typeof(Logger).AssemblyQualifiedName;
			string text2 = "NLog,";
			string text3 = "NLog.Extended,";
			int num = text.IndexOf(text2, StringComparison.OrdinalIgnoreCase);
			if (num >= 0)
			{
				text = ", " + text3 + text.Substring(num + text2.Length);
				string @namespace = typeof(DebugTarget).Namespace;
				this.targets.RegisterNamedType("AspNetTrace", @namespace + ".AspNetTraceTarget" + text);
				this.targets.RegisterNamedType("MSMQ", @namespace + ".MessageQueueTarget" + text);
				this.targets.RegisterNamedType("AspNetBufferingWrapper", @namespace + ".Wrappers.AspNetBufferingTargetWrapper" + text);
				string namespace2 = typeof(MessageLayoutRenderer).Namespace;
				this.layoutRenderers.RegisterNamedType("appsetting", namespace2 + ".AppSettingLayoutRenderer" + text);
				this.layoutRenderers.RegisterNamedType("aspnet-application", namespace2 + ".AspNetApplicationValueLayoutRenderer" + text);
				this.layoutRenderers.RegisterNamedType("aspnet-request", namespace2 + ".AspNetRequestValueLayoutRenderer" + text);
				this.layoutRenderers.RegisterNamedType("aspnet-sessionid", namespace2 + ".AspNetSessionIDLayoutRenderer" + text);
				this.layoutRenderers.RegisterNamedType("aspnet-session", namespace2 + ".AspNetSessionValueLayoutRenderer" + text);
				this.layoutRenderers.RegisterNamedType("aspnet-user-authtype", namespace2 + ".AspNetUserAuthTypeLayoutRenderer" + text);
				this.layoutRenderers.RegisterNamedType("aspnet-user-identity", namespace2 + ".AspNetUserIdentityLayoutRenderer" + text);
			}
		}

		// Token: 0x04000055 RID: 85
		private readonly IList<object> allFactories;

		// Token: 0x04000056 RID: 86
		private readonly Factory<Target, TargetAttribute> targets;

		// Token: 0x04000057 RID: 87
		private readonly Factory<Filter, FilterAttribute> filters;

		// Token: 0x04000058 RID: 88
		private readonly Factory<LayoutRenderer, LayoutRendererAttribute> layoutRenderers;

		// Token: 0x04000059 RID: 89
		private readonly Factory<Layout, LayoutAttribute> layouts;

		// Token: 0x0400005A RID: 90
		private readonly MethodFactory<ConditionMethodsAttribute, ConditionMethodAttribute> conditionMethods;

		// Token: 0x0400005B RID: 91
		private readonly Factory<LayoutRenderer, AmbientPropertyAttribute> ambientProperties;

		// Token: 0x0400005C RID: 92
		private readonly Factory<TimeSource, TimeSourceAttribute> timeSources;
	}
}
