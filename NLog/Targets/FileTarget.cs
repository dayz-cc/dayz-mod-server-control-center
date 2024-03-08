using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;
using NLog.Common;
using NLog.Config;
using NLog.Internal;
using NLog.Internal.FileAppenders;
using NLog.Layouts;

namespace NLog.Targets
{
	/// <summary>
	/// Writes log messages to one or more files.
	/// </summary>
	/// <seealso href="http://nlog-project.org/wiki/File_target">Documentation on NLog Wiki</seealso>
	// Token: 0x02000112 RID: 274
	[Target("File")]
	public class FileTarget : TargetWithLayoutHeaderAndFooter, ICreateFileParameters
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Targets.FileTarget" /> class.
		/// </summary>
		/// <remarks>
		/// The default value of the layout is: <code>${longdate}|${level:uppercase=true}|${logger}|${message}</code>
		/// </remarks>
		// Token: 0x060008B0 RID: 2224 RVA: 0x0001E8B0 File Offset: 0x0001CAB0
		public FileTarget()
		{
			this.ArchiveNumbering = ArchiveNumberingMode.Sequence;
			this._MaxArchiveFilesField = 9;
			this.ConcurrentWriteAttemptDelay = 1;
			this.ArchiveEvery = FileArchivePeriod.None;
			this.ArchiveAboveSize = -1L;
			this.ConcurrentWriteAttempts = 10;
			this.ConcurrentWrites = true;
			this.Encoding = Encoding.Default;
			this.BufferSize = 32768;
			this.AutoFlush = true;
			this.FileAttributes = Win32FileAttributes.Normal;
			this.NewLineChars = EnvironmentHelper.NewLine;
			this.EnableFileDelete = true;
			this.OpenFileCacheTimeout = -1;
			this.OpenFileCacheSize = 5;
			this.CreateDirs = true;
			this.dynamicArchiveFileHandler = new FileTarget.DynamicArchiveFileHandlerClass(this.MaxArchiveFiles);
			this.ForceManaged = false;
			this.ArchiveDateFormat = string.Empty;
		}

