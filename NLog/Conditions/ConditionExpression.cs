using System;
using NLog.Config;
using NLog.Internal;

namespace NLog.Conditions
{
	/// <summary>
	/// Base class for representing nodes in condition expression trees.
	/// </summary>
	// Token: 0x0200000D RID: 13
	[NLogConfigurationItem]
	[ThreadAgnostic]
	public abstract class ConditionExpression
	{
		/// <summary>
		/// Converts condition text to a condition expression tree.
		/// </summary>
		/// <param name="conditionExpressionText">Condition text to be converted.</param>
		/// <returns>Condition expression tree.</returns>
		// Token: 0x0600007C RID: 124 RVA: 0x00003438 File Offset: 0x00001638
		public static implicit operator ConditionExpression(string conditionExpressionText)
		{
			return ConditionParser.ParseExpression(conditionExpressionText);
		}

		/// <summary>
		/// Evaluates the expression.
		/// </summary>
		/// <param name="context">Evaluation context.</param>
		/// <returns>Expression result.</returns>
		// Token: 0x0600007D RID: 125 RVA: 0x00003450 File Offset: 0x00001650
		public object Evaluate(LogEventInfo context)
		{
			object obj;
			try
			{
				obj = this.EvaluateNode(context);
			}
			catch (Exception ex)
			{
				if (ex.MustBeRethrown())
				{
					throw;
				}
				throw new ConditionEvaluationException("Exception occurred when evaluating condition", ex);
			}
			return obj;
		}

		/// <summary>
		/// Returns a string representation of the expression.
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.String" /> that represents the condition expression.
		/// </returns>
		// Token: 0x0600007E RID: 126
		public abstract override string ToString();

		/// <summary>
		/// Evaluates the expression.
		/// </summary>
		/// <param name="context">Evaluation context.</param>
		/// <returns>Expression result.</returns>
		// Token: 0x0600007F RID: 127
		protected abstract object EvaluateNode(LogEventInfo context);
	}
}
