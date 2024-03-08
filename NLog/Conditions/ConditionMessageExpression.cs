using System;

namespace NLog.Conditions
{
	/// <summary>
	/// Condition message expression (represented by the <b>message</b> keyword).
	/// </summary>
	// Token: 0x02000014 RID: 20
	internal sealed class ConditionMessageExpression : ConditionExpression
	{
		/// <summary>
		/// Returns a string representation of this expression.
		/// </summary>
		/// <returns>The '<b>message</b>' string.</returns>
		// Token: 0x0600009D RID: 157 RVA: 0x00003758 File Offset: 0x00001958
		public override string ToString()
		{
			return "message";
		}

		/// <summary>
		/// Evaluates to the logger message.
		/// </summary>
		/// <param name="context">Evaluation context.</param>
		/// <returns>The logger message.</returns>
		// Token: 0x0600009E RID: 158 RVA: 0x00003770 File Offset: 0x00001970
		protected override object EvaluateNode(LogEventInfo context)
		{
			return context.FormattedMessage;
		}
	}
}
