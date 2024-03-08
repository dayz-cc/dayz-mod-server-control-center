using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using BattleNET;
using Crosire.Controlcenter.Classes;
using Crosire.Library;
using MySql.Data.MySqlClient;

namespace Crosire.Controlcenter.Forms {
    internal partial class frmLog : Form {
        private bool _closing = false;

        private string[] listBeHost = new string[frmMain.appInstances];

        private int[] listBePort = new int[frmMain.appInstances];

        private string[] listBePass = new string[frmMain.appInstances];

        private List<IBattleNET> b = new List<IBattleNET>(new IBattleNET[frmMain.appInstances]);

        private Thread threadworker;

        private IContainer components = null;

        private RichTextBox textLog;

        private TextBox textSend;

        protected override CreateParams CreateParams {
            get {
                CreateParams createParams = base.CreateParams;
                createParams.ClassStyle |= 512;
                return createParams;
            }
        }

        public frmLog() {
            InitializeComponent();
        }

        private void HandleMessage(object sender, BattlEyeMessageEventArgs args) {
            if (args.Message == null) {
                return;
            }
            int num = Convert.ToInt32(sender.ToString());
            Match match = Regex.Match(args.Message, "Player #(?<player_id>[0-9]{1,3})\\s(?<user>.+) - GUID: (?<guid>.+)\\W\\D\\S", RegexOptions.IgnoreCase);
            if (match.Success) {
                Configuration configuration = new Configuration(num);
                configuration.LoadXmlConfig();
                configuration.LoadHiveConfig();
                MySqlConnection connection = new MySqlConnection($"server={configuration.dbHost};port={configuration.dbPort.ToString()};user={configuration.dbUser};password={configuration.dbPass};database={configuration.dbName};");
                bool flag = true;
                if (!string.IsNullOrEmpty(configuration.beWhitelistHost) && !string.IsNullOrEmpty(configuration.beWhitelistPort.ToString()) && !string.IsNullOrEmpty(configuration.beWhitelistUser) && !string.IsNullOrEmpty(configuration.beWhitelistName)) {
                    connection = new MySqlConnection($"server={configuration.beWhitelistHost};port={configuration.beWhitelistPort.ToString()};user={configuration.beWhitelistUser};password={configuration.beWhitelistPass};database={configuration.beWhitelistName};");
                }
                Player player = new Player(match.Groups["player_id"].Value, string.Empty, string.Empty, match.Groups["guid"].Value.Trim(), match.Groups["user"].Value);
                subWrite(num, player.name + " (" + player.guid + ") joined.", Color.White);
                if (player.guid != null && player.name != null && configuration.beWhitelistEnabled) {
                    if (Whitelist.VerifyPlayer(player, connection)) {
                        subWrite(num, "> " + player.name + " is whitelisted!", Color.Green);
                        player.logType = Player.LogTypes.Success;
                        Whitelist.LogPlayer(player, true);
                    } else {
                        subWrite(num, "> " + player.name + " is NOT whitelisted, kicking!", Color.Red);
                        player.logType = Player.LogTypes.Kick;
                        Whitelist.KickPlayer(player, b[num - 1], configuration.beWhitelistMessage);
                        Whitelist.LogPlayer(player, false);
                        flag = false;
                    }
                }
                if (!string.IsNullOrEmpty(configuration.confWelcome) && flag) {
                    Whitelist.WelcomePlayer(player, b[num - 1], configuration.confWelcome);
                }
                return;
            }
            if (args.Message.StartsWith("Players on server:")) {
                Configuration configuration = new Configuration(num);
                configuration.LoadXmlConfig();
                configuration.LoadHiveConfig();
                if (!configuration.beWhitelistEnabled) {
                    return;
                }
                MySqlConnection connection = new MySqlConnection($"server={configuration.dbHost};port={configuration.dbPort.ToString()};user={configuration.dbUser};password={configuration.dbPass};database={configuration.dbName};");
                if (!string.IsNullOrEmpty(configuration.beWhitelistHost) && !string.IsNullOrEmpty(configuration.beWhitelistPort.ToString()) && !string.IsNullOrEmpty(configuration.beWhitelistUser) && !string.IsNullOrEmpty(configuration.beWhitelistName)) {
                    connection = new MySqlConnection($"server={configuration.beWhitelistHost};port={configuration.beWhitelistPort.ToString()};user={configuration.beWhitelistUser};password={configuration.beWhitelistPass};database={configuration.beWhitelistName};");
                }
                List<Player> list = new List<Player>();
                StringReader stringReader = new StringReader(args.Message);
                int num2 = 0;
                string text;
                while ((text = stringReader.ReadLine()) != null) {
                    num2++;
                    if (num2 > 3 && !text.StartsWith("(") && text.Length > 0) {
                        string[] array = text.Split(new char[1] { ' ' }, 5, StringSplitOptions.RemoveEmptyEntries);
                        if (array.Length == 5) {
                            list.Add(new Player(array[0], array[1].Split(':')[0], array[2], array[3].Replace("(OK)", "").Replace("(?)", ""), array[4].Replace(" (Lobby)", string.Empty)));
                        }
                    }
                }
                stringReader.Close();
                {
                    foreach (Player item in list) {
                        if (item.guid.Length == 32 && !Whitelist.VerifyPlayer(item, connection)) {
                            subWrite(num, "> " + item.name + " is NOT whitelisted, kicking!", Color.Red);
                            Whitelist.KickPlayer(item, b[num - 1], configuration.beWhitelistMessage);
                            Whitelist.LogPlayer(item, false);
                        }
                    }
                    return;
                }
            }
            if (args.Message.StartsWith("RCon admin #") && args.Message.EndsWith("logged in")) {
                subWrite(num, args.Message, Color.White);
                return;
            }
            if (args.Message.Contains("(Side) ")) {
                subWrite(num, args.Message, Color.DeepSkyBlue);
                return;
            }
            if (args.Message.Contains("(Vehicle) ")) {
                subWrite(num, args.Message, Color.Yellow);
                return;
            }
            if (args.Message.Contains("(Direct) ")) {
                subWrite(num, args.Message, Color.White);
                return;
            }
            match = Regex.Match(args.Message, "RCon admin # |\\(Global\\)(.+)(\\.|#)(?<cmd>.+)\\s(?<option>.+)", RegexOptions.IgnoreCase);
            if (match.Success) {
                if (match.Groups["cmd"].Value.ToLower() == "whitelist") {
                    if (match.Groups["option"].Value.ToLower() == "on") {
                        Configuration configuration = new Configuration(num);
                        configuration.LoadXmlConfig();
                        configuration.beWhitelistEnabled = true;
                        configuration.WriteXmlConfig();
                        b[num - 1].SendCommandPacket(EBattlEyeCommand.Say, "-1 Whitelist is now enabled ...");
                    } else if (match.Groups["option"].Value.ToLower() == "off") {
                        Configuration configuration = new Configuration(num);
                        configuration.LoadXmlConfig();
                        configuration.beWhitelistEnabled = false;
                        configuration.WriteXmlConfig();
                        b[num - 1].SendCommandPacket(EBattlEyeCommand.Say, "-1 Whitelist is now disabled ...");
                    } else if (match.Groups["option"].Value.ToLower() == "check") {
                        b[num - 1].SendCommandPacket(EBattlEyeCommand.Players);
                    }
                }
            } else {
                subWrite(num, args.Message, Color.Gray);
            }
        }

