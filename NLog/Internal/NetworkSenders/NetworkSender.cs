using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using NLog.Common;

namespace NLog.Internal.NetworkSenders
{
	/// <summary>
	/// A base class for all network senders. Supports one-way sending of messages
	/// over various protocols.
	/// </summary>
	// Token: 0x02000073 RID: 115
	internal abstract class NetworkSender : IDisposable
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Internal.NetworkSenders.NetworkSender" /> class.
		/// </summary>
		/// <param name="url">The network URL.</param>
		// Token: 0x060002DC RID: 732 RVA: 0x0000B369 File Offset: 0x00009569
		protected NetworkSender(string url)
		{
			this.Address = url;
			this.LastSendTime = Interlocked.Increment(ref NetworkSender.currentSendTime);
		}

		/// <summary>
		/// Finalizes an instance of the NetworkSender class.
		/// </summary>
		// Token: 0x060002DD RID: 733 RVA: 0x0000B390 File Offset: 0x00009590
		~NetworkSender()
		{
			this.Dispose(false);
		}

		/// <summary>
		/// Gets the address of the network endpoint.
		/// </summary>
		// Token: 0x17000090 RID: 144
		// (get) Token: 0x060002DE RID: 734 RVA: 0x0000B3C4 File Offset: 0x000095C4
		// (set) Token: 0x060002DF RID: 735 RVA: 0x0000B3DB File Offset: 0x000095DB
		public string Address { get; private set; }

		/// <summary>
		/// Gets the last send time.
		/// </summary>
		// Token: 0x17000091 RID: 145
		// (get) Token: 0x060002E0 RID: 736 RVA: 0x0000B3E4 File Offset: 0x000095E4
		// (set) Token: 0x060002E1 RID: 737 RVA: 0x0000B3FB File Offset: 0x000095FB
		public int LastSendTime { get; private set; }

		/// <summary>
		/// Initializes this network sender.
		/// </summary>
		// Token: 0x060002E2 RID: 738 RVA: 0x0000B404 File Offset: 0x00009604
		public void Initialize()
		{
			this.DoInitialize();
		}

		/// <summary>
		/// Closes the sender and releases any unmanaged resources.
		/// </summary>
		/// <param name="continuation">The continuation.</param>
		// Token: 0x060002E3 RID: 739 RVA: 0x0000B40E File Offset: 0x0000960E
		public void Close(AsyncContinuation continuation)
		{
			this.DoClose(continuation);
		}

		/// <summary>
		/// Flushes any pending messages and invokes a continuation.
		/// </summary>
		/// <param name="continuation">The continuation.</param>
		// Token: 0x060002E4 RID: 740 RVA: 0x0000B419 File Offset: 0x00009619
		public void FlushAsync(AsyncContinuation continuation)
		{
			this.DoFlush(continuation);
		}

		/// <summary>
		/// Send the given text over the specified protocol.
		/// </summary>
		/// <param name="bytes">Bytes to be sent.</param>
		/// <param name="offset">Offset in buffer.</param>
		/// <param name="length">Number of bytes to send.</param>
		/// <param name="asyncContinuation">The asynchronous continuation.</param>
		// Token: 0x060002E5 RID: 741 RVA: 0x0000B424 File Offset: 0x00009624
		public void Send(byte[] bytes, int offset, int length, AsyncContinuation asyncContinuation)
		{
			this.LastSendTime = Interlocked.Increment(ref NetworkSender.currentSendTime);
			this.DoSend(bytes, offset, length, asyncContinuation);
		}

		/// <summary>
		/// Closes the sender and releases any unmanaged resources.
		/// </summary>
		// Token: 0x060002E6 RID: 742 RVA: 0x0000B444 File Offset: 0x00009644
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// Performs sender-specific initialization.
		/// </summary>
		// Token: 0x060002E7 RID: 743 RVA: 0x0000B456 File Offset: 0x00009656
		protected virtual void DoInitialize()
		{
		}

		/// <summary>
		/// Performs sender-specific close operation.
		/// </summary>
		/// <param name="continuation">The continuation.</param>
		// Token: 0x060002E8 RID: 744 RVA: 0x0000B459 File Offset: 0x00009659
		protected virtual void DoClose(AsyncContinuation continuation)
		{
			continuation(null);
		}

		/// <summary>
		/// Performs sender-specific flush.
		/// </summary>
		/// <param name="continuation">The continuation.</param>
		// Token: 0x060002E9 RID: 745 RVA: 0x0000B464 File Offset: 0x00009664
		protected virtual void DoFlush(AsyncContinuation continuation)
		{
			continuation(null);
		}

		/// <summary>
		/// Actually sends the given text over the specified protocol.
		/// </summary>
		/// <param name="bytes">The bytes to be sent.</param>
		/// <param name="offset">Offset in buffer.</param>
		/// <param name="length">Number of bytes to send.</param>
		/// <param name="asyncContinuation">The async continuation to be invoked after the buffer has been sent.</param>
		/// <remarks>To be overridden in inheriting classes.</remarks>
		// Token: 0x060002EA RID: 746
		protected abstract void DoSend(byte[] bytes, int offset, int length, AsyncContinuation asyncContinuation);

		/// <summary>
		/// Parses the URI into an endpoint address.
		/// </summary>
		/// <param name="uri">The URI to parse.</param>
		/// <param name="addressFamily">The address family.</param>
		/// <returns>Parsed endpoint.</returns>
		// Token: 0x060002EB RID: 747 RVA: 0x0000B470 File Offset: 0x00009670
		protected virtual EndPoint ParseEndpointAddress(Uri uri, AddressFamily addressFamily)
		{
			EndPoint endPoint;
			switch (uri.HostNameType)
			{
			case UriHostNameType.IPv4:
			case UriHostNameType.IPv6:
				endPoint = new IPEndPoint(IPAddress.Parse(uri.Host), uri.Port);
				break;
			default:
			{
				IPAddress[] addressList = Dns.GetHostEntry(uri.Host).AddressList;
				foreach (IPAddress ipaddress in addressList)
				{
					if (ipaddress.AddressFamily == addressFamily || addressFamily == AddressFamily.Unspecified)
					{
						return new IPEndPoint(ipaddress, uri.Port);
					}
				}
				throw new IOException(string.Concat(new object[] { "Cannot resolve '", uri.Host, "' to an address in '", addressFamily, "'" }));
			}
			}
			return endPoint;
		}

		// Token: 0x060002EC RID: 748 RVA: 0x0000B560 File Offset: 0x00009760
		private void Dispose(bool disposing)
		{
			if (disposing)
			{
				this.Close(delegate(Exception ex)
				{
				});
			}
		}

		// Token: 0x040000BC RID: 188
		private static int currentSendTime;
	}
}
