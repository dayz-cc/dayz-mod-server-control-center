using System;
using System.ComponentModel;
using System.Security.Principal;
using System.Text;
using System.Threading;

namespace NLog.LayoutRenderers
{
	/// <summary>
	/// Thread identity information (name and authentication information).
	/// </summary>
	// Token: 0x020000A8 RID: 168
	[LayoutRenderer("identity")]
	public class IdentityLayoutRenderer : LayoutRenderer
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.LayoutRenderers.IdentityLayoutRenderer" /> class.
		/// </summary>
		// Token: 0x060003F1 RID: 1009 RVA: 0x0000EC04 File Offset: 0x0000CE04
		public IdentityLayoutRenderer()
		{
			this.Name = true;
			this.AuthType = true;
			this.IsAuthenticated = true;
			this.Separator = ":";
		}

		/// <summary>
		/// Gets or sets the separator to be used when concatenating 
		/// parts of identity information.
		/// </summary>
		/// <docgen category="Rendering Options" order="10" />
		// Token: 0x170000CF RID: 207
		// (get) Token: 0x060003F2 RID: 1010 RVA: 0x0000EC34 File Offset: 0x0000CE34
		// (set) Token: 0x060003F3 RID: 1011 RVA: 0x0000EC4B File Offset: 0x0000CE4B
		[DefaultValue(":")]
		public string Separator { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether to render Thread.CurrentPrincipal.Identity.Name.
		/// </summary>
		/// <docgen category="Rendering Options" order="10" />
		// Token: 0x170000D0 RID: 208
		// (get) Token: 0x060003F4 RID: 1012 RVA: 0x0000EC54 File Offset: 0x0000CE54
		// (set) Token: 0x060003F5 RID: 1013 RVA: 0x0000EC6B File Offset: 0x0000CE6B
		[DefaultValue(true)]
		public bool Name { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether to render Thread.CurrentPrincipal.Identity.AuthenticationType.
		/// </summary>
		/// <docgen category="Rendering Options" order="10" />
		// Token: 0x170000D1 RID: 209
		// (get) Token: 0x060003F6 RID: 1014 RVA: 0x0000EC74 File Offset: 0x0000CE74
		// (set) Token: 0x060003F7 RID: 1015 RVA: 0x0000EC8B File Offset: 0x0000CE8B
		[DefaultValue(true)]
		public bool AuthType { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether to render Thread.CurrentPrincipal.Identity.IsAuthenticated.
		/// </summary>
		/// <docgen category="Rendering Options" order="10" />
		// Token: 0x170000D2 RID: 210
		// (get) Token: 0x060003F8 RID: 1016 RVA: 0x0000EC94 File Offset: 0x0000CE94
		// (set) Token: 0x060003F9 RID: 1017 RVA: 0x0000ECAB File Offset: 0x0000CEAB
		[DefaultValue(true)]
		public bool IsAuthenticated { get; set; }

		/// <summary>
		/// Renders the specified identity information and appends it to the specified <see cref="T:System.Text.StringBuilder" />.
		/// </summary>
		/// <param name="builder">The <see cref="T:System.Text.StringBuilder" /> to append the rendered data to.</param>
		/// <param name="logEvent">Logging event.</param>
		// Token: 0x060003FA RID: 1018 RVA: 0x0000ECB4 File Offset: 0x0000CEB4
		protected override void Append(StringBuilder builder, LogEventInfo logEvent)
		{
			IPrincipal currentPrincipal = Thread.CurrentPrincipal;
			if (currentPrincipal != null)
			{
				IIdentity identity = currentPrincipal.Identity;
				if (identity != null)
				{
					string text = string.Empty;
					if (this.IsAuthenticated)
					{
						builder.Append(text);
						text = this.Separator;
						if (identity.IsAuthenticated)
						{
							builder.Append("auth");
						}
						else
						{
							builder.Append("notauth");
						}
					}
					if (this.AuthType)
					{
						builder.Append(text);
						text = this.Separator;
						builder.Append(identity.AuthenticationType);
					}
					if (this.Name)
					{
						builder.Append(text);
						builder.Append(identity.Name);
					}
				}
			}
		}
	}
}
