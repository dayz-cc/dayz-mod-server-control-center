using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;
using System.Threading;
using Microsoft.Win32.SafeHandles;
using NLog.Common;
using NLog.Time;

namespace NLog.Internal.FileAppenders
{
	/// <summary>
	/// Base class for optimized file appenders.
	/// </summary>
	// Token: 0x0200005D RID: 93
	[SecuritySafeCritical]
	internal abstract class BaseFileAppender : IDisposable
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Internal.FileAppenders.BaseFileAppender" /> class.
		/// </summary>
		/// <param name="fileName">Name of the file.</param>
		/// <param name="createParameters">The create parameters.</param>
		// Token: 0x06000265 RID: 613 RVA: 0x0000A1B0 File Offset: 0x000083B0
		public BaseFileAppender(string fileName, ICreateFileParameters createParameters)
		{
			this.CreateFileParameters = createParameters;
			this.FileName = fileName;
			this.OpenTime = TimeSource.Current.Time.ToLocalTime();
			this.LastWriteTime = DateTime.MinValue;
		}

		/// <summary>
		/// Gets the name of the file.
		/// </summary>
		/// <value>The name of the file.</value>
		// Token: 0x1700007E RID: 126
		// (get) Token: 0x06000266 RID: 614 RVA: 0x0000A208 File Offset: 0x00008408
		// (set) Token: 0x06000267 RID: 615 RVA: 0x0000A21F File Offset: 0x0000841F
		public string FileName { get; private set; }

		/// <summary>
		/// Gets the last write time.
		/// </summary>
		/// <value>The last write time.</value>
		// Token: 0x1700007F RID: 127
		// (get) Token: 0x06000268 RID: 616 RVA: 0x0000A228 File Offset: 0x00008428
		// (set) Token: 0x06000269 RID: 617 RVA: 0x0000A23F File Offset: 0x0000843F
		public DateTime LastWriteTime { get; private set; }

		/// <summary>
		/// Gets the open time of the file.
		/// </summary>
		/// <value>The open time.</value>
		// Token: 0x17000080 RID: 128
		// (get) Token: 0x0600026A RID: 618 RVA: 0x0000A248 File Offset: 0x00008448
		// (set) Token: 0x0600026B RID: 619 RVA: 0x0000A25F File Offset: 0x0000845F
		public DateTime OpenTime { get; private set; }

		/// <summary>
		/// Gets the file creation parameters.
		/// </summary>
		/// <value>The file creation parameters.</value>
		// Token: 0x17000081 RID: 129
		// (get) Token: 0x0600026C RID: 620 RVA: 0x0000A268 File Offset: 0x00008468
		// (set) Token: 0x0600026D RID: 621 RVA: 0x0000A27F File Offset: 0x0000847F
		public ICreateFileParameters CreateFileParameters { get; private set; }

		/// <summary>
		/// Writes the specified bytes.
		/// </summary>
		/// <param name="bytes">The bytes.</param>
		// Token: 0x0600026E RID: 622
		public abstract void Write(byte[] bytes);

		/// <summary>
		/// Flushes this instance.
		/// </summary>
		// Token: 0x0600026F RID: 623
		public abstract void Flush();

		/// <summary>
		/// Closes this instance.
		/// </summary>
		// Token: 0x06000270 RID: 624
		public abstract void Close();

