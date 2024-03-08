using System;

namespace NLog.Conditions
{
	/// <summary>
	/// Condition <b>or</b> expression.
	/// </summary>
	// Token: 0x0200001B RID: 27
	internal sealed class ConditionOrExpression : ConditionExpression
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Conditions.ConditionOrExpression" /> class.
		/// </summary>
		/// <param name="left">Left hand side of the OR expression.</param>
		/// <param name="right">Right hand side of the OR expression.</param>
		// Token: 0x060000B7 RID: 183 RVA: 0x00003C7F File Offset: 0x00001E7F
		public ConditionOrExpression(ConditionExpression left, ConditionExpression right)
		{
			this.LeftExpression = left;
			this.RightExpression = right;
		}

		/// <summary>
		/// Gets the left expression.
		/// </summary>
		/// <value>The left expression.</value>
		// Token: 0x1700002C RID: 44
		// (get) Token: 0x060000B8 RID: 184 RVA: 0x00003C9C File Offset: 0x00001E9C
		// (set) Token: 0x060000B9 RID: 185 RVA: 0x00003CB3 File Offset: 0x00001EB3
		public ConditionExpression LeftExpression { get; private set; }

		/// <summary>
		/// Gets the right expression.
		/// </summary>
		/// <value>The right expression.</value>
		// Token: 0x1700002D RID: 45
		// (get) Token: 0x060000BA RID: 186 RVA: 0x00003CBC File Offset: 0x00001EBC
		// (set) Token: 0x060000BB RID: 187 RVA: 0x00003CD3 File Offset: 0x00001ED3
		public ConditionExpression RightExpression { get; private set; }

		/// <summary>
		/// Returns a string representation of the expression.
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.String" /> that represents the condition expression.
		/// </returns>
		// Token: 0x060000BC RID: 188 RVA: 0x00003CDC File Offset: 0x00001EDC
		public override string ToString()
		{
			return string.Concat(new object[] { "(", this.LeftExpression, " or ", this.RightExpression, ")" });
		}

		/// <summary>
		/// Evaluates the expression by evaluating <see cref="P:NLog.Conditions.ConditionOrExpression.LeftExpression" /> and <see cref="P:NLog.Conditions.ConditionOrExpression.RightExpression" /> recursively.
		/// </summary>
		/// <param name="context">Evaluation context.</param>
		/// <returns>The value of the alternative operator.</returns>
		// Token: 0x060000BD RID: 189 RVA: 0x00003D28 File Offset: 0x00001F28
		protected override object EvaluateNode(LogEventInfo context)
		{
			bool flag = (bool)this.LeftExpression.Evaluate(context);
			object obj;
			if (flag)
			{
				obj = ConditionOrExpression.boxedTrue;
			}
			else
			{
				bool flag2 = (bool)this.RightExpression.Evaluate(context);
				if (flag2)
				{
					obj = ConditionOrExpression.boxedTrue;
				}
				else
				{
					obj = ConditionOrExpression.boxedFalse;
				}
			}
			return obj;
		}

		// Token: 0x0400001F RID: 31
		private static readonly object boxedFalse = false;

		// Token: 0x04000020 RID: 32
		private static readonly object boxedTrue = true;
	}
}
