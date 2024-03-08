using System;

namespace NLog.Config
{
	/// <summary>
	/// Implemented by objects which support installation and uninstallation.
	/// </summary>
	// Token: 0x0200002E RID: 46
	public interface IInstallable
	{
		/// <summary>
		/// Performs installation which requires administrative permissions.
		/// </summary>
		/// <param name="installationContext">The installation context.</param>
		// Token: 0x06000129 RID: 297
		void Install(InstallationContext installationContext);

		/// <summary>
		/// Performs uninstallation which requires administrative permissions.
		/// </summary>
		/// <param name="installationContext">The installation context.</param>
		// Token: 0x0600012A RID: 298
		void Uninstall(InstallationContext installationContext);

		/// <summary>
		/// Determines whether the item is installed.
		/// </summary>
		/// <param name="installationContext">The installation context.</param>
		/// <returns>
		/// Value indicating whether the item is installed or null if it is not possible to determine.
		/// </returns>
		// Token: 0x0600012B RID: 299
		bool? IsInstalled(InstallationContext installationContext);
	}
}
