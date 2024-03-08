using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net;
using System.Net.Sockets;
using NLog.Common;

namespace NLog.Internal.NetworkSenders
{
	/// <summary>
	/// Sends messages over the network as UDP datagrams.
	/// </summary>
	// Token: 0x0200007B RID: 123
	internal class UdpNetworkSender : NetworkSender
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Internal.NetworkSenders.UdpNetworkSender" /> class.
		/// </summary>
		/// <param name="url">URL. Must start with udp://.</param>
		/// <param name="addressFamily">The address family.</param>
		// Token: 0x0600030D RID: 781 RVA: 0x0000BE67 File Offset: 0x0000A067
		public UdpNetworkSender(string url, AddressFamily addressFamily)
			: base(url)
		{
			this.AddressFamily = addressFamily;
		}

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x0600030E RID: 782 RVA: 0x0000BE7C File Offset: 0x0000A07C
		// (set) Token: 0x0600030F RID: 783 RVA: 0x0000BE93 File Offset: 0x0000A093
		internal AddressFamily AddressFamily { get; set; }

		/// <summary>
		/// Creates the socket.
		/// </summary>
		/// <param name="addressFamily">The address family.</param>
		/// <param name="socketType">Type of the socket.</param>
		/// <param name="protocolType">Type of the protocol.</param>
		/// <returns>Implementation of <see cref="T:NLog.Internal.NetworkSenders.ISocket" /> to use.</returns>
		// Token: 0x06000310 RID: 784 RVA: 0x0000BE9C File Offset: 0x0000A09C
		[SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "Socket is disposed elsewhere.")]
		protected internal virtual ISocket CreateSocket(AddressFamily addressFamily, SocketType socketType, ProtocolType protocolType)
		{
			return new SocketProxy(addressFamily, socketType, protocolType);
		}

		/// <summary>
		/// Performs sender-specific initialization.
		/// </summary>
		// Token: 0x06000311 RID: 785 RVA: 0x0000BEB6 File Offset: 0x0000A0B6
		protected override void DoInitialize()
		{
			this.endpoint = this.ParseEndpointAddress(new Uri(base.Address), this.AddressFamily);
			this.socket = this.CreateSocket(this.endpoint.AddressFamily, SocketType.Dgram, ProtocolType.Udp);
		}

		/// <summary>
		/// Closes the socket.
		/// </summary>
		/// <param name="continuation">The continuation.</param>
		// Token: 0x06000312 RID: 786 RVA: 0x0000BEF0 File Offset: 0x0000A0F0
		protected override void DoClose(AsyncContinuation continuation)
		{
			lock (this)
			{
				try
				{
					if (this.socket != null)
					{
						this.socket.Close();
					}
				}
				catch (Exception ex)
				{
					if (ex.MustBeRethrown())
					{
						throw;
					}
				}
				this.socket = null;
			}
		}

		/// <summary>
		/// Sends the specified text as a UDP datagram.
		/// </summary>
		/// <param name="bytes">The bytes to be sent.</param>
		/// <param name="offset">Offset in buffer.</param>
		/// <param name="length">Number of bytes to send.</param>
		/// <param name="asyncContinuation">The async continuation to be invoked after the buffer has been sent.</param>
		/// <remarks>To be overridden in inheriting classes.</remarks>
		// Token: 0x06000313 RID: 787 RVA: 0x0000BF78 File Offset: 0x0000A178
		[SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "Dispose() is called in the event handler.")]
		protected override void DoSend(byte[] bytes, int offset, int length, AsyncContinuation asyncContinuation)
		{
			lock (this)
			{
				SocketAsyncEventArgs socketAsyncEventArgs = new SocketAsyncEventArgs();
				socketAsyncEventArgs.SetBuffer(bytes, offset, length);
				socketAsyncEventArgs.UserToken = asyncContinuation;
				socketAsyncEventArgs.Completed += this.SocketOperationCompleted;
				socketAsyncEventArgs.RemoteEndPoint = this.endpoint;
				if (!this.socket.SendToAsync(socketAsyncEventArgs))
				{
					this.SocketOperationCompleted(this.socket, socketAsyncEventArgs);
				}
			}
		}

		// Token: 0x06000314 RID: 788 RVA: 0x0000C014 File Offset: 0x0000A214
		private void SocketOperationCompleted(object sender, SocketAsyncEventArgs e)
		{
			AsyncContinuation asyncContinuation = e.UserToken as AsyncContinuation;
			Exception ex = null;
			if (e.SocketError != SocketError.Success)
			{
				ex = new IOException("Error: " + e.SocketError);
			}
			e.Dispose();
			if (asyncContinuation != null)
			{
				asyncContinuation(ex);
			}
		}

		// Token: 0x040000CA RID: 202
		private ISocket socket;

		// Token: 0x040000CB RID: 203
		private EndPoint endpoint;
	}
}
