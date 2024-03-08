using System;
using System.Runtime.InteropServices;

namespace Crosire.Controlcenter.Setup.Classes
{
	// Token: 0x02000003 RID: 3
	public struct Scrollbarinfo
	{
		// Token: 0x04000002 RID: 2
		public int CbSize;

		// Token: 0x04000003 RID: 3
		public Rect RcScrollBar;

		// Token: 0x04000004 RID: 4
		public int DxyLineButton;

		// Token: 0x04000005 RID: 5
		public int XyThumbTop;

		// Token: 0x04000006 RID: 6
		public int XyThumbBottom;

		// Token: 0x04000007 RID: 7
		public int Reserved;

		// Token: 0x04000008 RID: 8
		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
		public int[] Rgstate;
	}
}
