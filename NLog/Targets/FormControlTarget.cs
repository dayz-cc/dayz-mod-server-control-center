using System;
using System.ComponentModel;
using System.Windows.Forms;
using NLog.Config;
using NLog.Internal;

namespace NLog.Targets
{
	/// <summary>
	/// Logs text to Windows.Forms.Control.Text property control of specified Name.
	/// </summary>
	/// <example>
	/// <p>
	/// To set up the target in the <a href="config.html">configuration file</a>, 
	/// use the following syntax:
	/// </p>
	/// <code lang="XML" source="examples/targets/Configuration File/FormControl/NLog.config" />
	/// <p>
	/// The result is:
	/// </p>
	/// <img src="examples/targets/Screenshots/FormControl/FormControl.gif" />
	/// <p>
	/// To set up the log target programmatically similar to above use code like this:
	/// </p>
	/// <code lang="C#" source="examples/targets/Configuration API/FormControl/Form1.cs" />,
	/// </example>
	// Token: 0x02000114 RID: 276
	[Target("FormControl")]
	public sealed class FormControlTarget : TargetWithLayout
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Targets.FormControlTarget" /> class.
		/// </summary>
		/// <remarks>
		/// The default value of the layout is: <code>${longdate}|${level:uppercase=true}|${logger}|${message}</code>
		/// </remarks>
		// Token: 0x06000904 RID: 2308 RVA: 0x000204D0 File Offset: 0x0001E6D0
		public FormControlTarget()
		{
			this.Append = true;
		}

		/// <summary>
		/// Gets or sets the name of control to which NLog will log write log text.
		/// </summary>
		/// <docgen category="Form Options" order="10" />
		// Token: 0x170001D3 RID: 467
		// (get) Token: 0x06000905 RID: 2309 RVA: 0x000204E4 File Offset: 0x0001E6E4
		// (set) Token: 0x06000906 RID: 2310 RVA: 0x000204FB File Offset: 0x0001E6FB
		[RequiredParameter]
		public string ControlName { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether log text should be appended to the text of the control instead of overwriting it. </summary>
		/// <docgen category="Form Options" order="10" />
		// Token: 0x170001D4 RID: 468
		// (get) Token: 0x06000907 RID: 2311 RVA: 0x00020504 File Offset: 0x0001E704
		// (set) Token: 0x06000908 RID: 2312 RVA: 0x0002051B File Offset: 0x0001E71B
		[DefaultValue(true)]
		public bool Append { get; set; }

		/// <summary>
		/// Gets or sets the name of the Form on which the control is located.
		/// </summary>
		/// <docgen category="Form Options" order="10" />
		// Token: 0x170001D5 RID: 469
		// (get) Token: 0x06000909 RID: 2313 RVA: 0x00020524 File Offset: 0x0001E724
		// (set) Token: 0x0600090A RID: 2314 RVA: 0x0002053B File Offset: 0x0001E73B
		public string FormName { get; set; }

		/// <summary>
		/// Gets or sets whether new log entry are added to the start or the end of the control
		/// </summary>
		// Token: 0x170001D6 RID: 470
		// (get) Token: 0x0600090B RID: 2315 RVA: 0x00020544 File Offset: 0x0001E744
		// (set) Token: 0x0600090C RID: 2316 RVA: 0x0002055B File Offset: 0x0001E75B
		public bool ReverseOrder { get; set; }

		/// <summary>
		/// Log message to control.
		/// </summary>
		/// <param name="logEvent">
		/// The logging event.
		/// </param>
		// Token: 0x0600090D RID: 2317 RVA: 0x00020564 File Offset: 0x0001E764
		protected override void Write(LogEventInfo logEvent)
		{
			string text = this.Layout.Render(logEvent);
			this.FindControlAndSendTheMessage(text);
		}

		// Token: 0x0600090E RID: 2318 RVA: 0x00020588 File Offset: 0x0001E788
		private void FindControlAndSendTheMessage(string logMessage)
		{
			Form form = null;
			if (Form.ActiveForm != null)
			{
				form = Form.ActiveForm;
			}
			if (Application.OpenForms[this.FormName] != null)
			{
				form = Application.OpenForms[this.FormName];
			}
			if (form != null)
			{
				Control control = FormHelper.FindControl(this.ControlName, form);
				if (control != null)
				{
					control.BeginInvoke(new FormControlTarget.DelSendTheMessageToFormControl(this.SendTheMessageToFormControl), new object[] { control, logMessage });
				}
			}
		}

		// Token: 0x0600090F RID: 2319 RVA: 0x00020624 File Offset: 0x0001E824
		private void SendTheMessageToFormControl(Control ctrl, string logMessage)
		{
			if (this.Append)
			{
				if (this.ReverseOrder)
				{
					ctrl.Text = logMessage + ctrl.Text;
				}
				else
				{
					ctrl.Text += logMessage;
				}
			}
			else
			{
				ctrl.Text = logMessage;
			}
		}

		// Token: 0x02000115 RID: 277
		// (Invoke) Token: 0x06000911 RID: 2321
		private delegate void DelSendTheMessageToFormControl(Control ctrl, string logMessage);
	}
}
