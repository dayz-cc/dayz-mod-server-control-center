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
using Crosire.Controlcenter.Resources;
using Crosire.Library;
using Crosire.Library.Forms;
using NLog;

namespace Crosire.Controlcenter.Forms
{
    public class frmSplash : Form {
        private string pathApp = frmMain.pathApp;

        private string pathArma = frmMain.pathArma;

        private string pathMain = new Configuration().pathMain;

        private string pathUpdate = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "update");

        private bool download = true;

        private bool skipUpdate = false;

        private bool forceUpdate = false;

        public string[] versionLocal = new string[3]
        {
            Application.ProductVersion,
            "0.0.0.0",
            "0.0.0.0"
        };

        public string[] versionOnline = new string[3];

        public string[] versionDate = new string[3];

        public string versionBetaLocal = "0.0.0.0";

        public string versionBetaOnline = "0.0.0.0";

        private string url_dayzcc = "http://www.dayzcc.org";

        private static Logger logger = LogManager.GetCurrentClassLogger();

        private IContainer components = null;

        private BackgroundWorker workerMain;

        private Label labelTitle;

        private Label labelCompany;

        private Label labelVersion;

        private Label labelCopyright;

        private PictureBox pictureBanner;

        private Label labelProgress;

        private ProgressBar progressUpdate;

        private RichTextBox textProgress;

        private Label lblMaintainer;

        public frmSplash() {
            InitializeComponent();
            labelTitle.Text = Application.ProductName;
            labelVersion.Text = "Version " + Application.ProductVersion;
        }

