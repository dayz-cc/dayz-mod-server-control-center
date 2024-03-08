namespace Crosire.Controlcenter.Plugin
{
	// Token: 0x02000004 RID: 4
	public partial class frmShow : global::System.Windows.Forms.Form
	{
		// Token: 0x06000015 RID: 21 RVA: 0x000036BD File Offset: 0x000018BD
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000016 RID: 22 RVA: 0x000036DC File Offset: 0x000018DC
		private void InitializeComponent()
		{
			this.textMain = new global::System.Windows.Forms.RichTextBox();
			base.SuspendLayout();
			this.textMain.Dock = global::System.Windows.Forms.DockStyle.Fill;
			this.textMain.Location = new global::System.Drawing.Point(0, 0);
			this.textMain.Name = "textMain";
			this.textMain.Size = new global::System.Drawing.Size(784, 562);
			this.textMain.TabIndex = 0;
			this.textMain.Text = "";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(784, 562);
			base.Controls.Add(this.textMain);
			base.Name = "frmShow";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.ResumeLayout(false);
		}

		// Token: 0x04000021 RID: 33
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000022 RID: 34
		private global::System.Windows.Forms.RichTextBox textMain;
	}
}
