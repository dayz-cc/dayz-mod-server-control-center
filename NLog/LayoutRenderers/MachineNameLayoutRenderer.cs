using System;
using System.Text;
using NLog.Common;
using NLog.Config;
using NLog.Internal;

namespace NLog.LayoutRenderers
{
	/// <summary>
	/// The machine name that the process is running on.
	/// </summary>
	// Token: 0x020000B0 RID: 176
	[LayoutRenderer("machinename")]
	[AppDomainFixedOutput]
	[ThreadAgnostic]
	public class MachineNameLayoutRenderer : LayoutRenderer
	{
		// Token: 0x170000E1 RID: 225
		// (get) Token: 0x06000429 RID: 1065 RVA: 0x0000F918 File Offset: 0x0000DB18
		// (set) Token: 0x0600042A RID: 1066 RVA: 0x0000F92F File Offset: 0x0000DB2F
		internal string MachineName { get; private set; }

		/// <summary>
		/// Initializes the layout renderer.
		/// </summary>
		// Token: 0x0600042B RID: 1067 RVA: 0x0000F938 File Offset: 0x0000DB38
		protected override void InitializeLayoutRenderer()
		{
			base.InitializeLayoutRenderer();
			try
			{
				this.MachineName = Environment.MachineName;
			}
			catch (Exception ex)
			{
				if (ex.MustBeRethrown())
				{
					throw;
				}
				InternalLogger.Error("Error getting machine name {0}", new object[] { ex });
				this.MachineName = string.Empty;
			}
		}

		/// <summary>
		/// Renders the machine name and appends it to the specified <see cref="T:System.Text.StringBuilder" />.
		/// </summary>
		/// <param name="builder">The <see cref="T:System.Text.StringBuilder" /> to append the rendered data to.</param>
		/// <param name="logEvent">Logging event.</param>
		// Token: 0x0600042C RID: 1068 RVA: 0x0000F9A8 File Offset: 0x0000DBA8
		protected override void Append(StringBuilder builder, LogEventInfo logEvent)
		{
			builder.Append(this.MachineName);
		}
	}
}
