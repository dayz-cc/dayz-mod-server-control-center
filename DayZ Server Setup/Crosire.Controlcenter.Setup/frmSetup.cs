using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using Crosire.Library;
using Microsoft.Win32;
using MySql.Data.MySqlClient;
using NLog;

namespace Crosire.Controlcenter.Setup {
    public class frmSetup : Form {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public int wizPos;

        public bool wizUpdate;

        public bool wizForce;

        public bool wizReconf;

        public bool wizFinished;

        public bool skipDownload;

        public bool skipExtraction;

        public bool skipCopy;

        public bool skipConfig;

        public bool skipDatabase;

        public bool skipSecurity;

        public bool skipBackup;

        public bool noWindow;

        public string dbHost = "127.0.0.1";

        public string dbPort = "3306";

        public string dbPass = "";

        public string dbUser = "root";

        public string downloadUrl = "";

        public int instances = 6;

        public static string pathArma = "";

        public static string pathMain = "";

        public static string pathTemp = Path.Combine(Path.GetTempPath(), "DayZ Server Setup");

        public static string pathThis = Application.StartupPath;

        public static string pathReadme = Path.Combine(pathThis, "Readme.txt");

        public static string pathPackages = Path.Combine(pathThis, "setup");

        public static string pathConfig = Path.Combine(pathThis, "DayZ Server Controlcenter.exe.config");

        private string url_dayzcc = "http://www.dayzcc.org";

        private IContainer components;

        internal TableLayoutPanel containerButtons;

        internal Button btnBack;

        internal Button btnCancel;

        internal Button btnNext;

        internal Label labelVersionDescription;

        internal Label labelVersion;

        private PictureBox pictureBanner;

        private BackgroundWorker workerMain;

        private BackgroundWorker workerReconfig;

        private WebClient downloader;

        private Label labelStep;

        private Label labelCopyright;

        private Label labelCompany;

        private Panel container1;

        internal Button btnBrowse;

        private TextBox textPath;

        private Label labelEnterPath;

        private RichTextBox textReadme;

        private Panel container2;

        internal GroupBox groupOptions;

        internal RadioButton radioReconfig;

        internal RadioButton radioInstall;

        internal CheckBox checkRedis;

        internal CheckBox checkBeta;

        internal GroupBox groupDatabase;

        private CheckBox checkOwn;

        private Label labelEnterDatabase;

        private Label labelHost;

        private TextBox textDatabase;

        private Label labelPass;

        private TextBox textUser;

        private Label labelUser;

        private TextBox textPort;

        private Label labelSeperator;

        private TextBox textHost;

        private TextBox textPass;

        private Panel container3;

        private RichTextBox textProgress;

        private ProgressBar progressbar;

        private Label lblMaintainer;

        internal Label lblDayzModDescription;

        internal Label lblDayZModVersion;

        public frmSetup() {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e) {
            wizPos--;
            subUpdateWizard();
        }

        private void btnBrowse_Click(object sender, EventArgs e) {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog()) {
                folderBrowserDialog.SelectedPath = pathArma;
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK) {
                    textPath.Text = folderBrowserDialog.SelectedPath;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) {
            base.DialogResult = DialogResult.Abort;
            Close();
        }

        private void btnNext_Click(object sender, EventArgs e) {
            if (wizFinished) {
                base.DialogResult = DialogResult.OK;
                Close();
            } else {
                wizPos++;
                subUpdateWizard();
            }
        }

        private void checkOwn_CheckedChanged(object sender, EventArgs e) {
            if (checkOwn.Checked) {
                labelHost.Visible = true;
                labelUser.Visible = true;
                labelPass.Visible = true;
                labelSeperator.Visible = true;
                textHost.Visible = true;
                textPort.Visible = true;
                textUser.Visible = true;
                textPass.Visible = true;
            } else {
                labelHost.Visible = false;
                labelUser.Visible = false;
                labelPass.Visible = false;
                labelSeperator.Visible = false;
                textHost.Visible = false;
                textPort.Visible = false;
                textUser.Visible = false;
                textPass.Visible = false;
            }
        }

        private void downloader_DownloadCompleted(object sender, AsyncCompletedEventArgs e) {
            if (e.Error == null) {
                subAppendProgress("> Download finished!", LogLevel.Info);
                workerMain.RunWorkerAsync();
            } else {
                subAppendProgress("> Error: Exception: " + e.Error.Message, LogLevel.Fatal);
                subFinished();
            }
        }

        private void downloader_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e) {
            progressbar.Value = e.ProgressPercentage;
        }

