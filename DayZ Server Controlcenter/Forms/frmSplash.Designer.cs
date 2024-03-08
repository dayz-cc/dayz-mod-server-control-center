namespace Crosire.Controlcenter.Forms
{
	// Token: 0x0200000A RID: 10
	public partial class frmSplash : global::System.Windows.Forms.Form
	{
		// Token: 0x06000083 RID: 131 RVA: 0x00017DCC File Offset: 0x00015FCC
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000084 RID: 132 RVA: 0x00017E04 File Offset: 0x00016004
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Crosire.Controlcenter.Forms.frmSplash));
			this.workerMain = new global::System.ComponentModel.BackgroundWorker();
			this.labelTitle = new global::System.Windows.Forms.Label();
			this.labelCompany = new global::System.Windows.Forms.Label();
			this.labelVersion = new global::System.Windows.Forms.Label();
			this.labelCopyright = new global::System.Windows.Forms.Label();
			this.pictureBanner = new global::System.Windows.Forms.PictureBox();
			this.labelProgress = new global::System.Windows.Forms.Label();
			this.progressUpdate = new global::System.Windows.Forms.ProgressBar();
			this.textProgress = new global::System.Windows.Forms.RichTextBox();
			this.pictureSupporter = new global::System.Windows.Forms.PictureBox();
			this.lblSupporter = new global::System.Windows.Forms.Label();
			this.lblMaintainer = new global::System.Windows.Forms.Label();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBanner).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureSupporter).BeginInit();
			base.SuspendLayout();
			this.workerMain.DoWork += new global::System.ComponentModel.DoWorkEventHandler(this.workerMain_DoWork);
			this.workerMain.RunWorkerCompleted += new global::System.ComponentModel.RunWorkerCompletedEventHandler(this.workerMain_RunWorkerCompleted);
			this.labelTitle.Anchor = global::System.Windows.Forms.AnchorStyles.Top;
			this.labelTitle.BackColor = global::System.Drawing.Color.Transparent;
			this.labelTitle.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 18f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.labelTitle.ForeColor = global::System.Drawing.Color.White;
			this.labelTitle.Location = new global::System.Drawing.Point(9, 91);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new global::System.Drawing.Size(477, 26);
			this.labelTitle.TabIndex = 19;
			this.labelTitle.Text = "Title";
			this.labelTitle.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.labelCompany.AutoSize = true;
			this.labelCompany.BackColor = global::System.Drawing.Color.Transparent;
			this.labelCompany.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.labelCompany.ForeColor = global::System.Drawing.Color.White;
			this.labelCompany.Location = new global::System.Drawing.Point(13, 293);
			this.labelCompany.Name = "labelCompany";
			this.labelCompany.Size = new global::System.Drawing.Size(105, 15);
			this.labelCompany.TabIndex = 18;
			this.labelCompany.Text = "Written by: Crosire";
			this.labelVersion.AutoSize = true;
			this.labelVersion.BackColor = global::System.Drawing.Color.Transparent;
			this.labelVersion.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.labelVersion.ForeColor = global::System.Drawing.Color.Gray;
			this.labelVersion.Location = new global::System.Drawing.Point(396, 76);
			this.labelVersion.Name = "labelVersion";
			this.labelVersion.Size = new global::System.Drawing.Size(88, 15);
			this.labelVersion.TabIndex = 17;
			this.labelVersion.Text = "Version 0.0.0.0";
			this.labelCopyright.BackColor = global::System.Drawing.Color.Transparent;
			this.labelCopyright.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.labelCopyright.ForeColor = global::System.Drawing.Color.Gray;
			this.labelCopyright.Location = new global::System.Drawing.Point(13, 389);
			this.labelCopyright.Name = "labelCopyright";
			this.labelCopyright.Size = new global::System.Drawing.Size(471, 15);
			this.labelCopyright.TabIndex = 16;
			this.labelCopyright.Text = "Copyright ©2012 - 2013 Crosire and DayZ Priv. All rights reserved.";
			this.labelCopyright.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.pictureBanner.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom;
			this.pictureBanner.BackColor = global::System.Drawing.Color.Transparent;
			this.pictureBanner.Image = (global::System.Drawing.Image)componentResourceManager.GetObject("pictureBanner.Image");
			this.pictureBanner.Location = new global::System.Drawing.Point(12, 12);
			this.pictureBanner.Name = "pictureBanner";
			this.pictureBanner.Size = new global::System.Drawing.Size(472, 84);
			this.pictureBanner.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBanner.TabIndex = 12;
			this.pictureBanner.TabStop = false;
			this.pictureBanner.Click += new global::System.EventHandler(this.pictureBanner_Click);
			this.pictureBanner.MouseLeave += new global::System.EventHandler(this.pictureBanner_MouseLeave);
			this.pictureBanner.MouseHover += new global::System.EventHandler(this.pictureBanner_MouseHover);
			this.labelProgress.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left;
			this.labelProgress.AutoSize = true;
			this.labelProgress.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.labelProgress.Location = new global::System.Drawing.Point(16, 271);
			this.labelProgress.Name = "labelProgress";
			this.labelProgress.Size = new global::System.Drawing.Size(66, 15);
			this.labelProgress.TabIndex = 24;
			this.labelProgress.Text = "Initializing ...";
			this.progressUpdate.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.progressUpdate.Location = new global::System.Drawing.Point(12, 267);
			this.progressUpdate.Name = "progressUpdate";
			this.progressUpdate.Size = new global::System.Drawing.Size(474, 23);
			this.progressUpdate.TabIndex = 23;
			this.textProgress.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.textProgress.BackColor = global::System.Drawing.SystemColors.Control;
			this.textProgress.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.textProgress.Cursor = global::System.Windows.Forms.Cursors.Default;
			this.textProgress.DetectUrls = false;
			this.textProgress.ForeColor = global::System.Drawing.SystemColors.ControlText;
			this.textProgress.Location = new global::System.Drawing.Point(12, 123);
			this.textProgress.Name = "textProgress";
			this.textProgress.ReadOnly = true;
			this.textProgress.ScrollBars = global::System.Windows.Forms.RichTextBoxScrollBars.Vertical;
			this.textProgress.Size = new global::System.Drawing.Size(472, 138);
			this.textProgress.TabIndex = 22;
			this.textProgress.TabStop = false;
			this.textProgress.Text = "Initializing ...";
			this.pictureSupporter.BackColor = global::System.Drawing.Color.Transparent;
			this.pictureSupporter.BackgroundImage = global::Crosire.Controlcenter.Properties.Resources.logo_dayzpriv;
			this.pictureSupporter.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.Zoom;
			this.pictureSupporter.Location = new global::System.Drawing.Point(12, 336);
			this.pictureSupporter.Name = "pictureSupporter";
			this.pictureSupporter.Size = new global::System.Drawing.Size(472, 50);
			this.pictureSupporter.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureSupporter.TabIndex = 25;
			this.pictureSupporter.TabStop = false;
			this.pictureSupporter.Click += new global::System.EventHandler(this.pictureSupporter_Click);
			this.pictureSupporter.MouseLeave += new global::System.EventHandler(this.pictureSupporter_MouseLeave);
			this.pictureSupporter.MouseHover += new global::System.EventHandler(this.pictureSupporter_MouseHover);
			this.lblSupporter.Anchor = global::System.Windows.Forms.AnchorStyles.Top;
			this.lblSupporter.BackColor = global::System.Drawing.Color.Transparent;
			this.lblSupporter.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 12f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblSupporter.ForeColor = global::System.Drawing.Color.White;
			this.lblSupporter.Location = new global::System.Drawing.Point(10, 308);
			this.lblSupporter.Name = "lblSupporter";
			this.lblSupporter.Size = new global::System.Drawing.Size(472, 25);
			this.lblSupporter.TabIndex = 30;
			this.lblSupporter.Text = "Proudly Supported and Maintained By";
			this.lblSupporter.TextAlign = global::System.Drawing.ContentAlignment.MiddleCenter;
			this.lblMaintainer.AutoSize = true;
			this.lblMaintainer.BackColor = global::System.Drawing.Color.Transparent;
			this.lblMaintainer.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 9f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.lblMaintainer.ForeColor = global::System.Drawing.Color.White;
			this.lblMaintainer.Location = new global::System.Drawing.Point(339, 293);
			this.lblMaintainer.Name = "lblMaintainer";
			this.lblMaintainer.Size = new global::System.Drawing.Size(147, 15);
			this.lblMaintainer.TabIndex = 31;
			this.lblMaintainer.Text = "Maintained by: NovoGeek";
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = global::Crosire.Controlcenter.Properties.Resources.background;
			this.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.Stretch;
			base.ClientSize = new global::System.Drawing.Size(498, 413);
			base.Controls.Add(this.lblMaintainer);
			base.Controls.Add(this.lblSupporter);
			base.Controls.Add(this.pictureSupporter);
			base.Controls.Add(this.labelProgress);
			base.Controls.Add(this.progressUpdate);
			base.Controls.Add(this.textProgress);
			base.Controls.Add(this.labelCopyright);
			base.Controls.Add(this.labelVersion);
			base.Controls.Add(this.labelCompany);
			base.Controls.Add(this.labelTitle);
			base.Controls.Add(this.pictureBanner);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			this.MinimumSize = new global::System.Drawing.Size(498, 305);
			base.Name = "frmSplash";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.StartPosition = global::System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "DayZ Server Controlcenter";
			base.TopMost = true;
			base.Load += new global::System.EventHandler(this.frmSplash_Load);
			base.Shown += new global::System.EventHandler(this.frmSplash_Shown);
			((global::System.ComponentModel.ISupportInitialize)this.pictureBanner).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureSupporter).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000143 RID: 323
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000144 RID: 324
		private global::System.ComponentModel.BackgroundWorker workerMain;

		// Token: 0x04000145 RID: 325
		private global::System.Windows.Forms.Label labelTitle;

		// Token: 0x04000146 RID: 326
		private global::System.Windows.Forms.Label labelCompany;

		// Token: 0x04000147 RID: 327
		private global::System.Windows.Forms.Label labelVersion;

		// Token: 0x04000148 RID: 328
		private global::System.Windows.Forms.Label labelCopyright;

		// Token: 0x04000149 RID: 329
		private global::System.Windows.Forms.PictureBox pictureBanner;

		// Token: 0x0400014A RID: 330
		private global::System.Windows.Forms.Label labelProgress;

		// Token: 0x0400014B RID: 331
		private global::System.Windows.Forms.ProgressBar progressUpdate;

		// Token: 0x0400014C RID: 332
		private global::System.Windows.Forms.RichTextBox textProgress;

		// Token: 0x0400014D RID: 333
		private global::System.Windows.Forms.PictureBox pictureSupporter;

		// Token: 0x0400014E RID: 334
		private global::System.Windows.Forms.Label lblSupporter;

		// Token: 0x0400014F RID: 335
		private global::System.Windows.Forms.Label lblMaintainer;
	}
}
