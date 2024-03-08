using System;
using System.Collections.Generic;

namespace NLog.Internal.Fakeables
{
	/// <summary>
	/// Interface for fakeable the current <see cref="T:System.AppDomain" />. Not fully implemented, please methods/properties as necessary.
	/// </summary>
	// Token: 0x0200005B RID: 91
	public interface IAppDomain
	{
		/// <summary>
		/// Gets or sets the base directory that the assembly resolver uses to probe for assemblies.
		/// </summary>
		// Token: 0x17000075 RID: 117
		// (get) Token: 0x0600024D RID: 589
		string BaseDirectory { get; }

		/// <summary>
		/// Gets or sets the name of the configuration file for an application domain.
		/// </summary>
		// Token: 0x17000076 RID: 118
		// (get) Token: 0x0600024E RID: 590
		string ConfigurationFile { get; }

		/// <summary>
		/// Gets or sets the list of directories under the application base directory that are probed for private assemblies.
		/// </summary>
		// Token: 0x17000077 RID: 119
		// (get) Token: 0x0600024F RID: 591
		IEnumerable<string> PrivateBinPath { get; }

		/// <summary>
		/// Gets or set the friendly name.
		/// </summary>
		// Token: 0x17000078 RID: 120
		// (get) Token: 0x06000250 RID: 592
		string FriendlyName { get; }

		/// <summary>
		/// Process exit event.
		/// </summary>
		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000251 RID: 593
		// (remove) Token: 0x06000252 RID: 594
		event EventHandler<EventArgs> ProcessExit;

		/// <summary>
		/// Domain unloaded event.
		/// </summary>
		// Token: 0x14000002 RID: 2
		// (add) Token: 0x06000253 RID: 595
		// (remove) Token: 0x06000254 RID: 596
		event EventHandler<EventArgs> DomainUnload;
	}
}
