using System;
using System.IO;
using System.Security;
using NLog.Common;

namespace NLog.Internal.FileAppenders
{
	/// <summary>
	/// Optimized single-process file appender which keeps the file open for exclusive write.
	/// </summary>
	// Token: 0x02000066 RID: 102
	[SecuritySafeCritical]
	internal class SingleProcessFileAppender : BaseFileAppender
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Internal.FileAppenders.SingleProcessFileAppender" /> class.
		/// </summary>
		/// <param name="fileName">Name of the file.</param>
		/// <param name="parameters">The parameters.</param>
		// Token: 0x0600029C RID: 668 RVA: 0x0000AB21 File Offset: 0x00008D21
		public SingleProcessFileAppender(string fileName, ICreateFileParameters parameters)
			: base(fileName, parameters)
		{
			this.file = base.CreateFileStream(false);
		}

		/// <summary>
		/// Writes the specified bytes.
		/// </summary>
		/// <param name="bytes">The bytes.</param>
		// Token: 0x0600029D RID: 669 RVA: 0x0000AB3C File Offset: 0x00008D3C
		public override void Write(byte[] bytes)
		{
			if (this.file != null)
			{
				this.file.Write(bytes, 0, bytes.Length);
				base.FileTouched();
			}
		}

		/// <summary>
		/// Flushes this instance.
		/// </summary>
		// Token: 0x0600029E RID: 670 RVA: 0x0000AB78 File Offset: 0x00008D78
		public override void Flush()
		{
			if (this.file != null)
			{
				this.file.Flush();
				base.FileTouched();
			}
		}

		/// <summary>
		/// Closes this instance.
		/// </summary>
		// Token: 0x0600029F RID: 671 RVA: 0x0000ABAC File Offset: 0x00008DAC
		public override void Close()
		{
			if (this.file != null)
			{
				InternalLogger.Trace("Closing '{0}'", new object[] { base.FileName });
				this.file.Close();
				this.file = null;
			}
		}

		/// <summary>
		/// Gets the file info.
		/// </summary>
		/// <param name="lastWriteTime">The last write time.</param>
		/// <param name="fileLength">Length of the file.</param>
		/// <returns>
		/// True if the operation succeeded, false otherwise.
		/// </returns>
		// Token: 0x060002A0 RID: 672 RVA: 0x0000ABFC File Offset: 0x00008DFC
		public override bool GetFileInfo(out DateTime lastWriteTime, out long fileLength)
		{
			throw new NotSupportedException();
		}

		// Token: 0x040000B6 RID: 182
		public static readonly IFileAppenderFactory TheFactory = new SingleProcessFileAppender.Factory();

		// Token: 0x040000B7 RID: 183
		private FileStream file;

		/// <summary>
		/// Factory class.
		/// </summary>
		// Token: 0x02000067 RID: 103
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
			// Token: 0x060002A2 RID: 674 RVA: 0x0000AC10 File Offset: 0x00008E10
			BaseFileAppender IFileAppenderFactory.Open(string fileName, ICreateFileParameters parameters)
			{
				return new SingleProcessFileAppender(fileName, parameters);
			}
		}
	}
}