        private void HandleDisconnect(object sender, BattlEyeDisconnectEventArgs args) {
            int num = Convert.ToInt32(sender.ToString());
            if (args.DisconnectionType == EBattlEyeDisconnectionType.LoginFailed) {
                listBePass[num - 1] = null;
            }
            if (args.DisconnectionType == EBattlEyeDisconnectionType.ConnectionFailed) {
                listBePort[num - 1] = 0;
            }
            if (base.IsHandleCreated && !base.IsDisposed && !_closing) {
                subWrite(num, args.Message, Color.White);
            }
        }

        private void threadWorker() {
            while (true) {
                bool flag = true;
                for (int i = 1; i <= frmMain.appInstances; i++) {
                    if (!IO.GetProcessState("arma2oaserver_" + i)) {
                        continue;
                    }
                    if (b[i - 1] != null && !string.IsNullOrEmpty(listBeHost[i - 1]) && listBePort[i - 1] != 0 && !string.IsNullOrEmpty(listBePass[i - 1])) {
                        if (!b[i - 1].IsConnected()) {
                            subWrite(i, "Connecting ... ", Color.White);
                            b[i - 1].Connect();
                        } else {
                            b[i - 1].SendCommandPacket(EBattlEyeCommand.Players);
                        }
                        continue;
                    }
                    Configuration configuration = new Configuration(i);
                    configuration.LoadXmlConfig();
                    configuration.LoadCfgConfig();
                    if (File.Exists(configuration.pathConfigBattleye)) {
                        configuration.LoadBattleyeConfig();
                    }
                    if (configuration.confBattleye) {
                        listBeHost[i - 1] = configuration.beHost;
                        listBePort[i - 1] = configuration.bePort;
                        listBePass[i - 1] = configuration.bePass;
                        b[i - 1] = new BattlEyeClient(new BattlEyeLoginCredentials(listBeHost[i - 1], listBePort[i - 1], listBePass[i - 1]));
                        b[i - 1].MessageReceivedEvent += HandleMessage;
                        b[i - 1].DisconnectEvent += HandleDisconnect;
                        b[i - 1].ReconnectOnPacketLoss(true);
                        b[i - 1].Sender(i);
                        if (b[i - 1].IsConnected()) {
                            b[i - 1].Disconnect();
                        }
                    }
                }
                Thread.Sleep(10000);
            }
        }

