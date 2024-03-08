using System;

namespace BattleNET
{
	// Token: 0x0200000C RID: 12
	public interface IBattleNET
	{
		// Token: 0x0600001F RID: 31
		EBattlEyeCommandResult SendCommandPacket(string command);

		// Token: 0x06000020 RID: 32
		EBattlEyeCommandResult SendCommandPacket(EBattlEyeCommand command);

		// Token: 0x06000021 RID: 33
		EBattlEyeCommandResult SendCommandPacket(EBattlEyeCommand command, string parameters);

		// Token: 0x06000022 RID: 34
		EBattlEyeConnectionResult Connect();

		// Token: 0x06000023 RID: 35
		BattlEyeLoginCredentials Credentials(BattlEyeLoginCredentials loginCredentials);

		// Token: 0x06000024 RID: 36
		void Disconnect();

		// Token: 0x06000025 RID: 37
		bool IsConnected();

		// Token: 0x06000026 RID: 38
		bool ReconnectOnPacketLoss(bool newSetting);

		// Token: 0x06000027 RID: 39
		object Sender();

		// Token: 0x06000028 RID: 40
		object Sender(object newSetting);

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000029 RID: 41
		// (remove) Token: 0x0600002A RID: 42
		event BattlEyeMessageEventHandler MessageReceivedEvent;

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x0600002B RID: 43
		// (remove) Token: 0x0600002C RID: 44
		event BattlEyeDisconnectEventHandler DisconnectEvent;
	}
}
