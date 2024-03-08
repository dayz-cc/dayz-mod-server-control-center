using System;

namespace BattleNET
{
	// Token: 0x02000004 RID: 4
	public class BattlEyeMessageEventArgs : EventArgs
	{
		// Token: 0x06000005 RID: 5 RVA: 0x00002050 File Offset: 0x00000250
		public BattlEyeMessageEventArgs(string message)
		{
			this.Message = message;
		}

		// Token: 0x04000007 RID: 7
		public string Message;
	}
}
