using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using NLog.Config;
using NLog.Layouts;

namespace NLog.Targets
{
	/// <summary>
	/// Represents target that supports string formatting using layouts.
	/// </summary>
	// Token: 0x020000FF RID: 255
	public abstract class TargetWithLayout : Target
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Targets.TargetWithLayout" /> class.
		/// </summary>
		/// <remarks>
		/// The default value of the layout is: <code>${longdate}|${level:uppercase=true}|${logger}|${message}</code>
		/// </remarks>
		// Token: 0x060007D3 RID: 2003 RVA: 0x0001BAEC File Offset: 0x00019CEC
		[SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors", Justification = "This one is safe.")]
		protected TargetWithLayout()
		{
			this.Layout = "${longdate}|${level:uppercase=true}|${logger}|${message}";
		}

		/// <summary>
		/// Gets or sets the layout used to format log messages.
		/// </summary>
		/// <docgen category="Layout Options" order="1" />
		// Token: 0x1700016C RID: 364
		// (get) Token: 0x060007D4 RID: 2004 RVA: 0x0001BB08 File Offset: 0x00019D08
		// (set) Token: 0x060007D5 RID: 2005 RVA: 0x0001BB1F File Offset: 0x00019D1F
		[RequiredParameter]
		[DefaultValue("${longdate}|${level:uppercase=true}|${logger}|${message}")]
		public virtual Layout Layout { get; set; }
	}
}
