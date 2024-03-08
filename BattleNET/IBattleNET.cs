using System;

namespace BattleNET
{
	// Token: 0x02000003 RID: 3
	public interface IBattleNET
	{
		// Token: 0x06000002 RID: 2
		EBattlEyeCommandResult SendCommandPacket(string command);

		// Token: 0x06000003 RID: 3
		EBattlEyeCommandResult SendCommandPacket(EBattlEyeCommand command);

		// Token: 0x06000004 RID: 4
		EBattlEyeCommandResult SendCommandPacket(EBattlEyeCommand command, string parameters);

		// Token: 0x06000005 RID: 5
		EBattlEyeConnectionResult Connect();

		// Token: 0x06000006 RID: 6
		BattlEyeLoginCredentials Credentials(BattlEyeLoginCredentials loginCredentials);

		// Token: 0x06000007 RID: 7
		void Disconnect();

		// Token: 0x06000008 RID: 8
		bool IsConnected();

		// Token: 0x06000009 RID: 9
		bool ReconnectOnPacketLoss(bool newSetting);

		// Token: 0x0600000A RID: 10
		object Sender();

		// Token: 0x0600000B RID: 11
		object Sender(object newSetting);

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x0600000C RID: 12
		// (remove) Token: 0x0600000D RID: 13
		event BattlEyeMessageEventHandler MessageReceivedEvent;

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x0600000E RID: 14
		// (remove) Token: 0x0600000F RID: 15
		event BattlEyeDisconnectEventHandler DisconnectEvent;
	}
}
