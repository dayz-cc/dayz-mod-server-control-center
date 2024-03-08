using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;
using NLog.Common;
using NLog.Conditions;
using NLog.Config;
using NLog.Layouts;

namespace NLog.Internal
{
	/// <summary>
	/// Reflection helpers for accessing properties.
	/// </summary>
	// Token: 0x02000082 RID: 130
	internal static class PropertyHelper
	{
		// Token: 0x0600032F RID: 815 RVA: 0x0000C5E0 File Offset: 0x0000A7E0
		internal static void SetPropertyFromString(object o, string name, string value, ConfigurationItemFactory configurationItemFactory)
		{
			InternalLogger.Debug("Setting '{0}.{1}' to '{2}'", new object[]
			{
				o.GetType().Name,
				name,
				value
			});
			PropertyInfo propertyInfo;
			if (!PropertyHelper.TryGetPropertyInfo(o, name, out propertyInfo))
			{
				throw new NotSupportedException("Parameter " + name + " not supported on " + o.GetType().Name);
			}
			try
			{
				if (propertyInfo.IsDefined(typeof(ArrayParameterAttribute), false))
				{
					throw new NotSupportedException(string.Concat(new string[]
					{
						"Parameter ",
						name,
						" of ",
						o.GetType().Name,
						" is an array and cannot be assigned a scalar value."
					}));
				}
				Type type = propertyInfo.PropertyType;
				type = Nullable.GetUnderlyingType(type) ?? type;
				object obj;
				if (!PropertyHelper.TryNLogSpecificConversion(type, value, out obj, configurationItemFactory))
				{
					if (!PropertyHelper.TryGetEnumValue(type, value, out obj))
					{
						if (!PropertyHelper.TryImplicitConversion(type, value, out obj))
						{
							if (!PropertyHelper.TrySpecialConversion(type, value, out obj))
							{
								obj = Convert.ChangeType(value, type, CultureInfo.InvariantCulture);
							}
						}
					}
				}
				propertyInfo.SetValue(o, obj, null);
			}
			catch (TargetInvocationException ex)
			{
				throw new NLogConfigurationException(string.Concat(new object[] { "Error when setting property '", propertyInfo.Name, "' on ", o }), ex.InnerException);
			}
			catch (Exception ex2)
			{
				if (ex2.MustBeRethrown())
				{
					throw;
				}
				throw new NLogConfigurationException(string.Concat(new object[] { "Error when setting property '", propertyInfo.Name, "' on ", o }), ex2);
			}
		}

		// Token: 0x06000330 RID: 816 RVA: 0x0000C7CC File Offset: 0x0000A9CC
		internal static bool IsArrayProperty(Type t, string name)
		{
			PropertyInfo propertyInfo;
			if (!PropertyHelper.TryGetPropertyInfo(t, name, out propertyInfo))
			{
				throw new NotSupportedException("Parameter " + name + " not supported on " + t.Name);
			}
			return propertyInfo.IsDefined(typeof(ArrayParameterAttribute), false);
		}

		// Token: 0x06000331 RID: 817 RVA: 0x0000C81C File Offset: 0x0000AA1C
		internal static bool TryGetPropertyInfo(object o, string propertyName, out PropertyInfo result)
		{
			PropertyInfo property = o.GetType().GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
			bool flag;
			if (property != null)
			{
				result = property;
				flag = true;
			}
			else
			{
				lock (PropertyHelper.parameterInfoCache)
				{
					Type type = o.GetType();
					Dictionary<string, PropertyInfo> dictionary2;
					if (!PropertyHelper.parameterInfoCache.TryGetValue(type, out dictionary2))
					{
						dictionary2 = PropertyHelper.BuildPropertyInfoDictionary(type);
						PropertyHelper.parameterInfoCache[type] = dictionary2;
					}
					flag = dictionary2.TryGetValue(propertyName, out result);
				}
			}
			return flag;
		}

		// Token: 0x06000332 RID: 818 RVA: 0x0000C8C8 File Offset: 0x0000AAC8
		internal static Type GetArrayItemType(PropertyInfo propInfo)
		{
			ArrayParameterAttribute arrayParameterAttribute = (ArrayParameterAttribute)Attribute.GetCustomAttribute(propInfo, typeof(ArrayParameterAttribute));
			Type type;
			if (arrayParameterAttribute != null)
			{
				type = arrayParameterAttribute.ItemType;
			}
			else
			{
				type = null;
			}
			return type;
		}

		// Token: 0x06000333 RID: 819 RVA: 0x0000C904 File Offset: 0x0000AB04
		internal static IEnumerable<PropertyInfo> GetAllReadableProperties(Type type)
		{
			return type.GetProperties(BindingFlags.Instance | BindingFlags.Public);
		}

		// Token: 0x06000334 RID: 820 RVA: 0x0000C920 File Offset: 0x0000AB20
		internal static void CheckRequiredParameters(object o)
		{
			foreach (PropertyInfo propertyInfo in PropertyHelper.GetAllReadableProperties(o.GetType()))
			{
				if (propertyInfo.IsDefined(typeof(RequiredParameterAttribute), false))
				{
					object value = propertyInfo.GetValue(o, null);
					if (value == null)
					{
						throw new NLogConfigurationException(string.Concat(new object[] { "Required parameter '", propertyInfo.Name, "' on '", o, "' was not specified." }));
					}
				}
			}
		}

