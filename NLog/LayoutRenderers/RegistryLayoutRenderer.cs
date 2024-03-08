using System;
using System.Globalization;
using System.Text;
using Microsoft.Win32;
using NLog.Config;
using NLog.Internal;

namespace NLog.LayoutRenderers
{
	/// <summary>
	/// A value from the Registry.
	/// </summary>
	// Token: 0x020000BD RID: 189
	[LayoutRenderer("registry")]
	public class RegistryLayoutRenderer : LayoutRenderer
	{
		/// <summary>
		/// Gets or sets the registry value name.
		/// </summary>
		/// <docgen category="Registry Options" order="10" />
		// Token: 0x170000F6 RID: 246
		// (get) Token: 0x06000472 RID: 1138 RVA: 0x000103F0 File Offset: 0x0000E5F0
		// (set) Token: 0x06000473 RID: 1139 RVA: 0x00010407 File Offset: 0x0000E607
		public string Value { get; set; }

		/// <summary>
		/// Gets or sets the value to be output when the specified registry key or value is not found.
		/// </summary>
		/// <docgen category="Registry Options" order="10" />
		// Token: 0x170000F7 RID: 247
		// (get) Token: 0x06000474 RID: 1140 RVA: 0x00010410 File Offset: 0x0000E610
		// (set) Token: 0x06000475 RID: 1141 RVA: 0x00010427 File Offset: 0x0000E627
		public string DefaultValue { get; set; }

		/// <summary>
		/// Gets or sets the registry key.
		/// </summary>
		/// <remarks>
		/// Must have one of the forms:
		/// <ul>
		/// <li>HKLM\Key\Full\Name</li>
		/// <li>HKEY_LOCAL_MACHINE\Key\Full\Name</li>
		/// <li>HKCU\Key\Full\Name</li>
		/// <li>HKEY_CURRENT_USER\Key\Full\Name</li>
		/// </ul>
		/// </remarks>
		/// <docgen category="Registry Options" order="10" />
		// Token: 0x170000F8 RID: 248
		// (get) Token: 0x06000476 RID: 1142 RVA: 0x00010430 File Offset: 0x0000E630
		// (set) Token: 0x06000477 RID: 1143 RVA: 0x00010448 File Offset: 0x0000E648
		[RequiredParameter]
		public string Key
		{
			get
			{
				return this.key;
			}
			set
			{
				this.key = value;
				int num = this.key.IndexOfAny(new char[] { '\\', '/' });
				if (num >= 0)
				{
					string text = this.key.Substring(0, num);
					string text2 = text.ToUpper(CultureInfo.InvariantCulture);
					if (text2 != null)
					{
						if (!(text2 == "HKEY_LOCAL_MACHINE") && !(text2 == "HKLM"))
						{
							if (!(text2 == "HKEY_CURRENT_USER") && !(text2 == "HKCU"))
							{
								goto IL_A5;
							}
							this.rootKey = Registry.CurrentUser;
						}
						else
						{
							this.rootKey = Registry.LocalMachine;
						}
						this.subKey = this.key.Substring(num + 1).Replace('/', '\\');
						return;
					}
					IL_A5:
					throw new ArgumentException("Key name is invalid. Root hive not recognized.");
				}
				throw new ArgumentException("Key name is invalid");
			}
		}

		/// <summary>
		/// Reads the specified registry key and value and appends it to
		/// the passed <see cref="T:System.Text.StringBuilder" />.
		/// </summary>
		/// <param name="builder">The <see cref="T:System.Text.StringBuilder" /> to append the rendered data to.</param>
		/// <param name="logEvent">Logging event. Ignored.</param>
		// Token: 0x06000478 RID: 1144 RVA: 0x00010534 File Offset: 0x0000E734
		protected override void Append(StringBuilder builder, LogEventInfo logEvent)
		{
			string text;
			try
			{
				using (RegistryKey registryKey = this.rootKey.OpenSubKey(this.subKey))
				{
					text = Convert.ToString(registryKey.GetValue(this.Value, this.DefaultValue), CultureInfo.InvariantCulture);
				}
			}
			catch (Exception ex)
			{
				if (ex.MustBeRethrown())
				{
					throw;
				}
				text = this.DefaultValue;
			}
			builder.Append(text);
		}

		// Token: 0x0400018B RID: 395
		private string key;

		// Token: 0x0400018C RID: 396
		private RegistryKey rootKey = Registry.LocalMachine;

		// Token: 0x0400018D RID: 397
		private string subKey;
	}
}
