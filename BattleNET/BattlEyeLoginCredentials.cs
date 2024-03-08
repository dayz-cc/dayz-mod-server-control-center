using System;

namespace BattleNET
{
	// Token: 0x02000002 RID: 2
	public struct BattlEyeLoginCredentials
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public BattlEyeLoginCredentials(string host, int port, string password)
		{
			this = default(BattlEyeLoginCredentials);
			this.Host = host;
			this.Port = port;
			this.Password = password;
		}

		// Token: 0x04000001 RID: 1
		public string Host;

		// Token: 0x04000002 RID: 2
		public int Port;

		// Token: 0x04000003 RID: 3
		public string Password;
	}
}
