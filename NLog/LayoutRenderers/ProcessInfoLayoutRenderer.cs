using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using System.Text;
using NLog.Config;

namespace NLog.LayoutRenderers
{
	/// <summary>
	/// The information about the running process.
	/// </summary>
	// Token: 0x020000B8 RID: 184
	[LayoutRenderer("processinfo")]
	public class ProcessInfoLayoutRenderer : LayoutRenderer
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.LayoutRenderers.ProcessInfoLayoutRenderer" /> class.
		/// </summary>
		// Token: 0x06000459 RID: 1113 RVA: 0x0000FED0 File Offset: 0x0000E0D0
		public ProcessInfoLayoutRenderer()
		{
			this.Property = ProcessInfoProperty.Id;
		}

		/// <summary>
		/// Gets or sets the property to retrieve.
		/// </summary>
		/// <docgen category="Rendering Options" order="10" />
		// Token: 0x170000EF RID: 239
		// (get) Token: 0x0600045A RID: 1114 RVA: 0x0000FEE4 File Offset: 0x0000E0E4
		// (set) Token: 0x0600045B RID: 1115 RVA: 0x0000FEFB File Offset: 0x0000E0FB
		[DefaultParameter]
		[DefaultValue("Id")]
		public ProcessInfoProperty Property { get; set; }

		/// <summary>
		/// Initializes the layout renderer.
		/// </summary>
		// Token: 0x0600045C RID: 1116 RVA: 0x0000FF04 File Offset: 0x0000E104
		protected override void InitializeLayoutRenderer()
		{
			base.InitializeLayoutRenderer();
			this.propertyInfo = typeof(Process).GetProperty(this.Property.ToString());
			if (this.propertyInfo == null)
			{
				throw new ArgumentException("Property '" + this.propertyInfo + "' not found in System.Diagnostics.Process");
			}
			this.process = Process.GetCurrentProcess();
		}

		/// <summary>
		/// Closes the layout renderer.
		/// </summary>
		// Token: 0x0600045D RID: 1117 RVA: 0x0000FF78 File Offset: 0x0000E178
		protected override void CloseLayoutRenderer()
		{
			if (this.process != null)
			{
				this.process.Close();
				this.process = null;
			}
			base.CloseLayoutRenderer();
		}

		/// <summary>
		/// Renders the selected process information.
		/// </summary>
		/// <param name="builder">The <see cref="T:System.Text.StringBuilder" /> to append the rendered data to.</param>
		/// <param name="logEvent">Logging event.</param>
		// Token: 0x0600045E RID: 1118 RVA: 0x0000FFB0 File Offset: 0x0000E1B0
		protected override void Append(StringBuilder builder, LogEventInfo logEvent)
		{
			if (this.propertyInfo != null)
			{
				builder.Append(Convert.ToString(this.propertyInfo.GetValue(this.process, null), CultureInfo.InvariantCulture));
			}
		}

		// Token: 0x04000157 RID: 343
		private Process process;

		// Token: 0x04000158 RID: 344
		private PropertyInfo propertyInfo;
	}
}
