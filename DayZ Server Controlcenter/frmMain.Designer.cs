namespace Crosire.Controlcenter
{
	// Token: 0x02000009 RID: 9
	public partial class frmMain : global::System.Windows.Forms.Form
	{
		// Token: 0x0600006B RID: 107 RVA: 0x0000E5F8 File Offset: 0x0000C7F8
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600006C RID: 108 RVA: 0x0000E630 File Offset: 0x0000C830
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Crosire.Controlcenter.frmMain));
			this.timerMonitor = new global::System.Windows.Forms.Timer(this.components);
			this.container1 = new global::System.Windows.Forms.SplitContainer();
			this.btnLog = new global::System.Windows.Forms.CheckBox();
			this.btnExit = new global::System.Windows.Forms.Button();
			this.cbxInstance = new global::System.Windows.Forms.ComboBox();
			this.labelSelectInstance = new global::System.Windows.Forms.Label();
			this.labelDescription4 = new global::System.Windows.Forms.Label();
			this.labelDescription2 = new global::System.Windows.Forms.Label();
			this.labelDescription3 = new global::System.Windows.Forms.Label();
			this.labelDescription1 = new global::System.Windows.Forms.Label();
			this.btnMenu4 = new global::System.Windows.Forms.RadioButton();
			this.btnMenu2 = new global::System.Windows.Forms.RadioButton();
			this.btnMenu3 = new global::System.Windows.Forms.RadioButton();
			this.btnMenu1 = new global::System.Windows.Forms.RadioButton();
			this.container2 = new global::System.Windows.Forms.SplitContainer();
			this.textLog = new global::System.Windows.Forms.RichTextBox();
			this.container2_2 = new global::System.Windows.Forms.Panel();
			this.tab2 = new global::System.Windows.Forms.TabControl();
			this.tab2Page1 = new global::System.Windows.Forms.TabPage();
			this.tab2Page2 = new global::System.Windows.Forms.TabPage();
			this.groupLogin = new global::System.Windows.Forms.GroupBox();
			this.labelMySqlCredentials = new global::System.Windows.Forms.Label();
			this.btnMysqlHost = new global::System.Windows.Forms.Button();
			this.textMysqlUser = new global::System.Windows.Forms.TextBox();
			this.btnMysqlUser = new global::System.Windows.Forms.Button();
			this.textMysqlPass = new global::System.Windows.Forms.TextBox();
			this.labelMysqlPoint = new global::System.Windows.Forms.Label();
			this.labelMySqlHost = new global::System.Windows.Forms.Label();
			this.textMysqlPort = new global::System.Windows.Forms.TextBox();
			this.textMysqlHost = new global::System.Windows.Forms.TextBox();
			this.tab2Page3 = new global::System.Windows.Forms.TabPage();
			this.btnLogClear = new global::System.Windows.Forms.LinkLabel();
			this.btnLogMonitor = new global::System.Windows.Forms.LinkLabel();
			this.textLogRpt = new global::System.Windows.Forms.RichTextBox();
			this.container2_4 = new global::System.Windows.Forms.Panel();
			this.groupSettings = new global::System.Windows.Forms.GroupBox();
			this.cbxLanguage = new global::System.Windows.Forms.ComboBox();
			this.labelChooseLanguage = new global::System.Windows.Forms.Label();
			this.groupAbout = new global::System.Windows.Forms.GroupBox();
			this.pictureLicense = new global::System.Windows.Forms.PictureBox();
			this.labelAppName = new global::System.Windows.Forms.Label();
			this.labelVersionText = new global::System.Windows.Forms.Label();
			this.pictureIcon = new global::System.Windows.Forms.PictureBox();
			this.labelVersion = new global::System.Windows.Forms.Label();
			this.container2_3 = new global::System.Windows.Forms.Panel();
			this.tab3 = new global::System.Windows.Forms.TabControl();
			this.tab3Page1 = new global::System.Windows.Forms.TabPage();
			this.tab3Page2 = new global::System.Windows.Forms.TabPage();
			this.checkWhitelisted = new global::System.Windows.Forms.CheckBox();
			this.groupSurvivor = new global::System.Windows.Forms.GroupBox();
			this.textMedical = new global::System.Windows.Forms.TextBox();
			this.labelMedical = new global::System.Windows.Forms.Label();
			this.textPosition = new global::System.Windows.Forms.TextBox();
			this.labelPosition = new global::System.Windows.Forms.Label();
			this.textBackpack = new global::System.Windows.Forms.TextBox();
			this.labelBackpack = new global::System.Windows.Forms.Label();
			this.textInventory = new global::System.Windows.Forms.TextBox();
			this.labelInventory = new global::System.Windows.Forms.Label();
			this.listPlayers = new global::System.Windows.Forms.ListBox();
			this.groupProfile = new global::System.Windows.Forms.GroupBox();
			this.textPlayerGuid = new global::System.Windows.Forms.TextBox();
			this.labelPlayerGuid = new global::System.Windows.Forms.Label();
			this.textPlayerUid = new global::System.Windows.Forms.TextBox();
			this.labelPlayerUid = new global::System.Windows.Forms.Label();
			this.textPlayerName = new global::System.Windows.Forms.TextBox();
			this.labelPlayerName = new global::System.Windows.Forms.Label();
			this.btnPlayerAdd = new global::System.Windows.Forms.Button();
			this.btnSave4 = new global::System.Windows.Forms.Button();
			this.tab3Page3 = new global::System.Windows.Forms.TabPage();
			this.groupReset = new global::System.Windows.Forms.GroupBox();
			this.labelNoticeReset = new global::System.Windows.Forms.Label();
			this.btnReset = new global::System.Windows.Forms.Button();
			this.groupAutoBackup = new global::System.Windows.Forms.GroupBox();
			this.progressBackup = new global::System.Windows.Forms.ProgressBar();
			this.btnAutoBackup = new global::System.Windows.Forms.Button();
			this.numBackupInterval = new global::System.Windows.Forms.NumericUpDown();
			this.labelEnterBackupInterval = new global::System.Windows.Forms.Label();
			this.groupRestore = new global::System.Windows.Forms.GroupBox();
			this.btnRestore = new global::System.Windows.Forms.Button();
			this.groupBackup = new global::System.Windows.Forms.GroupBox();
			this.btnBackupBrowse = new global::System.Windows.Forms.Button();
			this.textBackupPath = new global::System.Windows.Forms.TextBox();
			this.labelPathBackupFolder = new global::System.Windows.Forms.Label();
			this.btnBackup = new global::System.Windows.Forms.Button();
			this.container2_1 = new global::System.Windows.Forms.Panel();
			this.tab1 = new global::System.Windows.Forms.TabControl();
			this.tab1Page1 = new global::System.Windows.Forms.TabPage();
			this.btnSave1 = new global::System.Windows.Forms.Button();
			this.textBuild = new global::System.Windows.Forms.MaskedTextBox();
			this.textPort = new global::System.Windows.Forms.MaskedTextBox();
			this.groupTime = new global::System.Windows.Forms.GroupBox();
			this.labelTime = new global::System.Windows.Forms.Label();
			this.checkDaytime = new global::System.Windows.Forms.CheckBox();
			this.textTimezone = new global::System.Windows.Forms.Label();
			this.labelTimezone = new global::System.Windows.Forms.Label();
			this.trackTimezone = new global::System.Windows.Forms.TrackBar();
			this.groupTemplate = new global::System.Windows.Forms.GroupBox();
			this.checkRmod = new global::System.Windows.Forms.CheckBox();
			this.btnDatabase = new global::System.Windows.Forms.Button();
			this.cbxDatabase = new global::System.Windows.Forms.ComboBox();
			this.labelSelectDatabase = new global::System.Windows.Forms.Label();
			this.labelDifficulty = new global::System.Windows.Forms.Label();
			this.cbxDifficulty = new global::System.Windows.Forms.ComboBox();
			this.cbxTemplate = new global::System.Windows.Forms.ComboBox();
			this.labelTemplate = new global::System.Windows.Forms.Label();
			this.checkPersistent = new global::System.Windows.Forms.CheckBox();
			this.groupVon = new global::System.Windows.Forms.GroupBox();
			this.numVonQuality = new global::System.Windows.Forms.NumericUpDown();
			this.labelCodecQuality = new global::System.Windows.Forms.Label();
			this.checkVon = new global::System.Windows.Forms.CheckBox();
			this.labelRequiredBuild = new global::System.Windows.Forms.Label();
			this.groupMessage = new global::System.Windows.Forms.GroupBox();
			this.textWelcomeMessage = new global::System.Windows.Forms.TextBox();
			this.labelWelcomeMessage = new global::System.Windows.Forms.Label();
			this.labelNoticeMessage = new global::System.Windows.Forms.Label();
			this.numMessageInterval = new global::System.Windows.Forms.NumericUpDown();
			this.labelTimeBetweenMessage = new global::System.Windows.Forms.Label();
			this.textMessage = new global::System.Windows.Forms.RichTextBox();
			this.numMaxPlayers = new global::System.Windows.Forms.NumericUpDown();
			this.labelMaxPlayers = new global::System.Windows.Forms.Label();
			this.cbxReportingIp = new global::System.Windows.Forms.ComboBox();
			this.labelPort = new global::System.Windows.Forms.Label();
			this.labelReportingIp = new global::System.Windows.Forms.Label();
			this.textHostname = new global::System.Windows.Forms.TextBox();
			this.labelServerName = new global::System.Windows.Forms.Label();
			this.tab1Page2 = new global::System.Windows.Forms.TabPage();
			this.groupWhitelist = new global::System.Windows.Forms.GroupBox();
			this.textWhitelistMessage = new global::System.Windows.Forms.TextBox();
			this.labelWhitelistMessage = new global::System.Windows.Forms.Label();
			this.checkWhitelist = new global::System.Windows.Forms.CheckBox();
			this.btnRandomPass = new global::System.Windows.Forms.Button();
			this.btnSave2 = new global::System.Windows.Forms.Button();
			this.groupSignatures = new global::System.Windows.Forms.GroupBox();
			this.numSecureId = new global::System.Windows.Forms.NumericUpDown();
			this.labelRequireSecureId = new global::System.Windows.Forms.Label();
			this.numVerifySignatures = new global::System.Windows.Forms.NumericUpDown();
			this.labelVerifySignatures = new global::System.Windows.Forms.Label();
			this.groupScripting = new global::System.Windows.Forms.GroupBox();
			this.checkDuplicate = new global::System.Windows.Forms.CheckBox();
			this.textRegularCheck = new global::System.Windows.Forms.TextBox();
			this.labelRegularCheck = new global::System.Windows.Forms.Label();
			this.textOnUnsigned = new global::System.Windows.Forms.TextBox();
			this.textOnDifferent = new global::System.Windows.Forms.TextBox();
			this.textOnHacked = new global::System.Windows.Forms.TextBox();
			this.textOnUserDisconnected = new global::System.Windows.Forms.TextBox();
			this.textOnUserConnected = new global::System.Windows.Forms.TextBox();
			this.textDoubleId = new global::System.Windows.Forms.TextBox();
			this.labelOnUnsignedData = new global::System.Windows.Forms.Label();
			this.labelOnDifferentData = new global::System.Windows.Forms.Label();
			this.labelOnHackedData = new global::System.Windows.Forms.Label();
			this.labelOnUserDisconnected = new global::System.Windows.Forms.Label();
			this.labelOnUserConnected = new global::System.Windows.Forms.Label();
			this.labelDoubleId = new global::System.Windows.Forms.Label();
			this.groupBattleye = new global::System.Windows.Forms.GroupBox();
			this.numMaxPing = new global::System.Windows.Forms.NumericUpDown();
			this.labelMaxPing = new global::System.Windows.Forms.Label();
			this.checkBattleye = new global::System.Windows.Forms.CheckBox();
			this.textPasswordRcon = new global::System.Windows.Forms.TextBox();
			this.labelRconPassword = new global::System.Windows.Forms.Label();
			this.textPasswordAdmin = new global::System.Windows.Forms.TextBox();
			this.labelAdminPassword = new global::System.Windows.Forms.Label();
			this.textPasswordServer = new global::System.Windows.Forms.TextBox();
			this.labelPassword = new global::System.Windows.Forms.Label();
			this.tab1Page3 = new global::System.Windows.Forms.TabPage();
			this.groupAdditional = new global::System.Windows.Forms.GroupBox();
			this.cbxLoadoutBackpack = new global::System.Windows.Forms.ComboBox();
			this.labelLoadoutBackpack = new global::System.Windows.Forms.Label();
			this.textModlist = new global::System.Windows.Forms.TextBox();
			this.labelModlist = new global::System.Windows.Forms.Label();
			this.cbxLoadout = new global::System.Windows.Forms.ComboBox();
			this.labelLoadout = new global::System.Windows.Forms.Label();
			this.numMaxCustomsize = new global::System.Windows.Forms.NumericUpDown();
			this.labelMaxCustomSize = new global::System.Windows.Forms.Label();
			this.labelMaxCustomSizeUnit = new global::System.Windows.Forms.Label();
			this.btnSave3 = new global::System.Windows.Forms.Button();
			this.groupNetwork = new global::System.Windows.Forms.GroupBox();
			this.numMaxBandwidth = new global::System.Windows.Forms.NumericUpDown();
			this.numMinBandwidth = new global::System.Windows.Forms.NumericUpDown();
			this.numMaxMessages = new global::System.Windows.Forms.NumericUpDown();
			this.numMaxSizeGuaranteed = new global::System.Windows.Forms.NumericUpDown();
			this.numMaxSizeNonguaranteed = new global::System.Windows.Forms.NumericUpDown();
			this.numMinErrorNear = new global::System.Windows.Forms.NumericUpDown();
			this.numMinError = new global::System.Windows.Forms.NumericUpDown();
			this.labelMaxBandwidthUnit = new global::System.Windows.Forms.Label();
			this.labelMinBandwidthUnit = new global::System.Windows.Forms.Label();
			this.labelMaxSizeNonguaranteedUnit = new global::System.Windows.Forms.Label();
			this.labelMaxSizeGuaranteedUnit = new global::System.Windows.Forms.Label();
			this.labelMinErrtoSendNear = new global::System.Windows.Forms.Label();
			this.labelMinErrtoSend = new global::System.Windows.Forms.Label();
			this.labelMaxBandwidth = new global::System.Windows.Forms.Label();
			this.labelMinBandwidth = new global::System.Windows.Forms.Label();
			this.labelMaxSizeNonguaranteed = new global::System.Windows.Forms.Label();
			this.labelMaxSizeGuaranteed = new global::System.Windows.Forms.Label();
			this.labelMaxMsgSent = new global::System.Windows.Forms.Label();
			((global::System.ComponentModel.ISupportInitialize)this.container1).BeginInit();
			this.container1.Panel1.SuspendLayout();
			this.container1.Panel2.SuspendLayout();
			this.container1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.container2).BeginInit();
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
			((global::System.ComponentModel.ISupportInitialize)this.pictureLicense).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureIcon).BeginInit();
			this.container2_3.SuspendLayout();
			this.tab3.SuspendLayout();
			this.tab3Page2.SuspendLayout();
			this.groupSurvivor.SuspendLayout();
			this.groupProfile.SuspendLayout();
			this.tab3Page3.SuspendLayout();
			this.groupReset.SuspendLayout();
			this.groupAutoBackup.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numBackupInterval).BeginInit();
			this.groupRestore.SuspendLayout();
			this.groupBackup.SuspendLayout();
			this.container2_1.SuspendLayout();
			this.tab1.SuspendLayout();
			this.tab1Page1.SuspendLayout();
			this.groupTime.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.trackTimezone).BeginInit();
			this.groupTemplate.SuspendLayout();
			this.groupVon.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numVonQuality).BeginInit();
			this.groupMessage.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numMessageInterval).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.numMaxPlayers).BeginInit();
			this.tab1Page2.SuspendLayout();
			this.groupWhitelist.SuspendLayout();
			this.groupSignatures.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numSecureId).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.numVerifySignatures).BeginInit();
			this.groupScripting.SuspendLayout();
			this.groupBattleye.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numMaxPing).BeginInit();
			this.tab1Page3.SuspendLayout();
			this.groupAdditional.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numMaxCustomsize).BeginInit();
			this.groupNetwork.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numMaxBandwidth).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.numMinBandwidth).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.numMaxMessages).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.numMaxSizeGuaranteed).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.numMaxSizeNonguaranteed).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.numMinErrorNear).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.numMinError).BeginInit();
			base.SuspendLayout();
			this.timerMonitor.Interval = 1000;
			this.timerMonitor.Tick += new global::System.EventHandler(this.timerMonitor_Tick);
			this.container1.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.container1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.container1.FixedPanel = global::System.Windows.Forms.FixedPanel.Panel1;
			this.container1.IsSplitterFixed = true;
			this.container1.Location = new global::System.Drawing.Point(0, 0);
			this.container1.Name = "container1";
			this.container1.Panel1.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.None;
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
			this.container1.Size = new global::System.Drawing.Size(884, 612);
			this.container1.SplitterDistance = 160;
			this.container1.SplitterWidth = 2;
			this.container1.TabIndex = 0;
			this.container1.TabStop = false;
			this.btnLog.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.btnLog.Appearance = global::System.Windows.Forms.Appearance.Button;
			this.btnLog.Location = new global::System.Drawing.Point(11, 551);
			this.btnLog.Name = "btnLog";
			this.btnLog.Size = new global::System.Drawing.Size(139, 24);
			this.btnLog.TabIndex = 16;
			this.btnLog.Text = global::Crosire.Controlcenter.Properties.Resources.button_log;
			this.btnLog.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.btnLog.UseVisualStyleBackColor = true;
			this.btnLog.CheckedChanged += new global::System.EventHandler(this.btnLog_CheckedChanged);
			this.btnExit.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.btnExit.DialogResult = global::System.Windows.Forms.DialogResult.OK;
			this.btnExit.Location = new global::System.Drawing.Point(11, 579);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new global::System.Drawing.Size(138, 23);
			this.btnExit.TabIndex = 2;
			this.btnExit.Text = global::Crosire.Controlcenter.Properties.Resources.button_exit;
			this.btnExit.UseVisualStyleBackColor = true;
			this.btnExit.Click += new global::System.EventHandler(this.btnExit_Click);
			this.cbxInstance.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.cbxInstance.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxInstance.FormattingEnabled = true;
			this.cbxInstance.Items.AddRange(new object[] { "1", "2", "3", "4", "5", "6" });
			this.cbxInstance.Location = new global::System.Drawing.Point(12, 524);
			this.cbxInstance.MaxDropDownItems = 9;
			this.cbxInstance.Name = "cbxInstance";
			this.cbxInstance.Size = new global::System.Drawing.Size(138, 21);
			this.cbxInstance.TabIndex = 0;
			this.cbxInstance.SelectedIndexChanged += new global::System.EventHandler(this.frmMain_ChangeInstance);
			this.labelSelectInstance.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left;
			this.labelSelectInstance.AutoSize = true;
			this.labelSelectInstance.Location = new global::System.Drawing.Point(9, 508);
			this.labelSelectInstance.Name = "labelSelectInstance";
			this.labelSelectInstance.Size = new global::System.Drawing.Size(137, 13);
			this.labelSelectInstance.TabIndex = 1;
			this.labelSelectInstance.Text = "Server instance to manage:";
			this.labelDescription4.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 6.75f);
			this.labelDescription4.Location = new global::System.Drawing.Point(11, 392);
			this.labelDescription4.Name = "labelDescription4";
			this.labelDescription4.Size = new global::System.Drawing.Size(139, 90);
			this.labelDescription4.TabIndex = 15;
			this.labelDescription4.Text = "Description";
			this.labelDescription2.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 6.75f);
			this.labelDescription2.Location = new global::System.Drawing.Point(11, 152);
			this.labelDescription2.Name = "labelDescription2";
			this.labelDescription2.Size = new global::System.Drawing.Size(139, 90);
			this.labelDescription2.TabIndex = 14;
			this.labelDescription2.Text = "Description";
			this.labelDescription3.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 6.75f);
			this.labelDescription3.Location = new global::System.Drawing.Point(11, 267);
			this.labelDescription3.Name = "labelDescription3";
			this.labelDescription3.Size = new global::System.Drawing.Size(139, 90);
			this.labelDescription3.TabIndex = 13;
			this.labelDescription3.Text = "Description";
			this.labelDescription1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 6.75f);
			this.labelDescription1.Location = new global::System.Drawing.Point(11, 37);
			this.labelDescription1.Name = "labelDescription1";
			this.labelDescription1.Size = new global::System.Drawing.Size(139, 90);
			this.labelDescription1.TabIndex = 12;
			this.labelDescription1.Text = "Description";
			this.btnMenu4.Appearance = global::System.Windows.Forms.Appearance.Button;
			this.btnMenu4.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold);
			this.btnMenu4.Location = new global::System.Drawing.Point(11, 366);
			this.btnMenu4.Name = "btnMenu4";
			this.btnMenu4.Size = new global::System.Drawing.Size(138, 23);
			this.btnMenu4.TabIndex = 11;
			this.btnMenu4.Text = global::Crosire.Controlcenter.Properties.Resources.button_menu4;
			this.btnMenu4.CheckedChanged += new global::System.EventHandler(this.frmMain_ChangePanel);
			this.btnMenu2.Appearance = global::System.Windows.Forms.Appearance.Button;
			this.btnMenu2.Checked = true;
			this.btnMenu2.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold);
			this.btnMenu2.Location = new global::System.Drawing.Point(11, 126);
			this.btnMenu2.Name = "btnMenu2";
			this.btnMenu2.Size = new global::System.Drawing.Size(138, 23);
			this.btnMenu2.TabIndex = 10;
			this.btnMenu2.TabStop = true;
			this.btnMenu2.Text = global::Crosire.Controlcenter.Properties.Resources.button_menu2;
			this.btnMenu2.UseVisualStyleBackColor = true;
			this.btnMenu2.CheckedChanged += new global::System.EventHandler(this.frmMain_ChangePanel);
			this.btnMenu3.Appearance = global::System.Windows.Forms.Appearance.Button;
			this.btnMenu3.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold);
			this.btnMenu3.Location = new global::System.Drawing.Point(11, 241);
			this.btnMenu3.Name = "btnMenu3";
			this.btnMenu3.Size = new global::System.Drawing.Size(138, 23);
			this.btnMenu3.TabIndex = 9;
			this.btnMenu3.Text = global::Crosire.Controlcenter.Properties.Resources.button_menu3;
			this.btnMenu3.CheckedChanged += new global::System.EventHandler(this.frmMain_ChangePanel);
			this.btnMenu1.Appearance = global::System.Windows.Forms.Appearance.Button;
			this.btnMenu1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Bold);
			this.btnMenu1.Location = new global::System.Drawing.Point(11, 11);
			this.btnMenu1.Name = "btnMenu1";
			this.btnMenu1.Size = new global::System.Drawing.Size(138, 23);
			this.btnMenu1.TabIndex = 8;
			this.btnMenu1.Text = global::Crosire.Controlcenter.Properties.Resources.button_menu1;
			this.btnMenu1.CheckedChanged += new global::System.EventHandler(this.frmMain_ChangePanel);
			this.container2.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.container2.FixedPanel = global::System.Windows.Forms.FixedPanel.Panel2;
			this.container2.IsSplitterFixed = true;
			this.container2.Location = new global::System.Drawing.Point(0, 0);
			this.container2.Name = "container2";
			this.container2.Orientation = global::System.Windows.Forms.Orientation.Horizontal;
			this.container2.Panel1.Controls.Add(this.textLog);
			this.container2.Panel1Collapsed = true;
			this.container2.Panel1MinSize = 0;
			this.container2.Panel2.Controls.Add(this.container2_2);
			this.container2.Panel2.Controls.Add(this.container2_4);
			this.container2.Panel2.Controls.Add(this.container2_3);
			this.container2.Panel2.Controls.Add(this.container2_1);
			this.container2.Panel2MinSize = 0;
			this.container2.Size = new global::System.Drawing.Size(720, 610);
			this.container2.SplitterDistance = 96;
			this.container2.TabIndex = 1;
			this.textLog.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.textLog.Location = new global::System.Drawing.Point(0, 0);
			this.textLog.Name = "textLog";
			this.textLog.ReadOnly = true;
			this.textLog.Size = new global::System.Drawing.Size(150, 96);
			this.textLog.TabIndex = 0;
			this.textLog.Text = "";
			this.container2_2.Controls.Add(this.tab2);
			this.container2_2.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.container2_2.Location = new global::System.Drawing.Point(0, 0);
			this.container2_2.Name = "container2_2";
			this.container2_2.Size = new global::System.Drawing.Size(720, 610);
			this.container2_2.TabIndex = 3;
			this.tab2.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.tab2.Appearance = global::System.Windows.Forms.TabAppearance.FlatButtons;
			this.tab2.Controls.Add(this.tab2Page1);
			this.tab2.Controls.Add(this.tab2Page2);
			this.tab2.Controls.Add(this.tab2Page3);
			this.tab2.ItemSize = new global::System.Drawing.Size(100, 21);
			this.tab2.Location = new global::System.Drawing.Point(0, 0);
			this.tab2.Name = "tab2";
			this.tab2.SelectedIndex = 0;
			this.tab2.Size = new global::System.Drawing.Size(721, 610);
			this.tab2.SizeMode = global::System.Windows.Forms.TabSizeMode.Fixed;
			this.tab2.TabIndex = 0;
			this.tab2Page1.Location = new global::System.Drawing.Point(4, 25);
			this.tab2Page1.Name = "tab2Page1";
			this.tab2Page1.Padding = new global::System.Windows.Forms.Padding(3);
			this.tab2Page1.Size = new global::System.Drawing.Size(713, 581);
			this.tab2Page1.TabIndex = 0;
			this.tab2Page1.Text = "Manage";
			this.tab2Page1.UseVisualStyleBackColor = true;
			this.tab2Page2.Controls.Add(this.groupLogin);
			this.tab2Page2.Location = new global::System.Drawing.Point(4, 25);
			this.tab2Page2.Name = "tab2Page2";
			this.tab2Page2.Size = new global::System.Drawing.Size(713, 581);
			this.tab2Page2.TabIndex = 4;
			this.tab2Page2.Text = "Server";
			this.tab2Page2.UseVisualStyleBackColor = true;
			this.groupLogin.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.groupLogin.Controls.Add(this.labelMySqlCredentials);
			this.groupLogin.Controls.Add(this.btnMysqlHost);
			this.groupLogin.Controls.Add(this.textMysqlUser);
			this.groupLogin.Controls.Add(this.btnMysqlUser);
			this.groupLogin.Controls.Add(this.textMysqlPass);
			this.groupLogin.Controls.Add(this.labelMysqlPoint);
			this.groupLogin.Controls.Add(this.labelMySqlHost);
			this.groupLogin.Controls.Add(this.textMysqlPort);
			this.groupLogin.Controls.Add(this.textMysqlHost);
			this.groupLogin.Location = new global::System.Drawing.Point(9, 7);
			this.groupLogin.Name = "groupLogin";
			this.groupLogin.Size = new global::System.Drawing.Size(690, 126);
			this.groupLogin.TabIndex = 6;
			this.groupLogin.TabStop = false;
			this.groupLogin.Text = "Login information";
			this.labelMySqlCredentials.AutoSize = true;
			this.labelMySqlCredentials.Location = new global::System.Drawing.Point(6, 72);
			this.labelMySqlCredentials.Name = "labelMySqlCredentials";
			this.labelMySqlCredentials.Size = new global::System.Drawing.Size(100, 13);
			this.labelMySqlCredentials.TabIndex = 11;
			this.labelMySqlCredentials.Text = "MySQL Credentials:";
			this.btnMysqlHost.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.btnMysqlHost.Location = new global::System.Drawing.Point(488, 40);
			this.btnMysqlHost.Name = "btnMysqlHost";
			this.btnMysqlHost.Size = new global::System.Drawing.Size(194, 23);
			this.btnMysqlHost.TabIndex = 6;
			this.btnMysqlHost.Text = global::Crosire.Controlcenter.Properties.Resources.button_save;
			this.btnMysqlHost.UseVisualStyleBackColor = true;
			this.btnMysqlHost.Click += new global::System.EventHandler(this.btnMysqlHost_Click);
			this.textMysqlUser.Location = new global::System.Drawing.Point(9, 92);
			this.textMysqlUser.MaxLength = 16;
			this.textMysqlUser.Name = "textMysqlUser";
			this.textMysqlUser.Size = new global::System.Drawing.Size(190, 20);
			this.textMysqlUser.TabIndex = 10;
			this.textMysqlUser.Text = "dayz";
			this.btnMysqlUser.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.btnMysqlUser.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.btnMysqlUser.Location = new global::System.Drawing.Point(488, 90);
			this.btnMysqlUser.Name = "btnMysqlUser";
			this.btnMysqlUser.Size = new global::System.Drawing.Size(194, 23);
			this.btnMysqlUser.TabIndex = 1;
			this.btnMysqlUser.Text = "Save";
			this.btnMysqlUser.UseVisualStyleBackColor = true;
			this.btnMysqlUser.Click += new global::System.EventHandler(this.btnMysqlUser_Click);
			this.textMysqlPass.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.textMysqlPass.Location = new global::System.Drawing.Point(221, 92);
			this.textMysqlPass.MaxLength = 100;
			this.textMysqlPass.Name = "textMysqlPass";
			this.textMysqlPass.Size = new global::System.Drawing.Size(261, 20);
			this.textMysqlPass.TabIndex = 2;
			this.textMysqlPass.UseSystemPasswordChar = true;
			this.labelMysqlPoint.AutoSize = true;
			this.labelMysqlPoint.Location = new global::System.Drawing.Point(206, 45);
			this.labelMysqlPoint.Name = "labelMysqlPoint";
			this.labelMysqlPoint.Size = new global::System.Drawing.Size(10, 13);
			this.labelMysqlPoint.TabIndex = 8;
			this.labelMysqlPoint.Text = ":";
			this.labelMySqlHost.AutoSize = true;
			this.labelMySqlHost.Location = new global::System.Drawing.Point(6, 22);
			this.labelMySqlHost.Name = "labelMySqlHost";
			this.labelMySqlHost.Size = new global::System.Drawing.Size(111, 13);
			this.labelMySqlHost.TabIndex = 4;
			this.labelMySqlHost.Text = "MySQL Host Address:";
			this.textMysqlPort.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.textMysqlPort.Location = new global::System.Drawing.Point(222, 42);
			this.textMysqlPort.MaxLength = 10;
			this.textMysqlPort.Name = "textMysqlPort";
			this.textMysqlPort.Size = new global::System.Drawing.Size(260, 20);
			this.textMysqlPort.TabIndex = 5;
			this.textMysqlPort.Text = "3306";
			this.textMysqlHost.Location = new global::System.Drawing.Point(9, 42);
			this.textMysqlHost.MaxLength = 32;
			this.textMysqlHost.Name = "textMysqlHost";
			this.textMysqlHost.Size = new global::System.Drawing.Size(191, 20);
			this.textMysqlHost.TabIndex = 5;
			this.textMysqlHost.Text = "127.0.0.1";
			this.tab2Page3.Controls.Add(this.btnLogClear);
			this.tab2Page3.Controls.Add(this.btnLogMonitor);
			this.tab2Page3.Controls.Add(this.textLogRpt);
			this.tab2Page3.Location = new global::System.Drawing.Point(4, 25);
			this.tab2Page3.Name = "tab2Page3";
			this.tab2Page3.Size = new global::System.Drawing.Size(713, 581);
			this.tab2Page3.TabIndex = 3;
			this.tab2Page3.Text = global::Crosire.Controlcenter.Properties.Resources.tab2_page3;
			this.tab2Page3.UseVisualStyleBackColor = true;
			this.btnLogClear.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.btnLogClear.Location = new global::System.Drawing.Point(599, 5);
			this.btnLogClear.Name = "btnLogClear";
			this.btnLogClear.Size = new global::System.Drawing.Size(108, 15);
			this.btnLogClear.TabIndex = 4;
			this.btnLogClear.TabStop = true;
			this.btnLogClear.Text = "Clear";
			this.btnLogClear.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.btnLogClear.LinkClicked += new global::System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnLogClear_LinkClicked);
			this.btnLogMonitor.AutoSize = true;
			this.btnLogMonitor.Location = new global::System.Drawing.Point(6, 5);
			this.btnLogMonitor.Name = "btnLogMonitor";
			this.btnLogMonitor.Size = new global::System.Drawing.Size(146, 13);
			this.btnLogMonitor.TabIndex = 2;
			this.btnLogMonitor.TabStop = true;
			this.btnLogMonitor.Text = "Start Realtime Log Monitoring";
			this.btnLogMonitor.LinkClicked += new global::System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnLogMonitor_LinkClicked);
			this.textLogRpt.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.textLogRpt.Location = new global::System.Drawing.Point(6, 23);
			this.textLogRpt.Name = "textLogRpt";
			this.textLogRpt.ReadOnly = true;
			this.textLogRpt.Size = new global::System.Drawing.Size(701, 551);
			this.textLogRpt.TabIndex = 0;
			this.textLogRpt.Text = "";
			this.textLogRpt.WordWrap = false;
			this.container2_4.Controls.Add(this.groupSettings);
			this.container2_4.Controls.Add(this.groupAbout);
			this.container2_4.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.container2_4.Location = new global::System.Drawing.Point(0, 0);
			this.container2_4.Name = "container2_4";
			this.container2_4.Size = new global::System.Drawing.Size(720, 610);
			this.container2_4.TabIndex = 4;
			this.groupSettings.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.groupSettings.Controls.Add(this.cbxLanguage);
			this.groupSettings.Controls.Add(this.labelChooseLanguage);
			this.groupSettings.Location = new global::System.Drawing.Point(10, 116);
			this.groupSettings.Name = "groupSettings";
			this.groupSettings.Size = new global::System.Drawing.Size(699, 57);
			this.groupSettings.TabIndex = 2;
			this.groupSettings.TabStop = false;
			this.groupSettings.Text = "Settings";
			this.cbxLanguage.DropDownHeight = 200;
			this.cbxLanguage.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxLanguage.DropDownWidth = 14;
			this.cbxLanguage.FormattingEnabled = true;
			this.cbxLanguage.IntegralHeight = false;
			this.cbxLanguage.ItemHeight = 13;
			this.cbxLanguage.Items.AddRange(new object[] { "en", "es", "de", "da", "fr", "pt", "pt-br", "ru", "zh-cn" });
			this.cbxLanguage.Location = new global::System.Drawing.Point(128, 19);
			this.cbxLanguage.Name = "cbxLanguage";
			this.cbxLanguage.Size = new global::System.Drawing.Size(65, 21);
			this.cbxLanguage.TabIndex = 1;
			this.cbxLanguage.DropDownClosed += new global::System.EventHandler(this.cbxLanguage_DropDownClosed);
			this.labelChooseLanguage.AutoSize = true;
			this.labelChooseLanguage.Location = new global::System.Drawing.Point(6, 22);
			this.labelChooseLanguage.Name = "labelChooseLanguage";
			this.labelChooseLanguage.Size = new global::System.Drawing.Size(116, 13);
			this.labelChooseLanguage.TabIndex = 0;
			this.labelChooseLanguage.Text = "Choose your language:";
			this.groupAbout.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.groupAbout.Controls.Add(this.pictureLicense);
			this.groupAbout.Controls.Add(this.labelAppName);
			this.groupAbout.Controls.Add(this.labelVersionText);
			this.groupAbout.Controls.Add(this.pictureIcon);
			this.groupAbout.Controls.Add(this.labelVersion);
			this.groupAbout.Location = new global::System.Drawing.Point(10, 11);
			this.groupAbout.Name = "groupAbout";
			this.groupAbout.Size = new global::System.Drawing.Size(699, 99);
			this.groupAbout.TabIndex = 0;
			this.groupAbout.TabStop = false;
			this.groupAbout.Text = "About";
			this.pictureLicense.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.pictureLicense.Image = global::Crosire.Controlcenter.Properties.Resources.license;
			this.pictureLicense.Location = new global::System.Drawing.Point(588, 21);
			this.pictureLicense.Name = "pictureLicense";
			this.pictureLicense.Size = new global::System.Drawing.Size(100, 64);
			this.pictureLicense.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.CenterImage;
			this.pictureLicense.TabIndex = 6;
			this.pictureLicense.TabStop = false;
			this.pictureLicense.Click += new global::System.EventHandler(this.pictureLicense_Click);
			this.labelAppName.AutoSize = true;
			this.labelAppName.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 10f, global::System.Drawing.FontStyle.Bold);
			this.labelAppName.Location = new global::System.Drawing.Point(81, 19);
			this.labelAppName.Name = "labelAppName";
			this.labelAppName.Size = new global::System.Drawing.Size(281, 17);
			this.labelAppName.TabIndex = 5;
			this.labelAppName.TabStop = true;
			this.labelAppName.Text = "DayZ Server Controlcenter by Crosire";
			this.labelVersionText.AutoSize = true;
			this.labelVersionText.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.75f);
			this.labelVersionText.Location = new global::System.Drawing.Point(81, 45);
			this.labelVersionText.Name = "labelVersionText";
			this.labelVersionText.Size = new global::System.Drawing.Size(57, 16);
			this.labelVersionText.TabIndex = 1;
			this.labelVersionText.Text = "Version:";
			this.pictureIcon.BackgroundImage = global::Crosire.Controlcenter.Properties.Resources.logo;
			this.pictureIcon.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.Stretch;
			this.pictureIcon.Location = new global::System.Drawing.Point(11, 21);
			this.pictureIcon.Name = "pictureIcon";
			this.pictureIcon.Size = new global::System.Drawing.Size(64, 64);
			this.pictureIcon.TabIndex = 3;
			this.pictureIcon.TabStop = false;
			this.pictureIcon.Click += new global::System.EventHandler(this.pictureIcon_Click);
			this.labelVersion.AutoSize = true;
			this.labelVersion.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9.75f);
			this.labelVersion.Location = new global::System.Drawing.Point(169, 45);
			this.labelVersion.Name = "labelVersion";
			this.labelVersion.Size = new global::System.Drawing.Size(0, 16);
			this.labelVersion.TabIndex = 1;
			this.container2_3.Controls.Add(this.tab3);
			this.container2_3.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.container2_3.Location = new global::System.Drawing.Point(0, 0);
			this.container2_3.Name = "container2_3";
			this.container2_3.Size = new global::System.Drawing.Size(720, 610);
			this.container2_3.TabIndex = 1;
			this.tab3.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.tab3.Appearance = global::System.Windows.Forms.TabAppearance.FlatButtons;
			this.tab3.Controls.Add(this.tab3Page1);
			this.tab3.Controls.Add(this.tab3Page2);
			this.tab3.Controls.Add(this.tab3Page3);
			this.tab3.ItemSize = new global::System.Drawing.Size(100, 21);
			this.tab3.Location = new global::System.Drawing.Point(0, 0);
			this.tab3.Name = "tab3";
			this.tab3.SelectedIndex = 0;
			this.tab3.Size = new global::System.Drawing.Size(721, 610);
			this.tab3.SizeMode = global::System.Windows.Forms.TabSizeMode.Fixed;
			this.tab3.TabIndex = 1;
			this.tab3Page1.Location = new global::System.Drawing.Point(4, 25);
			this.tab3Page1.Name = "tab3Page1";
			this.tab3Page1.Padding = new global::System.Windows.Forms.Padding(3);
			this.tab3Page1.Size = new global::System.Drawing.Size(713, 581);
			this.tab3Page1.TabIndex = 1;
			this.tab3Page1.Text = global::Crosire.Controlcenter.Properties.Resources.tab3_page1;
			this.tab3Page1.UseVisualStyleBackColor = true;
			this.tab3Page2.Controls.Add(this.checkWhitelisted);
			this.tab3Page2.Controls.Add(this.groupSurvivor);
			this.tab3Page2.Controls.Add(this.listPlayers);
			this.tab3Page2.Controls.Add(this.groupProfile);
			this.tab3Page2.Controls.Add(this.btnPlayerAdd);
			this.tab3Page2.Controls.Add(this.btnSave4);
			this.tab3Page2.Location = new global::System.Drawing.Point(4, 25);
			this.tab3Page2.Name = "tab3Page2";
			this.tab3Page2.Size = new global::System.Drawing.Size(713, 581);
			this.tab3Page2.TabIndex = 2;
			this.tab3Page2.Text = "Players";
			this.tab3Page2.UseVisualStyleBackColor = true;
			this.checkWhitelisted.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right;
			this.checkWhitelisted.Appearance = global::System.Windows.Forms.Appearance.Button;
			this.checkWhitelisted.Location = new global::System.Drawing.Point(193, 251);
			this.checkWhitelisted.Name = "checkWhitelisted";
			this.checkWhitelisted.Size = new global::System.Drawing.Size(250, 23);
			this.checkWhitelisted.TabIndex = 24;
			this.checkWhitelisted.Text = "Whitelisted";
			this.checkWhitelisted.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.checkWhitelisted.UseVisualStyleBackColor = true;
			this.groupSurvivor.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.groupSurvivor.Controls.Add(this.textMedical);
			this.groupSurvivor.Controls.Add(this.labelMedical);
			this.groupSurvivor.Controls.Add(this.textPosition);
			this.groupSurvivor.Controls.Add(this.labelPosition);
			this.groupSurvivor.Controls.Add(this.textBackpack);
			this.groupSurvivor.Controls.Add(this.labelBackpack);
			this.groupSurvivor.Controls.Add(this.textInventory);
			this.groupSurvivor.Controls.Add(this.labelInventory);
			this.groupSurvivor.Enabled = false;
			this.groupSurvivor.Location = new global::System.Drawing.Point(9, 398);
			this.groupSurvivor.Name = "groupSurvivor";
			this.groupSurvivor.Size = new global::System.Drawing.Size(690, 141);
			this.groupSurvivor.TabIndex = 22;
			this.groupSurvivor.TabStop = false;
			this.groupSurvivor.Text = "Survivor";
			this.textMedical.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.textMedical.Location = new global::System.Drawing.Point(89, 109);
			this.textMedical.Name = "textMedical";
			this.textMedical.Size = new global::System.Drawing.Size(591, 20);
			this.textMedical.TabIndex = 12;
			this.labelMedical.AutoSize = true;
			this.labelMedical.Location = new global::System.Drawing.Point(6, 112);
			this.labelMedical.Name = "labelMedical";
			this.labelMedical.Size = new global::System.Drawing.Size(47, 13);
			this.labelMedical.TabIndex = 11;
			this.labelMedical.Text = "Medical:";
			this.textPosition.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.textPosition.Location = new global::System.Drawing.Point(89, 79);
			this.textPosition.Name = "textPosition";
			this.textPosition.Size = new global::System.Drawing.Size(591, 20);
			this.textPosition.TabIndex = 9;
			this.labelPosition.AutoSize = true;
			this.labelPosition.Location = new global::System.Drawing.Point(6, 82);
			this.labelPosition.Name = "labelPosition";
			this.labelPosition.Size = new global::System.Drawing.Size(47, 13);
			this.labelPosition.TabIndex = 8;
			this.labelPosition.Text = "Position:";
			this.textBackpack.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.textBackpack.Location = new global::System.Drawing.Point(89, 49);
			this.textBackpack.Name = "textBackpack";
			this.textBackpack.Size = new global::System.Drawing.Size(591, 20);
			this.textBackpack.TabIndex = 5;
			this.labelBackpack.AutoSize = true;
			this.labelBackpack.Location = new global::System.Drawing.Point(6, 52);
			this.labelBackpack.Name = "labelBackpack";
			this.labelBackpack.Size = new global::System.Drawing.Size(59, 13);
			this.labelBackpack.TabIndex = 4;
			this.labelBackpack.Text = "Backpack:";
			this.textInventory.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.textInventory.Location = new global::System.Drawing.Point(89, 19);
			this.textInventory.Name = "textInventory";
			this.textInventory.Size = new global::System.Drawing.Size(591, 20);
			this.textInventory.TabIndex = 3;
			this.labelInventory.AutoSize = true;
			this.labelInventory.Location = new global::System.Drawing.Point(6, 22);
			this.labelInventory.Name = "labelInventory";
			this.labelInventory.Size = new global::System.Drawing.Size(54, 13);
			this.labelInventory.TabIndex = 2;
			this.labelInventory.Text = "Inventory:";
			this.listPlayers.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.listPlayers.FormattingEnabled = true;
			this.listPlayers.Location = new global::System.Drawing.Point(9, 7);
			this.listPlayers.Name = "listPlayers";
			this.listPlayers.ScrollAlwaysVisible = true;
			this.listPlayers.Size = new global::System.Drawing.Size(690, 238);
			this.listPlayers.Sorted = true;
			this.listPlayers.TabIndex = 1;
			this.listPlayers.SelectedIndexChanged += new global::System.EventHandler(this.listPlayers_SelectedIndexChanged);
			this.groupProfile.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.groupProfile.Controls.Add(this.textPlayerGuid);
			this.groupProfile.Controls.Add(this.labelPlayerGuid);
			this.groupProfile.Controls.Add(this.textPlayerUid);
			this.groupProfile.Controls.Add(this.labelPlayerUid);
			this.groupProfile.Controls.Add(this.textPlayerName);
			this.groupProfile.Controls.Add(this.labelPlayerName);
			this.groupProfile.Location = new global::System.Drawing.Point(9, 280);
			this.groupProfile.Name = "groupProfile";
			this.groupProfile.Size = new global::System.Drawing.Size(690, 112);
			this.groupProfile.TabIndex = 3;
			this.groupProfile.TabStop = false;
			this.groupProfile.Text = "Profile";
			this.textPlayerGuid.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.textPlayerGuid.Location = new global::System.Drawing.Point(89, 79);
			this.textPlayerGuid.MaxLength = 32;
			this.textPlayerGuid.Name = "textPlayerGuid";
			this.textPlayerGuid.Size = new global::System.Drawing.Size(591, 20);
			this.textPlayerGuid.TabIndex = 27;
			this.labelPlayerGuid.AutoSize = true;
			this.labelPlayerGuid.Location = new global::System.Drawing.Point(6, 82);
			this.labelPlayerGuid.Name = "labelPlayerGuid";
			this.labelPlayerGuid.Size = new global::System.Drawing.Size(37, 13);
			this.labelPlayerGuid.TabIndex = 26;
			this.labelPlayerGuid.Text = "GUID:";
			this.textPlayerUid.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.textPlayerUid.Enabled = false;
			this.textPlayerUid.Location = new global::System.Drawing.Point(89, 49);
			this.textPlayerUid.MaxLength = 128;
			this.textPlayerUid.Name = "textPlayerUid";
			this.textPlayerUid.Size = new global::System.Drawing.Size(591, 20);
			this.textPlayerUid.TabIndex = 25;
			this.labelPlayerUid.AutoSize = true;
			this.labelPlayerUid.Location = new global::System.Drawing.Point(6, 52);
			this.labelPlayerUid.Name = "labelPlayerUid";
			this.labelPlayerUid.Size = new global::System.Drawing.Size(29, 13);
			this.labelPlayerUid.TabIndex = 24;
			this.labelPlayerUid.Text = "UID:";
			this.textPlayerName.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.textPlayerName.Location = new global::System.Drawing.Point(89, 19);
			this.textPlayerName.MaxLength = 64;
			this.textPlayerName.Name = "textPlayerName";
			this.textPlayerName.Size = new global::System.Drawing.Size(591, 20);
			this.textPlayerName.TabIndex = 23;
			this.labelPlayerName.AutoSize = true;
			this.labelPlayerName.Location = new global::System.Drawing.Point(6, 22);
			this.labelPlayerName.Name = "labelPlayerName";
			this.labelPlayerName.Size = new global::System.Drawing.Size(38, 13);
			this.labelPlayerName.TabIndex = 22;
			this.labelPlayerName.Text = "Name:";
			this.btnPlayerAdd.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right;
			this.btnPlayerAdd.Location = new global::System.Drawing.Point(449, 251);
			this.btnPlayerAdd.Name = "btnPlayerAdd";
			this.btnPlayerAdd.Size = new global::System.Drawing.Size(250, 23);
			this.btnPlayerAdd.TabIndex = 20;
			this.btnPlayerAdd.Text = global::Crosire.Controlcenter.Properties.Resources.button_add_player;
			this.btnPlayerAdd.UseVisualStyleBackColor = true;
			this.btnPlayerAdd.Click += new global::System.EventHandler(this.btnPlayer_Click);
			this.btnSave4.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right;
			this.btnSave4.Location = new global::System.Drawing.Point(449, 545);
			this.btnSave4.Name = "btnSave4";
			this.btnSave4.Size = new global::System.Drawing.Size(250, 23);
			this.btnSave4.TabIndex = 23;
			this.btnSave4.Text = "Save configuration";
			this.btnSave4.UseVisualStyleBackColor = true;
			this.btnSave4.Click += new global::System.EventHandler(this.btnSave4_Click);
			this.tab3Page3.Controls.Add(this.groupReset);
			this.tab3Page3.Controls.Add(this.groupAutoBackup);
			this.tab3Page3.Controls.Add(this.groupRestore);
			this.tab3Page3.Controls.Add(this.groupBackup);
			this.tab3Page3.Location = new global::System.Drawing.Point(4, 25);
			this.tab3Page3.Name = "tab3Page3";
			this.tab3Page3.Padding = new global::System.Windows.Forms.Padding(3);
			this.tab3Page3.Size = new global::System.Drawing.Size(713, 581);
			this.tab3Page3.TabIndex = 3;
			this.tab3Page3.Text = "Backup";
			this.tab3Page3.UseVisualStyleBackColor = true;
			this.groupReset.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.groupReset.Controls.Add(this.labelNoticeReset);
			this.groupReset.Controls.Add(this.btnReset);
			this.groupReset.Location = new global::System.Drawing.Point(9, 236);
			this.groupReset.Name = "groupReset";
			this.groupReset.Size = new global::System.Drawing.Size(690, 100);
			this.groupReset.TabIndex = 6;
			this.groupReset.TabStop = false;
			this.groupReset.Text = "Reset";
			this.labelNoticeReset.AutoSize = true;
			this.labelNoticeReset.Location = new global::System.Drawing.Point(7, 19);
			this.labelNoticeReset.Name = "labelNoticeReset";
			this.labelNoticeReset.Size = new global::System.Drawing.Size(246, 13);
			this.labelNoticeReset.TabIndex = 5;
			this.labelNoticeReset.Text = "Notice: Warning! This deletes the whole database!";
			this.btnReset.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.btnReset.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.btnReset.Location = new global::System.Drawing.Point(9, 38);
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new global::System.Drawing.Size(671, 50);
			this.btnReset.TabIndex = 4;
			this.btnReset.Text = global::Crosire.Controlcenter.Properties.Resources.button_reset;
			this.btnReset.UseVisualStyleBackColor = true;
			this.btnReset.Click += new global::System.EventHandler(this.btnReset_Click);
			this.groupAutoBackup.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.groupAutoBackup.Controls.Add(this.progressBackup);
			this.groupAutoBackup.Controls.Add(this.btnAutoBackup);
			this.groupAutoBackup.Controls.Add(this.numBackupInterval);
			this.groupAutoBackup.Controls.Add(this.labelEnterBackupInterval);
			this.groupAutoBackup.Location = new global::System.Drawing.Point(9, 342);
			this.groupAutoBackup.Name = "groupAutoBackup";
			this.groupAutoBackup.Size = new global::System.Drawing.Size(690, 160);
			this.groupAutoBackup.TabIndex = 4;
			this.groupAutoBackup.TabStop = false;
			this.groupAutoBackup.Text = "Auto Backup";
			this.progressBackup.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.progressBackup.Location = new global::System.Drawing.Point(10, 124);
			this.progressBackup.Name = "progressBackup";
			this.progressBackup.Size = new global::System.Drawing.Size(670, 23);
			this.progressBackup.TabIndex = 6;
			this.btnAutoBackup.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.btnAutoBackup.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.btnAutoBackup.Location = new global::System.Drawing.Point(9, 68);
			this.btnAutoBackup.Name = "btnAutoBackup";
			this.btnAutoBackup.Size = new global::System.Drawing.Size(671, 50);
			this.btnAutoBackup.TabIndex = 4;
			this.btnAutoBackup.Text = global::Crosire.Controlcenter.Properties.Resources.button_autobackup_start;
			this.btnAutoBackup.UseVisualStyleBackColor = true;
			this.btnAutoBackup.Click += new global::System.EventHandler(this.btnAutoBackup_Click);
			this.numBackupInterval.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.numBackupInterval.Location = new global::System.Drawing.Point(10, 42);
			global::System.Windows.Forms.NumericUpDown numericUpDown = this.numBackupInterval;
			int[] array = new int[4];
			array[0] = 1000000000;
			numericUpDown.Maximum = new decimal(array);
			global::System.Windows.Forms.NumericUpDown numericUpDown2 = this.numBackupInterval;
			array = new int[4];
			array[0] = 1;
			numericUpDown2.Minimum = new decimal(array);
			this.numBackupInterval.Name = "numBackupInterval";
			this.numBackupInterval.Size = new global::System.Drawing.Size(670, 20);
			this.numBackupInterval.TabIndex = 1;
			global::System.Windows.Forms.NumericUpDown numericUpDown3 = this.numBackupInterval;
			array = new int[4];
			array[0] = 60;
			numericUpDown3.Value = new decimal(array);
			this.labelEnterBackupInterval.AutoSize = true;
			this.labelEnterBackupInterval.Location = new global::System.Drawing.Point(6, 22);
			this.labelEnterBackupInterval.Name = "labelEnterBackupInterval";
			this.labelEnterBackupInterval.Size = new global::System.Drawing.Size(318, 13);
			this.labelEnterBackupInterval.TabIndex = 0;
			this.labelEnterBackupInterval.Text = "Enter the interval in minutes in which a backup should be created:";
			this.groupRestore.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.groupRestore.Controls.Add(this.btnRestore);
			this.groupRestore.Location = new global::System.Drawing.Point(9, 145);
			this.groupRestore.Name = "groupRestore";
			this.groupRestore.Size = new global::System.Drawing.Size(690, 85);
			this.groupRestore.TabIndex = 2;
			this.groupRestore.TabStop = false;
			this.groupRestore.Text = "Restore";
			this.btnRestore.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.btnRestore.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.btnRestore.Location = new global::System.Drawing.Point(9, 22);
			this.btnRestore.Name = "btnRestore";
			this.btnRestore.Size = new global::System.Drawing.Size(671, 50);
			this.btnRestore.TabIndex = 2;
			this.btnRestore.Text = global::Crosire.Controlcenter.Properties.Resources.button_restore;
			this.btnRestore.UseVisualStyleBackColor = true;
			this.btnRestore.Click += new global::System.EventHandler(this.btnRestore_Click);
			this.groupBackup.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.groupBackup.Controls.Add(this.btnBackupBrowse);
			this.groupBackup.Controls.Add(this.textBackupPath);
			this.groupBackup.Controls.Add(this.labelPathBackupFolder);
			this.groupBackup.Controls.Add(this.btnBackup);
			this.groupBackup.Location = new global::System.Drawing.Point(9, 10);
			this.groupBackup.Name = "groupBackup";
			this.groupBackup.Size = new global::System.Drawing.Size(690, 129);
			this.groupBackup.TabIndex = 1;
			this.groupBackup.TabStop = false;
			this.groupBackup.Text = "Backup";
			this.btnBackupBrowse.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right;
			this.btnBackupBrowse.Location = new global::System.Drawing.Point(600, 94);
			this.btnBackupBrowse.Name = "btnBackupBrowse";
			this.btnBackupBrowse.Size = new global::System.Drawing.Size(80, 23);
			this.btnBackupBrowse.TabIndex = 4;
			this.btnBackupBrowse.Text = global::Crosire.Controlcenter.Properties.Resources.button_browse;
			this.btnBackupBrowse.UseVisualStyleBackColor = true;
			this.btnBackupBrowse.Click += new global::System.EventHandler(this.btnBackupBrowse_Click);
			this.textBackupPath.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.textBackupPath.Location = new global::System.Drawing.Point(10, 96);
			this.textBackupPath.Name = "textBackupPath";
			this.textBackupPath.Size = new global::System.Drawing.Size(584, 20);
			this.textBackupPath.TabIndex = 3;
			this.labelPathBackupFolder.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left;
			this.labelPathBackupFolder.AutoSize = true;
			this.labelPathBackupFolder.Location = new global::System.Drawing.Point(8, 80);
			this.labelPathBackupFolder.Name = "labelPathBackupFolder";
			this.labelPathBackupFolder.Size = new global::System.Drawing.Size(113, 13);
			this.labelPathBackupFolder.TabIndex = 2;
			this.labelPathBackupFolder.Text = "Path to Backup folder:";
			this.btnBackup.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.btnBackup.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.btnBackup.Location = new global::System.Drawing.Point(9, 22);
			this.btnBackup.Name = "btnBackup";
			this.btnBackup.Size = new global::System.Drawing.Size(671, 50);
			this.btnBackup.TabIndex = 0;
			this.btnBackup.Text = global::Crosire.Controlcenter.Properties.Resources.button_backup;
			this.btnBackup.UseVisualStyleBackColor = true;
			this.btnBackup.Click += new global::System.EventHandler(this.btnBackup_Click);
			this.container2_1.Controls.Add(this.tab1);
			this.container2_1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.container2_1.Location = new global::System.Drawing.Point(0, 0);
			this.container2_1.Name = "container2_1";
			this.container2_1.Size = new global::System.Drawing.Size(720, 610);
			this.container2_1.TabIndex = 2;
			this.tab1.Appearance = global::System.Windows.Forms.TabAppearance.FlatButtons;
			this.tab1.Controls.Add(this.tab1Page1);
			this.tab1.Controls.Add(this.tab1Page2);
			this.tab1.Controls.Add(this.tab1Page3);
			this.tab1.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.tab1.ItemSize = new global::System.Drawing.Size(100, 21);
			this.tab1.Location = new global::System.Drawing.Point(0, 0);
			this.tab1.Name = "tab1";
			this.tab1.SelectedIndex = 0;
			this.tab1.Size = new global::System.Drawing.Size(720, 610);
			this.tab1.SizeMode = global::System.Windows.Forms.TabSizeMode.Fixed;
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
			this.tab1Page1.Location = new global::System.Drawing.Point(4, 25);
			this.tab1Page1.Name = "tab1Page1";
			this.tab1Page1.Padding = new global::System.Windows.Forms.Padding(3);
			this.tab1Page1.Size = new global::System.Drawing.Size(712, 581);
			this.tab1Page1.TabIndex = 1;
			this.tab1Page1.Text = global::Crosire.Controlcenter.Properties.Resources.tab1_page1;
			this.tab1Page1.UseVisualStyleBackColor = true;
			this.btnSave1.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right;
			this.btnSave1.Location = new global::System.Drawing.Point(449, 545);
			this.btnSave1.Name = "btnSave1";
			this.btnSave1.Size = new global::System.Drawing.Size(250, 23);
			this.btnSave1.TabIndex = 18;
			this.btnSave1.Text = global::Crosire.Controlcenter.Properties.Resources.button_save_config;
			this.btnSave1.UseVisualStyleBackColor = true;
			this.btnSave1.Click += new global::System.EventHandler(this.btnSave1_Click);
			this.textBuild.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.textBuild.Culture = new global::System.Globalization.CultureInfo("");
			this.textBuild.Location = new global::System.Drawing.Point(325, 64);
			this.textBuild.Mask = "000000";
			this.textBuild.Name = "textBuild";
			this.textBuild.Size = new global::System.Drawing.Size(222, 20);
			this.textBuild.TabIndex = 22;
			this.textBuild.ValidatingType = typeof(int);
			this.textPort.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.textPort.Culture = new global::System.Globalization.CultureInfo("");
			this.textPort.Location = new global::System.Drawing.Point(612, 34);
			this.textPort.Mask = "0000";
			this.textPort.Name = "textPort";
			this.textPort.Size = new global::System.Drawing.Size(87, 20);
			this.textPort.TabIndex = 21;
			this.groupTime.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.groupTime.Controls.Add(this.labelTime);
			this.groupTime.Controls.Add(this.checkDaytime);
			this.groupTime.Controls.Add(this.textTimezone);
			this.groupTime.Controls.Add(this.labelTimezone);
			this.groupTime.Controls.Add(this.trackTimezone);
			this.groupTime.Location = new global::System.Drawing.Point(9, 460);
			this.groupTime.Name = "groupTime";
			this.groupTime.Size = new global::System.Drawing.Size(690, 79);
			this.groupTime.TabIndex = 20;
			this.groupTime.TabStop = false;
			this.groupTime.Text = "Time";
			this.labelTime.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.labelTime.AutoSize = true;
			this.labelTime.Location = new global::System.Drawing.Point(646, 53);
			this.labelTime.Name = "labelTime";
			this.labelTime.Size = new global::System.Drawing.Size(34, 13);
			this.labelTime.TabIndex = 20;
			this.labelTime.Text = "00:00";
			this.checkDaytime.AutoSize = true;
			this.checkDaytime.Location = new global::System.Drawing.Point(9, 52);
			this.checkDaytime.Name = "checkDaytime";
			this.checkDaytime.Size = new global::System.Drawing.Size(88, 17);
			this.checkDaytime.TabIndex = 19;
			this.checkDaytime.Text = "Only Daytime";
			this.checkDaytime.UseVisualStyleBackColor = true;
			this.checkDaytime.CheckedChanged += new global::System.EventHandler(this.trackTimezone_Scroll);
			this.textTimezone.AutoSize = true;
			this.textTimezone.Location = new global::System.Drawing.Point(119, 22);
			this.textTimezone.Name = "textTimezone";
			this.textTimezone.Size = new global::System.Drawing.Size(44, 13);
			this.textTimezone.TabIndex = 18;
			this.textTimezone.Text = "UTC +0";
			this.labelTimezone.AutoSize = true;
			this.labelTimezone.Location = new global::System.Drawing.Point(6, 22);
			this.labelTimezone.Name = "labelTimezone";
			this.labelTimezone.Size = new global::System.Drawing.Size(56, 13);
			this.labelTimezone.TabIndex = 17;
			this.labelTimezone.Text = "Timezone:";
			this.trackTimezone.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.trackTimezone.LargeChange = 2;
			this.trackTimezone.Location = new global::System.Drawing.Point(169, 19);
			this.trackTimezone.Maximum = 12;
			this.trackTimezone.Minimum = -12;
			this.trackTimezone.Name = "trackTimezone";
			this.trackTimezone.Size = new global::System.Drawing.Size(512, 45);
			this.trackTimezone.TabIndex = 16;
			this.trackTimezone.Scroll += new global::System.EventHandler(this.trackTimezone_Scroll);
			this.groupTemplate.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.groupTemplate.Controls.Add(this.checkRmod);
			this.groupTemplate.Controls.Add(this.btnDatabase);
			this.groupTemplate.Controls.Add(this.cbxDatabase);
			this.groupTemplate.Controls.Add(this.labelSelectDatabase);
			this.groupTemplate.Controls.Add(this.labelDifficulty);
			this.groupTemplate.Controls.Add(this.cbxDifficulty);
			this.groupTemplate.Controls.Add(this.cbxTemplate);
			this.groupTemplate.Controls.Add(this.labelTemplate);
			this.groupTemplate.Controls.Add(this.checkPersistent);
			this.groupTemplate.Location = new global::System.Drawing.Point(9, 309);
			this.groupTemplate.Name = "groupTemplate";
			this.groupTemplate.Size = new global::System.Drawing.Size(690, 145);
			this.groupTemplate.TabIndex = 16;
			this.groupTemplate.TabStop = false;
			this.groupTemplate.Text = "Mission";
			this.checkRmod.AutoSize = true;
			this.checkRmod.Location = new global::System.Drawing.Point(169, 112);
			this.checkRmod.Name = "checkRmod";
			this.checkRmod.Size = new global::System.Drawing.Size(86, 17);
			this.checkRmod.TabIndex = 31;
			this.checkRmod.Text = global::Crosire.Controlcenter.Properties.Resources.check_rmod;
			this.checkRmod.UseVisualStyleBackColor = true;
			this.btnDatabase.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.btnDatabase.Location = new global::System.Drawing.Point(545, 77);
			this.btnDatabase.Name = "btnDatabase";
			this.btnDatabase.Size = new global::System.Drawing.Size(137, 23);
			this.btnDatabase.TabIndex = 21;
			this.btnDatabase.Text = global::Crosire.Controlcenter.Properties.Resources.button_add_database;
			this.btnDatabase.UseVisualStyleBackColor = true;
			this.btnDatabase.Click += new global::System.EventHandler(this.btnDatabase_Click);
			this.cbxDatabase.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.cbxDatabase.FormattingEnabled = true;
			this.cbxDatabase.Location = new global::System.Drawing.Point(169, 79);
			this.cbxDatabase.MaxDropDownItems = 6;
			this.cbxDatabase.Name = "cbxDatabase";
			this.cbxDatabase.Size = new global::System.Drawing.Size(369, 21);
			this.cbxDatabase.TabIndex = 16;
			this.cbxDatabase.TextChanged += new global::System.EventHandler(this.cbxDatabase_TextChanged);
			this.labelSelectDatabase.AutoSize = true;
			this.labelSelectDatabase.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.labelSelectDatabase.Location = new global::System.Drawing.Point(6, 82);
			this.labelSelectDatabase.Name = "labelSelectDatabase";
			this.labelSelectDatabase.Size = new global::System.Drawing.Size(85, 13);
			this.labelSelectDatabase.TabIndex = 15;
			this.labelSelectDatabase.Text = "Database name:";
			this.labelDifficulty.AutoSize = true;
			this.labelDifficulty.Location = new global::System.Drawing.Point(6, 22);
			this.labelDifficulty.Name = "labelDifficulty";
			this.labelDifficulty.Size = new global::System.Drawing.Size(50, 13);
			this.labelDifficulty.TabIndex = 10;
			this.labelDifficulty.Text = "Difficulty:";
			this.cbxDifficulty.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.cbxDifficulty.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxDifficulty.FormattingEnabled = true;
			this.cbxDifficulty.Items.AddRange(new object[] { "recruit", "regular", "veteran", "mercenary" });
			this.cbxDifficulty.Location = new global::System.Drawing.Point(169, 19);
			this.cbxDifficulty.Name = "cbxDifficulty";
			this.cbxDifficulty.Size = new global::System.Drawing.Size(512, 21);
			this.cbxDifficulty.TabIndex = 10;
			this.cbxTemplate.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.cbxTemplate.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxTemplate.FormattingEnabled = true;
			this.cbxTemplate.Items.AddRange(new object[] { "dayz.chernarus", "dayz.lingor", "dayz.utes", "dayz.takistan", "dayz.panthera2", "dayz.fallujah", "dayz.zargabad", "dayz.namalsk", "dayz.mbg_celle2", "dayz.tavi" });
			this.cbxTemplate.Location = new global::System.Drawing.Point(169, 49);
			this.cbxTemplate.Name = "cbxTemplate";
			this.cbxTemplate.Size = new global::System.Drawing.Size(512, 21);
			this.cbxTemplate.TabIndex = 14;
			this.cbxTemplate.DropDownClosed += new global::System.EventHandler(this.cbxTemplate_DropDownClosed);
			this.labelTemplate.AutoSize = true;
			this.labelTemplate.Location = new global::System.Drawing.Point(6, 52);
			this.labelTemplate.Name = "labelTemplate";
			this.labelTemplate.Size = new global::System.Drawing.Size(92, 13);
			this.labelTemplate.TabIndex = 13;
			this.labelTemplate.Text = "Mission Template:";
			this.checkPersistent.AutoSize = true;
			this.checkPersistent.Location = new global::System.Drawing.Point(9, 112);
			this.checkPersistent.Name = "checkPersistent";
			this.checkPersistent.Size = new global::System.Drawing.Size(121, 17);
			this.checkPersistent.TabIndex = 11;
			this.checkPersistent.Text = global::Crosire.Controlcenter.Properties.Resources.check_persistent;
			this.checkPersistent.UseVisualStyleBackColor = true;
			this.groupVon.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.groupVon.Controls.Add(this.numVonQuality);
			this.groupVon.Controls.Add(this.labelCodecQuality);
			this.groupVon.Controls.Add(this.checkVon);
			this.groupVon.Location = new global::System.Drawing.Point(9, 248);
			this.groupVon.Name = "groupVon";
			this.groupVon.Size = new global::System.Drawing.Size(690, 55);
			this.groupVon.TabIndex = 6;
			this.groupVon.TabStop = false;
			this.groupVon.Text = "Voice Over Net";
			this.numVonQuality.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.numVonQuality.Location = new global::System.Drawing.Point(169, 21);
			global::System.Windows.Forms.NumericUpDown numericUpDown4 = this.numVonQuality;
			array = new int[4];
			array[0] = 10;
			numericUpDown4.Maximum = new decimal(array);
			this.numVonQuality.Name = "numVonQuality";
			this.numVonQuality.Size = new global::System.Drawing.Size(512, 20);
			this.numVonQuality.TabIndex = 1;
			global::System.Windows.Forms.NumericUpDown numericUpDown5 = this.numVonQuality;
			array = new int[4];
			array[0] = 3;
			numericUpDown5.Value = new decimal(array);
			this.labelCodecQuality.ImageAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.labelCodecQuality.Location = new global::System.Drawing.Point(80, 22);
			this.labelCodecQuality.Name = "labelCodecQuality";
			this.labelCodecQuality.Size = new global::System.Drawing.Size(83, 17);
			this.labelCodecQuality.TabIndex = 1;
			this.labelCodecQuality.Text = "Codec Quality:";
			this.labelCodecQuality.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.checkVon.AutoSize = true;
			this.checkVon.CheckAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.checkVon.Checked = true;
			this.checkVon.CheckState = global::System.Windows.Forms.CheckState.Checked;
			this.checkVon.Location = new global::System.Drawing.Point(6, 22);
			this.checkVon.Name = "checkVon";
			this.checkVon.Size = new global::System.Drawing.Size(65, 17);
			this.checkVon.TabIndex = 0;
			this.checkVon.Text = global::Crosire.Controlcenter.Properties.Resources.check_enabled;
			this.checkVon.UseVisualStyleBackColor = true;
			this.labelRequiredBuild.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.labelRequiredBuild.Location = new global::System.Drawing.Point(205, 67);
			this.labelRequiredBuild.Name = "labelRequiredBuild";
			this.labelRequiredBuild.Size = new global::System.Drawing.Size(114, 15);
			this.labelRequiredBuild.TabIndex = 4;
			this.labelRequiredBuild.Text = "Required Build:";
			this.labelRequiredBuild.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.groupMessage.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.groupMessage.Controls.Add(this.textWelcomeMessage);
			this.groupMessage.Controls.Add(this.labelWelcomeMessage);
			this.groupMessage.Controls.Add(this.labelNoticeMessage);
			this.groupMessage.Controls.Add(this.numMessageInterval);
			this.groupMessage.Controls.Add(this.labelTimeBetweenMessage);
			this.groupMessage.Controls.Add(this.textMessage);
			this.groupMessage.Location = new global::System.Drawing.Point(9, 100);
			this.groupMessage.Name = "groupMessage";
			this.groupMessage.Size = new global::System.Drawing.Size(690, 142);
			this.groupMessage.TabIndex = 5;
			this.groupMessage.TabStop = false;
			this.groupMessage.Text = "Message";
			this.textWelcomeMessage.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.textWelcomeMessage.Location = new global::System.Drawing.Point(103, 108);
			this.textWelcomeMessage.Name = "textWelcomeMessage";
			this.textWelcomeMessage.Size = new global::System.Drawing.Size(579, 20);
			this.textWelcomeMessage.TabIndex = 14;
			this.labelWelcomeMessage.AutoSize = true;
			this.labelWelcomeMessage.Location = new global::System.Drawing.Point(7, 111);
			this.labelWelcomeMessage.Name = "labelWelcomeMessage";
			this.labelWelcomeMessage.Size = new global::System.Drawing.Size(75, 13);
			this.labelWelcomeMessage.TabIndex = 13;
			this.labelWelcomeMessage.Text = "Join Message:";
			this.labelNoticeMessage.AutoSize = true;
			this.labelNoticeMessage.Location = new global::System.Drawing.Point(7, 81);
			this.labelNoticeMessage.Name = "labelNoticeMessage";
			this.labelNoticeMessage.Size = new global::System.Drawing.Size(323, 13);
			this.labelNoticeMessage.TabIndex = 2;
			this.labelNoticeMessage.Text = "Note: Use this pattern for your text: \"Message 1\",\"Message 2\",\"...\"";
			this.numMessageInterval.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.numMessageInterval.Location = new global::System.Drawing.Point(605, 79);
			this.numMessageInterval.Name = "numMessageInterval";
			this.numMessageInterval.Size = new global::System.Drawing.Size(77, 20);
			this.numMessageInterval.TabIndex = 1;
			this.labelTimeBetweenMessage.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.labelTimeBetweenMessage.Location = new global::System.Drawing.Point(345, 81);
			this.labelTimeBetweenMessage.Name = "labelTimeBetweenMessage";
			this.labelTimeBetweenMessage.Size = new global::System.Drawing.Size(254, 13);
			this.labelTimeBetweenMessage.TabIndex = 1;
			this.labelTimeBetweenMessage.Text = "Seconds between messages:";
			this.labelTimeBetweenMessage.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.textMessage.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.textMessage.Location = new global::System.Drawing.Point(10, 22);
			this.textMessage.Name = "textMessage";
			this.textMessage.ScrollBars = global::System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
			this.textMessage.Size = new global::System.Drawing.Size(672, 51);
			this.textMessage.TabIndex = 0;
			this.textMessage.Text = "";
			this.numMaxPlayers.Location = new global::System.Drawing.Point(112, 65);
			this.numMaxPlayers.Name = "numMaxPlayers";
			this.numMaxPlayers.Size = new global::System.Drawing.Size(87, 20);
			this.numMaxPlayers.TabIndex = 3;
			this.labelMaxPlayers.AutoSize = true;
			this.labelMaxPlayers.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.labelMaxPlayers.Location = new global::System.Drawing.Point(6, 67);
			this.labelMaxPlayers.Name = "labelMaxPlayers";
			this.labelMaxPlayers.Size = new global::System.Drawing.Size(70, 13);
			this.labelMaxPlayers.TabIndex = 3;
			this.labelMaxPlayers.Text = "Max. Players:";
			this.cbxReportingIp.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.cbxReportingIp.FormattingEnabled = true;
			this.cbxReportingIp.Items.AddRange(new object[] { "master.gamespy.com", "arma2pc.master.gamespy.com", "arma2oapc.master.gamespy.com", "127.0.0.1" });
			this.cbxReportingIp.Location = new global::System.Drawing.Point(112, 34);
			this.cbxReportingIp.MaxDropDownItems = 5;
			this.cbxReportingIp.Name = "cbxReportingIp";
			this.cbxReportingIp.Size = new global::System.Drawing.Size(435, 21);
			this.cbxReportingIp.TabIndex = 1;
			this.labelPort.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.labelPort.AutoSize = true;
			this.labelPort.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.labelPort.Location = new global::System.Drawing.Point(577, 37);
			this.labelPort.Name = "labelPort";
			this.labelPort.Size = new global::System.Drawing.Size(29, 13);
			this.labelPort.TabIndex = 2;
			this.labelPort.Text = "Port:";
			this.labelPort.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.labelReportingIp.AutoSize = true;
			this.labelReportingIp.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.labelReportingIp.Location = new global::System.Drawing.Point(6, 37);
			this.labelReportingIp.Name = "labelReportingIp";
			this.labelReportingIp.Size = new global::System.Drawing.Size(69, 13);
			this.labelReportingIp.TabIndex = 1;
			this.labelReportingIp.Text = "Reporting IP:";
			this.textHostname.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.textHostname.Location = new global::System.Drawing.Point(112, 4);
			this.textHostname.Name = "textHostname";
			this.textHostname.Size = new global::System.Drawing.Size(587, 20);
			this.textHostname.TabIndex = 0;
			this.labelServerName.AutoSize = true;
			this.labelServerName.Location = new global::System.Drawing.Point(6, 7);
			this.labelServerName.Name = "labelServerName";
			this.labelServerName.Size = new global::System.Drawing.Size(70, 13);
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
			this.tab1Page2.Location = new global::System.Drawing.Point(4, 25);
			this.tab1Page2.Name = "tab1Page2";
			this.tab1Page2.Size = new global::System.Drawing.Size(712, 581);
			this.tab1Page2.TabIndex = 2;
			this.tab1Page2.Text = global::Crosire.Controlcenter.Properties.Resources.tab1_page2;
			this.tab1Page2.UseVisualStyleBackColor = true;
			this.groupWhitelist.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.groupWhitelist.Controls.Add(this.textWhitelistMessage);
			this.groupWhitelist.Controls.Add(this.labelWhitelistMessage);
			this.groupWhitelist.Controls.Add(this.checkWhitelist);
			this.groupWhitelist.Location = new global::System.Drawing.Point(9, 161);
			this.groupWhitelist.Name = "groupWhitelist";
			this.groupWhitelist.Size = new global::System.Drawing.Size(690, 55);
			this.groupWhitelist.TabIndex = 5;
			this.groupWhitelist.TabStop = false;
			this.groupWhitelist.Text = "Whitelist";
			this.textWhitelistMessage.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.textWhitelistMessage.Location = new global::System.Drawing.Point(165, 20);
			this.textWhitelistMessage.Name = "textWhitelistMessage";
			this.textWhitelistMessage.Size = new global::System.Drawing.Size(512, 20);
			this.textWhitelistMessage.TabIndex = 12;
			this.labelWhitelistMessage.Location = new global::System.Drawing.Point(80, 23);
			this.labelWhitelistMessage.Name = "labelWhitelistMessage";
			this.labelWhitelistMessage.Size = new global::System.Drawing.Size(78, 15);
			this.labelWhitelistMessage.TabIndex = 2;
			this.labelWhitelistMessage.Text = "Message:";
			this.labelWhitelistMessage.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.checkWhitelist.AutoSize = true;
			this.checkWhitelist.CheckAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.checkWhitelist.Location = new global::System.Drawing.Point(6, 22);
			this.checkWhitelist.Name = "checkWhitelist";
			this.checkWhitelist.Size = new global::System.Drawing.Size(65, 17);
			this.checkWhitelist.TabIndex = 0;
			this.checkWhitelist.Text = "Enabled";
			this.checkWhitelist.UseVisualStyleBackColor = true;
			this.checkWhitelist.CheckedChanged += new global::System.EventHandler(this.checkWhitelist_CheckedChanged);
			this.btnRandomPass.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.btnRandomPass.Location = new global::System.Drawing.Point(178, 545);
			this.btnRandomPass.Name = "btnRandomPass";
			this.btnRandomPass.Size = new global::System.Drawing.Size(265, 23);
			this.btnRandomPass.TabIndex = 20;
			this.btnRandomPass.Text = global::Crosire.Controlcenter.Properties.Resources.button_random;
			this.btnRandomPass.UseVisualStyleBackColor = true;
			this.btnRandomPass.Click += new global::System.EventHandler(this.btnRandomPass_Click);
			this.btnSave2.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right;
			this.btnSave2.Location = new global::System.Drawing.Point(449, 545);
			this.btnSave2.Name = "btnSave2";
			this.btnSave2.Size = new global::System.Drawing.Size(250, 23);
			this.btnSave2.TabIndex = 14;
			this.btnSave2.Text = global::Crosire.Controlcenter.Properties.Resources.button_save_config;
			this.btnSave2.UseVisualStyleBackColor = true;
			this.btnSave2.Click += new global::System.EventHandler(this.btnSave2_Click);
			this.groupSignatures.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.groupSignatures.Controls.Add(this.numSecureId);
			this.groupSignatures.Controls.Add(this.labelRequireSecureId);
			this.groupSignatures.Controls.Add(this.numVerifySignatures);
			this.groupSignatures.Controls.Add(this.labelVerifySignatures);
			this.groupSignatures.Location = new global::System.Drawing.Point(9, 222);
			this.groupSignatures.Name = "groupSignatures";
			this.groupSignatures.Size = new global::System.Drawing.Size(690, 81);
			this.groupSignatures.TabIndex = 4;
			this.groupSignatures.TabStop = false;
			this.groupSignatures.Text = "Signatures";
			this.numSecureId.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.numSecureId.Location = new global::System.Drawing.Point(104, 50);
			global::System.Windows.Forms.NumericUpDown numericUpDown6 = this.numSecureId;
			array = new int[4];
			array[0] = 2;
			numericUpDown6.Maximum = new decimal(array);
			this.numSecureId.Name = "numSecureId";
			this.numSecureId.Size = new global::System.Drawing.Size(573, 20);
			this.numSecureId.TabIndex = 3;
			global::System.Windows.Forms.NumericUpDown numericUpDown7 = this.numSecureId;
			array = new int[4];
			array[0] = 1;
			numericUpDown7.Value = new decimal(array);
			this.labelRequireSecureId.AutoSize = true;
			this.labelRequireSecureId.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.labelRequireSecureId.Location = new global::System.Drawing.Point(7, 52);
			this.labelRequireSecureId.Name = "labelRequireSecureId";
			this.labelRequireSecureId.Size = new global::System.Drawing.Size(95, 13);
			this.labelRequireSecureId.TabIndex = 2;
			this.labelRequireSecureId.Text = "Require SecureID:";
			this.labelRequireSecureId.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.numVerifySignatures.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.numVerifySignatures.Location = new global::System.Drawing.Point(104, 20);
			global::System.Windows.Forms.NumericUpDown numericUpDown8 = this.numVerifySignatures;
			array = new int[4];
			array[0] = 2;
			numericUpDown8.Maximum = new decimal(array);
			this.numVerifySignatures.Name = "numVerifySignatures";
			this.numVerifySignatures.Size = new global::System.Drawing.Size(573, 20);
			this.numVerifySignatures.TabIndex = 1;
			global::System.Windows.Forms.NumericUpDown numericUpDown9 = this.numVerifySignatures;
			array = new int[4];
			array[0] = 2;
			numericUpDown9.Value = new decimal(array);
			this.labelVerifySignatures.AutoSize = true;
			this.labelVerifySignatures.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.labelVerifySignatures.Location = new global::System.Drawing.Point(7, 22);
			this.labelVerifySignatures.Name = "labelVerifySignatures";
			this.labelVerifySignatures.Size = new global::System.Drawing.Size(89, 13);
			this.labelVerifySignatures.TabIndex = 0;
			this.labelVerifySignatures.Text = "Verify Signatures:";
			this.labelVerifySignatures.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.groupScripting.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
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
			this.groupScripting.Location = new global::System.Drawing.Point(9, 309);
			this.groupScripting.Name = "groupScripting";
			this.groupScripting.Size = new global::System.Drawing.Size(690, 230);
			this.groupScripting.TabIndex = 5;
			this.groupScripting.TabStop = false;
			this.groupScripting.Text = "Scripting";
			this.checkDuplicate.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.checkDuplicate.AutoSize = true;
			this.checkDuplicate.Location = new global::System.Drawing.Point(582, 21);
			this.checkDuplicate.Name = "checkDuplicate";
			this.checkDuplicate.Size = new global::System.Drawing.Size(95, 17);
			this.checkDuplicate.TabIndex = 33;
			this.checkDuplicate.Text = global::Crosire.Controlcenter.Properties.Resources.check_duplicate;
			this.checkDuplicate.UseVisualStyleBackColor = true;
			this.textRegularCheck.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.textRegularCheck.Location = new global::System.Drawing.Point(165, 199);
			this.textRegularCheck.Name = "textRegularCheck";
			this.textRegularCheck.Size = new global::System.Drawing.Size(512, 20);
			this.textRegularCheck.TabIndex = 11;
			this.labelRegularCheck.AutoSize = true;
			this.labelRegularCheck.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.labelRegularCheck.Location = new global::System.Drawing.Point(7, 202);
			this.labelRegularCheck.Name = "labelRegularCheck";
			this.labelRegularCheck.Size = new global::System.Drawing.Size(87, 13);
			this.labelRegularCheck.TabIndex = 10;
			this.labelRegularCheck.Text = "Regular Check =";
			this.labelRegularCheck.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.textOnUnsigned.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.textOnUnsigned.Location = new global::System.Drawing.Point(165, 169);
			this.textOnUnsigned.Name = "textOnUnsigned";
			this.textOnUnsigned.Size = new global::System.Drawing.Size(512, 20);
			this.textOnUnsigned.TabIndex = 5;
			this.textOnDifferent.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.textOnDifferent.Location = new global::System.Drawing.Point(165, 139);
			this.textOnDifferent.Name = "textOnDifferent";
			this.textOnDifferent.Size = new global::System.Drawing.Size(512, 20);
			this.textOnDifferent.TabIndex = 4;
			this.textOnHacked.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.textOnHacked.Location = new global::System.Drawing.Point(165, 109);
			this.textOnHacked.Name = "textOnHacked";
			this.textOnHacked.Size = new global::System.Drawing.Size(512, 20);
			this.textOnHacked.TabIndex = 3;
			this.textOnUserDisconnected.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.textOnUserDisconnected.Location = new global::System.Drawing.Point(165, 79);
			this.textOnUserDisconnected.Name = "textOnUserDisconnected";
			this.textOnUserDisconnected.Size = new global::System.Drawing.Size(512, 20);
			this.textOnUserDisconnected.TabIndex = 2;
			this.textOnUserConnected.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.textOnUserConnected.Location = new global::System.Drawing.Point(165, 49);
			this.textOnUserConnected.Name = "textOnUserConnected";
			this.textOnUserConnected.Size = new global::System.Drawing.Size(512, 20);
			this.textOnUserConnected.TabIndex = 1;
			this.textDoubleId.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.textDoubleId.Location = new global::System.Drawing.Point(165, 19);
			this.textDoubleId.Name = "textDoubleId";
			this.textDoubleId.Size = new global::System.Drawing.Size(398, 20);
			this.textDoubleId.TabIndex = 0;
			this.labelOnUnsignedData.AutoSize = true;
			this.labelOnUnsignedData.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.labelOnUnsignedData.Location = new global::System.Drawing.Point(7, 172);
			this.labelOnUnsignedData.Name = "labelOnUnsignedData";
			this.labelOnUnsignedData.Size = new global::System.Drawing.Size(96, 13);
			this.labelOnUnsignedData.TabIndex = 5;
			this.labelOnUnsignedData.Text = "onUnsignedData =";
			this.labelOnUnsignedData.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.labelOnDifferentData.AutoSize = true;
			this.labelOnDifferentData.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.labelOnDifferentData.Location = new global::System.Drawing.Point(7, 142);
			this.labelOnDifferentData.Name = "labelOnDifferentData";
			this.labelOnDifferentData.Size = new global::System.Drawing.Size(91, 13);
			this.labelOnDifferentData.TabIndex = 4;
			this.labelOnDifferentData.Text = "onDifferentData =";
			this.labelOnDifferentData.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.labelOnHackedData.AutoSize = true;
			this.labelOnHackedData.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.labelOnHackedData.Location = new global::System.Drawing.Point(7, 112);
			this.labelOnHackedData.Name = "labelOnHackedData";
			this.labelOnHackedData.Size = new global::System.Drawing.Size(89, 13);
			this.labelOnHackedData.TabIndex = 3;
			this.labelOnHackedData.Text = "onHackedData =";
			this.labelOnHackedData.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.labelOnUserDisconnected.AutoSize = true;
			this.labelOnUserDisconnected.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.labelOnUserDisconnected.Location = new global::System.Drawing.Point(7, 82);
			this.labelOnUserDisconnected.Name = "labelOnUserDisconnected";
			this.labelOnUserDisconnected.Size = new global::System.Drawing.Size(116, 13);
			this.labelOnUserDisconnected.TabIndex = 2;
			this.labelOnUserDisconnected.Text = "onUserDisconnected =";
			this.labelOnUserDisconnected.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.labelOnUserConnected.AutoSize = true;
			this.labelOnUserConnected.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.labelOnUserConnected.Location = new global::System.Drawing.Point(7, 52);
			this.labelOnUserConnected.Name = "labelOnUserConnected";
			this.labelOnUserConnected.Size = new global::System.Drawing.Size(102, 13);
			this.labelOnUserConnected.TabIndex = 1;
			this.labelOnUserConnected.Text = "onUserConnected =";
			this.labelOnUserConnected.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.labelDoubleId.AutoSize = true;
			this.labelDoubleId.Location = new global::System.Drawing.Point(7, 22);
			this.labelDoubleId.Name = "labelDoubleId";
			this.labelDoubleId.Size = new global::System.Drawing.Size(101, 13);
			this.labelDoubleId.TabIndex = 0;
			this.labelDoubleId.Text = "doubleIdDetected =";
			this.labelDoubleId.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.groupBattleye.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.groupBattleye.Controls.Add(this.numMaxPing);
			this.groupBattleye.Controls.Add(this.labelMaxPing);
			this.groupBattleye.Controls.Add(this.checkBattleye);
			this.groupBattleye.Location = new global::System.Drawing.Point(9, 100);
			this.groupBattleye.Name = "groupBattleye";
			this.groupBattleye.Size = new global::System.Drawing.Size(690, 55);
			this.groupBattleye.TabIndex = 3;
			this.groupBattleye.TabStop = false;
			this.groupBattleye.Text = "BattlEye";
			this.numMaxPing.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			global::System.Windows.Forms.NumericUpDown numericUpDown10 = this.numMaxPing;
			array = new int[4];
			array[0] = 50;
			numericUpDown10.Increment = new decimal(array);
			this.numMaxPing.Location = new global::System.Drawing.Point(165, 21);
			global::System.Windows.Forms.NumericUpDown numericUpDown11 = this.numMaxPing;
			array = new int[4];
			array[0] = 999;
			numericUpDown11.Maximum = new decimal(array);
			this.numMaxPing.Name = "numMaxPing";
			this.numMaxPing.Size = new global::System.Drawing.Size(512, 20);
			this.numMaxPing.TabIndex = 2;
			global::System.Windows.Forms.NumericUpDown numericUpDown12 = this.numMaxPing;
			array = new int[4];
			array[0] = 100;
			numericUpDown12.Value = new decimal(array);
			this.labelMaxPing.Location = new global::System.Drawing.Point(80, 23);
			this.labelMaxPing.Name = "labelMaxPing";
			this.labelMaxPing.Size = new global::System.Drawing.Size(78, 15);
			this.labelMaxPing.TabIndex = 1;
			this.labelMaxPing.Text = "Max. Ping:";
			this.labelMaxPing.TextAlign = global::System.Drawing.ContentAlignment.TopRight;
			this.checkBattleye.AutoSize = true;
			this.checkBattleye.CheckAlign = global::System.Drawing.ContentAlignment.MiddleRight;
			this.checkBattleye.Location = new global::System.Drawing.Point(6, 22);
			this.checkBattleye.Name = "checkBattleye";
			this.checkBattleye.Size = new global::System.Drawing.Size(65, 17);
			this.checkBattleye.TabIndex = 0;
			this.checkBattleye.Text = global::Crosire.Controlcenter.Properties.Resources.check_enabled;
			this.checkBattleye.UseVisualStyleBackColor = true;
			this.checkBattleye.CheckedChanged += new global::System.EventHandler(this.checkBattleye_CheckedChanged);
			this.textPasswordRcon.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.textPasswordRcon.Location = new global::System.Drawing.Point(112, 64);
			this.textPasswordRcon.Name = "textPasswordRcon";
			this.textPasswordRcon.Size = new global::System.Drawing.Size(587, 20);
			this.textPasswordRcon.TabIndex = 2;
			this.labelRconPassword.AutoSize = true;
			this.labelRconPassword.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.labelRconPassword.Location = new global::System.Drawing.Point(6, 67);
			this.labelRconPassword.Name = "labelRconPassword";
			this.labelRconPassword.Size = new global::System.Drawing.Size(98, 13);
			this.labelRconPassword.TabIndex = 2;
			this.labelRconPassword.Text = "BattlEye Password:";
			this.textPasswordAdmin.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.textPasswordAdmin.Location = new global::System.Drawing.Point(112, 34);
			this.textPasswordAdmin.Name = "textPasswordAdmin";
			this.textPasswordAdmin.Size = new global::System.Drawing.Size(587, 20);
			this.textPasswordAdmin.TabIndex = 1;
			this.labelAdminPassword.AutoSize = true;
			this.labelAdminPassword.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.labelAdminPassword.Location = new global::System.Drawing.Point(6, 37);
			this.labelAdminPassword.Name = "labelAdminPassword";
			this.labelAdminPassword.Size = new global::System.Drawing.Size(88, 13);
			this.labelAdminPassword.TabIndex = 1;
			this.labelAdminPassword.Text = "Admin Password:";
			this.textPasswordServer.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.textPasswordServer.Location = new global::System.Drawing.Point(112, 4);
			this.textPasswordServer.Name = "textPasswordServer";
			this.textPasswordServer.Size = new global::System.Drawing.Size(587, 20);
			this.textPasswordServer.TabIndex = 0;
			this.labelPassword.AutoSize = true;
			this.labelPassword.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.labelPassword.Location = new global::System.Drawing.Point(6, 7);
			this.labelPassword.Name = "labelPassword";
			this.labelPassword.Size = new global::System.Drawing.Size(56, 13);
			this.labelPassword.TabIndex = 0;
			this.labelPassword.Text = "Password:";
			this.tab1Page3.Controls.Add(this.groupAdditional);
			this.tab1Page3.Controls.Add(this.btnSave3);
			this.tab1Page3.Controls.Add(this.groupNetwork);
			this.tab1Page3.Location = new global::System.Drawing.Point(4, 25);
			this.tab1Page3.Name = "tab1Page3";
			this.tab1Page3.Size = new global::System.Drawing.Size(712, 581);
			this.tab1Page3.TabIndex = 4;
			this.tab1Page3.Text = global::Crosire.Controlcenter.Properties.Resources.tab1_page3;
			this.tab1Page3.UseVisualStyleBackColor = true;
			this.groupAdditional.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.groupAdditional.Controls.Add(this.cbxLoadoutBackpack);
			this.groupAdditional.Controls.Add(this.labelLoadoutBackpack);
			this.groupAdditional.Controls.Add(this.textModlist);
			this.groupAdditional.Controls.Add(this.labelModlist);
			this.groupAdditional.Controls.Add(this.cbxLoadout);
			this.groupAdditional.Controls.Add(this.labelLoadout);
			this.groupAdditional.Controls.Add(this.numMaxCustomsize);
			this.groupAdditional.Controls.Add(this.labelMaxCustomSize);
			this.groupAdditional.Controls.Add(this.labelMaxCustomSizeUnit);
			this.groupAdditional.Location = new global::System.Drawing.Point(9, 246);
			this.groupAdditional.Name = "groupAdditional";
			this.groupAdditional.Size = new global::System.Drawing.Size(690, 141);
			this.groupAdditional.TabIndex = 2;
			this.groupAdditional.TabStop = false;
			this.groupAdditional.Text = "Additional Options";
			this.cbxLoadoutBackpack.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.cbxLoadoutBackpack.FormattingEnabled = true;
			this.cbxLoadoutBackpack.Items.AddRange(new object[] { "[\"DZ_Patrol_Pack_EP1\",[[],[]],[[],[]]]", "[\"DZ_Assault_Pack_EP1\",[[],[]],[[],[]]]", "[\"DZ_CivilBackpack_EP1\",[[],[]],[[],[]]]", "[\"DZ_ALICE_Pack_EP1\",[[],[]],[[],[]]]", "[\"DZ_Backpack_EP1\",[[],[]],[[],[]]]" });
			this.cbxLoadoutBackpack.Location = new global::System.Drawing.Point(165, 79);
			this.cbxLoadoutBackpack.Name = "cbxLoadoutBackpack";
			this.cbxLoadoutBackpack.Size = new global::System.Drawing.Size(464, 21);
			this.cbxLoadoutBackpack.TabIndex = 39;
			this.labelLoadoutBackpack.AutoSize = true;
			this.labelLoadoutBackpack.Location = new global::System.Drawing.Point(6, 82);
			this.labelLoadoutBackpack.Name = "labelLoadoutBackpack";
			this.labelLoadoutBackpack.Size = new global::System.Drawing.Size(117, 13);
			this.labelLoadoutBackpack.TabIndex = 38;
			this.labelLoadoutBackpack.Text = "Global backup loadout:";
			this.textModlist.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.textModlist.Location = new global::System.Drawing.Point(165, 109);
			this.textModlist.Name = "textModlist";
			this.textModlist.Size = new global::System.Drawing.Size(464, 20);
			this.textModlist.TabIndex = 29;
			this.labelModlist.AutoSize = true;
			this.labelModlist.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.labelModlist.Location = new global::System.Drawing.Point(6, 112);
			this.labelModlist.Name = "labelModlist";
			this.labelModlist.Size = new global::System.Drawing.Size(43, 13);
			this.labelModlist.TabIndex = 28;
			this.labelModlist.Text = "Modlist:";
			this.cbxLoadout.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.cbxLoadout.FormattingEnabled = true;
			this.cbxLoadout.Items.AddRange(new object[]
			{
				"[]",
				"[[\"M9SD\",\"FoodCanBakedBeans\",\"ItemMap\"],[\"15Rnd_9x19_M9SD\",\"ItemBandage\",\"15Rnd_9x19_M9SD\"]]",
				"[[\"M9SD\",\"FoodCanBakedBeans\",\"ItemMap\",\"LeeEnfield\"],[\"15Rnd_9x19_M9SD\",\"ItemBandage\",\"15Rnd_9x19_M9SD\",\"10x_303\",\"10x_303\",\"10x_303\",\"10x_303\"]]",
				"[[\"M9SD\",\"FoodCanBakedBeans\",\"ItemMap\",\"Mk_48_DZ\"],[\"15Rnd_9x19_M9SD\",\"ItemBandage\",\"15Rnd_9x19_M9SD\",\"100Rnd_762x51_M240\",\"100Rnd_762x51_M240\"]]",
				"[[\"ItemMap\",\"ItemCompass\",\"ItemMatchbox\",\"FoodCanBakedBeans\",\"ItemKnife\",\"FoodCanBakedBeans\"],[\"ItemTent\",\"ItemBandage\",\"ItemBandage\"]]",
				componentResourceManager.GetString("cbxLoadout.Items")
			});
			this.cbxLoadout.Location = new global::System.Drawing.Point(165, 49);
			this.cbxLoadout.Name = "cbxLoadout";
			this.cbxLoadout.Size = new global::System.Drawing.Size(464, 21);
			this.cbxLoadout.TabIndex = 37;
			this.labelLoadout.AutoSize = true;
			this.labelLoadout.Location = new global::System.Drawing.Point(6, 52);
			this.labelLoadout.Name = "labelLoadout";
			this.labelLoadout.Size = new global::System.Drawing.Size(78, 13);
			this.labelLoadout.TabIndex = 36;
			this.labelLoadout.Text = "Global loadout:";
			this.numMaxCustomsize.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.numMaxCustomsize.Location = new global::System.Drawing.Point(165, 20);
			global::System.Windows.Forms.NumericUpDown numericUpDown13 = this.numMaxCustomsize;
			array = new int[4];
			array[0] = 1410065407;
			array[1] = 2;
			numericUpDown13.Maximum = new decimal(array);
			this.numMaxCustomsize.Name = "numMaxCustomsize";
			this.numMaxCustomsize.Size = new global::System.Drawing.Size(464, 20);
			this.numMaxCustomsize.TabIndex = 0;
			this.labelMaxCustomSize.AutoSize = true;
			this.labelMaxCustomSize.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.labelMaxCustomSize.Location = new global::System.Drawing.Point(6, 22);
			this.labelMaxCustomSize.Name = "labelMaxCustomSize";
			this.labelMaxCustomSize.Size = new global::System.Drawing.Size(94, 13);
			this.labelMaxCustomSize.TabIndex = 0;
			this.labelMaxCustomSize.Text = "Max. Custom Size:";
			this.labelMaxCustomSizeUnit.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.labelMaxCustomSizeUnit.AutoSize = true;
			this.labelMaxCustomSizeUnit.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.labelMaxCustomSizeUnit.Location = new global::System.Drawing.Point(635, 22);
			this.labelMaxCustomSizeUnit.Name = "labelMaxCustomSizeUnit";
			this.labelMaxCustomSizeUnit.Size = new global::System.Drawing.Size(20, 13);
			this.labelMaxCustomSizeUnit.TabIndex = 25;
			this.labelMaxCustomSizeUnit.Text = "kB";
			this.btnSave3.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right;
			this.btnSave3.Location = new global::System.Drawing.Point(449, 545);
			this.btnSave3.Name = "btnSave3";
			this.btnSave3.Size = new global::System.Drawing.Size(250, 23);
			this.btnSave3.TabIndex = 9;
			this.btnSave3.Text = global::Crosire.Controlcenter.Properties.Resources.button_save_config;
			this.btnSave3.UseVisualStyleBackColor = true;
			this.btnSave3.Click += new global::System.EventHandler(this.btnSave3_Click);
			this.groupNetwork.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
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
			this.groupNetwork.Location = new global::System.Drawing.Point(9, 7);
			this.groupNetwork.Name = "groupNetwork";
			this.groupNetwork.Size = new global::System.Drawing.Size(690, 233);
			this.groupNetwork.TabIndex = 1;
			this.groupNetwork.TabStop = false;
			this.groupNetwork.Text = "Network Tuning";
			this.numMaxBandwidth.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			global::System.Windows.Forms.NumericUpDown numericUpDown14 = this.numMaxBandwidth;
			array = new int[4];
			array[0] = 1000;
			numericUpDown14.Increment = new decimal(array);
			this.numMaxBandwidth.Location = new global::System.Drawing.Point(165, 50);
			global::System.Windows.Forms.NumericUpDown numericUpDown15 = this.numMaxBandwidth;
			array = new int[4];
			array[0] = 1410065407;
			array[1] = 2;
			numericUpDown15.Maximum = new decimal(array);
			this.numMaxBandwidth.Name = "numMaxBandwidth";
			this.numMaxBandwidth.Size = new global::System.Drawing.Size(464, 20);
			this.numMaxBandwidth.TabIndex = 1;
			this.numMinBandwidth.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			global::System.Windows.Forms.NumericUpDown numericUpDown16 = this.numMinBandwidth;
			array = new int[4];
			array[0] = 1000;
			numericUpDown16.Increment = new decimal(array);
			this.numMinBandwidth.Location = new global::System.Drawing.Point(165, 20);
			global::System.Windows.Forms.NumericUpDown numericUpDown17 = this.numMinBandwidth;
			array = new int[4];
			array[0] = 1410065407;
			array[1] = 2;
			numericUpDown17.Maximum = new decimal(array);
			this.numMinBandwidth.Name = "numMinBandwidth";
			this.numMinBandwidth.Size = new global::System.Drawing.Size(464, 20);
			this.numMinBandwidth.TabIndex = 0;
			this.numMaxMessages.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.numMaxMessages.Location = new global::System.Drawing.Point(165, 80);
			global::System.Windows.Forms.NumericUpDown numericUpDown18 = this.numMaxMessages;
			array = new int[4];
			array[0] = 99999;
			numericUpDown18.Maximum = new decimal(array);
			this.numMaxMessages.Name = "numMaxMessages";
			this.numMaxMessages.Size = new global::System.Drawing.Size(464, 20);
			this.numMaxMessages.TabIndex = 2;
			this.numMaxSizeGuaranteed.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.numMaxSizeGuaranteed.Location = new global::System.Drawing.Point(165, 110);
			global::System.Windows.Forms.NumericUpDown numericUpDown19 = this.numMaxSizeGuaranteed;
			array = new int[4];
			array[0] = 99999;
			numericUpDown19.Maximum = new decimal(array);
			this.numMaxSizeGuaranteed.Name = "numMaxSizeGuaranteed";
			this.numMaxSizeGuaranteed.Size = new global::System.Drawing.Size(464, 20);
			this.numMaxSizeGuaranteed.TabIndex = 3;
			this.numMaxSizeNonguaranteed.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.numMaxSizeNonguaranteed.Location = new global::System.Drawing.Point(165, 140);
			global::System.Windows.Forms.NumericUpDown numericUpDown20 = this.numMaxSizeNonguaranteed;
			array = new int[4];
			array[0] = 99999;
			numericUpDown20.Maximum = new decimal(array);
			this.numMaxSizeNonguaranteed.Name = "numMaxSizeNonguaranteed";
			this.numMaxSizeNonguaranteed.Size = new global::System.Drawing.Size(464, 20);
			this.numMaxSizeNonguaranteed.TabIndex = 4;
			this.numMinErrorNear.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.numMinErrorNear.DecimalPlaces = 10;
			this.numMinErrorNear.Increment = new decimal(new int[] { 1, 0, 0, 196608 });
			this.numMinErrorNear.Location = new global::System.Drawing.Point(165, 200);
			global::System.Windows.Forms.NumericUpDown numericUpDown21 = this.numMinErrorNear;
			array = new int[4];
			array[0] = 1;
			numericUpDown21.Maximum = new decimal(array);
			this.numMinErrorNear.Name = "numMinErrorNear";
			this.numMinErrorNear.Size = new global::System.Drawing.Size(464, 20);
			this.numMinErrorNear.TabIndex = 6;
			this.numMinError.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.numMinError.DecimalPlaces = 10;
			this.numMinError.Increment = new decimal(new int[] { 1, 0, 0, 196608 });
			this.numMinError.Location = new global::System.Drawing.Point(165, 170);
			global::System.Windows.Forms.NumericUpDown numericUpDown22 = this.numMinError;
			array = new int[4];
			array[0] = 1;
			numericUpDown22.Maximum = new decimal(array);
			this.numMinError.Name = "numMinError";
			this.numMinError.Size = new global::System.Drawing.Size(464, 20);
			this.numMinError.TabIndex = 5;
			this.labelMaxBandwidthUnit.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.labelMaxBandwidthUnit.AutoSize = true;
			this.labelMaxBandwidthUnit.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.labelMaxBandwidthUnit.Location = new global::System.Drawing.Point(635, 52);
			this.labelMaxBandwidthUnit.Name = "labelMaxBandwidthUnit";
			this.labelMaxBandwidthUnit.Size = new global::System.Drawing.Size(24, 13);
			this.labelMaxBandwidthUnit.TabIndex = 24;
			this.labelMaxBandwidthUnit.Text = "B/s";
			this.labelMinBandwidthUnit.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.labelMinBandwidthUnit.AutoSize = true;
			this.labelMinBandwidthUnit.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.labelMinBandwidthUnit.Location = new global::System.Drawing.Point(635, 22);
			this.labelMinBandwidthUnit.Name = "labelMinBandwidthUnit";
			this.labelMinBandwidthUnit.Size = new global::System.Drawing.Size(24, 13);
			this.labelMinBandwidthUnit.TabIndex = 23;
			this.labelMinBandwidthUnit.Text = "B/s";
			this.labelMaxSizeNonguaranteedUnit.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.labelMaxSizeNonguaranteedUnit.AutoSize = true;
			this.labelMaxSizeNonguaranteedUnit.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.labelMaxSizeNonguaranteedUnit.Location = new global::System.Drawing.Point(635, 142);
			this.labelMaxSizeNonguaranteedUnit.Name = "labelMaxSizeNonguaranteedUnit";
			this.labelMaxSizeNonguaranteedUnit.Size = new global::System.Drawing.Size(33, 13);
			this.labelMaxSizeNonguaranteedUnit.TabIndex = 21;
			this.labelMaxSizeNonguaranteedUnit.Text = "Bytes";
			this.labelMaxSizeGuaranteedUnit.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.labelMaxSizeGuaranteedUnit.AutoSize = true;
			this.labelMaxSizeGuaranteedUnit.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.labelMaxSizeGuaranteedUnit.Location = new global::System.Drawing.Point(635, 112);
			this.labelMaxSizeGuaranteedUnit.Name = "labelMaxSizeGuaranteedUnit";
			this.labelMaxSizeGuaranteedUnit.Size = new global::System.Drawing.Size(33, 13);
			this.labelMaxSizeGuaranteedUnit.TabIndex = 20;
			this.labelMaxSizeGuaranteedUnit.Text = "Bytes";
			this.labelMinErrtoSendNear.AutoSize = true;
			this.labelMinErrtoSendNear.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.labelMinErrtoSendNear.Location = new global::System.Drawing.Point(6, 202);
			this.labelMinErrtoSendNear.Name = "labelMinErrtoSendNear";
			this.labelMinErrtoSendNear.Size = new global::System.Drawing.Size(126, 13);
			this.labelMinErrtoSendNear.TabIndex = 6;
			this.labelMinErrtoSendNear.Text = "Min. Errors to Send Near:";
			this.labelMinErrtoSend.AutoSize = true;
			this.labelMinErrtoSend.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.labelMinErrtoSend.Location = new global::System.Drawing.Point(6, 172);
			this.labelMinErrtoSend.Name = "labelMinErrtoSend";
			this.labelMinErrtoSend.Size = new global::System.Drawing.Size(100, 13);
			this.labelMinErrtoSend.TabIndex = 5;
			this.labelMinErrtoSend.Text = "Min. Errors to Send:";
			this.labelMaxBandwidth.AutoSize = true;
			this.labelMaxBandwidth.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.labelMaxBandwidth.Location = new global::System.Drawing.Point(6, 52);
			this.labelMaxBandwidth.Name = "labelMaxBandwidth";
			this.labelMaxBandwidth.Size = new global::System.Drawing.Size(86, 13);
			this.labelMaxBandwidth.TabIndex = 1;
			this.labelMaxBandwidth.Text = "Max. Bandwidth:";
			this.labelMinBandwidth.AutoSize = true;
			this.labelMinBandwidth.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.labelMinBandwidth.Location = new global::System.Drawing.Point(6, 22);
			this.labelMinBandwidth.Name = "labelMinBandwidth";
			this.labelMinBandwidth.Size = new global::System.Drawing.Size(83, 13);
			this.labelMinBandwidth.TabIndex = 0;
			this.labelMinBandwidth.Text = "Min. Bandwidth:";
			this.labelMaxSizeNonguaranteed.AutoSize = true;
			this.labelMaxSizeNonguaranteed.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.labelMaxSizeNonguaranteed.Location = new global::System.Drawing.Point(6, 142);
			this.labelMaxSizeNonguaranteed.Name = "labelMaxSizeNonguaranteed";
			this.labelMaxSizeNonguaranteed.Size = new global::System.Drawing.Size(110, 13);
			this.labelMaxSizeNonguaranteed.TabIndex = 4;
			this.labelMaxSizeNonguaranteed.Text = "Max. Nonguaranteed:";
			this.labelMaxSizeGuaranteed.AutoSize = true;
			this.labelMaxSizeGuaranteed.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.labelMaxSizeGuaranteed.Location = new global::System.Drawing.Point(6, 112);
			this.labelMaxSizeGuaranteed.Name = "labelMaxSizeGuaranteed";
			this.labelMaxSizeGuaranteed.Size = new global::System.Drawing.Size(92, 13);
			this.labelMaxSizeGuaranteed.TabIndex = 3;
			this.labelMaxSizeGuaranteed.Text = "Max. Guaranteed:";
			this.labelMaxMsgSent.AutoSize = true;
			this.labelMaxMsgSent.ImeMode = global::System.Windows.Forms.ImeMode.NoControl;
			this.labelMaxMsgSent.Location = new global::System.Drawing.Point(6, 82);
			this.labelMaxMsgSent.Name = "labelMaxMsgSent";
			this.labelMaxMsgSent.Size = new global::System.Drawing.Size(109, 13);
			this.labelMaxMsgSent.TabIndex = 2;
			this.labelMaxMsgSent.Text = "Max. Messages Sent:";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(884, 612);
			base.Controls.Add(this.container1);
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			this.MinimumSize = new global::System.Drawing.Size(800, 650);
			base.Name = "frmMain";
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
			base.Load += new global::System.EventHandler(this.frmMain_Load);
			base.Shown += new global::System.EventHandler(this.frmMain_Shown);
			base.Move += new global::System.EventHandler(this.frmMain_Move);
			base.Resize += new global::System.EventHandler(this.frmMain_Move);
			this.container1.Panel1.ResumeLayout(false);
			this.container1.Panel1.PerformLayout();
			this.container1.Panel2.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.container1).EndInit();
			this.container1.ResumeLayout(false);
			this.container2.Panel1.ResumeLayout(false);
			this.container2.Panel2.ResumeLayout(false);
			((global::System.ComponentModel.ISupportInitialize)this.container2).EndInit();
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
			((global::System.ComponentModel.ISupportInitialize)this.pictureLicense).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureIcon).EndInit();
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
			((global::System.ComponentModel.ISupportInitialize)this.numBackupInterval).EndInit();
			this.groupRestore.ResumeLayout(false);
			this.groupBackup.ResumeLayout(false);
			this.groupBackup.PerformLayout();
			this.container2_1.ResumeLayout(false);
			this.tab1.ResumeLayout(false);
			this.tab1Page1.ResumeLayout(false);
			this.tab1Page1.PerformLayout();
			this.groupTime.ResumeLayout(false);
			this.groupTime.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.trackTimezone).EndInit();
			this.groupTemplate.ResumeLayout(false);
			this.groupTemplate.PerformLayout();
			this.groupVon.ResumeLayout(false);
			this.groupVon.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numVonQuality).EndInit();
			this.groupMessage.ResumeLayout(false);
			this.groupMessage.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numMessageInterval).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.numMaxPlayers).EndInit();
			this.tab1Page2.ResumeLayout(false);
			this.tab1Page2.PerformLayout();
			this.groupWhitelist.ResumeLayout(false);
			this.groupWhitelist.PerformLayout();
			this.groupSignatures.ResumeLayout(false);
			this.groupSignatures.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numSecureId).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.numVerifySignatures).EndInit();
			this.groupScripting.ResumeLayout(false);
			this.groupScripting.PerformLayout();
			this.groupBattleye.ResumeLayout(false);
			this.groupBattleye.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numMaxPing).EndInit();
			this.tab1Page3.ResumeLayout(false);
			this.groupAdditional.ResumeLayout(false);
			this.groupAdditional.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numMaxCustomsize).EndInit();
			this.groupNetwork.ResumeLayout(false);
			this.groupNetwork.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.numMaxBandwidth).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.numMinBandwidth).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.numMaxMessages).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.numMaxSizeGuaranteed).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.numMaxSizeNonguaranteed).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.numMinErrorNear).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.numMinError).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000071 RID: 113
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000072 RID: 114
		private global::System.Windows.Forms.Timer timerMonitor;

		// Token: 0x04000073 RID: 115
		private global::System.Windows.Forms.SplitContainer container1;

		// Token: 0x04000074 RID: 116
		private global::System.Windows.Forms.Panel container2_3;

		// Token: 0x04000075 RID: 117
		private global::System.Windows.Forms.Panel container2_1;

		// Token: 0x04000076 RID: 118
		private global::System.Windows.Forms.TabControl tab1;

		// Token: 0x04000077 RID: 119
		private global::System.Windows.Forms.TabPage tab1Page1;

		// Token: 0x04000078 RID: 120
		private global::System.Windows.Forms.TabPage tab1Page2;

		// Token: 0x04000079 RID: 121
		private global::System.Windows.Forms.TabPage tab1Page3;

		// Token: 0x0400007A RID: 122
		private global::System.Windows.Forms.Panel container2_2;

		// Token: 0x0400007B RID: 123
		private global::System.Windows.Forms.TabControl tab2;

		// Token: 0x0400007C RID: 124
		private global::System.Windows.Forms.TabPage tab3Page3;

		// Token: 0x0400007D RID: 125
		private global::System.Windows.Forms.GroupBox groupBackup;

		// Token: 0x0400007E RID: 126
		private global::System.Windows.Forms.Button btnBackup;

		// Token: 0x0400007F RID: 127
		private global::System.Windows.Forms.GroupBox groupRestore;

		// Token: 0x04000080 RID: 128
		private global::System.Windows.Forms.Button btnRestore;

		// Token: 0x04000081 RID: 129
		private global::System.Windows.Forms.TextBox textHostname;

		// Token: 0x04000082 RID: 130
		private global::System.Windows.Forms.Label labelServerName;

		// Token: 0x04000083 RID: 131
		private global::System.Windows.Forms.Label labelReportingIp;

		// Token: 0x04000084 RID: 132
		private global::System.Windows.Forms.GroupBox groupMessage;

		// Token: 0x04000085 RID: 133
		private global::System.Windows.Forms.NumericUpDown numMaxPlayers;

		// Token: 0x04000086 RID: 134
		private global::System.Windows.Forms.Label labelMaxPlayers;

		// Token: 0x04000087 RID: 135
		private global::System.Windows.Forms.ComboBox cbxReportingIp;

		// Token: 0x04000088 RID: 136
		private global::System.Windows.Forms.Label labelPort;

		// Token: 0x04000089 RID: 137
		private global::System.Windows.Forms.NumericUpDown numMessageInterval;

		// Token: 0x0400008A RID: 138
		private global::System.Windows.Forms.Label labelTimeBetweenMessage;

		// Token: 0x0400008B RID: 139
		private global::System.Windows.Forms.RichTextBox textMessage;

		// Token: 0x0400008C RID: 140
		private global::System.Windows.Forms.Label labelRequiredBuild;

		// Token: 0x0400008D RID: 141
		private global::System.Windows.Forms.GroupBox groupVon;

		// Token: 0x0400008E RID: 142
		private global::System.Windows.Forms.CheckBox checkVon;

		// Token: 0x0400008F RID: 143
		private global::System.Windows.Forms.CheckBox checkPersistent;

		// Token: 0x04000090 RID: 144
		private global::System.Windows.Forms.NumericUpDown numVonQuality;

		// Token: 0x04000091 RID: 145
		private global::System.Windows.Forms.Label labelCodecQuality;

		// Token: 0x04000092 RID: 146
		private global::System.Windows.Forms.TextBox textPasswordServer;

		// Token: 0x04000093 RID: 147
		private global::System.Windows.Forms.Label labelPassword;

		// Token: 0x04000094 RID: 148
		private global::System.Windows.Forms.TextBox textPasswordAdmin;

		// Token: 0x04000095 RID: 149
		private global::System.Windows.Forms.Label labelAdminPassword;

		// Token: 0x04000096 RID: 150
		private global::System.Windows.Forms.GroupBox groupBattleye;

		// Token: 0x04000097 RID: 151
		private global::System.Windows.Forms.CheckBox checkBattleye;

		// Token: 0x04000098 RID: 152
		private global::System.Windows.Forms.TextBox textPasswordRcon;

		// Token: 0x04000099 RID: 153
		private global::System.Windows.Forms.Label labelRconPassword;

		// Token: 0x0400009A RID: 154
		private global::System.Windows.Forms.NumericUpDown numMaxPing;

		// Token: 0x0400009B RID: 155
		private global::System.Windows.Forms.Label labelMaxPing;

		// Token: 0x0400009C RID: 156
		private global::System.Windows.Forms.GroupBox groupNetwork;

		// Token: 0x0400009D RID: 157
		private global::System.Windows.Forms.Label labelMaxSizeGuaranteed;

		// Token: 0x0400009E RID: 158
		private global::System.Windows.Forms.Label labelMaxMsgSent;

		// Token: 0x0400009F RID: 159
		private global::System.Windows.Forms.Label labelMaxSizeNonguaranteed;

		// Token: 0x040000A0 RID: 160
		private global::System.Windows.Forms.Label labelMinErrtoSend;

		// Token: 0x040000A1 RID: 161
		private global::System.Windows.Forms.Label labelMaxBandwidth;

		// Token: 0x040000A2 RID: 162
		private global::System.Windows.Forms.Label labelMinBandwidth;

		// Token: 0x040000A3 RID: 163
		private global::System.Windows.Forms.Label labelMinErrtoSendNear;

		// Token: 0x040000A4 RID: 164
		private global::System.Windows.Forms.Label labelMaxBandwidthUnit;

		// Token: 0x040000A5 RID: 165
		private global::System.Windows.Forms.Label labelMinBandwidthUnit;

		// Token: 0x040000A6 RID: 166
		private global::System.Windows.Forms.Label labelMaxSizeNonguaranteedUnit;

		// Token: 0x040000A7 RID: 167
		private global::System.Windows.Forms.Label labelMaxSizeGuaranteedUnit;

		// Token: 0x040000A8 RID: 168
		private global::System.Windows.Forms.GroupBox groupAdditional;

		// Token: 0x040000A9 RID: 169
		private global::System.Windows.Forms.Label labelMaxCustomSize;

		// Token: 0x040000AA RID: 170
		private global::System.Windows.Forms.Label labelMaxCustomSizeUnit;

		// Token: 0x040000AB RID: 171
		private global::System.Windows.Forms.NumericUpDown numMinErrorNear;

		// Token: 0x040000AC RID: 172
		private global::System.Windows.Forms.NumericUpDown numMinError;

		// Token: 0x040000AD RID: 173
		private global::System.Windows.Forms.NumericUpDown numMaxCustomsize;

		// Token: 0x040000AE RID: 174
		private global::System.Windows.Forms.NumericUpDown numMaxBandwidth;

		// Token: 0x040000AF RID: 175
		private global::System.Windows.Forms.NumericUpDown numMinBandwidth;

		// Token: 0x040000B0 RID: 176
		private global::System.Windows.Forms.NumericUpDown numMaxMessages;

		// Token: 0x040000B1 RID: 177
		private global::System.Windows.Forms.NumericUpDown numMaxSizeGuaranteed;

		// Token: 0x040000B2 RID: 178
		private global::System.Windows.Forms.NumericUpDown numMaxSizeNonguaranteed;

		// Token: 0x040000B3 RID: 179
		private global::System.Windows.Forms.TabPage tab2Page1;

		// Token: 0x040000B4 RID: 180
		private global::System.Windows.Forms.ComboBox cbxDifficulty;

		// Token: 0x040000B5 RID: 181
		private global::System.Windows.Forms.Label labelDifficulty;

		// Token: 0x040000B6 RID: 182
		private global::System.Windows.Forms.ComboBox cbxTemplate;

		// Token: 0x040000B7 RID: 183
		private global::System.Windows.Forms.Label labelTemplate;

		// Token: 0x040000B8 RID: 184
		private global::System.Windows.Forms.TextBox textBackupPath;

		// Token: 0x040000B9 RID: 185
		private global::System.Windows.Forms.Label labelPathBackupFolder;

		// Token: 0x040000BA RID: 186
		private global::System.Windows.Forms.Button btnBackupBrowse;

		// Token: 0x040000BB RID: 187
		private global::System.Windows.Forms.TabPage tab2Page3;

		// Token: 0x040000BC RID: 188
		private global::System.Windows.Forms.RichTextBox textLogRpt;

		// Token: 0x040000BD RID: 189
		private global::System.Windows.Forms.LinkLabel btnLogMonitor;

		// Token: 0x040000BE RID: 190
		private global::System.Windows.Forms.GroupBox groupSignatures;

		// Token: 0x040000BF RID: 191
		private global::System.Windows.Forms.NumericUpDown numVerifySignatures;

		// Token: 0x040000C0 RID: 192
		private global::System.Windows.Forms.Label labelVerifySignatures;

		// Token: 0x040000C1 RID: 193
		private global::System.Windows.Forms.GroupBox groupScripting;

		// Token: 0x040000C2 RID: 194
		private global::System.Windows.Forms.TextBox textOnUnsigned;

		// Token: 0x040000C3 RID: 195
		private global::System.Windows.Forms.TextBox textOnDifferent;

		// Token: 0x040000C4 RID: 196
		private global::System.Windows.Forms.TextBox textOnHacked;

		// Token: 0x040000C5 RID: 197
		private global::System.Windows.Forms.TextBox textOnUserDisconnected;

		// Token: 0x040000C6 RID: 198
		private global::System.Windows.Forms.TextBox textOnUserConnected;

		// Token: 0x040000C7 RID: 199
		private global::System.Windows.Forms.TextBox textDoubleId;

		// Token: 0x040000C8 RID: 200
		private global::System.Windows.Forms.Label labelOnUnsignedData;

		// Token: 0x040000C9 RID: 201
		private global::System.Windows.Forms.Label labelOnDifferentData;

		// Token: 0x040000CA RID: 202
		private global::System.Windows.Forms.Label labelOnHackedData;

		// Token: 0x040000CB RID: 203
		private global::System.Windows.Forms.Label labelOnUserDisconnected;

		// Token: 0x040000CC RID: 204
		private global::System.Windows.Forms.Label labelOnUserConnected;

		// Token: 0x040000CD RID: 205
		private global::System.Windows.Forms.Label labelDoubleId;

		// Token: 0x040000CE RID: 206
		private global::System.Windows.Forms.TextBox textRegularCheck;

		// Token: 0x040000CF RID: 207
		private global::System.Windows.Forms.Label labelRegularCheck;

		// Token: 0x040000D0 RID: 208
		private global::System.Windows.Forms.GroupBox groupTemplate;

		// Token: 0x040000D1 RID: 209
		private global::System.Windows.Forms.LinkLabel btnLogClear;

		// Token: 0x040000D2 RID: 210
		private global::System.Windows.Forms.Panel container2_4;

		// Token: 0x040000D3 RID: 211
		private global::System.Windows.Forms.GroupBox groupAbout;

		// Token: 0x040000D4 RID: 212
		private global::System.Windows.Forms.Label labelVersionText;

		// Token: 0x040000D5 RID: 213
		private global::System.Windows.Forms.PictureBox pictureIcon;

		// Token: 0x040000D6 RID: 214
		private global::System.Windows.Forms.Label labelVersion;

		// Token: 0x040000D7 RID: 215
		private global::System.Windows.Forms.Button btnSave3;

		// Token: 0x040000D8 RID: 216
		private global::System.Windows.Forms.Button btnSave1;

		// Token: 0x040000D9 RID: 217
		private global::System.Windows.Forms.Button btnSave2;

		// Token: 0x040000DA RID: 218
		private global::System.Windows.Forms.ComboBox cbxInstance;

		// Token: 0x040000DB RID: 219
		private global::System.Windows.Forms.Button btnExit;

		// Token: 0x040000DC RID: 220
		private global::System.Windows.Forms.RadioButton btnMenu4;

		// Token: 0x040000DD RID: 221
		private global::System.Windows.Forms.RadioButton btnMenu2;

		// Token: 0x040000DE RID: 222
		private global::System.Windows.Forms.RadioButton btnMenu3;

		// Token: 0x040000DF RID: 223
		private global::System.Windows.Forms.Label labelDescription2;

		// Token: 0x040000E0 RID: 224
		private global::System.Windows.Forms.Label labelDescription3;

		// Token: 0x040000E1 RID: 225
		private global::System.Windows.Forms.Label labelDescription1;

		// Token: 0x040000E2 RID: 226
		private global::System.Windows.Forms.Label labelDescription4;

		// Token: 0x040000E3 RID: 227
		private global::System.Windows.Forms.Label labelSelectInstance;

		// Token: 0x040000E4 RID: 228
		private global::System.Windows.Forms.RadioButton btnMenu1;

		// Token: 0x040000E5 RID: 229
		private global::System.Windows.Forms.TabControl tab3;

		// Token: 0x040000E6 RID: 230
		private global::System.Windows.Forms.TabPage tab3Page1;

		// Token: 0x040000E7 RID: 231
		private global::System.Windows.Forms.GroupBox groupTime;

		// Token: 0x040000E8 RID: 232
		private global::System.Windows.Forms.Label textTimezone;

		// Token: 0x040000E9 RID: 233
		private global::System.Windows.Forms.Label labelTimezone;

		// Token: 0x040000EA RID: 234
		private global::System.Windows.Forms.TrackBar trackTimezone;

		// Token: 0x040000EB RID: 235
		private global::System.Windows.Forms.TabPage tab3Page2;

		// Token: 0x040000EC RID: 236
		private global::System.Windows.Forms.CheckBox checkWhitelist;

		// Token: 0x040000ED RID: 237
		private global::System.Windows.Forms.GroupBox groupProfile;

		// Token: 0x040000EE RID: 238
		private global::System.Windows.Forms.GroupBox groupReset;

		// Token: 0x040000EF RID: 239
		private global::System.Windows.Forms.Button btnReset;

		// Token: 0x040000F0 RID: 240
		private global::System.Windows.Forms.SplitContainer container2;

		// Token: 0x040000F1 RID: 241
		private global::System.Windows.Forms.GroupBox groupSettings;

		// Token: 0x040000F2 RID: 242
		private global::System.Windows.Forms.ComboBox cbxLanguage;

		// Token: 0x040000F3 RID: 243
		private global::System.Windows.Forms.Label labelChooseLanguage;

		// Token: 0x040000F4 RID: 244
		private global::System.Windows.Forms.CheckBox btnLog;

		// Token: 0x040000F5 RID: 245
		private global::System.Windows.Forms.RichTextBox textLog;

		// Token: 0x040000F6 RID: 246
		private global::System.Windows.Forms.Button btnPlayerAdd;

		// Token: 0x040000F7 RID: 247
		private global::System.Windows.Forms.Label labelAppName;

		// Token: 0x040000F8 RID: 248
		private global::System.Windows.Forms.ComboBox cbxDatabase;

		// Token: 0x040000F9 RID: 249
		private global::System.Windows.Forms.Label labelSelectDatabase;

		// Token: 0x040000FA RID: 250
		private global::System.Windows.Forms.Label labelNoticeMessage;

		// Token: 0x040000FB RID: 251
		private global::System.Windows.Forms.Button btnRandomPass;

		// Token: 0x040000FC RID: 252
		private global::System.Windows.Forms.Label labelNoticeReset;

		// Token: 0x040000FD RID: 253
		private global::System.Windows.Forms.GroupBox groupAutoBackup;

		// Token: 0x040000FE RID: 254
		private global::System.Windows.Forms.Button btnAutoBackup;

		// Token: 0x040000FF RID: 255
		private global::System.Windows.Forms.NumericUpDown numBackupInterval;

		// Token: 0x04000100 RID: 256
		private global::System.Windows.Forms.Label labelEnterBackupInterval;

		// Token: 0x04000101 RID: 257
		private global::System.Windows.Forms.Button btnDatabase;

		// Token: 0x04000102 RID: 258
		private global::System.Windows.Forms.TextBox textModlist;

		// Token: 0x04000103 RID: 259
		private global::System.Windows.Forms.Label labelModlist;

		// Token: 0x04000104 RID: 260
		private global::System.Windows.Forms.MaskedTextBox textPort;

		// Token: 0x04000105 RID: 261
		private global::System.Windows.Forms.MaskedTextBox textBuild;

		// Token: 0x04000106 RID: 262
		private global::System.Windows.Forms.GroupBox groupWhitelist;

		// Token: 0x04000107 RID: 263
		private global::System.Windows.Forms.TextBox textWhitelistMessage;

		// Token: 0x04000108 RID: 264
		private global::System.Windows.Forms.Label labelWhitelistMessage;

		// Token: 0x04000109 RID: 265
		private global::System.Windows.Forms.CheckBox checkDaytime;

		// Token: 0x0400010A RID: 266
		private global::System.Windows.Forms.CheckBox checkRmod;

		// Token: 0x0400010B RID: 267
		private global::System.Windows.Forms.CheckBox checkDuplicate;

		// Token: 0x0400010C RID: 268
		private global::System.Windows.Forms.ComboBox cbxLoadout;

		// Token: 0x0400010D RID: 269
		private global::System.Windows.Forms.Label labelLoadout;

		// Token: 0x0400010E RID: 270
		private global::System.Windows.Forms.Button btnSave4;

		// Token: 0x0400010F RID: 271
		internal global::System.Windows.Forms.GroupBox groupSurvivor;

		// Token: 0x04000110 RID: 272
		private global::System.Windows.Forms.TextBox textMedical;

		// Token: 0x04000111 RID: 273
		private global::System.Windows.Forms.Label labelMedical;

		// Token: 0x04000112 RID: 274
		private global::System.Windows.Forms.TextBox textPosition;

		// Token: 0x04000113 RID: 275
		private global::System.Windows.Forms.Label labelPosition;

		// Token: 0x04000114 RID: 276
		private global::System.Windows.Forms.TextBox textBackpack;

		// Token: 0x04000115 RID: 277
		private global::System.Windows.Forms.Label labelBackpack;

		// Token: 0x04000116 RID: 278
		private global::System.Windows.Forms.TextBox textInventory;

		// Token: 0x04000117 RID: 279
		private global::System.Windows.Forms.Label labelInventory;

		// Token: 0x04000118 RID: 280
		internal global::System.Windows.Forms.TextBox textPlayerGuid;

		// Token: 0x04000119 RID: 281
		internal global::System.Windows.Forms.Label labelPlayerGuid;

		// Token: 0x0400011A RID: 282
		internal global::System.Windows.Forms.TextBox textPlayerUid;

		// Token: 0x0400011B RID: 283
		internal global::System.Windows.Forms.Label labelPlayerUid;

		// Token: 0x0400011C RID: 284
		internal global::System.Windows.Forms.TextBox textPlayerName;

		// Token: 0x0400011D RID: 285
		internal global::System.Windows.Forms.Label labelPlayerName;

		// Token: 0x0400011E RID: 286
		internal global::System.Windows.Forms.ProgressBar progressBackup;

		// Token: 0x0400011F RID: 287
		private global::System.Windows.Forms.TabPage tab2Page2;

		// Token: 0x04000120 RID: 288
		private global::System.Windows.Forms.GroupBox groupLogin;

		// Token: 0x04000121 RID: 289
		private global::System.Windows.Forms.Label labelMySqlCredentials;

		// Token: 0x04000122 RID: 290
		private global::System.Windows.Forms.TextBox textMysqlUser;

		// Token: 0x04000123 RID: 291
		private global::System.Windows.Forms.Button btnMysqlUser;

		// Token: 0x04000124 RID: 292
		private global::System.Windows.Forms.TextBox textMysqlPass;

		// Token: 0x04000125 RID: 293
		private global::System.Windows.Forms.Label labelMysqlPoint;

		// Token: 0x04000126 RID: 294
		private global::System.Windows.Forms.Label labelMySqlHost;

		// Token: 0x04000127 RID: 295
		private global::System.Windows.Forms.TextBox textMysqlPort;

		// Token: 0x04000128 RID: 296
		private global::System.Windows.Forms.TextBox textMysqlHost;

		// Token: 0x04000129 RID: 297
		private global::System.Windows.Forms.Button btnMysqlHost;

		// Token: 0x0400012A RID: 298
		private global::System.Windows.Forms.ListBox listPlayers;

		// Token: 0x0400012B RID: 299
		private global::System.Windows.Forms.CheckBox checkWhitelisted;

		// Token: 0x0400012C RID: 300
		private global::System.Windows.Forms.NumericUpDown numSecureId;

		// Token: 0x0400012D RID: 301
		private global::System.Windows.Forms.Label labelRequireSecureId;

		// Token: 0x0400012E RID: 302
		private global::System.Windows.Forms.TextBox textWelcomeMessage;

		// Token: 0x0400012F RID: 303
		private global::System.Windows.Forms.Label labelWelcomeMessage;

		// Token: 0x04000130 RID: 304
		private global::System.Windows.Forms.Label labelTime;

		// Token: 0x04000131 RID: 305
		private global::System.Windows.Forms.ComboBox cbxLoadoutBackpack;

		// Token: 0x04000132 RID: 306
		private global::System.Windows.Forms.Label labelLoadoutBackpack;

		// Token: 0x04000133 RID: 307
		private global::System.Windows.Forms.PictureBox pictureLicense;
	}
}
