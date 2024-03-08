using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ICSharpCode.SharpZipLib.Zip;
using Microsoft.Win32;
using MySql.Data.MySqlClient;

namespace Crosire.Controlcenter.Plugin
{
	// Token: 0x02000003 RID: 3
	public partial class frmMain : Form
	{
		// Token: 0x06000009 RID: 9 RVA: 0x000028DD File Offset: 0x00000ADD
		public frmMain()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00002918 File Offset: 0x00000B18
		private void frmPlugin_Load(object sender, EventArgs e)
		{
			if (Directory.Exists(frmMain.pathPlugins))
			{
				foreach (FileInfo fileInfo in new DirectoryInfo(frmMain.pathPlugins).GetFiles("*.zip"))
				{
					this.listPlugins.Items.Add(Path.GetFileNameWithoutExtension(fileInfo.Name));
				}
			}
			RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey("SOFTWARE\\Bohemia Interactive Studio\\ArmA 2 OA");
			if (registryKey != null)
			{
				frmMain.pathArma = registryKey.GetValue("MAIN").ToString();
			}
			this.connection = new MySqlConnection(string.Format("server={0};port={1};user={2};password={3};", new object[] { "127.0.0.1", this.dbport, this.dbuser, this.dbpass }));
		}

		// Token: 0x0600000B RID: 11 RVA: 0x000029EC File Offset: 0x00000BEC
		private void listPlugins_Click(object sender, EventArgs e)
		{
			object selectedItem = this.listPlugins.SelectedItem;
		}

