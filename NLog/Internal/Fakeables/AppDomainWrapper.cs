using System;
using System.Collections.Generic;

namespace NLog.Internal.Fakeables
{
	/// <summary>
	/// Adapter for <see cref="T:System.AppDomain" /> to <see cref="T:NLog.Internal.Fakeables.IAppDomain" />
	/// </summary>
	// Token: 0x0200005C RID: 92
	public class AppDomainWrapper : IAppDomain
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Internal.Fakeables.AppDomainWrapper" /> class.
		/// </summary>
		/// <param name="appDomain">The <see cref="T:System.AppDomain" /> to wrap.</param>
		// Token: 0x06000255 RID: 597 RVA: 0x00009F28 File Offset: 0x00008128
		public AppDomainWrapper(AppDomain appDomain)
		{
			this.BaseDirectory = appDomain.BaseDirectory;
			this.ConfigurationFile = appDomain.SetupInformation.ConfigurationFile;
			string privateBinPath = appDomain.SetupInformation.PrivateBinPath;
			this.PrivateBinPath = (string.IsNullOrEmpty(privateBinPath) ? new string[0] : appDomain.SetupInformation.PrivateBinPath.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries));
			this.FriendlyName = appDomain.FriendlyName;
			appDomain.ProcessExit += this.OnProcessExit;
			appDomain.DomainUnload += this.OnDomainUnload;
		}

		/// <summary>
		/// Gets a the current <see cref="T:System.AppDomain" /> wrappered in a <see cref="T:NLog.Internal.Fakeables.AppDomainWrapper" />.
		/// </summary>
		// Token: 0x17000079 RID: 121
		// (get) Token: 0x06000256 RID: 598 RVA: 0x00009FD4 File Offset: 0x000081D4
		public static AppDomainWrapper CurrentDomain
		{
			get
			{
				return new AppDomainWrapper(AppDomain.CurrentDomain);
			}
		}

		/// <summary>
		/// Gets or sets the base directory that the assembly resolver uses to probe for assemblies.
		/// </summary>
		// Token: 0x1700007A RID: 122
		// (get) Token: 0x06000257 RID: 599 RVA: 0x00009FF0 File Offset: 0x000081F0
		// (set) Token: 0x06000258 RID: 600 RVA: 0x0000A007 File Offset: 0x00008207
		public string BaseDirectory { get; private set; }

		/// <summary>
		/// Gets or sets the name of the configuration file for an application domain.
		/// </summary>
		// Token: 0x1700007B RID: 123
		// (get) Token: 0x06000259 RID: 601 RVA: 0x0000A010 File Offset: 0x00008210
		// (set) Token: 0x0600025A RID: 602 RVA: 0x0000A027 File Offset: 0x00008227
		public string ConfigurationFile { get; private set; }

		/// <summary>
		/// Gets or sets the list of directories under the application base directory that are probed for private assemblies.
		/// </summary>
		// Token: 0x1700007C RID: 124
		// (get) Token: 0x0600025B RID: 603 RVA: 0x0000A030 File Offset: 0x00008230
		// (set) Token: 0x0600025C RID: 604 RVA: 0x0000A047 File Offset: 0x00008247
		public IEnumerable<string> PrivateBinPath { get; private set; }

		/// <summary>
		/// Gets or set the friendly name.
		/// </summary>
		// Token: 0x1700007D RID: 125
		// (get) Token: 0x0600025D RID: 605 RVA: 0x0000A050 File Offset: 0x00008250
		// (set) Token: 0x0600025E RID: 606 RVA: 0x0000A067 File Offset: 0x00008267
		public string FriendlyName { get; private set; }

		/// <summary>
		/// Process exit event.
		/// </summary>
		// Token: 0x14000003 RID: 3
		// (add) Token: 0x0600025F RID: 607 RVA: 0x0000A070 File Offset: 0x00008270
		// (remove) Token: 0x06000260 RID: 608 RVA: 0x0000A0AC File Offset: 0x000082AC
		public event EventHandler<EventArgs> ProcessExit;

		/// <summary>
		/// Domain unloaded event.
		/// </summary>
		// Token: 0x14000004 RID: 4
		// (add) Token: 0x06000261 RID: 609 RVA: 0x0000A0E8 File Offset: 0x000082E8
		// (remove) Token: 0x06000262 RID: 610 RVA: 0x0000A124 File Offset: 0x00008324
		public event EventHandler<EventArgs> DomainUnload;

		// Token: 0x06000263 RID: 611 RVA: 0x0000A160 File Offset: 0x00008360
		private void OnDomainUnload(object sender, EventArgs e)
		{
			EventHandler<EventArgs> domainUnload = this.DomainUnload;
			if (domainUnload != null)
			{
				domainUnload(sender, e);
			}
		}

		// Token: 0x06000264 RID: 612 RVA: 0x0000A188 File Offset: 0x00008388
		private void OnProcessExit(object sender, EventArgs eventArgs)
		{
			EventHandler<EventArgs> processExit = this.ProcessExit;
			if (processExit != null)
			{
				processExit(sender, eventArgs);
			}
		}
	}
}
