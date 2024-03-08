using System.Drawing;
using System.Windows.Forms;

namespace Crosire.Library.Forms
{
	public static class MessageBoxTop
	{
		public static DialogResult Show(string text)
		{
			return Show(text, string.Empty, MessageBoxButtons.OK, MessageBoxIcon.None);
		}

		public static DialogResult Show(string text, string caption)
		{
			return Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.None);
		}

		public static DialogResult Show(string text, string caption, MessageBoxButtons buttons)
		{
			return Show(text, caption, buttons, MessageBoxIcon.None);
		}

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
			DialogResult result = MessageBox.Show(form, text, caption, buttons, icon);
			form.Dispose();
			return result;
		}
	}
}
