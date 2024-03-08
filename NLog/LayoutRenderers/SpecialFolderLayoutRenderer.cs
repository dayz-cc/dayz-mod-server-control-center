using System;
using System.IO;
using System.Text;
using NLog.Config;

namespace NLog.LayoutRenderers
{
	/// <summary>
	/// System special folder path (includes My Documents, My Music, Program Files, Desktop, and more).
	/// </summary>
	// Token: 0x020000BF RID: 191
	[AppDomainFixedOutput]
	[LayoutRenderer("specialfolder")]
	public class SpecialFolderLayoutRenderer : LayoutRenderer
	{
		/// <summary>
		/// Gets or sets the system special folder to use.
		/// </summary>
		/// <remarks>
		/// Full list of options is available at <a href="http://msdn2.microsoft.com/en-us/system.environment.specialfolder.aspx">MSDN</a>.
		/// The most common ones are:
		/// <ul>
		/// <li><b>ApplicationData</b> - roaming application data for current user.</li>
		/// <li><b>CommonApplicationData</b> - application data for all users.</li>
		/// <li><b>MyDocuments</b> - My Documents</li>
		/// <li><b>DesktopDirectory</b> - Desktop directory</li>
		/// <li><b>LocalApplicationData</b> - non roaming application data</li>
		/// <li><b>Personal</b> - user profile directory</li>
		/// <li><b>System</b> - System directory</li>
		/// </ul>
		/// </remarks>
		/// <docgen category="Rendering Options" order="10" />
		// Token: 0x170000FA RID: 250
		// (get) Token: 0x0600047E RID: 1150 RVA: 0x0001064C File Offset: 0x0000E84C
		// (set) Token: 0x0600047F RID: 1151 RVA: 0x00010663 File Offset: 0x0000E863
		[DefaultParameter]
		public Environment.SpecialFolder Folder { get; set; }

		/// <summary>
		/// Gets or sets the name of the file to be Path.Combine()'d with the directory name.
		/// </summary>
		/// <docgen category="Advanced Options" order="10" />
		// Token: 0x170000FB RID: 251
		// (get) Token: 0x06000480 RID: 1152 RVA: 0x0001066C File Offset: 0x0000E86C
		// (set) Token: 0x06000481 RID: 1153 RVA: 0x00010683 File Offset: 0x0000E883
		public string File { get; set; }

		/// <summary>
		/// Gets or sets the name of the directory to be Path.Combine()'d with the directory name.
		/// </summary>
		/// <docgen category="Advanced Options" order="10" />
		// Token: 0x170000FC RID: 252
		// (get) Token: 0x06000482 RID: 1154 RVA: 0x0001068C File Offset: 0x0000E88C
		// (set) Token: 0x06000483 RID: 1155 RVA: 0x000106A3 File Offset: 0x0000E8A3
		public string Dir { get; set; }

		/// <summary>
		/// Renders the directory where NLog is located and appends it to the specified <see cref="T:System.Text.StringBuilder" />.
		/// </summary>
		/// <param name="builder">The <see cref="T:System.Text.StringBuilder" /> to append the rendered data to.</param>
		/// <param name="logEvent">Logging event.</param>
		// Token: 0x06000484 RID: 1156 RVA: 0x000106AC File Offset: 0x0000E8AC
		protected override void Append(StringBuilder builder, LogEventInfo logEvent)
		{
			string folderPath = Environment.GetFolderPath(this.Folder);
			if (this.File != null)
			{
				builder.Append(Path.Combine(folderPath, this.File));
			}
			else if (this.Dir != null)
			{
				builder.Append(Path.Combine(folderPath, this.Dir));
			}
			else
			{
				builder.Append(folderPath);
			}
		}
	}
}
