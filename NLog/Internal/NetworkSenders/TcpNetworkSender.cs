using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Net.Sockets;
using NLog.Common;

namespace NLog.Internal.NetworkSenders
{
	/// <summary>
	/// Sends messages over a TCP network connection.
	/// </summary>
	// Token: 0x02000079 RID: 121
	internal class TcpNetworkSender : NetworkSender
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Internal.NetworkSenders.TcpNetworkSender" /> class.
		/// </summary>
		/// <param name="url">URL. Must start with tcp://.</param>
		/// <param name="addressFamily">The address family.</param>
		// Token: 0x060002FE RID: 766 RVA: 0x0000B951 File Offset: 0x00009B51
		public TcpNetworkSender(string url, AddressFamily addressFamily)
			: base(url)
		{
			this.AddressFamily = addressFamily;
		}

		// Token: 0x17000092 RID: 146
		// (get) Token: 0x060002FF RID: 767 RVA: 0x0000B970 File Offset: 0x00009B70
		// (set) Token: 0x06000300 RID: 768 RVA: 0x0000B987 File Offset: 0x00009B87
		internal AddressFamily AddressFamily { get; set; }

		// Token: 0x17000093 RID: 147
		// (get) Token: 0x06000301 RID: 769 RVA: 0x0000B990 File Offset: 0x00009B90
		// (set) Token: 0x06000302 RID: 770 RVA: 0x0000B9A7 File Offset: 0x00009BA7
		internal int MaxQueueSize { get; set; }

