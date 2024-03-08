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
	[StandardModule]
	[CompilerGenerated]
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	[DebuggerNonUserCode]
	[HideModuleName]
	internal sealed class Resources
	{
		private static ResourceManager resourceMan;

		private static CultureInfo resourceCulture;

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				if (object.ReferenceEquals(resourceMan, null))
				{
					ResourceManager resourceManager = new ResourceManager("Loadout.Resources", typeof(Resources).Assembly);
					resourceMan = resourceManager;
				}
				return resourceMan;
			}
		}

		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return resourceCulture;
			}
			set
			{
				resourceCulture = value;
			}
		}

		internal static Bitmap background
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(ResourceManager.GetObject("background", resourceCulture));
				return (Bitmap)objectValue;
			}
		}

		internal static Bitmap binocular
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(ResourceManager.GetObject("binocular", resourceCulture));
				return (Bitmap)objectValue;
			}
		}

		internal static Bitmap gear
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(ResourceManager.GetObject("gear", resourceCulture));
				return (Bitmap)objectValue;
			}
		}

		internal static Bitmap grenade
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(ResourceManager.GetObject("grenade", resourceCulture));
				return (Bitmap)objectValue;
			}
		}

		internal static Bitmap heavyammo
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(ResourceManager.GetObject("heavyammo", resourceCulture));
				return (Bitmap)objectValue;
			}
		}

		internal static Bitmap pistol
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(ResourceManager.GetObject("pistol", resourceCulture));
				return (Bitmap)objectValue;
			}
		}

		internal static Bitmap rifle
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(ResourceManager.GetObject("rifle", resourceCulture));
				return (Bitmap)objectValue;
			}
		}

		internal static Bitmap second
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(ResourceManager.GetObject("second", resourceCulture));
				return (Bitmap)objectValue;
			}
		}

		internal static Bitmap smallammo
		{
			get
			{
				object objectValue = RuntimeHelpers.GetObjectValue(ResourceManager.GetObject("smallammo", resourceCulture));
				return (Bitmap)objectValue;
			}
		}
	}
}