        private void frmSetup_Load(object sender, EventArgs e) {
            string[] commandLineArgs = Environment.GetCommandLineArgs();
            foreach (string text in commandLineArgs) {
                switch (text.ToLower()) {
                    case "-skipdownload":
                        skipDownload = true;
                        break;
                    case "-skipextraction":
                        skipExtraction = true;
                        break;
                    case "-skipcopy":
                        skipCopy = true;
                        break;
                    case "-skipdatabase":
                        skipDatabase = true;
                        break;
                    case "-skiprandompass":
                        skipSecurity = true;
                        break;
                    case "-skipconfig":
                        skipConfig = true;
                        break;
                    case "-skipbackup":
                        skipBackup = true;
                        break;
                    case "-nowindow":
                        noWindow = true;
                        break;
                    case "-fresh":
                        wizForce = true;
                        break;
                }
                if (text.StartsWith("-u")) {
                    dbUser = text.Remove(0, 2);
                } else if (text.StartsWith("-p")) {
                    dbPass = text.Remove(0, 2);
                } else if (text.StartsWith("-i")) {
                    instances = Convert.ToInt32(text.Remove(0, 2));
                }
            }
            RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey("SOFTWARE\\Bohemia Interactive Studio\\ArmA 2 OA");
            if (registryKey != null) {
                pathArma = registryKey.GetValue("MAIN").ToString();
                pathMain = Path.Combine(pathArma, "@dayzcc");
            } else {
                logger.Log(LogLevel.Fatal, "Application: Missing Working Directory");
                MessageBox.Show("Game directory could not be found. Make sure it is installed and you have run both Arma2 and Arma2 OA at least once!", "Missing Working Directory", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Close();
            }
            if (File.Exists(pathThis + "\\DayZ Server Controlcenter.exe")) {
                labelVersion.Text = IO.GetFileVersion(pathThis + "\\DayZ Server Controlcenter.exe");
            } else {
                labelVersion.Text = Resources.Localized.error;
            }
            if (!noWindow) {
                new frmLang().ShowDialog();
                if (!string.IsNullOrEmpty(frmLang.language)) {
                    try {
                        Thread.CurrentThread.CurrentUICulture = new CultureInfo(frmLang.language);
                    } catch {
                    }
                }
                if (Directory.Exists(pathPackages)) {
                    checkRedis.Enabled = true;
                    if (File.Exists(Path.Combine(pathArma, "expansion", "beta", "arma2oaserver.exe"))) {
                        checkBeta.Enabled = true;
                    } else {
                        checkBeta.Checked = true;
                        checkBeta.Enabled = false;
                    }
                } else {
                    checkRedis.Checked = false;
                    checkRedis.Enabled = false;
                    checkBeta.Checked = false;
                    checkBeta.Enabled = false;
                }
                textUser.Text = dbUser;
                textPass.Text = dbPass;
                if (Directory.Exists(pathMain)) {
                    wizUpdate = true;
                    wizPos = 1;
                    container1.Visible = false;
                    container2.Visible = true;
                    container3.Visible = false;
                    btnNext.Enabled = true;
                    checkRedis.Checked = false;
                    checkRedis.Enabled = false;
                    checkOwn.Enabled = false;
                    textUser.Text = "dayz";
                    textPass.Text = "dayz";
                } else {
                    wizUpdate = false;
                    wizPos = 0;
                    container1.Visible = true;
                    container2.Visible = false;
                    container3.Visible = false;
                    btnNext.Enabled = false;
                    radioReconfig.Enabled = false;
                    labelHost.Visible = false;
                    labelUser.Visible = false;
                    labelPass.Visible = false;
                    labelSeperator.Visible = false;
                    textHost.Visible = false;
                    textPort.Visible = false;
                    textUser.Visible = false;
                    textPass.Visible = false;
                    if (File.Exists(pathReadme)) {
                        textReadme.Text = File.ReadAllText(pathReadme);
                    }
                }
                if (string.IsNullOrEmpty(pathArma)) {
                    textPath.Text = "";
                    btnNext.Enabled = false;
                } else {
                    textPath.Text = pathArma;
                }
                btnBack.Enabled = false;
                subReloadResources();
            } else {
                base.WindowState = FormWindowState.Minimized;
                base.ShowInTaskbar = false;
                subStart();
            }
        }

        private void pictureBanner_Click(object sender, EventArgs e) {
            Process.Start(url_dayzcc);
        }

        private void pictureBanner_MouseHover(object sender, EventArgs e) {
            Cursor = Cursors.Hand;
        }

        private void pictureBanner_MouseLeave(object sender, EventArgs e) {
            Cursor = Cursors.Default;
        }

        private void subAppendProgress(string message, LogLevel level) {
            if (base.InvokeRequired) {
                Invoke((MethodInvoker)delegate {
                    subAppendProgress(message, level);
                });
                return;
            }
            RichTextBox richTextBox = textProgress;
            richTextBox.Text = richTextBox.Text + Environment.NewLine + message;
            textProgress.SelectionStart = textProgress.Text.Length;
            textProgress.ScrollToCaret();
            if (level != null) {
                string message2 = message.Replace(Environment.NewLine, string.Empty).Replace("> ", string.Empty);
                logger.Log(level, message2);
            }
        }

        private void subFinished() {
            if (!noWindow) {
                subSetProgress(100);
                subAppendProgress(Environment.NewLine + "The Setup just finished. Make sure no errors are in the log above before you continue!", null);
                subAppendProgress("Click on '" + Resources.Localized.button_finish + "' to exit the wizard.", null);
                wizFinished = true;
                btnNext.Enabled = true;
                btnNext.Text = Resources.Localized.button_finish;
            } else {
                base.DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void subReloadResources() {
            labelStep.Text = Resources.Localized.step_1;
            btnBack.Text = Resources.Localized.button_back;
            btnNext.Text = Resources.Localized.button_next;
            btnCancel.Text = Resources.Localized.button_cancel;
            btnBrowse.Text = Resources.Localized.button_browse;
            labelVersionDescription.Text = Resources.Localized.version;
            labelEnterDatabase.Text = Resources.Localized.sentence_enterdatabase;
            labelEnterPath.Text = Resources.Localized.sentence_enterpath;
            labelHost.Text = Resources.Localized.host;
            labelUser.Text = Resources.Localized.user;
            labelPass.Text = Resources.Localized.password;
            checkRedis.Text = Resources.Localized.sentence_installredis;
            checkBeta.Text = Resources.Localized.sentence_installpatch;
            checkOwn.Text = Resources.Localized.button_own;
            groupOptions.Text = Resources.Localized.group_options;
            groupDatabase.Text = Resources.Localized.group_database;
            radioReconfig.Text = Resources.Localized.button_reconfigurate;
            if (wizUpdate) {
                radioInstall.Text = Resources.Localized.button_update;
            } else {
                radioInstall.Text = Resources.Localized.button_fresh;
            }
        }

        private void subReloadSettings() {
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load(pathConfig);
            XmlElement xmlElement = xmlDocument.SelectSingleNode("/configuration/applicationSettings/Crosire.Controlcenter.Properties.Settings/setting[@name = 'updateFull']/value") as XmlElement;
            if (xmlElement != null) {
                downloadUrl = xmlElement.InnerText;
            }
            xmlElement = xmlDocument.SelectSingleNode("/configuration/applicationSettings/Crosire.Controlcenter.Properties.Settings/setting[@name = 'uiInstances']/value") as XmlElement;
            if (xmlElement != null) {
                instances = Convert.ToInt32(xmlElement.InnerText);
            }
        }

        private void subSetProgress(int progress) {
            if (base.InvokeRequired) {
                Invoke(new Action<int>(subSetProgress), progress);
            } else if (progress <= progressbar.Maximum && progress >= progressbar.Minimum) {
                progressbar.Value = progress;
            }
        }

        private void subStart() {
            logger.Log(LogLevel.Info, "Initializing DayZ Server Setup " + Application.ProductVersion);
            textProgress.Text = "Setup " + Application.ProductVersion + " for DayZ Server Controlcenter " + labelVersion.Text + " initialized.";
            if (radioReconfig.Checked) {
                wizReconf = true;
                wizUpdate = false;
            }
            if (!noWindow) {
                pathArma = textPath.Text;
            }
            if (!wizUpdate && !wizReconf) {
                try {
                    RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey("SOFTWARE\\Bohemia Interactive Studio\\ArmA 2 OA", true)?.SetValue("MAIN", pathArma);
                } catch (UnauthorizedAccessException) {
                    subAppendProgress("> Missing permissions to write path to registry!", LogLevel.Error);
                }
            }
            if ((checkOwn.Checked || wizUpdate || wizReconf) && !noWindow) {
                dbHost = textHost.Text;
                dbPort = textPort.Text;
                dbUser = textUser.Text;
                dbPass = textPass.Text;
            }
            if (!wizReconf) {
                if (!File.Exists(pathConfig)) {
                    subAppendProgress("> Error: Unable to find application configuration file!", LogLevel.Fatal);
                    subFinished();
                    return;
                }
                subReloadSettings();
                if (string.IsNullOrEmpty(downloadUrl)) {
                    subAppendProgress("> Error: Unable to retrieve download link!", LogLevel.Fatal);
                    subFinished();
                    return;
                }
            }
            string[] array = new string[4];
            if (!wizReconf) {
                if (!(labelVersion.Text != Resources.Localized.error) && !string.IsNullOrEmpty(labelVersion.Text)) {
                    subAppendProgress("> Error: Unable to retrieve correct application version!", LogLevel.Fatal);
                    subFinished();
                    return;
                }
                array = labelVersion.Text.Split('.');
            }
            Process process = new Process();
            if (checkBeta.Checked && File.Exists(pathPackages + "\\patch.exe") && !noWindow) {
                subAppendProgress(Environment.NewLine + "Installing beta patch ...", LogLevel.Info);
                if (Directory.Exists(pathArma + "\\expansion\\beta")) {
                    try {
                        Directory.Delete(pathArma + "\\expansion\\beta", true);
                        subAppendProgress("> Previous beta patch uninstalled!", LogLevel.Info);
                    } catch (Exception ex2) {
                        subAppendProgress("> Error: Exception: " + ex2.Message, LogLevel.Error);
                    }
                }
                process.StartInfo.FileName = pathPackages + "\\patch.exe";
                process.Start();
                process.WaitForExit();
                subAppendProgress("> Beta patch installed!", LogLevel.Info);
            }
            if (checkRedis.Checked && checkRedis.Enabled && !noWindow) {
                subAppendProgress(Environment.NewLine + "Installing redistributables ...", LogLevel.Info);
                string[] files = Directory.GetFiles(pathPackages);
                foreach (string text in files) {
                    if (!text.EndsWith("patch.exe") && text.EndsWith(".exe")) {
                        try {
                            process.StartInfo.FileName = text;
                            process.Start();
                            process.WaitForExit();
                        } catch (IOException ex3) {
                            subAppendProgress("> Installation Error: " + ex3.Message, LogLevel.Error);
                        }
                    }
                }
                subAppendProgress("> Redistributables installed!", LogLevel.Info);
            }
            if (wizReconf) {
                workerReconfig.RunWorkerAsync();
                return;
            }
            if (skipDownload) {
                workerMain.RunWorkerAsync();
                return;
            }
            subAppendProgress(Environment.NewLine + "Downloading files from download server ...", LogLevel.Info);
            subAppendProgress("> This can take some time because of the large file size!", null);
            subAppendProgress("> Waiting for response. Download started!", null);
            downloader.DownloadFileAsync(new Uri(string.Format(downloadUrl, array[0], array[1], array[2], array[3])), pathThis + "\\Serverfiles.tar.gz");
        }

        private void subUpdateWizard() {
            switch (wizPos) {
                case 0:
                    labelStep.Text = Resources.Localized.step_1;
                    btnBack.Enabled = false;
                    btnNext.Enabled = true;
                    container1.Visible = true;
                    container2.Visible = false;
                    container3.Visible = false;
                    break;
                case 1:
                    labelStep.Text = Resources.Localized.step_2;
                    btnBack.Enabled = true;
                    btnNext.Enabled = true;
                    container1.Visible = false;
                    container2.Visible = true;
                    container3.Visible = false;
                    break;
                case 2:
                    labelStep.Text = Resources.Localized.step_3;
                    btnBack.Enabled = false;
                    btnNext.Enabled = false;
                    container1.Visible = false;
                    container2.Visible = false;
                    container3.Visible = true;
                    subStart();
                    break;
            }
        }

        private void textPath_TextChanged(object sender, EventArgs e) {
            if (string.IsNullOrEmpty(textPath.Text)) {
                btnNext.Enabled = false;
            } else {
                btnNext.Enabled = true;
            }
        }

        private void textReadme_VScroll(object sender, EventArgs e) {
            if (Classes.Scrollinfo.CheckBottom(textReadme)) {
                btnNext.Enabled = true;
            }
        }

        private void threadreconfig_DoWork(object sender, DoWorkEventArgs e) {
            subAppendProgress(Environment.NewLine + "Reconfigurating files ...", LogLevel.Info);
            int num = 0;
            subSetProgress(num);
            if (File.Exists(Path.Combine(pathArma, "expansion", "beta", "arma2oaserver.exe"))) {
                for (int i = 1; i <= instances; i++) {
                    try {
                        File.Copy(Path.Combine(pathArma, "expansion", "beta", "arma2oaserver.exe"), Path.Combine(pathMain + "_config", i.ToString(), "arma2oaserver_" + i + ".exe"), true);
                    } catch (Exception ex) {
                        subAppendProgress("> Error while copying server executable for instance " + i + "!", LogLevel.Warn);
                        subAppendProgress("> Exception: " + ex.Message, LogLevel.Error);
                    }
                }
            } else {
                subAppendProgress("> Warning: The beta patch is not installed!", LogLevel.Warn);
            }
            num += 50;
            subSetProgress(num);
            Process process = new Process();
            process.StartInfo.FileName = pathMain + "\\install\\install.bat";
            process.StartInfo.WorkingDirectory = pathMain + "\\install";
            process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
            try {
                process.Start();
                process.WaitForExit(13000);
                subAppendProgress("> Finished!", LogLevel.Info);
                num += 45;
                subSetProgress(num);
            } catch (Exception ex2) {
                subAppendProgress("> Error while running the installation script!", LogLevel.Warn);
                subAppendProgress("> Exception: " + ex2.Message, LogLevel.Error);
            }
        }

        private void threadreconfig_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            subFinished();
        }

        private void threadworker_DoWork(object sender, DoWorkEventArgs e) {
            int num = 0;
            subSetProgress(num);
            if (!skipExtraction) {
                subAppendProgress(Environment.NewLine + "Extracting downloaded files ...", LogLevel.Info);
                try {
                    Compression.Extract(Path.Combine(pathThis, "Serverfiles.tar.gz"), pathTemp);
                    subAppendProgress("> Extracting finished!", LogLevel.Info);
                    num += 20;
                    subSetProgress(num);
                } catch (Exception ex) {
                    subAppendProgress("> Error while extracting!", LogLevel.Warn);
                    subAppendProgress("> Exception: " + ex.Message, LogLevel.Fatal);
                    workerMain.CancelAsync();
                }
            }
            if (!skipCopy) {
                if (wizUpdate && !wizForce && !skipBackup) {
                    subAppendProgress("> Creating backup ...", LogLevel.Info);
                    try {
                        if (!Directory.Exists(pathThis + "\\backup")) {
                            Directory.CreateDirectory(pathThis + "\\backup");
                        }
                        if (!Directory.Exists(pathThis + "\\backup\\@dayzcc")) {
                            Directory.CreateDirectory(pathThis + "\\backup\\@dayzcc");
                        }
                        if (!Directory.Exists(pathThis + "\\backup\\@dayzcc\\addons")) {
                            Directory.CreateDirectory(pathThis + "\\backup\\@dayzcc\\addons");
                        }
                        if (!Directory.Exists(pathThis + "\\backup\\mpmissions")) {
                            Directory.CreateDirectory(pathThis + "\\backup\\mpmissions");
                        }
                        if (Directory.Exists(pathArma + "\\@dayzcc_config")) {
                            IO.CopyFolder(pathArma + "\\@dayzcc_config", pathThis + "\\backup\\@dayzcc_config", true, true);
                        }
                        if (Directory.Exists(pathMain + "\\mysql\\data")) {
                            IO.CopyFolder(pathMain + "\\mysql\\data", pathThis + "\\backup\\@dayzcc\\mysql\\data", true, true);
                        }
                        if (Directory.Exists(pathArma + "\\MPMissions")) {
                            IO.CopyFolder(pathArma + "\\MPMissions", pathThis + "\\backup\\mpmissions", true, true);
                        }
                        if (File.Exists(pathMain + "\\addons\\dayz_server.pbo")) {
                            File.Copy(pathMain + "\\addons\\dayz_server.pbo", pathThis + "\\backup\\@dayzcc\\addons\\dayz_server.pbo", true);
                        }
                        if (File.Exists(pathMain + "\\addons\\dayz_server_config.hpp")) {
                            File.Copy(pathMain + "\\addons\\dayz_server_config.hpp", pathThis + "\\backup\\@dayzcc\\addons\\dayz_server_config.hpp", true);
                        }
                    } catch (Exception ex2) {
                        subAppendProgress("> Error while creating the backup!", LogLevel.Warn);
                        subAppendProgress("> Exception: " + ex2.Message, LogLevel.Error);
                    }
                }
                subAppendProgress("> Copying files to ArmA directory ...", LogLevel.Info);
                if (wizUpdate && !wizForce) {
                    try {
                        Directory.Delete(Path.Combine(pathTemp, "@dayzcc", "mysql", "data"), true);
                        for (int i = 1; i <= instances; i++) {
                            try {
                                File.Delete(Path.Combine(pathTemp, "@dayzcc_config", i.ToString(), "config.cfg"));
                                File.Delete(Path.Combine(pathTemp, "@dayzcc_config", i.ToString(), "basic.cfg"));
                                File.Delete(Path.Combine(pathTemp, "@dayzcc_config", i.ToString(), "settings.xml"));
                                File.Delete(Path.Combine(pathTemp, "@dayzcc_config", i.ToString(), "BattlEye", "BEServer.cfg"));
                                File.Delete(Path.Combine(pathTemp, "@dayzcc_config", i.ToString(), "BattlEye", "bans.txt"));
                                Directory.Delete(Path.Combine(pathTemp, "@dayzcc_config", i.ToString(), "Users"), true);
                            } catch (Exception ex3) {
                                subAppendProgress("> Error while preparing files for instance " + i + "!", LogLevel.Warn);
                                subAppendProgress("> Exception: " + ex3.Message, LogLevel.Error);
                            }
                        }
                    } catch (Exception ex4) {
                        subAppendProgress("> Error while preparing files!", LogLevel.Warn);
                        subAppendProgress("> Exception: " + ex4.Message, LogLevel.Fatal);
                        workerMain.CancelAsync();
                    }
                }
                if (wizForce) {
                    subAppendProgress("> Killing processes ...", LogLevel.Info);
                    try {
                        Process[] processes = Process.GetProcesses();
                        foreach (Process process in processes) {
                            if (process.ProcessName == "mysqld" || process.ProcessName == "httpd") {
                                process.Kill();
                            }
                        }
                    } catch (Exception ex5) {
                        subAppendProgress("> Error while killing the running proceses!", LogLevel.Warn);
                        subAppendProgress("> Exception: " + ex5.Message, LogLevel.Error);
                    }
                    Thread.Sleep(1000);
                }
                try {
                    IO.CopyFolder(pathTemp, pathArma, true, true);
                    num += 30;
                    subSetProgress(num);
                } catch (Exception ex6) {
                    subAppendProgress("> Unable to copy files to the correct destination!", LogLevel.Fatal);
                    subAppendProgress("> Exception: " + ex6.Message, LogLevel.Fatal);
                    workerMain.CancelAsync();
                }
                try {
                    Directory.Delete(pathTemp, true);
                    subAppendProgress("> Done!", null);
                    num += 2;
                    subSetProgress(num);
                } catch {
                    subAppendProgress("> Warning: Could not delete the temporary extraction folder!", LogLevel.Warn);
                }
                if (File.Exists(Path.Combine(pathArma, "expansion", "beta", "arma2oaserver.exe"))) {
                    for (int k = 1; k <= instances; k++) {
                        try {
                            File.Copy(Path.Combine(pathArma, "expansion", "beta", "arma2oaserver.exe"), Path.Combine(pathMain + "_config", k.ToString(), "arma2oaserver_" + k + ".exe"), true);
                        } catch (Exception ex7) {
                            subAppendProgress("> Error while copying executables for instance " + k + "!", LogLevel.Warn);
                            subAppendProgress("> Exception: " + ex7.Message, LogLevel.Error);
                        }
                    }
                } else {
                    subAppendProgress("> Error: The beta patch is not installed!", LogLevel.Error);
                }
                try {
                    Directory.Delete(Path.Combine(pathMain, "install", "setup"), true);
                } catch {
                    subAppendProgress("> Warning: Could not delete a temporary folder!", LogLevel.Warn);
                }
            }
            if (!skipConfig) {
                subAppendProgress(Environment.NewLine + "Configurating files ...", LogLevel.Info);
                subAppendProgress("> Administration rights are needed in order to add some firewall rules for proper working!", null);
                Process process2 = new Process();
                try {
                    XmlDocument xmlDocument = new XmlDocument();
                    xmlDocument.Load(pathConfig);
                    XmlElement xmlElement = xmlDocument.SelectSingleNode("/configuration/applicationSettings/Crosire.Controlcenter.Properties.Settings/setting[@name = 'uiInstances']/value") as XmlElement;
                    if (xmlElement != null) {
                        xmlElement.InnerText = instances.ToString();
                    }
                    xmlDocument.Save(pathConfig);
                } catch (Exception ex8) {
                    subAppendProgress("> Error while saving application config file!", LogLevel.Warn);
                    subAppendProgress("> Exception: " + ex8.Message, LogLevel.Error);
                }
                process2.StartInfo.FileName = pathMain + "\\install\\install.bat";
                process2.StartInfo.WorkingDirectory = pathMain + "\\install";
                process2.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                try {
                    process2.Start();
                    process2.WaitForExit(13000);
                } catch (Exception ex9) {
                    subAppendProgress("> Error while running installation script!", LogLevel.Warn);
                    subAppendProgress("> Exception: " + ex9.Message, LogLevel.Error);
                }
                process2.StartInfo.FileName = "cmd.exe";
                process2.StartInfo.Arguments = "/c \"netsh advfirewall firewall delete rule name=\"DayZ Server Controlcenter\" || netsh advfirewall firewall add rule name=\"DayZ Server Controlcenter\" dir=in action=allow profile=any localport=78 protocol=tcp\"";
                process2.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                if (Environment.OSVersion.Version.Major >= 6) {
                    process2.StartInfo.Verb = "runas";
                }
                try {
                    process2.Start();
                    process2.WaitForExit();
                } catch (Exception ex10) {
                    subAppendProgress("> Error while adding new rules to the firewall!", LogLevel.Warn);
                    subAppendProgress("> Exception: " + ex10.Message, LogLevel.Error);
                }
                subAppendProgress("> Finished!", LogLevel.Info);
                num += 8;
                subSetProgress(num);
            }
            if (!skipDatabase) {
                subAppendProgress(Environment.NewLine + "Installing database ...", LogLevel.Info);
                Process process3 = new Process();
                for (int l = 0; l <= 3; l++) {
                    if (!IO.GetProcessState("mysqld") && (dbHost == "127.0.0.1" || dbHost == "localhost" || dbHost.StartsWith("192.168") || dbHost.StartsWith("172.") || dbHost.StartsWith("10."))) {
                        try {
                            process3.StartInfo.FileName = pathMain + "\\mysql\\bin\\mysqld.exe";
                            process3.StartInfo.WorkingDirectory = pathMain + "\\mysql";
                            process3.StartInfo.Arguments = "--defaults-file=\"" + pathMain + "\\mysql\\bin\\my.ini\"";
                            process3.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                            process3.Start();
                            subAppendProgress("> Starting own MySQL server!", LogLevel.Info);
                        } catch (Exception ex11) {
                            subAppendProgress("> Error while starting MySQL!", LogLevel.Warn);
                            subAppendProgress("> Exception: " + ex11.Message, LogLevel.Fatal);
                            workerMain.CancelAsync();
                        }
                    } else {
                        subAppendProgress("> Found already running MySQL server!", LogLevel.Info);
                    }
                    Thread.Sleep(15000);
                    if (IO.GetProcessState("mysqld")) {
                        subAppendProgress("> MySQL is running.", LogLevel.Info);
                        num += 5;
                        subSetProgress(num);
                        break;
                    }
                    if (dbHost == "127.0.0.1" || dbHost == "localhost" || dbHost.StartsWith("192.168") || dbHost.StartsWith("172.") || dbHost.StartsWith("10.")) {
                        subAppendProgress("> Error: MySQL is not running!", LogLevel.Error);
                    } else {
                        subAppendProgress("> Using external MySQL server!", LogLevel.Info);
                    }
                }
                MySqlConnection mySqlConnection = new MySqlConnection($"server={dbHost};port={dbPort};user={dbUser};password={dbPass};");
                subAppendProgress("> Testing MySQL User details for user \"" + dbUser + "\" ...", LogLevel.Info);
                try {
                    mySqlConnection.Open();
                    subAppendProgress("> Success!", LogLevel.Info);
                } catch (MySqlException ex12) {
                    subAppendProgress("> Error: " + ex12.Message, LogLevel.Warn);
                } finally {
                    mySqlConnection.Close();
                }
                string[] array = textDatabase.Text.Replace(" ", "").Split(',');
                foreach (string text in array) {
                    try {
                        process3.StartInfo.FileName = pathMain + "\\install\\migrate.bat";
                        process3.StartInfo.WorkingDirectory = pathMain + "\\install";
                        process3.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                        process3.StartInfo.Arguments = text + " " + dbHost + " " + dbPort + " " + dbUser + " " + dbPass;
                        process3.Start();
                        process3.WaitForExit(30000);
                        if (process3.ExitCode == 0) {
                            subAppendProgress("> Updated database \"" + text + "\"!", LogLevel.Info);
                            continue;
                        }
                        subAppendProgress("> Error while updating the database \"" + text + "\"!", LogLevel.Warn);
                        subAppendProgress("> Exit Code: " + process3.ExitCode, LogLevel.Error);
                        switch (process3.ExitCode) {
                            case 1:
                                subAppendProgress("> Could not connect to MySQL server!", null);
                                break;
                            case 2:
                                subAppendProgress("> Database creation failed!", null);
                                break;
                        }
                    } catch (Exception ex13) {
                        subAppendProgress("> Error while updating the database \"" + text + "\"!", LogLevel.Warn);
                        subAppendProgress("> Exception: " + ex13.Message, LogLevel.Fatal);
                    }
                }
                num += 25;
                subSetProgress(num);
            }
            if (skipSecurity || !(dbPass == "")) {
                return;
            }
            string text2 = Crosire.Library.Text.RandomString(8);
            subAppendProgress(Environment.NewLine + "Changing password for user \"" + dbUser + "\" to \"" + text2 + "\"", LogLevel.Info);
            subAppendProgress("> Please note it down as you cannot login later otherwise!", null);
            MySqlConnection mySqlConnection2 = new MySqlConnection($"server={dbHost};port={dbPort};user={dbUser};password={dbPass};");
            try {
                mySqlConnection2.Open();
                MySqlCommand mySqlCommand = new MySqlCommand("SET PASSWORD = PASSWORD('?pass')", mySqlConnection2);
                mySqlCommand.Parameters.AddWithValue("?pass", text2);
                mySqlCommand.ExecuteNonQuery();
                subAppendProgress("> Successfully changed the password!", LogLevel.Info);
            } catch (Exception ex14) {
                subAppendProgress("> Error while changing the password!", LogLevel.Warn);
                subAppendProgress("> Exception: " + ex14.Message, LogLevel.Error);
            } finally {
                mySqlConnection2.Close();
            }
            num += 5;
            subSetProgress(num);
        }

        private void threadworker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            subFinished();
        }

        protected override void Dispose(bool disposing) {
            if (disposing && components != null) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Crosire.Controlcenter.Setup.frmSetup));
            this.containerButtons = new System.Windows.Forms.TableLayoutPanel();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.labelVersionDescription = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.pictureBanner = new System.Windows.Forms.PictureBox();
            this.workerMain = new System.ComponentModel.BackgroundWorker();
            this.workerReconfig = new System.ComponentModel.BackgroundWorker();
            this.downloader = new System.Net.WebClient();
            this.labelStep = new System.Windows.Forms.Label();
            this.labelCopyright = new System.Windows.Forms.Label();
            this.labelCompany = new System.Windows.Forms.Label();
            this.container1 = new System.Windows.Forms.Panel();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.textPath = new System.Windows.Forms.TextBox();
            this.labelEnterPath = new System.Windows.Forms.Label();
            this.textReadme = new System.Windows.Forms.RichTextBox();
            this.container2 = new System.Windows.Forms.Panel();
            this.groupOptions = new System.Windows.Forms.GroupBox();
            this.radioReconfig = new System.Windows.Forms.RadioButton();
            this.radioInstall = new System.Windows.Forms.RadioButton();
            this.checkRedis = new System.Windows.Forms.CheckBox();
            this.checkBeta = new System.Windows.Forms.CheckBox();
            this.groupDatabase = new System.Windows.Forms.GroupBox();
            this.checkOwn = new System.Windows.Forms.CheckBox();
            this.labelEnterDatabase = new System.Windows.Forms.Label();
            this.labelHost = new System.Windows.Forms.Label();
            this.textDatabase = new System.Windows.Forms.TextBox();
            this.labelPass = new System.Windows.Forms.Label();
            this.textUser = new System.Windows.Forms.TextBox();
            this.labelUser = new System.Windows.Forms.Label();
            this.textPort = new System.Windows.Forms.TextBox();
            this.labelSeperator = new System.Windows.Forms.Label();
            this.textHost = new System.Windows.Forms.TextBox();
            this.textPass = new System.Windows.Forms.TextBox();
            this.container3 = new System.Windows.Forms.Panel();
            this.textProgress = new System.Windows.Forms.RichTextBox();
            this.progressbar = new System.Windows.Forms.ProgressBar();
            this.lblMaintainer = new System.Windows.Forms.Label();
            this.lblDayzModDescription = new System.Windows.Forms.Label();
            this.lblDayZModVersion = new System.Windows.Forms.Label();
            this.containerButtons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)this.pictureBanner).BeginInit();
            this.container1.SuspendLayout();
            this.container2.SuspendLayout();
            this.groupOptions.SuspendLayout();
            this.groupDatabase.SuspendLayout();
            this.container3.SuspendLayout();
            base.SuspendLayout();
            this.containerButtons.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this.containerButtons.BackColor = System.Drawing.Color.Transparent;
            this.containerButtons.ColumnCount = 3;
            this.containerButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333f));
            this.containerButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333f));
            this.containerButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333f));
            this.containerButtons.Controls.Add(this.btnBack, 0, 0);
            this.containerButtons.Controls.Add(this.btnCancel, 2, 0);
            this.containerButtons.Controls.Add(this.btnNext, 1, 0);
            this.containerButtons.Location = new System.Drawing.Point(212, 431);
            this.containerButtons.Name = "containerButtons";
            this.containerButtons.RowCount = 1;
            this.containerButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
            this.containerButtons.Size = new System.Drawing.Size(270, 29);
            this.containerButtons.TabIndex = 1;
            this.btnBack.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.btnBack.BackColor = System.Drawing.SystemColors.Control;
            this.btnBack.Enabled = false;
            this.btnBack.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBack.Location = new System.Drawing.Point(3, 3);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(84, 23);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(btnBack_Click);
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.btnCancel.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCancel.Location = new System.Drawing.Point(183, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(btnCancel_Click);
            this.btnNext.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.btnNext.BackColor = System.Drawing.SystemColors.Control;
            this.btnNext.Enabled = false;
            this.btnNext.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnNext.Location = new System.Drawing.Point(93, 3);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(84, 23);
            this.btnNext.TabIndex = 0;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(btnNext_Click);
            this.labelVersionDescription.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.labelVersionDescription.AutoSize = true;
            this.labelVersionDescription.BackColor = System.Drawing.Color.Transparent;
            this.labelVersionDescription.ForeColor = System.Drawing.Color.Gray;
            this.labelVersionDescription.Location = new System.Drawing.Point(325, 91);
            this.labelVersionDescription.Name = "labelVersionDescription";
            this.labelVersionDescription.Size = new System.Drawing.Size(111, 13);
            this.labelVersionDescription.TabIndex = 4;
            this.labelVersionDescription.Text = "Controlcenter Version:";
            this.labelVersion.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.labelVersion.AutoSize = true;
            this.labelVersion.BackColor = System.Drawing.Color.Transparent;
            this.labelVersion.ForeColor = System.Drawing.Color.Gray;
            this.labelVersion.Location = new System.Drawing.Point(442, 91);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(40, 13);
            this.labelVersion.TabIndex = 4;
            this.labelVersion.Text = "0.0.0.0";
            this.pictureBanner.BackColor = System.Drawing.Color.Transparent;
            this.pictureBanner.Image = Resources.Images.banner;
            this.pictureBanner.Location = new System.Drawing.Point(10, 12);
            this.pictureBanner.Name = "pictureBanner";
            this.pictureBanner.Size = new System.Drawing.Size(472, 92);
            this.pictureBanner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBanner.TabIndex = 14;
            this.pictureBanner.TabStop = false;
            this.pictureBanner.Click += new System.EventHandler(pictureBanner_Click);
            this.pictureBanner.MouseLeave += new System.EventHandler(pictureBanner_MouseLeave);
            this.pictureBanner.MouseHover += new System.EventHandler(pictureBanner_MouseHover);
            this.workerMain.DoWork += new System.ComponentModel.DoWorkEventHandler(threadworker_DoWork);
            this.workerMain.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(threadworker_RunWorkerCompleted);
            this.workerReconfig.DoWork += new System.ComponentModel.DoWorkEventHandler(threadreconfig_DoWork);
            this.workerReconfig.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(threadreconfig_RunWorkerCompleted);
            this.downloader.BaseAddress = "";
            this.downloader.CachePolicy = null;
            this.downloader.Credentials = null;
            this.downloader.Encoding = Resources.Settings.downloader_Encoding;
            this.downloader.Headers = Resources.Settings.downloader_Headers;
            this.downloader.QueryString = Resources.Settings.downloader_QueryString;
            this.downloader.UseDefaultCredentials = false;
            this.downloader.DownloadFileCompleted += new System.ComponentModel.AsyncCompletedEventHandler(downloader_DownloadCompleted);
            this.downloader.DownloadProgressChanged += new System.Net.DownloadProgressChangedEventHandler(downloader_DownloadProgressChanged);
            this.labelStep.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelStep.BackColor = System.Drawing.Color.Transparent;
            this.labelStep.Font = new System.Drawing.Font("Microsoft Sans Serif", 18f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            this.labelStep.ForeColor = System.Drawing.Color.White;
            this.labelStep.Location = new System.Drawing.Point(10, 106);
            this.labelStep.Name = "labelStep";
            this.labelStep.Size = new System.Drawing.Size(472, 32);
            this.labelStep.TabIndex = 20;
            this.labelStep.Text = "DayZ Server Setup";
            this.labelStep.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelCopyright.BackColor = System.Drawing.Color.Transparent;
            this.labelCopyright.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.labelCopyright.ForeColor = System.Drawing.Color.Gray;
            this.labelCopyright.Location = new System.Drawing.Point(7, 470);
            this.labelCopyright.Name = "labelCopyright";
            this.labelCopyright.Size = new System.Drawing.Size(475, 15);
            this.labelCopyright.TabIndex = 21;
            this.labelCopyright.Text = "Copyright ©2012 - 2013 Crosire. All rights reserved.";
            this.labelCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelCompany.AutoSize = true;
            this.labelCompany.BackColor = System.Drawing.Color.Transparent;
            this.labelCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.labelCompany.ForeColor = System.Drawing.Color.White;
            this.labelCompany.Location = new System.Drawing.Point(7, 431);
            this.labelCompany.Name = "labelCompany";
            this.labelCompany.Size = new System.Drawing.Size(105, 15);
            this.labelCompany.TabIndex = 23;
            this.labelCompany.Text = "Written by: Crosire";
            this.container1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.container1.Controls.Add(this.btnBrowse);
            this.container1.Controls.Add(this.textPath);
            this.container1.Controls.Add(this.labelEnterPath);
            this.container1.Controls.Add(this.textReadme);
            this.container1.Location = new System.Drawing.Point(10, 141);
            this.container1.Name = "container1";
            this.container1.Size = new System.Drawing.Size(472, 284);
            this.container1.TabIndex = 25;
            this.btnBrowse.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            this.btnBrowse.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnBrowse.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBrowse.Location = new System.Drawing.Point(379, 251);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(84, 23);
            this.btnBrowse.TabIndex = 18;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.Click += new System.EventHandler(btnBrowse_Click);
            this.textPath.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.textPath.Location = new System.Drawing.Point(9, 253);
            this.textPath.Name = "textPath";
            this.textPath.Size = new System.Drawing.Size(364, 20);
            this.textPath.TabIndex = 17;
            this.textPath.TextChanged += new System.EventHandler(textPath_TextChanged);
            this.labelEnterPath.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.labelEnterPath.AutoSize = true;
            this.labelEnterPath.Location = new System.Drawing.Point(6, 234);
            this.labelEnterPath.Name = "labelEnterPath";
            this.labelEnterPath.Size = new System.Drawing.Size(208, 13);
            this.labelEnterPath.TabIndex = 16;
            this.labelEnterPath.Text = "Enter the full path to your ArmA installation:";
            this.textReadme.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.textReadme.Font = new System.Drawing.Font("Courier New", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.textReadme.Location = new System.Drawing.Point(9, 7);
            this.textReadme.Name = "textReadme";
            this.textReadme.ReadOnly = true;
            this.textReadme.Size = new System.Drawing.Size(454, 220);
            this.textReadme.TabIndex = 15;
            this.textReadme.Text = "";
            this.textReadme.WordWrap = false;
            this.textReadme.VScroll += new System.EventHandler(textReadme_VScroll);
            this.container2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.container2.Controls.Add(this.groupOptions);
            this.container2.Controls.Add(this.groupDatabase);
            this.container2.Location = new System.Drawing.Point(10, 141);
            this.container2.Name = "container2";
            this.container2.Size = new System.Drawing.Size(472, 284);
            this.container2.TabIndex = 24;
            this.container2.Visible = false;
            this.groupOptions.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.groupOptions.BackColor = System.Drawing.SystemColors.Control;
            this.groupOptions.Controls.Add(this.radioReconfig);
            this.groupOptions.Controls.Add(this.radioInstall);
            this.groupOptions.Controls.Add(this.checkRedis);
            this.groupOptions.Controls.Add(this.checkBeta);
            this.groupOptions.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupOptions.Location = new System.Drawing.Point(9, 7);
            this.groupOptions.Name = "groupOptions";
            this.groupOptions.Size = new System.Drawing.Size(454, 69);
            this.groupOptions.TabIndex = 2;
            this.groupOptions.TabStop = false;
            this.groupOptions.Text = "Installation Options";
            this.radioReconfig.AutoSize = true;
            this.radioReconfig.Location = new System.Drawing.Point(9, 45);
            this.radioReconfig.Name = "radioReconfig";
            this.radioReconfig.Size = new System.Drawing.Size(92, 17);
            this.radioReconfig.TabIndex = 1;
            this.radioReconfig.Text = "Reconfigurate";
            this.radioReconfig.UseVisualStyleBackColor = true;
            this.radioInstall.AutoSize = true;
            this.radioInstall.Checked = true;
            this.radioInstall.Location = new System.Drawing.Point(9, 22);
            this.radioInstall.Name = "radioInstall";
            this.radioInstall.Size = new System.Drawing.Size(51, 17);
            this.radioInstall.TabIndex = 0;
            this.radioInstall.TabStop = true;
            this.radioInstall.Text = "Fresh";
            this.radioInstall.UseVisualStyleBackColor = true;
            this.checkRedis.AutoSize = true;
            this.checkRedis.Checked = true;
            this.checkRedis.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkRedis.Location = new System.Drawing.Point(122, 46);
            this.checkRedis.Name = "checkRedis";
            this.checkRedis.Size = new System.Drawing.Size(167, 17);
            this.checkRedis.TabIndex = 2;
            this.checkRedis.Text = "Install required redistributables";
            this.checkRedis.UseVisualStyleBackColor = true;
            this.checkBeta.AutoSize = true;
            this.checkBeta.Checked = true;
            this.checkBeta.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBeta.Location = new System.Drawing.Point(122, 23);
            this.checkBeta.Name = "checkBeta";
            this.checkBeta.Size = new System.Drawing.Size(148, 17);
            this.checkBeta.TabIndex = 0;
            this.checkBeta.Text = "Install required beta patch";
            this.checkBeta.UseVisualStyleBackColor = true;
            this.groupDatabase.Controls.Add(this.checkOwn);
            this.groupDatabase.Controls.Add(this.labelEnterDatabase);
            this.groupDatabase.Controls.Add(this.labelHost);
            this.groupDatabase.Controls.Add(this.textDatabase);
            this.groupDatabase.Controls.Add(this.labelPass);
            this.groupDatabase.Controls.Add(this.textUser);
            this.groupDatabase.Controls.Add(this.labelUser);
            this.groupDatabase.Controls.Add(this.textPort);
            this.groupDatabase.Controls.Add(this.labelSeperator);
            this.groupDatabase.Controls.Add(this.textHost);
            this.groupDatabase.Controls.Add(this.textPass);
            this.groupDatabase.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupDatabase.Location = new System.Drawing.Point(9, 82);
            this.groupDatabase.Name = "groupDatabase";
            this.groupDatabase.Size = new System.Drawing.Size(454, 194);
            this.groupDatabase.TabIndex = 4;
            this.groupDatabase.TabStop = false;
            this.groupDatabase.Text = "Database Options";
            this.checkOwn.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.checkOwn.Appearance = System.Windows.Forms.Appearance.Button;
            this.checkOwn.Location = new System.Drawing.Point(9, 22);
            this.checkOwn.Name = "checkOwn";
            this.checkOwn.Size = new System.Drawing.Size(437, 24);
            this.checkOwn.TabIndex = 10;
            this.checkOwn.Text = "I want to use my own MySQL server";
            this.checkOwn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.checkOwn.UseVisualStyleBackColor = true;
            this.checkOwn.CheckedChanged += new System.EventHandler(checkOwn_CheckedChanged);
            this.labelEnterDatabase.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.labelEnterDatabase.Location = new System.Drawing.Point(6, 141);
            this.labelEnterDatabase.Name = "labelEnterDatabase";
            this.labelEnterDatabase.Size = new System.Drawing.Size(440, 21);
            this.labelEnterDatabase.TabIndex = 9;
            this.labelEnterDatabase.Text = "Enter a list of databases you wish to update below. You can use commas to seperate them:";
            this.labelHost.AutoSize = true;
            this.labelHost.Location = new System.Drawing.Point(6, 61);
            this.labelHost.Name = "labelHost";
            this.labelHost.Size = new System.Drawing.Size(32, 13);
            this.labelHost.TabIndex = 8;
            this.labelHost.Text = "Host:";
            this.textDatabase.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.textDatabase.Location = new System.Drawing.Point(9, 165);
            this.textDatabase.Name = "textDatabase";
            this.textDatabase.Size = new System.Drawing.Size(437, 20);
            this.textDatabase.TabIndex = 6;
            this.textDatabase.Text = "dayz_chernarus";
            this.labelPass.AutoSize = true;
            this.labelPass.Location = new System.Drawing.Point(6, 113);
            this.labelPass.Name = "labelPass";
            this.labelPass.Size = new System.Drawing.Size(56, 13);
            this.labelPass.TabIndex = 7;
            this.labelPass.Text = "Password:";
            this.textUser.Location = new System.Drawing.Point(68, 84);
            this.textUser.Name = "textUser";
            this.textUser.Size = new System.Drawing.Size(106, 20);
            this.textUser.TabIndex = 6;
            this.textUser.Text = "root";
            this.labelUser.AutoSize = true;
            this.labelUser.Location = new System.Drawing.Point(6, 87);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(32, 13);
            this.labelUser.TabIndex = 5;
            this.labelUser.Text = "User:";
            this.textPort.Location = new System.Drawing.Point(196, 58);
            this.textPort.Name = "textPort";
            this.textPort.Size = new System.Drawing.Size(51, 20);
            this.textPort.TabIndex = 4;
            this.textPort.Text = "3306";
            this.labelSeperator.AutoSize = true;
            this.labelSeperator.Location = new System.Drawing.Point(180, 61);
            this.labelSeperator.Name = "labelSeperator";
            this.labelSeperator.Size = new System.Drawing.Size(10, 13);
            this.labelSeperator.TabIndex = 3;
            this.labelSeperator.Text = ":";
            this.textHost.Location = new System.Drawing.Point(68, 58);
            this.textHost.Name = "textHost";
            this.textHost.Size = new System.Drawing.Size(106, 20);
            this.textHost.TabIndex = 2;
            this.textHost.Text = "127.0.0.1";
            this.textPass.Location = new System.Drawing.Point(68, 110);
            this.textPass.Name = "textPass";
            this.textPass.Size = new System.Drawing.Size(106, 20);
            this.textPass.TabIndex = 1;
            this.textPass.UseSystemPasswordChar = true;
            this.container3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.container3.Controls.Add(this.textProgress);
            this.container3.Controls.Add(this.progressbar);
            this.container3.Location = new System.Drawing.Point(10, 141);
            this.container3.Name = "container3";
            this.container3.Size = new System.Drawing.Size(472, 284);
            this.container3.TabIndex = 26;
            this.container3.Visible = false;
            this.textProgress.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.textProgress.Location = new System.Drawing.Point(9, 7);
            this.textProgress.Name = "textProgress";
            this.textProgress.ReadOnly = true;
            this.textProgress.Size = new System.Drawing.Size(454, 237);
            this.textProgress.TabIndex = 0;
            this.textProgress.Text = "";
            this.textProgress.WordWrap = false;
            this.progressbar.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.progressbar.Location = new System.Drawing.Point(9, 253);
            this.progressbar.Name = "progressbar";
            this.progressbar.Size = new System.Drawing.Size(454, 23);
            this.progressbar.TabIndex = 1;
            this.lblMaintainer.AutoSize = true;
            this.lblMaintainer.BackColor = System.Drawing.Color.Transparent;
            this.lblMaintainer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.lblMaintainer.ForeColor = System.Drawing.Color.White;
            this.lblMaintainer.Location = new System.Drawing.Point(7, 445);
            this.lblMaintainer.Name = "lblMaintainer";
            this.lblMaintainer.Size = new System.Drawing.Size(144, 15);
            this.lblMaintainer.TabIndex = 27;
            this.lblMaintainer.Text = "Maintained by: Squadron";
            this.lblDayzModDescription.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.lblDayzModDescription.AutoSize = true;
            this.lblDayzModDescription.BackColor = System.Drawing.Color.Transparent;
            this.lblDayzModDescription.ForeColor = System.Drawing.Color.Gray;
            this.lblDayzModDescription.Location = new System.Drawing.Point(7, 91);
            this.lblDayzModDescription.Name = "lblDayzModDescription";
            this.lblDayzModDescription.Size = new System.Drawing.Size(98, 13);
            this.lblDayzModDescription.TabIndex = 30;
            this.lblDayzModDescription.Text = "DayZ Mod Version:";
            this.lblDayZModVersion.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            this.lblDayZModVersion.AutoSize = true;
            this.lblDayZModVersion.BackColor = System.Drawing.Color.Transparent;
            this.lblDayZModVersion.ForeColor = System.Drawing.Color.Gray;
            this.lblDayZModVersion.Location = new System.Drawing.Point(111, 91);
            this.lblDayZModVersion.Name = "lblDayZModVersion";
            this.lblDayZModVersion.Size = new System.Drawing.Size(40, 13);
            this.lblDayZModVersion.TabIndex = 31;
            this.lblDayZModVersion.Text = "1.8.0.3";
            base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = Resources.Images.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            base.ClientSize = new System.Drawing.Size(492, 496);
            base.Controls.Add(this.lblDayzModDescription);
            base.Controls.Add(this.lblDayZModVersion);
            base.Controls.Add(this.lblMaintainer);
            base.Controls.Add(this.container2);
            base.Controls.Add(this.container3);
            base.Controls.Add(this.labelCopyright);
            base.Controls.Add(this.labelCompany);
            base.Controls.Add(this.labelStep);
            base.Controls.Add(this.containerButtons);
            base.Controls.Add(this.labelVersionDescription);
            base.Controls.Add(this.labelVersion);
            base.Controls.Add(this.pictureBanner);
            base.Controls.Add(this.container1);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            base.Icon = Resources.Images.appIcon;
            base.Name = "frmSetup";
            base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Set Up and Update Wizard";
            base.Load += new System.EventHandler(frmSetup_Load);
            this.containerButtons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)this.pictureBanner).EndInit();
            this.container1.ResumeLayout(false);
            this.container1.PerformLayout();
            this.container2.ResumeLayout(false);
            this.groupOptions.ResumeLayout(false);
            this.groupOptions.PerformLayout();
            this.groupDatabase.ResumeLayout(false);
            this.groupDatabase.PerformLayout();
            this.container3.ResumeLayout(false);
            base.ResumeLayout(false);
            base.PerformLayout();
        }
    }
}
