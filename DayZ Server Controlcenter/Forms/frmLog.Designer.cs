namespace Crosire.Controlcenter.Forms
{
	// Token: 0x02000008 RID: 8
	public partial class frmLog : global::System.Windows.Forms.Form
	{
		// Token: 0x0600003B RID: 59 RVA: 0x00007C68 File Offset: 0x00005E68
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00007CA0 File Offset: 0x00005EA0
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Crosire.Controlcenter.Forms.frmLog));
			this.textLog = new global::System.Windows.Forms.RichTextBox();
			this.textSend = new global::System.Windows.Forms.TextBox();
			base.SuspendLayout();
			this.textLog.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.textLog.BackColor = global::System.Drawing.Color.Black;
			this.textLog.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 8.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.textLog.ForeColor = global::System.Drawing.SystemColors.HighlightText;
			this.textLog.Location = new global::System.Drawing.Point(0, 0);
			this.textLog.Name = "textLog";
			this.textLog.ReadOnly = true;
			this.textLog.ScrollBars = global::System.Windows.Forms.RichTextBoxScrollBars.ForcedVertical;
			this.textLog.Size = new global::System.Drawing.Size(364, 620);
			this.textLog.TabIndex = 2;
			this.textLog.Text = "";
			this.textSend.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.textSend.Location = new global::System.Drawing.Point(3, 621);
			this.textSend.MaxLength = 200;
			this.textSend.Name = "textSend";
			this.textSend.Size = new global::System.Drawing.Size(358, 20);
			this.textSend.TabIndex = 3;
			this.textSend.KeyDown += new global::System.Windows.Forms.KeyEventHandler(this.textSend_KeyDown);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(364, 644);
			base.ControlBox = false;
			base.Controls.Add(this.textSend);
			base.Controls.Add(this.textLog);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			this.MaximumSize = new global::System.Drawing.Size(380, 10000000);
			base.MinimizeBox = false;
			this.MinimumSize = new global::System.Drawing.Size(380, 650);
			base.Name = "frmLog";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.SizeGripStyle = global::System.Windows.Forms.SizeGripStyle.Hide;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.Manual;
			this.Text = " ";
			base.FormClosing += new global::System.Windows.Forms.FormClosingEventHandler(this.frmLog_FormClosing);
			base.Load += new global::System.EventHandler(this.frmLog_Load);
			base.Move += new global::System.EventHandler(this.frmLog_Move);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400005A RID: 90
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x0400005B RID: 91
		private global::System.Windows.Forms.RichTextBox textLog;

		// Token: 0x0400005C RID: 92
		private global::System.Windows.Forms.TextBox textSend;
	}
}
