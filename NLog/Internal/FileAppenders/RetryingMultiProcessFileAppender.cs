using System;
using System.IO;
using System.Security;

namespace NLog.Internal.FileAppenders
{
	/// <summary>
	/// Multi-process and multi-host file appender which attempts
	/// to get exclusive write access and retries if it's not available.
	/// </summary>
	// Token: 0x02000064 RID: 100
	[SecuritySafeCritical]
	internal class RetryingMultiProcessFileAppender : BaseFileAppender
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Internal.FileAppenders.RetryingMultiProcessFileAppender" /> class.
		/// </summary>
		/// <param name="fileName">Name of the file.</param>
		/// <param name="parameters">The parameters.</param>
		// Token: 0x06000294 RID: 660 RVA: 0x0000AA35 File Offset: 0x00008C35
		public RetryingMultiProcessFileAppender(string fileName, ICreateFileParameters parameters)
			: base(fileName, parameters)
		{
		}

		/// <summary>
		/// Writes the specified bytes.
		/// </summary>
		/// <param name="bytes">The bytes.</param>
		// Token: 0x06000295 RID: 661 RVA: 0x0000AA44 File Offset: 0x00008C44
		public override void Write(byte[] bytes)
		{
			using (FileStream fileStream = base.CreateFileStream(false))
			{
				fileStream.Write(bytes, 0, bytes.Length);
			}
			base.FileTouched();
		}

		/// <summary>
		/// Flushes this instance.
		/// </summary>
		// Token: 0x06000296 RID: 662 RVA: 0x0000AA94 File Offset: 0x00008C94
		public override void Flush()
		{
		}

		/// <summary>
		/// Closes this instance.
		/// </summary>
		// Token: 0x06000297 RID: 663 RVA: 0x0000AA97 File Offset: 0x00008C97
		public override void Close()
		{
		}

		/// <summary>
		/// Gets the file info.
		/// </summary>
		/// <param name="lastWriteTime">The last write time.</param>
		/// <param name="fileLength">Length of the file.</param>
		/// <returns>
		/// True if the operation succeeded, false otherwise.
		/// </returns>
		// Token: 0x06000298 RID: 664 RVA: 0x0000AA9C File Offset: 0x00008C9C
		public override bool GetFileInfo(out DateTime lastWriteTime, out long fileLength)
		{
			FileInfo fileInfo = new FileInfo(base.FileName);
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

		// Token: 0x040000B5 RID: 181
		public static readonly IFileAppenderFactory TheFactory = new RetryingMultiProcessFileAppender.Factory();

		/// <summary>
		/// Factory class.
		/// </summary>
		// Token: 0x02000065 RID: 101
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
			// Token: 0x0600029A RID: 666 RVA: 0x0000AB00 File Offset: 0x00008D00
			BaseFileAppender IFileAppenderFactory.Open(string fileName, ICreateFileParameters parameters)
			{
				return new RetryingMultiProcessFileAppender(fileName, parameters);
			}
		}
	}
}
