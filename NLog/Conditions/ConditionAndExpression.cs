using System;

namespace NLog.Conditions
{
	/// <summary>
	/// Condition <b>and</b> expression.
	/// </summary>
	// Token: 0x0200000E RID: 14
	internal sealed class ConditionAndExpression : ConditionExpression
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Conditions.ConditionAndExpression" /> class.
		/// </summary>
		/// <param name="left">Left hand side of the AND expression.</param>
		/// <param name="right">Right hand side of the AND expression.</param>
		// Token: 0x06000081 RID: 129 RVA: 0x000034A4 File Offset: 0x000016A4
		public ConditionAndExpression(ConditionExpression left, ConditionExpression right)
		{
			this.Left = left;
			this.Right = right;
		}

		/// <summary>
		/// Gets the left hand side of the AND expression.
		/// </summary>
		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000082 RID: 130 RVA: 0x000034C0 File Offset: 0x000016C0
		// (set) Token: 0x06000083 RID: 131 RVA: 0x000034D7 File Offset: 0x000016D7
		public ConditionExpression Left { get; private set; }

		/// <summary>
		/// Gets the right hand side of the AND expression.
		/// </summary>
		// Token: 0x17000025 RID: 37
		// (get) Token: 0x06000084 RID: 132 RVA: 0x000034E0 File Offset: 0x000016E0
		// (set) Token: 0x06000085 RID: 133 RVA: 0x000034F7 File Offset: 0x000016F7
		public ConditionExpression Right { get; private set; }

		/// <summary>
		/// Returns a string representation of this expression.
		/// </summary>
		/// <returns>A concatenated '(Left) and (Right)' string.</returns>
		// Token: 0x06000086 RID: 134 RVA: 0x00003500 File Offset: 0x00001700
		public override string ToString()
		{
			return string.Concat(new object[] { "(", this.Left, " and ", this.Right, ")" });
		}

		/// <summary>
		/// Evaluates the expression by evaluating <see cref="P:NLog.Conditions.ConditionAndExpression.Left" /> and <see cref="P:NLog.Conditions.ConditionAndExpression.Right" /> recursively.
		/// </summary>
		/// <param name="context">Evaluation context.</param>
		/// <returns>The value of the conjunction operator.</returns>
		// Token: 0x06000087 RID: 135 RVA: 0x0000354C File Offset: 0x0000174C
		protected override object EvaluateNode(LogEventInfo context)
		{
			object obj;
			if (!(bool)this.Left.Evaluate(context))
			{
				obj = ConditionAndExpression.boxedFalse;
			}
			else if (!(bool)this.Right.Evaluate(context))
			{
				obj = ConditionAndExpression.boxedFalse;
			}
			else
			{
				obj = ConditionAndExpression.boxedTrue;
			}
			return obj;
		}

		// Token: 0x04000013 RID: 19
		private static readonly object boxedFalse = false;

		// Token: 0x04000014 RID: 20
		private static readonly object boxedTrue = true;
	}
}
