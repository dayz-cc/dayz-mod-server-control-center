namespace Crosire.Controlcenter.Plugin
{
	// Token: 0x02000002 RID: 2
	public partial class frmCreate : global::System.Windows.Forms.Form
	{
		// Token: 0x06000007 RID: 7 RVA: 0x000023E8 File Offset: 0x000005E8
		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00002408 File Offset: 0x00000608
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			this.listFiles = new global::System.Windows.Forms.ListView();
			this.btnAdd = new global::System.Windows.Forms.Button();
			this.textFile = new global::System.Windows.Forms.TextBox();
			this.btnFinish = new global::System.Windows.Forms.Button();
			this.textName = new global::System.Windows.Forms.TextBox();
			this.textVersion = new global::System.Windows.Forms.TextBox();
			this.menuFiles = new global::System.Windows.Forms.ContextMenuStrip(this.components);
			this.removeToolStripMenuItem = new global::System.Windows.Forms.ToolStripMenuItem();
			this.menuFiles.SuspendLayout();
			base.SuspendLayout();
			this.listFiles.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.listFiles.Location = new global::System.Drawing.Point(12, 65);
			this.listFiles.Name = "listFiles";
			this.listFiles.Size = new global::System.Drawing.Size(502, 156);
			this.listFiles.TabIndex = 0;
			this.listFiles.UseCompatibleStateImageBehavior = false;
			this.listFiles.View = global::System.Windows.Forms.View.List;
			this.listFiles.Click += new global::System.EventHandler(this.listFiles_Click);
			this.btnAdd.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Right;
			this.btnAdd.Location = new global::System.Drawing.Point(439, 36);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new global::System.Drawing.Size(75, 23);
			this.btnAdd.TabIndex = 1;
			this.btnAdd.Text = "Add";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new global::System.EventHandler(this.btnAdd_Click);
			this.textFile.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.textFile.Location = new global::System.Drawing.Point(12, 38);
			this.textFile.Name = "textFile";
			this.textFile.Size = new global::System.Drawing.Size(421, 20);
			this.textFile.TabIndex = 2;
			this.textFile.Click += new global::System.EventHandler(this.textFile_Click);
			this.btnFinish.Anchor = global::System.Windows.Forms.AnchorStyles.Bottom | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.btnFinish.Enabled = false;
			this.btnFinish.Location = new global::System.Drawing.Point(12, 227);
			this.btnFinish.Name = "btnFinish";
			this.btnFinish.Size = new global::System.Drawing.Size(502, 23);
			this.btnFinish.TabIndex = 3;
			this.btnFinish.Text = "Create Plugin";
			this.btnFinish.UseVisualStyleBackColor = true;
			this.btnFinish.Click += new global::System.EventHandler(this.btnFinish_Click);
			this.textName.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.textName.Location = new global::System.Drawing.Point(12, 12);
			this.textName.Name = "textName";
			this.textName.Size = new global::System.Drawing.Size(421, 20);
			this.textName.TabIndex = 4;
			this.textName.Text = "My Plugin";
			this.textVersion.Anchor = global::System.Windows.Forms.AnchorStyles.Top | global::System.Windows.Forms.AnchorStyles.Left | global::System.Windows.Forms.AnchorStyles.Right;
			this.textVersion.Location = new global::System.Drawing.Point(439, 12);
			this.textVersion.Name = "textVersion";
			this.textVersion.Size = new global::System.Drawing.Size(75, 20);
			this.textVersion.TabIndex = 5;
			this.textVersion.Text = "1.0";
			this.menuFiles.Items.AddRange(new global::System.Windows.Forms.ToolStripItem[] { this.removeToolStripMenuItem });
			this.menuFiles.Name = "menuFiles";
			this.menuFiles.Size = new global::System.Drawing.Size(153, 48);
			this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
			this.removeToolStripMenuItem.Size = new global::System.Drawing.Size(152, 22);
			this.removeToolStripMenuItem.Text = "Remove";
			this.removeToolStripMenuItem.Click += new global::System.EventHandler(this.btnRemove_Click);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new global::System.Drawing.Size(526, 262);
			base.Controls.Add(this.textVersion);
			base.Controls.Add(this.textName);
			base.Controls.Add(this.btnFinish);
			base.Controls.Add(this.textFile);
			base.Controls.Add(this.btnAdd);
			base.Controls.Add(this.listFiles);
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "frmCreate";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			this.Text = "Create new plugin";
			this.menuFiles.ResumeLayout(false);
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000001 RID: 1
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000002 RID: 2
		private global::System.Windows.Forms.ListView listFiles;

		// Token: 0x04000003 RID: 3
		private global::System.Windows.Forms.Button btnAdd;

		// Token: 0x04000004 RID: 4
		private global::System.Windows.Forms.TextBox textFile;

		// Token: 0x04000005 RID: 5
		private global::System.Windows.Forms.Button btnFinish;

		// Token: 0x04000006 RID: 6
		private global::System.Windows.Forms.TextBox textName;

		// Token: 0x04000007 RID: 7
		private global::System.Windows.Forms.TextBox textVersion;

		// Token: 0x04000008 RID: 8
		private global::System.Windows.Forms.ContextMenuStrip menuFiles;

		// Token: 0x04000009 RID: 9
		private global::System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
	}
}
