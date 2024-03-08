using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Crosire.Controlcenter.Plugin
{
	public class frmShow : Form
	{
		private IContainer components;

		private RichTextBox textMain;

		public frmShow()
		{
			InitializeComponent();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.textMain = new System.Windows.Forms.RichTextBox();
			base.SuspendLayout();
			this.textMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textMain.Location = new System.Drawing.Point(0, 0);
			this.textMain.Name = "textMain";
			this.textMain.Size = new System.Drawing.Size(784, 562);
			this.textMain.TabIndex = 0;
			this.textMain.Text = "";
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(784, 562);
			base.Controls.Add(this.textMain);
			base.Name = "frmShow";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.ResumeLayout(false);
		}
	}
}
