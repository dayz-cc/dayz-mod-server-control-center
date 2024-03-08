using System;
using System.Net;
using System.Net.Mail;

namespace NLog.Internal
{
	/// <summary>
	/// Supports mocking of SMTP Client code.
	/// </summary>
	// Token: 0x0200006B RID: 107
	internal interface ISmtpClient : IDisposable
	{
		// Token: 0x1700008B RID: 139
		// (get) Token: 0x060002B0 RID: 688
		// (set) Token: 0x060002B1 RID: 689
		string Host { get; set; }

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x060002B2 RID: 690
		// (set) Token: 0x060002B3 RID: 691
		int Port { get; set; }

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x060002B4 RID: 692
		// (set) Token: 0x060002B5 RID: 693
		ICredentialsByHost Credentials { get; set; }

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x060002B6 RID: 694
		// (set) Token: 0x060002B7 RID: 695
		bool EnableSsl { get; set; }

		// Token: 0x060002B8 RID: 696
		void Send(MailMessage msg);
	}
}
