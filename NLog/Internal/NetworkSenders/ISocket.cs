using System;
using System.Net.Sockets;

namespace NLog.Internal.NetworkSenders
{
	/// <summary>
	/// Interface for mocking socket calls.
	/// </summary>
	// Token: 0x02000076 RID: 118
	internal interface ISocket
	{
		// Token: 0x060002F1 RID: 753
		bool ConnectAsync(SocketAsyncEventArgs args);

		// Token: 0x060002F2 RID: 754
		void Close();

		// Token: 0x060002F3 RID: 755
		bool SendAsync(SocketAsyncEventArgs args);

		// Token: 0x060002F4 RID: 756
		bool SendToAsync(SocketAsyncEventArgs args);
	}
}
