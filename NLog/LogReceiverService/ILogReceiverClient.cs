using System;
using System.ServiceModel;

namespace NLog.LogReceiverService
{
	/// <summary>
	/// Service contract for Log Receiver client.
	/// </summary>
	// Token: 0x020000ED RID: 237
	[ServiceContract(Namespace = "http://nlog-project.org/ws/", ConfigurationName = "NLog.LogReceiverService.ILogReceiverClient")]
	public interface ILogReceiverClient
	{
		/// <summary>
		/// Begins processing of log messages.
		/// </summary>
		/// <param name="events">The events.</param>
		/// <param name="callback">The callback.</param>
		/// <param name="asyncState">Asynchronous state.</param>
		/// <returns>
		/// IAsyncResult value which can be passed to <see cref="M:NLog.LogReceiverService.ILogReceiverClient.EndProcessLogMessages(System.IAsyncResult)" />.
		/// </returns>
		// Token: 0x06000739 RID: 1849
		[OperationContract(AsyncPattern = true, Action = "http://nlog-project.org/ws/ILogReceiverServer/ProcessLogMessages", ReplyAction = "http://nlog-project.org/ws/ILogReceiverServer/ProcessLogMessagesResponse")]
		IAsyncResult BeginProcessLogMessages(NLogEvents events, AsyncCallback callback, object asyncState);

		/// <summary>
		/// Ends asynchronous processing of log messages.
		/// </summary>
		/// <param name="result">The result.</param>
		// Token: 0x0600073A RID: 1850
		void EndProcessLogMessages(IAsyncResult result);
	}
}
