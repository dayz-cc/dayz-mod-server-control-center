namespace Crosire.Controlcenter.Plugin
{
	// Token: 0x02000003 RID: 3
	public partial class frmMain : global::System.Windows.Forms.Form
	{
		// Token: 0x06000011 RID: 17 RVA: 0x00003017 File Offset: 0x00001217
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00003038 File Offset: 0x00001238
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Crosire.Controlcenter.Plugin.frmMain));
			this.progressbar = new global::System.Windows.Forms.ProgressBar();
			this.btnInstall = new global::System.Windows.Forms.Button();
			this.labelInstalledPlugins = new global::System.Windows.Forms.Label();
			this.listPlugins = new global::System.Windows.Forms.ListBox();
			this.menuPlugin = new global::System.Windows.Forms.ContextMenuStrip(this.components);
			this.removeToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new global::System.Windows.Forms.ToolStripSeparator();
			this.showDiffToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.showPatchToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.btnCreate = new global::System.Windows.Forms.Button();
			this.labelStatus = new global::System.Windows.Forms.Label();
			this.menuPlugin.SuspendLayout();
			base.SuspendLayout();
			this.progressbar.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.progressbar.Location = new global::System.Drawing.Point(12, 9);
			this.progressbar.Name = "progressbar";
			this.progressbar.Size = new global::System.Drawing.Size(260, 23);
			this.progressbar.TabIndex = 0;
			this.progressbar.Visible = false;
			this.btnInstall.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.btnInstall.Location = new global::System.Drawing.Point(12, 38);
			this.btnInstall.Name = "btnInstall";
			this.btnInstall.Size = new global::System.Drawing.Size(260, 23);
			this.btnInstall.TabIndex = 0;
			this.btnInstall.Text = "Install";
			this.btnInstall.UseVisualStyleBackColor = true;
			this.btnInstall.Click += new global::System.EventHandler(this.btnInstall_Click);
			this.labelInstalledPlugins.AutoSize = true;
			this.labelInstalledPlugins.Location = new global::System.Drawing.Point(12, 76);
			this.labelInstalledPlugins.Name = "labelInstalledPlugins";
			this.labelInstalledPlugins.Size = new global::System.Drawing.Size(86, 13);
			this.labelInstalledPlugins.TabIndex = 3;
			this.labelInstalledPlugins.Text = "Installed Plugins:";
			this.listPlugins.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.listPlugins.FormattingEnabled = true;
			this.listPlugins.Location = new global::System.Drawing.Point(15, 92);
			this.listPlugins.Name = "listPlugins";
			this.listPlugins.ScrollAlwaysVisible = true;
			this.listPlugins.Size = new global::System.Drawing.Size(257, 147);
			this.listPlugins.TabIndex = 4;
			this.listPlugins.Click += new global::System.EventHandler(this.listPlugins_Click);
			this.menuPlugin.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.removeToolStripMenuItem, this.toolStripSeparator1, this.showDiffToolStripMenuItem, this.showPatchToolStripMenuItem });
			this.menuPlugin.Name = "menuPlugin";
			this.menuPlugin.Size = new global::System.Drawing.Size(137, 76);
			this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
			this.removeToolStripMenuItem.Size = new global::System.Drawing.Size(136, 22);
			this.removeToolStripMenuItem.Text = "Remove";
			this.removeToolStripMenuItem.Click += new global::System.EventHandler(this.btnRemove_Click);
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new global::System.Drawing.Size(133, 6);
			this.showDiffToolStripMenuItem.Name = "showDiffToolStripMenuItem";
			this.showDiffToolStripMenuItem.Size = new global::System.Drawing.Size(136, 22);
			this.showDiffToolStripMenuItem.Text = "Show Diff";
			this.showDiffToolStripMenuItem.Click += new global::System.EventHandler(this.btnShowDiff_Click);
			this.showPatchToolStripMenuItem.Name = "showPatchToolStripMenuItem";
			this.showPatchToolStripMenuItem.Size = new global::System.Drawing.Size(136, 22);
			this.showPatchToolStripMenuItem.Text = "Show Patch";
			this.showPatchToolStripMenuItem.Click += new global::System.EventHandler(this.btnShowPatch_Click);
			this.btnCreate.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.btnCreate.Location = new global::System.Drawing.Point(12, 9);
			this.btnCreate.Name = "btnCreate";
			this.btnCreate.Size = new global::System.Drawing.Size(260, 23);
			this.btnCreate.TabIndex = 1;
			this.btnCreate.Text = "Create";
			this.btnCreate.UseVisualStyleBackColor = true;
			this.btnCreate.Click += new global::System.EventHandler(this.btnCreate_Click);
			this.labelStatus.AutoSize = true;
			this.labelStatus.BorderStyle = global::System.Windows.Forms.BorderStyle.FixedSingle;
			this.labelStatus.Location = new global::System.Drawing.Point(16, 14);
			this.labelStatus.Name = "labelStatus";
			this.labelStatus.Size = new global::System.Drawing.Size(18, 15);
			this.labelStatus.TabIndex = 5;
			this.labelStatus.Text = "...";
			this.labelStatus.Visible = false;
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(284, 252);
			base.Controls.Add(this.labelStatus);
			base.Controls.Add(this.listPlugins);
			base.Controls.Add(this.labelInstalledPlugins);
			base.Controls.Add(this.progressbar);
			base.Controls.Add(this.btnInstall);
			base.Controls.Add(this.btnCreate);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Icon = (global::System.Drawing.Icon)componentResourceManager.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "frmMain";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.SizeGripStyle = global::System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "DayZ Server Plugin Manager";
			base.Load += new global::System.EventHandler(this.frmPlugin_Load);
			this.menuPlugin.ResumeLayout(false);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000015 RID: 21
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000016 RID: 22
		private global::System.Windows.Forms.ProgressBar progressbar;

		// Token: 0x04000017 RID: 23
		private global::System.Windows.Forms.Button btnInstall;

		// Token: 0x04000018 RID: 24
		private global::System.Windows.Forms.Label labelInstalledPlugins;

		// Token: 0x04000019 RID: 25
		private global::System.Windows.Forms.ListBox listPlugins;

		// Token: 0x0400001A RID: 26
		private global::System.Windows.Forms.ContextMenuStrip menuPlugin;

		// Token: 0x0400001B RID: 27
		private global::System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;

		// Token: 0x0400001C RID: 28
		private global::System.Windows.Forms.ToolStripSeparator toolStripSeparator1;

		// Token: 0x0400001D RID: 29
		private global::System.Windows.Forms.ToolStripMenuItem showDiffToolStripMenuItem;

		// Token: 0x0400001E RID: 30
		private global::System.Windows.Forms.ToolStripMenuItem showPatchToolStripMenuItem;

		// Token: 0x0400001F RID: 31
		private global::System.Windows.Forms.Button btnCreate;

		// Token: 0x04000020 RID: 32
		private global::System.Windows.Forms.Label labelStatus;
	}
}
