using System;

namespace BattleNET
{
	// Token: 0x02000009 RID: 9
	public struct BattlEyeLoginCredentials
	{
		// Token: 0x06000019 RID: 25 RVA: 0x0000235D File Offset: 0x0000055D
		public BattlEyeLoginCredentials(string host, int port, string password)
		{
			this = default(BattlEyeLoginCredentials);
			this.Host = host;
			this.Port = port;
			this.Password = password;
		}

		// Token: 0x04000025 RID: 37
		public string Host;

		// Token: 0x04000026 RID: 38
		public int Port;

		// Token: 0x04000027 RID: 39
		public string Password;
	}
}