        private void frmSplash_Load(object sender, EventArgs e) {
            string[] commandLineArgs = Environment.GetCommandLineArgs();
            foreach (string text in commandLineArgs) {
                switch (text.ToLower()) {
                    case "-skipupdate":
                        skipUpdate = true;
                        break;
                    case "-forceupdate":
                        forceUpdate = true;
                        break;
                }
            }
            if (string.IsNullOrEmpty(pathArma) || !Directory.Exists(pathArma)) {
                logger.Log(LogLevel.Fatal, "Application: Missing Working Directory");
                MessageBoxTop.Show("Game directory could not be found. Make sure it is installed and you have entered the correct path during the setup!", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Exit(DialogResult.Abort);
                return;
            }
            if (!File.Exists(Path.Combine(pathArma, "arma2oaserver.exe"))) {
                logger.Log(LogLevel.Warn, "Application: Invalid Working Directory");
                MessageBoxTop.Show("Looks like the game directory you entered is invalid. It is not recommended to continue!", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
            if (!Directory.Exists(pathMain)) {
                logger.Log(LogLevel.Fatal, "Application: Main folder not found");
                MessageBoxTop.Show("Serverfiles could not be found. Please run the setup before executing this application!", "", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                if (File.Exists(pathUpdate + ".exe")) {
                    Process.Start(pathUpdate + ".exe");
                }
                Exit(DialogResult.Abort);
                return;
            }
            if (Directory.Exists(pathUpdate) && File.Exists(pathUpdate + ".exe") && (Directory.GetFiles(pathUpdate).Length > 0 || Directory.GetDirectories(pathUpdate).Length > 0)) {
                logger.Log(LogLevel.Info, "Updater: Downloaded updates found");
                subAppendProgress(Environment.NewLine + "Found downloaded updates.");
                if (MessageBoxTop.Show("Found downloaded Updates! Do you want to install them now?", "Updates available!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                    Process.Start(pathUpdate + ".exe");
                    Exit(DialogResult.Abort);
                } else {
                    logger.Log(LogLevel.Warn, "Updater: User aborted update progress");
                    download = false;
                }
            }
            if (!IO.GetProcessState("mysqld")) {
                string text2 = Path.Combine(pathMain, "mysql", "bin", "mysqld.exe");
                if (File.Exists(text2)) {
                    logger.Log(LogLevel.Info, "Application: Starting MySQL Server [\"" + text2 + "\"]");
                    ProcessStartInfo processStartInfo = new ProcessStartInfo(text2, "--defaults-file=\"" + Path.Combine(pathMain, "mysql", "bin", "my.ini") + "\"");
                    processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    processStartInfo.WorkingDirectory = pathMain;
                    Process.Start(processStartInfo);
                    subAppendProgress("Started MySQL Server ...");
                    Thread.Sleep(1000);
                    if (!IO.GetProcessState("mysqld")) {
                        logger.Log(LogLevel.Warn, "Application: MySQL Server refuses to start");
                        subAppendProgress("> Error: MySQL Server refuses to start!");
                    }
                } else {
                    logger.Log(LogLevel.Error, "Application: File not found: \"" + text2 + "\"");
                    subAppendProgress("Error: File not found: \"" + text2 + "\"");
                }
            }
            if (!IO.GetProcessState("httpd")) {
                string text3 = Path.Combine(pathMain, "apache", "bin", "httpd.exe");
                if (File.Exists(text3)) {
                    logger.Log(LogLevel.Info, "Application: Starting Apache Server [\"" + text3 + "\"]");
                    ProcessStartInfo processStartInfo = new ProcessStartInfo(text3);
                    processStartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    processStartInfo.WorkingDirectory = pathMain;
                    Process.Start(processStartInfo);
                    subAppendProgress("Started Apache Server ...");
                    Thread.Sleep(1000);
                    if (!IO.GetProcessState("httpd")) {
                        logger.Log(LogLevel.Warn, "Application: Apache Server refuses to start");
                        subAppendProgress("> Error: Apache Server refuses to start!");
                    }
                } else {
                    logger.Log(LogLevel.Error, "Application: File not found: \"" + text3 + "\"");
                    subAppendProgress("Error: File not found: \"" + text3 + "\"");
                }
            }
            workerMain.RunWorkerAsync();
        }

        private void frmSplash_Shown(object sender, EventArgs e) {
            base.TopMost = false;
        }

        private void workerMain_DoWork(object sender, DoWorkEventArgs e) {
            if (File.Exists(Path.Combine(pathApp, "Crosire.dll"))) {
                versionLocal[1] = IO.GetFileVersion(Path.Combine(pathApp, "Crosire.dll"));
            }
            if (File.Exists(Path.Combine(pathApp, "DayZ Server Setup.exe"))) {
                versionLocal[2] = IO.GetFileVersion(Path.Combine(pathApp, "DayZ Server Setup.exe"));
            }
            if (File.Exists(Path.Combine(pathArma, "expansion", "beta", "arma2oa.exe"))) {
                versionBetaLocal = IO.GetFileVersion(Path.Combine(pathArma, "expansion", "beta", "arma2oa.exe"));
            }
            if (!skipUpdate || forceUpdate) {
                subAppendProgress(Environment.NewLine + "Searching for updates ...");
                logger.Log(LogLevel.Info, "Updater: Loading data from server");
                try {
                    string text = Web.ftpRead(Settings.Default.updateUrl + "/version.xml");
                    if (!string.IsNullOrEmpty(text)) {
                        XmlDocument xmlDocument = new XmlDocument();
                        xmlDocument.Load(new StringReader(text));
                        XmlNodeReader xmlNodeReader = new XmlNodeReader(xmlDocument);
                        while (xmlNodeReader.Read()) {
                            if (xmlNodeReader.NodeType == XmlNodeType.Element) {
                                if (xmlNodeReader.Name == "Application") {
                                    versionOnline[0] = xmlNodeReader.GetAttribute("version");
                                    versionDate[0] = xmlNodeReader.GetAttribute("date");
                                } else if (xmlNodeReader.Name == "Library") {
                                    versionOnline[1] = xmlNodeReader.GetAttribute("version");
                                    versionDate[1] = xmlNodeReader.GetAttribute("date");
                                } else if (xmlNodeReader.Name == "Setup") {
                                    versionOnline[2] = xmlNodeReader.GetAttribute("version");
                                    versionDate[2] = xmlNodeReader.GetAttribute("date");
                                } else if (xmlNodeReader.Name == "Beta") {
                                    versionBetaOnline = xmlNodeReader.GetAttribute("version");
                                }
                            }
                        }
                        logger.Log(LogLevel.Info, "Updater: Loaded [" + versionOnline[0] + ", " + versionOnline[1] + ", " + versionOnline[2] + "]");
                    } else {
                        subAppendProgress("> Recieved invalid data");
                        logger.Log(LogLevel.Error, "Updater: Failed: Recieved invalid data");
                        download = false;
                    }
                } catch (Exception ex) {
                    subAppendProgress("> Connection Error");
                    logger.Log(LogLevel.Error, "Updater: Failed: " + ex.ToString() + " [" + ex.Message + "]");
                    download = false;
                }
                if (!string.IsNullOrEmpty(versionBetaLocal) && versionBetaLocal != versionBetaOnline) {
                    logger.Log(LogLevel.Warn, "Updater: Beta patch version not matching [" + versionBetaLocal + ", " + versionBetaOnline + "]");
                    subAppendProgress("> Beta patch version does not match recommended one!");
                }
                if (download || forceUpdate) {
                    if (subCheckVersion(versionLocal[0], versionOnline[0]) < 0 || subCheckVersion(versionLocal[1], versionOnline[1]) < 0 || subCheckVersion(versionLocal[2], versionOnline[2]) < 0 || forceUpdate) {
                        string text2 = string.Empty;
                        if (subCheckVersion(versionLocal[0], versionOnline[0]) < 0) {
                            text2 += "DayZ Server Controlcenter.exe, ";
                        }
                        if (subCheckVersion(versionLocal[1], versionOnline[1]) < 0) {
                            text2 += "Crosire.dll, ";
                        }
                        if (subCheckVersion(versionLocal[2], versionOnline[2]) < 0) {
                            text2 += "DayZ Server Setup.exe, ";
                        }
                        text2 = text2.TrimEnd(',', ' ');
                        logger.Log(LogLevel.Info, "Updater: Updates found [\"" + text2 + "\"]");
                        subAppendProgress("> New updates found [Version " + versionOnline[0] + ", Release \"" + versionDate[0] + "\"" + (string.IsNullOrEmpty(text2) ? "" : (", Files \"" + text2 + "\"")) + "]!");
                        subAppendProgress("> Downloading ...");
                        try {
                            if (!Directory.Exists(pathUpdate)) {
                                Directory.CreateDirectory(pathUpdate);
                            }
                            if (File.Exists(pathUpdate + ".exe")) {
                                File.Delete(pathUpdate + ".exe");
                            }
                            string[] array = versionOnline[0].Split('.');
                            foreach (Ftp.FtpData item in Ftp.DownloadList(Settings.Default.updateUrl + "/" + string.Format(Settings.Default.updateFolder, array[0], array[1], array[2], array[3]), new DirectoryInfo(pathUpdate), true)) {
                                logger.Log(LogLevel.Info, "Updater: Downloading file: \"" + item.fileName + "\" (" + item.fileSize + ")");
                                subAppendProgress("> Downloading file: \"" + item.fileName + "\"");
                                Ftp.DownloadFileAsync(item, subDownloadChanged);
                                do {
                                    Thread.Sleep(500);
                                }
                                while (item.downloadProgress != 100.0);
                            }
                            logger.Log(LogLevel.Info, "Updater: Downloading Updater");
                            subAppendProgress("> Downloading Updater");
                            Ftp.DownloadFileAsync(new Ftp.FtpData(Settings.Default.updateUrl + "/update.exe", "update.exe", new DirectoryInfo(pathApp)), subDownloadChanged);
                            Thread.Sleep(1000);
                            if (File.Exists(pathUpdate + ".exe")) {
                                if (MessageBoxTop.Show("Do you want to install the updates now?", "Updates available!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes) {
                                    logger.Log(LogLevel.Info, "Updater: Executing Updater");
                                    subAppendProgress("> Running Updater ...");
                                    Process.Start(pathUpdate + ".exe");
                                    Exit(DialogResult.Abort);
                                } else {
                                    logger.Log(LogLevel.Warn, "Updater: User aborted update progress");
                                }
                            } else {
                                logger.Log(LogLevel.Error, "Updater: File not found: \"" + pathUpdate + ".exe\"");
                                subAppendProgress("> Error: File not found: \"" + pathUpdate + ".exe\"" + Environment.NewLine);
                            }
                        } catch (WebException ex2) {
                            logger.Log(LogLevel.Error, "Updater: Failed: Web Exception [" + ex2.Message + "]");
                            subAppendProgress("> Error: Server Connection Error");
                        } catch (Exception ex) {
                            logger.Log(LogLevel.Error, "Updater: Failed: " + ex.ToString() + " [" + ex.Message + "]");
                            subAppendProgress("> Error: Exception: " + ex.Message);
                        }
                    } else {
                        subAppendProgress("> No updates found!");
                    }
                } else {
                    logger.Log(LogLevel.Info, "Updater: Aborted");
                    subAppendProgress("> Aborted!");
                }
            }
            subAppendProgress("> Finished!");
            progressUpdate.BeginInvoke((MethodInvoker)delegate {
                progressUpdate.Value = progressUpdate.Maximum;
            });
            Thread.Sleep(7000);
        }

        private void workerMain_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            Exit(DialogResult.OK);
        }

        public int subCheckVersion(string vold, string vnew) {
            return new Version(vold.Replace(",", ".")).CompareTo(new Version(vnew.Replace(",", ".")));
        }

        public void subDownloadChanged(object sender, DownloadProgressChangedEventArgs e) {
            if (base.InvokeRequired) {
                Invoke((MethodInvoker)delegate {
                    subDownloadChanged(sender, e);
                });
                return;
            }
            Ftp.FtpData ftpData = e.UserState as Ftp.FtpData;
            ftpData.downloadProgress = (double)e.BytesReceived / ftpData.fileSize * 100.0;
            string text = ftpData.fileName;
            if (text.Length > 70) {
                text = text.Remove(70, text.Length - 73).Insert(70, "...");
            }
            progressUpdate.Value = Convert.ToInt32(ftpData.downloadProgress);
            labelProgress.Text = text + " (" + Convert.ToInt32(ftpData.downloadProgress) + "%)";
        }

        public void subAppendProgress(string message) {
            if (base.InvokeRequired) {
                Invoke((MethodInvoker)delegate {
                    subAppendProgress(message);
                });
                return;
            }
            RichTextBox richTextBox = textProgress;
            richTextBox.Text = richTextBox.Text + Environment.NewLine + message;
            textProgress.SelectionStart = textProgress.Text.Length;
            textProgress.ScrollToCaret();
            labelProgress.Text = message.Replace(Environment.NewLine, "").Replace("> ", "");
        }

        public void Exit(DialogResult result) {
            if (base.InvokeRequired) {
                Invoke((MethodInvoker)delegate {
                    Exit(result);
                });
            } else {
                base.DialogResult = result;
                Close();
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

        protected override void Dispose(bool disposing) {
            if (disposing && components != null) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSplash));
            this.workerMain = new System.ComponentModel.BackgroundWorker();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelCompany = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.labelCopyright = new System.Windows.Forms.Label();
            this.pictureBanner = new System.Windows.Forms.PictureBox();
            this.labelProgress = new System.Windows.Forms.Label();
            this.progressUpdate = new System.Windows.Forms.ProgressBar();
            this.textProgress = new System.Windows.Forms.RichTextBox();
            this.lblMaintainer = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBanner)).BeginInit();
            this.SuspendLayout();
            // 
            // workerMain
            // 
            this.workerMain.DoWork += new System.ComponentModel.DoWorkEventHandler(this.workerMain_DoWork);
            this.workerMain.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.workerMain_RunWorkerCompleted);
            // 
            // labelTitle
            // 
            this.labelTitle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelTitle.BackColor = System.Drawing.Color.Transparent;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.ForeColor = System.Drawing.Color.White;
            this.labelTitle.Location = new System.Drawing.Point(9, 91);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(477, 26);
            this.labelTitle.TabIndex = 19;
            this.labelTitle.Text = "Title";
            this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelCompany
            // 
            this.labelCompany.AutoSize = true;
            this.labelCompany.BackColor = System.Drawing.Color.Transparent;
            this.labelCompany.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCompany.ForeColor = System.Drawing.Color.White;
            this.labelCompany.Location = new System.Drawing.Point(13, 293);
            this.labelCompany.Name = "labelCompany";
            this.labelCompany.Size = new System.Drawing.Size(105, 15);
            this.labelCompany.TabIndex = 18;
            this.labelCompany.Text = "Written by: Crosire";
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.BackColor = System.Drawing.Color.Transparent;
            this.labelVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVersion.ForeColor = System.Drawing.Color.Gray;
            this.labelVersion.Location = new System.Drawing.Point(396, 76);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(88, 15);
            this.labelVersion.TabIndex = 17;
            this.labelVersion.Text = "Version 0.0.0.0";
            // 
            // labelCopyright
            // 
            this.labelCopyright.BackColor = System.Drawing.Color.Transparent;
            this.labelCopyright.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCopyright.ForeColor = System.Drawing.Color.Gray;
            this.labelCopyright.Location = new System.Drawing.Point(13, 320);
            this.labelCopyright.Name = "labelCopyright";
            this.labelCopyright.Size = new System.Drawing.Size(471, 15);
            this.labelCopyright.TabIndex = 16;
            this.labelCopyright.Text = "Copyright ©2012 - 2013 Crosire. All rights reserved.";
            this.labelCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBanner
            // 
            this.pictureBanner.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pictureBanner.BackColor = System.Drawing.Color.Transparent;
            this.pictureBanner.Image = Resources.Images.banner;
            this.pictureBanner.Location = new System.Drawing.Point(12, 12);
            this.pictureBanner.Name = "pictureBanner";
            this.pictureBanner.Size = new System.Drawing.Size(472, 84);
            this.pictureBanner.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBanner.TabIndex = 12;
            this.pictureBanner.TabStop = false;
            this.pictureBanner.Click += new System.EventHandler(this.pictureBanner_Click);
            this.pictureBanner.MouseLeave += new System.EventHandler(this.pictureBanner_MouseLeave);
            this.pictureBanner.MouseHover += new System.EventHandler(this.pictureBanner_MouseHover);
            // 
            // labelProgress
            // 
            this.labelProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelProgress.AutoSize = true;
            this.labelProgress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelProgress.Location = new System.Drawing.Point(16, 271);
            this.labelProgress.Name = "labelProgress";
            this.labelProgress.Size = new System.Drawing.Size(66, 15);
            this.labelProgress.TabIndex = 24;
            this.labelProgress.Text = "Initializing ...";
            // 
            // progressUpdate
            // 
            this.progressUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressUpdate.Location = new System.Drawing.Point(12, 267);
            this.progressUpdate.Name = "progressUpdate";
            this.progressUpdate.Size = new System.Drawing.Size(474, 23);
            this.progressUpdate.TabIndex = 23;
            // 
            // textProgress
            // 
            this.textProgress.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textProgress.BackColor = System.Drawing.SystemColors.Control;
            this.textProgress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textProgress.Cursor = System.Windows.Forms.Cursors.Default;
            this.textProgress.DetectUrls = false;
            this.textProgress.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textProgress.Location = new System.Drawing.Point(12, 123);
            this.textProgress.Name = "textProgress";
            this.textProgress.ReadOnly = true;
            this.textProgress.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.textProgress.Size = new System.Drawing.Size(472, 138);
            this.textProgress.TabIndex = 22;
            this.textProgress.TabStop = false;
            this.textProgress.Text = "Initializing ...";
            // 
            // lblMaintainer
            // 
            this.lblMaintainer.AutoSize = true;
            this.lblMaintainer.BackColor = System.Drawing.Color.Transparent;
            this.lblMaintainer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaintainer.ForeColor = System.Drawing.Color.White;
            this.lblMaintainer.Location = new System.Drawing.Point(339, 293);
            this.lblMaintainer.Name = "lblMaintainer";
            this.lblMaintainer.Size = new System.Drawing.Size(144, 15);
            this.lblMaintainer.TabIndex = 31;
            this.lblMaintainer.Text = "Maintained by: Squadron";
            // 
            // frmSplash
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = Resources.Images.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(498, 340);
            this.Controls.Add(this.lblMaintainer);
            this.Controls.Add(this.labelProgress);
            this.Controls.Add(this.progressUpdate);
            this.Controls.Add(this.textProgress);
            this.Controls.Add(this.labelCopyright);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.labelCompany);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.pictureBanner);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = Resources.Images.icon;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(498, 305);
            this.Name = "frmSplash";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DayZ Server Controlcenter";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmSplash_Load);
            this.Shown += new System.EventHandler(this.frmSplash_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBanner)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
