using System;

namespace NLog.Conditions
{
	/// <summary>
	/// Condition <b>not</b> expression.
	/// </summary>
	// Token: 0x0200001A RID: 26
	internal sealed class ConditionNotExpression : ConditionExpression
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Conditions.ConditionNotExpression" /> class.
		/// </summary>
		/// <param name="expression">The expression.</param>
		// Token: 0x060000B2 RID: 178 RVA: 0x00003BF8 File Offset: 0x00001DF8
		public ConditionNotExpression(ConditionExpression expression)
		{
			this.Expression = expression;
		}

		/// <summary>
		/// Gets the expression to be negated.
		/// </summary>
		/// <value>The expression.</value>
		// Token: 0x1700002B RID: 43
		// (get) Token: 0x060000B3 RID: 179 RVA: 0x00003C0C File Offset: 0x00001E0C
		// (set) Token: 0x060000B4 RID: 180 RVA: 0x00003C23 File Offset: 0x00001E23
		public ConditionExpression Expression { get; private set; }

		/// <summary>
		/// Returns a string representation of the expression.
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.String" /> that represents the condition expression.
		/// </returns>
		// Token: 0x060000B5 RID: 181 RVA: 0x00003C2C File Offset: 0x00001E2C
		public override string ToString()
		{
			return "(not " + this.Expression + ")";
		}

		/// <summary>
		/// Evaluates the expression.
		/// </summary>
		/// <param name="context">Evaluation context.</param>
		/// <returns>Expression result.</returns>
		// Token: 0x060000B6 RID: 182 RVA: 0x00003C54 File Offset: 0x00001E54
		protected override object EvaluateNode(LogEventInfo context)
		{
			return !(bool)this.Expression.Evaluate(context);
		}
	}
}