        private void frmLog_Load(object sender, EventArgs e) {
            threadworker = new Thread(threadWorker);
            threadworker.IsBackground = true;
            threadworker.Start();
        }

        private void frmLog_FormClosing(object sender, FormClosingEventArgs e) {
            _closing = true;
            for (int i = 1; i <= frmMain.appInstances; i++) {
                if (b[i - 1] != null && b[i - 1].IsConnected()) {
                    b[i - 1].SendCommandPacket(EBattlEyeCommand.Logout);
                    b[i - 1].Disconnect();
                }
            }
        }

        private void frmLog_Move(object sender, EventArgs e) {
            frmMain frmMain = (frmMain)Application.OpenForms["frmMain"];
            if (frmMain != null) {
                frmMain.Location = new Point(base.Left - frmMain.Width, base.Top);
            }
        }

        private void textSend_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Return && b[frmMain.serverInstance - 1] != null && b[frmMain.serverInstance - 1].IsConnected()) {
                b[frmMain.serverInstance - 1].SendCommandPacket(EBattlEyeCommand.Say, "-1 " + textSend.Text);
                textSend.Clear();
            }
        }

        private void subWrite(int instance, string message, Color color) {
            if (!base.IsHandleCreated || base.IsDisposed) {
                return;
            }
            if (base.InvokeRequired) {
                Invoke((MethodInvoker)delegate {
                    subWrite(instance, message, color);
                });
            } else if (textLog.IsHandleCreated && !textLog.IsDisposed) {
                textLog.Select(textLog.Text.Length, 0);
                textLog.SelectedText = instance + ": ";
                textLog.Select(textLog.Text.Length, 0);
                textLog.SelectionColor = color;
                textLog.SelectedText = message + Environment.NewLine;
            }
        }

        protected override void Dispose(bool disposing) {
            if (disposing && components != null) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Crosire.Controlcenter.Forms.frmLog));
            this.textLog = new System.Windows.Forms.RichTextBox();
            this.textSend = new System.Windows.Forms.TextBox();
            base.SuspendLayout();
            this.textLog.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.textLog.BackColor = System.Drawing.Color.Black;
            this.textLog.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            this.textLog.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.textLog.Location = new System.Drawing.Point(0, 0);
            this.textLog.Name = "textLog";
            this.textLog.ReadOnly = true;
            this.textLog.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
            this.textLog.Size = new System.Drawing.Size(364, 620);
            this.textLog.TabIndex = 2;
            this.textLog.Text = "";
            this.textSend.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.textSend.Location = new System.Drawing.Point(3, 621);
            this.textSend.MaxLength = 200;
            this.textSend.Name = "textSend";
            this.textSend.Size = new System.Drawing.Size(358, 20);
            this.textSend.TabIndex = 3;
            this.textSend.KeyDown += new System.Windows.Forms.KeyEventHandler(textSend_KeyDown);
            base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            base.ClientSize = new System.Drawing.Size(364, 644);
            base.ControlBox = false;
            base.Controls.Add(this.textSend);
            base.Controls.Add(this.textLog);
            base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            base.Icon = (System.Drawing.Icon)Resources.Images.icon;
            base.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(380, 10000000);
            base.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(380, 650);
            base.Name = "frmLog";
            base.ShowIcon = false;
            base.ShowInTaskbar = false;
            base.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            base.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = " ";
            base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(frmLog_FormClosing);
            base.Load += new System.EventHandler(frmLog_Load);
            base.Move += new System.EventHandler(frmLog_Move);
            base.ResumeLayout(false);
            base.PerformLayout();
        }
    }
}