		/// <summary>
		/// Creates the socket with given parameters. 
		/// </summary>
		/// <param name="addressFamily">The address family.</param>
		/// <param name="socketType">Type of the socket.</param>
		/// <param name="protocolType">Type of the protocol.</param>
		/// <returns>Instance of <see cref="T:NLog.Internal.NetworkSenders.ISocket" /> which represents the socket.</returns>
		// Token: 0x06000303 RID: 771 RVA: 0x0000B9B0 File Offset: 0x00009BB0
		[SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "This is a factory method")]
		protected internal virtual ISocket CreateSocket(AddressFamily addressFamily, SocketType socketType, ProtocolType protocolType)
		{
			return new SocketProxy(addressFamily, socketType, protocolType);
		}

		/// <summary>
		/// Performs sender-specific initialization.
		/// </summary>
		// Token: 0x06000304 RID: 772 RVA: 0x0000B9CC File Offset: 0x00009BCC
		[SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "Object is disposed in the event handler.")]
		protected override void DoInitialize()
		{
			TcpNetworkSender.MySocketAsyncEventArgs mySocketAsyncEventArgs = new TcpNetworkSender.MySocketAsyncEventArgs();
			mySocketAsyncEventArgs.RemoteEndPoint = this.ParseEndpointAddress(new Uri(base.Address), this.AddressFamily);
			mySocketAsyncEventArgs.Completed += this.SocketOperationCompleted;
			mySocketAsyncEventArgs.UserToken = null;
			this.socket = this.CreateSocket(mySocketAsyncEventArgs.RemoteEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
			this.asyncOperationInProgress = true;
			if (!this.socket.ConnectAsync(mySocketAsyncEventArgs))
			{
				this.SocketOperationCompleted(this.socket, mySocketAsyncEventArgs);
			}
		}

		/// <summary>
		/// Closes the socket.
		/// </summary>
		/// <param name="continuation">The continuation.</param>
		// Token: 0x06000305 RID: 773 RVA: 0x0000BA5C File Offset: 0x00009C5C
		protected override void DoClose(AsyncContinuation continuation)
		{
			lock (this)
			{
				if (this.asyncOperationInProgress)
				{
					this.closeContinuation = continuation;
				}
				else
				{
					this.CloseSocket(continuation);
				}
			}
		}

		/// <summary>
		/// Performs sender-specific flush.
		/// </summary>
		/// <param name="continuation">The continuation.</param>
		// Token: 0x06000306 RID: 774 RVA: 0x0000BAC0 File Offset: 0x00009CC0
		protected override void DoFlush(AsyncContinuation continuation)
		{
			lock (this)
			{
				if (!this.asyncOperationInProgress && this.pendingRequests.Count == 0)
				{
					continuation(null);
				}
				else
				{
					this.flushContinuation = continuation;
				}
			}
		}

		/// <summary>
		/// Sends the specified text over the connected socket.
		/// </summary>
		/// <param name="bytes">The bytes to be sent.</param>
		/// <param name="offset">Offset in buffer.</param>
		/// <param name="length">Number of bytes to send.</param>
		/// <param name="asyncContinuation">The async continuation to be invoked after the buffer has been sent.</param>
		/// <remarks>To be overridden in inheriting classes.</remarks>
		// Token: 0x06000307 RID: 775 RVA: 0x0000BB38 File Offset: 0x00009D38
		[SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "Object is disposed in the event handler.")]
		protected override void DoSend(byte[] bytes, int offset, int length, AsyncContinuation asyncContinuation)
		{
			TcpNetworkSender.MySocketAsyncEventArgs mySocketAsyncEventArgs = new TcpNetworkSender.MySocketAsyncEventArgs();
			mySocketAsyncEventArgs.SetBuffer(bytes, offset, length);
			mySocketAsyncEventArgs.UserToken = asyncContinuation;
			mySocketAsyncEventArgs.Completed += this.SocketOperationCompleted;
			lock (this)
			{
				if (this.MaxQueueSize != 0 && this.pendingRequests.Count >= this.MaxQueueSize)
				{
					this.pendingRequests.Dequeue();
				}
				this.pendingRequests.Enqueue(mySocketAsyncEventArgs);
			}
			this.ProcessNextQueuedItem();
		}

		// Token: 0x06000308 RID: 776 RVA: 0x0000BBEC File Offset: 0x00009DEC
		private void CloseSocket(AsyncContinuation continuation)
		{
			try
			{
				ISocket socket = this.socket;
				this.socket = null;
				if (socket != null)
				{
					socket.Close();
				}
				continuation(null);
			}
			catch (Exception ex)
			{
				if (ex.MustBeRethrown())
				{
					throw;
				}
				continuation(ex);
			}
		}

		// Token: 0x06000309 RID: 777 RVA: 0x0000BC54 File Offset: 0x00009E54
		private void SocketOperationCompleted(object sender, SocketAsyncEventArgs e)
		{
			lock (this)
			{
				this.asyncOperationInProgress = false;
				AsyncContinuation asyncContinuation = e.UserToken as AsyncContinuation;
				if (e.SocketError != SocketError.Success)
				{
					this.pendingError = new IOException("Error: " + e.SocketError);
				}
				e.Dispose();
				if (asyncContinuation != null)
				{
					asyncContinuation(this.pendingError);
				}
			}
			this.ProcessNextQueuedItem();
		}

		// Token: 0x0600030A RID: 778 RVA: 0x0000BCFC File Offset: 0x00009EFC
		private void ProcessNextQueuedItem()
		{
			lock (this)
			{
				if (!this.asyncOperationInProgress)
				{
					if (this.pendingError != null)
					{
						while (this.pendingRequests.Count != 0)
						{
							SocketAsyncEventArgs socketAsyncEventArgs = this.pendingRequests.Dequeue();
							AsyncContinuation asyncContinuation = (AsyncContinuation)socketAsyncEventArgs.UserToken;
							socketAsyncEventArgs.Dispose();
							asyncContinuation(this.pendingError);
						}
					}
					if (this.pendingRequests.Count == 0)
					{
						AsyncContinuation asyncContinuation2 = this.flushContinuation;
						if (asyncContinuation2 != null)
						{
							this.flushContinuation = null;
							asyncContinuation2(this.pendingError);
						}
						AsyncContinuation asyncContinuation3 = this.closeContinuation;
						if (asyncContinuation3 != null)
						{
							this.closeContinuation = null;
							this.CloseSocket(asyncContinuation3);
						}
					}
					else
					{
						SocketAsyncEventArgs socketAsyncEventArgs = this.pendingRequests.Dequeue();
						this.asyncOperationInProgress = true;
						if (!this.socket.SendAsync(socketAsyncEventArgs))
						{
							this.SocketOperationCompleted(this.socket, socketAsyncEventArgs);
						}
					}
				}
			}
		}

		// Token: 0x040000C2 RID: 194
		private readonly Queue<SocketAsyncEventArgs> pendingRequests = new Queue<SocketAsyncEventArgs>();

		// Token: 0x040000C3 RID: 195
		private ISocket socket;

		// Token: 0x040000C4 RID: 196
		private Exception pendingError;

		// Token: 0x040000C5 RID: 197
		private bool asyncOperationInProgress;

		// Token: 0x040000C6 RID: 198
		private AsyncContinuation closeContinuation;

		// Token: 0x040000C7 RID: 199
		private AsyncContinuation flushContinuation;

		/// <summary>
		/// Facilitates mocking of <see cref="T:System.Net.Sockets.SocketAsyncEventArgs" /> class.
		/// </summary>
		// Token: 0x0200007A RID: 122
		internal class MySocketAsyncEventArgs : SocketAsyncEventArgs
		{
			/// <summary>
			/// Raises the Completed event.
			/// </summary>
			// Token: 0x0600030B RID: 779 RVA: 0x0000BE54 File Offset: 0x0000A054
			public void RaiseCompleted()
			{
				this.OnCompleted(this);
			}
		}
	}
}
