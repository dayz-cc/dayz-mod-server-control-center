using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Crosire.Controlcenter.Setup.Properties
{
	// Token: 0x02000008 RID: 8
	[DebuggerNonUserCode]
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	[CompilerGenerated]
	internal class Resources
	{
		// Token: 0x0600002A RID: 42 RVA: 0x000066D8 File Offset: 0x000048D8
		internal Resources()
		{
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x0600002B RID: 43 RVA: 0x000066E0 File Offset: 0x000048E0
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (object.ReferenceEquals(Resources.resourceMan, null))
				{
					ResourceManager resourceManager = new ResourceManager("Crosire.Controlcenter.Setup.Properties.Resources", typeof(Resources).Assembly);
					Resources.resourceMan = resourceManager;
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600002C RID: 44 RVA: 0x0000671F File Offset: 0x0000491F
		// (set) Token: 0x0600002D RID: 45 RVA: 0x00006726 File Offset: 0x00004926
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

		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600002E RID: 46 RVA: 0x00006730 File Offset: 0x00004930
		internal static Bitmap background
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("background", Resources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600002F RID: 47 RVA: 0x00006758 File Offset: 0x00004958
		internal static Bitmap banner
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("banner", Resources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000030 RID: 48 RVA: 0x00006780 File Offset: 0x00004980
		internal static string button_back
		{
			get
			{
				return Resources.ResourceManager.GetString("button_back", Resources.resourceCulture);
			}
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000031 RID: 49 RVA: 0x00006796 File Offset: 0x00004996
		internal static string button_browse
		{
			get
			{
				return Resources.ResourceManager.GetString("button_browse", Resources.resourceCulture);
			}
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000032 RID: 50 RVA: 0x000067AC File Offset: 0x000049AC
		internal static string button_cancel
		{
			get
			{
				return Resources.ResourceManager.GetString("button_cancel", Resources.resourceCulture);
			}
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000033 RID: 51 RVA: 0x000067C2 File Offset: 0x000049C2
		internal static string button_finish
		{
			get
			{
				return Resources.ResourceManager.GetString("button_finish", Resources.resourceCulture);
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000034 RID: 52 RVA: 0x000067D8 File Offset: 0x000049D8
		internal static string button_fresh
		{
			get
			{
				return Resources.ResourceManager.GetString("button_fresh", Resources.resourceCulture);
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000035 RID: 53 RVA: 0x000067EE File Offset: 0x000049EE
		internal static string button_next
		{
			get
			{
				return Resources.ResourceManager.GetString("button_next", Resources.resourceCulture);
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000036 RID: 54 RVA: 0x00006804 File Offset: 0x00004A04
		internal static string button_own
		{
			get
			{
				return Resources.ResourceManager.GetString("button_own", Resources.resourceCulture);
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000037 RID: 55 RVA: 0x0000681A File Offset: 0x00004A1A
		internal static string button_reconfigurate
		{
			get
			{
				return Resources.ResourceManager.GetString("button_reconfigurate", Resources.resourceCulture);
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x06000038 RID: 56 RVA: 0x00006830 File Offset: 0x00004A30
		internal static string button_update
		{
			get
			{
				return Resources.ResourceManager.GetString("button_update", Resources.resourceCulture);
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x06000039 RID: 57 RVA: 0x00006846 File Offset: 0x00004A46
		internal static string error
		{
			get
			{
				return Resources.ResourceManager.GetString("error", Resources.resourceCulture);
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600003A RID: 58 RVA: 0x0000685C File Offset: 0x00004A5C
		internal static string group_database
		{
			get
			{
				return Resources.ResourceManager.GetString("group_database", Resources.resourceCulture);
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x0600003B RID: 59 RVA: 0x00006872 File Offset: 0x00004A72
		internal static string group_options
		{
			get
			{
				return Resources.ResourceManager.GetString("group_options", Resources.resourceCulture);
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x0600003C RID: 60 RVA: 0x00006888 File Offset: 0x00004A88
		internal static string host
		{
			get
			{
				return Resources.ResourceManager.GetString("host", Resources.resourceCulture);
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x0600003D RID: 61 RVA: 0x000068A0 File Offset: 0x00004AA0
		internal static Icon Icon
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("Icon", Resources.resourceCulture);
				return (Icon)@object;
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x0600003E RID: 62 RVA: 0x000068C8 File Offset: 0x00004AC8
		internal static Bitmap logo
		{
			get
			{
				object @object = Resources.ResourceManager.GetObject("logo", Resources.resourceCulture);
				return (Bitmap)@object;
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x0600003F RID: 63 RVA: 0x000068F0 File Offset: 0x00004AF0
		internal static string password
		{
			get
			{
				return Resources.ResourceManager.GetString("password", Resources.resourceCulture);
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x06000040 RID: 64 RVA: 0x00006906 File Offset: 0x00004B06
		internal static string sentence_chooselanguage
		{
			get
			{
				return Resources.ResourceManager.GetString("sentence_chooselanguage", Resources.resourceCulture);
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x06000041 RID: 65 RVA: 0x0000691C File Offset: 0x00004B1C
		internal static string sentence_enterdatabase
		{
			get
			{
				return Resources.ResourceManager.GetString("sentence_enterdatabase", Resources.resourceCulture);
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x06000042 RID: 66 RVA: 0x00006932 File Offset: 0x00004B32
		internal static string sentence_entermysql
		{
			get
			{
				return Resources.ResourceManager.GetString("sentence_entermysql", Resources.resourceCulture);
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000043 RID: 67 RVA: 0x00006948 File Offset: 0x00004B48
		internal static string sentence_enterpath
		{
			get
			{
				return Resources.ResourceManager.GetString("sentence_enterpath", Resources.resourceCulture);
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000044 RID: 68 RVA: 0x0000695E File Offset: 0x00004B5E
		internal static string sentence_installpatch
		{
			get
			{
				return Resources.ResourceManager.GetString("sentence_installpatch", Resources.resourceCulture);
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000045 RID: 69 RVA: 0x00006974 File Offset: 0x00004B74
		internal static string sentence_installredis
		{
			get
			{
				return Resources.ResourceManager.GetString("sentence_installredis", Resources.resourceCulture);
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000046 RID: 70 RVA: 0x0000698A File Offset: 0x00004B8A
		internal static string step_1
		{
			get
			{
				return Resources.ResourceManager.GetString("step_1", Resources.resourceCulture);
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000047 RID: 71 RVA: 0x000069A0 File Offset: 0x00004BA0
		internal static string step_2
		{
			get
			{
				return Resources.ResourceManager.GetString("step_2", Resources.resourceCulture);
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x06000048 RID: 72 RVA: 0x000069B6 File Offset: 0x00004BB6
		internal static string step_3
		{
			get
			{
				return Resources.ResourceManager.GetString("step_3", Resources.resourceCulture);
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x06000049 RID: 73 RVA: 0x000069CC File Offset: 0x00004BCC
		internal static string user
		{
			get
			{
				return Resources.ResourceManager.GetString("user", Resources.resourceCulture);
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x0600004A RID: 74 RVA: 0x000069E2 File Offset: 0x00004BE2
		internal static string version
		{
			get
			{
				return Resources.ResourceManager.GetString("version", Resources.resourceCulture);
			}
		}

		// Token: 0x0400005A RID: 90
		private static ResourceManager resourceMan;

		// Token: 0x0400005B RID: 91
		private static CultureInfo resourceCulture;
	}
}
