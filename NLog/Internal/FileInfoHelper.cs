using System;

namespace NLog.Internal
{
	/// <summary>
	/// Optimized routines to get the size and last write time of the specified file.
	/// </summary>
	// Token: 0x02000068 RID: 104
	internal abstract class FileInfoHelper
	{
		/// <summary>
		/// Initializes static members of the FileInfoHelper class.
		/// </summary>
		// Token: 0x060002A4 RID: 676 RVA: 0x0000AC34 File Offset: 0x00008E34
		static FileInfoHelper()
		{
			if (PlatformDetector.IsDesktopWin32)
			{
				FileInfoHelper.Helper = new Win32FileInfoHelper();
			}
			else
			{
				FileInfoHelper.Helper = new PortableFileInfoHelper();
			}
		}

		// Token: 0x1700008A RID: 138
		// (get) Token: 0x060002A5 RID: 677 RVA: 0x0000AC6C File Offset: 0x00008E6C
		// (set) Token: 0x060002A6 RID: 678 RVA: 0x0000AC82 File Offset: 0x00008E82
		internal static FileInfoHelper Helper { get; private set; }

		/// <summary>
		/// Gets the information about a file.
		/// </summary>
		/// <param name="fileName">Name of the file.</param>
		/// <param name="fileHandle">The file handle.</param>
		/// <param name="lastWriteTime">The last write time of the file.</param>
		/// <param name="fileLength">Length of the file.</param>
		/// <returns>A value of <c>true</c> if file information was retrieved successfully, <c>false</c> otherwise.</returns>
		// Token: 0x060002A7 RID: 679
		public abstract bool GetFileInfo(string fileName, IntPtr fileHandle, out DateTime lastWriteTime, out long fileLength);
	}
}
