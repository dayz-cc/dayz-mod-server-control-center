using System;

namespace BattleNET
{
	// Token: 0x0200000B RID: 11
	public class BattlEyeDisconnectEventArgs : EventArgs
	{
		// Token: 0x0600001E RID: 30 RVA: 0x0000237C File Offset: 0x0000057C
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

		// Token: 0x04000028 RID: 40
		public BattlEyeLoginCredentials LoginDetails;

		// Token: 0x04000029 RID: 41
		public EBattlEyeDisconnectionType DisconnectionType;

		// Token: 0x0400002A RID: 42
		public string Message;
	}
}
