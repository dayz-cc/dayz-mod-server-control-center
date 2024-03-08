using System;
using System.Net;
using System.Net.Mail;

namespace NLog.Internal
{
	/// <summary>
	/// Supports mocking of SMTP Client code.
	/// </summary>
	// Token: 0x02000071 RID: 113
	internal class MySmtpClient : SmtpClient, ISmtpClient, IDisposable
	{
		// Token: 0x060002CA RID: 714 RVA: 0x0000B2E0 File Offset: 0x000094E0
		string ISmtpClient.get_Host()
		{
			return base.Host;
		}

		// Token: 0x060002CB RID: 715 RVA: 0x0000B2F7 File Offset: 0x000094F7
		void ISmtpClient.set_Host(string A_1)
		{
			base.Host = A_1;
		}

		// Token: 0x060002CC RID: 716 RVA: 0x0000B300 File Offset: 0x00009500
		int ISmtpClient.get_Port()
		{
			return base.Port;
		}

		// Token: 0x060002CD RID: 717 RVA: 0x0000B317 File Offset: 0x00009517
		void ISmtpClient.set_Port(int A_1)
		{
			base.Port = A_1;
		}

		// Token: 0x060002CE RID: 718 RVA: 0x0000B320 File Offset: 0x00009520
		ICredentialsByHost ISmtpClient.get_Credentials()
		{
			return base.Credentials;
		}

		// Token: 0x060002CF RID: 719 RVA: 0x0000B337 File Offset: 0x00009537
		void ISmtpClient.set_Credentials(ICredentialsByHost A_1)
		{
			base.Credentials = A_1;
		}

		// Token: 0x060002D0 RID: 720 RVA: 0x0000B340 File Offset: 0x00009540
		bool ISmtpClient.get_EnableSsl()
		{
			return base.EnableSsl;
		}

		// Token: 0x060002D1 RID: 721 RVA: 0x0000B357 File Offset: 0x00009557
		void ISmtpClient.set_EnableSsl(bool A_1)
		{
			base.EnableSsl = A_1;
		}

		// Token: 0x060002D2 RID: 722 RVA: 0x0000B360 File Offset: 0x00009560
		void ISmtpClient.Send(MailMessage A_1)
		{
			base.Send(A_1);
		}
	}
}
