using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using NLog.Common;
using NLog.Conditions;
using NLog.Config;
using NLog.Internal;
using NLog.LayoutRenderers;
using NLog.LayoutRenderers.Wrappers;

namespace NLog.Layouts
{
	/// <summary>
	/// Parses layout strings.
	/// </summary>
	// Token: 0x020000DF RID: 223
	internal sealed class LayoutParser
	{
		// Token: 0x06000532 RID: 1330 RVA: 0x00012064 File Offset: 0x00010264
		internal static LayoutRenderer[] CompileLayout(ConfigurationItemFactory configurationItemFactory, SimpleStringReader sr, bool isNested, out string text)
		{
			List<LayoutRenderer> list = new List<LayoutRenderer>();
			StringBuilder stringBuilder = new StringBuilder();
			int position = sr.Position;
			int num;
			while ((num = sr.Peek()) != -1)
			{
				if (isNested && (num == 125 || num == 58))
				{
					break;
				}
				sr.Read();
				if (num == 36 && sr.Peek() == 123)
				{
					if (stringBuilder.Length > 0)
					{
						list.Add(new LiteralLayoutRenderer(stringBuilder.ToString()));
						stringBuilder.Length = 0;
					}
					LayoutRenderer layoutRenderer = LayoutParser.ParseLayoutRenderer(configurationItemFactory, sr);
					if (LayoutParser.CanBeConvertedToLiteral(layoutRenderer))
					{
						layoutRenderer = LayoutParser.ConvertToLiteral(layoutRenderer);
					}
					list.Add(layoutRenderer);
				}
				else
				{
					stringBuilder.Append((char)num);
				}
			}
			if (stringBuilder.Length > 0)
			{
				list.Add(new LiteralLayoutRenderer(stringBuilder.ToString()));
				stringBuilder.Length = 0;
			}
			int position2 = sr.Position;
			LayoutParser.MergeLiterals(list);
			text = sr.Substring(position, position2);
			return list.ToArray();
		}

