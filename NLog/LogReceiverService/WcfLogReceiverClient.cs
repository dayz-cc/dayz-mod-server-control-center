using System;
using System.ComponentModel;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading;

namespace NLog.LogReceiverService
{
	/// <summary>
	/// Log Receiver Client using WCF.
	/// </summary>
	// Token: 0x020000F4 RID: 244
	public sealed class WcfLogReceiverClient : ClientBase<ILogReceiverClient>, ILogReceiverClient
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.LogReceiverService.WcfLogReceiverClient" /> class.
		/// </summary>
		// Token: 0x0600075E RID: 1886 RVA: 0x0001A328 File Offset: 0x00018528
		public WcfLogReceiverClient()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.LogReceiverService.WcfLogReceiverClient" /> class.
		/// </summary>
		/// <param name="endpointConfigurationName">Name of the endpoint configuration.</param>
		// Token: 0x0600075F RID: 1887 RVA: 0x0001A333 File Offset: 0x00018533
		public WcfLogReceiverClient(string endpointConfigurationName)
			: base(endpointConfigurationName)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.LogReceiverService.WcfLogReceiverClient" /> class.
		/// </summary>
		/// <param name="endpointConfigurationName">Name of the endpoint configuration.</param>
		/// <param name="remoteAddress">The remote address.</param>
		// Token: 0x06000760 RID: 1888 RVA: 0x0001A33F File Offset: 0x0001853F
		public WcfLogReceiverClient(string endpointConfigurationName, string remoteAddress)
			: base(endpointConfigurationName, remoteAddress)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.LogReceiverService.WcfLogReceiverClient" /> class.
		/// </summary>
		/// <param name="endpointConfigurationName">Name of the endpoint configuration.</param>
		/// <param name="remoteAddress">The remote address.</param>
		// Token: 0x06000761 RID: 1889 RVA: 0x0001A34C File Offset: 0x0001854C
		public WcfLogReceiverClient(string endpointConfigurationName, EndpointAddress remoteAddress)
			: base(endpointConfigurationName, remoteAddress)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.LogReceiverService.WcfLogReceiverClient" /> class.
		/// </summary>
		/// <param name="binding">The binding.</param>
		/// <param name="remoteAddress">The remote address.</param>
		// Token: 0x06000762 RID: 1890 RVA: 0x0001A359 File Offset: 0x00018559
		public WcfLogReceiverClient(Binding binding, EndpointAddress remoteAddress)
			: base(binding, remoteAddress)
		{
		}

		/// <summary>
		/// Occurs when the log message processing has completed.
		/// </summary>
		// Token: 0x1400000B RID: 11
		// (add) Token: 0x06000763 RID: 1891 RVA: 0x0001A368 File Offset: 0x00018568
		// (remove) Token: 0x06000764 RID: 1892 RVA: 0x0001A3A4 File Offset: 0x000185A4
		public event EventHandler<AsyncCompletedEventArgs> ProcessLogMessagesCompleted;

		/// <summary>
		/// Occurs when Open operation has completed.
		/// </summary>
		// Token: 0x1400000C RID: 12
		// (add) Token: 0x06000765 RID: 1893 RVA: 0x0001A3E0 File Offset: 0x000185E0
		// (remove) Token: 0x06000766 RID: 1894 RVA: 0x0001A41C File Offset: 0x0001861C
		public event EventHandler<AsyncCompletedEventArgs> OpenCompleted;

		/// <summary>
		/// Occurs when Close operation has completed.
		/// </summary>
		// Token: 0x1400000D RID: 13
		// (add) Token: 0x06000767 RID: 1895 RVA: 0x0001A458 File Offset: 0x00018658
		// (remove) Token: 0x06000768 RID: 1896 RVA: 0x0001A494 File Offset: 0x00018694
		public event EventHandler<AsyncCompletedEventArgs> CloseCompleted;

