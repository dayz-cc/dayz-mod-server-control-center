using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using CefSharp.WinForms;
using Crosire.Controlcenter.Classes;
using Crosire.Controlcenter.Forms;
using Crosire.Controlcenter.Properties;
using Crosire.Library;
using MySql.Data.MySqlClient;
using NLog;

namespace Crosire.Controlcenter
{
	public class frmMain : Form
	{
		private WebView browserAdmin;

		private WebView browserDatabase;

		private bool _closing = false;

		private Thread threadmain;

		private Thread threadtimer;

		private Configuration configuration = new Configuration();

		internal static string pathArma = new Configuration().pathArma;

		internal static string pathApp = Path.GetDirectoryName(Application.ExecutablePath);

		internal static int appInstances = Settings.Default.uiInstances;

		internal static int serverInstance = 0;

		public static string[] listDbHost = new string[appInstances];

		public static int[] listDbPort = new int[appInstances];

		public static string[] listDbUser = new string[appInstances];

		public static string[] listDbPass = new string[appInstances];

		public static string[] listDbName = new string[appInstances];

		public static bool[] listAutoBackupEnabled = new bool[appInstances];

		public static int[] listAutoBackupProgress = new int[appInstances];

		public static int[] listAutoBackupInterval = new int[appInstances];

		public static string[] listAutoBackupPath = new string[appInstances];

		private static Logger logger = LogManager.GetCurrentClassLogger();

		private IContainer components = null;

		private System.Windows.Forms.Timer timerMonitor;

		private SplitContainer container1;

		private Panel container2_3;

		private Panel container2_1;

		private TabControl tab1;

		private TabPage tab1Page1;

		private TabPage tab1Page2;

		private TabPage tab1Page3;

		private Panel container2_2;

		private TabControl tab2;

		private TabPage tab3Page3;

		private GroupBox groupBackup;

		private Button btnBackup;

		private GroupBox groupRestore;

		private Button btnRestore;

		private TextBox textHostname;

		private Label labelServerName;

		private Label labelReportingIp;

		private GroupBox groupMessage;

		private NumericUpDown numMaxPlayers;

		private Label labelMaxPlayers;

		private ComboBox cbxReportingIp;

		private Label labelPort;

		private NumericUpDown numMessageInterval;

		private Label labelTimeBetweenMessage;

		private RichTextBox textMessage;

		private Label labelRequiredBuild;

		private GroupBox groupVon;

		private CheckBox checkVon;

		private CheckBox checkPersistent;

		private NumericUpDown numVonQuality;

		private Label labelCodecQuality;

		private TextBox textPasswordServer;

		private Label labelPassword;

		private TextBox textPasswordAdmin;

		private Label labelAdminPassword;

		private GroupBox groupBattleye;

		private CheckBox checkBattleye;

		private TextBox textPasswordRcon;

		private Label labelRconPassword;

		private NumericUpDown numMaxPing;

		private Label labelMaxPing;

		private GroupBox groupNetwork;

		private Label labelMaxSizeGuaranteed;

		private Label labelMaxMsgSent;

		private Label labelMaxSizeNonguaranteed;

		private Label labelMinErrtoSend;

		private Label labelMaxBandwidth;

		private Label labelMinBandwidth;

		private Label labelMinErrtoSendNear;

		private Label labelMaxBandwidthUnit;

		private Label labelMinBandwidthUnit;

		private Label labelMaxSizeNonguaranteedUnit;

		private Label labelMaxSizeGuaranteedUnit;

		private GroupBox groupAdditional;

		private Label labelMaxCustomSize;

		private Label labelMaxCustomSizeUnit;

		private NumericUpDown numMinErrorNear;

		private NumericUpDown numMinError;

		private NumericUpDown numMaxCustomsize;

		private NumericUpDown numMaxBandwidth;

		private NumericUpDown numMinBandwidth;

		private NumericUpDown numMaxMessages;

		private NumericUpDown numMaxSizeGuaranteed;

		private NumericUpDown numMaxSizeNonguaranteed;

		private TabPage tab2Page1;

		private ComboBox cbxDifficulty;

		private Label labelDifficulty;

		private ComboBox cbxTemplate;

		private Label labelTemplate;

		private TextBox textBackupPath;

		private Label labelPathBackupFolder;

		private Button btnBackupBrowse;

		private TabPage tab2Page3;

		private RichTextBox textLogRpt;

		private LinkLabel btnLogMonitor;

		private GroupBox groupSignatures;

		private NumericUpDown numVerifySignatures;

		private Label labelVerifySignatures;

		private GroupBox groupScripting;

		private TextBox textOnUnsigned;

		private TextBox textOnDifferent;

		private TextBox textOnHacked;

		private TextBox textOnUserDisconnected;

		private TextBox textOnUserConnected;

		private TextBox textDoubleId;

		private Label labelOnUnsignedData;

		private Label labelOnDifferentData;

		private Label labelOnHackedData;

		private Label labelOnUserDisconnected;

		private Label labelOnUserConnected;

		private Label labelDoubleId;

		private TextBox textRegularCheck;

		private Label labelRegularCheck;

		private GroupBox groupTemplate;

		private LinkLabel btnLogClear;

		private Panel container2_4;

		private GroupBox groupAbout;

		private Label labelVersionText;

		private PictureBox pictureIcon;

		private Label labelVersion;

		private Button btnSave3;

		private Button btnSave1;

		private Button btnSave2;

		private ComboBox cbxInstance;

		private Button btnExit;

		private RadioButton btnMenu4;

		private RadioButton btnMenu2;

		private RadioButton btnMenu3;

		private Label labelDescription2;

		private Label labelDescription3;

		private Label labelDescription1;

		private Label labelDescription4;

		private Label labelSelectInstance;

		private RadioButton btnMenu1;

		private TabControl tab3;

		private TabPage tab3Page1;

		private GroupBox groupTime;

		private Label textTimezone;

		private Label labelTimezone;

		private TrackBar trackTimezone;

		private TabPage tab3Page2;

		private CheckBox checkWhitelist;

		private GroupBox groupProfile;

		private GroupBox groupReset;

		private Button btnReset;

		private SplitContainer container2;

		private GroupBox groupSettings;

		private ComboBox cbxLanguage;

		private Label labelChooseLanguage;

		private CheckBox btnLog;

		private RichTextBox textLog;

		private Button btnPlayerAdd;

		private Label labelAppName;

		private ComboBox cbxDatabase;

		private Label labelSelectDatabase;

		private Label labelNoticeMessage;

		private Button btnRandomPass;

		private Label labelNoticeReset;

		private GroupBox groupAutoBackup;

		private Button btnAutoBackup;

		private NumericUpDown numBackupInterval;

		private Label labelEnterBackupInterval;

		private Button btnDatabase;

		private TextBox textModlist;

		private Label labelModlist;

		private MaskedTextBox textPort;

		private MaskedTextBox textBuild;

		private GroupBox groupWhitelist;

		private TextBox textWhitelistMessage;

		private Label labelWhitelistMessage;

		private CheckBox checkDaytime;

		private CheckBox checkRmod;

		private CheckBox checkDuplicate;

		private ComboBox cbxLoadout;

		private Label labelLoadout;

		private Button btnSave4;

		internal GroupBox groupSurvivor;

		private TextBox textMedical;

		private Label labelMedical;

		private TextBox textPosition;

		private Label labelPosition;

		private TextBox textBackpack;

		private Label labelBackpack;

		private TextBox textInventory;

		private Label labelInventory;

		internal TextBox textPlayerGuid;

		internal Label labelPlayerGuid;

		internal TextBox textPlayerUid;

		internal Label labelPlayerUid;

		internal TextBox textPlayerName;

		internal Label labelPlayerName;

		internal ProgressBar progressBackup;

		private TabPage tab2Page2;

		private GroupBox groupLogin;

		private Label labelMySqlCredentials;

		private TextBox textMysqlUser;

		private Button btnMysqlUser;

		private TextBox textMysqlPass;

		private Label labelMysqlPoint;

		private Label labelMySqlHost;

		private TextBox textMysqlPort;

		private TextBox textMysqlHost;

		private Button btnMysqlHost;

		private ListBox listPlayers;

		private CheckBox checkWhitelisted;

		private NumericUpDown numSecureId;

		private Label labelRequireSecureId;

		private TextBox textWelcomeMessage;

		private Label labelWelcomeMessage;

		private Label labelTime;

		private ComboBox cbxLoadoutBackpack;

		private Label labelLoadoutBackpack;

		private PictureBox pictureLicense;

		public frmMain()
		{
			InitializeComponent();
			Text = Application.ProductName + " " + Application.ProductVersion;
			labelVersion.Text = Application.ProductVersion;
			browserAdmin = new WebView();
			browserAdmin.Dock = DockStyle.Fill;
			browserAdmin.Address = Settings.Default.uiUrlAdmin;
			browserDatabase = new WebView();
			browserDatabase.Dock = DockStyle.Fill;
			browserDatabase.Address = Settings.Default.uiUrlDatabase;
			tab2Page1.Controls.Add(browserAdmin);
			tab3Page1.Controls.Add(browserDatabase);
			threadmain = new Thread(threadMain);
			threadtimer = new Thread(threadTimer);
		}

		private void threadMain()
		{
			while (true)
			{
				bool flag = true;
				if (base.IsHandleCreated && !base.IsDisposed && !_closing)
				{
					if (IO.GetProcessState("arma2oaserver_" + serverInstance))
					{
						BeginInvoke((MethodInvoker)delegate
						{
							btnMenu1.Enabled = false;
							btnLogClear.Enabled = false;
						});
					}
					else
					{
						BeginInvoke((MethodInvoker)delegate
						{
							btnMenu1.Enabled = true;
							btnLogClear.Enabled = true;
						});
					}
					if (File.Exists(Path.Combine(configuration.pathConfig, "arma2oaserver_" + serverInstance + ".rpt")))
					{
						BeginInvoke((MethodInvoker)delegate
						{
							btnLogMonitor.Enabled = true;
						});
					}
					else
					{
						BeginInvoke((MethodInvoker)delegate
						{
							btnLogMonitor.Enabled = false;
							btnLogClear.Enabled = false;
						});
					}
				}
				Thread.Sleep(250);
			}
		}

		private void threadTimer()
		{
			while (true)
			{
				bool flag = true;
				try
				{
					for (int i = 1; i <= appInstances; i++)
					{
						if (!listAutoBackupEnabled[i - 1])
						{
							continue;
						}
						listAutoBackupProgress[i - 1]++;
						if (listAutoBackupProgress[i - 1] != listAutoBackupInterval[i - 1] * 60)
						{
							continue;
						}
						try
						{
							if (!Directory.Exists(listAutoBackupPath[i - 1]))
							{
								Directory.CreateDirectory(listAutoBackupPath[i - 1]);
							}
							ProcessStartInfo processStartInfo = new ProcessStartInfo(Path.Combine(configuration.pathMain, "mysql", "bin", "mysqldump.exe"), "--host=" + listDbHost[i - 1] + " --user=" + listDbUser[i - 1] + " --password=" + listDbPass[i - 1] + " --port=" + listDbPort[i - 1] + " --routines --triggers --databases " + listDbName[i - 1] + " --result-file=\"" + Path.Combine(listAutoBackupPath[i - 1], DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "_" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "_" + listDbName[i - 1] + "_auto_backup.sql") + "\"");
							processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
							Process.Start(processStartInfo);
							subAppendLog("Backup: Dumped database [Database \"" + listDbName[i - 1] + "\"]", LogLevel.Info);
						}
						finally
						{
							listAutoBackupProgress[i - 1] = 0;
						}
					}
					if (progressBackup.IsHandleCreated && !progressBackup.IsDisposed && !_closing)
					{
						progressBackup.Invoke((MethodInvoker)delegate
						{
							if (listAutoBackupProgress[serverInstance - 1] <= progressBackup.Maximum)
							{
								progressBackup.Value = listAutoBackupProgress[serverInstance - 1];
							}
						});
					}
				}
				catch (Exception ex)
				{
					subAppendLog(ex);
				}
				Thread.Sleep(1000);
			}
		}

		private void threadBackup()
		{
			subAppendLog("Backup: Dumping database [Database \"" + configuration.dbName + "\"]", LogLevel.Info);
			if (!Directory.Exists(configuration.confAutoBackupPath))
			{
				Directory.CreateDirectory(configuration.confAutoBackupPath);
			}
			try
			{
				ProcessStartInfo processStartInfo = new ProcessStartInfo(Path.Combine(configuration.pathMain, "mysql", "bin", "mysqldump.exe"), "--host=" + configuration.dbHost + " --user=" + configuration.dbUser + " --password=" + configuration.dbPass + " --port=" + configuration.dbPort + " --routines --triggers --databases " + configuration.dbName + " --result-file=\"" + Path.Combine(configuration.confAutoBackupPath, DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "_" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "_" + configuration.dbName + "_backup.sql") + "\"");
				processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
				Process process = new Process();
				process.StartInfo = processStartInfo;
				process.Start();
				process.WaitForExit(15000);
				switch (process.ExitCode)
				{
				case 0:
					subAppendLog("Backup: Success!", LogLevel.Info);
					break;
				case 2:
					subAppendLog("Error: MySQL Connection Error, User " + configuration.dbUser + ", Password: " + configuration.dbPass, LogLevel.Error);
					break;
				default:
					subAppendLog("Error: MySQL Exit Code: " + process.ExitCode, LogLevel.Error);
					break;
				}
			}
			catch (Exception ex)
			{
				subAppendLog(ex);
			}
		}

