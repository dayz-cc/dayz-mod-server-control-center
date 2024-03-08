using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using Loadout.My.Resources;
using Microsoft.VisualBasic.CompilerServices;

namespace Loadout
{
	// Token: 0x02000008 RID: 8
	[DesignerGenerated]
	public sealed partial class frmMain : Form
	{
		// Token: 0x0600001E RID: 30 RVA: 0x00002438 File Offset: 0x00000638
		public frmMain()
		{
			base.Load += this.frmMain_Load;
			this.opticsLeft = 2;
			this.opticsName = new string[3];
			this.primaryLeft = 10;
			this.secondaryLeft = 10;
			this.inventory1Left = 12;
			this.inventory1Name = new string[12];
			this.inventory1Size = new int[12];
			this.inventory2Left = 8;
			this.inventory2Name = new string[8];
			this.inventory2Size = new int[8];
			this.toolLeft = 12;
			this.toolName = new string[12];
			this.toolSize = new int[12];
			this.baginventoryLeft = 0;
			this.baginventoryName = new string[24];
			this.baginventorySize = new int[24];
			this.rINV = new List<string>();
			this.lINV = new List<string>();
			this.lbagINV = new List<string>();
			this.rbagINV = new List<string>();
			this.lbagINV2 = new List<string>();
			this.rbagINV2 = new List<string>();
			this.lbagINVvalues = new List<int>();
			this.rbagINVvalues = new List<int>();
			this.itemdelside = new int[28];
			this.MainInvGridLoc = new int[12];
			this.BagInvGridLoc = new int[24];
			this.SecInvGridLoc = new int[8];
			this.ToolGridLoc = new int[12];
			this.InitializeComponent();
		}

		// Token: 0x17000008 RID: 8
		// (get) Token: 0x06000021 RID: 33 RVA: 0x00008880 File Offset: 0x00006A80
		// (set) Token: 0x06000022 RID: 34 RVA: 0x00008894 File Offset: 0x00006A94
		internal GroupBox groupResult
		{
			[DebuggerNonUserCode]
			get
			{
				return this._groupResult;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._groupResult = value;
			}
		}

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000023 RID: 35 RVA: 0x000088A0 File Offset: 0x00006AA0
		// (set) Token: 0x06000024 RID: 36 RVA: 0x000088B4 File Offset: 0x00006AB4
		internal TextBox textResult
		{
			[DebuggerNonUserCode]
			get
			{
				return this._textResult;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._textResult = value;
			}
		}

		// Token: 0x1700000A RID: 10
		// (get) Token: 0x06000025 RID: 37 RVA: 0x000088C0 File Offset: 0x00006AC0
		// (set) Token: 0x06000026 RID: 38 RVA: 0x000088D4 File Offset: 0x00006AD4
		internal GroupBox groupPreview
		{
			[DebuggerNonUserCode]
			get
			{
				return this._groupPreview;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._groupPreview = value;
			}
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000027 RID: 39 RVA: 0x000088E0 File Offset: 0x00006AE0
		// (set) Token: 0x06000028 RID: 40 RVA: 0x000088F4 File Offset: 0x00006AF4
		internal PictureBox picPreview
		{
			[DebuggerNonUserCode]
			get
			{
				return this._picPreview;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._picPreview = value;
			}
		}

		// Token: 0x1700000C RID: 12
		// (get) Token: 0x06000029 RID: 41 RVA: 0x00008900 File Offset: 0x00006B00
		// (set) Token: 0x0600002A RID: 42 RVA: 0x00008914 File Offset: 0x00006B14
		internal ComboBox comboboxMEDICAL
		{
			[DebuggerNonUserCode]
			get
			{
				return this._comboboxMEDICAL;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._comboboxMEDICAL != null)
				{
					this._comboboxMEDICAL.SelectedIndexChanged -= this.comboboxMEDICAL_SelectedIndexChanged;
					this._comboboxMEDICAL.KeyDown -= this.combobox_KeyDown;
				}
				this._comboboxMEDICAL = value;
				if (this._comboboxMEDICAL != null)
				{
					this._comboboxMEDICAL.SelectedIndexChanged += this.comboboxMEDICAL_SelectedIndexChanged;
					this._comboboxMEDICAL.KeyDown += this.combobox_KeyDown;
				}
			}
		}

		// Token: 0x1700000D RID: 13
		// (get) Token: 0x0600002B RID: 43 RVA: 0x00008998 File Offset: 0x00006B98
		// (set) Token: 0x0600002C RID: 44 RVA: 0x000089AC File Offset: 0x00006BAC
		internal ComboBox comboboxTOOLS
		{
			[DebuggerNonUserCode]
			get
			{
				return this._comboboxTOOLS;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._comboboxTOOLS != null)
				{
					this._comboboxTOOLS.SelectedIndexChanged -= this.comboboxTOOLS_SelectedIndexChanged;
					this._comboboxTOOLS.KeyDown -= this.combobox_KeyDown;
				}
				this._comboboxTOOLS = value;
				if (this._comboboxTOOLS != null)
				{
					this._comboboxTOOLS.SelectedIndexChanged += this.comboboxTOOLS_SelectedIndexChanged;
					this._comboboxTOOLS.KeyDown += this.combobox_KeyDown;
				}
			}
		}

