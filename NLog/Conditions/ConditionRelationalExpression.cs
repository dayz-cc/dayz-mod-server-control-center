using System;
using System.Globalization;

namespace NLog.Conditions
{
	/// <summary>
	/// Condition relational (<b>==</b>, <b>!=</b>, <b>&lt;</b>, <b>&lt;=</b>,
	/// <b>&gt;</b> or <b>&gt;=</b>) expression.
	/// </summary>
	// Token: 0x0200001E RID: 30
	internal sealed class ConditionRelationalExpression : ConditionExpression
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Conditions.ConditionRelationalExpression" /> class.
		/// </summary>
		/// <param name="leftExpression">The left expression.</param>
		/// <param name="rightExpression">The right expression.</param>
		/// <param name="relationalOperator">The relational operator.</param>
		// Token: 0x060000CF RID: 207 RVA: 0x00004570 File Offset: 0x00002770
		public ConditionRelationalExpression(ConditionExpression leftExpression, ConditionExpression rightExpression, ConditionRelationalOperator relationalOperator)
		{
			this.LeftExpression = leftExpression;
			this.RightExpression = rightExpression;
			this.RelationalOperator = relationalOperator;
		}

		/// <summary>
		/// Gets the left expression.
		/// </summary>
		/// <value>The left expression.</value>
		// Token: 0x1700002E RID: 46
		// (get) Token: 0x060000D0 RID: 208 RVA: 0x00004594 File Offset: 0x00002794
		// (set) Token: 0x060000D1 RID: 209 RVA: 0x000045AB File Offset: 0x000027AB
		public ConditionExpression LeftExpression { get; private set; }

		/// <summary>
		/// Gets the right expression.
		/// </summary>
		/// <value>The right expression.</value>
		// Token: 0x1700002F RID: 47
		// (get) Token: 0x060000D2 RID: 210 RVA: 0x000045B4 File Offset: 0x000027B4
		// (set) Token: 0x060000D3 RID: 211 RVA: 0x000045CB File Offset: 0x000027CB
		public ConditionExpression RightExpression { get; private set; }

		/// <summary>
		/// Gets the relational operator.
		/// </summary>
		/// <value>The operator.</value>
		// Token: 0x17000030 RID: 48
		// (get) Token: 0x060000D4 RID: 212 RVA: 0x000045D4 File Offset: 0x000027D4
		// (set) Token: 0x060000D5 RID: 213 RVA: 0x000045EB File Offset: 0x000027EB
		public ConditionRelationalOperator RelationalOperator { get; private set; }

		/// <summary>
		/// Returns a string representation of the expression.
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.String" /> that represents the condition expression.
		/// </returns>
		// Token: 0x060000D6 RID: 214 RVA: 0x000045F4 File Offset: 0x000027F4
		public override string ToString()
		{
			return string.Concat(new object[]
			{
				"(",
				this.LeftExpression,
				" ",
				this.GetOperatorString(),
				" ",
				this.RightExpression,
				")"
			});
		}

		/// <summary>
		/// Evaluates the expression.
		/// </summary>
		/// <param name="context">Evaluation context.</param>
		/// <returns>Expression result.</returns>
		// Token: 0x060000D7 RID: 215 RVA: 0x00004650 File Offset: 0x00002850
		protected override object EvaluateNode(LogEventInfo context)
		{
			object obj = this.LeftExpression.Evaluate(context);
			object obj2 = this.RightExpression.Evaluate(context);
			return ConditionRelationalExpression.Compare(obj, obj2, this.RelationalOperator);
		}

