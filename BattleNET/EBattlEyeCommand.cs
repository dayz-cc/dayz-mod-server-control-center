using System;
using System.ComponentModel;

namespace BattleNET
{
	// Token: 0x0200000B RID: 11
	public enum EBattlEyeCommand
	{
		// Token: 0x04000020 RID: 32
		[Description("say ")]
		Say,
		// Token: 0x04000021 RID: 33
		[Description("missions")]
		Missions,
		// Token: 0x04000022 RID: 34
		[Description("players")]
		Players,
		// Token: 0x04000023 RID: 35
		[Description("kick ")]
		Kick,
		// Token: 0x04000024 RID: 36
		[Description("RConPassword ")]
		RConPassword,
		// Token: 0x04000025 RID: 37
		[Description("MaxPing ")]
		MaxPing,
		// Token: 0x04000026 RID: 38
		[Description("logout")]
		Logout,
		// Token: 0x04000027 RID: 39
		[Description("Exit")]
		Exit,
		// Token: 0x04000028 RID: 40
		[Description("#restart")]
		Restart,
		// Token: 0x04000029 RID: 41
		[Description("#reassign")]
		Reassign,
		// Token: 0x0400002A RID: 42
		[Description("#shutdown")]
		Shutdown,
		// Token: 0x0400002B RID: 43
		[Description("#init")]
		Init,
		// Token: 0x0400002C RID: 44
		[Description("#exec ban ")]
		ExecBan,
		// Token: 0x0400002D RID: 45
		[Description("#lock ")]
		Lock,
		// Token: 0x0400002E RID: 46
		[Description("#unlock")]
		Unlock,
		// Token: 0x0400002F RID: 47
		[Description("loadBans")]
		loadBans,
		// Token: 0x04000030 RID: 48
		[Description("loadScripts")]
		loadScripts,
		// Token: 0x04000031 RID: 49
		[Description("loadEvents")]
		loadEvents
	}
}
