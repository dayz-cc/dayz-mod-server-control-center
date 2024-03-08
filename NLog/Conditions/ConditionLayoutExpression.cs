using System;
using NLog.Layouts;

namespace NLog.Conditions
{
	/// <summary>
	/// Condition layout expression (represented by a string literal
	/// with embedded ${}).
	/// </summary>
	// Token: 0x02000010 RID: 16
	internal sealed class ConditionLayoutExpression : ConditionExpression
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Conditions.ConditionLayoutExpression" /> class.
		/// </summary>
		/// <param name="layout">The layout.</param>
		// Token: 0x0600008D RID: 141 RVA: 0x000035EC File Offset: 0x000017EC
		public ConditionLayoutExpression(Layout layout)
		{
			this.Layout = layout;
		}

		/// <summary>
		/// Gets the layout.
		/// </summary>
		/// <value>The layout.</value>
		// Token: 0x17000026 RID: 38
		// (get) Token: 0x0600008E RID: 142 RVA: 0x00003600 File Offset: 0x00001800
		// (set) Token: 0x0600008F RID: 143 RVA: 0x00003617 File Offset: 0x00001817
		public Layout Layout { get; private set; }

		/// <summary>
		/// Returns a string representation of this expression.
		/// </summary>
		/// <returns>String literal in single quotes.</returns>
		// Token: 0x06000090 RID: 144 RVA: 0x00003620 File Offset: 0x00001820
		public override string ToString()
		{
			return this.Layout.ToString();
		}

		/// <summary>
		/// Evaluates the expression by calculating the value
		/// of the layout in the specified evaluation context.
		/// </summary>
		/// <param name="context">Evaluation context.</param>
		/// <returns>The value of the layout.</returns>
		// Token: 0x06000091 RID: 145 RVA: 0x00003640 File Offset: 0x00001840
		protected override object EvaluateNode(LogEventInfo context)
		{
			return this.Layout.Render(context);
		}
	}
}
