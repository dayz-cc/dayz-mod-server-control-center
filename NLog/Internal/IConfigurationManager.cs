using System;
using System.Collections.Specialized;

namespace NLog.Internal
{
	/// <summary>
	/// Interface for the wrapper around System.Configuration.ConfigurationManager.
	/// </summary>
	// Token: 0x02000053 RID: 83
	public interface IConfigurationManager
	{
		/// <summary>
		/// Gets the wrapper around ConfigurationManager.AppSettings.
		/// </summary>
		// Token: 0x17000066 RID: 102
		// (get) Token: 0x06000228 RID: 552
		NameValueCollection AppSettings { get; }
	}
}
