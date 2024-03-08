using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Crosire.Controlcenter.Properties
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
					ResourceManager resourceManager = new ResourceManager("Crosire.Controlcenter.Properties.Resources", typeof(Resources).Assembly);
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

		internal static string backpack => ResourceManager.GetString("backpack", resourceCulture);

		internal static string backupfolder => ResourceManager.GetString("backupfolder", resourceCulture);

		internal static Bitmap banner
		{
			get
			{
				object @object = ResourceManager.GetObject("banner", resourceCulture);
				return (Bitmap)@object;
			}
		}

		internal static string build => ResourceManager.GetString("build", resourceCulture);

		internal static string button_add_database => ResourceManager.GetString("button_add_database", resourceCulture);

		internal static string button_add_player => ResourceManager.GetString("button_add_player", resourceCulture);

		internal static string button_autobackup_start => ResourceManager.GetString("button_autobackup_start", resourceCulture);

		internal static string button_autobackup_stop => ResourceManager.GetString("button_autobackup_stop", resourceCulture);

		internal static string button_backup => ResourceManager.GetString("button_backup", resourceCulture);

		internal static string button_browse => ResourceManager.GetString("button_browse", resourceCulture);

		internal static string button_cancel => ResourceManager.GetString("button_cancel", resourceCulture);

		internal static string button_clear => ResourceManager.GetString("button_clear", resourceCulture);

		internal static string button_details => ResourceManager.GetString("button_details", resourceCulture);

		internal static string button_exit => ResourceManager.GetString("button_exit", resourceCulture);

		internal static string button_generate => ResourceManager.GetString("button_generate", resourceCulture);

		internal static string button_log => ResourceManager.GetString("button_log", resourceCulture);

		internal static string button_menu1 => ResourceManager.GetString("button_menu1", resourceCulture);

		internal static string button_menu2 => ResourceManager.GetString("button_menu2", resourceCulture);

		internal static string button_menu3 => ResourceManager.GetString("button_menu3", resourceCulture);

		internal static string button_menu4 => ResourceManager.GetString("button_menu4", resourceCulture);

		internal static string button_monitor_start => ResourceManager.GetString("button_monitor_start", resourceCulture);

		internal static string button_monitor_stop => ResourceManager.GetString("button_monitor_stop", resourceCulture);

		internal static string button_mysql_password => ResourceManager.GetString("button_mysql_password", resourceCulture);

		internal static string button_ok => ResourceManager.GetString("button_ok", resourceCulture);

		internal static string button_random => ResourceManager.GetString("button_random", resourceCulture);

		internal static string button_reload => ResourceManager.GetString("button_reload", resourceCulture);

		internal static string button_reset => ResourceManager.GetString("button_reset", resourceCulture);

		internal static string button_restore => ResourceManager.GetString("button_restore", resourceCulture);

		internal static string button_save => ResourceManager.GetString("button_save", resourceCulture);

		internal static string button_save_config => ResourceManager.GetString("button_save_config", resourceCulture);

		internal static string button_save_player => ResourceManager.GetString("button_save_player", resourceCulture);

		internal static string bytes => ResourceManager.GetString("bytes", resourceCulture);

		internal static string bytespersecond => ResourceManager.GetString("bytespersecond", resourceCulture);

		internal static string check_daytime => ResourceManager.GetString("check_daytime", resourceCulture);

		internal static string check_duplicate => ResourceManager.GetString("check_duplicate", resourceCulture);

		internal static string check_enabled => ResourceManager.GetString("check_enabled", resourceCulture);

		internal static string check_persistent => ResourceManager.GetString("check_persistent", resourceCulture);

		internal static string check_rmod => ResourceManager.GetString("check_rmod", resourceCulture);

		internal static string check_whitelisted => ResourceManager.GetString("check_whitelisted", resourceCulture);

		internal static string codecquality => ResourceManager.GetString("codecquality", resourceCulture);

		internal static string cpucount => ResourceManager.GetString("cpucount", resourceCulture);

		internal static string databasename => ResourceManager.GetString("databasename", resourceCulture);

		internal static string difficulty => ResourceManager.GetString("difficulty", resourceCulture);

		internal static string group_about => ResourceManager.GetString("group_about", resourceCulture);

		internal static string group_autobackup => ResourceManager.GetString("group_autobackup", resourceCulture);

		internal static string group_backup => ResourceManager.GetString("group_backup", resourceCulture);

		internal static string group_battleye => ResourceManager.GetString("group_battleye", resourceCulture);

		internal static string group_message => ResourceManager.GetString("group_message", resourceCulture);

		internal static string group_mysql => ResourceManager.GetString("group_mysql", resourceCulture);

		internal static string group_mysql_details => ResourceManager.GetString("group_mysql_details", resourceCulture);

		internal static string group_other => ResourceManager.GetString("group_other", resourceCulture);

		internal static string group_profile => ResourceManager.GetString("group_profile", resourceCulture);

		internal static string group_reset => ResourceManager.GetString("group_reset", resourceCulture);

		internal static string group_restore => ResourceManager.GetString("group_restore", resourceCulture);

		internal static string group_scripting => ResourceManager.GetString("group_scripting", resourceCulture);

		internal static string group_settings => ResourceManager.GetString("group_settings", resourceCulture);

		internal static string group_signatures => ResourceManager.GetString("group_signatures", resourceCulture);

		internal static string group_survivor => ResourceManager.GetString("group_survivor", resourceCulture);

		internal static string group_template => ResourceManager.GetString("group_template", resourceCulture);

		internal static string group_time => ResourceManager.GetString("group_time", resourceCulture);

		internal static string group_tuning_network => ResourceManager.GetString("group_tuning_network", resourceCulture);

		internal static string group_tuning_performance => ResourceManager.GetString("group_tuning_performance", resourceCulture);

		internal static string group_von => ResourceManager.GetString("group_von", resourceCulture);

		internal static string group_whitelist => ResourceManager.GetString("group_whitelist", resourceCulture);

		internal static string guid => ResourceManager.GetString("guid", resourceCulture);

		internal static Icon icon
		{
			get
			{
				object @object = ResourceManager.GetObject("icon", resourceCulture);
				return (Icon)@object;
			}
		}

		internal static string instance => ResourceManager.GetString("instance", resourceCulture);

		internal static string inventory => ResourceManager.GetString("inventory", resourceCulture);

		internal static string kilobyte => ResourceManager.GetString("kilobyte", resourceCulture);

		internal static Bitmap license
		{
			get
			{
				object @object = ResourceManager.GetObject("license", resourceCulture);
				return (Bitmap)@object;
			}
		}

		internal static string loadout => ResourceManager.GetString("loadout", resourceCulture);

		internal static string loadoutbackpack => ResourceManager.GetString("loadoutbackpack", resourceCulture);

		internal static Bitmap logo
		{
			get
			{
				object @object = ResourceManager.GetObject("logo", resourceCulture);
				return (Bitmap)@object;
			}
		}

		internal static Bitmap logo_dayzpriv
		{
			get
			{
				object @object = ResourceManager.GetObject("logo_dayzpriv", resourceCulture);
				return (Bitmap)@object;
			}
		}

		internal static string maxbandwidth => ResourceManager.GetString("maxbandwidth", resourceCulture);

		internal static string maxcustomsize => ResourceManager.GetString("maxcustomsize", resourceCulture);

		internal static string maxmsgsent => ResourceManager.GetString("maxmsgsent", resourceCulture);

		internal static string maxping => ResourceManager.GetString("maxping", resourceCulture);

		internal static string maxplayers => ResourceManager.GetString("maxplayers", resourceCulture);

		internal static string maxsizeguaranteed => ResourceManager.GetString("maxsizeguaranteed", resourceCulture);

		internal static string maxsizenonguaranteed => ResourceManager.GetString("maxsizenonguaranteed", resourceCulture);

		internal static string maxvehicles => ResourceManager.GetString("maxvehicles", resourceCulture);

		internal static string medical => ResourceManager.GetString("medical", resourceCulture);

		internal static string message => ResourceManager.GetString("message", resourceCulture);

		internal static string message_confirm_database => ResourceManager.GetString("message_confirm_database", resourceCulture);

		internal static string message_confirm_deletelog => ResourceManager.GetString("message_confirm_deletelog", resourceCulture);

		internal static string message_confirm_player => ResourceManager.GetString("message_confirm_player", resourceCulture);

		internal static string message_error_database => ResourceManager.GetString("message_error_database", resourceCulture);

		internal static string message_error_restore => ResourceManager.GetString("message_error_restore", resourceCulture);

		internal static string message_finished_database => ResourceManager.GetString("message_finished_database", resourceCulture);

		internal static string message_finished_reset => ResourceManager.GetString("message_finished_reset", resourceCulture);

		internal static string message_finished_restore => ResourceManager.GetString("message_finished_restore", resourceCulture);

		internal static string message_reset => ResourceManager.GetString("message_reset", resourceCulture);

		internal static string messagejoin => ResourceManager.GetString("messagejoin", resourceCulture);

		internal static string messagetime => ResourceManager.GetString("messagetime", resourceCulture);

		internal static string minbandwidth => ResourceManager.GetString("minbandwidth", resourceCulture);

		internal static string minerrtosend => ResourceManager.GetString("minerrtosend", resourceCulture);

		internal static string minerrtosendnear => ResourceManager.GetString("minerrtosendnear", resourceCulture);

		internal static string modlist => ResourceManager.GetString("modlist", resourceCulture);

		internal static string mysql_credentials => ResourceManager.GetString("mysql_credentials", resourceCulture);

		internal static string mysql_host => ResourceManager.GetString("mysql_host", resourceCulture);

		internal static string name => ResourceManager.GetString("name", resourceCulture);

		internal static string password => ResourceManager.GetString("password", resourceCulture);

		internal static string passwordadmin => ResourceManager.GetString("passwordadmin", resourceCulture);

		internal static string passwordrcon => ResourceManager.GetString("passwordrcon", resourceCulture);

		internal static string port => ResourceManager.GetString("port", resourceCulture);

		internal static string position => ResourceManager.GetString("position", resourceCulture);

		internal static string reportingip => ResourceManager.GetString("reportingip", resourceCulture);

		internal static string requiresecureid => ResourceManager.GetString("requiresecureid", resourceCulture);

		internal static string sentence_backupinterval => ResourceManager.GetString("sentence_backupinterval", resourceCulture);

		internal static string sentence_chooselanguage => ResourceManager.GetString("sentence_chooselanguage", resourceCulture);

		internal static string sentence_menu1_description => ResourceManager.GetString("sentence_menu1_description", resourceCulture);

		internal static string sentence_menu2_description => ResourceManager.GetString("sentence_menu2_description", resourceCulture);

		internal static string sentence_menu3_description => ResourceManager.GetString("sentence_menu3_description", resourceCulture);

		internal static string sentence_menu4_description => ResourceManager.GetString("sentence_menu4_description", resourceCulture);

		internal static string sentence_message => ResourceManager.GetString("sentence_message", resourceCulture);

		internal static string sentence_reset => ResourceManager.GetString("sentence_reset", resourceCulture);

		internal static string sentence_selectinstance => ResourceManager.GetString("sentence_selectinstance", resourceCulture);

		internal static string servername => ResourceManager.GetString("servername", resourceCulture);

		internal static string tab1_page1 => ResourceManager.GetString("tab1_page1", resourceCulture);

		internal static string tab1_page2 => ResourceManager.GetString("tab1_page2", resourceCulture);

		internal static string tab1_page3 => ResourceManager.GetString("tab1_page3", resourceCulture);

		internal static string tab2_page1 => ResourceManager.GetString("tab2_page1", resourceCulture);

		internal static string tab2_page2 => ResourceManager.GetString("tab2_page2", resourceCulture);

		internal static string tab2_page3 => ResourceManager.GetString("tab2_page3", resourceCulture);

		internal static string tab3_page1 => ResourceManager.GetString("tab3_page1", resourceCulture);

		internal static string tab3_page2 => ResourceManager.GetString("tab3_page2", resourceCulture);

		internal static string tab3_page3 => ResourceManager.GetString("tab3_page3", resourceCulture);

		internal static string template => ResourceManager.GetString("template", resourceCulture);

		internal static string timezone => ResourceManager.GetString("timezone", resourceCulture);

		internal static string uid => ResourceManager.GetString("uid", resourceCulture);

		internal static string verifysignatures => ResourceManager.GetString("verifysignatures", resourceCulture);

		internal static string version => ResourceManager.GetString("version", resourceCulture);

		internal Resources()
		{
		}
	}
}
