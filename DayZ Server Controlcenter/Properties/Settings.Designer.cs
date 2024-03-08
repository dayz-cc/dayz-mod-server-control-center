using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Crosire.Controlcenter.Properties
{
	// Token: 0x0200000D RID: 13
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
	internal sealed partial class Settings : ApplicationSettingsBase
	{
		// Token: 0x17000089 RID: 137
		// (get) Token: 0x06000111 RID: 273 RVA: 0x00019D5C File Offset: 0x00017F5C
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x06000112 RID: 274 RVA: 0x00019D74 File Offset: 0x00017F74
		// (set) Token: 0x06000113 RID: 275 RVA: 0x00019D96 File Offset: 0x00017F96
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("")]
		public string workingDir
		{
			get
			{
				return (string)this["workingDir"];
			}
			set
			{
				this["workingDir"] = value;
			}
		}

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x06000114 RID: 276 RVA: 0x00019DA8 File Offset: 0x00017FA8
		[ApplicationScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("release")]
		public string updateChannel
		{
			get
			{
				return (string)this["updateChannel"];
			}
		}

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x06000115 RID: 277 RVA: 0x00019DCC File Offset: 0x00017FCC
		[DebuggerNonUserCode]
		[DefaultSettingValue("ftp://mgc-portal.dyndns.org")]
		[ApplicationScopedSetting]
		public string updateUrl
		{
			get
			{
				return (string)this["updateUrl"];
			}
		}

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x06000116 RID: 278 RVA: 0x00019DF0 File Offset: 0x00017FF0
		[ApplicationScopedSetting]
		[DefaultSettingValue("DayZ_Server_Controlcenter_{0}-{1}-{2}-{3}")]
		[DebuggerNonUserCode]
		public string updateFolder
		{
			get
			{
				return (string)this["updateFolder"];
			}
		}

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x06000117 RID: 279 RVA: 0x00019E14 File Offset: 0x00018014
		[ApplicationScopedSetting]
		[DefaultSettingValue("http://mgc-portal.dyndns.org/dayzcc/5.9.4.1.tar.gz")]
		[DebuggerNonUserCode]
		public string updateFull
		{
			get
			{
				return (string)this["updateFull"];
			}
		}

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x06000118 RID: 280 RVA: 0x00019E38 File Offset: 0x00018038
		// (set) Token: 0x06000119 RID: 281 RVA: 0x00019E5A File Offset: 0x0001805A
		[UserScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("Normal")]
		public FormWindowState uiState
		{
			get
			{
				return (FormWindowState)this["uiState"];
			}
			set
			{
				this["uiState"] = value;
			}
		}

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x0600011A RID: 282 RVA: 0x00019E70 File Offset: 0x00018070
		// (set) Token: 0x0600011B RID: 283 RVA: 0x00019E92 File Offset: 0x00018092
		[DebuggerNonUserCode]
		[DefaultSettingValue("en")]
		[UserScopedSetting]
		public string uiLanguage
		{
			get
			{
				return (string)this["uiLanguage"];
			}
			set
			{
				this["uiLanguage"] = value;
			}
		}

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x0600011C RID: 284 RVA: 0x00019EA4 File Offset: 0x000180A4
		[ApplicationScopedSetting]
		[DebuggerNonUserCode]
		[DefaultSettingValue("6")]
		public int uiInstances
		{
			get
			{
				return (int)this["uiInstances"];
			}
		}

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x0600011D RID: 285 RVA: 0x00019EC8 File Offset: 0x000180C8
		[DebuggerNonUserCode]
		[DefaultSettingValue("http://127.0.0.1:78/dayz/index.php")]
		[ApplicationScopedSetting]
		public string uiUrlAdmin
		{
			get
			{
				return (string)this["uiUrlAdmin"];
			}
		}

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x0600011E RID: 286 RVA: 0x00019EEC File Offset: 0x000180EC
		[DefaultSettingValue("http://127.0.0.1:78/chive/index.php")]
		[DebuggerNonUserCode]
		[ApplicationScopedSetting]
		public string uiUrlDatabase
		{
			get
			{
				return (string)this["uiUrlDatabase"];
			}
		}

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x0600011F RID: 287 RVA: 0x00019F10 File Offset: 0x00018110
		[DefaultSettingValue("http://www.dayzcc.org")]
		[ApplicationScopedSetting]
		[DebuggerNonUserCode]
		public string uiUrlHomepage
		{
			get
			{
				return (string)this["uiUrlHomepage"];
			}
		}

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x06000120 RID: 288 RVA: 0x00019F34 File Offset: 0x00018134
		[DebuggerNonUserCode]
		[DefaultSettingValue("dayz.chernarus, dayz.lingor, dayz.utes, dayz.takistan, dayz.panthera2, dayz.fallujah, dayz.zargabad, dayz.namalsk, dayz.mbg_celle2, dayz.tavi, dayz.thirsk, dayz.oring, dayz.isladuala")]
		[ApplicationScopedSetting]
		public string confTemplates
		{
			get
			{
				return (string)this["confTemplates"];
			}
		}

		// Token: 0x04000150 RID: 336
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
