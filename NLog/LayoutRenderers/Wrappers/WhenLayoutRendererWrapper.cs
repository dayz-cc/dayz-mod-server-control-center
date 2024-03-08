using System;
using NLog.Conditions;
using NLog.Config;

namespace NLog.LayoutRenderers.Wrappers
{
	/// <summary>
	/// Only outputs the inner layout when the specified condition has been met.
	/// </summary>
	// Token: 0x020000D5 RID: 213
	[AmbientProperty("When")]
	[ThreadAgnostic]
	[LayoutRenderer("when")]
	public sealed class WhenLayoutRendererWrapper : WrapperLayoutRendererBase
	{
		/// <summary>
		/// Gets or sets the condition that must be met for the inner layout to be printed.
		/// </summary>
		/// <docgen category="Transformation Options" order="10" />
		// Token: 0x1700011A RID: 282
		// (get) Token: 0x060004F7 RID: 1271 RVA: 0x000116DC File Offset: 0x0000F8DC
		// (set) Token: 0x060004F8 RID: 1272 RVA: 0x000116F3 File Offset: 0x0000F8F3
		[RequiredParameter]
		public ConditionExpression When { get; set; }

		/// <summary>
		/// Transforms the output of another layout.
		/// </summary>
		/// <param name="text">Output to be transform.</param>
		/// <returns>Transformed text.</returns>
		// Token: 0x060004F9 RID: 1273 RVA: 0x000116FC File Offset: 0x0000F8FC
		protected override string Transform(string text)
		{
			return text;
		}

		/// <summary>
		/// Renders the inner layout contents.
		/// </summary>
		/// <param name="logEvent">The log event.</param>
		/// <returns>
		/// Contents of inner layout.
		/// </returns>
		// Token: 0x060004FA RID: 1274 RVA: 0x00011710 File Offset: 0x0000F910
		protected override string RenderInner(LogEventInfo logEvent)
		{
			string text;
			if (true.Equals(this.When.Evaluate(logEvent)))
			{
				text = base.RenderInner(logEvent);
			}
			else
			{
				text = string.Empty;
			}
			return text;
		}
	}
}
