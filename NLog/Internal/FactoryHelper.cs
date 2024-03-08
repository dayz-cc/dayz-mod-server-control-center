using System;
using System.Reflection;

namespace NLog.Internal
{
	/// <summary>
	/// Object construction helper.
	/// </summary>
	// Token: 0x0200005A RID: 90
	internal class FactoryHelper
	{
		// Token: 0x0600024A RID: 586 RVA: 0x00009EAF File Offset: 0x000080AF
		private FactoryHelper()
		{
		}

		// Token: 0x0600024B RID: 587 RVA: 0x00009EBC File Offset: 0x000080BC
		internal static object CreateInstance(Type t)
		{
			ConstructorInfo constructor = t.GetConstructor(FactoryHelper.emptyTypes);
			if (constructor != null)
			{
				return constructor.Invoke(FactoryHelper.emptyParams);
			}
			throw new NLogConfigurationException("Cannot access the constructor of type: " + t.FullName + ". Is the required permission granted?");
		}

		// Token: 0x040000A2 RID: 162
		private static Type[] emptyTypes = new Type[0];

		// Token: 0x040000A3 RID: 163
		private static object[] emptyParams = new object[0];
	}
}
