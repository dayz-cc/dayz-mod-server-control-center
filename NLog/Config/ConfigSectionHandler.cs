using System;
using System.Configuration;
using System.Xml;
using NLog.Common;
using NLog.Internal;
using NLog.Internal.Fakeables;

namespace NLog.Config
{
	/// <summary>
	/// NLog configuration section handler class for configuring NLog from App.config.
	/// </summary>
	// Token: 0x02000026 RID: 38
	public sealed class ConfigSectionHandler : IConfigurationSectionHandler
	{
		// Token: 0x060000FA RID: 250 RVA: 0x0000547C File Offset: 0x0000367C
		private object Create(XmlNode section, IAppDomain appDomain)
		{
			object obj;
			try
			{
				string configurationFile = appDomain.ConfigurationFile;
				obj = new XmlLoggingConfiguration((XmlElement)section, configurationFile);
			}
			catch (Exception ex)
			{
				if (ex.MustBeRethrown())
				{
					throw;
				}
				InternalLogger.Error("ConfigSectionHandler error: {0}", new object[] { ex });
				throw;
			}
			return obj;
		}

		/// <summary>
		/// Creates a configuration section handler.
		/// </summary>
		/// <param name="parent">Parent object.</param>
		/// <param name="configContext">Configuration context object.</param>
		/// <param name="section">Section XML node.</param>
		/// <returns>The created section handler object.</returns>
		// Token: 0x060000FB RID: 251 RVA: 0x000054E4 File Offset: 0x000036E4
		object IConfigurationSectionHandler.Create(object parent, object configContext, XmlNode section)
		{
			return this.Create(section, AppDomainWrapper.CurrentDomain);
		}
	}
}
