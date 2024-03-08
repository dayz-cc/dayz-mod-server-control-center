using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using Crosire.Controlcenter.Setup.Properties;

namespace Crosire.Controlcenter.Setup
{
	public class frmLang : Form
	{
		public static string language;

		private IContainer components;

		private Label labelChoose;

		private ComboBox cbxLanguage;

		private Button btnOk;

		public frmLang()
		{
			InitializeComponent();
		}

		private void frmLang_Load(object sender, EventArgs e)
		{
			labelChoose.Text = Resources.sentence_chooselanguage;
			cbxLanguage.SelectedItem = Thread.CurrentThread.CurrentUICulture.IetfLanguageTag.Substring(0, 2).ToLower();
		}

		private void btnOk_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void cbxLanguage_SelectedIndexChanged(object sender, EventArgs e)
		{
			language = cbxLanguage.SelectedItem.ToString();
			Thread.CurrentThread.CurrentUICulture = new CultureInfo(language);
			labelChoose.Text = Resources.sentence_chooselanguage;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Crosire.Controlcenter.Setup.frmLang));
			this.labelChoose = new System.Windows.Forms.Label();
			this.cbxLanguage = new System.Windows.Forms.ComboBox();
			this.btnOk = new System.Windows.Forms.Button();
			base.SuspendLayout();
			this.labelChoose.AutoSize = true;
			this.labelChoose.Location = new System.Drawing.Point(12, 9);
			this.labelChoose.Name = "labelChoose";
			this.labelChoose.Size = new System.Drawing.Size(116, 13);
			this.labelChoose.TabIndex = 0;
			this.labelChoose.Text = "Choose your language:";
			this.cbxLanguage.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.cbxLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbxLanguage.FormattingEnabled = true;
			this.cbxLanguage.Items.AddRange(new object[6] { "en", "es", "de", "da", "ru", "zh-cn" });
			this.cbxLanguage.Location = new System.Drawing.Point(15, 25);
			this.cbxLanguage.Name = "cbxLanguage";
			this.cbxLanguage.Size = new System.Drawing.Size(257, 21);
			this.cbxLanguage.TabIndex = 1;
			this.cbxLanguage.SelectedIndexChanged += new System.EventHandler(cbxLanguage_SelectedIndexChanged);
			this.btnOk.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.btnOk.Location = new System.Drawing.Point(162, 52);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(110, 23);
			this.btnOk.TabIndex = 2;
			this.btnOk.Text = "&OK";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(btnOk_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(284, 88);
			base.ControlBox = false;
			base.Controls.Add(this.btnOk);
			base.Controls.Add(this.cbxLanguage);
			base.Controls.Add(this.labelChoose);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "frmLang";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = " ";
			base.TopMost = true;
			base.Load += new System.EventHandler(frmLang_Load);
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
