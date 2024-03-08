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
		// Token: 0x1700008A RID: 138
		// (get) Token: 0x06000115 RID: 277 RVA: 0x0001A124 File Offset: 0x00018324
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x06000116 RID: 278 RVA: 0x0001A13C File Offset: 0x0001833C
		// (set) Token: 0x06000117 RID: 279 RVA: 0x0001A15E File Offset: 0x0001835E
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

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x06000118 RID: 280 RVA: 0x0001A170 File Offset: 0x00018370
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

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x06000119 RID: 281 RVA: 0x0001A194 File Offset: 0x00018394
		[DebuggerNonUserCode]
		[DefaultSettingValue("ftp://www.dayzcc.tk")]
		[ApplicationScopedSetting]
		public string updateUrl
		{
			get
			{
				return (string)this["updateUrl"];
			}
		}

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x0600011A RID: 282 RVA: 0x0001A1B8 File Offset: 0x000183B8
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

		// Token: 0x1700008F RID: 143
		// (get) Token: 0x0600011B RID: 283 RVA: 0x0001A1DC File Offset: 0x000183DC
		[ApplicationScopedSetting]
		[DefaultSettingValue("http://rapidshare.com/files/3403905477/{0}.{1}.{2}.{3}.tar.gz?directstart=1")]
		[DebuggerNonUserCode]
		public string updateFull
		{
			get
			{
				return (string)this["updateFull"];
			}
		}

		// Token: 0x17000090 RID: 144
		// (get) Token: 0x0600011C RID: 284 RVA: 0x0001A200 File Offset: 0x00018400
		// (set) Token: 0x0600011D RID: 285 RVA: 0x0001A222 File Offset: 0x00018422
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

		// Token: 0x17000091 RID: 145
		// (get) Token: 0x0600011E RID: 286 RVA: 0x0001A238 File Offset: 0x00018438
		// (set) Token: 0x0600011F RID: 287 RVA: 0x0001A25A File Offset: 0x0001845A
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

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x06000120 RID: 288 RVA: 0x0001A26C File Offset: 0x0001846C
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

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x06000121 RID: 289 RVA: 0x0001A290 File Offset: 0x00018490
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

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x06000122 RID: 290 RVA: 0x0001A2B4 File Offset: 0x000184B4
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

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x06000123 RID: 291 RVA: 0x0001A2D8 File Offset: 0x000184D8
		[DefaultSettingValue("http://www.dayzcc.tk")]
		[ApplicationScopedSetting]
		[DebuggerNonUserCode]
		public string uiUrlHomepage
		{
			get
			{
				return (string)this["uiUrlHomepage"];
			}
		}

		// Token: 0x17000096 RID: 150
		// (get) Token: 0x06000124 RID: 292 RVA: 0x0001A2FC File Offset: 0x000184FC
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

		// Token: 0x04000153 RID: 339
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
