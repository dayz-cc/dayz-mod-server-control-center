using System;
using System.Collections.Generic;
using System.Reflection;
using NLog.Common;

namespace NLog.Internal
{
	/// <summary>
	/// Reflection helpers.
	/// </summary>
	// Token: 0x02000083 RID: 131
	internal static class ReflectionHelpers
	{
		/// <summary>
		/// Gets all usable exported types from the given assembly.
		/// </summary>
		/// <param name="assembly">Assembly to scan.</param>
		/// <returns>Usable types from the given assembly.</returns>
		/// <remarks>Types which cannot be loaded are skipped.</remarks>
		// Token: 0x0600033C RID: 828 RVA: 0x0000CE38 File Offset: 0x0000B038
		public static Type[] SafeGetTypes(this Assembly assembly)
		{
			Type[] array;
			try
			{
				array = assembly.GetTypes();
			}
			catch (ReflectionTypeLoadException ex)
			{
				foreach (Exception ex2 in ex.LoaderExceptions)
				{
					InternalLogger.Warn("Type load exception: {0}", new object[] { ex2 });
				}
				List<Type> list = new List<Type>();
				foreach (Type type in ex.Types)
				{
					if (type != null)
					{
						list.Add(type);
					}
				}
				array = list.ToArray();
			}
			return array;
		}
	}
}
