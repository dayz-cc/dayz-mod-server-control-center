using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Crosire.Controlcenter.Setup.Properties
{
	[DebuggerNonUserCode]
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
	[CompilerGenerated]
	internal class Resources
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
					ResourceManager resourceManager = new ResourceManager("Crosire.Controlcenter.Setup.Properties.Resources", typeof(Resources).Assembly);
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
				object @object = ResourceManager.GetObject("background", resourceCulture);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap banner
		{
			get
			{
				object @object = ResourceManager.GetObject("banner", resourceCulture);
				return (Bitmap)@object;
			}
		}

		internal static string button_back => ResourceManager.GetString("button_back", resourceCulture);

		internal static string button_browse => ResourceManager.GetString("button_browse", resourceCulture);

		internal static string button_cancel => ResourceManager.GetString("button_cancel", resourceCulture);

		internal static string button_finish => ResourceManager.GetString("button_finish", resourceCulture);

		internal static string button_fresh => ResourceManager.GetString("button_fresh", resourceCulture);

		internal static string button_next => ResourceManager.GetString("button_next", resourceCulture);

		internal static string button_own => ResourceManager.GetString("button_own", resourceCulture);

		internal static string button_reconfigurate => ResourceManager.GetString("button_reconfigurate", resourceCulture);

		internal static string button_update => ResourceManager.GetString("button_update", resourceCulture);

		internal static string error => ResourceManager.GetString("error", resourceCulture);

		internal static string group_database => ResourceManager.GetString("group_database", resourceCulture);

		internal static string group_options => ResourceManager.GetString("group_options", resourceCulture);

		internal static string host => ResourceManager.GetString("host", resourceCulture);

		internal static Icon Icon
		{
			get
			{
				object @object = ResourceManager.GetObject("Icon", resourceCulture);
				return (Icon)@object;
			}
		}

		internal static Bitmap logo
		{
			get
			{
				object @object = ResourceManager.GetObject("logo", resourceCulture);
				return (Bitmap)@object;
			}
		}

		internal static string password => ResourceManager.GetString("password", resourceCulture);

		internal static string sentence_chooselanguage => ResourceManager.GetString("sentence_chooselanguage", resourceCulture);

		internal static string sentence_enterdatabase => ResourceManager.GetString("sentence_enterdatabase", resourceCulture);

		internal static string sentence_entermysql => ResourceManager.GetString("sentence_entermysql", resourceCulture);

		internal static string sentence_enterpath => ResourceManager.GetString("sentence_enterpath", resourceCulture);

		internal static string sentence_installpatch => ResourceManager.GetString("sentence_installpatch", resourceCulture);

		internal static string sentence_installredis => ResourceManager.GetString("sentence_installredis", resourceCulture);

		internal static string step_1 => ResourceManager.GetString("step_1", resourceCulture);

		internal static string step_2 => ResourceManager.GetString("step_2", resourceCulture);

		internal static string step_3 => ResourceManager.GetString("step_3", resourceCulture);

		internal static string user => ResourceManager.GetString("user", resourceCulture);

		internal static string version => ResourceManager.GetString("version", resourceCulture);

		internal Resources()
		{
		}
	}
}
