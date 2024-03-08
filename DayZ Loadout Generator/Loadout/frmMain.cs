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
	[DesignerGenerated]
	public sealed class frmMain : Form
	{
		private IContainer components;

		[AccessedThroughProperty("groupResult")]
		private GroupBox _groupResult;

		[AccessedThroughProperty("textResult")]
		private TextBox _textResult;

		[AccessedThroughProperty("groupPreview")]
		private GroupBox _groupPreview;

		[AccessedThroughProperty("picPreview")]
		private PictureBox _picPreview;

		[AccessedThroughProperty("comboboxMEDICAL")]
		private ComboBox _comboboxMEDICAL;

		[AccessedThroughProperty("comboboxTOOLS")]
		private ComboBox _comboboxTOOLS;

		[AccessedThroughProperty("comboboxPARTS")]
		private ComboBox _comboboxPARTS;

		[AccessedThroughProperty("comboboxRIFLE")]
		private ComboBox _comboboxRIFLE;

		[AccessedThroughProperty("comboboxSUBMACHINE")]
		private ComboBox _comboboxSUBMACHINE;

		[AccessedThroughProperty("comboboxSHOTGUN")]
		private ComboBox _comboboxSHOTGUN;

		[AccessedThroughProperty("comboboxSNIPER")]
		private ComboBox _comboboxSNIPER;

		[AccessedThroughProperty("comboboxMACHINEGUN")]
		private ComboBox _comboboxMACHINEGUN;

		[AccessedThroughProperty("comboboxMISC")]
		private ComboBox _comboboxMISC;

		[AccessedThroughProperty("btnAddInv")]
		private Button _btnAddInv;

		[AccessedThroughProperty("btnAddBag")]
		private Button _btnAddBag;

		[AccessedThroughProperty("comboboxFOOD")]
		private ComboBox _comboboxFOOD;

		[AccessedThroughProperty("comboboxPISTOL")]
		private ComboBox _comboboxPISTOL;

		[AccessedThroughProperty("btnGenerateInv")]
		private Button _btnGenerateInv;

		[AccessedThroughProperty("btnGenerateBag")]
		private Button _btnGenerateBag;

		[AccessedThroughProperty("groupBackpack")]
		private GroupBox _groupBackpack;

		[AccessedThroughProperty("radio6")]
		private RadioButton _radio6;

		[AccessedThroughProperty("radio4")]
		private RadioButton _radio4;

		[AccessedThroughProperty("radio3")]
		private RadioButton _radio3;

		[AccessedThroughProperty("radio2")]
		private RadioButton _radio2;

		[AccessedThroughProperty("radio1")]
		private RadioButton _radio1;

		[AccessedThroughProperty("radio5")]
		private RadioButton _radio5;

		[AccessedThroughProperty("imgBags")]
		private ImageList _imgBags;

		[AccessedThroughProperty("cmsRemove")]
		private ContextMenuStrip _cmsRemove;

		[AccessedThroughProperty("cmsRemoveItem")]
		private ToolStripMenuItem _cmsRemoveItem;

		[AccessedThroughProperty("imgPrimaryWeapons")]
		private ImageList _imgPrimaryWeapons;

		[AccessedThroughProperty("imgSecondaryWeapons")]
		private ImageList _imgSecondaryWeapons;

		[AccessedThroughProperty("imgPrimaryInv")]
		private ImageList _imgPrimaryInv;

		[AccessedThroughProperty("imgSecondaryInv")]
		private ImageList _imgSecondaryInv;

		[AccessedThroughProperty("imgTools")]
		private ImageList _imgTools;

		[AccessedThroughProperty("panel1")]
		private Panel _panel1;

		[AccessedThroughProperty("picOptics2")]
		private PictureBox _picOptics2;

		[AccessedThroughProperty("picOptics1")]
		private PictureBox _picOptics1;

		[AccessedThroughProperty("picPrimary")]
		private PictureBox _picPrimary;

		[AccessedThroughProperty("picBackpack")]
		private PictureBox _picBackpack;

		[AccessedThroughProperty("picSecondary")]
		private PictureBox _picSecondary;

		[AccessedThroughProperty("picPrimaryInv1")]
		private PictureBox _picPrimaryInv1;

		[AccessedThroughProperty("picPrimaryInv2")]
		private PictureBox _picPrimaryInv2;

		[AccessedThroughProperty("picPrimaryInv4")]
		private PictureBox _picPrimaryInv4;

		[AccessedThroughProperty("picPrimaryInv3")]
		private PictureBox _picPrimaryInv3;

		[AccessedThroughProperty("picPrimaryInv7")]
		private PictureBox _picPrimaryInv7;

		[AccessedThroughProperty("picPrimaryInv8")]
		private PictureBox _picPrimaryInv8;

		[AccessedThroughProperty("picPrimaryInv6")]
		private PictureBox _picPrimaryInv6;

		[AccessedThroughProperty("picPrimaryInv5")]
		private PictureBox _picPrimaryInv5;

		[AccessedThroughProperty("picPrimaryInv11")]
		private PictureBox _picPrimaryInv11;

		[AccessedThroughProperty("picPrimaryInv12")]
		private PictureBox _picPrimaryInv12;

		[AccessedThroughProperty("picPrimaryInv10")]
		private PictureBox _picPrimaryInv10;

		[AccessedThroughProperty("picPrimaryInv9")]
		private PictureBox _picPrimaryInv9;

		[AccessedThroughProperty("picSecondaryInv1")]
		private PictureBox _picSecondaryInv1;

		[AccessedThroughProperty("picSecondaryInv2")]
		private PictureBox _picSecondaryInv2;

		[AccessedThroughProperty("picSecondaryInv3")]
		private PictureBox _picSecondaryInv3;

		[AccessedThroughProperty("picSecondaryInv4")]
		private PictureBox _picSecondaryInv4;

		[AccessedThroughProperty("picSecondaryInv8")]
		private PictureBox _picSecondaryInv8;

		[AccessedThroughProperty("picSecondaryInv7")]
		private PictureBox _picSecondaryInv7;

		[AccessedThroughProperty("picSecondaryInv6")]
		private PictureBox _picSecondaryInv6;

		[AccessedThroughProperty("picSecondaryInv5")]
		private PictureBox _picSecondaryInv5;

		[AccessedThroughProperty("picToolInv1")]
		private PictureBox _picToolInv1;

		[AccessedThroughProperty("picToolInv7")]
		private PictureBox _picToolInv7;

		[AccessedThroughProperty("picToolInv6")]
		private PictureBox _picToolInv6;

		[AccessedThroughProperty("picToolInv5")]
		private PictureBox _picToolInv5;

		[AccessedThroughProperty("picToolInv4")]
		private PictureBox _picToolInv4;

		[AccessedThroughProperty("picToolInv2")]
		private PictureBox _picToolInv2;

		[AccessedThroughProperty("picToolInv3")]
		private PictureBox _picToolInv3;

		[AccessedThroughProperty("picBagInv1")]
		private PictureBox _picBagInv1;

		[AccessedThroughProperty("picBagInv2")]
		private PictureBox _picBagInv2;

		[AccessedThroughProperty("picBagInv3")]
		private PictureBox _picBagInv3;

		[AccessedThroughProperty("picBagInv4")]
		private PictureBox _picBagInv4;

		[AccessedThroughProperty("picBagInv5")]
		private PictureBox _picBagInv5;

		[AccessedThroughProperty("picBagInv6")]
		private PictureBox _picBagInv6;

		[AccessedThroughProperty("picBagInv7")]
		private PictureBox _picBagInv7;

		[AccessedThroughProperty("picBagInv14")]
		private PictureBox _picBagInv14;

		[AccessedThroughProperty("picBagInv13")]
		private PictureBox _picBagInv13;

		[AccessedThroughProperty("picBagInv12")]
		private PictureBox _picBagInv12;

		[AccessedThroughProperty("picBagInv11")]
		private PictureBox _picBagInv11;

		[AccessedThroughProperty("picBagInv10")]
		private PictureBox _picBagInv10;

		[AccessedThroughProperty("picBagInv9")]
		private PictureBox _picBagInv9;

		[AccessedThroughProperty("picBagInv8")]
		private PictureBox _picBagInv8;

		[AccessedThroughProperty("picBagInv21")]
		private PictureBox _picBagInv21;

		[AccessedThroughProperty("picBagInv20")]
		private PictureBox _picBagInv20;

		[AccessedThroughProperty("picBagInv19")]
		private PictureBox _picBagInv19;

		[AccessedThroughProperty("picBagInv18")]
		private PictureBox _picBagInv18;

		[AccessedThroughProperty("picBagInv17")]
		private PictureBox _picBagInv17;

		[AccessedThroughProperty("picBagInv16")]
		private PictureBox _picBagInv16;

		[AccessedThroughProperty("picBagInv15")]
		private PictureBox _picBagInv15;

		[AccessedThroughProperty("picBagInv23")]
		private PictureBox _picBagInv23;

		[AccessedThroughProperty("picBagInv22")]
		private PictureBox _picBagInv22;

		[AccessedThroughProperty("picBagPrimary")]
		private PictureBox _picBagPrimary;

		[AccessedThroughProperty("picBagSecondary")]
		private PictureBox _picBagSecondary;

		[AccessedThroughProperty("picBagInv24")]
		private PictureBox _picBagInv24;

		[AccessedThroughProperty("panel2")]
		private Panel _panel2;

		[AccessedThroughProperty("panel3")]
		private Panel _panel3;

		[AccessedThroughProperty("panel4")]
		private Panel _panel4;

		[AccessedThroughProperty("panel5")]
		private Panel _panel5;

		[AccessedThroughProperty("panel6")]
		private Panel _panel6;

		private int opticsLeft;

		private string[] opticsName;

		private int primaryLeft;

		private string primaryName;

		private int primarySize;

		private int secondaryLeft;

		private string secondaryName;

		private int secondarySize;

		private int inventory1Left;

		private string[] inventory1Name;

		private int[] inventory1Size;

		private int inventory2Left;

		private string[] inventory2Name;

		private int[] inventory2Size;

		private int toolLeft;

		private string[] toolName;

		private int[] toolSize;

		private int baginventoryLeft;

		private string[] baginventoryName;

		private int[] baginventorySize;

		private string bagsecondaryName;

		private int bagsecondarySize;

		private string bagprimaryName;

		private int bagprimarySize;

		private List<string> rINV;

		private List<string> lINV;

		private List<string> lbagINV;

		private List<string> rbagINV;

		private List<string> lbagINV2;

		private List<string> rbagINV2;

		private List<int> lbagINVvalues;

		private List<int> rbagINVvalues;

		private int invtype;

		private int itemsize;

		private int itempicture;

		private string itemname;

		private int keyinput;

		private int Counter;

		private int ItemDel;

		private int ItemDelBag;

		private string ItemHolder;

		private int[] itemdelside;

		private string BagName;

		private int MaxBagSlots;

		private List<PictureBox> picPrimaryInv;

		private List<PictureBox> picSecondaryInv;

		private List<PictureBox> picToolInv;

		private List<PictureBox> picBagInv;

		private int[] MainInvGridLoc;

		private int[] BagInvGridLoc;

		private int[] SecInvGridLoc;

		private int[] ToolGridLoc;

		internal virtual GroupBox groupResult
		{
			[DebuggerNonUserCode]
			get
			{
				return _groupResult;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				_groupResult = value;
			}
		}

		internal virtual TextBox textResult
		{
			[DebuggerNonUserCode]
			get
			{
				return _textResult;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				_textResult = value;
			}
		}

		internal virtual GroupBox groupPreview
		{
			[DebuggerNonUserCode]
			get
			{
				return _groupPreview;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				_groupPreview = value;
			}
		}

		internal virtual PictureBox picPreview
		{
			[DebuggerNonUserCode]
			get
			{
				return _picPreview;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				_picPreview = value;
			}
		}

		internal virtual ComboBox comboboxMEDICAL
		{
			[DebuggerNonUserCode]
			get
			{
				return _comboboxMEDICAL;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_comboboxMEDICAL != null)
				{
					_comboboxMEDICAL.SelectedIndexChanged -= comboboxMEDICAL_SelectedIndexChanged;
					_comboboxMEDICAL.KeyDown -= combobox_KeyDown;
				}
				_comboboxMEDICAL = value;
				if (_comboboxMEDICAL != null)
				{
					_comboboxMEDICAL.SelectedIndexChanged += comboboxMEDICAL_SelectedIndexChanged;
					_comboboxMEDICAL.KeyDown += combobox_KeyDown;
				}
			}
		}

		internal virtual ComboBox comboboxTOOLS
		{
			[DebuggerNonUserCode]
			get
			{
				return _comboboxTOOLS;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_comboboxTOOLS != null)
				{
					_comboboxTOOLS.SelectedIndexChanged -= comboboxTOOLS_SelectedIndexChanged;
					_comboboxTOOLS.KeyDown -= combobox_KeyDown;
				}
				_comboboxTOOLS = value;
				if (_comboboxTOOLS != null)
				{
					_comboboxTOOLS.SelectedIndexChanged += comboboxTOOLS_SelectedIndexChanged;
					_comboboxTOOLS.KeyDown += combobox_KeyDown;
				}
			}
		}

		internal virtual ComboBox comboboxPARTS
		{
			[DebuggerNonUserCode]
			get
			{
				return _comboboxPARTS;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_comboboxPARTS != null)
				{
					_comboboxPARTS.SelectedIndexChanged -= comboboxPARTS_SelectedIndexChanged;
					_comboboxPARTS.KeyDown -= combobox_KeyDown;
				}
				_comboboxPARTS = value;
				if (_comboboxPARTS != null)
				{
					_comboboxPARTS.SelectedIndexChanged += comboboxPARTS_SelectedIndexChanged;
					_comboboxPARTS.KeyDown += combobox_KeyDown;
				}
			}
		}

		internal virtual ComboBox comboboxRIFLE
		{
			[DebuggerNonUserCode]
			get
			{
				return _comboboxRIFLE;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_comboboxRIFLE != null)
				{
					_comboboxRIFLE.SelectedIndexChanged -= comboboxRIFLE_SelectedIndexChanged;
					_comboboxRIFLE.KeyDown -= combobox_KeyDown;
				}
				_comboboxRIFLE = value;
				if (_comboboxRIFLE != null)
				{
					_comboboxRIFLE.SelectedIndexChanged += comboboxRIFLE_SelectedIndexChanged;
					_comboboxRIFLE.KeyDown += combobox_KeyDown;
				}
			}
		}

		internal virtual ComboBox comboboxSUBMACHINE
		{
			[DebuggerNonUserCode]
			get
			{
				return _comboboxSUBMACHINE;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_comboboxSUBMACHINE != null)
				{
					_comboboxSUBMACHINE.SelectedIndexChanged -= comboboxSUBMACHINE_SelectedIndexChanged;
					_comboboxSUBMACHINE.KeyDown -= combobox_KeyDown;
				}
				_comboboxSUBMACHINE = value;
				if (_comboboxSUBMACHINE != null)
				{
					_comboboxSUBMACHINE.SelectedIndexChanged += comboboxSUBMACHINE_SelectedIndexChanged;
					_comboboxSUBMACHINE.KeyDown += combobox_KeyDown;
				}
			}
		}

		internal virtual ComboBox comboboxSHOTGUN
		{
			[DebuggerNonUserCode]
			get
			{
				return _comboboxSHOTGUN;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_comboboxSHOTGUN != null)
				{
					_comboboxSHOTGUN.SelectedIndexChanged -= comboboxSHOTGUN_SelectedIndexChanged;
					_comboboxSHOTGUN.KeyDown -= combobox_KeyDown;
				}
				_comboboxSHOTGUN = value;
				if (_comboboxSHOTGUN != null)
				{
					_comboboxSHOTGUN.SelectedIndexChanged += comboboxSHOTGUN_SelectedIndexChanged;
					_comboboxSHOTGUN.KeyDown += combobox_KeyDown;
				}
			}
		}

		internal virtual ComboBox comboboxSNIPER
		{
			[DebuggerNonUserCode]
			get
			{
				return _comboboxSNIPER;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_comboboxSNIPER != null)
				{
					_comboboxSNIPER.SelectedIndexChanged -= comboboxSNIPER_SelectedIndexChanged;
					_comboboxSNIPER.KeyDown -= combobox_KeyDown;
				}
				_comboboxSNIPER = value;
				if (_comboboxSNIPER != null)
				{
					_comboboxSNIPER.SelectedIndexChanged += comboboxSNIPER_SelectedIndexChanged;
					_comboboxSNIPER.KeyDown += combobox_KeyDown;
				}
			}
		}

		internal virtual ComboBox comboboxMACHINEGUN
		{
			[DebuggerNonUserCode]
			get
			{
				return _comboboxMACHINEGUN;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_comboboxMACHINEGUN != null)
				{
					_comboboxMACHINEGUN.SelectedIndexChanged -= comboboxMACHINEGUN_SelectedIndexChanged;
					_comboboxMACHINEGUN.KeyDown -= combobox_KeyDown;
				}
				_comboboxMACHINEGUN = value;
				if (_comboboxMACHINEGUN != null)
				{
					_comboboxMACHINEGUN.SelectedIndexChanged += comboboxMACHINEGUN_SelectedIndexChanged;
					_comboboxMACHINEGUN.KeyDown += combobox_KeyDown;
				}
			}
		}

		internal virtual ComboBox comboboxMISC
		{
			[DebuggerNonUserCode]
			get
			{
				return _comboboxMISC;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_comboboxMISC != null)
				{
					_comboboxMISC.SelectedIndexChanged -= comboboxMISC_SelectedIndexChanged;
					_comboboxMISC.KeyDown -= combobox_KeyDown;
				}
				_comboboxMISC = value;
				if (_comboboxMISC != null)
				{
					_comboboxMISC.SelectedIndexChanged += comboboxMISC_SelectedIndexChanged;
					_comboboxMISC.KeyDown += combobox_KeyDown;
				}
			}
		}

		internal virtual Button btnAddInv
		{
			[DebuggerNonUserCode]
			get
			{
				return _btnAddInv;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_btnAddInv != null)
				{
					_btnAddInv.Click -= btnAddInventory_Click;
				}
				_btnAddInv = value;
				if (_btnAddInv != null)
				{
					_btnAddInv.Click += btnAddInventory_Click;
				}
			}
		}

		internal virtual Button btnAddBag
		{
			[DebuggerNonUserCode]
			get
			{
				return _btnAddBag;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_btnAddBag != null)
				{
					_btnAddBag.Click -= btnAddBackpack_Click;
				}
				_btnAddBag = value;
				if (_btnAddBag != null)
				{
					_btnAddBag.Click += btnAddBackpack_Click;
				}
			}
		}

		internal virtual ComboBox comboboxFOOD
		{
			[DebuggerNonUserCode]
			get
			{
				return _comboboxFOOD;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_comboboxFOOD != null)
				{
					_comboboxFOOD.SelectedIndexChanged -= comboboxFOOD_SelectedIndexChanged;
					_comboboxFOOD.KeyDown -= combobox_KeyDown;
				}
				_comboboxFOOD = value;
				if (_comboboxFOOD != null)
				{
					_comboboxFOOD.SelectedIndexChanged += comboboxFOOD_SelectedIndexChanged;
					_comboboxFOOD.KeyDown += combobox_KeyDown;
				}
			}
		}

		internal virtual ComboBox comboboxPISTOL
		{
			[DebuggerNonUserCode]
			get
			{
				return _comboboxPISTOL;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_comboboxPISTOL != null)
				{
					_comboboxPISTOL.SelectedIndexChanged -= comboboxPISTOL_SelectedIndexChanged;
					_comboboxPISTOL.KeyDown -= combobox_KeyDown;
				}
				_comboboxPISTOL = value;
				if (_comboboxPISTOL != null)
				{
					_comboboxPISTOL.SelectedIndexChanged += comboboxPISTOL_SelectedIndexChanged;
					_comboboxPISTOL.KeyDown += combobox_KeyDown;
				}
			}
		}

		internal virtual Button btnGenerateInv
		{
			[DebuggerNonUserCode]
			get
			{
				return _btnGenerateInv;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_btnGenerateInv != null)
				{
					_btnGenerateInv.Click -= btnGenerate_Click;
				}
				_btnGenerateInv = value;
				if (_btnGenerateInv != null)
				{
					_btnGenerateInv.Click += btnGenerate_Click;
				}
			}
		}

		internal virtual Button btnGenerateBag
		{
			[DebuggerNonUserCode]
			get
			{
				return _btnGenerateBag;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_btnGenerateBag != null)
				{
					_btnGenerateBag.Click -= btnGenerateBag_Click;
				}
				_btnGenerateBag = value;
				if (_btnGenerateBag != null)
				{
					_btnGenerateBag.Click += btnGenerateBag_Click;
				}
			}
		}

		internal virtual GroupBox groupBackpack
		{
			[DebuggerNonUserCode]
			get
			{
				return _groupBackpack;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				_groupBackpack = value;
			}
		}

		internal virtual RadioButton radio6
		{
			[DebuggerNonUserCode]
			get
			{
				return _radio6;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_radio6 != null)
				{
					_radio6.CheckedChanged -= radioBackpack_CheckedChanged;
				}
				_radio6 = value;
				if (_radio6 != null)
				{
					_radio6.CheckedChanged += radioBackpack_CheckedChanged;
				}
			}
		}

		internal virtual RadioButton radio4
		{
			[DebuggerNonUserCode]
			get
			{
				return _radio4;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_radio4 != null)
				{
					_radio4.CheckedChanged -= radioBackpack_CheckedChanged;
				}
				_radio4 = value;
				if (_radio4 != null)
				{
					_radio4.CheckedChanged += radioBackpack_CheckedChanged;
				}
			}
		}

		internal virtual RadioButton radio3
		{
			[DebuggerNonUserCode]
			get
			{
				return _radio3;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_radio3 != null)
				{
					_radio3.CheckedChanged -= radioBackpack_CheckedChanged;
				}
				_radio3 = value;
				if (_radio3 != null)
				{
					_radio3.CheckedChanged += radioBackpack_CheckedChanged;
				}
			}
		}

		internal virtual RadioButton radio2
		{
			[DebuggerNonUserCode]
			get
			{
				return _radio2;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_radio2 != null)
				{
					_radio2.CheckedChanged -= radioBackpack_CheckedChanged;
				}
				_radio2 = value;
				if (_radio2 != null)
				{
					_radio2.CheckedChanged += radioBackpack_CheckedChanged;
				}
			}
		}

		internal virtual RadioButton radio1
		{
			[DebuggerNonUserCode]
			get
			{
				return _radio1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_radio1 != null)
				{
					_radio1.CheckedChanged -= radioBackpack_CheckedChanged;
				}
				_radio1 = value;
				if (_radio1 != null)
				{
					_radio1.CheckedChanged += radioBackpack_CheckedChanged;
				}
			}
		}

		internal virtual RadioButton radio5
		{
			[DebuggerNonUserCode]
			get
			{
				return _radio5;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_radio5 != null)
				{
					_radio5.CheckedChanged -= radioBackpack_CheckedChanged;
				}
				_radio5 = value;
				if (_radio5 != null)
				{
					_radio5.CheckedChanged += radioBackpack_CheckedChanged;
				}
			}
		}

		internal virtual ImageList imgBags
		{
			[DebuggerNonUserCode]
			get
			{
				return _imgBags;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				_imgBags = value;
			}
		}

		internal virtual ContextMenuStrip cmsRemove
		{
			[DebuggerNonUserCode]
			get
			{
				return _cmsRemove;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				_cmsRemove = value;
			}
		}

		internal virtual ToolStripMenuItem cmsRemoveItem
		{
			[DebuggerNonUserCode]
			get
			{
				return _cmsRemoveItem;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_cmsRemoveItem != null)
				{
					_cmsRemoveItem.Click -= cmsRemoveItem_Click;
				}
				_cmsRemoveItem = value;
				if (_cmsRemoveItem != null)
				{
					_cmsRemoveItem.Click += cmsRemoveItem_Click;
				}
			}
		}

		internal virtual ImageList imgPrimaryWeapons
		{
			[DebuggerNonUserCode]
			get
			{
				return _imgPrimaryWeapons;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				_imgPrimaryWeapons = value;
			}
		}

		internal virtual ImageList imgSecondaryWeapons
		{
			[DebuggerNonUserCode]
			get
			{
				return _imgSecondaryWeapons;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				_imgSecondaryWeapons = value;
			}
		}

		internal virtual ImageList imgPrimaryInv
		{
			[DebuggerNonUserCode]
			get
			{
				return _imgPrimaryInv;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				_imgPrimaryInv = value;
			}
		}

		internal virtual ImageList imgSecondaryInv
		{
			[DebuggerNonUserCode]
			get
			{
				return _imgSecondaryInv;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				_imgSecondaryInv = value;
			}
		}

		internal virtual ImageList imgTools
		{
			[DebuggerNonUserCode]
			get
			{
				return _imgTools;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				_imgTools = value;
			}
		}

		internal virtual Panel panel1
		{
			[DebuggerNonUserCode]
			get
			{
				return _panel1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				_panel1 = value;
			}
		}

		internal virtual PictureBox picOptics2
		{
			[DebuggerNonUserCode]
			get
			{
				return _picOptics2;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_picOptics2 != null)
				{
					_picOptics2.MouseEnter -= picOptics_MouseEnter;
				}
				_picOptics2 = value;
				if (_picOptics2 != null)
				{
					_picOptics2.MouseEnter += picOptics_MouseEnter;
				}
			}
		}

		internal virtual PictureBox picOptics1
		{
			[DebuggerNonUserCode]
			get
			{
				return _picOptics1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_picOptics1 != null)
				{
					_picOptics1.MouseEnter -= picOptics_MouseEnter;
				}
				_picOptics1 = value;
				if (_picOptics1 != null)
				{
					_picOptics1.MouseEnter += picOptics_MouseEnter;
				}
			}
		}

		internal virtual PictureBox picPrimary
		{
			[DebuggerNonUserCode]
			get
			{
				return _picPrimary;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_picPrimary != null)
				{
					_picPrimary.MouseEnter -= picPrimary_MouseEnter;
				}
				_picPrimary = value;
				if (_picPrimary != null)
				{
					_picPrimary.MouseEnter += picPrimary_MouseEnter;
				}
			}
		}

		internal virtual PictureBox picBackpack
		{
			[DebuggerNonUserCode]
			get
			{
				return _picBackpack;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_picBackpack != null)
				{
					_picBackpack.MouseEnter -= picBackpack_MouseEnter;
				}
				_picBackpack = value;
				if (_picBackpack != null)
				{
					_picBackpack.MouseEnter += picBackpack_MouseEnter;
				}
			}
		}

		internal virtual PictureBox picSecondary
		{
			[DebuggerNonUserCode]
			get
			{
				return _picSecondary;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_picSecondary != null)
				{
					_picSecondary.MouseEnter -= picSecondary_MouseEnter;
				}
				_picSecondary = value;
				if (_picSecondary != null)
				{
					_picSecondary.MouseEnter += picSecondary_MouseEnter;
				}
			}
		}

		internal virtual PictureBox picPrimaryInv1
		{
			[DebuggerNonUserCode]
			get
			{
				return _picPrimaryInv1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_picPrimaryInv1 != null)
				{
					_picPrimaryInv1.MouseEnter -= picPrimaryInv_MouseEnter;
				}
				_picPrimaryInv1 = value;
				if (_picPrimaryInv1 != null)
				{
					_picPrimaryInv1.MouseEnter += picPrimaryInv_MouseEnter;
				}
			}
		}

		internal virtual PictureBox picPrimaryInv2
		{
			[DebuggerNonUserCode]
			get
			{
				return _picPrimaryInv2;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_picPrimaryInv2 != null)
				{
					_picPrimaryInv2.MouseEnter -= picPrimaryInv_MouseEnter;
				}
				_picPrimaryInv2 = value;
				if (_picPrimaryInv2 != null)
				{
					_picPrimaryInv2.MouseEnter += picPrimaryInv_MouseEnter;
				}
			}
		}

		internal virtual PictureBox picPrimaryInv4
		{
			[DebuggerNonUserCode]
			get
			{
				return _picPrimaryInv4;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_picPrimaryInv4 != null)
				{
					_picPrimaryInv4.MouseEnter -= picPrimaryInv_MouseEnter;
				}
				_picPrimaryInv4 = value;
				if (_picPrimaryInv4 != null)
				{
					_picPrimaryInv4.MouseEnter += picPrimaryInv_MouseEnter;
				}
			}
		}

		internal virtual PictureBox picPrimaryInv3
		{
			[DebuggerNonUserCode]
			get
			{
				return _picPrimaryInv3;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_picPrimaryInv3 != null)
				{
					_picPrimaryInv3.MouseEnter -= picPrimaryInv_MouseEnter;
				}
				_picPrimaryInv3 = value;
				if (_picPrimaryInv3 != null)
				{
					_picPrimaryInv3.MouseEnter += picPrimaryInv_MouseEnter;
				}
			}
		}

		internal virtual PictureBox picPrimaryInv7
		{
			[DebuggerNonUserCode]
			get
			{
				return _picPrimaryInv7;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_picPrimaryInv7 != null)
				{
					_picPrimaryInv7.MouseEnter -= picPrimaryInv_MouseEnter;
				}
				_picPrimaryInv7 = value;
				if (_picPrimaryInv7 != null)
				{
					_picPrimaryInv7.MouseEnter += picPrimaryInv_MouseEnter;
				}
			}
		}

		internal virtual PictureBox picPrimaryInv8
		{
			[DebuggerNonUserCode]
			get
			{
				return _picPrimaryInv8;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_picPrimaryInv8 != null)
				{
					_picPrimaryInv8.MouseEnter -= picPrimaryInv_MouseEnter;
				}
				_picPrimaryInv8 = value;
				if (_picPrimaryInv8 != null)
				{
					_picPrimaryInv8.MouseEnter += picPrimaryInv_MouseEnter;
				}
			}
		}

		internal virtual PictureBox picPrimaryInv6
		{
			[DebuggerNonUserCode]
			get
			{
				return _picPrimaryInv6;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_picPrimaryInv6 != null)
				{
					_picPrimaryInv6.MouseEnter -= picPrimaryInv_MouseEnter;
				}
				_picPrimaryInv6 = value;
				if (_picPrimaryInv6 != null)
				{
					_picPrimaryInv6.MouseEnter += picPrimaryInv_MouseEnter;
				}
			}
		}

		internal virtual PictureBox picPrimaryInv5
		{
			[DebuggerNonUserCode]
			get
			{
				return _picPrimaryInv5;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_picPrimaryInv5 != null)
				{
					_picPrimaryInv5.MouseEnter -= picPrimaryInv_MouseEnter;
				}
				_picPrimaryInv5 = value;
				if (_picPrimaryInv5 != null)
				{
					_picPrimaryInv5.MouseEnter += picPrimaryInv_MouseEnter;
				}
			}
		}

		internal virtual PictureBox picPrimaryInv11
		{
			[DebuggerNonUserCode]
			get
			{
				return _picPrimaryInv11;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_picPrimaryInv11 != null)
				{
					_picPrimaryInv11.MouseEnter -= picPrimaryInv_MouseEnter;
				}
				_picPrimaryInv11 = value;
				if (_picPrimaryInv11 != null)
				{
					_picPrimaryInv11.MouseEnter += picPrimaryInv_MouseEnter;
				}
			}
		}

		internal virtual PictureBox picPrimaryInv12
		{
			[DebuggerNonUserCode]
			get
			{
				return _picPrimaryInv12;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_picPrimaryInv12 != null)
				{
					_picPrimaryInv12.MouseEnter -= picPrimaryInv_MouseEnter;
				}
				_picPrimaryInv12 = value;
				if (_picPrimaryInv12 != null)
				{
					_picPrimaryInv12.MouseEnter += picPrimaryInv_MouseEnter;
				}
			}
		}

		internal virtual PictureBox picPrimaryInv10
		{
			[DebuggerNonUserCode]
			get
			{
				return _picPrimaryInv10;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_picPrimaryInv10 != null)
				{
					_picPrimaryInv10.MouseEnter -= picPrimaryInv_MouseEnter;
				}
				_picPrimaryInv10 = value;
				if (_picPrimaryInv10 != null)
				{
					_picPrimaryInv10.MouseEnter += picPrimaryInv_MouseEnter;
				}
			}
		}

		internal virtual PictureBox picPrimaryInv9
		{
			[DebuggerNonUserCode]
			get
			{
				return _picPrimaryInv9;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_picPrimaryInv9 != null)
				{
					_picPrimaryInv9.MouseEnter -= picPrimaryInv_MouseEnter;
				}
				_picPrimaryInv9 = value;
				if (_picPrimaryInv9 != null)
				{
					_picPrimaryInv9.MouseEnter += picPrimaryInv_MouseEnter;
				}
			}
		}

		internal virtual PictureBox picSecondaryInv1
		{
			[DebuggerNonUserCode]
			get
			{
				return _picSecondaryInv1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_picSecondaryInv1 != null)
				{
					_picSecondaryInv1.MouseEnter -= picSecondaryInv_MouseEnter;
				}
				_picSecondaryInv1 = value;
				if (_picSecondaryInv1 != null)
				{
					_picSecondaryInv1.MouseEnter += picSecondaryInv_MouseEnter;
				}
			}
		}

		internal virtual PictureBox picSecondaryInv2
		{
			[DebuggerNonUserCode]
			get
			{
				return _picSecondaryInv2;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_picSecondaryInv2 != null)
				{
					_picSecondaryInv2.MouseEnter -= picSecondaryInv_MouseEnter;
				}
				_picSecondaryInv2 = value;
				if (_picSecondaryInv2 != null)
				{
					_picSecondaryInv2.MouseEnter += picSecondaryInv_MouseEnter;
				}
			}
		}

		internal virtual PictureBox picSecondaryInv3
		{
			[DebuggerNonUserCode]
			get
			{
				return _picSecondaryInv3;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_picSecondaryInv3 != null)
				{
					_picSecondaryInv3.MouseEnter -= picSecondaryInv_MouseEnter;
				}
				_picSecondaryInv3 = value;
				if (_picSecondaryInv3 != null)
				{
					_picSecondaryInv3.MouseEnter += picSecondaryInv_MouseEnter;
				}
			}
		}

		internal virtual PictureBox picSecondaryInv4
		{
			[DebuggerNonUserCode]
			get
			{
				return _picSecondaryInv4;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_picSecondaryInv4 != null)
				{
					_picSecondaryInv4.MouseEnter -= picSecondaryInv_MouseEnter;
				}
				_picSecondaryInv4 = value;
				if (_picSecondaryInv4 != null)
				{
					_picSecondaryInv4.MouseEnter += picSecondaryInv_MouseEnter;
				}
			}
		}

		internal virtual PictureBox picSecondaryInv8
		{
			[DebuggerNonUserCode]
			get
			{
				return _picSecondaryInv8;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_picSecondaryInv8 != null)
				{
					_picSecondaryInv8.MouseEnter -= picSecondaryInv_MouseEnter;
				}
				_picSecondaryInv8 = value;
				if (_picSecondaryInv8 != null)
				{
					_picSecondaryInv8.MouseEnter += picSecondaryInv_MouseEnter;
				}
			}
		}

		internal virtual PictureBox picSecondaryInv7
		{
			[DebuggerNonUserCode]
			get
			{
				return _picSecondaryInv7;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_picSecondaryInv7 != null)
				{
					_picSecondaryInv7.MouseEnter -= picSecondaryInv_MouseEnter;
				}
				_picSecondaryInv7 = value;
				if (_picSecondaryInv7 != null)
				{
					_picSecondaryInv7.MouseEnter += picSecondaryInv_MouseEnter;
				}
			}
		}

		internal virtual PictureBox picSecondaryInv6
		{
			[DebuggerNonUserCode]
			get
			{
				return _picSecondaryInv6;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_picSecondaryInv6 != null)
				{
					_picSecondaryInv6.MouseEnter -= picSecondaryInv_MouseEnter;
				}
				_picSecondaryInv6 = value;
				if (_picSecondaryInv6 != null)
				{
					_picSecondaryInv6.MouseEnter += picSecondaryInv_MouseEnter;
				}
			}
		}

		internal virtual PictureBox picSecondaryInv5
		{
			[DebuggerNonUserCode]
			get
			{
				return _picSecondaryInv5;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_picSecondaryInv5 != null)
				{
					_picSecondaryInv5.MouseEnter -= picSecondaryInv_MouseEnter;
				}
				_picSecondaryInv5 = value;
				if (_picSecondaryInv5 != null)
				{
					_picSecondaryInv5.MouseEnter += picSecondaryInv_MouseEnter;
				}
			}
		}

		internal virtual PictureBox picToolInv1
		{
			[DebuggerNonUserCode]
			get
			{
				return _picToolInv1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_picToolInv1 != null)
				{
					_picToolInv1.MouseEnter -= picToolInv_MouseEnter;
				}
				_picToolInv1 = value;
				if (_picToolInv1 != null)
				{
					_picToolInv1.MouseEnter += picToolInv_MouseEnter;
				}
			}
		}

		internal virtual PictureBox picToolInv7
		{
			[DebuggerNonUserCode]
			get
			{
				return _picToolInv7;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_picToolInv7 != null)
				{
					_picToolInv7.MouseEnter -= picToolInv_MouseEnter;
				}
				_picToolInv7 = value;
				if (_picToolInv7 != null)
				{
					_picToolInv7.MouseEnter += picToolInv_MouseEnter;
				}
			}
		}

		internal virtual PictureBox picToolInv6
		{
			[DebuggerNonUserCode]
			get
			{
				return _picToolInv6;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_picToolInv6 != null)
				{
					_picToolInv6.MouseEnter -= picToolInv_MouseEnter;
				}
				_picToolInv6 = value;
				if (_picToolInv6 != null)
				{
					_picToolInv6.MouseEnter += picToolInv_MouseEnter;
				}
			}
		}

		internal virtual PictureBox picToolInv5
		{
			[DebuggerNonUserCode]
			get
			{
				return _picToolInv5;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_picToolInv5 != null)
				{
					_picToolInv5.MouseEnter -= picToolInv_MouseEnter;
				}
				_picToolInv5 = value;
				if (_picToolInv5 != null)
				{
					_picToolInv5.MouseEnter += picToolInv_MouseEnter;
				}
			}
		}

		internal virtual PictureBox picToolInv4
		{
			[DebuggerNonUserCode]
			get
			{
				return _picToolInv4;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_picToolInv4 != null)
				{
					_picToolInv4.MouseEnter -= picToolInv_MouseEnter;
				}
				_picToolInv4 = value;
				if (_picToolInv4 != null)
				{
					_picToolInv4.MouseEnter += picToolInv_MouseEnter;
				}
			}
		}

		internal virtual PictureBox picToolInv2
		{
			[DebuggerNonUserCode]
			get
			{
				return _picToolInv2;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_picToolInv2 != null)
				{
					_picToolInv2.MouseEnter -= picToolInv_MouseEnter;
				}
				_picToolInv2 = value;
				if (_picToolInv2 != null)
				{
					_picToolInv2.MouseEnter += picToolInv_MouseEnter;
				}
			}
		}

		internal virtual PictureBox picToolInv3
		{
			[DebuggerNonUserCode]
			get
			{
				return _picToolInv3;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_picToolInv3 != null)
				{
					_picToolInv3.MouseEnter -= picToolInv_MouseEnter;
				}
				_picToolInv3 = value;
				if (_picToolInv3 != null)
				{
					_picToolInv3.MouseEnter += picToolInv_MouseEnter;
				}
			}
		}

		internal virtual PictureBox picBagInv1
		{
			[DebuggerNonUserCode]
			get
			{
				return _picBagInv1;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_picBagInv1 != null)
				{
					_picBagInv1.MouseEnter -= picBagInv_MouseEnter;
					_picBagInv1.MouseEnter -= picBagInv_MouseEnter;
				}
				_picBagInv1 = value;
				if (_picBagInv1 != null)
				{
					_picBagInv1.MouseEnter += picBagInv_MouseEnter;
					_picBagInv1.MouseEnter += picBagInv_MouseEnter;
				}
			}
		}

		internal virtual PictureBox picBagInv2
		{
			[DebuggerNonUserCode]
			get
			{
				return _picBagInv2;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_picBagInv2 != null)
				{
					_picBagInv2.MouseEnter -= picBagInv_MouseEnter;
				}
				_picBagInv2 = value;
				if (_picBagInv2 != null)
				{
					_picBagInv2.MouseEnter += picBagInv_MouseEnter;
				}
			}
		}

		internal virtual PictureBox picBagInv3
		{
			[DebuggerNonUserCode]
			get
			{
				return _picBagInv3;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_picBagInv3 != null)
				{
					_picBagInv3.MouseEnter -= picBagInv_MouseEnter;
				}
				_picBagInv3 = value;
				if (_picBagInv3 != null)
				{
					_picBagInv3.MouseEnter += picBagInv_MouseEnter;
				}
			}
		}

		internal virtual PictureBox picBagInv4
		{
			[DebuggerNonUserCode]
			get
			{
				return _picBagInv4;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_picBagInv4 != null)
				{
					_picBagInv4.MouseEnter -= picBagInv_MouseEnter;
				}
				_picBagInv4 = value;
				if (_picBagInv4 != null)
				{
					_picBagInv4.MouseEnter += picBagInv_MouseEnter;
				}
			}
		}

		internal virtual PictureBox picBagInv5
		{
			[DebuggerNonUserCode]
			get
			{
				return _picBagInv5;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_picBagInv5 != null)
				{
					_picBagInv5.MouseEnter -= picBagInv_MouseEnter;
				}
				_picBagInv5 = value;
				if (_picBagInv5 != null)
				{
					_picBagInv5.MouseEnter += picBagInv_MouseEnter;
				}
			}
		}

		internal virtual PictureBox picBagInv6
		{
			[DebuggerNonUserCode]
			get
			{
				return _picBagInv6;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_picBagInv6 != null)
				{
					_picBagInv6.MouseEnter -= picBagInv_MouseEnter;
				}
				_picBagInv6 = value;
				if (_picBagInv6 != null)
				{
					_picBagInv6.MouseEnter += picBagInv_MouseEnter;
				}
			}
		}

		internal virtual PictureBox picBagInv7
		{
			[DebuggerNonUserCode]
			get
			{
				return _picBagInv7;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_picBagInv7 != null)
				{
					_picBagInv7.MouseEnter -= picBagInv_MouseEnter;
				}
				_picBagInv7 = value;
				if (_picBagInv7 != null)
				{
					_picBagInv7.MouseEnter += picBagInv_MouseEnter;
				}
			}
		}

		internal virtual PictureBox picBagInv14
		{
			[DebuggerNonUserCode]
			get
			{
				return _picBagInv14;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_picBagInv14 != null)
				{
					_picBagInv14.MouseEnter -= picBagInv_MouseEnter;
				}
				_picBagInv14 = value;
				if (_picBagInv14 != null)
				{
					_picBagInv14.MouseEnter += picBagInv_MouseEnter;
				}
			}
		}

		internal virtual PictureBox picBagInv13
		{
			[DebuggerNonUserCode]
			get
			{
				return _picBagInv13;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_picBagInv13 != null)
				{
					_picBagInv13.MouseEnter -= picBagInv_MouseEnter;
				}
				_picBagInv13 = value;
				if (_picBagInv13 != null)
				{
					_picBagInv13.MouseEnter += picBagInv_MouseEnter;
				}
			}
		}

		internal virtual PictureBox picBagInv12
		{
			[DebuggerNonUserCode]
			get
			{
				return _picBagInv12;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_picBagInv12 != null)
				{
					_picBagInv12.MouseEnter -= picBagInv_MouseEnter;
				}
				_picBagInv12 = value;
				if (_picBagInv12 != null)
				{
					_picBagInv12.MouseEnter += picBagInv_MouseEnter;
				}
			}
		}

		internal virtual PictureBox picBagInv11
		{
			[DebuggerNonUserCode]
			get
			{
				return _picBagInv11;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_picBagInv11 != null)
				{
					_picBagInv11.MouseEnter -= picBagInv_MouseEnter;
				}
				_picBagInv11 = value;
				if (_picBagInv11 != null)
				{
					_picBagInv11.MouseEnter += picBagInv_MouseEnter;
				}
			}
		}

		internal virtual PictureBox picBagInv10
		{
			[DebuggerNonUserCode]
			get
			{
				return _picBagInv10;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_picBagInv10 != null)
				{
					_picBagInv10.MouseEnter -= picBagInv_MouseEnter;
				}
				_picBagInv10 = value;
				if (_picBagInv10 != null)
				{
					_picBagInv10.MouseEnter += picBagInv_MouseEnter;
				}
			}
		}

		internal virtual PictureBox picBagInv9
		{
			[DebuggerNonUserCode]
			get
			{
				return _picBagInv9;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_picBagInv9 != null)
				{
					_picBagInv9.MouseEnter -= picBagInv_MouseEnter;
				}
				_picBagInv9 = value;
				if (_picBagInv9 != null)
				{
					_picBagInv9.MouseEnter += picBagInv_MouseEnter;
				}
			}
		}

		internal virtual PictureBox picBagInv8
		{
			[DebuggerNonUserCode]
			get
			{
				return _picBagInv8;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_picBagInv8 != null)
				{
					_picBagInv8.MouseEnter -= picBagInv_MouseEnter;
				}
				_picBagInv8 = value;
				if (_picBagInv8 != null)
				{
					_picBagInv8.MouseEnter += picBagInv_MouseEnter;
				}
			}
		}

		internal virtual PictureBox picBagInv21
		{
			[DebuggerNonUserCode]
			get
			{
				return _picBagInv21;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_picBagInv21 != null)
				{
					_picBagInv21.MouseEnter -= picBagInv_MouseEnter;
				}
				_picBagInv21 = value;
				if (_picBagInv21 != null)
				{
					_picBagInv21.MouseEnter += picBagInv_MouseEnter;
				}
			}
		}

		internal virtual PictureBox picBagInv20
		{
			[DebuggerNonUserCode]
			get
			{
				return _picBagInv20;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_picBagInv20 != null)
				{
					_picBagInv20.MouseEnter -= picBagInv_MouseEnter;
				}
				_picBagInv20 = value;
				if (_picBagInv20 != null)
				{
					_picBagInv20.MouseEnter += picBagInv_MouseEnter;
				}
			}
		}

		internal virtual PictureBox picBagInv19
		{
			[DebuggerNonUserCode]
			get
			{
				return _picBagInv19;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_picBagInv19 != null)
				{
					_picBagInv19.MouseEnter -= picBagInv_MouseEnter;
				}
				_picBagInv19 = value;
				if (_picBagInv19 != null)
				{
					_picBagInv19.MouseEnter += picBagInv_MouseEnter;
				}
			}
		}

		internal virtual PictureBox picBagInv18
		{
			[DebuggerNonUserCode]
			get
			{
				return _picBagInv18;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_picBagInv18 != null)
				{
					_picBagInv18.MouseEnter -= picBagInv_MouseEnter;
				}
				_picBagInv18 = value;
				if (_picBagInv18 != null)
				{
					_picBagInv18.MouseEnter += picBagInv_MouseEnter;
				}
			}
		}

		internal virtual PictureBox picBagInv17
		{
			[DebuggerNonUserCode]
			get
			{
				return _picBagInv17;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_picBagInv17 != null)
				{
					_picBagInv17.MouseEnter -= picBagInv_MouseEnter;
				}
				_picBagInv17 = value;
				if (_picBagInv17 != null)
				{
					_picBagInv17.MouseEnter += picBagInv_MouseEnter;
				}
			}
		}

		internal virtual PictureBox picBagInv16
		{
			[DebuggerNonUserCode]
			get
			{
				return _picBagInv16;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_picBagInv16 != null)
				{
					_picBagInv16.MouseEnter -= picBagInv_MouseEnter;
				}
				_picBagInv16 = value;
				if (_picBagInv16 != null)
				{
					_picBagInv16.MouseEnter += picBagInv_MouseEnter;
				}
			}
		}

		internal virtual PictureBox picBagInv15
		{
			[DebuggerNonUserCode]
			get
			{
				return _picBagInv15;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_picBagInv15 != null)
				{
					_picBagInv15.MouseEnter -= picBagInv_MouseEnter;
				}
				_picBagInv15 = value;
				if (_picBagInv15 != null)
				{
					_picBagInv15.MouseEnter += picBagInv_MouseEnter;
				}
			}
		}

		internal virtual PictureBox picBagInv23
		{
			[DebuggerNonUserCode]
			get
			{
				return _picBagInv23;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_picBagInv23 != null)
				{
					_picBagInv23.MouseEnter -= picBagInv_MouseEnter;
				}
				_picBagInv23 = value;
				if (_picBagInv23 != null)
				{
					_picBagInv23.MouseEnter += picBagInv_MouseEnter;
				}
			}
		}

		internal virtual PictureBox picBagInv22
		{
			[DebuggerNonUserCode]
			get
			{
				return _picBagInv22;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_picBagInv22 != null)
				{
					_picBagInv22.MouseEnter -= picBagInv_MouseEnter;
				}
				_picBagInv22 = value;
				if (_picBagInv22 != null)
				{
					_picBagInv22.MouseEnter += picBagInv_MouseEnter;
				}
			}
		}

		internal virtual PictureBox picBagPrimary
		{
			[DebuggerNonUserCode]
			get
			{
				return _picBagPrimary;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_picBagPrimary != null)
				{
					_picBagPrimary.MouseEnter -= picBagPrimary_MouseEnter;
				}
				_picBagPrimary = value;
				if (_picBagPrimary != null)
				{
					_picBagPrimary.MouseEnter += picBagPrimary_MouseEnter;
				}
			}
		}

		internal virtual PictureBox picBagSecondary
		{
			[DebuggerNonUserCode]
			get
			{
				return _picBagSecondary;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_picBagSecondary != null)
				{
					_picBagSecondary.MouseEnter -= picBagSecondary_MouseEnter;
				}
				_picBagSecondary = value;
				if (_picBagSecondary != null)
				{
					_picBagSecondary.MouseEnter += picBagSecondary_MouseEnter;
				}
			}
		}

		internal virtual PictureBox picBagInv24
		{
			[DebuggerNonUserCode]
			get
			{
				return _picBagInv24;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				if (_picBagInv24 != null)
				{
					_picBagInv24.MouseEnter -= picBagInv_MouseEnter;
				}
				_picBagInv24 = value;
				if (_picBagInv24 != null)
				{
					_picBagInv24.MouseEnter += picBagInv_MouseEnter;
				}
			}
		}

		internal virtual Panel panel2
		{
			[DebuggerNonUserCode]
			get
			{
				return _panel2;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				_panel2 = value;
			}
		}

		internal virtual Panel panel3
		{
			[DebuggerNonUserCode]
			get
			{
				return _panel3;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				_panel3 = value;
			}
		}

		internal virtual Panel panel4
		{
			[DebuggerNonUserCode]
			get
			{
				return _panel4;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				_panel4 = value;
			}
		}

		internal virtual Panel panel5
		{
			[DebuggerNonUserCode]
			get
			{
				return _panel5;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				_panel5 = value;
			}
		}

		internal virtual Panel panel6
		{
			[DebuggerNonUserCode]
			get
			{
				return _panel6;
			}
			[MethodImpl(MethodImplOptions.Synchronized)]
			[DebuggerNonUserCode]
			set
			{
				_panel6 = value;
			}
		}

		public frmMain()
		{
			base.Load += frmMain_Load;
			opticsLeft = 2;
			opticsName = new string[3];
			primaryLeft = 10;
			secondaryLeft = 10;
			inventory1Left = 12;
			inventory1Name = new string[12];
			inventory1Size = new int[12];
			inventory2Left = 8;
			inventory2Name = new string[8];
			inventory2Size = new int[8];
			toolLeft = 12;
			toolName = new string[12];
			toolSize = new int[12];
			baginventoryLeft = 0;
			baginventoryName = new string[24];
			baginventorySize = new int[24];
			rINV = new List<string>();
			lINV = new List<string>();
			lbagINV = new List<string>();
			rbagINV = new List<string>();
			lbagINV2 = new List<string>();
			rbagINV2 = new List<string>();
			lbagINVvalues = new List<int>();
			rbagINVvalues = new List<int>();
			itemdelside = new int[28];
			MainInvGridLoc = new int[12];
			BagInvGridLoc = new int[24];
			SecInvGridLoc = new int[8];
			ToolGridLoc = new int[12];
			InitializeComponent();
		}

		[DebuggerNonUserCode]
		protected override void Dispose(bool disposing)
		{
			try
			{
				if (disposing && components != null)
				{
					components.Dispose();
				}
			}
			finally
			{
				base.Dispose(disposing);
			}
		}

		[System.Diagnostics.DebuggerStepThrough]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Loadout.frmMain));
			this.cmsRemove = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.cmsRemoveItem = new System.Windows.Forms.ToolStripMenuItem();
			this.groupResult = new System.Windows.Forms.GroupBox();
			this.textResult = new System.Windows.Forms.TextBox();
			this.groupPreview = new System.Windows.Forms.GroupBox();
			this.picPreview = new System.Windows.Forms.PictureBox();
			this.comboboxMEDICAL = new System.Windows.Forms.ComboBox();
			this.comboboxTOOLS = new System.Windows.Forms.ComboBox();
			this.comboboxPARTS = new System.Windows.Forms.ComboBox();
			this.comboboxRIFLE = new System.Windows.Forms.ComboBox();
			this.comboboxSUBMACHINE = new System.Windows.Forms.ComboBox();
			this.comboboxSHOTGUN = new System.Windows.Forms.ComboBox();
			this.comboboxSNIPER = new System.Windows.Forms.ComboBox();
			this.comboboxMACHINEGUN = new System.Windows.Forms.ComboBox();
			this.comboboxMISC = new System.Windows.Forms.ComboBox();
			this.btnAddInv = new System.Windows.Forms.Button();
			this.btnAddBag = new System.Windows.Forms.Button();
			this.comboboxFOOD = new System.Windows.Forms.ComboBox();
			this.comboboxPISTOL = new System.Windows.Forms.ComboBox();
			this.btnGenerateInv = new System.Windows.Forms.Button();
			this.btnGenerateBag = new System.Windows.Forms.Button();
			this.groupBackpack = new System.Windows.Forms.GroupBox();
			this.radio6 = new System.Windows.Forms.RadioButton();
			this.radio4 = new System.Windows.Forms.RadioButton();
			this.radio3 = new System.Windows.Forms.RadioButton();
			this.radio2 = new System.Windows.Forms.RadioButton();
			this.radio1 = new System.Windows.Forms.RadioButton();
			this.radio5 = new System.Windows.Forms.RadioButton();
			this.imgBags = new System.Windows.Forms.ImageList(this.components);
			this.imgPrimaryWeapons = new System.Windows.Forms.ImageList(this.components);
			this.imgSecondaryWeapons = new System.Windows.Forms.ImageList(this.components);
			this.imgPrimaryInv = new System.Windows.Forms.ImageList(this.components);
			this.imgSecondaryInv = new System.Windows.Forms.ImageList(this.components);
			this.imgTools = new System.Windows.Forms.ImageList(this.components);
			this.panel1 = new System.Windows.Forms.Panel();
			this.picOptics2 = new System.Windows.Forms.PictureBox();
			this.picOptics1 = new System.Windows.Forms.PictureBox();
			this.picPrimary = new System.Windows.Forms.PictureBox();
			this.picBackpack = new System.Windows.Forms.PictureBox();
			this.picSecondary = new System.Windows.Forms.PictureBox();
			this.picPrimaryInv1 = new System.Windows.Forms.PictureBox();
			this.picPrimaryInv2 = new System.Windows.Forms.PictureBox();
			this.picPrimaryInv4 = new System.Windows.Forms.PictureBox();
			this.picPrimaryInv3 = new System.Windows.Forms.PictureBox();
			this.picPrimaryInv7 = new System.Windows.Forms.PictureBox();
			this.picPrimaryInv8 = new System.Windows.Forms.PictureBox();
			this.picPrimaryInv6 = new System.Windows.Forms.PictureBox();
			this.picPrimaryInv5 = new System.Windows.Forms.PictureBox();
			this.picPrimaryInv11 = new System.Windows.Forms.PictureBox();
			this.picPrimaryInv12 = new System.Windows.Forms.PictureBox();
			this.picPrimaryInv10 = new System.Windows.Forms.PictureBox();
			this.picPrimaryInv9 = new System.Windows.Forms.PictureBox();
			this.picSecondaryInv1 = new System.Windows.Forms.PictureBox();
			this.picSecondaryInv2 = new System.Windows.Forms.PictureBox();
			this.picSecondaryInv3 = new System.Windows.Forms.PictureBox();
			this.picSecondaryInv4 = new System.Windows.Forms.PictureBox();
			this.picSecondaryInv8 = new System.Windows.Forms.PictureBox();
			this.picSecondaryInv7 = new System.Windows.Forms.PictureBox();
			this.picSecondaryInv6 = new System.Windows.Forms.PictureBox();
			this.picSecondaryInv5 = new System.Windows.Forms.PictureBox();
			this.picToolInv1 = new System.Windows.Forms.PictureBox();
			this.picToolInv7 = new System.Windows.Forms.PictureBox();
			this.picToolInv6 = new System.Windows.Forms.PictureBox();
			this.picToolInv5 = new System.Windows.Forms.PictureBox();
			this.picToolInv4 = new System.Windows.Forms.PictureBox();
			this.picToolInv2 = new System.Windows.Forms.PictureBox();
			this.picToolInv3 = new System.Windows.Forms.PictureBox();
			this.picBagInv1 = new System.Windows.Forms.PictureBox();
			this.picBagInv2 = new System.Windows.Forms.PictureBox();
			this.picBagInv3 = new System.Windows.Forms.PictureBox();
			this.picBagInv4 = new System.Windows.Forms.PictureBox();
			this.picBagInv5 = new System.Windows.Forms.PictureBox();
			this.picBagInv6 = new System.Windows.Forms.PictureBox();
			this.picBagInv7 = new System.Windows.Forms.PictureBox();
			this.picBagInv14 = new System.Windows.Forms.PictureBox();
			this.picBagInv13 = new System.Windows.Forms.PictureBox();
			this.picBagInv12 = new System.Windows.Forms.PictureBox();
			this.picBagInv11 = new System.Windows.Forms.PictureBox();
			this.picBagInv10 = new System.Windows.Forms.PictureBox();
			this.picBagInv9 = new System.Windows.Forms.PictureBox();
			this.picBagInv8 = new System.Windows.Forms.PictureBox();
			this.picBagInv21 = new System.Windows.Forms.PictureBox();
			this.picBagInv20 = new System.Windows.Forms.PictureBox();
			this.picBagInv19 = new System.Windows.Forms.PictureBox();
			this.picBagInv18 = new System.Windows.Forms.PictureBox();
			this.picBagInv17 = new System.Windows.Forms.PictureBox();
			this.picBagInv16 = new System.Windows.Forms.PictureBox();
			this.picBagInv15 = new System.Windows.Forms.PictureBox();
			this.picBagInv23 = new System.Windows.Forms.PictureBox();
			this.picBagInv22 = new System.Windows.Forms.PictureBox();
			this.picBagPrimary = new System.Windows.Forms.PictureBox();
			this.picBagSecondary = new System.Windows.Forms.PictureBox();
			this.picBagInv24 = new System.Windows.Forms.PictureBox();
			this.panel2 = new System.Windows.Forms.Panel();
			this.panel3 = new System.Windows.Forms.Panel();
			this.panel4 = new System.Windows.Forms.Panel();
			this.panel5 = new System.Windows.Forms.Panel();
			this.panel6 = new System.Windows.Forms.Panel();
			this.cmsRemove.SuspendLayout();
			this.groupResult.SuspendLayout();
			this.groupPreview.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.picPreview).BeginInit();
			this.groupBackpack.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.picOptics2).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.picOptics1).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.picPrimary).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.picBackpack).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.picSecondary).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.picPrimaryInv1).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.picPrimaryInv2).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.picPrimaryInv4).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.picPrimaryInv3).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.picPrimaryInv7).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.picPrimaryInv8).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.picPrimaryInv6).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.picPrimaryInv5).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.picPrimaryInv11).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.picPrimaryInv12).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.picPrimaryInv10).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.picPrimaryInv9).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.picSecondaryInv1).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.picSecondaryInv2).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.picSecondaryInv3).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.picSecondaryInv4).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.picSecondaryInv8).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.picSecondaryInv7).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.picSecondaryInv6).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.picSecondaryInv5).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.picToolInv1).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.picToolInv7).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.picToolInv6).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.picToolInv5).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.picToolInv4).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.picToolInv2).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.picToolInv3).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.picBagInv1).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.picBagInv2).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.picBagInv3).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.picBagInv4).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.picBagInv5).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.picBagInv6).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.picBagInv7).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.picBagInv14).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.picBagInv13).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.picBagInv12).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.picBagInv11).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.picBagInv10).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.picBagInv9).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.picBagInv8).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.picBagInv21).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.picBagInv20).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.picBagInv19).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.picBagInv18).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.picBagInv17).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.picBagInv16).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.picBagInv15).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.picBagInv23).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.picBagInv22).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.picBagPrimary).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.picBagSecondary).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.picBagInv24).BeginInit();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel4.SuspendLayout();
			this.panel5.SuspendLayout();
			this.panel6.SuspendLayout();
			this.SuspendLayout();
			this.cmsRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.cmsRemove.Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { this.cmsRemoveItem });
			this.cmsRemove.Name = "ContextMenuStrip1";
			this.cmsRemove.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
			this.cmsRemove.ShowImageMargin = false;
			System.Windows.Forms.ContextMenuStrip contextMenuStrip = this.cmsRemove;
			System.Drawing.Size size = new System.Drawing.Size(123, 26);
			contextMenuStrip.Size = size;
			this.cmsRemoveItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.cmsRemoveItem.Name = "cmsRemoveItem";
			System.Windows.Forms.ToolStripMenuItem toolStripMenuItem = this.cmsRemoveItem;
			size = new System.Drawing.Size(122, 22);
			toolStripMenuItem.Size = size;
			this.cmsRemoveItem.Text = "Remove Item";
			this.groupResult.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom;
			this.groupResult.BackColor = System.Drawing.Color.Transparent;
			this.groupResult.Controls.Add(this.textResult);
			this.groupResult.Font = new System.Drawing.Font("Bookman Old Style", 9.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.groupResult.ForeColor = System.Drawing.Color.DarkGoldenrod;
			System.Windows.Forms.GroupBox groupBox = this.groupResult;
			System.Drawing.Point location = new System.Drawing.Point(10, 393);
			groupBox.Location = location;
			this.groupResult.Name = "groupResult";
			System.Windows.Forms.GroupBox groupBox2 = this.groupResult;
			size = new System.Drawing.Size(347, 112);
			groupBox2.Size = size;
			this.groupResult.TabIndex = 61;
			this.groupResult.TabStop = false;
			this.groupResult.Text = "SQL Code";
			this.textResult.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.textResult.BackColor = System.Drawing.SystemColors.Window;
			this.textResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			System.Windows.Forms.TextBox textBox = this.textResult;
			location = new System.Drawing.Point(12, 26);
			textBox.Location = location;
			this.textResult.Multiline = true;
			this.textResult.Name = "textResult";
			this.textResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			System.Windows.Forms.TextBox textBox2 = this.textResult;
			size = new System.Drawing.Size(322, 73);
			textBox2.Size = size;
			this.textResult.TabIndex = 0;
			this.textResult.Text = "[[],[]]";
			this.groupPreview.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.groupPreview.BackColor = System.Drawing.Color.Transparent;
			this.groupPreview.Controls.Add(this.picPreview);
			this.groupPreview.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.groupPreview.ForeColor = System.Drawing.Color.DarkGoldenrod;
			System.Windows.Forms.GroupBox groupBox3 = this.groupPreview;
			location = new System.Drawing.Point(48, 28);
			groupBox3.Location = location;
			this.groupPreview.Name = "groupPreview";
			System.Windows.Forms.GroupBox groupBox4 = this.groupPreview;
			size = new System.Drawing.Size(273, 123);
			groupBox4.Size = size;
			this.groupPreview.TabIndex = 63;
			this.groupPreview.TabStop = false;
			this.groupPreview.Text = "Item Viewer";
			this.picPreview.Dock = System.Windows.Forms.DockStyle.Fill;
			this.picPreview.InitialImage = null;
			System.Windows.Forms.PictureBox pictureBox = this.picPreview;
			location = new System.Drawing.Point(3, 16);
			pictureBox.Location = location;
			this.picPreview.Name = "picPreview";
			System.Windows.Forms.PictureBox pictureBox2 = this.picPreview;
			size = new System.Drawing.Size(267, 104);
			pictureBox2.Size = size;
			this.picPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.picPreview.TabIndex = 0;
			this.picPreview.TabStop = false;
			this.comboboxMEDICAL.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.comboboxMEDICAL.FormattingEnabled = true;
			this.comboboxMEDICAL.Items.AddRange(new object[7] { "Bandage", "Pain Killers", "Morphine", "Epinephrine", "Antibiotic", "Blood Bag", "Heat Pack" });
			System.Windows.Forms.ComboBox comboBox = this.comboboxMEDICAL;
			location = new System.Drawing.Point(139, 0);
			comboBox.Location = location;
			this.comboboxMEDICAL.Name = "comboboxMEDICAL";
			System.Windows.Forms.ComboBox comboBox2 = this.comboboxMEDICAL;
			size = new System.Drawing.Size(134, 21);
			comboBox2.Size = size;
			this.comboboxMEDICAL.TabIndex = 2;
			this.comboboxMEDICAL.Text = "Medical:";
			this.comboboxTOOLS.FormattingEnabled = true;
			this.comboboxTOOLS.Items.AddRange(new object[14]
			{
				"Binocular", "Range Finder", "Night Vision Goggles", "GPS", "Map", "Compass", "Watch", "Flashlight", "Military Flash Light", "Knife",
				"Hatchet", "Matchbox", "Etrench Tool", "Tool Box"
			});
			System.Windows.Forms.ComboBox comboBox3 = this.comboboxTOOLS;
			location = new System.Drawing.Point(0, 27);
			comboBox3.Location = location;
			this.comboboxTOOLS.Name = "comboboxTOOLS";
			System.Windows.Forms.ComboBox comboBox4 = this.comboboxTOOLS;
			size = new System.Drawing.Size(135, 21);
			comboBox4.Size = size;
			this.comboboxTOOLS.TabIndex = 3;
			this.comboboxTOOLS.Text = "Tools and Accessories:";
			this.comboboxPARTS.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.comboboxPARTS.FormattingEnabled = true;
			this.comboboxPARTS.Items.AddRange(new object[8] { "Wood Pile", "Wheel", "Fuel Tank", "Glass", "Engine", "Scrap Metal", "Helicopter Rotor", "Jerry Can" });
			System.Windows.Forms.ComboBox comboBox5 = this.comboboxPARTS;
			location = new System.Drawing.Point(0, 54);
			comboBox5.Location = location;
			this.comboboxPARTS.Name = "comboboxPARTS";
			System.Windows.Forms.ComboBox comboBox6 = this.comboboxPARTS;
			size = new System.Drawing.Size(272, 21);
			comboBox6.Size = size;
			this.comboboxPARTS.TabIndex = 4;
			this.comboboxPARTS.Text = "Parts:";
			this.comboboxRIFLE.FormattingEnabled = true;
			this.comboboxRIFLE.Items.AddRange(new object[37]
			{
				"AK-74", "AKM", "AKS-74 Kobra", "AKS-74U", "FN FAL", "FN FAL AN/PVS-4", "L85A2 AWS", "Lee Enfield", "M16A2", "M16A2 M203",
				"M16A2 ACOG", "M4A1", "M4A1 CCO Silenced", "M4A1 CCO", "M4A3 CCO", "Cross Bow", "", "30 Round AK-74 Magazine", "30 Round AKM Magazine", "30 Round AKS-74 Kobra Magazine",
				"30 Round AKS-74U Magazine", "30 Round FN FAL Magazine", "30 Round FN FAL AN/PVS-4 Magazine", "30 Round L85A2 AWS Magazine", "10 Round Lee Enfield Magazine", "30 Round M16A2 Magazine", "30 Round M16A4 ACOG Magazine", "30 Round M4A1 Magazine", "30 Round M4A1 CCO Silenced Magazine", "30 Round M4A1 CCO Magazine",
				"30 Round M4A1 Holo Magazine", "30 Round M4A3 CCO  Magazine", "1 Round Steel Bolt Crossbow Magazine", "1 Round M203 HE Magazine", "1 Round M203 Smoke Magazine", "1 Round M203 Flare White Magazine", "1 Round M203 Flare Green Magazine"
			});
			System.Windows.Forms.ComboBox comboBox7 = this.comboboxRIFLE;
			location = new System.Drawing.Point(0, 108);
			comboBox7.Location = location;
			this.comboboxRIFLE.Name = "comboboxRIFLE";
			System.Windows.Forms.ComboBox comboBox8 = this.comboboxRIFLE;
			size = new System.Drawing.Size(135, 21);
			comboBox8.Size = size;
			this.comboboxRIFLE.TabIndex = 6;
			this.comboboxRIFLE.Text = "Assault Rifles:";
			this.comboboxSUBMACHINE.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.comboboxSUBMACHINE.FormattingEnabled = true;
			this.comboboxSUBMACHINE.Items.AddRange(new object[7] { "Bizon PP-19 Silenced", "MP5A5", "MP5 Silenced", "", "64 Round Bizon PP-19 SD Magazine", "30 Round MP5A5 Magazine", "30 Round  MP5 Silenced Magazine" });
			System.Windows.Forms.ComboBox comboBox9 = this.comboboxSUBMACHINE;
			location = new System.Drawing.Point(139, 135);
			comboBox9.Location = location;
			this.comboboxSUBMACHINE.Name = "comboboxSUBMACHINE";
			System.Windows.Forms.ComboBox comboBox10 = this.comboboxSUBMACHINE;
			size = new System.Drawing.Size(133, 21);
			comboBox10.Size = size;
			this.comboboxSUBMACHINE.TabIndex = 7;
			this.comboboxSUBMACHINE.Text = "Sub Machine Guns:";
			this.comboboxSHOTGUN.FormattingEnabled = true;
			this.comboboxSHOTGUN.Items.AddRange(new object[8] { "Double Barrel Shotgun", "M1014", "Remington 870", "Winchester 1866", "", "8 Round Shotgun Slugs", "8 Round Shotgun Pellets", "15 Round 1866 Shotgun Slugs" });
			System.Windows.Forms.ComboBox comboBox11 = this.comboboxSHOTGUN;
			location = new System.Drawing.Point(0, 135);
			comboBox11.Location = location;
			this.comboboxSHOTGUN.Name = "comboboxSHOTGUN";
			System.Windows.Forms.ComboBox comboBox12 = this.comboboxSHOTGUN;
			size = new System.Drawing.Size(135, 21);
			comboBox12.Size = size;
			this.comboboxSHOTGUN.TabIndex = 8;
			this.comboboxSHOTGUN.Text = "Shotguns:";
			this.comboboxSNIPER.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.comboboxSNIPER.FormattingEnabled = true;
			this.comboboxSNIPER.Items.AddRange(new object[15]
			{
				"AS50", "CZ50", "DMR", "M14 AIM", "M24", "M107", "SVD Camo", "", "10 Round AS50 Magazine", "5 Round CZ550 Magazine",
				"20 Round DMR Magazine", "20 Round M14 AIM Magazine", "5 Round M24 Magazine", "10 Round M107 Magazine", "10 Round SVD Camo Magazine"
			});
			System.Windows.Forms.ComboBox comboBox13 = this.comboboxSNIPER;
			location = new System.Drawing.Point(139, 81);
			comboBox13.Location = location;
			this.comboboxSNIPER.Name = "comboboxSNIPER";
			System.Windows.Forms.ComboBox comboBox14 = this.comboboxSNIPER;
			size = new System.Drawing.Size(133, 21);
			comboBox14.Size = size;
			this.comboboxSNIPER.TabIndex = 9;
			this.comboboxSNIPER.Text = "Sniper Rifles:";
			this.comboboxMACHINEGUN.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.comboboxMACHINEGUN.FormattingEnabled = true;
			this.comboboxMACHINEGUN.Items.AddRange(new object[7] { "M240", "M249 SAW", "Mk 48 Mod 0", "", "100 Round M240 Magazine", "200 Round M249 SAW Magazine", "100 Round MK 48 Mod 0 Magazine" });
			System.Windows.Forms.ComboBox comboBox15 = this.comboboxMACHINEGUN;
			location = new System.Drawing.Point(139, 108);
			comboBox15.Location = location;
			this.comboboxMACHINEGUN.Name = "comboboxMACHINEGUN";
			System.Windows.Forms.ComboBox comboBox16 = this.comboboxMACHINEGUN;
			size = new System.Drawing.Size(133, 21);
			comboBox16.Size = size;
			this.comboboxMACHINEGUN.TabIndex = 10;
			this.comboboxMACHINEGUN.Text = "Machine Guns:";
			this.comboboxMISC.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.comboboxMISC.FormattingEnabled = true;
			this.comboboxMISC.Items.AddRange(new object[14]
			{
				"Tent", "Soldier Clothing", "Survivor Clothing", "Camo Clothing", "Ghillie Suit Clothing", "Satchel Charge", "M67 Frag Grenade", "Road Flare", "Chem Light Green", "Chem Light Blue",
				"Chem Light Red", "Sand Bag", "Tank Trap", "Wire"
			});
			System.Windows.Forms.ComboBox comboBox17 = this.comboboxMISC;
			location = new System.Drawing.Point(139, 27);
			comboBox17.Location = location;
			this.comboboxMISC.Name = "comboboxMISC";
			System.Windows.Forms.ComboBox comboBox18 = this.comboboxMISC;
			size = new System.Drawing.Size(133, 21);
			comboBox18.Size = size;
			this.comboboxMISC.TabIndex = 11;
			this.comboboxMISC.Text = "Clothing and Misc:";
			this.btnAddInv.BackColor = System.Drawing.Color.DarkGoldenrod;
			this.btnAddInv.FlatAppearance.BorderSize = 3;
			this.btnAddInv.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			System.Windows.Forms.Button button = this.btnAddInv;
			location = new System.Drawing.Point(0, 171);
			button.Location = location;
			this.btnAddInv.Name = "btnAddInv";
			System.Windows.Forms.Button button2 = this.btnAddInv;
			size = new System.Drawing.Size(135, 29);
			button2.Size = size;
			this.btnAddInv.TabIndex = 73;
			this.btnAddInv.Text = "Add to Inventory";
			this.btnAddInv.UseVisualStyleBackColor = false;
			this.btnAddBag.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.btnAddBag.BackColor = System.Drawing.Color.DarkGoldenrod;
			this.btnAddBag.FlatAppearance.BorderSize = 3;
			this.btnAddBag.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			System.Windows.Forms.Button button3 = this.btnAddBag;
			location = new System.Drawing.Point(139, 171);
			button3.Location = location;
			this.btnAddBag.Name = "btnAddBag";
			System.Windows.Forms.Button button4 = this.btnAddBag;
			size = new System.Drawing.Size(134, 29);
			button4.Size = size;
			this.btnAddBag.TabIndex = 74;
			this.btnAddBag.Text = "Add to Bag";
			this.btnAddBag.UseVisualStyleBackColor = false;
			this.comboboxFOOD.FormattingEnabled = true;
			this.comboboxFOOD.Items.AddRange(new object[8] { "Raw Steak", "Cooked Steak", "Baked Beans", "Sardines", "Pasta", "Coke", "Pepsi", "Water Bottle" });
			System.Windows.Forms.ComboBox comboBox19 = this.comboboxFOOD;
			location = new System.Drawing.Point(0, 0);
			comboBox19.Location = location;
			this.comboboxFOOD.Name = "comboboxFOOD";
			System.Windows.Forms.ComboBox comboBox20 = this.comboboxFOOD;
			size = new System.Drawing.Size(135, 21);
			comboBox20.Size = size;
			this.comboboxFOOD.TabIndex = 1;
			this.comboboxFOOD.Text = "Food:";
			this.comboboxPISTOL.FormattingEnabled = true;
			this.comboboxPISTOL.Items.AddRange(new object[15]
			{
				"G17", "M9", "M9 Silenced", "Makarov PM", "M1911", "Uzi", "Revolver", "", "G17 Pistol Ammo", "M9 Pistol Ammo",
				"M9 Silenced Pistol Ammo", "Makarov Pistol Ammo", "M1911 Pistol Ammo", "Uzi Pistol Ammo", "Revolver Pistol Ammo"
			});
			System.Windows.Forms.ComboBox comboBox21 = this.comboboxPISTOL;
			location = new System.Drawing.Point(0, 81);
			comboBox21.Location = location;
			this.comboboxPISTOL.Name = "comboboxPISTOL";
			System.Windows.Forms.ComboBox comboBox22 = this.comboboxPISTOL;
			size = new System.Drawing.Size(135, 21);
			comboBox22.Size = size;
			this.comboboxPISTOL.TabIndex = 5;
			this.comboboxPISTOL.Text = "Pistols:";
			this.btnGenerateInv.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
			this.btnGenerateInv.BackColor = System.Drawing.Color.DarkGoldenrod;
			this.btnGenerateInv.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			System.Windows.Forms.Button button5 = this.btnGenerateInv;
			location = new System.Drawing.Point(10, 511);
			button5.Location = location;
			this.btnGenerateInv.Name = "btnGenerateInv";
			System.Windows.Forms.Button button6 = this.btnGenerateInv;
			size = new System.Drawing.Size(170, 32);
			button6.Size = size;
			this.btnGenerateInv.TabIndex = 104;
			this.btnGenerateInv.Text = "Generate Inventory SQL";
			this.btnGenerateInv.UseVisualStyleBackColor = false;
			this.btnGenerateBag.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			this.btnGenerateBag.BackColor = System.Drawing.Color.DarkGoldenrod;
			this.btnGenerateBag.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			System.Windows.Forms.Button button7 = this.btnGenerateBag;
			location = new System.Drawing.Point(187, 511);
			button7.Location = location;
			this.btnGenerateBag.Name = "btnGenerateBag";
			System.Windows.Forms.Button button8 = this.btnGenerateBag;
			size = new System.Drawing.Size(170, 32);
			button8.Size = size;
			this.btnGenerateBag.TabIndex = 105;
			this.btnGenerateBag.Text = "Generate Bag SQL";
			this.btnGenerateBag.UseVisualStyleBackColor = false;
			this.groupBackpack.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.groupBackpack.BackColor = System.Drawing.Color.Transparent;
			this.groupBackpack.Controls.Add(this.radio6);
			this.groupBackpack.Controls.Add(this.radio4);
			this.groupBackpack.Controls.Add(this.radio3);
			this.groupBackpack.Controls.Add(this.radio2);
			this.groupBackpack.Controls.Add(this.radio1);
			this.groupBackpack.Controls.Add(this.radio5);
			this.groupBackpack.Font = new System.Drawing.Font("Arial", 8.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			this.groupBackpack.ForeColor = System.Drawing.Color.DarkGoldenrod;
			System.Windows.Forms.GroupBox groupBox5 = this.groupBackpack;
			location = new System.Drawing.Point(750, 393);
			groupBox5.Location = location;
			this.groupBackpack.Name = "groupBackpack";
			System.Windows.Forms.GroupBox groupBox6 = this.groupBackpack;
			size = new System.Drawing.Size(347, 112);
			groupBox6.Size = size;
			this.groupBackpack.TabIndex = 106;
			this.groupBackpack.TabStop = false;
			this.groupBackpack.Text = "Bag Selection";
			this.radio6.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.radio6.AutoSize = true;
			System.Windows.Forms.RadioButton radioButton = this.radio6;
			location = new System.Drawing.Point(174, 80);
			radioButton.Location = location;
			this.radio6.Name = "radio6";
			System.Windows.Forms.RadioButton radioButton2 = this.radio6;
			size = new System.Drawing.Size(119, 18);
			radioButton2.Size = size;
			this.radio6.TabIndex = 5;
			this.radio6.Text = "Coyote Backpack";
			this.radio6.UseVisualStyleBackColor = true;
			this.radio4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.radio4.AutoSize = true;
			System.Windows.Forms.RadioButton radioButton3 = this.radio4;
			location = new System.Drawing.Point(174, 24);
			radioButton3.Location = location;
			this.radio4.Name = "radio4";
			System.Windows.Forms.RadioButton radioButton4 = this.radio4;
			size = new System.Drawing.Size(114, 18);
			radioButton4.Size = size;
			this.radio4.TabIndex = 4;
			this.radio4.Text = "Czech Backpack";
			this.radio4.UseVisualStyleBackColor = true;
			this.radio3.AutoSize = true;
			System.Windows.Forms.RadioButton radioButton5 = this.radio3;
			location = new System.Drawing.Point(23, 80);
			radioButton5.Location = location;
			this.radio3.Name = "radio3";
			System.Windows.Forms.RadioButton radioButton6 = this.radio3;
			size = new System.Drawing.Size(96, 18);
			radioButton6.Size = size;
			this.radio3.TabIndex = 3;
			this.radio3.Text = "Assault Pack";
			this.radio3.UseVisualStyleBackColor = true;
			this.radio2.AutoSize = true;
			System.Windows.Forms.RadioButton radioButton7 = this.radio2;
			location = new System.Drawing.Point(23, 52);
			radioButton7.Location = location;
			this.radio2.Name = "radio2";
			System.Windows.Forms.RadioButton radioButton8 = this.radio2;
			size = new System.Drawing.Size(86, 18);
			radioButton8.Size = size;
			this.radio2.TabIndex = 2;
			this.radio2.Text = "Patrol Pack";
			this.radio2.UseVisualStyleBackColor = true;
			this.radio1.AutoSize = true;
			this.radio1.Checked = true;
			System.Windows.Forms.RadioButton radioButton9 = this.radio1;
			location = new System.Drawing.Point(23, 24);
			radioButton9.Location = location;
			this.radio1.Name = "radio1";
			System.Windows.Forms.RadioButton radioButton10 = this.radio1;
			size = new System.Drawing.Size(62, 18);
			radioButton10.Size = size;
			this.radio1.TabIndex = 1;
			this.radio1.TabStop = true;
			this.radio1.Text = "No Bag";
			this.radio1.UseVisualStyleBackColor = true;
			this.radio5.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.radio5.AutoSize = true;
			System.Windows.Forms.RadioButton radioButton11 = this.radio5;
			location = new System.Drawing.Point(174, 52);
			radioButton11.Location = location;
			this.radio5.Name = "radio5";
			System.Windows.Forms.RadioButton radioButton12 = this.radio5;
			size = new System.Drawing.Size(112, 18);
			radioButton12.Size = size;
			this.radio5.TabIndex = 0;
			this.radio5.Text = "ALICE Backpack";
			this.radio5.UseVisualStyleBackColor = true;
			this.imgBags.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("imgBags.ImageStream");
			this.imgBags.TransparentColor = System.Drawing.Color.Transparent;
			this.imgBags.Images.SetKeyName(0, "bag-vestpouch.png");
			this.imgBags.Images.SetKeyName(1, "DZ_Patrol_Pack_EP1.png");
			this.imgBags.Images.SetKeyName(2, "bag-assaultpack.png");
			this.imgBags.Images.SetKeyName(3, "DZ_CivilBackPack_EP1.png");
			this.imgBags.Images.SetKeyName(4, "DZ_ALICE_Pack_EP1.png");
			this.imgBags.Images.SetKeyName(5, "DZ_Backpack_EP1.png");
			this.imgPrimaryWeapons.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("imgPrimaryWeapons.ImageStream");
			this.imgPrimaryWeapons.TransparentColor = System.Drawing.Color.Transparent;
			this.imgPrimaryWeapons.Images.SetKeyName(0, "1_AK_74.png");
			this.imgPrimaryWeapons.Images.SetKeyName(1, "2_AK_47_M.png");
			this.imgPrimaryWeapons.Images.SetKeyName(2, "3_AKS_74_kobra.png");
			this.imgPrimaryWeapons.Images.SetKeyName(3, "4_AKS_74_U.png");
			this.imgPrimaryWeapons.Images.SetKeyName(4, "5_FN_FAL.png");
			this.imgPrimaryWeapons.Images.SetKeyName(5, "6_FN_FAL_ANPVS4.png");
			this.imgPrimaryWeapons.Images.SetKeyName(6, "7_BAF_L85A2_RIS_CWS.png");
			this.imgPrimaryWeapons.Images.SetKeyName(7, "8_LeeEnfield.png");
			this.imgPrimaryWeapons.Images.SetKeyName(8, "9_M16A2.png");
			this.imgPrimaryWeapons.Images.SetKeyName(9, "10_M16A2GL.png");
			this.imgPrimaryWeapons.Images.SetKeyName(10, "11_m16a4_acg.png");
			this.imgPrimaryWeapons.Images.SetKeyName(11, "12_M4A1.png");
			this.imgPrimaryWeapons.Images.SetKeyName(12, "13_M4A1_AIM_SD_camo.png");
			this.imgPrimaryWeapons.Images.SetKeyName(13, "14_M4A1_Aim.png");
			this.imgPrimaryWeapons.Images.SetKeyName(14, "15_M4A3_CCO_EP1.png");
			this.imgPrimaryWeapons.Images.SetKeyName(15, "16_crossbow.png");
			this.imgPrimaryWeapons.Images.SetKeyName(16, "17_bizon_silenced.png");
			this.imgPrimaryWeapons.Images.SetKeyName(17, "18_MP5A5.png");
			this.imgPrimaryWeapons.Images.SetKeyName(18, "19_MP5SD.png");
			this.imgPrimaryWeapons.Images.SetKeyName(19, "20_mr43.png");
			this.imgPrimaryWeapons.Images.SetKeyName(20, "21_M1014.png");
			this.imgPrimaryWeapons.Images.SetKeyName(21, "22_remington870_lamp.png");
			this.imgPrimaryWeapons.Images.SetKeyName(22, "23_winchester1866.png");
			this.imgPrimaryWeapons.Images.SetKeyName(23, "24_BAF_AS50_scoped.png");
			this.imgPrimaryWeapons.Images.SetKeyName(24, "25_huntingrifle.png");
			this.imgPrimaryWeapons.Images.SetKeyName(25, "26_DMR.png");
			this.imgPrimaryWeapons.Images.SetKeyName(26, "27_M14_EP1.png");
			this.imgPrimaryWeapons.Images.SetKeyName(27, "28_M24.png");
			this.imgPrimaryWeapons.Images.SetKeyName(28, "29_m107.png");
			this.imgPrimaryWeapons.Images.SetKeyName(29, "30_SVD_CAMO.png");
			this.imgPrimaryWeapons.Images.SetKeyName(30, "31_M240.png");
			this.imgPrimaryWeapons.Images.SetKeyName(31, "32_M249.png");
			this.imgPrimaryWeapons.Images.SetKeyName(32, "33_Mk_48.png");
			this.imgSecondaryWeapons.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("imgSecondaryWeapons.ImageStream");
			this.imgSecondaryWeapons.TransparentColor = System.Drawing.Color.Transparent;
			this.imgSecondaryWeapons.Images.SetKeyName(0, "0_g17.png");
			this.imgSecondaryWeapons.Images.SetKeyName(1, "1_m9.png");
			this.imgSecondaryWeapons.Images.SetKeyName(2, "2_m9sd.png");
			this.imgSecondaryWeapons.Images.SetKeyName(3, "4_makarov.png");
			this.imgSecondaryWeapons.Images.SetKeyName(4, "5_m1911.png");
			this.imgSecondaryWeapons.Images.SetKeyName(5, "3_pdw.png");
			this.imgSecondaryWeapons.Images.SetKeyName(6, "6_revolver.png");
			this.imgPrimaryInv.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("imgPrimaryInv.ImageStream");
			this.imgPrimaryInv.TransparentColor = System.Drawing.Color.Transparent;
			this.imgPrimaryInv.Images.SetKeyName(0, "0_FoodSteakRaw.png");
			this.imgPrimaryInv.Images.SetKeyName(1, "1_FoodSteakCooked.png");
			this.imgPrimaryInv.Images.SetKeyName(2, "2_FoodCanBakedBeans.png");
			this.imgPrimaryInv.Images.SetKeyName(3, "3_FoodCanSardines.png");
			this.imgPrimaryInv.Images.SetKeyName(4, "4_FoodCanPasta.png");
			this.imgPrimaryInv.Images.SetKeyName(5, "5_itemsodacoke.png");
			this.imgPrimaryInv.Images.SetKeyName(6, "6_itemsodapepsi.png");
			this.imgPrimaryInv.Images.SetKeyName(7, "7_itemwaterbottle.png");
			this.imgPrimaryInv.Images.SetKeyName(8, "8_itempainkiller.png");
			this.imgPrimaryInv.Images.SetKeyName(9, "9_itemmorphine.png");
			this.imgPrimaryInv.Images.SetKeyName(10, "10_itemepinephrine.png");
			this.imgPrimaryInv.Images.SetKeyName(11, "11_itemantibiotic.png");
			this.imgPrimaryInv.Images.SetKeyName(12, "12_itembloodbag.png");
			this.imgPrimaryInv.Images.SetKeyName(13, "13_itemheatpack.png");
			this.imgPrimaryInv.Images.SetKeyName(14, "14_partwoodpile.png");
			this.imgPrimaryInv.Images.SetKeyName(15, "15_partwheel.png");
			this.imgPrimaryInv.Images.SetKeyName(16, "16_partfueltank.png");
			this.imgPrimaryInv.Images.SetKeyName(17, "17_partglass.png");
			this.imgPrimaryInv.Images.SetKeyName(18, "18_partengine.png");
			this.imgPrimaryInv.Images.SetKeyName(19, "19_partgeneric.png");
			this.imgPrimaryInv.Images.SetKeyName(20, "20_partvrotor.png");
			this.imgPrimaryInv.Images.SetKeyName(21, "21_itemjerrycan.png");
			this.imgPrimaryInv.Images.SetKeyName(22, "22_30Rnd_545x39_AK.png");
			this.imgPrimaryInv.Images.SetKeyName(23, "23_30Rnd_762x39_AK47.png");
			this.imgPrimaryInv.Images.SetKeyName(24, "24_30Rnd_545x39_AK.png");
			this.imgPrimaryInv.Images.SetKeyName(25, "25_30Rnd_545x39_AK.png");
			this.imgPrimaryInv.Images.SetKeyName(26, "26_20Rnd_762x51_FNFAL.png");
			this.imgPrimaryInv.Images.SetKeyName(27, "27_20Rnd_762x51_FNFAL.png");
			this.imgPrimaryInv.Images.SetKeyName(28, "28_30Rnd_556x45_Stanag.png");
			this.imgPrimaryInv.Images.SetKeyName(29, "29_10x_303.png");
			this.imgPrimaryInv.Images.SetKeyName(30, "30_28_30Rnd_556x45_Stanag.png");
			this.imgPrimaryInv.Images.SetKeyName(31, "31_28_30Rnd_556x45_Stanag.png");
			this.imgPrimaryInv.Images.SetKeyName(32, "32_30Rnd_556x45_Stanag.png");
			this.imgPrimaryInv.Images.SetKeyName(33, "33_30Rnd_556x45_StanagSD.png");
			this.imgPrimaryInv.Images.SetKeyName(34, "34_30Rnd_556x45_Stanag.png");
			this.imgPrimaryInv.Images.SetKeyName(35, "35_30Rnd_556x45_Stanag.png");
			this.imgPrimaryInv.Images.SetKeyName(36, "36_30Rnd_556x45_Stanag - Copy.png");
			this.imgPrimaryInv.Images.SetKeyName(37, "37_boltsteel.png");
			this.imgPrimaryInv.Images.SetKeyName(38, "38_64Rnd_9x19_SD_Bizon.png");
			this.imgPrimaryInv.Images.SetKeyName(39, "39_30Rnd_9x19_MP5.png");
			this.imgPrimaryInv.Images.SetKeyName(40, "40_30Rnd_9x19_MP5SD.png");
			this.imgPrimaryInv.Images.SetKeyName(41, "41_8Rnd_B_Beneli_74Slug.png");
			this.imgPrimaryInv.Images.SetKeyName(42, "42_8Rnd_B_Beneli_Pellets.png");
			this.imgPrimaryInv.Images.SetKeyName(43, "43_15Rnd_W1866_Slug.png");
			this.imgPrimaryInv.Images.SetKeyName(44, "44_10Rnd_127x99_m107.png");
			this.imgPrimaryInv.Images.SetKeyName(45, "45_5x_22_LR_17_HMR.png");
			this.imgPrimaryInv.Images.SetKeyName(46, "46_20Rnd_762x51_DMR.png");
			this.imgPrimaryInv.Images.SetKeyName(47, "47_20Rnd_762x51_DMR.png");
			this.imgPrimaryInv.Images.SetKeyName(48, "48_5Rnd_762x51_M24.png");
			this.imgPrimaryInv.Images.SetKeyName(49, "49_10Rnd_127x99_m107.png");
			this.imgPrimaryInv.Images.SetKeyName(50, "50_10Rnd_762x54_SVD.png");
			this.imgPrimaryInv.Images.SetKeyName(51, "51_100Rnd_762x51_M240.png");
			this.imgPrimaryInv.Images.SetKeyName(52, "52_200Rnd_556x45_M249.png");
			this.imgPrimaryInv.Images.SetKeyName(53, "53_100Rnd_762x51_M240.png");
			this.imgPrimaryInv.Images.SetKeyName(54, "54_itemtent.png");
			this.imgPrimaryInv.Images.SetKeyName(55, "55_cloth_parcel.png");
			this.imgPrimaryInv.Images.SetKeyName(56, "56_cloth_parcel.png");
			this.imgPrimaryInv.Images.SetKeyName(57, "57_cloth_parcel.png");
			this.imgPrimaryInv.Images.SetKeyName(58, "58_cloth_parcel.png");
			this.imgPrimaryInv.Images.SetKeyName(59, "59_PipeBomb.png");
			this.imgPrimaryInv.Images.SetKeyName(60, "60_HandGrenade_West.png");
			this.imgPrimaryInv.Images.SetKeyName(61, "61_handroadflare.png");
			this.imgPrimaryInv.Images.SetKeyName(62, "62_handchemblue.png");
			this.imgPrimaryInv.Images.SetKeyName(63, "63_handchemgreen.png");
			this.imgPrimaryInv.Images.SetKeyName(64, "64_handchemred.png");
			this.imgPrimaryInv.Images.SetKeyName(65, "65_itemsandbag.png");
			this.imgPrimaryInv.Images.SetKeyName(66, "66_itemtanktrap.png");
			this.imgPrimaryInv.Images.SetKeyName(67, "67_fencewire_kit.png");
			this.imgSecondaryInv.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("imgSecondaryInv.ImageStream");
			this.imgSecondaryInv.TransparentColor = System.Drawing.Color.Transparent;
			this.imgSecondaryInv.Images.SetKeyName(0, "0_bandage.png");
			this.imgSecondaryInv.Images.SetKeyName(1, "1_g17mag.png");
			this.imgSecondaryInv.Images.SetKeyName(2, "2_m9mag.png");
			this.imgSecondaryInv.Images.SetKeyName(3, "3_m9mag.png");
			this.imgSecondaryInv.Images.SetKeyName(4, "5_makarovmag.png");
			this.imgSecondaryInv.Images.SetKeyName(5, "6_m1911mag.png");
			this.imgSecondaryInv.Images.SetKeyName(6, "4_pdwmag.png");
			this.imgSecondaryInv.Images.SetKeyName(7, "7_45acp.png");
			this.imgSecondaryInv.Images.SetKeyName(8, "8_m203he.png");
			this.imgSecondaryInv.Images.SetKeyName(9, "9_m203smoke.png");
			this.imgSecondaryInv.Images.SetKeyName(10, "10_m203flarewhite.png");
			this.imgSecondaryInv.Images.SetKeyName(11, "11_m203flaregreen.png");
			this.imgTools.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("imgTools.ImageStream");
			this.imgTools.TransparentColor = System.Drawing.Color.Transparent;
			this.imgTools.Images.SetKeyName(0, "1_Binocular.png");
			this.imgTools.Images.SetKeyName(1, "2_Binocular_Vector.png");
			this.imgTools.Images.SetKeyName(2, "3_NVGoggles.png");
			this.imgTools.Images.SetKeyName(3, "4_ItemGPS.png");
			this.imgTools.Images.SetKeyName(4, "5_ItemMap.png");
			this.imgTools.Images.SetKeyName(5, "6_ItemCompass.png");
			this.imgTools.Images.SetKeyName(6, "7_ItemWatch.png");
			this.imgTools.Images.SetKeyName(7, "8_itemflashlight.png");
			this.imgTools.Images.SetKeyName(8, "9_itemflashlightred.png");
			this.imgTools.Images.SetKeyName(9, "10_itemknife.png");
			this.imgTools.Images.SetKeyName(10, "11_itemhatchet.png");
			this.imgTools.Images.SetKeyName(11, "12_itemmatchbox.png");
			this.imgTools.Images.SetKeyName(12, "13_itemetool.png");
			this.imgTools.Images.SetKeyName(13, "14_itemtoolbox.png");
			this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.panel1.BackColor = System.Drawing.Color.Transparent;
			this.panel1.Controls.Add(this.comboboxFOOD);
			this.panel1.Controls.Add(this.comboboxPARTS);
			this.panel1.Controls.Add(this.comboboxSUBMACHINE);
			this.panel1.Controls.Add(this.comboboxTOOLS);
			this.panel1.Controls.Add(this.comboboxRIFLE);
			this.panel1.Controls.Add(this.btnAddBag);
			this.panel1.Controls.Add(this.comboboxPISTOL);
			this.panel1.Controls.Add(this.comboboxSHOTGUN);
			this.panel1.Controls.Add(this.btnAddInv);
			this.panel1.Controls.Add(this.comboboxMISC);
			this.panel1.Controls.Add(this.comboboxMEDICAL);
			this.panel1.Controls.Add(this.comboboxMACHINEGUN);
			this.panel1.Controls.Add(this.comboboxSNIPER);
			System.Windows.Forms.Panel panel = this.panel1;
			location = new System.Drawing.Point(48, 159);
			panel.Location = location;
			this.panel1.Name = "panel1";
			System.Windows.Forms.Panel panel2 = this.panel1;
			size = new System.Drawing.Size(273, 200);
			panel2.Size = size;
			this.panel1.TabIndex = 107;
			this.picOptics2.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.picOptics2.BackColor = System.Drawing.Color.Transparent;
			this.picOptics2.BackgroundImage = Loadout.My.Resources.Resources.background;
			this.picOptics2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.picOptics2.ContextMenuStrip = this.cmsRemove;
			this.picOptics2.Image = Loadout.My.Resources.Resources.binocular;
			System.Windows.Forms.PictureBox pictureBox3 = this.picOptics2;
			location = new System.Drawing.Point(643, 52);
			pictureBox3.Location = location;
			this.picOptics2.Name = "picOptics2";
			System.Windows.Forms.PictureBox pictureBox4 = this.picOptics2;
			size = new System.Drawing.Size(87, 93);
			pictureBox4.Size = size;
			this.picOptics2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picOptics2.TabIndex = 109;
			this.picOptics2.TabStop = false;
			this.picOptics1.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.picOptics1.BackColor = System.Drawing.Color.Transparent;
			this.picOptics1.BackgroundImage = Loadout.My.Resources.Resources.background;
			this.picOptics1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.picOptics1.ContextMenuStrip = this.cmsRemove;
			this.picOptics1.Image = Loadout.My.Resources.Resources.binocular;
			System.Windows.Forms.PictureBox pictureBox5 = this.picOptics1;
			location = new System.Drawing.Point(378, 52);
			pictureBox5.Location = location;
			this.picOptics1.Name = "picOptics1";
			System.Windows.Forms.PictureBox pictureBox6 = this.picOptics1;
			size = new System.Drawing.Size(87, 93);
			pictureBox6.Size = size;
			this.picOptics1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picOptics1.TabIndex = 110;
			this.picOptics1.TabStop = false;
			this.picPrimary.BackColor = System.Drawing.Color.Transparent;
			this.picPrimary.BackgroundImage = Loadout.My.Resources.Resources.background;
			this.picPrimary.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.picPrimary.ContextMenuStrip = this.cmsRemove;
			this.picPrimary.Image = Loadout.My.Resources.Resources.rifle;
			System.Windows.Forms.PictureBox pictureBox7 = this.picPrimary;
			location = new System.Drawing.Point(0, 0);
			pictureBox7.Location = location;
			this.picPrimary.Name = "picPrimary";
			System.Windows.Forms.PictureBox pictureBox8 = this.picPrimary;
			size = new System.Drawing.Size(160, 90);
			pictureBox8.Size = size;
			this.picPrimary.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.picPrimary.TabIndex = 111;
			this.picPrimary.TabStop = false;
			this.picBackpack.BackColor = System.Drawing.Color.Transparent;
			this.picBackpack.BackgroundImage = Loadout.My.Resources.Resources.background;
			this.picBackpack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.picBackpack.ContextMenuStrip = this.cmsRemove;
			this.picBackpack.Image = Loadout.My.Resources.Resources.second;
			System.Windows.Forms.PictureBox pictureBox9 = this.picBackpack;
			location = new System.Drawing.Point(0, 92);
			pictureBox9.Location = location;
			this.picBackpack.Name = "picBackpack";
			System.Windows.Forms.PictureBox pictureBox10 = this.picBackpack;
			size = new System.Drawing.Size(160, 90);
			pictureBox10.Size = size;
			this.picBackpack.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.picBackpack.TabIndex = 112;
			this.picBackpack.TabStop = false;
			this.picSecondary.BackColor = System.Drawing.Color.Transparent;
			this.picSecondary.BackgroundImage = Loadout.My.Resources.Resources.background;
			this.picSecondary.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.picSecondary.ContextMenuStrip = this.cmsRemove;
			this.picSecondary.Image = Loadout.My.Resources.Resources.pistol;
			System.Windows.Forms.PictureBox pictureBox11 = this.picSecondary;
			location = new System.Drawing.Point(0, 0);
			pictureBox11.Location = location;
			this.picSecondary.Name = "picSecondary";
			System.Windows.Forms.PictureBox pictureBox12 = this.picSecondary;
			size = new System.Drawing.Size(160, 90);
			pictureBox12.Size = size;
			this.picSecondary.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.picSecondary.TabIndex = 113;
			this.picSecondary.TabStop = false;
			this.picPrimaryInv1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.picPrimaryInv1.BackColor = System.Drawing.Color.Transparent;
			this.picPrimaryInv1.BackgroundImage = Loadout.My.Resources.Resources.background;
			this.picPrimaryInv1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.picPrimaryInv1.ContextMenuStrip = this.cmsRemove;
			this.picPrimaryInv1.Image = Loadout.My.Resources.Resources.heavyammo;
			System.Windows.Forms.PictureBox pictureBox13 = this.picPrimaryInv1;
			location = new System.Drawing.Point(166, 0);
			pictureBox13.Location = location;
			this.picPrimaryInv1.Name = "picPrimaryInv1";
			System.Windows.Forms.PictureBox pictureBox14 = this.picPrimaryInv1;
			size = new System.Drawing.Size(45, 44);
			pictureBox14.Size = size;
			this.picPrimaryInv1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picPrimaryInv1.TabIndex = 114;
			this.picPrimaryInv1.TabStop = false;
			this.picPrimaryInv2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.picPrimaryInv2.BackColor = System.Drawing.Color.Transparent;
			this.picPrimaryInv2.BackgroundImage = Loadout.My.Resources.Resources.background;
			this.picPrimaryInv2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.picPrimaryInv2.ContextMenuStrip = this.cmsRemove;
			this.picPrimaryInv2.Image = Loadout.My.Resources.Resources.heavyammo;
			System.Windows.Forms.PictureBox pictureBox15 = this.picPrimaryInv2;
			location = new System.Drawing.Point(213, 0);
			pictureBox15.Location = location;
			this.picPrimaryInv2.Name = "picPrimaryInv2";
			System.Windows.Forms.PictureBox pictureBox16 = this.picPrimaryInv2;
			size = new System.Drawing.Size(45, 44);
			pictureBox16.Size = size;
			this.picPrimaryInv2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picPrimaryInv2.TabIndex = 115;
			this.picPrimaryInv2.TabStop = false;
			this.picPrimaryInv4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.picPrimaryInv4.BackColor = System.Drawing.Color.Transparent;
			this.picPrimaryInv4.BackgroundImage = Loadout.My.Resources.Resources.background;
			this.picPrimaryInv4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.picPrimaryInv4.ContextMenuStrip = this.cmsRemove;
			this.picPrimaryInv4.Image = Loadout.My.Resources.Resources.heavyammo;
			System.Windows.Forms.PictureBox pictureBox17 = this.picPrimaryInv4;
			location = new System.Drawing.Point(307, 0);
			pictureBox17.Location = location;
			this.picPrimaryInv4.Name = "picPrimaryInv4";
			System.Windows.Forms.PictureBox pictureBox18 = this.picPrimaryInv4;
			size = new System.Drawing.Size(45, 44);
			pictureBox18.Size = size;
			this.picPrimaryInv4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picPrimaryInv4.TabIndex = 116;
			this.picPrimaryInv4.TabStop = false;
			this.picPrimaryInv3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.picPrimaryInv3.BackColor = System.Drawing.Color.Transparent;
			this.picPrimaryInv3.BackgroundImage = Loadout.My.Resources.Resources.background;
			this.picPrimaryInv3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.picPrimaryInv3.ContextMenuStrip = this.cmsRemove;
			this.picPrimaryInv3.Image = Loadout.My.Resources.Resources.heavyammo;
			System.Windows.Forms.PictureBox pictureBox19 = this.picPrimaryInv3;
			location = new System.Drawing.Point(260, 0);
			pictureBox19.Location = location;
			this.picPrimaryInv3.Name = "picPrimaryInv3";
			System.Windows.Forms.PictureBox pictureBox20 = this.picPrimaryInv3;
			size = new System.Drawing.Size(45, 44);
			pictureBox20.Size = size;
			this.picPrimaryInv3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picPrimaryInv3.TabIndex = 117;
			this.picPrimaryInv3.TabStop = false;
			this.picPrimaryInv7.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.picPrimaryInv7.BackColor = System.Drawing.Color.Transparent;
			this.picPrimaryInv7.BackgroundImage = Loadout.My.Resources.Resources.background;
			this.picPrimaryInv7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.picPrimaryInv7.ContextMenuStrip = this.cmsRemove;
			this.picPrimaryInv7.Image = Loadout.My.Resources.Resources.heavyammo;
			System.Windows.Forms.PictureBox pictureBox21 = this.picPrimaryInv7;
			location = new System.Drawing.Point(260, 46);
			pictureBox21.Location = location;
			this.picPrimaryInv7.Name = "picPrimaryInv7";
			System.Windows.Forms.PictureBox pictureBox22 = this.picPrimaryInv7;
			size = new System.Drawing.Size(45, 44);
			pictureBox22.Size = size;
			this.picPrimaryInv7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picPrimaryInv7.TabIndex = 121;
			this.picPrimaryInv7.TabStop = false;
			this.picPrimaryInv8.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.picPrimaryInv8.BackColor = System.Drawing.Color.Transparent;
			this.picPrimaryInv8.BackgroundImage = Loadout.My.Resources.Resources.background;
			this.picPrimaryInv8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.picPrimaryInv8.ContextMenuStrip = this.cmsRemove;
			this.picPrimaryInv8.Image = Loadout.My.Resources.Resources.heavyammo;
			System.Windows.Forms.PictureBox pictureBox23 = this.picPrimaryInv8;
			location = new System.Drawing.Point(307, 46);
			pictureBox23.Location = location;
			this.picPrimaryInv8.Name = "picPrimaryInv8";
			System.Windows.Forms.PictureBox pictureBox24 = this.picPrimaryInv8;
			size = new System.Drawing.Size(45, 44);
			pictureBox24.Size = size;
			this.picPrimaryInv8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picPrimaryInv8.TabIndex = 120;
			this.picPrimaryInv8.TabStop = false;
			this.picPrimaryInv6.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.picPrimaryInv6.BackColor = System.Drawing.Color.Transparent;
			this.picPrimaryInv6.BackgroundImage = Loadout.My.Resources.Resources.background;
			this.picPrimaryInv6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.picPrimaryInv6.ContextMenuStrip = this.cmsRemove;
			this.picPrimaryInv6.Image = Loadout.My.Resources.Resources.heavyammo;
			System.Windows.Forms.PictureBox pictureBox25 = this.picPrimaryInv6;
			location = new System.Drawing.Point(213, 46);
			pictureBox25.Location = location;
			this.picPrimaryInv6.Name = "picPrimaryInv6";
			System.Windows.Forms.PictureBox pictureBox26 = this.picPrimaryInv6;
			size = new System.Drawing.Size(45, 44);
			pictureBox26.Size = size;
			this.picPrimaryInv6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picPrimaryInv6.TabIndex = 119;
			this.picPrimaryInv6.TabStop = false;
			this.picPrimaryInv5.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.picPrimaryInv5.BackColor = System.Drawing.Color.Transparent;
			this.picPrimaryInv5.BackgroundImage = Loadout.My.Resources.Resources.background;
			this.picPrimaryInv5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.picPrimaryInv5.ContextMenuStrip = this.cmsRemove;
			this.picPrimaryInv5.Image = Loadout.My.Resources.Resources.heavyammo;
			System.Windows.Forms.PictureBox pictureBox27 = this.picPrimaryInv5;
			location = new System.Drawing.Point(166, 46);
			pictureBox27.Location = location;
			this.picPrimaryInv5.Name = "picPrimaryInv5";
			System.Windows.Forms.PictureBox pictureBox28 = this.picPrimaryInv5;
			size = new System.Drawing.Size(45, 44);
			pictureBox28.Size = size;
			this.picPrimaryInv5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picPrimaryInv5.TabIndex = 118;
			this.picPrimaryInv5.TabStop = false;
			this.picPrimaryInv11.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.picPrimaryInv11.BackColor = System.Drawing.Color.Transparent;
			this.picPrimaryInv11.BackgroundImage = Loadout.My.Resources.Resources.background;
			this.picPrimaryInv11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.picPrimaryInv11.ContextMenuStrip = this.cmsRemove;
			this.picPrimaryInv11.Image = Loadout.My.Resources.Resources.heavyammo;
			System.Windows.Forms.PictureBox pictureBox29 = this.picPrimaryInv11;
			location = new System.Drawing.Point(260, 92);
			pictureBox29.Location = location;
			this.picPrimaryInv11.Name = "picPrimaryInv11";
			System.Windows.Forms.PictureBox pictureBox30 = this.picPrimaryInv11;
			size = new System.Drawing.Size(45, 44);
			pictureBox30.Size = size;
			this.picPrimaryInv11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picPrimaryInv11.TabIndex = 125;
			this.picPrimaryInv11.TabStop = false;
			this.picPrimaryInv12.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.picPrimaryInv12.BackColor = System.Drawing.Color.Transparent;
			this.picPrimaryInv12.BackgroundImage = Loadout.My.Resources.Resources.background;
			this.picPrimaryInv12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.picPrimaryInv12.ContextMenuStrip = this.cmsRemove;
			this.picPrimaryInv12.Image = Loadout.My.Resources.Resources.heavyammo;
			System.Windows.Forms.PictureBox pictureBox31 = this.picPrimaryInv12;
			location = new System.Drawing.Point(307, 92);
			pictureBox31.Location = location;
			this.picPrimaryInv12.Name = "picPrimaryInv12";
			System.Windows.Forms.PictureBox pictureBox32 = this.picPrimaryInv12;
			size = new System.Drawing.Size(45, 44);
			pictureBox32.Size = size;
			this.picPrimaryInv12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picPrimaryInv12.TabIndex = 124;
			this.picPrimaryInv12.TabStop = false;
			this.picPrimaryInv10.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.picPrimaryInv10.BackColor = System.Drawing.Color.Transparent;
			this.picPrimaryInv10.BackgroundImage = Loadout.My.Resources.Resources.background;
			this.picPrimaryInv10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.picPrimaryInv10.ContextMenuStrip = this.cmsRemove;
			this.picPrimaryInv10.Image = Loadout.My.Resources.Resources.heavyammo;
			System.Windows.Forms.PictureBox pictureBox33 = this.picPrimaryInv10;
			location = new System.Drawing.Point(213, 92);
			pictureBox33.Location = location;
			this.picPrimaryInv10.Name = "picPrimaryInv10";
			System.Windows.Forms.PictureBox pictureBox34 = this.picPrimaryInv10;
			size = new System.Drawing.Size(45, 44);
			pictureBox34.Size = size;
			this.picPrimaryInv10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picPrimaryInv10.TabIndex = 123;
			this.picPrimaryInv10.TabStop = false;
			this.picPrimaryInv9.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.picPrimaryInv9.BackColor = System.Drawing.Color.Transparent;
			this.picPrimaryInv9.BackgroundImage = Loadout.My.Resources.Resources.background;
			this.picPrimaryInv9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.picPrimaryInv9.ContextMenuStrip = this.cmsRemove;
			this.picPrimaryInv9.Image = Loadout.My.Resources.Resources.heavyammo;
			System.Windows.Forms.PictureBox pictureBox35 = this.picPrimaryInv9;
			location = new System.Drawing.Point(166, 92);
			pictureBox35.Location = location;
			this.picPrimaryInv9.Name = "picPrimaryInv9";
			System.Windows.Forms.PictureBox pictureBox36 = this.picPrimaryInv9;
			size = new System.Drawing.Size(45, 44);
			pictureBox36.Size = size;
			this.picPrimaryInv9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picPrimaryInv9.TabIndex = 122;
			this.picPrimaryInv9.TabStop = false;
			this.picSecondaryInv1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.picSecondaryInv1.BackColor = System.Drawing.Color.Transparent;
			this.picSecondaryInv1.BackgroundImage = Loadout.My.Resources.Resources.background;
			this.picSecondaryInv1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.picSecondaryInv1.ContextMenuStrip = this.cmsRemove;
			this.picSecondaryInv1.Image = (System.Drawing.Image)resources.GetObject("picSecondaryInv1.Image");
			System.Windows.Forms.PictureBox pictureBox37 = this.picSecondaryInv1;
			location = new System.Drawing.Point(166, 0);
			pictureBox37.Location = location;
			this.picSecondaryInv1.Name = "picSecondaryInv1";
			System.Windows.Forms.PictureBox pictureBox38 = this.picSecondaryInv1;
			size = new System.Drawing.Size(45, 44);
			pictureBox38.Size = size;
			this.picSecondaryInv1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picSecondaryInv1.TabIndex = 130;
			this.picSecondaryInv1.TabStop = false;
			this.picSecondaryInv2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.picSecondaryInv2.BackColor = System.Drawing.Color.Transparent;
			this.picSecondaryInv2.BackgroundImage = Loadout.My.Resources.Resources.background;
			this.picSecondaryInv2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.picSecondaryInv2.ContextMenuStrip = this.cmsRemove;
			this.picSecondaryInv2.Image = (System.Drawing.Image)resources.GetObject("picSecondaryInv2.Image");
			System.Windows.Forms.PictureBox pictureBox39 = this.picSecondaryInv2;
			location = new System.Drawing.Point(213, 0);
			pictureBox39.Location = location;
			this.picSecondaryInv2.Name = "picSecondaryInv2";
			System.Windows.Forms.PictureBox pictureBox40 = this.picSecondaryInv2;
			size = new System.Drawing.Size(45, 44);
			pictureBox40.Size = size;
			this.picSecondaryInv2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picSecondaryInv2.TabIndex = 131;
			this.picSecondaryInv2.TabStop = false;
			this.picSecondaryInv3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.picSecondaryInv3.BackColor = System.Drawing.Color.Transparent;
			this.picSecondaryInv3.BackgroundImage = Loadout.My.Resources.Resources.background;
			this.picSecondaryInv3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.picSecondaryInv3.ContextMenuStrip = this.cmsRemove;
			this.picSecondaryInv3.Image = (System.Drawing.Image)resources.GetObject("picSecondaryInv3.Image");
			System.Windows.Forms.PictureBox pictureBox41 = this.picSecondaryInv3;
			location = new System.Drawing.Point(260, 0);
			pictureBox41.Location = location;
			this.picSecondaryInv3.Name = "picSecondaryInv3";
			System.Windows.Forms.PictureBox pictureBox42 = this.picSecondaryInv3;
			size = new System.Drawing.Size(45, 44);
			pictureBox42.Size = size;
			this.picSecondaryInv3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picSecondaryInv3.TabIndex = 132;
			this.picSecondaryInv3.TabStop = false;
			this.picSecondaryInv4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.picSecondaryInv4.BackColor = System.Drawing.Color.Transparent;
			this.picSecondaryInv4.BackgroundImage = Loadout.My.Resources.Resources.background;
			this.picSecondaryInv4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.picSecondaryInv4.ContextMenuStrip = this.cmsRemove;
			this.picSecondaryInv4.Image = (System.Drawing.Image)resources.GetObject("picSecondaryInv4.Image");
			System.Windows.Forms.PictureBox pictureBox43 = this.picSecondaryInv4;
			location = new System.Drawing.Point(307, 0);
			pictureBox43.Location = location;
			this.picSecondaryInv4.Name = "picSecondaryInv4";
			System.Windows.Forms.PictureBox pictureBox44 = this.picSecondaryInv4;
			size = new System.Drawing.Size(45, 44);
			pictureBox44.Size = size;
			this.picSecondaryInv4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picSecondaryInv4.TabIndex = 133;
			this.picSecondaryInv4.TabStop = false;
			this.picSecondaryInv8.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.picSecondaryInv8.BackColor = System.Drawing.Color.Transparent;
			this.picSecondaryInv8.BackgroundImage = Loadout.My.Resources.Resources.background;
			this.picSecondaryInv8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.picSecondaryInv8.ContextMenuStrip = this.cmsRemove;
			this.picSecondaryInv8.Image = (System.Drawing.Image)resources.GetObject("picSecondaryInv8.Image");
			System.Windows.Forms.PictureBox pictureBox45 = this.picSecondaryInv8;
			location = new System.Drawing.Point(307, 46);
			pictureBox45.Location = location;
			this.picSecondaryInv8.Name = "picSecondaryInv8";
			System.Windows.Forms.PictureBox pictureBox46 = this.picSecondaryInv8;
			size = new System.Drawing.Size(45, 44);
			pictureBox46.Size = size;
			this.picSecondaryInv8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picSecondaryInv8.TabIndex = 137;
			this.picSecondaryInv8.TabStop = false;
			this.picSecondaryInv7.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.picSecondaryInv7.BackColor = System.Drawing.Color.Transparent;
			this.picSecondaryInv7.BackgroundImage = Loadout.My.Resources.Resources.background;
			this.picSecondaryInv7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.picSecondaryInv7.ContextMenuStrip = this.cmsRemove;
			this.picSecondaryInv7.Image = (System.Drawing.Image)resources.GetObject("picSecondaryInv7.Image");
			System.Windows.Forms.PictureBox pictureBox47 = this.picSecondaryInv7;
			location = new System.Drawing.Point(260, 46);
			pictureBox47.Location = location;
			this.picSecondaryInv7.Name = "picSecondaryInv7";
			System.Windows.Forms.PictureBox pictureBox48 = this.picSecondaryInv7;
			size = new System.Drawing.Size(45, 44);
			pictureBox48.Size = size;
			this.picSecondaryInv7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picSecondaryInv7.TabIndex = 136;
			this.picSecondaryInv7.TabStop = false;
			this.picSecondaryInv6.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.picSecondaryInv6.BackColor = System.Drawing.Color.Transparent;
			this.picSecondaryInv6.BackgroundImage = Loadout.My.Resources.Resources.background;
			this.picSecondaryInv6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.picSecondaryInv6.ContextMenuStrip = this.cmsRemove;
			this.picSecondaryInv6.Image = (System.Drawing.Image)resources.GetObject("picSecondaryInv6.Image");
			System.Windows.Forms.PictureBox pictureBox49 = this.picSecondaryInv6;
			location = new System.Drawing.Point(213, 46);
			pictureBox49.Location = location;
			this.picSecondaryInv6.Name = "picSecondaryInv6";
			System.Windows.Forms.PictureBox pictureBox50 = this.picSecondaryInv6;
			size = new System.Drawing.Size(45, 44);
			pictureBox50.Size = size;
			this.picSecondaryInv6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picSecondaryInv6.TabIndex = 135;
			this.picSecondaryInv6.TabStop = false;
			this.picSecondaryInv5.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			this.picSecondaryInv5.BackColor = System.Drawing.Color.Transparent;
			this.picSecondaryInv5.BackgroundImage = Loadout.My.Resources.Resources.background;
			this.picSecondaryInv5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.picSecondaryInv5.ContextMenuStrip = this.cmsRemove;
			this.picSecondaryInv5.Image = (System.Drawing.Image)resources.GetObject("picSecondaryInv5.Image");
			System.Windows.Forms.PictureBox pictureBox51 = this.picSecondaryInv5;
			location = new System.Drawing.Point(166, 46);
			pictureBox51.Location = location;
			this.picSecondaryInv5.Name = "picSecondaryInv5";
			System.Windows.Forms.PictureBox pictureBox52 = this.picSecondaryInv5;
			size = new System.Drawing.Size(45, 44);
			pictureBox52.Size = size;
			this.picSecondaryInv5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picSecondaryInv5.TabIndex = 134;
			this.picSecondaryInv5.TabStop = false;
			this.picToolInv1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.picToolInv1.BackColor = System.Drawing.Color.Transparent;
			this.picToolInv1.BackgroundImage = Loadout.My.Resources.Resources.background;
			this.picToolInv1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.picToolInv1.ContextMenuStrip = this.cmsRemove;
			System.Windows.Forms.PictureBox pictureBox53 = this.picToolInv1;
			location = new System.Drawing.Point(0, 0);
			pictureBox53.Location = location;
			this.picToolInv1.Name = "picToolInv1";
			System.Windows.Forms.PictureBox pictureBox54 = this.picToolInv1;
			size = new System.Drawing.Size(45, 44);
			pictureBox54.Size = size;
			this.picToolInv1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picToolInv1.TabIndex = 138;
			this.picToolInv1.TabStop = false;
			this.picToolInv7.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.picToolInv7.BackColor = System.Drawing.Color.Transparent;
			this.picToolInv7.BackgroundImage = Loadout.My.Resources.Resources.background;
			this.picToolInv7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.picToolInv7.ContextMenuStrip = this.cmsRemove;
			System.Windows.Forms.PictureBox pictureBox55 = this.picToolInv7;
			location = new System.Drawing.Point(282, 0);
			pictureBox55.Location = location;
			this.picToolInv7.Name = "picToolInv7";
			System.Windows.Forms.PictureBox pictureBox56 = this.picToolInv7;
			size = new System.Drawing.Size(45, 44);
			pictureBox56.Size = size;
			this.picToolInv7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picToolInv7.TabIndex = 139;
			this.picToolInv7.TabStop = false;
			this.picToolInv6.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.picToolInv6.BackColor = System.Drawing.Color.Transparent;
			this.picToolInv6.BackgroundImage = Loadout.My.Resources.Resources.background;
			this.picToolInv6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.picToolInv6.ContextMenuStrip = this.cmsRemove;
			System.Windows.Forms.PictureBox pictureBox57 = this.picToolInv6;
			location = new System.Drawing.Point(235, 0);
			pictureBox57.Location = location;
			this.picToolInv6.Name = "picToolInv6";
			System.Windows.Forms.PictureBox pictureBox58 = this.picToolInv6;
			size = new System.Drawing.Size(45, 44);
			pictureBox58.Size = size;
			this.picToolInv6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picToolInv6.TabIndex = 140;
			this.picToolInv6.TabStop = false;
			this.picToolInv5.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.picToolInv5.BackColor = System.Drawing.Color.Transparent;
			this.picToolInv5.BackgroundImage = Loadout.My.Resources.Resources.background;
			this.picToolInv5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.picToolInv5.ContextMenuStrip = this.cmsRemove;
			System.Windows.Forms.PictureBox pictureBox59 = this.picToolInv5;
			location = new System.Drawing.Point(188, 0);
			pictureBox59.Location = location;
			this.picToolInv5.Name = "picToolInv5";
			System.Windows.Forms.PictureBox pictureBox60 = this.picToolInv5;
			size = new System.Drawing.Size(45, 44);
			pictureBox60.Size = size;
			this.picToolInv5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picToolInv5.TabIndex = 141;
			this.picToolInv5.TabStop = false;
			this.picToolInv4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.picToolInv4.BackColor = System.Drawing.Color.Transparent;
			this.picToolInv4.BackgroundImage = Loadout.My.Resources.Resources.background;
			this.picToolInv4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.picToolInv4.ContextMenuStrip = this.cmsRemove;
			System.Windows.Forms.PictureBox pictureBox61 = this.picToolInv4;
			location = new System.Drawing.Point(141, 0);
			pictureBox61.Location = location;
			this.picToolInv4.Name = "picToolInv4";
			System.Windows.Forms.PictureBox pictureBox62 = this.picToolInv4;
			size = new System.Drawing.Size(45, 44);
			pictureBox62.Size = size;
			this.picToolInv4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picToolInv4.TabIndex = 142;
			this.picToolInv4.TabStop = false;
			this.picToolInv2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.picToolInv2.BackColor = System.Drawing.Color.Transparent;
			this.picToolInv2.BackgroundImage = Loadout.My.Resources.Resources.background;
			this.picToolInv2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.picToolInv2.ContextMenuStrip = this.cmsRemove;
			System.Windows.Forms.PictureBox pictureBox63 = this.picToolInv2;
			location = new System.Drawing.Point(47, 0);
			pictureBox63.Location = location;
			this.picToolInv2.Name = "picToolInv2";
			System.Windows.Forms.PictureBox pictureBox64 = this.picToolInv2;
			size = new System.Drawing.Size(45, 44);
			pictureBox64.Size = size;
			this.picToolInv2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picToolInv2.TabIndex = 143;
			this.picToolInv2.TabStop = false;
			this.picToolInv3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.picToolInv3.BackColor = System.Drawing.Color.Transparent;
			this.picToolInv3.BackgroundImage = Loadout.My.Resources.Resources.background;
			this.picToolInv3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.picToolInv3.ContextMenuStrip = this.cmsRemove;
			System.Windows.Forms.PictureBox pictureBox65 = this.picToolInv3;
			location = new System.Drawing.Point(94, 0);
			pictureBox65.Location = location;
			this.picToolInv3.Name = "picToolInv3";
			System.Windows.Forms.PictureBox pictureBox66 = this.picToolInv3;
			size = new System.Drawing.Size(45, 44);
			pictureBox66.Size = size;
			this.picToolInv3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picToolInv3.TabIndex = 144;
			this.picToolInv3.TabStop = false;
			this.picBagInv1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.picBagInv1.BackColor = System.Drawing.Color.Transparent;
			this.picBagInv1.BackgroundImage = Loadout.My.Resources.Resources.background;
			this.picBagInv1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.picBagInv1.ContextMenuStrip = this.cmsRemove;
			System.Windows.Forms.PictureBox pictureBox67 = this.picBagInv1;
			location = new System.Drawing.Point(0, 0);
			pictureBox67.Location = location;
			this.picBagInv1.Name = "picBagInv1";
			System.Windows.Forms.PictureBox pictureBox68 = this.picBagInv1;
			size = new System.Drawing.Size(45, 44);
			pictureBox68.Size = size;
			this.picBagInv1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picBagInv1.TabIndex = 146;
			this.picBagInv1.TabStop = false;
			this.picBagInv1.Visible = false;
			this.picBagInv2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.picBagInv2.BackColor = System.Drawing.Color.Transparent;
			this.picBagInv2.BackgroundImage = Loadout.My.Resources.Resources.background;
			this.picBagInv2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.picBagInv2.ContextMenuStrip = this.cmsRemove;
			System.Windows.Forms.PictureBox pictureBox69 = this.picBagInv2;
			location = new System.Drawing.Point(47, 0);
			pictureBox69.Location = location;
			this.picBagInv2.Name = "picBagInv2";
			System.Windows.Forms.PictureBox pictureBox70 = this.picBagInv2;
			size = new System.Drawing.Size(45, 44);
			pictureBox70.Size = size;
			this.picBagInv2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picBagInv2.TabIndex = 147;
			this.picBagInv2.TabStop = false;
			this.picBagInv2.Visible = false;
			this.picBagInv3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.picBagInv3.BackColor = System.Drawing.Color.Transparent;
			this.picBagInv3.BackgroundImage = Loadout.My.Resources.Resources.background;
			this.picBagInv3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.picBagInv3.ContextMenuStrip = this.cmsRemove;
			System.Windows.Forms.PictureBox pictureBox71 = this.picBagInv3;
			location = new System.Drawing.Point(94, 0);
			pictureBox71.Location = location;
			this.picBagInv3.Name = "picBagInv3";
			System.Windows.Forms.PictureBox pictureBox72 = this.picBagInv3;
			size = new System.Drawing.Size(45, 44);
			pictureBox72.Size = size;
			this.picBagInv3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picBagInv3.TabIndex = 148;
			this.picBagInv3.TabStop = false;
			this.picBagInv3.Visible = false;
			this.picBagInv4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.picBagInv4.BackColor = System.Drawing.Color.Transparent;
			this.picBagInv4.BackgroundImage = Loadout.My.Resources.Resources.background;
			this.picBagInv4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.picBagInv4.ContextMenuStrip = this.cmsRemove;
			System.Windows.Forms.PictureBox pictureBox73 = this.picBagInv4;
			location = new System.Drawing.Point(141, 0);
			pictureBox73.Location = location;
			this.picBagInv4.Name = "picBagInv4";
			System.Windows.Forms.PictureBox pictureBox74 = this.picBagInv4;
			size = new System.Drawing.Size(45, 44);
			pictureBox74.Size = size;
			this.picBagInv4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picBagInv4.TabIndex = 149;
			this.picBagInv4.TabStop = false;
			this.picBagInv4.Visible = false;
			this.picBagInv5.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.picBagInv5.BackColor = System.Drawing.Color.Transparent;
			this.picBagInv5.BackgroundImage = Loadout.My.Resources.Resources.background;
			this.picBagInv5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.picBagInv5.ContextMenuStrip = this.cmsRemove;
			System.Windows.Forms.PictureBox pictureBox75 = this.picBagInv5;
			location = new System.Drawing.Point(188, 0);
			pictureBox75.Location = location;
			this.picBagInv5.Name = "picBagInv5";
			System.Windows.Forms.PictureBox pictureBox76 = this.picBagInv5;
			size = new System.Drawing.Size(45, 44);
			pictureBox76.Size = size;
			this.picBagInv5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picBagInv5.TabIndex = 150;
			this.picBagInv5.TabStop = false;
			this.picBagInv5.Visible = false;
			this.picBagInv6.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.picBagInv6.BackColor = System.Drawing.Color.Transparent;
			this.picBagInv6.BackgroundImage = Loadout.My.Resources.Resources.background;
			this.picBagInv6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.picBagInv6.ContextMenuStrip = this.cmsRemove;
			System.Windows.Forms.PictureBox pictureBox77 = this.picBagInv6;
			location = new System.Drawing.Point(235, 0);
			pictureBox77.Location = location;
			this.picBagInv6.Name = "picBagInv6";
			System.Windows.Forms.PictureBox pictureBox78 = this.picBagInv6;
			size = new System.Drawing.Size(45, 44);
			pictureBox78.Size = size;
			this.picBagInv6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picBagInv6.TabIndex = 151;
			this.picBagInv6.TabStop = false;
			this.picBagInv6.Visible = false;
			this.picBagInv7.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.picBagInv7.BackColor = System.Drawing.Color.Transparent;
			this.picBagInv7.BackgroundImage = Loadout.My.Resources.Resources.background;
			this.picBagInv7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.picBagInv7.ContextMenuStrip = this.cmsRemove;
			System.Windows.Forms.PictureBox pictureBox79 = this.picBagInv7;
			location = new System.Drawing.Point(282, 0);
			pictureBox79.Location = location;
			this.picBagInv7.Name = "picBagInv7";
			System.Windows.Forms.PictureBox pictureBox80 = this.picBagInv7;
			size = new System.Drawing.Size(45, 44);
			pictureBox80.Size = size;
			this.picBagInv7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picBagInv7.TabIndex = 152;
			this.picBagInv7.TabStop = false;
			this.picBagInv7.Visible = false;
			this.picBagInv14.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.picBagInv14.BackColor = System.Drawing.Color.Transparent;
			this.picBagInv14.BackgroundImage = Loadout.My.Resources.Resources.background;
			this.picBagInv14.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.picBagInv14.ContextMenuStrip = this.cmsRemove;
			System.Windows.Forms.PictureBox pictureBox81 = this.picBagInv14;
			location = new System.Drawing.Point(282, 47);
			pictureBox81.Location = location;
			this.picBagInv14.Name = "picBagInv14";
			System.Windows.Forms.PictureBox pictureBox82 = this.picBagInv14;
			size = new System.Drawing.Size(45, 44);
			pictureBox82.Size = size;
			this.picBagInv14.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picBagInv14.TabIndex = 159;
			this.picBagInv14.TabStop = false;
			this.picBagInv14.Visible = false;
			this.picBagInv13.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.picBagInv13.BackColor = System.Drawing.Color.Transparent;
			this.picBagInv13.BackgroundImage = Loadout.My.Resources.Resources.background;
			this.picBagInv13.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.picBagInv13.ContextMenuStrip = this.cmsRemove;
			System.Windows.Forms.PictureBox pictureBox83 = this.picBagInv13;
			location = new System.Drawing.Point(235, 47);
			pictureBox83.Location = location;
			this.picBagInv13.Name = "picBagInv13";
			System.Windows.Forms.PictureBox pictureBox84 = this.picBagInv13;
			size = new System.Drawing.Size(45, 44);
			pictureBox84.Size = size;
			this.picBagInv13.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picBagInv13.TabIndex = 158;
			this.picBagInv13.TabStop = false;
			this.picBagInv13.Visible = false;
			this.picBagInv12.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.picBagInv12.BackColor = System.Drawing.Color.Transparent;
			this.picBagInv12.BackgroundImage = Loadout.My.Resources.Resources.background;
			this.picBagInv12.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.picBagInv12.ContextMenuStrip = this.cmsRemove;
			System.Windows.Forms.PictureBox pictureBox85 = this.picBagInv12;
			location = new System.Drawing.Point(188, 47);
			pictureBox85.Location = location;
			this.picBagInv12.Name = "picBagInv12";
			System.Windows.Forms.PictureBox pictureBox86 = this.picBagInv12;
			size = new System.Drawing.Size(45, 44);
			pictureBox86.Size = size;
			this.picBagInv12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picBagInv12.TabIndex = 157;
			this.picBagInv12.TabStop = false;
			this.picBagInv12.Visible = false;
			this.picBagInv11.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.picBagInv11.BackColor = System.Drawing.Color.Transparent;
			this.picBagInv11.BackgroundImage = Loadout.My.Resources.Resources.background;
			this.picBagInv11.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.picBagInv11.ContextMenuStrip = this.cmsRemove;
			System.Windows.Forms.PictureBox pictureBox87 = this.picBagInv11;
			location = new System.Drawing.Point(141, 47);
			pictureBox87.Location = location;
			this.picBagInv11.Name = "picBagInv11";
			System.Windows.Forms.PictureBox pictureBox88 = this.picBagInv11;
			size = new System.Drawing.Size(45, 44);
			pictureBox88.Size = size;
			this.picBagInv11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picBagInv11.TabIndex = 156;
			this.picBagInv11.TabStop = false;
			this.picBagInv11.Visible = false;
			this.picBagInv10.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.picBagInv10.BackColor = System.Drawing.Color.Transparent;
			this.picBagInv10.BackgroundImage = Loadout.My.Resources.Resources.background;
			this.picBagInv10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.picBagInv10.ContextMenuStrip = this.cmsRemove;
			System.Windows.Forms.PictureBox pictureBox89 = this.picBagInv10;
			location = new System.Drawing.Point(94, 47);
			pictureBox89.Location = location;
			this.picBagInv10.Name = "picBagInv10";
			System.Windows.Forms.PictureBox pictureBox90 = this.picBagInv10;
			size = new System.Drawing.Size(45, 44);
			pictureBox90.Size = size;
			this.picBagInv10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picBagInv10.TabIndex = 155;
			this.picBagInv10.TabStop = false;
			this.picBagInv10.Visible = false;
			this.picBagInv9.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.picBagInv9.BackColor = System.Drawing.Color.Transparent;
			this.picBagInv9.BackgroundImage = Loadout.My.Resources.Resources.background;
			this.picBagInv9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.picBagInv9.ContextMenuStrip = this.cmsRemove;
			System.Windows.Forms.PictureBox pictureBox91 = this.picBagInv9;
			location = new System.Drawing.Point(47, 47);
			pictureBox91.Location = location;
			this.picBagInv9.Name = "picBagInv9";
			System.Windows.Forms.PictureBox pictureBox92 = this.picBagInv9;
			size = new System.Drawing.Size(45, 44);
			pictureBox92.Size = size;
			this.picBagInv9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picBagInv9.TabIndex = 154;
			this.picBagInv9.TabStop = false;
			this.picBagInv9.Visible = false;
			this.picBagInv8.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.picBagInv8.BackColor = System.Drawing.Color.Transparent;
			this.picBagInv8.BackgroundImage = Loadout.My.Resources.Resources.background;
			this.picBagInv8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.picBagInv8.ContextMenuStrip = this.cmsRemove;
			System.Windows.Forms.PictureBox pictureBox93 = this.picBagInv8;
			location = new System.Drawing.Point(0, 47);
			pictureBox93.Location = location;
			this.picBagInv8.Name = "picBagInv8";
			System.Windows.Forms.PictureBox pictureBox94 = this.picBagInv8;
			size = new System.Drawing.Size(45, 44);
			pictureBox94.Size = size;
			this.picBagInv8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picBagInv8.TabIndex = 153;
			this.picBagInv8.TabStop = false;
			this.picBagInv8.Visible = false;
			this.picBagInv21.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.picBagInv21.BackColor = System.Drawing.Color.Transparent;
			this.picBagInv21.BackgroundImage = Loadout.My.Resources.Resources.background;
			this.picBagInv21.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.picBagInv21.ContextMenuStrip = this.cmsRemove;
			System.Windows.Forms.PictureBox pictureBox95 = this.picBagInv21;
			location = new System.Drawing.Point(282, 94);
			pictureBox95.Location = location;
			this.picBagInv21.Name = "picBagInv21";
			System.Windows.Forms.PictureBox pictureBox96 = this.picBagInv21;
			size = new System.Drawing.Size(45, 44);
			pictureBox96.Size = size;
			this.picBagInv21.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picBagInv21.TabIndex = 166;
			this.picBagInv21.TabStop = false;
			this.picBagInv21.Visible = false;
			this.picBagInv20.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.picBagInv20.BackColor = System.Drawing.Color.Transparent;
			this.picBagInv20.BackgroundImage = Loadout.My.Resources.Resources.background;
			this.picBagInv20.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.picBagInv20.ContextMenuStrip = this.cmsRemove;
			System.Windows.Forms.PictureBox pictureBox97 = this.picBagInv20;
			location = new System.Drawing.Point(235, 94);
			pictureBox97.Location = location;
			this.picBagInv20.Name = "picBagInv20";
			System.Windows.Forms.PictureBox pictureBox98 = this.picBagInv20;
			size = new System.Drawing.Size(45, 44);
			pictureBox98.Size = size;
			this.picBagInv20.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picBagInv20.TabIndex = 165;
			this.picBagInv20.TabStop = false;
			this.picBagInv20.Visible = false;
			this.picBagInv19.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.picBagInv19.BackColor = System.Drawing.Color.Transparent;
			this.picBagInv19.BackgroundImage = Loadout.My.Resources.Resources.background;
			this.picBagInv19.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.picBagInv19.ContextMenuStrip = this.cmsRemove;
			System.Windows.Forms.PictureBox pictureBox99 = this.picBagInv19;
			location = new System.Drawing.Point(188, 94);
			pictureBox99.Location = location;
			this.picBagInv19.Name = "picBagInv19";
			System.Windows.Forms.PictureBox pictureBox100 = this.picBagInv19;
			size = new System.Drawing.Size(45, 44);
			pictureBox100.Size = size;
			this.picBagInv19.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picBagInv19.TabIndex = 164;
			this.picBagInv19.TabStop = false;
			this.picBagInv19.Visible = false;
			this.picBagInv18.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.picBagInv18.BackColor = System.Drawing.Color.Transparent;
			this.picBagInv18.BackgroundImage = Loadout.My.Resources.Resources.background;
			this.picBagInv18.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.picBagInv18.ContextMenuStrip = this.cmsRemove;
			System.Windows.Forms.PictureBox pictureBox101 = this.picBagInv18;
			location = new System.Drawing.Point(141, 94);
			pictureBox101.Location = location;
			this.picBagInv18.Name = "picBagInv18";
			System.Windows.Forms.PictureBox pictureBox102 = this.picBagInv18;
			size = new System.Drawing.Size(45, 44);
			pictureBox102.Size = size;
			this.picBagInv18.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picBagInv18.TabIndex = 163;
			this.picBagInv18.TabStop = false;
			this.picBagInv18.Visible = false;
			this.picBagInv17.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.picBagInv17.BackColor = System.Drawing.Color.Transparent;
			this.picBagInv17.BackgroundImage = Loadout.My.Resources.Resources.background;
			this.picBagInv17.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.picBagInv17.ContextMenuStrip = this.cmsRemove;
			System.Windows.Forms.PictureBox pictureBox103 = this.picBagInv17;
			location = new System.Drawing.Point(94, 94);
			pictureBox103.Location = location;
			this.picBagInv17.Name = "picBagInv17";
			System.Windows.Forms.PictureBox pictureBox104 = this.picBagInv17;
			size = new System.Drawing.Size(45, 44);
			pictureBox104.Size = size;
			this.picBagInv17.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picBagInv17.TabIndex = 162;
			this.picBagInv17.TabStop = false;
			this.picBagInv17.Visible = false;
			this.picBagInv16.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.picBagInv16.BackColor = System.Drawing.Color.Transparent;
			this.picBagInv16.BackgroundImage = Loadout.My.Resources.Resources.background;
			this.picBagInv16.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.picBagInv16.ContextMenuStrip = this.cmsRemove;
			System.Windows.Forms.PictureBox pictureBox105 = this.picBagInv16;
			location = new System.Drawing.Point(47, 94);
			pictureBox105.Location = location;
			this.picBagInv16.Name = "picBagInv16";
			System.Windows.Forms.PictureBox pictureBox106 = this.picBagInv16;
			size = new System.Drawing.Size(45, 44);
			pictureBox106.Size = size;
			this.picBagInv16.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picBagInv16.TabIndex = 161;
			this.picBagInv16.TabStop = false;
			this.picBagInv16.Visible = false;
			this.picBagInv15.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.picBagInv15.BackColor = System.Drawing.Color.Transparent;
			this.picBagInv15.BackgroundImage = Loadout.My.Resources.Resources.background;
			this.picBagInv15.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.picBagInv15.ContextMenuStrip = this.cmsRemove;
			System.Windows.Forms.PictureBox pictureBox107 = this.picBagInv15;
			location = new System.Drawing.Point(0, 94);
			pictureBox107.Location = location;
			this.picBagInv15.Name = "picBagInv15";
			System.Windows.Forms.PictureBox pictureBox108 = this.picBagInv15;
			size = new System.Drawing.Size(45, 44);
			pictureBox108.Size = size;
			this.picBagInv15.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picBagInv15.TabIndex = 160;
			this.picBagInv15.TabStop = false;
			this.picBagInv15.Visible = false;
			this.picBagInv23.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.picBagInv23.BackColor = System.Drawing.Color.Transparent;
			this.picBagInv23.BackgroundImage = Loadout.My.Resources.Resources.background;
			this.picBagInv23.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.picBagInv23.ContextMenuStrip = this.cmsRemove;
			System.Windows.Forms.PictureBox pictureBox109 = this.picBagInv23;
			location = new System.Drawing.Point(47, 140);
			pictureBox109.Location = location;
			this.picBagInv23.Name = "picBagInv23";
			System.Windows.Forms.PictureBox pictureBox110 = this.picBagInv23;
			size = new System.Drawing.Size(45, 44);
			pictureBox110.Size = size;
			this.picBagInv23.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picBagInv23.TabIndex = 168;
			this.picBagInv23.TabStop = false;
			this.picBagInv23.Visible = false;
			this.picBagInv22.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.picBagInv22.BackColor = System.Drawing.Color.Transparent;
			this.picBagInv22.BackgroundImage = Loadout.My.Resources.Resources.background;
			this.picBagInv22.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.picBagInv22.ContextMenuStrip = this.cmsRemove;
			System.Windows.Forms.PictureBox pictureBox111 = this.picBagInv22;
			location = new System.Drawing.Point(0, 140);
			pictureBox111.Location = location;
			this.picBagInv22.Name = "picBagInv22";
			System.Windows.Forms.PictureBox pictureBox112 = this.picBagInv22;
			size = new System.Drawing.Size(45, 44);
			pictureBox112.Size = size;
			this.picBagInv22.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picBagInv22.TabIndex = 167;
			this.picBagInv22.TabStop = false;
			this.picBagInv22.Visible = false;
			this.picBagPrimary.BackColor = System.Drawing.Color.Transparent;
			this.picBagPrimary.BackgroundImage = Loadout.My.Resources.Resources.background;
			this.picBagPrimary.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.picBagPrimary.ContextMenuStrip = this.cmsRemove;
			System.Windows.Forms.PictureBox pictureBox113 = this.picBagPrimary;
			location = new System.Drawing.Point(0, 0);
			pictureBox113.Location = location;
			this.picBagPrimary.Name = "picBagPrimary";
			System.Windows.Forms.PictureBox pictureBox114 = this.picBagPrimary;
			size = new System.Drawing.Size(160, 90);
			pictureBox114.Size = size;
			this.picBagPrimary.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.picBagPrimary.TabIndex = 169;
			this.picBagPrimary.TabStop = false;
			this.picBagPrimary.Visible = false;
			this.picBagSecondary.BackColor = System.Drawing.Color.Transparent;
			this.picBagSecondary.BackgroundImage = Loadout.My.Resources.Resources.background;
			this.picBagSecondary.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.picBagSecondary.ContextMenuStrip = this.cmsRemove;
			System.Windows.Forms.PictureBox pictureBox115 = this.picBagSecondary;
			location = new System.Drawing.Point(167, 0);
			pictureBox115.Location = location;
			this.picBagSecondary.Name = "picBagSecondary";
			System.Windows.Forms.PictureBox pictureBox116 = this.picBagSecondary;
			size = new System.Drawing.Size(160, 90);
			pictureBox116.Size = size;
			this.picBagSecondary.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.picBagSecondary.TabIndex = 170;
			this.picBagSecondary.TabStop = false;
			this.picBagSecondary.Visible = false;
			this.picBagInv24.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			this.picBagInv24.BackColor = System.Drawing.Color.Transparent;
			this.picBagInv24.BackgroundImage = Loadout.My.Resources.Resources.background;
			this.picBagInv24.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.picBagInv24.ContextMenuStrip = this.cmsRemove;
			System.Windows.Forms.PictureBox pictureBox117 = this.picBagInv24;
			location = new System.Drawing.Point(94, 140);
			pictureBox117.Location = location;
			this.picBagInv24.Name = "picBagInv24";
			System.Windows.Forms.PictureBox pictureBox118 = this.picBagInv24;
			size = new System.Drawing.Size(45, 44);
			pictureBox118.Size = size;
			this.picBagInv24.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.picBagInv24.TabIndex = 171;
			this.picBagInv24.TabStop = false;
			this.picBagInv24.Visible = false;
			this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.panel2.BackColor = System.Drawing.Color.Transparent;
			this.panel2.Controls.Add(this.picBackpack);
			this.panel2.Controls.Add(this.picPrimary);
			this.panel2.Controls.Add(this.picPrimaryInv1);
			this.panel2.Controls.Add(this.picPrimaryInv2);
			this.panel2.Controls.Add(this.picPrimaryInv4);
			this.panel2.Controls.Add(this.picPrimaryInv3);
			this.panel2.Controls.Add(this.picPrimaryInv5);
			this.panel2.Controls.Add(this.picPrimaryInv6);
			this.panel2.Controls.Add(this.picPrimaryInv8);
			this.panel2.Controls.Add(this.picPrimaryInv7);
			this.panel2.Controls.Add(this.picPrimaryInv9);
			this.panel2.Controls.Add(this.picPrimaryInv10);
			this.panel2.Controls.Add(this.picPrimaryInv12);
			this.panel2.Controls.Add(this.picPrimaryInv11);
			System.Windows.Forms.Panel panel3 = this.panel2;
			location = new System.Drawing.Point(378, 159);
			panel3.Location = location;
			this.panel2.Name = "panel2";
			System.Windows.Forms.Panel panel4 = this.panel2;
			size = new System.Drawing.Size(352, 182);
			panel4.Size = size;
			this.panel2.TabIndex = 172;
			this.panel3.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.panel3.BackColor = System.Drawing.Color.Transparent;
			this.panel3.Controls.Add(this.picSecondary);
			this.panel3.Controls.Add(this.picSecondaryInv1);
			this.panel3.Controls.Add(this.picSecondaryInv2);
			this.panel3.Controls.Add(this.picSecondaryInv3);
			this.panel3.Controls.Add(this.picSecondaryInv4);
			this.panel3.Controls.Add(this.picSecondaryInv5);
			this.panel3.Controls.Add(this.picSecondaryInv6);
			this.panel3.Controls.Add(this.picSecondaryInv7);
			this.panel3.Controls.Add(this.picSecondaryInv8);
			System.Windows.Forms.Panel panel5 = this.panel3;
			location = new System.Drawing.Point(378, 343);
			panel5.Location = location;
			this.panel3.Name = "panel3";
			System.Windows.Forms.Panel panel6 = this.panel3;
			size = new System.Drawing.Size(352, 90);
			panel6.Size = size;
			this.panel3.TabIndex = 173;
			this.panel4.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.panel4.BackColor = System.Drawing.Color.Transparent;
			this.panel4.Controls.Add(this.picToolInv1);
			this.panel4.Controls.Add(this.picToolInv7);
			this.panel4.Controls.Add(this.picToolInv6);
			this.panel4.Controls.Add(this.picToolInv5);
			this.panel4.Controls.Add(this.picToolInv4);
			this.panel4.Controls.Add(this.picToolInv2);
			this.panel4.Controls.Add(this.picToolInv3);
			System.Windows.Forms.Panel panel7 = this.panel4;
			location = new System.Drawing.Point(391, 449);
			panel7.Location = location;
			this.panel4.Name = "panel4";
			System.Windows.Forms.Panel panel8 = this.panel4;
			size = new System.Drawing.Size(327, 44);
			panel8.Size = size;
			this.panel4.TabIndex = 174;
			this.panel5.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.panel5.BackColor = System.Drawing.Color.Transparent;
			this.panel5.Controls.Add(this.picBagInv1);
			this.panel5.Controls.Add(this.picBagInv2);
			this.panel5.Controls.Add(this.picBagInv24);
			this.panel5.Controls.Add(this.picBagInv3);
			this.panel5.Controls.Add(this.picBagInv4);
			this.panel5.Controls.Add(this.picBagInv23);
			this.panel5.Controls.Add(this.picBagInv5);
			this.panel5.Controls.Add(this.picBagInv22);
			this.panel5.Controls.Add(this.picBagInv6);
			this.panel5.Controls.Add(this.picBagInv21);
			this.panel5.Controls.Add(this.picBagInv7);
			this.panel5.Controls.Add(this.picBagInv20);
			this.panel5.Controls.Add(this.picBagInv8);
			this.panel5.Controls.Add(this.picBagInv19);
			this.panel5.Controls.Add(this.picBagInv9);
			this.panel5.Controls.Add(this.picBagInv18);
			this.panel5.Controls.Add(this.picBagInv10);
			this.panel5.Controls.Add(this.picBagInv17);
			this.panel5.Controls.Add(this.picBagInv11);
			this.panel5.Controls.Add(this.picBagInv16);
			this.panel5.Controls.Add(this.picBagInv12);
			this.panel5.Controls.Add(this.picBagInv15);
			this.panel5.Controls.Add(this.picBagInv13);
			this.panel5.Controls.Add(this.picBagInv14);
			System.Windows.Forms.Panel panel9 = this.panel5;
			location = new System.Drawing.Point(760, 52);
			panel9.Location = location;
			this.panel5.Name = "panel5";
			System.Windows.Forms.Panel panel10 = this.panel5;
			size = new System.Drawing.Size(327, 185);
			panel10.Size = size;
			this.panel5.TabIndex = 175;
			this.panel6.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.panel6.BackColor = System.Drawing.Color.Transparent;
			this.panel6.Controls.Add(this.picBagPrimary);
			this.panel6.Controls.Add(this.picBagSecondary);
			System.Windows.Forms.Panel panel11 = this.panel6;
			location = new System.Drawing.Point(760, 251);
			panel11.Location = location;
			this.panel6.Name = "panel6";
			System.Windows.Forms.Panel panel12 = this.panel6;
			size = new System.Drawing.Size(327, 90);
			panel12.Size = size;
			this.panel6.TabIndex = 176;
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.BackgroundImage = Loadout.My.Resources.Resources.gear;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			size = new System.Drawing.Size(1109, 555);
			this.ClientSize = size;
			this.Controls.Add(this.panel6);
			this.Controls.Add(this.picOptics1);
			this.Controls.Add(this.picOptics2);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.btnGenerateInv);
			this.Controls.Add(this.btnGenerateBag);
			this.Controls.Add(this.groupBackpack);
			this.Controls.Add(this.groupPreview);
			this.Controls.Add(this.groupResult);
			this.Controls.Add(this.panel2);
			this.Controls.Add(this.panel3);
			this.Controls.Add(this.panel4);
			this.Controls.Add(this.panel5);
			this.DoubleBuffered = true;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmMain";
			this.ShowIcon = true;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.Text = "DayZ Loadout Generator";
			this.cmsRemove.ResumeLayout(false);
			this.groupResult.ResumeLayout(false);
			this.groupResult.PerformLayout();
			this.groupPreview.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)this.picPreview).EndInit();
			this.groupBackpack.ResumeLayout(false);
			this.groupBackpack.PerformLayout();
			this.panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)this.picOptics2).EndInit();
			((System.ComponentModel.ISupportInitialize)this.picOptics1).EndInit();
			((System.ComponentModel.ISupportInitialize)this.picPrimary).EndInit();
			((System.ComponentModel.ISupportInitialize)this.picBackpack).EndInit();
			((System.ComponentModel.ISupportInitialize)this.picSecondary).EndInit();
			((System.ComponentModel.ISupportInitialize)this.picPrimaryInv1).EndInit();
			((System.ComponentModel.ISupportInitialize)this.picPrimaryInv2).EndInit();
			((System.ComponentModel.ISupportInitialize)this.picPrimaryInv4).EndInit();
			((System.ComponentModel.ISupportInitialize)this.picPrimaryInv3).EndInit();
			((System.ComponentModel.ISupportInitialize)this.picPrimaryInv7).EndInit();
			((System.ComponentModel.ISupportInitialize)this.picPrimaryInv8).EndInit();
			((System.ComponentModel.ISupportInitialize)this.picPrimaryInv6).EndInit();
			((System.ComponentModel.ISupportInitialize)this.picPrimaryInv5).EndInit();
			((System.ComponentModel.ISupportInitialize)this.picPrimaryInv11).EndInit();
			((System.ComponentModel.ISupportInitialize)this.picPrimaryInv12).EndInit();
			((System.ComponentModel.ISupportInitialize)this.picPrimaryInv10).EndInit();
			((System.ComponentModel.ISupportInitialize)this.picPrimaryInv9).EndInit();
			((System.ComponentModel.ISupportInitialize)this.picSecondaryInv1).EndInit();
			((System.ComponentModel.ISupportInitialize)this.picSecondaryInv2).EndInit();
			((System.ComponentModel.ISupportInitialize)this.picSecondaryInv3).EndInit();
			((System.ComponentModel.ISupportInitialize)this.picSecondaryInv4).EndInit();
			((System.ComponentModel.ISupportInitialize)this.picSecondaryInv8).EndInit();
			((System.ComponentModel.ISupportInitialize)this.picSecondaryInv7).EndInit();
			((System.ComponentModel.ISupportInitialize)this.picSecondaryInv6).EndInit();
			((System.ComponentModel.ISupportInitialize)this.picSecondaryInv5).EndInit();
			((System.ComponentModel.ISupportInitialize)this.picToolInv1).EndInit();
			((System.ComponentModel.ISupportInitialize)this.picToolInv7).EndInit();
			((System.ComponentModel.ISupportInitialize)this.picToolInv6).EndInit();
			((System.ComponentModel.ISupportInitialize)this.picToolInv5).EndInit();
			((System.ComponentModel.ISupportInitialize)this.picToolInv4).EndInit();
			((System.ComponentModel.ISupportInitialize)this.picToolInv2).EndInit();
			((System.ComponentModel.ISupportInitialize)this.picToolInv3).EndInit();
			((System.ComponentModel.ISupportInitialize)this.picBagInv1).EndInit();
			((System.ComponentModel.ISupportInitialize)this.picBagInv2).EndInit();
			((System.ComponentModel.ISupportInitialize)this.picBagInv3).EndInit();
			((System.ComponentModel.ISupportInitialize)this.picBagInv4).EndInit();
			((System.ComponentModel.ISupportInitialize)this.picBagInv5).EndInit();
			((System.ComponentModel.ISupportInitialize)this.picBagInv6).EndInit();
			((System.ComponentModel.ISupportInitialize)this.picBagInv7).EndInit();
			((System.ComponentModel.ISupportInitialize)this.picBagInv14).EndInit();
			((System.ComponentModel.ISupportInitialize)this.picBagInv13).EndInit();
			((System.ComponentModel.ISupportInitialize)this.picBagInv12).EndInit();
			((System.ComponentModel.ISupportInitialize)this.picBagInv11).EndInit();
			((System.ComponentModel.ISupportInitialize)this.picBagInv10).EndInit();
			((System.ComponentModel.ISupportInitialize)this.picBagInv9).EndInit();
			((System.ComponentModel.ISupportInitialize)this.picBagInv8).EndInit();
			((System.ComponentModel.ISupportInitialize)this.picBagInv21).EndInit();
			((System.ComponentModel.ISupportInitialize)this.picBagInv20).EndInit();
			((System.ComponentModel.ISupportInitialize)this.picBagInv19).EndInit();
			((System.ComponentModel.ISupportInitialize)this.picBagInv18).EndInit();
			((System.ComponentModel.ISupportInitialize)this.picBagInv17).EndInit();
			((System.ComponentModel.ISupportInitialize)this.picBagInv16).EndInit();
			((System.ComponentModel.ISupportInitialize)this.picBagInv15).EndInit();
			((System.ComponentModel.ISupportInitialize)this.picBagInv23).EndInit();
			((System.ComponentModel.ISupportInitialize)this.picBagInv22).EndInit();
			((System.ComponentModel.ISupportInitialize)this.picBagPrimary).EndInit();
			((System.ComponentModel.ISupportInitialize)this.picBagSecondary).EndInit();
			((System.ComponentModel.ISupportInitialize)this.picBagInv24).EndInit();
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.panel4.ResumeLayout(false);
			this.panel5.ResumeLayout(false);
			this.panel6.ResumeLayout(false);
			this.ResumeLayout(false);
		}

		private void combobox_KeyDown(object sender, KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
			case Keys.Up:
				e.SuppressKeyPress = false;
				break;
			case Keys.Down:
				e.SuppressKeyPress = false;
				break;
			default:
				e.SuppressKeyPress = true;
				break;
			}
		}

		private void comboboxFOOD_SelectedIndexChanged(object sender, EventArgs e)
		{
			comboboxMEDICAL.Text = "Medical:";
			comboboxTOOLS.Text = "Tools and Accesories:";
			comboboxPARTS.Text = "Parts:";
			comboboxPISTOL.Text = "Pistols:";
			comboboxRIFLE.Text = "Assault Rifles:";
			comboboxSUBMACHINE.Text = "Sub Machine Guns:";
			comboboxSHOTGUN.Text = "Shotguns:";
			comboboxSNIPER.Text = "Sniper Rifles:";
			comboboxMACHINEGUN.Text = "Machine Guns:";
			comboboxMISC.Text = "Clothing and Misc:";
			btnAddInv.Enabled = true;
			btnAddBag.Enabled = true;
			object selectedItem = comboboxFOOD.SelectedItem;
			if (Operators.ConditionalCompareObjectEqual(selectedItem, "Raw Steak", false))
			{
				invtype = 3;
				itemsize = 1;
				itempicture = 0;
				itemname = "FoodSteakRaw";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Cooked Steak", false))
			{
				invtype = 3;
				itemsize = 1;
				itempicture = 1;
				itemname = "FoodSteakCooked";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Baked Beans", false))
			{
				invtype = 3;
				itemsize = 1;
				itempicture = 2;
				itemname = "FoodCanBakedBeans";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Sardines", false))
			{
				invtype = 3;
				itemsize = 1;
				itempicture = 3;
				itemname = "FoodCanSardines";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Pasta", false))
			{
				invtype = 3;
				itemsize = 1;
				itempicture = 4;
				itemname = "FoodCanPasta";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Coke", false))
			{
				invtype = 3;
				itemsize = 1;
				itempicture = 5;
				itemname = "ItemSodaCoke";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Pepsi", false))
			{
				invtype = 3;
				itemsize = 1;
				itempicture = 6;
				itemname = "ItemSodaPepsi";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Water Bottle", false))
			{
				invtype = 3;
				itemsize = 1;
				itempicture = 7;
				itemname = "ItemWaterBottle";
			}
			else
			{
				MessageBox.Show("Please Select a Valid Item", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			picPreview.Image = imgPrimaryInv.Images[itempicture];
		}

		private void comboboxMEDICAL_SelectedIndexChanged(object sender, EventArgs e)
		{
			comboboxFOOD.Text = "Food:";
			comboboxTOOLS.Text = "Tools and Accesories:";
			comboboxPARTS.Text = "Parts:";
			comboboxPISTOL.Text = "Pistols:";
			comboboxRIFLE.Text = "Assault Rifles:";
			comboboxSUBMACHINE.Text = "Sub Machine Guns:";
			comboboxSHOTGUN.Text = "Shotguns:";
			comboboxSNIPER.Text = "Sniper Rifles:";
			comboboxMACHINEGUN.Text = "Machine Guns:";
			comboboxMISC.Text = "Clothing and Misc:";
			btnAddInv.Enabled = true;
			btnAddBag.Enabled = true;
			object selectedItem = comboboxMEDICAL.SelectedItem;
			if (Operators.ConditionalCompareObjectEqual(selectedItem, "Bandage", false))
			{
				invtype = 5;
				itemsize = 1;
				itempicture = 0;
				itemname = "ItemBandage";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Pain Killers", false))
			{
				invtype = 3;
				itemsize = 1;
				itempicture = 8;
				itemname = "ItemPainkiller";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Morphine", false))
			{
				invtype = 3;
				itemsize = 1;
				itempicture = 9;
				itemname = "ItemMorphine";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Epinephrine", false))
			{
				invtype = 3;
				itemsize = 1;
				itempicture = 10;
				itemname = "ItemEpinephrine";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Antibiotic", false))
			{
				invtype = 3;
				itemsize = 1;
				itempicture = 11;
				itemname = "ItemAntibiotic";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Blood Bag", false))
			{
				invtype = 3;
				itemsize = 1;
				itempicture = 12;
				itemname = "ItemBloodbag";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Heat Pack", false))
			{
				invtype = 3;
				itemsize = 1;
				itempicture = 13;
				itemname = "ItemHeatPack";
			}
			else
			{
				MessageBox.Show("Please Select a Valid Item", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			if (invtype == 3)
			{
				picPreview.Image = imgPrimaryInv.Images[itempicture];
			}
			else
			{
				picPreview.Image = imgSecondaryInv.Images[itempicture];
			}
		}

		private void comboboxTOOLS_SelectedIndexChanged(object sender, EventArgs e)
		{
			comboboxFOOD.Text = "Food:";
			comboboxMEDICAL.Text = "Medical:";
			comboboxTOOLS.Text = "Tools and Accesories:";
			comboboxPARTS.Text = "Parts:";
			comboboxPISTOL.Text = "Pistols:";
			comboboxRIFLE.Text = "Assault Rifles:";
			comboboxSUBMACHINE.Text = "Sub Machine Guns:";
			comboboxSHOTGUN.Text = "Shotguns:";
			comboboxSNIPER.Text = "Sniper Rifles:";
			comboboxMACHINEGUN.Text = "Machine Guns:";
			comboboxMISC.Text = "Clothing and Misc:";
			btnAddInv.Enabled = true;
			btnAddBag.Enabled = true;
			object selectedItem = comboboxTOOLS.SelectedItem;
			if (Operators.ConditionalCompareObjectEqual(selectedItem, "Binocular", false))
			{
				invtype = 1;
				itemsize = 1;
				itempicture = 0;
				itemname = "Binocular";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Range Finder", false))
			{
				invtype = 1;
				itemsize = 1;
				itempicture = 1;
				itemname = "Binocular_Vector";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Night Vision Goggles", false))
			{
				invtype = 1;
				itemsize = 1;
				itempicture = 2;
				itemname = "NVGoggles";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "GPS", false))
			{
				invtype = 6;
				itemsize = 1;
				itempicture = 3;
				itemname = "ItemGPS";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Map", false))
			{
				invtype = 6;
				itemsize = 1;
				itempicture = 4;
				itemname = "ItemMap";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Compass", false))
			{
				invtype = 6;
				itemsize = 1;
				itempicture = 5;
				itemname = "ItemCompass";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Watch", false))
			{
				invtype = 6;
				itemsize = 1;
				itempicture = 6;
				itemname = "ItemWatch";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Flashlight", false))
			{
				invtype = 6;
				itemsize = 1;
				itempicture = 7;
				itemname = "ItemFlashlight";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Military Flash Light", false))
			{
				invtype = 6;
				itemsize = 1;
				itempicture = 8;
				itemname = "ItemFlashlightRed";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Knife", false))
			{
				invtype = 6;
				itemsize = 1;
				itempicture = 9;
				itemname = "ItemKnife";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Hatchet", false))
			{
				invtype = 6;
				itemsize = 1;
				itempicture = 10;
				itemname = "ItemHatchet";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Matchbox", false))
			{
				invtype = 6;
				itemsize = 1;
				itempicture = 11;
				itemname = "ItemMatchbox";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Etrench Tool", false))
			{
				invtype = 6;
				itemsize = 1;
				itempicture = 12;
				itemname = "ItemEtool";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Tool Box", false))
			{
				invtype = 6;
				itemsize = 1;
				itempicture = 13;
				itemname = "ItemToolbox";
			}
			else
			{
				MessageBox.Show("Please Select a Valid Item", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			if (invtype == 1)
			{
				picPreview.Image = imgTools.Images[itempicture];
			}
			else
			{
				picPreview.Image = imgTools.Images[itempicture];
			}
		}

		private void comboboxPARTS_SelectedIndexChanged(object sender, EventArgs e)
		{
			comboboxFOOD.Text = "Food:";
			comboboxMEDICAL.Text = "Medical:";
			comboboxTOOLS.Text = "Tools and Accesories:";
			comboboxPISTOL.Text = "Pistols:";
			comboboxRIFLE.Text = "Assault Rifles:";
			comboboxSUBMACHINE.Text = "Sub Machine Guns:";
			comboboxSHOTGUN.Text = "Shotguns:";
			comboboxSNIPER.Text = "Sniper Rifles:";
			comboboxMACHINEGUN.Text = "Machine Guns:";
			comboboxMISC.Text = "Clothing and Misc:";
			btnAddInv.Enabled = true;
			btnAddBag.Enabled = true;
			object selectedItem = comboboxPARTS.SelectedItem;
			if (Operators.ConditionalCompareObjectEqual(selectedItem, "Wood Pile", false))
			{
				invtype = 3;
				itemsize = 2;
				itempicture = 14;
				itemname = "PartWoodPile";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Wheel", false))
			{
				invtype = 3;
				itemsize = 6;
				itempicture = 15;
				itemname = "PartWheel";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Fuel Tank", false))
			{
				invtype = 3;
				itemsize = 4;
				itempicture = 16;
				itemname = "PartFueltank";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Glass", false))
			{
				invtype = 3;
				itemsize = 2;
				itempicture = 17;
				itemname = "PartGlass";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Engine", false))
			{
				invtype = 3;
				itemsize = 6;
				itempicture = 18;
				itemname = "PartEngine";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Scrap Metal", false))
			{
				invtype = 3;
				itemsize = 3;
				itempicture = 19;
				itemname = "PartGeneric";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Helicopter Rotor", false))
			{
				invtype = 3;
				itemsize = 6;
				itempicture = 20;
				itemname = "PartVRotor";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Jerry Can", false))
			{
				invtype = 3;
				itemsize = 3;
				itempicture = 21;
				itemname = "ItemJerrycan";
			}
			else
			{
				MessageBox.Show("Please Select a Valid Item", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			picPreview.Image = imgPrimaryInv.Images[itempicture];
		}

		private void comboboxPISTOL_SelectedIndexChanged(object sender, EventArgs e)
		{
			comboboxFOOD.Text = "Food:";
			comboboxMEDICAL.Text = "Medical:";
			comboboxTOOLS.Text = "Tools and Accesories:";
			comboboxPARTS.Text = "Parts:";
			comboboxPISTOL.Text = "Pistols:";
			comboboxRIFLE.Text = "Assault Rifles:";
			comboboxSUBMACHINE.Text = "Sub Machine Guns:";
			comboboxSHOTGUN.Text = "Shotguns:";
			comboboxSNIPER.Text = "Sniper Rifles:";
			comboboxMACHINEGUN.Text = "Machine Guns:";
			comboboxMISC.Text = "Clothing and Misc:";
			btnAddInv.Enabled = true;
			btnAddBag.Enabled = true;
			object selectedItem = comboboxPISTOL.SelectedItem;
			checked
			{
				if (Operators.ConditionalCompareObjectEqual(selectedItem, "G17", false))
				{
					invtype = 4;
					itemsize = 10;
					itempicture = 0;
					itemname = "glock17_EP1";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "M9", false))
				{
					invtype = 4;
					itemsize = 10;
					itempicture = 1;
					itemname = "M9";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "M9 Silenced", false))
				{
					invtype = 4;
					itemsize = 10;
					itempicture = 2;
					itemname = "M9SD";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Makarov PM", false))
				{
					invtype = 4;
					itemsize = 10;
					itempicture = 3;
					itemname = "Makarov";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "M1911", false))
				{
					invtype = 4;
					itemsize = 10;
					itempicture = 4;
					itemname = "Colt1911";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Uzi", false))
				{
					invtype = 4;
					itemsize = 10;
					itempicture = 5;
					itemname = "UZI_EP1";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Revolver", false))
				{
					invtype = 4;
					itemsize = 10;
					itempicture = 6;
					itemname = "revolver_EP1";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "G17 Pistol Ammo", false))
				{
					invtype = 5;
					itemsize = 1;
					itempicture = 1;
					itemname = "17Rnd_9x19_glock17";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "M9 Pistol Ammo", false))
				{
					invtype = 5;
					itemsize = 1;
					itempicture = 2;
					itemname = "15Rnd_9x19_M9";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "M9 Silenced Pistol Ammo", false))
				{
					invtype = 5;
					itemsize = 1;
					itempicture = 3;
					itemname = "15Rnd_9x19_M9SD";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Makarov Pistol Ammo", false))
				{
					invtype = 5;
					itemsize = 1;
					itempicture = 4;
					itemname = "8Rnd_9x18_Makarov";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "M1911 Pistol Ammo", false))
				{
					invtype = 5;
					itemsize = 1;
					itempicture = 5;
					itemname = "7Rnd_45ACP_1911";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Uzi Pistol Ammo", false))
				{
					invtype = 5;
					itemsize = 1;
					itempicture = 6;
					itemname = "15Rnd_9x19_M9";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Revolver Pistol Ammo", false))
				{
					invtype = 5;
					itemsize = 1;
					itempicture = 7;
					itemname = "6Rnd_45ACP";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "", false))
				{
					btnAddInv.Enabled = false;
					btnAddBag.Enabled = false;
					if (keyinput == 38)
					{
						comboboxPISTOL.SelectedIndex -= 1;
					}
					if (keyinput == 40)
					{
						comboboxPISTOL.SelectedIndex += 1;
					}
				}
				else
				{
					MessageBox.Show("Please Select a Valid Item", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				if (invtype == 4)
				{
					picPreview.Image = imgSecondaryWeapons.Images[itempicture];
				}
				else
				{
					picPreview.Image = imgSecondaryInv.Images[itempicture];
				}
			}
		}

		private void comboboxRIFLE_SelectedIndexChanged(object sender, EventArgs e)
		{
			comboboxFOOD.Text = "Food:";
			comboboxMEDICAL.Text = "Medical:";
			comboboxTOOLS.Text = "Tools and Accessories:";
			comboboxPARTS.Text = "Parts:";
			comboboxPISTOL.Text = "Pistols:";
			comboboxSUBMACHINE.Text = "Sub Machine Guns:";
			comboboxSHOTGUN.Text = "Shotguns:";
			comboboxSNIPER.Text = "Sniper Rifles:";
			comboboxMACHINEGUN.Text = "Machine Guns:";
			comboboxMISC.Text = "Clothing and Misc:";
			btnAddInv.Enabled = true;
			btnAddBag.Enabled = true;
			object selectedItem = comboboxRIFLE.SelectedItem;
			checked
			{
				if (Operators.ConditionalCompareObjectEqual(selectedItem, "AK-74", false))
				{
					invtype = 2;
					itemsize = 10;
					itempicture = 0;
					itemname = "AK_74";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "AKM", false))
				{
					invtype = 2;
					itemsize = 10;
					itempicture = 1;
					itemname = "AK_47_M";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "AKS-74 Kobra", false))
				{
					invtype = 2;
					itemsize = 10;
					itempicture = 2;
					itemname = "AKS_74_kobra";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "AKS-74U", false))
				{
					invtype = 2;
					itemsize = 10;
					itempicture = 3;
					itemname = "AKS_74_U";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "FN FAL", false))
				{
					invtype = 2;
					itemsize = 10;
					itempicture = 4;
					itemname = "FN_FAL";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "FN FAL AN/PVS-4", false))
				{
					invtype = 2;
					itemsize = 10;
					itempicture = 5;
					itemname = "FN_FAL_ANPVS4";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "L85A2 AWS", false))
				{
					invtype = 2;
					itemsize = 10;
					itempicture = 6;
					itemname = "BAF_L85A2_RIS_CWS";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Lee Enfield", false))
				{
					invtype = 2;
					itemsize = 10;
					itempicture = 7;
					itemname = "LeeEnfield";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "M16A2", false))
				{
					invtype = 2;
					itemsize = 10;
					itempicture = 8;
					itemname = "M16A2";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "M16A2 M203", false))
				{
					invtype = 2;
					itemsize = 10;
					itempicture = 9;
					itemname = "M16A2GL";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "M16A2 ACOG", false))
				{
					invtype = 2;
					itemsize = 10;
					itempicture = 10;
					itemname = "m16a4_acg";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "M4A1", false))
				{
					invtype = 2;
					itemsize = 10;
					itempicture = 11;
					itemname = "M4A1";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "M4A1 CCO Silenced", false))
				{
					invtype = 2;
					itemsize = 10;
					itempicture = 12;
					itemname = "M4A1_AIM_SD_camo";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "M4A1 CCO", false))
				{
					invtype = 2;
					itemsize = 10;
					itempicture = 13;
					itemname = "M4A1_Aim";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "M4A3 CCO", false))
				{
					invtype = 2;
					itemsize = 10;
					itempicture = 14;
					itemname = "M4A3_CCO_EP1";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Cross Bow", false))
				{
					invtype = 2;
					itemsize = 10;
					itempicture = 15;
					itemname = "Crossbow";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "30 Round AK-74 Magazine", false))
				{
					invtype = 3;
					itemsize = 1;
					itempicture = 22;
					itemname = "30Rnd_545x39_AK";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "30 Round AKM Magazine", false))
				{
					invtype = 3;
					itemsize = 1;
					itempicture = 23;
					itemname = "30Rnd_762x39_AK47";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "30 Round AKS-74 Kobra Magazine", false))
				{
					invtype = 3;
					itemsize = 1;
					itempicture = 24;
					itemname = "30Rnd_545x39_AK";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "30 Round AKS-74U Magazine", false))
				{
					invtype = 3;
					itemsize = 1;
					itempicture = 25;
					itemname = "30Rnd_545x39_AK";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "30 Round FN FAL Magazine", false))
				{
					invtype = 3;
					itemsize = 1;
					itempicture = 26;
					itemname = "20Rnd_762x51_FNFAL";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "30 Round FN FAL AN/PVS-4 Magazine", false))
				{
					invtype = 3;
					itemsize = 1;
					itempicture = 27;
					itemname = "20Rnd_762x51_FNFAL";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "30 Round L85A2 AWS Magazine", false))
				{
					invtype = 3;
					itemsize = 1;
					itempicture = 28;
					itemname = "30Rnd_556x45_Stanag";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "10 Round Lee Enfield Magazine", false))
				{
					invtype = 3;
					itemsize = 1;
					itempicture = 29;
					itemname = "10x_303";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "30 Round M16A2 Magazine", false))
				{
					invtype = 3;
					itemsize = 1;
					itempicture = 30;
					itemname = "30Rnd_556x45_Stanag";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "30 Round M16A4 ACOG Magazine", false))
				{
					invtype = 3;
					itemsize = 1;
					itempicture = 31;
					itemname = "30Rnd_556x45_Stanag";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "30 Round M4A1 Magazine", false))
				{
					invtype = 3;
					itemsize = 1;
					itempicture = 32;
					itemname = "30Rnd_556x45_Stanag";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "30 Round M4A1 CCO Silenced Magazine", false))
				{
					invtype = 3;
					itemsize = 1;
					itempicture = 33;
					itemname = "30Rnd_556x45_StanagSD";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "30 Round M4A1 CCO Magazine", false))
				{
					invtype = 3;
					itemsize = 1;
					itempicture = 34;
					itemname = "30Rnd_556x45_Stanag";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "30 Round M4A1 Holo Magazine", false))
				{
					invtype = 3;
					itemsize = 1;
					itempicture = 35;
					itemname = "30Rnd_556x45_Stanag";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "30 Round M4A3 CCO  Magazine", false))
				{
					invtype = 3;
					itemsize = 1;
					itempicture = 36;
					itemname = "30Rnd_556x45_Stanag";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "1 Round Steel Bolt Crossbow Magazine", false))
				{
					invtype = 3;
					itemsize = 1;
					itempicture = 37;
					itemname = "BoltSteel";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "1 Round M203 HE Magazine", false))
				{
					invtype = 5;
					itemsize = 1;
					itempicture = 8;
					itemname = "1Rnd_HE_M203";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "1 Round M203 Smoke Magazine", false))
				{
					invtype = 5;
					itemsize = 1;
					itempicture = 9;
					itemname = "1Rnd_Smoke_M203";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "1 Round M203 Flare White Magazine", false))
				{
					invtype = 5;
					itemsize = 1;
					itempicture = 10;
					itemname = "FlareWhite_M203";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "1 Round M203 Flare Green Magazine", false))
				{
					invtype = 5;
					itemsize = 1;
					itempicture = 11;
					itemname = "FlareGreen_M203";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "", false))
				{
					btnAddInv.Enabled = false;
					btnAddBag.Enabled = false;
					if (keyinput == 38)
					{
						comboboxRIFLE.SelectedIndex -= 1;
					}
					if (keyinput == 40)
					{
						comboboxRIFLE.SelectedIndex += 1;
					}
				}
				else
				{
					MessageBox.Show("Please Select a Valid Item", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				if (invtype == 2)
				{
					picPreview.Image = imgPrimaryWeapons.Images[itempicture];
				}
				else if (invtype == 3)
				{
					picPreview.Image = imgPrimaryInv.Images[itempicture];
				}
				else
				{
					picPreview.Image = imgSecondaryInv.Images[itempicture];
				}
			}
		}

		private void comboboxSUBMACHINE_SelectedIndexChanged(object sender, EventArgs e)
		{
			comboboxFOOD.Text = "Food:";
			comboboxMEDICAL.Text = "Medical:";
			comboboxTOOLS.Text = "Tools and Accessories:";
			comboboxPARTS.Text = "Parts:";
			comboboxPISTOL.Text = "Pistols:";
			comboboxRIFLE.Text = "Assault Rifles:";
			comboboxSHOTGUN.Text = "Shotguns:";
			comboboxSNIPER.Text = "Sniper Rifles:";
			comboboxMACHINEGUN.Text = "Machine Guns:";
			comboboxMISC.Text = "Clothing and Misc:";
			btnAddInv.Enabled = true;
			btnAddBag.Enabled = true;
			object selectedItem = comboboxSUBMACHINE.SelectedItem;
			checked
			{
				if (Operators.ConditionalCompareObjectEqual(selectedItem, "Bizon PP-19 Silenced", false))
				{
					invtype = 2;
					itemsize = 10;
					itempicture = 16;
					itemname = "bizon_silenced";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "MP5A5", false))
				{
					invtype = 2;
					itemsize = 10;
					itempicture = 17;
					itemname = "MP5A5";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "MP5 Silenced", false))
				{
					invtype = 2;
					itemsize = 10;
					itempicture = 18;
					itemname = "MP5SD";
					itemname = "MP5SD";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "64 Round Bizon PP-19 SD Magazine", false))
				{
					invtype = 3;
					itemsize = 10;
					itempicture = 38;
					itemname = "64Rnd_9x19_SD_Bizon";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "30 Round MP5A5 Magazine", false))
				{
					invtype = 3;
					itemsize = 1;
					itempicture = 39;
					itemname = "30Rnd_9x19_MP5";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "30 Round  MP5 Silenced Magazine", false))
				{
					invtype = 3;
					itemsize = 1;
					itempicture = 40;
					itemname = "30Rnd_9x19_MP5SD";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "", false))
				{
					btnAddInv.Enabled = false;
					btnAddBag.Enabled = false;
					if (keyinput == 38)
					{
						comboboxSUBMACHINE.SelectedIndex -= 1;
					}
					if (keyinput == 40)
					{
						comboboxSUBMACHINE.SelectedIndex += 1;
					}
				}
				else
				{
					MessageBox.Show("Please Select a Valid Item", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				if (invtype == 2)
				{
					picPreview.Image = imgPrimaryWeapons.Images[itempicture];
				}
				else
				{
					picPreview.Image = imgPrimaryInv.Images[itempicture];
				}
			}
		}

		private void comboboxSHOTGUN_SelectedIndexChanged(object sender, EventArgs e)
		{
			comboboxFOOD.Text = "Food:";
			comboboxMEDICAL.Text = "Medical:";
			comboboxTOOLS.Text = "Tools and Accessories:";
			comboboxPARTS.Text = "Parts:";
			comboboxPISTOL.Text = "Pistols:";
			comboboxRIFLE.Text = "Assault Rifles:";
			comboboxSUBMACHINE.Text = "Sub Machine Guns:";
			comboboxSNIPER.Text = "Sniper Rifles:";
			comboboxMACHINEGUN.Text = "Machine Guns:";
			comboboxMISC.Text = "Clothing and Misc:";
			btnAddInv.Enabled = true;
			btnAddBag.Enabled = true;
			object selectedItem = comboboxSHOTGUN.SelectedItem;
			checked
			{
				if (Operators.ConditionalCompareObjectEqual(selectedItem, "Double Barrel Shotgun", false))
				{
					invtype = 2;
					itemsize = 10;
					itempicture = 19;
					itemname = "MR43";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "M1014", false))
				{
					invtype = 2;
					itemsize = 10;
					itempicture = 20;
					itemname = "M1014";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Remington 870", false))
				{
					invtype = 2;
					itemsize = 10;
					itempicture = 21;
					itemname = "Remington870_lamp";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Winchester 1866", false))
				{
					invtype = 2;
					itemsize = 10;
					itempicture = 22;
					itemname = "Winchester1866";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "8 Round Shotgun Slugs", false))
				{
					invtype = 3;
					itemsize = 10;
					itempicture = 41;
					itemname = "8Rnd_B_Beneli_74Slug";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "8 Round Shotgun Pellets", false))
				{
					invtype = 3;
					itemsize = 10;
					itempicture = 42;
					itemname = "8Rnd_B_Beneli_Pellets";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "15 Round 1866 Shotgun Slugs", false))
				{
					invtype = 3;
					itemsize = 10;
					itempicture = 43;
					itemname = "15Rnd_W1866_Slug";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "", false))
				{
					btnAddInv.Enabled = false;
					btnAddBag.Enabled = false;
					if (keyinput == 38)
					{
						comboboxSHOTGUN.SelectedIndex -= 1;
					}
					if (keyinput == 40)
					{
						comboboxSHOTGUN.SelectedIndex += 1;
					}
				}
				else
				{
					MessageBox.Show("Please Select a Valid Item", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				if (invtype == 2)
				{
					picPreview.Image = imgPrimaryWeapons.Images[itempicture];
				}
				else
				{
					picPreview.Image = imgPrimaryInv.Images[itempicture];
				}
			}
		}

		private void comboboxSNIPER_SelectedIndexChanged(object sender, EventArgs e)
		{
			comboboxFOOD.Text = "Food:";
			comboboxMEDICAL.Text = "Medical:";
			comboboxTOOLS.Text = "Tools and Accessories:";
			comboboxPARTS.Text = "Parts:";
			comboboxPISTOL.Text = "Pistols:";
			comboboxRIFLE.Text = "Assault Rifles:";
			comboboxSUBMACHINE.Text = "Sub Machine Guns:";
			comboboxSHOTGUN.Text = "Shotguns:";
			comboboxMACHINEGUN.Text = "Machine Guns:";
			comboboxMISC.Text = "Clothing and Misc:";
			btnAddInv.Enabled = true;
			btnAddBag.Enabled = true;
			object selectedItem = comboboxSNIPER.SelectedItem;
			checked
			{
				if (Operators.ConditionalCompareObjectEqual(selectedItem, "AS50", false))
				{
					invtype = 2;
					itemsize = 10;
					itempicture = 23;
					itemname = "BAF_AS50_scoped";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "CZ50", false))
				{
					invtype = 2;
					itemsize = 10;
					itempicture = 24;
					itemname = "huntingrifle";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "DMR", false))
				{
					invtype = 2;
					itemsize = 10;
					itempicture = 25;
					itemname = "DMR";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "M14 AIM", false))
				{
					invtype = 2;
					itemsize = 10;
					itempicture = 26;
					itemname = "M14_EP1";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "M24", false))
				{
					invtype = 2;
					itemsize = 10;
					itempicture = 27;
					itemname = "M24";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "M107", false))
				{
					invtype = 2;
					itemsize = 10;
					itempicture = 28;
					itemname = "m107_DZ";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "SVD Camo", false))
				{
					invtype = 2;
					itemsize = 10;
					itempicture = 29;
					itemname = "SVD_Camo";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "10 Round AS50 Magazine", false))
				{
					invtype = 3;
					itemsize = 1;
					itempicture = 44;
					itemname = "10Rnd_127x99_m107";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "5 Round CZ550 Magazine", false))
				{
					invtype = 3;
					itemsize = 1;
					itempicture = 45;
					itemname = "5x_22_LR_17_HMR";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "20 Round DMR Magazine", false))
				{
					invtype = 3;
					itemsize = 1;
					itempicture = 46;
					itemname = "20Rnd_762x51_DMR";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "20 Round M14 AIM Magazine", false))
				{
					invtype = 3;
					itemsize = 1;
					itempicture = 47;
					itemname = "20Rnd_762x51_DMR";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "5 Round M24 Magazine", false))
				{
					invtype = 3;
					itemsize = 1;
					itempicture = 48;
					itemname = "5Rnd_762x51_M24";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "10 Round M107 Magazine", false))
				{
					invtype = 3;
					itemsize = 1;
					itempicture = 49;
					itemname = "10Rnd_127x99_m107";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "10 Round SVD Camo Magazine", false))
				{
					invtype = 3;
					itemsize = 1;
					itempicture = 50;
					itemname = "10Rnd_762x54_SVD";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "", false))
				{
					btnAddInv.Enabled = false;
					btnAddBag.Enabled = false;
					if (keyinput == 38)
					{
						comboboxSNIPER.SelectedIndex -= 1;
					}
					if (keyinput == 40)
					{
						comboboxSNIPER.SelectedIndex += 1;
					}
				}
				else
				{
					MessageBox.Show("Please Select a Valid Item", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				if (invtype == 2)
				{
					picPreview.Image = imgPrimaryWeapons.Images[itempicture];
				}
				else
				{
					picPreview.Image = imgPrimaryInv.Images[itempicture];
				}
			}
		}

		private void comboboxMACHINEGUN_SelectedIndexChanged(object sender, EventArgs e)
		{
			comboboxFOOD.Text = "Food:";
			comboboxMEDICAL.Text = "Medical:";
			comboboxTOOLS.Text = "Tools and Accessories:";
			comboboxPARTS.Text = "Parts:";
			comboboxPISTOL.Text = "Pistols:";
			comboboxRIFLE.Text = "Assault Rifles:";
			comboboxSUBMACHINE.Text = "Sub Machine Guns:";
			comboboxSHOTGUN.Text = "Shotguns:";
			comboboxSNIPER.Text = "Sniper Rifles:";
			comboboxMISC.Text = "Clothing and Misc:";
			btnAddInv.Enabled = true;
			btnAddBag.Enabled = true;
			object selectedItem = comboboxMACHINEGUN.SelectedItem;
			checked
			{
				if (Operators.ConditionalCompareObjectEqual(selectedItem, "M240", false))
				{
					invtype = 2;
					itemsize = 10;
					itempicture = 30;
					itemname = "M240";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "M249 SAW", false))
				{
					invtype = 2;
					itemsize = 10;
					itempicture = 31;
					itemname = "M249";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Mk 48 Mod 0", false))
				{
					invtype = 2;
					itemsize = 10;
					itempicture = 32;
					itemname = "Mk_48_DZ";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "100 Round M240 Magazine", false))
				{
					invtype = 3;
					itemsize = 2;
					itempicture = 51;
					itemname = "100Rnd_762x51_M240";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "200 Round M249 SAW Magazine", false))
				{
					invtype = 3;
					itemsize = 2;
					itempicture = 52;
					itemname = "200Rnd_556x45_M249";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "100 Round MK 48 Mod 0 Magazine", false))
				{
					invtype = 3;
					itemsize = 2;
					itempicture = 53;
					itemname = "100Rnd_762x51_M240";
				}
				else if (Operators.ConditionalCompareObjectEqual(selectedItem, "", false))
				{
					btnAddInv.Enabled = false;
					btnAddBag.Enabled = false;
					if (keyinput == 38)
					{
						comboboxMACHINEGUN.SelectedIndex -= 1;
					}
					if (keyinput == 40)
					{
						comboboxMACHINEGUN.SelectedIndex += 1;
					}
				}
				else
				{
					MessageBox.Show("Please Select a Valid Item", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Hand);
				}
				if (invtype == 2)
				{
					picPreview.Image = imgPrimaryWeapons.Images[itempicture];
				}
				else
				{
					picPreview.Image = imgPrimaryInv.Images[itempicture];
				}
			}
		}

		private void comboboxMISC_SelectedIndexChanged(object sender, EventArgs e)
		{
			comboboxFOOD.Text = "Food:";
			comboboxMEDICAL.Text = "Medical:";
			comboboxTOOLS.Text = "Tools and Accessories:";
			comboboxPARTS.Text = "Parts:";
			comboboxPISTOL.Text = "Pistols:";
			comboboxRIFLE.Text = "Assault Rifles:";
			comboboxSUBMACHINE.Text = "Sub Machine Guns:";
			comboboxSHOTGUN.Text = "Shotguns:";
			comboboxSNIPER.Text = "Sniper Rifles:";
			comboboxMACHINEGUN.Text = "Machine Guns:";
			btnAddInv.Enabled = true;
			btnAddBag.Enabled = true;
			object selectedItem = comboboxMISC.SelectedItem;
			if (Operators.ConditionalCompareObjectEqual(selectedItem, "Tent", false))
			{
				invtype = 3;
				itemsize = 3;
				itempicture = 54;
				itemname = "ItemTent";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Soldier Clothing", false))
			{
				invtype = 3;
				itemsize = 1;
				itempicture = 55;
				itemname = "Skin_Soldier1_DZ";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Survivor Clothing", false))
			{
				invtype = 3;
				itemsize = 1;
				itempicture = 56;
				itemname = "Skin_Survivor2_DZ";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Camo Clothing", false))
			{
				invtype = 3;
				itemsize = 1;
				itempicture = 57;
				itemname = "Skin_Camo1_DZ";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Ghillie Suit Clothing", false))
			{
				invtype = 3;
				itemsize = 1;
				itempicture = 58;
				itemname = "Skin_Sniper1_DZ";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Satchel Charge", false))
			{
				invtype = 3;
				itemsize = 2;
				itempicture = 59;
				itemname = "PipeBomb";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "M67 Frag Grenade", false))
			{
				invtype = 3;
				itemsize = 1;
				itempicture = 60;
				itemname = "HandGrenade_west";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Road Flare", false))
			{
				invtype = 3;
				itemsize = 1;
				itempicture = 61;
				itemname = "HandRoadFlare";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Chem Light Green", false))
			{
				invtype = 3;
				itemsize = 1;
				itempicture = 62;
				itemname = "HandChemGreen";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Chem Light Blue", false))
			{
				invtype = 3;
				itemsize = 1;
				itempicture = 63;
				itemname = "HandChemBlue";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Chem Light Red", false))
			{
				invtype = 3;
				itemsize = 1;
				itempicture = 64;
				itemname = "HandChemRed";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Sand Bag", false))
			{
				invtype = 3;
				itemsize = 1;
				itempicture = 65;
				itemname = "ItemSandbag";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Tank Trap", false))
			{
				invtype = 3;
				itemsize = 1;
				itempicture = 66;
				itemname = "ItemTankTrap";
			}
			else if (Operators.ConditionalCompareObjectEqual(selectedItem, "Wire", false))
			{
				invtype = 3;
				itemsize = 1;
				itempicture = 67;
				itemname = "ItemWire";
			}
			else
			{
				MessageBox.Show("Please Select a Valid Item", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
			picPreview.Image = imgPrimaryInv.Images[itempicture];
		}

		private void picOptics_MouseEnter(object sender, EventArgs e)
		{
			ItemDelBag = 1000;
			if (Operators.CompareString(((PictureBox)sender).Name, "picOpticsL", false) == 0)
			{
				ItemDel = 0;
			}
			else
			{
				ItemDel = 1;
			}
		}

		private void picPrimary_MouseEnter(object sender, EventArgs e)
		{
			ItemDelBag = 1000;
			ItemDel = 2;
		}

		private void picSecondary_MouseEnter(object sender, EventArgs e)
		{
			ItemDelBag = 1000;
			ItemDel = 15;
		}

		private void picBackpack_MouseEnter(object sender, EventArgs e)
		{
			ItemDelBag = 1000;
			ItemDel = 999;
		}

		private void picPrimaryInv_MouseEnter(object sender, EventArgs e)
		{
			ItemDelBag = 1000;
			ItemDel = checked(Convert.ToInt32(((PictureBox)sender).Name.Replace("picPrimaryInv", string.Empty)) + 2);
		}

		private void picSecondaryInv_MouseEnter(object sender, EventArgs e)
		{
			ItemDelBag = 1000;
			ItemDel = checked(Convert.ToInt32(((PictureBox)sender).Name.Replace("picSecondaryInv", string.Empty)) + 15);
		}

		private void picToolInv_MouseEnter(object sender, EventArgs e)
		{
			ItemDelBag = 1000;
			ItemDel = checked(Convert.ToInt32(((PictureBox)sender).Name.Replace("picToolInv", string.Empty)) + 23);
		}

		private void picBagInv_MouseEnter(object sender, EventArgs e)
		{
			ItemDel = 1000;
			ItemDelBag = checked(Convert.ToInt32(((PictureBox)sender).Name.Replace("picBagInv", string.Empty)) - 1);
		}

		private void picBagPrimary_MouseEnter(object sender, EventArgs e)
		{
			ItemDel = 1000;
			ItemDelBag = 24;
		}

		private void picBagSecondary_MouseEnter(object sender, EventArgs e)
		{
			ItemDel = 1000;
			ItemDelBag = 26;
		}

		private void frmMain_Load(object sender, EventArgs e)
		{
			opticsLeft = 2;
			primaryLeft = 10;
			primaryName = string.Empty;
			primarySize = 0;
			secondaryLeft = 10;
			secondaryName = string.Empty;
			secondarySize = 0;
			inventory1Left = 12;
			inventory2Left = 8;
			toolLeft = 12;
			baginventoryLeft = 0;
			bagsecondaryName = string.Empty;
			bagsecondarySize = 0;
			bagprimaryName = string.Empty;
			bagprimarySize = 0;
			rINV = new List<string>();
			lINV = new List<string>();
			lbagINV = new List<string>();
			rbagINV = new List<string>();
			lbagINV2 = new List<string>();
			rbagINV2 = new List<string>();
			lbagINVvalues = new List<int>();
			rbagINVvalues = new List<int>();
			invtype = 0;
			itemsize = 0;
			itempicture = 0;
			itemname = string.Empty;
			Counter = 0;
			ItemDel = 0;
			ItemDelBag = 0;
			ItemHolder = string.Empty;
			BagName = string.Empty;
			MaxBagSlots = 0;
			picPrimaryInv = new List<PictureBox>(new PictureBox[12]
			{
				picPrimaryInv1, picPrimaryInv2, picPrimaryInv3, picPrimaryInv4, picPrimaryInv5, picPrimaryInv6, picPrimaryInv7, picPrimaryInv8, picPrimaryInv9, picPrimaryInv10,
				picPrimaryInv11, picPrimaryInv12
			});
			picSecondaryInv = new List<PictureBox>(new PictureBox[8] { picSecondaryInv1, picSecondaryInv2, picSecondaryInv3, picSecondaryInv4, picSecondaryInv5, picSecondaryInv6, picSecondaryInv7, picSecondaryInv8 });
			picToolInv = new List<PictureBox>(new PictureBox[7] { picToolInv1, picToolInv2, picToolInv3, picToolInv4, picToolInv5, picToolInv6, picToolInv7 });
			picBagInv = new List<PictureBox>(new PictureBox[24]
			{
				picBagInv1, picBagInv2, picBagInv3, picBagInv4, picBagInv5, picBagInv6, picBagInv7, picBagInv8, picBagInv9, picBagInv10,
				picBagInv11, picBagInv12, picBagInv13, picBagInv14, picBagInv15, picBagInv16, picBagInv17, picBagInv18, picBagInv19, picBagInv20,
				picBagInv21, picBagInv22, picBagInv23, picBagInv24
			});
		}

		private void btnGenerate_Click(object sender, EventArgs e)
		{
			string empty = string.Empty;
			checked
			{
				if ((lINV.Count > 0) & (rINV.Count > 0))
				{
					if (lINV.Count > 1)
					{
						empty = "[[\"" + lINV[0] + "\"";
						int num = lINV.Count - 1;
						for (int i = 1; i <= num; i++)
						{
							empty = empty + ",\"" + lINV[i] + "\"";
						}
						empty = empty + "],[\"" + rINV[0] + "\"";
					}
					else
					{
						empty = "[[\"" + lINV[0] + "\"],[\"" + rINV[0] + "\"";
					}
					if (rINV.Count > 1)
					{
						int num2 = rINV.Count - 1;
						for (int j = 1; j <= num2; j++)
						{
							empty = empty + ",\"" + rINV[j] + "\"";
						}
					}
					empty += "]]";
				}
				else if (lINV.Count > 0)
				{
					empty = "[[\"" + lINV[0] + "\"],[]]";
				}
				else if (rINV.Count > 0)
				{
					empty = "[[],[\"" + rINV[0] + "\"";
					int num3 = rINV.Count - 1;
					for (int k = 1; k <= num3; k++)
					{
						empty = empty + ",\"" + rINV[k] + "\"";
					}
					empty += "]]";
				}
				else
				{
					empty = "[[],[]]";
				}
				textResult.Text = empty;
			}
		}

		private void btnGenerateBag_Click(object sender, EventArgs e)
		{
			string text = string.Empty;
			checked
			{
				if ((lbagINV.Count == 0) & (rbagINV.Count == 0))
				{
					text = ((!string.IsNullOrEmpty(BagName)) ? ("[\"" + BagName + "\",[[],[]],[[],[]]]") : string.Empty);
				}
				else
				{
					lbagINV.Sort();
					lbagINV2.Sort();
					rbagINV.Sort();
					rbagINV2.Sort();
					RemoveDupes();
					if ((lbagINV.Count == 1) & (rbagINV.Count == 0))
					{
						text = "[\"" + BagName + "\",[[\"" + lbagINV[0] + "\"],[" + Conversions.ToString(lbagINVvalues[0]) + "]],[[],[]]]";
					}
					else if ((lbagINV.Count > 1) & (rbagINV.Count == 0))
					{
						text = "[\"" + BagName + "\",[[\"" + lbagINV[0] + "\"";
						int num = lbagINV.Count - 1;
						for (int i = 1; i <= num; i++)
						{
							text = text + ",\"" + lbagINV[i] + "\"";
						}
						text = text + "],[" + Conversions.ToString(lbagINVvalues[0]);
						int num2 = lbagINVvalues.Count - 1;
						for (int j = 1; j <= num2; j++)
						{
							text = text + "," + Conversions.ToString(lbagINVvalues[j]);
						}
						text += "]],[[],[]]]";
					}
					else if ((lbagINV.Count == 0) & (rbagINV.Count == 1))
					{
						text = "[\"" + BagName + "\",[[],[]],[[\"" + rbagINV[0] + "\"],[" + Conversions.ToString(rbagINVvalues[0]) + "]]]";
					}
					else if ((lbagINV.Count == 0) & (rbagINV.Count > 1))
					{
						text = "[\"" + BagName + "\",[[],[]],[[\"" + rbagINV[0] + "\"";
						int num3 = rbagINV.Count - 1;
						for (int k = 1; k <= num3; k++)
						{
							text = text + ",\"" + rbagINV[k] + "\"";
						}
						text = text + "],[" + Conversions.ToString(rbagINVvalues[0]);
						int num4 = rbagINVvalues.Count - 1;
						for (int l = 1; l <= num4; l++)
						{
							text = text + "," + Conversions.ToString(rbagINVvalues[l]);
						}
						text += "]]]";
					}
					else if ((lbagINV.Count == 1) & (rbagINV.Count == 1))
					{
						text = "[\"" + BagName + "\",[[\"" + lbagINV[0] + "\"],[" + Conversions.ToString(lbagINVvalues[0]) + "]],[[\"" + rbagINV[0] + "\"],[" + Conversions.ToString(rbagINVvalues[0]) + "]]]";
					}
					else if ((lbagINV.Count > 1) & (rbagINV.Count > 1))
					{
						text = "[\"" + BagName + "\",[[\"" + lbagINV[0] + "\"";
						int num5 = lbagINV.Count - 1;
						for (int m = 1; m <= num5; m++)
						{
							text = text + ",\"" + lbagINV[m] + "\"";
						}
						text = text + "],[" + Conversions.ToString(lbagINVvalues[0]);
						int num6 = lbagINVvalues.Count - 1;
						for (int n = 1; n <= num6; n++)
						{
							text = text + "," + Conversions.ToString(lbagINVvalues[n]);
						}
						text = text + "]],[[\"" + rbagINV[0] + "\"";
						int num7 = rbagINV.Count - 1;
						for (int num8 = 1; num8 <= num7; num8++)
						{
							text = text + ",\"" + rbagINV[num8] + "\"";
						}
						text = text + "],[" + Conversions.ToString(rbagINVvalues[0]);
						int num9 = rbagINVvalues.Count - 1;
						for (int num10 = 1; num10 <= num9; num10++)
						{
							text = text + "," + Conversions.ToString(rbagINVvalues[num10]);
						}
						text += "]]]";
					}
				}
				textResult.Text = text;
			}
		}

		private void btnAddInventory_Click(object sender, EventArgs e)
		{
			checked
			{
				switch (invtype)
				{
				case 1:
					if ((invtype == 1) & (opticsLeft - itemsize >= 0))
					{
						lINV.Add(itemname);
						opticsLeft -= itemsize;
						if (Operators.CompareString(itemname, "NVGoggles", false) == 0)
						{
							opticsName[1] = itemname;
							picOptics2.Image = imgTools.Images[itempicture];
						}
						else
						{
							opticsName[0] = itemname;
							picOptics1.Image = imgTools.Images[itempicture];
						}
					}
					break;
				case 2:
					if (primaryLeft - itemsize >= 0)
					{
						lINV.Add(itemname);
						primaryName = itemname;
						primarySize = itemsize;
						primaryLeft -= itemsize;
						picPrimary.Image = imgPrimaryWeapons.Images[itempicture];
					}
					break;
				case 3:
					if ((inventory1Left - itemsize >= 0) & (itemsize == 1))
					{
						int num3 = 0;
						do
						{
							if (MainInvGridLoc[num3] == 0)
							{
								rINV.Add(itemname);
								MainInvGridLoc[num3] = 1;
								inventory1Name[num3] = itemname;
								inventory1Size[num3] = itemsize;
								inventory1Left -= itemsize;
								picPrimaryInv[num3].Image = imgPrimaryInv.Images[itempicture];
								break;
							}
							num3++;
						}
						while (num3 <= 11);
					}
					else
					{
						if (!((inventory1Left - itemsize >= 0) & (itemsize > 1)))
						{
							break;
						}
						int num4 = 0;
						do
						{
							if (MainInvGridLoc[num4] == 0)
							{
								rINV.Add(itemname);
								MainInvGridLoc[num4] = 1;
								inventory1Name[num4] = itemname;
								inventory1Size[num4] = itemsize;
								inventory1Left -= itemsize;
								picPrimaryInv[num4].Image = imgPrimaryInv.Images[itempicture];
								Counter = itemsize - 1;
								int num5 = 11;
								while (Counter > 0)
								{
									if (MainInvGridLoc[num5] == 0)
									{
										picPrimaryInv[num5].Visible = false;
										MainInvGridLoc[num5] = 3;
										Counter--;
									}
									num5 += -1;
									if (num5 < 0)
									{
										break;
									}
								}
								break;
							}
							num4++;
						}
						while (num4 <= 11);
					}
					break;
				case 4:
					if (secondaryLeft - itemsize >= 0)
					{
						lINV.Add(itemname);
						secondaryName = itemname;
						secondarySize = itemsize;
						secondaryLeft -= itemsize;
						picSecondary.Image = imgSecondaryWeapons.Images[itempicture];
					}
					break;
				case 5:
				{
					if (inventory2Left - itemsize < 0)
					{
						break;
					}
					int num2 = 0;
					do
					{
						if (SecInvGridLoc[num2] == 0)
						{
							rINV.Add(itemname);
							SecInvGridLoc[num2] = 1;
							inventory2Name[num2] = itemname;
							inventory2Size[num2] = itemsize;
							inventory2Left -= itemsize;
							picSecondaryInv[num2].Image = imgSecondaryInv.Images[itempicture];
							break;
						}
						num2++;
					}
					while (num2 <= 7);
					break;
				}
				case 6:
				{
					if (toolLeft - itemsize < 0)
					{
						break;
					}
					int num = 0;
					do
					{
						if (ToolGridLoc[num] == 0)
						{
							lINV.Add(itemname);
							ToolGridLoc[num] = 1;
							toolName[num] = itemname;
							toolSize[num] = itemsize;
							toolLeft -= itemsize;
							picToolInv[num].Image = imgTools.Images[itempicture];
							break;
						}
						num++;
					}
					while (num <= 7);
					break;
				}
				}
			}
		}

		private void btnAddBackpack_Click(object sender, EventArgs e)
		{
			checked
			{
				switch (invtype)
				{
				case 1:
				{
					if (baginventoryLeft - itemsize < 0)
					{
						break;
					}
					int num10 = MaxBagSlots - 1;
					for (int num11 = 0; num11 <= num10; num11++)
					{
						if (BagInvGridLoc[num11] == 0)
						{
							lbagINV.Add(itemname);
							lbagINV2.Add(itemname);
							BagInvGridLoc[num11] = 1;
							baginventoryName[num11] = itemname;
							baginventorySize[num11] = itemsize;
							itemdelside[num11] = 0;
							baginventoryLeft -= itemsize;
							picBagInv[num11].Image = imgTools.Images[itempicture];
							break;
						}
					}
					break;
				}
				case 2:
				{
					if (baginventoryLeft - itemsize < 0)
					{
						break;
					}
					int num7 = MaxBagSlots - 1;
					int num8 = 0;
					if (num8 > num7)
					{
						break;
					}
					lbagINV.Add(itemname);
					lbagINV2.Add(itemname);
					itemdelside[num8 + 24] = 2;
					baginventoryLeft -= itemsize;
					bagprimaryName = itemname;
					bagprimarySize = itemsize;
					picBagPrimary.Visible = true;
					picBagPrimary.Image = imgPrimaryWeapons.Images[itempicture];
					Counter = itemsize;
					for (int num9 = MaxBagSlots - 1; num9 >= 0; num9 += -1)
					{
						if (Counter == 0)
						{
							break;
						}
						if (BagInvGridLoc[num9] == 0)
						{
							BagInvGridLoc[num9] = 3;
							picBagInv[num9].Visible = false;
							Counter--;
						}
					}
					break;
				}
				case 3:
					if ((baginventoryLeft - itemsize >= 0) & (itemsize == 1))
					{
						int num4 = MaxBagSlots - 1;
						for (int k = 0; k <= num4; k++)
						{
							if (BagInvGridLoc[k] == 0)
							{
								rbagINV.Add(itemname);
								rbagINV2.Add(itemname);
								BagInvGridLoc[k] = 1;
								baginventoryName[k] = itemname;
								baginventorySize[k] = itemsize;
								itemdelside[k] = 1;
								baginventoryLeft -= itemsize;
								picBagInv[k].Image = imgPrimaryInv.Images[itempicture];
								break;
							}
						}
					}
					else
					{
						if (!((baginventoryLeft - itemsize >= 0) & (itemsize > 1)))
						{
							break;
						}
						int num5 = MaxBagSlots - 1;
						for (int l = 0; l <= num5; l++)
						{
							if (BagInvGridLoc[l] != 0)
							{
								continue;
							}
							rbagINV.Add(itemname);
							rbagINV2.Add(itemname);
							BagInvGridLoc[l] = 1;
							baginventoryName[l] = itemname;
							baginventorySize[l] = itemsize;
							baginventoryLeft -= itemsize;
							itemdelside[l] = 1;
							picBagInv[l].Image = imgPrimaryInv.Images[itempicture];
							Counter = itemsize - 1;
							for (int m = MaxBagSlots - 1; m >= 0; m += -1)
							{
								if (Counter == 0)
								{
									break;
								}
								if (BagInvGridLoc[m] == 0)
								{
									BagInvGridLoc[m] = 3;
									picBagInv[m].Visible = false;
									Counter--;
								}
							}
							break;
						}
					}
					break;
				case 4:
				{
					if (baginventoryLeft - itemsize < 0)
					{
						break;
					}
					int num2 = MaxBagSlots - 1;
					int num3 = 0;
					if (num3 > num2)
					{
						break;
					}
					lbagINV.Add(itemname);
					lbagINV2.Add(itemname);
					bagsecondaryName = itemname;
					bagsecondarySize = itemsize;
					baginventoryLeft -= itemsize;
					picBagSecondary.Visible = true;
					picBagSecondary.Image = imgSecondaryWeapons.Images[itempicture];
					itemdelside[num3 + 26] = 3;
					Counter = itemsize;
					for (int j = MaxBagSlots - 1; j >= 0; j += -1)
					{
						if (Counter == 0)
						{
							break;
						}
						if (BagInvGridLoc[j] == 0)
						{
							BagInvGridLoc[j] = 3;
							picBagInv[j].Visible = false;
							Counter--;
						}
					}
					break;
				}
				case 5:
				{
					if (baginventoryLeft - itemsize < 0)
					{
						break;
					}
					int num6 = MaxBagSlots - 1;
					for (int n = 0; n <= num6; n++)
					{
						if (BagInvGridLoc[n] == 0)
						{
							rbagINV.Add(itemname);
							rbagINV2.Add(itemname);
							BagInvGridLoc[n] = 1;
							baginventoryName[n] = itemname;
							baginventorySize[n] = itemsize;
							baginventoryLeft -= itemsize;
							itemdelside[n] = 1;
							picBagInv[n].Image = imgSecondaryInv.Images[itempicture];
							break;
						}
					}
					break;
				}
				case 6:
				{
					if (baginventoryLeft - itemsize < 0)
					{
						break;
					}
					int num = MaxBagSlots - 1;
					for (int i = 0; i <= num; i++)
					{
						if (BagInvGridLoc[i] == 0)
						{
							lbagINV.Add(itemname);
							lbagINV2.Add(itemname);
							BagInvGridLoc[i] = 1;
							baginventoryName[i] = itemname;
							baginventorySize[i] = itemsize;
							itemdelside[i] = 0;
							baginventoryLeft--;
							picBagInv[i].Image = imgTools.Images[itempicture];
							break;
						}
					}
					break;
				}
				}
			}
		}

		private void radioBackpack_CheckedChanged(object sender, EventArgs e)
		{
			ClearBackpack();
			checked
			{
				if (radio2.Checked)
				{
					BagName = "DZ_Patrol_Pack_EP1";
					MaxBagSlots = 8;
					baginventoryLeft = 8;
					picBackpack.Image = imgBags.Images[1];
					int num = MaxBagSlots - 1;
					for (int i = 0; i <= num; i++)
					{
						picBagInv[i].Visible = true;
					}
				}
				else if (radio3.Checked)
				{
					BagName = "DZ_Assault_Pack_EP1";
					MaxBagSlots = 12;
					baginventoryLeft = 12;
					picBackpack.Image = imgBags.Images[2];
					int num2 = MaxBagSlots - 1;
					for (int j = 0; j <= num2; j++)
					{
						picBagInv[j].Visible = true;
					}
				}
				else if (radio4.Checked)
				{
					BagName = "DZ_CivilBackpack_EP1";
					MaxBagSlots = 16;
					baginventoryLeft = 16;
					picBackpack.Image = imgBags.Images[3];
					int num3 = MaxBagSlots - 1;
					for (int k = 0; k <= num3; k++)
					{
						picBagInv[k].Visible = true;
					}
				}
				else if (radio5.Checked)
				{
					BagName = "DZ_ALICE_Pack_EP1";
					MaxBagSlots = 20;
					baginventoryLeft = 20;
					picBackpack.Image = imgBags.Images[4];
					int num4 = MaxBagSlots - 1;
					for (int l = 0; l <= num4; l++)
					{
						picBagInv[l].Visible = true;
					}
				}
				else if (radio6.Checked)
				{
					BagName = "DZ_Backpack_EP1";
					MaxBagSlots = 24;
					baginventoryLeft = 24;
					picBackpack.Image = imgBags.Images[5];
					int num5 = MaxBagSlots - 1;
					for (int m = 0; m <= num5; m++)
					{
						picBagInv[m].Visible = true;
					}
				}
			}
		}

		private void cmsRemoveItem_Click(object sender, EventArgs e)
		{
			checked
			{
				if (!((ItemDel == 1000) | (ItemDel == 999)))
				{
					if (ItemDel == 0)
					{
						lINV.Remove(opticsName[ItemDel]);
						opticsLeft++;
						picOptics1.Image = Resources.binocular;
					}
					else if (ItemDel == 1)
					{
						lINV.Remove(opticsName[ItemDel]);
						opticsLeft++;
						picOptics2.Image = Resources.binocular;
					}
					else if (ItemDel == 2)
					{
						lINV.Remove(primaryName);
						primaryLeft += primarySize;
						picPrimary.Image = Resources.rifle;
					}
					else if (ItemDel == 15)
					{
						lINV.Remove(secondaryName);
						secondaryLeft += secondarySize;
						picSecondary.Image = Resources.pistol;
					}
					else if ((ItemDel < 15) & (ItemDel > 2))
					{
						rINV.Remove(inventory1Name[ItemDel - 3]);
						MainInvGridLoc[ItemDel - 3] = 0;
						inventory1Left += inventory1Size[ItemDel - 3];
						picPrimaryInv[ItemDel - 3].ContextMenuStrip = null;
						picPrimaryInv[ItemDel - 3].Image = Resources.heavyammo;
						if (inventory1Size[ItemDel - 3] <= 1)
						{
							return;
						}
						Counter = inventory1Size[ItemDel - 3];
						int num = 0;
						while (Counter != 0)
						{
							if (MainInvGridLoc[num] == 3)
							{
								picPrimaryInv[num].Visible = true;
								MainInvGridLoc[num] = 0;
								Counter--;
							}
							num++;
							if (num > 11)
							{
								break;
							}
						}
					}
					else if ((ItemDel < 24) & (ItemDel > 15))
					{
						rINV.Remove(inventory2Name[ItemDel - 16]);
						inventory2Left += inventory2Size[ItemDel - 16];
						SecInvGridLoc[ItemDel - 16] = 0;
						picSecondaryInv[ItemDel - 16].Image = Resources.smallammo;
					}
					else if (ItemDel > 23)
					{
						lINV.Remove(toolName[ItemDel - 24]);
						toolLeft += toolSize[ItemDel - 24];
						ToolGridLoc[ItemDel - 24] = 0;
						picToolInv[ItemDel - 24].Image = null;
					}
				}
				else if (ItemDelBag != 1000)
				{
					if (itemdelside[ItemDelBag] == 0)
					{
						lbagINV.Remove(baginventoryName[ItemDelBag]);
						lbagINV2.Remove(baginventoryName[ItemDelBag]);
						BagInvGridLoc[ItemDelBag] = 0;
						baginventoryLeft += baginventorySize[ItemDelBag];
						picBagInv[ItemDelBag].Image = null;
					}
					else if (itemdelside[ItemDelBag] == 1)
					{
						rbagINV.Remove(baginventoryName[ItemDelBag]);
						rbagINV2.Remove(baginventoryName[ItemDelBag]);
						BagInvGridLoc[ItemDelBag] = 0;
						baginventoryLeft += baginventorySize[ItemDelBag];
						picBagInv[ItemDelBag].ContextMenuStrip = null;
						picBagInv[ItemDelBag].Image = null;
						Counter = baginventorySize[ItemDelBag];
						if (Counter <= 1)
						{
							return;
						}
						int num2 = MaxBagSlots - 1;
						for (int i = 0; i <= num2; i++)
						{
							if (Counter == 0)
							{
								break;
							}
							if (BagInvGridLoc[i] == 3)
							{
								picBagInv[i].Visible = true;
								BagInvGridLoc[i] = 0;
								Counter--;
							}
						}
					}
					else if (itemdelside[ItemDelBag] == 2)
					{
						lbagINV.Remove(bagprimaryName);
						lbagINV2.Remove(bagprimaryName);
						baginventoryLeft += bagprimarySize;
						picBagPrimary.Image = null;
						picBagPrimary.Visible = false;
						Counter = bagprimarySize;
						int num3 = MaxBagSlots - 1;
						for (int j = 0; j <= num3; j++)
						{
							if (Counter == 0)
							{
								break;
							}
							if (BagInvGridLoc[j] == 3)
							{
								BagInvGridLoc[j] = 0;
								picBagInv[j].Visible = true;
								Counter--;
							}
						}
					}
					else
					{
						if (itemdelside[ItemDelBag] != 3)
						{
							return;
						}
						lbagINV.Remove(bagsecondaryName);
						lbagINV2.Remove(bagsecondaryName);
						baginventoryLeft += bagsecondarySize;
						picBagSecondary.Image = null;
						picBagSecondary.Visible = false;
						Counter = bagsecondarySize;
						int num4 = MaxBagSlots - 1;
						for (int k = 0; k <= num4; k++)
						{
							if (Counter == 0)
							{
								break;
							}
							if (BagInvGridLoc[k] == 3)
							{
								BagInvGridLoc[k] = 0;
								picBagInv[k].Visible = true;
								Counter--;
							}
						}
					}
				}
				else if (ItemDel == 999)
				{
					ClearBackpack();
					radio1.Checked = true;
					radio2.Checked = false;
					radio3.Checked = false;
					radio4.Checked = false;
					radio5.Checked = false;
					radio6.Checked = false;
				}
			}
		}

		private void ClearBackpack()
		{
			if ((picBagInv != null) & (picBackpack != null) & (picBagPrimary != null) & (picBagSecondary != null))
			{
				int num = 0;
				do
				{
					picBagInv[num].Visible = false;
					picBagInv[num].Image = null;
					BagInvGridLoc[num] = 0;
					num = checked(num + 1);
				}
				while (num <= 23);
				picBagPrimary.Image = null;
				picBagSecondary.Image = null;
				picBagPrimary.Visible = false;
				picBagSecondary.Visible = false;
				lbagINV.Clear();
				lbagINV2.Clear();
				lbagINVvalues.Clear();
				rbagINV.Clear();
				rbagINV2.Clear();
				rbagINVvalues.Clear();
				MaxBagSlots = 0;
				baginventoryLeft = 0;
				BagName = string.Empty;
				picBackpack.Image = Resources.second;
			}
		}

		private void RemoveDupes()
		{
			checked
			{
				int num = lbagINV.Count - 1;
				for (int i = 0; i <= num && lbagINV.Count != i; i++)
				{
					ItemHolder = lbagINV[i];
					int num2 = i + 1;
					int num3 = lbagINV.Count - 1;
					for (int j = num2; j <= num3 && lbagINV.Count != j; j++)
					{
						if (Operators.CompareString(lbagINV[j], ItemHolder, false) == 0)
						{
							lbagINV.RemoveAt(j);
							j--;
						}
					}
				}
				while (lbagINV2.Count > 0)
				{
					ItemHolder = lbagINV2[0];
					int num4 = lbagINV2.Count - 1;
					for (int k = 0; k <= num4; k++)
					{
						if (Operators.CompareString(lbagINV2[k], ItemHolder, false) == 0)
						{
							Counter++;
						}
					}
					lbagINVvalues.Add(Counter);
					int num5 = Counter - 1;
					for (int l = 0; l <= num5; l++)
					{
						lbagINV2.RemoveAt(Counter - 1);
						Counter--;
					}
					Counter = 0;
				}
				int num6 = rbagINV.Count - 1;
				for (int m = 0; m <= num6 && rbagINV.Count != m; m++)
				{
					ItemHolder = rbagINV[m];
					int num7 = m + 1;
					int num8 = rbagINV.Count - 1;
					for (int n = num7; n <= num8 && rbagINV.Count != n; n++)
					{
						if (Operators.CompareString(rbagINV[n], ItemHolder, false) == 0)
						{
							rbagINV.RemoveAt(n);
							n--;
						}
					}
				}
				Counter = 0;
				while (rbagINV2.Count > 0)
				{
					ItemHolder = rbagINV2[0];
					int num9 = rbagINV2.Count - 1;
					for (int num10 = 0; num10 <= num9; num10++)
					{
						if (Operators.CompareString(rbagINV2[num10], ItemHolder, false) == 0)
						{
							Counter++;
						}
					}
					rbagINVvalues.Add(Counter);
					int num11 = Counter - 1;
					for (int num12 = 0; num12 <= num11; num12++)
					{
						rbagINV2.RemoveAt(Counter - 1);
						Counter--;
					}
					Counter = 0;
				}
			}
		}
	}
}
