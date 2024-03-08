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
	// Token: 0x02000009 RID: 9
	public partial class frmMain : Form
	{
		// Token: 0x0600003D RID: 61 RVA: 0x00007F60 File Offset: 0x00006160
		public frmMain()
		{
			this.InitializeComponent();
			this.Text = Application.ProductName + " " + Application.ProductVersion;
			this.labelVersion.Text = Application.ProductVersion;
			this.browserAdmin = new WebView();
			this.browserAdmin.Dock = DockStyle.Fill;
			this.browserAdmin.Address = Settings.Default.uiUrlAdmin;
			this.browserDatabase = new WebView();
			this.browserDatabase.Dock = DockStyle.Fill;
			this.browserDatabase.Address = Settings.Default.uiUrlDatabase;
			this.tab2Page1.Controls.Add(this.browserAdmin);
			this.tab3Page1.Controls.Add(this.browserDatabase);
			this.threadmain = new Thread(new ThreadStart(this.threadMain));
			this.threadtimer = new Thread(new ThreadStart(this.threadTimer));
		}

		// Token: 0x0600003E RID: 62 RVA: 0x000080E4 File Offset: 0x000062E4
		private void threadMain()
		{
			for (;;)
			{
				if (base.IsHandleCreated && !base.IsDisposed && !this._closing)
				{
					if (IO.GetProcessState("arma2oaserver_" + frmMain.serverInstance.ToString()))
					{
						base.BeginInvoke(new MethodInvoker(delegate
						{
							this.btnMenu1.Enabled = false;
							this.btnLogClear.Enabled = false;
						}));
					}
					else
					{
						base.BeginInvoke(new MethodInvoker(delegate
						{
							this.btnMenu1.Enabled = true;
							this.btnLogClear.Enabled = true;
						}));
					}
					if (File.Exists(Path.Combine(this.configuration.pathConfig, "arma2oaserver_" + frmMain.serverInstance.ToString() + ".rpt")))
					{
						base.BeginInvoke(new MethodInvoker(delegate
						{
							this.btnLogMonitor.Enabled = true;
						}));
					}
					else
					{
						base.BeginInvoke(new MethodInvoker(delegate
						{
							this.btnLogMonitor.Enabled = false;
							this.btnLogClear.Enabled = false;
						}));
					}
				}
				Thread.Sleep(250);
			}
		}

		// Token: 0x0600003F RID: 63 RVA: 0x00008250 File Offset: 0x00006450
		private void threadTimer()
		{
			for (;;)
			{
				try
				{
					for (int i = 1; i <= frmMain.appInstances; i++)
					{
						if (frmMain.listAutoBackupEnabled[i - 1])
						{
							frmMain.listAutoBackupProgress[i - 1]++;
							if (frmMain.listAutoBackupProgress[i - 1] == frmMain.listAutoBackupInterval[i - 1] * 60)
							{
								try
								{
									if (!Directory.Exists(frmMain.listAutoBackupPath[i - 1]))
									{
										Directory.CreateDirectory(frmMain.listAutoBackupPath[i - 1]);
									}
									Process.Start(new ProcessStartInfo(Path.Combine(this.configuration.pathMain, "mysql", "bin", "mysqldump.exe"), string.Concat(new string[]
									{
										"--host=",
										frmMain.listDbHost[i - 1],
										" --user=",
										frmMain.listDbUser[i - 1],
										" --password=",
										frmMain.listDbPass[i - 1],
										" --port=",
										frmMain.listDbPort[i - 1].ToString(),
										" --routines --triggers --databases ",
										frmMain.listDbName[i - 1],
										" --result-file=\"",
										Path.Combine(frmMain.listAutoBackupPath[i - 1], string.Concat(new string[]
										{
											DateTime.Now.Year.ToString(),
											"-",
											DateTime.Now.Month.ToString(),
											"-",
											DateTime.Now.Day.ToString(),
											"_",
											DateTime.Now.Hour.ToString(),
											"-",
											DateTime.Now.Minute.ToString(),
											"_",
											frmMain.listDbName[i - 1],
											"_auto_backup.sql"
										})),
										"\""
									}))
									{
										WindowStyle = ProcessWindowStyle.Hidden
									});
									this.subAppendLog("Backup: Dumped database [Database \"" + frmMain.listDbName[i - 1] + "\"]", LogLevel.Info);
								}
								finally
								{
									frmMain.listAutoBackupProgress[i - 1] = 0;
								}
							}
						}
					}
					if (this.progressBackup.IsHandleCreated && !this.progressBackup.IsDisposed && !this._closing)
					{
						this.progressBackup.Invoke(new MethodInvoker(delegate
						{
							if (frmMain.listAutoBackupProgress[frmMain.serverInstance - 1] <= this.progressBackup.Maximum)
							{
								this.progressBackup.Value = frmMain.listAutoBackupProgress[frmMain.serverInstance - 1];
							}
						}));
					}
				}
				catch (Exception ex)
				{
					this.subAppendLog(ex);
				}
				Thread.Sleep(1000);
			}
		}

		// Token: 0x06000040 RID: 64 RVA: 0x0000859C File Offset: 0x0000679C
		private void threadBackup()
		{
			this.subAppendLog("Backup: Dumping database [Database \"" + this.configuration.dbName + "\"]", LogLevel.Info);
			if (!Directory.Exists(this.configuration.confAutoBackupPath))
			{
				Directory.CreateDirectory(this.configuration.confAutoBackupPath);
			}
			try
			{
				ProcessStartInfo processStartInfo = new ProcessStartInfo(Path.Combine(this.configuration.pathMain, "mysql", "bin", "mysqldump.exe"), string.Concat(new string[]
				{
					"--host=",
					this.configuration.dbHost,
					" --user=",
					this.configuration.dbUser,
					" --password=",
					this.configuration.dbPass,
					" --port=",
					this.configuration.dbPort.ToString(),
					" --routines --triggers --databases ",
					this.configuration.dbName,
					" --result-file=\"",
					Path.Combine(this.configuration.confAutoBackupPath, string.Concat(new string[]
					{
						DateTime.Now.Year.ToString(),
						"-",
						DateTime.Now.Month.ToString(),
						"-",
						DateTime.Now.Day.ToString(),
						"_",
						DateTime.Now.Hour.ToString(),
						"-",
						DateTime.Now.Minute.ToString(),
						"_",
						this.configuration.dbName,
						"_backup.sql"
					})),
					"\""
				}));
				processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
				Process process = new Process();
				process.StartInfo = processStartInfo;
				process.Start();
				process.WaitForExit(15000);
				switch (process.ExitCode)
				{
				case 0:
					this.subAppendLog("Backup: Success!", LogLevel.Info);
					goto IL_2BD;
				case 2:
					this.subAppendLog("Error: MySQL Connection Error, User " + this.configuration.dbUser + ", Password: " + this.configuration.dbPass, LogLevel.Error);
					goto IL_2BD;
				}
				this.subAppendLog("Error: MySQL Exit Code: " + process.ExitCode.ToString(), LogLevel.Error);
				IL_2BD:;
			}
			catch (Exception ex)
			{
				this.subAppendLog(ex);
			}
		}

		// Token: 0x06000041 RID: 65 RVA: 0x00008894 File Offset: 0x00006A94
		private void threadRestore(string path)
		{
			this.subAppendLog(string.Concat(new string[]
			{
				"Backup: Restoring database [Host ",
				this.configuration.dbHost,
				":",
				this.configuration.dbPort.ToString(),
				"]"
			}), LogLevel.Info);
			try
			{
				ProcessStartInfo processStartInfo = new ProcessStartInfo("cmd.exe", string.Concat(new string[]
				{
					"/c \"\"",
					Path.Combine(this.configuration.pathMain, "mysql", "bin", "mysql.exe"),
					"\" --host=",
					this.configuration.dbHost,
					" --user=",
					this.configuration.dbUser,
					" --password=",
					this.configuration.dbPass,
					" --port=",
					this.configuration.dbPort.ToString(),
					" < \"",
					path,
					"\"\""
				}));
				processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
				Process process = new Process();
				process.StartInfo = processStartInfo;
				process.Start();
				process.WaitForExit(15000);
				if (process.ExitCode == 0)
				{
					this.subAppendLog("Backup: Success!", LogLevel.Info);
					MessageBox.Show(Resources.message_finished_restore, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				else
				{
					this.subAppendLog(string.Concat(new string[]
					{
						"Error: MySQL Exit Code ",
						process.ExitCode.ToString(),
						", User ",
						this.configuration.dbUser,
						", Password: ",
						this.configuration.dbPass,
						", File: \"",
						path,
						"\""
					}), LogLevel.Error);
					MessageBox.Show(Resources.message_error_restore + " MySQL Exit Code: " + process.ExitCode.ToString(), string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
			catch (Exception ex)
			{
				this.subAppendLog(ex);
			}
		}

		// Token: 0x06000042 RID: 66 RVA: 0x00008AE4 File Offset: 0x00006CE4
		private void threadDatabase(string name, bool reset = false)
		{
			if (!string.IsNullOrEmpty(name))
			{
				this.subAppendLog("Configuration: Creating database [Database \"" + name + "\"]", LogLevel.Info);
				try
				{
					ProcessStartInfo processStartInfo = new ProcessStartInfo(Path.Combine(this.configuration.pathMain, "install", "migrate.bat"), string.Concat(new string[]
					{
						name,
						" ",
						this.configuration.dbHost,
						" ",
						this.configuration.dbPort.ToString(),
						" ",
						this.configuration.dbUser,
						" ",
						this.configuration.dbPass
					}));
					processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
					processStartInfo.WorkingDirectory = Path.Combine(this.configuration.pathMain, "install");
					Process process = new Process();
					process.StartInfo = processStartInfo;
					process.Start();
					process.WaitForExit(15000);
					if (process.ExitCode == 0)
					{
						this.subAppendLog("Configuration: Success!", LogLevel.Info);
						if (reset)
						{
							MessageBox.Show(Resources.message_finished_reset, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						}
						else
						{
							MessageBox.Show(Resources.message_finished_database, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						}
					}
					else
					{
						this.subAppendLog(string.Concat(new string[]
						{
							"Error: Exit Code: ",
							process.ExitCode.ToString(),
							", User: ",
							this.configuration.dbUser,
							", Password: ",
							this.configuration.dbPass
						}), LogLevel.Error);
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
							MessageBox.Show(Resources.message_error_database + " Exit Code " + process.ExitCode.ToString(), string.Empty, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						}
					}
				}
				catch (Exception ex)
				{
					this.subAppendLog(ex);
				}
			}
		}

		// Token: 0x06000043 RID: 67 RVA: 0x00008D80 File Offset: 0x00006F80
		private void timerMonitor_Tick(object sender, EventArgs e)
		{
			string text = IO.GetNewLines(Path.Combine(this.configuration.pathConfig, "arma2oaserver_" + frmMain.serverInstance.ToString() + ".rpt")).ToString();
			text = Regex.Replace(text, "([0-9\\s]{2}:[0-9]{2}:[0-9]{2})\\s\\\"Locality\\sEvent\\\"\\r\\n?", "", RegexOptions.IgnoreCase);
			text = Regex.Replace(text, "(([0-9\\s]{2}:[0-9]{2}:[0-9]{2})\\s)?Unrecognized.*?\\r\\n?", "", RegexOptions.IgnoreCase);
			text = Regex.Replace(text, "Updating\\sbase\\sclass\\s.*\\r\\n?", "", RegexOptions.IgnoreCase);
			this.textLogRpt.AppendText(text);
		}

		// Token: 0x06000044 RID: 68 RVA: 0x00008E08 File Offset: 0x00007008
		private void frmMain_Load(object sender, EventArgs e)
		{
			this.textLog.Text = string.Format(DateTime.Now.ToString() + " Application: Initializing {0} {1}", Application.ProductName, Application.ProductVersion);
			if (!string.IsNullOrEmpty(Settings.Default.uiLanguage))
			{
				try
				{
					Thread.CurrentThread.CurrentUICulture = new CultureInfo(Settings.Default.uiLanguage);
					this.cbxLanguage.SelectedItem = Settings.Default.uiLanguage.ToLower();
				}
				catch (Exception ex)
				{
					this.subAppendLog(ex);
				}
			}
			else
			{
				this.subAppendLog("Error: No valid language is saved!", LogLevel.Error);
			}
			string[] array = new string[frmMain.appInstances];
			for (int i = 0; i < frmMain.appInstances; i++)
			{
				array[i] = (i + 1).ToString();
			}
			this.cbxInstance.Items.Clear();
			this.cbxInstance.Items.AddRange(array);
			this.cbxTemplate.Items.Clear();
			this.cbxTemplate.Items.AddRange(Settings.Default.confTemplates.Replace(" ", "").Split(new char[] { ',' }));
			this.container2_1.Visible = false;
			this.container2_2.Visible = false;
			this.container2_4.Visible = false;
			DialogResult dialogResult = DialogResult.OK;
			if (!((IList<string>)Environment.GetCommandLineArgs()).Contains("-skipsplash"))
			{
				dialogResult = new frmSplash().ShowDialog();
			}
			if (dialogResult != DialogResult.OK)
			{
				this.subAppendLog("Application: Aborted", LogLevel.Info);
				base.Close();
			}
			else
			{
				this.cbxInstance.SelectedIndex = 0;
				base.WindowState = Settings.Default.uiState;
				this.subAppendLog("Application: Restored window state [" + base.WindowState.ToString() + "]", LogLevel.Info);
				if (!((IList<string>)Environment.GetCommandLineArgs()).Contains("-skipwhitelist"))
				{
					frmLog frmLog = new frmLog();
					frmLog.Owner = this;
					frmLog.Location = new Point(base.Right, base.Top);
					frmLog.Size = new Size(frmLog.Width, base.Height);
					frmLog.Show();
				}
				this.threadmain.IsBackground = true;
				this.threadmain.Start();
				this.threadtimer.IsBackground = true;
				this.threadtimer.Start();
			}
		}

		// Token: 0x06000045 RID: 69 RVA: 0x000090D4 File Offset: 0x000072D4
		private void frmMain_Shown(object sender, EventArgs e)
		{
			this.browserAdmin.Load(Settings.Default.uiUrlAdmin);
			this.browserDatabase.Load(Settings.Default.uiUrlDatabase);
		}

		// Token: 0x06000046 RID: 70 RVA: 0x00009104 File Offset: 0x00007304
		private void frmMain_Move(object sender, EventArgs e)
		{
			frmLog frmLog = (frmLog)Application.OpenForms["frmLog"];
			if (frmLog != null)
			{
				frmLog.Size = new Size(frmLog.Width, base.Height);
				frmLog.Location = new Point(base.Right, base.Top);
			}
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00009164 File Offset: 0x00007364
		private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			this._closing = true;
			if (this.timerMonitor.Enabled)
			{
				this.timerMonitor.Stop();
			}
			Settings.Default.uiState = base.WindowState;
			Settings.Default.Save();
		}

		// Token: 0x06000048 RID: 72 RVA: 0x000091B8 File Offset: 0x000073B8
		private void frmMain_ChangePanel(object sender, EventArgs e)
		{
			if (this.btnMenu1.Checked)
			{
				this.subReloadPanel1();
			}
			else if (this.btnMenu2.Checked)
			{
				this.subReloadPanel2();
			}
			else if (this.btnMenu3.Checked)
			{
				this.subReloadPanel3();
			}
			else if (this.btnMenu4.Checked)
			{
				this.container2_1.Visible = false;
				this.container2_3.Visible = false;
				this.container2_2.Visible = false;
				this.container2_4.Visible = true;
			}
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00009268 File Offset: 0x00007468
		private void frmMain_ChangeInstance(object sender, EventArgs e)
		{
			if (frmMain.serverInstance != this.cbxInstance.SelectedIndex + 1)
			{
				if (frmMain.serverInstance > 0)
				{
					this.subAppendLog("Application: Switching instance [Instance " + (this.cbxInstance.SelectedIndex + 1).ToString() + "]", LogLevel.Info);
				}
				frmMain.serverInstance = this.cbxInstance.SelectedIndex + 1;
				this.configuration = new Configuration(frmMain.serverInstance);
				this.configuration.LoadBasicConfig();
				this.configuration.LoadCfgConfig();
				this.configuration.LoadHiveConfig();
				this.configuration.LoadXmlConfig();
				this.configuration.LoadBattleyeConfig();
				for (int i = 1; i <= frmMain.appInstances; i++)
				{
					Configuration configuration = new Configuration(i);
					try
					{
						if (File.Exists(configuration.pathConfigXml))
						{
							configuration.LoadXmlConfig();
							frmMain.listAutoBackupEnabled[i - 1] = configuration.confAutoBackupEnabled;
							frmMain.listAutoBackupInterval[i - 1] = configuration.confAutoBackupInterval;
							frmMain.listAutoBackupPath[i - 1] = configuration.confAutoBackupPath;
						}
						if (File.Exists(configuration.pathConfigHive))
						{
							configuration.LoadHiveConfig();
							frmMain.listDbHost[i - 1] = configuration.dbHost;
							frmMain.listDbPort[i - 1] = configuration.dbPort;
							frmMain.listDbUser[i - 1] = configuration.dbUser;
							frmMain.listDbPass[i - 1] = configuration.dbPass;
							frmMain.listDbName[i - 1] = configuration.dbName;
						}
					}
					catch (Exception ex)
					{
						this.subAppendLog(ex);
					}
				}
				mysql.Close();
				mysql.Connection = new MySqlConnection(string.Format("server={0};port={1};user={2};password={3};", new object[]
				{
					this.configuration.dbHost,
					this.configuration.dbPort.ToString(),
					this.configuration.dbUser,
					this.configuration.dbPass
				}));
				this.configuration.confInstance = frmMain.serverInstance;
				this.configuration.confWorld = Regex.Replace(this.configuration.confTemplate, "[a-z]{4}_[0-9]{1}.", "");
				this.configuration.confWorldId = this.configuration.GetWorldId();
				this.configuration.WriteXmlConfig();
			}
			if (this.timerMonitor.Enabled)
			{
				this.timerMonitor.Stop();
			}
			this.textLogRpt.Clear();
			this.subReloadPanel2();
			this.subReloadResources();
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00009544 File Offset: 0x00007744
		private void subAppendLog(string message, LogLevel level)
		{
			if (base.IsHandleCreated && !base.IsDisposed && !this.textLog.IsDisposed && !this._closing)
			{
				if (base.InvokeRequired)
				{
					base.Invoke(new MethodInvoker(delegate
					{
						this.subAppendLog(message, level);
					}));
					return;
				}
				RichTextBox richTextBox = this.textLog;
				string text = richTextBox.Text;
				richTextBox.Text = string.Concat(new string[]
				{
					text,
					Environment.NewLine,
					DateTime.Now.ToString(),
					" ",
					message
				});
			}
			frmMain.logger.Log(level, message);
		}

		// Token: 0x0600004B RID: 75 RVA: 0x0000965C File Offset: 0x0000785C
		private void subAppendLog(Exception ex)
		{
			if (base.IsHandleCreated && !base.IsDisposed && !this.textLog.IsDisposed && !this._closing)
			{
				if (base.InvokeRequired)
				{
					base.Invoke(new MethodInvoker(delegate
					{
						this.subAppendLog(ex);
					}));
					return;
				}
				RichTextBox richTextBox = this.textLog;
				string text = richTextBox.Text;
				richTextBox.Text = string.Concat(new string[]
				{
					text,
					Environment.NewLine,
					DateTime.Now.ToString(),
					" Error: Exception: ",
					ex.Message
				});
			}
			if (ex.InnerException != null)
			{
				frmMain.logger.Log(LogLevel.Fatal, ex.InnerException.ToString() + " [" + ex.Message + "]");
			}
			else
			{
				frmMain.logger.Log(LogLevel.Fatal, ex.ToString() + "[" + ex.Message + "]");
			}
			if (ex.StackTrace != null)
			{
				frmMain.logger.Log(LogLevel.Trace, ex.StackTrace);
			}
		}

		// Token: 0x0600004C RID: 76 RVA: 0x000097F4 File Offset: 0x000079F4
		private void subReloadPanel1()
		{
			this.btnMenu1.Checked = true;
			this.btnMenu2.Checked = false;
			this.btnMenu3.Checked = false;
			this.btnMenu4.Checked = false;
			this.container2_1.Visible = true;
			this.container2_2.Visible = false;
			this.container2_3.Visible = false;
			this.container2_4.Visible = false;
			this.btnSave1.Enabled = true;
			this.btnSave2.Enabled = true;
			this.btnSave3.Enabled = true;
			this.cbxDatabase.Enabled = true;
			this.cbxDatabase.Items.Clear();
			if (Directory.Exists(this.configuration.pathConfig))
			{
				try
				{
					if (File.Exists(this.configuration.pathConfigCfg))
					{
						this.configuration.LoadCfgConfig();
						this.textHostname.Enabled = true;
						this.textBuild.Enabled = true;
						this.textMessage.Enabled = true;
						this.textRegularCheck.Enabled = true;
						this.textOnUserConnected.Enabled = true;
						this.textOnUserDisconnected.Enabled = true;
						this.textOnUnsigned.Enabled = true;
						this.textOnHacked.Enabled = true;
						this.textOnDifferent.Enabled = true;
						this.textDoubleId.Enabled = true;
						this.textPasswordServer.Enabled = true;
						this.textPasswordAdmin.Enabled = true;
						this.numMaxPlayers.Enabled = true;
						this.numMessageInterval.Enabled = true;
						this.numVonQuality.Enabled = true;
						this.numVerifySignatures.Enabled = true;
						this.numSecureId.Enabled = true;
						this.cbxReportingIp.Enabled = true;
						this.cbxDifficulty.Enabled = true;
						this.checkPersistent.Enabled = true;
						this.checkDuplicate.Enabled = true;
						this.checkRmod.Enabled = true;
						this.checkBattleye.Enabled = true;
						this.checkVon.Enabled = true;
						this.cbxTemplate.Enabled = true;
						this.textHostname.Text = this.configuration.confHostname;
						this.textBuild.Text = this.configuration.confRequiredBuild.ToString();
						this.textMessage.Text = this.configuration.confMotd;
						this.textRegularCheck.Text = this.configuration.confRegularCheck;
						this.textOnUserConnected.Text = this.configuration.confOnUserConnected;
						this.textOnUserDisconnected.Text = this.configuration.confOnUserDisconnected;
						this.textOnUnsigned.Text = this.configuration.confOnUnsignedData;
						this.textOnHacked.Text = this.configuration.confOnHackedData;
						this.textOnDifferent.Text = this.configuration.confOnDifferentData;
						this.textDoubleId.Text = this.configuration.confDoubleIdDetected;
						this.textPasswordServer.Text = this.configuration.confPasswordServer;
						this.textPasswordAdmin.Text = this.configuration.confPasswordAdmin;
						this.numMaxPlayers.Value = this.configuration.confMaxPlayers;
						this.numMessageInterval.Value = this.configuration.confMotdInterval;
						this.numVonQuality.Value = this.configuration.confVonQuality;
						this.numVerifySignatures.Value = this.configuration.confVerifySignatures;
						this.numSecureId.Value = this.configuration.confSecureId;
						this.cbxDifficulty.SelectedItem = this.configuration.confDifficulty;
						this.checkPersistent.Checked = this.configuration.confPersistent;
						this.checkDuplicate.Checked = this.configuration.confKickDuplicate;
						this.checkRmod.Checked = this.configuration.confRmod;
						this.checkVon.Checked = this.configuration.confVon;
						this.checkBattleye.Checked = this.configuration.confBattleye;
						if (this.cbxReportingIp.Items.Contains(this.configuration.confReportingIp))
						{
							this.cbxReportingIp.SelectedItem = this.configuration.confReportingIp;
						}
						else
						{
							this.cbxReportingIp.Text = this.configuration.confReportingIp;
						}
						if (this.cbxTemplate.Items.Contains(this.configuration.confTemplate.Replace("rmod", "dayz").Remove(4, 2)))
						{
							this.cbxTemplate.SelectedItem = this.configuration.confTemplate.Replace("rmod", "dayz").Remove(4, 2);
						}
						else
						{
							this.subAppendLog("Warning: Mission Template does not match any preset", LogLevel.Warn);
							this.cbxTemplate.SelectedItem = "dayz.chernarus";
						}
					}
					else
					{
						this.subAppendLog("Error: File not found: \"" + this.configuration.pathConfigCfg + "\"", LogLevel.Error);
						this.textHostname.Enabled = false;
						this.textBuild.Enabled = false;
						this.textMessage.Enabled = false;
						this.textRegularCheck.Enabled = false;
						this.textOnUserConnected.Enabled = false;
						this.textOnUserDisconnected.Enabled = false;
						this.textOnUnsigned.Enabled = false;
						this.textOnHacked.Enabled = false;
						this.textOnDifferent.Enabled = false;
						this.textDoubleId.Enabled = false;
						this.textPasswordServer.Enabled = false;
						this.textPasswordAdmin.Enabled = false;
						this.numMaxPlayers.Enabled = false;
						this.numMessageInterval.Enabled = false;
						this.numVonQuality.Enabled = false;
						this.numSecureId.Enabled = false;
						this.numVerifySignatures.Enabled = false;
						this.cbxReportingIp.Enabled = false;
						this.cbxDifficulty.Enabled = false;
						this.checkPersistent.Enabled = false;
						this.checkDuplicate.Enabled = false;
						this.checkRmod.Enabled = false;
						this.checkBattleye.Enabled = false;
						this.checkVon.Enabled = false;
						this.cbxTemplate.Enabled = false;
					}
					if (File.Exists(this.configuration.pathConfigXml))
					{
						this.configuration.LoadXmlConfig();
						this.textWhitelistMessage.Enabled = true;
						this.textModlist.Enabled = true;
						this.textPort.Enabled = true;
						this.textWelcomeMessage.Enabled = true;
						if (this.checkBattleye.Checked)
						{
							this.checkWhitelist.Enabled = true;
							this.checkWhitelist.Checked = this.configuration.beWhitelistEnabled;
						}
						else
						{
							this.checkWhitelist.Enabled = false;
							this.checkWhitelist.Checked = false;
						}
						this.textWhitelistMessage.Text = this.configuration.beWhitelistMessage;
						this.textWelcomeMessage.Text = this.configuration.confWelcome;
						this.textModlist.Text = this.configuration.confModlist;
						this.textPort.Text = this.configuration.bePort.ToString();
					}
					else
					{
						this.subAppendLog("Error: File not found: \"" + this.configuration.pathConfigXml + "\"", LogLevel.Error);
						this.checkWhitelist.Enabled = false;
						this.textWhitelistMessage.Enabled = false;
						this.textWelcomeMessage.Enabled = false;
						this.textModlist.Enabled = false;
						this.textPort.Enabled = false;
					}
					if (File.Exists(this.configuration.CheckBattleyeConfig(this.configuration.pathConfigBattleye)))
					{
						this.configuration.LoadBattleyeConfig();
						this.textPasswordRcon.Enabled = true;
						this.numMaxPing.Enabled = true;
						this.textPasswordRcon.Text = this.configuration.bePass;
						this.numMaxPing.Value = this.configuration.beMaxPing;
					}
					else
					{
						this.subAppendLog("Warning: File not found: \"" + this.configuration.pathConfigBattleye + "\"", LogLevel.Warn);
						this.textPasswordRcon.Enabled = false;
						this.numMaxPing.Enabled = false;
					}
					if (File.Exists(this.configuration.pathConfigBasic))
					{
						this.configuration.LoadBasicConfig();
						this.numMinBandwidth.Enabled = true;
						this.numMaxBandwidth.Enabled = true;
						this.numMaxMessages.Enabled = true;
						this.numMaxSizeGuaranteed.Enabled = true;
						this.numMaxSizeNonguaranteed.Enabled = true;
						this.numMinError.Enabled = true;
						this.numMinErrorNear.Enabled = true;
						this.numMaxCustomsize.Enabled = true;
						this.numMinBandwidth.Value = this.configuration.confMinBandwidth;
						this.numMaxBandwidth.Value = this.configuration.confMaxBandwidth;
						this.numMaxMessages.Value = this.configuration.confMaxMsgSend;
						this.numMaxSizeGuaranteed.Value = this.configuration.confMaxSizeGuaranteed;
						this.numMaxSizeNonguaranteed.Value = this.configuration.confMaxSizeNonguaranteed;
						this.numMinError.Value = this.configuration.confMinErrorToSend;
						this.numMinErrorNear.Value = this.configuration.confMinErrorToSendNear;
						this.numMaxCustomsize.Value = this.configuration.confMaxCustomFileSize;
					}
					else
					{
						this.subAppendLog("Error: File not found: \"" + this.configuration.pathConfigBasic + "\"", LogLevel.Error);
						this.numMinBandwidth.Enabled = false;
						this.numMaxBandwidth.Enabled = false;
						this.numMaxMessages.Enabled = false;
						this.numMaxSizeGuaranteed.Enabled = false;
						this.numMaxSizeNonguaranteed.Enabled = false;
						this.numMinError.Enabled = false;
						this.numMinErrorNear.Enabled = false;
						this.numMaxCustomsize.Enabled = false;
					}
					if (File.Exists(this.configuration.pathConfigHive))
					{
						this.configuration.LoadHiveConfig();
						this.trackTimezone.Enabled = true;
						this.checkDaytime.Enabled = true;
						this.checkDaytime.Checked = this.configuration.confDaytime;
						int num = Convert.ToInt32(TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now).TotalHours) + this.configuration.confTimezone;
						if (num < 0)
						{
							this.textTimezone.Text = "UTC " + num.ToString();
							if (num < -12)
							{
								this.trackTimezone.Value = -12;
								this.subAppendLog("Warning: Timezone Value is too small (\"" + num.ToString() + "\")!", LogLevel.Warn);
							}
							else
							{
								this.trackTimezone.Value = num;
							}
						}
						else
						{
							this.textTimezone.Text = "UTC +" + num.ToString();
							if (num > 12)
							{
								this.trackTimezone.Value = 12;
								this.subAppendLog("Warning: Timezone Value is too big (\"" + num.ToString() + "\")!", LogLevel.Warn);
							}
							else
							{
								this.trackTimezone.Value = num;
							}
						}
						if (!this.configuration.confDaytime)
						{
							int num2 = DateTime.Now.ToUniversalTime().Hour + this.trackTimezone.Value;
							if (num2 > 23)
							{
								num2 -= 24;
							}
							this.labelTime.Text = num2.ToString("D2") + ":" + DateTime.Now.ToUniversalTime().Minute.ToString("D2");
						}
						else
						{
							this.labelTime.Text = this.configuration.confStaticHour.ToString("D2") + ":00";
						}
					}
					else
					{
						this.subAppendLog("Error: File not found: \"" + this.configuration.pathConfigHive + "\"", LogLevel.Error);
						this.trackTimezone.Enabled = false;
						this.checkDaytime.Enabled = false;
					}
				}
				catch (Exception ex)
				{
					this.subAppendLog(ex);
					this.btnSave1.Enabled = false;
					this.btnSave2.Enabled = false;
					this.btnSave3.Enabled = false;
				}
				try
				{
					mysql.Open();
					mysql.ChangeDatabase(this.configuration.dbName);
					MySqlCommand mySqlCommand = new MySqlCommand("SELECT `inventory`, `backpack` FROM `instance` WHERE `id` = ?instance", mysql.Connection);
					mySqlCommand.Parameters.AddWithValue("?instance", frmMain.serverInstance);
					MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
					mySqlDataReader.Read();
					if (mySqlDataReader.HasRows)
					{
						this.cbxLoadout.Text = mySqlDataReader.GetString("inventory");
						this.cbxLoadoutBackpack.Text = mySqlDataReader.GetString("backpack");
					}
					mySqlDataReader.Close();
					List<string> list = new List<string>();
					mySqlDataReader = new MySqlCommand("SHOW DATABASES", mysql.Connection).ExecuteReader();
					while (mySqlDataReader.Read())
					{
						list.Add(mySqlDataReader["Database"].ToString());
					}
					mySqlDataReader.Close();
					foreach (string text in list)
					{
						mySqlDataReader = new MySqlCommand(string.Format("SHOW TABLES FROM `{0}`", text), mysql.Connection).ExecuteReader();
						while (mySqlDataReader.Read())
						{
							if (mySqlDataReader["tables_in_" + text].ToString() == "instance")
							{
								this.cbxDatabase.Items.Add(text);
							}
						}
						mySqlDataReader.Close();
					}
					this.cbxDatabase.Text = this.configuration.dbName;
				}
				catch (MySqlException ex2)
				{
					this.subAppendLog("Error: MySQL Exception: " + ex2.Message, LogLevel.Error);
				}
				catch (Exception ex)
				{
					this.subAppendLog(ex);
				}
				finally
				{
					mysql.Close();
				}
				this.tab1.SelectTab(0);
			}
			else
			{
				this.subAppendLog("Error: Directory not found: \"" + this.configuration.pathConfig + "\"", LogLevel.Fatal);
				this.subReloadPanel2();
			}
		}

		// Token: 0x0600004D RID: 77 RVA: 0x0000A844 File Offset: 0x00008A44
		private void subReloadPanel2()
		{
			this.btnMenu1.Checked = false;
			this.btnMenu2.Checked = true;
			this.btnMenu3.Checked = false;
			this.btnMenu4.Checked = false;
			this.container2_1.Visible = false;
			this.container2_2.Visible = true;
			this.container2_3.Visible = false;
			this.container2_4.Visible = false;
			if (string.IsNullOrEmpty(this.configuration.dbHost) || string.IsNullOrEmpty(this.configuration.dbPort.ToString()) || string.IsNullOrEmpty(this.configuration.dbUser))
			{
				this.groupLogin.Enabled = false;
			}
			else
			{
				this.groupLogin.Enabled = true;
				this.textMysqlHost.Text = this.configuration.dbHost;
				this.textMysqlPort.Text = this.configuration.dbPort.ToString();
				this.textMysqlUser.Text = this.configuration.dbUser;
				this.textMysqlPass.Text = this.configuration.dbPass;
			}
			this.browserAdmin.Load(Settings.Default.uiUrlAdmin + "?instance=" + frmMain.serverInstance.ToString());
			this.tab2.SelectTab(0);
		}

		// Token: 0x0600004E RID: 78 RVA: 0x0000A9B8 File Offset: 0x00008BB8
		private void subReloadPanel3()
		{
			this.btnMenu1.Checked = false;
			this.btnMenu2.Checked = false;
			this.btnMenu3.Checked = true;
			this.btnMenu4.Checked = false;
			this.container2_1.Visible = false;
			this.container2_2.Visible = false;
			this.container2_3.Visible = true;
			this.container2_4.Visible = false;
			this.btnSave4.Enabled = true;
			this.checkWhitelisted.Checked = false;
			this.textPlayerName.Clear();
			this.textPlayerUid.Clear();
			this.textPlayerUid.Enabled = false;
			this.textPlayerGuid.Clear();
			this.textInventory.Clear();
			this.textBackpack.Clear();
			this.textMedical.Clear();
			this.textPosition.Clear();
			this.groupSurvivor.Enabled = false;
			this.listPlayers.Items.Clear();
			this.textBackupPath.Text = this.configuration.confAutoBackupPath;
			this.numBackupInterval.Value = this.configuration.confAutoBackupInterval;
			if (frmMain.listAutoBackupEnabled[frmMain.serverInstance - 1])
			{
				this.btnAutoBackup.Text = Resources.button_autobackup_stop;
			}
			else
			{
				this.btnAutoBackup.Text = Resources.button_autobackup_start;
			}
			try
			{
				try
				{
					this.listPlayers.Enabled = true;
					this.btnPlayerAdd.Enabled = true;
					this.checkWhitelisted.Enabled = true;
					this.groupProfile.Enabled = true;
					mysql.Open();
					mysql.ChangeDatabase(this.configuration.dbName);
					MySqlDataReader mySqlDataReader = new MySqlCommand("SELECT * FROM `profile`", mysql.Connection).ExecuteReader();
					while (mySqlDataReader.Read())
					{
						this.listPlayers.Items.Add(mySqlDataReader.GetString("name"));
					}
					mySqlDataReader.Close();
				}
				catch (MySqlException ex)
				{
					this.subAppendLog("Error: MySQL Exception: " + ex.Message, LogLevel.Error);
					this.btnSave4.Enabled = false;
					this.listPlayers.Enabled = false;
					this.btnPlayerAdd.Enabled = false;
					this.checkWhitelisted.Enabled = false;
					this.groupProfile.Enabled = false;
				}
				finally
				{
					mysql.Close();
				}
				MySqlConnection mySqlConnection = mysql.Connection;
				if (!string.IsNullOrEmpty(this.configuration.beWhitelistHost) && !string.IsNullOrEmpty(this.configuration.beWhitelistUser) && !string.IsNullOrEmpty(this.configuration.beWhitelistPass) && !string.IsNullOrEmpty(this.configuration.beWhitelistName))
				{
					mySqlConnection = new MySqlConnection(string.Format("server={0};port={1};user={2};password={3};database={4};", new object[]
					{
						this.configuration.beWhitelistHost,
						this.configuration.beWhitelistPort.ToString(),
						this.configuration.beWhitelistUser,
						this.configuration.beWhitelistPass,
						this.configuration.beWhitelistName
					}));
				}
				try
				{
					mySqlConnection.Open();
					MySqlDataReader mySqlDataReader = new MySqlCommand("SELECT * FROM `whitelist`", mySqlConnection).ExecuteReader();
					while (mySqlDataReader.Read())
					{
						string @string = mySqlDataReader.GetString("name");
						if (!this.listPlayers.Items.Contains(@string) && !this.listPlayers.Items.Contains(@string.Replace(" ", "")))
						{
							this.listPlayers.Items.Add(@string);
						}
					}
					mySqlDataReader.Close();
				}
				catch (MySqlException ex2)
				{
					this.subAppendLog("Error: MySQL Exception: " + ex2.Message, LogLevel.Error);
				}
				finally
				{
					mySqlConnection.Close();
				}
			}
			catch (Exception ex3)
			{
				this.subAppendLog(ex3);
				this.btnSave4.Enabled = false;
			}
			this.tab3.SelectTab(0);
		}

		// Token: 0x0600004F RID: 79 RVA: 0x0000AE6C File Offset: 0x0000906C
		private void subReloadResources()
		{
			this.labelAdminPassword.Text = Resources.passwordadmin + ":";
			this.labelAppName.Text = Application.ProductName;
			this.labelChooseLanguage.Text = Resources.sentence_chooselanguage;
			this.labelCodecQuality.Text = Resources.codecquality + ":";
			this.labelDifficulty.Text = Resources.difficulty + ":";
			this.labelEnterBackupInterval.Text = Resources.sentence_backupinterval;
			this.labelLoadout.Text = Resources.loadout + ":";
			this.labelLoadoutBackpack.Text = Resources.loadoutbackpack + ":";
			this.labelDescription1.Text = Resources.sentence_menu1_description;
			this.labelDescription2.Text = Resources.sentence_menu2_description;
			this.labelDescription3.Text = Resources.sentence_menu3_description;
			this.labelDescription4.Text = Resources.sentence_menu4_description;
			this.labelMaxBandwidth.Text = Resources.maxbandwidth + ":";
			this.labelMaxBandwidthUnit.Text = Resources.bytespersecond;
			this.labelMaxCustomSize.Text = Resources.maxcustomsize + ":";
			this.labelMaxCustomSizeUnit.Text = Resources.kilobyte;
			this.labelMaxMsgSent.Text = Resources.maxmsgsent + ":";
			this.labelMaxPing.Text = Resources.maxping + ":";
			this.labelMaxPlayers.Text = Resources.maxplayers + ":";
			this.labelMaxSizeGuaranteed.Text = Resources.maxsizeguaranteed + ":";
			this.labelMaxSizeGuaranteedUnit.Text = Resources.bytes;
			this.labelMaxSizeNonguaranteed.Text = Resources.maxsizenonguaranteed + ":";
			this.labelMaxSizeNonguaranteedUnit.Text = Resources.bytes;
			this.labelModlist.Text = Resources.modlist + ":";
			this.labelMinBandwidth.Text = Resources.minbandwidth + ":";
			this.labelMinBandwidthUnit.Text = Resources.bytespersecond;
			this.labelMinErrtoSend.Text = Resources.minerrtosend + ":";
			this.labelMinErrtoSendNear.Text = Resources.minerrtosendnear + ":";
			this.labelNoticeMessage.Text = Resources.sentence_message;
			this.labelNoticeReset.Text = Resources.sentence_reset;
			this.labelMySqlHost.Text = Resources.mysql_host + ":";
			this.labelMySqlCredentials.Text = Resources.mysql_credentials + ":";
			this.labelPassword.Text = Resources.password + ":";
			this.labelPathBackupFolder.Text = Resources.backupfolder + ":";
			this.labelPort.Text = Resources.port + ":";
			this.labelRconPassword.Text = Resources.passwordrcon + ":";
			this.labelReportingIp.Text = Resources.reportingip + ":";
			this.labelRequiredBuild.Text = Resources.build + ":";
			this.labelRequireSecureId.Text = Resources.requiresecureid + ":";
			this.labelWelcomeMessage.Text = Resources.messagejoin + ":";
			this.labelSelectInstance.Text = Resources.sentence_selectinstance;
			this.labelSelectDatabase.Text = Resources.databasename + ":";
			this.labelServerName.Text = Resources.servername + ":";
			this.labelTemplate.Text = Resources.template + ":";
			this.labelTimeBetweenMessage.Text = Resources.messagetime + ":";
			this.labelTimezone.Text = Resources.timezone + ":";
			this.labelVerifySignatures.Text = Resources.verifysignatures + ":";
			this.labelVersionText.Text = Resources.version + ":";
			this.labelWhitelistMessage.Text = Resources.message + ":";
			this.labelPlayerName.Text = Resources.name + ":";
			this.labelPlayerUid.Text = Resources.uid + ":";
			this.labelPlayerGuid.Text = Resources.guid + ":";
			this.labelBackpack.Text = Resources.backpack + ":";
			this.labelInventory.Text = Resources.inventory + ":";
			this.labelMedical.Text = Resources.medical + ":";
			this.labelPosition.Text = Resources.position + ":";
			this.btnBackup.Text = Resources.button_backup;
			this.btnBackupBrowse.Text = Resources.button_browse;
			this.btnDatabase.Text = Resources.button_add_database;
			this.btnExit.Text = Resources.button_exit;
			this.btnLog.Text = Resources.button_log;
			this.btnLogClear.Text = Resources.button_clear;
			this.btnLogMonitor.Text = Resources.button_monitor_start;
			this.btnPlayerAdd.Text = Resources.button_add_player;
			this.btnMenu1.Text = Resources.button_menu1;
			this.btnMenu2.Text = Resources.button_menu2;
			this.btnMenu3.Text = Resources.button_menu3;
			this.btnMenu4.Text = Resources.button_menu4;
			this.btnMysqlUser.Text = Resources.button_save;
			this.btnMysqlHost.Text = Resources.button_save;
			this.btnRandomPass.Text = Resources.button_random;
			this.btnReset.Text = Resources.button_reset;
			this.btnRestore.Text = Resources.button_restore;
			this.btnSave1.Text = Resources.button_save_config;
			this.btnSave2.Text = Resources.button_save_config;
			this.btnSave3.Text = Resources.button_save_config;
			this.btnSave4.Text = Resources.button_save_player;
			this.checkBattleye.Text = Resources.check_enabled;
			this.checkDuplicate.Text = Resources.check_duplicate;
			this.checkPersistent.Text = Resources.check_persistent;
			this.checkRmod.Text = Resources.check_rmod;
			this.checkVon.Text = Resources.check_enabled;
			this.checkWhitelist.Text = Resources.check_enabled;
			this.checkWhitelisted.Text = Resources.check_whitelisted;
			this.checkDaytime.Text = Resources.check_daytime;
			this.tab1Page1.Text = Resources.tab1_page1;
			this.tab1Page2.Text = Resources.tab1_page2;
			this.tab1Page3.Text = Resources.tab1_page3;
			this.tab2Page1.Text = Resources.tab2_page1;
			this.tab2Page2.Text = Resources.tab2_page2;
			this.tab2Page3.Text = Resources.tab2_page3;
			this.tab3Page1.Text = Resources.tab3_page1;
			this.tab3Page2.Text = Resources.tab3_page2;
			this.tab3Page3.Text = Resources.tab3_page3;
			this.groupAbout.Text = Resources.group_about;
			this.groupBackup.Text = Resources.group_backup;
			this.groupAutoBackup.Text = Resources.group_autobackup;
			this.groupBattleye.Text = Resources.group_battleye;
			this.groupLogin.Text = Resources.group_mysql_details;
			this.groupMessage.Text = Resources.group_message;
			this.groupTemplate.Text = Resources.group_template;
			this.groupProfile.Text = Resources.group_profile;
			this.groupSurvivor.Text = Resources.group_survivor;
			this.groupReset.Text = Resources.group_reset;
			this.groupRestore.Text = Resources.group_restore;
			this.groupScripting.Text = Resources.group_scripting;
			this.groupSettings.Text = Resources.group_settings;
			this.groupSignatures.Text = Resources.group_signatures;
			this.groupTime.Text = Resources.group_time;
			this.groupNetwork.Text = Resources.group_tuning_network;
			this.groupAdditional.Text = Resources.group_other;
			this.groupVon.Text = Resources.group_von;
			this.groupWhitelist.Text = Resources.group_whitelist;
			if (this.configuration.confAutoBackupEnabled)
			{
				this.btnAutoBackup.Text = Resources.button_autobackup_stop;
			}
			else
			{
				this.btnAutoBackup.Text = Resources.button_autobackup_start;
			}
		}

		// Token: 0x06000050 RID: 80 RVA: 0x0000B7D0 File Offset: 0x000099D0
		private void btnSave1_Click(object sender, EventArgs e)
		{
			this.subAppendLog("Configuration: Saving [Panel \"" + Resources.tab1_page1 + "\"]", LogLevel.Info);
			string confWorld = this.configuration.confWorld;
			this.configuration.confDaytime = this.checkDaytime.Checked;
			this.configuration.confDifficulty = this.cbxDifficulty.SelectedItem.ToString();
			this.configuration.confMaxPlayers = Convert.ToInt32(this.numMaxPlayers.Value);
			this.configuration.confMotdInterval = Convert.ToInt32(this.numMessageInterval.Value);
			this.configuration.confPersistent = this.checkPersistent.Checked;
			this.configuration.confRequiredBuild = this.textBuild.Text;
			this.configuration.confRmod = this.checkRmod.Checked;
			this.configuration.confTimezone = Convert.ToInt32((double)this.trackTimezone.Value - TimeZone.CurrentTimeZone.GetUtcOffset(DateTime.Now).TotalHours);
			this.configuration.confTemplate = this.cbxTemplate.SelectedItem.ToString().Insert(4, "_" + this.configuration.confInstance.ToString());
			this.configuration.confVon = this.checkVon.Checked;
			this.configuration.confVonQuality = Convert.ToInt32(this.numVonQuality.Value);
			this.configuration.confWorld = Regex.Replace(this.configuration.confTemplate, "[a-z]{4}_[0-9]{1}.", string.Empty);
			this.configuration.confWorldId = this.configuration.GetWorldId();
			this.configuration.confWelcome = this.textWelcomeMessage.Text;
			if (!string.IsNullOrEmpty(this.cbxReportingIp.Text))
			{
				this.configuration.confReportingIp = this.cbxReportingIp.SelectedItem.ToString();
			}
			else
			{
				this.configuration.confReportingIp = "127.0.0.1";
			}
			if (!string.IsNullOrEmpty(this.cbxDatabase.Text))
			{
				this.configuration.dbName = this.cbxDatabase.Text;
			}
			if (!string.IsNullOrEmpty(this.textPort.Text))
			{
				this.configuration.bePort = Convert.ToInt32(this.textPort.Text);
			}
			if (!string.IsNullOrEmpty(this.textHostname.Text))
			{
				this.configuration.confHostname = this.textHostname.Text;
			}
			if (string.IsNullOrEmpty(this.textMessage.Text))
			{
				this.configuration.confMotd = "\"\"";
			}
			else
			{
				this.configuration.confMotd = this.textMessage.Text;
			}
			if (confWorld != this.configuration.confWorld)
			{
				try
				{
					mysql.Open();
					mysql.ChangeDatabase(this.configuration.dbName);
					MySqlCommand mySqlCommand = new MySqlCommand("SELECT `folder` FROM `world` WHERE `id` = ?worldid", mysql.Connection);
					mySqlCommand.Parameters.AddWithValue("?worldid", this.configuration.confWorldId);
					MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
					mySqlDataReader.Read();
					if (mySqlDataReader.HasRows)
					{
						this.configuration.confModlist = mySqlDataReader.GetString("folder");
					}
				}
				catch (MySqlException ex)
				{
					this.subAppendLog("Error: MySQL Exception: " + ex.Message, LogLevel.Error);
				}
				catch (Exception ex2)
				{
					this.subAppendLog(ex2);
				}
				finally
				{
					mysql.Close();
				}
				if (!this.configuration.confModlist.EndsWith(";"))
				{
					Configuration configuration = this.configuration;
					configuration.confModlist += ";";
				}
				if (!this.configuration.confModlist.ToLower().Contains("@dayzcc"))
				{
					Configuration configuration2 = this.configuration;
					configuration2.confModlist += "@dayzcc;";
				}
			}
			if (this.checkRmod.Checked)
			{
				this.configuration.confTemplate = this.configuration.confTemplate.Replace("dayz", "rmod");
				if (!this.configuration.confModlist.ToLower().Contains("@rmod"))
				{
					if (!this.configuration.confModlist.EndsWith(";"))
					{
						Configuration configuration3 = this.configuration;
						configuration3.confModlist += ";";
					}
					Configuration configuration4 = this.configuration;
					configuration4.confModlist += "@rMod;";
				}
			}
			else
			{
				this.configuration.confTemplate = this.configuration.confTemplate.Replace("rmod", "dayz");
				if (this.configuration.confModlist.ToLower().Contains("@rmod;"))
				{
					this.configuration.confModlist = this.configuration.confModlist.Remove(this.configuration.confModlist.ToLower().IndexOf("@rmod"), 6);
				}
				else if (this.configuration.confModlist.ToLower().Contains("@rmod"))
				{
					this.configuration.confModlist = this.configuration.confModlist.Remove(this.configuration.confModlist.ToLower().IndexOf("@rmod"), 5);
				}
			}
			try
			{
				mysql.Open();
				mysql.ChangeDatabase(this.configuration.dbName);
				MySqlCommand mySqlCommand = new MySqlCommand("UPDATE `instance` SET `world_id` = ?worldid WHERE `id` = ?instance", mysql.Connection);
				mySqlCommand.Parameters.AddWithValue("?worldid", this.configuration.confWorldId);
				mySqlCommand.Parameters.AddWithValue("?instance", frmMain.serverInstance);
				mySqlCommand.ExecuteNonQuery();
			}
			catch (MySqlException ex)
			{
				this.subAppendLog("Error: MySQL Exception: " + ex.Message, LogLevel.Error);
			}
			catch (Exception ex2)
			{
				this.subAppendLog(ex2);
			}
			finally
			{
				mysql.Close();
			}
			if (File.Exists(this.configuration.pathConfigCfg))
			{
				this.configuration.WriteCfgConfig();
			}
			else
			{
				this.subAppendLog("Error: File not found: \"" + this.configuration.pathConfigCfg + "\"", LogLevel.Error);
			}
			if (File.Exists(this.configuration.pathConfigHive))
			{
				this.configuration.WriteHiveConfig();
			}
			else
			{
				this.subAppendLog("Error: File not found: \"" + this.configuration.pathConfigHive + "\"", LogLevel.Error);
			}
			if (File.Exists(this.configuration.pathConfigXml))
			{
				this.configuration.WriteXmlConfig();
			}
			else
			{
				this.subAppendLog("Error: File not found: \"" + this.configuration.pathConfigXml + "\"", LogLevel.Error);
			}
			this.textModlist.Text = this.configuration.confModlist;
		}

		// Token: 0x06000051 RID: 81 RVA: 0x0000BFAC File Offset: 0x0000A1AC
		private void btnSave2_Click(object sender, EventArgs e)
		{
			this.subAppendLog("Configuration: Saving [Panel \"" + Resources.tab1_page2 + "\"]", LogLevel.Info);
			this.configuration.beMaxPing = Convert.ToInt32(this.numMaxPing.Value);
			this.configuration.bePass = this.textPasswordRcon.Text;
			this.configuration.beWhitelistEnabled = this.checkWhitelist.Checked;
			this.configuration.beWhitelistMessage = this.textWhitelistMessage.Text;
			this.configuration.confBattleye = this.checkBattleye.Checked;
			this.configuration.confDoubleIdDetected = this.textDoubleId.Text;
			this.configuration.confKickDuplicate = this.checkDuplicate.Checked;
			this.configuration.confOnUserConnected = this.textOnUserConnected.Text;
			this.configuration.confOnUserDisconnected = this.textOnUserDisconnected.Text;
			this.configuration.confOnUnsignedData = this.textOnUnsigned.Text;
			this.configuration.confOnHackedData = this.textOnHacked.Text;
			this.configuration.confOnDifferentData = this.textOnDifferent.Text;
			this.configuration.confPasswordAdmin = this.textPasswordAdmin.Text;
			this.configuration.confPasswordServer = this.textPasswordServer.Text;
			this.configuration.confRegularCheck = this.textRegularCheck.Text;
			this.configuration.confVerifySignatures = Convert.ToInt32(this.numVerifySignatures.Value);
			this.configuration.confSecureId = Convert.ToInt32(this.numSecureId.Value);
			if (File.Exists(this.configuration.pathConfigXml))
			{
				this.configuration.WriteXmlConfig();
			}
			else
			{
				this.subAppendLog("Error: File not found: \"" + this.configuration.pathConfigXml + "\"", LogLevel.Error);
			}
			if (File.Exists(this.configuration.pathConfigCfg))
			{
				this.configuration.WriteCfgConfig();
			}
			else
			{
				this.subAppendLog("Error: File not found: \"" + this.configuration.pathConfigCfg + "\"", LogLevel.Error);
			}
			if (File.Exists(this.configuration.pathConfigBattleye))
			{
				this.configuration.WriteBattleyeConfig();
			}
			else
			{
				this.subAppendLog("Warning: File not found: \"" + this.configuration.pathConfigBattleye + "\"", LogLevel.Warn);
			}
		}

		// Token: 0x06000052 RID: 82 RVA: 0x0000C24C File Offset: 0x0000A44C
		private void btnSave3_Click(object sender, EventArgs e)
		{
			this.subAppendLog("Configuration: Saving [Panel \"" + Resources.tab1_page3 + "\"]", LogLevel.Info);
			this.configuration.confMaxCustomFileSize = Convert.ToInt32(this.numMaxCustomsize.Value);
			this.configuration.confMinBandwidth = this.numMinBandwidth.Value;
			this.configuration.confMaxBandwidth = this.numMaxBandwidth.Value;
			this.configuration.confMaxMsgSend = this.numMaxMessages.Value;
			this.configuration.confMaxSizeGuaranteed = this.numMaxSizeGuaranteed.Value;
			this.configuration.confMaxSizeNonguaranteed = this.numMaxSizeNonguaranteed.Value;
			this.configuration.confMinErrorToSend = this.numMinError.Value;
			this.configuration.confMinErrorToSendNear = this.numMinErrorNear.Value;
			this.configuration.confModlist = this.textModlist.Text;
			try
			{
				mysql.Open();
				mysql.ChangeDatabase(this.configuration.dbName);
				if (!string.IsNullOrEmpty(this.cbxLoadout.Text))
				{
					MySqlCommand mySqlCommand = new MySqlCommand("UPDATE `instance` SET `inventory` = ?inventory WHERE `id` = ?instance", mysql.Connection);
					mySqlCommand.Parameters.AddWithValue("?inventory", this.cbxLoadout.Text);
					mySqlCommand.Parameters.AddWithValue("?instance", frmMain.serverInstance);
					mySqlCommand.ExecuteNonQuery();
				}
				if (!string.IsNullOrEmpty(this.cbxLoadoutBackpack.Text))
				{
					MySqlCommand mySqlCommand = new MySqlCommand("UPDATE `instance` SET `backpack` = ?backpack WHERE `id` = ?instance", mysql.Connection);
					mySqlCommand.Parameters.AddWithValue("?backpack", this.cbxLoadoutBackpack.Text);
					mySqlCommand.Parameters.AddWithValue("?instance", frmMain.serverInstance);
					mySqlCommand.ExecuteNonQuery();
				}
			}
			catch (MySqlException ex)
			{
				this.subAppendLog("Error: MySQL Exception: " + ex.Message, LogLevel.Error);
			}
			catch (Exception ex2)
			{
				this.subAppendLog(ex2);
			}
			finally
			{
				mysql.Close();
			}
			if (File.Exists(this.configuration.pathConfigCfg))
			{
				this.configuration.WriteCfgConfig();
			}
			else
			{
				this.subAppendLog("Error: File not found: \"" + this.configuration.pathConfigCfg + "\"", LogLevel.Error);
			}
			if (File.Exists(this.configuration.pathConfigBasic))
			{
				this.configuration.WriteBasicConfig();
			}
			else
			{
				this.subAppendLog("Error: File not found: \"" + this.configuration.pathConfigBasic + "\"", LogLevel.Error);
			}
			if (File.Exists(this.configuration.pathConfigXml))
			{
				this.configuration.WriteXmlConfig();
			}
			else
			{
				this.subAppendLog("Error: File not found: \"" + this.configuration.pathConfigXml + "\"", LogLevel.Error);
			}
		}

		// Token: 0x06000053 RID: 83 RVA: 0x0000C59C File Offset: 0x0000A79C
		private void btnSave4_Click(object sender, EventArgs e)
		{
			this.subAppendLog(string.Concat(new string[]
			{
				"Configuration: Saving Player [Name \"",
				this.textPlayerName.Text,
				"\", UID \"",
				this.textPlayerUid.Text,
				"\"]"
			}), LogLevel.Info);
			try
			{
				mysql.Open();
				mysql.ChangeDatabase(this.configuration.dbName);
				if (this.groupSurvivor.Enabled && !string.IsNullOrEmpty(this.textInventory.Text) && !string.IsNullOrEmpty(this.textBackpack.Text) && !string.IsNullOrEmpty(this.textPosition.Text) && !string.IsNullOrEmpty(this.textMedical.Text))
				{
					MySqlCommand mySqlCommand = new MySqlCommand("UPDATE `survivor` SET `inventory` = ?inventory, `backpack` = ?backpack, `worldspace` = ?worldspace, `medical` = ?medical WHERE `unique_id` = ?uid AND `is_dead` = '0'", mysql.Connection);
					mySqlCommand.Parameters.AddWithValue("?inventory", this.textInventory.Text);
					mySqlCommand.Parameters.AddWithValue("?backpack", this.textBackpack.Text);
					mySqlCommand.Parameters.AddWithValue("?worldspace", this.textPosition.Text);
					mySqlCommand.Parameters.AddWithValue("?medical", this.textMedical.Text);
					mySqlCommand.Parameters.AddWithValue("?uid", this.textPlayerUid.Text);
					mySqlCommand.ExecuteNonQuery();
				}
				if (this.textPlayerName.Enabled && this.textPlayerUid.Enabled && !string.IsNullOrEmpty(this.textPlayerName.Text) && !string.IsNullOrEmpty(this.textPlayerUid.Text))
				{
					MySqlCommand mySqlCommand = new MySqlCommand("UPDATE `profile` SET `unique_id` = ?uid WHERE `name` = ?name", mysql.Connection);
					mySqlCommand.Parameters.AddWithValue("?uid", this.textPlayerUid.Text);
					mySqlCommand.Parameters.AddWithValue("?name", this.textPlayerName.Text);
					mySqlCommand.ExecuteNonQuery();
				}
			}
			catch (MySqlException ex)
			{
				this.subAppendLog("Error: MySQL Exception: " + ex.Message, LogLevel.Error);
			}
			catch (Exception ex2)
			{
				this.subAppendLog(ex2);
			}
			finally
			{
				mysql.Close();
			}
			if (this.textPlayerGuid.Text.Length == 32)
			{
				MySqlConnection mySqlConnection = mysql.Connection;
				if (!string.IsNullOrEmpty(this.configuration.beWhitelistHost) && !string.IsNullOrEmpty(this.configuration.beWhitelistUser) && !string.IsNullOrEmpty(this.configuration.beWhitelistPass) && !string.IsNullOrEmpty(this.configuration.beWhitelistName))
				{
					mySqlConnection = new MySqlConnection(string.Format("server={0};port={1};user={2};password={3};database={4};", new object[]
					{
						this.configuration.beWhitelistHost,
						this.configuration.beWhitelistPort.ToString(),
						this.configuration.beWhitelistUser,
						this.configuration.beWhitelistPass,
						this.configuration.beWhitelistName
					}));
				}
				try
				{
					if (mySqlConnection.State == ConnectionState.Closed)
					{
						mySqlConnection.Open();
					}
					MySqlCommand mySqlCommand = new MySqlCommand("SELECT * FROM `whitelist` WHERE `guid` = ?guid", mySqlConnection);
					mySqlCommand.Parameters.AddWithValue("?guid", this.textPlayerGuid.Text);
					MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
					if (mySqlDataReader.Read())
					{
						mySqlDataReader.Close();
						mySqlCommand = new MySqlCommand("UPDATE `whitelist` SET `guid` = ?guid WHERE `name` = ?name", mySqlConnection);
						mySqlCommand.Parameters.AddWithValue("@guid", this.textPlayerGuid.Text);
						mySqlCommand.Parameters.AddWithValue("@name", this.textPlayerName.Text);
						mySqlCommand.ExecuteNonQuery();
						mySqlCommand = new MySqlCommand("UPDATE `whitelist` SET `is_whitelisted` = ?whitelisted WHERE `guid` = ?guid", mySqlConnection);
						mySqlCommand.Parameters.AddWithValue("?whitelisted", this.checkWhitelisted.Checked ? "1" : "0");
						mySqlCommand.Parameters.AddWithValue("?guid", this.textPlayerGuid.Text);
						mySqlCommand.ExecuteNonQuery();
					}
					else
					{
						mySqlDataReader.Close();
						mySqlCommand = new MySqlCommand("INSERT INTO `whitelist` (`name`, `guid`, `is_whitelisted`) VALUES (?name, ?guid, '1')", mySqlConnection);
						mySqlCommand.Parameters.AddWithValue("?name", this.textPlayerName.Text);
						mySqlCommand.Parameters.AddWithValue("?guid", this.textPlayerGuid.Text);
						mySqlCommand.ExecuteNonQuery();
						this.checkWhitelisted.Enabled = true;
						this.checkWhitelisted.Checked = true;
					}
				}
				catch (MySqlException ex)
				{
					this.subAppendLog("Error: MySQL Exception: " + ex.Message, LogLevel.Error);
				}
				catch (Exception ex2)
				{
					this.subAppendLog(ex2);
				}
				finally
				{
					mySqlConnection.Close();
				}
			}
			else if (string.IsNullOrEmpty(this.textPlayerGuid.Text))
			{
				MySqlConnection mySqlConnection = mysql.Connection;
				if (!string.IsNullOrEmpty(this.configuration.beWhitelistHost) && !string.IsNullOrEmpty(this.configuration.beWhitelistUser) && !string.IsNullOrEmpty(this.configuration.beWhitelistPass) && !string.IsNullOrEmpty(this.configuration.beWhitelistName))
				{
					mySqlConnection = new MySqlConnection(string.Format("server={0};port={1};user={2};password={3};database={4};", new object[]
					{
						this.configuration.beWhitelistHost,
						this.configuration.beWhitelistPort.ToString(),
						this.configuration.beWhitelistUser,
						this.configuration.beWhitelistPass,
						this.configuration.beWhitelistName
					}));
				}
				try
				{
					if (mySqlConnection.State == ConnectionState.Closed)
					{
						mySqlConnection.Open();
					}
					MySqlCommand mySqlCommand = new MySqlCommand("DELETE FROM `whitelist` WHERE `name` = ?name", mySqlConnection);
					mySqlCommand.Parameters.AddWithValue("?name", this.textPlayerName.Text);
					mySqlCommand.ExecuteNonQuery();
					this.checkWhitelisted.Checked = false;
					this.checkWhitelisted.Enabled = false;
				}
				catch (MySqlException ex)
				{
					this.subAppendLog("Error: MySQL Exception: " + ex.Message, LogLevel.Error);
				}
				catch (Exception ex2)
				{
					this.subAppendLog(ex2);
				}
				finally
				{
					mySqlConnection.Close();
				}
			}
			else
			{
				this.subAppendLog("Warning: Invalid GUID", LogLevel.Warn);
				this.textPlayerGuid.Clear();
			}
		}

		// Token: 0x06000054 RID: 84 RVA: 0x0000CD18 File Offset: 0x0000AF18
		private void btnAutoBackup_Click(object sender, EventArgs e)
		{
			if (frmMain.listAutoBackupEnabled[frmMain.serverInstance - 1])
			{
				this.subAppendLog("Backup: Auto Backup stopped [Instance " + frmMain.serverInstance.ToString() + "]", LogLevel.Info);
				this.btnAutoBackup.Text = Resources.button_autobackup_start;
				frmMain.listAutoBackupEnabled[frmMain.serverInstance - 1] = false;
			}
			else
			{
				this.subAppendLog("Backup: Auto Backup started [Instance " + frmMain.serverInstance.ToString() + "]", LogLevel.Info);
				this.btnAutoBackup.Text = Resources.button_autobackup_stop;
				frmMain.listAutoBackupInterval[frmMain.serverInstance - 1] = Convert.ToInt32(this.numBackupInterval.Value);
				frmMain.listAutoBackupEnabled[frmMain.serverInstance - 1] = true;
				this.progressBackup.Maximum = frmMain.listAutoBackupInterval[frmMain.serverInstance - 1] * 60;
			}
			this.configuration.confAutoBackupInterval = frmMain.listAutoBackupInterval[frmMain.serverInstance - 1];
			this.configuration.confAutoBackupEnabled = frmMain.listAutoBackupEnabled[frmMain.serverInstance - 1];
			if (File.Exists(this.configuration.pathConfigXml))
			{
				this.configuration.WriteXmlConfig();
			}
			else
			{
				this.subAppendLog("Error: File not found: \"" + this.configuration.pathConfigXml + "\"", LogLevel.Error);
			}
		}

		// Token: 0x06000055 RID: 85 RVA: 0x0000CE80 File Offset: 0x0000B080
		private void btnBackup_Click(object sender, EventArgs e)
		{
			new Thread(new ThreadStart(this.threadBackup))
			{
				IsBackground = true
			}.Start();
		}

		// Token: 0x06000056 RID: 86 RVA: 0x0000CEB0 File Offset: 0x0000B0B0
		private void btnBackupBrowse_Click(object sender, EventArgs e)
		{
			using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
			{
				if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
				{
					this.configuration.confAutoBackupPath = folderBrowserDialog.SelectedPath;
					this.textBackupPath.Text = this.configuration.confAutoBackupPath;
					if (File.Exists(this.configuration.pathConfigXml))
					{
						this.configuration.WriteXmlConfig();
						this.subAppendLog("Configuration: Backup Path changed [Path \"" + this.configuration.confAutoBackupPath + "\"]", LogLevel.Info);
					}
					else
					{
						this.subAppendLog("Error: File not found: \"" + this.configuration.pathConfigXml + "\"", LogLevel.Error);
					}
				}
			}
		}

		// Token: 0x06000057 RID: 87 RVA: 0x0000CFBC File Offset: 0x0000B1BC
		private void btnDatabase_Click(object sender, EventArgs e)
		{
			string name = this.cbxDatabase.Text.Replace(" ", "");
			if (!string.IsNullOrEmpty(name) && !this.cbxDatabase.Items.Contains(name))
			{
				if (MessageBox.Show(Resources.message_confirm_database + " \"" + name + "\"?", string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					new Thread(delegate
					{
						this.threadDatabase(name, false);
					})
					{
						IsBackground = true
					}.Start();
				}
			}
		}

		// Token: 0x06000058 RID: 88 RVA: 0x0000D082 File Offset: 0x0000B282
		private void btnExit_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000059 RID: 89 RVA: 0x0000D08C File Offset: 0x0000B28C
		private void btnLog_CheckedChanged(object sender, EventArgs e)
		{
			if (this.btnLog.Checked)
			{
				this.container2.Panel1Collapsed = false;
			}
			else
			{
				this.container2.Panel1Collapsed = true;
			}
		}

		// Token: 0x0600005A RID: 90 RVA: 0x0000D0CC File Offset: 0x0000B2CC
		private void btnLogMonitor_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (this.timerMonitor.Enabled)
			{
				this.subAppendLog("Monitor: Log Monitoring stopped [Instance " + frmMain.serverInstance.ToString() + "]", LogLevel.Info);
				this.timerMonitor.Stop();
				this.btnLogMonitor.Text = Resources.button_monitor_start;
			}
			else
			{
				this.subAppendLog("Monitor: Log Monitoring started [Instance " + frmMain.serverInstance.ToString() + "]", LogLevel.Info);
				if (File.Exists(Path.Combine(this.configuration.pathConfig, "arma2oaserver_" + frmMain.serverInstance.ToString() + ".rpt")))
				{
					this.timerMonitor.Start();
					this.btnLogMonitor.Text = Resources.button_monitor_stop;
				}
				else
				{
					this.subAppendLog("Error: File not found: \"" + Path.Combine(this.configuration.pathConfig, "arma2oaserver_" + frmMain.serverInstance.ToString() + ".rpt") + "\"", LogLevel.Error);
				}
			}
		}

		// Token: 0x0600005B RID: 91 RVA: 0x0000D1F8 File Offset: 0x0000B3F8
		private void btnLogClear_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			if (File.Exists(Path.Combine(this.configuration.pathConfig, "arma2oaserver_" + frmMain.serverInstance.ToString() + ".rpt")))
			{
				if (MessageBox.Show(Resources.message_confirm_deletelog, string.Empty, MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
				{
					this.subAppendLog("Monitor: Deleting Log [Instance " + frmMain.serverInstance.ToString() + "]", LogLevel.Info);
					if (this.timerMonitor.Enabled)
					{
						this.timerMonitor.Stop();
					}
					this.btnLogMonitor.Text = Resources.button_monitor_start;
					try
					{
						File.Delete(Path.Combine(this.configuration.pathConfig, "arma2oaserver_" + frmMain.serverInstance.ToString() + ".rpt"));
						this.textLogRpt.Clear();
						this.btnLogMonitor.Enabled = false;
						this.btnLogClear.Enabled = false;
					}
					catch (Exception ex)
					{
						this.subAppendLog(ex);
					}
				}
			}
		}

		// Token: 0x0600005C RID: 92 RVA: 0x0000D334 File Offset: 0x0000B534
		private void btnMysqlHost_Click(object sender, EventArgs e)
		{
			this.subAppendLog(string.Concat(new string[]
			{
				"Configuration: MySQL Host changed [Host \"",
				this.textMysqlHost.Text,
				":",
				this.textMysqlPort.Text,
				"\"]"
			}), LogLevel.Info);
			this.configuration.dbHost = this.textMysqlHost.Text;
			this.configuration.dbPort = Convert.ToInt32(this.textMysqlPort.Text);
			if (File.Exists(this.configuration.pathConfigHive))
			{
				this.configuration.WriteHiveConfig();
			}
			else
			{
				this.subAppendLog("Error: File not found: \"" + this.configuration.pathConfigHive + "\"", LogLevel.Error);
			}
			mysql.Close();
			mysql.Connection = new MySqlConnection(string.Format("server={0};port={1};user={2};password={3};", new object[]
			{
				this.configuration.dbHost,
				this.configuration.dbPort.ToString(),
				this.configuration.dbUser,
				this.configuration.dbPass
			}));
		}

		// Token: 0x0600005D RID: 93 RVA: 0x0000D470 File Offset: 0x0000B670
		private void btnMysqlUser_Click(object sender, EventArgs e)
		{
			this.subAppendLog(string.Concat(new string[]
			{
				"Configuration: MySQL User changed [User \"",
				this.textMysqlUser.Text,
				"\", Password \"",
				this.textMysqlPass.Text,
				"\"]"
			}), LogLevel.Info);
			bool flag = false;
			if (this.textMysqlUser.Text == this.configuration.dbUser)
			{
				try
				{
					mysql.Open();
					MySqlCommand mySqlCommand = new MySqlCommand("SET PASSWORD = PASSWORD(?pass)", mysql.Connection);
					mySqlCommand.Parameters.AddWithValue("?pass", this.textMysqlPass.Text);
					mySqlCommand.ExecuteNonQuery();
				}
				catch (MySqlException ex)
				{
					flag = true;
					this.subAppendLog("Error: MySQL Exception: " + ex.Message, LogLevel.Error);
				}
				catch (Exception ex2)
				{
					flag = true;
					this.subAppendLog(ex2);
				}
				finally
				{
					mysql.Close();
				}
			}
			else
			{
				MySqlConnection mySqlConnection = new MySqlConnection(string.Format("server={0};port={1};user={2};password={3};", new object[]
				{
					this.configuration.dbHost,
					this.configuration.dbPort.ToString(),
					this.textMysqlUser.Text,
					this.textMysqlPass.Text
				}));
				try
				{
					mySqlConnection.Open();
					new MySqlCommand("SHOW DATABASES", mySqlConnection).ExecuteNonQuery();
				}
				catch (MySqlException ex)
				{
					flag = true;
					this.subAppendLog("Error: MySQL Exception: " + ex.Message, LogLevel.Error);
				}
				finally
				{
					mySqlConnection.Close();
				}
			}
			if (!flag)
			{
				mysql.Close();
				mysql.Connection = new MySqlConnection(string.Format("server={0};port={1};user={2};password={3};", new object[]
				{
					this.configuration.dbHost,
					this.configuration.dbPort.ToString(),
					this.configuration.dbUser,
					this.configuration.dbPass
				}));
				this.configuration.dbUser = this.textMysqlUser.Text;
				this.configuration.dbPass = this.textMysqlPass.Text;
				for (int i = 1; i <= frmMain.appInstances; i++)
				{
					Configuration configuration = new Configuration(i);
					if (File.Exists(configuration.pathConfigHive) && i != frmMain.serverInstance)
					{
						configuration.LoadHiveConfig();
						if (this.configuration.dbHost == configuration.dbHost && this.configuration.dbUser == configuration.dbUser)
						{
							configuration.dbPass = this.textMysqlPass.Text;
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
					this.subAppendLog("Error: File not found: \"" + this.configuration.pathConfigHive + "\"", LogLevel.Error);
				}
			}
		}

		// Token: 0x0600005E RID: 94 RVA: 0x0000D80C File Offset: 0x0000BA0C
		private void btnPlayer_Click(object sender, EventArgs e)
		{
			string text = this.textPlayerName.Text;
			string text2 = this.textPlayerGuid.Text;
			if (this.textPlayerGuid.Text.Length == 32)
			{
				if (MessageBox.Show(string.Concat(new string[]
				{
					Resources.message_confirm_player,
					" \"",
					text,
					"\", \"",
					text2,
					"\"?"
				}), "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					MySqlConnection mySqlConnection = mysql.Connection;
					if (!string.IsNullOrEmpty(this.configuration.beWhitelistHost) && !string.IsNullOrEmpty(this.configuration.beWhitelistUser) && !string.IsNullOrEmpty(this.configuration.beWhitelistPass) && !string.IsNullOrEmpty(this.configuration.beWhitelistName))
					{
						mySqlConnection = new MySqlConnection(string.Format("server={0};port={1};user={2};password={3};database={4};", new object[]
						{
							this.configuration.beWhitelistHost,
							this.configuration.beWhitelistPort.ToString(),
							this.configuration.beWhitelistUser,
							this.configuration.beWhitelistPass,
							this.configuration.beWhitelistName
						}));
					}
					this.subAppendLog(string.Concat(new string[] { "Whitelist: Adding player [Name \"", text, "\", GUID \"", text2, "\"]" }), LogLevel.Info);
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
							this.subAppendLog("Error: Player already exists", LogLevel.Warn);
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
						this.subAppendLog("Error: MySQL Exception: " + ex.Message, LogLevel.Error);
					}
					catch (Exception ex2)
					{
						this.subAppendLog(ex2);
					}
					finally
					{
						mySqlConnection.Close();
					}
					this.subReloadPanel3();
				}
			}
			else
			{
				this.subAppendLog("Warning: Invalid GUID", LogLevel.Warn);
			}
		}

		// Token: 0x0600005F RID: 95 RVA: 0x0000DAF0 File Offset: 0x0000BCF0
		private void btnRandomPass_Click(object sender, EventArgs e)
		{
			if (this.textPasswordAdmin.Enabled)
			{
				this.textPasswordAdmin.Text = Crosire.Library.Text.RandomString(10);
			}
			if (this.textPasswordRcon.Enabled)
			{
				this.textPasswordRcon.Text = Crosire.Library.Text.RandomString(10);
			}
		}

		// Token: 0x06000060 RID: 96 RVA: 0x0000DB64 File Offset: 0x0000BD64
		private void btnReset_Click(object sender, EventArgs e)
		{
			if (MessageBox.Show(Resources.message_reset, "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				try
				{
					this.subAppendLog("Configuration: Dropping current database [Database \"" + this.configuration.dbName + "\"]", LogLevel.Info);
					mysql.Open();
					MySqlCommand mySqlCommand = new MySqlCommand("DROP DATABASE IF EXISTS `@name`", mysql.Connection);
					mySqlCommand.Parameters.AddWithValue("@name", this.configuration.dbName);
					mySqlCommand.ExecuteNonQuery();
				}
				catch (MySqlException ex)
				{
					this.subAppendLog("Error: MySQL Exception: " + ex.Message, LogLevel.Error);
					mysql.Close();
					return;
				}
				finally
				{
					mysql.Close();
				}
				new Thread(delegate
				{
					this.threadDatabase(this.configuration.dbName, true);
				})
				{
					IsBackground = true
				}.Start();
			}
		}

		// Token: 0x06000061 RID: 97 RVA: 0x0000DC98 File Offset: 0x0000BE98
		private void btnRestore_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog dlg = new OpenFileDialog())
			{
				dlg.Filter = "SQL Backups|*.sql";
				dlg.InitialDirectory = this.configuration.confAutoBackupPath;
				if (dlg.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(dlg.FileName) && File.Exists(dlg.FileName))
				{
					new Thread(delegate
					{
						this.threadRestore(dlg.FileName);
					})
					{
						IsBackground = true
					}.Start();
				}
			}
		}

		// Token: 0x06000062 RID: 98 RVA: 0x0000DD7C File Offset: 0x0000BF7C
		private void cbxDatabase_TextChanged(object sender, EventArgs e)
		{
			this.cbxDatabase.Text = this.cbxDatabase.Text.Replace(" ", "");
			if (string.IsNullOrEmpty(this.cbxDatabase.Text) || this.cbxDatabase.Items.Contains(this.cbxDatabase.Text))
			{
				this.btnDatabase.Enabled = false;
			}
			else
			{
				this.btnDatabase.Enabled = true;
			}
		}

		// Token: 0x06000063 RID: 99 RVA: 0x0000DE08 File Offset: 0x0000C008
		private void cbxLanguage_DropDownClosed(object sender, EventArgs e)
		{
			string text = this.cbxLanguage.SelectedItem.ToString();
			if (Thread.CurrentThread.CurrentUICulture.IetfLanguageTag != text)
			{
				this.subAppendLog("Application: Language changed [" + text + "]", LogLevel.Info);
				try
				{
					Thread.CurrentThread.CurrentUICulture = new CultureInfo(text);
					this.cbxLanguage.Text = text;
					this.subReloadResources();
					Settings.Default.uiLanguage = text;
					Settings.Default.Save();
				}
				catch (Exception ex)
				{
					this.subAppendLog(ex);
				}
			}
		}

		// Token: 0x06000064 RID: 100 RVA: 0x0000DEC0 File Offset: 0x0000C0C0
		private void cbxTemplate_DropDownClosed(object sender, EventArgs e)
		{
			if (this.cbxDatabase.Items.Contains("dayz_" + this.cbxTemplate.SelectedItem.ToString().Remove(0, 5)))
			{
				this.cbxDatabase.SelectedItem = "dayz_" + this.cbxTemplate.SelectedItem.ToString().Remove(0, 5);
			}
		}

		// Token: 0x06000065 RID: 101 RVA: 0x0000DF35 File Offset: 0x0000C135
		private void checkBattleye_CheckedChanged(object sender, EventArgs e)
		{
		}

		// Token: 0x06000066 RID: 102 RVA: 0x0000DF38 File Offset: 0x0000C138
		private void checkWhitelist_CheckedChanged(object sender, EventArgs e)
		{
			if (this.checkWhitelist.Checked)
			{
				this.textWelcomeMessage.Enabled = true;
			}
			else
			{
				this.textWelcomeMessage.Enabled = false;
			}
		}

		// Token: 0x06000067 RID: 103 RVA: 0x0000DF78 File Offset: 0x0000C178
		private void listPlayers_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.listPlayers.SelectedItem != null)
			{
				MySqlConnection mySqlConnection = mysql.Connection;
				if (!string.IsNullOrEmpty(this.configuration.beWhitelistHost) && !string.IsNullOrEmpty(this.configuration.beWhitelistUser) && !string.IsNullOrEmpty(this.configuration.beWhitelistPass) && !string.IsNullOrEmpty(this.configuration.beWhitelistName))
				{
					mySqlConnection = new MySqlConnection(string.Format("server={0};port={1};user={2};password={3};database={4};", new object[]
					{
						this.configuration.beWhitelistHost,
						this.configuration.beWhitelistPort.ToString(),
						this.configuration.beWhitelistUser,
						this.configuration.beWhitelistPass,
						this.configuration.beWhitelistName
					}));
				}
				this.checkWhitelisted.Enabled = false;
				try
				{
					if (mySqlConnection.State == ConnectionState.Closed)
					{
						mySqlConnection.Open();
					}
					if (string.IsNullOrEmpty(this.configuration.beWhitelistName))
					{
						mySqlConnection.ChangeDatabase(this.configuration.dbName);
					}
					else
					{
						mySqlConnection.ChangeDatabase(this.configuration.beWhitelistName);
					}
					MySqlDataReader mySqlDataReader = new MySqlCommand("SELECT * FROM `whitelist`", mySqlConnection).ExecuteReader();
					while (mySqlDataReader.Read())
					{
						if (mySqlDataReader.GetString("name") == this.listPlayers.SelectedItem.ToString())
						{
							this.checkWhitelisted.Enabled = true;
							if (mySqlDataReader.GetString("is_whitelisted") == "1")
							{
								this.checkWhitelisted.Checked = true;
							}
							else
							{
								this.checkWhitelisted.Checked = false;
							}
						}
					}
					mySqlDataReader.Close();
				}
				catch (MySqlException ex)
				{
					this.subAppendLog("Error: MySQL Exception: " + ex.Message, LogLevel.Error);
				}
				catch (Exception ex2)
				{
					this.subAppendLog(ex2);
				}
				finally
				{
					mySqlConnection.Close();
				}
				this.textPlayerName.Text = this.listPlayers.SelectedItem.ToString();
				try
				{
					mysql.Open();
					mysql.ChangeDatabase(this.configuration.dbName);
					MySqlCommand mySqlCommand = new MySqlCommand("SELECT `unique_id` FROM `profile` WHERE `name` = ?name", mysql.Connection);
					mySqlCommand.Parameters.AddWithValue("?name", this.listPlayers.SelectedItem.ToString());
					MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
					mySqlDataReader.Read();
					if (mySqlDataReader.HasRows)
					{
						this.textPlayerUid.Enabled = true;
						this.textPlayerUid.Text = mySqlDataReader.GetString("unique_id");
					}
					else
					{
						this.textPlayerUid.Enabled = false;
						this.textPlayerUid.Clear();
					}
					mySqlDataReader.Close();
				}
				catch (MySqlException ex)
				{
					this.subAppendLog("Error: MySQL Exception: " + ex.Message, LogLevel.Error);
				}
				catch (Exception ex2)
				{
					this.subAppendLog(ex2);
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
					mySqlCommand.Parameters.AddWithValue("?name", this.listPlayers.SelectedItem.ToString());
					MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
					mySqlDataReader.Read();
					if (mySqlDataReader.HasRows)
					{
						this.textPlayerGuid.Text = mySqlDataReader.GetString("guid");
					}
					else
					{
						this.textPlayerGuid.Clear();
					}
					mySqlDataReader.Close();
				}
				catch (MySqlException ex)
				{
					this.subAppendLog("Error: MySQL Exception: " + ex.Message, LogLevel.Error);
				}
				catch (Exception ex2)
				{
					this.subAppendLog(ex2);
				}
				finally
				{
					mySqlConnection.Close();
				}
				try
				{
					mysql.Open();
					mysql.ChangeDatabase(this.configuration.dbName);
					MySqlCommand mySqlCommand = new MySqlCommand("SELECT profile.name, survivor.* FROM `profile`, `survivor` WHERE profile.unique_id = survivor.unique_id AND survivor.is_dead = '0' AND survivor.unique_id = ?uid", mysql.Connection);
					mySqlCommand.Parameters.AddWithValue("?uid", this.textPlayerUid.Text);
					MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
					mySqlDataReader.Read();
					if (mySqlDataReader.HasRows)
					{
						this.groupSurvivor.Enabled = true;
						this.textInventory.Text = mySqlDataReader.GetString("inventory");
						this.textBackpack.Text = mySqlDataReader.GetString("backpack");
						this.textPosition.Text = mySqlDataReader.GetString("worldspace");
						this.textMedical.Text = mySqlDataReader.GetString("medical");
					}
					else
					{
						this.textInventory.Clear();
						this.textBackpack.Clear();
						this.textPosition.Clear();
						this.textMedical.Clear();
						this.groupSurvivor.Enabled = false;
					}
					mySqlDataReader.Close();
				}
				catch (MySqlException ex)
				{
					this.subAppendLog("Error: MySQL Exception: " + ex.Message, LogLevel.Error);
				}
				catch (Exception ex2)
				{
					this.subAppendLog(ex2);
				}
				finally
				{
					mysql.Close();
				}
			}
		}

		// Token: 0x06000068 RID: 104 RVA: 0x0000E60C File Offset: 0x0000C80C
		private void pictureIcon_Click(object sender, EventArgs e)
		{
			Process.Start(Settings.Default.uiUrlHomepage);
		}

		// Token: 0x06000069 RID: 105 RVA: 0x0000E61F File Offset: 0x0000C81F
		private void pictureLicense_Click(object sender, EventArgs e)
		{
			Process.Start("http://creativecommons.org/licenses/by-nd/3.0/");
		}

		// Token: 0x0600006A RID: 106 RVA: 0x0000E630 File Offset: 0x0000C830
		private void trackTimezone_Scroll(object sender, EventArgs e)
		{
			if (this.trackTimezone.Value <= 0)
			{
				this.textTimezone.Text = "UTC " + this.trackTimezone.Value.ToString();
			}
			else
			{
				this.textTimezone.Text = "UTC +" + this.trackTimezone.Value.ToString();
			}
			if (!this.checkDaytime.Checked)
			{
				int num = DateTime.Now.ToUniversalTime().Hour + this.trackTimezone.Value;
				if (num > 23)
				{
					num -= 24;
				}
				this.labelTime.Text = num.ToString("D2") + ":" + DateTime.Now.ToUniversalTime().Minute.ToString("D2");
			}
			else
			{
				this.labelTime.Text = this.configuration.confStaticHour.ToString("D2") + ":00";
			}
		}

		// Token: 0x0400005D RID: 93
		private WebView browserAdmin;

		// Token: 0x0400005E RID: 94
		private WebView browserDatabase;

		// Token: 0x0400005F RID: 95
		private bool _closing = false;

		// Token: 0x04000060 RID: 96
		private Thread threadmain;

		// Token: 0x04000061 RID: 97
		private Thread threadtimer;

		// Token: 0x04000062 RID: 98
		private Configuration configuration = new Configuration();

		// Token: 0x04000063 RID: 99
		internal static string pathArma = new Configuration().pathArma;

		// Token: 0x04000064 RID: 100
		internal static string pathApp = Path.GetDirectoryName(Application.ExecutablePath);

		// Token: 0x04000065 RID: 101
		internal static int appInstances = Settings.Default.uiInstances;

		// Token: 0x04000066 RID: 102
		internal static int serverInstance = 0;

		// Token: 0x04000067 RID: 103
		public static string[] listDbHost = new string[frmMain.appInstances];

		// Token: 0x04000068 RID: 104
		public static int[] listDbPort = new int[frmMain.appInstances];

		// Token: 0x04000069 RID: 105
		public static string[] listDbUser = new string[frmMain.appInstances];

		// Token: 0x0400006A RID: 106
		public static string[] listDbPass = new string[frmMain.appInstances];

		// Token: 0x0400006B RID: 107
		public static string[] listDbName = new string[frmMain.appInstances];

		// Token: 0x0400006C RID: 108
		public static bool[] listAutoBackupEnabled = new bool[frmMain.appInstances];

		// Token: 0x0400006D RID: 109
		public static int[] listAutoBackupProgress = new int[frmMain.appInstances];

		// Token: 0x0400006E RID: 110
		public static int[] listAutoBackupInterval = new int[frmMain.appInstances];

		// Token: 0x0400006F RID: 111
		public static string[] listAutoBackupPath = new string[frmMain.appInstances];

		// Token: 0x04000070 RID: 112
		private static Logger logger = LogManager.GetCurrentClassLogger();
	}
}
