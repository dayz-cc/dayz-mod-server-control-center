﻿using System;
using System.Diagnostics.CodeAnalysis;

namespace NLog.Targets.Wrappers
{
	/// <summary>
	/// Logon type.
	/// </summary>
	// Token: 0x02000141 RID: 321
	[SuppressMessage("Microsoft.Design", "CA1008:EnumsShouldHaveZeroValue", Justification = "Valid security logon type is required.")]
	public enum SecurityLogOnType
	{
		/// <summary>
		/// Interactive Logon.
		/// </summary>
		/// <remarks>
		/// This logon type is intended for users who will be interactively using the computer, such as a user being logged on  
		/// by a terminal server, remote shell, or similar process.
		/// This logon type has the additional expense of caching logon information for disconnected operations;
		/// therefore, it is inappropriate for some client/server applications,
		/// such as a mail server.
		/// </remarks>
		// Token: 0x04000378 RID: 888
		Interactive = 2,
		/// <summary>
		/// Network Logon.
		/// </summary>
		/// <remarks>
		/// This logon type is intended for high performance servers to authenticate plaintext passwords.
		/// The LogonUser function does not cache credentials for this logon type.
		/// </remarks>
		// Token: 0x04000379 RID: 889
		Network,
		/// <summary>
		/// Batch Logon.
		/// </summary>
		/// <remarks>
		/// This logon type is intended for batch servers, where processes may be executing on behalf of a user without
		/// their direct intervention. This type is also for higher performance servers that process many plaintext
		/// authentication attempts at a time, such as mail or Web servers.
		/// The LogonUser function does not cache credentials for this logon type.
		/// </remarks>
		// Token: 0x0400037A RID: 890
		Batch,
		/// <summary>
		/// Logon as a Service.
		/// </summary>
		/// <remarks>
		/// Indicates a service-type logon. The account provided must have the service privilege enabled.
		/// </remarks>
		// Token: 0x0400037B RID: 891
		Service,
		/// <summary>
		/// Network Clear Text Logon.
		/// </summary>
		/// <remarks>
		/// This logon type preserves the name and password in the authentication package, which allows the server to make
		/// connections to other network servers while impersonating the client. A server can accept plaintext credentials
		/// from a client, call LogonUser, verify that the user can access the system across the network, and still
		/// communicate with other servers.
		/// NOTE: Windows NT:  This value is not supported.
		/// </remarks>
		// Token: 0x0400037C RID: 892
		NetworkClearText = 8,
		/// <summary>
		/// New Network Credentials.
		/// </summary>
		/// <remarks>
		/// This logon type allows the caller to clone its current token and specify new credentials for outbound connections.
		/// The new logon session has the same local identifier but uses different credentials for other network connections.
		/// NOTE: This logon type is supported only by the LOGON32_PROVIDER_WINNT50 logon provider.
		/// NOTE: Windows NT:  This value is not supported.
		/// </remarks>
		// Token: 0x0400037D RID: 893
		NewCredentials
	}
}
