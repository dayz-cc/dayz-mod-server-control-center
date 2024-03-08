using System;
using System.ComponentModel;

namespace BattleNET
{
	// Token: 0x02000008 RID: 8
	public enum EBattlEyeCommand
	{
		// Token: 0x04000013 RID: 19
		[Description("say ")]
		Say,
		// Token: 0x04000014 RID: 20
		[Description("missions")]
		Missions,
		// Token: 0x04000015 RID: 21
		[Description("players")]
		Players,
		// Token: 0x04000016 RID: 22
		[Description("kick ")]
		Kick,
		// Token: 0x04000017 RID: 23
		[Description("RConPassword ")]
		RConPassword,
		// Token: 0x04000018 RID: 24
		[Description("MaxPing ")]
		MaxPing,
		// Token: 0x04000019 RID: 25
		[Description("logout")]
		Logout,
		// Token: 0x0400001A RID: 26
		[Description("Exit")]
		Exit,
		// Token: 0x0400001B RID: 27
		[Description("#restart")]
		Restart,
		// Token: 0x0400001C RID: 28
		[Description("#reassign")]
		Reassign,
		// Token: 0x0400001D RID: 29
		[Description("#shutdown")]
		Shutdown,
		// Token: 0x0400001E RID: 30
		[Description("#init")]
		Init,
		// Token: 0x0400001F RID: 31
		[Description("#exec ban ")]
		ExecBan,
		// Token: 0x04000020 RID: 32
		[Description("#lock ")]
		Lock,
		// Token: 0x04000021 RID: 33
		[Description("#unlock")]
		Unlock,
		// Token: 0x04000022 RID: 34
		[Description("loadBans")]
		loadBans,
		// Token: 0x04000023 RID: 35
		[Description("loadScripts")]
		loadScripts,
		// Token: 0x04000024 RID: 36
		[Description("loadEvents")]
		loadEvents
	}
}
