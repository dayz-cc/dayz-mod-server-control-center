using System.Runtime.InteropServices;

namespace Crosire.Controlcenter.Setup.Classes
{
	public struct Scrollbarinfo
	{
		public int CbSize;

		public Rect RcScrollBar;

		public int DxyLineButton;

		public int XyThumbTop;

		public int XyThumbBottom;

		public int Reserved;

		[MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
		public int[] Rgstate;
	}
}
