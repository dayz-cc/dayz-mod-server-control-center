using System;

namespace NLog.Conditions
{
	/// <summary>
	/// Condition logger name expression (represented by the <b>logger</b> keyword).
	/// </summary>
	// Token: 0x02000013 RID: 19
	internal sealed class ConditionLoggerNameExpression : ConditionExpression
	{
		/// <summary>
		/// Returns a string representation of this expression.
		/// </summary>
		/// <returns>A <b>logger</b> string.</returns>
		// Token: 0x0600009A RID: 154 RVA: 0x00003720 File Offset: 0x00001920
		public override string ToString()
		{
			return "logger";
		}

		/// <summary>
		/// Evaluates to the logger name.
		/// </summary>
		/// <param name="context">Evaluation context.</param>
		/// <returns>The logger name.</returns>
		// Token: 0x0600009B RID: 155 RVA: 0x00003738 File Offset: 0x00001938
		protected override object EvaluateNode(LogEventInfo context)
		{
			return context.LoggerName;
		}
	}
}
