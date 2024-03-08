namespace Crosire.Controlcenter.Classes
{
	public class Player
	{
		public enum LogTypes
		{
			Success = 6,
			Kick
		}

		public string number;

		public string ip;

		public string ping;

		public string guid;

		public string name;

		public LogTypes logType;

		public Player(string number, string ip, string ping, string guid, string name)
		{
			this.number = number;
			this.ip = ip;
			this.ping = ping;
			this.guid = guid;
			this.name = name;
		}
	}
}
