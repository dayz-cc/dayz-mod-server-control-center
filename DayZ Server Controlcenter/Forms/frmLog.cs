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

namespace Crosire.Controlcenter.Forms
{
	// Token: 0x02000008 RID: 8
	public partial class frmLog : Form
	{
		// Token: 0x06000031 RID: 49 RVA: 0x00006DC0 File Offset: 0x00004FC0
		public frmLog()
		{
			this.InitializeComponent();
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000032 RID: 50 RVA: 0x00006E30 File Offset: 0x00005030
		protected override CreateParams CreateParams
		{
			get
			{
				CreateParams createParams = base.CreateParams;
				createParams.ClassStyle |= 512;
				return createParams;
			}
		}

		// Token: 0x06000033 RID: 51 RVA: 0x00006E60 File Offset: 0x00005060
		private void HandleMessage(object sender, BattlEyeMessageEventArgs args)
		{
			if (args.Message != null)
			{
				int num = Convert.ToInt32(sender.ToString());
				Match match = Regex.Match(args.Message, "Player #(?<player_id>[0-9]{1,3})\\s(?<user>.+) - GUID: (?<guid>.+)\\W\\D\\S", RegexOptions.IgnoreCase);
				if (match.Success)
				{
					Configuration configuration = new Configuration(num);
					configuration.LoadXmlConfig();
					configuration.LoadHiveConfig();
					MySqlConnection mySqlConnection = new MySqlConnection(string.Format("server={0};port={1};user={2};password={3};database={4};", new object[]
					{
						configuration.dbHost,
						configuration.dbPort.ToString(),
						configuration.dbUser,
						configuration.dbPass,
						configuration.dbName
					}));
					bool flag = true;
					if (!string.IsNullOrEmpty(configuration.beWhitelistHost) && !string.IsNullOrEmpty(configuration.beWhitelistPort.ToString()) && !string.IsNullOrEmpty(configuration.beWhitelistUser) && !string.IsNullOrEmpty(configuration.beWhitelistName))
					{
						mySqlConnection = new MySqlConnection(string.Format("server={0};port={1};user={2};password={3};database={4};", new object[]
						{
							configuration.beWhitelistHost,
							configuration.beWhitelistPort.ToString(),
							configuration.beWhitelistUser,
							configuration.beWhitelistPass,
							configuration.beWhitelistName
						}));
					}
					Player player = new Player(match.Groups["player_id"].Value, string.Empty, string.Empty, match.Groups["guid"].Value.Trim(), match.Groups["user"].Value);
					this.subWrite(num, player.name + " (" + player.guid + ") joined.", Color.White);
					if (player.guid != null && player.name != null && configuration.beWhitelistEnabled)
					{
						if (Whitelist.VerifyPlayer(player, mySqlConnection))
						{
							this.subWrite(num, "> " + player.name + " is whitelisted!", Color.Green);
							player.logType = Player.LogTypes.Success;
							Whitelist.LogPlayer(player, true);
						}
						else
						{
							this.subWrite(num, "> " + player.name + " is NOT whitelisted, kicking!", Color.Red);
							player.logType = Player.LogTypes.Kick;
							Whitelist.KickPlayer(player, this.b[num - 1], configuration.beWhitelistMessage);
							Whitelist.LogPlayer(player, false);
							flag = false;
						}
					}
					if (!string.IsNullOrEmpty(configuration.confWelcome) && flag)
					{
						Whitelist.WelcomePlayer(player, this.b[num - 1], configuration.confWelcome);
					}
				}
				else if (args.Message.StartsWith("Players on server:"))
				{
					Configuration configuration = new Configuration(num);
					configuration.LoadXmlConfig();
					configuration.LoadHiveConfig();
					if (configuration.beWhitelistEnabled)
					{
						MySqlConnection mySqlConnection = new MySqlConnection(string.Format("server={0};port={1};user={2};password={3};database={4};", new object[]
						{
							configuration.dbHost,
							configuration.dbPort.ToString(),
							configuration.dbUser,
							configuration.dbPass,
							configuration.dbName
						}));
						if (!string.IsNullOrEmpty(configuration.beWhitelistHost) && !string.IsNullOrEmpty(configuration.beWhitelistPort.ToString()) && !string.IsNullOrEmpty(configuration.beWhitelistUser) && !string.IsNullOrEmpty(configuration.beWhitelistName))
						{
							mySqlConnection = new MySqlConnection(string.Format("server={0};port={1};user={2};password={3};database={4};", new object[]
							{
								configuration.beWhitelistHost,
								configuration.beWhitelistPort.ToString(),
								configuration.beWhitelistUser,
								configuration.beWhitelistPass,
								configuration.beWhitelistName
							}));
						}
						List<Player> list = new List<Player>();
						StringReader stringReader = new StringReader(args.Message);
						int num2 = 0;
						string text;
						while ((text = stringReader.ReadLine()) != null)
						{
							num2++;
							if (num2 > 3 && !text.StartsWith("(") && text.Length > 0)
							{
								string[] array = text.Split(new char[] { ' ' }, 5, StringSplitOptions.RemoveEmptyEntries);
								if (array.Length == 5)
								{
									list.Add(new Player(array[0], array[1].Split(new char[] { ':' })[0], array[2], array[3].Replace("(OK)", "").Replace("(?)", ""), array[4].Replace(" (Lobby)", string.Empty)));
								}
							}
						}
						stringReader.Close();
						foreach (Player player in list)
						{
							if (player.guid.Length == 32)
							{
								if (!Whitelist.VerifyPlayer(player, mySqlConnection))
								{
									this.subWrite(num, "> " + player.name + " is NOT whitelisted, kicking!", Color.Red);
									Whitelist.KickPlayer(player, this.b[num - 1], configuration.beWhitelistMessage);
									Whitelist.LogPlayer(player, false);
								}
							}
						}
					}
				}
				else if (args.Message.StartsWith("RCon admin #") && args.Message.EndsWith("logged in"))
				{
					this.subWrite(num, args.Message, Color.White);
				}
				else if (args.Message.Contains("(Side) "))
				{
					this.subWrite(num, args.Message, Color.DeepSkyBlue);
				}
				else if (args.Message.Contains("(Vehicle) "))
				{
					this.subWrite(num, args.Message, Color.Yellow);
				}
				else if (args.Message.Contains("(Direct) "))
				{
					this.subWrite(num, args.Message, Color.White);
				}
				else
				{
					match = Regex.Match(args.Message, "RCon admin # |\\(Global\\)(.+)(\\.|#)(?<cmd>.+)\\s(?<option>.+)", RegexOptions.IgnoreCase);
					if (match.Success)
					{
						if (match.Groups["cmd"].Value.ToLower() == "whitelist")
						{
							if (match.Groups["option"].Value.ToLower() == "on")
							{
								Configuration configuration = new Configuration(num);
								configuration.LoadXmlConfig();
								configuration.beWhitelistEnabled = true;
								configuration.WriteXmlConfig();
								this.b[num - 1].SendCommandPacket(EBattlEyeCommand.Say, "-1 Whitelist is now enabled ...");
							}
							else if (match.Groups["option"].Value.ToLower() == "off")
							{
								Configuration configuration = new Configuration(num);
								configuration.LoadXmlConfig();
								configuration.beWhitelistEnabled = false;
								configuration.WriteXmlConfig();
								this.b[num - 1].SendCommandPacket(EBattlEyeCommand.Say, "-1 Whitelist is now disabled ...");
							}
							else if (match.Groups["option"].Value.ToLower() == "check")
							{
								this.b[num - 1].SendCommandPacket(EBattlEyeCommand.Players);
							}
						}
					}
					else
					{
						this.subWrite(num, args.Message, Color.Gray);
					}
				}
			}
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00007694 File Offset: 0x00005894
		private void HandleDisconnect(object sender, BattlEyeDisconnectEventArgs args)
		{
			int num = Convert.ToInt32(sender.ToString());
			if (args.DisconnectionType == EBattlEyeDisconnectionType.LoginFailed)
			{
				this.listBePass[num - 1] = null;
			}
			if (args.DisconnectionType == EBattlEyeDisconnectionType.ConnectionFailed)
			{
				this.listBePort[num - 1] = 0;
			}
			if (base.IsHandleCreated && !base.IsDisposed && !this._closing)
			{
				this.subWrite(num, args.Message, Color.White);
			}
		}

		// Token: 0x06000035 RID: 53 RVA: 0x0000771C File Offset: 0x0000591C
		private void threadWorker()
		{
			for (;;)
			{
				for (int i = 1; i <= frmMain.appInstances; i++)
				{
					if (IO.GetProcessState("arma2oaserver_" + i.ToString()))
					{
						if (this.b[i - 1] != null && !string.IsNullOrEmpty(this.listBeHost[i - 1]) && this.listBePort[i - 1] != 0 && !string.IsNullOrEmpty(this.listBePass[i - 1]))
						{
							if (!this.b[i - 1].IsConnected())
							{
								this.subWrite(i, "Connecting ... ", Color.White);
								this.b[i - 1].Connect();
							}
							else
							{
								this.b[i - 1].SendCommandPacket(EBattlEyeCommand.Players);
							}
						}
						else
						{
							Configuration configuration = new Configuration(i);
							configuration.LoadXmlConfig();
							configuration.LoadCfgConfig();
							if (File.Exists(configuration.pathConfigBattleye))
							{
								configuration.LoadBattleyeConfig();
							}
							if (configuration.confBattleye)
							{
								this.listBeHost[i - 1] = configuration.beHost;
								this.listBePort[i - 1] = configuration.bePort;
								this.listBePass[i - 1] = configuration.bePass;
								this.b[i - 1] = new BattlEyeClient(new BattlEyeLoginCredentials(this.listBeHost[i - 1], this.listBePort[i - 1], this.listBePass[i - 1]));
								this.b[i - 1].MessageReceivedEvent += this.HandleMessage;
								this.b[i - 1].DisconnectEvent += this.HandleDisconnect;
								this.b[i - 1].ReconnectOnPacketLoss(true);
								this.b[i - 1].Sender(i);
								if (this.b[i - 1].IsConnected())
								{
									this.b[i - 1].Disconnect();
								}
							}
						}
					}
				}
				Thread.Sleep(10000);
			}
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00007970 File Offset: 0x00005B70
		private void frmLog_Load(object sender, EventArgs e)
		{
			this.threadworker = new Thread(new ThreadStart(this.threadWorker));
			this.threadworker.IsBackground = true;
			this.threadworker.Start();
		}

		// Token: 0x06000037 RID: 55 RVA: 0x000079A4 File Offset: 0x00005BA4
		private void frmLog_FormClosing(object sender, FormClosingEventArgs e)
		{
			this._closing = true;
			for (int i = 1; i <= frmMain.appInstances; i++)
			{
				if (this.b[i - 1] != null)
				{
					if (this.b[i - 1].IsConnected())
					{
						this.b[i - 1].SendCommandPacket(EBattlEyeCommand.Logout);
						this.b[i - 1].Disconnect();
					}
				}
			}
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00007A30 File Offset: 0x00005C30
		private void frmLog_Move(object sender, EventArgs e)
		{
			frmMain frmMain = (frmMain)Application.OpenForms["frmMain"];
			if (frmMain != null)
			{
				frmMain.Location = new Point(base.Left - frmMain.Width, base.Top);
			}
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00007A7C File Offset: 0x00005C7C
		private void textSend_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Return)
			{
				if (this.b[frmMain.serverInstance - 1] != null)
				{
					if (this.b[frmMain.serverInstance - 1].IsConnected())
					{
						this.b[frmMain.serverInstance - 1].SendCommandPacket(EBattlEyeCommand.Say, "-1 " + this.textSend.Text);
						this.textSend.Clear();
					}
				}
			}
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00007B3C File Offset: 0x00005D3C
		private void subWrite(int instance, string message, Color color)
		{
			if (base.IsHandleCreated && !base.IsDisposed)
			{
				if (base.InvokeRequired)
				{
					base.Invoke(new MethodInvoker(delegate
					{
						this.subWrite(instance, message, color);
					}));
				}
				else if (this.textLog.IsHandleCreated && !this.textLog.IsDisposed)
				{
					this.textLog.Select(this.textLog.Text.Length, 0);
					this.textLog.SelectedText = instance.ToString() + ": ";
					this.textLog.Select(this.textLog.Text.Length, 0);
					this.textLog.SelectionColor = color;
					this.textLog.SelectedText = message + Environment.NewLine;
				}
			}
		}

		// Token: 0x04000054 RID: 84
		private bool _closing = false;

		// Token: 0x04000055 RID: 85
		private string[] listBeHost = new string[frmMain.appInstances];

		// Token: 0x04000056 RID: 86
		private int[] listBePort = new int[frmMain.appInstances];

		// Token: 0x04000057 RID: 87
		private string[] listBePass = new string[frmMain.appInstances];

		// Token: 0x04000058 RID: 88
		private List<IBattleNET> b = new List<IBattleNET>(new IBattleNET[frmMain.appInstances]);

		// Token: 0x04000059 RID: 89
		private Thread threadworker;
	}
}
