using System;

namespace NLog.Targets
{
	/// <summary>
	/// SMTP authentication modes.
	/// </summary>
	// Token: 0x02000128 RID: 296
	public enum SmtpAuthenticationMode
	{
		/// <summary>
		/// No authentication.
		/// </summary>
		// Token: 0x0400031E RID: 798
		None,
		/// <summary>
		/// Basic - username and password.
		/// </summary>
		// Token: 0x0400031F RID: 799
		Basic,
		/// <summary>
		/// NTLM Authentication.
		/// </summary>
		// Token: 0x04000320 RID: 800
		Ntlm
	}
}