		private void threadRestore(string path)
		{
			subAppendLog("Backup: Restoring database [Host " + configuration.dbHost + ":" + configuration.dbPort + "]", LogLevel.Info);
			try
			{
				ProcessStartInfo processStartInfo = new ProcessStartInfo("cmd.exe", "/c \"\"" + Path.Combine(configuration.pathMain, "mysql", "bin", "mysql.exe") + "\" --host=" + configuration.dbHost + " --user=" + configuration.dbUser + " --password=" + configuration.dbPass + " --port=" + configuration.dbPort + " < \"" + path + "\"\"");
				processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
				Process process = new Process();
				process.StartInfo = processStartInfo;
				process.Start();
				process.WaitForExit(15000);
				if (process.ExitCode == 0)
				{
					subAppendLog("Backup: Success!", LogLevel.Info);
					MessageBox.Show(Resources.message_finished_restore, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					return;
				}
				subAppendLog("Error: MySQL Exit Code " + process.ExitCode + ", User " + configuration.dbUser + ", Password: " + configuration.dbPass + ", File: \"" + path + "\"", LogLevel.Error);
				MessageBox.Show(Resources.message_error_restore + " MySQL Exit Code: " + process.ExitCode, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			catch (Exception ex)
			{
				subAppendLog(ex);
			}
		}

		private void threadDatabase(string name, bool reset = false)
		{
			if (string.IsNullOrEmpty(name))
			{
				return;
			}
			subAppendLog("Configuration: Creating database [Database \"" + name + "\"]", LogLevel.Info);
			try
			{
				ProcessStartInfo processStartInfo = new ProcessStartInfo(Path.Combine(configuration.pathMain, "install", "migrate.bat"), name + " " + configuration.dbHost + " " + configuration.dbPort + " " + configuration.dbUser + " " + configuration.dbPass);
				processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
				processStartInfo.WorkingDirectory = Path.Combine(configuration.pathMain, "install");
				Process process = new Process();
				process.StartInfo = processStartInfo;
				process.Start();
				process.WaitForExit(15000);
				if (process.ExitCode == 0)
				{
					subAppendLog("Configuration: Success!", LogLevel.Info);
					if (reset)
					{
						MessageBox.Show(Resources.message_finished_reset, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					}
					else
					{
						MessageBox.Show(Resources.message_finished_database, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					}
					return;
				}
				subAppendLog("Error: Exit Code: " + process.ExitCode + ", User: " + configuration.dbUser + ", Password: " + configuration.dbPass, LogLevel.Error);
				if (process.ExitCode == 1)
				{
					MessageBox.Show(Resources.message_error_database + " Connection failed", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
				else if (process.ExitCode == 2)
				{
					MessageBox.Show(Resources.message_error_database + " Missing permissions", string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
				else
				{
					MessageBox.Show(Resources.message_error_database + " Exit Code " + process.ExitCode, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
			catch (Exception ex)
			{
				subAppendLog(ex);
			}
		}

		private void timerMonitor_Tick(object sender, EventArgs e)
		{
			string input = IO.GetNewLines(Path.Combine(configuration.pathConfig, "arma2oaserver_" + serverInstance + ".rpt")).ToString();
			input = Regex.Replace(input, "([0-9\\s]{2}:[0-9]{2}:[0-9]{2})\\s\\\"Locality\\sEvent\\\"\\r\\n?", "", RegexOptions.IgnoreCase);
			input = Regex.Replace(input, "(([0-9\\s]{2}:[0-9]{2}:[0-9]{2})\\s)?Unrecognized.*?\\r\\n?", "", RegexOptions.IgnoreCase);
			input = Regex.Replace(input, "Updating\\sbase\\sclass\\s.*\\r\\n?", "", RegexOptions.IgnoreCase);
			textLogRpt.AppendText(input);
		}

		private void frmMain_Load(object sender, EventArgs e)
		{
			textLog.Text = string.Format(DateTime.Now.ToString() + " Application: Initializing {0} {1}", Application.ProductName, Application.ProductVersion);
			if (!string.IsNullOrEmpty(Settings.Default.uiLanguage))
			{
				try
				{
					Thread.CurrentThread.CurrentUICulture = new CultureInfo(Settings.Default.uiLanguage);
					cbxLanguage.SelectedItem = Settings.Default.uiLanguage.ToLower();
				}
				catch (Exception ex)
				{
					subAppendLog(ex);
				}
			}
			else
			{
				subAppendLog("Error: No valid language is saved!", LogLevel.Error);
			}
			string[] array = new string[appInstances];
			for (int i = 0; i < appInstances; i++)
			{
				array[i] = (i + 1).ToString();
			}
			cbxInstance.Items.Clear();
			cbxInstance.Items.AddRange(array);
			cbxTemplate.Items.Clear();
			cbxTemplate.Items.AddRange(Settings.Default.confTemplates.Replace(" ", "").Split(','));
			container2_1.Visible = false;
			container2_2.Visible = false;
			container2_4.Visible = false;
			DialogResult dialogResult = DialogResult.OK;
			if (!((IList<string>)Environment.GetCommandLineArgs()).Contains("-skipsplash"))
			{
				dialogResult = new frmSplash().ShowDialog();
			}
			if (dialogResult != DialogResult.OK)
			{
				subAppendLog("Application: Aborted", LogLevel.Info);
				Close();
				return;
			}
			cbxInstance.SelectedIndex = 0;
			base.WindowState = Settings.Default.uiState;
			subAppendLog("Application: Restored window state [" + base.WindowState.ToString() + "]", LogLevel.Info);
			if (!((IList<string>)Environment.GetCommandLineArgs()).Contains("-skipwhitelist"))
			{
				frmLog frmLog = new frmLog();
				frmLog.Owner = this;
				frmLog.Location = new Point(base.Right, base.Top);
				frmLog.Size = new Size(frmLog.Width, base.Height);
				frmLog.Show();
			}
			threadmain.IsBackground = true;
			threadmain.Start();
			threadtimer.IsBackground = true;
			threadtimer.Start();
		}

		private void frmMain_Shown(object sender, EventArgs e)
		{
			browserAdmin.Load(Settings.Default.uiUrlAdmin);
			browserDatabase.Load(Settings.Default.uiUrlDatabase);
		}

		private void frmMain_Move(object sender, EventArgs e)
		{
			frmLog frmLog = (frmLog)Application.OpenForms["frmLog"];
			if (frmLog != null)
			{
				frmLog.Size = new Size(frmLog.Width, base.Height);
				frmLog.Location = new Point(base.Right, base.Top);
			}
		}

		private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			_closing = true;
			if (timerMonitor.Enabled)
			{
				timerMonitor.Stop();
			}
			Settings.Default.uiState = base.WindowState;
			Settings.Default.Save();
		}

		private void frmMain_ChangePanel(object sender, EventArgs e)
		{
			if (btnMenu1.Checked)
			{
				subReloadPanel1();
			}
			else if (btnMenu2.Checked)
			{
				subReloadPanel2();
			}
			else if (btnMenu3.Checked)
			{
				subReloadPanel3();
			}
			else if (btnMenu4.Checked)
			{
				container2_1.Visible = false;
				container2_3.Visible = false;
				container2_2.Visible = false;
				container2_4.Visible = true;
			}
		}

		private void frmMain_ChangeInstance(object sender, EventArgs e)
		{
			if (serverInstance != cbxInstance.SelectedIndex + 1)
			{
				if (serverInstance > 0)
				{
					subAppendLog("Application: Switching instance [Instance " + (cbxInstance.SelectedIndex + 1) + "]", LogLevel.Info);
				}
				serverInstance = cbxInstance.SelectedIndex + 1;
				this.configuration = new Configuration(serverInstance);
				this.configuration.LoadBasicConfig();
				this.configuration.LoadCfgConfig();
				this.configuration.LoadHiveConfig();
				this.configuration.LoadXmlConfig();
				this.configuration.LoadBattleyeConfig();
				for (int i = 1; i <= appInstances; i++)
				{
					Configuration configuration = new Configuration(i);
					try
					{
						if (File.Exists(configuration.pathConfigXml))
						{
							configuration.LoadXmlConfig();
							listAutoBackupEnabled[i - 1] = configuration.confAutoBackupEnabled;
							listAutoBackupInterval[i - 1] = configuration.confAutoBackupInterval;
							listAutoBackupPath[i - 1] = configuration.confAutoBackupPath;
						}
						if (File.Exists(configuration.pathConfigHive))
						{
							configuration.LoadHiveConfig();
							listDbHost[i - 1] = configuration.dbHost;
							listDbPort[i - 1] = configuration.dbPort;
							listDbUser[i - 1] = configuration.dbUser;
							listDbPass[i - 1] = configuration.dbPass;
							listDbName[i - 1] = configuration.dbName;
						}
					}
					catch (Exception ex)
					{
						subAppendLog(ex);
					}
				}
				mysql.Close();
				mysql.Connection = new MySqlConnection($"server={this.configuration.dbHost};port={this.configuration.dbPort.ToString()};user={this.configuration.dbUser};password={this.configuration.dbPass};");
				this.configuration.confInstance = serverInstance;
				this.configuration.confWorld = Regex.Replace(this.configuration.confTemplate, "[a-z]{4}_[0-9]{1}.", "");
				this.configuration.confWorldId = this.configuration.GetWorldId();
				this.configuration.WriteXmlConfig();
			}
			if (timerMonitor.Enabled)
			{
				timerMonitor.Stop();
			}
			textLogRpt.Clear();
			subReloadPanel2();
			subReloadResources();
		}

		private void subAppendLog(string message, LogLevel level)
		{
			if (base.IsHandleCreated && !base.IsDisposed && !textLog.IsDisposed && !_closing)
			{
				if (base.InvokeRequired)
				{
					Invoke((MethodInvoker)delegate
					{
						subAppendLog(message, level);
					});
					return;
				}
				RichTextBox richTextBox = textLog;
				string text = richTextBox.Text;
				richTextBox.Text = text + Environment.NewLine + DateTime.Now.ToString() + " " + message;
			}
			logger.Log(level, message);
		}

		private void subAppendLog(Exception ex)
		{
			if (base.IsHandleCreated && !base.IsDisposed && !textLog.IsDisposed && !_closing)
			{
				if (base.InvokeRequired)
				{
					Invoke((MethodInvoker)delegate
					{
						subAppendLog(ex);
					});
					return;
				}
				RichTextBox richTextBox = textLog;
				string text = richTextBox.Text;
				richTextBox.Text = text + Environment.NewLine + DateTime.Now.ToString() + " Error: Exception: " + ex.Message;
			}
			if (ex.InnerException != null)
			{
				logger.Log(LogLevel.Fatal, ex.InnerException.ToString() + " [" + ex.Message + "]");
			}
			else
			{
				logger.Log(LogLevel.Fatal, ex.ToString() + "[" + ex.Message + "]");
			}
			if (ex.StackTrace != null)
			{
				logger.Log(LogLevel.Trace, ex.StackTrace);
			}
		}

		private void subReloadPanel1()
		{
			btnMenu1.Checked = true;
			btnMenu2.Checked = false;
			btnMenu3.Checked = false;
			btnMenu4.Checked = false;
			container2_1.Visible = true;
			container2_2.Visible = false;
			container2_3.Visible = false;
			container2_4.Visible = false;
			btnSave1.Enabled = true;
			btnSave2.Enabled = true;
			btnSave3.Enabled = true;
			cbxDatabase.Enabled = true;
			cbxDatabase.Items.Clear();
			if (Directory.Exists(configuration.pathConfig))
			{
				try
				{
					if (File.Exists(configuration.pathConfigCfg))
					{
						configuration.LoadCfgConfig();
						textHostname.Enabled = true;
						textBuild.Enabled = true;
						textMessage.Enabled = true;
						textRegularCheck.Enabled = true;
						textOnUserConnected.Enabled = true;
						textOnUserDisconnected.Enabled = true;
						textOnUnsigned.Enabled = true;
						textOnHacked.Enabled = true;
						textOnDifferent.Enabled = true;
						textDoubleId.Enabled = true;
						textPasswordServer.Enabled = true;
						textPasswordAdmin.Enabled = true;
						numMaxPlayers.Enabled = true;
						numMessageInterval.Enabled = true;
						numVonQuality.Enabled = true;
						numVerifySignatures.Enabled = true;
						numSecureId.Enabled = true;
						cbxReportingIp.Enabled = true;
						cbxDifficulty.Enabled = true;
						checkPersistent.Enabled = true;
						checkDuplicate.Enabled = true;
						checkRmod.Enabled = true;
						checkBattleye.Enabled = true;
						checkVon.Enabled = true;
						cbxTemplate.Enabled = true;
						textHostname.Text = configuration.confHostname;
						textBuild.Text = configuration.confRequiredBuild.ToString();
						textMessage.Text = configuration.confMotd;
						textRegularCheck.Text = configuration.confRegularCheck;
						textOnUserConnected.Text = configuration.confOnUserConnected;
						textOnUserDisconnected.Text = configuration.confOnUserDisconnected;
						textOnUnsigned.Text = configuration.confOnUnsignedData;
						textOnHacked.Text = configuration.confOnHackedData;
						textOnDifferent.Text = configuration.confOnDifferentData;
						textDoubleId.Text = configuration.confDoubleIdDetected;
						textPasswordServer.Text = configuration.confPasswordServer;
						textPasswordAdmin.Text = configuration.confPasswordAdmin;
						numMaxPlayers.Value = configuration.confMaxPlayers;
						numMessageInterval.Value = configuration.confMotdInterval;
						numVonQuality.Value = configuration.confVonQuality;
						numVerifySignatures.Value = configuration.confVerifySignatures;
						numSecureId.Value = configuration.confSecureId;
						cbxDifficulty.SelectedItem = configuration.confDifficulty;
						checkPersistent.Checked = configuration.confPersistent;
						checkDuplicate.Checked = configuration.confKickDuplicate;
						checkRmod.Checked = configuration.confRmod;
						checkVon.Checked = configuration.confVon;
						checkBattleye.Checked = configuration.confBattleye;
						if (cbxReportingIp.Items.Contains(configuration.confReportingIp))
						{
							cbxReportingIp.SelectedItem = configuration.confReportingIp;
						}
						else
						{
							cbxReportingIp.Text = configuration.confReportingIp;
						}
						if (cbxTemplate.Items.Contains(configuration.confTemplate.Replace("rmod", "dayz").Remove(4, 2)))
						{
							cbxTemplate.SelectedItem = configuration.confTemplate.Replace("rmod", "dayz").Remove(4, 2);
						}
						else
						{
							subAppendLog("Warning: Mission Template does not match any preset", LogLevel.Warn);
							cbxTemplate.SelectedItem = "dayz.chernarus";
						}
					}
					else
					{
						subAppendLog("Error: File not found: \"" + configuration.pathConfigCfg + "\"", LogLevel.Error);
						textHostname.Enabled = false;
						textBuild.Enabled = false;
						textMessage.Enabled = false;
						textRegularCheck.Enabled = false;
						textOnUserConnected.Enabled = false;
						textOnUserDisconnected.Enabled = false;
						textOnUnsigned.Enabled = false;
						textOnHacked.Enabled = false;
						textOnDifferent.Enabled = false;
						textDoubleId.Enabled = false;
						textPasswordServer.Enabled = false;
						textPasswordAdmin.Enabled = false;
						numMaxPlayers.Enabled = false;
						numMessageInterval.Enabled = false;
						numVonQuality.Enabled = false;
						numSecureId.Enabled = false;
						numVerifySignatures.Enabled = false;
						cbxReportingIp.Enabled = false;
						cbxDifficulty.Enabled = false;
						checkPersistent.Enabled = false;
						checkDuplicate.Enabled = false;
						checkRmod.Enabled = false;
						checkBattleye.Enabled = false;
						checkVon.Enabled = false;
						cbxTemplate.Enabled = false;
					}
					if (File.Exists(configuration.pathConfigXml))
					{
						configuration.LoadXmlConfig();
						textWhitelistMessage.Enabled = true;
						textModlist.Enabled = true;
						textPort.Enabled = true;
						textWelcomeMessage.Enabled = true;
						if (checkBattleye.Checked)
						{
							checkWhitelist.Enabled = true;
							checkWhitelist.Checked = configuration.beWhitelistEnabled;
						}
						else
						{
							checkWhitelist.Enabled = false;
							checkWhitelist.Checked = false;
						}
						textWhitelistMessage.Text = configuration.beWhitelistMessage;
						textWelcomeMessage.Text = configuration.confWelcome;
						textModlist.Text = configuration.confModlist;
						textPort.Text = configuration.bePort.ToString();
					}
					else
					{
						subAppendLog("Error: File not found: \"" + configuration.pathConfigXml + "\"", LogLevel.Error);
						checkWhitelist.Enabled = false;
						textWhitelistMessage.Enabled = false;
						textWelcomeMessage.Enabled = false;
						textModlist.Enabled = false;
						textPort.Enabled = false;
					}
					if (File.Exists(configuration.CheckBattleyeConfig(configuration.pathConfigBattleye)))
					{
						configuration.LoadBattleyeConfig();
						textPasswordRcon.Enabled = true;
						numMaxPing.Enabled = true;
						textPasswordRcon.Text = configuration.bePass;
						numMaxPing.Value = configuration.beMaxPing;
					}
					else
					{
						subAppendLog("Warning: File not found: \"" + configuration.pathConfigBattleye + "\"", LogLevel.Warn);
						textPasswordRcon.Enabled = false;
						numMaxPing.Enabled = false;
					}
					if (File.Exists(configuration.pathConfigBasic))
					{
						configuration.LoadBasicConfig();
						numMinBandwidth.Enabled = true;
						numMaxBandwidth.Enabled = true;
						numMaxMessages.Enabled = true;
						numMaxSizeGuaranteed.Enabled = true;
						numMaxSizeNonguaranteed.Enabled = true;
						numMinError.Enabled = true;
						numMinErrorNear.Enabled = true;
						numMaxCustomsize.Enabled = true;
						numMinBandwidth.Value = configuration.confMinBandwidth;
						numMaxBandwidth.Value = configuration.confMaxBandwidth;
						numMaxMessages.Value = configuration.confMaxMsgSend;
						numMaxSizeGuaranteed.Value = configuration.confMaxSizeGuaranteed;
						numMaxSizeNonguaranteed.Value = configuration.confMaxSizeNonguaranteed;
						numMinError.Value = configuration.confMinErrorToSend;
						numMinErrorNear.Value = configuration.confMinErrorToSendNear;
						numMaxCustomsize.Value = configuration.confMaxCustomFileSize;
					}
					else
					{
						subAppendLog("Error: File not found: \"" + configuration.pathConfigBasic + "\"", LogLevel.Error);
						numMinBandwidth.Enabled = false;
						numMaxBandwidth.Enabled = false;
						numMaxMessages.Enabled = false;
						numMaxSizeGuaranteed.Enabled = false;
						numMaxSizeNonguaranteed.Enabled = false;
						numMinError.Enabled = false;
						numMinErrorNear.Enabled = false;
						numMaxCustomsize.Enabled = false;
					}
					if (File.Exists(configuration.pathConfigHive))
					{
						configuration.LoadHiveConfig();
						trackTimezone.Enabled = true;
						checkDaytime.Enabled = true;
						checkDaytime.Checked = configuration.confDaytime;
						int num = Convert.ToInt32(TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now).TotalHours) + configuration.confTimezone;
						if (num < 0)
						{
							textTimezone.Text = "UTC " + num;
							if (num < -12)
							{
								trackTimezone.Value = -12;
								subAppendLog("Warning: Timezone Value is too small (\"" + num + "\")!", LogLevel.Warn);
							}
							else
							{
								trackTimezone.Value = num;
							}
						}
						else
						{
							textTimezone.Text = "UTC +" + num;
							if (num > 12)
							{
								trackTimezone.Value = 12;
								subAppendLog("Warning: Timezone Value is too big (\"" + num + "\")!", LogLevel.Warn);
							}
							else
							{
								trackTimezone.Value = num;
							}
						}
						if (!configuration.confDaytime)
						{
							int num2 = DateTime.Now.ToUniversalTime().Hour + trackTimezone.Value;
							if (num2 > 23)
							{
								num2 -= 24;
							}
							labelTime.Text = num2.ToString("D2") + ":" + DateTime.Now.ToUniversalTime().Minute.ToString("D2");
						}
						else
						{
							labelTime.Text = configuration.confStaticHour.ToString("D2") + ":00";
						}
					}
					else
					{
						subAppendLog("Error: File not found: \"" + configuration.pathConfigHive + "\"", LogLevel.Error);
						trackTimezone.Enabled = false;
						checkDaytime.Enabled = false;
					}
				}
				catch (Exception ex)
				{
					subAppendLog(ex);
					btnSave1.Enabled = false;
					btnSave2.Enabled = false;
					btnSave3.Enabled = false;
				}
				try
				{
					mysql.Open();
					mysql.ChangeDatabase(configuration.dbName);
					MySqlCommand mySqlCommand = new MySqlCommand("SELECT `inventory`, `backpack` FROM `instance` WHERE `id` = ?instance", mysql.Connection);
					mySqlCommand.Parameters.AddWithValue("?instance", serverInstance);
					MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
					mySqlDataReader.Read();
					if (mySqlDataReader.HasRows)
					{
						cbxLoadout.Text = mySqlDataReader.GetString("inventory");
						cbxLoadoutBackpack.Text = mySqlDataReader.GetString("backpack");
					}
					mySqlDataReader.Close();
					List<string> list = new List<string>();
					mySqlDataReader = new MySqlCommand("SHOW DATABASES", mysql.Connection).ExecuteReader();
					while (mySqlDataReader.Read())
					{
						list.Add(mySqlDataReader["Database"].ToString());
					}
					mySqlDataReader.Close();
					foreach (string item in list)
					{
						mySqlDataReader = new MySqlCommand($"SHOW TABLES FROM `{item}`", mysql.Connection).ExecuteReader();
						while (mySqlDataReader.Read())
						{
							if (mySqlDataReader["tables_in_" + item].ToString() == "instance")
							{
								cbxDatabase.Items.Add(item);
							}
						}
						mySqlDataReader.Close();
					}
					cbxDatabase.Text = configuration.dbName;
				}
				catch (MySqlException ex2)
				{
					subAppendLog("Error: MySQL Exception: " + ex2.Message, LogLevel.Error);
				}
				catch (Exception ex)
				{
					subAppendLog(ex);
				}
				finally
				{
					mysql.Close();
				}
				tab1.SelectTab(0);
			}
			else
			{
				subAppendLog("Error: Directory not found: \"" + configuration.pathConfig + "\"", LogLevel.Fatal);
				subReloadPanel2();
			}
		}

		private void subReloadPanel2()
		{
			btnMenu1.Checked = false;
			btnMenu2.Checked = true;
			btnMenu3.Checked = false;
			btnMenu4.Checked = false;
			container2_1.Visible = false;
			container2_2.Visible = true;
			container2_3.Visible = false;
			container2_4.Visible = false;
			if (string.IsNullOrEmpty(configuration.dbHost) || string.IsNullOrEmpty(configuration.dbPort.ToString()) || string.IsNullOrEmpty(configuration.dbUser))
			{
				groupLogin.Enabled = false;
			}
			else
			{
				groupLogin.Enabled = true;
				textMysqlHost.Text = configuration.dbHost;
				textMysqlPort.Text = configuration.dbPort.ToString();
				textMysqlUser.Text = configuration.dbUser;
				textMysqlPass.Text = configuration.dbPass;
			}
			browserAdmin.Load(Settings.Default.uiUrlAdmin + "?instance=" + serverInstance);
			tab2.SelectTab(0);
		}

		private void subReloadPanel3()
		{
			btnMenu1.Checked = false;
			btnMenu2.Checked = false;
			btnMenu3.Checked = true;
			btnMenu4.Checked = false;
			container2_1.Visible = false;
			container2_2.Visible = false;
			container2_3.Visible = true;
			container2_4.Visible = false;
			btnSave4.Enabled = true;
			checkWhitelisted.Checked = false;
			textPlayerName.Clear();
			textPlayerUid.Clear();
			textPlayerUid.Enabled = false;
			textPlayerGuid.Clear();
			textInventory.Clear();
			textBackpack.Clear();
			textMedical.Clear();
			textPosition.Clear();
			groupSurvivor.Enabled = false;
			listPlayers.Items.Clear();
			textBackupPath.Text = configuration.confAutoBackupPath;
			numBackupInterval.Value = configuration.confAutoBackupInterval;
			if (listAutoBackupEnabled[serverInstance - 1])
			{
				btnAutoBackup.Text = Resources.button_autobackup_stop;
			}
			else
			{
				btnAutoBackup.Text = Resources.button_autobackup_start;
			}
			try
			{
				try
				{
					listPlayers.Enabled = true;
					btnPlayerAdd.Enabled = true;
					checkWhitelisted.Enabled = true;
					groupProfile.Enabled = true;
					mysql.Open();
					mysql.ChangeDatabase(configuration.dbName);
					MySqlDataReader mySqlDataReader = new MySqlCommand("SELECT * FROM `profile`", mysql.Connection).ExecuteReader();
					while (mySqlDataReader.Read())
					{
						listPlayers.Items.Add(mySqlDataReader.GetString("name"));
					}
					mySqlDataReader.Close();
				}
				catch (MySqlException ex)
				{
					subAppendLog("Error: MySQL Exception: " + ex.Message, LogLevel.Error);
					btnSave4.Enabled = false;
					listPlayers.Enabled = false;
					btnPlayerAdd.Enabled = false;
					checkWhitelisted.Enabled = false;
					groupProfile.Enabled = false;
				}
				finally
				{
					mysql.Close();
				}
				MySqlConnection mySqlConnection = mysql.Connection;
				if (!string.IsNullOrEmpty(configuration.beWhitelistHost) && !string.IsNullOrEmpty(configuration.beWhitelistUser) && !string.IsNullOrEmpty(configuration.beWhitelistPass) && !string.IsNullOrEmpty(configuration.beWhitelistName))
				{
					mySqlConnection = new MySqlConnection($"server={configuration.beWhitelistHost};port={configuration.beWhitelistPort.ToString()};user={configuration.beWhitelistUser};password={configuration.beWhitelistPass};database={configuration.beWhitelistName};");
				}
				try
				{
					mySqlConnection.Open();
					MySqlDataReader mySqlDataReader = new MySqlCommand("SELECT * FROM `whitelist`", mySqlConnection).ExecuteReader();
					while (mySqlDataReader.Read())
					{
						string @string = mySqlDataReader.GetString("name");
						if (!listPlayers.Items.Contains(@string) && !listPlayers.Items.Contains(@string.Replace(" ", "")))
						{
							listPlayers.Items.Add(@string);
						}
					}
					mySqlDataReader.Close();
				}
				catch (MySqlException ex2)
				{
					subAppendLog("Error: MySQL Exception: " + ex2.Message, LogLevel.Error);
				}
				finally
				{
					mySqlConnection.Close();
				}
			}
			catch (Exception ex3)
			{
				subAppendLog(ex3);
				btnSave4.Enabled = false;
			}
			tab3.SelectTab(0);
		}

		private void subReloadResources()
		{
			labelAdminPassword.Text = Resources.passwordadmin + ":";
			labelAppName.Text = Application.ProductName;
			labelChooseLanguage.Text = Resources.sentence_chooselanguage;
			labelCodecQuality.Text = Resources.codecquality + ":";
			labelDifficulty.Text = Resources.difficulty + ":";
			labelEnterBackupInterval.Text = Resources.sentence_backupinterval;
			labelLoadout.Text = Resources.loadout + ":";
			labelLoadoutBackpack.Text = Resources.loadoutbackpack + ":";
			labelDescription1.Text = Resources.sentence_menu1_description;
			labelDescription2.Text = Resources.sentence_menu2_description;
			labelDescription3.Text = Resources.sentence_menu3_description;
			labelDescription4.Text = Resources.sentence_menu4_description;
			labelMaxBandwidth.Text = Resources.maxbandwidth + ":";
			labelMaxBandwidthUnit.Text = Resources.bytespersecond;
			labelMaxCustomSize.Text = Resources.maxcustomsize + ":";
			labelMaxCustomSizeUnit.Text = Resources.kilobyte;
			labelMaxMsgSent.Text = Resources.maxmsgsent + ":";
			labelMaxPing.Text = Resources.maxping + ":";
			labelMaxPlayers.Text = Resources.maxplayers + ":";
			labelMaxSizeGuaranteed.Text = Resources.maxsizeguaranteed + ":";
			labelMaxSizeGuaranteedUnit.Text = Resources.bytes;
			labelMaxSizeNonguaranteed.Text = Resources.maxsizenonguaranteed + ":";
			labelMaxSizeNonguaranteedUnit.Text = Resources.bytes;
			labelModlist.Text = Resources.modlist + ":";
			labelMinBandwidth.Text = Resources.minbandwidth + ":";
			labelMinBandwidthUnit.Text = Resources.bytespersecond;
			labelMinErrtoSend.Text = Resources.minerrtosend + ":";
			labelMinErrtoSendNear.Text = Resources.minerrtosendnear + ":";
			labelNoticeMessage.Text = Resources.sentence_message;
			labelNoticeReset.Text = Resources.sentence_reset;
			labelMySqlHost.Text = Resources.mysql_host + ":";
			labelMySqlCredentials.Text = Resources.mysql_credentials + ":";
			labelPassword.Text = Resources.password + ":";
			labelPathBackupFolder.Text = Resources.backupfolder + ":";
			labelPort.Text = Resources.port + ":";
			labelRconPassword.Text = Resources.passwordrcon + ":";
			labelReportingIp.Text = Resources.reportingip + ":";
			labelRequiredBuild.Text = Resources.build + ":";
			labelRequireSecureId.Text = Resources.requiresecureid + ":";
			labelWelcomeMessage.Text = Resources.messagejoin + ":";
			labelSelectInstance.Text = Resources.sentence_selectinstance;
			labelSelectDatabase.Text = Resources.databasename + ":";
			labelServerName.Text = Resources.servername + ":";
			labelTemplate.Text = Resources.template + ":";
			labelTimeBetweenMessage.Text = Resources.messagetime + ":";
			labelTimezone.Text = Resources.timezone + ":";
			labelVerifySignatures.Text = Resources.verifysignatures + ":";
			labelVersionText.Text = Resources.version + ":";
			labelWhitelistMessage.Text = Resources.message + ":";
			labelPlayerName.Text = Resources.name + ":";
			labelPlayerUid.Text = Resources.uid + ":";
			labelPlayerGuid.Text = Resources.guid + ":";
			labelBackpack.Text = Resources.backpack + ":";
			labelInventory.Text = Resources.inventory + ":";
			labelMedical.Text = Resources.medical + ":";
			labelPosition.Text = Resources.position + ":";
			btnBackup.Text = Resources.button_backup;
			btnBackupBrowse.Text = Resources.button_browse;
			btnDatabase.Text = Resources.button_add_database;
			btnExit.Text = Resources.button_exit;
			btnLog.Text = Resources.button_log;
			btnLogClear.Text = Resources.button_clear;
			btnLogMonitor.Text = Resources.button_monitor_start;
			btnPlayerAdd.Text = Resources.button_add_player;
			btnMenu1.Text = Resources.button_menu1;
			btnMenu2.Text = Resources.button_menu2;
			btnMenu3.Text = Resources.button_menu3;
			btnMenu4.Text = Resources.button_menu4;
			btnMysqlUser.Text = Resources.button_save;
			btnMysqlHost.Text = Resources.button_save;
			btnRandomPass.Text = Resources.button_random;
			btnReset.Text = Resources.button_reset;
			btnRestore.Text = Resources.button_restore;
			btnSave1.Text = Resources.button_save_config;
			btnSave2.Text = Resources.button_save_config;
			btnSave3.Text = Resources.button_save_config;
			btnSave4.Text = Resources.button_save_player;
			checkBattleye.Text = Resources.check_enabled;
			checkDuplicate.Text = Resources.check_duplicate;
			checkPersistent.Text = Resources.check_persistent;
			checkRmod.Text = Resources.check_rmod;
			checkVon.Text = Resources.check_enabled;
			checkWhitelist.Text = Resources.check_enabled;
			checkWhitelisted.Text = Resources.check_whitelisted;
			checkDaytime.Text = Resources.check_daytime;
			tab1Page1.Text = Resources.tab1_page1;
			tab1Page2.Text = Resources.tab1_page2;
			tab1Page3.Text = Resources.tab1_page3;
			tab2Page1.Text = Resources.tab2_page1;
			tab2Page2.Text = Resources.tab2_page2;
			tab2Page3.Text = Resources.tab2_page3;
			tab3Page1.Text = Resources.tab3_page1;
			tab3Page2.Text = Resources.tab3_page2;
			tab3Page3.Text = Resources.tab3_page3;
			groupAbout.Text = Resources.group_about;
			groupBackup.Text = Resources.group_backup;
			groupAutoBackup.Text = Resources.group_autobackup;
			groupBattleye.Text = Resources.group_battleye;
			groupLogin.Text = Resources.group_mysql_details;
			groupMessage.Text = Resources.group_message;
			groupTemplate.Text = Resources.group_template;
			groupProfile.Text = Resources.group_profile;
			groupSurvivor.Text = Resources.group_survivor;
			groupReset.Text = Resources.group_reset;
			groupRestore.Text = Resources.group_restore;
			groupScripting.Text = Resources.group_scripting;
			groupSettings.Text = Resources.group_settings;
			groupSignatures.Text = Resources.group_signatures;
			groupTime.Text = Resources.group_time;
			groupNetwork.Text = Resources.group_tuning_network;
			groupAdditional.Text = Resources.group_other;
			groupVon.Text = Resources.group_von;
			groupWhitelist.Text = Resources.group_whitelist;
			if (configuration.confAutoBackupEnabled)
			{
				btnAutoBackup.Text = Resources.button_autobackup_stop;
			}
			else
			{
				btnAutoBackup.Text = Resources.button_autobackup_start;
			}
		}

		private void btnSave1_Click(object sender, EventArgs e)
		{
			subAppendLog("Configuration: Saving [Panel \"" + Resources.tab1_page1 + "\"]", LogLevel.Info);
			string confWorld = configuration.confWorld;
			configuration.confDaytime = checkDaytime.Checked;
			configuration.confDifficulty = cbxDifficulty.SelectedItem.ToString();
			configuration.confMaxPlayers = Convert.ToInt32(numMaxPlayers.Value);
			configuration.confMotdInterval = Convert.ToInt32(numMessageInterval.Value);
			configuration.confPersistent = checkPersistent.Checked;
			configuration.confRequiredBuild = textBuild.Text;
			configuration.confRmod = checkRmod.Checked;
			configuration.confTimezone = Convert.ToInt32((double)trackTimezone.Value - TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now).TotalHours);
			configuration.confTemplate = cbxTemplate.SelectedItem.ToString().Insert(4, "_" + configuration.confInstance);
			configuration.confVon = checkVon.Checked;
			configuration.confVonQuality = Convert.ToInt32(numVonQuality.Value);
			configuration.confWorld = Regex.Replace(configuration.confTemplate, "[a-z]{4}_[0-9]{1}.", string.Empty);
			configuration.confWorldId = configuration.GetWorldId();
			configuration.confWelcome = textWelcomeMessage.Text;
			if (!string.IsNullOrEmpty(cbxReportingIp.Text))
			{
				configuration.confReportingIp = cbxReportingIp.SelectedItem.ToString();
			}
			else
			{
				configuration.confReportingIp = "127.0.0.1";
			}
			if (!string.IsNullOrEmpty(cbxDatabase.Text))
			{
				configuration.dbName = cbxDatabase.Text;
			}
			if (!string.IsNullOrEmpty(textPort.Text))
			{
				configuration.bePort = Convert.ToInt32(textPort.Text);
			}
			if (!string.IsNullOrEmpty(textHostname.Text))
			{
				configuration.confHostname = textHostname.Text;
			}
			if (string.IsNullOrEmpty(textMessage.Text))
			{
				configuration.confMotd = "\"\"";
			}
			else
			{
				configuration.confMotd = textMessage.Text;
			}
			if (confWorld != configuration.confWorld)
			{
				try
				{
					mysql.Open();
					mysql.ChangeDatabase(configuration.dbName);
					MySqlCommand mySqlCommand = new MySqlCommand("SELECT `folder` FROM `world` WHERE `id` = ?worldid", mysql.Connection);
					mySqlCommand.Parameters.AddWithValue("?worldid", configuration.confWorldId);
					MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
					mySqlDataReader.Read();
					if (mySqlDataReader.HasRows)
					{
						configuration.confModlist = mySqlDataReader.GetString("folder");
					}
				}
				catch (MySqlException ex)
				{
					subAppendLog("Error: MySQL Exception: " + ex.Message, LogLevel.Error);
				}
				catch (Exception ex2)
				{
					subAppendLog(ex2);
				}
				finally
				{
					mysql.Close();
				}
				if (!configuration.confModlist.EndsWith(";"))
				{
					configuration.confModlist += ";";
				}
				if (!configuration.confModlist.ToLower().Contains("@dayzcc"))
				{
					configuration.confModlist += "@dayzcc;";
				}
			}
			if (checkRmod.Checked)
			{
				configuration.confTemplate = configuration.confTemplate.Replace("dayz", "rmod");
				if (!configuration.confModlist.ToLower().Contains("@rmod"))
				{
					if (!configuration.confModlist.EndsWith(";"))
					{
						configuration.confModlist += ";";
					}
					configuration.confModlist += "@rMod;";
				}
			}
			else
			{
				configuration.confTemplate = configuration.confTemplate.Replace("rmod", "dayz");
				if (configuration.confModlist.ToLower().Contains("@rmod;"))
				{
					configuration.confModlist = configuration.confModlist.Remove(configuration.confModlist.ToLower().IndexOf("@rmod"), 6);
				}
				else if (configuration.confModlist.ToLower().Contains("@rmod"))
				{
					configuration.confModlist = configuration.confModlist.Remove(configuration.confModlist.ToLower().IndexOf("@rmod"), 5);
				}
			}
			try
			{
				mysql.Open();
				mysql.ChangeDatabase(configuration.dbName);
				MySqlCommand mySqlCommand = new MySqlCommand("UPDATE `instance` SET `world_id` = ?worldid WHERE `id` = ?instance", mysql.Connection);
				mySqlCommand.Parameters.AddWithValue("?worldid", configuration.confWorldId);
				mySqlCommand.Parameters.AddWithValue("?instance", serverInstance);
				mySqlCommand.ExecuteNonQuery();
			}
			catch (MySqlException ex)
			{
				subAppendLog("Error: MySQL Exception: " + ex.Message, LogLevel.Error);
			}
			catch (Exception ex2)
			{
				subAppendLog(ex2);
			}
			finally
			{
				mysql.Close();
			}
			if (File.Exists(configuration.pathConfigCfg))
			{
				configuration.WriteCfgConfig();
			}
			else
			{
				subAppendLog("Error: File not found: \"" + configuration.pathConfigCfg + "\"", LogLevel.Error);
			}
			if (File.Exists(configuration.pathConfigHive))
			{
				configuration.WriteHiveConfig();
			}
			else
			{
				subAppendLog("Error: File not found: \"" + configuration.pathConfigHive + "\"", LogLevel.Error);
			}
			if (File.Exists(configuration.pathConfigXml))
			{
				configuration.WriteXmlConfig();
			}
			else
			{
				subAppendLog("Error: File not found: \"" + configuration.pathConfigXml + "\"", LogLevel.Error);
			}
			textModlist.Text = configuration.confModlist;
		}

		private void btnSave2_Click(object sender, EventArgs e)
		{
			subAppendLog("Configuration: Saving [Panel \"" + Resources.tab1_page2 + "\"]", LogLevel.Info);
			configuration.beMaxPing = Convert.ToInt32(numMaxPing.Value);
			configuration.bePass = textPasswordRcon.Text;
			configuration.beWhitelistEnabled = checkWhitelist.Checked;
			configuration.beWhitelistMessage = textWhitelistMessage.Text;
			configuration.confBattleye = checkBattleye.Checked;
			configuration.confDoubleIdDetected = textDoubleId.Text;
			configuration.confKickDuplicate = checkDuplicate.Checked;
			configuration.confOnUserConnected = textOnUserConnected.Text;
			configuration.confOnUserDisconnected = textOnUserDisconnected.Text;
			configuration.confOnUnsignedData = textOnUnsigned.Text;
			configuration.confOnHackedData = textOnHacked.Text;
			configuration.confOnDifferentData = textOnDifferent.Text;
			configuration.confPasswordAdmin = textPasswordAdmin.Text;
			configuration.confPasswordServer = textPasswordServer.Text;
			configuration.confRegularCheck = textRegularCheck.Text;
			configuration.confVerifySignatures = Convert.ToInt32(numVerifySignatures.Value);
			configuration.confSecureId = Convert.ToInt32(numSecureId.Value);
			if (File.Exists(configuration.pathConfigXml))
			{
				configuration.WriteXmlConfig();
			}
			else
			{
				subAppendLog("Error: File not found: \"" + configuration.pathConfigXml + "\"", LogLevel.Error);
			}
			if (File.Exists(configuration.pathConfigCfg))
			{
				configuration.WriteCfgConfig();
			}
			else
			{
				subAppendLog("Error: File not found: \"" + configuration.pathConfigCfg + "\"", LogLevel.Error);
			}
			if (File.Exists(configuration.pathConfigBattleye))
			{
				configuration.WriteBattleyeConfig();
			}
			else
			{
				subAppendLog("Warning: File not found: \"" + configuration.pathConfigBattleye + "\"", LogLevel.Warn);
			}
		}

		private void btnSave3_Click(object sender, EventArgs e)
		{
			subAppendLog("Configuration: Saving [Panel \"" + Resources.tab1_page3 + "\"]", LogLevel.Info);
			configuration.confMaxCustomFileSize = Convert.ToInt32(numMaxCustomsize.Value);
			configuration.confMinBandwidth = numMinBandwidth.Value;
			configuration.confMaxBandwidth = numMaxBandwidth.Value;
			configuration.confMaxMsgSend = numMaxMessages.Value;
			configuration.confMaxSizeGuaranteed = numMaxSizeGuaranteed.Value;
			configuration.confMaxSizeNonguaranteed = numMaxSizeNonguaranteed.Value;
			configuration.confMinErrorToSend = numMinError.Value;
			configuration.confMinErrorToSendNear = numMinErrorNear.Value;
			configuration.confModlist = textModlist.Text;
			try
			{
				mysql.Open();
				mysql.ChangeDatabase(configuration.dbName);
				if (!string.IsNullOrEmpty(cbxLoadout.Text))
				{
					MySqlCommand mySqlCommand = new MySqlCommand("UPDATE `instance` SET `inventory` = ?inventory WHERE `id` = ?instance", mysql.Connection);
					mySqlCommand.Parameters.AddWithValue("?inventory", cbxLoadout.Text);
					mySqlCommand.Parameters.AddWithValue("?instance", serverInstance);
					mySqlCommand.ExecuteNonQuery();
				}
				if (!string.IsNullOrEmpty(cbxLoadoutBackpack.Text))
				{
					MySqlCommand mySqlCommand = new MySqlCommand("UPDATE `instance` SET `backpack` = ?backpack WHERE `id` = ?instance", mysql.Connection);
					mySqlCommand.Parameters.AddWithValue("?backpack", cbxLoadoutBackpack.Text);
					mySqlCommand.Parameters.AddWithValue("?instance", serverInstance);
					mySqlCommand.ExecuteNonQuery();
				}
			}
			catch (MySqlException ex)
			{
				subAppendLog("Error: MySQL Exception: " + ex.Message, LogLevel.Error);
			}
			catch (Exception ex2)
			{
				subAppendLog(ex2);
			}
			finally
			{
				mysql.Close();
			}
			if (File.Exists(configuration.pathConfigCfg))
			{
				configuration.WriteCfgConfig();
			}
			else
			{
				subAppendLog("Error: File not found: \"" + configuration.pathConfigCfg + "\"", LogLevel.Error);
			}
			if (File.Exists(configuration.pathConfigBasic))
			{
				configuration.WriteBasicConfig();
			}
			else
			{
				subAppendLog("Error: File not found: \"" + configuration.pathConfigBasic + "\"", LogLevel.Error);
			}
			if (File.Exists(configuration.pathConfigXml))
			{
				configuration.WriteXmlConfig();
			}
			else
			{
				subAppendLog("Error: File not found: \"" + configuration.pathConfigXml + "\"", LogLevel.Error);
			}
		}

		private void btnSave4_Click(object sender, EventArgs e)
		{
			subAppendLog("Configuration: Saving Player [Name \"" + textPlayerName.Text + "\", UID \"" + textPlayerUid.Text + "\"]", LogLevel.Info);
			try
			{
				mysql.Open();
				mysql.ChangeDatabase(configuration.dbName);
				if (groupSurvivor.Enabled && !string.IsNullOrEmpty(textInventory.Text) && !string.IsNullOrEmpty(textBackpack.Text) && !string.IsNullOrEmpty(textPosition.Text) && !string.IsNullOrEmpty(textMedical.Text))
				{
					MySqlCommand mySqlCommand = new MySqlCommand("UPDATE `survivor` SET `inventory` = ?inventory, `backpack` = ?backpack, `worldspace` = ?worldspace, `medical` = ?medical WHERE `unique_id` = ?uid AND `is_dead` = '0'", mysql.Connection);
					mySqlCommand.Parameters.AddWithValue("?inventory", textInventory.Text);
					mySqlCommand.Parameters.AddWithValue("?backpack", textBackpack.Text);
					mySqlCommand.Parameters.AddWithValue("?worldspace", textPosition.Text);
					mySqlCommand.Parameters.AddWithValue("?medical", textMedical.Text);
					mySqlCommand.Parameters.AddWithValue("?uid", textPlayerUid.Text);
					mySqlCommand.ExecuteNonQuery();
				}
				if (textPlayerName.Enabled && textPlayerUid.Enabled && !string.IsNullOrEmpty(textPlayerName.Text) && !string.IsNullOrEmpty(textPlayerUid.Text))
				{
					MySqlCommand mySqlCommand = new MySqlCommand("UPDATE `profile` SET `unique_id` = ?uid WHERE `name` = ?name", mysql.Connection);
					mySqlCommand.Parameters.AddWithValue("?uid", textPlayerUid.Text);
					mySqlCommand.Parameters.AddWithValue("?name", textPlayerName.Text);
					mySqlCommand.ExecuteNonQuery();
				}
			}
			catch (MySqlException ex)
			{
				subAppendLog("Error: MySQL Exception: " + ex.Message, LogLevel.Error);
			}
			catch (Exception ex2)
			{
				subAppendLog(ex2);
			}
			finally
			{
				mysql.Close();
			}
			if (textPlayerGuid.Text.Length == 32)
			{
				MySqlConnection mySqlConnection = mysql.Connection;
				if (!string.IsNullOrEmpty(configuration.beWhitelistHost) && !string.IsNullOrEmpty(configuration.beWhitelistUser) && !string.IsNullOrEmpty(configuration.beWhitelistPass) && !string.IsNullOrEmpty(configuration.beWhitelistName))
				{
					mySqlConnection = new MySqlConnection($"server={configuration.beWhitelistHost};port={configuration.beWhitelistPort.ToString()};user={configuration.beWhitelistUser};password={configuration.beWhitelistPass};database={configuration.beWhitelistName};");
				}
				try
				{
					if (mySqlConnection.State == ConnectionState.Closed)
					{
						mySqlConnection.Open();
					}
					MySqlCommand mySqlCommand = new MySqlCommand("SELECT * FROM `whitelist` WHERE `guid` = ?guid", mySqlConnection);
					mySqlCommand.Parameters.AddWithValue("?guid", textPlayerGuid.Text);
					MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
					if (mySqlDataReader.Read())
					{
						mySqlDataReader.Close();
						mySqlCommand = new MySqlCommand("UPDATE `whitelist` SET `guid` = ?guid WHERE `name` = ?name", mySqlConnection);
						mySqlCommand.Parameters.AddWithValue("@guid", textPlayerGuid.Text);
						mySqlCommand.Parameters.AddWithValue("@name", textPlayerName.Text);
						mySqlCommand.ExecuteNonQuery();
						mySqlCommand = new MySqlCommand("UPDATE `whitelist` SET `is_whitelisted` = ?whitelisted WHERE `guid` = ?guid", mySqlConnection);
						mySqlCommand.Parameters.AddWithValue("?whitelisted", checkWhitelisted.Checked ? "1" : "0");
						mySqlCommand.Parameters.AddWithValue("?guid", textPlayerGuid.Text);
						mySqlCommand.ExecuteNonQuery();
					}
					else
					{
						mySqlDataReader.Close();
						mySqlCommand = new MySqlCommand("INSERT INTO `whitelist` (`name`, `guid`, `is_whitelisted`) VALUES (?name, ?guid, '1')", mySqlConnection);
						mySqlCommand.Parameters.AddWithValue("?name", textPlayerName.Text);
						mySqlCommand.Parameters.AddWithValue("?guid", textPlayerGuid.Text);
						mySqlCommand.ExecuteNonQuery();
						checkWhitelisted.Enabled = true;
						checkWhitelisted.Checked = true;
					}
					return;
				}
				catch (MySqlException ex)
				{
					subAppendLog("Error: MySQL Exception: " + ex.Message, LogLevel.Error);
					return;
				}
				catch (Exception ex2)
				{
					subAppendLog(ex2);
					return;
				}
				finally
				{
					mySqlConnection.Close();
				}
			}
			if (string.IsNullOrEmpty(textPlayerGuid.Text))
			{
				MySqlConnection mySqlConnection = mysql.Connection;
				if (!string.IsNullOrEmpty(configuration.beWhitelistHost) && !string.IsNullOrEmpty(configuration.beWhitelistUser) && !string.IsNullOrEmpty(configuration.beWhitelistPass) && !string.IsNullOrEmpty(configuration.beWhitelistName))
				{
					mySqlConnection = new MySqlConnection($"server={configuration.beWhitelistHost};port={configuration.beWhitelistPort.ToString()};user={configuration.beWhitelistUser};password={configuration.beWhitelistPass};database={configuration.beWhitelistName};");
				}
				try
				{
					if (mySqlConnection.State == ConnectionState.Closed)
					{
						mySqlConnection.Open();
					}
					MySqlCommand mySqlCommand = new MySqlCommand("DELETE FROM `whitelist` WHERE `name` = ?name", mySqlConnection);
					mySqlCommand.Parameters.AddWithValue("?name", textPlayerName.Text);
					mySqlCommand.ExecuteNonQuery();
					checkWhitelisted.Checked = false;
					checkWhitelisted.Enabled = false;
					return;
				}
				catch (MySqlException ex)
				{
					subAppendLog("Error: MySQL Exception: " + ex.Message, LogLevel.Error);
					return;
				}
				catch (Exception ex2)
				{
					subAppendLog(ex2);
					return;
				}
				finally
				{
					mySqlConnection.Close();
				}
			}
			subAppendLog("Warning: Invalid GUID", LogLevel.Warn);
			textPlayerGuid.Clear();
		}

		private void btnAutoBackup_Click(object sender, EventArgs e)
		{
			if (listAutoBackupEnabled[serverInstance - 1])
			{
				subAppendLog("Backup: Auto Backup stopped [Instance " + serverInstance + "]", LogLevel.Info);
				btnAutoBackup.Text = Resources.button_autobackup_start;
				listAutoBackupEnabled[serverInstance - 1] = false;
			}
			else
			{
				subAppendLog("Backup: Auto Backup started [Instance " + serverInstance + "]", LogLevel.Info);
				btnAutoBackup.Text = Resources.button_autobackup_stop;
				listAutoBackupInterval[serverInstance - 1] = Convert.ToInt32(numBackupInterval.Value);
				listAutoBackupEnabled[serverInstance - 1] = true;
				progressBackup.Maximum = listAutoBackupInterval[serverInstance - 1] * 60;
			}
			configuration.confAutoBackupInterval = listAutoBackupInterval[serverInstance - 1];
			configuration.confAutoBackupEnabled = listAutoBackupEnabled[serverInstance - 1];
			if (File.Exists(configuration.pathConfigXml))
			{
				configuration.WriteXmlConfig();
			}
			else
			{
				subAppendLog("Error: File not found: \"" + configuration.pathConfigXml + "\"", LogLevel.Error);
			}
		}

		private void btnBackup_Click(object sender, EventArgs e)
		{
			Thread thread = new Thread(threadBackup);
			thread.IsBackground = true;
			thread.Start();
		}

		private void btnBackupBrowse_Click(object sender, EventArgs e)
		{
			using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
			{
				if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
				{
					configuration.confAutoBackupPath = folderBrowserDialog.SelectedPath;
					textBackupPath.Text = configuration.confAutoBackupPath;
					if (File.Exists(configuration.pathConfigXml))
					{
						configuration.WriteXmlConfig();
						subAppendLog("Configuration: Backup Path changed [Path \"" + configuration.confAutoBackupPath + "\"]", LogLevel.Info);
					}
					else
					{
						subAppendLog("Error: File not found: \"" + configuration.pathConfigXml + "\"", LogLevel.Error);
					}
				}
			}
		}

		private void btnDatabase_Click(object sender, EventArgs e)
		{
			string name = cbxDatabase.Text.Replace(" ", "");
			if (!string.IsNullOrEmpty(name) && !cbxDatabase.Items.Contains(name) && MessageBox.Show(Resources.message_confirm_database + " \"" + name + "\"?", string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				Thread thread = new Thread((ThreadStart)delegate
				{
					threadDatabase(name);
				});
				thread.IsBackground = true;
				thread.Start();
			}
		}

		private void btnExit_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnLog_CheckedChanged(object sender, EventArgs e)
		{
			if (btnLog.Checked)
			{
				container2.Panel1Collapsed = false;
			}
			else
			{
				container2.Panel1Collapsed = true;
			}
		}

		private void btnLogMonitor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (timerMonitor.Enabled)
			{
				subAppendLog("Monitor: Log Monitoring stopped [Instance " + serverInstance + "]", LogLevel.Info);
				timerMonitor.Stop();
				btnLogMonitor.Text = Resources.button_monitor_start;
				return;
			}
			subAppendLog("Monitor: Log Monitoring started [Instance " + serverInstance + "]", LogLevel.Info);
			if (File.Exists(Path.Combine(configuration.pathConfig, "arma2oaserver_" + serverInstance + ".rpt")))
			{
				timerMonitor.Start();
				btnLogMonitor.Text = Resources.button_monitor_stop;
			}
			else
			{
				subAppendLog("Error: File not found: \"" + Path.Combine(configuration.pathConfig, "arma2oaserver_" + serverInstance + ".rpt") + "\"", LogLevel.Error);
			}
		}

		private void btnLogClear_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (File.Exists(Path.Combine(configuration.pathConfig, "arma2oaserver_" + serverInstance + ".rpt")) && MessageBox.Show(Resources.message_confirm_deletelog, string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
			{
				subAppendLog("Monitor: Deleting Log [Instance " + serverInstance + "]", LogLevel.Info);
				if (timerMonitor.Enabled)
				{
					timerMonitor.Stop();
				}
				btnLogMonitor.Text = Resources.button_monitor_start;
				try
				{
					File.Delete(Path.Combine(configuration.pathConfig, "arma2oaserver_" + serverInstance + ".rpt"));
					textLogRpt.Clear();
					btnLogMonitor.Enabled = false;
					btnLogClear.Enabled = false;
				}
				catch (Exception ex)
				{
					subAppendLog(ex);
				}
			}
		}

		private void btnMysqlHost_Click(object sender, EventArgs e)
		{
			subAppendLog("Configuration: MySQL Host changed [Host \"" + textMysqlHost.Text + ":" + textMysqlPort.Text + "\"]", LogLevel.Info);
			configuration.dbHost = textMysqlHost.Text;
			configuration.dbPort = Convert.ToInt32(textMysqlPort.Text);
			if (File.Exists(configuration.pathConfigHive))
			{
				configuration.WriteHiveConfig();
			}
			else
			{
				subAppendLog("Error: File not found: \"" + configuration.pathConfigHive + "\"", LogLevel.Error);
			}
			mysql.Close();
			mysql.Connection = new MySqlConnection($"server={configuration.dbHost};port={configuration.dbPort.ToString()};user={configuration.dbUser};password={configuration.dbPass};");
		}

		private void btnMysqlUser_Click(object sender, EventArgs e)
		{
			subAppendLog("Configuration: MySQL User changed [User \"" + textMysqlUser.Text + "\", Password \"" + textMysqlPass.Text + "\"]", LogLevel.Info);
			bool flag = false;
			if (textMysqlUser.Text == this.configuration.dbUser)
			{
				try
				{
					mysql.Open();
					MySqlCommand mySqlCommand = new MySqlCommand("SET PASSWORD = PASSWORD(?pass)", mysql.Connection);
					mySqlCommand.Parameters.AddWithValue("?pass", textMysqlPass.Text);
					mySqlCommand.ExecuteNonQuery();
				}
				catch (MySqlException ex)
				{
					flag = true;
					subAppendLog("Error: MySQL Exception: " + ex.Message, LogLevel.Error);
				}
				catch (Exception ex2)
				{
					flag = true;
					subAppendLog(ex2);
				}
				finally
				{
					mysql.Close();
				}
			}
			else
			{
				MySqlConnection mySqlConnection = new MySqlConnection($"server={this.configuration.dbHost};port={this.configuration.dbPort.ToString()};user={textMysqlUser.Text};password={textMysqlPass.Text};");
				try
				{
					mySqlConnection.Open();
					new MySqlCommand("SHOW DATABASES", mySqlConnection).ExecuteNonQuery();
				}
				catch (MySqlException ex)
				{
					flag = true;
					subAppendLog("Error: MySQL Exception: " + ex.Message, LogLevel.Error);
				}
				finally
				{
					mySqlConnection.Close();
				}
			}
			if (flag)
			{
				return;
			}
			mysql.Close();
			mysql.Connection = new MySqlConnection($"server={this.configuration.dbHost};port={this.configuration.dbPort.ToString()};user={this.configuration.dbUser};password={this.configuration.dbPass};");
			this.configuration.dbUser = textMysqlUser.Text;
			this.configuration.dbPass = textMysqlPass.Text;
			for (int i = 1; i <= appInstances; i++)
			{
				Configuration configuration = new Configuration(i);
				if (File.Exists(configuration.pathConfigHive) && i != serverInstance)
				{
					configuration.LoadHiveConfig();
					if (this.configuration.dbHost == configuration.dbHost && this.configuration.dbUser == configuration.dbUser)
					{
						configuration.dbPass = textMysqlPass.Text;
						configuration.WriteHiveConfig();
					}
				}
			}
			if (File.Exists(this.configuration.pathConfigHive))
			{
				this.configuration.WriteHiveConfig();
			}
			else
			{
				subAppendLog("Error: File not found: \"" + this.configuration.pathConfigHive + "\"", LogLevel.Error);
			}
		}

		private void btnPlayer_Click(object sender, EventArgs e)
		{
			string text = textPlayerName.Text;
			string text2 = textPlayerGuid.Text;
			if (textPlayerGuid.Text.Length == 32)
			{
				if (MessageBox.Show(Resources.message_confirm_player + " \"" + text + "\", \"" + text2 + "\"?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
				{
					return;
				}
				MySqlConnection mySqlConnection = mysql.Connection;
				if (!string.IsNullOrEmpty(configuration.beWhitelistHost) && !string.IsNullOrEmpty(configuration.beWhitelistUser) && !string.IsNullOrEmpty(configuration.beWhitelistPass) && !string.IsNullOrEmpty(configuration.beWhitelistName))
				{
					mySqlConnection = new MySqlConnection($"server={configuration.beWhitelistHost};port={configuration.beWhitelistPort.ToString()};user={configuration.beWhitelistUser};password={configuration.beWhitelistPass};database={configuration.beWhitelistName};");
				}
				subAppendLog("Whitelist: Adding player [Name \"" + text + "\", GUID \"" + text2 + "\"]", LogLevel.Info);
				try
				{
					if (mySqlConnection.State == ConnectionState.Closed)
					{
						mySqlConnection.Open();
					}
					MySqlCommand mySqlCommand = new MySqlCommand("SELECT `name` FROM `whitelist` WHERE `name` = ?name", mySqlConnection);
					mySqlCommand.Parameters.AddWithValue("?name", text);
					MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
					mySqlDataReader.Read();
					if (mySqlDataReader.HasRows)
					{
						mySqlDataReader.Close();
						subAppendLog("Error: Player already exists", LogLevel.Warn);
					}
					else
					{
						mySqlDataReader.Close();
						mySqlCommand = new MySqlCommand("INSERT INTO `whitelist` (`name`, `guid`, `is_whitelisted`) VALUES (?name, ?guid, '1')", mySqlConnection);
						mySqlCommand.Parameters.AddWithValue("?name", text);
						mySqlCommand.Parameters.AddWithValue("?guid", text2);
						mySqlCommand.ExecuteNonQuery();
					}
				}
				catch (MySqlException ex)
				{
					subAppendLog("Error: MySQL Exception: " + ex.Message, LogLevel.Error);
				}
				catch (Exception ex2)
				{
					subAppendLog(ex2);
				}
				finally
				{
					mySqlConnection.Close();
				}
				subReloadPanel3();
			}
			else
			{
				subAppendLog("Warning: Invalid GUID", LogLevel.Warn);
			}
		}

		private void btnRandomPass_Click(object sender, EventArgs e)
		{
			if (textPasswordAdmin.Enabled)
			{
				textPasswordAdmin.Text = Crosire.Library.Text.RandomString(10);
			}
			if (textPasswordRcon.Enabled)
			{
				textPasswordRcon.Text = Crosire.Library.Text.RandomString(10);
			}
		}

		private void btnReset_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show(Resources.message_reset, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
			{
				return;
			}
			try
			{
				subAppendLog("Configuration: Dropping current database [Database \"" + configuration.dbName + "\"]", LogLevel.Info);
				mysql.Open();
				MySqlCommand mySqlCommand = new MySqlCommand("DROP DATABASE IF EXISTS `@name`", mysql.Connection);
				mySqlCommand.Parameters.AddWithValue("@name", configuration.dbName);
				mySqlCommand.ExecuteNonQuery();
			}
			catch (MySqlException ex)
			{
				subAppendLog("Error: MySQL Exception: " + ex.Message, LogLevel.Error);
				mysql.Close();
				return;
			}
			finally
			{
				mysql.Close();
			}
			Thread thread = new Thread((ThreadStart)delegate
			{
				threadDatabase(configuration.dbName, true);
			});
			thread.IsBackground = true;
			thread.Start();
		}

		private void btnRestore_Click(object sender, EventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog();
			try
			{
				dlg.Filter = "SQL Backups|*.sql";
				dlg.InitialDirectory = configuration.confAutoBackupPath;
				if (dlg.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(dlg.FileName) && File.Exists(dlg.FileName))
				{
					Thread thread = new Thread((ThreadStart)delegate
					{
						threadRestore(dlg.FileName);
					});
					thread.IsBackground = true;
					thread.Start();
				}
			}
			finally
			{
				if (dlg != null)
				{
					((IDisposable)dlg).Dispose();
				}
			}
		}

		private void cbxDatabase_TextChanged(object sender, EventArgs e)
		{
			cbxDatabase.Text = cbxDatabase.Text.Replace(" ", "");
			if (string.IsNullOrEmpty(cbxDatabase.Text) || cbxDatabase.Items.Contains(cbxDatabase.Text))
			{
				btnDatabase.Enabled = false;
			}
			else
			{
				btnDatabase.Enabled = true;
			}
		}

		private void cbxLanguage_DropDownClosed(object sender, EventArgs e)
		{
			string text = cbxLanguage.SelectedItem.ToString();
			if (Thread.CurrentThread.CurrentUICulture.IetfLanguageTag != text)
			{
				subAppendLog("Application: Language changed [" + text + "]", LogLevel.Info);
				try
				{
					Thread.CurrentThread.CurrentUICulture = new CultureInfo(text);
					cbxLanguage.Text = text;
					subReloadResources();
					Settings.Default.uiLanguage = text;
					Settings.Default.Save();
				}
				catch (Exception ex)
				{
					subAppendLog(ex);
				}
			}
		}

		private void cbxTemplate_DropDownClosed(object sender, EventArgs e)
		{
			if (cbxDatabase.Items.Contains("dayz_" + cbxTemplate.SelectedItem.ToString().Remove(0, 5)))
			{
				cbxDatabase.SelectedItem = "dayz_" + cbxTemplate.SelectedItem.ToString().Remove(0, 5);
			}
		}

		private void checkBattleye_CheckedChanged(object sender, EventArgs e)
		{
		}

		private void checkWhitelist_CheckedChanged(object sender, EventArgs e)
		{
			if (checkWhitelist.Checked)
			{
				textWelcomeMessage.Enabled = true;
			}
			else
			{
				textWelcomeMessage.Enabled = false;
			}
		}

		private void listPlayers_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (listPlayers.SelectedItem == null)
			{
				return;
			}
			MySqlConnection mySqlConnection = mysql.Connection;
			if (!string.IsNullOrEmpty(configuration.beWhitelistHost) && !string.IsNullOrEmpty(configuration.beWhitelistUser) && !string.IsNullOrEmpty(configuration.beWhitelistPass) && !string.IsNullOrEmpty(configuration.beWhitelistName))
			{
				mySqlConnection = new MySqlConnection($"server={configuration.beWhitelistHost};port={configuration.beWhitelistPort.ToString()};user={configuration.beWhitelistUser};password={configuration.beWhitelistPass};database={configuration.beWhitelistName};");
			}
			checkWhitelisted.Enabled = false;
			try
			{
				if (mySqlConnection.State == ConnectionState.Closed)
				{
					mySqlConnection.Open();
				}
				if (string.IsNullOrEmpty(configuration.beWhitelistName))
				{
					mySqlConnection.ChangeDatabase(configuration.dbName);
				}
				else
				{
					mySqlConnection.ChangeDatabase(configuration.beWhitelistName);
				}
				MySqlDataReader mySqlDataReader = new MySqlCommand("SELECT * FROM `whitelist`", mySqlConnection).ExecuteReader();
				while (mySqlDataReader.Read())
				{
					if (mySqlDataReader.GetString("name") == listPlayers.SelectedItem.ToString())
					{
						checkWhitelisted.Enabled = true;
						if (mySqlDataReader.GetString("is_whitelisted") == "1")
						{
							checkWhitelisted.Checked = true;
						}
						else
						{
							checkWhitelisted.Checked = false;
						}
					}
				}
				mySqlDataReader.Close();
			}
			catch (MySqlException ex)
			{
				subAppendLog("Error: MySQL Exception: " + ex.Message, LogLevel.Error);
			}
			catch (Exception ex2)
			{
				subAppendLog(ex2);
			}
			finally
			{
				mySqlConnection.Close();
			}
			textPlayerName.Text = listPlayers.SelectedItem.ToString();
			try
			{
				mysql.Open();
				mysql.ChangeDatabase(configuration.dbName);
				MySqlCommand mySqlCommand = new MySqlCommand("SELECT `unique_id` FROM `profile` WHERE `name` = ?name", mysql.Connection);
				mySqlCommand.Parameters.AddWithValue("?name", listPlayers.SelectedItem.ToString());
				MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
				mySqlDataReader.Read();
				if (mySqlDataReader.HasRows)
				{
					textPlayerUid.Enabled = true;
					textPlayerUid.Text = mySqlDataReader.GetString("unique_id");
				}
				else
				{
					textPlayerUid.Enabled = false;
					textPlayerUid.Clear();
				}
				mySqlDataReader.Close();
			}
			catch (MySqlException ex)
			{
				subAppendLog("Error: MySQL Exception: " + ex.Message, LogLevel.Error);
			}
			catch (Exception ex2)
			{
				subAppendLog(ex2);
			}
			finally
			{
				mysql.Close();
			}
			try
			{
				if (mySqlConnection.State == ConnectionState.Closed)
				{
					mySqlConnection.Open();
				}
				MySqlCommand mySqlCommand = new MySqlCommand("SELECT `guid` FROM `whitelist` WHERE `name` = ?name", mySqlConnection);
				mySqlCommand.Parameters.AddWithValue("?name", listPlayers.SelectedItem.ToString());
				MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
				mySqlDataReader.Read();
				if (mySqlDataReader.HasRows)
				{
					textPlayerGuid.Text = mySqlDataReader.GetString("guid");
				}
				else
				{
					textPlayerGuid.Clear();
				}
				mySqlDataReader.Close();
			}
			catch (MySqlException ex)
			{
				subAppendLog("Error: MySQL Exception: " + ex.Message, LogLevel.Error);
			}
			catch (Exception ex2)
			{
				subAppendLog(ex2);
			}
			finally
			{
				mySqlConnection.Close();
			}
			try
			{
				mysql.Open();
				mysql.ChangeDatabase(configuration.dbName);
				MySqlCommand mySqlCommand = new MySqlCommand("SELECT profile.name, survivor.* FROM `profile`, `survivor` WHERE profile.unique_id = survivor.unique_id AND survivor.is_dead = '0' AND survivor.unique_id = ?uid", mysql.Connection);
				mySqlCommand.Parameters.AddWithValue("?uid", textPlayerUid.Text);
				MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
				mySqlDataReader.Read();
				if (mySqlDataReader.HasRows)
				{
					groupSurvivor.Enabled = true;
					textInventory.Text = mySqlDataReader.GetString("inventory");
					textBackpack.Text = mySqlDataReader.GetString("backpack");
					textPosition.Text = mySqlDataReader.GetString("worldspace");
					textMedical.Text = mySqlDataReader.GetString("medical");
				}
				else
				{
					textInventory.Clear();
					textBackpack.Clear();
					textPosition.Clear();
					textMedical.Clear();
					groupSurvivor.Enabled = false;
				}
				mySqlDataReader.Close();
			}
			catch (MySqlException ex)
			{
				subAppendLog("Error: MySQL Exception: " + ex.Message, LogLevel.Error);
			}
			catch (Exception ex2)
			{
				subAppendLog(ex2);
			}
			finally
			{
				mysql.Close();
			}
		}

		private void pictureIcon_Click(object sender, EventArgs e)
		{
			Process.Start(Settings.Default.uiUrlHomepage);
		}

		private void pictureLicense_Click(object sender, EventArgs e)
		{
			Process.Start("http://creativecommons.org/licenses/by-nd/3.0/");
		}

		private void trackTimezone_Scroll(object sender, EventArgs e)
		{
			if (trackTimezone.Value <= 0)
			{
				textTimezone.Text = "UTC " + trackTimezone.Value;
			}
			else
			{
				textTimezone.Text = "UTC +" + trackTimezone.Value;
			}
			if (!checkDaytime.Checked)
			{
				int num = DateTime.Now.ToUniversalTime().Hour + trackTimezone.Value;
				if (num > 23)
				{
					num -= 24;
				}
				labelTime.Text = num.ToString("D2") + ":" + DateTime.Now.ToUniversalTime().Minute.ToString("D2");
			}
			else
			{
				labelTime.Text = configuration.confStaticHour.ToString("D2") + ":00";
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Crosire.Controlcenter.frmMain));
			this.timerMonitor = new System.Windows.Forms.Timer(this.components);
			this.container1 = new System.Windows.Forms.SplitContainer();
			this.btnLog = new System.Windows.Forms.CheckBox();
			this.btnExit = new System.Windows.Forms.Button();
			this.cbxInstance = new System.Windows.Forms.ComboBox();
			this.labelSelectInstance = new System.Windows.Forms.Label();
			this.labelDescription4 = new System.Windows.Forms.Label();
			this.labelDescription2 = new System.Windows.Forms.Label();
			this.labelDescription3 = new System.Windows.Forms.Label();
			this.labelDescription1 = new System.Windows.Forms.Label();
			this.btnMenu4 = new System.Windows.Forms.RadioButton();
			this.btnMenu2 = new System.Windows.Forms.RadioButton();
			this.btnMenu3 = new System.Windows.Forms.RadioButton();
			this.btnMenu1 = new System.Windows.Forms.RadioButton();
			this.container2 = new System.Windows.Forms.SplitContainer();
			this.textLog = new System.Windows.Forms.RichTextBox();
			this.container2_2 = new System.Windows.Forms.Panel();
			this.tab2 = new System.Windows.Forms.TabControl();
			this.tab2Page1 = new System.Windows.Forms.TabPage();
			this.tab2Page2 = new System.Windows.Forms.TabPage();
			this.groupLogin = new System.Windows.Forms.GroupBox();
			this.labelMySqlCredentials = new System.Windows.Forms.Label();
			this.btnMysqlHost = new System.Windows.Forms.Button();
			this.textMysqlUser = new System.Windows.Forms.TextBox();
			this.btnMysqlUser = new System.Windows.Forms.Button();
			this.textMysqlPass = new System.Windows.Forms.TextBox();
			this.labelMysqlPoint = new System.Windows.Forms.Label();
			this.labelMySqlHost = new System.Windows.Forms.Label();
			this.textMysqlPort = new System.Windows.Forms.TextBox();
			this.textMysqlHost = new System.Windows.Forms.TextBox();
			this.tab2Page3 = new System.Windows.Forms.TabPage();
			this.btnLogClear = new System.Windows.Forms.LinkLabel();
			this.btnLogMonitor = new System.Windows.Forms.LinkLabel();
			this.textLogRpt = new System.Windows.Forms.RichTextBox();
			this.container2_4 = new System.Windows.Forms.Panel();
			this.groupSettings = new System.Windows.Forms.GroupBox();
			this.cbxLanguage = new System.Windows.Forms.ComboBox();
			this.labelChooseLanguage = new System.Windows.Forms.Label();
			this.groupAbout = new System.Windows.Forms.GroupBox();
			this.pictureLicense = new System.Windows.Forms.PictureBox();
			this.labelAppName = new System.Windows.Forms.Label();
			this.labelVersionText = new System.Windows.Forms.Label();
			this.pictureIcon = new System.Windows.Forms.PictureBox();
			this.labelVersion = new System.Windows.Forms.Label();
			this.container2_3 = new System.Windows.Forms.Panel();
			this.tab3 = new System.Windows.Forms.TabControl();
			this.tab3Page1 = new System.Windows.Forms.TabPage();
			this.tab3Page2 = new System.Windows.Forms.TabPage();
			this.checkWhitelisted = new System.Windows.Forms.CheckBox();
			this.groupSurvivor = new System.Windows.Forms.GroupBox();
			this.textMedical = new System.Windows.Forms.TextBox();
			this.labelMedical = new System.Windows.Forms.Label();
			this.textPosition = new System.Windows.Forms.TextBox();
			this.labelPosition = new System.Windows.Forms.Label();
			this.textBackpack = new System.Windows.Forms.TextBox();
			this.labelBackpack = new System.Windows.Forms.Label();
			this.textInventory = new System.Windows.Forms.TextBox();
			this.labelInventory = new System.Windows.Forms.Label();
			this.listPlayers = new System.Windows.Forms.ListBox();
			this.groupProfile = new System.Windows.Forms.GroupBox();
			this.textPlayerGuid = new System.Windows.Forms.TextBox();
			this.labelPlayerGuid = new System.Windows.Forms.Label();
			this.textPlayerUid = new System.Windows.Forms.TextBox();
			this.labelPlayerUid = new System.Windows.Forms.Label();
			this.textPlayerName = new System.Windows.Forms.TextBox();
			this.labelPlayerName = new System.Windows.Forms.Label();
			this.btnPlayerAdd = new System.Windows.Forms.Button();
			this.btnSave4 = new System.Windows.Forms.Button();
			this.tab3Page3 = new System.Windows.Forms.TabPage();
			this.groupReset = new System.Windows.Forms.GroupBox();
			this.labelNoticeReset = new System.Windows.Forms.Label();
			this.btnReset = new System.Windows.Forms.Button();
			this.groupAutoBackup = new System.Windows.Forms.GroupBox();
			this.progressBackup = new System.Windows.Forms.ProgressBar();
			this.btnAutoBackup = new System.Windows.Forms.Button();
			this.numBackupInterval = new System.Windows.Forms.NumericUpDown();
			this.labelEnterBackupInterval = new System.Windows.Forms.Label();
			this.groupRestore = new System.Windows.Forms.GroupBox();
			this.btnRestore = new System.Windows.Forms.Button();
			this.groupBackup = new System.Windows.Forms.GroupBox();
			this.btnBackupBrowse = new System.Windows.Forms.Button();
			this.textBackupPath = new System.Windows.Forms.TextBox();
			this.labelPathBackupFolder = new System.Windows.Forms.Label();
			this.btnBackup = new System.Windows.Forms.Button();
			this.container2_1 = new System.Windows.Forms.Panel();
			this.tab1 = new System.Windows.Forms.TabControl();
			this.tab1Page1 = new System.Windows.Forms.TabPage();
			this.btnSave1 = new System.Windows.Forms.Button();
			this.textBuild = new System.Windows.Forms.MaskedTextBox();
			this.textPort = new System.Windows.Forms.MaskedTextBox();
			this.groupTime = new System.Windows.Forms.GroupBox();
			this.labelTime = new System.Windows.Forms.Label();
			this.checkDaytime = new System.Windows.Forms.CheckBox();
			this.textTimezone = new System.Windows.Forms.Label();
			this.labelTimezone = new System.Windows.Forms.Label();
			this.trackTimezone = new System.Windows.Forms.TrackBar();
			this.groupTemplate = new System.Windows.Forms.GroupBox();
			this.checkRmod = new System.Windows.Forms.CheckBox();
			this.btnDatabase = new System.Windows.Forms.Button();
			this.cbxDatabase = new System.Windows.Forms.ComboBox();
			this.labelSelectDatabase = new System.Windows.Forms.Label();
			this.labelDifficulty = new System.Windows.Forms.Label();
			this.cbxDifficulty = new System.Windows.Forms.ComboBox();
			this.cbxTemplate = new System.Windows.Forms.ComboBox();
			this.labelTemplate = new System.Windows.Forms.Label();
			this.checkPersistent = new System.Windows.Forms.CheckBox();
			this.groupVon = new System.Windows.Forms.GroupBox();
			this.numVonQuality = new System.Windows.Forms.NumericUpDown();
			this.labelCodecQuality = new System.Windows.Forms.Label();
			this.checkVon = new System.Windows.Forms.CheckBox();
			this.labelRequiredBuild = new System.Windows.Forms.Label();
			this.groupMessage = new System.Windows.Forms.GroupBox();
			this.textWelcomeMessage = new System.Windows.Forms.TextBox();
			this.labelWelcomeMessage = new System.Windows.Forms.Label();
			this.labelNoticeMessage = new System.Windows.Forms.Label();
			this.numMessageInterval = new System.Windows.Forms.NumericUpDown();
			this.labelTimeBetweenMessage = new System.Windows.Forms.Label();
			this.textMessage = new System.Windows.Forms.RichTextBox();
			this.numMaxPlayers = new System.Windows.Forms.NumericUpDown();
			this.labelMaxPlayers = new System.Windows.Forms.Label();
			this.cbxReportingIp = new System.Windows.Forms.ComboBox();
			this.labelPort = new System.Windows.Forms.Label();
			this.labelReportingIp = new System.Windows.Forms.Label();
			this.textHostname = new System.Windows.Forms.TextBox();
			this.labelServerName = new System.Windows.Forms.Label();
			this.tab1Page2 = new System.Windows.Forms.TabPage();
			this.groupWhitelist = new System.Windows.Forms.GroupBox();
			this.textWhitelistMessage = new System.Windows.Forms.TextBox();
			this.labelWhitelistMessage = new System.Windows.Forms.Label();
			this.checkWhitelist = new System.Windows.Forms.CheckBox();
			this.btnRandomPass = new System.Windows.Forms.Button();
			this.btnSave2 = new System.Windows.Forms.Button();
			this.groupSignatures = new System.Windows.Forms.GroupBox();
			this.numSecureId = new System.Windows.Forms.NumericUpDown();
			this.labelRequireSecureId = new System.Windows.Forms.Label();
			this.numVerifySignatures = new System.Windows.Forms.NumericUpDown();
			this.labelVerifySignatures = new System.Windows.Forms.Label();
			this.groupScripting = new System.Windows.Forms.GroupBox();
			this.checkDuplicate = new System.Windows.Forms.CheckBox();
			this.textRegularCheck = new System.Windows.Forms.TextBox();
			this.labelRegularCheck = new System.Windows.Forms.Label();
			this.textOnUnsigned = new System.Windows.Forms.TextBox();
			this.textOnDifferent = new System.Windows.Forms.TextBox();
			this.textOnHacked = new System.Windows.Forms.TextBox();
			this.textOnUserDisconnected = new System.Windows.Forms.TextBox();
			this.textOnUserConnected = new System.Windows.Forms.TextBox();
			this.textDoubleId = new System.Windows.Forms.TextBox();
			this.labelOnUnsignedData = new System.Windows.Forms.Label();
			this.labelOnDifferentData = new System.Windows.Forms.Label();
			this.labelOnHackedData = new System.Windows.Forms.Label();
			this.labelOnUserDisconnected = new System.Windows.Forms.Label();
			this.labelOnUserConnected = new System.Windows.Forms.Label();
			this.labelDoubleId = new System.Windows.Forms.Label();
			this.groupBattleye = new System.Windows.Forms.GroupBox();
			this.numMaxPing = new System.Windows.Forms.NumericUpDown();
			this.labelMaxPing = new System.Windows.Forms.Label();
			this.checkBattleye = new System.Windows.Forms.CheckBox();
			this.textPasswordRcon = new System.Windows.Forms.TextBox();
			this.labelRconPassword = new System.Windows.Forms.Label();
			this.textPasswordAdmin = new System.Windows.Forms.TextBox();
			this.labelAdminPassword = new System.Windows.Forms.Label();
			this.textPasswordServer = new System.Windows.Forms.TextBox();
			this.labelPassword = new System.Windows.Forms.Label();
			this.tab1Page3 = new System.Windows.Forms.TabPage();
			this.groupAdditional = new System.Windows.Forms.GroupBox();
			this.cbxLoadoutBackpack = new System.Windows.Forms.ComboBox();
			this.labelLoadoutBackpack = new System.Windows.Forms.Label();
			this.textModlist = new System.Windows.Forms.TextBox();
			this.labelModlist = new System.Windows.Forms.Label();
			this.cbxLoadout = new System.Windows.Forms.ComboBox();
			this.labelLoadout = new System.Windows.Forms.Label();
			this.numMaxCustomsize = new System.Windows.Forms.NumericUpDown();
			this.labelMaxCustomSize = new System.Windows.Forms.Label();
			this.labelMaxCustomSizeUnit = new System.Windows.Forms.Label();
			this.btnSave3 = new System.Windows.Forms.Button();
			this.groupNetwork = new System.Windows.Forms.GroupBox();
			this.numMaxBandwidth = new System.Windows.Forms.NumericUpDown();
			this.numMinBandwidth = new System.Windows.Forms.NumericUpDown();
			this.numMaxMessages = new System.Windows.Forms.NumericUpDown();
			this.numMaxSizeGuaranteed = new System.Windows.Forms.NumericUpDown();
			this.numMaxSizeNonguaranteed = new System.Windows.Forms.NumericUpDown();
			this.numMinErrorNear = new System.Windows.Forms.NumericUpDown();
			this.numMinError = new System.Windows.Forms.NumericUpDown();
			this.labelMaxBandwidthUnit = new System.Windows.Forms.Label();
			this.labelMinBandwidthUnit = new System.Windows.Forms.Label();
			this.labelMaxSizeNonguaranteedUnit = new System.Windows.Forms.Label();
			this.labelMaxSizeGuaranteedUnit = new System.Windows.Forms.Label();
			this.labelMinErrtoSendNear = new System.Windows.Forms.Label();
			this.labelMinErrtoSend = new System.Windows.Forms.Label();
			this.labelMaxBandwidth = new System.Windows.Forms.Label();
			this.labelMinBandwidth = new System.Windows.Forms.Label();
			this.labelMaxSizeNonguaranteed = new System.Windows.Forms.Label();
			this.labelMaxSizeGuaranteed = new System.Windows.Forms.Label();
			this.labelMaxMsgSent = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)this.container1).BeginInit();
			this.container1.Panel1.SuspendLayout();
			this.container1.Panel2.SuspendLayout();
			this.container1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.container2).BeginInit();
			this.container2.Panel1.SuspendLayout();
			this.container2.Panel2.SuspendLayout();
			this.container2.SuspendLayout();
			this.container2_2.SuspendLayout();
			this.tab2.SuspendLayout();
			this.tab2Page2.SuspendLayout();
			this.groupLogin.SuspendLayout();
			this.tab2Page3.SuspendLayout();
			this.container2_4.SuspendLayout();
			this.groupSettings.SuspendLayout();
			this.groupAbout.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.pictureLicense).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.pictureIcon).BeginInit();
			this.container2_3.SuspendLayout();
			this.tab3.SuspendLayout();
			this.tab3Page2.SuspendLayout();
			this.groupSurvivor.SuspendLayout();
			this.groupProfile.SuspendLayout();
			this.tab3Page3.SuspendLayout();
			this.groupReset.SuspendLayout();
			this.groupAutoBackup.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.numBackupInterval).BeginInit();
			this.groupRestore.SuspendLayout();
			this.groupBackup.SuspendLayout();
			this.container2_1.SuspendLayout();
			this.tab1.SuspendLayout();
			this.tab1Page1.SuspendLayout();
			this.groupTime.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.trackTimezone).BeginInit();
			this.groupTemplate.SuspendLayout();
			this.groupVon.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.numVonQuality).BeginInit();
			this.groupMessage.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.numMessageInterval).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.numMaxPlayers).BeginInit();
			this.tab1Page2.SuspendLayout();
			this.groupWhitelist.SuspendLayout();
			this.groupSignatures.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.numSecureId).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.numVerifySignatures).BeginInit();
			this.groupScripting.SuspendLayout();
			this.groupBattleye.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.numMaxPing).BeginInit();
			this.tab1Page3.SuspendLayout();
			this.groupAdditional.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.numMaxCustomsize).BeginInit();
			this.groupNetwork.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.numMaxBandwidth).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.numMinBandwidth).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.numMaxMessages).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.numMaxSizeGuaranteed).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.numMaxSizeNonguaranteed).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.numMinErrorNear).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.numMinError).BeginInit();
			base.SuspendLayout();
			this.timerMonitor.Interval = 1000;
			this.timerMonitor.Tick += new System.EventHandler(timerMonitor_Tick);
			this.container1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.container1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.container1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.container1.IsSplitterFixed = true;
			this.container1.Location = new System.Drawing.Point(0, 0);
			this.container1.Name = "container1";
			this.container1.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
			this.container1.Panel1.Controls.Add(this.btnLog);
			this.container1.Panel1.Controls.Add(this.btnExit);
			this.container1.Panel1.Controls.Add(this.cbxInstance);
			this.container1.Panel1.Controls.Add(this.labelSelectInstance);
			this.container1.Panel1.Controls.Add(this.labelDescription4);
			this.container1.Panel1.Controls.Add(this.labelDescription2);
			this.container1.Panel1.Controls.Add(this.labelDescription3);
			this.container1.Panel1.Controls.Add(this.labelDescription1);
			this.container1.Panel1.Controls.Add(this.btnMenu4);
			this.container1.Panel1.Controls.Add(this.btnMenu2);
			this.container1.Panel1.Controls.Add(this.btnMenu3);
			this.container1.Panel1.Controls.Add(this.btnMenu1);
			this.container1.Panel2.Controls.Add(this.container2);
			this.container1.Size = new System.Drawing.Size(884, 612);
			this.container1.SplitterDistance = 160;
			this.container1.SplitterWidth = 2;
			this.container1.TabIndex = 0;
			this.container1.TabStop = false;
			this.btnLog.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.btnLog.Appearance = System.Windows.Forms.Appearance.Button;
			this.btnLog.Location = new System.Drawing.Point(11, 551);
			this.btnLog.Name = "btnLog";
			this.btnLog.Size = new System.Drawing.Size(139, 24);
			this.btnLog.TabIndex = 16;
			this.btnLog.Text = Crosire.Controlcenter.Properties.Resources.button_log;
			this.btnLog.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.btnLog.UseVisualStyleBackColor = true;
			this.btnLog.CheckedChanged += new System.EventHandler(btnLog_CheckedChanged);
			this.btnExit.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.btnExit.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnExit.Location = new System.Drawing.Point(11, 579);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(138, 23);
			this.btnExit.TabIndex = 2;
			this.btnExit.Text = Crosire.Controlcenter.Properties.Resources.button_exit;
			this.btnExit.UseVisualStyleBackColor = true;
			this.btnExit.Click += new System.EventHandler(btnExit_Click);
			this.cbxInstance.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.cbxInstance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxInstance.FormattingEnabled = true;
			this.cbxInstance.Items.AddRange(new object[6] { "1", "2", "3", "4", "5", "6" });
			this.cbxInstance.Location = new System.Drawing.Point(12, 524);
			this.cbxInstance.MaxDropDownItems = 9;
			this.cbxInstance.Name = "cbxInstance";
			this.cbxInstance.Size = new System.Drawing.Size(138, 21);
			this.cbxInstance.TabIndex = 0;
			this.cbxInstance.SelectedIndexChanged += new System.EventHandler(frmMain_ChangeInstance);
			this.labelSelectInstance.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			this.labelSelectInstance.AutoSize = true;
			this.labelSelectInstance.Location = new System.Drawing.Point(9, 508);
			this.labelSelectInstance.Name = "labelSelectInstance";
			this.labelSelectInstance.Size = new System.Drawing.Size(137, 13);
			this.labelSelectInstance.TabIndex = 1;
			this.labelSelectInstance.Text = "Server instance to manage:";
			this.labelDescription4.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75f);
			this.labelDescription4.Location = new System.Drawing.Point(11, 392);
			this.labelDescription4.Name = "labelDescription4";
			this.labelDescription4.Size = new System.Drawing.Size(139, 90);
			this.labelDescription4.TabIndex = 15;
			this.labelDescription4.Text = "Description";
			this.labelDescription2.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75f);
			this.labelDescription2.Location = new System.Drawing.Point(11, 152);
			this.labelDescription2.Name = "labelDescription2";
			this.labelDescription2.Size = new System.Drawing.Size(139, 90);
			this.labelDescription2.TabIndex = 14;
			this.labelDescription2.Text = "Description";
			this.labelDescription3.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75f);
			this.labelDescription3.Location = new System.Drawing.Point(11, 267);
			this.labelDescription3.Name = "labelDescription3";
			this.labelDescription3.Size = new System.Drawing.Size(139, 90);
			this.labelDescription3.TabIndex = 13;
			this.labelDescription3.Text = "Description";
			this.labelDescription1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75f);
			this.labelDescription1.Location = new System.Drawing.Point(11, 37);
			this.labelDescription1.Name = "labelDescription1";
			this.labelDescription1.Size = new System.Drawing.Size(139, 90);
			this.labelDescription1.TabIndex = 12;
			this.labelDescription1.Text = "Description";
			this.btnMenu4.Appearance = System.Windows.Forms.Appearance.Button;
			this.btnMenu4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold);
			this.btnMenu4.Location = new System.Drawing.Point(11, 366);
			this.btnMenu4.Name = "btnMenu4";
			this.btnMenu4.Size = new System.Drawing.Size(138, 23);
			this.btnMenu4.TabIndex = 11;
			this.btnMenu4.Text = Crosire.Controlcenter.Properties.Resources.button_menu4;
			this.btnMenu4.CheckedChanged += new System.EventHandler(frmMain_ChangePanel);
			this.btnMenu2.Appearance = System.Windows.Forms.Appearance.Button;
			this.btnMenu2.Checked = true;
			this.btnMenu2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold);
			this.btnMenu2.Location = new System.Drawing.Point(11, 126);
			this.btnMenu2.Name = "btnMenu2";
			this.btnMenu2.Size = new System.Drawing.Size(138, 23);
			this.btnMenu2.TabIndex = 10;
			this.btnMenu2.TabStop = true;
			this.btnMenu2.Text = Crosire.Controlcenter.Properties.Resources.button_menu2;
			this.btnMenu2.UseVisualStyleBackColor = true;
			this.btnMenu2.CheckedChanged += new System.EventHandler(frmMain_ChangePanel);
			this.btnMenu3.Appearance = System.Windows.Forms.Appearance.Button;
			this.btnMenu3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold);
			this.btnMenu3.Location = new System.Drawing.Point(11, 241);
			this.btnMenu3.Name = "btnMenu3";
			this.btnMenu3.Size = new System.Drawing.Size(138, 23);
			this.btnMenu3.TabIndex = 9;
			this.btnMenu3.Text = Crosire.Controlcenter.Properties.Resources.button_menu3;
			this.btnMenu3.CheckedChanged += new System.EventHandler(frmMain_ChangePanel);
			this.btnMenu1.Appearance = System.Windows.Forms.Appearance.Button;
			this.btnMenu1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold);
			this.btnMenu1.Location = new System.Drawing.Point(11, 11);
			this.btnMenu1.Name = "btnMenu1";
			this.btnMenu1.Size = new System.Drawing.Size(138, 23);
			this.btnMenu1.TabIndex = 8;
			this.btnMenu1.Text = Crosire.Controlcenter.Properties.Resources.button_menu1;
			this.btnMenu1.CheckedChanged += new System.EventHandler(frmMain_ChangePanel);
			this.container2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.container2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.container2.IsSplitterFixed = true;
			this.container2.Location = new System.Drawing.Point(0, 0);
			this.container2.Name = "container2";
			this.container2.Orientation = System.Windows.Forms.Orientation.Horizontal;
			this.container2.Panel1.Controls.Add(this.textLog);
			this.container2.Panel1Collapsed = true;
			this.container2.Panel1MinSize = 0;
			this.container2.Panel2.Controls.Add(this.container2_2);
			this.container2.Panel2.Controls.Add(this.container2_4);
			this.container2.Panel2.Controls.Add(this.container2_3);
			this.container2.Panel2.Controls.Add(this.container2_1);
			this.container2.Panel2MinSize = 0;
			this.container2.Size = new System.Drawing.Size(720, 610);
			this.container2.SplitterDistance = 96;
			this.container2.TabIndex = 1;
			this.textLog.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textLog.Location = new System.Drawing.Point(0, 0);
			this.textLog.Name = "textLog";
			this.textLog.ReadOnly = true;
			this.textLog.Size = new System.Drawing.Size(150, 96);
			this.textLog.TabIndex = 0;
			this.textLog.Text = "";
			this.container2_2.Controls.Add(this.tab2);
			this.container2_2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.container2_2.Location = new System.Drawing.Point(0, 0);
			this.container2_2.Name = "container2_2";
			this.container2_2.Size = new System.Drawing.Size(720, 610);
			this.container2_2.TabIndex = 3;
			this.tab2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.tab2.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
			this.tab2.Controls.Add(this.tab2Page1);
			this.tab2.Controls.Add(this.tab2Page2);
			this.tab2.Controls.Add(this.tab2Page3);
			this.tab2.ItemSize = new System.Drawing.Size(100, 21);
			this.tab2.Location = new System.Drawing.Point(0, 0);
			this.tab2.Name = "tab2";
			this.tab2.SelectedIndex = 0;
			this.tab2.Size = new System.Drawing.Size(721, 610);
			this.tab2.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
			this.tab2.TabIndex = 0;
			this.tab2Page1.Location = new System.Drawing.Point(4, 25);
			this.tab2Page1.Name = "tab2Page1";
			this.tab2Page1.Padding = new System.Windows.Forms.Padding(3);
			this.tab2Page1.Size = new System.Drawing.Size(713, 581);
			this.tab2Page1.TabIndex = 0;
			this.tab2Page1.Text = "Manage";
			this.tab2Page1.UseVisualStyleBackColor = true;
			this.tab2Page2.Controls.Add(this.groupLogin);
			this.tab2Page2.Location = new System.Drawing.Point(4, 25);
			this.tab2Page2.Name = "tab2Page2";
			this.tab2Page2.Size = new System.Drawing.Size(713, 581);
			this.tab2Page2.TabIndex = 4;
			this.tab2Page2.Text = "Server";
			this.tab2Page2.UseVisualStyleBackColor = true;
			this.groupLogin.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.groupLogin.Controls.Add(this.labelMySqlCredentials);
			this.groupLogin.Controls.Add(this.btnMysqlHost);
			this.groupLogin.Controls.Add(this.textMysqlUser);
			this.groupLogin.Controls.Add(this.btnMysqlUser);
			this.groupLogin.Controls.Add(this.textMysqlPass);
			this.groupLogin.Controls.Add(this.labelMysqlPoint);
			this.groupLogin.Controls.Add(this.labelMySqlHost);
			this.groupLogin.Controls.Add(this.textMysqlPort);
			this.groupLogin.Controls.Add(this.textMysqlHost);
			this.groupLogin.Location = new System.Drawing.Point(9, 7);
			this.groupLogin.Name = "groupLogin";
			this.groupLogin.Size = new System.Drawing.Size(690, 126);
			this.groupLogin.TabIndex = 6;
			this.groupLogin.TabStop = false;
			this.groupLogin.Text = "Login information";
			this.labelMySqlCredentials.AutoSize = true;
			this.labelMySqlCredentials.Location = new System.Drawing.Point(6, 72);
			this.labelMySqlCredentials.Name = "labelMySqlCredentials";
			this.labelMySqlCredentials.Size = new System.Drawing.Size(100, 13);
			this.labelMySqlCredentials.TabIndex = 11;
			this.labelMySqlCredentials.Text = "MySQL Credentials:";
			this.btnMysqlHost.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.btnMysqlHost.Location = new System.Drawing.Point(488, 40);
			this.btnMysqlHost.Name = "btnMysqlHost";
			this.btnMysqlHost.Size = new System.Drawing.Size(194, 23);
			this.btnMysqlHost.TabIndex = 6;
			this.btnMysqlHost.Text = Crosire.Controlcenter.Properties.Resources.button_save;
			this.btnMysqlHost.UseVisualStyleBackColor = true;
			this.btnMysqlHost.Click += new System.EventHandler(btnMysqlHost_Click);
			this.textMysqlUser.Location = new System.Drawing.Point(9, 92);
			this.textMysqlUser.MaxLength = 16;
			this.textMysqlUser.Name = "textMysqlUser";
			this.textMysqlUser.Size = new System.Drawing.Size(190, 20);
			this.textMysqlUser.TabIndex = 10;
			this.textMysqlUser.Text = "dayz";
			this.btnMysqlUser.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.btnMysqlUser.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.btnMysqlUser.Location = new System.Drawing.Point(488, 90);
			this.btnMysqlUser.Name = "btnMysqlUser";
			this.btnMysqlUser.Size = new System.Drawing.Size(194, 23);
			this.btnMysqlUser.TabIndex = 1;
			this.btnMysqlUser.Text = "Save";
			this.btnMysqlUser.UseVisualStyleBackColor = true;
			this.btnMysqlUser.Click += new System.EventHandler(btnMysqlUser_Click);
			this.textMysqlPass.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.textMysqlPass.Location = new System.Drawing.Point(221, 92);
			this.textMysqlPass.MaxLength = 100;
			this.textMysqlPass.Name = "textMysqlPass";
			this.textMysqlPass.Size = new System.Drawing.Size(261, 20);
			this.textMysqlPass.TabIndex = 2;
			this.textMysqlPass.UseSystemPasswordChar = true;
			this.labelMysqlPoint.AutoSize = true;
			this.labelMysqlPoint.Location = new System.Drawing.Point(206, 45);
			this.labelMysqlPoint.Name = "labelMysqlPoint";
			this.labelMysqlPoint.Size = new System.Drawing.Size(10, 13);
			this.labelMysqlPoint.TabIndex = 8;
			this.labelMysqlPoint.Text = ":";
			this.labelMySqlHost.AutoSize = true;
			this.labelMySqlHost.Location = new System.Drawing.Point(6, 22);
			this.labelMySqlHost.Name = "labelMySqlHost";
			this.labelMySqlHost.Size = new System.Drawing.Size(111, 13);
			this.labelMySqlHost.TabIndex = 4;
			this.labelMySqlHost.Text = "MySQL Host Address:";
			this.textMysqlPort.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.textMysqlPort.Location = new System.Drawing.Point(222, 42);
			this.textMysqlPort.MaxLength = 10;
			this.textMysqlPort.Name = "textMysqlPort";
			this.textMysqlPort.Size = new System.Drawing.Size(260, 20);
			this.textMysqlPort.TabIndex = 5;
			this.textMysqlPort.Text = "3306";
			this.textMysqlHost.Location = new System.Drawing.Point(9, 42);
			this.textMysqlHost.MaxLength = 32;
			this.textMysqlHost.Name = "textMysqlHost";
			this.textMysqlHost.Size = new System.Drawing.Size(191, 20);
			this.textMysqlHost.TabIndex = 5;
			this.textMysqlHost.Text = "127.0.0.1";
			this.tab2Page3.Controls.Add(this.btnLogClear);
			this.tab2Page3.Controls.Add(this.btnLogMonitor);
			this.tab2Page3.Controls.Add(this.textLogRpt);
			this.tab2Page3.Location = new System.Drawing.Point(4, 25);
			this.tab2Page3.Name = "tab2Page3";
			this.tab2Page3.Size = new System.Drawing.Size(713, 581);
			this.tab2Page3.TabIndex = 3;
			this.tab2Page3.Text = Crosire.Controlcenter.Properties.Resources.tab2_page3;
			this.tab2Page3.UseVisualStyleBackColor = true;
			this.btnLogClear.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.btnLogClear.Location = new System.Drawing.Point(599, 5);
			this.btnLogClear.Name = "btnLogClear";
			this.btnLogClear.Size = new System.Drawing.Size(108, 15);
			this.btnLogClear.TabIndex = 4;
			this.btnLogClear.TabStop = true;
			this.btnLogClear.Text = "Clear";
			this.btnLogClear.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.btnLogClear.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(btnLogClear_LinkClicked);
			this.btnLogMonitor.AutoSize = true;
			this.btnLogMonitor.Location = new System.Drawing.Point(6, 5);
			this.btnLogMonitor.Name = "btnLogMonitor";
			this.btnLogMonitor.Size = new System.Drawing.Size(146, 13);
			this.btnLogMonitor.TabIndex = 2;
			this.btnLogMonitor.TabStop = true;
			this.btnLogMonitor.Text = "Start Realtime Log Monitoring";
			this.btnLogMonitor.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(btnLogMonitor_LinkClicked);
			this.textLogRpt.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.textLogRpt.Location = new System.Drawing.Point(6, 23);
			this.textLogRpt.Name = "textLogRpt";
			this.textLogRpt.ReadOnly = true;
			this.textLogRpt.Size = new System.Drawing.Size(701, 551);
			this.textLogRpt.TabIndex = 0;
			this.textLogRpt.Text = "";
			this.textLogRpt.WordWrap = false;
			this.container2_4.Controls.Add(this.groupSettings);
			this.container2_4.Controls.Add(this.groupAbout);
			this.container2_4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.container2_4.Location = new System.Drawing.Point(0, 0);
			this.container2_4.Name = "container2_4";
			this.container2_4.Size = new System.Drawing.Size(720, 610);
			this.container2_4.TabIndex = 4;
			this.groupSettings.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.groupSettings.Controls.Add(this.cbxLanguage);
			this.groupSettings.Controls.Add(this.labelChooseLanguage);
			this.groupSettings.Location = new System.Drawing.Point(10, 116);
			this.groupSettings.Name = "groupSettings";
			this.groupSettings.Size = new System.Drawing.Size(699, 57);
			this.groupSettings.TabIndex = 2;
			this.groupSettings.TabStop = false;
			this.groupSettings.Text = "Settings";
			this.cbxLanguage.DropDownHeight = 200;
			this.cbxLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxLanguage.DropDownWidth = 14;
			this.cbxLanguage.FormattingEnabled = true;
			this.cbxLanguage.IntegralHeight = false;
			this.cbxLanguage.ItemHeight = 13;
			this.cbxLanguage.Items.AddRange(new object[9] { "en", "es", "de", "da", "fr", "pt", "pt-br", "ru", "zh-cn" });
			this.cbxLanguage.Location = new System.Drawing.Point(128, 19);
			this.cbxLanguage.Name = "cbxLanguage";
			this.cbxLanguage.Size = new System.Drawing.Size(65, 21);
			this.cbxLanguage.TabIndex = 1;
			this.cbxLanguage.DropDownClosed += new System.EventHandler(cbxLanguage_DropDownClosed);
			this.labelChooseLanguage.AutoSize = true;
			this.labelChooseLanguage.Location = new System.Drawing.Point(6, 22);
			this.labelChooseLanguage.Name = "labelChooseLanguage";
			this.labelChooseLanguage.Size = new System.Drawing.Size(116, 13);
			this.labelChooseLanguage.TabIndex = 0;
			this.labelChooseLanguage.Text = "Choose your language:";
			this.groupAbout.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.groupAbout.Controls.Add(this.pictureLicense);
			this.groupAbout.Controls.Add(this.labelAppName);
			this.groupAbout.Controls.Add(this.labelVersionText);
			this.groupAbout.Controls.Add(this.pictureIcon);
			this.groupAbout.Controls.Add(this.labelVersion);
			this.groupAbout.Location = new System.Drawing.Point(10, 11);
			this.groupAbout.Name = "groupAbout";
			this.groupAbout.Size = new System.Drawing.Size(699, 99);
			this.groupAbout.TabIndex = 0;
			this.groupAbout.TabStop = false;
			this.groupAbout.Text = "About";
			this.pictureLicense.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.pictureLicense.Image = Crosire.Controlcenter.Properties.Resources.license;
			this.pictureLicense.Location = new System.Drawing.Point(588, 21);
			this.pictureLicense.Name = "pictureLicense";
			this.pictureLicense.Size = new System.Drawing.Size(100, 64);
			this.pictureLicense.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.pictureLicense.TabIndex = 6;
			this.pictureLicense.TabStop = false;
			this.pictureLicense.Click += new System.EventHandler(pictureLicense_Click);
			this.labelAppName.AutoSize = true;
			this.labelAppName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10f, System.Drawing.FontStyle.Bold);
			this.labelAppName.Location = new System.Drawing.Point(81, 19);
			this.labelAppName.Name = "labelAppName";
			this.labelAppName.Size = new System.Drawing.Size(281, 17);
			this.labelAppName.TabIndex = 5;
			this.labelAppName.TabStop = true;
			this.labelAppName.Text = "DayZ Server Controlcenter by Crosire";
			this.labelVersionText.AutoSize = true;
			this.labelVersionText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f);
			this.labelVersionText.Location = new System.Drawing.Point(81, 45);
			this.labelVersionText.Name = "labelVersionText";
			this.labelVersionText.Size = new System.Drawing.Size(57, 16);
			this.labelVersionText.TabIndex = 1;
			this.labelVersionText.Text = "Version:";
			this.pictureIcon.BackgroundImage = Crosire.Controlcenter.Properties.Resources.logo;
			this.pictureIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.pictureIcon.Location = new System.Drawing.Point(11, 21);
			this.pictureIcon.Name = "pictureIcon";
			this.pictureIcon.Size = new System.Drawing.Size(64, 64);
			this.pictureIcon.TabIndex = 3;
			this.pictureIcon.TabStop = false;
			this.pictureIcon.Click += new System.EventHandler(pictureIcon_Click);
			this.labelVersion.AutoSize = true;
			this.labelVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f);
			this.labelVersion.Location = new System.Drawing.Point(169, 45);
			this.labelVersion.Name = "labelVersion";
			this.labelVersion.Size = new System.Drawing.Size(0, 16);
			this.labelVersion.TabIndex = 1;
			this.container2_3.Controls.Add(this.tab3);
			this.container2_3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.container2_3.Location = new System.Drawing.Point(0, 0);
			this.container2_3.Name = "container2_3";
			this.container2_3.Size = new System.Drawing.Size(720, 610);
			this.container2_3.TabIndex = 1;
			this.tab3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.tab3.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
			this.tab3.Controls.Add(this.tab3Page1);
			this.tab3.Controls.Add(this.tab3Page2);
			this.tab3.Controls.Add(this.tab3Page3);
			this.tab3.ItemSize = new System.Drawing.Size(100, 21);
			this.tab3.Location = new System.Drawing.Point(0, 0);
			this.tab3.Name = "tab3";
			this.tab3.SelectedIndex = 0;
			this.tab3.Size = new System.Drawing.Size(721, 610);
			this.tab3.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
			this.tab3.TabIndex = 1;
			this.tab3Page1.Location = new System.Drawing.Point(4, 25);
			this.tab3Page1.Name = "tab3Page1";
			this.tab3Page1.Padding = new System.Windows.Forms.Padding(3);
			this.tab3Page1.Size = new System.Drawing.Size(713, 581);
			this.tab3Page1.TabIndex = 1;
			this.tab3Page1.Text = Crosire.Controlcenter.Properties.Resources.tab3_page1;
			this.tab3Page1.UseVisualStyleBackColor = true;
			this.tab3Page2.Controls.Add(this.checkWhitelisted);
			this.tab3Page2.Controls.Add(this.groupSurvivor);
			this.tab3Page2.Controls.Add(this.listPlayers);
			this.tab3Page2.Controls.Add(this.groupProfile);
			this.tab3Page2.Controls.Add(this.btnPlayerAdd);
			this.tab3Page2.Controls.Add(this.btnSave4);
			this.tab3Page2.Location = new System.Drawing.Point(4, 25);
			this.tab3Page2.Name = "tab3Page2";
			this.tab3Page2.Size = new System.Drawing.Size(713, 581);
			this.tab3Page2.TabIndex = 2;
			this.tab3Page2.Text = "Players";
			this.tab3Page2.UseVisualStyleBackColor = true;
			this.checkWhitelisted.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.checkWhitelisted.Appearance = System.Windows.Forms.Appearance.Button;
			this.checkWhitelisted.Location = new System.Drawing.Point(193, 251);
			this.checkWhitelisted.Name = "checkWhitelisted";
			this.checkWhitelisted.Size = new System.Drawing.Size(250, 23);
			this.checkWhitelisted.TabIndex = 24;
			this.checkWhitelisted.Text = "Whitelisted";
			this.checkWhitelisted.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.checkWhitelisted.UseVisualStyleBackColor = true;
			this.groupSurvivor.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.groupSurvivor.Controls.Add(this.textMedical);
			this.groupSurvivor.Controls.Add(this.labelMedical);
			this.groupSurvivor.Controls.Add(this.textPosition);
			this.groupSurvivor.Controls.Add(this.labelPosition);
			this.groupSurvivor.Controls.Add(this.textBackpack);
			this.groupSurvivor.Controls.Add(this.labelBackpack);
			this.groupSurvivor.Controls.Add(this.textInventory);
			this.groupSurvivor.Controls.Add(this.labelInventory);
			this.groupSurvivor.Enabled = false;
			this.groupSurvivor.Location = new System.Drawing.Point(9, 398);
			this.groupSurvivor.Name = "groupSurvivor";
			this.groupSurvivor.Size = new System.Drawing.Size(690, 141);
			this.groupSurvivor.TabIndex = 22;
			this.groupSurvivor.TabStop = false;
			this.groupSurvivor.Text = "Survivor";
			this.textMedical.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.textMedical.Location = new System.Drawing.Point(89, 109);
			this.textMedical.Name = "textMedical";
			this.textMedical.Size = new System.Drawing.Size(591, 20);
			this.textMedical.TabIndex = 12;
			this.labelMedical.AutoSize = true;
			this.labelMedical.Location = new System.Drawing.Point(6, 112);
			this.labelMedical.Name = "labelMedical";
			this.labelMedical.Size = new System.Drawing.Size(47, 13);
			this.labelMedical.TabIndex = 11;
			this.labelMedical.Text = "Medical:";
			this.textPosition.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.textPosition.Location = new System.Drawing.Point(89, 79);
			this.textPosition.Name = "textPosition";
			this.textPosition.Size = new System.Drawing.Size(591, 20);
			this.textPosition.TabIndex = 9;
			this.labelPosition.AutoSize = true;
			this.labelPosition.Location = new System.Drawing.Point(6, 82);
			this.labelPosition.Name = "labelPosition";
			this.labelPosition.Size = new System.Drawing.Size(47, 13);
			this.labelPosition.TabIndex = 8;
			this.labelPosition.Text = "Position:";
			this.textBackpack.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.textBackpack.Location = new System.Drawing.Point(89, 49);
			this.textBackpack.Name = "textBackpack";
			this.textBackpack.Size = new System.Drawing.Size(591, 20);
			this.textBackpack.TabIndex = 5;
			this.labelBackpack.AutoSize = true;
			this.labelBackpack.Location = new System.Drawing.Point(6, 52);
			this.labelBackpack.Name = "labelBackpack";
			this.labelBackpack.Size = new System.Drawing.Size(59, 13);
			this.labelBackpack.TabIndex = 4;
			this.labelBackpack.Text = "Backpack:";
			this.textInventory.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.textInventory.Location = new System.Drawing.Point(89, 19);
			this.textInventory.Name = "textInventory";
			this.textInventory.Size = new System.Drawing.Size(591, 20);
			this.textInventory.TabIndex = 3;
			this.labelInventory.AutoSize = true;
			this.labelInventory.Location = new System.Drawing.Point(6, 22);
			this.labelInventory.Name = "labelInventory";
			this.labelInventory.Size = new System.Drawing.Size(54, 13);
			this.labelInventory.TabIndex = 2;
			this.labelInventory.Text = "Inventory:";
			this.listPlayers.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.listPlayers.FormattingEnabled = true;
			this.listPlayers.Location = new System.Drawing.Point(9, 7);
			this.listPlayers.Name = "listPlayers";
			this.listPlayers.ScrollAlwaysVisible = true;
			this.listPlayers.Size = new System.Drawing.Size(690, 238);
			this.listPlayers.Sorted = true;
			this.listPlayers.TabIndex = 1;
			this.listPlayers.SelectedIndexChanged += new System.EventHandler(listPlayers_SelectedIndexChanged);
			this.groupProfile.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.groupProfile.Controls.Add(this.textPlayerGuid);
			this.groupProfile.Controls.Add(this.labelPlayerGuid);
			this.groupProfile.Controls.Add(this.textPlayerUid);
			this.groupProfile.Controls.Add(this.labelPlayerUid);
			this.groupProfile.Controls.Add(this.textPlayerName);
			this.groupProfile.Controls.Add(this.labelPlayerName);
			this.groupProfile.Location = new System.Drawing.Point(9, 280);
			this.groupProfile.Name = "groupProfile";
			this.groupProfile.Size = new System.Drawing.Size(690, 112);
			this.groupProfile.TabIndex = 3;
			this.groupProfile.TabStop = false;
			this.groupProfile.Text = "Profile";
			this.textPlayerGuid.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.textPlayerGuid.Location = new System.Drawing.Point(89, 79);
			this.textPlayerGuid.MaxLength = 32;
			this.textPlayerGuid.Name = "textPlayerGuid";
			this.textPlayerGuid.Size = new System.Drawing.Size(591, 20);
			this.textPlayerGuid.TabIndex = 27;
			this.labelPlayerGuid.AutoSize = true;
			this.labelPlayerGuid.Location = new System.Drawing.Point(6, 82);
			this.labelPlayerGuid.Name = "labelPlayerGuid";
			this.labelPlayerGuid.Size = new System.Drawing.Size(37, 13);
			this.labelPlayerGuid.TabIndex = 26;
			this.labelPlayerGuid.Text = "GUID:";
			this.textPlayerUid.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.textPlayerUid.Enabled = false;
			this.textPlayerUid.Location = new System.Drawing.Point(89, 49);
			this.textPlayerUid.MaxLength = 128;
			this.textPlayerUid.Name = "textPlayerUid";
			this.textPlayerUid.Size = new System.Drawing.Size(591, 20);
			this.textPlayerUid.TabIndex = 25;
			this.labelPlayerUid.AutoSize = true;
			this.labelPlayerUid.Location = new System.Drawing.Point(6, 52);
			this.labelPlayerUid.Name = "labelPlayerUid";
			this.labelPlayerUid.Size = new System.Drawing.Size(29, 13);
			this.labelPlayerUid.TabIndex = 24;
			this.labelPlayerUid.Text = "UID:";
			this.textPlayerName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.textPlayerName.Location = new System.Drawing.Point(89, 19);
			this.textPlayerName.MaxLength = 64;
			this.textPlayerName.Name = "textPlayerName";
			this.textPlayerName.Size = new System.Drawing.Size(591, 20);
			this.textPlayerName.TabIndex = 23;
			this.labelPlayerName.AutoSize = true;
			this.labelPlayerName.Location = new System.Drawing.Point(6, 22);
			this.labelPlayerName.Name = "labelPlayerName";
			this.labelPlayerName.Size = new System.Drawing.Size(38, 13);
			this.labelPlayerName.TabIndex = 22;
			this.labelPlayerName.Text = "Name:";
			this.btnPlayerAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.btnPlayerAdd.Location = new System.Drawing.Point(449, 251);
			this.btnPlayerAdd.Name = "btnPlayerAdd";
			this.btnPlayerAdd.Size = new System.Drawing.Size(250, 23);
			this.btnPlayerAdd.TabIndex = 20;
			this.btnPlayerAdd.Text = Crosire.Controlcenter.Properties.Resources.button_add_player;
			this.btnPlayerAdd.UseVisualStyleBackColor = true;
			this.btnPlayerAdd.Click += new System.EventHandler(btnPlayer_Click);
			this.btnSave4.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.btnSave4.Location = new System.Drawing.Point(449, 545);
			this.btnSave4.Name = "btnSave4";
			this.btnSave4.Size = new System.Drawing.Size(250, 23);
			this.btnSave4.TabIndex = 23;
			this.btnSave4.Text = "Save configuration";
			this.btnSave4.UseVisualStyleBackColor = true;
			this.btnSave4.Click += new System.EventHandler(btnSave4_Click);
			this.tab3Page3.Controls.Add(this.groupReset);
			this.tab3Page3.Controls.Add(this.groupAutoBackup);
			this.tab3Page3.Controls.Add(this.groupRestore);
			this.tab3Page3.Controls.Add(this.groupBackup);
			this.tab3Page3.Location = new System.Drawing.Point(4, 25);
			this.tab3Page3.Name = "tab3Page3";
			this.tab3Page3.Padding = new System.Windows.Forms.Padding(3);
			this.tab3Page3.Size = new System.Drawing.Size(713, 581);
			this.tab3Page3.TabIndex = 3;
			this.tab3Page3.Text = "Backup";
			this.tab3Page3.UseVisualStyleBackColor = true;
			this.groupReset.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.groupReset.Controls.Add(this.labelNoticeReset);
			this.groupReset.Controls.Add(this.btnReset);
			this.groupReset.Location = new System.Drawing.Point(9, 236);
			this.groupReset.Name = "groupReset";
			this.groupReset.Size = new System.Drawing.Size(690, 100);
			this.groupReset.TabIndex = 6;
			this.groupReset.TabStop = false;
			this.groupReset.Text = "Reset";
			this.labelNoticeReset.AutoSize = true;
			this.labelNoticeReset.Location = new System.Drawing.Point(7, 19);
			this.labelNoticeReset.Name = "labelNoticeReset";
			this.labelNoticeReset.Size = new System.Drawing.Size(246, 13);
			this.labelNoticeReset.TabIndex = 5;
			this.labelNoticeReset.Text = "Notice: Warning! This deletes the whole database!";
			this.btnReset.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.btnReset.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.btnReset.Location = new System.Drawing.Point(9, 38);
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new System.Drawing.Size(671, 50);
			this.btnReset.TabIndex = 4;
			this.btnReset.Text = Crosire.Controlcenter.Properties.Resources.button_reset;
			this.btnReset.UseVisualStyleBackColor = true;
			this.btnReset.Click += new System.EventHandler(btnReset_Click);
			this.groupAutoBackup.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.groupAutoBackup.Controls.Add(this.progressBackup);
			this.groupAutoBackup.Controls.Add(this.btnAutoBackup);
			this.groupAutoBackup.Controls.Add(this.numBackupInterval);
			this.groupAutoBackup.Controls.Add(this.labelEnterBackupInterval);
			this.groupAutoBackup.Location = new System.Drawing.Point(9, 342);
			this.groupAutoBackup.Name = "groupAutoBackup";
			this.groupAutoBackup.Size = new System.Drawing.Size(690, 160);
			this.groupAutoBackup.TabIndex = 4;
			this.groupAutoBackup.TabStop = false;
			this.groupAutoBackup.Text = "Auto Backup";
			this.progressBackup.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.progressBackup.Location = new System.Drawing.Point(10, 124);
			this.progressBackup.Name = "progressBackup";
			this.progressBackup.Size = new System.Drawing.Size(670, 23);
			this.progressBackup.TabIndex = 6;
			this.btnAutoBackup.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.btnAutoBackup.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.btnAutoBackup.Location = new System.Drawing.Point(9, 68);
			this.btnAutoBackup.Name = "btnAutoBackup";
			this.btnAutoBackup.Size = new System.Drawing.Size(671, 50);
			this.btnAutoBackup.TabIndex = 4;
			this.btnAutoBackup.Text = Crosire.Controlcenter.Properties.Resources.button_autobackup_start;
			this.btnAutoBackup.UseVisualStyleBackColor = true;
			this.btnAutoBackup.Click += new System.EventHandler(btnAutoBackup_Click);
			this.numBackupInterval.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.numBackupInterval.Location = new System.Drawing.Point(10, 42);
			this.numBackupInterval.Maximum = new decimal(new int[4] { 1000000000, 0, 0, 0 });
			this.numBackupInterval.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
			this.numBackupInterval.Name = "numBackupInterval";
			this.numBackupInterval.Size = new System.Drawing.Size(670, 20);
			this.numBackupInterval.TabIndex = 1;
			this.numBackupInterval.Value = new decimal(new int[4] { 60, 0, 0, 0 });
			this.labelEnterBackupInterval.AutoSize = true;
			this.labelEnterBackupInterval.Location = new System.Drawing.Point(6, 22);
			this.labelEnterBackupInterval.Name = "labelEnterBackupInterval";
			this.labelEnterBackupInterval.Size = new System.Drawing.Size(318, 13);
			this.labelEnterBackupInterval.TabIndex = 0;
			this.labelEnterBackupInterval.Text = "Enter the interval in minutes in which a backup should be created:";
			this.groupRestore.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.groupRestore.Controls.Add(this.btnRestore);
			this.groupRestore.Location = new System.Drawing.Point(9, 145);
			this.groupRestore.Name = "groupRestore";
			this.groupRestore.Size = new System.Drawing.Size(690, 85);
			this.groupRestore.TabIndex = 2;
			this.groupRestore.TabStop = false;
			this.groupRestore.Text = "Restore";
			this.btnRestore.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.btnRestore.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.btnRestore.Location = new System.Drawing.Point(9, 22);
			this.btnRestore.Name = "btnRestore";
			this.btnRestore.Size = new System.Drawing.Size(671, 50);
			this.btnRestore.TabIndex = 2;
			this.btnRestore.Text = Crosire.Controlcenter.Properties.Resources.button_restore;
			this.btnRestore.UseVisualStyleBackColor = true;
			this.btnRestore.Click += new System.EventHandler(btnRestore_Click);
			this.groupBackup.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.groupBackup.Controls.Add(this.btnBackupBrowse);
			this.groupBackup.Controls.Add(this.textBackupPath);
			this.groupBackup.Controls.Add(this.labelPathBackupFolder);
			this.groupBackup.Controls.Add(this.btnBackup);
			this.groupBackup.Location = new System.Drawing.Point(9, 10);
			this.groupBackup.Name = "groupBackup";
			this.groupBackup.Size = new System.Drawing.Size(690, 129);
			this.groupBackup.TabIndex = 1;
			this.groupBackup.TabStop = false;
			this.groupBackup.Text = "Backup";
			this.btnBackupBrowse.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.btnBackupBrowse.Location = new System.Drawing.Point(600, 94);
			this.btnBackupBrowse.Name = "btnBackupBrowse";
			this.btnBackupBrowse.Size = new System.Drawing.Size(80, 23);
			this.btnBackupBrowse.TabIndex = 4;
			this.btnBackupBrowse.Text = Crosire.Controlcenter.Properties.Resources.button_browse;
			this.btnBackupBrowse.UseVisualStyleBackColor = true;
			this.btnBackupBrowse.Click += new System.EventHandler(btnBackupBrowse_Click);
			this.textBackupPath.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.textBackupPath.Location = new System.Drawing.Point(10, 96);
			this.textBackupPath.Name = "textBackupPath";
			this.textBackupPath.Size = new System.Drawing.Size(584, 20);
			this.textBackupPath.TabIndex = 3;
			this.labelPathBackupFolder.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			this.labelPathBackupFolder.AutoSize = true;
			this.labelPathBackupFolder.Location = new System.Drawing.Point(8, 80);
			this.labelPathBackupFolder.Name = "labelPathBackupFolder";
			this.labelPathBackupFolder.Size = new System.Drawing.Size(113, 13);
			this.labelPathBackupFolder.TabIndex = 2;
			this.labelPathBackupFolder.Text = "Path to Backup folder:";
			this.btnBackup.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.btnBackup.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.btnBackup.Location = new System.Drawing.Point(9, 22);
			this.btnBackup.Name = "btnBackup";
			this.btnBackup.Size = new System.Drawing.Size(671, 50);
			this.btnBackup.TabIndex = 0;
			this.btnBackup.Text = Crosire.Controlcenter.Properties.Resources.button_backup;
			this.btnBackup.UseVisualStyleBackColor = true;
			this.btnBackup.Click += new System.EventHandler(btnBackup_Click);
			this.container2_1.Controls.Add(this.tab1);
			this.container2_1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.container2_1.Location = new System.Drawing.Point(0, 0);
			this.container2_1.Name = "container2_1";
			this.container2_1.Size = new System.Drawing.Size(720, 610);
			this.container2_1.TabIndex = 2;
			this.tab1.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
			this.tab1.Controls.Add(this.tab1Page1);
			this.tab1.Controls.Add(this.tab1Page2);
			this.tab1.Controls.Add(this.tab1Page3);
			this.tab1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tab1.ItemSize = new System.Drawing.Size(100, 21);
			this.tab1.Location = new System.Drawing.Point(0, 0);
			this.tab1.Name = "tab1";
			this.tab1.SelectedIndex = 0;
			this.tab1.Size = new System.Drawing.Size(720, 610);
			this.tab1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
			this.tab1.TabIndex = 0;
			this.tab1.TabStop = false;
			this.tab1Page1.Controls.Add(this.btnSave1);
			this.tab1Page1.Controls.Add(this.textBuild);
			this.tab1Page1.Controls.Add(this.textPort);
			this.tab1Page1.Controls.Add(this.groupTime);
			this.tab1Page1.Controls.Add(this.groupTemplate);
			this.tab1Page1.Controls.Add(this.groupVon);
			this.tab1Page1.Controls.Add(this.labelRequiredBuild);
			this.tab1Page1.Controls.Add(this.groupMessage);
			this.tab1Page1.Controls.Add(this.numMaxPlayers);
			this.tab1Page1.Controls.Add(this.labelMaxPlayers);
			this.tab1Page1.Controls.Add(this.cbxReportingIp);
			this.tab1Page1.Controls.Add(this.labelPort);
			this.tab1Page1.Controls.Add(this.labelReportingIp);
			this.tab1Page1.Controls.Add(this.textHostname);
			this.tab1Page1.Controls.Add(this.labelServerName);
			this.tab1Page1.Location = new System.Drawing.Point(4, 25);
			this.tab1Page1.Name = "tab1Page1";
			this.tab1Page1.Padding = new System.Windows.Forms.Padding(3);
			this.tab1Page1.Size = new System.Drawing.Size(712, 581);
			this.tab1Page1.TabIndex = 1;
			this.tab1Page1.Text = Crosire.Controlcenter.Properties.Resources.tab1_page1;
			this.tab1Page1.UseVisualStyleBackColor = true;
			this.btnSave1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.btnSave1.Location = new System.Drawing.Point(449, 545);
			this.btnSave1.Name = "btnSave1";
			this.btnSave1.Size = new System.Drawing.Size(250, 23);
			this.btnSave1.TabIndex = 18;
			this.btnSave1.Text = Crosire.Controlcenter.Properties.Resources.button_save_config;
			this.btnSave1.UseVisualStyleBackColor = true;
			this.btnSave1.Click += new System.EventHandler(btnSave1_Click);
			this.textBuild.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.textBuild.Culture = new System.Globalization.CultureInfo("");
			this.textBuild.Location = new System.Drawing.Point(325, 64);
			this.textBuild.Mask = "000000";
			this.textBuild.Name = "textBuild";
			this.textBuild.Size = new System.Drawing.Size(222, 20);
			this.textBuild.TabIndex = 22;
			this.textBuild.ValidatingType = typeof(int);
			this.textPort.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.textPort.Culture = new System.Globalization.CultureInfo("");
			this.textPort.Location = new System.Drawing.Point(612, 34);
			this.textPort.Mask = "0000";
			this.textPort.Name = "textPort";
			this.textPort.Size = new System.Drawing.Size(87, 20);
			this.textPort.TabIndex = 21;
			this.groupTime.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.groupTime.Controls.Add(this.labelTime);
			this.groupTime.Controls.Add(this.checkDaytime);
			this.groupTime.Controls.Add(this.textTimezone);
			this.groupTime.Controls.Add(this.labelTimezone);
			this.groupTime.Controls.Add(this.trackTimezone);
			this.groupTime.Location = new System.Drawing.Point(9, 460);
			this.groupTime.Name = "groupTime";
			this.groupTime.Size = new System.Drawing.Size(690, 79);
			this.groupTime.TabIndex = 20;
			this.groupTime.TabStop = false;
			this.groupTime.Text = "Time";
			this.labelTime.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.labelTime.AutoSize = true;
			this.labelTime.Location = new System.Drawing.Point(646, 53);
			this.labelTime.Name = "labelTime";
			this.labelTime.Size = new System.Drawing.Size(34, 13);
			this.labelTime.TabIndex = 20;
			this.labelTime.Text = "00:00";
			this.checkDaytime.AutoSize = true;
			this.checkDaytime.Location = new System.Drawing.Point(9, 52);
			this.checkDaytime.Name = "checkDaytime";
			this.checkDaytime.Size = new System.Drawing.Size(88, 17);
			this.checkDaytime.TabIndex = 19;
			this.checkDaytime.Text = "Only Daytime";
			this.checkDaytime.UseVisualStyleBackColor = true;
			this.checkDaytime.CheckedChanged += new System.EventHandler(trackTimezone_Scroll);
			this.textTimezone.AutoSize = true;
			this.textTimezone.Location = new System.Drawing.Point(119, 22);
			this.textTimezone.Name = "textTimezone";
			this.textTimezone.Size = new System.Drawing.Size(44, 13);
			this.textTimezone.TabIndex = 18;
			this.textTimezone.Text = "UTC +0";
			this.labelTimezone.AutoSize = true;
			this.labelTimezone.Location = new System.Drawing.Point(6, 22);
			this.labelTimezone.Name = "labelTimezone";
			this.labelTimezone.Size = new System.Drawing.Size(56, 13);
			this.labelTimezone.TabIndex = 17;
			this.labelTimezone.Text = "Timezone:";
			this.trackTimezone.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.trackTimezone.LargeChange = 2;
			this.trackTimezone.Location = new System.Drawing.Point(169, 19);
			this.trackTimezone.Maximum = 12;
			this.trackTimezone.Minimum = -12;
			this.trackTimezone.Name = "trackTimezone";
			this.trackTimezone.Size = new System.Drawing.Size(512, 45);
			this.trackTimezone.TabIndex = 16;
			this.trackTimezone.Scroll += new System.EventHandler(trackTimezone_Scroll);
			this.groupTemplate.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.groupTemplate.Controls.Add(this.checkRmod);
			this.groupTemplate.Controls.Add(this.btnDatabase);
			this.groupTemplate.Controls.Add(this.cbxDatabase);
			this.groupTemplate.Controls.Add(this.labelSelectDatabase);
			this.groupTemplate.Controls.Add(this.labelDifficulty);
			this.groupTemplate.Controls.Add(this.cbxDifficulty);
			this.groupTemplate.Controls.Add(this.cbxTemplate);
			this.groupTemplate.Controls.Add(this.labelTemplate);
			this.groupTemplate.Controls.Add(this.checkPersistent);
			this.groupTemplate.Location = new System.Drawing.Point(9, 309);
			this.groupTemplate.Name = "groupTemplate";
			this.groupTemplate.Size = new System.Drawing.Size(690, 145);
			this.groupTemplate.TabIndex = 16;
			this.groupTemplate.TabStop = false;
			this.groupTemplate.Text = "Mission";
			this.checkRmod.AutoSize = true;
			this.checkRmod.Location = new System.Drawing.Point(169, 112);
			this.checkRmod.Name = "checkRmod";
			this.checkRmod.Size = new System.Drawing.Size(86, 17);
			this.checkRmod.TabIndex = 31;
			this.checkRmod.Text = Crosire.Controlcenter.Properties.Resources.check_rmod;
			this.checkRmod.UseVisualStyleBackColor = true;
			this.btnDatabase.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.btnDatabase.Location = new System.Drawing.Point(545, 77);
			this.btnDatabase.Name = "btnDatabase";
			this.btnDatabase.Size = new System.Drawing.Size(137, 23);
			this.btnDatabase.TabIndex = 21;
			this.btnDatabase.Text = Crosire.Controlcenter.Properties.Resources.button_add_database;
			this.btnDatabase.UseVisualStyleBackColor = true;
			this.btnDatabase.Click += new System.EventHandler(btnDatabase_Click);
			this.cbxDatabase.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.cbxDatabase.FormattingEnabled = true;
			this.cbxDatabase.Location = new System.Drawing.Point(169, 79);
			this.cbxDatabase.MaxDropDownItems = 6;
			this.cbxDatabase.Name = "cbxDatabase";
			this.cbxDatabase.Size = new System.Drawing.Size(369, 21);
			this.cbxDatabase.TabIndex = 16;
			this.cbxDatabase.TextChanged += new System.EventHandler(cbxDatabase_TextChanged);
			this.labelSelectDatabase.AutoSize = true;
			this.labelSelectDatabase.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.labelSelectDatabase.Location = new System.Drawing.Point(6, 82);
			this.labelSelectDatabase.Name = "labelSelectDatabase";
			this.labelSelectDatabase.Size = new System.Drawing.Size(85, 13);
			this.labelSelectDatabase.TabIndex = 15;
			this.labelSelectDatabase.Text = "Database name:";
			this.labelDifficulty.AutoSize = true;
			this.labelDifficulty.Location = new System.Drawing.Point(6, 22);
			this.labelDifficulty.Name = "labelDifficulty";
			this.labelDifficulty.Size = new System.Drawing.Size(50, 13);
			this.labelDifficulty.TabIndex = 10;
			this.labelDifficulty.Text = "Difficulty:";
			this.cbxDifficulty.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.cbxDifficulty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxDifficulty.FormattingEnabled = true;
			this.cbxDifficulty.Items.AddRange(new object[4] { "recruit", "regular", "veteran", "mercenary" });
			this.cbxDifficulty.Location = new System.Drawing.Point(169, 19);
			this.cbxDifficulty.Name = "cbxDifficulty";
			this.cbxDifficulty.Size = new System.Drawing.Size(512, 21);
			this.cbxDifficulty.TabIndex = 10;
			this.cbxTemplate.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.cbxTemplate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxTemplate.FormattingEnabled = true;
			this.cbxTemplate.Items.AddRange(new object[10] { "dayz.chernarus", "dayz.lingor", "dayz.utes", "dayz.takistan", "dayz.panthera2", "dayz.fallujah", "dayz.zargabad", "dayz.namalsk", "dayz.mbg_celle2", "dayz.tavi" });
			this.cbxTemplate.Location = new System.Drawing.Point(169, 49);
			this.cbxTemplate.Name = "cbxTemplate";
			this.cbxTemplate.Size = new System.Drawing.Size(512, 21);
			this.cbxTemplate.TabIndex = 14;
			this.cbxTemplate.DropDownClosed += new System.EventHandler(cbxTemplate_DropDownClosed);
			this.labelTemplate.AutoSize = true;
			this.labelTemplate.Location = new System.Drawing.Point(6, 52);
			this.labelTemplate.Name = "labelTemplate";
			this.labelTemplate.Size = new System.Drawing.Size(92, 13);
			this.labelTemplate.TabIndex = 13;
			this.labelTemplate.Text = "Mission Template:";
			this.checkPersistent.AutoSize = true;
			this.checkPersistent.Location = new System.Drawing.Point(9, 112);
			this.checkPersistent.Name = "checkPersistent";
			this.checkPersistent.Size = new System.Drawing.Size(121, 17);
			this.checkPersistent.TabIndex = 11;
			this.checkPersistent.Text = Crosire.Controlcenter.Properties.Resources.check_persistent;
			this.checkPersistent.UseVisualStyleBackColor = true;
			this.groupVon.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.groupVon.Controls.Add(this.numVonQuality);
			this.groupVon.Controls.Add(this.labelCodecQuality);
			this.groupVon.Controls.Add(this.checkVon);
			this.groupVon.Location = new System.Drawing.Point(9, 248);
			this.groupVon.Name = "groupVon";
			this.groupVon.Size = new System.Drawing.Size(690, 55);
			this.groupVon.TabIndex = 6;
			this.groupVon.TabStop = false;
			this.groupVon.Text = "Voice Over Net";
			this.numVonQuality.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.numVonQuality.Location = new System.Drawing.Point(169, 21);
			this.numVonQuality.Maximum = new decimal(new int[4] { 10, 0, 0, 0 });
			this.numVonQuality.Name = "numVonQuality";
			this.numVonQuality.Size = new System.Drawing.Size(512, 20);
			this.numVonQuality.TabIndex = 1;
			this.numVonQuality.Value = new decimal(new int[4] { 3, 0, 0, 0 });
			this.labelCodecQuality.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.labelCodecQuality.Location = new System.Drawing.Point(80, 22);
			this.labelCodecQuality.Name = "labelCodecQuality";
			this.labelCodecQuality.Size = new System.Drawing.Size(83, 17);
			this.labelCodecQuality.TabIndex = 1;
			this.labelCodecQuality.Text = "Codec Quality:";
			this.labelCodecQuality.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.checkVon.AutoSize = true;
			this.checkVon.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkVon.Checked = true;
			this.checkVon.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkVon.Location = new System.Drawing.Point(6, 22);
			this.checkVon.Name = "checkVon";
			this.checkVon.Size = new System.Drawing.Size(65, 17);
			this.checkVon.TabIndex = 0;
			this.checkVon.Text = Crosire.Controlcenter.Properties.Resources.check_enabled;
			this.checkVon.UseVisualStyleBackColor = true;
			this.labelRequiredBuild.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.labelRequiredBuild.Location = new System.Drawing.Point(205, 67);
			this.labelRequiredBuild.Name = "labelRequiredBuild";
			this.labelRequiredBuild.Size = new System.Drawing.Size(114, 15);
			this.labelRequiredBuild.TabIndex = 4;
			this.labelRequiredBuild.Text = "Required Build:";
			this.labelRequiredBuild.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.groupMessage.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.groupMessage.Controls.Add(this.textWelcomeMessage);
			this.groupMessage.Controls.Add(this.labelWelcomeMessage);
			this.groupMessage.Controls.Add(this.labelNoticeMessage);
			this.groupMessage.Controls.Add(this.numMessageInterval);
			this.groupMessage.Controls.Add(this.labelTimeBetweenMessage);
			this.groupMessage.Controls.Add(this.textMessage);
			this.groupMessage.Location = new System.Drawing.Point(9, 100);
			this.groupMessage.Name = "groupMessage";
			this.groupMessage.Size = new System.Drawing.Size(690, 142);
			this.groupMessage.TabIndex = 5;
			this.groupMessage.TabStop = false;
			this.groupMessage.Text = "Message";
			this.textWelcomeMessage.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.textWelcomeMessage.Location = new System.Drawing.Point(103, 108);
			this.textWelcomeMessage.Name = "textWelcomeMessage";
			this.textWelcomeMessage.Size = new System.Drawing.Size(579, 20);
			this.textWelcomeMessage.TabIndex = 14;
			this.labelWelcomeMessage.AutoSize = true;
			this.labelWelcomeMessage.Location = new System.Drawing.Point(7, 111);
			this.labelWelcomeMessage.Name = "labelWelcomeMessage";
			this.labelWelcomeMessage.Size = new System.Drawing.Size(75, 13);
			this.labelWelcomeMessage.TabIndex = 13;
			this.labelWelcomeMessage.Text = "Join Message:";
			this.labelNoticeMessage.AutoSize = true;
			this.labelNoticeMessage.Location = new System.Drawing.Point(7, 81);
			this.labelNoticeMessage.Name = "labelNoticeMessage";
			this.labelNoticeMessage.Size = new System.Drawing.Size(323, 13);
			this.labelNoticeMessage.TabIndex = 2;
			this.labelNoticeMessage.Text = "Note: Use this pattern for your text: \"Message 1\",\"Message 2\",\"...\"";
			this.numMessageInterval.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.numMessageInterval.Location = new System.Drawing.Point(605, 79);
			this.numMessageInterval.Name = "numMessageInterval";
			this.numMessageInterval.Size = new System.Drawing.Size(77, 20);
			this.numMessageInterval.TabIndex = 1;
			this.labelTimeBetweenMessage.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.labelTimeBetweenMessage.Location = new System.Drawing.Point(345, 81);
			this.labelTimeBetweenMessage.Name = "labelTimeBetweenMessage";
			this.labelTimeBetweenMessage.Size = new System.Drawing.Size(254, 13);
			this.labelTimeBetweenMessage.TabIndex = 1;
			this.labelTimeBetweenMessage.Text = "Seconds between messages:";
			this.labelTimeBetweenMessage.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.textMessage.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.textMessage.Location = new System.Drawing.Point(10, 22);
			this.textMessage.Name = "textMessage";
			this.textMessage.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
			this.textMessage.Size = new System.Drawing.Size(672, 51);
			this.textMessage.TabIndex = 0;
			this.textMessage.Text = "";
			this.numMaxPlayers.Location = new System.Drawing.Point(112, 65);
			this.numMaxPlayers.Name = "numMaxPlayers";
			this.numMaxPlayers.Size = new System.Drawing.Size(87, 20);
			this.numMaxPlayers.TabIndex = 3;
			this.labelMaxPlayers.AutoSize = true;
			this.labelMaxPlayers.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.labelMaxPlayers.Location = new System.Drawing.Point(6, 67);
			this.labelMaxPlayers.Name = "labelMaxPlayers";
			this.labelMaxPlayers.Size = new System.Drawing.Size(70, 13);
			this.labelMaxPlayers.TabIndex = 3;
			this.labelMaxPlayers.Text = "Max. Players:";
			this.cbxReportingIp.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.cbxReportingIp.FormattingEnabled = true;
			this.cbxReportingIp.Items.AddRange(new object[4] { "master.gamespy.com", "arma2pc.master.gamespy.com", "arma2oapc.master.gamespy.com", "127.0.0.1" });
			this.cbxReportingIp.Location = new System.Drawing.Point(112, 34);
			this.cbxReportingIp.MaxDropDownItems = 5;
			this.cbxReportingIp.Name = "cbxReportingIp";
			this.cbxReportingIp.Size = new System.Drawing.Size(435, 21);
			this.cbxReportingIp.TabIndex = 1;
			this.labelPort.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.labelPort.AutoSize = true;
			this.labelPort.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.labelPort.Location = new System.Drawing.Point(577, 37);
			this.labelPort.Name = "labelPort";
			this.labelPort.Size = new System.Drawing.Size(29, 13);
			this.labelPort.TabIndex = 2;
			this.labelPort.Text = "Port:";
			this.labelPort.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.labelReportingIp.AutoSize = true;
			this.labelReportingIp.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.labelReportingIp.Location = new System.Drawing.Point(6, 37);
			this.labelReportingIp.Name = "labelReportingIp";
			this.labelReportingIp.Size = new System.Drawing.Size(69, 13);
			this.labelReportingIp.TabIndex = 1;
			this.labelReportingIp.Text = "Reporting IP:";
			this.textHostname.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.textHostname.Location = new System.Drawing.Point(112, 4);
			this.textHostname.Name = "textHostname";
			this.textHostname.Size = new System.Drawing.Size(587, 20);
			this.textHostname.TabIndex = 0;
			this.labelServerName.AutoSize = true;
			this.labelServerName.Location = new System.Drawing.Point(6, 7);
			this.labelServerName.Name = "labelServerName";
			this.labelServerName.Size = new System.Drawing.Size(70, 13);
			this.labelServerName.TabIndex = 0;
			this.labelServerName.Text = "Server name:";
			this.tab1Page2.Controls.Add(this.groupWhitelist);
			this.tab1Page2.Controls.Add(this.btnRandomPass);
			this.tab1Page2.Controls.Add(this.btnSave2);
			this.tab1Page2.Controls.Add(this.groupSignatures);
			this.tab1Page2.Controls.Add(this.groupScripting);
			this.tab1Page2.Controls.Add(this.groupBattleye);
			this.tab1Page2.Controls.Add(this.textPasswordRcon);
			this.tab1Page2.Controls.Add(this.labelRconPassword);
			this.tab1Page2.Controls.Add(this.textPasswordAdmin);
			this.tab1Page2.Controls.Add(this.labelAdminPassword);
			this.tab1Page2.Controls.Add(this.textPasswordServer);
			this.tab1Page2.Controls.Add(this.labelPassword);
			this.tab1Page2.Location = new System.Drawing.Point(4, 25);
			this.tab1Page2.Name = "tab1Page2";
			this.tab1Page2.Size = new System.Drawing.Size(712, 581);
			this.tab1Page2.TabIndex = 2;
			this.tab1Page2.Text = Crosire.Controlcenter.Properties.Resources.tab1_page2;
			this.tab1Page2.UseVisualStyleBackColor = true;
			this.groupWhitelist.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.groupWhitelist.Controls.Add(this.textWhitelistMessage);
			this.groupWhitelist.Controls.Add(this.labelWhitelistMessage);
			this.groupWhitelist.Controls.Add(this.checkWhitelist);
			this.groupWhitelist.Location = new System.Drawing.Point(9, 161);
			this.groupWhitelist.Name = "groupWhitelist";
			this.groupWhitelist.Size = new System.Drawing.Size(690, 55);
			this.groupWhitelist.TabIndex = 5;
			this.groupWhitelist.TabStop = false;
			this.groupWhitelist.Text = "Whitelist";
			this.textWhitelistMessage.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.textWhitelistMessage.Location = new System.Drawing.Point(165, 20);
			this.textWhitelistMessage.Name = "textWhitelistMessage";
			this.textWhitelistMessage.Size = new System.Drawing.Size(512, 20);
			this.textWhitelistMessage.TabIndex = 12;
			this.labelWhitelistMessage.Location = new System.Drawing.Point(80, 23);
			this.labelWhitelistMessage.Name = "labelWhitelistMessage";
			this.labelWhitelistMessage.Size = new System.Drawing.Size(78, 15);
			this.labelWhitelistMessage.TabIndex = 2;
			this.labelWhitelistMessage.Text = "Message:";
			this.labelWhitelistMessage.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.checkWhitelist.AutoSize = true;
			this.checkWhitelist.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkWhitelist.Location = new System.Drawing.Point(6, 22);
			this.checkWhitelist.Name = "checkWhitelist";
			this.checkWhitelist.Size = new System.Drawing.Size(65, 17);
			this.checkWhitelist.TabIndex = 0;
			this.checkWhitelist.Text = "Enabled";
			this.checkWhitelist.UseVisualStyleBackColor = true;
			this.checkWhitelist.CheckedChanged += new System.EventHandler(checkWhitelist_CheckedChanged);
			this.btnRandomPass.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.btnRandomPass.Location = new System.Drawing.Point(178, 545);
			this.btnRandomPass.Name = "btnRandomPass";
			this.btnRandomPass.Size = new System.Drawing.Size(265, 23);
			this.btnRandomPass.TabIndex = 20;
			this.btnRandomPass.Text = Crosire.Controlcenter.Properties.Resources.button_random;
			this.btnRandomPass.UseVisualStyleBackColor = true;
			this.btnRandomPass.Click += new System.EventHandler(btnRandomPass_Click);
			this.btnSave2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.btnSave2.Location = new System.Drawing.Point(449, 545);
			this.btnSave2.Name = "btnSave2";
			this.btnSave2.Size = new System.Drawing.Size(250, 23);
			this.btnSave2.TabIndex = 14;
			this.btnSave2.Text = Crosire.Controlcenter.Properties.Resources.button_save_config;
			this.btnSave2.UseVisualStyleBackColor = true;
			this.btnSave2.Click += new System.EventHandler(btnSave2_Click);
			this.groupSignatures.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.groupSignatures.Controls.Add(this.numSecureId);
			this.groupSignatures.Controls.Add(this.labelRequireSecureId);
			this.groupSignatures.Controls.Add(this.numVerifySignatures);
			this.groupSignatures.Controls.Add(this.labelVerifySignatures);
			this.groupSignatures.Location = new System.Drawing.Point(9, 222);
			this.groupSignatures.Name = "groupSignatures";
			this.groupSignatures.Size = new System.Drawing.Size(690, 81);
			this.groupSignatures.TabIndex = 4;
			this.groupSignatures.TabStop = false;
			this.groupSignatures.Text = "Signatures";
			this.numSecureId.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.numSecureId.Location = new System.Drawing.Point(104, 50);
			this.numSecureId.Maximum = new decimal(new int[4] { 2, 0, 0, 0 });
			this.numSecureId.Name = "numSecureId";
			this.numSecureId.Size = new System.Drawing.Size(573, 20);
			this.numSecureId.TabIndex = 3;
			this.numSecureId.Value = new decimal(new int[4] { 1, 0, 0, 0 });
			this.labelRequireSecureId.AutoSize = true;
			this.labelRequireSecureId.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.labelRequireSecureId.Location = new System.Drawing.Point(7, 52);
			this.labelRequireSecureId.Name = "labelRequireSecureId";
			this.labelRequireSecureId.Size = new System.Drawing.Size(95, 13);
			this.labelRequireSecureId.TabIndex = 2;
			this.labelRequireSecureId.Text = "Require SecureID:";
			this.labelRequireSecureId.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.numVerifySignatures.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.numVerifySignatures.Location = new System.Drawing.Point(104, 20);
			this.numVerifySignatures.Maximum = new decimal(new int[4] { 2, 0, 0, 0 });
			this.numVerifySignatures.Name = "numVerifySignatures";
			this.numVerifySignatures.Size = new System.Drawing.Size(573, 20);
			this.numVerifySignatures.TabIndex = 1;
			this.numVerifySignatures.Value = new decimal(new int[4] { 2, 0, 0, 0 });
			this.labelVerifySignatures.AutoSize = true;
			this.labelVerifySignatures.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.labelVerifySignatures.Location = new System.Drawing.Point(7, 22);
			this.labelVerifySignatures.Name = "labelVerifySignatures";
			this.labelVerifySignatures.Size = new System.Drawing.Size(89, 13);
			this.labelVerifySignatures.TabIndex = 0;
			this.labelVerifySignatures.Text = "Verify Signatures:";
			this.labelVerifySignatures.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.groupScripting.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.groupScripting.Controls.Add(this.checkDuplicate);
			this.groupScripting.Controls.Add(this.textRegularCheck);
			this.groupScripting.Controls.Add(this.labelRegularCheck);
			this.groupScripting.Controls.Add(this.textOnUnsigned);
			this.groupScripting.Controls.Add(this.textOnDifferent);
			this.groupScripting.Controls.Add(this.textOnHacked);
			this.groupScripting.Controls.Add(this.textOnUserDisconnected);
			this.groupScripting.Controls.Add(this.textOnUserConnected);
			this.groupScripting.Controls.Add(this.textDoubleId);
			this.groupScripting.Controls.Add(this.labelOnUnsignedData);
			this.groupScripting.Controls.Add(this.labelOnDifferentData);
			this.groupScripting.Controls.Add(this.labelOnHackedData);
			this.groupScripting.Controls.Add(this.labelOnUserDisconnected);
			this.groupScripting.Controls.Add(this.labelOnUserConnected);
			this.groupScripting.Controls.Add(this.labelDoubleId);
			this.groupScripting.Location = new System.Drawing.Point(9, 309);
			this.groupScripting.Name = "groupScripting";
			this.groupScripting.Size = new System.Drawing.Size(690, 230);
			this.groupScripting.TabIndex = 5;
			this.groupScripting.TabStop = false;
			this.groupScripting.Text = "Scripting";
			this.checkDuplicate.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.checkDuplicate.AutoSize = true;
			this.checkDuplicate.Location = new System.Drawing.Point(582, 21);
			this.checkDuplicate.Name = "checkDuplicate";
			this.checkDuplicate.Size = new System.Drawing.Size(95, 17);
			this.checkDuplicate.TabIndex = 33;
			this.checkDuplicate.Text = Crosire.Controlcenter.Properties.Resources.check_duplicate;
			this.checkDuplicate.UseVisualStyleBackColor = true;
			this.textRegularCheck.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.textRegularCheck.Location = new System.Drawing.Point(165, 199);
			this.textRegularCheck.Name = "textRegularCheck";
			this.textRegularCheck.Size = new System.Drawing.Size(512, 20);
			this.textRegularCheck.TabIndex = 11;
			this.labelRegularCheck.AutoSize = true;
			this.labelRegularCheck.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.labelRegularCheck.Location = new System.Drawing.Point(7, 202);
			this.labelRegularCheck.Name = "labelRegularCheck";
			this.labelRegularCheck.Size = new System.Drawing.Size(87, 13);
			this.labelRegularCheck.TabIndex = 10;
			this.labelRegularCheck.Text = "Regular Check =";
			this.labelRegularCheck.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.textOnUnsigned.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.textOnUnsigned.Location = new System.Drawing.Point(165, 169);
			this.textOnUnsigned.Name = "textOnUnsigned";
			this.textOnUnsigned.Size = new System.Drawing.Size(512, 20);
			this.textOnUnsigned.TabIndex = 5;
			this.textOnDifferent.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.textOnDifferent.Location = new System.Drawing.Point(165, 139);
			this.textOnDifferent.Name = "textOnDifferent";
			this.textOnDifferent.Size = new System.Drawing.Size(512, 20);
			this.textOnDifferent.TabIndex = 4;
			this.textOnHacked.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.textOnHacked.Location = new System.Drawing.Point(165, 109);
			this.textOnHacked.Name = "textOnHacked";
			this.textOnHacked.Size = new System.Drawing.Size(512, 20);
			this.textOnHacked.TabIndex = 3;
			this.textOnUserDisconnected.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.textOnUserDisconnected.Location = new System.Drawing.Point(165, 79);
			this.textOnUserDisconnected.Name = "textOnUserDisconnected";
			this.textOnUserDisconnected.Size = new System.Drawing.Size(512, 20);
			this.textOnUserDisconnected.TabIndex = 2;
			this.textOnUserConnected.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.textOnUserConnected.Location = new System.Drawing.Point(165, 49);
			this.textOnUserConnected.Name = "textOnUserConnected";
			this.textOnUserConnected.Size = new System.Drawing.Size(512, 20);
			this.textOnUserConnected.TabIndex = 1;
			this.textDoubleId.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.textDoubleId.Location = new System.Drawing.Point(165, 19);
			this.textDoubleId.Name = "textDoubleId";
			this.textDoubleId.Size = new System.Drawing.Size(398, 20);
			this.textDoubleId.TabIndex = 0;
			this.labelOnUnsignedData.AutoSize = true;
			this.labelOnUnsignedData.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.labelOnUnsignedData.Location = new System.Drawing.Point(7, 172);
			this.labelOnUnsignedData.Name = "labelOnUnsignedData";
			this.labelOnUnsignedData.Size = new System.Drawing.Size(96, 13);
			this.labelOnUnsignedData.TabIndex = 5;
			this.labelOnUnsignedData.Text = "onUnsignedData =";
			this.labelOnUnsignedData.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.labelOnDifferentData.AutoSize = true;
			this.labelOnDifferentData.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.labelOnDifferentData.Location = new System.Drawing.Point(7, 142);
			this.labelOnDifferentData.Name = "labelOnDifferentData";
			this.labelOnDifferentData.Size = new System.Drawing.Size(91, 13);
			this.labelOnDifferentData.TabIndex = 4;
			this.labelOnDifferentData.Text = "onDifferentData =";
			this.labelOnDifferentData.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.labelOnHackedData.AutoSize = true;
			this.labelOnHackedData.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.labelOnHackedData.Location = new System.Drawing.Point(7, 112);
			this.labelOnHackedData.Name = "labelOnHackedData";
			this.labelOnHackedData.Size = new System.Drawing.Size(89, 13);
			this.labelOnHackedData.TabIndex = 3;
			this.labelOnHackedData.Text = "onHackedData =";
			this.labelOnHackedData.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.labelOnUserDisconnected.AutoSize = true;
			this.labelOnUserDisconnected.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.labelOnUserDisconnected.Location = new System.Drawing.Point(7, 82);
			this.labelOnUserDisconnected.Name = "labelOnUserDisconnected";
			this.labelOnUserDisconnected.Size = new System.Drawing.Size(116, 13);
			this.labelOnUserDisconnected.TabIndex = 2;
			this.labelOnUserDisconnected.Text = "onUserDisconnected =";
			this.labelOnUserDisconnected.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.labelOnUserConnected.AutoSize = true;
			this.labelOnUserConnected.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.labelOnUserConnected.Location = new System.Drawing.Point(7, 52);
			this.labelOnUserConnected.Name = "labelOnUserConnected";
			this.labelOnUserConnected.Size = new System.Drawing.Size(102, 13);
			this.labelOnUserConnected.TabIndex = 1;
			this.labelOnUserConnected.Text = "onUserConnected =";
			this.labelOnUserConnected.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.labelDoubleId.AutoSize = true;
			this.labelDoubleId.Location = new System.Drawing.Point(7, 22);
			this.labelDoubleId.Name = "labelDoubleId";
			this.labelDoubleId.Size = new System.Drawing.Size(101, 13);
			this.labelDoubleId.TabIndex = 0;
			this.labelDoubleId.Text = "doubleIdDetected =";
			this.labelDoubleId.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.groupBattleye.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.groupBattleye.Controls.Add(this.numMaxPing);
			this.groupBattleye.Controls.Add(this.labelMaxPing);
			this.groupBattleye.Controls.Add(this.checkBattleye);
			this.groupBattleye.Location = new System.Drawing.Point(9, 100);
			this.groupBattleye.Name = "groupBattleye";
			this.groupBattleye.Size = new System.Drawing.Size(690, 55);
			this.groupBattleye.TabIndex = 3;
			this.groupBattleye.TabStop = false;
			this.groupBattleye.Text = "BattlEye";
			this.numMaxPing.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.numMaxPing.Increment = new decimal(new int[4] { 50, 0, 0, 0 });
			this.numMaxPing.Location = new System.Drawing.Point(165, 21);
			this.numMaxPing.Maximum = new decimal(new int[4] { 999, 0, 0, 0 });
			this.numMaxPing.Name = "numMaxPing";
			this.numMaxPing.Size = new System.Drawing.Size(512, 20);
			this.numMaxPing.TabIndex = 2;
			this.numMaxPing.Value = new decimal(new int[4] { 100, 0, 0, 0 });
			this.labelMaxPing.Location = new System.Drawing.Point(80, 23);
			this.labelMaxPing.Name = "labelMaxPing";
			this.labelMaxPing.Size = new System.Drawing.Size(78, 15);
			this.labelMaxPing.TabIndex = 1;
			this.labelMaxPing.Text = "Max. Ping:";
			this.labelMaxPing.TextAlign = System.Drawing.ContentAlignment.TopRight;
			this.checkBattleye.AutoSize = true;
			this.checkBattleye.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.checkBattleye.Location = new System.Drawing.Point(6, 22);
			this.checkBattleye.Name = "checkBattleye";
			this.checkBattleye.Size = new System.Drawing.Size(65, 17);
			this.checkBattleye.TabIndex = 0;
			this.checkBattleye.Text = Crosire.Controlcenter.Properties.Resources.check_enabled;
			this.checkBattleye.UseVisualStyleBackColor = true;
			this.checkBattleye.CheckedChanged += new System.EventHandler(checkBattleye_CheckedChanged);
			this.textPasswordRcon.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.textPasswordRcon.Location = new System.Drawing.Point(112, 64);
			this.textPasswordRcon.Name = "textPasswordRcon";
			this.textPasswordRcon.Size = new System.Drawing.Size(587, 20);
			this.textPasswordRcon.TabIndex = 2;
			this.labelRconPassword.AutoSize = true;
			this.labelRconPassword.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.labelRconPassword.Location = new System.Drawing.Point(6, 67);
			this.labelRconPassword.Name = "labelRconPassword";
			this.labelRconPassword.Size = new System.Drawing.Size(98, 13);
			this.labelRconPassword.TabIndex = 2;
			this.labelRconPassword.Text = "BattlEye Password:";
			this.textPasswordAdmin.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.textPasswordAdmin.Location = new System.Drawing.Point(112, 34);
			this.textPasswordAdmin.Name = "textPasswordAdmin";
			this.textPasswordAdmin.Size = new System.Drawing.Size(587, 20);
			this.textPasswordAdmin.TabIndex = 1;
			this.labelAdminPassword.AutoSize = true;
			this.labelAdminPassword.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.labelAdminPassword.Location = new System.Drawing.Point(6, 37);
			this.labelAdminPassword.Name = "labelAdminPassword";
			this.labelAdminPassword.Size = new System.Drawing.Size(88, 13);
			this.labelAdminPassword.TabIndex = 1;
			this.labelAdminPassword.Text = "Admin Password:";
			this.textPasswordServer.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.textPasswordServer.Location = new System.Drawing.Point(112, 4);
			this.textPasswordServer.Name = "textPasswordServer";
			this.textPasswordServer.Size = new System.Drawing.Size(587, 20);
			this.textPasswordServer.TabIndex = 0;
			this.labelPassword.AutoSize = true;
			this.labelPassword.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.labelPassword.Location = new System.Drawing.Point(6, 7);
			this.labelPassword.Name = "labelPassword";
			this.labelPassword.Size = new System.Drawing.Size(56, 13);
			this.labelPassword.TabIndex = 0;
			this.labelPassword.Text = "Password:";
			this.tab1Page3.Controls.Add(this.groupAdditional);
			this.tab1Page3.Controls.Add(this.btnSave3);
			this.tab1Page3.Controls.Add(this.groupNetwork);
			this.tab1Page3.Location = new System.Drawing.Point(4, 25);
			this.tab1Page3.Name = "tab1Page3";
			this.tab1Page3.Size = new System.Drawing.Size(712, 581);
			this.tab1Page3.TabIndex = 4;
			this.tab1Page3.Text = Crosire.Controlcenter.Properties.Resources.tab1_page3;
			this.tab1Page3.UseVisualStyleBackColor = true;
			this.groupAdditional.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.groupAdditional.Controls.Add(this.cbxLoadoutBackpack);
			this.groupAdditional.Controls.Add(this.labelLoadoutBackpack);
			this.groupAdditional.Controls.Add(this.textModlist);
			this.groupAdditional.Controls.Add(this.labelModlist);
			this.groupAdditional.Controls.Add(this.cbxLoadout);
			this.groupAdditional.Controls.Add(this.labelLoadout);
			this.groupAdditional.Controls.Add(this.numMaxCustomsize);
			this.groupAdditional.Controls.Add(this.labelMaxCustomSize);
			this.groupAdditional.Controls.Add(this.labelMaxCustomSizeUnit);
			this.groupAdditional.Location = new System.Drawing.Point(9, 246);
			this.groupAdditional.Name = "groupAdditional";
			this.groupAdditional.Size = new System.Drawing.Size(690, 141);
			this.groupAdditional.TabIndex = 2;
			this.groupAdditional.TabStop = false;
			this.groupAdditional.Text = "Additional Options";
			this.cbxLoadoutBackpack.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.cbxLoadoutBackpack.FormattingEnabled = true;
			this.cbxLoadoutBackpack.Items.AddRange(new object[5] { "[\"DZ_Patrol_Pack_EP1\",[[],[]],[[],[]]]", "[\"DZ_Assault_Pack_EP1\",[[],[]],[[],[]]]", "[\"DZ_CivilBackpack_EP1\",[[],[]],[[],[]]]", "[\"DZ_ALICE_Pack_EP1\",[[],[]],[[],[]]]", "[\"DZ_Backpack_EP1\",[[],[]],[[],[]]]" });
			this.cbxLoadoutBackpack.Location = new System.Drawing.Point(165, 79);
			this.cbxLoadoutBackpack.Name = "cbxLoadoutBackpack";
			this.cbxLoadoutBackpack.Size = new System.Drawing.Size(464, 21);
			this.cbxLoadoutBackpack.TabIndex = 39;
			this.labelLoadoutBackpack.AutoSize = true;
			this.labelLoadoutBackpack.Location = new System.Drawing.Point(6, 82);
			this.labelLoadoutBackpack.Name = "labelLoadoutBackpack";
			this.labelLoadoutBackpack.Size = new System.Drawing.Size(117, 13);
			this.labelLoadoutBackpack.TabIndex = 38;
			this.labelLoadoutBackpack.Text = "Global backup loadout:";
			this.textModlist.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.textModlist.Location = new System.Drawing.Point(165, 109);
			this.textModlist.Name = "textModlist";
			this.textModlist.Size = new System.Drawing.Size(464, 20);
			this.textModlist.TabIndex = 29;
			this.labelModlist.AutoSize = true;
			this.labelModlist.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.labelModlist.Location = new System.Drawing.Point(6, 112);
			this.labelModlist.Name = "labelModlist";
			this.labelModlist.Size = new System.Drawing.Size(43, 13);
			this.labelModlist.TabIndex = 28;
			this.labelModlist.Text = "Modlist:";
			this.cbxLoadout.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.cbxLoadout.FormattingEnabled = true;
			this.cbxLoadout.Items.AddRange(new object[6]
			{
				"[]",
				"[[\"M9SD\",\"FoodCanBakedBeans\",\"ItemMap\"],[\"15Rnd_9x19_M9SD\",\"ItemBandage\",\"15Rnd_9x19_M9SD\"]]",
				"[[\"M9SD\",\"FoodCanBakedBeans\",\"ItemMap\",\"LeeEnfield\"],[\"15Rnd_9x19_M9SD\",\"ItemBandage\",\"15Rnd_9x19_M9SD\",\"10x_303\",\"10x_303\",\"10x_303\",\"10x_303\"]]",
				"[[\"M9SD\",\"FoodCanBakedBeans\",\"ItemMap\",\"Mk_48_DZ\"],[\"15Rnd_9x19_M9SD\",\"ItemBandage\",\"15Rnd_9x19_M9SD\",\"100Rnd_762x51_M240\",\"100Rnd_762x51_M240\"]]",
				"[[\"ItemMap\",\"ItemCompass\",\"ItemMatchbox\",\"FoodCanBakedBeans\",\"ItemKnife\",\"FoodCanBakedBeans\"],[\"ItemTent\",\"ItemBandage\",\"ItemBandage\"]]",
				resources.GetString("cbxLoadout.Items")
			});
			this.cbxLoadout.Location = new System.Drawing.Point(165, 49);
			this.cbxLoadout.Name = "cbxLoadout";
			this.cbxLoadout.Size = new System.Drawing.Size(464, 21);
			this.cbxLoadout.TabIndex = 37;
			this.labelLoadout.AutoSize = true;
			this.labelLoadout.Location = new System.Drawing.Point(6, 52);
			this.labelLoadout.Name = "labelLoadout";
			this.labelLoadout.Size = new System.Drawing.Size(78, 13);
			this.labelLoadout.TabIndex = 36;
			this.labelLoadout.Text = "Global loadout:";
			this.numMaxCustomsize.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.numMaxCustomsize.Location = new System.Drawing.Point(165, 20);
			this.numMaxCustomsize.Maximum = new decimal(new int[4] { 1410065407, 2, 0, 0 });
			this.numMaxCustomsize.Name = "numMaxCustomsize";
			this.numMaxCustomsize.Size = new System.Drawing.Size(464, 20);
			this.numMaxCustomsize.TabIndex = 0;
			this.labelMaxCustomSize.AutoSize = true;
			this.labelMaxCustomSize.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.labelMaxCustomSize.Location = new System.Drawing.Point(6, 22);
			this.labelMaxCustomSize.Name = "labelMaxCustomSize";
			this.labelMaxCustomSize.Size = new System.Drawing.Size(94, 13);
			this.labelMaxCustomSize.TabIndex = 0;
			this.labelMaxCustomSize.Text = "Max. Custom Size:";
			this.labelMaxCustomSizeUnit.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.labelMaxCustomSizeUnit.AutoSize = true;
			this.labelMaxCustomSizeUnit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.labelMaxCustomSizeUnit.Location = new System.Drawing.Point(635, 22);
			this.labelMaxCustomSizeUnit.Name = "labelMaxCustomSizeUnit";
			this.labelMaxCustomSizeUnit.Size = new System.Drawing.Size(20, 13);
			this.labelMaxCustomSizeUnit.TabIndex = 25;
			this.labelMaxCustomSizeUnit.Text = "kB";
			this.btnSave3.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.btnSave3.Location = new System.Drawing.Point(449, 545);
			this.btnSave3.Name = "btnSave3";
			this.btnSave3.Size = new System.Drawing.Size(250, 23);
			this.btnSave3.TabIndex = 9;
			this.btnSave3.Text = Crosire.Controlcenter.Properties.Resources.button_save_config;
			this.btnSave3.UseVisualStyleBackColor = true;
			this.btnSave3.Click += new System.EventHandler(btnSave3_Click);
			this.groupNetwork.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.groupNetwork.Controls.Add(this.numMaxBandwidth);
			this.groupNetwork.Controls.Add(this.numMinBandwidth);
			this.groupNetwork.Controls.Add(this.numMaxMessages);
			this.groupNetwork.Controls.Add(this.numMaxSizeGuaranteed);
			this.groupNetwork.Controls.Add(this.numMaxSizeNonguaranteed);
			this.groupNetwork.Controls.Add(this.numMinErrorNear);
			this.groupNetwork.Controls.Add(this.numMinError);
			this.groupNetwork.Controls.Add(this.labelMaxBandwidthUnit);
			this.groupNetwork.Controls.Add(this.labelMinBandwidthUnit);
			this.groupNetwork.Controls.Add(this.labelMaxSizeNonguaranteedUnit);
			this.groupNetwork.Controls.Add(this.labelMaxSizeGuaranteedUnit);
			this.groupNetwork.Controls.Add(this.labelMinErrtoSendNear);
			this.groupNetwork.Controls.Add(this.labelMinErrtoSend);
			this.groupNetwork.Controls.Add(this.labelMaxBandwidth);
			this.groupNetwork.Controls.Add(this.labelMinBandwidth);
			this.groupNetwork.Controls.Add(this.labelMaxSizeNonguaranteed);
			this.groupNetwork.Controls.Add(this.labelMaxSizeGuaranteed);
			this.groupNetwork.Controls.Add(this.labelMaxMsgSent);
			this.groupNetwork.Location = new System.Drawing.Point(9, 7);
			this.groupNetwork.Name = "groupNetwork";
			this.groupNetwork.Size = new System.Drawing.Size(690, 233);
			this.groupNetwork.TabIndex = 1;
			this.groupNetwork.TabStop = false;
			this.groupNetwork.Text = "Network Tuning";
			this.numMaxBandwidth.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.numMaxBandwidth.Increment = new decimal(new int[4] { 1000, 0, 0, 0 });
			this.numMaxBandwidth.Location = new System.Drawing.Point(165, 50);
			this.numMaxBandwidth.Maximum = new decimal(new int[4] { 1410065407, 2, 0, 0 });
			this.numMaxBandwidth.Name = "numMaxBandwidth";
			this.numMaxBandwidth.Size = new System.Drawing.Size(464, 20);
			this.numMaxBandwidth.TabIndex = 1;
			this.numMinBandwidth.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.numMinBandwidth.Increment = new decimal(new int[4] { 1000, 0, 0, 0 });
			this.numMinBandwidth.Location = new System.Drawing.Point(165, 20);
			this.numMinBandwidth.Maximum = new decimal(new int[4] { 1410065407, 2, 0, 0 });
			this.numMinBandwidth.Name = "numMinBandwidth";
			this.numMinBandwidth.Size = new System.Drawing.Size(464, 20);
			this.numMinBandwidth.TabIndex = 0;
			this.numMaxMessages.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.numMaxMessages.Location = new System.Drawing.Point(165, 80);
			this.numMaxMessages.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
			this.numMaxMessages.Name = "numMaxMessages";
			this.numMaxMessages.Size = new System.Drawing.Size(464, 20);
			this.numMaxMessages.TabIndex = 2;
			this.numMaxSizeGuaranteed.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.numMaxSizeGuaranteed.Location = new System.Drawing.Point(165, 110);
			this.numMaxSizeGuaranteed.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
			this.numMaxSizeGuaranteed.Name = "numMaxSizeGuaranteed";
			this.numMaxSizeGuaranteed.Size = new System.Drawing.Size(464, 20);
			this.numMaxSizeGuaranteed.TabIndex = 3;
			this.numMaxSizeNonguaranteed.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.numMaxSizeNonguaranteed.Location = new System.Drawing.Point(165, 140);
			this.numMaxSizeNonguaranteed.Maximum = new decimal(new int[4] { 99999, 0, 0, 0 });
			this.numMaxSizeNonguaranteed.Name = "numMaxSizeNonguaranteed";
			this.numMaxSizeNonguaranteed.Size = new System.Drawing.Size(464, 20);
			this.numMaxSizeNonguaranteed.TabIndex = 4;
			this.numMinErrorNear.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.numMinErrorNear.DecimalPlaces = 10;
			this.numMinErrorNear.Increment = new decimal(new int[4] { 1, 0, 0, 196608 });
			this.numMinErrorNear.Location = new System.Drawing.Point(165, 200);
			this.numMinErrorNear.Maximum = new decimal(new int[4] { 1, 0, 0, 0 });
			this.numMinErrorNear.Name = "numMinErrorNear";
			this.numMinErrorNear.Size = new System.Drawing.Size(464, 20);
			this.numMinErrorNear.TabIndex = 6;
			this.numMinError.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.numMinError.DecimalPlaces = 10;
			this.numMinError.Increment = new decimal(new int[4] { 1, 0, 0, 196608 });
			this.numMinError.Location = new System.Drawing.Point(165, 170);
			this.numMinError.Maximum = new decimal(new int[4] { 1, 0, 0, 0 });
			this.numMinError.Name = "numMinError";
			this.numMinError.Size = new System.Drawing.Size(464, 20);
			this.numMinError.TabIndex = 5;
			this.labelMaxBandwidthUnit.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.labelMaxBandwidthUnit.AutoSize = true;
			this.labelMaxBandwidthUnit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.labelMaxBandwidthUnit.Location = new System.Drawing.Point(635, 52);
			this.labelMaxBandwidthUnit.Name = "labelMaxBandwidthUnit";
			this.labelMaxBandwidthUnit.Size = new System.Drawing.Size(24, 13);
			this.labelMaxBandwidthUnit.TabIndex = 24;
			this.labelMaxBandwidthUnit.Text = "B/s";
			this.labelMinBandwidthUnit.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.labelMinBandwidthUnit.AutoSize = true;
			this.labelMinBandwidthUnit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.labelMinBandwidthUnit.Location = new System.Drawing.Point(635, 22);
			this.labelMinBandwidthUnit.Name = "labelMinBandwidthUnit";
			this.labelMinBandwidthUnit.Size = new System.Drawing.Size(24, 13);
			this.labelMinBandwidthUnit.TabIndex = 23;
			this.labelMinBandwidthUnit.Text = "B/s";
			this.labelMaxSizeNonguaranteedUnit.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.labelMaxSizeNonguaranteedUnit.AutoSize = true;
			this.labelMaxSizeNonguaranteedUnit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.labelMaxSizeNonguaranteedUnit.Location = new System.Drawing.Point(635, 142);
			this.labelMaxSizeNonguaranteedUnit.Name = "labelMaxSizeNonguaranteedUnit";
			this.labelMaxSizeNonguaranteedUnit.Size = new System.Drawing.Size(33, 13);
			this.labelMaxSizeNonguaranteedUnit.TabIndex = 21;
			this.labelMaxSizeNonguaranteedUnit.Text = "Bytes";
			this.labelMaxSizeGuaranteedUnit.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.labelMaxSizeGuaranteedUnit.AutoSize = true;
			this.labelMaxSizeGuaranteedUnit.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.labelMaxSizeGuaranteedUnit.Location = new System.Drawing.Point(635, 112);
			this.labelMaxSizeGuaranteedUnit.Name = "labelMaxSizeGuaranteedUnit";
			this.labelMaxSizeGuaranteedUnit.Size = new System.Drawing.Size(33, 13);
			this.labelMaxSizeGuaranteedUnit.TabIndex = 20;
			this.labelMaxSizeGuaranteedUnit.Text = "Bytes";
			this.labelMinErrtoSendNear.AutoSize = true;
			this.labelMinErrtoSendNear.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.labelMinErrtoSendNear.Location = new System.Drawing.Point(6, 202);
			this.labelMinErrtoSendNear.Name = "labelMinErrtoSendNear";
			this.labelMinErrtoSendNear.Size = new System.Drawing.Size(126, 13);
			this.labelMinErrtoSendNear.TabIndex = 6;
			this.labelMinErrtoSendNear.Text = "Min. Errors to Send Near:";
			this.labelMinErrtoSend.AutoSize = true;
			this.labelMinErrtoSend.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.labelMinErrtoSend.Location = new System.Drawing.Point(6, 172);
			this.labelMinErrtoSend.Name = "labelMinErrtoSend";
			this.labelMinErrtoSend.Size = new System.Drawing.Size(100, 13);
			this.labelMinErrtoSend.TabIndex = 5;
			this.labelMinErrtoSend.Text = "Min. Errors to Send:";
			this.labelMaxBandwidth.AutoSize = true;
			this.labelMaxBandwidth.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.labelMaxBandwidth.Location = new System.Drawing.Point(6, 52);
			this.labelMaxBandwidth.Name = "labelMaxBandwidth";
			this.labelMaxBandwidth.Size = new System.Drawing.Size(86, 13);
			this.labelMaxBandwidth.TabIndex = 1;
			this.labelMaxBandwidth.Text = "Max. Bandwidth:";
			this.labelMinBandwidth.AutoSize = true;
			this.labelMinBandwidth.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.labelMinBandwidth.Location = new System.Drawing.Point(6, 22);
			this.labelMinBandwidth.Name = "labelMinBandwidth";
			this.labelMinBandwidth.Size = new System.Drawing.Size(83, 13);
			this.labelMinBandwidth.TabIndex = 0;
			this.labelMinBandwidth.Text = "Min. Bandwidth:";
			this.labelMaxSizeNonguaranteed.AutoSize = true;
			this.labelMaxSizeNonguaranteed.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.labelMaxSizeNonguaranteed.Location = new System.Drawing.Point(6, 142);
			this.labelMaxSizeNonguaranteed.Name = "labelMaxSizeNonguaranteed";
			this.labelMaxSizeNonguaranteed.Size = new System.Drawing.Size(110, 13);
			this.labelMaxSizeNonguaranteed.TabIndex = 4;
			this.labelMaxSizeNonguaranteed.Text = "Max. Nonguaranteed:";
			this.labelMaxSizeGuaranteed.AutoSize = true;
			this.labelMaxSizeGuaranteed.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.labelMaxSizeGuaranteed.Location = new System.Drawing.Point(6, 112);
			this.labelMaxSizeGuaranteed.Name = "labelMaxSizeGuaranteed";
			this.labelMaxSizeGuaranteed.Size = new System.Drawing.Size(92, 13);
			this.labelMaxSizeGuaranteed.TabIndex = 3;
			this.labelMaxSizeGuaranteed.Text = "Max. Guaranteed:";
			this.labelMaxMsgSent.AutoSize = true;
			this.labelMaxMsgSent.ImeMode = System.Windows.Forms.ImeMode.NoControl;
			this.labelMaxMsgSent.Location = new System.Drawing.Point(6, 82);
			this.labelMaxMsgSent.Name = "labelMaxMsgSent";
			this.labelMaxMsgSent.Size = new System.Drawing.Size(109, 13);
			this.labelMaxMsgSent.TabIndex = 2;
			this.labelMaxMsgSent.Text = "Max. Messages Sent:";
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(884, 612);
			base.Controls.Add(this.container1);
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			this.MinimumSize = new System.Drawing.Size(800, 650);
			base.Name = "frmMain";
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(frmMain_FormClosing);
			base.Load += new System.EventHandler(frmMain_Load);
			base.Shown += new System.EventHandler(frmMain_Shown);
			base.Move += new System.EventHandler(frmMain_Move);
			base.Resize += new System.EventHandler(frmMain_Move);
			this.container1.Panel1.ResumeLayout(false);
			this.container1.Panel1.PerformLayout();
			this.container1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)this.container1).EndInit();
			this.container1.ResumeLayout(false);
			this.container2.Panel1.ResumeLayout(false);
			this.container2.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)this.container2).EndInit();
			this.container2.ResumeLayout(false);
			this.container2_2.ResumeLayout(false);
			this.tab2.ResumeLayout(false);
			this.tab2Page2.ResumeLayout(false);
			this.groupLogin.ResumeLayout(false);
			this.groupLogin.PerformLayout();
			this.tab2Page3.ResumeLayout(false);
			this.tab2Page3.PerformLayout();
			this.container2_4.ResumeLayout(false);
			this.groupSettings.ResumeLayout(false);
			this.groupSettings.PerformLayout();
			this.groupAbout.ResumeLayout(false);
			this.groupAbout.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.pictureLicense).EndInit();
			((System.ComponentModel.ISupportInitialize)this.pictureIcon).EndInit();
			this.container2_3.ResumeLayout(false);
			this.tab3.ResumeLayout(false);
			this.tab3Page2.ResumeLayout(false);
			this.groupSurvivor.ResumeLayout(false);
			this.groupSurvivor.PerformLayout();
			this.groupProfile.ResumeLayout(false);
			this.groupProfile.PerformLayout();
			this.tab3Page3.ResumeLayout(false);
			this.groupReset.ResumeLayout(false);
			this.groupReset.PerformLayout();
			this.groupAutoBackup.ResumeLayout(false);
			this.groupAutoBackup.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.numBackupInterval).EndInit();
			this.groupRestore.ResumeLayout(false);
			this.groupBackup.ResumeLayout(false);
			this.groupBackup.PerformLayout();
			this.container2_1.ResumeLayout(false);
			this.tab1.ResumeLayout(false);
			this.tab1Page1.ResumeLayout(false);
			this.tab1Page1.PerformLayout();
			this.groupTime.ResumeLayout(false);
			this.groupTime.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.trackTimezone).EndInit();
			this.groupTemplate.ResumeLayout(false);
			this.groupTemplate.PerformLayout();
			this.groupVon.ResumeLayout(false);
			this.groupVon.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.numVonQuality).EndInit();
			this.groupMessage.ResumeLayout(false);
			this.groupMessage.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.numMessageInterval).EndInit();
			((System.ComponentModel.ISupportInitialize)this.numMaxPlayers).EndInit();
			this.tab1Page2.ResumeLayout(false);
			this.tab1Page2.PerformLayout();
			this.groupWhitelist.ResumeLayout(false);
			this.groupWhitelist.PerformLayout();
			this.groupSignatures.ResumeLayout(false);
			this.groupSignatures.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.numSecureId).EndInit();
			((System.ComponentModel.ISupportInitialize)this.numVerifySignatures).EndInit();
			this.groupScripting.ResumeLayout(false);
			this.groupScripting.PerformLayout();
			this.groupBattleye.ResumeLayout(false);
			this.groupBattleye.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.numMaxPing).EndInit();
			this.tab1Page3.ResumeLayout(false);
			this.groupAdditional.ResumeLayout(false);
			this.groupAdditional.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.numMaxCustomsize).EndInit();
			this.groupNetwork.ResumeLayout(false);
			this.groupNetwork.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.numMaxBandwidth).EndInit();
			((System.ComponentModel.ISupportInitialize)this.numMinBandwidth).EndInit();
			((System.ComponentModel.ISupportInitialize)this.numMaxMessages).EndInit();
			((System.ComponentModel.ISupportInitialize)this.numMaxSizeGuaranteed).EndInit();
			((System.ComponentModel.ISupportInitialize)this.numMaxSizeNonguaranteed).EndInit();
			((System.ComponentModel.ISupportInitialize)this.numMinErrorNear).EndInit();
			((System.ComponentModel.ISupportInitialize)this.numMinError).EndInit();
			base.ResumeLayout(false);
		}
	}
}