		/// <summary>
		/// Compares the specified values using specified relational operator.
		/// </summary>
		/// <param name="leftValue">The first value.</param>
		/// <param name="rightValue">The second value.</param>
		/// <param name="relationalOperator">The relational operator.</param>
		/// <returns>Result of the given relational operator.</returns>
		// Token: 0x060000D8 RID: 216 RVA: 0x0000468C File Offset: 0x0000288C
		private static object Compare(object leftValue, object rightValue, ConditionRelationalOperator relationalOperator)
		{
			StringComparer invariantCulture = StringComparer.InvariantCulture;
			ConditionRelationalExpression.PromoteTypes(ref leftValue, ref rightValue);
			object obj;
			switch (relationalOperator)
			{
			case ConditionRelationalOperator.Equal:
				obj = invariantCulture.Compare(leftValue, rightValue) == 0;
				break;
			case ConditionRelationalOperator.NotEqual:
				obj = invariantCulture.Compare(leftValue, rightValue) != 0;
				break;
			case ConditionRelationalOperator.Less:
				obj = invariantCulture.Compare(leftValue, rightValue) < 0;
				break;
			case ConditionRelationalOperator.Greater:
				obj = invariantCulture.Compare(leftValue, rightValue) > 0;
				break;
			case ConditionRelationalOperator.LessOrEqual:
				obj = invariantCulture.Compare(leftValue, rightValue) <= 0;
				break;
			case ConditionRelationalOperator.GreaterOrEqual:
				obj = invariantCulture.Compare(leftValue, rightValue) >= 0;
				break;
			default:
				throw new NotSupportedException("Relational operator " + relationalOperator + " is not supported.");
			}
			return obj;
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x00004768 File Offset: 0x00002968
		private static void PromoteTypes(ref object val1, ref object val2)
		{
			if (val1 != null && val2 != null)
			{
				if (!(val1.GetType() == val2.GetType()))
				{
					if (val1 is DateTime || val2 is DateTime)
					{
						val1 = Convert.ToDateTime(val1, CultureInfo.InvariantCulture);
						val2 = Convert.ToDateTime(val2, CultureInfo.InvariantCulture);
					}
					else if (val1 is string || val2 is string)
					{
						val1 = Convert.ToString(val1, CultureInfo.InvariantCulture);
						val2 = Convert.ToString(val2, CultureInfo.InvariantCulture);
					}
					else if (val1 is double || val2 is double)
					{
						val1 = Convert.ToDouble(val1, CultureInfo.InvariantCulture);
						val2 = Convert.ToDouble(val2, CultureInfo.InvariantCulture);
					}
					else if (val1 is float || val2 is float)
					{
						val1 = Convert.ToSingle(val1, CultureInfo.InvariantCulture);
						val2 = Convert.ToSingle(val2, CultureInfo.InvariantCulture);
					}
					else if (val1 is decimal || val2 is decimal)
					{
						val1 = Convert.ToDecimal(val1, CultureInfo.InvariantCulture);
						val2 = Convert.ToDecimal(val2, CultureInfo.InvariantCulture);
					}
					else if (val1 is long || val2 is long)
					{
						val1 = Convert.ToInt64(val1, CultureInfo.InvariantCulture);
						val2 = Convert.ToInt64(val2, CultureInfo.InvariantCulture);
					}
					else if (val1 is int || val2 is int)
					{
						val1 = Convert.ToInt32(val1, CultureInfo.InvariantCulture);
						val2 = Convert.ToInt32(val2, CultureInfo.InvariantCulture);
					}
					else
					{
						if (!(val1 is bool) && !(val2 is bool))
						{
							throw new ConditionEvaluationException(string.Concat(new string[]
							{
								"Cannot find common type for '",
								val1.GetType().Name,
								"' and '",
								val2.GetType().Name,
								"'."
							}));
						}
						val1 = Convert.ToBoolean(val1, CultureInfo.InvariantCulture);
						val2 = Convert.ToBoolean(val2, CultureInfo.InvariantCulture);
					}
				}
			}
		}

		// Token: 0x060000DA RID: 218 RVA: 0x00004A3C File Offset: 0x00002C3C
		private string GetOperatorString()
		{
			string text;
			switch (this.RelationalOperator)
			{
			case ConditionRelationalOperator.Equal:
				text = "==";
				break;
			case ConditionRelationalOperator.NotEqual:
				text = "!=";
				break;
			case ConditionRelationalOperator.Less:
				text = "<";
				break;
			case ConditionRelationalOperator.Greater:
				text = ">";
				break;
			case ConditionRelationalOperator.LessOrEqual:
				text = "<=";
				break;
			case ConditionRelationalOperator.GreaterOrEqual:
				text = ">=";
				break;
			default:
				throw new NotSupportedException("Relational operator " + this.RelationalOperator + " is not supported.");
			}
			return text;
		}
	}
}
