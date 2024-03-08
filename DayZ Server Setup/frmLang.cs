using System;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;
using Crosire.Controlcenter.Setup.Properties;

namespace Crosire.Controlcenter.Setup
{
	// Token: 0x02000005 RID: 5
	public partial class frmLang : Form
	{
		// Token: 0x06000004 RID: 4 RVA: 0x000020BD File Offset: 0x000002BD
		public frmLang()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000005 RID: 5 RVA: 0x000020CB File Offset: 0x000002CB
		private void btnOk_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000006 RID: 6 RVA: 0x000020D3 File Offset: 0x000002D3
		private void cbxLanguage_SelectedIndexChanged(object sender, EventArgs e)
		{
			frmLang.language = this.cbxLanguage.SelectedItem.ToString();
			Thread.CurrentThread.CurrentUICulture = new CultureInfo(frmLang.language);
			this.labelChoose.Text = Resources.sentence_chooselanguage;
		}

		// Token: 0x06000007 RID: 7 RVA: 0x0000210E File Offset: 0x0000030E
		private void frmLang_Load(object sender, EventArgs e)
		{
			this.labelChoose.Text = Resources.sentence_chooselanguage;
			this.cbxLanguage.SelectedItem = Thread.CurrentThread.CurrentUICulture.IetfLanguageTag.Substring(0, 2).ToLower();
		}

		// Token: 0x0400000D RID: 13
		public static string language;
	}
}
