using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Threading;
using NLog.Common;
using NLog.Internal.NetworkSenders;
using NLog.Layouts;

namespace NLog.Targets
{
	/// <summary>
	/// Sends log messages over the network.
	/// </summary>
	/// <seealso href="http://nlog-project.org/wiki/Network_target">Documentation on NLog Wiki</seealso>
	/// <example>
	/// <p>
	/// To set up the target in the <a href="config.html">configuration file</a>, 
	/// use the following syntax:
	/// </p>
	/// <code lang="XML" source="examples/targets/Configuration File/Network/NLog.config" />
	/// <p>
	/// This assumes just one target and a single rule. More configuration
	/// options are described <a href="config.html">here</a>.
	/// </p>
	/// <p>
	/// To set up the log target programmatically use code like this:
	/// </p>
	/// <code lang="C#" source="examples/targets/Configuration API/Network/Simple/Example.cs" />
	/// <p>
	/// To print the results, use any application that's able to receive messages over
	/// TCP or UDP. <a href="http://m.nu/program/util/netcat/netcat.html">NetCat</a> is
	/// a simple but very powerful command-line tool that can be used for that. This image
	/// demonstrates the NetCat tool receiving log messages from Network target.
	/// </p>
	/// <img src="examples/targets/Screenshots/Network/Output.gif" />
	/// <p>
	/// NOTE: If your receiver application is ever likely to be off-line, don't use TCP protocol
	/// or you'll get TCP timeouts and your application will be very slow. 
	/// Either switch to UDP transport or use <a href="target.AsyncWrapper.html">AsyncWrapper</a> target
	/// so that your application threads will not be blocked by the timing-out connection attempts.
	/// </p>
	/// <p>
	/// There are two specialized versions of the Network target: <a href="target.Chainsaw.html">Chainsaw</a>
	/// and <a href="target.NLogViewer.html">NLogViewer</a> which write to instances of Chainsaw log4j viewer
	/// or NLogViewer application respectively.
	/// </p>
	/// </example>
	// Token: 0x02000101 RID: 257
	[Target("Network")]
	public class NetworkTarget : TargetWithLayout
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Targets.NetworkTarget" /> class.
		/// </summary>
		/// <remarks>
		/// The default value of the layout is: <code>${longdate}|${level:uppercase=true}|${logger}|${message}</code>
		/// </remarks>
		// Token: 0x060007DA RID: 2010 RVA: 0x0001BBC0 File Offset: 0x00019DC0
		public NetworkTarget()
		{
			this.SenderFactory = NetworkSenderFactory.Default;
			this.Encoding = Encoding.UTF8;
			this.OnOverflow = NetworkTargetOverflowAction.Split;
			this.KeepConnection = true;
			this.MaxMessageSize = 65000;
			this.ConnectionCacheSize = 5;
		}

