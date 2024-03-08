using System;

namespace NLog.Conditions
{
	/// <summary>
	/// Condition level expression (represented by the <b>level</b> keyword).
	/// </summary>
	// Token: 0x02000011 RID: 17
	internal sealed class ConditionLevelExpression : ConditionExpression
	{
		/// <summary>
		/// Returns a string representation of the expression.
		/// </summary>
		/// <returns>The '<b>level</b>' string.</returns>
		// Token: 0x06000092 RID: 146 RVA: 0x00003660 File Offset: 0x00001860
		public override string ToString()
		{
			return "level";
		}

		/// <summary>
		/// Evaluates to the current log level.
		/// </summary>
		/// <param name="context">Evaluation context. Ignored.</param>
		/// <returns>The <see cref="T:NLog.LogLevel" /> object representing current log level.</returns>
		// Token: 0x06000093 RID: 147 RVA: 0x00003678 File Offset: 0x00001878
		protected override object EvaluateNode(LogEventInfo context)
		{
			return context.Level;
		}
	}
}
