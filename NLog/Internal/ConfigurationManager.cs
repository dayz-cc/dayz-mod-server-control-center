using System;
using System.Collections.Specialized;
using System.Configuration;

namespace NLog.Internal
{
	/// <summary>
	/// Internal configuration manager used to read .NET configuration files.
	/// Just a wrapper around the BCL ConfigurationManager, but used to enable
	/// unit testing.
	/// </summary>
	// Token: 0x02000054 RID: 84
	public class ConfigurationManager : IConfigurationManager
	{
		/// <summary>
		/// Gets the wrapper around ConfigurationManager.AppSettings.
		/// </summary>
		// Token: 0x17000067 RID: 103
		// (get) Token: 0x06000229 RID: 553 RVA: 0x000097E0 File Offset: 0x000079E0
		public NameValueCollection AppSettings
		{
			get
			{
				return ConfigurationManager.AppSettings;
			}
		}
	}
}