		/// <summary>
		/// Gets or sets the network address.
		/// </summary>
		/// <remarks>
		/// The network address can be:
		/// <ul>
		/// <li>tcp://host:port - TCP (auto select IPv4/IPv6) (not supported on Windows Phone 7.0)</li>
		/// <li>tcp4://host:port - force TCP/IPv4 (not supported on Windows Phone 7.0)</li>
		/// <li>tcp6://host:port - force TCP/IPv6 (not supported on Windows Phone 7.0)</li>
		/// <li>udp://host:port - UDP (auto select IPv4/IPv6, not supported on Silverlight and on Windows Phone 7.0)</li>
		/// <li>udp4://host:port - force UDP/IPv4 (not supported on Silverlight and on Windows Phone 7.0)</li>
		/// <li>udp6://host:port - force UDP/IPv6  (not supported on Silverlight and on Windows Phone 7.0)</li>
		/// <li>http://host:port/pageName - HTTP using POST verb</li>
		/// <li>https://host:port/pageName - HTTPS using POST verb</li>
		/// </ul>
		/// For SOAP-based webservice support over HTTP use WebService target.
		/// </remarks>
		/// <docgen category="Connection Options" order="10" />
		// Token: 0x1700016E RID: 366
		// (get) Token: 0x060007DB RID: 2011 RVA: 0x0001BC28 File Offset: 0x00019E28
		// (set) Token: 0x060007DC RID: 2012 RVA: 0x0001BC3F File Offset: 0x00019E3F
		public Layout Address { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether to keep connection open whenever possible.
		/// </summary>
		/// <docgen category="Connection Options" order="10" />
		// Token: 0x1700016F RID: 367
		// (get) Token: 0x060007DD RID: 2013 RVA: 0x0001BC48 File Offset: 0x00019E48
		// (set) Token: 0x060007DE RID: 2014 RVA: 0x0001BC5F File Offset: 0x00019E5F
		[DefaultValue(true)]
		public bool KeepConnection { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether to append newline at the end of log message.
		/// </summary>
		/// <docgen category="Layout Options" order="10" />
		// Token: 0x17000170 RID: 368
		// (get) Token: 0x060007DF RID: 2015 RVA: 0x0001BC68 File Offset: 0x00019E68
		// (set) Token: 0x060007E0 RID: 2016 RVA: 0x0001BC7F File Offset: 0x00019E7F
		[DefaultValue(false)]
		public bool NewLine { get; set; }

		/// <summary>
		/// Gets or sets the maximum message size in bytes.
		/// </summary>
		/// <docgen category="Layout Options" order="10" />
		// Token: 0x17000171 RID: 369
		// (get) Token: 0x060007E1 RID: 2017 RVA: 0x0001BC88 File Offset: 0x00019E88
		// (set) Token: 0x060007E2 RID: 2018 RVA: 0x0001BC9F File Offset: 0x00019E9F
		[DefaultValue(65000)]
		public int MaxMessageSize { get; set; }

		/// <summary>
		/// Gets or sets the size of the connection cache (number of connections which are kept alive).
		/// </summary>
		/// <docgen category="Connection Options" order="10" />
		// Token: 0x17000172 RID: 370
		// (get) Token: 0x060007E3 RID: 2019 RVA: 0x0001BCA8 File Offset: 0x00019EA8
		// (set) Token: 0x060007E4 RID: 2020 RVA: 0x0001BCBF File Offset: 0x00019EBF
		[DefaultValue(5)]
		public int ConnectionCacheSize { get; set; }

		/// <summary>
		/// Gets or sets the maximum queue size.
		/// </summary>
		// Token: 0x17000173 RID: 371
		// (get) Token: 0x060007E5 RID: 2021 RVA: 0x0001BCC8 File Offset: 0x00019EC8
		// (set) Token: 0x060007E6 RID: 2022 RVA: 0x0001BCDF File Offset: 0x00019EDF
		[DefaultValue(0)]
		public int MaxQueueSize { get; set; }

		/// <summary>
		/// Gets or sets the action that should be taken if the message is larger than
		/// maxMessageSize.
		/// </summary>
		/// <docgen category="Layout Options" order="10" />
		// Token: 0x17000174 RID: 372
		// (get) Token: 0x060007E7 RID: 2023 RVA: 0x0001BCE8 File Offset: 0x00019EE8
		// (set) Token: 0x060007E8 RID: 2024 RVA: 0x0001BCFF File Offset: 0x00019EFF
		public NetworkTargetOverflowAction OnOverflow { get; set; }

		/// <summary>
		/// Gets or sets the encoding to be used.
		/// </summary>
		/// <docgen category="Layout Options" order="10" />
		// Token: 0x17000175 RID: 373
		// (get) Token: 0x060007E9 RID: 2025 RVA: 0x0001BD08 File Offset: 0x00019F08
		// (set) Token: 0x060007EA RID: 2026 RVA: 0x0001BD1F File Offset: 0x00019F1F
		[DefaultValue("utf-8")]
		public Encoding Encoding { get; set; }

		// Token: 0x17000176 RID: 374
		// (get) Token: 0x060007EB RID: 2027 RVA: 0x0001BD28 File Offset: 0x00019F28
		// (set) Token: 0x060007EC RID: 2028 RVA: 0x0001BD3F File Offset: 0x00019F3F
		internal INetworkSenderFactory SenderFactory { get; set; }

		/// <summary>
		/// Flush any pending log messages asynchronously (in case of asynchronous targets).
		/// </summary>
		/// <param name="asyncContinuation">The asynchronous continuation.</param>
		// Token: 0x060007ED RID: 2029 RVA: 0x0001BD84 File Offset: 0x00019F84
		protected override void FlushAsync(AsyncContinuation asyncContinuation)
		{
			int remainingCount = 0;
			AsyncContinuation asyncContinuation2 = delegate(Exception ex)
			{
				if (Interlocked.Decrement(ref remainingCount) == 0)
				{
					asyncContinuation(null);
				}
			};
			lock (this.openNetworkSenders)
			{
				remainingCount = this.openNetworkSenders.Count;
				if (remainingCount == 0)
				{
					asyncContinuation(null);
				}
				else
				{
					foreach (NetworkSender networkSender in this.openNetworkSenders)
					{
						networkSender.FlushAsync(asyncContinuation2);
					}
				}
			}
		}

		/// <summary>
		/// Closes the target.
		/// </summary>
		// Token: 0x060007EE RID: 2030 RVA: 0x0001BE78 File Offset: 0x0001A078
		protected override void CloseTarget()
		{
			base.CloseTarget();
			lock (this.openNetworkSenders)
			{
				foreach (NetworkSender networkSender in this.openNetworkSenders)
				{
					networkSender.Close(delegate(Exception ex)
					{
					});
				}
				this.openNetworkSenders.Clear();
			}
		}

		/// <summary>
		/// Sends the 
		/// rendered logging event over the network optionally concatenating it with a newline character.
		/// </summary>
		/// <param name="logEvent">The logging event.</param>
		// Token: 0x060007EF RID: 2031 RVA: 0x0001C084 File Offset: 0x0001A284
		protected override void Write(AsyncLogEventInfo logEvent)
		{
			string text = this.Address.Render(logEvent.LogEvent);
			byte[] bytesToWrite = this.GetBytesToWrite(logEvent.LogEvent);
			if (this.KeepConnection)
			{
				NetworkSender sender2 = this.GetCachedNetworkSender(text);
				this.ChunkedSend(sender2, bytesToWrite, delegate(Exception ex)
				{
					if (ex != null)
					{
						InternalLogger.Error("Error when sending {0}", new object[] { ex });
						this.ReleaseCachedConnection(sender2);
					}
					logEvent.Continuation(ex);
				});
			}
			else
			{
				NetworkSender sender = this.SenderFactory.Create(text, this.MaxQueueSize);
				sender.Initialize();
				lock (this.openNetworkSenders)
				{
					this.openNetworkSenders.Add(sender);
					this.ChunkedSend(sender, bytesToWrite, delegate(Exception ex)
					{
						lock (this.openNetworkSenders)
						{
							this.openNetworkSenders.Remove(sender);
						}
						if (ex != null)
						{
							InternalLogger.Error("Error when sending {0}", new object[] { ex });
						}
						sender.Close(delegate(Exception ex2)
						{
						});
						logEvent.Continuation(ex);
					});
				}
			}
		}

		/// <summary>
		/// Gets the bytes to be written.
		/// </summary>
		/// <param name="logEvent">Log event.</param>
		/// <returns>Byte array.</returns>
		// Token: 0x060007F0 RID: 2032 RVA: 0x0001C1D0 File Offset: 0x0001A3D0
		protected virtual byte[] GetBytesToWrite(LogEventInfo logEvent)
		{
			string text;
			if (this.NewLine)
			{
				text = this.Layout.Render(logEvent) + "\r\n";
			}
			else
			{
				text = this.Layout.Render(logEvent);
			}
			return this.Encoding.GetBytes(text);
		}

		// Token: 0x060007F1 RID: 2033 RVA: 0x0001C228 File Offset: 0x0001A428
		private NetworkSender GetCachedNetworkSender(string address)
		{
			NetworkSender networkSender2;
			lock (this.currentSenderCache)
			{
				NetworkSender networkSender;
				if (this.currentSenderCache.TryGetValue(address, out networkSender))
				{
					networkSender2 = networkSender;
				}
				else
				{
					if (this.currentSenderCache.Count >= this.ConnectionCacheSize)
					{
						int num = int.MaxValue;
						NetworkSender networkSender3 = null;
						foreach (KeyValuePair<string, NetworkSender> keyValuePair in this.currentSenderCache)
						{
							if (keyValuePair.Value.LastSendTime < num)
							{
								num = keyValuePair.Value.LastSendTime;
								networkSender3 = keyValuePair.Value;
							}
						}
						if (networkSender3 != null)
						{
							this.ReleaseCachedConnection(networkSender3);
						}
					}
					networkSender = this.SenderFactory.Create(address, this.MaxQueueSize);
					networkSender.Initialize();
					lock (this.openNetworkSenders)
					{
						this.openNetworkSenders.Add(networkSender);
					}
					this.currentSenderCache.Add(address, networkSender);
					networkSender2 = networkSender;
				}
			}
			return networkSender2;
		}

		// Token: 0x060007F2 RID: 2034 RVA: 0x0001C3DC File Offset: 0x0001A5DC
		private void ReleaseCachedConnection(NetworkSender sender)
		{
			lock (this.currentSenderCache)
			{
				lock (this.openNetworkSenders)
				{
					if (this.openNetworkSenders.Remove(sender))
					{
						sender.Close(delegate(Exception ex)
						{
						});
					}
				}
				NetworkSender networkSender;
				if (this.currentSenderCache.TryGetValue(sender.Address, out networkSender))
				{
					if (object.ReferenceEquals(sender, networkSender))
					{
						this.currentSenderCache.Remove(sender.Address);
					}
				}
			}
		}

		// Token: 0x060007F3 RID: 2035 RVA: 0x0001C630 File Offset: 0x0001A830
		[SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", Justification = "Using property names in message.")]
		private void ChunkedSend(NetworkSender sender, byte[] buffer, AsyncContinuation continuation)
		{
			int tosend = buffer.Length;
			int pos = 0;
			AsyncContinuation sendNextChunk = null;
			sendNextChunk = delegate(Exception ex)
			{
				if (ex != null)
				{
					continuation(ex);
				}
				else if (tosend <= 0)
				{
					continuation(null);
				}
				else
				{
					int num = tosend;
					if (num > this.MaxMessageSize)
					{
						if (this.OnOverflow == NetworkTargetOverflowAction.Discard)
						{
							continuation(null);
							return;
						}
						if (this.OnOverflow == NetworkTargetOverflowAction.Error)
						{
							continuation(new OverflowException(string.Concat(new object[] { "Attempted to send a message larger than MaxMessageSize (", this.MaxMessageSize, "). Actual size was: ", buffer.Length, ". Adjust OnOverflow and MaxMessageSize parameters accordingly." })));
							return;
						}
						num = this.MaxMessageSize;
					}
					int pos2 = pos;
					tosend -= num;
					pos += num;
					sender.Send(buffer, pos2, num, sendNextChunk);
				}
			};
			sendNextChunk(null);
		}

		// Token: 0x04000240 RID: 576
		private Dictionary<string, NetworkSender> currentSenderCache = new Dictionary<string, NetworkSender>();

		// Token: 0x04000241 RID: 577
		private List<NetworkSender> openNetworkSenders = new List<NetworkSender>();
	}
}
