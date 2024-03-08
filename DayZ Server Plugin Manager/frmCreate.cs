using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ICSharpCode.SharpZipLib.Zip;

namespace Crosire.Controlcenter.Plugin
{
	// Token: 0x02000002 RID: 2
	public partial class frmCreate : Form
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public frmCreate()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00002060 File Offset: 0x00000260
		private void textFile_Click(object sender, EventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.InitialDirectory = frmMain.pathArma;
			openFileDialog.Multiselect = false;
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				this.textFile.Text = openFileDialog.FileName;
			}
		}

		// Token: 0x06000003 RID: 3 RVA: 0x0000209F File Offset: 0x0000029F
		private void listFiles_Click(object sender, EventArgs e)
		{
			if (this.listFiles.SelectedItems != null)
			{
				this.menuFiles.Show(Cursor.Position);
			}
		}

		// Token: 0x06000004 RID: 4 RVA: 0x000020C0 File Offset: 0x000002C0
		private void btnAdd_Click(object sender, EventArgs e)
		{
			if (!string.IsNullOrEmpty(this.textFile.Text))
			{
				if (this.textFile.Text.Contains(frmMain.pathArma) || this.textFile.Text.Contains(frmMain.pathMain) || Path.GetExtension(this.textFile.Text) == ".sql")
				{
					this.listFiles.Items.Add(this.textFile.Text);
				}
				else
				{
					MessageBox.Show("You haven't selected a valid file. It has to be either in your Arma or Pluginmanager directory or with the file extension \"sql\"!");
				}
				this.textFile.Text = "";
			}
			else
			{
				this.textFile_Click(null, EventArgs.Empty);
				this.btnAdd_Click(sender, e);
			}
			this.btnFinish.Enabled = this.listFiles.Items.Count > 0;
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002199 File Offset: 0x00000399
		private void btnRemove_Click(object sender, EventArgs e)
		{
			if (this.listFiles.SelectedItems != null)
			{
				this.listFiles.Items.Remove(this.listFiles.SelectedItems[0]);
			}
		}

		// Token: 0x06000006 RID: 6 RVA: 0x000021CC File Offset: 0x000003CC
		private void btnFinish_Click(object sender, EventArgs e)
		{
			if (this.listFiles.Items.Count > 0)
			{
				if (Directory.Exists(frmMain.pathTemp))
				{
					Directory.Delete(frmMain.pathTemp, true);
				}
				Directory.CreateDirectory(frmMain.pathTemp);
				foreach (object obj in this.listFiles.Items)
				{
					ListViewItem listViewItem = (ListViewItem)obj;
					if (Path.GetExtension(listViewItem.Text) == ".sql")
					{
						File.Copy(listViewItem.Text, Path.Combine(frmMain.pathTemp, "database"));
					}
					else if (listViewItem.Text.StartsWith(frmMain.pathArma))
					{
						string text = Path.Combine(frmMain.pathTemp, "arma", listViewItem.Text.Replace(frmMain.pathArma, "").Remove(0, 1));
						if (!Directory.Exists(Path.GetDirectoryName(text)))
						{
							Directory.CreateDirectory(Path.GetDirectoryName(text));
						}
						File.Copy(listViewItem.Text, text);
					}
					else if (listViewItem.Text.StartsWith(frmMain.pathMain))
					{
						string text2 = Path.Combine(frmMain.pathTemp, "main", listViewItem.Text.Replace(frmMain.pathMain, "").Remove(0, 1));
						if (!Directory.Exists(Path.GetDirectoryName(text2)))
						{
							Directory.CreateDirectory(Path.GetDirectoryName(text2));
						}
						File.Copy(listViewItem.Text, text2);
					}
				}
				new FastZip
				{
					CreateEmptyDirectories = false
				}.CreateZip(Path.Combine(frmMain.pathMain, this.textName.Text + ".zip"), frmMain.pathTemp, true, null);
				MessageBox.Show("Plugin saved at \"" + Path.Combine(frmMain.pathMain, this.textName.Text + ".zip") + "\"");
				base.Close();
			}
		}
	}
}
