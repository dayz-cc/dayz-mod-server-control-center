using System;

namespace NLog.Internal
{
	/// <summary>
	/// Win32-optimized implementation of <see cref="T:NLog.Internal.FileInfoHelper" />.
	/// </summary>
	// Token: 0x0200008E RID: 142
	internal class Win32FileInfoHelper : FileInfoHelper
	{
		/// <summary>
		/// Gets the information about a file.
		/// </summary>
		/// <param name="fileName">Name of the file.</param>
		/// <param name="fileHandle">The file handle.</param>
		/// <param name="lastWriteTime">The last write time of the file.</param>
		/// <param name="fileLength">Length of the file.</param>
		/// <returns>
		/// A value of <c>true</c> if file information was retrieved successfully, <c>false</c> otherwise.
		/// </returns>
		// Token: 0x06000363 RID: 867 RVA: 0x0000D610 File Offset: 0x0000B810
		public override bool GetFileInfo(string fileName, IntPtr fileHandle, out DateTime lastWriteTime, out long fileLength)
		{
			Win32FileNativeMethods.BY_HANDLE_FILE_INFORMATION by_HANDLE_FILE_INFORMATION;
			bool flag;
			if (Win32FileNativeMethods.GetFileInformationByHandle(fileHandle, out by_HANDLE_FILE_INFORMATION))
			{
				lastWriteTime = DateTime.FromFileTime(by_HANDLE_FILE_INFORMATION.ftLastWriteTime);
				fileLength = (long)((ulong)by_HANDLE_FILE_INFORMATION.nFileSizeLow + ((ulong)by_HANDLE_FILE_INFORMATION.nFileSizeHigh << 32));
				flag = true;
			}
			else
			{
				lastWriteTime = DateTime.MinValue;
				fileLength = -1L;
				flag = false;
			}
			return flag;
		}
	}
}
