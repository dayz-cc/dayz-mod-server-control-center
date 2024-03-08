using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace BattleNET
{
	public class BattlEyeClient : IBattleNET
	{
		private Socket _socket;

		private Thread _doWork;

		private Thread _keepAlive;

		private DateTime _commandSend;

		private DateTime _responseReceived;

		private BattlEyeLoginCredentials _loginCredentials;

		private EBattlEyeDisconnectionType _disconnectionType;

		private bool _ranBefore;

		private bool _keepRunning;

		private bool _reconnectOnPacketLoss;

		private object _sender;

		public bool IsReconnectingOnPacketLoss => _reconnectOnPacketLoss;

		public event BattlEyeMessageEventHandler MessageReceivedEvent;

		public event BattlEyeDisconnectEventHandler DisconnectEvent;

		public BattlEyeClient(BattlEyeLoginCredentials loginCredentials)
		{
			_loginCredentials = loginCredentials;
			_sender = this;
		}

		private void OnMessageReceived(string message)
		{
			if (this.MessageReceivedEvent != null)
			{
				this.MessageReceivedEvent(_sender, new BattlEyeMessageEventArgs(message));
			}
		}

		private void OnDisconnect(BattlEyeLoginCredentials loginDetails, EBattlEyeDisconnectionType disconnectionType)
		{
			if (this.DisconnectEvent != null)
			{
				this.DisconnectEvent(_sender, new BattlEyeDisconnectEventArgs(loginDetails, disconnectionType));
			}
		}

		private EBattlEyeCommandResult SendLoginPacket(string command)
		{
			try
			{
				if (!_socket.Connected)
				{
					return EBattlEyeCommandResult.NotConnected;
				}
				CRC32 cRC = new CRC32();
				string text = "BE";
				string hexString = BitConverter.ToString(cRC.ComputeHash(Helpers.String2Bytes(Helpers.Hex2Ascii("FF00") + command))).Replace("-", string.Empty);
				hexString = Helpers.Hex2Ascii(hexString);
				char[] array = hexString.ToCharArray();
				Array.Reverse(array);
				hexString = new string(array);
				text += hexString;
				string s = text + Helpers.Hex2Ascii("FF00") + command;
				_socket.Send(Helpers.String2Bytes(s));
				_commandSend = DateTime.Now;
			}
			catch
			{
				return EBattlEyeCommandResult.Error;
			}
			return EBattlEyeCommandResult.Success;
		}

		private EBattlEyeCommandResult SendAcknowledgePacket(string command)
		{
			try
			{
				if (!_socket.Connected)
				{
					return EBattlEyeCommandResult.NotConnected;
				}
				CRC32 cRC = new CRC32();
				string text = "BE";
				string hexString = BitConverter.ToString(cRC.ComputeHash(Helpers.String2Bytes(Helpers.Hex2Ascii("FF02") + command))).Replace("-", string.Empty);
				hexString = Helpers.Hex2Ascii(hexString);
				char[] array = hexString.ToCharArray();
				Array.Reverse(array);
				hexString = new string(array);
				text += hexString;
				string s = text + Helpers.Hex2Ascii("FF02") + command;
				_socket.Send(Helpers.String2Bytes(s));
				_commandSend = DateTime.Now;
			}
			catch
			{
				return EBattlEyeCommandResult.Error;
			}
			return EBattlEyeCommandResult.Success;
		}

		private void Disconnect(EBattlEyeDisconnectionType disconnectionType)
		{
			_keepRunning = false;
			_disconnectionType = disconnectionType;
			if (_socket.Connected)
			{
				_socket.Shutdown(SocketShutdown.Both);
				_socket.Close();
			}
			OnDisconnect(_loginCredentials, _disconnectionType);
		}

		public void Disconnect()
		{
			_keepRunning = false;
			_disconnectionType = EBattlEyeDisconnectionType.Manual;
			if (_socket.Connected)
			{
				_socket.Shutdown(SocketShutdown.Both);
				_socket.Close();
			}
			OnDisconnect(_loginCredentials, _disconnectionType);
		}

		public EBattlEyeConnectionResult Connect()
		{
			try
			{
				_commandSend = DateTime.Now;
				_responseReceived = DateTime.Now;
				_keepRunning = true;
				IPAddress address = IPAddress.Parse(_loginCredentials.Host);
				EndPoint remoteEP = new IPEndPoint(address, _loginCredentials.Port);
				_socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
				_socket.ReceiveBufferSize = 65535;
				OnMessageReceived($"Connecting to {_loginCredentials.Host}:{_loginCredentials.Port}... ");
				try
				{
					_socket.Connect(remoteEP);
					if (SendLoginPacket(_loginCredentials.Password) == EBattlEyeCommandResult.Error)
					{
						return EBattlEyeConnectionResult.ConnectionFailed;
					}
					_socket.ReceiveTimeout = 5000;
					byte[] array = new byte[4096];
					try
					{
						_socket.Receive(array, array.Length, SocketFlags.None);
						if (array[7] == 0)
						{
							if (array[8] == 1)
							{
								OnMessageReceived("Connected!");
								_socket.ReceiveTimeout = 0;
								if (!_ranBefore)
								{
									_keepAlive = new Thread(KeepAlive);
									_keepAlive.Start();
								}
								_doWork = new Thread(DoWork);
								_doWork.Start();
								_ranBefore = true;
							}
							else
							{
								Disconnect(EBattlEyeDisconnectionType.LoginFailed);
							}
						}
					}
					catch (Exception)
					{
						Disconnect(EBattlEyeDisconnectionType.ConnectionFailed);
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

		public EBattlEyeCommandResult SendCommandPacket(string command)
		{
			try
			{
				if (!_socket.Connected)
				{
					return EBattlEyeCommandResult.NotConnected;
				}
				CRC32 cRC = new CRC32();
				string text = "BE";
				string text2 = Helpers.Hex2Ascii("FF01");
				byte[] bytes = new byte[1];
				string hexString = BitConverter.ToString(cRC.ComputeHash(Helpers.String2Bytes(text2 + Helpers.Bytes2String(bytes) + command))).Replace("-", string.Empty);
				hexString = Helpers.Hex2Ascii(hexString);
				char[] array = hexString.ToCharArray();
				Array.Reverse(array);
				hexString = new string(array);
				text += hexString;
				string text3 = text;
				string text4 = Helpers.Hex2Ascii("FF01");
				byte[] bytes2 = new byte[1];
				string s = text3 + text4 + Helpers.Bytes2String(bytes2) + command;
				_socket.Send(Helpers.String2Bytes(s));
				_commandSend = DateTime.Now;
			}
			catch
			{
				return EBattlEyeCommandResult.Error;
			}
			return EBattlEyeCommandResult.Success;
		}

		public EBattlEyeCommandResult SendCommandPacket(EBattlEyeCommand command)
		{
			try
			{
				if (!_socket.Connected)
				{
					return EBattlEyeCommandResult.NotConnected;
				}
				CRC32 cRC = new CRC32();
				string text = "BE";
				string text2 = Helpers.Hex2Ascii("FF01");
				byte[] bytes = new byte[1];
				string hexString = BitConverter.ToString(cRC.ComputeHash(Helpers.String2Bytes(text2 + Helpers.Bytes2String(bytes) + Helpers.StringValueOf(command)))).Replace("-", string.Empty);
				hexString = Helpers.Hex2Ascii(hexString);
				char[] array = hexString.ToCharArray();
				Array.Reverse(array);
				hexString = new string(array);
				text += hexString;
				string text3 = text;
				string text4 = Helpers.Hex2Ascii("FF01");
				byte[] bytes2 = new byte[1];
				string s = text3 + text4 + Helpers.Bytes2String(bytes2) + Helpers.StringValueOf(command);
				_socket.Send(Helpers.String2Bytes(s));
				_commandSend = DateTime.Now;
			}
			catch
			{
				return EBattlEyeCommandResult.Error;
			}
			return EBattlEyeCommandResult.Success;
		}

		public EBattlEyeCommandResult SendCommandPacket(EBattlEyeCommand command, string parameters)
		{
			try
			{
				if (!_socket.Connected)
				{
					return EBattlEyeCommandResult.NotConnected;
				}
				CRC32 cRC = new CRC32();
				string text = "BE";
				string text2 = Helpers.Hex2Ascii("FF01");
				byte[] bytes = new byte[1];
				string hexString = BitConverter.ToString(cRC.ComputeHash(Helpers.String2Bytes(text2 + Helpers.Bytes2String(bytes) + Helpers.StringValueOf(command) + parameters))).Replace("-", string.Empty);
				hexString = Helpers.Hex2Ascii(hexString);
				char[] array = hexString.ToCharArray();
				Array.Reverse(array);
				hexString = new string(array);
				text += hexString;
				string[] array2 = new string[5]
				{
					text,
					Helpers.Hex2Ascii("FF01"),
					null,
					null,
					null
				};
				byte[] bytes2 = new byte[1];
				array2[2] = Helpers.Bytes2String(bytes2);
				array2[3] = Helpers.StringValueOf(command);
				array2[4] = parameters;
				string s = string.Concat(array2);
				_socket.Send(Helpers.String2Bytes(s));
				_commandSend = DateTime.Now;
			}
			catch
			{
				return EBattlEyeCommandResult.Error;
			}
			return EBattlEyeCommandResult.Success;
		}

		public bool IsConnected()
		{
			if (_socket != null)
			{
				return _socket.Connected;
			}
			return false;
		}

		public bool ReconnectOnPacketLoss(bool newSetting)
		{
			_reconnectOnPacketLoss = newSetting;
			return _reconnectOnPacketLoss;
		}

		public object Sender()
		{
			return _sender;
		}

		public object Sender(object newSetting)
		{
			_sender = newSetting;
			return _sender;
		}

		public BattlEyeLoginCredentials Credentials(BattlEyeLoginCredentials loginCredentials)
		{
			_loginCredentials = loginCredentials;
			return _loginCredentials;
		}

		private void DoWork()
		{
			byte[] array = new byte[4096];
			int num = 0;
			string text = null;
			int num2 = 0;
			int num3 = 0;
			_disconnectionType = EBattlEyeDisconnectionType.ConnectionLost;
			while (_socket.Connected && _keepRunning)
			{
				try
				{
					num = _socket.Receive(array, array.Length, SocketFlags.None);
					if (array[7] == 2)
					{
						SendAcknowledgePacket(Helpers.Bytes2String(new byte[1] { array[8] }));
						OnMessageReceived(Helpers.Bytes2String(array, 9, num - 9));
					}
					else if (array[7] == 1 && num > 9)
					{
						if (array[7] == 1 && array[9] == 0)
						{
							if (array[11] == 0)
							{
								num3 = array[10];
							}
							if (num2 < num3)
							{
								text += Helpers.Bytes2String(array, 12, num - 12);
								num2++;
							}
							if (num2 == num3)
							{
								OnMessageReceived(text);
								text = null;
								num2 = 0;
								num3 = 0;
							}
						}
						else
						{
							text = null;
							num2 = 0;
							num3 = 0;
							OnMessageReceived(Helpers.Bytes2String(array, 9, num - 9));
						}
					}
					_responseReceived = DateTime.Now;
					array = new byte[4096];
				}
				catch (Exception)
				{
					if (_keepRunning)
					{
						Disconnect(EBattlEyeDisconnectionType.SocketException);
					}
				}
			}
			if (!_socket.Connected)
			{
				OnDisconnect(_loginCredentials, _disconnectionType);
			}
		}

		private void KeepAlive()
		{
			while (_socket.Connected && _keepRunning)
			{
				TimeSpan timeSpan = DateTime.Now - _commandSend;
				TimeSpan timeSpan2 = DateTime.Now - _responseReceived;
				if (timeSpan.TotalSeconds >= 15.0)
				{
					SendCommandPacket(null);
				}
				if (timeSpan2.TotalSeconds >= 45.0)
				{
					Disconnect(EBattlEyeDisconnectionType.ConnectionLost);
					if (_reconnectOnPacketLoss)
					{
						while (_doWork.IsAlive)
						{
							Thread.Sleep(250);
						}
						Connect();
					}
				}
				Thread.Sleep(500);
			}
		}
	}
}