		/// <summary>
		/// Opens the client asynchronously.
		/// </summary>
		// Token: 0x06000769 RID: 1897 RVA: 0x0001A4D0 File Offset: 0x000186D0
		public void OpenAsync()
		{
			this.OpenAsync(null);
		}

		/// <summary>
		/// Opens the client asynchronously.
		/// </summary>
		/// <param name="userState">User-specific state.</param>
		// Token: 0x0600076A RID: 1898 RVA: 0x0001A4DB File Offset: 0x000186DB
		public void OpenAsync(object userState)
		{
			base.InvokeAsync(new ClientBase<ILogReceiverClient>.BeginOperationDelegate(this.OnBeginOpen), null, new ClientBase<ILogReceiverClient>.EndOperationDelegate(this.OnEndOpen), new SendOrPostCallback(this.OnOpenCompleted), userState);
		}

		/// <summary>
		/// Closes the client asynchronously.
		/// </summary>
		// Token: 0x0600076B RID: 1899 RVA: 0x0001A50B File Offset: 0x0001870B
		public void CloseAsync()
		{
			this.CloseAsync(null);
		}

		/// <summary>
		/// Closes the client asynchronously.
		/// </summary>
		/// <param name="userState">User-specific state.</param>
		// Token: 0x0600076C RID: 1900 RVA: 0x0001A516 File Offset: 0x00018716
		public void CloseAsync(object userState)
		{
			base.InvokeAsync(new ClientBase<ILogReceiverClient>.BeginOperationDelegate(this.OnBeginClose), null, new ClientBase<ILogReceiverClient>.EndOperationDelegate(this.OnEndClose), new SendOrPostCallback(this.OnCloseCompleted), userState);
		}

		/// <summary>
		/// Processes the log messages asynchronously.
		/// </summary>
		/// <param name="events">The events to send.</param>
		// Token: 0x0600076D RID: 1901 RVA: 0x0001A546 File Offset: 0x00018746
		public void ProcessLogMessagesAsync(NLogEvents events)
		{
			this.ProcessLogMessagesAsync(events, null);
		}

		/// <summary>
		/// Processes the log messages asynchronously.
		/// </summary>
		/// <param name="events">The events to send.</param>
		/// <param name="userState">User-specific state.</param>
		// Token: 0x0600076E RID: 1902 RVA: 0x0001A554 File Offset: 0x00018754
		public void ProcessLogMessagesAsync(NLogEvents events, object userState)
		{
			base.InvokeAsync(new ClientBase<ILogReceiverClient>.BeginOperationDelegate(this.OnBeginProcessLogMessages), new object[] { events }, new ClientBase<ILogReceiverClient>.EndOperationDelegate(this.OnEndProcessLogMessages), new SendOrPostCallback(this.OnProcessLogMessagesCompleted), userState);
		}

		/// <summary>
		/// Begins processing of log messages.
		/// </summary>
		/// <param name="events">The events to send.</param>
		/// <param name="callback">The callback.</param>
		/// <param name="asyncState">Asynchronous state.</param>
		/// <returns>
		/// IAsyncResult value which can be passed to <see cref="M:NLog.LogReceiverService.ILogReceiverClient.EndProcessLogMessages(System.IAsyncResult)" />.
		/// </returns>
		// Token: 0x0600076F RID: 1903 RVA: 0x0001A59C File Offset: 0x0001879C
		IAsyncResult ILogReceiverClient.BeginProcessLogMessages(NLogEvents events, AsyncCallback callback, object asyncState)
		{
			return base.Channel.BeginProcessLogMessages(events, callback, asyncState);
		}

		/// <summary>
		/// Ends asynchronous processing of log messages.
		/// </summary>
		/// <param name="result">The result.</param>
		// Token: 0x06000770 RID: 1904 RVA: 0x0001A5BC File Offset: 0x000187BC
		void ILogReceiverClient.EndProcessLogMessages(IAsyncResult result)
		{
			base.Channel.EndProcessLogMessages(result);
		}

