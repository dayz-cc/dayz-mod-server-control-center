using System;
using System.Net.Sockets;

namespace NLog.Internal.NetworkSenders
{
	/// <summary>
	/// Default implementation of <see cref="T:NLog.Internal.NetworkSenders.INetworkSenderFactory" />.
	/// </summary>
	// Token: 0x02000077 RID: 119
	internal class NetworkSenderFactory : INetworkSenderFactory
	{
		/// <summary>
		/// Creates a new instance of the network sender based on a network URL:.
		/// </summary>
		/// <param name="url">
		/// URL that determines the network sender to be created.
		/// </param>
		/// <param name="maxQueueSize">
		/// The maximum queue size.
		/// </param>
		/// /// <returns>
		/// A newly created network sender.
		/// </returns>
		// Token: 0x060002F5 RID: 757 RVA: 0x0000B75C File Offset: 0x0000995C
		public NetworkSender Create(string url, int maxQueueSize)
		{
			NetworkSender networkSender;
			if (url.StartsWith("http://", StringComparison.OrdinalIgnoreCase))
			{
				networkSender = new HttpNetworkSender(url);
			}
			else if (url.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
			{
				networkSender = new HttpNetworkSender(url);
			}
			else if (url.StartsWith("tcp://", StringComparison.OrdinalIgnoreCase))
			{
				networkSender = new TcpNetworkSender(url, AddressFamily.Unspecified)
				{
					MaxQueueSize = maxQueueSize
				};
			}
			else if (url.StartsWith("tcp4://", StringComparison.OrdinalIgnoreCase))
			{
				networkSender = new TcpNetworkSender(url, AddressFamily.InterNetwork)
				{
					MaxQueueSize = maxQueueSize
				};
			}
			else if (url.StartsWith("tcp6://", StringComparison.OrdinalIgnoreCase))
			{
				networkSender = new TcpNetworkSender(url, AddressFamily.InterNetworkV6)
				{
					MaxQueueSize = maxQueueSize
				};
			}
			else if (url.StartsWith("udp://", StringComparison.OrdinalIgnoreCase))
			{
				networkSender = new UdpNetworkSender(url, AddressFamily.Unspecified);
			}
			else if (url.StartsWith("udp4://", StringComparison.OrdinalIgnoreCase))
			{
				networkSender = new UdpNetworkSender(url, AddressFamily.InterNetwork);
			}
			else
			{
				if (!url.StartsWith("udp6://", StringComparison.OrdinalIgnoreCase))
				{
					throw new ArgumentException("Unrecognized network address", "url");
				}
				networkSender = new UdpNetworkSender(url, AddressFamily.InterNetworkV6);
			}
			return networkSender;
		}

		// Token: 0x040000C0 RID: 192
		public static readonly INetworkSenderFactory Default = new NetworkSenderFactory();
	}
}
