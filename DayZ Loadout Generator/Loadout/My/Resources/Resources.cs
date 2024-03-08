using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Loadout.My.Resources
{
	// Token: 0x02000009 RID: 9
	[StandardModule]
	[CompilerGenerated]
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	[DebuggerNonUserCode]
	[HideModuleName]
	internal sealed class Resources
	{
		// Token: 0x1700006A RID: 106
		// (get) Token: 0x06000104 RID: 260 RVA: 0x0000FE84 File Offset: 0x0000E084
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (object.ReferenceEquals(Resources.resourceMan, null))
				{
					ResourceManager resourceManager = new ResourceManager("Loadout.Resources", typeof(Resources).Assembly);
					Resources.resourceMan = resourceManager;
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x1700006B RID: 107
		// (get) Token: 0x06000105 RID: 261 RVA: 0x0000FEC4 File Offset: 0x0000E0C4
		// (set) Token: 0x06000106 RID: 262 RVA: 0x0000FED8 File Offset: 0x0000E0D8
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

		// Token: 0x1700006C RID: 108
		// (get) Token: 0x06000107 RID: 263 RVA: 0x0000FEE0 File Offset: 0x0000E0E0
		internal static Bitmap background
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("background", Resources.resourceCulture));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x1700006D RID: 109
		// (get) Token: 0x06000108 RID: 264 RVA: 0x0000FF10 File Offset: 0x0000E110
		internal static Bitmap binocular
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("binocular", Resources.resourceCulture));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x1700006E RID: 110
		// (get) Token: 0x06000109 RID: 265 RVA: 0x0000FF40 File Offset: 0x0000E140
		internal static Bitmap gear
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("gear", Resources.resourceCulture));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x1700006F RID: 111
		// (get) Token: 0x0600010A RID: 266 RVA: 0x0000FF70 File Offset: 0x0000E170
		internal static Bitmap grenade
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("grenade", Resources.resourceCulture));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x17000070 RID: 112
		// (get) Token: 0x0600010B RID: 267 RVA: 0x0000FFA0 File Offset: 0x0000E1A0
		internal static Bitmap heavyammo
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("heavyammo", Resources.resourceCulture));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x17000071 RID: 113
		// (get) Token: 0x0600010C RID: 268 RVA: 0x0000FFD0 File Offset: 0x0000E1D0
		internal static Bitmap pistol
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("pistol", Resources.resourceCulture));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x0600010D RID: 269 RVA: 0x00010000 File Offset: 0x0000E200
		internal static Bitmap rifle
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("rifle", Resources.resourceCulture));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x17000073 RID: 115
		// (get) Token: 0x0600010E RID: 270 RVA: 0x00010030 File Offset: 0x0000E230
		internal static Bitmap second
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("second", Resources.resourceCulture));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x17000074 RID: 116
		// (get) Token: 0x0600010F RID: 271 RVA: 0x00010060 File Offset: 0x0000E260
		internal static Bitmap smallammo
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(Resources.ResourceManager.GetObject("smallammo", Resources.resourceCulture));
				return (Bitmap)objectValue;
			}
		}

		// Token: 0x040000A0 RID: 160
		private static ResourceManager resourceMan;

		// Token: 0x040000A1 RID: 161
		private static CultureInfo resourceCulture;
	}
}
