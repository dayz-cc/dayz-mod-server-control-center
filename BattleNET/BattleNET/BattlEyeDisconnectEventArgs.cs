using System;

namespace BattleNET
{
	public class BattlEyeDisconnectEventArgs : EventArgs
	{
		public BattlEyeLoginCredentials LoginDetails;

		public EBattlEyeDisconnectionType DisconnectionType;

		public string Message;

		public BattlEyeDisconnectEventArgs(BattlEyeLoginCredentials loginDetails, EBattlEyeDisconnectionType disconnectionType)
		{
			LoginDetails = loginDetails;
			DisconnectionType = disconnectionType;
			switch (DisconnectionType)
			{
			case EBattlEyeDisconnectionType.ConnectionLost:
				Message = "Disconnected! (Connection timeout)";
				break;
			case EBattlEyeDisconnectionType.LoginFailed:
				Message = "Disconnected! (Failed to login)";
				break;
			case EBattlEyeDisconnectionType.Manual:
				Message = "Disconnected!";
				break;
			case EBattlEyeDisconnectionType.SocketException:
				Message = "Disconnected! (Socket Exception)";
				break;
			case EBattlEyeDisconnectionType.ConnectionFailed:
				Message = "Connection failed!";
				break;
			}
		}
	}
}
