using System;
using System.Net.Sockets;

namespace NLog.Internal.NetworkSenders
{
	/// <summary>
	/// Socket proxy for mocking Socket code.
	/// </summary>
	// Token: 0x02000078 RID: 120
	internal sealed class SocketProxy : ISocket, IDisposable
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Internal.NetworkSenders.SocketProxy" /> class.
		/// </summary>
		/// <param name="addressFamily">The address family.</param>
		/// <param name="socketType">Type of the socket.</param>
		/// <param name="protocolType">Type of the protocol.</param>
		// Token: 0x060002F8 RID: 760 RVA: 0x0000B8B9 File Offset: 0x00009AB9
		internal SocketProxy(AddressFamily addressFamily, SocketType socketType, ProtocolType protocolType)
		{
			this.socket = new Socket(addressFamily, socketType, protocolType);
		}

		/// <summary>
		/// Closes the wrapped socket.
		/// </summary>
		// Token: 0x060002F9 RID: 761 RVA: 0x0000B8D2 File Offset: 0x00009AD2
		public void Close()
		{
			this.socket.Close();
		}

		/// <summary>
		/// Invokes ConnectAsync method on the wrapped socket.
		/// </summary>
		/// <param name="args">The <see cref="T:System.Net.Sockets.SocketAsyncEventArgs" /> instance containing the event data.</param>
		/// <returns>Result of original method.</returns>
		// Token: 0x060002FA RID: 762 RVA: 0x0000B8E4 File Offset: 0x00009AE4
		public bool ConnectAsync(SocketAsyncEventArgs args)
		{
			return this.socket.ConnectAsync(args);
		}

		/// <summary>
		/// Invokes SendAsync method on the wrapped socket.
		/// </summary>
		/// <param name="args">The <see cref="T:System.Net.Sockets.SocketAsyncEventArgs" /> instance containing the event data.</param>
		/// <returns>Result of original method.</returns>
		// Token: 0x060002FB RID: 763 RVA: 0x0000B904 File Offset: 0x00009B04
		public bool SendAsync(SocketAsyncEventArgs args)
		{
			return this.socket.SendAsync(args);
		}

		/// <summary>
		/// Invokes SendToAsync method on the wrapped socket.
		/// </summary>
		/// <param name="args">The <see cref="T:System.Net.Sockets.SocketAsyncEventArgs" /> instance containing the event data.</param>
		/// <returns>Result of original method.</returns>
		// Token: 0x060002FC RID: 764 RVA: 0x0000B924 File Offset: 0x00009B24
		public bool SendToAsync(SocketAsyncEventArgs args)
		{
			return this.socket.SendToAsync(args);
		}

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		// Token: 0x060002FD RID: 765 RVA: 0x0000B942 File Offset: 0x00009B42
		public void Dispose()
		{
			((IDisposable)this.socket).Dispose();
		}

		// Token: 0x040000C1 RID: 193
		private readonly Socket socket;
	}
}
