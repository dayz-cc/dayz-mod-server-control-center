using System;

namespace BattleNET
{
	// Token: 0x02000008 RID: 8
	public class BattlEyeMessageEventArgs : EventArgs
	{
		// Token: 0x06000030 RID: 48 RVA: 0x00002BB6 File Offset: 0x00000DB6
		public BattlEyeMessageEventArgs(string message)
		{
			this.Message = message;
		}

		// Token: 0x04000014 RID: 20
		public string Message;
	}
}