		// Token: 0x1700000E RID: 14
		// (get) Token: 0x0600002D RID: 45 RVA: 0x00008A30 File Offset: 0x00006C30
		// (set) Token: 0x0600002E RID: 46 RVA: 0x00008A44 File Offset: 0x00006C44
		internal ComboBox comboboxPARTS
		{
			[DebuggerNonUserCode]
			get
			{
				return this._comboboxPARTS;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._comboboxPARTS != null)
				{
					this._comboboxPARTS.SelectedIndexChanged -= this.comboboxPARTS_SelectedIndexChanged;
					this._comboboxPARTS.KeyDown -= this.combobox_KeyDown;
				}
				this._comboboxPARTS = value;
				if (this._comboboxPARTS != null)
				{
					this._comboboxPARTS.SelectedIndexChanged += this.comboboxPARTS_SelectedIndexChanged;
					this._comboboxPARTS.KeyDown += this.combobox_KeyDown;
				}
			}
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600002F RID: 47 RVA: 0x00008AC8 File Offset: 0x00006CC8
		// (set) Token: 0x06000030 RID: 48 RVA: 0x00008ADC File Offset: 0x00006CDC
		internal ComboBox comboboxRIFLE
		{
			[DebuggerNonUserCode]
			get
			{
				return this._comboboxRIFLE;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._comboboxRIFLE != null)
				{
					this._comboboxRIFLE.SelectedIndexChanged -= this.comboboxRIFLE_SelectedIndexChanged;
					this._comboboxRIFLE.KeyDown -= this.combobox_KeyDown;
				}
				this._comboboxRIFLE = value;
				if (this._comboboxRIFLE != null)
				{
					this._comboboxRIFLE.SelectedIndexChanged += this.comboboxRIFLE_SelectedIndexChanged;
					this._comboboxRIFLE.KeyDown += this.combobox_KeyDown;
				}
			}
		}

		// Token: 0x17000010 RID: 16
		// (get) Token: 0x06000031 RID: 49 RVA: 0x00008B60 File Offset: 0x00006D60
		// (set) Token: 0x06000032 RID: 50 RVA: 0x00008B74 File Offset: 0x00006D74
		internal ComboBox comboboxSUBMACHINE
		{
			[DebuggerNonUserCode]
			get
			{
				return this._comboboxSUBMACHINE;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._comboboxSUBMACHINE != null)
				{
					this._comboboxSUBMACHINE.SelectedIndexChanged -= this.comboboxSUBMACHINE_SelectedIndexChanged;
					this._comboboxSUBMACHINE.KeyDown -= this.combobox_KeyDown;
				}
				this._comboboxSUBMACHINE = value;
				if (this._comboboxSUBMACHINE != null)
				{
					this._comboboxSUBMACHINE.SelectedIndexChanged += this.comboboxSUBMACHINE_SelectedIndexChanged;
					this._comboboxSUBMACHINE.KeyDown += this.combobox_KeyDown;
				}
			}
		}

		// Token: 0x17000011 RID: 17
		// (get) Token: 0x06000033 RID: 51 RVA: 0x00008BF8 File Offset: 0x00006DF8
		// (set) Token: 0x06000034 RID: 52 RVA: 0x00008C0C File Offset: 0x00006E0C
		internal ComboBox comboboxSHOTGUN
		{
			[DebuggerNonUserCode]
			get
			{
				return this._comboboxSHOTGUN;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._comboboxSHOTGUN != null)
				{
					this._comboboxSHOTGUN.SelectedIndexChanged -= this.comboboxSHOTGUN_SelectedIndexChanged;
					this._comboboxSHOTGUN.KeyDown -= this.combobox_KeyDown;
				}
				this._comboboxSHOTGUN = value;
				if (this._comboboxSHOTGUN != null)
				{
					this._comboboxSHOTGUN.SelectedIndexChanged += this.comboboxSHOTGUN_SelectedIndexChanged;
					this._comboboxSHOTGUN.KeyDown += this.combobox_KeyDown;
				}
			}
		}

		// Token: 0x17000012 RID: 18
		// (get) Token: 0x06000035 RID: 53 RVA: 0x00008C90 File Offset: 0x00006E90
		// (set) Token: 0x06000036 RID: 54 RVA: 0x00008CA4 File Offset: 0x00006EA4
		internal ComboBox comboboxSNIPER
		{
			[DebuggerNonUserCode]
			get
			{
				return this._comboboxSNIPER;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._comboboxSNIPER != null)
				{
					this._comboboxSNIPER.SelectedIndexChanged -= this.comboboxSNIPER_SelectedIndexChanged;
					this._comboboxSNIPER.KeyDown -= this.combobox_KeyDown;
				}
				this._comboboxSNIPER = value;
				if (this._comboboxSNIPER != null)
				{
					this._comboboxSNIPER.SelectedIndexChanged += this.comboboxSNIPER_SelectedIndexChanged;
					this._comboboxSNIPER.KeyDown += this.combobox_KeyDown;
				}
			}
		}

		// Token: 0x17000013 RID: 19
		// (get) Token: 0x06000037 RID: 55 RVA: 0x00008D28 File Offset: 0x00006F28
		// (set) Token: 0x06000038 RID: 56 RVA: 0x00008D3C File Offset: 0x00006F3C
		internal ComboBox comboboxMACHINEGUN
		{
			[DebuggerNonUserCode]
			get
			{
				return this._comboboxMACHINEGUN;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._comboboxMACHINEGUN != null)
				{
					this._comboboxMACHINEGUN.SelectedIndexChanged -= this.comboboxMACHINEGUN_SelectedIndexChanged;
					this._comboboxMACHINEGUN.KeyDown -= this.combobox_KeyDown;
				}
				this._comboboxMACHINEGUN = value;
				if (this._comboboxMACHINEGUN != null)
				{
					this._comboboxMACHINEGUN.SelectedIndexChanged += this.comboboxMACHINEGUN_SelectedIndexChanged;
					this._comboboxMACHINEGUN.KeyDown += this.combobox_KeyDown;
				}
			}
		}

		// Token: 0x17000014 RID: 20
		// (get) Token: 0x06000039 RID: 57 RVA: 0x00008DC0 File Offset: 0x00006FC0
		// (set) Token: 0x0600003A RID: 58 RVA: 0x00008DD4 File Offset: 0x00006FD4
		internal ComboBox comboboxMISC
		{
			[DebuggerNonUserCode]
			get
			{
				return this._comboboxMISC;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._comboboxMISC != null)
				{
					this._comboboxMISC.SelectedIndexChanged -= this.comboboxMISC_SelectedIndexChanged;
					this._comboboxMISC.KeyDown -= this.combobox_KeyDown;
				}
				this._comboboxMISC = value;
				if (this._comboboxMISC != null)
				{
					this._comboboxMISC.SelectedIndexChanged += this.comboboxMISC_SelectedIndexChanged;
					this._comboboxMISC.KeyDown += this.combobox_KeyDown;
				}
			}
		}

		// Token: 0x17000015 RID: 21
		// (get) Token: 0x0600003B RID: 59 RVA: 0x00008E58 File Offset: 0x00007058
		// (set) Token: 0x0600003C RID: 60 RVA: 0x00008E6C File Offset: 0x0000706C
		internal Button btnAddInv
		{
			[DebuggerNonUserCode]
			get
			{
				return this._btnAddInv;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._btnAddInv != null)
				{
					this._btnAddInv.Click -= this.btnAddInventory_Click;
				}
				this._btnAddInv = value;
				if (this._btnAddInv != null)
				{
					this._btnAddInv.Click += this.btnAddInventory_Click;
				}
			}
		}

		// Token: 0x17000016 RID: 22
		// (get) Token: 0x0600003D RID: 61 RVA: 0x00008EC0 File Offset: 0x000070C0
		// (set) Token: 0x0600003E RID: 62 RVA: 0x00008ED4 File Offset: 0x000070D4
		internal Button btnAddBag
		{
			[DebuggerNonUserCode]
			get
			{
				return this._btnAddBag;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._btnAddBag != null)
				{
					this._btnAddBag.Click -= this.btnAddBackpack_Click;
				}
				this._btnAddBag = value;
				if (this._btnAddBag != null)
				{
					this._btnAddBag.Click += this.btnAddBackpack_Click;
				}
			}
		}

		// Token: 0x17000017 RID: 23
		// (get) Token: 0x0600003F RID: 63 RVA: 0x00008F28 File Offset: 0x00007128
		// (set) Token: 0x06000040 RID: 64 RVA: 0x00008F3C File Offset: 0x0000713C
		internal ComboBox comboboxFOOD
		{
			[DebuggerNonUserCode]
			get
			{
				return this._comboboxFOOD;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._comboboxFOOD != null)
				{
					this._comboboxFOOD.SelectedIndexChanged -= this.comboboxFOOD_SelectedIndexChanged;
					this._comboboxFOOD.KeyDown -= this.combobox_KeyDown;
				}
				this._comboboxFOOD = value;
				if (this._comboboxFOOD != null)
				{
					this._comboboxFOOD.SelectedIndexChanged += this.comboboxFOOD_SelectedIndexChanged;
					this._comboboxFOOD.KeyDown += this.combobox_KeyDown;
				}
			}
		}

		// Token: 0x17000018 RID: 24
		// (get) Token: 0x06000041 RID: 65 RVA: 0x00008FC0 File Offset: 0x000071C0
		// (set) Token: 0x06000042 RID: 66 RVA: 0x00008FD4 File Offset: 0x000071D4
		internal ComboBox comboboxPISTOL
		{
			[DebuggerNonUserCode]
			get
			{
				return this._comboboxPISTOL;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._comboboxPISTOL != null)
				{
					this._comboboxPISTOL.SelectedIndexChanged -= this.comboboxPISTOL_SelectedIndexChanged;
					this._comboboxPISTOL.KeyDown -= this.combobox_KeyDown;
				}
				this._comboboxPISTOL = value;
				if (this._comboboxPISTOL != null)
				{
					this._comboboxPISTOL.SelectedIndexChanged += this.comboboxPISTOL_SelectedIndexChanged;
					this._comboboxPISTOL.KeyDown += this.combobox_KeyDown;
				}
			}
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000043 RID: 67 RVA: 0x00009058 File Offset: 0x00007258
		// (set) Token: 0x06000044 RID: 68 RVA: 0x0000906C File Offset: 0x0000726C
		internal Button btnGenerateInv
		{
			[DebuggerNonUserCode]
			get
			{
				return this._btnGenerateInv;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._btnGenerateInv != null)
				{
					this._btnGenerateInv.Click -= this.btnGenerate_Click;
				}
				this._btnGenerateInv = value;
				if (this._btnGenerateInv != null)
				{
					this._btnGenerateInv.Click += this.btnGenerate_Click;
				}
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000045 RID: 69 RVA: 0x000090C0 File Offset: 0x000072C0
		// (set) Token: 0x06000046 RID: 70 RVA: 0x000090D4 File Offset: 0x000072D4
		internal Button btnGenerateBag
		{
			[DebuggerNonUserCode]
			get
			{
				return this._btnGenerateBag;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._btnGenerateBag != null)
				{
					this._btnGenerateBag.Click -= this.btnGenerateBag_Click;
				}
				this._btnGenerateBag = value;
				if (this._btnGenerateBag != null)
				{
					this._btnGenerateBag.Click += this.btnGenerateBag_Click;
				}
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000047 RID: 71 RVA: 0x00009128 File Offset: 0x00007328
		// (set) Token: 0x06000048 RID: 72 RVA: 0x0000913C File Offset: 0x0000733C
		internal GroupBox groupBackpack
		{
			[DebuggerNonUserCode]
			get
			{
				return this._groupBackpack;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._groupBackpack = value;
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000049 RID: 73 RVA: 0x00009148 File Offset: 0x00007348
		// (set) Token: 0x0600004A RID: 74 RVA: 0x0000915C File Offset: 0x0000735C
		internal RadioButton radio6
		{
			[DebuggerNonUserCode]
			get
			{
				return this._radio6;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._radio6 != null)
				{
					this._radio6.CheckedChanged -= this.radioBackpack_CheckedChanged;
				}
				this._radio6 = value;
				if (this._radio6 != null)
				{
					this._radio6.CheckedChanged += this.radioBackpack_CheckedChanged;
				}
			}
		}

		// Token: 0x1700001D RID: 29
		// (get) Token: 0x0600004B RID: 75 RVA: 0x000091B0 File Offset: 0x000073B0
		// (set) Token: 0x0600004C RID: 76 RVA: 0x000091C4 File Offset: 0x000073C4
		internal RadioButton radio4
		{
			[DebuggerNonUserCode]
			get
			{
				return this._radio4;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._radio4 != null)
				{
					this._radio4.CheckedChanged -= this.radioBackpack_CheckedChanged;
				}
				this._radio4 = value;
				if (this._radio4 != null)
				{
					this._radio4.CheckedChanged += this.radioBackpack_CheckedChanged;
				}
			}
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x0600004D RID: 77 RVA: 0x00009218 File Offset: 0x00007418
		// (set) Token: 0x0600004E RID: 78 RVA: 0x0000922C File Offset: 0x0000742C
		internal RadioButton radio3
		{
			[DebuggerNonUserCode]
			get
			{
				return this._radio3;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._radio3 != null)
				{
					this._radio3.CheckedChanged -= this.radioBackpack_CheckedChanged;
				}
				this._radio3 = value;
				if (this._radio3 != null)
				{
					this._radio3.CheckedChanged += this.radioBackpack_CheckedChanged;
				}
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x0600004F RID: 79 RVA: 0x00009280 File Offset: 0x00007480
		// (set) Token: 0x06000050 RID: 80 RVA: 0x00009294 File Offset: 0x00007494
		internal RadioButton radio2
		{
			[DebuggerNonUserCode]
			get
			{
				return this._radio2;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._radio2 != null)
				{
					this._radio2.CheckedChanged -= this.radioBackpack_CheckedChanged;
				}
				this._radio2 = value;
				if (this._radio2 != null)
				{
					this._radio2.CheckedChanged += this.radioBackpack_CheckedChanged;
				}
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x06000051 RID: 81 RVA: 0x000092E8 File Offset: 0x000074E8
		// (set) Token: 0x06000052 RID: 82 RVA: 0x000092FC File Offset: 0x000074FC
		internal RadioButton radio1
		{
			[DebuggerNonUserCode]
			get
			{
				return this._radio1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._radio1 != null)
				{
					this._radio1.CheckedChanged -= this.radioBackpack_CheckedChanged;
				}
				this._radio1 = value;
				if (this._radio1 != null)
				{
					this._radio1.CheckedChanged += this.radioBackpack_CheckedChanged;
				}
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x06000053 RID: 83 RVA: 0x00009350 File Offset: 0x00007550
		// (set) Token: 0x06000054 RID: 84 RVA: 0x00009364 File Offset: 0x00007564
		internal RadioButton radio5
		{
			[DebuggerNonUserCode]
			get
			{
				return this._radio5;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._radio5 != null)
				{
					this._radio5.CheckedChanged -= this.radioBackpack_CheckedChanged;
				}
				this._radio5 = value;
				if (this._radio5 != null)
				{
					this._radio5.CheckedChanged += this.radioBackpack_CheckedChanged;
				}
			}
		}

		// Token: 0x17000022 RID: 34
		// (get) Token: 0x06000055 RID: 85 RVA: 0x000093B8 File Offset: 0x000075B8
		// (set) Token: 0x06000056 RID: 86 RVA: 0x000093CC File Offset: 0x000075CC
		internal ImageList imgBags
		{
			[DebuggerNonUserCode]
			get
			{
				return this._imgBags;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._imgBags = value;
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x06000057 RID: 87 RVA: 0x000093D8 File Offset: 0x000075D8
		// (set) Token: 0x06000058 RID: 88 RVA: 0x000093EC File Offset: 0x000075EC
		internal ContextMenuStrip cmsRemove
		{
			[DebuggerNonUserCode]
			get
			{
				return this._cmsRemove;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._cmsRemove = value;
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x06000059 RID: 89 RVA: 0x000093F8 File Offset: 0x000075F8
		// (set) Token: 0x0600005A RID: 90 RVA: 0x0000940C File Offset: 0x0000760C
		internal ToolStripMenuItem cmsRemoveItem
		{
			[DebuggerNonUserCode]
			get
			{
				return this._cmsRemoveItem;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._cmsRemoveItem != null)
				{
					this._cmsRemoveItem.Click -= this.cmsRemoveItem_Click;
				}
				this._cmsRemoveItem = value;
				if (this._cmsRemoveItem != null)
				{
					this._cmsRemoveItem.Click += this.cmsRemoveItem_Click;
				}
			}
		}

		// Token: 0x17000025 RID: 37
		// (get) Token: 0x0600005B RID: 91 RVA: 0x00009460 File Offset: 0x00007660
		// (set) Token: 0x0600005C RID: 92 RVA: 0x00009474 File Offset: 0x00007674
		internal ImageList imgPrimaryWeapons
		{
			[DebuggerNonUserCode]
			get
			{
				return this._imgPrimaryWeapons;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._imgPrimaryWeapons = value;
			}
		}

		// Token: 0x17000026 RID: 38
		// (get) Token: 0x0600005D RID: 93 RVA: 0x00009480 File Offset: 0x00007680
		// (set) Token: 0x0600005E RID: 94 RVA: 0x00009494 File Offset: 0x00007694
		internal ImageList imgSecondaryWeapons
		{
			[DebuggerNonUserCode]
			get
			{
				return this._imgSecondaryWeapons;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._imgSecondaryWeapons = value;
			}
		}

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x0600005F RID: 95 RVA: 0x000094A0 File Offset: 0x000076A0
		// (set) Token: 0x06000060 RID: 96 RVA: 0x000094B4 File Offset: 0x000076B4
		internal ImageList imgPrimaryInv
		{
			[DebuggerNonUserCode]
			get
			{
				return this._imgPrimaryInv;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._imgPrimaryInv = value;
			}
		}

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x06000061 RID: 97 RVA: 0x000094C0 File Offset: 0x000076C0
		// (set) Token: 0x06000062 RID: 98 RVA: 0x000094D4 File Offset: 0x000076D4
		internal ImageList imgSecondaryInv
		{
			[DebuggerNonUserCode]
			get
			{
				return this._imgSecondaryInv;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._imgSecondaryInv = value;
			}
		}

		// Token: 0x17000029 RID: 41
		// (get) Token: 0x06000063 RID: 99 RVA: 0x000094E0 File Offset: 0x000076E0
		// (set) Token: 0x06000064 RID: 100 RVA: 0x000094F4 File Offset: 0x000076F4
		internal ImageList imgTools
		{
			[DebuggerNonUserCode]
			get
			{
				return this._imgTools;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._imgTools = value;
			}
		}

		// Token: 0x1700002A RID: 42
		// (get) Token: 0x06000065 RID: 101 RVA: 0x00009500 File Offset: 0x00007700
		// (set) Token: 0x06000066 RID: 102 RVA: 0x00009514 File Offset: 0x00007714
		internal Panel panel1
		{
			[DebuggerNonUserCode]
			get
			{
				return this._panel1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._panel1 = value;
			}
		}

		// Token: 0x1700002B RID: 43
		// (get) Token: 0x06000067 RID: 103 RVA: 0x00009520 File Offset: 0x00007720
		// (set) Token: 0x06000068 RID: 104 RVA: 0x00009534 File Offset: 0x00007734
		internal PictureBox picOptics2
		{
			[DebuggerNonUserCode]
			get
			{
				return this._picOptics2;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._picOptics2 != null)
				{
					this._picOptics2.MouseEnter -= this.picOptics_MouseEnter;
				}
				this._picOptics2 = value;
				if (this._picOptics2 != null)
				{
					this._picOptics2.MouseEnter += this.picOptics_MouseEnter;
				}
			}
		}

		// Token: 0x1700002C RID: 44
		// (get) Token: 0x06000069 RID: 105 RVA: 0x00009588 File Offset: 0x00007788
		// (set) Token: 0x0600006A RID: 106 RVA: 0x0000959C File Offset: 0x0000779C
		internal PictureBox picOptics1
		{
			[DebuggerNonUserCode]
			get
			{
				return this._picOptics1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._picOptics1 != null)
				{
					this._picOptics1.MouseEnter -= this.picOptics_MouseEnter;
				}
				this._picOptics1 = value;
				if (this._picOptics1 != null)
				{
					this._picOptics1.MouseEnter += this.picOptics_MouseEnter;
				}
			}
		}

		// Token: 0x1700002D RID: 45
		// (get) Token: 0x0600006B RID: 107 RVA: 0x000095F0 File Offset: 0x000077F0
		// (set) Token: 0x0600006C RID: 108 RVA: 0x00009604 File Offset: 0x00007804
		internal PictureBox picPrimary
		{
			[DebuggerNonUserCode]
			get
			{
				return this._picPrimary;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._picPrimary != null)
				{
					this._picPrimary.MouseEnter -= this.picPrimary_MouseEnter;
				}
				this._picPrimary = value;
				if (this._picPrimary != null)
				{
					this._picPrimary.MouseEnter += this.picPrimary_MouseEnter;
				}
			}
		}

		// Token: 0x1700002E RID: 46
		// (get) Token: 0x0600006D RID: 109 RVA: 0x00009658 File Offset: 0x00007858
		// (set) Token: 0x0600006E RID: 110 RVA: 0x0000966C File Offset: 0x0000786C
		internal PictureBox picBackpack
		{
			[DebuggerNonUserCode]
			get
			{
				return this._picBackpack;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._picBackpack != null)
				{
					this._picBackpack.MouseEnter -= this.picBackpack_MouseEnter;
				}
				this._picBackpack = value;
				if (this._picBackpack != null)
				{
					this._picBackpack.MouseEnter += this.picBackpack_MouseEnter;
				}
			}
		}

		// Token: 0x1700002F RID: 47
		// (get) Token: 0x0600006F RID: 111 RVA: 0x000096C0 File Offset: 0x000078C0
		// (set) Token: 0x06000070 RID: 112 RVA: 0x000096D4 File Offset: 0x000078D4
		internal PictureBox picSecondary
		{
			[DebuggerNonUserCode]
			get
			{
				return this._picSecondary;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._picSecondary != null)
				{
					this._picSecondary.MouseEnter -= this.picSecondary_MouseEnter;
				}
				this._picSecondary = value;
				if (this._picSecondary != null)
				{
					this._picSecondary.MouseEnter += this.picSecondary_MouseEnter;
				}
			}
		}

		// Token: 0x17000030 RID: 48
		// (get) Token: 0x06000071 RID: 113 RVA: 0x00009728 File Offset: 0x00007928
		// (set) Token: 0x06000072 RID: 114 RVA: 0x0000973C File Offset: 0x0000793C
		internal PictureBox picPrimaryInv1
		{
			[DebuggerNonUserCode]
			get
			{
				return this._picPrimaryInv1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._picPrimaryInv1 != null)
				{
					this._picPrimaryInv1.MouseEnter -= this.picPrimaryInv_MouseEnter;
				}
				this._picPrimaryInv1 = value;
				if (this._picPrimaryInv1 != null)
				{
					this._picPrimaryInv1.MouseEnter += this.picPrimaryInv_MouseEnter;
				}
			}
		}

		// Token: 0x17000031 RID: 49
		// (get) Token: 0x06000073 RID: 115 RVA: 0x00009790 File Offset: 0x00007990
		// (set) Token: 0x06000074 RID: 116 RVA: 0x000097A4 File Offset: 0x000079A4
		internal PictureBox picPrimaryInv2
		{
			[DebuggerNonUserCode]
			get
			{
				return this._picPrimaryInv2;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._picPrimaryInv2 != null)
				{
					this._picPrimaryInv2.MouseEnter -= this.picPrimaryInv_MouseEnter;
				}
				this._picPrimaryInv2 = value;
				if (this._picPrimaryInv2 != null)
				{
					this._picPrimaryInv2.MouseEnter += this.picPrimaryInv_MouseEnter;
				}
			}
		}

		// Token: 0x17000032 RID: 50
		// (get) Token: 0x06000075 RID: 117 RVA: 0x000097F8 File Offset: 0x000079F8
		// (set) Token: 0x06000076 RID: 118 RVA: 0x0000980C File Offset: 0x00007A0C
		internal PictureBox picPrimaryInv4
		{
			[DebuggerNonUserCode]
			get
			{
				return this._picPrimaryInv4;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._picPrimaryInv4 != null)
				{
					this._picPrimaryInv4.MouseEnter -= this.picPrimaryInv_MouseEnter;
				}
				this._picPrimaryInv4 = value;
				if (this._picPrimaryInv4 != null)
				{
					this._picPrimaryInv4.MouseEnter += this.picPrimaryInv_MouseEnter;
				}
			}
		}

		// Token: 0x17000033 RID: 51
		// (get) Token: 0x06000077 RID: 119 RVA: 0x00009860 File Offset: 0x00007A60
		// (set) Token: 0x06000078 RID: 120 RVA: 0x00009874 File Offset: 0x00007A74
		internal PictureBox picPrimaryInv3
		{
			[DebuggerNonUserCode]
			get
			{
				return this._picPrimaryInv3;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._picPrimaryInv3 != null)
				{
					this._picPrimaryInv3.MouseEnter -= this.picPrimaryInv_MouseEnter;
				}
				this._picPrimaryInv3 = value;
				if (this._picPrimaryInv3 != null)
				{
					this._picPrimaryInv3.MouseEnter += this.picPrimaryInv_MouseEnter;
				}
			}
		}

		// Token: 0x17000034 RID: 52
		// (get) Token: 0x06000079 RID: 121 RVA: 0x000098C8 File Offset: 0x00007AC8
		// (set) Token: 0x0600007A RID: 122 RVA: 0x000098DC File Offset: 0x00007ADC
		internal PictureBox picPrimaryInv7
		{
			[DebuggerNonUserCode]
			get
			{
				return this._picPrimaryInv7;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._picPrimaryInv7 != null)
				{
					this._picPrimaryInv7.MouseEnter -= this.picPrimaryInv_MouseEnter;
				}
				this._picPrimaryInv7 = value;
				if (this._picPrimaryInv7 != null)
				{
					this._picPrimaryInv7.MouseEnter += this.picPrimaryInv_MouseEnter;
				}
			}
		}

		// Token: 0x17000035 RID: 53
		// (get) Token: 0x0600007B RID: 123 RVA: 0x00009930 File Offset: 0x00007B30
		// (set) Token: 0x0600007C RID: 124 RVA: 0x00009944 File Offset: 0x00007B44
		internal PictureBox picPrimaryInv8
		{
			[DebuggerNonUserCode]
			get
			{
				return this._picPrimaryInv8;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._picPrimaryInv8 != null)
				{
					this._picPrimaryInv8.MouseEnter -= this.picPrimaryInv_MouseEnter;
				}
				this._picPrimaryInv8 = value;
				if (this._picPrimaryInv8 != null)
				{
					this._picPrimaryInv8.MouseEnter += this.picPrimaryInv_MouseEnter;
				}
			}
		}

		// Token: 0x17000036 RID: 54
		// (get) Token: 0x0600007D RID: 125 RVA: 0x00009998 File Offset: 0x00007B98
		// (set) Token: 0x0600007E RID: 126 RVA: 0x000099AC File Offset: 0x00007BAC
		internal PictureBox picPrimaryInv6
		{
			[DebuggerNonUserCode]
			get
			{
				return this._picPrimaryInv6;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._picPrimaryInv6 != null)
				{
					this._picPrimaryInv6.MouseEnter -= this.picPrimaryInv_MouseEnter;
				}
				this._picPrimaryInv6 = value;
				if (this._picPrimaryInv6 != null)
				{
					this._picPrimaryInv6.MouseEnter += this.picPrimaryInv_MouseEnter;
				}
			}
		}

		// Token: 0x17000037 RID: 55
		// (get) Token: 0x0600007F RID: 127 RVA: 0x00009A00 File Offset: 0x00007C00
		// (set) Token: 0x06000080 RID: 128 RVA: 0x00009A14 File Offset: 0x00007C14
		internal PictureBox picPrimaryInv5
		{
			[DebuggerNonUserCode]
			get
			{
				return this._picPrimaryInv5;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._picPrimaryInv5 != null)
				{
					this._picPrimaryInv5.MouseEnter -= this.picPrimaryInv_MouseEnter;
				}
				this._picPrimaryInv5 = value;
				if (this._picPrimaryInv5 != null)
				{
					this._picPrimaryInv5.MouseEnter += this.picPrimaryInv_MouseEnter;
				}
			}
		}

		// Token: 0x17000038 RID: 56
		// (get) Token: 0x06000081 RID: 129 RVA: 0x00009A68 File Offset: 0x00007C68
		// (set) Token: 0x06000082 RID: 130 RVA: 0x00009A7C File Offset: 0x00007C7C
		internal PictureBox picPrimaryInv11
		{
			[DebuggerNonUserCode]
			get
			{
				return this._picPrimaryInv11;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._picPrimaryInv11 != null)
				{
					this._picPrimaryInv11.MouseEnter -= this.picPrimaryInv_MouseEnter;
				}
				this._picPrimaryInv11 = value;
				if (this._picPrimaryInv11 != null)
				{
					this._picPrimaryInv11.MouseEnter += this.picPrimaryInv_MouseEnter;
				}
			}
		}

		// Token: 0x17000039 RID: 57
		// (get) Token: 0x06000083 RID: 131 RVA: 0x00009AD0 File Offset: 0x00007CD0
		// (set) Token: 0x06000084 RID: 132 RVA: 0x00009AE4 File Offset: 0x00007CE4
		internal PictureBox picPrimaryInv12
		{
			[DebuggerNonUserCode]
			get
			{
				return this._picPrimaryInv12;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._picPrimaryInv12 != null)
				{
					this._picPrimaryInv12.MouseEnter -= this.picPrimaryInv_MouseEnter;
				}
				this._picPrimaryInv12 = value;
				if (this._picPrimaryInv12 != null)
				{
					this._picPrimaryInv12.MouseEnter += this.picPrimaryInv_MouseEnter;
				}
			}
		}

		// Token: 0x1700003A RID: 58
		// (get) Token: 0x06000085 RID: 133 RVA: 0x00009B38 File Offset: 0x00007D38
		// (set) Token: 0x06000086 RID: 134 RVA: 0x00009B4C File Offset: 0x00007D4C
		internal PictureBox picPrimaryInv10
		{
			[DebuggerNonUserCode]
			get
			{
				return this._picPrimaryInv10;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._picPrimaryInv10 != null)
				{
					this._picPrimaryInv10.MouseEnter -= this.picPrimaryInv_MouseEnter;
				}
				this._picPrimaryInv10 = value;
				if (this._picPrimaryInv10 != null)
				{
					this._picPrimaryInv10.MouseEnter += this.picPrimaryInv_MouseEnter;
				}
			}
		}

		// Token: 0x1700003B RID: 59
		// (get) Token: 0x06000087 RID: 135 RVA: 0x00009BA0 File Offset: 0x00007DA0
		// (set) Token: 0x06000088 RID: 136 RVA: 0x00009BB4 File Offset: 0x00007DB4
		internal PictureBox picPrimaryInv9
		{
			[DebuggerNonUserCode]
			get
			{
				return this._picPrimaryInv9;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._picPrimaryInv9 != null)
				{
					this._picPrimaryInv9.MouseEnter -= this.picPrimaryInv_MouseEnter;
				}
				this._picPrimaryInv9 = value;
				if (this._picPrimaryInv9 != null)
				{
					this._picPrimaryInv9.MouseEnter += this.picPrimaryInv_MouseEnter;
				}
			}
		}

		// Token: 0x1700003C RID: 60
		// (get) Token: 0x06000089 RID: 137 RVA: 0x00009C08 File Offset: 0x00007E08
		// (set) Token: 0x0600008A RID: 138 RVA: 0x00009C1C File Offset: 0x00007E1C
		internal PictureBox picSecondaryInv1
		{
			[DebuggerNonUserCode]
			get
			{
				return this._picSecondaryInv1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._picSecondaryInv1 != null)
				{
					this._picSecondaryInv1.MouseEnter -= this.picSecondaryInv_MouseEnter;
				}
				this._picSecondaryInv1 = value;
				if (this._picSecondaryInv1 != null)
				{
					this._picSecondaryInv1.MouseEnter += this.picSecondaryInv_MouseEnter;
				}
			}
		}

		// Token: 0x1700003D RID: 61
		// (get) Token: 0x0600008B RID: 139 RVA: 0x00009C70 File Offset: 0x00007E70
		// (set) Token: 0x0600008C RID: 140 RVA: 0x00009C84 File Offset: 0x00007E84
		internal PictureBox picSecondaryInv2
		{
			[DebuggerNonUserCode]
			get
			{
				return this._picSecondaryInv2;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._picSecondaryInv2 != null)
				{
					this._picSecondaryInv2.MouseEnter -= this.picSecondaryInv_MouseEnter;
				}
				this._picSecondaryInv2 = value;
				if (this._picSecondaryInv2 != null)
				{
					this._picSecondaryInv2.MouseEnter += this.picSecondaryInv_MouseEnter;
				}
			}
		}

		// Token: 0x1700003E RID: 62
		// (get) Token: 0x0600008D RID: 141 RVA: 0x00009CD8 File Offset: 0x00007ED8
		// (set) Token: 0x0600008E RID: 142 RVA: 0x00009CEC File Offset: 0x00007EEC
		internal PictureBox picSecondaryInv3
		{
			[DebuggerNonUserCode]
			get
			{
				return this._picSecondaryInv3;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._picSecondaryInv3 != null)
				{
					this._picSecondaryInv3.MouseEnter -= this.picSecondaryInv_MouseEnter;
				}
				this._picSecondaryInv3 = value;
				if (this._picSecondaryInv3 != null)
				{
					this._picSecondaryInv3.MouseEnter += this.picSecondaryInv_MouseEnter;
				}
			}
		}

		// Token: 0x1700003F RID: 63
		// (get) Token: 0x0600008F RID: 143 RVA: 0x00009D40 File Offset: 0x00007F40
		// (set) Token: 0x06000090 RID: 144 RVA: 0x00009D54 File Offset: 0x00007F54
		internal PictureBox picSecondaryInv4
		{
			[DebuggerNonUserCode]
			get
			{
				return this._picSecondaryInv4;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._picSecondaryInv4 != null)
				{
					this._picSecondaryInv4.MouseEnter -= this.picSecondaryInv_MouseEnter;
				}
				this._picSecondaryInv4 = value;
				if (this._picSecondaryInv4 != null)
				{
					this._picSecondaryInv4.MouseEnter += this.picSecondaryInv_MouseEnter;
				}
			}
		}

		// Token: 0x17000040 RID: 64
		// (get) Token: 0x06000091 RID: 145 RVA: 0x00009DA8 File Offset: 0x00007FA8
		// (set) Token: 0x06000092 RID: 146 RVA: 0x00009DBC File Offset: 0x00007FBC
		internal PictureBox picSecondaryInv8
		{
			[DebuggerNonUserCode]
			get
			{
				return this._picSecondaryInv8;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._picSecondaryInv8 != null)
				{
					this._picSecondaryInv8.MouseEnter -= this.picSecondaryInv_MouseEnter;
				}
				this._picSecondaryInv8 = value;
				if (this._picSecondaryInv8 != null)
				{
					this._picSecondaryInv8.MouseEnter += this.picSecondaryInv_MouseEnter;
				}
			}
		}

		// Token: 0x17000041 RID: 65
		// (get) Token: 0x06000093 RID: 147 RVA: 0x00009E10 File Offset: 0x00008010
		// (set) Token: 0x06000094 RID: 148 RVA: 0x00009E24 File Offset: 0x00008024
		internal PictureBox picSecondaryInv7
		{
			[DebuggerNonUserCode]
			get
			{
				return this._picSecondaryInv7;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._picSecondaryInv7 != null)
				{
					this._picSecondaryInv7.MouseEnter -= this.picSecondaryInv_MouseEnter;
				}
				this._picSecondaryInv7 = value;
				if (this._picSecondaryInv7 != null)
				{
					this._picSecondaryInv7.MouseEnter += this.picSecondaryInv_MouseEnter;
				}
			}
		}

		// Token: 0x17000042 RID: 66
		// (get) Token: 0x06000095 RID: 149 RVA: 0x00009E78 File Offset: 0x00008078
		// (set) Token: 0x06000096 RID: 150 RVA: 0x00009E8C File Offset: 0x0000808C
		internal PictureBox picSecondaryInv6
		{
			[DebuggerNonUserCode]
			get
			{
				return this._picSecondaryInv6;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._picSecondaryInv6 != null)
				{
					this._picSecondaryInv6.MouseEnter -= this.picSecondaryInv_MouseEnter;
				}
				this._picSecondaryInv6 = value;
				if (this._picSecondaryInv6 != null)
				{
					this._picSecondaryInv6.MouseEnter += this.picSecondaryInv_MouseEnter;
				}
			}
		}

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x06000097 RID: 151 RVA: 0x00009EE0 File Offset: 0x000080E0
		// (set) Token: 0x06000098 RID: 152 RVA: 0x00009EF4 File Offset: 0x000080F4
		internal PictureBox picSecondaryInv5
		{
			[DebuggerNonUserCode]
			get
			{
				return this._picSecondaryInv5;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._picSecondaryInv5 != null)
				{
					this._picSecondaryInv5.MouseEnter -= this.picSecondaryInv_MouseEnter;
				}
				this._picSecondaryInv5 = value;
				if (this._picSecondaryInv5 != null)
				{
					this._picSecondaryInv5.MouseEnter += this.picSecondaryInv_MouseEnter;
				}
			}
		}

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x06000099 RID: 153 RVA: 0x00009F48 File Offset: 0x00008148
		// (set) Token: 0x0600009A RID: 154 RVA: 0x00009F5C File Offset: 0x0000815C
		internal PictureBox picToolInv1
		{
			[DebuggerNonUserCode]
			get
			{
				return this._picToolInv1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._picToolInv1 != null)
				{
					this._picToolInv1.MouseEnter -= this.picToolInv_MouseEnter;
				}
				this._picToolInv1 = value;
				if (this._picToolInv1 != null)
				{
					this._picToolInv1.MouseEnter += this.picToolInv_MouseEnter;
				}
			}
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x0600009B RID: 155 RVA: 0x00009FB0 File Offset: 0x000081B0
		// (set) Token: 0x0600009C RID: 156 RVA: 0x00009FC4 File Offset: 0x000081C4
		internal PictureBox picToolInv7
		{
			[DebuggerNonUserCode]
			get
			{
				return this._picToolInv7;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._picToolInv7 != null)
				{
					this._picToolInv7.MouseEnter -= this.picToolInv_MouseEnter;
				}
				this._picToolInv7 = value;
				if (this._picToolInv7 != null)
				{
					this._picToolInv7.MouseEnter += this.picToolInv_MouseEnter;
				}
			}
		}

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x0600009D RID: 157 RVA: 0x0000A018 File Offset: 0x00008218
		// (set) Token: 0x0600009E RID: 158 RVA: 0x0000A02C File Offset: 0x0000822C
		internal PictureBox picToolInv6
		{
			[DebuggerNonUserCode]
			get
			{
				return this._picToolInv6;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._picToolInv6 != null)
				{
					this._picToolInv6.MouseEnter -= this.picToolInv_MouseEnter;
				}
				this._picToolInv6 = value;
				if (this._picToolInv6 != null)
				{
					this._picToolInv6.MouseEnter += this.picToolInv_MouseEnter;
				}
			}
		}

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x0600009F RID: 159 RVA: 0x0000A080 File Offset: 0x00008280
		// (set) Token: 0x060000A0 RID: 160 RVA: 0x0000A094 File Offset: 0x00008294
		internal PictureBox picToolInv5
		{
			[DebuggerNonUserCode]
			get
			{
				return this._picToolInv5;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._picToolInv5 != null)
				{
					this._picToolInv5.MouseEnter -= this.picToolInv_MouseEnter;
				}
				this._picToolInv5 = value;
				if (this._picToolInv5 != null)
				{
					this._picToolInv5.MouseEnter += this.picToolInv_MouseEnter;
				}
			}
		}

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x060000A1 RID: 161 RVA: 0x0000A0E8 File Offset: 0x000082E8
		// (set) Token: 0x060000A2 RID: 162 RVA: 0x0000A0FC File Offset: 0x000082FC
		internal PictureBox picToolInv4
		{
			[DebuggerNonUserCode]
			get
			{
				return this._picToolInv4;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._picToolInv4 != null)
				{
					this._picToolInv4.MouseEnter -= this.picToolInv_MouseEnter;
				}
				this._picToolInv4 = value;
				if (this._picToolInv4 != null)
				{
					this._picToolInv4.MouseEnter += this.picToolInv_MouseEnter;
				}
			}
		}

		// Token: 0x17000049 RID: 73
		// (get) Token: 0x060000A3 RID: 163 RVA: 0x0000A150 File Offset: 0x00008350
		// (set) Token: 0x060000A4 RID: 164 RVA: 0x0000A164 File Offset: 0x00008364
		internal PictureBox picToolInv2
		{
			[DebuggerNonUserCode]
			get
			{
				return this._picToolInv2;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._picToolInv2 != null)
				{
					this._picToolInv2.MouseEnter -= this.picToolInv_MouseEnter;
				}
				this._picToolInv2 = value;
				if (this._picToolInv2 != null)
				{
					this._picToolInv2.MouseEnter += this.picToolInv_MouseEnter;
				}
			}
		}

		// Token: 0x1700004A RID: 74
		// (get) Token: 0x060000A5 RID: 165 RVA: 0x0000A1B8 File Offset: 0x000083B8
		// (set) Token: 0x060000A6 RID: 166 RVA: 0x0000A1CC File Offset: 0x000083CC
		internal PictureBox picToolInv3
		{
			[DebuggerNonUserCode]
			get
			{
				return this._picToolInv3;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._picToolInv3 != null)
				{
					this._picToolInv3.MouseEnter -= this.picToolInv_MouseEnter;
				}
				this._picToolInv3 = value;
				if (this._picToolInv3 != null)
				{
					this._picToolInv3.MouseEnter += this.picToolInv_MouseEnter;
				}
			}
		}

		// Token: 0x1700004B RID: 75
		// (get) Token: 0x060000A7 RID: 167 RVA: 0x0000A220 File Offset: 0x00008420
		// (set) Token: 0x060000A8 RID: 168 RVA: 0x0000A234 File Offset: 0x00008434
		internal PictureBox picBagInv1
		{
			[DebuggerNonUserCode]
			get
			{
				return this._picBagInv1;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._picBagInv1 != null)
				{
					this._picBagInv1.MouseEnter -= this.picBagInv_MouseEnter;
					this._picBagInv1.MouseEnter -= this.picBagInv_MouseEnter;
				}
				this._picBagInv1 = value;
				if (this._picBagInv1 != null)
				{
					this._picBagInv1.MouseEnter += this.picBagInv_MouseEnter;
					this._picBagInv1.MouseEnter += this.picBagInv_MouseEnter;
				}
			}
		}

		// Token: 0x1700004C RID: 76
		// (get) Token: 0x060000A9 RID: 169 RVA: 0x0000A2B8 File Offset: 0x000084B8
		// (set) Token: 0x060000AA RID: 170 RVA: 0x0000A2CC File Offset: 0x000084CC
		internal PictureBox picBagInv2
		{
			[DebuggerNonUserCode]
			get
			{
				return this._picBagInv2;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._picBagInv2 != null)
				{
					this._picBagInv2.MouseEnter -= this.picBagInv_MouseEnter;
				}
				this._picBagInv2 = value;
				if (this._picBagInv2 != null)
				{
					this._picBagInv2.MouseEnter += this.picBagInv_MouseEnter;
				}
			}
		}

		// Token: 0x1700004D RID: 77
		// (get) Token: 0x060000AB RID: 171 RVA: 0x0000A320 File Offset: 0x00008520
		// (set) Token: 0x060000AC RID: 172 RVA: 0x0000A334 File Offset: 0x00008534
		internal PictureBox picBagInv3
		{
			[DebuggerNonUserCode]
			get
			{
				return this._picBagInv3;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._picBagInv3 != null)
				{
					this._picBagInv3.MouseEnter -= this.picBagInv_MouseEnter;
				}
				this._picBagInv3 = value;
				if (this._picBagInv3 != null)
				{
					this._picBagInv3.MouseEnter += this.picBagInv_MouseEnter;
				}
			}
		}

		// Token: 0x1700004E RID: 78
		// (get) Token: 0x060000AD RID: 173 RVA: 0x0000A388 File Offset: 0x00008588
		// (set) Token: 0x060000AE RID: 174 RVA: 0x0000A39C File Offset: 0x0000859C
		internal PictureBox picBagInv4
		{
			[DebuggerNonUserCode]
			get
			{
				return this._picBagInv4;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._picBagInv4 != null)
				{
					this._picBagInv4.MouseEnter -= this.picBagInv_MouseEnter;
				}
				this._picBagInv4 = value;
				if (this._picBagInv4 != null)
				{
					this._picBagInv4.MouseEnter += this.picBagInv_MouseEnter;
				}
			}
		}

		// Token: 0x1700004F RID: 79
		// (get) Token: 0x060000AF RID: 175 RVA: 0x0000A3F0 File Offset: 0x000085F0
		// (set) Token: 0x060000B0 RID: 176 RVA: 0x0000A404 File Offset: 0x00008604
		internal PictureBox picBagInv5
		{
			[DebuggerNonUserCode]
			get
			{
				return this._picBagInv5;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._picBagInv5 != null)
				{
					this._picBagInv5.MouseEnter -= this.picBagInv_MouseEnter;
				}
				this._picBagInv5 = value;
				if (this._picBagInv5 != null)
				{
					this._picBagInv5.MouseEnter += this.picBagInv_MouseEnter;
				}
			}
		}

		// Token: 0x17000050 RID: 80
		// (get) Token: 0x060000B1 RID: 177 RVA: 0x0000A458 File Offset: 0x00008658
		// (set) Token: 0x060000B2 RID: 178 RVA: 0x0000A46C File Offset: 0x0000866C
		internal PictureBox picBagInv6
		{
			[DebuggerNonUserCode]
			get
			{
				return this._picBagInv6;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._picBagInv6 != null)
				{
					this._picBagInv6.MouseEnter -= this.picBagInv_MouseEnter;
				}
				this._picBagInv6 = value;
				if (this._picBagInv6 != null)
				{
					this._picBagInv6.MouseEnter += this.picBagInv_MouseEnter;
				}
			}
		}

		// Token: 0x17000051 RID: 81
		// (get) Token: 0x060000B3 RID: 179 RVA: 0x0000A4C0 File Offset: 0x000086C0
		// (set) Token: 0x060000B4 RID: 180 RVA: 0x0000A4D4 File Offset: 0x000086D4
		internal PictureBox picBagInv7
		{
			[DebuggerNonUserCode]
			get
			{
				return this._picBagInv7;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._picBagInv7 != null)
				{
					this._picBagInv7.MouseEnter -= this.picBagInv_MouseEnter;
				}
				this._picBagInv7 = value;
				if (this._picBagInv7 != null)
				{
					this._picBagInv7.MouseEnter += this.picBagInv_MouseEnter;
				}
			}
		}

		// Token: 0x17000052 RID: 82
		// (get) Token: 0x060000B5 RID: 181 RVA: 0x0000A528 File Offset: 0x00008728
		// (set) Token: 0x060000B6 RID: 182 RVA: 0x0000A53C File Offset: 0x0000873C
		internal PictureBox picBagInv14
		{
			[DebuggerNonUserCode]
			get
			{
				return this._picBagInv14;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._picBagInv14 != null)
				{
					this._picBagInv14.MouseEnter -= this.picBagInv_MouseEnter;
				}
				this._picBagInv14 = value;
				if (this._picBagInv14 != null)
				{
					this._picBagInv14.MouseEnter += this.picBagInv_MouseEnter;
				}
			}
		}

		// Token: 0x17000053 RID: 83
		// (get) Token: 0x060000B7 RID: 183 RVA: 0x0000A590 File Offset: 0x00008790
		// (set) Token: 0x060000B8 RID: 184 RVA: 0x0000A5A4 File Offset: 0x000087A4
		internal PictureBox picBagInv13
		{
			[DebuggerNonUserCode]
			get
			{
				return this._picBagInv13;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._picBagInv13 != null)
				{
					this._picBagInv13.MouseEnter -= this.picBagInv_MouseEnter;
				}
				this._picBagInv13 = value;
				if (this._picBagInv13 != null)
				{
					this._picBagInv13.MouseEnter += this.picBagInv_MouseEnter;
				}
			}
		}

		// Token: 0x17000054 RID: 84
		// (get) Token: 0x060000B9 RID: 185 RVA: 0x0000A5F8 File Offset: 0x000087F8
		// (set) Token: 0x060000BA RID: 186 RVA: 0x0000A60C File Offset: 0x0000880C
		internal PictureBox picBagInv12
		{
			[DebuggerNonUserCode]
			get
			{
				return this._picBagInv12;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._picBagInv12 != null)
				{
					this._picBagInv12.MouseEnter -= this.picBagInv_MouseEnter;
				}
				this._picBagInv12 = value;
				if (this._picBagInv12 != null)
				{
					this._picBagInv12.MouseEnter += this.picBagInv_MouseEnter;
				}
			}
		}

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x060000BB RID: 187 RVA: 0x0000A660 File Offset: 0x00008860
		// (set) Token: 0x060000BC RID: 188 RVA: 0x0000A674 File Offset: 0x00008874
		internal PictureBox picBagInv11
		{
			[DebuggerNonUserCode]
			get
			{
				return this._picBagInv11;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._picBagInv11 != null)
				{
					this._picBagInv11.MouseEnter -= this.picBagInv_MouseEnter;
				}
				this._picBagInv11 = value;
				if (this._picBagInv11 != null)
				{
					this._picBagInv11.MouseEnter += this.picBagInv_MouseEnter;
				}
			}
		}

		// Token: 0x17000056 RID: 86
		// (get) Token: 0x060000BD RID: 189 RVA: 0x0000A6C8 File Offset: 0x000088C8
		// (set) Token: 0x060000BE RID: 190 RVA: 0x0000A6DC File Offset: 0x000088DC
		internal PictureBox picBagInv10
		{
			[DebuggerNonUserCode]
			get
			{
				return this._picBagInv10;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._picBagInv10 != null)
				{
					this._picBagInv10.MouseEnter -= this.picBagInv_MouseEnter;
				}
				this._picBagInv10 = value;
				if (this._picBagInv10 != null)
				{
					this._picBagInv10.MouseEnter += this.picBagInv_MouseEnter;
				}
			}
		}

		// Token: 0x17000057 RID: 87
		// (get) Token: 0x060000BF RID: 191 RVA: 0x0000A730 File Offset: 0x00008930
		// (set) Token: 0x060000C0 RID: 192 RVA: 0x0000A744 File Offset: 0x00008944
		internal PictureBox picBagInv9
		{
			[DebuggerNonUserCode]
			get
			{
				return this._picBagInv9;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._picBagInv9 != null)
				{
					this._picBagInv9.MouseEnter -= this.picBagInv_MouseEnter;
				}
				this._picBagInv9 = value;
				if (this._picBagInv9 != null)
				{
					this._picBagInv9.MouseEnter += this.picBagInv_MouseEnter;
				}
			}
		}

		// Token: 0x17000058 RID: 88
		// (get) Token: 0x060000C1 RID: 193 RVA: 0x0000A798 File Offset: 0x00008998
		// (set) Token: 0x060000C2 RID: 194 RVA: 0x0000A7AC File Offset: 0x000089AC
		internal PictureBox picBagInv8
		{
			[DebuggerNonUserCode]
			get
			{
				return this._picBagInv8;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._picBagInv8 != null)
				{
					this._picBagInv8.MouseEnter -= this.picBagInv_MouseEnter;
				}
				this._picBagInv8 = value;
				if (this._picBagInv8 != null)
				{
					this._picBagInv8.MouseEnter += this.picBagInv_MouseEnter;
				}
			}
		}

		// Token: 0x17000059 RID: 89
		// (get) Token: 0x060000C3 RID: 195 RVA: 0x0000A800 File Offset: 0x00008A00
		// (set) Token: 0x060000C4 RID: 196 RVA: 0x0000A814 File Offset: 0x00008A14
		internal PictureBox picBagInv21
		{
			[DebuggerNonUserCode]
			get
			{
				return this._picBagInv21;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._picBagInv21 != null)
				{
					this._picBagInv21.MouseEnter -= this.picBagInv_MouseEnter;
				}
				this._picBagInv21 = value;
				if (this._picBagInv21 != null)
				{
					this._picBagInv21.MouseEnter += this.picBagInv_MouseEnter;
				}
			}
		}

		// Token: 0x1700005A RID: 90
		// (get) Token: 0x060000C5 RID: 197 RVA: 0x0000A868 File Offset: 0x00008A68
		// (set) Token: 0x060000C6 RID: 198 RVA: 0x0000A87C File Offset: 0x00008A7C
		internal PictureBox picBagInv20
		{
			[DebuggerNonUserCode]
			get
			{
				return this._picBagInv20;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._picBagInv20 != null)
				{
					this._picBagInv20.MouseEnter -= this.picBagInv_MouseEnter;
				}
				this._picBagInv20 = value;
				if (this._picBagInv20 != null)
				{
					this._picBagInv20.MouseEnter += this.picBagInv_MouseEnter;
				}
			}
		}

		// Token: 0x1700005B RID: 91
		// (get) Token: 0x060000C7 RID: 199 RVA: 0x0000A8D0 File Offset: 0x00008AD0
		// (set) Token: 0x060000C8 RID: 200 RVA: 0x0000A8E4 File Offset: 0x00008AE4
		internal PictureBox picBagInv19
		{
			[DebuggerNonUserCode]
			get
			{
				return this._picBagInv19;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._picBagInv19 != null)
				{
					this._picBagInv19.MouseEnter -= this.picBagInv_MouseEnter;
				}
				this._picBagInv19 = value;
				if (this._picBagInv19 != null)
				{
					this._picBagInv19.MouseEnter += this.picBagInv_MouseEnter;
				}
			}
		}

		// Token: 0x1700005C RID: 92
		// (get) Token: 0x060000C9 RID: 201 RVA: 0x0000A938 File Offset: 0x00008B38
		// (set) Token: 0x060000CA RID: 202 RVA: 0x0000A94C File Offset: 0x00008B4C
		internal PictureBox picBagInv18
		{
			[DebuggerNonUserCode]
			get
			{
				return this._picBagInv18;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._picBagInv18 != null)
				{
					this._picBagInv18.MouseEnter -= this.picBagInv_MouseEnter;
				}
				this._picBagInv18 = value;
				if (this._picBagInv18 != null)
				{
					this._picBagInv18.MouseEnter += this.picBagInv_MouseEnter;
				}
			}
		}

		// Token: 0x1700005D RID: 93
		// (get) Token: 0x060000CB RID: 203 RVA: 0x0000A9A0 File Offset: 0x00008BA0
		// (set) Token: 0x060000CC RID: 204 RVA: 0x0000A9B4 File Offset: 0x00008BB4
		internal PictureBox picBagInv17
		{
			[DebuggerNonUserCode]
			get
			{
				return this._picBagInv17;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._picBagInv17 != null)
				{
					this._picBagInv17.MouseEnter -= this.picBagInv_MouseEnter;
				}
				this._picBagInv17 = value;
				if (this._picBagInv17 != null)
				{
					this._picBagInv17.MouseEnter += this.picBagInv_MouseEnter;
				}
			}
		}

		// Token: 0x1700005E RID: 94
		// (get) Token: 0x060000CD RID: 205 RVA: 0x0000AA08 File Offset: 0x00008C08
		// (set) Token: 0x060000CE RID: 206 RVA: 0x0000AA1C File Offset: 0x00008C1C
		internal PictureBox picBagInv16
		{
			[DebuggerNonUserCode]
			get
			{
				return this._picBagInv16;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._picBagInv16 != null)
				{
					this._picBagInv16.MouseEnter -= this.picBagInv_MouseEnter;
				}
				this._picBagInv16 = value;
				if (this._picBagInv16 != null)
				{
					this._picBagInv16.MouseEnter += this.picBagInv_MouseEnter;
				}
			}
		}

		// Token: 0x1700005F RID: 95
		// (get) Token: 0x060000CF RID: 207 RVA: 0x0000AA70 File Offset: 0x00008C70
		// (set) Token: 0x060000D0 RID: 208 RVA: 0x0000AA84 File Offset: 0x00008C84
		internal PictureBox picBagInv15
		{
			[DebuggerNonUserCode]
			get
			{
				return this._picBagInv15;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._picBagInv15 != null)
				{
					this._picBagInv15.MouseEnter -= this.picBagInv_MouseEnter;
				}
				this._picBagInv15 = value;
				if (this._picBagInv15 != null)
				{
					this._picBagInv15.MouseEnter += this.picBagInv_MouseEnter;
				}
			}
		}

		// Token: 0x17000060 RID: 96
		// (get) Token: 0x060000D1 RID: 209 RVA: 0x0000AAD8 File Offset: 0x00008CD8
		// (set) Token: 0x060000D2 RID: 210 RVA: 0x0000AAEC File Offset: 0x00008CEC
		internal PictureBox picBagInv23
		{
			[DebuggerNonUserCode]
			get
			{
				return this._picBagInv23;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._picBagInv23 != null)
				{
					this._picBagInv23.MouseEnter -= this.picBagInv_MouseEnter;
				}
				this._picBagInv23 = value;
				if (this._picBagInv23 != null)
				{
					this._picBagInv23.MouseEnter += this.picBagInv_MouseEnter;
				}
			}
		}

		// Token: 0x17000061 RID: 97
		// (get) Token: 0x060000D3 RID: 211 RVA: 0x0000AB40 File Offset: 0x00008D40
		// (set) Token: 0x060000D4 RID: 212 RVA: 0x0000AB54 File Offset: 0x00008D54
		internal PictureBox picBagInv22
		{
			[DebuggerNonUserCode]
			get
			{
				return this._picBagInv22;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._picBagInv22 != null)
				{
					this._picBagInv22.MouseEnter -= this.picBagInv_MouseEnter;
				}
				this._picBagInv22 = value;
				if (this._picBagInv22 != null)
				{
					this._picBagInv22.MouseEnter += this.picBagInv_MouseEnter;
				}
			}
		}

		// Token: 0x17000062 RID: 98
		// (get) Token: 0x060000D5 RID: 213 RVA: 0x0000ABA8 File Offset: 0x00008DA8
		// (set) Token: 0x060000D6 RID: 214 RVA: 0x0000ABBC File Offset: 0x00008DBC
		internal PictureBox picBagPrimary
		{
			[DebuggerNonUserCode]
			get
			{
				return this._picBagPrimary;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._picBagPrimary != null)
				{
					this._picBagPrimary.MouseEnter -= this.picBagPrimary_MouseEnter;
				}
				this._picBagPrimary = value;
				if (this._picBagPrimary != null)
				{
					this._picBagPrimary.MouseEnter += this.picBagPrimary_MouseEnter;
				}
			}
		}

		// Token: 0x17000063 RID: 99
		// (get) Token: 0x060000D7 RID: 215 RVA: 0x0000AC10 File Offset: 0x00008E10
		// (set) Token: 0x060000D8 RID: 216 RVA: 0x0000AC24 File Offset: 0x00008E24
		internal PictureBox picBagSecondary
		{
			[DebuggerNonUserCode]
			get
			{
				return this._picBagSecondary;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._picBagSecondary != null)
				{
					this._picBagSecondary.MouseEnter -= this.picBagSecondary_MouseEnter;
				}
				this._picBagSecondary = value;
				if (this._picBagSecondary != null)
				{
					this._picBagSecondary.MouseEnter += this.picBagSecondary_MouseEnter;
				}
			}
		}

		// Token: 0x17000064 RID: 100
		// (get) Token: 0x060000D9 RID: 217 RVA: 0x0000AC78 File Offset: 0x00008E78
		// (set) Token: 0x060000DA RID: 218 RVA: 0x0000AC8C File Offset: 0x00008E8C
		internal PictureBox picBagInv24
		{
			[DebuggerNonUserCode]
			get
			{
				return this._picBagInv24;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				if (this._picBagInv24 != null)
				{
					this._picBagInv24.MouseEnter -= this.picBagInv_MouseEnter;
				}
				this._picBagInv24 = value;
				if (this._picBagInv24 != null)
				{
					this._picBagInv24.MouseEnter += this.picBagInv_MouseEnter;
				}
			}
		}

		// Token: 0x17000065 RID: 101
		// (get) Token: 0x060000DB RID: 219 RVA: 0x0000ACE0 File Offset: 0x00008EE0
		// (set) Token: 0x060000DC RID: 220 RVA: 0x0000ACF4 File Offset: 0x00008EF4
		internal Panel panel2
		{
			[DebuggerNonUserCode]
			get
			{
				return this._panel2;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._panel2 = value;
			}
		}

		// Token: 0x17000066 RID: 102
		// (get) Token: 0x060000DD RID: 221 RVA: 0x0000AD00 File Offset: 0x00008F00
		// (set) Token: 0x060000DE RID: 222 RVA: 0x0000AD14 File Offset: 0x00008F14
		internal Panel panel3
		{
			[DebuggerNonUserCode]
			get
			{
				return this._panel3;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._panel3 = value;
			}
		}

		// Token: 0x17000067 RID: 103
		// (get) Token: 0x060000DF RID: 223 RVA: 0x0000AD20 File Offset: 0x00008F20
		// (set) Token: 0x060000E0 RID: 224 RVA: 0x0000AD34 File Offset: 0x00008F34
		internal Panel panel4
		{
			[DebuggerNonUserCode]
			get
			{
				return this._panel4;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._panel4 = value;
			}
		}

		// Token: 0x17000068 RID: 104
		// (get) Token: 0x060000E1 RID: 225 RVA: 0x0000AD40 File Offset: 0x00008F40
		// (set) Token: 0x060000E2 RID: 226 RVA: 0x0000AD54 File Offset: 0x00008F54
		internal Panel panel5
		{
			[DebuggerNonUserCode]
			get
			{
				return this._panel5;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._panel5 = value;
			}
		}

		// Token: 0x17000069 RID: 105
		// (get) Token: 0x060000E3 RID: 227 RVA: 0x0000AD60 File Offset: 0x00008F60
		// (set) Token: 0x060000E4 RID: 228 RVA: 0x0000AD74 File Offset: 0x00008F74
		internal Panel panel6
		{
			[DebuggerNonUserCode]
			get
			{
				return this._panel6;
			}
			[DebuggerNonUserCode]
			[MethodImpl(MethodImplOptions.Synchronized)]
			set
			{
				this._panel6 = value;
			}
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x0000AD80 File Offset: 0x00008F80
		private void combobox_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
			case Keys.Up:
				e.SuppressKeyPress = false;
				return;
			case Keys.Down:
				e.SuppressKeyPress = false;
				return;
			}
			e.SuppressKeyPress = true;
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x0000ADC4 File Offset: 0x00008FC4
		private void comboboxFOOD_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.comboboxMEDICAL.Text = "Medical:";
			this.comboboxTOOLS.Text = "Tools and Accesories:";
			this.comboboxPARTS.Text = "Parts:";
			this.comboboxPISTOL.Text = "Pistols:";
			this.comboboxRIFLE.Text = "Assault Rifles:";
			this.comboboxSUBMACHINE.Text = "Sub Machine Guns:";
			this.comboboxSHOTGUN.Text = "Shotguns:";
			this.comboboxSNIPER.Text = "Sniper Rifles:";
			this.comboboxMACHINEGUN.Text = "Machine Guns:";
			this.comboboxMISC.Text = "Clothing and Misc:";
			this.btnAddInv.Enabled = true;
			this.btnAddBag.Enabled = true;
			object selectedItem = this.comboboxFOOD.SelectedItem;
			if (Operators.ConditionalCompareObjectEqual(selectedItem, "Raw Steak", false))
			{
				this.invtype = 3;
				this.itemsize = 1;
				this.itempicture = 0;
				this.itemname = "FoodSteakRaw";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Cooked Steak", false))
			{
				this.invtype = 3;
				this.itemsize = 1;
				this.itempicture = 1;
				this.itemname = "FoodSteakCooked";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Baked Beans", false))
			{
				this.invtype = 3;
				this.itemsize = 1;
				this.itempicture = 2;
				this.itemname = "FoodCanBakedBeans";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Sardines", false))
			{
				this.invtype = 3;
				this.itemsize = 1;
				this.itempicture = 3;
				this.itemname = "FoodCanSardines";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Pasta", false))
			{
				this.invtype = 3;
				this.itemsize = 1;
				this.itempicture = 4;
				this.itemname = "FoodCanPasta";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Coke", false))
			{
				this.invtype = 3;
				this.itemsize = 1;
				this.itempicture = 5;
				this.itemname = "ItemSodaCoke";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Pepsi", false))
			{
				this.invtype = 3;
				this.itemsize = 1;
				this.itempicture = 6;
				this.itemname = "ItemSodaPepsi";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Water Bottle", false))
			{
				this.invtype = 3;
				this.itemsize = 1;
				this.itempicture = 7;
				this.itemname = "ItemWaterBottle";
			}
			else
			{
				MessageBox.Show("Please Select a Valid Item", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			this.picPreview.Image = this.imgPrimaryInv.Images[this.itempicture];
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x0000B058 File Offset: 0x00009258
		private void comboboxMEDICAL_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.comboboxFOOD.Text = "Food:";
			this.comboboxTOOLS.Text = "Tools and Accesories:";
			this.comboboxPARTS.Text = "Parts:";
			this.comboboxPISTOL.Text = "Pistols:";
			this.comboboxRIFLE.Text = "Assault Rifles:";
			this.comboboxSUBMACHINE.Text = "Sub Machine Guns:";
			this.comboboxSHOTGUN.Text = "Shotguns:";
			this.comboboxSNIPER.Text = "Sniper Rifles:";
			this.comboboxMACHINEGUN.Text = "Machine Guns:";
			this.comboboxMISC.Text = "Clothing and Misc:";
			this.btnAddInv.Enabled = true;
			this.btnAddBag.Enabled = true;
			object selectedItem = this.comboboxMEDICAL.SelectedItem;
			if (Operators.ConditionalCompareObjectEqual(selectedItem, "Bandage", false))
			{
				this.invtype = 5;
				this.itemsize = 1;
				this.itempicture = 0;
				this.itemname = "ItemBandage";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Pain Killers", false))
			{
				this.invtype = 3;
				this.itemsize = 1;
				this.itempicture = 8;
				this.itemname = "ItemPainkiller";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Morphine", false))
			{
				this.invtype = 3;
				this.itemsize = 1;
				this.itempicture = 9;
				this.itemname = "ItemMorphine";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Epinephrine", false))
			{
				this.invtype = 3;
				this.itemsize = 1;
				this.itempicture = 10;
				this.itemname = "ItemEpinephrine";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Antibiotic", false))
			{
				this.invtype = 3;
				this.itemsize = 1;
				this.itempicture = 11;
				this.itemname = "ItemAntibiotic";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Blood Bag", false))
			{
				this.invtype = 3;
				this.itemsize = 1;
				this.itempicture = 12;
				this.itemname = "ItemBloodbag";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Heat Pack", false))
			{
				this.invtype = 3;
				this.itemsize = 1;
				this.itempicture = 13;
				this.itemname = "ItemHeatPack";
			}
			else
			{
				MessageBox.Show("Please Select a Valid Item", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			if (this.invtype == 3)
			{
				this.picPreview.Image = this.imgPrimaryInv.Images[this.itempicture];
			}
			else
			{
				this.picPreview.Image = this.imgSecondaryInv.Images[this.itempicture];
			}
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x0000B2EC File Offset: 0x000094EC
		private void comboboxTOOLS_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.comboboxFOOD.Text = "Food:";
			this.comboboxMEDICAL.Text = "Medical:";
			this.comboboxTOOLS.Text = "Tools and Accesories:";
			this.comboboxPARTS.Text = "Parts:";
			this.comboboxPISTOL.Text = "Pistols:";
			this.comboboxRIFLE.Text = "Assault Rifles:";
			this.comboboxSUBMACHINE.Text = "Sub Machine Guns:";
			this.comboboxSHOTGUN.Text = "Shotguns:";
			this.comboboxSNIPER.Text = "Sniper Rifles:";
			this.comboboxMACHINEGUN.Text = "Machine Guns:";
			this.comboboxMISC.Text = "Clothing and Misc:";
			this.btnAddInv.Enabled = true;
			this.btnAddBag.Enabled = true;
			object selectedItem = this.comboboxTOOLS.SelectedItem;
			if (Operators.ConditionalCompareObjectEqual(selectedItem, "Binocular", false))
			{
				this.invtype = 1;
				this.itemsize = 1;
				this.itempicture = 0;
				this.itemname = "Binocular";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Range Finder", false))
			{
				this.invtype = 1;
				this.itemsize = 1;
				this.itempicture = 1;
				this.itemname = "Binocular_Vector";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Night Vision Goggles", false))
			{
				this.invtype = 1;
				this.itemsize = 1;
				this.itempicture = 2;
				this.itemname = "NVGoggles";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "GPS", false))
			{
				this.invtype = 6;
				this.itemsize = 1;
				this.itempicture = 3;
				this.itemname = "ItemGPS";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Map", false))
			{
				this.invtype = 6;
				this.itemsize = 1;
				this.itempicture = 4;
				this.itemname = "ItemMap";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Compass", false))
			{
				this.invtype = 6;
				this.itemsize = 1;
				this.itempicture = 5;
				this.itemname = "ItemCompass";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Watch", false))
			{
				this.invtype = 6;
				this.itemsize = 1;
				this.itempicture = 6;
				this.itemname = "ItemWatch";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Flashlight", false))
			{
				this.invtype = 6;
				this.itemsize = 1;
				this.itempicture = 7;
				this.itemname = "ItemFlashlight";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Military Flash Light", false))
			{
				this.invtype = 6;
				this.itemsize = 1;
				this.itempicture = 8;
				this.itemname = "ItemFlashlightRed";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Knife", false))
			{
				this.invtype = 6;
				this.itemsize = 1;
				this.itempicture = 9;
				this.itemname = "ItemKnife";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Hatchet", false))
			{
				this.invtype = 6;
				this.itemsize = 1;
				this.itempicture = 10;
				this.itemname = "ItemHatchet";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Matchbox", false))
			{
				this.invtype = 6;
				this.itemsize = 1;
				this.itempicture = 11;
				this.itemname = "ItemMatchbox";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Etrench Tool", false))
			{
				this.invtype = 6;
				this.itemsize = 1;
				this.itempicture = 12;
				this.itemname = "ItemEtool";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Tool Box", false))
			{
				this.invtype = 6;
				this.itemsize = 1;
				this.itempicture = 13;
				this.itemname = "ItemToolbox";
			}
			else
			{
				MessageBox.Show("Please Select a Valid Item", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			if (this.invtype == 1)
			{
				this.picPreview.Image = this.imgTools.Images[this.itempicture];
			}
			else
			{
				this.picPreview.Image = this.imgTools.Images[this.itempicture];
			}
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x0000B6F4 File Offset: 0x000098F4
		private void comboboxPARTS_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.comboboxFOOD.Text = "Food:";
			this.comboboxMEDICAL.Text = "Medical:";
			this.comboboxTOOLS.Text = "Tools and Accesories:";
			this.comboboxPISTOL.Text = "Pistols:";
			this.comboboxRIFLE.Text = "Assault Rifles:";
			this.comboboxSUBMACHINE.Text = "Sub Machine Guns:";
			this.comboboxSHOTGUN.Text = "Shotguns:";
			this.comboboxSNIPER.Text = "Sniper Rifles:";
			this.comboboxMACHINEGUN.Text = "Machine Guns:";
			this.comboboxMISC.Text = "Clothing and Misc:";
			this.btnAddInv.Enabled = true;
			this.btnAddBag.Enabled = true;
			object selectedItem = this.comboboxPARTS.SelectedItem;
			if (Operators.ConditionalCompareObjectEqual(selectedItem, "Wood Pile", false))
			{
				this.invtype = 3;
				this.itemsize = 2;
				this.itempicture = 14;
				this.itemname = "PartWoodPile";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Wheel", false))
			{
				this.invtype = 3;
				this.itemsize = 6;
				this.itempicture = 15;
				this.itemname = "PartWheel";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Fuel Tank", false))
			{
				this.invtype = 3;
				this.itemsize = 4;
				this.itempicture = 16;
				this.itemname = "PartFueltank";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Glass", false))
			{
				this.invtype = 3;
				this.itemsize = 2;
				this.itempicture = 17;
				this.itemname = "PartGlass";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Engine", false))
			{
				this.invtype = 3;
				this.itemsize = 6;
				this.itempicture = 18;
				this.itemname = "PartEngine";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Scrap Metal", false))
			{
				this.invtype = 3;
				this.itemsize = 3;
				this.itempicture = 19;
				this.itemname = "PartGeneric";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Helicopter Rotor", false))
			{
				this.invtype = 3;
				this.itemsize = 6;
				this.itempicture = 20;
				this.itemname = "PartVRotor";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Jerry Can", false))
			{
				this.invtype = 3;
				this.itemsize = 3;
				this.itempicture = 21;
				this.itemname = "ItemJerrycan";
			}
			else
			{
				MessageBox.Show("Please Select a Valid Item", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			this.picPreview.Image = this.imgPrimaryInv.Images[this.itempicture];
		}

		// Token: 0x060000EA RID: 234 RVA: 0x0000B990 File Offset: 0x00009B90
		private void comboboxPISTOL_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.comboboxFOOD.Text = "Food:";
			this.comboboxMEDICAL.Text = "Medical:";
			this.comboboxTOOLS.Text = "Tools and Accesories:";
			this.comboboxPARTS.Text = "Parts:";
			this.comboboxPISTOL.Text = "Pistols:";
			this.comboboxRIFLE.Text = "Assault Rifles:";
			this.comboboxSUBMACHINE.Text = "Sub Machine Guns:";
			this.comboboxSHOTGUN.Text = "Shotguns:";
			this.comboboxSNIPER.Text = "Sniper Rifles:";
			this.comboboxMACHINEGUN.Text = "Machine Guns:";
			this.comboboxMISC.Text = "Clothing and Misc:";
			this.btnAddInv.Enabled = true;
			this.btnAddBag.Enabled = true;
			object selectedItem = this.comboboxPISTOL.SelectedItem;
			checked
			{
				if (Operators.ConditionalCompareObjectEqual(selectedItem, "G17", false))
				{
					this.invtype = 4;
					this.itemsize = 10;
					this.itempicture = 0;
					this.itemname = "glock17_EP1";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "M9", false))
				{
					this.invtype = 4;
					this.itemsize = 10;
					this.itempicture = 1;
					this.itemname = "M9";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "M9 Silenced", false))
				{
					this.invtype = 4;
					this.itemsize = 10;
					this.itempicture = 2;
					this.itemname = "M9SD";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Makarov PM", false))
				{
					this.invtype = 4;
					this.itemsize = 10;
					this.itempicture = 3;
					this.itemname = "Makarov";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "M1911", false))
				{
					this.invtype = 4;
					this.itemsize = 10;
					this.itempicture = 4;
					this.itemname = "Colt1911";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Uzi", false))
				{
					this.invtype = 4;
					this.itemsize = 10;
					this.itempicture = 5;
					this.itemname = "UZI_EP1";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Revolver", false))
				{
					this.invtype = 4;
					this.itemsize = 10;
					this.itempicture = 6;
					this.itemname = "revolver_EP1";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "G17 Pistol Ammo", false))
				{
					this.invtype = 5;
					this.itemsize = 1;
					this.itempicture = 1;
					this.itemname = "17Rnd_9x19_glock17";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "M9 Pistol Ammo", false))
				{
					this.invtype = 5;
					this.itemsize = 1;
					this.itempicture = 2;
					this.itemname = "15Rnd_9x19_M9";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "M9 Silenced Pistol Ammo", false))
				{
					this.invtype = 5;
					this.itemsize = 1;
					this.itempicture = 3;
					this.itemname = "15Rnd_9x19_M9SD";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Makarov Pistol Ammo", false))
				{
					this.invtype = 5;
					this.itemsize = 1;
					this.itempicture = 4;
					this.itemname = "8Rnd_9x18_Makarov";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "M1911 Pistol Ammo", false))
				{
					this.invtype = 5;
					this.itemsize = 1;
					this.itempicture = 5;
					this.itemname = "7Rnd_45ACP_1911";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Uzi Pistol Ammo", false))
				{
					this.invtype = 5;
					this.itemsize = 1;
					this.itempicture = 6;
					this.itemname = "15Rnd_9x19_M9";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Revolver Pistol Ammo", false))
				{
					this.invtype = 5;
					this.itemsize = 1;
					this.itempicture = 7;
					this.itemname = "6Rnd_45ACP";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "", false))
				{
					this.btnAddInv.Enabled = false;
					this.btnAddBag.Enabled = false;
					if (this.keyinput == 38)
					{
						this.comboboxPISTOL.SelectedIndex = this.comboboxPISTOL.SelectedIndex - 1;
					}
					if (this.keyinput == 40)
					{
						this.comboboxPISTOL.SelectedIndex = this.comboboxPISTOL.SelectedIndex + 1;
					}
				}
				else
				{
					MessageBox.Show("Please Select a Valid Item", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				if (this.invtype == 4)
				{
					this.picPreview.Image = this.imgSecondaryWeapons.Images[this.itempicture];
				}
				else
				{
					this.picPreview.Image = this.imgSecondaryInv.Images[this.itempicture];
				}
			}
		}

		// Token: 0x060000EB RID: 235 RVA: 0x0000BE0C File Offset: 0x0000A00C
		private void comboboxRIFLE_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.comboboxFOOD.Text = "Food:";
			this.comboboxMEDICAL.Text = "Medical:";
			this.comboboxTOOLS.Text = "Tools and Accessories:";
			this.comboboxPARTS.Text = "Parts:";
			this.comboboxPISTOL.Text = "Pistols:";
			this.comboboxSUBMACHINE.Text = "Sub Machine Guns:";
			this.comboboxSHOTGUN.Text = "Shotguns:";
			this.comboboxSNIPER.Text = "Sniper Rifles:";
			this.comboboxMACHINEGUN.Text = "Machine Guns:";
			this.comboboxMISC.Text = "Clothing and Misc:";
			this.btnAddInv.Enabled = true;
			this.btnAddBag.Enabled = true;
			object selectedItem = this.comboboxRIFLE.SelectedItem;
			checked
			{
				if (Operators.ConditionalCompareObjectEqual(selectedItem, "AK-74", false))
				{
					this.invtype = 2;
					this.itemsize = 10;
					this.itempicture = 0;
					this.itemname = "AK_74";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "AKM", false))
				{
					this.invtype = 2;
					this.itemsize = 10;
					this.itempicture = 1;
					this.itemname = "AK_47_M";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "AKS-74 Kobra", false))
				{
					this.invtype = 2;
					this.itemsize = 10;
					this.itempicture = 2;
					this.itemname = "AKS_74_kobra";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "AKS-74U", false))
				{
					this.invtype = 2;
					this.itemsize = 10;
					this.itempicture = 3;
					this.itemname = "AKS_74_U";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "FN FAL", false))
				{
					this.invtype = 2;
					this.itemsize = 10;
					this.itempicture = 4;
					this.itemname = "FN_FAL";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "FN FAL AN/PVS-4", false))
				{
					this.invtype = 2;
					this.itemsize = 10;
					this.itempicture = 5;
					this.itemname = "FN_FAL_ANPVS4";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "L85A2 AWS", false))
				{
					this.invtype = 2;
					this.itemsize = 10;
					this.itempicture = 6;
					this.itemname = "BAF_L85A2_RIS_CWS";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Lee Enfield", false))
				{
					this.invtype = 2;
					this.itemsize = 10;
					this.itempicture = 7;
					this.itemname = "LeeEnfield";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "M16A2", false))
				{
					this.invtype = 2;
					this.itemsize = 10;
					this.itempicture = 8;
					this.itemname = "M16A2";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "M16A2 M203", false))
				{
					this.invtype = 2;
					this.itemsize = 10;
					this.itempicture = 9;
					this.itemname = "M16A2GL";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "M16A2 ACOG", false))
				{
					this.invtype = 2;
					this.itemsize = 10;
					this.itempicture = 10;
					this.itemname = "m16a4_acg";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "M4A1", false))
				{
					this.invtype = 2;
					this.itemsize = 10;
					this.itempicture = 11;
					this.itemname = "M4A1";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "M4A1 CCO Silenced", false))
				{
					this.invtype = 2;
					this.itemsize = 10;
					this.itempicture = 12;
					this.itemname = "M4A1_AIM_SD_camo";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "M4A1 CCO", false))
				{
					this.invtype = 2;
					this.itemsize = 10;
					this.itempicture = 13;
					this.itemname = "M4A1_Aim";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "M4A3 CCO", false))
				{
					this.invtype = 2;
					this.itemsize = 10;
					this.itempicture = 14;
					this.itemname = "M4A3_CCO_EP1";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Cross Bow", false))
				{
					this.invtype = 2;
					this.itemsize = 10;
					this.itempicture = 15;
					this.itemname = "Crossbow";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "30 Round AK-74 Magazine", false))
				{
					this.invtype = 3;
					this.itemsize = 1;
					this.itempicture = 22;
					this.itemname = "30Rnd_545x39_AK";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "30 Round AKM Magazine", false))
				{
					this.invtype = 3;
					this.itemsize = 1;
					this.itempicture = 23;
					this.itemname = "30Rnd_762x39_AK47";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "30 Round AKS-74 Kobra Magazine", false))
				{
					this.invtype = 3;
					this.itemsize = 1;
					this.itempicture = 24;
					this.itemname = "30Rnd_545x39_AK";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "30 Round AKS-74U Magazine", false))
				{
					this.invtype = 3;
					this.itemsize = 1;
					this.itempicture = 25;
					this.itemname = "30Rnd_545x39_AK";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "30 Round FN FAL Magazine", false))
				{
					this.invtype = 3;
					this.itemsize = 1;
					this.itempicture = 26;
					this.itemname = "20Rnd_762x51_FNFAL";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "30 Round FN FAL AN/PVS-4 Magazine", false))
				{
					this.invtype = 3;
					this.itemsize = 1;
					this.itempicture = 27;
					this.itemname = "20Rnd_762x51_FNFAL";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "30 Round L85A2 AWS Magazine", false))
				{
					this.invtype = 3;
					this.itemsize = 1;
					this.itempicture = 28;
					this.itemname = "30Rnd_556x45_Stanag";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "10 Round Lee Enfield Magazine", false))
				{
					this.invtype = 3;
					this.itemsize = 1;
					this.itempicture = 29;
					this.itemname = "10x_303";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "30 Round M16A2 Magazine", false))
				{
					this.invtype = 3;
					this.itemsize = 1;
					this.itempicture = 30;
					this.itemname = "30Rnd_556x45_Stanag";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "30 Round M16A4 ACOG Magazine", false))
				{
					this.invtype = 3;
					this.itemsize = 1;
					this.itempicture = 31;
					this.itemname = "30Rnd_556x45_Stanag";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "30 Round M4A1 Magazine", false))
				{
					this.invtype = 3;
					this.itemsize = 1;
					this.itempicture = 32;
					this.itemname = "30Rnd_556x45_Stanag";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "30 Round M4A1 CCO Silenced Magazine", false))
				{
					this.invtype = 3;
					this.itemsize = 1;
					this.itempicture = 33;
					this.itemname = "30Rnd_556x45_StanagSD";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "30 Round M4A1 CCO Magazine", false))
				{
					this.invtype = 3;
					this.itemsize = 1;
					this.itempicture = 34;
					this.itemname = "30Rnd_556x45_Stanag";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "30 Round M4A1 Holo Magazine", false))
				{
					this.invtype = 3;
					this.itemsize = 1;
					this.itempicture = 35;
					this.itemname = "30Rnd_556x45_Stanag";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "30 Round M4A3 CCO  Magazine", false))
				{
					this.invtype = 3;
					this.itemsize = 1;
					this.itempicture = 36;
					this.itemname = "30Rnd_556x45_Stanag";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "1 Round Steel Bolt Crossbow Magazine", false))
				{
					this.invtype = 3;
					this.itemsize = 1;
					this.itempicture = 37;
					this.itemname = "BoltSteel";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "1 Round M203 HE Magazine", false))
				{
					this.invtype = 5;
					this.itemsize = 1;
					this.itempicture = 8;
					this.itemname = "1Rnd_HE_M203";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "1 Round M203 Smoke Magazine", false))
				{
					this.invtype = 5;
					this.itemsize = 1;
					this.itempicture = 9;
					this.itemname = "1Rnd_Smoke_M203";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "1 Round M203 Flare White Magazine", false))
				{
					this.invtype = 5;
					this.itemsize = 1;
					this.itempicture = 10;
					this.itemname = "FlareWhite_M203";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "1 Round M203 Flare Green Magazine", false))
				{
					this.invtype = 5;
					this.itemsize = 1;
					this.itempicture = 11;
					this.itemname = "FlareGreen_M203";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "", false))
				{
					this.btnAddInv.Enabled = false;
					this.btnAddBag.Enabled = false;
					if (this.keyinput == 38)
					{
						this.comboboxRIFLE.SelectedIndex = this.comboboxRIFLE.SelectedIndex - 1;
					}
					if (this.keyinput == 40)
					{
						this.comboboxRIFLE.SelectedIndex = this.comboboxRIFLE.SelectedIndex + 1;
					}
				}
				else
				{
					MessageBox.Show("Please Select a Valid Item", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				if (this.invtype == 2)
				{
					this.picPreview.Image = this.imgPrimaryWeapons.Images[this.itempicture];
				}
				else if (this.invtype == 3)
				{
					this.picPreview.Image = this.imgPrimaryInv.Images[this.itempicture];
				}
				else
				{
					this.picPreview.Image = this.imgSecondaryInv.Images[this.itempicture];
				}
			}
		}

		// Token: 0x060000EC RID: 236 RVA: 0x0000C728 File Offset: 0x0000A928
		private void comboboxSUBMACHINE_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.comboboxFOOD.Text = "Food:";
			this.comboboxMEDICAL.Text = "Medical:";
			this.comboboxTOOLS.Text = "Tools and Accessories:";
			this.comboboxPARTS.Text = "Parts:";
			this.comboboxPISTOL.Text = "Pistols:";
			this.comboboxRIFLE.Text = "Assault Rifles:";
			this.comboboxSHOTGUN.Text = "Shotguns:";
			this.comboboxSNIPER.Text = "Sniper Rifles:";
			this.comboboxMACHINEGUN.Text = "Machine Guns:";
			this.comboboxMISC.Text = "Clothing and Misc:";
			this.btnAddInv.Enabled = true;
			this.btnAddBag.Enabled = true;
			object selectedItem = this.comboboxSUBMACHINE.SelectedItem;
			checked
			{
				if (Operators.ConditionalCompareObjectEqual(selectedItem, "Bizon PP-19 Silenced", false))
				{
					this.invtype = 2;
					this.itemsize = 10;
					this.itempicture = 16;
					this.itemname = "bizon_silenced";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "MP5A5", false))
				{
					this.invtype = 2;
					this.itemsize = 10;
					this.itempicture = 17;
					this.itemname = "MP5A5";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "MP5 Silenced", false))
				{
					this.invtype = 2;
					this.itemsize = 10;
					this.itempicture = 18;
					this.itemname = "MP5SD";
					this.itemname = "MP5SD";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "64 Round Bizon PP-19 SD Magazine", false))
				{
					this.invtype = 3;
					this.itemsize = 10;
					this.itempicture = 38;
					this.itemname = "64Rnd_9x19_SD_Bizon";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "30 Round MP5A5 Magazine", false))
				{
					this.invtype = 3;
					this.itemsize = 1;
					this.itempicture = 39;
					this.itemname = "30Rnd_9x19_MP5";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "30 Round  MP5 Silenced Magazine", false))
				{
					this.invtype = 3;
					this.itemsize = 1;
					this.itempicture = 40;
					this.itemname = "30Rnd_9x19_MP5SD";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "", false))
				{
					this.btnAddInv.Enabled = false;
					this.btnAddBag.Enabled = false;
					if (this.keyinput == 38)
					{
						this.comboboxSUBMACHINE.SelectedIndex = this.comboboxSUBMACHINE.SelectedIndex - 1;
					}
					if (this.keyinput == 40)
					{
						this.comboboxSUBMACHINE.SelectedIndex = this.comboboxSUBMACHINE.SelectedIndex + 1;
					}
				}
				else
				{
					MessageBox.Show("Please Select a Valid Item", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				if (this.invtype == 2)
				{
					this.picPreview.Image = this.imgPrimaryWeapons.Images[this.itempicture];
				}
				else
				{
					this.picPreview.Image = this.imgPrimaryInv.Images[this.itempicture];
				}
			}
		}

		// Token: 0x060000ED RID: 237 RVA: 0x0000CA0C File Offset: 0x0000AC0C
		private void comboboxSHOTGUN_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.comboboxFOOD.Text = "Food:";
			this.comboboxMEDICAL.Text = "Medical:";
			this.comboboxTOOLS.Text = "Tools and Accessories:";
			this.comboboxPARTS.Text = "Parts:";
			this.comboboxPISTOL.Text = "Pistols:";
			this.comboboxRIFLE.Text = "Assault Rifles:";
			this.comboboxSUBMACHINE.Text = "Sub Machine Guns:";
			this.comboboxSNIPER.Text = "Sniper Rifles:";
			this.comboboxMACHINEGUN.Text = "Machine Guns:";
			this.comboboxMISC.Text = "Clothing and Misc:";
			this.btnAddInv.Enabled = true;
			this.btnAddBag.Enabled = true;
			object selectedItem = this.comboboxSHOTGUN.SelectedItem;
			checked
			{
				if (Operators.ConditionalCompareObjectEqual(selectedItem, "Double Barrel Shotgun", false))
				{
					this.invtype = 2;
					this.itemsize = 10;
					this.itempicture = 19;
					this.itemname = "MR43";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "M1014", false))
				{
					this.invtype = 2;
					this.itemsize = 10;
					this.itempicture = 20;
					this.itemname = "M1014";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Remington 870", false))
				{
					this.invtype = 2;
					this.itemsize = 10;
					this.itempicture = 21;
					this.itemname = "Remington870_lamp";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Winchester 1866", false))
				{
					this.invtype = 2;
					this.itemsize = 10;
					this.itempicture = 22;
					this.itemname = "Winchester1866";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "8 Round Shotgun Slugs", false))
				{
					this.invtype = 3;
					this.itemsize = 10;
					this.itempicture = 41;
					this.itemname = "8Rnd_B_Beneli_74Slug";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "8 Round Shotgun Pellets", false))
				{
					this.invtype = 3;
					this.itemsize = 10;
					this.itempicture = 42;
					this.itemname = "8Rnd_B_Beneli_Pellets";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "15 Round 1866 Shotgun Slugs", false))
				{
					this.invtype = 3;
					this.itemsize = 10;
					this.itempicture = 43;
					this.itemname = "15Rnd_W1866_Slug";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "", false))
				{
					this.btnAddInv.Enabled = false;
					this.btnAddBag.Enabled = false;
					if (this.keyinput == 38)
					{
						this.comboboxSHOTGUN.SelectedIndex = this.comboboxSHOTGUN.SelectedIndex - 1;
					}
					if (this.keyinput == 40)
					{
						this.comboboxSHOTGUN.SelectedIndex = this.comboboxSHOTGUN.SelectedIndex + 1;
					}
				}
				else
				{
					MessageBox.Show("Please Select a Valid Item", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				if (this.invtype == 2)
				{
					this.picPreview.Image = this.imgPrimaryWeapons.Images[this.itempicture];
				}
				else
				{
					this.picPreview.Image = this.imgPrimaryInv.Images[this.itempicture];
				}
			}
		}

		// Token: 0x060000EE RID: 238 RVA: 0x0000CD1C File Offset: 0x0000AF1C
		private void comboboxSNIPER_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.comboboxFOOD.Text = "Food:";
			this.comboboxMEDICAL.Text = "Medical:";
			this.comboboxTOOLS.Text = "Tools and Accessories:";
			this.comboboxPARTS.Text = "Parts:";
			this.comboboxPISTOL.Text = "Pistols:";
			this.comboboxRIFLE.Text = "Assault Rifles:";
			this.comboboxSUBMACHINE.Text = "Sub Machine Guns:";
			this.comboboxSHOTGUN.Text = "Shotguns:";
			this.comboboxMACHINEGUN.Text = "Machine Guns:";
			this.comboboxMISC.Text = "Clothing and Misc:";
			this.btnAddInv.Enabled = true;
			this.btnAddBag.Enabled = true;
			object selectedItem = this.comboboxSNIPER.SelectedItem;
			checked
			{
				if (Operators.ConditionalCompareObjectEqual(selectedItem, "AS50", false))
				{
					this.invtype = 2;
					this.itemsize = 10;
					this.itempicture = 23;
					this.itemname = "BAF_AS50_scoped";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "CZ50", false))
				{
					this.invtype = 2;
					this.itemsize = 10;
					this.itempicture = 24;
					this.itemname = "huntingrifle";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "DMR", false))
				{
					this.invtype = 2;
					this.itemsize = 10;
					this.itempicture = 25;
					this.itemname = "DMR";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "M14 AIM", false))
				{
					this.invtype = 2;
					this.itemsize = 10;
					this.itempicture = 26;
					this.itemname = "M14_EP1";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "M24", false))
				{
					this.invtype = 2;
					this.itemsize = 10;
					this.itempicture = 27;
					this.itemname = "M24";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "M107", false))
				{
					this.invtype = 2;
					this.itemsize = 10;
					this.itempicture = 28;
					this.itemname = "m107_DZ";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "SVD Camo", false))
				{
					this.invtype = 2;
					this.itemsize = 10;
					this.itempicture = 29;
					this.itemname = "SVD_Camo";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "10 Round AS50 Magazine", false))
				{
					this.invtype = 3;
					this.itemsize = 1;
					this.itempicture = 44;
					this.itemname = "10Rnd_127x99_m107";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "5 Round CZ550 Magazine", false))
				{
					this.invtype = 3;
					this.itemsize = 1;
					this.itempicture = 45;
					this.itemname = "5x_22_LR_17_HMR";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "20 Round DMR Magazine", false))
				{
					this.invtype = 3;
					this.itemsize = 1;
					this.itempicture = 46;
					this.itemname = "20Rnd_762x51_DMR";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "20 Round M14 AIM Magazine", false))
				{
					this.invtype = 3;
					this.itemsize = 1;
					this.itempicture = 47;
					this.itemname = "20Rnd_762x51_DMR";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "5 Round M24 Magazine", false))
				{
					this.invtype = 3;
					this.itemsize = 1;
					this.itempicture = 48;
					this.itemname = "5Rnd_762x51_M24";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "10 Round M107 Magazine", false))
				{
					this.invtype = 3;
					this.itemsize = 1;
					this.itempicture = 49;
					this.itemname = "10Rnd_127x99_m107";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "10 Round SVD Camo Magazine", false))
				{
					this.invtype = 3;
					this.itemsize = 1;
					this.itempicture = 50;
					this.itemname = "10Rnd_762x54_SVD";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "", false))
				{
					this.btnAddInv.Enabled = false;
					this.btnAddBag.Enabled = false;
					if (this.keyinput == 38)
					{
						this.comboboxSNIPER.SelectedIndex = this.comboboxSNIPER.SelectedIndex - 1;
					}
					if (this.keyinput == 40)
					{
						this.comboboxSNIPER.SelectedIndex = this.comboboxSNIPER.SelectedIndex + 1;
					}
				}
				else
				{
					MessageBox.Show("Please Select a Valid Item", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				if (this.invtype == 2)
				{
					this.picPreview.Image = this.imgPrimaryWeapons.Images[this.itempicture];
				}
				else
				{
					this.picPreview.Image = this.imgPrimaryInv.Images[this.itempicture];
				}
			}
		}

		// Token: 0x060000EF RID: 239 RVA: 0x0000D198 File Offset: 0x0000B398
		private void comboboxMACHINEGUN_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.comboboxFOOD.Text = "Food:";
			this.comboboxMEDICAL.Text = "Medical:";
			this.comboboxTOOLS.Text = "Tools and Accessories:";
			this.comboboxPARTS.Text = "Parts:";
			this.comboboxPISTOL.Text = "Pistols:";
			this.comboboxRIFLE.Text = "Assault Rifles:";
			this.comboboxSUBMACHINE.Text = "Sub Machine Guns:";
			this.comboboxSHOTGUN.Text = "Shotguns:";
			this.comboboxSNIPER.Text = "Sniper Rifles:";
			this.comboboxMISC.Text = "Clothing and Misc:";
			this.btnAddInv.Enabled = true;
			this.btnAddBag.Enabled = true;
			object selectedItem = this.comboboxMACHINEGUN.SelectedItem;
			checked
			{
				if (Operators.ConditionalCompareObjectEqual(selectedItem, "M240", false))
				{
					this.invtype = 2;
					this.itemsize = 10;
					this.itempicture = 30;
					this.itemname = "M240";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "M249 SAW", false))
				{
					this.invtype = 2;
					this.itemsize = 10;
					this.itempicture = 31;
					this.itemname = "M249";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Mk 48 Mod 0", false))
				{
					this.invtype = 2;
					this.itemsize = 10;
					this.itempicture = 32;
					this.itemname = "Mk_48_DZ";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "100 Round M240 Magazine", false))
				{
					this.invtype = 3;
					this.itemsize = 2;
					this.itempicture = 51;
					this.itemname = "100Rnd_762x51_M240";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "200 Round M249 SAW Magazine", false))
				{
					this.invtype = 3;
					this.itemsize = 2;
					this.itempicture = 52;
					this.itemname = "200Rnd_556x45_M249";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "100 Round MK 48 Mod 0 Magazine", false))
				{
					this.invtype = 3;
					this.itemsize = 2;
					this.itempicture = 53;
					this.itemname = "100Rnd_762x51_M240";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "", false))
				{
					this.btnAddInv.Enabled = false;
					this.btnAddBag.Enabled = false;
					if (this.keyinput == 38)
					{
						this.comboboxMACHINEGUN.SelectedIndex = this.comboboxMACHINEGUN.SelectedIndex - 1;
					}
					if (this.keyinput == 40)
					{
						this.comboboxMACHINEGUN.SelectedIndex = this.comboboxMACHINEGUN.SelectedIndex + 1;
					}
				}
				else
				{
					MessageBox.Show("Please Select a Valid Item", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				if (this.invtype == 2)
				{
					this.picPreview.Image = this.imgPrimaryWeapons.Images[this.itempicture];
				}
				else
				{
					this.picPreview.Image = this.imgPrimaryInv.Images[this.itempicture];
				}
			}
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x0000D470 File Offset: 0x0000B670
		private void comboboxMISC_SelectedIndexChanged(object sender, EventArgs e)
		{
			this.comboboxFOOD.Text = "Food:";
			this.comboboxMEDICAL.Text = "Medical:";
			this.comboboxTOOLS.Text = "Tools and Accessories:";
			this.comboboxPARTS.Text = "Parts:";
			this.comboboxPISTOL.Text = "Pistols:";
			this.comboboxRIFLE.Text = "Assault Rifles:";
			this.comboboxSUBMACHINE.Text = "Sub Machine Guns:";
			this.comboboxSHOTGUN.Text = "Shotguns:";
			this.comboboxSNIPER.Text = "Sniper Rifles:";
			this.comboboxMACHINEGUN.Text = "Machine Guns:";
			this.btnAddInv.Enabled = true;
			this.btnAddBag.Enabled = true;
			object selectedItem = this.comboboxMISC.SelectedItem;
			if (Operators.ConditionalCompareObjectEqual(selectedItem, "Tent", false))
			{
				this.invtype = 3;
				this.itemsize = 3;
				this.itempicture = 54;
				this.itemname = "ItemTent";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Soldier Clothing", false))
			{
				this.invtype = 3;
				this.itemsize = 1;
				this.itempicture = 55;
				this.itemname = "Skin_Soldier1_DZ";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Survivor Clothing", false))
			{
				this.invtype = 3;
				this.itemsize = 1;
				this.itempicture = 56;
				this.itemname = "Skin_Survivor2_DZ";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Camo Clothing", false))
			{
				this.invtype = 3;
				this.itemsize = 1;
				this.itempicture = 57;
				this.itemname = "Skin_Camo1_DZ";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Ghillie Suit Clothing", false))
			{
				this.invtype = 3;
				this.itemsize = 1;
				this.itempicture = 58;
				this.itemname = "Skin_Sniper1_DZ";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Satchel Charge", false))
			{
				this.invtype = 3;
				this.itemsize = 2;
				this.itempicture = 59;
				this.itemname = "PipeBomb";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "M67 Frag Grenade", false))
			{
				this.invtype = 3;
				this.itemsize = 1;
				this.itempicture = 60;
				this.itemname = "HandGrenade_west";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Road Flare", false))
			{
				this.invtype = 3;
				this.itemsize = 1;
				this.itempicture = 61;
				this.itemname = "HandRoadFlare";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Chem Light Green", false))
			{
				this.invtype = 3;
				this.itemsize = 1;
				this.itempicture = 62;
				this.itemname = "HandChemGreen";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Chem Light Blue", false))
			{
				this.invtype = 3;
				this.itemsize = 1;
				this.itempicture = 63;
				this.itemname = "HandChemBlue";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Chem Light Red", false))
			{
				this.invtype = 3;
				this.itemsize = 1;
				this.itempicture = 64;
				this.itemname = "HandChemRed";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Sand Bag", false))
			{
				this.invtype = 3;
				this.itemsize = 1;
				this.itempicture = 65;
				this.itemname = "ItemSandbag";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Tank Trap", false))
			{
				this.invtype = 3;
				this.itemsize = 1;
				this.itempicture = 66;
				this.itemname = "ItemTankTrap";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Wire", false))
			{
				this.invtype = 3;
				this.itemsize = 1;
				this.itempicture = 67;
				this.itemname = "ItemWire";
			}
			else
			{
				MessageBox.Show("Please Select a Valid Item", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			this.picPreview.Image = this.imgPrimaryInv.Images[this.itempicture];
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x0000D844 File Offset: 0x0000BA44
		private void picOptics_MouseEnter(object sender, EventArgs e)
		{
			this.ItemDelBag = 1000;
			if (Operators.CompareString(((PictureBox)sender).Name, "picOpticsL", false) == 0)
			{
				this.ItemDel = 0;
			}
			else
			{
				this.ItemDel = 1;
			}
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x0000D87C File Offset: 0x0000BA7C
		private void picPrimary_MouseEnter(object sender, EventArgs e)
		{
			this.ItemDelBag = 1000;
			this.ItemDel = 2;
		}

		// Token: 0x060000F3 RID: 243 RVA: 0x0000D890 File Offset: 0x0000BA90
		private void picSecondary_MouseEnter(object sender, EventArgs e)
		{
			this.ItemDelBag = 1000;
			this.ItemDel = 15;
		}

		// Token: 0x060000F4 RID: 244 RVA: 0x0000D8A8 File Offset: 0x0000BAA8
		private void picBackpack_MouseEnter(object sender, EventArgs e)
		{
			this.ItemDelBag = 1000;
			this.ItemDel = 999;
		}

		// Token: 0x060000F5 RID: 245 RVA: 0x0000D8C0 File Offset: 0x0000BAC0
		private void picPrimaryInv_MouseEnter(object sender, EventArgs e)
		{
			this.ItemDelBag = 1000;
			this.ItemDel = checked(Convert.ToInt32(((PictureBox)sender).Name.Replace("picPrimaryInv", string.Empty)) + 2);
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x0000D8F4 File Offset: 0x0000BAF4
		private void picSecondaryInv_MouseEnter(object sender, EventArgs e)
		{
			this.ItemDelBag = 1000;
			this.ItemDel = checked(Convert.ToInt32(((PictureBox)sender).Name.Replace("picSecondaryInv", string.Empty)) + 15);
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x0000D92C File Offset: 0x0000BB2C
		private void picToolInv_MouseEnter(object sender, EventArgs e)
		{
			this.ItemDelBag = 1000;
			this.ItemDel = checked(Convert.ToInt32(((PictureBox)sender).Name.Replace("picToolInv", string.Empty)) + 23);
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x0000D964 File Offset: 0x0000BB64
		private void picBagInv_MouseEnter(object sender, EventArgs e)
		{
			this.ItemDel = 1000;
			this.ItemDelBag = checked(Convert.ToInt32(((PictureBox)sender).Name.Replace("picBagInv", string.Empty)) - 1);
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x0000D998 File Offset: 0x0000BB98
		private void picBagPrimary_MouseEnter(object sender, EventArgs e)
		{
			this.ItemDel = 1000;
			this.ItemDelBag = 24;
		}

		// Token: 0x060000FA RID: 250 RVA: 0x0000D9B0 File Offset: 0x0000BBB0
		private void picBagSecondary_MouseEnter(object sender, EventArgs e)
		{
			this.ItemDel = 1000;
			this.ItemDelBag = 26;
		}

		// Token: 0x060000FB RID: 251 RVA: 0x0000D9C8 File Offset: 0x0000BBC8
		private void frmMain_Load(object sender, EventArgs e)
		{
			this.opticsLeft = 2;
			this.primaryLeft = 10;
			this.primaryName = string.Empty;
			this.primarySize = 0;
			this.secondaryLeft = 10;
			this.secondaryName = string.Empty;
			this.secondarySize = 0;
			this.inventory1Left = 12;
			this.inventory2Left = 8;
			this.toolLeft = 12;
			this.baginventoryLeft = 0;
			this.bagsecondaryName = string.Empty;
			this.bagsecondarySize = 0;
			this.bagprimaryName = string.Empty;
			this.bagprimarySize = 0;
			this.rINV = new List<string>();
			this.lINV = new List<string>();
			this.lbagINV = new List<string>();
			this.rbagINV = new List<string>();
			this.lbagINV2 = new List<string>();
			this.rbagINV2 = new List<string>();
			this.lbagINVvalues = new List<int>();
			this.rbagINVvalues = new List<int>();
			this.invtype = 0;
			this.itemsize = 0;
			this.itempicture = 0;
			this.itemname = string.Empty;
			this.Counter = 0;
			this.ItemDel = 0;
			this.ItemDelBag = 0;
			this.ItemHolder = string.Empty;
			this.BagName = string.Empty;
			this.MaxBagSlots = 0;
			this.picPrimaryInv = new List<PictureBox>(new PictureBox[]
			{
				this.picPrimaryInv1, this.picPrimaryInv2, this.picPrimaryInv3, this.picPrimaryInv4, this.picPrimaryInv5, this.picPrimaryInv6, this.picPrimaryInv7, this.picPrimaryInv8, this.picPrimaryInv9, this.picPrimaryInv10,
				this.picPrimaryInv11, this.picPrimaryInv12
			});
			this.picSecondaryInv = new List<PictureBox>(new PictureBox[] { this.picSecondaryInv1, this.picSecondaryInv2, this.picSecondaryInv3, this.picSecondaryInv4, this.picSecondaryInv5, this.picSecondaryInv6, this.picSecondaryInv7, this.picSecondaryInv8 });
			this.picToolInv = new List<PictureBox>(new PictureBox[] { this.picToolInv1, this.picToolInv2, this.picToolInv3, this.picToolInv4, this.picToolInv5, this.picToolInv6, this.picToolInv7 });
			this.picBagInv = new List<PictureBox>(new PictureBox[]
			{
				this.picBagInv1, this.picBagInv2, this.picBagInv3, this.picBagInv4, this.picBagInv5, this.picBagInv6, this.picBagInv7, this.picBagInv8, this.picBagInv9, this.picBagInv10,
				this.picBagInv11, this.picBagInv12, this.picBagInv13, this.picBagInv14, this.picBagInv15, this.picBagInv16, this.picBagInv17, this.picBagInv18, this.picBagInv19, this.picBagInv20,
				this.picBagInv21, this.picBagInv22, this.picBagInv23, this.picBagInv24
			});
		}

		// Token: 0x060000FC RID: 252 RVA: 0x0000DD28 File Offset: 0x0000BF28
		private void btnGenerate_Click(object sender, EventArgs e)
		{
			string text = string.Empty;
			checked
			{
				if ((this.lINV.Count > 0) & (this.rINV.Count > 0))
				{
					if (this.lINV.Count > 1)
					{
						text = "[[\"" + this.lINV[0] + "\"";
						int num = 1;
						int num2 = this.lINV.Count - 1;
						for (int i = num; i <= num2; i++)
						{
							text = text + ",\"" + this.lINV[i] + "\"";
						}
						text = text + "],[\"" + this.rINV[0] + "\"";
					}
					else
					{
						text = string.Concat(new string[]
						{
							"[[\"",
							this.lINV[0],
							"\"],[\"",
							this.rINV[0],
							"\""
						});
					}
					if (this.rINV.Count > 1)
					{
						int num3 = 1;
						int num4 = this.rINV.Count - 1;
						for (int j = num3; j <= num4; j++)
						{
							text = text + ",\"" + this.rINV[j] + "\"";
						}
					}
					text += "]]";
				}
				else if (this.lINV.Count > 0)
				{
					text = "[[\"" + this.lINV[0] + "\"],[]]";
				}
				else if (this.rINV.Count > 0)
				{
					text = "[[],[\"" + this.rINV[0] + "\"";
					int num5 = 1;
					int num6 = this.rINV.Count - 1;
					for (int k = num5; k <= num6; k++)
					{
						text = text + ",\"" + this.rINV[k] + "\"";
					}
					text += "]]";
				}
				else
				{
					text = "[[],[]]";
				}
				this.textResult.Text = text;
			}
		}

		// Token: 0x060000FD RID: 253 RVA: 0x0000DF34 File Offset: 0x0000C134
		private void btnGenerateBag_Click(object sender, EventArgs e)
		{
			string text = string.Empty;
			checked
			{
				if (!((this.lbagINV.Count == 0) & (this.rbagINV.Count == 0)))
				{
					this.lbagINV.Sort();
					this.lbagINV2.Sort();
					this.rbagINV.Sort();
					this.rbagINV2.Sort();
					this.RemoveDupes();
					if ((this.lbagINV.Count == 1) & (this.rbagINV.Count == 0))
					{
						text = string.Concat(new string[]
						{
							"[\"",
							this.BagName,
							"\",[[\"",
							this.lbagINV[0],
							"\"],[",
							Conversions.ToString(this.lbagINVvalues[0]),
							"]],[[],[]]]"
						});
					}
					else if ((this.lbagINV.Count > 1) & (this.rbagINV.Count == 0))
					{
						text = string.Concat(new string[]
						{
							"[\"",
							this.BagName,
							"\",[[\"",
							this.lbagINV[0],
							"\""
						});
						int num = 1;
						int num2 = this.lbagINV.Count - 1;
						for (int i = num; i <= num2; i++)
						{
							text = text + ",\"" + this.lbagINV[i] + "\"";
						}
						text = text + "],[" + Conversions.ToString(this.lbagINVvalues[0]);
						int num3 = 1;
						int num4 = this.lbagINVvalues.Count - 1;
						for (int j = num3; j <= num4; j++)
						{
							text = text + "," + Conversions.ToString(this.lbagINVvalues[j]);
						}
						text += "]],[[],[]]]";
					}
					else if ((this.lbagINV.Count == 0) & (this.rbagINV.Count == 1))
					{
						text = string.Concat(new string[]
						{
							"[\"",
							this.BagName,
							"\",[[],[]],[[\"",
							this.rbagINV[0],
							"\"],[",
							Conversions.ToString(this.rbagINVvalues[0]),
							"]]]"
						});
					}
					else if ((this.lbagINV.Count == 0) & (this.rbagINV.Count > 1))
					{
						text = string.Concat(new string[]
						{
							"[\"",
							this.BagName,
							"\",[[],[]],[[\"",
							this.rbagINV[0],
							"\""
						});
						int num5 = 1;
						int num6 = this.rbagINV.Count - 1;
						for (int k = num5; k <= num6; k++)
						{
							text = text + ",\"" + this.rbagINV[k] + "\"";
						}
						text = text + "],[" + Conversions.ToString(this.rbagINVvalues[0]);
						int num7 = 1;
						int num8 = this.rbagINVvalues.Count - 1;
						for (int l = num7; l <= num8; l++)
						{
							text = text + "," + Conversions.ToString(this.rbagINVvalues[l]);
						}
						text += "]]]";
					}
					else if ((this.lbagINV.Count == 1) & (this.rbagINV.Count == 1))
					{
						text = string.Concat(new string[]
						{
							"[\"",
							this.BagName,
							"\",[[\"",
							this.lbagINV[0],
							"\"],[",
							Conversions.ToString(this.lbagINVvalues[0]),
							"]],[[\"",
							this.rbagINV[0],
							"\"],[",
							Conversions.ToString(this.rbagINVvalues[0]),
							"]]]"
						});
					}
					else if ((this.lbagINV.Count > 1) & (this.rbagINV.Count > 1))
					{
						text = string.Concat(new string[]
						{
							"[\"",
							this.BagName,
							"\",[[\"",
							this.lbagINV[0],
							"\""
						});
						int num9 = 1;
						int num10 = this.lbagINV.Count - 1;
						for (int m = num9; m <= num10; m++)
						{
							text = text + ",\"" + this.lbagINV[m] + "\"";
						}
						text = text + "],[" + Conversions.ToString(this.lbagINVvalues[0]);
						int num11 = 1;
						int num12 = this.lbagINVvalues.Count - 1;
						for (int n = num11; n <= num12; n++)
						{
							text = text + "," + Conversions.ToString(this.lbagINVvalues[n]);
						}
						text = text + "]],[[\"" + this.rbagINV[0] + "\"";
						int num13 = 1;
						int num14 = this.rbagINV.Count - 1;
						for (int num15 = num13; num15 <= num14; num15++)
						{
							text = text + ",\"" + this.rbagINV[num15] + "\"";
						}
						text = text + "],[" + Conversions.ToString(this.rbagINVvalues[0]);
						int num16 = 1;
						int num17 = this.rbagINVvalues.Count - 1;
						for (int num18 = num16; num18 <= num17; num18++)
						{
							text = text + "," + Conversions.ToString(this.rbagINVvalues[num18]);
						}
						text += "]]]";
					}
				}
				else if (string.IsNullOrEmpty(this.BagName))
				{
					text = string.Empty;
				}
				else
				{
					text = "[\"" + this.BagName + "\",[[],[]],[[],[]]]";
				}
				this.textResult.Text = text;
			}
		}

		// Token: 0x060000FE RID: 254 RVA: 0x0000E57C File Offset: 0x0000C77C
		private void btnAddInventory_Click(object sender, EventArgs e)
		{
			checked
			{
				switch (this.invtype)
				{
				case 1:
					if ((this.invtype == 1) & (this.opticsLeft - this.itemsize >= 0))
					{
						this.lINV.Add(this.itemname);
						this.opticsLeft -= this.itemsize;
						if (Operators.CompareString(this.itemname, "NVGoggles", false) == 0)
						{
							this.opticsName[1] = this.itemname;
							this.picOptics2.Image = this.imgTools.Images[this.itempicture];
						}
						else
						{
							this.opticsName[0] = this.itemname;
							this.picOptics1.Image = this.imgTools.Images[this.itempicture];
						}
					}
					break;
				case 2:
					if (this.primaryLeft - this.itemsize >= 0)
					{
						this.lINV.Add(this.itemname);
						this.primaryName = this.itemname;
						this.primarySize = this.itemsize;
						this.primaryLeft -= this.itemsize;
						this.picPrimary.Image = this.imgPrimaryWeapons.Images[this.itempicture];
					}
					break;
				case 3:
					if ((this.inventory1Left - this.itemsize >= 0) & (this.itemsize == 1))
					{
						int num = 0;
						while (this.MainInvGridLoc[num] != 0)
						{
							num++;
							if (num > 11)
							{
								return;
							}
						}
						this.rINV.Add(this.itemname);
						this.MainInvGridLoc[num] = 1;
						this.inventory1Name[num] = this.itemname;
						this.inventory1Size[num] = this.itemsize;
						this.inventory1Left -= this.itemsize;
						this.picPrimaryInv[num].Image = this.imgPrimaryInv.Images[this.itempicture];
					}
					else if ((this.inventory1Left - this.itemsize >= 0) & (this.itemsize > 1))
					{
						int num2 = 0;
						while (this.MainInvGridLoc[num2] != 0)
						{
							num2++;
							if (num2 > 11)
							{
								return;
							}
						}
						this.rINV.Add(this.itemname);
						this.MainInvGridLoc[num2] = 1;
						this.inventory1Name[num2] = this.itemname;
						this.inventory1Size[num2] = this.itemsize;
						this.inventory1Left -= this.itemsize;
						this.picPrimaryInv[num2].Image = this.imgPrimaryInv.Images[this.itempicture];
						this.Counter = this.itemsize - 1;
						int num3 = 11;
						while (this.Counter > 0)
						{
							if (this.MainInvGridLoc[num3] == 0)
							{
								this.picPrimaryInv[num3].Visible = false;
								this.MainInvGridLoc[num3] = 3;
								this.Counter--;
							}
							num3 += -1;
							if (num3 < 0)
							{
								return;
							}
						}
						return;
					}
					break;
				case 4:
					if (this.secondaryLeft - this.itemsize >= 0)
					{
						this.lINV.Add(this.itemname);
						this.secondaryName = this.itemname;
						this.secondarySize = this.itemsize;
						this.secondaryLeft -= this.itemsize;
						this.picSecondary.Image = this.imgSecondaryWeapons.Images[this.itempicture];
					}
					break;
				case 5:
					if (this.inventory2Left - this.itemsize >= 0)
					{
						int num4 = 0;
						while (this.SecInvGridLoc[num4] != 0)
						{
							num4++;
							if (num4 > 7)
							{
								return;
							}
						}
						this.rINV.Add(this.itemname);
						this.SecInvGridLoc[num4] = 1;
						this.inventory2Name[num4] = this.itemname;
						this.inventory2Size[num4] = this.itemsize;
						this.inventory2Left -= this.itemsize;
						this.picSecondaryInv[num4].Image = this.imgSecondaryInv.Images[this.itempicture];
						return;
					}
					break;
				case 6:
					if (this.toolLeft - this.itemsize >= 0)
					{
						int num5 = 0;
						while (this.ToolGridLoc[num5] != 0)
						{
							num5++;
							if (num5 > 7)
							{
								return;
							}
						}
						this.lINV.Add(this.itemname);
						this.ToolGridLoc[num5] = 1;
						this.toolName[num5] = this.itemname;
						this.toolSize[num5] = this.itemsize;
						this.toolLeft -= this.itemsize;
						this.picToolInv[num5].Image = this.imgTools.Images[this.itempicture];
						return;
					}
					break;
				}
			}
		}

		// Token: 0x060000FF RID: 255 RVA: 0x0000EA64 File Offset: 0x0000CC64
		private void btnAddBackpack_Click(object sender, EventArgs e)
		{
			checked
			{
				switch (this.invtype)
				{
				case 1:
					if (this.baginventoryLeft - this.itemsize >= 0)
					{
						int num = 0;
						int num2 = this.MaxBagSlots - 1;
						for (int i = num; i <= num2; i++)
						{
							if (this.BagInvGridLoc[i] == 0)
							{
								this.lbagINV.Add(this.itemname);
								this.lbagINV2.Add(this.itemname);
								this.BagInvGridLoc[i] = 1;
								this.baginventoryName[i] = this.itemname;
								this.baginventorySize[i] = this.itemsize;
								this.itemdelside[i] = 0;
								this.baginventoryLeft -= this.itemsize;
								this.picBagInv[i].Image = this.imgTools.Images[this.itempicture];
								return;
							}
						}
					}
					break;
				case 2:
					if (this.baginventoryLeft - this.itemsize >= 0)
					{
						int num3 = 0;
						int num4 = this.MaxBagSlots - 1;
						int num5 = num3;
						if (num5 <= num4)
						{
							this.lbagINV.Add(this.itemname);
							this.lbagINV2.Add(this.itemname);
							this.itemdelside[num5 + 24] = 2;
							this.baginventoryLeft -= this.itemsize;
							this.bagprimaryName = this.itemname;
							this.bagprimarySize = this.itemsize;
							this.picBagPrimary.Visible = true;
							this.picBagPrimary.Image = this.imgPrimaryWeapons.Images[this.itempicture];
							this.Counter = this.itemsize;
							for (int j = this.MaxBagSlots - 1; j >= 0; j += -1)
							{
								if (this.Counter == 0)
								{
									return;
								}
								if (this.BagInvGridLoc[j] == 0)
								{
									this.BagInvGridLoc[j] = 3;
									this.picBagInv[j].Visible = false;
									this.Counter--;
								}
							}
							return;
						}
					}
					break;
				case 3:
					if ((this.baginventoryLeft - this.itemsize >= 0) & (this.itemsize == 1))
					{
						int num6 = 0;
						int num7 = this.MaxBagSlots - 1;
						for (int k = num6; k <= num7; k++)
						{
							if (this.BagInvGridLoc[k] == 0)
							{
								this.rbagINV.Add(this.itemname);
								this.rbagINV2.Add(this.itemname);
								this.BagInvGridLoc[k] = 1;
								this.baginventoryName[k] = this.itemname;
								this.baginventorySize[k] = this.itemsize;
								this.itemdelside[k] = 1;
								this.baginventoryLeft -= this.itemsize;
								this.picBagInv[k].Image = this.imgPrimaryInv.Images[this.itempicture];
								return;
							}
						}
					}
					else if ((this.baginventoryLeft - this.itemsize >= 0) & (this.itemsize > 1))
					{
						int num8 = 0;
						int num9 = this.MaxBagSlots - 1;
						for (int l = num8; l <= num9; l++)
						{
							if (this.BagInvGridLoc[l] == 0)
							{
								this.rbagINV.Add(this.itemname);
								this.rbagINV2.Add(this.itemname);
								this.BagInvGridLoc[l] = 1;
								this.baginventoryName[l] = this.itemname;
								this.baginventorySize[l] = this.itemsize;
								this.baginventoryLeft -= this.itemsize;
								this.itemdelside[l] = 1;
								this.picBagInv[l].Image = this.imgPrimaryInv.Images[this.itempicture];
								this.Counter = this.itemsize - 1;
								for (int m = this.MaxBagSlots - 1; m >= 0; m += -1)
								{
									if (this.Counter == 0)
									{
										return;
									}
									if (this.BagInvGridLoc[m] == 0)
									{
										this.BagInvGridLoc[m] = 3;
										this.picBagInv[m].Visible = false;
										this.Counter--;
									}
								}
								return;
							}
						}
					}
					break;
				case 4:
					if (this.baginventoryLeft - this.itemsize >= 0)
					{
						int num10 = 0;
						int num11 = this.MaxBagSlots - 1;
						int num12 = num10;
						if (num12 <= num11)
						{
							this.lbagINV.Add(this.itemname);
							this.lbagINV2.Add(this.itemname);
							this.bagsecondaryName = this.itemname;
							this.bagsecondarySize = this.itemsize;
							this.baginventoryLeft -= this.itemsize;
							this.picBagSecondary.Visible = true;
							this.picBagSecondary.Image = this.imgSecondaryWeapons.Images[this.itempicture];
							this.itemdelside[num12 + 26] = 3;
							this.Counter = this.itemsize;
							for (int n = this.MaxBagSlots - 1; n >= 0; n += -1)
							{
								if (this.Counter == 0)
								{
									return;
								}
								if (this.BagInvGridLoc[n] == 0)
								{
									this.BagInvGridLoc[n] = 3;
									this.picBagInv[n].Visible = false;
									this.Counter--;
								}
							}
							return;
						}
					}
					break;
				case 5:
					if (this.baginventoryLeft - this.itemsize >= 0)
					{
						int num13 = 0;
						int num14 = this.MaxBagSlots - 1;
						for (int num15 = num13; num15 <= num14; num15++)
						{
							if (this.BagInvGridLoc[num15] == 0)
							{
								this.rbagINV.Add(this.itemname);
								this.rbagINV2.Add(this.itemname);
								this.BagInvGridLoc[num15] = 1;
								this.baginventoryName[num15] = this.itemname;
								this.baginventorySize[num15] = this.itemsize;
								this.baginventoryLeft -= this.itemsize;
								this.itemdelside[num15] = 1;
								this.picBagInv[num15].Image = this.imgSecondaryInv.Images[this.itempicture];
								return;
							}
						}
					}
					break;
				case 6:
					if (this.baginventoryLeft - this.itemsize >= 0)
					{
						int num16 = 0;
						int num17 = this.MaxBagSlots - 1;
						for (int num18 = num16; num18 <= num17; num18++)
						{
							if (this.BagInvGridLoc[num18] == 0)
							{
								this.lbagINV.Add(this.itemname);
								this.lbagINV2.Add(this.itemname);
								this.BagInvGridLoc[num18] = 1;
								this.baginventoryName[num18] = this.itemname;
								this.baginventorySize[num18] = this.itemsize;
								this.itemdelside[num18] = 0;
								this.baginventoryLeft--;
								this.picBagInv[num18].Image = this.imgTools.Images[this.itempicture];
								return;
							}
						}
					}
					break;
				}
			}
		}

		// Token: 0x06000100 RID: 256 RVA: 0x0000F170 File Offset: 0x0000D370
		private void radioBackpack_CheckedChanged(object sender, EventArgs e)
		{
			this.ClearBackpack();
			checked
			{
				if (this.radio2.Checked)
				{
					this.BagName = "DZ_Patrol_Pack_EP1";
					this.MaxBagSlots = 8;
					this.baginventoryLeft = 8;
					this.picBackpack.Image = this.imgBags.Images[1];
					int num = 0;
					int num2 = this.MaxBagSlots - 1;
					for (int i = num; i <= num2; i++)
					{
						this.picBagInv[i].Visible = true;
					}
				}
				else if (this.radio3.Checked)
				{
					this.BagName = "DZ_Assault_Pack_EP1";
					this.MaxBagSlots = 12;
					this.baginventoryLeft = 12;
					this.picBackpack.Image = this.imgBags.Images[2];
					int num3 = 0;
					int num4 = this.MaxBagSlots - 1;
					for (int j = num3; j <= num4; j++)
					{
						this.picBagInv[j].Visible = true;
					}
				}
				else if (this.radio4.Checked)
				{
					this.BagName = "DZ_CivilBackpack_EP1";
					this.MaxBagSlots = 16;
					this.baginventoryLeft = 16;
					this.picBackpack.Image = this.imgBags.Images[3];
					int num5 = 0;
					int num6 = this.MaxBagSlots - 1;
					for (int k = num5; k <= num6; k++)
					{
						this.picBagInv[k].Visible = true;
					}
				}
				else if (this.radio5.Checked)
				{
					this.BagName = "DZ_ALICE_Pack_EP1";
					this.MaxBagSlots = 20;
					this.baginventoryLeft = 20;
					this.picBackpack.Image = this.imgBags.Images[4];
					int num7 = 0;
					int num8 = this.MaxBagSlots - 1;
					for (int l = num7; l <= num8; l++)
					{
						this.picBagInv[l].Visible = true;
					}
				}
				else if (this.radio6.Checked)
				{
					this.BagName = "DZ_Backpack_EP1";
					this.MaxBagSlots = 24;
					this.baginventoryLeft = 24;
					this.picBackpack.Image = this.imgBags.Images[5];
					int num9 = 0;
					int num10 = this.MaxBagSlots - 1;
					for (int m = num9; m <= num10; m++)
					{
						this.picBagInv[m].Visible = true;
					}
				}
			}
		}

		// Token: 0x06000101 RID: 257 RVA: 0x0000F3B8 File Offset: 0x0000D5B8
		private void cmsRemoveItem_Click(object sender, EventArgs e)
		{
			checked
			{
				if (!((this.ItemDel == 1000) | (this.ItemDel == 999)))
				{
					if (this.ItemDel == 0)
					{
						this.lINV.Remove(this.opticsName[this.ItemDel]);
						this.opticsLeft++;
						this.picOptics1.Image = Resources.binocular;
					}
					else if (this.ItemDel == 1)
					{
						this.lINV.Remove(this.opticsName[this.ItemDel]);
						this.opticsLeft++;
						this.picOptics2.Image = Resources.binocular;
					}
					else if (this.ItemDel == 2)
					{
						this.lINV.Remove(this.primaryName);
						this.primaryLeft += this.primarySize;
						this.picPrimary.Image = Resources.rifle;
					}
					else if (this.ItemDel == 15)
					{
						this.lINV.Remove(this.secondaryName);
						this.secondaryLeft += this.secondarySize;
						this.picSecondary.Image = Resources.pistol;
					}
					else if ((this.ItemDel < 15) & (this.ItemDel > 2))
					{
						this.rINV.Remove(this.inventory1Name[this.ItemDel - 3]);
						this.MainInvGridLoc[this.ItemDel - 3] = 0;
						this.inventory1Left += this.inventory1Size[this.ItemDel - 3];
						this.picPrimaryInv[this.ItemDel - 3].ContextMenuStrip = null;
						this.picPrimaryInv[this.ItemDel - 3].Image = Resources.heavyammo;
						if (this.inventory1Size[this.ItemDel - 3] > 1)
						{
							this.Counter = this.inventory1Size[this.ItemDel - 3];
							int num = 0;
							while (this.Counter != 0)
							{
								if (this.MainInvGridLoc[num] == 3)
								{
									this.picPrimaryInv[num].Visible = true;
									this.MainInvGridLoc[num] = 0;
									this.Counter--;
								}
								num++;
								if (num > 11)
								{
									break;
								}
							}
						}
					}
					else if ((this.ItemDel < 24) & (this.ItemDel > 15))
					{
						this.rINV.Remove(this.inventory2Name[this.ItemDel - 16]);
						this.inventory2Left += this.inventory2Size[this.ItemDel - 16];
						this.SecInvGridLoc[this.ItemDel - 16] = 0;
						this.picSecondaryInv[this.ItemDel - 16].Image = Resources.smallammo;
					}
					else if (this.ItemDel > 23)
					{
						this.lINV.Remove(this.toolName[this.ItemDel - 24]);
						this.toolLeft += this.toolSize[this.ItemDel - 24];
						this.ToolGridLoc[this.ItemDel - 24] = 0;
						this.picToolInv[this.ItemDel - 24].Image = null;
					}
				}
				else if (this.ItemDelBag != 1000)
				{
					if (this.itemdelside[this.ItemDelBag] == 0)
					{
						this.lbagINV.Remove(this.baginventoryName[this.ItemDelBag]);
						this.lbagINV2.Remove(this.baginventoryName[this.ItemDelBag]);
						this.BagInvGridLoc[this.ItemDelBag] = 0;
						this.baginventoryLeft += this.baginventorySize[this.ItemDelBag];
						this.picBagInv[this.ItemDelBag].Image = null;
					}
					else if (this.itemdelside[this.ItemDelBag] == 1)
					{
						this.rbagINV.Remove(this.baginventoryName[this.ItemDelBag]);
						this.rbagINV2.Remove(this.baginventoryName[this.ItemDelBag]);
						this.BagInvGridLoc[this.ItemDelBag] = 0;
						this.baginventoryLeft += this.baginventorySize[this.ItemDelBag];
						this.picBagInv[this.ItemDelBag].ContextMenuStrip = null;
						this.picBagInv[this.ItemDelBag].Image = null;
						this.Counter = this.baginventorySize[this.ItemDelBag];
						if (this.Counter > 1)
						{
							int num2 = 0;
							int num3 = this.MaxBagSlots - 1;
							int num4 = num2;
							while (num4 <= num3 && this.Counter != 0)
							{
								if (this.BagInvGridLoc[num4] == 3)
								{
									this.picBagInv[num4].Visible = true;
									this.BagInvGridLoc[num4] = 0;
									this.Counter--;
								}
								num4++;
							}
						}
					}
					else if (this.itemdelside[this.ItemDelBag] == 2)
					{
						this.lbagINV.Remove(this.bagprimaryName);
						this.lbagINV2.Remove(this.bagprimaryName);
						this.baginventoryLeft += this.bagprimarySize;
						this.picBagPrimary.Image = null;
						this.picBagPrimary.Visible = false;
						this.Counter = this.bagprimarySize;
						int num5 = 0;
						int num6 = this.MaxBagSlots - 1;
						for (int i = num5; i <= num6; i++)
						{
							if (this.Counter == 0)
							{
								break;
							}
							if (this.BagInvGridLoc[i] == 3)
							{
								this.BagInvGridLoc[i] = 0;
								this.picBagInv[i].Visible = true;
								this.Counter--;
							}
						}
					}
					else if (this.itemdelside[this.ItemDelBag] == 3)
					{
						this.lbagINV.Remove(this.bagsecondaryName);
						this.lbagINV2.Remove(this.bagsecondaryName);
						this.baginventoryLeft += this.bagsecondarySize;
						this.picBagSecondary.Image = null;
						this.picBagSecondary.Visible = false;
						this.Counter = this.bagsecondarySize;
						int num7 = 0;
						int num8 = this.MaxBagSlots - 1;
						int num9 = num7;
						while (num9 <= num8 && this.Counter != 0)
						{
							if (this.BagInvGridLoc[num9] == 3)
							{
								this.BagInvGridLoc[num9] = 0;
								this.picBagInv[num9].Visible = true;
								this.Counter--;
							}
							num9++;
						}
					}
				}
				else if (this.ItemDel == 999)
				{
					this.ClearBackpack();
					this.radio1.Checked = true;
					this.radio2.Checked = false;
					this.radio3.Checked = false;
					this.radio4.Checked = false;
					this.radio5.Checked = false;
					this.radio6.Checked = false;
				}
			}
		}

		// Token: 0x06000102 RID: 258 RVA: 0x0000FA90 File Offset: 0x0000DC90
		private void ClearBackpack()
		{
			checked
			{
				if ((this.picBagInv != null) & (this.picBackpack != null) & (this.picBagPrimary != null) & (this.picBagSecondary != null))
				{
					int num = 0;
					do
					{
						this.picBagInv[num].Visible = false;
						this.picBagInv[num].Image = null;
						this.BagInvGridLoc[num] = 0;
						num++;
					}
					while (num <= 23);
					this.picBagPrimary.Image = null;
					this.picBagSecondary.Image = null;
					this.picBagPrimary.Visible = false;
					this.picBagSecondary.Visible = false;
					this.lbagINV.Clear();
					this.lbagINV2.Clear();
					this.lbagINVvalues.Clear();
					this.rbagINV.Clear();
					this.rbagINV2.Clear();
					this.rbagINVvalues.Clear();
					this.MaxBagSlots = 0;
					this.baginventoryLeft = 0;
					this.BagName = string.Empty;
					this.picBackpack.Image = Resources.second;
				}
			}
		}

		// Token: 0x06000103 RID: 259 RVA: 0x0000FBA8 File Offset: 0x0000DDA8
		private void RemoveDupes()
		{
			int num = 0;
			checked
			{
				int num2 = this.lbagINV.Count - 1;
				for (int i = num; i <= num2; i++)
				{
					if (this.lbagINV.Count == i)
					{
						IL_145:
						while (this.lbagINV2.Count > 0)
						{
							this.ItemHolder = this.lbagINV2[0];
							int num3 = 0;
							int num4 = this.lbagINV2.Count - 1;
							for (int j = num3; j <= num4; j++)
							{
								if (Operators.CompareString(this.lbagINV2[j], this.ItemHolder, false) == 0)
								{
									this.Counter++;
								}
							}
							this.lbagINVvalues.Add(this.Counter);
							int num5 = 0;
							int num6 = this.Counter - 1;
							for (int k = num5; k <= num6; k++)
							{
								this.lbagINV2.RemoveAt(this.Counter - 1);
								this.Counter--;
							}
							this.Counter = 0;
						}
						int num7 = 0;
						int num8 = this.rbagINV.Count - 1;
						int num9 = num7;
						while (num9 <= num8 && this.rbagINV.Count != num9)
						{
							this.ItemHolder = this.rbagINV[num9];
							int num10 = num9 + 1;
							int num11 = this.rbagINV.Count - 1;
							int num12 = num10;
							while (num12 <= num11 && this.rbagINV.Count != num12)
							{
								if (Operators.CompareString(this.rbagINV[num12], this.ItemHolder, false) == 0)
								{
									this.rbagINV.RemoveAt(num12);
									num12--;
								}
								num12++;
							}
							num9++;
						}
						this.Counter = 0;
						while (this.rbagINV2.Count > 0)
						{
							this.ItemHolder = this.rbagINV2[0];
							int num13 = 0;
							int num14 = this.rbagINV2.Count - 1;
							for (int l = num13; l <= num14; l++)
							{
								if (Operators.CompareString(this.rbagINV2[l], this.ItemHolder, false) == 0)
								{
									this.Counter++;
								}
							}
							this.rbagINVvalues.Add(this.Counter);
							int num15 = 0;
							int num16 = this.Counter - 1;
							for (int m = num15; m <= num16; m++)
							{
								this.rbagINV2.RemoveAt(this.Counter - 1);
								this.Counter--;
							}
							this.Counter = 0;
						}
						return;
					}
					this.ItemHolder = this.lbagINV[i];
					int num17 = i + 1;
					int num18 = this.lbagINV.Count - 1;
					int num19 = num17;
					while (num19 <= num18 && this.lbagINV.Count != num19)
					{
						if (Operators.CompareString(this.lbagINV[num19], this.ItemHolder, false) == 0)
						{
							this.lbagINV.RemoveAt(num19);
							num19--;
						}
						num19++;
					}
				}
				goto IL_145;
			}
		}

		// Token: 0x0400000A RID: 10
		[AccessedThroughProperty("groupResult")]
		private GroupBox _groupResult;

		// Token: 0x0400000B RID: 11
		[AccessedThroughProperty("textResult")]
		private TextBox _textResult;

		// Token: 0x0400000C RID: 12
		[AccessedThroughProperty("groupPreview")]
		private GroupBox _groupPreview;

		// Token: 0x0400000D RID: 13
		[AccessedThroughProperty("picPreview")]
		private PictureBox _picPreview;

		// Token: 0x0400000E RID: 14
		[AccessedThroughProperty("comboboxMEDICAL")]
		private ComboBox _comboboxMEDICAL;

		// Token: 0x0400000F RID: 15
		[AccessedThroughProperty("comboboxTOOLS")]
		private ComboBox _comboboxTOOLS;

		// Token: 0x04000010 RID: 16
		[AccessedThroughProperty("comboboxPARTS")]
		private ComboBox _comboboxPARTS;

		// Token: 0x04000011 RID: 17
		[AccessedThroughProperty("comboboxRIFLE")]
		private ComboBox _comboboxRIFLE;

		// Token: 0x04000012 RID: 18
		[AccessedThroughProperty("comboboxSUBMACHINE")]
		private ComboBox _comboboxSUBMACHINE;

		// Token: 0x04000013 RID: 19
		[AccessedThroughProperty("comboboxSHOTGUN")]
		private ComboBox _comboboxSHOTGUN;

		// Token: 0x04000014 RID: 20
		[AccessedThroughProperty("comboboxSNIPER")]
		private ComboBox _comboboxSNIPER;

		// Token: 0x04000015 RID: 21
		[AccessedThroughProperty("comboboxMACHINEGUN")]
		private ComboBox _comboboxMACHINEGUN;

		// Token: 0x04000016 RID: 22
		[AccessedThroughProperty("comboboxMISC")]
		private ComboBox _comboboxMISC;

		// Token: 0x04000017 RID: 23
		[AccessedThroughProperty("btnAddInv")]
		private Button _btnAddInv;

		// Token: 0x04000018 RID: 24
		[AccessedThroughProperty("btnAddBag")]
		private Button _btnAddBag;

		// Token: 0x04000019 RID: 25
		[AccessedThroughProperty("comboboxFOOD")]
		private ComboBox _comboboxFOOD;

		// Token: 0x0400001A RID: 26
		[AccessedThroughProperty("comboboxPISTOL")]
		private ComboBox _comboboxPISTOL;

		// Token: 0x0400001B RID: 27
		[AccessedThroughProperty("btnGenerateInv")]
		private Button _btnGenerateInv;

		// Token: 0x0400001C RID: 28
		[AccessedThroughProperty("btnGenerateBag")]
		private Button _btnGenerateBag;

		// Token: 0x0400001D RID: 29
		[AccessedThroughProperty("groupBackpack")]
		private GroupBox _groupBackpack;

		// Token: 0x0400001E RID: 30
		[AccessedThroughProperty("radio6")]
		private RadioButton _radio6;

		// Token: 0x0400001F RID: 31
		[AccessedThroughProperty("radio4")]
		private RadioButton _radio4;

		// Token: 0x04000020 RID: 32
		[AccessedThroughProperty("radio3")]
		private RadioButton _radio3;

		// Token: 0x04000021 RID: 33
		[AccessedThroughProperty("radio2")]
		private RadioButton _radio2;

		// Token: 0x04000022 RID: 34
		[AccessedThroughProperty("radio1")]
		private RadioButton _radio1;

		// Token: 0x04000023 RID: 35
		[AccessedThroughProperty("radio5")]
		private RadioButton _radio5;

		// Token: 0x04000024 RID: 36
		[AccessedThroughProperty("imgBags")]
		private ImageList _imgBags;

		// Token: 0x04000025 RID: 37
		[AccessedThroughProperty("cmsRemove")]
		private ContextMenuStrip _cmsRemove;

		// Token: 0x04000026 RID: 38
		[AccessedThroughProperty("cmsRemoveItem")]
		private ToolStripMenuItem _cmsRemoveItem;

		// Token: 0x04000027 RID: 39
		[AccessedThroughProperty("imgPrimaryWeapons")]
		private ImageList _imgPrimaryWeapons;

		// Token: 0x04000028 RID: 40
		[AccessedThroughProperty("imgSecondaryWeapons")]
		private ImageList _imgSecondaryWeapons;

		// Token: 0x04000029 RID: 41
		[AccessedThroughProperty("imgPrimaryInv")]
		private ImageList _imgPrimaryInv;

		// Token: 0x0400002A RID: 42
		[AccessedThroughProperty("imgSecondaryInv")]
		private ImageList _imgSecondaryInv;

		// Token: 0x0400002B RID: 43
		[AccessedThroughProperty("imgTools")]
		private ImageList _imgTools;

		// Token: 0x0400002C RID: 44
		[AccessedThroughProperty("panel1")]
		private Panel _panel1;

		// Token: 0x0400002D RID: 45
		[AccessedThroughProperty("picOptics2")]
		private PictureBox _picOptics2;

		// Token: 0x0400002E RID: 46
		[AccessedThroughProperty("picOptics1")]
		private PictureBox _picOptics1;

		// Token: 0x0400002F RID: 47
		[AccessedThroughProperty("picPrimary")]
		private PictureBox _picPrimary;

		// Token: 0x04000030 RID: 48
		[AccessedThroughProperty("picBackpack")]
		private PictureBox _picBackpack;

		// Token: 0x04000031 RID: 49
		[AccessedThroughProperty("picSecondary")]
		private PictureBox _picSecondary;

		// Token: 0x04000032 RID: 50
		[AccessedThroughProperty("picPrimaryInv1")]
		private PictureBox _picPrimaryInv1;

		// Token: 0x04000033 RID: 51
		[AccessedThroughProperty("picPrimaryInv2")]
		private PictureBox _picPrimaryInv2;

		// Token: 0x04000034 RID: 52
		[AccessedThroughProperty("picPrimaryInv4")]
		private PictureBox _picPrimaryInv4;

		// Token: 0x04000035 RID: 53
		[AccessedThroughProperty("picPrimaryInv3")]
		private PictureBox _picPrimaryInv3;

		// Token: 0x04000036 RID: 54
		[AccessedThroughProperty("picPrimaryInv7")]
		private PictureBox _picPrimaryInv7;

		// Token: 0x04000037 RID: 55
		[AccessedThroughProperty("picPrimaryInv8")]
		private PictureBox _picPrimaryInv8;

		// Token: 0x04000038 RID: 56
		[AccessedThroughProperty("picPrimaryInv6")]
		private PictureBox _picPrimaryInv6;

		// Token: 0x04000039 RID: 57
		[AccessedThroughProperty("picPrimaryInv5")]
		private PictureBox _picPrimaryInv5;

		// Token: 0x0400003A RID: 58
		[AccessedThroughProperty("picPrimaryInv11")]
		private PictureBox _picPrimaryInv11;

		// Token: 0x0400003B RID: 59
		[AccessedThroughProperty("picPrimaryInv12")]
		private PictureBox _picPrimaryInv12;

		// Token: 0x0400003C RID: 60
		[AccessedThroughProperty("picPrimaryInv10")]
		private PictureBox _picPrimaryInv10;

		// Token: 0x0400003D RID: 61
		[AccessedThroughProperty("picPrimaryInv9")]
		private PictureBox _picPrimaryInv9;

		// Token: 0x0400003E RID: 62
		[AccessedThroughProperty("picSecondaryInv1")]
		private PictureBox _picSecondaryInv1;

		// Token: 0x0400003F RID: 63
		[AccessedThroughProperty("picSecondaryInv2")]
		private PictureBox _picSecondaryInv2;

		// Token: 0x04000040 RID: 64
		[AccessedThroughProperty("picSecondaryInv3")]
		private PictureBox _picSecondaryInv3;

		// Token: 0x04000041 RID: 65
		[AccessedThroughProperty("picSecondaryInv4")]
		private PictureBox _picSecondaryInv4;

		// Token: 0x04000042 RID: 66
		[AccessedThroughProperty("picSecondaryInv8")]
		private PictureBox _picSecondaryInv8;

		// Token: 0x04000043 RID: 67
		[AccessedThroughProperty("picSecondaryInv7")]
		private PictureBox _picSecondaryInv7;

		// Token: 0x04000044 RID: 68
		[AccessedThroughProperty("picSecondaryInv6")]
		private PictureBox _picSecondaryInv6;

		// Token: 0x04000045 RID: 69
		[AccessedThroughProperty("picSecondaryInv5")]
		private PictureBox _picSecondaryInv5;

		// Token: 0x04000046 RID: 70
		[AccessedThroughProperty("picToolInv1")]
		private PictureBox _picToolInv1;

		// Token: 0x04000047 RID: 71
		[AccessedThroughProperty("picToolInv7")]
		private PictureBox _picToolInv7;

		// Token: 0x04000048 RID: 72
		[AccessedThroughProperty("picToolInv6")]
		private PictureBox _picToolInv6;

		// Token: 0x04000049 RID: 73
		[AccessedThroughProperty("picToolInv5")]
		private PictureBox _picToolInv5;

		// Token: 0x0400004A RID: 74
		[AccessedThroughProperty("picToolInv4")]
		private PictureBox _picToolInv4;

		// Token: 0x0400004B RID: 75
		[AccessedThroughProperty("picToolInv2")]
		private PictureBox _picToolInv2;

		// Token: 0x0400004C RID: 76
		[AccessedThroughProperty("picToolInv3")]
		private PictureBox _picToolInv3;

		// Token: 0x0400004D RID: 77
		[AccessedThroughProperty("picBagInv1")]
		private PictureBox _picBagInv1;

		// Token: 0x0400004E RID: 78
		[AccessedThroughProperty("picBagInv2")]
		private PictureBox _picBagInv2;

		// Token: 0x0400004F RID: 79
		[AccessedThroughProperty("picBagInv3")]
		private PictureBox _picBagInv3;

		// Token: 0x04000050 RID: 80
		[AccessedThroughProperty("picBagInv4")]
		private PictureBox _picBagInv4;

		// Token: 0x04000051 RID: 81
		[AccessedThroughProperty("picBagInv5")]
		private PictureBox _picBagInv5;

		// Token: 0x04000052 RID: 82
		[AccessedThroughProperty("picBagInv6")]
		private PictureBox _picBagInv6;

		// Token: 0x04000053 RID: 83
		[AccessedThroughProperty("picBagInv7")]
		private PictureBox _picBagInv7;

		// Token: 0x04000054 RID: 84
		[AccessedThroughProperty("picBagInv14")]
		private PictureBox _picBagInv14;

		// Token: 0x04000055 RID: 85
		[AccessedThroughProperty("picBagInv13")]
		private PictureBox _picBagInv13;

		// Token: 0x04000056 RID: 86
		[AccessedThroughProperty("picBagInv12")]
		private PictureBox _picBagInv12;

		// Token: 0x04000057 RID: 87
		[AccessedThroughProperty("picBagInv11")]
		private PictureBox _picBagInv11;

		// Token: 0x04000058 RID: 88
		[AccessedThroughProperty("picBagInv10")]
		private PictureBox _picBagInv10;

		// Token: 0x04000059 RID: 89
		[AccessedThroughProperty("picBagInv9")]
		private PictureBox _picBagInv9;

		// Token: 0x0400005A RID: 90
		[AccessedThroughProperty("picBagInv8")]
		private PictureBox _picBagInv8;

		// Token: 0x0400005B RID: 91
		[AccessedThroughProperty("picBagInv21")]
		private PictureBox _picBagInv21;

		// Token: 0x0400005C RID: 92
		[AccessedThroughProperty("picBagInv20")]
		private PictureBox _picBagInv20;

		// Token: 0x0400005D RID: 93
		[AccessedThroughProperty("picBagInv19")]
		private PictureBox _picBagInv19;

		// Token: 0x0400005E RID: 94
		[AccessedThroughProperty("picBagInv18")]
		private PictureBox _picBagInv18;

		// Token: 0x0400005F RID: 95
		[AccessedThroughProperty("picBagInv17")]
		private PictureBox _picBagInv17;

		// Token: 0x04000060 RID: 96
		[AccessedThroughProperty("picBagInv16")]
		private PictureBox _picBagInv16;

		// Token: 0x04000061 RID: 97
		[AccessedThroughProperty("picBagInv15")]
		private PictureBox _picBagInv15;

		// Token: 0x04000062 RID: 98
		[AccessedThroughProperty("picBagInv23")]
		private PictureBox _picBagInv23;

		// Token: 0x04000063 RID: 99
		[AccessedThroughProperty("picBagInv22")]
		private PictureBox _picBagInv22;

		// Token: 0x04000064 RID: 100
		[AccessedThroughProperty("picBagPrimary")]
		private PictureBox _picBagPrimary;

		// Token: 0x04000065 RID: 101
		[AccessedThroughProperty("picBagSecondary")]
		private PictureBox _picBagSecondary;

		// Token: 0x04000066 RID: 102
		[AccessedThroughProperty("picBagInv24")]
		private PictureBox _picBagInv24;

		// Token: 0x04000067 RID: 103
		[AccessedThroughProperty("panel2")]
		private Panel _panel2;

		// Token: 0x04000068 RID: 104
		[AccessedThroughProperty("panel3")]
		private Panel _panel3;

		// Token: 0x04000069 RID: 105
		[AccessedThroughProperty("panel4")]
		private Panel _panel4;

		// Token: 0x0400006A RID: 106
		[AccessedThroughProperty("panel5")]
		private Panel _panel5;

		// Token: 0x0400006B RID: 107
		[AccessedThroughProperty("panel6")]
		private Panel _panel6;

		// Token: 0x0400006C RID: 108
		private int opticsLeft;

		// Token: 0x0400006D RID: 109
		private string[] opticsName;

		// Token: 0x0400006E RID: 110
		private int primaryLeft;

		// Token: 0x0400006F RID: 111
		private string primaryName;

		// Token: 0x04000070 RID: 112
		private int primarySize;

		// Token: 0x04000071 RID: 113
		private int secondaryLeft;

		// Token: 0x04000072 RID: 114
		private string secondaryName;

		// Token: 0x04000073 RID: 115
		private int secondarySize;

		// Token: 0x04000074 RID: 116
		private int inventory1Left;

		// Token: 0x04000075 RID: 117
		private string[] inventory1Name;

		// Token: 0x04000076 RID: 118
		private int[] inventory1Size;

		// Token: 0x04000077 RID: 119
		private int inventory2Left;

		// Token: 0x04000078 RID: 120
		private string[] inventory2Name;

		// Token: 0x04000079 RID: 121
		private int[] inventory2Size;

		// Token: 0x0400007A RID: 122
		private int toolLeft;

		// Token: 0x0400007B RID: 123
		private string[] toolName;

		// Token: 0x0400007C RID: 124
		private int[] toolSize;

		// Token: 0x0400007D RID: 125
		private int baginventoryLeft;

		// Token: 0x0400007E RID: 126
		private string[] baginventoryName;

		// Token: 0x0400007F RID: 127
		private int[] baginventorySize;

		// Token: 0x04000080 RID: 128
		private string bagsecondaryName;

		// Token: 0x04000081 RID: 129
		private int bagsecondarySize;

		// Token: 0x04000082 RID: 130
		private string bagprimaryName;

		// Token: 0x04000083 RID: 131
		private int bagprimarySize;

		// Token: 0x04000084 RID: 132
		private List<string> rINV;

		// Token: 0x04000085 RID: 133
		private List<string> lINV;

		// Token: 0x04000086 RID: 134
		private List<string> lbagINV;

		// Token: 0x04000087 RID: 135
		private List<string> rbagINV;

		// Token: 0x04000088 RID: 136
		private List<string> lbagINV2;

		// Token: 0x04000089 RID: 137
		private List<string> rbagINV2;

		// Token: 0x0400008A RID: 138
		private List<int> lbagINVvalues;

		// Token: 0x0400008B RID: 139
		private List<int> rbagINVvalues;

		// Token: 0x0400008C RID: 140
		private int invtype;

		// Token: 0x0400008D RID: 141
		private int itemsize;

		// Token: 0x0400008E RID: 142
		private int itempicture;

		// Token: 0x0400008F RID: 143
		private string itemname;

		// Token: 0x04000090 RID: 144
		private int keyinput;

		// Token: 0x04000091 RID: 145
		private int Counter;

		// Token: 0x04000092 RID: 146
		private int ItemDel;

		// Token: 0x04000093 RID: 147
		private int ItemDelBag;

		// Token: 0x04000094 RID: 148
		private string ItemHolder;

		// Token: 0x04000095 RID: 149
		private int[] itemdelside;

		// Token: 0x04000096 RID: 150
		private string BagName;

		// Token: 0x04000097 RID: 151
		private int MaxBagSlots;

		// Token: 0x04000098 RID: 152
		private List<PictureBox> picPrimaryInv;

		// Token: 0x04000099 RID: 153
		private List<PictureBox> picSecondaryInv;

		// Token: 0x0400009A RID: 154
		private List<PictureBox> picToolInv;

		// Token: 0x0400009B RID: 155
		private List<PictureBox> picBagInv;

		// Token: 0x0400009C RID: 156
		private int[] MainInvGridLoc;

		// Token: 0x0400009D RID: 157
		private int[] BagInvGridLoc;

		// Token: 0x0400009E RID: 158
		private int[] SecInvGridLoc;

		// Token: 0x0400009F RID: 159
		private int[] ToolGridLoc;
	}
}
