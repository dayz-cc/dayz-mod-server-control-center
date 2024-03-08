using System;
using NLog.Config;
using NLog.Layouts;

namespace NLog.Targets
{
	/// <summary>
	/// Represents target that supports string formatting using layouts.
	/// </summary>
	// Token: 0x02000104 RID: 260
	public abstract class TargetWithLayoutHeaderAndFooter : TargetWithLayout
	{
		/// <summary>
		/// Gets or sets the text to be rendered.
		/// </summary>
		/// <docgen category="Layout Options" order="1" />
		// Token: 0x17000181 RID: 385
		// (get) Token: 0x0600080C RID: 2060 RVA: 0x0001C8A4 File Offset: 0x0001AAA4
		// (set) Token: 0x0600080D RID: 2061 RVA: 0x0001C8C4 File Offset: 0x0001AAC4
		[RequiredParameter]
		public override Layout Layout
		{
			get
			{
				return this.LHF.Layout;
			}
			set
			{
				if (value is LayoutWithHeaderAndFooter)
				{
					base.Layout = value;
				}
				else if (this.LHF == null)
				{
					this.LHF = new LayoutWithHeaderAndFooter
					{
						Layout = value
					};
				}
				else
				{
					this.LHF.Layout = value;
				}
			}
		}

		/// <summary>
		/// Gets or sets the footer.
		/// </summary>
		/// <docgen category="Layout Options" order="3" />
		// Token: 0x17000182 RID: 386
		// (get) Token: 0x0600080E RID: 2062 RVA: 0x0001C928 File Offset: 0x0001AB28
		// (set) Token: 0x0600080F RID: 2063 RVA: 0x0001C945 File Offset: 0x0001AB45
		public Layout Footer
		{
			get
			{
				return this.LHF.Footer;
			}
			set
			{
				this.LHF.Footer = value;
			}
		}

		/// <summary>
		/// Gets or sets the header.
		/// </summary>
		/// <docgen category="Layout Options" order="2" />
		// Token: 0x17000183 RID: 387
		// (get) Token: 0x06000810 RID: 2064 RVA: 0x0001C958 File Offset: 0x0001AB58
		// (set) Token: 0x06000811 RID: 2065 RVA: 0x0001C975 File Offset: 0x0001AB75
		public Layout Header
		{
			get
			{
				return this.LHF.Header;
			}
			set
			{
				this.LHF.Header = value;
			}
		}

		/// <summary>
		/// Gets or sets the layout with header and footer.
		/// </summary>
		/// <value>The layout with header and footer.</value>
		// Token: 0x17000184 RID: 388
		// (get) Token: 0x06000812 RID: 2066 RVA: 0x0001C988 File Offset: 0x0001AB88
		// (set) Token: 0x06000813 RID: 2067 RVA: 0x0001C9A5 File Offset: 0x0001ABA5
		private LayoutWithHeaderAndFooter LHF
		{
			get
			{
				return (LayoutWithHeaderAndFooter)base.Layout;
			}
			set
			{
				base.Layout = value;
			}
		}
	}
}
