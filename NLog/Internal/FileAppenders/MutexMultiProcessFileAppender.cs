using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Security;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading;
using NLog.Common;

namespace NLog.Internal.FileAppenders
{
	/// <summary>
	/// Provides a multiprocess-safe atomic file appends while
	/// keeping the files open.
	/// </summary>
	/// <remarks>
	/// On Unix you can get all the appends to be atomic, even when multiple 
	/// processes are trying to write to the same file, because setting the file
	/// pointer to the end of the file and appending can be made one operation.
	/// On Win32 we need to maintain some synchronization between processes
	/// (global named mutex is used for this)
	/// </remarks>
	// Token: 0x02000062 RID: 98
	[SecuritySafeCritical]
	internal class MutexMultiProcessFileAppender : BaseFileAppender
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Internal.FileAppenders.MutexMultiProcessFileAppender" /> class.
		/// </summary>
		/// <param name="fileName">Name of the file.</param>
		/// <param name="parameters">The parameters.</param>
		// Token: 0x0600028A RID: 650 RVA: 0x0000A718 File Offset: 0x00008918
		public MutexMultiProcessFileAppender(string fileName, ICreateFileParameters parameters)
			: base(fileName, parameters)
		{
			try
			{
				this.mutex = MutexMultiProcessFileAppender.CreateSharableMutex(MutexMultiProcessFileAppender.GetMutexName(fileName));
				this.file = base.CreateFileStream(true);
			}
			catch
			{
				if (this.mutex != null)
				{
					this.mutex.Close();
					this.mutex = null;
				}
				if (this.file != null)
				{
					this.file.Close();
					this.file = null;
				}
				throw;
			}
		}

		/// <summary>
		/// Writes the specified bytes.
		/// </summary>
		/// <param name="bytes">The bytes to be written.</param>
		// Token: 0x0600028B RID: 651 RVA: 0x0000A7AC File Offset: 0x000089AC
		public override void Write(byte[] bytes)
		{
			if (this.mutex != null)
			{
				try
				{
					this.mutex.WaitOne();
				}
				catch (AbandonedMutexException)
				{
				}
				try
				{
					this.file.Seek(0L, SeekOrigin.End);
					this.file.Write(bytes, 0, bytes.Length);
					this.file.Flush();
					base.FileTouched();
				}
				finally
				{
					this.mutex.ReleaseMutex();
				}
			}
		}

		/// <summary>
		/// Closes this instance.
		/// </summary>
		// Token: 0x0600028C RID: 652 RVA: 0x0000A848 File Offset: 0x00008A48
		public override void Close()
		{
			InternalLogger.Trace("Closing '{0}'", new object[] { base.FileName });
			if (this.mutex != null)
			{
				this.mutex.Close();
			}
			if (this.file != null)
			{
				this.file.Close();
			}
			this.mutex = null;
			this.file = null;
			base.FileTouched();
		}

		/// <summary>
		/// Flushes this instance.
		/// </summary>
		// Token: 0x0600028D RID: 653 RVA: 0x0000A8BD File Offset: 0x00008ABD
		public override void Flush()
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
		// Token: 0x0600028E RID: 654 RVA: 0x0000A8C0 File Offset: 0x00008AC0
		[SuppressMessage("Microsoft.Reliability", "CA2001:AvoidCallingProblematicMethods", MessageId = "System.Runtime.InteropServices.SafeHandle.DangerousGetHandle", Justification = "Optimization")]
		public override bool GetFileInfo(out DateTime lastWriteTime, out long fileLength)
		{
			return FileInfoHelper.Helper.GetFileInfo(base.FileName, this.file.SafeFileHandle.DangerousGetHandle(), out lastWriteTime, out fileLength);
		}

		// Token: 0x0600028F RID: 655 RVA: 0x0000A8F4 File Offset: 0x00008AF4
		private static Mutex CreateSharableMutex(string name)
		{
			MutexSecurity mutexSecurity = new MutexSecurity();
			SecurityIdentifier securityIdentifier = new SecurityIdentifier(WellKnownSidType.WorldSid, null);
			mutexSecurity.AddAccessRule(new MutexAccessRule(securityIdentifier, MutexRights.FullControl, AccessControlType.Allow));
			bool flag;
			return new Mutex(false, name, out flag, mutexSecurity);
		}

		// Token: 0x06000290 RID: 656 RVA: 0x0000A934 File Offset: 0x00008B34
		private static string GetMutexName(string fileName)
		{
			string text = Path.GetFullPath(fileName).ToLowerInvariant();
			text = text.Replace('\\', '/');
			string text2;
			if ("Global\\NLog-FileLock-".Length + text.Length <= 260)
			{
				text2 = "Global\\NLog-FileLock-" + text;
			}
			else
			{
				string text3;
				using (MD5 md = MD5.Create())
				{
					byte[] array = md.ComputeHash(Encoding.UTF8.GetBytes(text));
					text3 = Convert.ToBase64String(array);
				}
				int num = text.Length - (260 - "Global\\NLog-FileLock-".Length - text3.Length);
				text2 = "Global\\NLog-FileLock-" + text3 + text.Substring(num);
			}
			return text2;
		}

		// Token: 0x040000B2 RID: 178
		public static readonly IFileAppenderFactory TheFactory = new MutexMultiProcessFileAppender.Factory();

		// Token: 0x040000B3 RID: 179
		private FileStream file;

		// Token: 0x040000B4 RID: 180
		private Mutex mutex;

		/// <summary>
		/// Factory class.
		/// </summary>
		// Token: 0x02000063 RID: 99
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
			// Token: 0x06000292 RID: 658 RVA: 0x0000AA14 File Offset: 0x00008C14
			BaseFileAppender IFileAppenderFactory.Open(string fileName, ICreateFileParameters parameters)
			{
				return new MutexMultiProcessFileAppender(fileName, parameters);
			}
		}
	}
}