		// Token: 0x06000533 RID: 1331 RVA: 0x000121A8 File Offset: 0x000103A8
		private static string ParseLayoutRendererName(SimpleStringReader sr)
		{
			StringBuilder stringBuilder = new StringBuilder();
			int num;
			while ((num = sr.Peek()) != -1)
			{
				if (num == 58 || num == 125)
				{
					break;
				}
				stringBuilder.Append((char)num);
				sr.Read();
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06000534 RID: 1332 RVA: 0x00012204 File Offset: 0x00010404
		private static string ParseParameterName(SimpleStringReader sr)
		{
			int num = 0;
			StringBuilder stringBuilder = new StringBuilder();
			int num2;
			while ((num2 = sr.Peek()) != -1)
			{
				if ((num2 == 61 || num2 == 125 || num2 == 58) && num == 0)
				{
					break;
				}
				if (num2 == 36)
				{
					sr.Read();
					stringBuilder.Append('$');
					if (sr.Peek() == 123)
					{
						stringBuilder.Append('{');
						num++;
						sr.Read();
					}
				}
				else
				{
					if (num2 == 125)
					{
						num--;
					}
					if (num2 == 92)
					{
						sr.Read();
						stringBuilder.Append((char)sr.Read());
					}
					else
					{
						stringBuilder.Append((char)num2);
						sr.Read();
					}
				}
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06000535 RID: 1333 RVA: 0x000122FC File Offset: 0x000104FC
		private static string ParseParameterValue(SimpleStringReader sr)
		{
			StringBuilder stringBuilder = new StringBuilder();
			int num;
			while ((num = sr.Peek()) != -1)
			{
				if (num == 58 || num == 125)
				{
					break;
				}
				if (num == 92)
				{
					sr.Read();
					stringBuilder.Append((char)sr.Read());
				}
				else
				{
					stringBuilder.Append((char)num);
					sr.Read();
				}
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06000536 RID: 1334 RVA: 0x0001237C File Offset: 0x0001057C
		private static LayoutRenderer ParseLayoutRenderer(ConfigurationItemFactory configurationItemFactory, SimpleStringReader sr)
		{
			int num = sr.Read();
			Debug.Assert(num == 123, "'{' expected in layout specification");
			string text = LayoutParser.ParseLayoutRendererName(sr);
			LayoutRenderer layoutRenderer = configurationItemFactory.LayoutRenderers.CreateInstance(text);
			Dictionary<Type, LayoutRenderer> dictionary = new Dictionary<Type, LayoutRenderer>();
			List<LayoutRenderer> list = new List<LayoutRenderer>();
			num = sr.Read();
			while (num != -1 && num != 125)
			{
				string text2 = LayoutParser.ParseParameterName(sr).Trim();
				PropertyInfo propertyInfo;
				if (sr.Peek() == 61)
				{
					sr.Read();
					LayoutRenderer layoutRenderer2 = layoutRenderer;
					if (!PropertyHelper.TryGetPropertyInfo(layoutRenderer, text2, out propertyInfo))
					{
						Type type;
						if (configurationItemFactory.AmbientProperties.TryGetDefinition(text2, out type))
						{
							LayoutRenderer layoutRenderer3;
							if (!dictionary.TryGetValue(type, out layoutRenderer3))
							{
								layoutRenderer3 = configurationItemFactory.AmbientProperties.CreateInstance(text2);
								dictionary[type] = layoutRenderer3;
								list.Add(layoutRenderer3);
							}
							if (!PropertyHelper.TryGetPropertyInfo(layoutRenderer3, text2, out propertyInfo))
							{
								propertyInfo = null;
							}
							else
							{
								layoutRenderer2 = layoutRenderer3;
							}
						}
					}
					if (propertyInfo == null)
					{
						LayoutParser.ParseParameterValue(sr);
					}
					else if (typeof(Layout).IsAssignableFrom(propertyInfo.PropertyType))
					{
						SimpleLayout simpleLayout = new SimpleLayout();
						string text3;
						LayoutRenderer[] array = LayoutParser.CompileLayout(configurationItemFactory, sr, true, out text3);
						simpleLayout.SetRenderers(array, text3);
						propertyInfo.SetValue(layoutRenderer2, simpleLayout, null);
					}
					else if (typeof(ConditionExpression).IsAssignableFrom(propertyInfo.PropertyType))
					{
						ConditionExpression conditionExpression = ConditionParser.ParseExpression(sr, configurationItemFactory);
						propertyInfo.SetValue(layoutRenderer2, conditionExpression, null);
					}
					else
					{
						string text4 = LayoutParser.ParseParameterValue(sr);
						PropertyHelper.SetPropertyFromString(layoutRenderer2, text2, text4, configurationItemFactory);
					}
				}
				else if (PropertyHelper.TryGetPropertyInfo(layoutRenderer, string.Empty, out propertyInfo))
				{
					if (typeof(SimpleLayout) == propertyInfo.PropertyType)
					{
						propertyInfo.SetValue(layoutRenderer, new SimpleLayout(text2), null);
					}
					else
					{
						string text4 = text2;
						PropertyHelper.SetPropertyFromString(layoutRenderer, propertyInfo.Name, text4, configurationItemFactory);
					}
				}
				else
				{
					InternalLogger.Warn("{0} has no default property", new object[] { layoutRenderer.GetType().FullName });
				}
				num = sr.Read();
			}
			return LayoutParser.ApplyWrappers(configurationItemFactory, layoutRenderer, list);
		}

		// Token: 0x06000537 RID: 1335 RVA: 0x00012604 File Offset: 0x00010804
		private static LayoutRenderer ApplyWrappers(ConfigurationItemFactory configurationItemFactory, LayoutRenderer lr, List<LayoutRenderer> orderedWrappers)
		{
			for (int i = orderedWrappers.Count - 1; i >= 0; i--)
			{
				WrapperLayoutRendererBase wrapperLayoutRendererBase = (WrapperLayoutRendererBase)orderedWrappers[i];
				InternalLogger.Trace("Wrapping {0} with {1}", new object[]
				{
					lr.GetType().Name,
					wrapperLayoutRendererBase.GetType().Name
				});
				if (LayoutParser.CanBeConvertedToLiteral(lr))
				{
					lr = LayoutParser.ConvertToLiteral(lr);
				}
				wrapperLayoutRendererBase.Inner = new SimpleLayout(new LayoutRenderer[] { lr }, string.Empty, configurationItemFactory);
				lr = wrapperLayoutRendererBase;
			}
			return lr;
		}

		// Token: 0x06000538 RID: 1336 RVA: 0x000126B4 File Offset: 0x000108B4
		private static bool CanBeConvertedToLiteral(LayoutRenderer lr)
		{
			foreach (IRenderable renderable in ObjectGraphScanner.FindReachableObjects<IRenderable>(new object[] { lr }))
			{
				if (!(renderable.GetType() == typeof(SimpleLayout)))
				{
					if (!renderable.GetType().IsDefined(typeof(AppDomainFixedOutputAttribute), false))
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x06000539 RID: 1337 RVA: 0x0001273C File Offset: 0x0001093C
		private static void MergeLiterals(List<LayoutRenderer> list)
		{
			int num = 0;
			while (num + 1 < list.Count)
			{
				LiteralLayoutRenderer literalLayoutRenderer = list[num] as LiteralLayoutRenderer;
				LiteralLayoutRenderer literalLayoutRenderer2 = list[num + 1] as LiteralLayoutRenderer;
				if (literalLayoutRenderer != null && literalLayoutRenderer2 != null)
				{
					LiteralLayoutRenderer literalLayoutRenderer3 = literalLayoutRenderer;
					literalLayoutRenderer3.Text += literalLayoutRenderer2.Text;
					list.RemoveAt(num + 1);
				}
				else
				{
					num++;
				}
			}
		}

		// Token: 0x0600053A RID: 1338 RVA: 0x000127B8 File Offset: 0x000109B8
		private static LayoutRenderer ConvertToLiteral(LayoutRenderer renderer)
		{
			return new LiteralLayoutRenderer(renderer.Render(LogEventInfo.CreateNullEvent()));
		}
	}
}
