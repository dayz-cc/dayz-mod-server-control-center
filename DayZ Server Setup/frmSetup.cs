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
using Crosire.Controlcenter.Setup.Classes;
using Crosire.Controlcenter.Setup.Properties;
using Crosire.Library;
using Microsoft.Win32;
using MySql.Data.MySqlClient;
using NLog;

namespace Crosire.Controlcenter.Setup
{
	// Token: 0x02000006 RID: 6
	public partial class frmSetup : Form
	{
		// Token: 0x0600000A RID: 10 RVA: 0x00002448 File Offset: 0x00000648
		public frmSetup()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600000B RID: 11 RVA: 0x000024AA File Offset: 0x000006AA
		private void btnBack_Click(object sender, EventArgs e)
		{
			this.wizPos--;
			this.subUpdateWizard();
		}

		// Token: 0x0600000C RID: 12 RVA: 0x000024C0 File Offset: 0x000006C0
		private void btnBrowse_Click(object sender, EventArgs e)
		{
			using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
			{
				folderBrowserDialog.SelectedPath = frmSetup.pathArma;
				if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
				{
					this.textPath.Text = folderBrowserDialog.SelectedPath;
				}
			}
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00002514 File Offset: 0x00000714
		private void btnCancel_Click(object sender, EventArgs e)
		{
			base.DialogResult = DialogResult.Abort;
			base.Close();
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002523 File Offset: 0x00000723
		private void btnNext_Click(object sender, EventArgs e)
		{
			if (this.wizFinished)
			{
				base.DialogResult = DialogResult.OK;
				base.Close();
				return;
			}
			this.wizPos++;
			this.subUpdateWizard();
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002550 File Offset: 0x00000750
		private void checkOwn_CheckedChanged(object sender, EventArgs e)
		{
			if (this.checkOwn.Checked)
			{
				this.labelHost.Visible = true;
				this.labelUser.Visible = true;
				this.labelPass.Visible = true;
				this.labelSeperator.Visible = true;
				this.textHost.Visible = true;
				this.textPort.Visible = true;
				this.textUser.Visible = true;
				this.textPass.Visible = true;
				return;
			}
			this.labelHost.Visible = false;
			this.labelUser.Visible = false;
			this.labelPass.Visible = false;
			this.labelSeperator.Visible = false;
			this.textHost.Visible = false;
			this.textPort.Visible = false;
			this.textUser.Visible = false;
			this.textPass.Visible = false;
		}

		// Token: 0x06000010 RID: 16 RVA: 0x0000262C File Offset: 0x0000082C
		private void downloader_DownloadCompleted(object sender, AsyncCompletedEventArgs e)
		{
			if (e.Error == null)
			{
				this.subAppendProgress("> Download finished!", LogLevel.Info);
				this.workerMain.RunWorkerAsync();
				return;
			}
			this.subAppendProgress("> Error: Exception: " + e.Error.Message, LogLevel.Fatal);
			this.subFinished();
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002683 File Offset: 0x00000883
		private void downloader_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
		{
			this.progressbar.Value = e.ProgressPercentage;
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00002698 File Offset: 0x00000898
		private void frmSetup_Load(object sender, EventArgs e)
		{
			foreach (string text in Environment.GetCommandLineArgs())
			{
				string text2;
				switch (text2 = text.ToLower())
				{
				case "-skipdownload":
					this.skipDownload = true;
					break;
				case "-skipextraction":
					this.skipExtraction = true;
					break;
				case "-skipcopy":
					this.skipCopy = true;
					break;
				case "-skipdatabase":
					this.skipDatabase = true;
					break;
				case "-skiprandompass":
					this.skipSecurity = true;
					break;
				case "-skipconfig":
					this.skipConfig = true;
					break;
				case "-skipbackup":
					this.skipBackup = true;
					break;
				case "-nowindow":
					this.noWindow = true;
					break;
				case "-fresh":
					this.wizForce = true;
					break;
				}
				if (text.StartsWith("-u"))
				{
					this.dbUser = text.Remove(0, 2);
				}
				else if (text.StartsWith("-p"))
				{
					this.dbPass = text.Remove(0, 2);
				}
				else if (text.StartsWith("-i"))
				{
					this.instances = Convert.ToInt32(text.Remove(0, 2));
				}
			}
			RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, 512).OpenSubKey("SOFTWARE\\Bohemia Interactive Studio\\ArmA 2 OA");
			if (registryKey != null)
			{
				frmSetup.pathArma = registryKey.GetValue("MAIN").ToString();
				frmSetup.pathMain = Path.Combine(frmSetup.pathArma, "@dayzcc");
			}
			else
			{
				frmSetup.logger.Log(LogLevel.Fatal, "Application: Missing Working Directory");
				MessageBox.Show("Game directory could not be found. Make sure it is installed and you have run both Arma2 and Arma2 OA at least once!", "Missing Working Directory", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				base.Close();
			}
			if (File.Exists(frmSetup.pathThis + "\\DayZ Server Controlcenter.exe"))
			{
				this.labelVersion.Text = IO.GetFileVersion(frmSetup.pathThis + "\\DayZ Server Controlcenter.exe");
			}
			else
			{
				this.labelVersion.Text = Resources.error;
			}
			if (!this.noWindow)
			{
				new frmLang().ShowDialog();
				if (!string.IsNullOrEmpty(frmLang.language))
				{
					try
					{
						Thread.CurrentThread.CurrentUICulture = new CultureInfo(frmLang.language);
					}
					catch
					{
					}
				}
				if (Directory.Exists(frmSetup.pathPackages))
				{
					this.checkRedis.Enabled = true;
					if (File.Exists(Path.Combine(frmSetup.pathArma, "expansion", "beta", "arma2oaserver.exe")))
					{
						this.checkBeta.Enabled = true;
					}
					else
					{
						this.checkBeta.Checked = true;
						this.checkBeta.Enabled = false;
					}
				}
				else
				{
					this.checkRedis.Checked = false;
					this.checkRedis.Enabled = false;
					this.checkBeta.Checked = false;
					this.checkBeta.Enabled = false;
				}
				this.textUser.Text = this.dbUser;
				this.textPass.Text = this.dbPass;
				if (Directory.Exists(frmSetup.pathMain))
				{
					this.wizUpdate = true;
					this.wizPos = 1;
					this.container1.Visible = false;
					this.container2.Visible = true;
					this.container3.Visible = false;
					this.btnNext.Enabled = true;
					this.checkRedis.Checked = false;
					this.checkRedis.Enabled = false;
					this.checkOwn.Enabled = false;
					this.textUser.Text = "dayz";
					this.textPass.Text = "dayz";
				}
				else
				{
					this.wizUpdate = false;
					this.wizPos = 0;
					this.container1.Visible = true;
					this.container2.Visible = false;
					this.container3.Visible = false;
					this.btnNext.Enabled = false;
					this.radioReconfig.Enabled = false;
					this.labelHost.Visible = false;
					this.labelUser.Visible = false;
					this.labelPass.Visible = false;
					this.labelSeperator.Visible = false;
					this.textHost.Visible = false;
					this.textPort.Visible = false;
					this.textUser.Visible = false;
					this.textPass.Visible = false;
					if (File.Exists(frmSetup.pathReadme))
					{
						this.textReadme.Text = File.ReadAllText(frmSetup.pathReadme);
					}
				}
				if (string.IsNullOrEmpty(frmSetup.pathArma))
				{
					this.textPath.Text = "";
					this.btnNext.Enabled = false;
				}
				else
				{
					this.textPath.Text = frmSetup.pathArma;
				}
				this.btnBack.Enabled = false;
				this.subReloadResources();
				return;
			}
			base.WindowState = FormWindowState.Minimized;
			base.ShowInTaskbar = false;
			this.subStart();
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00002BB8 File Offset: 0x00000DB8
		private void pictureBanner_Click(object sender, EventArgs e)
		{
			Process.Start(this.url_dayzcc);
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002BC6 File Offset: 0x00000DC6
		private void pictureBanner_MouseHover(object sender, EventArgs e)
		{
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002BD3 File Offset: 0x00000DD3
		private void pictureBanner_MouseLeave(object sender, EventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002C04 File Offset: 0x00000E04
		private void subAppendProgress(string message, LogLevel level)
		{
			if (base.InvokeRequired)
			{
				base.Invoke(new MethodInvoker(delegate
				{
					this.subAppendProgress(message, level);
				}));
				return;
			}
			RichTextBox richTextBox = this.textProgress;
			richTextBox.Text = richTextBox.Text + Environment.NewLine + message;
			this.textProgress.SelectionStart = this.textProgress.Text.Length;
			this.textProgress.ScrollToCaret();
			if (level != null)
			{
				string text = message.Replace(Environment.NewLine, string.Empty).Replace("> ", string.Empty);
				frmSetup.logger.Log(level, text);
			}
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002CDC File Offset: 0x00000EDC
		private void subFinished()
		{
			if (!this.noWindow)
			{
				this.subSetProgress(100);
				this.subAppendProgress(Environment.NewLine + "The Setup just finished. Make sure no errors are in the log above before you continue!", null);
				this.subAppendProgress("Click on '" + Resources.button_finish + "' to exit the wizard.", null);
				this.wizFinished = true;
				this.btnNext.Enabled = true;
				this.btnNext.Text = Resources.button_finish;
				return;
			}
			base.DialogResult = DialogResult.OK;
			base.Close();
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002D5C File Offset: 0x00000F5C
		private void subReloadResources()
		{
			this.labelStep.Text = Resources.step_1;
			this.btnBack.Text = Resources.button_back;
			this.btnNext.Text = Resources.button_next;
			this.btnCancel.Text = Resources.button_cancel;
			this.btnBrowse.Text = Resources.button_browse;
			this.labelVersionDescription.Text = Resources.version;
			this.labelEnterDatabase.Text = Resources.sentence_enterdatabase;
			this.labelEnterPath.Text = Resources.sentence_enterpath;
			this.labelHost.Text = Resources.host;
			this.labelUser.Text = Resources.user;
			this.labelPass.Text = Resources.password;
			this.checkRedis.Text = Resources.sentence_installredis;
			this.checkBeta.Text = Resources.sentence_installpatch;
			this.checkOwn.Text = Resources.button_own;
			this.groupOptions.Text = Resources.group_options;
			this.groupDatabase.Text = Resources.group_database;
			this.radioReconfig.Text = Resources.button_reconfigurate;
			if (this.wizUpdate)
			{
				this.radioInstall.Text = Resources.button_update;
				return;
			}
			this.radioInstall.Text = Resources.button_fresh;
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00002EA4 File Offset: 0x000010A4
		private void subReloadSettings()
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(frmSetup.pathConfig);
			XmlElement xmlElement = xmlDocument.SelectSingleNode("/configuration/applicationSettings/Crosire.Controlcenter.Properties.Settings/setting[@name = 'updateFull']/value") as XmlElement;
			if (xmlElement != null)
			{
				this.downloadUrl = xmlElement.InnerText;
			}
			xmlElement = xmlDocument.SelectSingleNode("/configuration/applicationSettings/Crosire.Controlcenter.Properties.Settings/setting[@name = 'uiInstances']/value") as XmlElement;
			if (xmlElement != null)
			{
				this.instances = Convert.ToInt32(xmlElement.InnerText);
			}
		}

		// Token: 0x0600001A RID: 26 RVA: 0x00002F08 File Offset: 0x00001108
		private void subSetProgress(int progress)
		{
			if (base.InvokeRequired)
			{
				base.Invoke(new Action<int>(this.subSetProgress), new object[] { progress });
				return;
			}
			if (progress <= this.progressbar.Maximum && progress >= this.progressbar.Minimum)
			{
				this.progressbar.Value = progress;
			}
		}

		// Token: 0x0600001B RID: 27 RVA: 0x00002F6C File Offset: 0x0000116C
		private void subStart()
		{
			frmSetup.logger.Log(LogLevel.Info, "Initializing DayZ Server Setup " + Application.ProductVersion);
			this.textProgress.Text = string.Concat(new string[]
			{
				"Setup ",
				Application.ProductVersion,
				" for DayZ Server Controlcenter ",
				this.labelVersion.Text,
				" initialized."
			});
			if (this.radioReconfig.Checked)
			{
				this.wizReconf = true;
				this.wizUpdate = false;
			}
			if (!this.noWindow)
			{
				frmSetup.pathArma = this.textPath.Text;
			}
			if (!this.wizUpdate && !this.wizReconf)
			{
				try
				{
					RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, 512).OpenSubKey("SOFTWARE\\Bohemia Interactive Studio\\ArmA 2 OA", true);
					if (registryKey != null)
					{
						registryKey.SetValue("MAIN", frmSetup.pathArma);
					}
				}
				catch (UnauthorizedAccessException)
				{
					this.subAppendProgress("> Missing permissions to write path to registry!", LogLevel.Error);
				}
			}
			if ((this.checkOwn.Checked || this.wizUpdate || this.wizReconf) && !this.noWindow)
			{
				this.dbHost = this.textHost.Text;
				this.dbPort = this.textPort.Text;
				this.dbUser = this.textUser.Text;
				this.dbPass = this.textPass.Text;
			}
			if (!this.wizReconf)
			{
				if (!File.Exists(frmSetup.pathConfig))
				{
					this.subAppendProgress("> Error: Unable to find application configuration file!", LogLevel.Fatal);
					this.subFinished();
					return;
				}
				this.subReloadSettings();
				if (string.IsNullOrEmpty(this.downloadUrl))
				{
					this.subAppendProgress("> Error: Unable to retrieve download link!", LogLevel.Fatal);
					this.subFinished();
					return;
				}
			}
			string[] array = new string[4];
			if (!this.wizReconf)
			{
				if (!(this.labelVersion.Text != Resources.error) && !string.IsNullOrEmpty(this.labelVersion.Text))
				{
					this.subAppendProgress("> Error: Unable to retrieve correct application version!", LogLevel.Fatal);
					this.subFinished();
					return;
				}
				array = this.labelVersion.Text.Split(new char[] { '.' });
			}
			Process process = new Process();
			if (this.checkBeta.Checked && File.Exists(frmSetup.pathPackages + "\\patch.exe") && !this.noWindow)
			{
				this.subAppendProgress(Environment.NewLine + "Installing beta patch ...", LogLevel.Info);
				if (Directory.Exists(frmSetup.pathArma + "\\expansion\\beta"))
				{
					try
					{
						Directory.Delete(frmSetup.pathArma + "\\expansion\\beta", true);
						this.subAppendProgress("> Previous beta patch uninstalled!", LogLevel.Info);
					}
					catch (Exception ex)
					{
						this.subAppendProgress("> Error: Exception: " + ex.Message, LogLevel.Error);
					}
				}
				process.StartInfo.FileName = frmSetup.pathPackages + "\\patch.exe";
				process.Start();
				process.WaitForExit();
				this.subAppendProgress("> Beta patch installed!", LogLevel.Info);
			}
			if (this.checkRedis.Checked && this.checkRedis.Enabled && !this.noWindow)
			{
				this.subAppendProgress(Environment.NewLine + "Installing redistributables ...", LogLevel.Info);
				foreach (string text in Directory.GetFiles(frmSetup.pathPackages))
				{
					if (!text.EndsWith("patch.exe") && text.EndsWith(".exe"))
					{
						try
						{
							process.StartInfo.FileName = text;
							process.Start();
							process.WaitForExit();
						}
						catch (IOException ex2)
						{
							this.subAppendProgress("> Installation Error: " + ex2.Message, LogLevel.Error);
						}
					}
				}
				this.subAppendProgress("> Redistributables installed!", LogLevel.Info);
			}
			if (this.wizReconf)
			{
				this.workerReconfig.RunWorkerAsync();
				return;
			}
			if (this.skipDownload)
			{
				this.workerMain.RunWorkerAsync();
				return;
			}
			this.subAppendProgress(Environment.NewLine + "Downloading files from download server ...", LogLevel.Info);
			this.subAppendProgress("> This can take some time because of the large file size!", null);
			this.subAppendProgress("> Waiting for response. Download started!", null);
			this.downloader.DownloadFileAsync(new Uri(string.Format(this.downloadUrl, new object[]
			{
				array[0],
				array[1],
				array[2],
				array[3]
			})), frmSetup.pathThis + "\\Serverfiles.tar.gz");
		}

		// Token: 0x0600001C RID: 28 RVA: 0x00003428 File Offset: 0x00001628
		private void subUpdateWizard()
		{
			switch (this.wizPos)
			{
			case 0:
				this.labelStep.Text = Resources.step_1;
				this.btnBack.Enabled = false;
				this.btnNext.Enabled = true;
				this.container1.Visible = true;
				this.container2.Visible = false;
				this.container3.Visible = false;
				return;
			case 1:
				this.labelStep.Text = Resources.step_2;
				this.btnBack.Enabled = true;
				this.btnNext.Enabled = true;
				this.container1.Visible = false;
				this.container2.Visible = true;
				this.container3.Visible = false;
				return;
			case 2:
				this.labelStep.Text = Resources.step_3;
				this.btnBack.Enabled = false;
				this.btnNext.Enabled = false;
				this.container1.Visible = false;
				this.container2.Visible = false;
				this.container3.Visible = true;
				this.subStart();
				return;
			default:
				return;
			}
		}

		// Token: 0x0600001D RID: 29 RVA: 0x0000353B File Offset: 0x0000173B
		private void textPath_TextChanged(object sender, EventArgs e)
		{
			if (string.IsNullOrEmpty(this.textPath.Text))
			{
				this.btnNext.Enabled = false;
				return;
			}
			this.btnNext.Enabled = true;
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00003568 File Offset: 0x00001768
		private void textReadme_VScroll(object sender, EventArgs e)
		{
			if (Scrollinfo.CheckBottom(this.textReadme))
			{
				this.btnNext.Enabled = true;
			}
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00003584 File Offset: 0x00001784
		private void threadreconfig_DoWork(object sender, DoWorkEventArgs e)
		{
			this.subAppendProgress(Environment.NewLine + "Reconfigurating files ...", LogLevel.Info);
			int num = 0;
			this.subSetProgress(num);
			if (File.Exists(Path.Combine(frmSetup.pathArma, "expansion", "beta", "arma2oaserver.exe")))
			{
				for (int i = 1; i <= this.instances; i++)
				{
					try
					{
						File.Copy(Path.Combine(frmSetup.pathArma, "expansion", "beta", "arma2oaserver.exe"), Path.Combine(frmSetup.pathMain + "_config", i.ToString(), "arma2oaserver_" + i.ToString() + ".exe"), true);
					}
					catch (Exception ex)
					{
						this.subAppendProgress("> Error while copying server executable for instance " + i.ToString() + "!", LogLevel.Warn);
						this.subAppendProgress("> Exception: " + ex.Message, LogLevel.Error);
					}
				}
			}
			else
			{
				this.subAppendProgress("> Warning: The beta patch is not installed!", LogLevel.Warn);
			}
			num += 50;
			this.subSetProgress(num);
			Process process = new Process();
			process.StartInfo.FileName = frmSetup.pathMain + "\\install\\install.bat";
			process.StartInfo.WorkingDirectory = frmSetup.pathMain + "\\install";
			process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			try
			{
				process.Start();
				process.WaitForExit(13000);
				this.subAppendProgress("> Finished!", LogLevel.Info);
				num += 45;
				this.subSetProgress(num);
			}
			catch (Exception ex2)
			{
				this.subAppendProgress("> Error while running the installation script!", LogLevel.Warn);
				this.subAppendProgress("> Exception: " + ex2.Message, LogLevel.Error);
			}
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00003760 File Offset: 0x00001960
		private void threadreconfig_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			this.subFinished();
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00003768 File Offset: 0x00001968
		private void threadworker_DoWork(object sender, DoWorkEventArgs e)
		{
			int num = 0;
			this.subSetProgress(num);
			if (!this.skipExtraction)
			{
				this.subAppendProgress(Environment.NewLine + "Extracting downloaded files ...", LogLevel.Info);
				try
				{
					Compression.Extract(Path.Combine(frmSetup.pathThis, "Serverfiles.tar.gz"), frmSetup.pathTemp);
					this.subAppendProgress("> Extracting finished!", LogLevel.Info);
					num += 20;
					this.subSetProgress(num);
				}
				catch (Exception ex)
				{
					this.subAppendProgress("> Error while extracting!", LogLevel.Warn);
					this.subAppendProgress("> Exception: " + ex.Message, LogLevel.Fatal);
					this.workerMain.CancelAsync();
				}
			}
			if (!this.skipCopy)
			{
				if (this.wizUpdate && !this.wizForce && !this.skipBackup)
				{
					this.subAppendProgress("> Creating backup ...", LogLevel.Info);
					try
					{
						if (!Directory.Exists(frmSetup.pathThis + "\\backup"))
						{
							Directory.CreateDirectory(frmSetup.pathThis + "\\backup");
						}
						if (!Directory.Exists(frmSetup.pathThis + "\\backup\\@dayzcc"))
						{
							Directory.CreateDirectory(frmSetup.pathThis + "\\backup\\@dayzcc");
						}
						if (!Directory.Exists(frmSetup.pathThis + "\\backup\\@dayzcc\\addons"))
						{
							Directory.CreateDirectory(frmSetup.pathThis + "\\backup\\@dayzcc\\addons");
						}
						if (!Directory.Exists(frmSetup.pathThis + "\\backup\\mpmissions"))
						{
							Directory.CreateDirectory(frmSetup.pathThis + "\\backup\\mpmissions");
						}
						if (Directory.Exists(frmSetup.pathArma + "\\@dayzcc_config"))
						{
							IO.CopyFolder(frmSetup.pathArma + "\\@dayzcc_config", frmSetup.pathThis + "\\backup\\@dayzcc_config", true, true);
						}
						if (Directory.Exists(frmSetup.pathMain + "\\mysql\\data"))
						{
							IO.CopyFolder(frmSetup.pathMain + "\\mysql\\data", frmSetup.pathThis + "\\backup\\@dayzcc\\mysql\\data", true, true);
						}
						if (Directory.Exists(frmSetup.pathArma + "\\MPMissions"))
						{
							IO.CopyFolder(frmSetup.pathArma + "\\MPMissions", frmSetup.pathThis + "\\backup\\mpmissions", true, true);
						}
						if (File.Exists(frmSetup.pathMain + "\\addons\\dayz_server.pbo"))
						{
							File.Copy(frmSetup.pathMain + "\\addons\\dayz_server.pbo", frmSetup.pathThis + "\\backup\\@dayzcc\\addons\\dayz_server.pbo", true);
						}
						if (File.Exists(frmSetup.pathMain + "\\addons\\dayz_server_config.hpp"))
						{
							File.Copy(frmSetup.pathMain + "\\addons\\dayz_server_config.hpp", frmSetup.pathThis + "\\backup\\@dayzcc\\addons\\dayz_server_config.hpp", true);
						}
					}
					catch (Exception ex2)
					{
						this.subAppendProgress("> Error while creating the backup!", LogLevel.Warn);
						this.subAppendProgress("> Exception: " + ex2.Message, LogLevel.Error);
					}
				}
				this.subAppendProgress("> Copying files to ArmA directory ...", LogLevel.Info);
				if (this.wizUpdate && !this.wizForce)
				{
					try
					{
						Directory.Delete(Path.Combine(frmSetup.pathTemp, "@dayzcc", "mysql", "data"), true);
						for (int i = 1; i <= this.instances; i++)
						{
							try
							{
								File.Delete(Path.Combine(frmSetup.pathTemp, "@dayzcc_config", i.ToString(), "config.cfg"));
								File.Delete(Path.Combine(frmSetup.pathTemp, "@dayzcc_config", i.ToString(), "basic.cfg"));
								File.Delete(Path.Combine(frmSetup.pathTemp, "@dayzcc_config", i.ToString(), "settings.xml"));
								File.Delete(Path.Combine(new string[]
								{
									frmSetup.pathTemp,
									"@dayzcc_config",
									i.ToString(),
									"BattlEye",
									"BEServer.cfg"
								}));
								File.Delete(Path.Combine(new string[]
								{
									frmSetup.pathTemp,
									"@dayzcc_config",
									i.ToString(),
									"BattlEye",
									"bans.txt"
								}));
								Directory.Delete(Path.Combine(frmSetup.pathTemp, "@dayzcc_config", i.ToString(), "Users"), true);
							}
							catch (Exception ex3)
							{
								this.subAppendProgress("> Error while preparing files for instance " + i.ToString() + "!", LogLevel.Warn);
								this.subAppendProgress("> Exception: " + ex3.Message, LogLevel.Error);
							}
						}
					}
					catch (Exception ex4)
					{
						this.subAppendProgress("> Error while preparing files!", LogLevel.Warn);
						this.subAppendProgress("> Exception: " + ex4.Message, LogLevel.Fatal);
						this.workerMain.CancelAsync();
					}
				}
				if (this.wizForce)
				{
					this.subAppendProgress("> Killing processes ...", LogLevel.Info);
					try
					{
						foreach (Process process in Process.GetProcesses())
						{
							if (process.ProcessName == "mysqld" || process.ProcessName == "httpd")
							{
								process.Kill();
							}
						}
					}
					catch (Exception ex5)
					{
						this.subAppendProgress("> Error while killing the running proceses!", LogLevel.Warn);
						this.subAppendProgress("> Exception: " + ex5.Message, LogLevel.Error);
					}
					Thread.Sleep(1000);
				}
				try
				{
					IO.CopyFolder(frmSetup.pathTemp, frmSetup.pathArma, true, true);
					num += 30;
					this.subSetProgress(num);
				}
				catch (Exception ex6)
				{
					this.subAppendProgress("> Unable to copy files to the correct destination!", LogLevel.Fatal);
					this.subAppendProgress("> Exception: " + ex6.Message, LogLevel.Fatal);
					this.workerMain.CancelAsync();
				}
				try
				{
					Directory.Delete(frmSetup.pathTemp, true);
					this.subAppendProgress("> Done!", null);
					num += 2;
					this.subSetProgress(num);
				}
				catch
				{
					this.subAppendProgress("> Warning: Could not delete the temporary extraction folder!", LogLevel.Warn);
				}
				if (File.Exists(Path.Combine(frmSetup.pathArma, "expansion", "beta", "arma2oaserver.exe")))
				{
					for (int k = 1; k <= this.instances; k++)
					{
						try
						{
							File.Copy(Path.Combine(frmSetup.pathArma, "expansion", "beta", "arma2oaserver.exe"), Path.Combine(frmSetup.pathMain + "_config", k.ToString(), "arma2oaserver_" + k.ToString() + ".exe"), true);
						}
						catch (Exception ex7)
						{
							this.subAppendProgress("> Error while copying executables for instance " + k.ToString() + "!", LogLevel.Warn);
							this.subAppendProgress("> Exception: " + ex7.Message, LogLevel.Error);
						}
					}
				}
				else
				{
					this.subAppendProgress("> Error: The beta patch is not installed!", LogLevel.Error);
				}
				try
				{
					Directory.Delete(Path.Combine(frmSetup.pathMain, "install", "setup"), true);
				}
				catch
				{
					this.subAppendProgress("> Warning: Could not delete a temporary folder!", LogLevel.Warn);
				}
			}
			if (!this.skipConfig)
			{
				this.subAppendProgress(Environment.NewLine + "Configurating files ...", LogLevel.Info);
				this.subAppendProgress("> Administration rights are needed in order to add some firewall rules for proper working!", null);
				Process process2 = new Process();
				try
				{
					XmlDocument xmlDocument = new XmlDocument();
					xmlDocument.Load(frmSetup.pathConfig);
					XmlElement xmlElement = xmlDocument.SelectSingleNode("/configuration/applicationSettings/Crosire.Controlcenter.Properties.Settings/setting[@name = 'uiInstances']/value") as XmlElement;
					if (xmlElement != null)
					{
						xmlElement.InnerText = this.instances.ToString();
					}
					xmlDocument.Save(frmSetup.pathConfig);
				}
				catch (Exception ex8)
				{
					this.subAppendProgress("> Error while saving application config file!", LogLevel.Warn);
					this.subAppendProgress("> Exception: " + ex8.Message, LogLevel.Error);
				}
				process2.StartInfo.FileName = frmSetup.pathMain + "\\install\\install.bat";
				process2.StartInfo.WorkingDirectory = frmSetup.pathMain + "\\install";
				process2.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
				try
				{
					process2.Start();
					process2.WaitForExit(13000);
				}
				catch (Exception ex9)
				{
					this.subAppendProgress("> Error while running installation script!", LogLevel.Warn);
					this.subAppendProgress("> Exception: " + ex9.Message, LogLevel.Error);
				}
				process2.StartInfo.FileName = "cmd.exe";
				process2.StartInfo.Arguments = "/c \"netsh advfirewall firewall delete rule name=\"DayZ Server Controlcenter\" || netsh advfirewall firewall add rule name=\"DayZ Server Controlcenter\" dir=in action=allow profile=any localport=78 protocol=tcp\"";
				process2.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
				if (Environment.OSVersion.Version.Major >= 6)
				{
					process2.StartInfo.Verb = "runas";
				}
				try
				{
					process2.Start();
					process2.WaitForExit();
				}
				catch (Exception ex10)
				{
					this.subAppendProgress("> Error while adding new rules to the firewall!", LogLevel.Warn);
					this.subAppendProgress("> Exception: " + ex10.Message, LogLevel.Error);
				}
				this.subAppendProgress("> Finished!", LogLevel.Info);
				num += 8;
				this.subSetProgress(num);
			}
			if (!this.skipDatabase)
			{
				this.subAppendProgress(Environment.NewLine + "Installing database ...", LogLevel.Info);
				Process process3 = new Process();
				int l = 0;
				while (l <= 3)
				{
					if (!IO.GetProcessState("mysqld"))
					{
						if (!(this.dbHost == "127.0.0.1") && !(this.dbHost == "localhost") && !this.dbHost.StartsWith("192.168") && !this.dbHost.StartsWith("172."))
						{
							if (!this.dbHost.StartsWith("10."))
							{
								goto IL_A48;
							}
						}
						try
						{
							process3.StartInfo.FileName = frmSetup.pathMain + "\\mysql\\bin\\mysqld.exe";
							process3.StartInfo.WorkingDirectory = frmSetup.pathMain + "\\mysql";
							process3.StartInfo.Arguments = "--defaults-file=\"" + frmSetup.pathMain + "\\mysql\\bin\\my.ini\"";
							process3.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
							process3.Start();
							this.subAppendProgress("> Starting own MySQL server!", LogLevel.Info);
							goto IL_A58;
						}
						catch (Exception ex11)
						{
							this.subAppendProgress("> Error while starting MySQL!", LogLevel.Warn);
							this.subAppendProgress("> Exception: " + ex11.Message, LogLevel.Fatal);
							this.workerMain.CancelAsync();
							goto IL_A58;
						}
						goto IL_A48;
					}
					goto IL_A48;
					IL_A58:
					Thread.Sleep(15000);
					if (IO.GetProcessState("mysqld"))
					{
						this.subAppendProgress("> MySQL is running.", LogLevel.Info);
						num += 5;
						this.subSetProgress(num);
						break;
					}
					if (this.dbHost == "127.0.0.1" || this.dbHost == "localhost" || this.dbHost.StartsWith("192.168") || this.dbHost.StartsWith("172.") || this.dbHost.StartsWith("10."))
					{
						this.subAppendProgress("> Error: MySQL is not running!", LogLevel.Error);
					}
					else
					{
						this.subAppendProgress("> Using external MySQL server!", LogLevel.Info);
					}
					l++;
					continue;
					IL_A48:
					this.subAppendProgress("> Found already running MySQL server!", LogLevel.Info);
					goto IL_A58;
				}
				MySqlConnection mySqlConnection = new MySqlConnection(string.Format("server={0};port={1};user={2};password={3};", new object[] { this.dbHost, this.dbPort, this.dbUser, this.dbPass }));
				this.subAppendProgress("> Testing MySQL User details for user \"" + this.dbUser + "\" ...", LogLevel.Info);
				try
				{
					mySqlConnection.Open();
					this.subAppendProgress("> Success!", LogLevel.Info);
				}
				catch (MySqlException ex12)
				{
					this.subAppendProgress("> Error: " + ex12.Message, LogLevel.Warn);
				}
				finally
				{
					mySqlConnection.Close();
				}
				foreach (string text in this.textDatabase.Text.Replace(" ", "").Split(new char[] { ',' }))
				{
					try
					{
						process3.StartInfo.FileName = frmSetup.pathMain + "\\install\\migrate.bat";
						process3.StartInfo.WorkingDirectory = frmSetup.pathMain + "\\install";
						process3.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
						process3.StartInfo.Arguments = string.Concat(new string[] { text, " ", this.dbHost, " ", this.dbPort, " ", this.dbUser, " ", this.dbPass });
						process3.Start();
						process3.WaitForExit(30000);
						if (process3.ExitCode == 0)
						{
							this.subAppendProgress("> Updated database \"" + text + "\"!", LogLevel.Info);
						}
						else
						{
							this.subAppendProgress("> Error while updating the database \"" + text + "\"!", LogLevel.Warn);
							this.subAppendProgress("> Exit Code: " + process3.ExitCode.ToString(), LogLevel.Error);
							switch (process3.ExitCode)
							{
							case 1:
								this.subAppendProgress("> Could not connect to MySQL server!", null);
								break;
							case 2:
								this.subAppendProgress("> Database creation failed!", null);
								break;
							}
						}
					}
					catch (Exception ex13)
					{
						this.subAppendProgress("> Error while updating the database \"" + text + "\"!", LogLevel.Warn);
						this.subAppendProgress("> Exception: " + ex13.Message, LogLevel.Fatal);
					}
				}
				num += 25;
				this.subSetProgress(num);
			}
			if (!this.skipSecurity && this.dbPass == "")
			{
				string text2 = Crosire.Library.Text.RandomString(8);
				this.subAppendProgress(string.Concat(new string[]
				{
					Environment.NewLine,
					"Changing password for user \"",
					this.dbUser,
					"\" to \"",
					text2,
					"\""
				}), LogLevel.Info);
				this.subAppendProgress("> Please note it down as you cannot login later otherwise!", null);
				MySqlConnection mySqlConnection2 = new MySqlConnection(string.Format("server={0};port={1};user={2};password={3};", new object[] { this.dbHost, this.dbPort, this.dbUser, this.dbPass }));
				try
				{
					mySqlConnection2.Open();
					MySqlCommand mySqlCommand = new MySqlCommand("SET PASSWORD = PASSWORD('?pass')", mySqlConnection2);
					mySqlCommand.Parameters.AddWithValue("?pass", text2);
					mySqlCommand.ExecuteNonQuery();
					this.subAppendProgress("> Successfully changed the password!", LogLevel.Info);
				}
				catch (Exception ex14)
				{
					this.subAppendProgress("> Error while changing the password!", LogLevel.Warn);
					this.subAppendProgress("> Exception: " + ex14.Message, LogLevel.Error);
				}
				finally
				{
					mySqlConnection2.Close();
				}
				num += 5;
				this.subSetProgress(num);
			}
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00004834 File Offset: 0x00002A34
		private void threadworker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			this.subFinished();
		}

		// Token: 0x04000012 RID: 18
		private static Logger logger = LogManager.GetCurrentClassLogger();

		// Token: 0x04000013 RID: 19
		public int wizPos;

		// Token: 0x04000014 RID: 20
		public bool wizUpdate;

		// Token: 0x04000015 RID: 21
		public bool wizForce;

		// Token: 0x04000016 RID: 22
		public bool wizReconf;

		// Token: 0x04000017 RID: 23
		public bool wizFinished;

		// Token: 0x04000018 RID: 24
		public bool skipDownload;

		// Token: 0x04000019 RID: 25
		public bool skipExtraction;

		// Token: 0x0400001A RID: 26
		public bool skipCopy;

		// Token: 0x0400001B RID: 27
		public bool skipConfig;

		// Token: 0x0400001C RID: 28
		public bool skipDatabase;

		// Token: 0x0400001D RID: 29
		public bool skipSecurity;

		// Token: 0x0400001E RID: 30
		public bool skipBackup;

		// Token: 0x0400001F RID: 31
		public bool noWindow;

		// Token: 0x04000020 RID: 32
		public string dbHost = "127.0.0.1";

		// Token: 0x04000021 RID: 33
		public string dbPort = "3306";

		// Token: 0x04000022 RID: 34
		public string dbPass = "";

		// Token: 0x04000023 RID: 35
		public string dbUser = "root";

		// Token: 0x04000024 RID: 36
		public string downloadUrl = "";

		// Token: 0x04000025 RID: 37
		public int instances = 6;

		// Token: 0x04000026 RID: 38
		public static string pathArma = "";

		// Token: 0x04000027 RID: 39
		public static string pathMain = "";

		// Token: 0x04000028 RID: 40
		public static string pathTemp = Path.Combine(Path.GetTempPath(), "DayZ Server Setup");

		// Token: 0x04000029 RID: 41
		public static string pathThis = Application.StartupPath;

		// Token: 0x0400002A RID: 42
		public static string pathReadme = Path.Combine(frmSetup.pathThis, "Readme.txt");

		// Token: 0x0400002B RID: 43
		public static string pathPackages = Path.Combine(frmSetup.pathThis, "setup");

		// Token: 0x0400002C RID: 44
		public static string pathConfig = Path.Combine(frmSetup.pathThis, "DayZ Server Controlcenter.exe.config");

		// Token: 0x0400002D RID: 45
		private string url_dayzcc = "http://www.dayzcc.org";
	}
}