		/// <summary>
		/// Gets the file info.
		/// </summary>
		/// <param name="lastWriteTime">The last write time.</param>
		/// <param name="fileLength">Length of the file.</param>
		/// <returns>True if the operation succeeded, false otherwise.</returns>
		// Token: 0x06000271 RID: 625
		public abstract bool GetFileInfo(out DateTime lastWriteTime, out long fileLength);

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		// Token: 0x06000272 RID: 626 RVA: 0x0000A288 File Offset: 0x00008488
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// Releases unmanaged and - optionally - managed resources.
		/// </summary>
		/// <param name="disposing">True to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
		// Token: 0x06000273 RID: 627 RVA: 0x0000A29C File Offset: 0x0000849C
		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				this.Close();
			}
		}

		/// <summary>
		/// Records the last write time for a file.
		/// </summary>
		// Token: 0x06000274 RID: 628 RVA: 0x0000A2BC File Offset: 0x000084BC
		protected void FileTouched()
		{
			this.LastWriteTime = TimeSource.Current.Time.ToLocalTime();
		}

		/// <summary>
		/// Records the last write time for a file to be specific date.
		/// </summary>
		/// <param name="dateTime">Date and time when the last write occurred.</param>
		// Token: 0x06000275 RID: 629 RVA: 0x0000A2E3 File Offset: 0x000084E3
		protected void FileTouched(DateTime dateTime)
		{
			this.LastWriteTime = dateTime;
		}

		/// <summary>
		/// Creates the file stream.
		/// </summary>
		/// <param name="allowConcurrentWrite">If set to <c>true</c> allow concurrent writes.</param>
		/// <returns>A <see cref="T:System.IO.FileStream" /> object which can be used to write to the file.</returns>
		// Token: 0x06000276 RID: 630 RVA: 0x0000A2F0 File Offset: 0x000084F0
		protected FileStream CreateFileStream(bool allowConcurrentWrite)
		{
			int num = this.CreateFileParameters.ConcurrentWriteAttemptDelay;
			InternalLogger.Trace("Opening {0} with concurrentWrite={1}", new object[] { this.FileName, allowConcurrentWrite });
			for (int i = 0; i < this.CreateFileParameters.ConcurrentWriteAttempts; i++)
			{
				try
				{
					try
					{
						return this.TryCreateFileStream(allowConcurrentWrite);
					}
					catch (DirectoryNotFoundException)
					{
						if (!this.CreateFileParameters.CreateDirs)
						{
							throw;
						}
						Directory.CreateDirectory(Path.GetDirectoryName(this.FileName));
						return this.TryCreateFileStream(allowConcurrentWrite);
					}
				}
				catch (IOException)
				{
					if (!this.CreateFileParameters.ConcurrentWrites || !allowConcurrentWrite || i + 1 == this.CreateFileParameters.ConcurrentWriteAttempts)
					{
						throw;
					}
					int num2 = this.random.Next(num);
					InternalLogger.Warn("Attempt #{0} to open {1} failed. Sleeping for {2}ms", new object[] { i, this.FileName, num2 });
					num *= 2;
					Thread.Sleep(num2);
				}
			}
			throw new InvalidOperationException("Should not be reached.");
		}

		// Token: 0x06000277 RID: 631 RVA: 0x0000A444 File Offset: 0x00008644
		[SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "Objects are disposed elsewhere")]
		private FileStream WindowsCreateFile(string fileName, bool allowConcurrentWrite)
		{
			int num = 1;
			if (allowConcurrentWrite)
			{
				num |= 2;
			}
			if (this.CreateFileParameters.EnableFileDelete && PlatformDetector.CurrentOS != RuntimeOS.Windows)
			{
				num |= 4;
			}
			IntPtr intPtr = Win32FileNativeMethods.CreateFile(fileName, Win32FileNativeMethods.FileAccess.GenericWrite, num, IntPtr.Zero, Win32FileNativeMethods.CreationDisposition.OpenAlways, this.CreateFileParameters.FileAttributes, IntPtr.Zero);
			if (intPtr.ToInt32() == -1)
			{
				Marshal.ThrowExceptionForHR(Marshal.GetHRForLastWin32Error());
			}
			SafeFileHandle safeFileHandle = new SafeFileHandle(intPtr, true);
			FileStream fileStream = new FileStream(safeFileHandle, FileAccess.Write, this.CreateFileParameters.BufferSize);
			fileStream.Seek(0L, SeekOrigin.End);
			return fileStream;
		}

		// Token: 0x06000278 RID: 632 RVA: 0x0000A4F8 File Offset: 0x000086F8
		private FileStream TryCreateFileStream(bool allowConcurrentWrite)
		{
			FileShare fileShare = FileShare.Read;
			if (allowConcurrentWrite)
			{
				fileShare = FileShare.ReadWrite;
			}
			if (this.CreateFileParameters.EnableFileDelete && PlatformDetector.CurrentOS != RuntimeOS.Windows)
			{
				fileShare |= FileShare.Delete;
			}
			try
			{
				if (!this.CreateFileParameters.ForceManaged && PlatformDetector.IsDesktopWin32)
				{
					return this.WindowsCreateFile(this.FileName, allowConcurrentWrite);
				}
			}
			catch (SecurityException)
			{
				InternalLogger.Debug("Could not use native Windows create file, falling back to managed filestream");
			}
			return new FileStream(this.FileName, FileMode.Append, FileAccess.Write, fileShare, this.CreateFileParameters.BufferSize);
		}

		// Token: 0x040000AA RID: 170
		private readonly Random random = new Random();
	}
}
