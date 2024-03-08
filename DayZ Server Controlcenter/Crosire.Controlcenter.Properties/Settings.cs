using System.CodeDom.Compiler;
using System.Configuration;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Crosire.Controlcenter.Properties {
    [CompilerGenerated]
    [GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "11.0.0.0")]
    internal sealed class Settings : ApplicationSettingsBase {
        private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());

        public static Settings Default => defaultInstance;

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("")]
        public string workingDir {
            get {
                return (string)this["workingDir"];
            }
            set {
                this["workingDir"] = value;
            }
        }

        [ApplicationScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("release")]
        public string updateChannel => (string)this["updateChannel"];

        [DebuggerNonUserCode]
        [DefaultSettingValue("ftp://mgc-portal.dyndns.org")]
        [ApplicationScopedSetting]
        public string updateUrl => (string)this["updateUrl"];

        [ApplicationScopedSetting]
        [DefaultSettingValue("DayZ_Server_Controlcenter_{0}-{1}-{2}-{3}")]
        [DebuggerNonUserCode]
        public string updateFolder => (string)this["updateFolder"];

        [ApplicationScopedSetting]
        [DefaultSettingValue("http://mgc-portal.dyndns.org/dayzcc/5.9.4.1.tar.gz")]
        [DebuggerNonUserCode]
        public string updateFull => (string)this["updateFull"];

        [UserScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("Normal")]
        public FormWindowState uiState {
            get {
                return (FormWindowState)this["uiState"];
            }
            set {
                this["uiState"] = value;
            }
        }

        [DebuggerNonUserCode]
        [DefaultSettingValue("en")]
        [UserScopedSetting]
        public string uiLanguage {
            get {
                return (string)this["uiLanguage"];
            }
            set {
                this["uiLanguage"] = value;
            }
        }

        [ApplicationScopedSetting]
        [DebuggerNonUserCode]
        [DefaultSettingValue("6")]
        public int uiInstances => (int)this["uiInstances"];

        [DebuggerNonUserCode]
        [DefaultSettingValue("http://127.0.0.1:78/dayz/index.php")]
        [ApplicationScopedSetting]
        public string uiUrlAdmin => (string)this["uiUrlAdmin"];

        [DefaultSettingValue("http://127.0.0.1:78/chive/index.php")]
        [DebuggerNonUserCode]
        [ApplicationScopedSetting]
        public string uiUrlDatabase => (string)this["uiUrlDatabase"];

        [DefaultSettingValue("http://www.dayzcc.org")]
        [ApplicationScopedSetting]
        [DebuggerNonUserCode]
        public string uiUrlHomepage => (string)this["uiUrlHomepage"];

        [DebuggerNonUserCode]
        [DefaultSettingValue("dayz.chernarus, dayz.lingor, dayz.utes, dayz.takistan, dayz.panthera2, dayz.fallujah, dayz.zargabad, dayz.namalsk, dayz.mbg_celle2, dayz.tavi, dayz.thirsk, dayz.oring, dayz.isladuala")]
        [ApplicationScopedSetting]
        public string confTemplates => (string)this["confTemplates"];

        [DebuggerNonUserCode]
        [DefaultSettingValue("[[\"Mk_48_DZ\",\"NVGoggles\",\"Binocular_Vector\",\"M9SD\",\"ItemGPS\",\"ItemToolbox\",\"ItemEtool\",\"ItemCompass\",\"ItemMatchbox\",\"FoodCanBakedBeans\",\"ItemKnife\",\"ItemMap\",\"ItemWatch\"],[[\"100Rnd_762x51_M240\",47],\"ItemPainkiller\",\"ItemBandage\",\"15Rnd_9x19_M9SD\",\"100Rnd_762x51_M240\",\"ItemBandage\",\"ItemBandage\",\"15Rnd_9x19_M9SD\",\"15Rnd_9x19_M9SD\",\"15Rnd_9x19_M9SD\",\"ItemMorphine\",\"PartWoodPile\"]]")]
        [ApplicationScopedSetting]
        public string cbxLoadoutItems => (string)this["cbxLoadoutItems"];
    }
}
