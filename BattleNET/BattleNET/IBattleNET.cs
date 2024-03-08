namespace BattleNET
{
	public interface IBattleNET
	{
		event BattlEyeMessageEventHandler MessageReceivedEvent;

		event BattlEyeDisconnectEventHandler DisconnectEvent;

		EBattlEyeCommandResult SendCommandPacket(string command);

		EBattlEyeCommandResult SendCommandPacket(EBattlEyeCommand command);

		EBattlEyeCommandResult SendCommandPacket(EBattlEyeCommand command, string parameters);

		EBattlEyeConnectionResult Connect();

		BattlEyeLoginCredentials Credentials(BattlEyeLoginCredentials loginCredentials);

		void Disconnect();

		bool IsConnected();

		bool ReconnectOnPacketLoss(bool newSetting);

		object Sender();

		object Sender(object newSetting);
	}
}