		// Token: 0x0600000C RID: 12 RVA: 0x000029FC File Offset: 0x00000BFC
		private void btnCreate_Click(object sender, EventArgs e)
		{
			frmCreate frmCreate = new frmCreate();
			frmCreate.ShowDialog();
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00002A18 File Offset: 0x00000C18
		private void btnInstall_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.Filter = "Plugins (*.zip)|*.zip";
				openFileDialog.Multiselect = false;
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					frmMain.pathFile = openFileDialog.FileName;
				}
			}
			if (File.Exists(frmMain.pathFile) && Path.GetExtension(frmMain.pathFile) == ".zip")
			{
				this.progressbar.Visible = true;
				this.labelStatus.Visible = true;
				this.labelStatus.Text = "Starting up ...";
				frmMain.pathPlugin = Path.Combine(frmMain.pathPlugins, Path.GetFileName(frmMain.pathFile));
				if (!Directory.Exists(frmMain.pathPlugins))
				{
					Directory.CreateDirectory(frmMain.pathPlugins);
				}
				File.Copy(frmMain.pathFile, frmMain.pathPlugin, true);
				this.progressbar.Increment(10);
				if (Directory.Exists(frmMain.pathTemp))
				{
					Directory.Delete(frmMain.pathTemp, true);
				}
				this.labelStatus.Text = "Extracting ...";
				FastZip fastZip = new FastZip();
				fastZip.ExtractZip(frmMain.pathPlugin, frmMain.pathTemp, null);
				this.progressbar.Increment(30);
				this.labelStatus.Text = "Patching files ...";
				if (Directory.Exists(Path.Combine(frmMain.pathTemp, "database")))
				{
					foreach (FileInfo fileInfo in new DirectoryInfo(Path.Combine(frmMain.pathTemp, "database")).GetFiles("*.sql"))
					{
						string text = File.ReadAllText(fileInfo.FullName);
						try
						{
							this.connection.Open();
							this.connection.ChangeDatabase(this.dbname);
							new MySqlCommand(text, this.connection).ExecuteNonQuery();
						}
						catch (MySqlException ex)
						{
							this.labelStatus.Text = "Error: " + ex.Message;
						}
						finally
						{
							this.connection.Close();
						}
					}
					this.progressbar.Increment(10);
				}
				if (Directory.Exists(Path.Combine(frmMain.pathTemp, "arma")))
				{
					foreach (FileInfo fileInfo2 in new DirectoryInfo(Path.Combine(frmMain.pathTemp, "arma")).GetFiles("*.*", SearchOption.AllDirectories))
					{
						string text2 = Path.Combine(frmMain.pathArma, fileInfo2.FullName.Replace(Path.Combine(frmMain.pathTemp, "arma"), "").Remove(0, 1));
						if (File.Exists(text2))
						{
							string text3 = Path.Combine(frmMain.pathMain, "backup", fileInfo2.FullName.Replace(Path.Combine(frmMain.pathTemp, "arma"), "").Remove(0, 1));
							Directory.Exists(Path.GetDirectoryName(text3));
							Directory.CreateDirectory(Path.GetDirectoryName(text3));
							File.Copy(text2, text3, true);
						}
						if (!Directory.Exists(Path.GetDirectoryName(text2)))
						{
							Directory.CreateDirectory(Path.GetDirectoryName(text2));
						}
						File.Copy(fileInfo2.FullName, text2, true);
					}
					this.progressbar.Increment(30);
				}
				if (Directory.Exists(Path.Combine(frmMain.pathTemp, "main")))
				{
					foreach (FileInfo fileInfo3 in new DirectoryInfo(Path.Combine(frmMain.pathTemp, "main")).GetFiles("*.*", SearchOption.AllDirectories))
					{
						string text4 = Path.Combine(frmMain.pathArma, fileInfo3.FullName.Replace(Path.Combine(frmMain.pathTemp, "main"), "").Remove(0, 1));
						if (File.Exists(text4))
						{
							string text5 = Path.Combine(frmMain.pathMain, "backup", fileInfo3.FullName.Replace(Path.Combine(frmMain.pathTemp, "main"), "").Remove(0, 1));
							Directory.Exists(Path.GetDirectoryName(text5));
							Directory.CreateDirectory(Path.GetDirectoryName(text5));
							File.Copy(text4, text5, true);
						}
						if (!Directory.Exists(Path.GetDirectoryName(text4)))
						{
							Directory.CreateDirectory(Path.GetDirectoryName(text4));
						}
						File.Copy(fileInfo3.FullName, text4, true);
					}
					this.progressbar.Increment(20);
				}
				this.labelStatus.Text = "Cleaning up ...";
				Directory.Delete(frmMain.pathTemp, true);
				this.progressbar.Value = this.progressbar.Maximum;
				if (!this.listPlugins.Items.Contains(Path.GetFileNameWithoutExtension(frmMain.pathFile)))
				{
					this.listPlugins.Items.Add(Path.GetFileNameWithoutExtension(frmMain.pathFile));
				}
				this.labelStatus.Text = "Finished!";
			}
		}

		// Token: 0x0600000E RID: 14 RVA: 0x00002F10 File Offset: 0x00001110
		private void btnRemove_Click(object sender, EventArgs e)
		{
			if (this.listPlugins.SelectedItem != null)
			{
				frmMain.pathPlugin = Path.Combine(frmMain.pathPlugins, this.listPlugins.SelectedItem.ToString() + ".zip");
				if (Directory.Exists(frmMain.pathTemp))
				{
					Directory.Delete(frmMain.pathTemp, true);
				}
				FastZip fastZip = new FastZip();
				fastZip.ExtractZip(frmMain.pathPlugin, frmMain.pathTemp, null);
				Directory.Delete(frmMain.pathTemp, true);
				if (File.Exists(frmMain.pathPlugin))
				{
					File.Delete(frmMain.pathPlugin);
				}
				this.listPlugins.Items.Remove(this.listPlugins.SelectedItem.ToString());
			}
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00002FC8 File Offset: 0x000011C8
		private void btnShowPatch_Click(object sender, EventArgs e)
		{
			if (this.listPlugins.SelectedItem != null)
			{
				frmShow frmShow = new frmShow();
				frmShow.ShowDialog();
			}
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00002FF0 File Offset: 0x000011F0
		private void btnShowDiff_Click(object sender, EventArgs e)
		{
			if (this.listPlugins.SelectedItem != null)
			{
				frmShow frmShow = new frmShow();
				frmShow.ShowDialog();
			}
		}

		// Token: 0x0400000A RID: 10
		public static string pathPlugins = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "plugins");

		// Token: 0x0400000B RID: 11
		public static string pathPlugin = string.Empty;

		// Token: 0x0400000C RID: 12
		public static string pathTemp = Path.Combine(Path.GetTempPath(), "plugin");

		// Token: 0x0400000D RID: 13
		public static string pathFile = string.Empty;

		// Token: 0x0400000E RID: 14
		public static string pathArma = string.Empty;

		// Token: 0x0400000F RID: 15
		public static string pathMain = Path.GetDirectoryName(Application.ExecutablePath);

		// Token: 0x04000010 RID: 16
		private MySqlConnection connection;

		// Token: 0x04000011 RID: 17
		private string dbport = "3306";

		// Token: 0x04000012 RID: 18
		private string dbuser = "dayz";

		// Token: 0x04000013 RID: 19
		private string dbpass = "dayz";

		// Token: 0x04000014 RID: 20
		private string dbname = "dayz_chernarus";
	}
}
