using System;
using System.Drawing;
using System.Windows.Forms;

namespace Crosire.Library.Forms
{
	// Token: 0x02000002 RID: 2
	public static class MessageBoxTop
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public static DialogResult Show(string text)
		{
			return MessageBoxTop.Show(text, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.None);
		}

		// Token: 0x06000002 RID: 2 RVA: 0x0000205F File Offset: 0x0000025F
		public static DialogResult Show(string text, string caption)
		{
			return MessageBoxTop.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.None);
		}

		// Token: 0x06000003 RID: 3 RVA: 0x0000206A File Offset: 0x0000026A
		public static DialogResult Show(string text, string caption, MessageBoxButtons buttons)
		{
			return MessageBoxTop.Show(text, caption, buttons, MessageBoxIcon.None);
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002078 File Offset: 0x00000278
		public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
		{
			Form form = new Form();
			form.Size = new Size(1, 1);
			form.StartPosition = FormStartPosition.Manual;
			Rectangle virtualScreen = SystemInformation.VirtualScreen;
			form.Location = new Point(virtualScreen.Bottom + 10, virtualScreen.Right + 10);
			form.Show();
			form.Focus();
			form.BringToFront();
			form.TopMost = true;
			DialogResult dialogResult = MessageBox.Show(form, text, caption, buttons, icon);
			form.Dispose();
			return dialogResult;
		}
	}
}
