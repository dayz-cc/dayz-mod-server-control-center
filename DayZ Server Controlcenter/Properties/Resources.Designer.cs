using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Crosire.Controlcenter.Properties
{
	// Token: 0x0200000C RID: 12
	[DebuggerNonUserCode]
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	[CompilerGenerated]
	internal class Resources
	{
		// Token: 0x0600008B RID: 139 RVA: 0x00018B8B File Offset: 0x00016D8B
		internal Resources()
		{
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600008C RID: 140 RVA: 0x00018B98 File Offset: 0x00016D98
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (object.ReferenceEquals(Resources.resourceMan, null))
				{
					ResourceManager resourceManager = new ResourceManager("Crosire.Controlcenter.Properties.Resources", typeof(Resources).Assembly);
					Resources.resourceMan = resourceManager;
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600008D RID: 141 RVA: 0x00018BE4 File Offset: 0x00016DE4
		// (set) Token: 0x0600008E RID: 142 RVA: 0x00018BFB File Offset: 0x00016DFB
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Resources.resourceCulture;
			}
			set
			{
				Resources.resourceCulture = value;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600008F RID: 143 RVA: 0x00018C04 File Offset: 0x00016E04
		internal static Bitmap background
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("background", Resources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000090 RID: 144 RVA: 0x00018C34 File Offset: 0x00016E34
		internal static string backpack
		{
			get
			{
				return Resources.ResourceManager.GetString("backpack", Resources.resourceCulture);
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000091 RID: 145 RVA: 0x00018C5C File Offset: 0x00016E5C
		internal static string backupfolder
		{
			get
			{
				return Resources.ResourceManager.GetString("backupfolder", Resources.resourceCulture);
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000092 RID: 146 RVA: 0x00018C84 File Offset: 0x00016E84
		internal static Bitmap banner
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("banner", Resources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000093 RID: 147 RVA: 0x00018CB4 File Offset: 0x00016EB4
		internal static string build
		{
			get
			{
				return Resources.ResourceManager.GetString("build", Resources.resourceCulture);
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000094 RID: 148 RVA: 0x00018CDC File Offset: 0x00016EDC
		internal static string button_add_database
		{
			get
			{
				return Resources.ResourceManager.GetString("button_add_database", Resources.resourceCulture);
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000095 RID: 149 RVA: 0x00018D04 File Offset: 0x00016F04
		internal static string button_add_player
		{
			get
			{
				return Resources.ResourceManager.GetString("button_add_player", Resources.resourceCulture);
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000096 RID: 150 RVA: 0x00018D2C File Offset: 0x00016F2C
		internal static string button_autobackup_start
		{
			get
			{
				return Resources.ResourceManager.GetString("button_autobackup_start", Resources.resourceCulture);
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000097 RID: 151 RVA: 0x00018D54 File Offset: 0x00016F54
		internal static string button_autobackup_stop
		{
			get
			{
				return Resources.ResourceManager.GetString("button_autobackup_stop", Resources.resourceCulture);
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000098 RID: 152 RVA: 0x00018D7C File Offset: 0x00016F7C
		internal static string button_backup
		{
			get
			{
				return Resources.ResourceManager.GetString("button_backup", Resources.resourceCulture);
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000099 RID: 153 RVA: 0x00018DA4 File Offset: 0x00016FA4
		internal static string button_browse
		{
			get
			{
				return Resources.ResourceManager.GetString("button_browse", Resources.resourceCulture);
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600009A RID: 154 RVA: 0x00018DCC File Offset: 0x00016FCC
		internal static string button_cancel
		{
			get
			{
				return Resources.ResourceManager.GetString("button_cancel", Resources.resourceCulture);
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x0600009B RID: 155 RVA: 0x00018DF4 File Offset: 0x00016FF4
		internal static string button_clear
		{
			get
			{
				return Resources.ResourceManager.GetString("button_clear", Resources.resourceCulture);
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x0600009C RID: 156 RVA: 0x00018E1C File Offset: 0x0001701C
		internal static string button_details
		{
			get
			{
				return Resources.ResourceManager.GetString("button_details", Resources.resourceCulture);
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x0600009D RID: 157 RVA: 0x00018E44 File Offset: 0x00017044
		internal static string button_exit
		{
			get
			{
				return Resources.ResourceManager.GetString("button_exit", Resources.resourceCulture);
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600009E RID: 158 RVA: 0x00018E6C File Offset: 0x0001706C
		internal static string button_generate
		{
			get
			{
				return Resources.ResourceManager.GetString("button_generate", Resources.resourceCulture);
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x0600009F RID: 159 RVA: 0x00018E94 File Offset: 0x00017094
		internal static string button_log
		{
			get
			{
				return Resources.ResourceManager.GetString("button_log", Resources.resourceCulture);
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x060000A0 RID: 160 RVA: 0x00018EBC File Offset: 0x000170BC
		internal static string button_menu1
		{
			get
			{
				return Resources.ResourceManager.GetString("button_menu1", Resources.resourceCulture);
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x060000A1 RID: 161 RVA: 0x00018EE4 File Offset: 0x000170E4
		internal static string button_menu2
		{
			get
			{
				return Resources.ResourceManager.GetString("button_menu2", Resources.resourceCulture);
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x060000A2 RID: 162 RVA: 0x00018F0C File Offset: 0x0001710C
		internal static string button_menu3
		{
			get
			{
				return Resources.ResourceManager.GetString("button_menu3", Resources.resourceCulture);
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x060000A3 RID: 163 RVA: 0x00018F34 File Offset: 0x00017134
		internal static string button_menu4
		{
			get
			{
				return Resources.ResourceManager.GetString("button_menu4", Resources.resourceCulture);
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x060000A4 RID: 164 RVA: 0x00018F5C File Offset: 0x0001715C
		internal static string button_monitor_start
		{
			get
			{
				return Resources.ResourceManager.GetString("button_monitor_start", Resources.resourceCulture);
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x060000A5 RID: 165 RVA: 0x00018F84 File Offset: 0x00017184
		internal static string button_monitor_stop
		{
			get
			{
				return Resources.ResourceManager.GetString("button_monitor_stop", Resources.resourceCulture);
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x060000A6 RID: 166 RVA: 0x00018FAC File Offset: 0x000171AC
		internal static string button_mysql_password
		{
			get
			{
				return Resources.ResourceManager.GetString("button_mysql_password", Resources.resourceCulture);
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x060000A7 RID: 167 RVA: 0x00018FD4 File Offset: 0x000171D4
		internal static string button_ok
		{
			get
			{
				return Resources.ResourceManager.GetString("button_ok", Resources.resourceCulture);
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x060000A8 RID: 168 RVA: 0x00018FFC File Offset: 0x000171FC
		internal static string button_random
		{
			get
			{
				return Resources.ResourceManager.GetString("button_random", Resources.resourceCulture);
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x060000A9 RID: 169 RVA: 0x00019024 File Offset: 0x00017224
		internal static string button_reload
		{
			get
			{
				return Resources.ResourceManager.GetString("button_reload", Resources.resourceCulture);
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x060000AA RID: 170 RVA: 0x0001904C File Offset: 0x0001724C
		internal static string button_reset
		{
			get
			{
				return Resources.ResourceManager.GetString("button_reset", Resources.resourceCulture);
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x060000AB RID: 171 RVA: 0x00019074 File Offset: 0x00017274
		internal static string button_restore
		{
			get
			{
				return Resources.ResourceManager.GetString("button_restore", Resources.resourceCulture);
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x060000AC RID: 172 RVA: 0x0001909C File Offset: 0x0001729C
		internal static string button_save
		{
			get
			{
				return Resources.ResourceManager.GetString("button_save", Resources.resourceCulture);
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x060000AD RID: 173 RVA: 0x000190C4 File Offset: 0x000172C4
		internal static string button_save_config
		{
			get
			{
				return Resources.ResourceManager.GetString("button_save_config", Resources.resourceCulture);
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x060000AE RID: 174 RVA: 0x000190EC File Offset: 0x000172EC
		internal static string button_save_player
		{
			get
			{
				return Resources.ResourceManager.GetString("button_save_player", Resources.resourceCulture);
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x060000AF RID: 175 RVA: 0x00019114 File Offset: 0x00017314
		internal static string bytes
		{
			get
			{
				return Resources.ResourceManager.GetString("bytes", Resources.resourceCulture);
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x060000B0 RID: 176 RVA: 0x0001913C File Offset: 0x0001733C
		internal static string bytespersecond
		{
			get
			{
				return Resources.ResourceManager.GetString("bytespersecond", Resources.resourceCulture);
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x060000B1 RID: 177 RVA: 0x00019164 File Offset: 0x00017364
		internal static string check_daytime
		{
			get
			{
				return Resources.ResourceManager.GetString("check_daytime", Resources.resourceCulture);
			}
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x060000B2 RID: 178 RVA: 0x0001918C File Offset: 0x0001738C
		internal static string check_duplicate
		{
			get
			{
				return Resources.ResourceManager.GetString("check_duplicate", Resources.resourceCulture);
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x060000B3 RID: 179 RVA: 0x000191B4 File Offset: 0x000173B4
		internal static string check_enabled
		{
			get
			{
				return Resources.ResourceManager.GetString("check_enabled", Resources.resourceCulture);
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x060000B4 RID: 180 RVA: 0x000191DC File Offset: 0x000173DC
		internal static string check_persistent
		{
			get
			{
				return Resources.ResourceManager.GetString("check_persistent", Resources.resourceCulture);
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x060000B5 RID: 181 RVA: 0x00019204 File Offset: 0x00017404
		internal static string check_rmod
		{
			get
			{
				return Resources.ResourceManager.GetString("check_rmod", Resources.resourceCulture);
			}
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x060000B6 RID: 182 RVA: 0x0001922C File Offset: 0x0001742C
		internal static string check_whitelisted
		{
			get
			{
				return Resources.ResourceManager.GetString("check_whitelisted", Resources.resourceCulture);
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x060000B7 RID: 183 RVA: 0x00019254 File Offset: 0x00017454
		internal static string codecquality
		{
			get
			{
				return Resources.ResourceManager.GetString("codecquality", Resources.resourceCulture);
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x060000B8 RID: 184 RVA: 0x0001927C File Offset: 0x0001747C
		internal static string cpucount
		{
			get
			{
				return Resources.ResourceManager.GetString("cpucount", Resources.resourceCulture);
			}
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x060000B9 RID: 185 RVA: 0x000192A4 File Offset: 0x000174A4
		internal static string databasename
		{
			get
			{
				return Resources.ResourceManager.GetString("databasename", Resources.resourceCulture);
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x060000BA RID: 186 RVA: 0x000192CC File Offset: 0x000174CC
		internal static string difficulty
		{
			get
			{
				return Resources.ResourceManager.GetString("difficulty", Resources.resourceCulture);
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x060000BB RID: 187 RVA: 0x000192F4 File Offset: 0x000174F4
		internal static string group_about
		{
			get
			{
				return Resources.ResourceManager.GetString("group_about", Resources.resourceCulture);
			}
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x060000BC RID: 188 RVA: 0x0001931C File Offset: 0x0001751C
		internal static string group_autobackup
		{
			get
			{
				return Resources.ResourceManager.GetString("group_autobackup", Resources.resourceCulture);
			}
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x060000BD RID: 189 RVA: 0x00019344 File Offset: 0x00017544
		internal static string group_backup
		{
			get
			{
				return Resources.ResourceManager.GetString("group_backup", Resources.resourceCulture);
			}
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x060000BE RID: 190 RVA: 0x0001936C File Offset: 0x0001756C
		internal static string group_battleye
		{
			get
			{
				return Resources.ResourceManager.GetString("group_battleye", Resources.resourceCulture);
			}
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x060000BF RID: 191 RVA: 0x00019394 File Offset: 0x00017594
		internal static string group_message
		{
			get
			{
				return Resources.ResourceManager.GetString("group_message", Resources.resourceCulture);
			}
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x060000C0 RID: 192 RVA: 0x000193BC File Offset: 0x000175BC
		internal static string group_mysql
		{
			get
			{
				return Resources.ResourceManager.GetString("group_mysql", Resources.resourceCulture);
			}
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x060000C1 RID: 193 RVA: 0x000193E4 File Offset: 0x000175E4
		internal static string group_mysql_details
		{
			get
			{
				return Resources.ResourceManager.GetString("group_mysql_details", Resources.resourceCulture);
			}
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x060000C2 RID: 194 RVA: 0x0001940C File Offset: 0x0001760C
		internal static string group_other
		{
			get
			{
				return Resources.ResourceManager.GetString("group_other", Resources.resourceCulture);
			}
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x060000C3 RID: 195 RVA: 0x00019434 File Offset: 0x00017634
		internal static string group_profile
		{
			get
			{
				return Resources.ResourceManager.GetString("group_profile", Resources.resourceCulture);
			}
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x060000C4 RID: 196 RVA: 0x0001945C File Offset: 0x0001765C
		internal static string group_reset
		{
			get
			{
				return Resources.ResourceManager.GetString("group_reset", Resources.resourceCulture);
			}
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x060000C5 RID: 197 RVA: 0x00019484 File Offset: 0x00017684
		internal static string group_restore
		{
			get
			{
				return Resources.ResourceManager.GetString("group_restore", Resources.resourceCulture);
			}
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x060000C6 RID: 198 RVA: 0x000194AC File Offset: 0x000176AC
		internal static string group_scripting
		{
			get
			{
				return Resources.ResourceManager.GetString("group_scripting", Resources.resourceCulture);
			}
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x060000C7 RID: 199 RVA: 0x000194D4 File Offset: 0x000176D4
		internal static string group_settings
		{
			get
			{
				return Resources.ResourceManager.GetString("group_settings", Resources.resourceCulture);
			}
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x060000C8 RID: 200 RVA: 0x000194FC File Offset: 0x000176FC
		internal static string group_signatures
		{
			get
			{
				return Resources.ResourceManager.GetString("group_signatures", Resources.resourceCulture);
			}
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x060000C9 RID: 201 RVA: 0x00019524 File Offset: 0x00017724
		internal static string group_survivor
		{
			get
			{
				return Resources.ResourceManager.GetString("group_survivor", Resources.resourceCulture);
			}
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x060000CA RID: 202 RVA: 0x0001954C File Offset: 0x0001774C
		internal static string group_template
		{
			get
			{
				return Resources.ResourceManager.GetString("group_template", Resources.resourceCulture);
			}
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x060000CB RID: 203 RVA: 0x00019574 File Offset: 0x00017774
		internal static string group_time
		{
			get
			{
				return Resources.ResourceManager.GetString("group_time", Resources.resourceCulture);
			}
		}

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x060000CC RID: 204 RVA: 0x0001959C File Offset: 0x0001779C
		internal static string group_tuning_network
		{
			get
			{
				return Resources.ResourceManager.GetString("group_tuning_network", Resources.resourceCulture);
			}
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x060000CD RID: 205 RVA: 0x000195C4 File Offset: 0x000177C4
		internal static string group_tuning_performance
		{
			get
			{
				return Resources.ResourceManager.GetString("group_tuning_performance", Resources.resourceCulture);
			}
		}

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x060000CE RID: 206 RVA: 0x000195EC File Offset: 0x000177EC
		internal static string group_von
		{
			get
			{
				return Resources.ResourceManager.GetString("group_von", Resources.resourceCulture);
			}
		}

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x060000CF RID: 207 RVA: 0x00019614 File Offset: 0x00017814
		internal static string group_whitelist
		{
			get
			{
				return Resources.ResourceManager.GetString("group_whitelist", Resources.resourceCulture);
			}
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x060000D0 RID: 208 RVA: 0x0001963C File Offset: 0x0001783C
		internal static string guid
		{
			get
			{
				return Resources.ResourceManager.GetString("guid", Resources.resourceCulture);
			}
		}

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x060000D1 RID: 209 RVA: 0x00019664 File Offset: 0x00017864
		internal static Icon icon
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("icon", Resources.resourceCulture);
				return (Icon)@object;
			}
		}

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x060000D2 RID: 210 RVA: 0x00019694 File Offset: 0x00017894
		internal static string instance
		{
			get
			{
				return Resources.ResourceManager.GetString("instance", Resources.resourceCulture);
			}
		}

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x060000D3 RID: 211 RVA: 0x000196BC File Offset: 0x000178BC
		internal static string inventory
		{
			get
			{
				return Resources.ResourceManager.GetString("inventory", Resources.resourceCulture);
			}
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x060000D4 RID: 212 RVA: 0x000196E4 File Offset: 0x000178E4
		internal static string kilobyte
		{
			get
			{
				return Resources.ResourceManager.GetString("kilobyte", Resources.resourceCulture);
			}
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x060000D5 RID: 213 RVA: 0x0001970C File Offset: 0x0001790C
		internal static Bitmap license
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("license", Resources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x060000D6 RID: 214 RVA: 0x0001973C File Offset: 0x0001793C
		internal static string loadout
		{
			get
			{
				return Resources.ResourceManager.GetString("loadout", Resources.resourceCulture);
			}
		}

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x060000D7 RID: 215 RVA: 0x00019764 File Offset: 0x00017964
		internal static string loadoutbackpack
		{
			get
			{
				return Resources.ResourceManager.GetString("loadoutbackpack", Resources.resourceCulture);
			}
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x060000D8 RID: 216 RVA: 0x0001978C File Offset: 0x0001798C
		internal static Bitmap logo
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("logo", Resources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x060000D9 RID: 217 RVA: 0x000197BC File Offset: 0x000179BC
		internal static Bitmap logo_dayzpriv
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("logo_dayzpriv", Resources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x060000DA RID: 218 RVA: 0x000197EC File Offset: 0x000179EC
		internal static string maxbandwidth
		{
			get
			{
				return Resources.ResourceManager.GetString("maxbandwidth", Resources.resourceCulture);
			}
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x060000DB RID: 219 RVA: 0x00019814 File Offset: 0x00017A14
		internal static string maxcustomsize
		{
			get
			{
				return Resources.ResourceManager.GetString("maxcustomsize", Resources.resourceCulture);
			}
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x060000DC RID: 220 RVA: 0x0001983C File Offset: 0x00017A3C
		internal static string maxmsgsent
		{
			get
			{
				return Resources.ResourceManager.GetString("maxmsgsent", Resources.resourceCulture);
			}
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x060000DD RID: 221 RVA: 0x00019864 File Offset: 0x00017A64
		internal static string maxping
		{
			get
			{
				return Resources.ResourceManager.GetString("maxping", Resources.resourceCulture);
			}
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x060000DE RID: 222 RVA: 0x0001988C File Offset: 0x00017A8C
		internal static string maxplayers
		{
			get
			{
				return Resources.ResourceManager.GetString("maxplayers", Resources.resourceCulture);
			}
		}

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x060000DF RID: 223 RVA: 0x000198B4 File Offset: 0x00017AB4
		internal static string maxsizeguaranteed
		{
			get
			{
				return Resources.ResourceManager.GetString("maxsizeguaranteed", Resources.resourceCulture);
			}
		}

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x060000E0 RID: 224 RVA: 0x000198DC File Offset: 0x00017ADC
		internal static string maxsizenonguaranteed
		{
			get
			{
				return Resources.ResourceManager.GetString("maxsizenonguaranteed", Resources.resourceCulture);
			}
		}

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x060000E1 RID: 225 RVA: 0x00019904 File Offset: 0x00017B04
		internal static string maxvehicles
		{
			get
			{
				return Resources.ResourceManager.GetString("maxvehicles", Resources.resourceCulture);
			}
		}

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x060000E2 RID: 226 RVA: 0x0001992C File Offset: 0x00017B2C
		internal static string medical
		{
			get
			{
				return Resources.ResourceManager.GetString("medical", Resources.resourceCulture);
			}
		}

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x060000E3 RID: 227 RVA: 0x00019954 File Offset: 0x00017B54
		internal static string message
		{
			get
			{
				return Resources.ResourceManager.GetString("message", Resources.resourceCulture);
			}
		}

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x060000E4 RID: 228 RVA: 0x0001997C File Offset: 0x00017B7C
		internal static string message_confirm_database
		{
			get
			{
				return Resources.ResourceManager.GetString("message_confirm_database", Resources.resourceCulture);
			}
		}

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x060000E5 RID: 229 RVA: 0x000199A4 File Offset: 0x00017BA4
		internal static string message_confirm_deletelog
		{
			get
			{
				return Resources.ResourceManager.GetString("message_confirm_deletelog", Resources.resourceCulture);
			}
		}

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x060000E6 RID: 230 RVA: 0x000199CC File Offset: 0x00017BCC
		internal static string message_confirm_player
		{
			get
			{
				return Resources.ResourceManager.GetString("message_confirm_player", Resources.resourceCulture);
			}
		}

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x060000E7 RID: 231 RVA: 0x000199F4 File Offset: 0x00017BF4
		internal static string message_error_database
		{
			get
			{
				return Resources.ResourceManager.GetString("message_error_database", Resources.resourceCulture);
			}
		}

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x060000E8 RID: 232 RVA: 0x00019A1C File Offset: 0x00017C1C
		internal static string message_error_restore
		{
			get
			{
				return Resources.ResourceManager.GetString("message_error_restore", Resources.resourceCulture);
			}
		}

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x060000E9 RID: 233 RVA: 0x00019A44 File Offset: 0x00017C44
		internal static string message_finished_database
		{
			get
			{
				return Resources.ResourceManager.GetString("message_finished_database", Resources.resourceCulture);
			}
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x060000EA RID: 234 RVA: 0x00019A6C File Offset: 0x00017C6C
		internal static string message_finished_reset
		{
			get
			{
				return Resources.ResourceManager.GetString("message_finished_reset", Resources.resourceCulture);
			}
		}

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x060000EB RID: 235 RVA: 0x00019A94 File Offset: 0x00017C94
		internal static string message_finished_restore
		{
			get
			{
				return Resources.ResourceManager.GetString("message_finished_restore", Resources.resourceCulture);
			}
		}

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x060000EC RID: 236 RVA: 0x00019ABC File Offset: 0x00017CBC
		internal static string message_reset
		{
			get
			{
				return Resources.ResourceManager.GetString("message_reset", Resources.resourceCulture);
			}
		}

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x060000ED RID: 237 RVA: 0x00019AE4 File Offset: 0x00017CE4
		internal static string messagejoin
		{
			get
			{
				return Resources.ResourceManager.GetString("messagejoin", Resources.resourceCulture);
			}
		}

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x060000EE RID: 238 RVA: 0x00019B0C File Offset: 0x00017D0C
		internal static string messagetime
		{
			get
			{
				return Resources.ResourceManager.GetString("messagetime", Resources.resourceCulture);
			}
		}

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x060000EF RID: 239 RVA: 0x00019B34 File Offset: 0x00017D34
		internal static string minbandwidth
		{
			get
			{
				return Resources.ResourceManager.GetString("minbandwidth", Resources.resourceCulture);
			}
		}

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x060000F0 RID: 240 RVA: 0x00019B5C File Offset: 0x00017D5C
		internal static string minerrtosend
		{
			get
			{
				return Resources.ResourceManager.GetString("minerrtosend", Resources.resourceCulture);
			}
		}

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x060000F1 RID: 241 RVA: 0x00019B84 File Offset: 0x00017D84
		internal static string minerrtosendnear
		{
			get
			{
				return Resources.ResourceManager.GetString("minerrtosendnear", Resources.resourceCulture);
			}
		}

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x060000F2 RID: 242 RVA: 0x00019BAC File Offset: 0x00017DAC
		internal static string modlist
		{
			get
			{
				return Resources.ResourceManager.GetString("modlist", Resources.resourceCulture);
			}
		}

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x060000F3 RID: 243 RVA: 0x00019BD4 File Offset: 0x00017DD4
		internal static string mysql_credentials
		{
			get
			{
				return Resources.ResourceManager.GetString("mysql_credentials", Resources.resourceCulture);
			}
		}

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x060000F4 RID: 244 RVA: 0x00019BFC File Offset: 0x00017DFC
		internal static string mysql_host
		{
			get
			{
				return Resources.ResourceManager.GetString("mysql_host", Resources.resourceCulture);
			}
		}

		// Token: 0x1700006A RID: 106
		// (get) Token: 0x060000F5 RID: 245 RVA: 0x00019C24 File Offset: 0x00017E24
		internal static string name
		{
			get
			{
				return Resources.ResourceManager.GetString("name", Resources.resourceCulture);
			}
		}

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x060000F6 RID: 246 RVA: 0x00019C4C File Offset: 0x00017E4C
		internal static string password
		{
			get
			{
				return Resources.ResourceManager.GetString("password", Resources.resourceCulture);
			}
		}

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x060000F7 RID: 247 RVA: 0x00019C74 File Offset: 0x00017E74
		internal static string passwordadmin
		{
			get
			{
				return Resources.ResourceManager.GetString("passwordadmin", Resources.resourceCulture);
			}
		}

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x060000F8 RID: 248 RVA: 0x00019C9C File Offset: 0x00017E9C
		internal static string passwordrcon
		{
			get
			{
				return Resources.ResourceManager.GetString("passwordrcon", Resources.resourceCulture);
			}
		}

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x060000F9 RID: 249 RVA: 0x00019CC4 File Offset: 0x00017EC4
		internal static string port
		{
			get
			{
				return Resources.ResourceManager.GetString("port", Resources.resourceCulture);
			}
		}

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x060000FA RID: 250 RVA: 0x00019CEC File Offset: 0x00017EEC
		internal static string position
		{
			get
			{
				return Resources.ResourceManager.GetString("position", Resources.resourceCulture);
			}
		}

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x060000FB RID: 251 RVA: 0x00019D14 File Offset: 0x00017F14
		internal static string reportingip
		{
			get
			{
				return Resources.ResourceManager.GetString("reportingip", Resources.resourceCulture);
			}
		}

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x060000FC RID: 252 RVA: 0x00019D3C File Offset: 0x00017F3C
		internal static string requiresecureid
		{
			get
			{
				return Resources.ResourceManager.GetString("requiresecureid", Resources.resourceCulture);
			}
		}

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x060000FD RID: 253 RVA: 0x00019D64 File Offset: 0x00017F64
		internal static string sentence_backupinterval
		{
			get
			{
				return Resources.ResourceManager.GetString("sentence_backupinterval", Resources.resourceCulture);
			}
		}

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x060000FE RID: 254 RVA: 0x00019D8C File Offset: 0x00017F8C
		internal static string sentence_chooselanguage
		{
			get
			{
				return Resources.ResourceManager.GetString("sentence_chooselanguage", Resources.resourceCulture);
			}
		}

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x060000FF RID: 255 RVA: 0x00019DB4 File Offset: 0x00017FB4
		internal static string sentence_menu1_description
		{
			get
			{
				return Resources.ResourceManager.GetString("sentence_menu1_description", Resources.resourceCulture);
			}
		}

		// Token: 0x17000075 RID: 117
		// (get) Token: 0x06000100 RID: 256 RVA: 0x00019DDC File Offset: 0x00017FDC
		internal static string sentence_menu2_description
		{
			get
			{
				return Resources.ResourceManager.GetString("sentence_menu2_description", Resources.resourceCulture);
			}
		}

		// Token: 0x17000076 RID: 118
		// (get) Token: 0x06000101 RID: 257 RVA: 0x00019E04 File Offset: 0x00018004
		internal static string sentence_menu3_description
		{
			get
			{
				return Resources.ResourceManager.GetString("sentence_menu3_description", Resources.resourceCulture);
			}
		}

		// Token: 0x17000077 RID: 119
		// (get) Token: 0x06000102 RID: 258 RVA: 0x00019E2C File Offset: 0x0001802C
		internal static string sentence_menu4_description
		{
			get
			{
				return Resources.ResourceManager.GetString("sentence_menu4_description", Resources.resourceCulture);
			}
		}

		// Token: 0x17000078 RID: 120
		// (get) Token: 0x06000103 RID: 259 RVA: 0x00019E54 File Offset: 0x00018054
		internal static string sentence_message
		{
			get
			{
				return Resources.ResourceManager.GetString("sentence_message", Resources.resourceCulture);
			}
		}

		// Token: 0x17000079 RID: 121
		// (get) Token: 0x06000104 RID: 260 RVA: 0x00019E7C File Offset: 0x0001807C
		internal static string sentence_reset
		{
			get
			{
				return Resources.ResourceManager.GetString("sentence_reset", Resources.resourceCulture);
			}
		}

		// Token: 0x1700007A RID: 122
		// (get) Token: 0x06000105 RID: 261 RVA: 0x00019EA4 File Offset: 0x000180A4
		internal static string sentence_selectinstance
		{
			get
			{
				return Resources.ResourceManager.GetString("sentence_selectinstance", Resources.resourceCulture);
			}
		}

		// Token: 0x1700007B RID: 123
		// (get) Token: 0x06000106 RID: 262 RVA: 0x00019ECC File Offset: 0x000180CC
		internal static string servername
		{
			get
			{
				return Resources.ResourceManager.GetString("servername", Resources.resourceCulture);
			}
		}

		// Token: 0x1700007C RID: 124
		// (get) Token: 0x06000107 RID: 263 RVA: 0x00019EF4 File Offset: 0x000180F4
		internal static string tab1_page1
		{
			get
			{
				return Resources.ResourceManager.GetString("tab1_page1", Resources.resourceCulture);
			}
		}

		// Token: 0x1700007D RID: 125
		// (get) Token: 0x06000108 RID: 264 RVA: 0x00019F1C File Offset: 0x0001811C
		internal static string tab1_page2
		{
			get
			{
				return Resources.ResourceManager.GetString("tab1_page2", Resources.resourceCulture);
			}
		}

		// Token: 0x1700007E RID: 126
		// (get) Token: 0x06000109 RID: 265 RVA: 0x00019F44 File Offset: 0x00018144
		internal static string tab1_page3
		{
			get
			{
				return Resources.ResourceManager.GetString("tab1_page3", Resources.resourceCulture);
			}
		}

		// Token: 0x1700007F RID: 127
		// (get) Token: 0x0600010A RID: 266 RVA: 0x00019F6C File Offset: 0x0001816C
		internal static string tab2_page1
		{
			get
			{
				return Resources.ResourceManager.GetString("tab2_page1", Resources.resourceCulture);
			}
		}

		// Token: 0x17000080 RID: 128
		// (get) Token: 0x0600010B RID: 267 RVA: 0x00019F94 File Offset: 0x00018194
		internal static string tab2_page2
		{
			get
			{
				return Resources.ResourceManager.GetString("tab2_page2", Resources.resourceCulture);
			}
		}

		// Token: 0x17000081 RID: 129
		// (get) Token: 0x0600010C RID: 268 RVA: 0x00019FBC File Offset: 0x000181BC
		internal static string tab2_page3
		{
			get
			{
				return Resources.ResourceManager.GetString("tab2_page3", Resources.resourceCulture);
			}
		}

		// Token: 0x17000082 RID: 130
		// (get) Token: 0x0600010D RID: 269 RVA: 0x00019FE4 File Offset: 0x000181E4
		internal static string tab3_page1
		{
			get
			{
				return Resources.ResourceManager.GetString("tab3_page1", Resources.resourceCulture);
			}
		}

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x0600010E RID: 270 RVA: 0x0001A00C File Offset: 0x0001820C
		internal static string tab3_page2
		{
			get
			{
				return Resources.ResourceManager.GetString("tab3_page2", Resources.resourceCulture);
			}
		}

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x0600010F RID: 271 RVA: 0x0001A034 File Offset: 0x00018234
		internal static string tab3_page3
		{
			get
			{
				return Resources.ResourceManager.GetString("tab3_page3", Resources.resourceCulture);
			}
		}

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x06000110 RID: 272 RVA: 0x0001A05C File Offset: 0x0001825C
		internal static string template
		{
			get
			{
				return Resources.ResourceManager.GetString("template", Resources.resourceCulture);
			}
		}

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x06000111 RID: 273 RVA: 0x0001A084 File Offset: 0x00018284
		internal static string timezone
		{
			get
			{
				return Resources.ResourceManager.GetString("timezone", Resources.resourceCulture);
			}
		}

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x06000112 RID: 274 RVA: 0x0001A0AC File Offset: 0x000182AC
		internal static string uid
		{
			get
			{
				return Resources.ResourceManager.GetString("uid", Resources.resourceCulture);
			}
		}

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x06000113 RID: 275 RVA: 0x0001A0D4 File Offset: 0x000182D4
		internal static string verifysignatures
		{
			get
			{
				return Resources.ResourceManager.GetString("verifysignatures", Resources.resourceCulture);
			}
		}

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x06000114 RID: 276 RVA: 0x0001A0FC File Offset: 0x000182FC
		internal static string version
		{
			get
			{
				return Resources.ResourceManager.GetString("version", Resources.resourceCulture);
			}
		}

		// Token: 0x04000151 RID: 337
		private static ResourceManager resourceMan;

		// Token: 0x04000152 RID: 338
		private static CultureInfo resourceCulture;
	}
}
