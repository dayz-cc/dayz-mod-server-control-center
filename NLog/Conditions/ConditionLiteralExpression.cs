using System;
using System.Globalization;

namespace NLog.Conditions
{
	/// <summary>
	/// Condition literal expression (numeric, <b>LogLevel.XXX</b>, <b>true</b> or <b>false</b>).
	/// </summary>
	// Token: 0x02000012 RID: 18
	internal sealed class ConditionLiteralExpression : ConditionExpression
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Conditions.ConditionLiteralExpression" /> class.
		/// </summary>
		/// <param name="literalValue">Literal value.</param>
		// Token: 0x06000095 RID: 149 RVA: 0x00003698 File Offset: 0x00001898
		public ConditionLiteralExpression(object literalValue)
		{
			this.LiteralValue = literalValue;
		}

		/// <summary>
		/// Gets the literal value.
		/// </summary>
		/// <value>The literal value.</value>
		// Token: 0x17000027 RID: 39
		// (get) Token: 0x06000096 RID: 150 RVA: 0x000036AC File Offset: 0x000018AC
		// (set) Token: 0x06000097 RID: 151 RVA: 0x000036C3 File Offset: 0x000018C3
		public object LiteralValue { get; private set; }

		/// <summary>
		/// Returns a string representation of the expression.
		/// </summary>
		/// <returns>The literal value.</returns>
		// Token: 0x06000098 RID: 152 RVA: 0x000036CC File Offset: 0x000018CC
		public override string ToString()
		{
			string text;
			if (this.LiteralValue == null)
			{
				text = "null";
			}
			else
			{
				text = Convert.ToString(this.LiteralValue, CultureInfo.InvariantCulture);
			}
			return text;
		}

		/// <summary>
		/// Evaluates the expression.
		/// </summary>
		/// <param name="context">Evaluation context.</param>
		/// <returns>The literal value as passed in the constructor.</returns>
		// Token: 0x06000099 RID: 153 RVA: 0x00003708 File Offset: 0x00001908
		protected override object EvaluateNode(LogEventInfo context)
		{
			return this.LiteralValue;
		}
	}
}
