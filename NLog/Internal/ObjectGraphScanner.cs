using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using NLog.Common;
using NLog.Config;

namespace NLog.Internal
{
	/// <summary>
	/// Scans (breadth-first) the object graph following all the edges whose are 
	/// instances have <see cref="T:NLog.Config.NLogConfigurationItemAttribute" /> attached and returns 
	/// all objects implementing a specified interfaces.
	/// </summary>
	// Token: 0x0200007C RID: 124
	internal class ObjectGraphScanner
	{
		/// <summary>
		/// Finds the objects which have attached <see cref="T:NLog.Config.NLogConfigurationItemAttribute" /> which are reachable
		/// from any of the given root objects when traversing the object graph over public properties.
		/// </summary>
		/// <typeparam name="T">Type of the objects to return.</typeparam>
		/// <param name="rootObjects">The root objects.</param>
		/// <returns>Ordered list of objects implementing T.</returns>
		// Token: 0x06000315 RID: 789 RVA: 0x0000C074 File Offset: 0x0000A274
		public static T[] FindReachableObjects<T>(params object[] rootObjects) where T : class
		{
			InternalLogger.Trace("FindReachableObject<{0}>:", new object[] { typeof(T) });
			List<T> list = new List<T>();
			Dictionary<object, int> dictionary = new Dictionary<object, int>();
			foreach (object obj in rootObjects)
			{
				ObjectGraphScanner.ScanProperties<T>(list, obj, 0, dictionary);
			}
			return list.ToArray();
		}

		// Token: 0x06000316 RID: 790 RVA: 0x0000C0EC File Offset: 0x0000A2EC
		private static void ScanProperties<T>(List<T> result, object o, int level, Dictionary<object, int> visitedObjects) where T : class
		{
			if (o != null)
			{
				if (o.GetType().IsDefined(typeof(NLogConfigurationItemAttribute), true))
				{
					if (!visitedObjects.ContainsKey(o))
					{
						visitedObjects.Add(o, 0);
						T t = o as T;
						if (t != null)
						{
							result.Add(t);
						}
						if (InternalLogger.IsTraceEnabled)
						{
							InternalLogger.Trace("{0}Scanning {1} '{2}'", new object[]
							{
								new string(' ', level),
								o.GetType().Name,
								o
							});
						}
						foreach (PropertyInfo propertyInfo in PropertyHelper.GetAllReadableProperties(o.GetType()))
						{
							if (!propertyInfo.PropertyType.IsPrimitive && !propertyInfo.PropertyType.IsEnum && !(propertyInfo.PropertyType == typeof(string)))
							{
								object value = propertyInfo.GetValue(o, null);
								if (value != null)
								{
									IEnumerable enumerable = value as IEnumerable;
									if (enumerable != null)
									{
										foreach (object obj in enumerable.OfType<object>().ToList<object>())
										{
											ObjectGraphScanner.ScanProperties<T>(result, obj, level + 1, visitedObjects);
										}
									}
									else
									{
										ObjectGraphScanner.ScanProperties<T>(result, value, level + 1, visitedObjects);
									}
								}
							}
						}
					}
				}
			}
		}
	}
}
