using System;

namespace Crosire.Controlcenter.Classes
{
	// Token: 0x02000005 RID: 5
	public class Player
	{
		// Token: 0x0600002A RID: 42 RVA: 0x00006BD7 File Offset: 0x00004DD7
		public Player(string number, string ip, string ping, string guid, string name)
		{
			this.number = number;
			this.ip = ip;
			this.ping = ping;
			this.guid = guid;
			this.name = name;
		}

		// Token: 0x0400004A RID: 74
		public string number;

		// Token: 0x0400004B RID: 75
		public string ip;

		// Token: 0x0400004C RID: 76
		public string ping;

		// Token: 0x0400004D RID: 77
		public string guid;

		// Token: 0x0400004E RID: 78
		public string name;

		// Token: 0x0400004F RID: 79
		public Player.LogTypes logType;

		// Token: 0x02000006 RID: 6
		public enum LogTypes
		{
			// Token: 0x04000051 RID: 81
			Success = 6,
			// Token: 0x04000052 RID: 82
			Kick
		}
	}
}
