using System;

namespace BattleNET
{
	public class BattlEyeMessageEventArgs : EventArgs
	{
		public string Message;

		public BattlEyeMessageEventArgs(string message)
		{
			Message = message;
		}
	}
}
