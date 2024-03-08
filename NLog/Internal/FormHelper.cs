using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace NLog.Internal
{
	/// <summary>
	/// Form helper methods.
	/// </summary>
	// Token: 0x02000069 RID: 105
	internal class FormHelper
	{
		/// <summary>
		/// Creates RichTextBox and docks in parentForm.
		/// </summary>
		/// <param name="name">Name of RichTextBox.</param>
		/// <param name="parentForm">Form to dock RichTextBox.</param>
		/// <returns>Created RichTextBox.</returns>
		// Token: 0x060002A9 RID: 681 RVA: 0x0000AC94 File Offset: 0x00008E94
		[SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "Objects are disposed elsewhere")]
		internal static RichTextBox CreateRichTextBox(string name, Form parentForm)
		{
			RichTextBox richTextBox = new RichTextBox();
			richTextBox.Dock = DockStyle.Fill;
			richTextBox.Location = new Point(0, 0);
			richTextBox.Name = name;
			richTextBox.Size = new Size(parentForm.Width, parentForm.Height);
			parentForm.Controls.Add(richTextBox);
			return richTextBox;
		}

		/// <summary>
		/// Finds control embedded on searchControl.
		/// </summary>
		/// <param name="name">Name of the control.</param>
		/// <param name="searchControl">Control in which we're searching for control.</param>
		/// <returns>A value of null if no control has been found.</returns>
		// Token: 0x060002AA RID: 682 RVA: 0x0000ACF0 File Offset: 0x00008EF0
		internal static Control FindControl(string name, Control searchControl)
		{
			Control control;
			if (searchControl.Name == name)
			{
				control = searchControl;
			}
			else
			{
				foreach (object obj in searchControl.Controls)
				{
					Control control2 = (Control)obj;
					Control control3 = FormHelper.FindControl(name, control2);
					if (control3 != null)
					{
						return control3;
					}
				}
				control = null;
			}
			return control;
		}

		/// <summary>
		/// Finds control of specified type embended on searchControl.
		/// </summary>
		/// <typeparam name="TControl">The type of the control.</typeparam>
		/// <param name="name">Name of the control.</param>
		/// <param name="searchControl">Control in which we're searching for control.</param>
		/// <returns>
		/// A value of null if no control has been found.
		/// </returns>
		// Token: 0x060002AB RID: 683 RVA: 0x0000AD8C File Offset: 0x00008F8C
		internal static TControl FindControl<TControl>(string name, Control searchControl) where TControl : Control
		{
			if (searchControl.Name == name)
			{
				TControl tcontrol = searchControl as TControl;
				if (tcontrol != null)
				{
					return tcontrol;
				}
			}
			foreach (object obj in searchControl.Controls)
			{
				Control control = (Control)obj;
				TControl tcontrol = FormHelper.FindControl<TControl>(name, control);
				if (tcontrol != null)
				{
					return tcontrol;
				}
			}
			return default(TControl);
		}

		/// <summary>
		/// Creates a form.
		/// </summary>
		/// <param name="name">Name of form.</param>
		/// <param name="width">Width of form.</param>
		/// <param name="height">Height of form.</param>
		/// <param name="show">Auto show form.</param>
		/// <param name="showMinimized">If set to <c>true</c> the form will be minimized.</param>
		/// <param name="toolWindow">If set to <c>true</c> the form will be created as tool window.</param>
		/// <returns>Created form.</returns>
		// Token: 0x060002AC RID: 684 RVA: 0x0000AE50 File Offset: 0x00009050
		[SuppressMessage("Microsoft.Globalization", "CA1303:Do not pass literals as localized parameters", MessageId = "System.Windows.Forms.Control.set_Text(System.String)", Justification = "Does not need to be localized.")]
		[SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "Objects are disposed elsewhere")]
		[SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", Justification = "Using property names in message.")]
		internal static Form CreateForm(string name, int width, int height, bool show, bool showMinimized, bool toolWindow)
		{
			Form form = new Form
			{
				Name = name,
				Text = "NLog",
				Icon = FormHelper.GetNLogIcon()
			};
			if (toolWindow)
			{
				form.FormBorderStyle = FormBorderStyle.SizableToolWindow;
			}
			if (width > 0)
			{
				form.Width = width;
			}
			if (height > 0)
			{
				form.Height = height;
			}
			if (show)
			{
				if (showMinimized)
				{
					form.WindowState = FormWindowState.Minimized;
					form.Show();
				}
				else
				{
					form.Show();
				}
			}
			return form;
		}

		// Token: 0x060002AD RID: 685 RVA: 0x0000AEF8 File Offset: 0x000090F8
		private static Icon GetNLogIcon()
		{
			Icon icon;
			using (Stream manifestResourceStream = typeof(FormHelper).Assembly.GetManifestResourceStream("NLog.Resources.NLog.ico"))
			{
				icon = new Icon(manifestResourceStream);
			}
			return icon;
		}
	}
}
