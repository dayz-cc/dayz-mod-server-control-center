namespace BattleNET
{
	public struct BattlEyeLoginCredentials
	{
		public string Host;

		public int Port;

		public string Password;

		public BattlEyeLoginCredentials(string host, int port, string password)
		{
			this = default(BattlEyeLoginCredentials);
			Host = host;
			Port = port;
			Password = password;
		}
	}
}
