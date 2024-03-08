using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Crosire.Controlcenter.Setup.Classes
{
	internal class Scrollinfo
	{
		public const uint ObjidVscroll = 4294967291u;

		[DllImport("user32.dll", SetLastError = true)]
		private static extern int GetScrollBarInfo(IntPtr hWnd, uint idObject, ref Scrollbarinfo psbi);

		internal static bool CheckBottom(RichTextBox rtb)
		{
			Scrollbarinfo psbi = default(Scrollbarinfo);
			psbi.CbSize = Marshal.SizeOf((object)psbi);
			GetScrollBarInfo(rtb.Handle, 4294967291u, ref psbi);
			return psbi.XyThumbBottom > psbi.RcScrollBar.Bottom - psbi.RcScrollBar.Top - psbi.DxyLineButton * 2;
		}
	}
}
