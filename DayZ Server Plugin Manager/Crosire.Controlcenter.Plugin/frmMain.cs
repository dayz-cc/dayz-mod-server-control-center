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
	public class frmMain : Form
	{
		public static string pathPlugins = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "plugins");

		public static string pathPlugin = string.Empty;

		public static string pathTemp = Path.Combine(Path.GetTempPath(), "plugin");

		public static string pathFile = string.Empty;

		public static string pathArma = string.Empty;

		public static string pathMain = Path.GetDirectoryName(Application.ExecutablePath);

		private MySqlConnection connection;

		private string dbport = "3306";

		private string dbuser = "dayz";

		private string dbpass = "dayz";

		private string dbname = "dayz_chernarus";

		private IContainer components;

		private ProgressBar progressbar;

		private Button btnInstall;

		private Label labelInstalledPlugins;

		private ListBox listPlugins;

		private ContextMenuStrip menuPlugin;

		private ToolStripMenuItem removeToolStripMenuItem;

		private ToolStripSeparator toolStripSeparator1;

		private ToolStripMenuItem showDiffToolStripMenuItem;

		private ToolStripMenuItem showPatchToolStripMenuItem;

		private Button btnCreate;

		private Label labelStatus;

		public frmMain()
		{
			InitializeComponent();
		}

		private void frmPlugin_Load(object sender, EventArgs e)
		{
			if (Directory.Exists(pathPlugins))
			{
				FileInfo[] files = new DirectoryInfo(pathPlugins).GetFiles("*.zip");
				foreach (FileInfo fileInfo in files)
				{
					listPlugins.Items.Add(Path.GetFileNameWithoutExtension(fileInfo.Name));
				}
			}
			RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey("SOFTWARE\\Bohemia Interactive Studio\\ArmA 2 OA");
			if (registryKey != null)
			{
				pathArma = registryKey.GetValue("MAIN").ToString();
			}
			connection = new MySqlConnection(string.Format("server={0};port={1};user={2};password={3};", "127.0.0.1", dbport, dbuser, dbpass));
		}

		private void listPlugins_Click(object sender, EventArgs e)
		{
			object selectedItem = listPlugins.SelectedItem;
		}

		private void btnCreate_Click(object sender, EventArgs e)
		{
			frmCreate frmCreate2 = new frmCreate();
			frmCreate2.ShowDialog();
		}

		private void btnInstall_Click(object sender, EventArgs e)
		{
			using (OpenFileDialog openFileDialog = new OpenFileDialog())
			{
				openFileDialog.Filter = "Plugins (*.zip)|*.zip";
				openFileDialog.Multiselect = false;
				if (openFileDialog.ShowDialog() == DialogResult.OK)
				{
					pathFile = openFileDialog.FileName;
				}
			}
			if (!File.Exists(pathFile) || !(Path.GetExtension(pathFile) == ".zip"))
			{
				return;
			}
			progressbar.Visible = true;
			labelStatus.Visible = true;
			labelStatus.Text = "Starting up ...";
			pathPlugin = Path.Combine(pathPlugins, Path.GetFileName(pathFile));
			if (!Directory.Exists(pathPlugins))
			{
				Directory.CreateDirectory(pathPlugins);
			}
			File.Copy(pathFile, pathPlugin, true);
			progressbar.Increment(10);
			if (Directory.Exists(pathTemp))
			{
				Directory.Delete(pathTemp, true);
			}
			labelStatus.Text = "Extracting ...";
			FastZip fastZip = new FastZip();
			fastZip.ExtractZip(pathPlugin, pathTemp, null);
			progressbar.Increment(30);
			labelStatus.Text = "Patching files ...";
			if (Directory.Exists(Path.Combine(pathTemp, "database")))
			{
				FileInfo[] files = new DirectoryInfo(Path.Combine(pathTemp, "database")).GetFiles("*.sql");
				foreach (FileInfo fileInfo in files)
				{
					string cmdText = File.ReadAllText(fileInfo.FullName);
					try
					{
						connection.Open();
						connection.ChangeDatabase(dbname);
						new MySqlCommand(cmdText, connection).ExecuteNonQuery();
					}
					catch (MySqlException ex)
					{
						labelStatus.Text = "Error: " + ex.Message;
					}
					finally
					{
						connection.Close();
					}
				}
				progressbar.Increment(10);
			}
			if (Directory.Exists(Path.Combine(pathTemp, "arma")))
			{
				FileInfo[] files2 = new DirectoryInfo(Path.Combine(pathTemp, "arma")).GetFiles("*.*", SearchOption.AllDirectories);
				foreach (FileInfo fileInfo2 in files2)
				{
					string text = Path.Combine(pathArma, fileInfo2.FullName.Replace(Path.Combine(pathTemp, "arma"), "").Remove(0, 1));
					if (File.Exists(text))
					{
						string text2 = Path.Combine(pathMain, "backup", fileInfo2.FullName.Replace(Path.Combine(pathTemp, "arma"), "").Remove(0, 1));
						Directory.Exists(Path.GetDirectoryName(text2));
						Directory.CreateDirectory(Path.GetDirectoryName(text2));
						File.Copy(text, text2, true);
					}
					if (!Directory.Exists(Path.GetDirectoryName(text)))
					{
						Directory.CreateDirectory(Path.GetDirectoryName(text));
					}
					File.Copy(fileInfo2.FullName, text, true);
				}
				progressbar.Increment(30);
			}
			if (Directory.Exists(Path.Combine(pathTemp, "main")))
			{
				FileInfo[] files3 = new DirectoryInfo(Path.Combine(pathTemp, "main")).GetFiles("*.*", SearchOption.AllDirectories);
				foreach (FileInfo fileInfo3 in files3)
				{
					string text3 = Path.Combine(pathArma, fileInfo3.FullName.Replace(Path.Combine(pathTemp, "main"), "").Remove(0, 1));
					if (File.Exists(text3))
					{
						string text4 = Path.Combine(pathMain, "backup", fileInfo3.FullName.Replace(Path.Combine(pathTemp, "main"), "").Remove(0, 1));
						Directory.Exists(Path.GetDirectoryName(text4));
						Directory.CreateDirectory(Path.GetDirectoryName(text4));
						File.Copy(text3, text4, true);
					}
					if (!Directory.Exists(Path.GetDirectoryName(text3)))
					{
						Directory.CreateDirectory(Path.GetDirectoryName(text3));
					}
					File.Copy(fileInfo3.FullName, text3, true);
				}
				progressbar.Increment(20);
			}
			labelStatus.Text = "Cleaning up ...";
			Directory.Delete(pathTemp, true);
			progressbar.Value = progressbar.Maximum;
			if (!listPlugins.Items.Contains(Path.GetFileNameWithoutExtension(pathFile)))
			{
				listPlugins.Items.Add(Path.GetFileNameWithoutExtension(pathFile));
			}
			labelStatus.Text = "Finished!";
		}

		private void btnRemove_Click(object sender, EventArgs e)
		{
			if (listPlugins.SelectedItem != null)
			{
				pathPlugin = Path.Combine(pathPlugins, listPlugins.SelectedItem.ToString() + ".zip");
				if (Directory.Exists(pathTemp))
				{
					Directory.Delete(pathTemp, true);
				}
				FastZip fastZip = new FastZip();
				fastZip.ExtractZip(pathPlugin, pathTemp, null);
				Directory.Delete(pathTemp, true);
				if (File.Exists(pathPlugin))
				{
					File.Delete(pathPlugin);
				}
				listPlugins.Items.Remove(listPlugins.SelectedItem.ToString());
			}
		}

		private void btnShowPatch_Click(object sender, EventArgs e)
		{
			if (listPlugins.SelectedItem != null)
			{
				frmShow frmShow2 = new frmShow();
				frmShow2.ShowDialog();
			}
		}

		private void btnShowDiff_Click(object sender, EventArgs e)
		{
			if (listPlugins.SelectedItem != null)
			{
				frmShow frmShow2 = new frmShow();
				frmShow2.ShowDialog();
			}
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Crosire.Controlcenter.Plugin.frmMain));
			this.progressbar = new System.Windows.Forms.ProgressBar();
			this.btnInstall = new System.Windows.Forms.Button();
			this.labelInstalledPlugins = new System.Windows.Forms.Label();
			this.listPlugins = new System.Windows.Forms.ListBox();
			this.menuPlugin = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.showDiffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showPatchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.btnCreate = new System.Windows.Forms.Button();
			this.labelStatus = new System.Windows.Forms.Label();
			this.menuPlugin.SuspendLayout();
			base.SuspendLayout();
			this.progressbar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.progressbar.Location = new System.Drawing.Point(12, 9);
			this.progressbar.Name = "progressbar";
			this.progressbar.Size = new System.Drawing.Size(260, 23);
			this.progressbar.TabIndex = 0;
			this.progressbar.Visible = false;
			this.btnInstall.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.btnInstall.Location = new System.Drawing.Point(12, 38);
			this.btnInstall.Name = "btnInstall";
			this.btnInstall.Size = new System.Drawing.Size(260, 23);
			this.btnInstall.TabIndex = 0;
			this.btnInstall.Text = "Install";
			this.btnInstall.UseVisualStyleBackColor = true;
			this.btnInstall.Click += new System.EventHandler(btnInstall_Click);
			this.labelInstalledPlugins.AutoSize = true;
			this.labelInstalledPlugins.Location = new System.Drawing.Point(12, 76);
			this.labelInstalledPlugins.Name = "labelInstalledPlugins";
			this.labelInstalledPlugins.Size = new System.Drawing.Size(86, 13);
			this.labelInstalledPlugins.TabIndex = 3;
			this.labelInstalledPlugins.Text = "Installed Plugins:";
			this.listPlugins.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.listPlugins.FormattingEnabled = true;
			this.listPlugins.Location = new System.Drawing.Point(15, 92);
			this.listPlugins.Name = "listPlugins";
			this.listPlugins.ScrollAlwaysVisible = true;
			this.listPlugins.Size = new System.Drawing.Size(257, 147);
			this.listPlugins.TabIndex = 4;
			this.listPlugins.Click += new System.EventHandler(listPlugins_Click);
			this.menuPlugin.Items.AddRange(new System.Windows.Forms.ToolStripItem[4] { this.removeToolStripMenuItem, this.toolStripSeparator1, this.showDiffToolStripMenuItem, this.showPatchToolStripMenuItem });
			this.menuPlugin.Name = "menuPlugin";
			this.menuPlugin.Size = new System.Drawing.Size(137, 76);
			this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
			this.removeToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
			this.removeToolStripMenuItem.Text = "Remove";
			this.removeToolStripMenuItem.Click += new System.EventHandler(btnRemove_Click);
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(133, 6);
			this.showDiffToolStripMenuItem.Name = "showDiffToolStripMenuItem";
			this.showDiffToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
			this.showDiffToolStripMenuItem.Text = "Show Diff";
			this.showDiffToolStripMenuItem.Click += new System.EventHandler(btnShowDiff_Click);
			this.showPatchToolStripMenuItem.Name = "showPatchToolStripMenuItem";
			this.showPatchToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
			this.showPatchToolStripMenuItem.Text = "Show Patch";
			this.showPatchToolStripMenuItem.Click += new System.EventHandler(btnShowPatch_Click);
			this.btnCreate.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.btnCreate.Location = new System.Drawing.Point(12, 9);
			this.btnCreate.Name = "btnCreate";
			this.btnCreate.Size = new System.Drawing.Size(260, 23);
			this.btnCreate.TabIndex = 1;
			this.btnCreate.Text = "Create";
			this.btnCreate.UseVisualStyleBackColor = true;
			this.btnCreate.Click += new System.EventHandler(btnCreate_Click);
			this.labelStatus.AutoSize = true;
			this.labelStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.labelStatus.Location = new System.Drawing.Point(16, 14);
			this.labelStatus.Name = "labelStatus";
			this.labelStatus.Size = new System.Drawing.Size(18, 15);
			this.labelStatus.TabIndex = 5;
			this.labelStatus.Text = "...";
			this.labelStatus.Visible = false;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(284, 252);
			base.Controls.Add(this.labelStatus);
			base.Controls.Add(this.listPlugins);
			base.Controls.Add(this.labelInstalledPlugins);
			base.Controls.Add(this.progressbar);
			base.Controls.Add(this.btnInstall);
			base.Controls.Add(this.btnCreate);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "frmMain";
			base.ShowIcon = false;
			base.ShowInTaskbar = false;
			base.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "DayZ Server Plugin Manager";
			base.Load += new System.EventHandler(frmPlugin_Load);
			this.menuPlugin.ResumeLayout(false);
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
