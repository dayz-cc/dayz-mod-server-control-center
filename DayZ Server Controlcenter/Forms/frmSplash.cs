using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using Crosire.Controlcenter.Classes;
using Crosire.Controlcenter.Properties;
using Crosire.Library;
using Crosire.Library.Forms;
using NLog;

namespace Crosire.Controlcenter.Forms
{
	// Token: 0x0200000A RID: 10
	public partial class frmSplash : Form
	{
		// Token: 0x06000074 RID: 116 RVA: 0x00016894 File Offset: 0x00014A94
		public frmSplash()
		{
			this.InitializeComponent();
			this.labelTitle.Text = Application.ProductName;
			this.labelVersion.Text = "Version " + Application.ProductVersion;
		}

		// Token: 0x06000075 RID: 117 RVA: 0x00016998 File Offset: 0x00014B98
		private void frmSplash_Load(object sender, EventArgs e)
		{
			foreach (string text in Environment.GetCommandLineArgs())
			{
				string text2 = text.ToLower();
				if (text2 != null)
				{
					if (!(text2 == "-skipupdate"))
					{
						if (text2 == "-forceupdate")
						{
							this.forceUpdate = true;
						}
					}
					else
					{
						this.skipUpdate = true;
					}
				}
			}
			if (string.IsNullOrEmpty(this.pathArma) || !Directory.Exists(this.pathArma))
			{
				frmSplash.logger.Log(LogLevel.Fatal, "Application: Missing Working Directory");
				MessageBoxTop.Show("Game directory could not be found. Make sure it is installed and you have entered the correct path during the setup!", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				this.Exit(DialogResult.Abort);
			}
			else
			{
				if (!File.Exists(Path.Combine(this.pathArma, "arma2oaserver.exe")))
				{
					frmSplash.logger.Log(LogLevel.Warn, "Application: Invalid Working Directory");
					MessageBoxTop.Show("Looks like the game directory you entered is invalid. It is not recommended to continue!", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				if (!Directory.Exists(this.pathMain))
				{
					frmSplash.logger.Log(LogLevel.Fatal, "Application: Main folder not found");
					MessageBoxTop.Show("Serverfiles could not be found. Please run the setup before executing this application!", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
					if (File.Exists(this.pathUpdate + ".exe"))
					{
						Process.Start(this.pathUpdate + ".exe");
					}
					this.Exit(DialogResult.Abort);
				}
				else
				{
					if (Directory.Exists(this.pathUpdate) && File.Exists(this.pathUpdate + ".exe"))
					{
						if (Directory.GetFiles(this.pathUpdate).Length > 0 || Directory.GetDirectories(this.pathUpdate).Length > 0)
						{
							frmSplash.logger.Log(LogLevel.Info, "Updater: Downloaded updates found");
							this.subAppendProgress(Environment.NewLine + "Found downloaded updates.");
							if (MessageBoxTop.Show("Found downloaded Updates! Do you want to install them now?", "Updates available!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
							{
								Process.Start(this.pathUpdate + ".exe");
								this.Exit(DialogResult.Abort);
							}
							else
							{
								frmSplash.logger.Log(LogLevel.Warn, "Updater: User aborted update progress");
								this.download = false;
							}
						}
					}
					if (!IO.GetProcessState("mysqld"))
					{
						string text3 = Path.Combine(this.pathMain, "mysql", "bin", "mysqld.exe");
						if (File.Exists(text3))
						{
							frmSplash.logger.Log(LogLevel.Info, "Application: Starting MySQL Server [\"" + text3 + "\"]");
							Process.Start(new ProcessStartInfo(text3, "--defaults-file=\"" + Path.Combine(this.pathMain, "mysql", "bin", "my.ini") + "\"")
							{
								WindowStyle = ProcessWindowStyle.Hidden,
								WorkingDirectory = this.pathMain
							});
							this.subAppendProgress("Started MySQL Server ...");
							Thread.Sleep(1000);
							if (!IO.GetProcessState("mysqld"))
							{
								frmSplash.logger.Log(LogLevel.Warn, "Application: MySQL Server refuses to start");
								this.subAppendProgress("> Error: MySQL Server refuses to start!");
							}
						}
						else
						{
							frmSplash.logger.Log(LogLevel.Error, "Application: File not found: \"" + text3 + "\"");
							this.subAppendProgress("Error: File not found: \"" + text3 + "\"");
						}
					}
					if (!IO.GetProcessState("httpd"))
					{
						string text4 = Path.Combine(this.pathMain, "apache", "bin", "httpd.exe");
						if (File.Exists(text4))
						{
							frmSplash.logger.Log(LogLevel.Info, "Application: Starting Apache Server [\"" + text4 + "\"]");
							Process.Start(new ProcessStartInfo(text4)
							{
								WindowStyle = ProcessWindowStyle.Hidden,
								WorkingDirectory = this.pathMain
							});
							this.subAppendProgress("Started Apache Server ...");
							Thread.Sleep(1000);
							if (!IO.GetProcessState("httpd"))
							{
								frmSplash.logger.Log(LogLevel.Warn, "Application: Apache Server refuses to start");
								this.subAppendProgress("> Error: Apache Server refuses to start!");
							}
						}
						else
						{
							frmSplash.logger.Log(LogLevel.Error, "Application: File not found: \"" + text4 + "\"");
							this.subAppendProgress("Error: File not found: \"" + text4 + "\"");
						}
					}
					this.workerMain.RunWorkerAsync();
				}
			}
		}

		// Token: 0x06000076 RID: 118 RVA: 0x00016E67 File Offset: 0x00015067
		private void frmSplash_Shown(object sender, EventArgs e)
		{
			base.TopMost = false;
		}

		// Token: 0x06000077 RID: 119 RVA: 0x00016E8C File Offset: 0x0001508C
		private void workerMain_DoWork(object sender, DoWorkEventArgs e)
		{
			if (File.Exists(Path.Combine(this.pathApp, "Crosire.dll")))
			{
				this.versionLocal[1] = IO.GetFileVersion(Path.Combine(this.pathApp, "Crosire.dll"));
			}
			if (File.Exists(Path.Combine(this.pathApp, "DayZ Server Setup.exe")))
			{
				this.versionLocal[2] = IO.GetFileVersion(Path.Combine(this.pathApp, "DayZ Server Setup.exe"));
			}
			if (File.Exists(Path.Combine(this.pathArma, "expansion", "beta", "arma2oa.exe")))
			{
				this.versionBetaLocal = IO.GetFileVersion(Path.Combine(this.pathArma, "expansion", "beta", "arma2oa.exe"));
			}
			if (!this.skipUpdate || this.forceUpdate)
			{
				this.subAppendProgress(Environment.NewLine + "Searching for updates ...");
				frmSplash.logger.Log(LogLevel.Info, "Updater: Loading data from server");
				try
				{
					string text = Web.ftpRead(Settings.Default.updateUrl + "/version.xml");
					if (!string.IsNullOrEmpty(text))
					{
						XmlDocument xmlDocument = new XmlDocument();
						xmlDocument.Load(new StringReader(text));
						XmlNodeReader xmlNodeReader = new XmlNodeReader(xmlDocument);
						while (xmlNodeReader.Read())
						{
							if (xmlNodeReader.NodeType == XmlNodeType.Element)
							{
								if (xmlNodeReader.Name == "Application")
								{
									this.versionOnline[0] = xmlNodeReader.GetAttribute("version");
									this.versionDate[0] = xmlNodeReader.GetAttribute("date");
								}
								else if (xmlNodeReader.Name == "Library")
								{
									this.versionOnline[1] = xmlNodeReader.GetAttribute("version");
									this.versionDate[1] = xmlNodeReader.GetAttribute("date");
								}
								else if (xmlNodeReader.Name == "Setup")
								{
									this.versionOnline[2] = xmlNodeReader.GetAttribute("version");
									this.versionDate[2] = xmlNodeReader.GetAttribute("date");
								}
								else if (xmlNodeReader.Name == "Beta")
								{
									this.versionBetaOnline = xmlNodeReader.GetAttribute("version");
								}
							}
						}
						frmSplash.logger.Log(LogLevel.Info, string.Concat(new string[]
						{
							"Updater: Loaded [",
							this.versionOnline[0],
							", ",
							this.versionOnline[1],
							", ",
							this.versionOnline[2],
							"]"
						}));
					}
					else
					{
						this.subAppendProgress("> Recieved invalid data");
						frmSplash.logger.Log(LogLevel.Error, "Updater: Failed: Recieved invalid data");
						this.download = false;
					}
				}
				catch (Exception ex)
				{
					this.subAppendProgress("> Connection Error");
					frmSplash.logger.Log(LogLevel.Error, string.Concat(new string[]
					{
						"Updater: Failed: ",
						ex.ToString(),
						" [",
						ex.Message,
						"]"
					}));
					this.download = false;
				}
				if (!string.IsNullOrEmpty(this.versionBetaLocal) && this.versionBetaLocal != this.versionBetaOnline)
				{
					frmSplash.logger.Log(LogLevel.Warn, string.Concat(new string[] { "Updater: Beta patch version not matching [", this.versionBetaLocal, ", ", this.versionBetaOnline, "]" }));
					this.subAppendProgress("> Beta patch version does not match recommended one!");
				}
				if (this.download || this.forceUpdate)
				{
					if (this.subCheckVersion(this.versionLocal[0], this.versionOnline[0]) < 0 || this.subCheckVersion(this.versionLocal[1], this.versionOnline[1]) < 0 || this.subCheckVersion(this.versionLocal[2], this.versionOnline[2]) < 0 || this.forceUpdate)
					{
						string text2 = string.Empty;
						if (this.subCheckVersion(this.versionLocal[0], this.versionOnline[0]) < 0)
						{
							text2 += "DayZ Server Controlcenter.exe, ";
						}
						if (this.subCheckVersion(this.versionLocal[1], this.versionOnline[1]) < 0)
						{
							text2 += "Crosire.dll, ";
						}
						if (this.subCheckVersion(this.versionLocal[2], this.versionOnline[2]) < 0)
						{
							text2 += "DayZ Server Setup.exe, ";
						}
						text2 = text2.TrimEnd(new char[] { ',', ' ' });
						frmSplash.logger.Log(LogLevel.Info, "Updater: Updates found [\"" + text2 + "\"]");
						this.subAppendProgress(string.Concat(new string[]
						{
							"> New updates found [Version ",
							this.versionOnline[0],
							", Release \"",
							this.versionDate[0],
							"\"",
							string.IsNullOrEmpty(text2) ? "" : (", Files \"" + text2 + "\""),
							"]!"
						}));
						this.subAppendProgress("> Downloading ...");
						try
						{
							if (!Directory.Exists(this.pathUpdate))
							{
								Directory.CreateDirectory(this.pathUpdate);
							}
							if (File.Exists(this.pathUpdate + ".exe"))
							{
								File.Delete(this.pathUpdate + ".exe");
							}
							string[] array = this.versionOnline[0].Split(new char[] { '.' });
							foreach (Ftp.FtpData ftpData in Ftp.DownloadList(Settings.Default.updateUrl + "/" + string.Format(Settings.Default.updateFolder, new object[]
							{
								array[0],
								array[1],
								array[2],
								array[3]
							}), new DirectoryInfo(this.pathUpdate), true))
							{
								frmSplash.logger.Log(LogLevel.Info, string.Concat(new object[] { "Updater: Downloading file: \"", ftpData.fileName, "\" (", ftpData.fileSize, ")" }));
								this.subAppendProgress("> Downloading file: \"" + ftpData.fileName + "\"");
								Ftp.DownloadFileAsync(ftpData, new DownloadProgressChangedEventHandler(this.subDownloadChanged));
								do
								{
									Thread.Sleep(500);
								}
								while (ftpData.downloadProgress != 100.0);
							}
							frmSplash.logger.Log(LogLevel.Info, "Updater: Downloading Updater");
							this.subAppendProgress("> Downloading Updater");
							Ftp.DownloadFileAsync(new Ftp.FtpData(Settings.Default.updateUrl + "/update.exe", "update.exe", new DirectoryInfo(this.pathApp)), new DownloadProgressChangedEventHandler(this.subDownloadChanged));
							Thread.Sleep(1000);
							if (File.Exists(this.pathUpdate + ".exe"))
							{
								if (MessageBoxTop.Show("Do you want to install the updates now?", "Updates available!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
								{
									frmSplash.logger.Log(LogLevel.Info, "Updater: Executing Updater");
									this.subAppendProgress("> Running Updater ...");
									Process.Start(this.pathUpdate + ".exe");
									this.Exit(DialogResult.Abort);
								}
								else
								{
									frmSplash.logger.Log(LogLevel.Warn, "Updater: User aborted update progress");
								}
							}
							else
							{
								frmSplash.logger.Log(LogLevel.Error, "Updater: File not found: \"" + this.pathUpdate + ".exe\"");
								this.subAppendProgress("> Error: File not found: \"" + this.pathUpdate + ".exe\"" + Environment.NewLine);
							}
						}
						catch (WebException ex2)
						{
							frmSplash.logger.Log(LogLevel.Error, "Updater: Failed: Web Exception [" + ex2.Message + "]");
							this.subAppendProgress("> Error: Server Connection Error");
						}
						catch (Exception ex)
						{
							frmSplash.logger.Log(LogLevel.Error, string.Concat(new string[]
							{
								"Updater: Failed: ",
								ex.ToString(),
								" [",
								ex.Message,
								"]"
							}));
							this.subAppendProgress("> Error: Exception: " + ex.Message);
						}
					}
					else
					{
						this.subAppendProgress("> No updates found!");
					}
				}
				else
				{
					frmSplash.logger.Log(LogLevel.Info, "Updater: Aborted");
					this.subAppendProgress("> Aborted!");
				}
			}
			this.subAppendProgress("> Finished!");
			this.progressUpdate.BeginInvoke(new MethodInvoker(delegate
			{
				this.progressUpdate.Value = this.progressUpdate.Maximum;
			}));
			Thread.Sleep(7000);
		}

		// Token: 0x06000078 RID: 120 RVA: 0x000178F8 File Offset: 0x00015AF8
		private void workerMain_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		{
			this.Exit(DialogResult.OK);
		}

		// Token: 0x06000079 RID: 121 RVA: 0x00017904 File Offset: 0x00015B04
		public int subCheckVersion(string vold, string vnew)
		{
			return new Version(vold.Replace(",", ".")).CompareTo(new Version(vnew.Replace(",", ".")));
		}

		// Token: 0x0600007A RID: 122 RVA: 0x00017968 File Offset: 0x00015B68
		public void subDownloadChanged(object sender, DownloadProgressChangedEventArgs e)
		{
			if (base.InvokeRequired)
			{
				base.Invoke(new MethodInvoker(delegate
				{
					this.subDownloadChanged(sender, e);
				}));
			}
			else
			{
				Ftp.FtpData ftpData = e.UserState as Ftp.FtpData;
				ftpData.downloadProgress = (double)e.BytesReceived / ftpData.fileSize * 100.0;
				string text = ftpData.fileName;
				if (text.Length > 70)
				{
					text = text.Remove(70, text.Length - 73).Insert(70, "...");
				}
				this.progressUpdate.Value = Convert.ToInt32(ftpData.downloadProgress);
				this.labelProgress.Text = string.Concat(new object[]
				{
					text,
					" (",
					Convert.ToInt32(ftpData.downloadProgress),
					"%)"
				});
			}
		}

		// Token: 0x0600007B RID: 123 RVA: 0x00017AAC File Offset: 0x00015CAC
		public void subAppendProgress(string message)
		{
			if (base.InvokeRequired)
			{
				base.Invoke(new MethodInvoker(delegate
				{
					this.subAppendProgress(message);
				}));
			}
			else
			{
				RichTextBox richTextBox = this.textProgress;
				richTextBox.Text = richTextBox.Text + Environment.NewLine + message;
				this.textProgress.SelectionStart = this.textProgress.Text.Length;
				this.textProgress.ScrollToCaret();
				this.labelProgress.Text = message.Replace(Environment.NewLine, "").Replace("> ", "");
			}
		}

		// Token: 0x0600007C RID: 124 RVA: 0x00017B94 File Offset: 0x00015D94
		public void Exit(DialogResult result)
		{
			if (base.InvokeRequired)
			{
				base.Invoke(new MethodInvoker(delegate
				{
					this.Exit(result);
				}));
			}
			else
			{
				base.DialogResult = result;
				base.Close();
			}
		}

		// Token: 0x0600007D RID: 125 RVA: 0x00017BF7 File Offset: 0x00015DF7
		private void pictureBanner_Click(object sender, EventArgs e)
		{
			Process.Start(this.url_dayzcc);
		}

		// Token: 0x0600007E RID: 126 RVA: 0x00017C06 File Offset: 0x00015E06
		private void pictureBanner_MouseHover(object sender, EventArgs e)
		{
			this.Cursor = Cursors.Hand;
		}

		// Token: 0x0600007F RID: 127 RVA: 0x00017C15 File Offset: 0x00015E15
		private void pictureBanner_MouseLeave(object sender, EventArgs e)
		{
			this.Cursor = Cursors.Default;
		}

		// Token: 0x04000134 RID: 308
		private string pathApp = frmMain.pathApp;

		// Token: 0x04000135 RID: 309
		private string pathArma = frmMain.pathArma;

		// Token: 0x04000136 RID: 310
		private string pathMain = new Configuration().pathMain;

		// Token: 0x04000137 RID: 311
		private string pathUpdate = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "update");

		// Token: 0x04000138 RID: 312
		private bool download = true;

		// Token: 0x04000139 RID: 313
		private bool skipUpdate = false;

		// Token: 0x0400013A RID: 314
		private bool forceUpdate = false;

		// Token: 0x0400013B RID: 315
		public string[] versionLocal = new string[]
		{
			Application.ProductVersion,
			"0.0.0.0",
			"0.0.0.0"
		};

		// Token: 0x0400013C RID: 316
		public string[] versionOnline = new string[3];

		// Token: 0x0400013D RID: 317
		public string[] versionDate = new string[3];

		// Token: 0x0400013E RID: 318
		public string versionBetaLocal = "0.0.0.0";

		// Token: 0x0400013F RID: 319
		public string versionBetaOnline = "0.0.0.0";

		// Token: 0x04000140 RID: 320
		private string url_dayzcc = "http://www.dayzcc.org";

		// Token: 0x04000141 RID: 321
		private static Logger logger = LogManager.GetCurrentClassLogger();
	}
}
