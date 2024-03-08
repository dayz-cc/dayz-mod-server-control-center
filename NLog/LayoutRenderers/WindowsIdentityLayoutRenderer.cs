using System;
using System.ComponentModel;
using System.Security.Principal;
using System.Text;

namespace NLog.LayoutRenderers
{
	/// <summary>
	/// Thread Windows identity information (username).
	/// </summary>
	// Token: 0x020000C7 RID: 199
	[LayoutRenderer("windows-identity")]
	public class WindowsIdentityLayoutRenderer : LayoutRenderer
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.LayoutRenderers.WindowsIdentityLayoutRenderer" /> class.
		/// </summary>
		// Token: 0x060004A2 RID: 1186 RVA: 0x00010BDC File Offset: 0x0000EDDC
		public WindowsIdentityLayoutRenderer()
		{
			this.UserName = true;
			this.Domain = true;
		}

		/// <summary>
		/// Gets or sets a value indicating whether domain name should be included.
		/// </summary>
		/// <docgen category="Rendering Options" order="10" />
		// Token: 0x17000104 RID: 260
		// (get) Token: 0x060004A3 RID: 1187 RVA: 0x00010BF8 File Offset: 0x0000EDF8
		// (set) Token: 0x060004A4 RID: 1188 RVA: 0x00010C0F File Offset: 0x0000EE0F
		[DefaultValue(true)]
		public bool Domain { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether username should be included.
		/// </summary>
		/// <docgen category="Rendering Options" order="10" />
		// Token: 0x17000105 RID: 261
		// (get) Token: 0x060004A5 RID: 1189 RVA: 0x00010C18 File Offset: 0x0000EE18
		// (set) Token: 0x060004A6 RID: 1190 RVA: 0x00010C2F File Offset: 0x0000EE2F
		[DefaultValue(true)]
		public bool UserName { get; set; }

		/// <summary>
		/// Renders the current thread windows identity information and appends it to the specified <see cref="T:System.Text.StringBuilder" />.
		/// </summary>
		/// <param name="builder">The <see cref="T:System.Text.StringBuilder" /> to append the rendered data to.</param>
		/// <param name="logEvent">Logging event.</param>
		// Token: 0x060004A7 RID: 1191 RVA: 0x00010C38 File Offset: 0x0000EE38
		protected override void Append(StringBuilder builder, LogEventInfo logEvent)
		{
			WindowsIdentity current = WindowsIdentity.GetCurrent();
			if (current != null)
			{
				string text = string.Empty;
				if (this.UserName)
				{
					if (this.Domain)
					{
						text = current.Name;
					}
					else
					{
						int num = current.Name.LastIndexOf('\\');
						if (num >= 0)
						{
							text = current.Name.Substring(num + 1);
						}
						else
						{
							text = current.Name;
						}
					}
				}
				else
				{
					if (!this.Domain)
					{
						return;
					}
					int num = current.Name.IndexOf('\\');
					if (num >= 0)
					{
						text = current.Name.Substring(0, num);
					}
					else
					{
						text = current.Name;
					}
				}
				builder.Append(text);
			}
		}
	}
}
