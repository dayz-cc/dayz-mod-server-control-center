using System;

namespace NLog.Internal.NetworkSenders
{
	/// <summary>
	/// Creates instances of <see cref="T:NLog.Internal.NetworkSenders.NetworkSender" /> objects for given URLs.
	/// </summary>
	// Token: 0x02000075 RID: 117
	internal interface INetworkSenderFactory
	{
		/// <summary>
		/// Creates a new instance of the network sender based on a network URL.
		/// </summary>
		/// <param name="url">
		/// URL that determines the network sender to be created.
		/// </param>
		/// <param name="maxQueueSize">
		/// The maximum queue size.
		/// </param>
		/// <returns>
		/// A newly created network sender.
		/// </returns>
		// Token: 0x060002F0 RID: 752
		NetworkSender Create(string url, int maxQueueSize);
	}
}
