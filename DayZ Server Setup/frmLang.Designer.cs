namespace Crosire.Controlcenter.Setup
{
	// Token: 0x02000005 RID: 5
	public partial class frmLang : global::System.Windows.Forms.Form
	{
		// Token: 0x06000008 RID: 8 RVA: 0x00002146 File Offset: 0x00000346
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000009 RID: 9 RVA: 0x00002168 File Offset: 0x00000368
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Crosire.Controlcenter.Setup.frmLang));
			this.labelChoose = new global::System.Windows.Forms.Label();
			this.cbxLanguage = new global::System.Windows.Forms.ComboBox();
			this.btnOk = new global::System.Windows.Forms.Button();
			base.SuspendLayout();
			this.labelChoose.AutoSize = true;
			this.labelChoose.Location = new global::System.Drawing.Point(12, 9);
			this.labelChoose.Name = "labelChoose";
			this.labelChoose.Size = new global::System.Drawing.Size(161, 13);
			this.labelChoose.TabIndex = 0;
			this.labelChoose.Text = "Choose your preferred language:";
			this.cbxLanguage.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.cbxLanguage.DropDownStyle = global::System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxLanguage.FormattingEnabled = true;
			this.cbxLanguage.Items.AddRange(new object[] { "en", "es", "de", "da", "ru", "zh-cn" });
			this.cbxLanguage.Location = new global::System.Drawing.Point(15, 25);
			this.cbxLanguage.Name = "cbxLanguage";
			this.cbxLanguage.Size = new global::System.Drawing.Size(257, 21);
			this.cbxLanguage.TabIndex = 1;
			this.cbxLanguage.SelectedIndexChanged += new global::System.EventHandler(this.cbxLanguage_SelectedIndexChanged);
			this.btnOk.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Right;
			this.btnOk.Location = new global::System.Drawing.Point(162, 52);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new global::System.Drawing.Size(110, 23);
			this.btnOk.TabIndex = 2;
			this.btnOk.Text = "&OK";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new global::System.EventHandler(this.btnOk_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(284, 88);
			base.ControlBox = false;
			base.Controls.Add(this.btnOk);
			base.Controls.Add(this.cbxLanguage);
			base.Controls.Add(this.labelChoose);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "frmLang";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = " Language Selection";
			base.TopMost = true;
			base.Load += new global::System.EventHandler(this.frmLang_Load);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x0400000E RID: 14
		private global::System.ComponentModel.IContainer components;

		// Token: 0x0400000F RID: 15
		private global::System.Windows.Forms.Label labelChoose;

		// Token: 0x04000010 RID: 16
		private global::System.Windows.Forms.ComboBox cbxLanguage;

		// Token: 0x04000011 RID: 17
		private global::System.Windows.Forms.Button btnOk;
	}
}
