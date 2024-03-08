using System;
using System.IO;

namespace NLog.Internal
{
	/// <summary>
	/// Portable implementation of <see cref="T:NLog.Internal.FileInfoHelper" />.
	/// </summary>
	// Token: 0x0200007F RID: 127
	internal class PortableFileInfoHelper : FileInfoHelper
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
		// Token: 0x0600031F RID: 799 RVA: 0x0000C418 File Offset: 0x0000A618
		public override bool GetFileInfo(string fileName, IntPtr fileHandle, out DateTime lastWriteTime, out long fileLength)
		{
			FileInfo fileInfo = new FileInfo(fileName);
			bool flag;
			if (fileInfo.Exists)
			{
				fileLength = fileInfo.Length;
				lastWriteTime = fileInfo.LastWriteTime;
				flag = true;
			}
			else
			{
				fileLength = -1L;
				lastWriteTime = DateTime.MinValue;
				flag = false;
			}
			return flag;
		}
	}
}
