using System;
using System.ServiceModel;

namespace NLog.LogReceiverService
{
	/// <summary>
	/// Service contract for Log Receiver server.
	/// </summary>
	// Token: 0x020000EE RID: 238
	[ServiceContract(Namespace = "http://nlog-project.org/ws/")]
	public interface ILogReceiverServer
	{
		/// <summary>
		/// Processes the log messages.
		/// </summary>
		/// <param name="events">The events.</param>
		// Token: 0x0600073B RID: 1851
		[OperationContract]
		void ProcessLogMessages(NLogEvents events);
	}
}
