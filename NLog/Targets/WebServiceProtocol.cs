using System;

namespace NLog.Targets
{
	/// <summary>
	/// Web service protocol.
	/// </summary>
	// Token: 0x0200012B RID: 299
	public enum WebServiceProtocol
	{
		/// <summary>
		/// Use SOAP 1.1 Protocol.
		/// </summary>
		// Token: 0x04000324 RID: 804
		Soap11,
		/// <summary>
		/// Use SOAP 1.2 Protocol.
		/// </summary>
		// Token: 0x04000325 RID: 805
		Soap12,
		/// <summary>
		/// Use HTTP POST Protocol.
		/// </summary>
		// Token: 0x04000326 RID: 806
		HttpPost,
		/// <summary>
		/// Use HTTP GET Protocol.
		/// </summary>
		// Token: 0x04000327 RID: 807
		HttpGet
	}
}
