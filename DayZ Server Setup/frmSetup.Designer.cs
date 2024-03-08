namespace Crosire.Controlcenter.Setup
{
	// Token: 0x02000006 RID: 6
	public partial class frmSetup : global::System.Windows.Forms.Form
	{
		// Token: 0x06000026 RID: 38 RVA: 0x00004854 File Offset: 0x00002A54
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00004874 File Offset: 0x00002A74
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Crosire.Controlcenter.Setup.frmSetup));
			this.containerButtons = new global::System.Windows.Forms.TableLayoutPanel();
			this.btnBack = new global::System.Windows.Forms.Button();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.btnNext = new global::System.Windows.Forms.Button();
			this.labelVersionDescription = new global::System.Windows.Forms.Label();
			this.labelVersion = new global::System.Windows.Forms.Label();
			this.pictureBanner = new global::System.Windows.Forms.PictureBox();
			this.workerMain = new global::System.ComponentModel.BackgroundWorker();
			this.workerReconfig = new global::System.ComponentModel.BackgroundWorker();
			this.downloader = new global::System.Net.WebClient();
			this.labelStep = new global::System.Windows.Forms.Label();
			this.labelCopyright = new global::System.Windows.Forms.Label();
			this.labelCompany = new global::System.Windows.Forms.Label();
			this.container1 = new global::System.Windows.Forms.Panel();
			this.btnBrowse = new global::System.Windows.Forms.Button();
			this.textPath = new global::System.Windows.Forms.TextBox();
			this.labelEnterPath = new global::System.Windows.Forms.Label();
			this.textReadme = new global::System.Windows.Forms.RichTextBox();
			this.container2 = new global::System.Windows.Forms.Panel();
			this.groupOptions = new global::System.Windows.Forms.GroupBox();
			this.radioReconfig = new global::System.Windows.Forms.RadioButton();
			this.radioInstall = new global::System.Windows.Forms.RadioButton();
			this.checkRedis = new global::System.Windows.Forms.CheckBox();
			this.checkBeta = new global::System.Windows.Forms.CheckBox();
			this.groupDatabase = new global::System.Windows.Forms.GroupBox();
			this.checkOwn = new global::System.Windows.Forms.CheckBox();
			this.labelEnterDatabase = new global::System.Windows.Forms.Label();
			this.labelHost = new global::System.Windows.Forms.Label();
			this.textDatabase = new global::System.Windows.Forms.TextBox();
			this.labelPass = new global::System.Windows.Forms.Label();
			this.textUser = new global::System.Windows.Forms.TextBox();
			this.labelUser = new global::System.Windows.Forms.Label();
			this.textPort = new global::System.Windows.Forms.TextBox();
			this.labelSeperator = new global::System.Windows.Forms.Label();
			this.textHost = new global::System.Windows.Forms.TextBox();
			this.textPass = new global::System.Windows.Forms.TextBox();
			this.container3 = new global::System.Windows.Forms.Panel();
			this.textProgress = new global::System.Windows.Forms.RichTextBox();
			this.progressbar = new global::System.Windows.Forms.ProgressBar();
			this.lblMaintainer = new global::System.Windows.Forms.Label();
			this.pictureLogo = new global::System.Windows.Forms.PictureBox();
			this.lblSupporter = new global::System.Windows.Forms.Label();
			this.lblDayzModDescription = new global::System.Windows.Forms.Label();
			this.lblDayZModVersion = new global::System.Windows.Forms.Label();
			this.containerButtons.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBanner).BeginInit();
			this.container1.SuspendLayout();
			this.container2.SuspendLayout();
			this.groupOptions.SuspendLayout();
			this.groupDatabase.SuspendLayout();
			this.container3.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureLogo).BeginInit();
			base.SuspendLayout();
			this.containerButtons.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right;
			this.containerButtons.BackColor = global::System.Drawing.Color.Transparent;
			this.containerButtons.ColumnCount = 3;
			this.containerButtons.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 33.33333f));
			this.containerButtons.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 33.33333f));
			this.containerButtons.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 33.33333f));
			this.containerButtons.Controls.Add(this.btnBack, 0, 0);
			this.containerButtons.Controls.Add(this.btnCancel, 2, 0);
			this.containerButtons.Controls.Add(this.btnNext, 1, 0);
			this.containerButtons.Location = new global::System.Drawing.Point(212, 431);
			this.containerButtons.Name = "containerButtons";
			this.containerButtons.RowCount = 1;
			this.containerButtons.RowStyles.Add(new global::System.Windows.Forms.RowStyle(global::System.Windows.Forms.SizeType.Percent, 100f));
			this.containerButtons.Size = new global::System.Drawing.Size(270, 29);
			this.containerButtons.TabIndex = 1;
			this.btnBack.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.btnBack.BackColor = global::System.Drawing.SystemColors.Control;
			this.btnBack.Enabled = false;
			this.btnBack.ForeColor = global::System.Drawing.SystemColors.ControlText;
			this.btnBack.Location = new global::System.Drawing.Point(3, 3);
			this.btnBack.Name = "btnBack";
			this.btnBack.Size = new global::System.Drawing.Size(84, 23);
			this.btnBack.TabIndex = 1;
			this.btnBack.Text = "Back";
			this.btnBack.UseVisualStyleBackColor = true;
			this.btnBack.Click += new global::System.EventHandler(this.btnBack_Click);
			this.btnCancel.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.btnCancel.BackColor = global::System.Drawing.SystemColors.Control;
			this.btnCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.ForeColor = global::System.Drawing.SystemColors.ControlText;
			this.btnCancel.Location = new global::System.Drawing.Point(183, 3);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new global::System.Drawing.Size(84, 23);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new global::System.EventHandler(this.btnCancel_Click);
			this.btnNext.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.btnNext.BackColor = global::System.Drawing.SystemColors.Control;
			this.btnNext.Enabled = false;
			this.btnNext.ForeColor = global::System.Drawing.SystemColors.ControlText;
			this.btnNext.Location = new global::System.Drawing.Point(93, 3);
			this.btnNext.Name = "btnNext";
			this.btnNext.Size = new global::System.Drawing.Size(84, 23);
			this.btnNext.TabIndex = 0;
			this.btnNext.Text = "Next";
			this.btnNext.UseVisualStyleBackColor = true;
			this.btnNext.Click += new global::System.EventHandler(this.btnNext_Click);
			this.labelVersionDescription.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left;
			this.labelVersionDescription.AutoSize = true;
			this.labelVersionDescription.BackColor = global::System.Drawing.Color.Transparent;
			this.labelVersionDescription.ForeColor = global::System.Drawing.Color.Gray;
			this.labelVersionDescription.Location = new global::System.Drawing.Point(325, 91);
			this.labelVersionDescription.Name = "labelVersionDescription";
			this.labelVersionDescription.Size = new global::System.Drawing.Size(111, 13);
			this.labelVersionDescription.TabIndex = 4;
			this.labelVersionDescription.Text = "Controlcenter Version:";
			this.labelVersion.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left;
			this.labelVersion.AutoSize = true;
			this.labelVersion.BackColor = global::System.Drawing.Color.Transparent;
			this.labelVersion.ForeColor = global::System.Drawing.Color.Gray;
			this.labelVersion.Location = new global::System.Drawing.Point(442, 91);
			this.labelVersion.Name = "labelVersion";
			this.labelVersion.Size = new global::System.Drawing.Size(40, 13);
			this.labelVersion.TabIndex = 4;
			this.labelVersion.Text = "0.0.0.0";
			this.pictureBanner.BackColor = global::System.Drawing.Color.Transparent;
			this.pictureBanner.Image = global::Crosire.Controlcenter.Setup.Properties.Resources.banner;
			this.pictureBanner.Location = new global::System.Drawing.Point(10, 12);
			this.pictureBanner.Name = "pictureBanner";
			this.pictureBanner.Size = new global::System.Drawing.Size(472, 92);
			this.pictureBanner.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBanner.TabIndex = 14;
			this.pictureBanner.TabStop = false;
			this.pictureBanner.Click += new global::System.EventHandler(this.pictureBanner_Click);
			this.pictureBanner.MouseLeave += new global::System.EventHandler(this.pictureBanner_MouseLeave);
			this.pictureBanner.MouseHover += new global::System.EventHandler(this.pictureBanner_MouseHover);
			this.workerMain.DoWork += new global::System.ComponentModel.DoWorkEventHandler(this.threadworker_DoWork);
			this.workerMain.RunWorkerCompleted += new global::System.ComponentModel.RunWorkerCompletedEventHandler(this.threadworker_RunWorkerCompleted);
			this.workerReconfig.DoWork += new global::System.ComponentModel.DoWorkEventHandler(this.threadreconfig_DoWork);
			this.workerReconfig.RunWorkerCompleted += new global::System.ComponentModel.RunWorkerCompletedEventHandler(this.threadreconfig_RunWorkerCompleted);
			this.downloader.BaseAddress = "";
			this.downloader.CachePolicy = null;
			this.downloader.Credentials = null;
			this.downloader.Encoding = (global::System.Text.Encoding)componentResourceManager.GetObject("downloader.Encoding");
			this.downloader.Headers = (global::System.Net.WebHeaderCollection)componentResourceManager.GetObject("downloader.Headers");
			this.downloader.QueryString = (global::System.Collections.Specialized.NameValueCollection)componentResourceManager.GetObject("downloader.QueryString");
			this.downloader.UseDefaultCredentials = false;
			this.downloader.DownloadFileCompleted += new global::System.ComponentModel.AsyncCompletedEventHandler(this.downloader_DownloadCompleted);
			this.downloader.DownloadProgressChanged += new global::System.Net.DownloadProgressChangedEventHandler(this.downloader_DownloadProgressChanged);
			this.labelStep.Anchor = global::System.Windows.Forms.AnchorStyles.Top;
			this.labelStep.BackColor = global::System.Drawing.Color.Transparent;
			this.labelStep.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 18f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.labelStep.ForeColor = global::System.Drawing.Color.White;
			this.labelStep.Location = new global::System.Drawing.Point(10, 106);
			this.labelStep.Name = "labelStep";
			this.labelStep.Size = new global::System.Drawing.Size(472, 32);
			this.labelStep.TabIndex = 20;
			this.labelStep.Text = "DayZ Server Setup";
			this.labelStep.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.labelCopyright.BackColor = global::System.Drawing.Color.Transparent;
			this.labelCopyright.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.labelCopyright.ForeColor = global::System.Drawing.Color.Gray;
			this.labelCopyright.Location = new global::System.Drawing.Point(7, 542);
			this.labelCopyright.Name = "labelCopyright";
			this.labelCopyright.Size = new global::System.Drawing.Size(475, 15);
			this.labelCopyright.TabIndex = 21;
			this.labelCopyright.Text = "Copyright ©2012 - 2013 Crosire and DayZ Priv. All rights reserved.";
			this.labelCopyright.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.labelCompany.AutoSize = true;
			this.labelCompany.BackColor = global::System.Drawing.Color.Transparent;
			this.labelCompany.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.labelCompany.ForeColor = global::System.Drawing.Color.White;
			this.labelCompany.Location = new global::System.Drawing.Point(7, 431);
			this.labelCompany.Name = "labelCompany";
			this.labelCompany.Size = new global::System.Drawing.Size(105, 15);
			this.labelCompany.TabIndex = 23;
			this.labelCompany.Text = "Written by: Crosire";
			this.container1.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.container1.Controls.Add(this.btnBrowse);
			this.container1.Controls.Add(this.textPath);
			this.container1.Controls.Add(this.labelEnterPath);
			this.container1.Controls.Add(this.textReadme);
			this.container1.Location = new global::System.Drawing.Point(10, 141);
			this.container1.Name = "container1";
			this.container1.Size = new global::System.Drawing.Size(472, 284);
			this.container1.TabIndex = 25;
			this.btnBrowse.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right;
			this.btnBrowse.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.btnBrowse.ForeColor = global::System.Drawing.SystemColors.ControlText;
			this.btnBrowse.Location = new global::System.Drawing.Point(379, 251);
			this.btnBrowse.Name = "btnBrowse";
			this.btnBrowse.Size = new global::System.Drawing.Size(84, 23);
			this.btnBrowse.TabIndex = 18;
			this.btnBrowse.Text = "Browse";
			this.btnBrowse.Click += new global::System.EventHandler(this.btnBrowse_Click);
			this.textPath.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.textPath.Location = new global::System.Drawing.Point(9, 253);
			this.textPath.Name = "textPath";
			this.textPath.Size = new global::System.Drawing.Size(364, 20);
			this.textPath.TabIndex = 17;
			this.textPath.TextChanged += new global::System.EventHandler(this.textPath_TextChanged);
			this.labelEnterPath.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left;
			this.labelEnterPath.AutoSize = true;
			this.labelEnterPath.Location = new global::System.Drawing.Point(6, 234);
			this.labelEnterPath.Name = "labelEnterPath";
			this.labelEnterPath.Size = new global::System.Drawing.Size(208, 13);
			this.labelEnterPath.TabIndex = 16;
			this.labelEnterPath.Text = "Enter the full path to your ArmA installation:";
			this.textReadme.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.textReadme.Font = new global::System.Drawing.Font("Courier New", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.textReadme.Location = new global::System.Drawing.Point(9, 7);
			this.textReadme.Name = "textReadme";
			this.textReadme.ReadOnly = true;
			this.textReadme.Size = new global::System.Drawing.Size(454, 220);
			this.textReadme.TabIndex = 15;
			this.textReadme.Text = "";
			this.textReadme.WordWrap = false;
			this.textReadme.VScroll += new global::System.EventHandler(this.textReadme_VScroll);
			this.container2.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.container2.Controls.Add(this.groupOptions);
			this.container2.Controls.Add(this.groupDatabase);
			this.container2.Location = new global::System.Drawing.Point(10, 141);
			this.container2.Name = "container2";
			this.container2.Size = new global::System.Drawing.Size(472, 284);
			this.container2.TabIndex = 24;
			this.container2.Visible = false;
			this.groupOptions.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.groupOptions.BackColor = global::System.Drawing.SystemColors.Control;
			this.groupOptions.Controls.Add(this.radioReconfig);
			this.groupOptions.Controls.Add(this.radioInstall);
			this.groupOptions.Controls.Add(this.checkRedis);
			this.groupOptions.Controls.Add(this.checkBeta);
			this.groupOptions.ForeColor = global::System.Drawing.SystemColors.ControlText;
			this.groupOptions.Location = new global::System.Drawing.Point(9, 7);
			this.groupOptions.Name = "groupOptions";
			this.groupOptions.Size = new global::System.Drawing.Size(454, 69);
			this.groupOptions.TabIndex = 2;
			this.groupOptions.TabStop = false;
			this.groupOptions.Text = "Installation Options";
			this.radioReconfig.AutoSize = true;
			this.radioReconfig.Location = new global::System.Drawing.Point(9, 45);
			this.radioReconfig.Name = "radioReconfig";
			this.radioReconfig.Size = new global::System.Drawing.Size(92, 17);
			this.radioReconfig.TabIndex = 1;
			this.radioReconfig.Text = "Reconfigurate";
			this.radioReconfig.UseVisualStyleBackColor = true;
			this.radioInstall.AutoSize = true;
			this.radioInstall.Checked = true;
			this.radioInstall.Location = new global::System.Drawing.Point(9, 22);
			this.radioInstall.Name = "radioInstall";
			this.radioInstall.Size = new global::System.Drawing.Size(51, 17);
			this.radioInstall.TabIndex = 0;
			this.radioInstall.TabStop = true;
			this.radioInstall.Text = "Fresh";
			this.radioInstall.UseVisualStyleBackColor = true;
			this.checkRedis.AutoSize = true;
			this.checkRedis.Checked = true;
			this.checkRedis.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.checkRedis.Location = new global::System.Drawing.Point(122, 46);
			this.checkRedis.Name = "checkRedis";
			this.checkRedis.Size = new global::System.Drawing.Size(167, 17);
			this.checkRedis.TabIndex = 2;
			this.checkRedis.Text = "Install required redistributables";
			this.checkRedis.UseVisualStyleBackColor = true;
			this.checkBeta.AutoSize = true;
			this.checkBeta.Checked = true;
			this.checkBeta.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.checkBeta.Location = new global::System.Drawing.Point(122, 23);
			this.checkBeta.Name = "checkBeta";
			this.checkBeta.Size = new global::System.Drawing.Size(148, 17);
			this.checkBeta.TabIndex = 0;
			this.checkBeta.Text = "Install required beta patch";
			this.checkBeta.UseVisualStyleBackColor = true;
			this.groupDatabase.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
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
			this.groupDatabase.ForeColor = global::System.Drawing.SystemColors.ControlText;
			this.groupDatabase.Location = new global::System.Drawing.Point(9, 82);
			this.groupDatabase.Name = "groupDatabase";
			this.groupDatabase.Size = new global::System.Drawing.Size(454, 194);
			this.groupDatabase.TabIndex = 4;
			this.groupDatabase.TabStop = false;
			this.groupDatabase.Text = "Database Options";
			this.checkOwn.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.checkOwn.Appearance = global::System.Windows.Forms.Appearance.Button;
			this.checkOwn.Location = new global::System.Drawing.Point(9, 22);
			this.checkOwn.Name = "checkOwn";
			this.checkOwn.Size = new global::System.Drawing.Size(437, 24);
			this.checkOwn.TabIndex = 10;
			this.checkOwn.Text = "I want to use my own MySQL server";
			this.checkOwn.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.checkOwn.UseVisualStyleBackColor = true;
			this.checkOwn.CheckedChanged += new global::System.EventHandler(this.checkOwn_CheckedChanged);
			this.labelEnterDatabase.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.labelEnterDatabase.Location = new global::System.Drawing.Point(6, 141);
			this.labelEnterDatabase.Name = "labelEnterDatabase";
			this.labelEnterDatabase.Size = new global::System.Drawing.Size(440, 21);
			this.labelEnterDatabase.TabIndex = 9;
			this.labelEnterDatabase.Text = "Enter a list of databases you wish to update below. You can use commas to seperate them:";
			this.labelHost.AutoSize = true;
			this.labelHost.Location = new global::System.Drawing.Point(6, 61);
			this.labelHost.Name = "labelHost";
			this.labelHost.Size = new global::System.Drawing.Size(32, 13);
			this.labelHost.TabIndex = 8;
			this.labelHost.Text = "Host:";
			this.textDatabase.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.textDatabase.Location = new global::System.Drawing.Point(9, 165);
			this.textDatabase.Name = "textDatabase";
			this.textDatabase.Size = new global::System.Drawing.Size(437, 20);
			this.textDatabase.TabIndex = 6;
			this.textDatabase.Text = "dayz_chernarus";
			this.labelPass.AutoSize = true;
			this.labelPass.Location = new global::System.Drawing.Point(6, 113);
			this.labelPass.Name = "labelPass";
			this.labelPass.Size = new global::System.Drawing.Size(56, 13);
			this.labelPass.TabIndex = 7;
			this.labelPass.Text = "Password:";
			this.textUser.Location = new global::System.Drawing.Point(68, 84);
			this.textUser.Name = "textUser";
			this.textUser.Size = new global::System.Drawing.Size(106, 20);
			this.textUser.TabIndex = 6;
			this.textUser.Text = "root";
			this.labelUser.AutoSize = true;
			this.labelUser.Location = new global::System.Drawing.Point(6, 87);
			this.labelUser.Name = "labelUser";
			this.labelUser.Size = new global::System.Drawing.Size(32, 13);
			this.labelUser.TabIndex = 5;
			this.labelUser.Text = "User:";
			this.textPort.Location = new global::System.Drawing.Point(196, 58);
			this.textPort.Name = "textPort";
			this.textPort.Size = new global::System.Drawing.Size(51, 20);
			this.textPort.TabIndex = 4;
			this.textPort.Text = "3306";
			this.labelSeperator.AutoSize = true;
			this.labelSeperator.Location = new global::System.Drawing.Point(180, 61);
			this.labelSeperator.Name = "labelSeperator";
			this.labelSeperator.Size = new global::System.Drawing.Size(10, 13);
			this.labelSeperator.TabIndex = 3;
			this.labelSeperator.Text = ":";
			this.textHost.Location = new global::System.Drawing.Point(68, 58);
			this.textHost.Name = "textHost";
			this.textHost.Size = new global::System.Drawing.Size(106, 20);
			this.textHost.TabIndex = 2;
			this.textHost.Text = "127.0.0.1";
			this.textPass.Location = new global::System.Drawing.Point(68, 110);
			this.textPass.Name = "textPass";
			this.textPass.Size = new global::System.Drawing.Size(106, 20);
			this.textPass.TabIndex = 1;
			this.textPass.UseSystemPasswordChar = true;
			this.container3.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.container3.Controls.Add(this.textProgress);
			this.container3.Controls.Add(this.progressbar);
			this.container3.Location = new global::System.Drawing.Point(10, 141);
			this.container3.Name = "container3";
			this.container3.Size = new global::System.Drawing.Size(472, 284);
			this.container3.TabIndex = 26;
			this.container3.Visible = false;
			this.textProgress.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.textProgress.Location = new global::System.Drawing.Point(9, 7);
			this.textProgress.Name = "textProgress";
			this.textProgress.ReadOnly = true;
			this.textProgress.Size = new global::System.Drawing.Size(454, 237);
			this.textProgress.TabIndex = 0;
			this.textProgress.Text = "";
			this.textProgress.WordWrap = false;
			this.progressbar.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.progressbar.Location = new global::System.Drawing.Point(9, 253);
			this.progressbar.Name = "progressbar";
			this.progressbar.Size = new global::System.Drawing.Size(454, 23);
			this.progressbar.TabIndex = 1;
			this.lblMaintainer.AutoSize = true;
			this.lblMaintainer.BackColor = global::System.Drawing.Color.Transparent;
			this.lblMaintainer.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblMaintainer.ForeColor = global::System.Drawing.Color.White;
			this.lblMaintainer.Location = new global::System.Drawing.Point(7, 445);
			this.lblMaintainer.Name = "lblMaintainer";
			this.lblMaintainer.Size = new global::System.Drawing.Size(147, 15);
			this.lblMaintainer.TabIndex = 27;
			this.lblMaintainer.Text = "Maintained by: NovoGeek";
			this.pictureLogo.BackColor = global::System.Drawing.Color.Transparent;
			this.pictureLogo.BackgroundImage = global::Crosire.Controlcenter.Setup.Properties.Resources.logo;
			this.pictureLogo.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.Zoom;
			this.pictureLogo.Location = new global::System.Drawing.Point(10, 492);
			this.pictureLogo.Name = "pictureLogo";
			this.pictureLogo.Size = new global::System.Drawing.Size(472, 44);
			this.pictureLogo.TabIndex = 28;
			this.pictureLogo.TabStop = false;
			this.pictureLogo.Click += new global::System.EventHandler(this.pictureLogo_Click);
			this.pictureLogo.MouseLeave += new global::System.EventHandler(this.pictureLogo_MouseLeave);
			this.pictureLogo.MouseHover += new global::System.EventHandler(this.pictureLogo_MouseHover);
			this.lblSupporter.Anchor = global::System.Windows.Forms.AnchorStyles.Top;
			this.lblSupporter.BackColor = global::System.Drawing.Color.Transparent;
			this.lblSupporter.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblSupporter.ForeColor = global::System.Drawing.Color.White;
			this.lblSupporter.Location = new global::System.Drawing.Point(10, 471);
			this.lblSupporter.Name = "lblSupporter";
			this.lblSupporter.Size = new global::System.Drawing.Size(472, 25);
			this.lblSupporter.TabIndex = 29;
			this.lblSupporter.Text = "Proudly Supported and Maintained By";
			this.lblSupporter.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.lblDayzModDescription.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left;
			this.lblDayzModDescription.AutoSize = true;
			this.lblDayzModDescription.BackColor = global::System.Drawing.Color.Transparent;
			this.lblDayzModDescription.ForeColor = global::System.Drawing.Color.Gray;
			this.lblDayzModDescription.Location = new global::System.Drawing.Point(7, 91);
			this.lblDayzModDescription.Name = "lblDayzModDescription";
			this.lblDayzModDescription.Size = new global::System.Drawing.Size(98, 13);
			this.lblDayzModDescription.TabIndex = 30;
			this.lblDayzModDescription.Text = "DayZ Mod Version:";
			this.lblDayZModVersion.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left;
			this.lblDayZModVersion.AutoSize = true;
			this.lblDayZModVersion.BackColor = global::System.Drawing.Color.Transparent;
			this.lblDayZModVersion.ForeColor = global::System.Drawing.Color.Gray;
			this.lblDayZModVersion.Location = new global::System.Drawing.Point(111, 91);
			this.lblDayZModVersion.Name = "lblDayZModVersion";
			this.lblDayZModVersion.Size = new global::System.Drawing.Size(40, 13);
			this.lblDayZModVersion.TabIndex = 31;
			this.lblDayZModVersion.Text = "1.7.7.1";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = global::Crosire.Controlcenter.Setup.Properties.Resources.background;
			this.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.Stretch;
			base.ClientSize = new global::System.Drawing.Size(492, 566);
			base.Controls.Add(this.lblDayzModDescription);
			base.Controls.Add(this.lblDayZModVersion);
			base.Controls.Add(this.lblSupporter);
			base.Controls.Add(this.pictureLogo);
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
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.Name = "frmSetup";
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Set Up and Update Wizard";
			base.Load += new global::System.EventHandler(this.frmSetup_Load);
			this.containerButtons.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBanner).EndInit();
			this.container1.ResumeLayout(false);
			this.container1.PerformLayout();
			this.container2.ResumeLayout(false);
			this.groupOptions.ResumeLayout(false);
			this.groupOptions.PerformLayout();
			this.groupDatabase.ResumeLayout(false);
			this.groupDatabase.PerformLayout();
			this.container3.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.pictureLogo).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400002F RID: 47
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000030 RID: 48
		internal global::System.Windows.Forms.TableLayoutPanel containerButtons;

		// Token: 0x04000031 RID: 49
		internal global::System.Windows.Forms.Button btnBack;

		// Token: 0x04000032 RID: 50
		internal global::System.Windows.Forms.Button btnCancel;

		// Token: 0x04000033 RID: 51
		internal global::System.Windows.Forms.Button btnNext;

		// Token: 0x04000034 RID: 52
		internal global::System.Windows.Forms.Label labelVersionDescription;

		// Token: 0x04000035 RID: 53
		internal global::System.Windows.Forms.Label labelVersion;

		// Token: 0x04000036 RID: 54
		private global::System.Windows.Forms.PictureBox pictureBanner;

		// Token: 0x04000037 RID: 55
		private global::System.ComponentModel.BackgroundWorker workerMain;

		// Token: 0x04000038 RID: 56
		private global::System.ComponentModel.BackgroundWorker workerReconfig;

		// Token: 0x04000039 RID: 57
		private global::System.Net.WebClient downloader;

		// Token: 0x0400003A RID: 58
		private global::System.Windows.Forms.Label labelStep;

		// Token: 0x0400003B RID: 59
		private global::System.Windows.Forms.Label labelCopyright;

		// Token: 0x0400003C RID: 60
		private global::System.Windows.Forms.Label labelCompany;

		// Token: 0x0400003D RID: 61
		private global::System.Windows.Forms.Panel container1;

		// Token: 0x0400003E RID: 62
		internal global::System.Windows.Forms.Button btnBrowse;

		// Token: 0x0400003F RID: 63
		private global::System.Windows.Forms.TextBox textPath;

		// Token: 0x04000040 RID: 64
		private global::System.Windows.Forms.Label labelEnterPath;

		// Token: 0x04000041 RID: 65
		private global::System.Windows.Forms.RichTextBox textReadme;

		// Token: 0x04000042 RID: 66
		private global::System.Windows.Forms.Panel container2;

		// Token: 0x04000043 RID: 67
		internal global::System.Windows.Forms.GroupBox groupOptions;

		// Token: 0x04000044 RID: 68
		internal global::System.Windows.Forms.RadioButton radioReconfig;

		// Token: 0x04000045 RID: 69
		internal global::System.Windows.Forms.RadioButton radioInstall;

		// Token: 0x04000046 RID: 70
		internal global::System.Windows.Forms.CheckBox checkRedis;

		// Token: 0x04000047 RID: 71
		internal global::System.Windows.Forms.CheckBox checkBeta;

		// Token: 0x04000048 RID: 72
		internal global::System.Windows.Forms.GroupBox groupDatabase;

		// Token: 0x04000049 RID: 73
		private global::System.Windows.Forms.CheckBox checkOwn;

		// Token: 0x0400004A RID: 74
		private global::System.Windows.Forms.Label labelEnterDatabase;

		// Token: 0x0400004B RID: 75
		private global::System.Windows.Forms.Label labelHost;

		// Token: 0x0400004C RID: 76
		private global::System.Windows.Forms.TextBox textDatabase;

		// Token: 0x0400004D RID: 77
		private global::System.Windows.Forms.Label labelPass;

		// Token: 0x0400004E RID: 78
		private global::System.Windows.Forms.TextBox textUser;

		// Token: 0x0400004F RID: 79
		private global::System.Windows.Forms.Label labelUser;

		// Token: 0x04000050 RID: 80
		private global::System.Windows.Forms.TextBox textPort;

		// Token: 0x04000051 RID: 81
		private global::System.Windows.Forms.Label labelSeperator;

		// Token: 0x04000052 RID: 82
		private global::System.Windows.Forms.TextBox textHost;

		// Token: 0x04000053 RID: 83
		private global::System.Windows.Forms.TextBox textPass;

		// Token: 0x04000054 RID: 84
		private global::System.Windows.Forms.Panel container3;

		// Token: 0x04000055 RID: 85
		private global::System.Windows.Forms.RichTextBox textProgress;

		// Token: 0x04000056 RID: 86
		private global::System.Windows.Forms.ProgressBar progressbar;

		// Token: 0x04000057 RID: 87
		private global::System.Windows.Forms.Label lblMaintainer;

		// Token: 0x04000058 RID: 88
		private global::System.Windows.Forms.PictureBox pictureLogo;

		// Token: 0x04000059 RID: 89
		private global::System.Windows.Forms.Label lblSupporter;

		// Token: 0x0400005A RID: 90
		internal global::System.Windows.Forms.Label lblDayzModDescription;

		// Token: 0x0400005B RID: 91
		internal global::System.Windows.Forms.Label lblDayZModVersion;
	}
}
