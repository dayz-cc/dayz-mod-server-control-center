using System;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Net;
using System.Text;
using System.Xml;
using NLog.Common;
using NLog.Internal;

namespace NLog.Targets
{
	/// <summary>
	/// Calls the specified web service on each log message.
	/// </summary>
	/// <seealso href="http://nlog-project.org/wiki/WebService_target">Documentation on NLog Wiki</seealso>
	/// <remarks>
	/// The web service must implement a method that accepts a number of string parameters.
	/// </remarks>
	/// <example>
	/// <p>
	/// To set up the target in the <a href="config.html">configuration file</a>, 
	/// use the following syntax:
	/// </p>
	/// <code lang="XML" source="examples/targets/Configuration File/WebService/NLog.config" />
	/// <p>
	/// This assumes just one target and a single rule. More configuration
	/// options are described <a href="config.html">here</a>.
	/// </p>
	/// <p>
	/// To set up the log target programmatically use code like this:
	/// </p>
	/// <code lang="C#" source="examples/targets/Configuration API/WebService/Simple/Example.cs" />
	/// <p>The example web service that works with this example is shown below</p>
	/// <code lang="C#" source="examples/targets/Configuration API/WebService/Simple/WebService1/Service1.asmx.cs" />
	/// </example>
	// Token: 0x0200012C RID: 300
	[Target("WebService")]
	public sealed class WebServiceTarget : MethodCallTargetBase
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Targets.WebServiceTarget" /> class.
		/// </summary>
		// Token: 0x060009F0 RID: 2544 RVA: 0x0002316D File Offset: 0x0002136D
		public WebServiceTarget()
		{
			this.Protocol = WebServiceProtocol.Soap11;
			this.Encoding = Encoding.UTF8;
		}

		/// <summary>
		/// Gets or sets the web service URL.
		/// </summary>
		/// <docgen category="Web Service Options" order="10" />
		// Token: 0x1700021F RID: 543
		// (get) Token: 0x060009F1 RID: 2545 RVA: 0x0002318C File Offset: 0x0002138C
		// (set) Token: 0x060009F2 RID: 2546 RVA: 0x000231A3 File Offset: 0x000213A3
		public Uri Url { get; set; }

		/// <summary>
		/// Gets or sets the Web service method name.
		/// </summary>
		/// <docgen category="Web Service Options" order="10" />
		// Token: 0x17000220 RID: 544
		// (get) Token: 0x060009F3 RID: 2547 RVA: 0x000231AC File Offset: 0x000213AC
		// (set) Token: 0x060009F4 RID: 2548 RVA: 0x000231C3 File Offset: 0x000213C3
		public string MethodName { get; set; }

		/// <summary>
		/// Gets or sets the Web service namespace.
		/// </summary>
		/// <docgen category="Web Service Options" order="10" />
		// Token: 0x17000221 RID: 545
		// (get) Token: 0x060009F5 RID: 2549 RVA: 0x000231CC File Offset: 0x000213CC
		// (set) Token: 0x060009F6 RID: 2550 RVA: 0x000231E3 File Offset: 0x000213E3
		public string Namespace { get; set; }

		/// <summary>
		/// Gets or sets the protocol to be used when calling web service.
		/// </summary>
		/// <docgen category="Web Service Options" order="10" />
		// Token: 0x17000222 RID: 546
		// (get) Token: 0x060009F7 RID: 2551 RVA: 0x000231EC File Offset: 0x000213EC
		// (set) Token: 0x060009F8 RID: 2552 RVA: 0x00023203 File Offset: 0x00021403
		[DefaultValue("Soap11")]
		public WebServiceProtocol Protocol { get; set; }

		/// <summary>
		/// Gets or sets the encoding.
		/// </summary>
		/// <docgen category="Web Service Options" order="10" />
		// Token: 0x17000223 RID: 547
		// (get) Token: 0x060009F9 RID: 2553 RVA: 0x0002320C File Offset: 0x0002140C
		// (set) Token: 0x060009FA RID: 2554 RVA: 0x00023223 File Offset: 0x00021423
		public Encoding Encoding { get; set; }

		/// <summary>
		/// Calls the target method. Must be implemented in concrete classes.
		/// </summary>
		/// <param name="parameters">Method call parameters.</param>
		// Token: 0x060009FB RID: 2555 RVA: 0x0002322C File Offset: 0x0002142C
		protected override void DoInvoke(object[] parameters)
		{
			throw new NotImplementedException();
		}