		// Token: 0x06000771 RID: 1905 RVA: 0x0001A5CC File Offset: 0x000187CC
		private IAsyncResult OnBeginProcessLogMessages(object[] inValues, AsyncCallback callback, object asyncState)
		{
			NLogEvents nlogEvents = (NLogEvents)inValues[0];
			return ((ILogReceiverClient)this).BeginProcessLogMessages(nlogEvents, callback, asyncState);
		}

		// Token: 0x06000772 RID: 1906 RVA: 0x0001A5F0 File Offset: 0x000187F0
		private object[] OnEndProcessLogMessages(IAsyncResult result)
		{
			((ILogReceiverClient)this).EndProcessLogMessages(result);
			return null;
		}

		// Token: 0x06000773 RID: 1907 RVA: 0x0001A60C File Offset: 0x0001880C
		private void OnProcessLogMessagesCompleted(object state)
		{
			if (this.ProcessLogMessagesCompleted != null)
			{
				ClientBase<ILogReceiverClient>.InvokeAsyncCompletedEventArgs invokeAsyncCompletedEventArgs = (ClientBase<ILogReceiverClient>.InvokeAsyncCompletedEventArgs)state;
				this.ProcessLogMessagesCompleted(this, new AsyncCompletedEventArgs(invokeAsyncCompletedEventArgs.Error, invokeAsyncCompletedEventArgs.Cancelled, invokeAsyncCompletedEventArgs.UserState));
			}
		}

		// Token: 0x06000774 RID: 1908 RVA: 0x0001A654 File Offset: 0x00018854
		private IAsyncResult OnBeginOpen(object[] inValues, AsyncCallback callback, object asyncState)
		{
			return this.BeginOpen(callback, asyncState);
		}

		// Token: 0x06000775 RID: 1909 RVA: 0x0001A670 File Offset: 0x00018870
		private object[] OnEndOpen(IAsyncResult result)
		{
			this.EndOpen(result);
			return null;
		}

		// Token: 0x06000776 RID: 1910 RVA: 0x0001A68C File Offset: 0x0001888C
		private void OnOpenCompleted(object state)
		{
			if (this.OpenCompleted != null)
			{
				ClientBase<ILogReceiverClient>.InvokeAsyncCompletedEventArgs invokeAsyncCompletedEventArgs = (ClientBase<ILogReceiverClient>.InvokeAsyncCompletedEventArgs)state;
				this.OpenCompleted(this, new AsyncCompletedEventArgs(invokeAsyncCompletedEventArgs.Error, invokeAsyncCompletedEventArgs.Cancelled, invokeAsyncCompletedEventArgs.UserState));
			}
		}

		// Token: 0x06000777 RID: 1911 RVA: 0x0001A6D4 File Offset: 0x000188D4
		private IAsyncResult OnBeginClose(object[] inValues, AsyncCallback callback, object asyncState)
		{
			return this.BeginClose(callback, asyncState);
		}

		// Token: 0x06000778 RID: 1912 RVA: 0x0001A6F0 File Offset: 0x000188F0
		private object[] OnEndClose(IAsyncResult result)
		{
			this.EndClose(result);
			return null;
		}

		// Token: 0x06000779 RID: 1913 RVA: 0x0001A70C File Offset: 0x0001890C
		private void OnCloseCompleted(object state)
		{
			if (this.CloseCompleted != null)
			{
				ClientBase<ILogReceiverClient>.InvokeAsyncCompletedEventArgs invokeAsyncCompletedEventArgs = (ClientBase<ILogReceiverClient>.InvokeAsyncCompletedEventArgs)state;
				this.CloseCompleted(this, new AsyncCompletedEventArgs(invokeAsyncCompletedEventArgs.Error, invokeAsyncCompletedEventArgs.Cancelled, invokeAsyncCompletedEventArgs.UserState));
			}
		}
	}
}