		// Token: 0x06000335 RID: 821 RVA: 0x0000C9EC File Offset: 0x0000ABEC
		private static bool TryImplicitConversion(Type resultType, string value, out object result)
		{
			MethodInfo method = resultType.GetMethod("op_Implicit", BindingFlags.Static | BindingFlags.Public, null, new Type[] { typeof(string) }, null);
			bool flag;
			if (method == null)
			{
				result = null;
				flag = false;
			}
			else
			{
				result = method.Invoke(null, new object[] { value });
				flag = true;
			}
			return flag;
		}

		// Token: 0x06000336 RID: 822 RVA: 0x0000CA54 File Offset: 0x0000AC54
		private static bool TryNLogSpecificConversion(Type propertyType, string value, out object newValue, ConfigurationItemFactory configurationItemFactory)
		{
			bool flag;
			if (propertyType == typeof(Layout) || propertyType == typeof(SimpleLayout))
			{
				newValue = new SimpleLayout(value, configurationItemFactory);
				flag = true;
			}
			else if (propertyType == typeof(ConditionExpression))
			{
				newValue = ConditionParser.ParseExpression(value, configurationItemFactory);
				flag = true;
			}
			else
			{
				newValue = null;
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000337 RID: 823 RVA: 0x0000CACC File Offset: 0x0000ACCC
		private static bool TryGetEnumValue(Type resultType, string value, out object result)
		{
			bool flag;
			if (!resultType.IsEnum)
			{
				result = null;
				flag = false;
			}
			else if (resultType.IsDefined(typeof(FlagsAttribute), false))
			{
				ulong num = 0UL;
				foreach (string text in value.Split(new char[] { ',' }))
				{
					FieldInfo fieldInfo = resultType.GetField(text.Trim(), BindingFlags.IgnoreCase | BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy);
					if (fieldInfo == null)
					{
						throw new NLogConfigurationException("Invalid enumeration value '" + value + "'.");
					}
					num |= Convert.ToUInt64(fieldInfo.GetValue(null), CultureInfo.InvariantCulture);
				}
				result = Convert.ChangeType(num, Enum.GetUnderlyingType(resultType), CultureInfo.InvariantCulture);
				result = Enum.ToObject(resultType, result);
				flag = true;
			}
			else
			{
				FieldInfo fieldInfo = resultType.GetField(value, BindingFlags.IgnoreCase | BindingFlags.Static | BindingFlags.Public | BindingFlags.FlattenHierarchy);
				if (fieldInfo == null)
				{
					throw new NLogConfigurationException("Invalid enumeration value '" + value + "'.");
				}
				result = fieldInfo.GetValue(null);
				flag = true;
			}
			return flag;
		}

		// Token: 0x06000338 RID: 824 RVA: 0x0000CBFC File Offset: 0x0000ADFC
		private static bool TrySpecialConversion(Type type, string value, out object newValue)
		{
			bool flag;
			if (type == typeof(Uri))
			{
				newValue = new Uri(value, UriKind.RelativeOrAbsolute);
				flag = true;
			}
			else if (type == typeof(Encoding))
			{
				newValue = Encoding.GetEncoding(value);
				flag = true;
			}
			else if (type == typeof(CultureInfo))
			{
				newValue = new CultureInfo(value);
				flag = true;
			}
			else if (type == typeof(Type))
			{
				newValue = Type.GetType(value, true);
				flag = true;
			}
			else
			{
				newValue = null;
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000339 RID: 825 RVA: 0x0000CCA4 File Offset: 0x0000AEA4
		private static bool TryGetPropertyInfo(Type targetType, string propertyName, out PropertyInfo result)
		{
			if (!string.IsNullOrEmpty(propertyName))
			{
				PropertyInfo property = targetType.GetProperty(propertyName, BindingFlags.IgnoreCase | BindingFlags.Instance | BindingFlags.Public);
				if (property != null)
				{
					result = property;
					return true;
				}
			}
			bool flag2;
			lock (PropertyHelper.parameterInfoCache)
			{
				Dictionary<string, PropertyInfo> dictionary2;
				if (!PropertyHelper.parameterInfoCache.TryGetValue(targetType, out dictionary2))
				{
					dictionary2 = PropertyHelper.BuildPropertyInfoDictionary(targetType);
					PropertyHelper.parameterInfoCache[targetType] = dictionary2;
				}
				flag2 = dictionary2.TryGetValue(propertyName, out result);
			}
			return flag2;
		}

		// Token: 0x0600033A RID: 826 RVA: 0x0000CD50 File Offset: 0x0000AF50
		private static Dictionary<string, PropertyInfo> BuildPropertyInfoDictionary(Type t)
		{
			Dictionary<string, PropertyInfo> dictionary = new Dictionary<string, PropertyInfo>(StringComparer.OrdinalIgnoreCase);
			foreach (PropertyInfo propertyInfo in PropertyHelper.GetAllReadableProperties(t))
			{
				ArrayParameterAttribute arrayParameterAttribute = (ArrayParameterAttribute)Attribute.GetCustomAttribute(propertyInfo, typeof(ArrayParameterAttribute));
				if (arrayParameterAttribute != null)
				{
					dictionary[arrayParameterAttribute.ElementName] = propertyInfo;
				}
				else
				{
					dictionary[propertyInfo.Name] = propertyInfo;
				}
				if (propertyInfo.IsDefined(typeof(DefaultParameterAttribute), false))
				{
					dictionary[string.Empty] = propertyInfo;
				}
			}
			return dictionary;
		}

		// Token: 0x040000D3 RID: 211
		private static Dictionary<Type, Dictionary<string, PropertyInfo>> parameterInfoCache = new Dictionary<Type, Dictionary<string, PropertyInfo>>();
	}
}