		/// <summary>
		/// Invokes the web service method.
		/// </summary>
		/// <param name="parameters">Parameters to be passed.</param>
		/// <param name="continuation">The continuation.</param>
		// Token: 0x060009FC RID: 2556 RVA: 0x00023394 File Offset: 0x00021594
		protected override void DoInvoke(object[] parameters, AsyncContinuation continuation)
		{
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(this.Url);
			byte[] postPayload = null;
			switch (this.Protocol)
			{
			case WebServiceProtocol.Soap11:
				postPayload = this.PrepareSoap11Request(request, parameters);
				break;
			case WebServiceProtocol.Soap12:
				postPayload = this.PrepareSoap12Request(request, parameters);
				break;
			case WebServiceProtocol.HttpPost:
				postPayload = this.PreparePostRequest(request, parameters);
				break;
			case WebServiceProtocol.HttpGet:
				postPayload = this.PrepareGetRequest(request, parameters);
				break;
			}
			AsyncContinuation sendContinuation = delegate(Exception ex)
			{
				if (ex != null)
				{
					continuation(ex);
				}
				else
				{
					request.BeginGetResponse(delegate(IAsyncResult r)
					{
						try
						{
							using (request.EndGetResponse(r))
							{
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
					}, null);
				}
			};
			if (postPayload != null && postPayload.Length > 0)
			{
				request.BeginGetRequestStream(delegate(IAsyncResult r)
				{
					try
					{
						using (Stream stream = request.EndGetRequestStream(r))
						{
							stream.Write(postPayload, 0, postPayload.Length);
						}
						sendContinuation(null);
					}
					catch (Exception ex2)
					{
						if (ex2.MustBeRethrown())
						{
							throw;
						}
						continuation(ex2);
					}
				}, null);
			}
			else
			{
				sendContinuation(null);
			}
		}

		// Token: 0x060009FD RID: 2557 RVA: 0x000234A8 File Offset: 0x000216A8
		private byte[] PrepareSoap11Request(HttpWebRequest request, object[] parameters)
		{
			request.Method = "POST";
			request.ContentType = "text/xml; charset=" + this.Encoding.WebName;
			if (this.Namespace.EndsWith("/", StringComparison.Ordinal))
			{
				request.Headers["SOAPAction"] = this.Namespace + this.MethodName;
			}
			else
			{
				request.Headers["SOAPAction"] = this.Namespace + "/" + this.MethodName;
			}
			byte[] array;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				XmlWriter xmlWriter = XmlWriter.Create(memoryStream, new XmlWriterSettings
				{
					Encoding = this.Encoding
				});
				xmlWriter.WriteStartElement("soap", "Envelope", "http://schemas.xmlsoap.org/soap/envelope/");
				xmlWriter.WriteStartElement("Body", "http://schemas.xmlsoap.org/soap/envelope/");
				xmlWriter.WriteStartElement(this.MethodName, this.Namespace);
				int num = 0;
				foreach (MethodCallParameter methodCallParameter in base.Parameters)
				{
					xmlWriter.WriteElementString(methodCallParameter.Name, Convert.ToString(parameters[num], CultureInfo.InvariantCulture));
					num++;
				}
				xmlWriter.WriteEndElement();
				xmlWriter.WriteEndElement();
				xmlWriter.WriteEndElement();
				xmlWriter.Flush();
				array = memoryStream.ToArray();
			}
			return array;
		}

		// Token: 0x060009FE RID: 2558 RVA: 0x0002365C File Offset: 0x0002185C
		private byte[] PrepareSoap12Request(HttpWebRequest request, object[] parameterValues)
		{
			request.Method = "POST";
			request.ContentType = "text/xml; charset=" + this.Encoding.WebName;
			byte[] array;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				XmlWriter xmlWriter = XmlWriter.Create(memoryStream, new XmlWriterSettings
				{
					Encoding = this.Encoding
				});
				xmlWriter.WriteStartElement("soap12", "Envelope", "http://www.w3.org/2003/05/soap-envelope");
				xmlWriter.WriteStartElement("Body", "http://www.w3.org/2003/05/soap-envelope");
				xmlWriter.WriteStartElement(this.MethodName, this.Namespace);
				int num = 0;
				foreach (MethodCallParameter methodCallParameter in base.Parameters)
				{
					xmlWriter.WriteElementString(methodCallParameter.Name, Convert.ToString(parameterValues[num], CultureInfo.InvariantCulture));
					num++;
				}
				xmlWriter.WriteEndElement();
				xmlWriter.WriteEndElement();
				xmlWriter.WriteEndElement();
				xmlWriter.Flush();
				array = memoryStream.ToArray();
			}
			return array;
		}

		// Token: 0x060009FF RID: 2559 RVA: 0x000237A8 File Offset: 0x000219A8
		private byte[] PreparePostRequest(HttpWebRequest request, object[] parameterValues)
		{
			request.Method = "POST";
			return this.PrepareHttpRequest(request, parameterValues);
		}

		// Token: 0x06000A00 RID: 2560 RVA: 0x000237D0 File Offset: 0x000219D0
		private byte[] PrepareGetRequest(HttpWebRequest request, object[] parameterValues)
		{
			request.Method = "GET";
			return this.PrepareHttpRequest(request, parameterValues);
		}

		// Token: 0x06000A01 RID: 2561 RVA: 0x000237F8 File Offset: 0x000219F8
		private byte[] PrepareHttpRequest(HttpWebRequest request, object[] parameterValues)
		{
			request.ContentType = "application/x-www-form-urlencoded; charset=" + this.Encoding.WebName;
			string text = string.Empty;
			byte[] array;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				StreamWriter streamWriter = new StreamWriter(memoryStream, this.Encoding);
				streamWriter.Write(string.Empty);
				int num = 0;
				foreach (MethodCallParameter methodCallParameter in base.Parameters)
				{
					streamWriter.Write(text);
					streamWriter.Write(methodCallParameter.Name);
					streamWriter.Write("=");
					streamWriter.Write(UrlHelper.UrlEncode(Convert.ToString(parameterValues[num], CultureInfo.InvariantCulture), true));
					text = "&";
					num++;
				}
				streamWriter.Flush();
				array = memoryStream.ToArray();
			}
			return array;
		}

		// Token: 0x04000328 RID: 808
		private const string SoapEnvelopeNamespace = "http://schemas.xmlsoap.org/soap/envelope/";

		// Token: 0x04000329 RID: 809
		private const string Soap12EnvelopeNamespace = "http://www.w3.org/2003/05/soap-envelope";
	}
}
