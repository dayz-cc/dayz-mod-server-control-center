using System;
using System.IO;
using System.Security;

namespace NLog.Internal.FileAppenders
{
	/// <summary>
	/// Implementation of <see cref="T:NLog.Internal.FileAppenders.BaseFileAppender" /> which caches 
	/// file information.
	/// </summary>
	// Token: 0x0200005E RID: 94
	[SecuritySafeCritical]
	internal class CountingSingleProcessFileAppender : BaseFileAppender
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Internal.FileAppenders.CountingSingleProcessFileAppender" /> class.
		/// </summary>
		/// <param name="fileName">Name of the file.</param>
		/// <param name="parameters">The parameters.</param>
		// Token: 0x06000279 RID: 633 RVA: 0x0000A5A8 File Offset: 0x000087A8
		public CountingSingleProcessFileAppender(string fileName, ICreateFileParameters parameters)
			: base(fileName, parameters)
		{
			FileInfo fileInfo = new FileInfo(fileName);
			if (fileInfo.Exists)
			{
				base.FileTouched(fileInfo.LastWriteTime);
				this.currentFileLength = fileInfo.Length;
			}
			else
			{
				base.FileTouched();
				this.currentFileLength = 0L;
			}
			this.file = base.CreateFileStream(false);
		}

		/// <summary>
		/// Closes this instance of the appender.
		/// </summary>
		// Token: 0x0600027A RID: 634 RVA: 0x0000A610 File Offset: 0x00008810
		public override void Close()
		{
			if (this.file != null)
			{
				this.file.Close();
				this.file = null;
			}
		}

		/// <summary>
		/// Flushes this current appender.
		/// </summary>
		// Token: 0x0600027B RID: 635 RVA: 0x0000A640 File Offset: 0x00008840
		public override void Flush()
		{
			if (this.file != null)
			{
				this.file.Flush();
				base.FileTouched();
			}
		}

		/// <summary>
		/// Gets the file info.
		/// </summary>
		/// <param name="lastWriteTime">The last write time.</param>
		/// <param name="fileLength">Length of the file.</param>
		/// <returns>True if the operation succeeded, false otherwise.</returns>
		// Token: 0x0600027C RID: 636 RVA: 0x0000A674 File Offset: 0x00008874
		public override bool GetFileInfo(out DateTime lastWriteTime, out long fileLength)
		{
			lastWriteTime = base.LastWriteTime;
			fileLength = this.currentFileLength;
			return true;
		}

		/// <summary>
		/// Writes the specified bytes to a file.
		/// </summary>
		/// <param name="bytes">The bytes to be written.</param>
		// Token: 0x0600027D RID: 637 RVA: 0x0000A69C File Offset: 0x0000889C
		public override void Write(byte[] bytes)
		{
			if (this.file != null)
			{
				this.currentFileLength += (long)bytes.Length;
				this.file.Write(bytes, 0, bytes.Length);
				base.FileTouched();
			}
		}

		// Token: 0x040000AF RID: 175
		public static readonly IFileAppenderFactory TheFactory = new CountingSingleProcessFileAppender.Factory();

		// Token: 0x040000B0 RID: 176
		private FileStream file;

		// Token: 0x040000B1 RID: 177
		private long currentFileLength;

		/// <summary>
		/// Factory class which creates <see cref="T:NLog.Internal.FileAppenders.CountingSingleProcessFileAppender" /> objects.
		/// </summary>
		// Token: 0x02000060 RID: 96
		private class Factory : IFileAppenderFactory
		{
			/// <summary>
			/// Opens the appender for given file name and parameters.
			/// </summary>
			/// <param name="fileName">Name of the file.</param>
			/// <param name="parameters">Creation parameters.</param>
			/// <returns>
			/// Instance of <see cref="T:NLog.Internal.FileAppenders.BaseFileAppender" /> which can be used to write to the file.
			/// </returns>
			// Token: 0x06000280 RID: 640 RVA: 0x0000A6F4 File Offset: 0x000088F4
			BaseFileAppender IFileAppenderFactory.Open(string fileName, ICreateFileParameters parameters)
			{
				return new CountingSingleProcessFileAppender(fileName, parameters);
			}
		}
	}
}
