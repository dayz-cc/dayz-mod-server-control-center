using System;
using System.IO;
using System.Net;
using NLog.Common;

namespace NLog.Internal.NetworkSenders
{
	/// <summary>
	/// Network sender which uses HTTP or HTTPS POST.
	/// </summary>
	// Token: 0x02000074 RID: 116
	internal class HttpNetworkSender : NetworkSender
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Internal.NetworkSenders.HttpNetworkSender" /> class.
		/// </summary>
		/// <param name="url">The network URL.</param>
		// Token: 0x060002EE RID: 750 RVA: 0x0000B59E File Offset: 0x0000979E
		public HttpNetworkSender(string url)
			: base(url)
		{
		}

		/// <summary>
		/// Actually sends the given text over the specified protocol.
		/// </summary>
		/// <param name="bytes">The bytes to be sent.</param>
		/// <param name="offset">Offset in buffer.</param>
		/// <param name="length">Number of bytes to send.</param>
		/// <param name="asyncContinuation">The async continuation to be invoked after the buffer has been sent.</param>
		/// <remarks>To be overridden in inheriting classes.</remarks>
		// Token: 0x060002EF RID: 751 RVA: 0x0000B6D4 File Offset: 0x000098D4
		protected override void DoSend(byte[] bytes, int offset, int length, AsyncContinuation asyncContinuation)
		{
			WebRequest webRequest = WebRequest.Create(new Uri(base.Address));
			webRequest.Method = "POST";
			AsyncCallback onResponse = delegate(IAsyncResult r)
			{
				try
				{
					using (webRequest.EndGetResponse(r))
					{
					}
					asyncContinuation(null);
				}
				catch (Exception ex)
				{
					if (ex.MustBeRethrown())
					{
						throw;
					}
					asyncContinuation(ex);
				}
			};
			AsyncCallback asyncCallback = delegate(IAsyncResult r)
			{
				try
				{
					using (Stream stream = webRequest.EndGetRequestStream(r))
					{
						stream.Write(bytes, offset, length);
					}
					webRequest.BeginGetResponse(onResponse, null);
				}
				catch (Exception ex2)
				{
					if (ex2.MustBeRethrown())
					{
						throw;
					}
					asyncContinuation(ex2);
				}
			};
			webRequest.BeginGetRequestStream(asyncCallback, null);
		}
	}
}
