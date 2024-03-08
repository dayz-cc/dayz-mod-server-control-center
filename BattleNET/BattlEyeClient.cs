using System;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Threading;

namespace BattleNET
{
	// Token: 0x02000004 RID: 4
	public class BattlEyeClient : IBattleNET
	{
		// Token: 0x06000010 RID: 16 RVA: 0x0000206E File Offset: 0x0000026E
		public BattlEyeClient(BattlEyeLoginCredentials loginCredentials)
		{
			this._loginCredentials = loginCredentials;
			this._sender = this;
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00002084 File Offset: 0x00000284
		private void OnMessageReceived(string message)
		{
			if (this.MessageReceivedEvent != null)
			{
				this.MessageReceivedEvent(this._sender, new BattlEyeMessageEventArgs(message));
			}
		}

		// Token: 0x06000012 RID: 18 RVA: 0x000020A5 File Offset: 0x000002A5
		private void OnDisconnect(BattlEyeLoginCredentials loginDetails, EBattlEyeDisconnectionType disconnectionType)
		{
			if (this.DisconnectEvent != null)
			{
				this.DisconnectEvent(this._sender, new BattlEyeDisconnectEventArgs(loginDetails, disconnectionType));
			}
		}

		// Token: 0x06000013 RID: 19 RVA: 0x000020C8 File Offset: 0x000002C8
		private EBattlEyeCommandResult SendLoginPacket(string command)
		{
			try
			{
				if (!this._socket.Connected)
				{
					return EBattlEyeCommandResult.NotConnected;
				}
				CRC32 crc = new CRC32();
				string text = "BE";
				string text2 = BitConverter.ToString(crc.ComputeHash(Helpers.String2Bytes(Helpers.Hex2Ascii("FF00") + command))).Replace("-", string.Empty);
				text2 = Helpers.Hex2Ascii(text2);
				char[] array = text2.ToCharArray();
				Array.Reverse(array);
				text2 = new string(array);
				text += text2;
				string text3 = text + Helpers.Hex2Ascii("FF00") + command;
				this._socket.Send(Helpers.String2Bytes(text3));
				this._commandSend = DateTime.Now;
			}
			catch
			{
				return EBattlEyeCommandResult.Error;
			}
			return EBattlEyeCommandResult.Success;
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002198 File Offset: 0x00000398
		private EBattlEyeCommandResult SendAcknowledgePacket(string command)
		{
			try
			{
				if (!this._socket.Connected)
				{
					return EBattlEyeCommandResult.NotConnected;
				}
				CRC32 crc = new CRC32();
				string text = "BE";
				string text2 = BitConverter.ToString(crc.ComputeHash(Helpers.String2Bytes(Helpers.Hex2Ascii("FF02") + command))).Replace("-", string.Empty);
				text2 = Helpers.Hex2Ascii(text2);
				char[] array = text2.ToCharArray();
				Array.Reverse(array);
				text2 = new string(array);
				text += text2;
				string text3 = text + Helpers.Hex2Ascii("FF02") + command;
				this._socket.Send(Helpers.String2Bytes(text3));
				this._commandSend = DateTime.Now;
			}
			catch
			{
				return EBattlEyeCommandResult.Error;
			}
			return EBattlEyeCommandResult.Success;
		}

		// Token: 0x06000015 RID: 21 RVA: 0x00002268 File Offset: 0x00000468
		private void Disconnect(EBattlEyeDisconnectionType disconnectionType)
		{
			this._keepRunning = false;
			this._disconnectionType = disconnectionType;
			if (this._socket.Connected)
			{
				this._socket.Shutdown(SocketShutdown.Both);
				this._socket.Close();
			}
			this.OnDisconnect(this._loginCredentials, this._disconnectionType);
		}

		// Token: 0x06000016 RID: 22 RVA: 0x000022BC File Offset: 0x000004BC
		public void Disconnect()
		{
			this._keepRunning = false;
			this._disconnectionType = EBattlEyeDisconnectionType.Manual;
			if (this._socket.Connected)
			{
				this._socket.Shutdown(SocketShutdown.Both);
				this._socket.Close();
			}
			this.OnDisconnect(this._loginCredentials, this._disconnectionType);
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00002310 File Offset: 0x00000510
		public EBattlEyeConnectionResult Connect()
		{
			try
			{
				this._commandSend = DateTime.Now;
				this._responseReceived = DateTime.Now;
				this._keepRunning = true;
				IPAddress ipaddress = IPAddress.Parse(this._loginCredentials.Host);
				EndPoint endPoint = new IPEndPoint(ipaddress, this._loginCredentials.Port);
				this._socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
				this._socket.ReceiveBufferSize = 65535;
				this.OnMessageReceived(string.Format("Connecting to {0}:{1}... ", this._loginCredentials.Host, this._loginCredentials.Port));
				try
				{
					this._socket.Connect(endPoint);
					if (this.SendLoginPacket(this._loginCredentials.Password) == EBattlEyeCommandResult.Error)
					{
						return EBattlEyeConnectionResult.ConnectionFailed;
					}
					this._socket.ReceiveTimeout = 5000;
					byte[] array = new byte[4096];
					try
					{
						this._socket.Receive(array, array.Length, SocketFlags.None);
						if (array[7] == 0)
						{
							if (array[8] == 1)
							{
								this.OnMessageReceived("Connected!");
								this._socket.ReceiveTimeout = 0;
								if (!this._ranBefore)
								{
									this._keepAlive = new Thread(new ThreadStart(this.KeepAlive));
									this._keepAlive.Start();
								}
								this._doWork = new Thread(new ThreadStart(this.DoWork));
								this._doWork.Start();
								this._ranBefore = true;
							}
							else
							{
								this.Disconnect(EBattlEyeDisconnectionType.LoginFailed);
							}
						}
					}
					catch (Exception)
					{
						this.Disconnect(EBattlEyeDisconnectionType.ConnectionFailed);
					}
				}
				catch (Exception)
				{
					return EBattlEyeConnectionResult.ConnectionFailed;
				}
			}
			catch (Exception)
			{
				return EBattlEyeConnectionResult.ParseError;
			}
			return EBattlEyeConnectionResult.Success;
		}

		// Token: 0x06000018 RID: 24 RVA: 0x000024E4 File Offset: 0x000006E4
		public EBattlEyeCommandResult SendCommandPacket(string command)
		{
			try
			{
				if (!this._socket.Connected)
				{
					return EBattlEyeCommandResult.NotConnected;
				}
				CRC32 crc = new CRC32();
				string text = "BE";
				HashAlgorithm hashAlgorithm = crc;
				string text2 = Helpers.Hex2Ascii("FF01");
				byte[] array = new byte[1];
				string text3 = BitConverter.ToString(hashAlgorithm.ComputeHash(Helpers.String2Bytes(text2 + Helpers.Bytes2String(array) + command))).Replace("-", string.Empty);
				text3 = Helpers.Hex2Ascii(text3);
				char[] array2 = text3.ToCharArray();
				Array.Reverse(array2);
				text3 = new string(array2);
				text += text3;
				string text4 = text;
				string text5 = Helpers.Hex2Ascii("FF01");
				byte[] array3 = new byte[1];
				string text6 = text4 + text5 + Helpers.Bytes2String(array3) + command;
				this._socket.Send(Helpers.String2Bytes(text6));
				this._commandSend = DateTime.Now;
			}
			catch
			{
				return EBattlEyeCommandResult.Error;
			}
			return EBattlEyeCommandResult.Success;
		}

		// Token: 0x06000019 RID: 25 RVA: 0x000025D4 File Offset: 0x000007D4
		public EBattlEyeCommandResult SendCommandPacket(EBattlEyeCommand command)
		{
			try
			{
				if (!this._socket.Connected)
				{
					return EBattlEyeCommandResult.NotConnected;
				}
				CRC32 crc = new CRC32();
				string text = "BE";
				HashAlgorithm hashAlgorithm = crc;
				string text2 = Helpers.Hex2Ascii("FF01");
				byte[] array = new byte[1];
				string text3 = BitConverter.ToString(hashAlgorithm.ComputeHash(Helpers.String2Bytes(text2 + Helpers.Bytes2String(array) + Helpers.StringValueOf(command)))).Replace("-", string.Empty);
				text3 = Helpers.Hex2Ascii(text3);
				char[] array2 = text3.ToCharArray();
				Array.Reverse(array2);
				text3 = new string(array2);
				text += text3;
				string text4 = text;
				string text5 = Helpers.Hex2Ascii("FF01");
				byte[] array3 = new byte[1];
				string text6 = text4 + text5 + Helpers.Bytes2String(array3) + Helpers.StringValueOf(command);
				this._socket.Send(Helpers.String2Bytes(text6));
				this._commandSend = DateTime.Now;
			}
			catch
			{
				return EBattlEyeCommandResult.Error;
			}
			return EBattlEyeCommandResult.Success;
		}

		// Token: 0x0600001A RID: 26 RVA: 0x000026D8 File Offset: 0x000008D8
		public EBattlEyeCommandResult SendCommandPacket(EBattlEyeCommand command, string parameters)
		{
			try
			{
				if (!this._socket.Connected)
				{
					return EBattlEyeCommandResult.NotConnected;
				}
				CRC32 crc = new CRC32();
				string text = "BE";
				HashAlgorithm hashAlgorithm = crc;
				string text2 = Helpers.Hex2Ascii("FF01");
				byte[] array = new byte[1];
				string text3 = BitConverter.ToString(hashAlgorithm.ComputeHash(Helpers.String2Bytes(text2 + Helpers.Bytes2String(array) + Helpers.StringValueOf(command) + parameters))).Replace("-", string.Empty);
				text3 = Helpers.Hex2Ascii(text3);
				char[] array2 = text3.ToCharArray();
				Array.Reverse(array2);
				text3 = new string(array2);
				text += text3;
				string[] array3 = new string[5];
				array3[0] = text;
				array3[1] = Helpers.Hex2Ascii("FF01");
				string[] array4 = array3;
				int num = 2;
				byte[] array5 = new byte[1];
				array4[num] = Helpers.Bytes2String(array5);
				array3[3] = Helpers.StringValueOf(command);
				array3[4] = parameters;
				string text4 = string.Concat(array3);
				this._socket.Send(Helpers.String2Bytes(text4));
				this._commandSend = DateTime.Now;
			}
			catch
			{
				return EBattlEyeCommandResult.Error;
			}
			return EBattlEyeCommandResult.Success;
		}

		// Token: 0x0600001B RID: 27 RVA: 0x000027FC File Offset: 0x000009FC
		public bool IsConnected()
		{
			return this._socket != null && this._socket.Connected;
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x0600001C RID: 28 RVA: 0x00002813 File Offset: 0x00000A13
		public bool IsReconnectingOnPacketLoss
		{
			get
			{
				return this._reconnectOnPacketLoss;
			}
		}

		// Token: 0x0600001D RID: 29 RVA: 0x0000281B File Offset: 0x00000A1B
		public bool ReconnectOnPacketLoss(bool newSetting)
		{
			this._reconnectOnPacketLoss = newSetting;
			return this._reconnectOnPacketLoss;
		}

		// Token: 0x0600001E RID: 30 RVA: 0x0000282A File Offset: 0x00000A2A
		public object Sender()
		{
			return this._sender;
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00002832 File Offset: 0x00000A32
		public object Sender(object newSetting)
		{
			this._sender = newSetting;
			return this._sender;
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00002841 File Offset: 0x00000A41
		public BattlEyeLoginCredentials Credentials(BattlEyeLoginCredentials loginCredentials)
		{
			this._loginCredentials = loginCredentials;
			return this._loginCredentials;
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00002850 File Offset: 0x00000A50
		private void DoWork()
		{
			byte[] array = new byte[4096];
			string text = null;
			int num = 0;
			int num2 = 0;
			this._disconnectionType = EBattlEyeDisconnectionType.ConnectionLost;
			while (this._socket.Connected && this._keepRunning)
			{
				try
				{
					int num3 = this._socket.Receive(array, array.Length, SocketFlags.None);
					if (array[7] == 2)
					{
						this.SendAcknowledgePacket(Helpers.Bytes2String(new byte[] { array[8] }));
						this.OnMessageReceived(Helpers.Bytes2String(array, 9, num3 - 9));
					}
					else if (array[7] == 1 && num3 > 9)
					{
						if (array[7] == 1 && array[9] == 0)
						{
							if (array[11] == 0)
							{
								num2 = (int)array[10];
							}
							if (num < num2)
							{
								text += Helpers.Bytes2String(array, 12, num3 - 12);
								num++;
							}
							if (num == num2)
							{
								this.OnMessageReceived(text);
								text = null;
								num = 0;
								num2 = 0;
							}
						}
						else
						{
							text = null;
							num = 0;
							num2 = 0;
							this.OnMessageReceived(Helpers.Bytes2String(array, 9, num3 - 9));
						}
					}
					this._responseReceived = DateTime.Now;
					array = new byte[4096];
				}
				catch (Exception)
				{
					if (this._keepRunning)
					{
						this.Disconnect(EBattlEyeDisconnectionType.SocketException);
					}
				}
			}
			if (!this._socket.Connected)
			{
				this.OnDisconnect(this._loginCredentials, this._disconnectionType);
			}
		}

		// Token: 0x06000022 RID: 34 RVA: 0x000029A4 File Offset: 0x00000BA4
		private void KeepAlive()
		{
			while (this._socket.Connected && this._keepRunning)
			{
				TimeSpan timeSpan = DateTime.Now - this._commandSend;
				TimeSpan timeSpan2 = DateTime.Now - this._responseReceived;
				if (timeSpan.TotalSeconds >= 15.0)
				{
					this.SendCommandPacket(null);
				}
				if (timeSpan2.TotalSeconds >= 45.0)
				{
					this.Disconnect(EBattlEyeDisconnectionType.ConnectionLost);
					if (this._reconnectOnPacketLoss)
					{
						while (this._doWork.IsAlive)
						{
							Thread.Sleep(250);
						}
						this.Connect();
					}
				}
				Thread.Sleep(500);
			}
		}

		// Token: 0x14000003 RID: 3
		// (add) Token: 0x06000023 RID: 35 RVA: 0x00002A58 File Offset: 0x00000C58
		// (remove) Token: 0x06000024 RID: 36 RVA: 0x00002A90 File Offset: 0x00000C90
		public event BattlEyeMessageEventHandler MessageReceivedEvent;

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x06000025 RID: 37 RVA: 0x00002AC8 File Offset: 0x00000CC8
		// (remove) Token: 0x06000026 RID: 38 RVA: 0x00002B00 File Offset: 0x00000D00
		public event BattlEyeDisconnectEventHandler DisconnectEvent;

		// Token: 0x04000004 RID: 4
		private Socket _socket;

		// Token: 0x04000005 RID: 5
		private Thread _doWork;

		// Token: 0x04000006 RID: 6
		private Thread _keepAlive;

		// Token: 0x04000007 RID: 7
		private DateTime _commandSend;

		// Token: 0x04000008 RID: 8
		private DateTime _responseReceived;

		// Token: 0x04000009 RID: 9
		private BattlEyeLoginCredentials _loginCredentials;

		// Token: 0x0400000A RID: 10
		private EBattlEyeDisconnectionType _disconnectionType;

		// Token: 0x0400000B RID: 11
		private bool _ranBefore;

		// Token: 0x0400000C RID: 12
		private bool _keepRunning;

		// Token: 0x0400000D RID: 13
		private bool _reconnectOnPacketLoss;

		// Token: 0x0400000E RID: 14
		private object _sender;
	}
}
