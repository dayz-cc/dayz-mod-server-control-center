using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Crosire.Controlcenter.Setup.Classes
{
	// Token: 0x02000002 RID: 2
	internal class Scrollinfo
	{
		// Token: 0x06000001 RID: 1
		[DllImport("user32.dll", SetLastError = true)]
		private static extern int GetScrollBarInfo(IntPtr hWnd, uint idObject, ref Scrollbarinfo psbi);

		// Token: 0x06000002 RID: 2 RVA: 0x00002050 File Offset: 0x00000250
		internal static bool CheckBottom(RichTextBox rtb)
		{
			Scrollbarinfo scrollbarinfo = default(Scrollbarinfo);
			scrollbarinfo.CbSize = Marshal.SizeOf(scrollbarinfo);
			Scrollinfo.GetScrollBarInfo(rtb.Handle, 4294967291U, ref scrollbarinfo);
			return scrollbarinfo.XyThumbBottom > scrollbarinfo.RcScrollBar.Bottom - scrollbarinfo.RcScrollBar.Top - scrollbarinfo.DxyLineButton * 2;
		}

		// Token: 0x04000001 RID: 1
		public const uint ObjidVscroll = 4294967291U;
	}
}
