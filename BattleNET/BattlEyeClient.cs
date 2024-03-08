using System;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Threading;

namespace BattleNET
{
	// Token: 0x0200000D RID: 13
	public class BattlEyeClient : IBattleNET
	{
		// Token: 0x0600002D RID: 45 RVA: 0x000023FA File Offset: 0x000005FA
		public BattlEyeClient(BattlEyeLoginCredentials loginCredentials)
		{
			this._loginCredentials = loginCredentials;
			this._sender = this;
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00002410 File Offset: 0x00000610
		private void OnMessageReceived(string message)
		{
			if (this.MessageReceivedEvent != null)
			{
				this.MessageReceivedEvent(this._sender, new BattlEyeMessageEventArgs(message));
			}
		}

		// Token: 0x0600002F RID: 47 RVA: 0x00002431 File Offset: 0x00000631
		private void OnDisconnect(BattlEyeLoginCredentials loginDetails, EBattlEyeDisconnectionType disconnectionType)
		{
			if (this.DisconnectEvent != null)
			{
				this.DisconnectEvent(this._sender, new BattlEyeDisconnectEventArgs(loginDetails, disconnectionType));
			}
		}

		// Token: 0x06000030 RID: 48 RVA: 0x00002454 File Offset: 0x00000654
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

		// Token: 0x06000031 RID: 49 RVA: 0x00002524 File Offset: 0x00000724
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

		// Token: 0x06000032 RID: 50 RVA: 0x000025F4 File Offset: 0x000007F4
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

		// Token: 0x06000033 RID: 51 RVA: 0x00002648 File Offset: 0x00000848
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

		// Token: 0x06000034 RID: 52 RVA: 0x0000269C File Offset: 0x0000089C
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

		// Token: 0x06000035 RID: 53 RVA: 0x00002870 File Offset: 0x00000A70
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

		// Token: 0x06000036 RID: 54 RVA: 0x00002960 File Offset: 0x00000B60
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

		// Token: 0x06000037 RID: 55 RVA: 0x00002A64 File Offset: 0x00000C64
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

		// Token: 0x06000038 RID: 56 RVA: 0x00002B88 File Offset: 0x00000D88
		public bool IsConnected()
		{
			return this._socket != null && this._socket.Connected;
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000039 RID: 57 RVA: 0x00002B9F File Offset: 0x00000D9F
		public bool IsReconnectingOnPacketLoss
		{
			get
			{
				return this._reconnectOnPacketLoss;
			}
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00002BA7 File Offset: 0x00000DA7
		public bool ReconnectOnPacketLoss(bool newSetting)
		{
			this._reconnectOnPacketLoss = newSetting;
			return this._reconnectOnPacketLoss;
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00002BB6 File Offset: 0x00000DB6
		public object Sender()
		{
			return this._sender;
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00002BBE File Offset: 0x00000DBE
		public object Sender(object newSetting)
		{
			this._sender = newSetting;
			return this._sender;
		}

		// Token: 0x0600003D RID: 61 RVA: 0x00002BCD File Offset: 0x00000DCD
		public BattlEyeLoginCredentials Credentials(BattlEyeLoginCredentials loginCredentials)
		{
			this._loginCredentials = loginCredentials;
			return this._loginCredentials;
		}

		// Token: 0x0600003E RID: 62 RVA: 0x00002BDC File Offset: 0x00000DDC
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

		// Token: 0x0600003F RID: 63 RVA: 0x00002D30 File Offset: 0x00000F30
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
		// (add) Token: 0x06000040 RID: 64 RVA: 0x00002DE1 File Offset: 0x00000FE1
		// (remove) Token: 0x06000041 RID: 65 RVA: 0x00002DFA File Offset: 0x00000FFA
		public event BattlEyeMessageEventHandler MessageReceivedEvent;

		// Token: 0x14000004 RID: 4
		// (add) Token: 0x06000042 RID: 66 RVA: 0x00002E13 File Offset: 0x00001013
		// (remove) Token: 0x06000043 RID: 67 RVA: 0x00002E2C File Offset: 0x0000102C
		public event BattlEyeDisconnectEventHandler DisconnectEvent;

		// Token: 0x0400002B RID: 43
		private Socket _socket;

		// Token: 0x0400002C RID: 44
		private Thread _doWork;

		// Token: 0x0400002D RID: 45
		private Thread _keepAlive;

		// Token: 0x0400002E RID: 46
		private DateTime _commandSend;

		// Token: 0x0400002F RID: 47
		private DateTime _responseReceived;

		// Token: 0x04000030 RID: 48
		private BattlEyeLoginCredentials _loginCredentials;

		// Token: 0x04000031 RID: 49
		private EBattlEyeDisconnectionType _disconnectionType;

		// Token: 0x04000032 RID: 50
		private bool _ranBefore;

		// Token: 0x04000033 RID: 51
		private bool _keepRunning;

		// Token: 0x04000034 RID: 52
		private bool _reconnectOnPacketLoss;

		// Token: 0x04000035 RID: 53
		private object _sender;
	}
}