		/// <summary>
		/// Gets or sets the name of the file to write to.
		/// </summary>
		/// <remarks>
		/// This FileName string is a layout which may include instances of layout renderers.
		/// This lets you use a single target to write to multiple files.
		/// </remarks>
		/// <example>
		/// The following value makes NLog write logging events to files based on the log level in the directory where
		/// the application runs.
		/// <code>${basedir}/${level}.log</code>
		/// All <c>Debug</c> messages will go to <c>Debug.log</c>, all <c>Info</c> messages will go to <c>Info.log</c> and so on.
		/// You can combine as many of the layout renderers as you want to produce an arbitrary log file name.
		/// </example>
		/// <docgen category="Output Options" order="1" />
		// Token: 0x170001B9 RID: 441
		// (get) Token: 0x060008B1 RID: 2225 RVA: 0x0001E990 File Offset: 0x0001CB90
		// (set) Token: 0x060008B2 RID: 2226 RVA: 0x0001E9A7 File Offset: 0x0001CBA7
		[RequiredParameter]
		public Layout FileName { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether to create directories if they don't exist.
		/// </summary>
		/// <remarks>
		/// Setting this to false may improve performance a bit, but you'll receive an error
		/// when attempting to write to a directory that's not present.
		/// </remarks>
		/// <docgen category="Output Options" order="10" />
		// Token: 0x170001BA RID: 442
		// (get) Token: 0x060008B3 RID: 2227 RVA: 0x0001E9B0 File Offset: 0x0001CBB0
		// (set) Token: 0x060008B4 RID: 2228 RVA: 0x0001E9C7 File Offset: 0x0001CBC7
		[DefaultValue(true)]
		[Advanced]
		public bool CreateDirs { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether to delete old log file on startup.
		/// </summary>
		/// <remarks>
		/// This option works only when the "FileName" parameter denotes a single file.
		/// </remarks>
		/// <docgen category="Output Options" order="10" />
		// Token: 0x170001BB RID: 443
		// (get) Token: 0x060008B5 RID: 2229 RVA: 0x0001E9D0 File Offset: 0x0001CBD0
		// (set) Token: 0x060008B6 RID: 2230 RVA: 0x0001E9E7 File Offset: 0x0001CBE7
		[DefaultValue(false)]
		public bool DeleteOldFileOnStartup { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether to replace file contents on each write instead of appending log message at the end.
		/// </summary>
		/// <docgen category="Output Options" order="10" />
		// Token: 0x170001BC RID: 444
		// (get) Token: 0x060008B7 RID: 2231 RVA: 0x0001E9F0 File Offset: 0x0001CBF0
		// (set) Token: 0x060008B8 RID: 2232 RVA: 0x0001EA07 File Offset: 0x0001CC07
		[DefaultValue(false)]
		[Advanced]
		public bool ReplaceFileContentsOnEachWrite { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether to keep log file open instead of opening and closing it on each logging event.
		/// </summary>
		/// <remarks>
		/// Setting this property to <c>True</c> helps improve performance.
		/// </remarks>
		/// <docgen category="Performance Tuning Options" order="10" />
		// Token: 0x170001BD RID: 445
		// (get) Token: 0x060008B9 RID: 2233 RVA: 0x0001EA10 File Offset: 0x0001CC10
		// (set) Token: 0x060008BA RID: 2234 RVA: 0x0001EA27 File Offset: 0x0001CC27
		[DefaultValue(false)]
		public bool KeepFileOpen { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether to enable log file(s) to be deleted.
		/// </summary>
		/// <docgen category="Output Options" order="10" />
		// Token: 0x170001BE RID: 446
		// (get) Token: 0x060008BB RID: 2235 RVA: 0x0001EA30 File Offset: 0x0001CC30
		// (set) Token: 0x060008BC RID: 2236 RVA: 0x0001EA47 File Offset: 0x0001CC47
		[DefaultValue(true)]
		public bool EnableFileDelete { get; set; }

		/// <summary>
		/// Gets or sets a value specifying the date format to use when archving files.
		/// </summary>
		/// <remarks>
		/// This option works only when the "ArchiveNumbering" parameter is set to Date.
		/// </remarks>
		/// <docgen category="Output Options" order="10" />
		// Token: 0x170001BF RID: 447
		// (get) Token: 0x060008BD RID: 2237 RVA: 0x0001EA50 File Offset: 0x0001CC50
		// (set) Token: 0x060008BE RID: 2238 RVA: 0x0001EA67 File Offset: 0x0001CC67
		[DefaultValue("")]
		public string ArchiveDateFormat { get; set; }

		/// <summary>
		/// Gets or sets the file attributes (Windows only).
		/// </summary>
		/// <docgen category="Output Options" order="10" />
		// Token: 0x170001C0 RID: 448
		// (get) Token: 0x060008BF RID: 2239 RVA: 0x0001EA70 File Offset: 0x0001CC70
		// (set) Token: 0x060008C0 RID: 2240 RVA: 0x0001EA87 File Offset: 0x0001CC87
		[Advanced]
		public Win32FileAttributes FileAttributes { get; set; }

		/// <summary>
		/// Gets or sets the line ending mode.
		/// </summary>
		/// <docgen category="Layout Options" order="10" />
		// Token: 0x170001C1 RID: 449
		// (get) Token: 0x060008C1 RID: 2241 RVA: 0x0001EA90 File Offset: 0x0001CC90
		// (set) Token: 0x060008C2 RID: 2242 RVA: 0x0001EAA8 File Offset: 0x0001CCA8
		[Advanced]
		public LineEndingMode LineEnding
		{
			get
			{
				return this.lineEndingMode;
			}
			set
			{
				this.lineEndingMode = value;
				switch (value)
				{
				case LineEndingMode.Default:
					this.NewLineChars = EnvironmentHelper.NewLine;
					break;
				case LineEndingMode.CRLF:
					this.NewLineChars = "\r\n";
					break;
				case LineEndingMode.CR:
					this.NewLineChars = "\r";
					break;
				case LineEndingMode.LF:
					this.NewLineChars = "\n";
					break;
				case LineEndingMode.None:
					this.NewLineChars = string.Empty;
					break;
				}
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether to automatically flush the file buffers after each log message.
		/// </summary>
		/// <docgen category="Performance Tuning Options" order="10" />
		// Token: 0x170001C2 RID: 450
		// (get) Token: 0x060008C3 RID: 2243 RVA: 0x0001EB24 File Offset: 0x0001CD24
		// (set) Token: 0x060008C4 RID: 2244 RVA: 0x0001EB3B File Offset: 0x0001CD3B
		[DefaultValue(true)]
		public bool AutoFlush { get; set; }

		/// <summary>
		/// Gets or sets the number of files to be kept open. Setting this to a higher value may improve performance
		/// in a situation where a single File target is writing to many files
		/// (such as splitting by level or by logger).
		/// </summary>
		/// <remarks>
		/// The files are managed on a LRU (least recently used) basis, which flushes
		/// the files that have not been used for the longest period of time should the
		/// cache become full. As a rule of thumb, you shouldn't set this parameter to 
		/// a very high value. A number like 10-15 shouldn't be exceeded, because you'd
		/// be keeping a large number of files open which consumes system resources.
		/// </remarks>
		/// <docgen category="Performance Tuning Options" order="10" />
		// Token: 0x170001C3 RID: 451
		// (get) Token: 0x060008C5 RID: 2245 RVA: 0x0001EB44 File Offset: 0x0001CD44
		// (set) Token: 0x060008C6 RID: 2246 RVA: 0x0001EB5B File Offset: 0x0001CD5B
		[Advanced]
		[DefaultValue(5)]
		public int OpenFileCacheSize { get; set; }

		/// <summary>
		/// Gets or sets the maximum number of seconds that files are kept open. If this number is negative the files are 
		/// not automatically closed after a period of inactivity.
		/// </summary>
		/// <docgen category="Performance Tuning Options" order="10" />
		// Token: 0x170001C4 RID: 452
		// (get) Token: 0x060008C7 RID: 2247 RVA: 0x0001EB64 File Offset: 0x0001CD64
		// (set) Token: 0x060008C8 RID: 2248 RVA: 0x0001EB7B File Offset: 0x0001CD7B
		[Advanced]
		[DefaultValue(-1)]
		public int OpenFileCacheTimeout { get; set; }

		/// <summary>
		/// Gets or sets the log file buffer size in bytes.
		/// </summary>
		/// <docgen category="Performance Tuning Options" order="10" />
		// Token: 0x170001C5 RID: 453
		// (get) Token: 0x060008C9 RID: 2249 RVA: 0x0001EB84 File Offset: 0x0001CD84
		// (set) Token: 0x060008CA RID: 2250 RVA: 0x0001EB9B File Offset: 0x0001CD9B
		[DefaultValue(32768)]
		public int BufferSize { get; set; }

		/// <summary>
		/// Gets or sets the file encoding.
		/// </summary>
		/// <docgen category="Layout Options" order="10" />
		// Token: 0x170001C6 RID: 454
		// (get) Token: 0x060008CB RID: 2251 RVA: 0x0001EBA4 File Offset: 0x0001CDA4
		// (set) Token: 0x060008CC RID: 2252 RVA: 0x0001EBBB File Offset: 0x0001CDBB
		public Encoding Encoding { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether concurrent writes to the log file by multiple processes on the same host.
		/// </summary>
		/// <remarks>
		/// This makes multi-process logging possible. NLog uses a special technique
		/// that lets it keep the files open for writing.
		/// </remarks>
		/// <docgen category="Performance Tuning Options" order="10" />
		// Token: 0x170001C7 RID: 455
		// (get) Token: 0x060008CD RID: 2253 RVA: 0x0001EBC4 File Offset: 0x0001CDC4
		// (set) Token: 0x060008CE RID: 2254 RVA: 0x0001EBDB File Offset: 0x0001CDDB
		[DefaultValue(true)]
		public bool ConcurrentWrites { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether concurrent writes to the log file by multiple processes on different network hosts.
		/// </summary>
		/// <remarks>
		/// This effectively prevents files from being kept open.
		/// </remarks>
		/// <docgen category="Performance Tuning Options" order="10" />
		// Token: 0x170001C8 RID: 456
		// (get) Token: 0x060008CF RID: 2255 RVA: 0x0001EBE4 File Offset: 0x0001CDE4
		// (set) Token: 0x060008D0 RID: 2256 RVA: 0x0001EBFB File Offset: 0x0001CDFB
		[DefaultValue(false)]
		public bool NetworkWrites { get; set; }

		/// <summary>
		/// Gets or sets the number of times the write is appended on the file before NLog
		/// discards the log message.
		/// </summary>
		/// <docgen category="Performance Tuning Options" order="10" />
		// Token: 0x170001C9 RID: 457
		// (get) Token: 0x060008D1 RID: 2257 RVA: 0x0001EC04 File Offset: 0x0001CE04
		// (set) Token: 0x060008D2 RID: 2258 RVA: 0x0001EC1B File Offset: 0x0001CE1B
		[DefaultValue(10)]
		[Advanced]
		public int ConcurrentWriteAttempts { get; set; }

		/// <summary>
		/// Gets or sets the delay in milliseconds to wait before attempting to write to the file again.
		/// </summary>
		/// <remarks>
		/// The actual delay is a random value between 0 and the value specified
		/// in this parameter. On each failed attempt the delay base is doubled
		/// up to <see cref="P:NLog.Targets.FileTarget.ConcurrentWriteAttempts" /> times.
		/// </remarks>
		/// <example>
		/// Assuming that ConcurrentWriteAttemptDelay is 10 the time to wait will be:<p />
		/// a random value between 0 and 10 milliseconds - 1st attempt<br />
		/// a random value between 0 and 20 milliseconds - 2nd attempt<br />
		/// a random value between 0 and 40 milliseconds - 3rd attempt<br />
		/// a random value between 0 and 80 milliseconds - 4th attempt<br />
		/// ...<p />
		/// and so on.
		/// </example>
		/// <docgen category="Performance Tuning Options" order="10" />
		// Token: 0x170001CA RID: 458
		// (get) Token: 0x060008D3 RID: 2259 RVA: 0x0001EC24 File Offset: 0x0001CE24
		// (set) Token: 0x060008D4 RID: 2260 RVA: 0x0001EC3B File Offset: 0x0001CE3B
		[Advanced]
		[DefaultValue(1)]
		public int ConcurrentWriteAttemptDelay { get; set; }

		/// <summary>
		/// Gets or sets the size in bytes above which log files will be automatically archived.
		/// </summary>
		/// <remarks>
		/// Caution: Enabling this option can considerably slow down your file 
		/// logging in multi-process scenarios. If only one process is going to
		/// be writing to the file, consider setting <c>ConcurrentWrites</c>
		/// to <c>false</c> for maximum performance.
		/// </remarks>
		/// <docgen category="Archival Options" order="10" />
		// Token: 0x170001CB RID: 459
		// (get) Token: 0x060008D5 RID: 2261 RVA: 0x0001EC44 File Offset: 0x0001CE44
		// (set) Token: 0x060008D6 RID: 2262 RVA: 0x0001EC5B File Offset: 0x0001CE5B
		public long ArchiveAboveSize { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether to automatically archive log files every time the specified time passes.
		/// </summary>
		/// <remarks>
		/// Files are moved to the archive as part of the write operation if the current period of time changes. For example
		/// if the current <c>hour</c> changes from 10 to 11, the first write that will occur
		/// on or after 11:00 will trigger the archiving.
		/// <p>
		/// Caution: Enabling this option can considerably slow down your file 
		/// logging in multi-process scenarios. If only one process is going to
		/// be writing to the file, consider setting <c>ConcurrentWrites</c>
		/// to <c>false</c> for maximum performance.
		/// </p>
		/// </remarks>
		/// <docgen category="Archival Options" order="10" />
		// Token: 0x170001CC RID: 460
		// (get) Token: 0x060008D7 RID: 2263 RVA: 0x0001EC64 File Offset: 0x0001CE64
		// (set) Token: 0x060008D8 RID: 2264 RVA: 0x0001EC7B File Offset: 0x0001CE7B
		public FileArchivePeriod ArchiveEvery { get; set; }

		/// <summary>
		/// Gets or sets the name of the file to be used for an archive.
		/// </summary>
		/// <remarks>
		/// It may contain a special placeholder {#####}
		/// that will be replaced with a sequence of numbers depending on 
		/// the archiving strategy. The number of hash characters used determines
		/// the number of numerical digits to be used for numbering files.
		/// </remarks>
		/// <docgen category="Archival Options" order="10" />
		// Token: 0x170001CD RID: 461
		// (get) Token: 0x060008D9 RID: 2265 RVA: 0x0001EC84 File Offset: 0x0001CE84
		// (set) Token: 0x060008DA RID: 2266 RVA: 0x0001EC9B File Offset: 0x0001CE9B
		public Layout ArchiveFileName { get; set; }

		/// <summary>
		/// Gets or sets the maximum number of archive files that should be kept.
		/// </summary>
		/// <docgen category="Archival Options" order="10" />
		// Token: 0x170001CE RID: 462
		// (get) Token: 0x060008DB RID: 2267 RVA: 0x0001ECA4 File Offset: 0x0001CEA4
		// (set) Token: 0x060008DC RID: 2268 RVA: 0x0001ECBC File Offset: 0x0001CEBC
		[DefaultValue(9)]
		public int MaxArchiveFiles
		{
			get
			{
				return this._MaxArchiveFilesField;
			}
			set
			{
				this._MaxArchiveFilesField = value;
				this.dynamicArchiveFileHandler.MaxArchiveFileToKeep = value;
			}
		}

		/// <summary>
		/// Gets ors set a value indicating whether a managed file stream is forced, instead of used the native implementation.
		/// </summary>
		// Token: 0x170001CF RID: 463
		// (get) Token: 0x060008DD RID: 2269 RVA: 0x0001ECD4 File Offset: 0x0001CED4
		// (set) Token: 0x060008DE RID: 2270 RVA: 0x0001ECEB File Offset: 0x0001CEEB
		[DefaultValue(false)]
		public bool ForceManaged { get; set; }

		/// <summary>
		/// Gets or sets the way file archives are numbered. 
		/// </summary>
		/// <docgen category="Archival Options" order="10" />
		// Token: 0x170001D0 RID: 464
		// (get) Token: 0x060008DF RID: 2271 RVA: 0x0001ECF4 File Offset: 0x0001CEF4
		// (set) Token: 0x060008E0 RID: 2272 RVA: 0x0001ED0B File Offset: 0x0001CF0B
		public ArchiveNumberingMode ArchiveNumbering { get; set; }

		/// <summary>
		/// Gets the characters that are appended after each line.
		/// </summary>
		// Token: 0x170001D1 RID: 465
		// (get) Token: 0x060008E1 RID: 2273 RVA: 0x0001ED14 File Offset: 0x0001CF14
		// (set) Token: 0x060008E2 RID: 2274 RVA: 0x0001ED2B File Offset: 0x0001CF2B
		protected internal string NewLineChars { get; private set; }

		/// <summary>
		/// Removes records of initialized files that have not been 
		/// accessed in the last two days.
		/// </summary>
		/// <remarks>
		/// Files are marked 'initialized' for the purpose of writing footers when the logging finishes.
		/// </remarks>
		// Token: 0x060008E3 RID: 2275 RVA: 0x0001ED34 File Offset: 0x0001CF34
		public void CleanupInitializedFiles()
		{
			this.CleanupInitializedFiles(DateTime.Now.AddDays(-2.0));
		}

		/// <summary>
		/// Removes records of initialized files that have not been
		/// accessed after the specified date.
		/// </summary>
		/// <param name="cleanupThreshold">The cleanup threshold.</param>
		/// <remarks>
		/// Files are marked 'initialized' for the purpose of writing footers when the logging finishes.
		/// </remarks>
		// Token: 0x060008E4 RID: 2276 RVA: 0x0001ED60 File Offset: 0x0001CF60
		public void CleanupInitializedFiles(DateTime cleanupThreshold)
		{
			List<string> list = new List<string>();
			foreach (KeyValuePair<string, DateTime> keyValuePair in this.initializedFiles)
			{
				string text = keyValuePair.Key;
				DateTime value = keyValuePair.Value;
				if (value < cleanupThreshold)
				{
					list.Add(text);
				}
			}
			foreach (string text in list)
			{
				string text;
				this.WriteFooterAndUninitialize(text);
			}
		}

		/// <summary>
		/// Flushes all pending file operations.
		/// </summary>
		/// <param name="asyncContinuation">The asynchronous continuation.</param>
		/// <remarks>
		/// The timeout parameter is ignored, because file APIs don't provide
		/// the needed functionality.
		/// </remarks>
		// Token: 0x060008E5 RID: 2277 RVA: 0x0001EE30 File Offset: 0x0001D030
		protected override void FlushAsync(AsyncContinuation asyncContinuation)
		{
			try
			{
				foreach (BaseFileAppender baseFileAppender in this.recentAppenders)
				{
					if (baseFileAppender == null)
					{
						break;
					}
					baseFileAppender.Flush();
				}
				asyncContinuation(null);
			}
			catch (Exception ex)
			{
				if (ex.MustBeRethrown())
				{
					throw;
				}
				asyncContinuation(ex);
			}
		}

		/// <summary>
		/// Initializes file logging by creating data structures that
		/// enable efficient multi-file logging.
		/// </summary>
		// Token: 0x060008E6 RID: 2278 RVA: 0x0001EEB4 File Offset: 0x0001D0B4
		protected override void InitializeTarget()
		{
			base.InitializeTarget();
			if (!this.KeepFileOpen)
			{
				this.appenderFactory = RetryingMultiProcessFileAppender.TheFactory;
			}
			else if (this.ArchiveAboveSize != -1L || this.ArchiveEvery != FileArchivePeriod.None)
			{
				if (this.NetworkWrites)
				{
					this.appenderFactory = RetryingMultiProcessFileAppender.TheFactory;
				}
				else if (this.ConcurrentWrites)
				{
					this.appenderFactory = MutexMultiProcessFileAppender.TheFactory;
				}
				else
				{
					this.appenderFactory = CountingSingleProcessFileAppender.TheFactory;
				}
			}
			else if (this.NetworkWrites)
			{
				this.appenderFactory = RetryingMultiProcessFileAppender.TheFactory;
			}
			else if (this.ConcurrentWrites)
			{
				this.appenderFactory = MutexMultiProcessFileAppender.TheFactory;
			}
			else
			{
				this.appenderFactory = SingleProcessFileAppender.TheFactory;
			}
			this.recentAppenders = new BaseFileAppender[this.OpenFileCacheSize];
			if ((this.OpenFileCacheSize > 0 || this.EnableFileDelete) && this.OpenFileCacheTimeout > 0)
			{
				this.autoClosingTimer = new Timer(new TimerCallback(this.AutoClosingTimerCallback), null, this.OpenFileCacheTimeout * 1000, this.OpenFileCacheTimeout * 1000);
			}
		}

		/// <summary>
		/// Closes the file(s) opened for writing.
		/// </summary>
		// Token: 0x060008E7 RID: 2279 RVA: 0x0001EFFC File Offset: 0x0001D1FC
		protected override void CloseTarget()
		{
			base.CloseTarget();
			foreach (string text in new List<string>(this.initializedFiles.Keys))
			{
				this.WriteFooterAndUninitialize(text);
			}
			if (this.autoClosingTimer != null)
			{
				this.autoClosingTimer.Change(-1, -1);
				this.autoClosingTimer.Dispose();
				this.autoClosingTimer = null;
			}
			if (this.recentAppenders != null)
			{
				for (int i = 0; i < this.recentAppenders.Length; i++)
				{
					if (this.recentAppenders[i] == null)
					{
						break;
					}
					this.recentAppenders[i].Close();
					this.recentAppenders[i] = null;
				}
			}
		}

		/// <summary>
		/// Writes the specified logging event to a file specified in the FileName 
		/// parameter.
		/// </summary>
		/// <param name="logEvent">The logging event.</param>
		// Token: 0x060008E8 RID: 2280 RVA: 0x0001F0F0 File Offset: 0x0001D2F0
		protected override void Write(LogEventInfo logEvent)
		{
			string text = this.FileName.Render(logEvent);
			byte[] bytesToWrite = this.GetBytesToWrite(logEvent);
			if (this.ShouldAutoArchive(text, logEvent, bytesToWrite.Length))
			{
				this.InvalidateCacheItem(text);
				this.DoAutoArchive(text, logEvent);
			}
			this.WriteToFile(text, bytesToWrite, false);
		}

		/// <summary>
		/// Writes the specified array of logging events to a file specified in the FileName
		/// parameter.
		/// </summary>
		/// <param name="logEvents">An array of <see cref="T:NLog.LogEventInfo" /> objects.</param>
		/// <remarks>
		/// This function makes use of the fact that the events are batched by sorting
		/// the requests by filename. This optimizes the number of open/close calls
		/// and can help improve performance.
		/// </remarks>
		// Token: 0x060008E9 RID: 2281 RVA: 0x0001F168 File Offset: 0x0001D368
		protected override void Write(AsyncLogEventInfo[] logEvents)
		{
			Dictionary<string, List<AsyncLogEventInfo>> dictionary = logEvents.BucketSort((AsyncLogEventInfo c) => this.FileName.Render(c.LogEvent));
			using (MemoryStream memoryStream = new MemoryStream())
			{
				List<AsyncContinuation> list = new List<AsyncContinuation>();
				foreach (KeyValuePair<string, List<AsyncLogEventInfo>> keyValuePair in dictionary)
				{
					string key = keyValuePair.Key;
					memoryStream.SetLength(0L);
					memoryStream.Position = 0L;
					LogEventInfo logEventInfo = null;
					foreach (AsyncLogEventInfo asyncLogEventInfo in keyValuePair.Value)
					{
						if (logEventInfo == null)
						{
							logEventInfo = asyncLogEventInfo.LogEvent;
						}
						byte[] bytesToWrite = this.GetBytesToWrite(asyncLogEventInfo.LogEvent);
						memoryStream.Write(bytesToWrite, 0, bytesToWrite.Length);
						list.Add(asyncLogEventInfo.Continuation);
					}
					this.FlushCurrentFileWrites(key, logEventInfo, memoryStream, list);
				}
			}
		}

		/// <summary>
		/// Formats the log event for write.
		/// </summary>
		/// <param name="logEvent">The log event to be formatted.</param>
		/// <returns>A string representation of the log event.</returns>
		// Token: 0x060008EA RID: 2282 RVA: 0x0001F2B8 File Offset: 0x0001D4B8
		protected virtual string GetFormattedMessage(LogEventInfo logEvent)
		{
			return this.Layout.Render(logEvent);
		}

		/// <summary>
		/// Gets the bytes to be written to the file.
		/// </summary>
		/// <param name="logEvent">Log event.</param>
		/// <returns>Array of bytes that are ready to be written.</returns>
		// Token: 0x060008EB RID: 2283 RVA: 0x0001F2D8 File Offset: 0x0001D4D8
		protected virtual byte[] GetBytesToWrite(LogEventInfo logEvent)
		{
			string text = this.GetFormattedMessage(logEvent) + this.NewLineChars;
			return this.TransformBytes(this.Encoding.GetBytes(text));
		}

		/// <summary>
		/// Modifies the specified byte array before it gets sent to a file.
		/// </summary>
		/// <param name="value">The byte array.</param>
		/// <returns>The modified byte array. The function can do the modification in-place.</returns>
		// Token: 0x060008EC RID: 2284 RVA: 0x0001F310 File Offset: 0x0001D510
		protected virtual byte[] TransformBytes(byte[] value)
		{
			return value;
		}

		// Token: 0x060008ED RID: 2285 RVA: 0x0001F324 File Offset: 0x0001D524
		private static bool IsContainValidNumberPatternForReplacement(string pattern)
		{
			int num = pattern.IndexOf("{#", StringComparison.Ordinal);
			int num2 = pattern.IndexOf("#}", StringComparison.Ordinal);
			return num != -1 && num2 != -1 && num < num2;
		}

		// Token: 0x060008EE RID: 2286 RVA: 0x0001F360 File Offset: 0x0001D560
		private static string ReplaceNumber(string pattern, int value)
		{
			int num = pattern.IndexOf("{#", StringComparison.Ordinal);
			int num2 = pattern.IndexOf("#}", StringComparison.Ordinal) + 2;
			int num3 = num2 - num - 2;
			return pattern.Substring(0, num) + Convert.ToString(value, 10).PadLeft(num3, '0') + pattern.Substring(num2);
		}

		// Token: 0x060008EF RID: 2287 RVA: 0x0001F3B8 File Offset: 0x0001D5B8
		private void FlushCurrentFileWrites(string currentFileName, LogEventInfo firstLogEvent, MemoryStream ms, List<AsyncContinuation> pendingContinuations)
		{
			Exception ex = null;
			try
			{
				if (currentFileName != null)
				{
					if (this.ShouldAutoArchive(currentFileName, firstLogEvent, (int)ms.Length))
					{
						this.WriteFooterAndUninitialize(currentFileName);
						this.InvalidateCacheItem(currentFileName);
						this.DoAutoArchive(currentFileName, firstLogEvent);
					}
					this.WriteToFile(currentFileName, ms.ToArray(), false);
				}
			}
			catch (Exception ex2)
			{
				if (ex2.MustBeRethrown())
				{
					throw;
				}
				ex = ex2;
			}
			foreach (AsyncContinuation asyncContinuation in pendingContinuations)
			{
				asyncContinuation(ex);
			}
			pendingContinuations.Clear();
		}

		// Token: 0x060008F0 RID: 2288 RVA: 0x0001F490 File Offset: 0x0001D690
		private void RecursiveRollingRename(string fileName, string pattern, int archiveNumber)
		{
			if (archiveNumber >= this.MaxArchiveFiles)
			{
				File.Delete(fileName);
			}
			else if (File.Exists(fileName))
			{
				string text = FileTarget.ReplaceNumber(pattern, archiveNumber);
				if (File.Exists(fileName))
				{
					this.RecursiveRollingRename(text, pattern, archiveNumber + 1);
				}
				InternalLogger.Trace("Renaming {0} to {1}", new object[] { fileName, text });
				try
				{
					File.Move(fileName, text);
				}
				catch (IOException)
				{
					string directoryName = Path.GetDirectoryName(text);
					if (!Directory.Exists(directoryName))
					{
						Directory.CreateDirectory(directoryName);
					}
					File.Move(fileName, text);
				}
			}
		}

		// Token: 0x060008F1 RID: 2289 RVA: 0x0001F544 File Offset: 0x0001D744
		private void SequentialArchive(string fileName, string pattern)
		{
			string fileName2 = Path.GetFileName(pattern);
			int num = fileName2.IndexOf("{#", StringComparison.Ordinal);
			int num2 = fileName2.IndexOf("#}", StringComparison.Ordinal) + 2;
			int num3 = fileName2.Length - num2;
			string text = fileName2.Substring(0, num) + "*" + fileName2.Substring(num2);
			string directoryName = Path.GetDirectoryName(Path.GetFullPath(pattern));
			int num4 = -1;
			int num5 = -1;
			Dictionary<int, string> dictionary = new Dictionary<int, string>();
			try
			{
				string[] files = Directory.GetFiles(directoryName, text);
				int i = 0;
				while (i < files.Length)
				{
					string text2 = files[i];
					string fileName3 = Path.GetFileName(text2);
					string text3 = fileName3.Substring(num, fileName3.Length - num3 - num);
					int num6;
					try
					{
						num6 = Convert.ToInt32(text3, CultureInfo.InvariantCulture);
					}
					catch (FormatException)
					{
						goto IL_DE;
					}
					goto IL_B0;
					IL_DE:
					i++;
					continue;
					IL_B0:
					num4 = Math.Max(num4, num6);
					num5 = ((num5 != -1) ? Math.Min(num5, num6) : num6);
					dictionary[num6] = text2;
					goto IL_DE;
				}
				num4++;
			}
			catch (DirectoryNotFoundException)
			{
				Directory.CreateDirectory(directoryName);
				num4 = 0;
			}
			if (num5 != -1)
			{
				int num7 = num4 - this.MaxArchiveFiles + 1;
				for (int j = num5; j < num7; j++)
				{
					string text2;
					if (dictionary.TryGetValue(j, out text2))
					{
						File.Delete(text2);
					}
				}
			}
			string text4 = FileTarget.ReplaceNumber(pattern, num4);
			File.Move(fileName, text4);
		}

		// Token: 0x060008F2 RID: 2290 RVA: 0x0001F6E0 File Offset: 0x0001D8E0
		private void DateArchive(string fileName, string pattern)
		{
			string fileName2 = Path.GetFileName(pattern);
			int num = fileName2.IndexOf("{#", StringComparison.Ordinal);
			int num2 = fileName2.IndexOf("#}", StringComparison.Ordinal) + 2;
			string text = fileName2.Substring(0, num) + "*" + fileName2.Substring(num2);
			string directoryName = Path.GetDirectoryName(Path.GetFullPath(pattern));
			string dateFormatString = this.GetDateFormatString(this.ArchiveDateFormat);
			int num3 = 0;
			try
			{
				List<string> list = Directory.GetFiles(directoryName, text).ToList<string>();
				Dictionary<DateTime, string> dictionary = new Dictionary<DateTime, string>();
				foreach (string text2 in list)
				{
					string fileName3 = Path.GetFileName(text2);
					string text3 = fileName3.Substring(text.LastIndexOf('*'), dateFormatString.Length);
					DateTime now = DateTime.Now;
					if (DateTime.TryParseExact(text3, dateFormatString, CultureInfo.InvariantCulture, DateTimeStyles.None, out now))
					{
						dictionary.Add(now, text2);
					}
				}
				foreach (KeyValuePair<DateTime, string> keyValuePair in dictionary)
				{
					if (num3 > list.Count - this.MaxArchiveFiles)
					{
						break;
					}
					File.Delete(keyValuePair.Value);
					num3++;
				}
			}
			catch (DirectoryNotFoundException)
			{
				Directory.CreateDirectory(directoryName);
			}
			string text4 = Path.Combine(directoryName, text.Replace("*", this.GetArchiveDate().ToString(dateFormatString)));
			File.Move(fileName, text4);
		}

		// Token: 0x060008F3 RID: 2291 RVA: 0x0001F8D8 File Offset: 0x0001DAD8
		private string GetDateFormatString(string defaultFormat)
		{
			string text = defaultFormat;
			if (string.IsNullOrEmpty(text))
			{
				switch (this.ArchiveEvery)
				{
				case FileArchivePeriod.Year:
					text = "yyyy";
					goto IL_5E;
				case FileArchivePeriod.Month:
					text = "yyyyMM";
					goto IL_5E;
				case FileArchivePeriod.Hour:
					text = "yyyyMMddHH";
					goto IL_5E;
				case FileArchivePeriod.Minute:
					text = "yyyyMMddHHmm";
					goto IL_5E;
				}
				text = "yyyyMMdd";
				IL_5E:;
			}
			return text;
		}

		// Token: 0x060008F4 RID: 2292 RVA: 0x0001F94C File Offset: 0x0001DB4C
		private DateTime GetArchiveDate()
		{
			DateTime dateTime = DateTime.Now;
			switch (this.ArchiveEvery)
			{
			case FileArchivePeriod.Year:
				dateTime = dateTime.AddYears(-1);
				break;
			case FileArchivePeriod.Month:
				dateTime = dateTime.AddMonths(-1);
				break;
			case FileArchivePeriod.Day:
				dateTime = dateTime.AddDays(-1.0);
				break;
			case FileArchivePeriod.Hour:
				dateTime = dateTime.AddHours(-1.0);
				break;
			case FileArchivePeriod.Minute:
				dateTime = dateTime.AddMinutes(-1.0);
				break;
			}
			return dateTime;
		}

		// Token: 0x060008F5 RID: 2293 RVA: 0x0001F9DC File Offset: 0x0001DBDC
		private void DoAutoArchive(string fileName, LogEventInfo ev)
		{
			FileInfo fileInfo = new FileInfo(fileName);
			if (fileInfo.Exists)
			{
				string text;
				if (this.ArchiveFileName == null)
				{
					string extension = Path.GetExtension(fileName);
					text = Path.ChangeExtension(fileInfo.FullName, ".{#}" + extension);
				}
				else
				{
					text = this.ArchiveFileName.Render(ev);
				}
				if (!FileTarget.IsContainValidNumberPatternForReplacement(text))
				{
					this.dynamicArchiveFileHandler.AddToArchive(text, fileInfo.FullName, this.CreateDirs);
				}
				else
				{
					switch (this.ArchiveNumbering)
					{
					case ArchiveNumberingMode.Sequence:
						this.SequentialArchive(fileInfo.FullName, text);
						break;
					case ArchiveNumberingMode.Rolling:
						this.RecursiveRollingRename(fileInfo.FullName, text, 0);
						break;
					case ArchiveNumberingMode.Date:
						this.DateArchive(fileInfo.FullName, text);
						break;
					}
				}
			}
		}

		// Token: 0x060008F6 RID: 2294 RVA: 0x0001FABC File Offset: 0x0001DCBC
		private bool ShouldAutoArchive(string fileName, LogEventInfo ev, int upcomingWriteSize)
		{
			bool flag;
			DateTime dateTime;
			long num;
			if (this.ArchiveAboveSize == -1L && this.ArchiveEvery == FileArchivePeriod.None)
			{
				flag = false;
			}
			else if (!this.GetFileInfo(fileName, out dateTime, out num))
			{
				flag = false;
			}
			else
			{
				if (this.ArchiveAboveSize != -1L)
				{
					if (num + (long)upcomingWriteSize > this.ArchiveAboveSize)
					{
						return true;
					}
				}
				if (this.ArchiveEvery != FileArchivePeriod.None)
				{
					string dateFormatString = this.GetDateFormatString(string.Empty);
					string text = dateTime.ToString(dateFormatString, CultureInfo.InvariantCulture);
					string text2 = ev.TimeStamp.ToLocalTime().ToString(dateFormatString, CultureInfo.InvariantCulture);
					if (text != text2)
					{
						return true;
					}
				}
				flag = false;
			}
			return flag;
		}

		// Token: 0x060008F7 RID: 2295 RVA: 0x0001FBA4 File Offset: 0x0001DDA4
		private void AutoClosingTimerCallback(object state)
		{
			lock (base.SyncRoot)
			{
				if (base.IsInitialized)
				{
					try
					{
						DateTime dateTime = DateTime.Now.AddSeconds((double)(-(double)this.OpenFileCacheTimeout));
						for (int i = 0; i < this.recentAppenders.Length; i++)
						{
							if (this.recentAppenders[i] == null)
							{
								break;
							}
							if (this.recentAppenders[i].OpenTime < dateTime)
							{
								for (int j = i; j < this.recentAppenders.Length; j++)
								{
									if (this.recentAppenders[j] == null)
									{
										break;
									}
									this.recentAppenders[j].Close();
									this.recentAppenders[j] = null;
								}
								break;
							}
						}
					}
					catch (Exception ex)
					{
						if (ex.MustBeRethrown())
						{
							throw;
						}
						InternalLogger.Warn("Exception in AutoClosingTimerCallback: {0}", new object[] { ex });
					}
				}
			}
		}

		// Token: 0x060008F8 RID: 2296 RVA: 0x0001FD18 File Offset: 0x0001DF18
		private void WriteToFile(string fileName, byte[] bytes, bool justData)
		{
			if (this.ReplaceFileContentsOnEachWrite)
			{
				using (FileStream fileStream = File.Create(fileName))
				{
					byte[] array = this.GetHeaderBytes();
					byte[] footerBytes = this.GetFooterBytes();
					if (array != null)
					{
						fileStream.Write(array, 0, array.Length);
					}
					fileStream.Write(bytes, 0, bytes.Length);
					if (footerBytes != null)
					{
						fileStream.Write(footerBytes, 0, footerBytes.Length);
					}
				}
			}
			else
			{
				bool flag = false;
				if (!justData)
				{
					if (!this.initializedFiles.ContainsKey(fileName))
					{
						if (this.DeleteOldFileOnStartup)
						{
							try
							{
								File.Delete(fileName);
							}
							catch (Exception ex)
							{
								if (ex.MustBeRethrown())
								{
									throw;
								}
								InternalLogger.Warn("Unable to delete old log file '{0}': {1}", new object[] { fileName, ex });
							}
						}
						this.initializedFiles[fileName] = DateTime.Now;
						this.initializedFilesCounter++;
						flag = true;
						if (this.initializedFilesCounter >= 100)
						{
							this.initializedFilesCounter = 0;
							this.CleanupInitializedFiles();
						}
					}
					this.initializedFiles[fileName] = DateTime.Now;
				}
				BaseFileAppender baseFileAppender = null;
				int num = this.recentAppenders.Length - 1;
				for (int i = 0; i < this.recentAppenders.Length; i++)
				{
					if (this.recentAppenders[i] == null)
					{
						num = i;
						break;
					}
					if (this.recentAppenders[i].FileName == fileName)
					{
						BaseFileAppender baseFileAppender2 = this.recentAppenders[i];
						for (int j = i; j > 0; j--)
						{
							this.recentAppenders[j] = this.recentAppenders[j - 1];
						}
						this.recentAppenders[0] = baseFileAppender2;
						baseFileAppender = baseFileAppender2;
						break;
					}
				}
				if (baseFileAppender == null)
				{
					BaseFileAppender baseFileAppender3 = this.appenderFactory.Open(fileName, this);
					if (this.recentAppenders[num] != null)
					{
						this.recentAppenders[num].Close();
						this.recentAppenders[num] = null;
					}
					for (int j = num; j > 0; j--)
					{
						this.recentAppenders[j] = this.recentAppenders[j - 1];
					}
					this.recentAppenders[0] = baseFileAppender3;
					baseFileAppender = baseFileAppender3;
				}
				if (flag)
				{
					DateTime dateTime;
					long num2;
					if (!baseFileAppender.GetFileInfo(out dateTime, out num2) || num2 == 0L)
					{
						byte[] array = this.GetHeaderBytes();
						if (array != null)
						{
							baseFileAppender.Write(array);
						}
					}
				}
				baseFileAppender.Write(bytes);
			}
		}

		// Token: 0x060008F9 RID: 2297 RVA: 0x00020024 File Offset: 0x0001E224
		private byte[] GetHeaderBytes()
		{
			byte[] array;
			if (base.Header == null)
			{
				array = null;
			}
			else
			{
				string text = base.Header.Render(LogEventInfo.CreateNullEvent()) + this.NewLineChars;
				array = this.TransformBytes(this.Encoding.GetBytes(text));
			}
			return array;
		}

		// Token: 0x060008FA RID: 2298 RVA: 0x0002007C File Offset: 0x0001E27C
		private byte[] GetFooterBytes()
		{
			byte[] array;
			if (base.Footer == null)
			{
				array = null;
			}
			else
			{
				string text = base.Footer.Render(LogEventInfo.CreateNullEvent()) + this.NewLineChars;
				array = this.TransformBytes(this.Encoding.GetBytes(text));
			}
			return array;
		}

		// Token: 0x060008FB RID: 2299 RVA: 0x000200D4 File Offset: 0x0001E2D4
		private void WriteFooterAndUninitialize(string fileName)
		{
			byte[] footerBytes = this.GetFooterBytes();
			if (footerBytes != null)
			{
				if (File.Exists(fileName))
				{
					this.WriteToFile(fileName, footerBytes, true);
				}
			}
			this.initializedFiles.Remove(fileName);
		}

		// Token: 0x060008FC RID: 2300 RVA: 0x0002011C File Offset: 0x0001E31C
		private bool GetFileInfo(string fileName, out DateTime lastWriteTime, out long fileLength)
		{
			foreach (BaseFileAppender baseFileAppender in this.recentAppenders)
			{
				if (baseFileAppender == null)
				{
					break;
				}
				if (baseFileAppender.FileName == fileName)
				{
					baseFileAppender.GetFileInfo(out lastWriteTime, out fileLength);
					return true;
				}
			}
			FileInfo fileInfo = new FileInfo(fileName);
			if (fileInfo.Exists)
			{
				fileLength = fileInfo.Length;
				lastWriteTime = fileInfo.LastWriteTime;
				return true;
			}
			fileLength = -1L;
			lastWriteTime = DateTime.MinValue;
			return false;
		}

		// Token: 0x060008FD RID: 2301 RVA: 0x000201C8 File Offset: 0x0001E3C8
		private void InvalidateCacheItem(string fileName)
		{
			for (int i = 0; i < this.recentAppenders.Length; i++)
			{
				if (this.recentAppenders[i] == null)
				{
					break;
				}
				if (this.recentAppenders[i].FileName == fileName)
				{
					this.recentAppenders[i].Close();
					for (int j = i; j < this.recentAppenders.Length - 1; j++)
					{
						this.recentAppenders[j] = this.recentAppenders[j + 1];
					}
					this.recentAppenders[this.recentAppenders.Length - 1] = null;
					break;
				}
			}
		}

		// Token: 0x040002A1 RID: 673
		private readonly Dictionary<string, DateTime> initializedFiles = new Dictionary<string, DateTime>();

		// Token: 0x040002A2 RID: 674
		private LineEndingMode lineEndingMode = LineEndingMode.Default;

		// Token: 0x040002A3 RID: 675
		private IFileAppenderFactory appenderFactory;

		// Token: 0x040002A4 RID: 676
		private BaseFileAppender[] recentAppenders;

		// Token: 0x040002A5 RID: 677
		private Timer autoClosingTimer;

		// Token: 0x040002A6 RID: 678
		private int initializedFilesCounter;

		// Token: 0x040002A7 RID: 679
		private int _MaxArchiveFilesField;

		// Token: 0x040002A8 RID: 680
		private readonly FileTarget.DynamicArchiveFileHandlerClass dynamicArchiveFileHandler;

		// Token: 0x02000113 RID: 275
		private class DynamicArchiveFileHandlerClass
		{
			// Token: 0x060008FF RID: 2303 RVA: 0x00020277 File Offset: 0x0001E477
			public DynamicArchiveFileHandlerClass(int MaxArchivedFiles)
				: this()
			{
				this.MaxArchiveFileToKeep = MaxArchivedFiles;
			}

			// Token: 0x06000900 RID: 2304 RVA: 0x0002028A File Offset: 0x0001E48A
			public DynamicArchiveFileHandlerClass()
			{
				this.MaxArchiveFileToKeep = -1;
				this.archiveFileEntryQueue = new Queue<string>();
			}

			// Token: 0x170001D2 RID: 466
			// (get) Token: 0x06000901 RID: 2305 RVA: 0x000202A8 File Offset: 0x0001E4A8
			// (set) Token: 0x06000902 RID: 2306 RVA: 0x000202BF File Offset: 0x0001E4BF
			public int MaxArchiveFileToKeep { get; set; }

			// Token: 0x06000903 RID: 2307 RVA: 0x000202C8 File Offset: 0x0001E4C8
			[SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
			public void AddToArchive(string archiveFileName, string fileName, bool createDirectoryIfNotExists)
			{
				if (this.MaxArchiveFileToKeep < 1)
				{
					InternalLogger.Warn("AddToArchive is called. Even though the MaxArchiveFiles is set to less than 1");
				}
				else if (!File.Exists(fileName))
				{
					InternalLogger.Error("Error while trying to archive, Source File : {0} Not found.", new object[] { fileName });
				}
				else
				{
					while (this.archiveFileEntryQueue.Count >= this.MaxArchiveFileToKeep)
					{
						string text = this.archiveFileEntryQueue.Dequeue();
						try
						{
							File.Delete(text);
						}
						catch (Exception ex)
						{
							InternalLogger.Warn("Can't Delete Old Archive File : {0} , Exception : {1}", new object[] { text, ex });
						}
					}
					string text2 = archiveFileName;
					if (this.archiveFileEntryQueue.Contains(archiveFileName))
					{
						InternalLogger.Trace("Archive File {0} seems to be already exist. Trying with Different File Name..", new object[] { archiveFileName });
						int num = 1;
						text2 = Path.GetFileNameWithoutExtension(archiveFileName) + ".{#}" + Path.GetExtension(archiveFileName);
						while (File.Exists(FileTarget.ReplaceNumber(text2, num)))
						{
							InternalLogger.Trace("Archive File {0} seems to be already exist, too. Trying with Different File Name..", new object[] { archiveFileName });
							num++;
						}
					}
					try
					{
						File.Move(fileName, text2);
					}
					catch (DirectoryNotFoundException)
					{
						if (!createDirectoryIfNotExists)
						{
							throw;
						}
						InternalLogger.Trace("Directory For Archive File is not created. Creating it..");
						try
						{
							Directory.CreateDirectory(Path.GetDirectoryName(archiveFileName));
							File.Move(fileName, text2);
						}
						catch (Exception ex2)
						{
							InternalLogger.Error("Can't create Archive File Directory , Exception : {0}", new object[] { ex2 });
							throw;
						}
					}
					catch (Exception ex2)
					{
						InternalLogger.Error("Can't Archive File : {0} , Exception : {1}", new object[] { fileName, ex2 });
						throw;
					}
					this.archiveFileEntryQueue.Enqueue(archiveFileName);
				}
			}

			// Token: 0x040002C0 RID: 704
			private readonly Queue<string> archiveFileEntryQueue;
		}
	}
}
