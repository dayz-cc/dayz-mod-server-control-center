using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ICSharpCode.SharpZipLib.Zip;

namespace Crosire.Controlcenter.Plugin
{
	public class frmCreate : Form
	{
		private IContainer components;

		private ListView listFiles;

		private Button btnAdd;

		private TextBox textFile;

		private Button btnFinish;

		private TextBox textName;

		private TextBox textVersion;

		private ContextMenuStrip menuFiles;

		private ToolStripMenuItem removeToolStripMenuItem;

		public frmCreate()
		{
			InitializeComponent();
		}

		private void textFile_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.InitialDirectory = frmMain.pathArma;
			openFileDialog.Multiselect = false;
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				textFile.Text = openFileDialog.FileName;
			}
		}

		private void listFiles_Click(object sender, EventArgs e)
		{
			if (listFiles.SelectedItems != null)
			{
				menuFiles.Show(Cursor.Position);
			}
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(textFile.Text))
			{
				if (textFile.Text.Contains(frmMain.pathArma) || textFile.Text.Contains(frmMain.pathMain) || Path.GetExtension(textFile.Text) == ".sql")
				{
					listFiles.Items.Add(textFile.Text);
				}
				else
				{
					MessageBox.Show("You haven't selected a valid file. It has to be either in your Arma or Pluginmanager directory or with the file extension \"sql\"!");
				}
				textFile.Text = "";
			}
			else
			{
				textFile_Click(null, EventArgs.Empty);
				btnAdd_Click(sender, e);
			}
			btnFinish.Enabled = listFiles.Items.Count > 0;
		}

		private void btnRemove_Click(object sender, EventArgs e)
		{
			if (listFiles.SelectedItems != null)
			{
				listFiles.Items.Remove(listFiles.SelectedItems[0]);
			}
		}

		private void btnFinish_Click(object sender, EventArgs e)
		{
			if (listFiles.Items.Count <= 0)
			{
				return;
			}
			if (Directory.Exists(frmMain.pathTemp))
			{
				Directory.Delete(frmMain.pathTemp, true);
			}
			Directory.CreateDirectory(frmMain.pathTemp);
			foreach (ListViewItem item in listFiles.Items)
			{
				if (Path.GetExtension(item.Text) == ".sql")
				{
					File.Copy(item.Text, Path.Combine(frmMain.pathTemp, "database"));
				}
				else if (item.Text.StartsWith(frmMain.pathArma))
				{
					string text = Path.Combine(frmMain.pathTemp, "arma", item.Text.Replace(frmMain.pathArma, "").Remove(0, 1));
					if (!Directory.Exists(Path.GetDirectoryName(text)))
					{
						Directory.CreateDirectory(Path.GetDirectoryName(text));
					}
					File.Copy(item.Text, text);
				}
				else if (item.Text.StartsWith(frmMain.pathMain))
				{
					string text2 = Path.Combine(frmMain.pathTemp, "main", item.Text.Replace(frmMain.pathMain, "").Remove(0, 1));
					if (!Directory.Exists(Path.GetDirectoryName(text2)))
					{
						Directory.CreateDirectory(Path.GetDirectoryName(text2));
					}
					File.Copy(item.Text, text2);
				}
			}
			FastZip fastZip = new FastZip();
			fastZip.CreateEmptyDirectories = false;
			fastZip.CreateZip(Path.Combine(frmMain.pathMain, textName.Text + ".zip"), frmMain.pathTemp, true, null);
			MessageBox.Show("Plugin saved at \"" + Path.Combine(frmMain.pathMain, textName.Text + ".zip") + "\"");
			Close();
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
			this.components = new System.ComponentModel.Container();
			this.listFiles = new System.Windows.Forms.ListView();
			this.btnAdd = new System.Windows.Forms.Button();
			this.textFile = new System.Windows.Forms.TextBox();
			this.btnFinish = new System.Windows.Forms.Button();
			this.textName = new System.Windows.Forms.TextBox();
			this.textVersion = new System.Windows.Forms.TextBox();
			this.menuFiles = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuFiles.SuspendLayout();
			base.SuspendLayout();
			this.listFiles.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.listFiles.Location = new System.Drawing.Point(12, 65);
			this.listFiles.Name = "listFiles";
			this.listFiles.Size = new System.Drawing.Size(502, 156);
			this.listFiles.TabIndex = 0;
			this.listFiles.UseCompatibleStateImageBehavior = false;
			this.listFiles.View = System.Windows.Forms.View.List;
			this.listFiles.Click += new System.EventHandler(listFiles_Click);
			this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.btnAdd.Location = new System.Drawing.Point(439, 36);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(75, 23);
			this.btnAdd.TabIndex = 1;
			this.btnAdd.Text = "Add";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(btnAdd_Click);
			this.textFile.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.textFile.Location = new System.Drawing.Point(12, 38);
			this.textFile.Name = "textFile";
			this.textFile.Size = new System.Drawing.Size(421, 20);
			this.textFile.TabIndex = 2;
			this.textFile.Click += new System.EventHandler(textFile_Click);
			this.btnFinish.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.btnFinish.Enabled = false;
			this.btnFinish.Location = new System.Drawing.Point(12, 227);
			this.btnFinish.Name = "btnFinish";
			this.btnFinish.Size = new System.Drawing.Size(502, 23);
			this.btnFinish.TabIndex = 3;
			this.btnFinish.Text = "Create Plugin";
			this.btnFinish.UseVisualStyleBackColor = true;
			this.btnFinish.Click += new System.EventHandler(btnFinish_Click);
			this.textName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.textName.Location = new System.Drawing.Point(12, 12);
			this.textName.Name = "textName";
			this.textName.Size = new System.Drawing.Size(421, 20);
			this.textName.TabIndex = 4;
			this.textName.Text = "My Plugin";
			this.textVersion.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.textVersion.Location = new System.Drawing.Point(439, 12);
			this.textVersion.Name = "textVersion";
			this.textVersion.Size = new System.Drawing.Size(75, 20);
			this.textVersion.TabIndex = 5;
			this.textVersion.Text = "1.0";
			this.menuFiles.Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { this.removeToolStripMenuItem });
			this.menuFiles.Name = "menuFiles";
			this.menuFiles.Size = new System.Drawing.Size(153, 48);
			this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
			this.removeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.removeToolStripMenuItem.Text = "Remove";
			this.removeToolStripMenuItem.Click += new System.EventHandler(btnRemove_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(526, 262);
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
	}
}
