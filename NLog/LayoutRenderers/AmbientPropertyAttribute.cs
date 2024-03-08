using System;
using NLog.Config;

namespace NLog.LayoutRenderers
{
	/// <summary>
	/// Designates a property of the class as an ambient property.
	/// </summary>
	// Token: 0x02000094 RID: 148
	[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
	public sealed class AmbientPropertyAttribute : NameBaseAttribute
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.LayoutRenderers.AmbientPropertyAttribute" /> class.
		/// </summary>
		/// <param name="name">Ambient property name.</param>
		// Token: 0x0600036C RID: 876 RVA: 0x0000D750 File Offset: 0x0000B950
		public AmbientPropertyAttribute(string name)
			: base(name)
		{
		}
	}
}
