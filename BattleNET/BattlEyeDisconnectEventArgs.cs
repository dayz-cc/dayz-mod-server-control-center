using System;

namespace BattleNET
{
	// Token: 0x02000006 RID: 6
	public class BattlEyeDisconnectEventArgs : EventArgs
	{
		// Token: 0x0600002B RID: 43 RVA: 0x00002B38 File Offset: 0x00000D38
		public BattlEyeDisconnectEventArgs(BattlEyeLoginCredentials loginDetails, EBattlEyeDisconnectionType disconnectionType)
		{
			this.LoginDetails = loginDetails;
			this.DisconnectionType = disconnectionType;
			switch (this.DisconnectionType)
			{
			case EBattlEyeDisconnectionType.Manual:
				this.Message = "Disconnected!";
				return;
			case EBattlEyeDisconnectionType.ConnectionLost:
				this.Message = "Disconnected! (Connection timeout)";
				return;
			case EBattlEyeDisconnectionType.SocketException:
				this.Message = "Disconnected! (Socket Exception)";
				return;
			case EBattlEyeDisconnectionType.LoginFailed:
				this.Message = "Disconnected! (Failed to login)";
				return;
			case EBattlEyeDisconnectionType.ConnectionFailed:
				this.Message = "Connection failed!";
				return;
			default:
				return;
			}
		}

		// Token: 0x04000011 RID: 17
		public BattlEyeLoginCredentials LoginDetails;

		// Token: 0x04000012 RID: 18
		public EBattlEyeDisconnectionType DisconnectionType;

		// Token: 0x04000013 RID: 19
		public string Message;
	}
}
