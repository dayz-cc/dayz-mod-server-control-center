using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Mail;
using System.Text;
using NLog.Common;
using NLog.Config;
using NLog.Internal;
using NLog.Layouts;

namespace NLog.Targets
{
	/// <summary>
	/// Sends log messages by email using SMTP protocol.
	/// </summary>
	/// <seealso href="http://nlog-project.org/wiki/Mail_target">Documentation on NLog Wiki</seealso>
	/// <example>
	/// <p>
	/// To set up the target in the <a href="config.html">configuration file</a>, 
	/// use the following syntax:
	/// </p>
	/// <code lang="XML" source="examples/targets/Configuration File/Mail/Simple/NLog.config" />
	/// <p>
	/// This assumes just one target and a single rule. More configuration
	/// options are described <a href="config.html">here</a>.
	/// </p>
	/// <p>
	/// To set up the log target programmatically use code like this:
	/// </p>
	/// <code lang="C#" source="examples/targets/Configuration API/Mail/Simple/Example.cs" />
	/// <p>
	/// Mail target works best when used with BufferingWrapper target
	/// which lets you send multiple log messages in single mail
	/// </p>
	/// <p>
	/// To set up the buffered mail target in the <a href="config.html">configuration file</a>, 
	/// use the following syntax:
	/// </p>
	/// <code lang="XML" source="examples/targets/Configuration File/Mail/Buffered/NLog.config" />
	/// <p>
	/// To set up the buffered mail target programmatically use code like this:
	/// </p>
	/// <code lang="C#" source="examples/targets/Configuration API/Mail/Buffered/Example.cs" />
	/// </example>
	// Token: 0x02000118 RID: 280
	[Target("Mail")]
	public class MailTarget : TargetWithLayoutHeaderAndFooter
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Targets.MailTarget" /> class.
		/// </summary>
		/// <remarks>
		/// The default value of the layout is: <code>${longdate}|${level:uppercase=true}|${logger}|${message}</code>
		/// </remarks>
		// Token: 0x0600092A RID: 2346 RVA: 0x00020DB4 File Offset: 0x0001EFB4
		[SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors", Justification = "This one is safe.")]
		public MailTarget()
		{
			this.Body = "${message}${newline}";
			this.Subject = "Message from NLog on ${machinename}";
			this.Encoding = Encoding.UTF8;
			this.SmtpPort = 25;
			this.SmtpAuthentication = SmtpAuthenticationMode.None;
		}

		/// <summary>
		/// Gets or sets sender's email address (e.g. joe@domain.com).
		/// </summary>
		/// <docgen category="Message Options" order="10" />
		// Token: 0x170001DD RID: 477
		// (get) Token: 0x0600092B RID: 2347 RVA: 0x00020E0C File Offset: 0x0001F00C
		// (set) Token: 0x0600092C RID: 2348 RVA: 0x00020E23 File Offset: 0x0001F023
		[RequiredParameter]
		public Layout From { get; set; }

		/// <summary>
		/// Gets or sets recipients' email addresses separated by semicolons (e.g. john@domain.com;jane@domain.com).
		/// </summary>
		/// <docgen category="Message Options" order="11" />
		// Token: 0x170001DE RID: 478
		// (get) Token: 0x0600092D RID: 2349 RVA: 0x00020E2C File Offset: 0x0001F02C
		// (set) Token: 0x0600092E RID: 2350 RVA: 0x00020E43 File Offset: 0x0001F043
		[RequiredParameter]
		public Layout To { get; set; }

		/// <summary>
		/// Gets or sets CC email addresses separated by semicolons (e.g. john@domain.com;jane@domain.com).
		/// </summary>
		/// <docgen category="Message Options" order="12" />
		// Token: 0x170001DF RID: 479
		// (get) Token: 0x0600092F RID: 2351 RVA: 0x00020E4C File Offset: 0x0001F04C
		// (set) Token: 0x06000930 RID: 2352 RVA: 0x00020E63 File Offset: 0x0001F063
		public Layout CC { get; set; }

		/// <summary>
		/// Gets or sets BCC email addresses separated by semicolons (e.g. john@domain.com;jane@domain.com).
		/// </summary>
		/// <docgen category="Message Options" order="13" />
		// Token: 0x170001E0 RID: 480
		// (get) Token: 0x06000931 RID: 2353 RVA: 0x00020E6C File Offset: 0x0001F06C
		// (set) Token: 0x06000932 RID: 2354 RVA: 0x00020E83 File Offset: 0x0001F083
		public Layout Bcc { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether to add new lines between log entries.
		/// </summary>
		/// <value>A value of <c>true</c> if new lines should be added; otherwise, <c>false</c>.</value>
		/// <docgen category="Layout Options" order="99" />
		// Token: 0x170001E1 RID: 481
		// (get) Token: 0x06000933 RID: 2355 RVA: 0x00020E8C File Offset: 0x0001F08C
		// (set) Token: 0x06000934 RID: 2356 RVA: 0x00020EA3 File Offset: 0x0001F0A3
		public bool AddNewLines { get; set; }

		/// <summary>
		/// Gets or sets the mail subject.
		/// </summary>
		/// <docgen category="Message Options" order="5" />
		// Token: 0x170001E2 RID: 482
		// (get) Token: 0x06000935 RID: 2357 RVA: 0x00020EAC File Offset: 0x0001F0AC
		// (set) Token: 0x06000936 RID: 2358 RVA: 0x00020EC3 File Offset: 0x0001F0C3
		[RequiredParameter]
		[DefaultValue("Message from NLog on ${machinename}")]
		public Layout Subject { get; set; }

		/// <summary>
		/// Gets or sets mail message body (repeated for each log message send in one mail).
		/// </summary>
		/// <remarks>Alias for the <c>Layout</c> property.</remarks>
		/// <docgen category="Message Options" order="6" />
		// Token: 0x170001E3 RID: 483
		// (get) Token: 0x06000937 RID: 2359 RVA: 0x00020ECC File Offset: 0x0001F0CC
		// (set) Token: 0x06000938 RID: 2360 RVA: 0x00020EE4 File Offset: 0x0001F0E4
		[DefaultValue("${message}")]
		public Layout Body
		{
			get
			{
				return this.Layout;
			}
			set
			{
				this.Layout = value;
			}
		}

		/// <summary>
		/// Gets or sets encoding to be used for sending e-mail.
		/// </summary>
		/// <docgen category="Layout Options" order="20" />
		// Token: 0x170001E4 RID: 484
		// (get) Token: 0x06000939 RID: 2361 RVA: 0x00020EF0 File Offset: 0x0001F0F0
		// (set) Token: 0x0600093A RID: 2362 RVA: 0x00020F07 File Offset: 0x0001F107
		[DefaultValue("UTF8")]
		public Encoding Encoding { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether to send message as HTML instead of plain text.
		/// </summary>
		/// <docgen category="Layout Options" order="11" />
		// Token: 0x170001E5 RID: 485
		// (get) Token: 0x0600093B RID: 2363 RVA: 0x00020F10 File Offset: 0x0001F110
		// (set) Token: 0x0600093C RID: 2364 RVA: 0x00020F27 File Offset: 0x0001F127
		[DefaultValue(false)]
		public bool Html { get; set; }

		/// <summary>
		/// Gets or sets SMTP Server to be used for sending.
		/// </summary>
		/// <docgen category="SMTP Options" order="10" />
		// Token: 0x170001E6 RID: 486
		// (get) Token: 0x0600093D RID: 2365 RVA: 0x00020F30 File Offset: 0x0001F130
		// (set) Token: 0x0600093E RID: 2366 RVA: 0x00020F47 File Offset: 0x0001F147
		public Layout SmtpServer { get; set; }

		/// <summary>
		/// Gets or sets SMTP Authentication mode.
		/// </summary>
		/// <docgen category="SMTP Options" order="11" />
		// Token: 0x170001E7 RID: 487
		// (get) Token: 0x0600093F RID: 2367 RVA: 0x00020F50 File Offset: 0x0001F150
		// (set) Token: 0x06000940 RID: 2368 RVA: 0x00020F67 File Offset: 0x0001F167
		[DefaultValue("None")]
		public SmtpAuthenticationMode SmtpAuthentication { get; set; }

		/// <summary>
		/// Gets or sets the username used to connect to SMTP server (used when SmtpAuthentication is set to "basic").
		/// </summary>
		/// <docgen category="SMTP Options" order="12" />
		// Token: 0x170001E8 RID: 488
		// (get) Token: 0x06000941 RID: 2369 RVA: 0x00020F70 File Offset: 0x0001F170
		// (set) Token: 0x06000942 RID: 2370 RVA: 0x00020F87 File Offset: 0x0001F187
		public Layout SmtpUserName { get; set; }

		/// <summary>
		/// Gets or sets the password used to authenticate against SMTP server (used when SmtpAuthentication is set to "basic").
		/// </summary>
		/// <docgen category="SMTP Options" order="13" />
		// Token: 0x170001E9 RID: 489
		// (get) Token: 0x06000943 RID: 2371 RVA: 0x00020F90 File Offset: 0x0001F190
		// (set) Token: 0x06000944 RID: 2372 RVA: 0x00020FA7 File Offset: 0x0001F1A7
		public Layout SmtpPassword { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether SSL (secure sockets layer) should be used when communicating with SMTP server.
		/// </summary>
		/// <docgen category="SMTP Options" order="14" />
		// Token: 0x170001EA RID: 490
		// (get) Token: 0x06000945 RID: 2373 RVA: 0x00020FB0 File Offset: 0x0001F1B0
		// (set) Token: 0x06000946 RID: 2374 RVA: 0x00020FC7 File Offset: 0x0001F1C7
		[DefaultValue(false)]
		public bool EnableSsl { get; set; }

		/// <summary>
		/// Gets or sets the port number that SMTP Server is listening on.
		/// </summary>
		/// <docgen category="SMTP Options" order="15" />
		// Token: 0x170001EB RID: 491
		// (get) Token: 0x06000947 RID: 2375 RVA: 0x00020FD0 File Offset: 0x0001F1D0
		// (set) Token: 0x06000948 RID: 2376 RVA: 0x00020FE7 File Offset: 0x0001F1E7
		[DefaultValue(25)]
		public int SmtpPort { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether the default Settings from System.Net.MailSettings should be used.
		/// </summary>
		/// <docgen category="SMTP Options" order="16" />
		// Token: 0x170001EC RID: 492
		// (get) Token: 0x06000949 RID: 2377 RVA: 0x00020FF0 File Offset: 0x0001F1F0
		// (set) Token: 0x0600094A RID: 2378 RVA: 0x00021007 File Offset: 0x0001F207
		[DefaultValue(false)]
		public bool UseSystemNetMailSettings { get; set; }

		/// <summary>
		/// Gets or sets the priority used for sending mails.
		/// </summary>
		// Token: 0x170001ED RID: 493
		// (get) Token: 0x0600094B RID: 2379 RVA: 0x00021010 File Offset: 0x0001F210
		// (set) Token: 0x0600094C RID: 2380 RVA: 0x00021027 File Offset: 0x0001F227
		public Layout Priority { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether NewLine characters in the body should be replaced with <br /> tags.
		/// </summary>
		/// <remarks>Only happens when <see cref="P:NLog.Targets.MailTarget.Html" /> is set to true.</remarks>
		// Token: 0x170001EE RID: 494
		// (get) Token: 0x0600094D RID: 2381 RVA: 0x00021030 File Offset: 0x0001F230
		// (set) Token: 0x0600094E RID: 2382 RVA: 0x00021047 File Offset: 0x0001F247
		[DefaultValue(false)]
		public bool ReplaceNewlineWithBrTagInHtml { get; set; }

		// Token: 0x0600094F RID: 2383 RVA: 0x00021050 File Offset: 0x0001F250
		[SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "This is a factory method.")]
		internal virtual ISmtpClient CreateSmtpClient()
		{
			return new MySmtpClient();
		}

		/// <summary>
		/// Renders the logging event message and adds it to the internal ArrayList of log messages.
		/// </summary>
		/// <param name="logEvent">The logging event.</param>
		// Token: 0x06000950 RID: 2384 RVA: 0x00021068 File Offset: 0x0001F268
		protected override void Write(AsyncLogEventInfo logEvent)
		{
			this.Write(new AsyncLogEventInfo[] { logEvent });
		}

		/// <summary>
		/// Renders an array logging events.
		/// </summary>
		/// <param name="logEvents">Array of logging events.</param>
		// Token: 0x06000951 RID: 2385 RVA: 0x000210B4 File Offset: 0x0001F2B4
		protected override void Write(AsyncLogEventInfo[] logEvents)
		{
			foreach (KeyValuePair<string, List<AsyncLogEventInfo>> keyValuePair in logEvents.BucketSort((AsyncLogEventInfo c) => this.GetSmtpSettingsKey(c.LogEvent)))
			{
				List<AsyncLogEventInfo> value = keyValuePair.Value;
				this.ProcessSingleMailMessage(value);
			}
		}

		// Token: 0x06000952 RID: 2386 RVA: 0x00021124 File Offset: 0x0001F324
		private void ProcessSingleMailMessage(List<AsyncLogEventInfo> events)
		{
			try
			{
				LogEventInfo logEvent = events[0].LogEvent;
				LogEventInfo logEvent2 = events[events.Count - 1].LogEvent;
				StringBuilder stringBuilder = new StringBuilder();
				if (base.Header != null)
				{
					stringBuilder.Append(base.Header.Render(logEvent));
					if (this.AddNewLines)
					{
						stringBuilder.Append("\n");
					}
				}
				foreach (AsyncLogEventInfo asyncLogEventInfo in events)
				{
					stringBuilder.Append(this.Layout.Render(asyncLogEventInfo.LogEvent));
					if (this.AddNewLines)
					{
						stringBuilder.Append("\n");
					}
				}
				if (base.Footer != null)
				{
					stringBuilder.Append(base.Footer.Render(logEvent2));
					if (this.AddNewLines)
					{
						stringBuilder.Append("\n");
					}
				}
				using (MailMessage mailMessage = new MailMessage())
				{
					this.SetupMailMessage(mailMessage, logEvent2);
					mailMessage.Body = stringBuilder.ToString();
					if (mailMessage.IsBodyHtml && this.ReplaceNewlineWithBrTagInHtml)
					{
						mailMessage.Body = mailMessage.Body.Replace(EnvironmentHelper.NewLine, "<br/>");
					}
					using (ISmtpClient smtpClient = this.CreateSmtpClient())
					{
						if (!this.UseSystemNetMailSettings)
						{
							this.ConfigureMailClient(logEvent2, smtpClient);
						}
						InternalLogger.Debug("Sending mail to {0} using {1}:{2} (ssl={3})", new object[] { mailMessage.To, smtpClient.Host, smtpClient.Port, smtpClient.EnableSsl });
						InternalLogger.Trace("  Subject: '{0}'", new object[] { mailMessage.Subject });
						InternalLogger.Trace("  From: '{0}'", new object[] { mailMessage.From.ToString() });
						smtpClient.Send(mailMessage);
						foreach (AsyncLogEventInfo asyncLogEventInfo2 in events)
						{
							asyncLogEventInfo2.Continuation(null);
						}
					}
				}
			}
			catch (Exception ex)
			{
				if (ex.MustBeRethrown())
				{
					throw;
				}
				foreach (AsyncLogEventInfo asyncLogEventInfo2 in events)
				{
					asyncLogEventInfo2.Continuation(ex);
				}
			}
		}

		// Token: 0x06000953 RID: 2387 RVA: 0x000214CC File Offset: 0x0001F6CC
		private void ConfigureMailClient(LogEventInfo lastEvent, ISmtpClient client)
		{
			client.Host = this.SmtpServer.Render(lastEvent);
			client.Port = this.SmtpPort;
			client.EnableSsl = this.EnableSsl;
			if (this.SmtpAuthentication == SmtpAuthenticationMode.Ntlm)
			{
				InternalLogger.Trace("  Using NTLM authentication.");
				client.Credentials = CredentialCache.DefaultNetworkCredentials;
			}
			else if (this.SmtpAuthentication == SmtpAuthenticationMode.Basic)
			{
				string text = this.SmtpUserName.Render(lastEvent);
				string text2 = this.SmtpPassword.Render(lastEvent);
				InternalLogger.Trace("  Using basic authentication: Username='{0}' Password='{1}'", new object[]
				{
					text,
					new string('*', text2.Length)
				});
				client.Credentials = new NetworkCredential(text, text2);
			}
		}

		// Token: 0x06000954 RID: 2388 RVA: 0x00021594 File Offset: 0x0001F794
		private string GetSmtpSettingsKey(LogEventInfo logEvent)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(this.From.Render(logEvent));
			stringBuilder.Append("|");
			stringBuilder.Append(this.To.Render(logEvent));
			stringBuilder.Append("|");
			if (this.CC != null)
			{
				stringBuilder.Append(this.CC.Render(logEvent));
			}
			stringBuilder.Append("|");
			if (this.Bcc != null)
			{
				stringBuilder.Append(this.Bcc.Render(logEvent));
			}
			stringBuilder.Append("|");
			if (this.SmtpServer != null)
			{
				stringBuilder.Append(this.SmtpServer.Render(logEvent));
			}
			if (this.SmtpPassword != null)
			{
				stringBuilder.Append(this.SmtpPassword.Render(logEvent));
			}
			stringBuilder.Append("|");
			if (this.SmtpUserName != null)
			{
				stringBuilder.Append(this.SmtpUserName.Render(logEvent));
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06000955 RID: 2389 RVA: 0x000216C0 File Offset: 0x0001F8C0
		private void SetupMailMessage(MailMessage msg, LogEventInfo logEvent)
		{
			msg.From = new MailAddress(this.From.Render(logEvent));
			foreach (string text in this.To.Render(logEvent).Split(new char[] { ';' }))
			{
				msg.To.Add(text);
			}
			if (this.Bcc != null)
			{
				foreach (string text in this.Bcc.Render(logEvent).Split(new char[] { ';' }))
				{
					msg.Bcc.Add(text);
				}
			}
			if (this.CC != null)
			{
				foreach (string text in this.CC.Render(logEvent).Split(new char[] { ';' }))
				{
					msg.CC.Add(text);
				}
			}
			msg.Subject = this.Subject.Render(logEvent).Trim();
			msg.BodyEncoding = this.Encoding;
			msg.IsBodyHtml = this.Html;
			if (this.Priority != null)
			{
				string text2 = this.Priority.Render(logEvent);
				try
				{
					msg.Priority = (MailPriority)Enum.Parse(typeof(MailPriority), text2, true);
				}
				catch
				{
					InternalLogger.Warn("Could not convert '{0}' to MailPriority, valid values are Low, Normal and High. Using normal priority as fallback.");
					msg.Priority = MailPriority.Normal;
				}
			}
		}
	}
}
