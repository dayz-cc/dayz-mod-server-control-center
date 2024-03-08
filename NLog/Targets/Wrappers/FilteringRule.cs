using System;
using NLog.Conditions;
using NLog.Config;

namespace NLog.Targets.Wrappers
{
	/// <summary>
	/// Filtering rule for <see cref="T:NLog.Targets.Wrappers.PostFilteringTargetWrapper" />.
	/// </summary>
	// Token: 0x02000136 RID: 310
	[NLogConfigurationItem]
	public class FilteringRule
	{
		/// <summary>
		/// Initializes a new instance of the FilteringRule class.
		/// </summary>
		// Token: 0x06000A43 RID: 2627 RVA: 0x000248CC File Offset: 0x00022ACC
		public FilteringRule()
			: this(null, null)
		{
		}

		/// <summary>
		/// Initializes a new instance of the FilteringRule class.
		/// </summary>
		/// <param name="whenExistsExpression">Condition to be tested against all events.</param>
		/// <param name="filterToApply">Filter to apply to all log events when the first condition matches any of them.</param>
		// Token: 0x06000A44 RID: 2628 RVA: 0x000248D9 File Offset: 0x00022AD9
		public FilteringRule(ConditionExpression whenExistsExpression, ConditionExpression filterToApply)
		{
			this.Exists = whenExistsExpression;
			this.Filter = filterToApply;
		}

		/// <summary>
		/// Gets or sets the condition to be tested.
		/// </summary>
		/// <docgen category="Filtering Options" order="10" />
		// Token: 0x17000232 RID: 562
		// (get) Token: 0x06000A45 RID: 2629 RVA: 0x000248F4 File Offset: 0x00022AF4
		// (set) Token: 0x06000A46 RID: 2630 RVA: 0x0002490B File Offset: 0x00022B0B
		[RequiredParameter]
		public ConditionExpression Exists { get; set; }

		/// <summary>
		/// Gets or sets the resulting filter to be applied when the condition matches.
		/// </summary>
		/// <docgen category="Filtering Options" order="10" />
		// Token: 0x17000233 RID: 563
		// (get) Token: 0x06000A47 RID: 2631 RVA: 0x00024914 File Offset: 0x00022B14
		// (set) Token: 0x06000A48 RID: 2632 RVA: 0x0002492B File Offset: 0x00022B2B
		[RequiredParameter]
		public ConditionExpression Filter { get; set; }
	}
}
