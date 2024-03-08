using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Text;
using NLog.Common;

namespace NLog.Conditions
{
	/// <summary>
	/// Condition method invocation expression (represented by <b>method(p1,p2,p3)</b> syntax).
	/// </summary>
	// Token: 0x02000017 RID: 23
	internal sealed class ConditionMethodExpression : ConditionExpression
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Conditions.ConditionMethodExpression" /> class.
		/// </summary>
		/// <param name="conditionMethodName">Name of the condition method.</param>
		/// <param name="methodInfo"><see cref="P:NLog.Conditions.ConditionMethodExpression.MethodInfo" /> of the condition method.</param>
		/// <param name="methodParameters">The method parameters.</param>
		// Token: 0x060000A4 RID: 164 RVA: 0x000037D0 File Offset: 0x000019D0
		public ConditionMethodExpression(string conditionMethodName, MethodInfo methodInfo, IEnumerable<ConditionExpression> methodParameters)
		{
			this.MethodInfo = methodInfo;
			this.conditionMethodName = conditionMethodName;
			this.MethodParameters = new List<ConditionExpression>(methodParameters).AsReadOnly();
			ParameterInfo[] parameters = this.MethodInfo.GetParameters();
			if (parameters.Length > 0 && parameters[0].ParameterType == typeof(LogEventInfo))
			{
				this.acceptsLogEvent = true;
			}
			int num = this.MethodParameters.Count;
			if (this.acceptsLogEvent)
			{
				num++;
			}
			int num2 = 0;
			int num3 = 0;
			foreach (ParameterInfo parameterInfo in parameters)
			{
				if (parameterInfo.IsOptional)
				{
					num3++;
				}
				else
				{
					num2++;
				}
			}
			if (num < num2 || num > parameters.Length)
			{
				string text;
				if (num3 > 0)
				{
					text = string.Format(CultureInfo.InvariantCulture, "Condition method '{0}' requires between {1} and {2} parameters, but passed {3}.", new object[] { conditionMethodName, num2, parameters.Length, num });
				}
				else
				{
					text = string.Format(CultureInfo.InvariantCulture, "Condition method '{0}' requires {1} parameters, but passed {2}.", new object[] { conditionMethodName, num2, num });
				}
				InternalLogger.Error(text);
				throw new ConditionParseException(text);
			}
		}

		/// <summary>
		/// Gets the method info.
		/// </summary>
		// Token: 0x17000029 RID: 41
		// (get) Token: 0x060000A5 RID: 165 RVA: 0x00003960 File Offset: 0x00001B60
		// (set) Token: 0x060000A6 RID: 166 RVA: 0x00003977 File Offset: 0x00001B77
		public MethodInfo MethodInfo { get; private set; }

		/// <summary>
		/// Gets the method parameters.
		/// </summary>
		/// <value>The method parameters.</value>
		// Token: 0x1700002A RID: 42
		// (get) Token: 0x060000A7 RID: 167 RVA: 0x00003980 File Offset: 0x00001B80
		// (set) Token: 0x060000A8 RID: 168 RVA: 0x00003997 File Offset: 0x00001B97
		public IList<ConditionExpression> MethodParameters { get; private set; }

		/// <summary>
		/// Returns a string representation of the expression.
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.String" /> that represents the condition expression.
		/// </returns>
		// Token: 0x060000A9 RID: 169 RVA: 0x000039A0 File Offset: 0x00001BA0
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(this.conditionMethodName);
			stringBuilder.Append("(");
			string text = string.Empty;
			foreach (ConditionExpression conditionExpression in this.MethodParameters)
			{
				stringBuilder.Append(text);
				stringBuilder.Append(conditionExpression);
				text = ", ";
			}
			stringBuilder.Append(")");
			return stringBuilder.ToString();
		}

		/// <summary>
		/// Evaluates the expression.
		/// </summary>
		/// <param name="context">Evaluation context.</param>
		/// <returns>Expression result.</returns>
		// Token: 0x060000AA RID: 170 RVA: 0x00003A50 File Offset: 0x00001C50
		protected override object EvaluateNode(LogEventInfo context)
		{
			int num = (this.acceptsLogEvent ? 1 : 0);
			object[] array = new object[this.MethodParameters.Count + num];
			int num2 = 0;
			foreach (ConditionExpression conditionExpression in this.MethodParameters)
			{
				array[num2++ + num] = conditionExpression.Evaluate(context);
			}
			if (this.acceptsLogEvent)
			{
				array[0] = context;
			}
			return this.MethodInfo.DeclaringType.InvokeMember(this.MethodInfo.Name, BindingFlags.Static | BindingFlags.Public | BindingFlags.InvokeMethod | BindingFlags.OptionalParamBinding, null, null, array, CultureInfo.InvariantCulture);
		}

		// Token: 0x0400001A RID: 26
		private readonly bool acceptsLogEvent;

		// Token: 0x0400001B RID: 27
		private readonly string conditionMethodName;
	}
}
