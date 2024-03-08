using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using NLog.Common;

namespace NLog.Internal
{
	/// <summary>
	/// Watches multiple files at the same time and raises an event whenever 
	/// a single change is detected in any of those files.
	/// </summary>
	// Token: 0x02000070 RID: 112
	internal class MultiFileWatcher : IDisposable
	{
		/// <summary>
		/// Occurs when a change is detected in one of the monitored files.
		/// </summary>
		// Token: 0x14000005 RID: 5
		// (add) Token: 0x060002C1 RID: 705 RVA: 0x0000AFC0 File Offset: 0x000091C0
		// (remove) Token: 0x060002C2 RID: 706 RVA: 0x0000AFFC File Offset: 0x000091FC
		public event EventHandler OnChange;

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		// Token: 0x060002C3 RID: 707 RVA: 0x0000B038 File Offset: 0x00009238
		public void Dispose()
		{
			this.StopWatching();
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// Stops the watching.
		/// </summary>
		// Token: 0x060002C4 RID: 708 RVA: 0x0000B04C File Offset: 0x0000924C
		public void StopWatching()
		{
			lock (this)
			{
				foreach (FileSystemWatcher fileSystemWatcher in this.watchers)
				{
					InternalLogger.Info("Stopping file watching for path '{0}' filter '{1}'", new object[] { fileSystemWatcher.Path, fileSystemWatcher.Filter });
					fileSystemWatcher.EnableRaisingEvents = false;
					fileSystemWatcher.Dispose();
				}
				this.watchers.Clear();
			}
		}

		/// <summary>
		/// Watches the specified files for changes.
		/// </summary>
		/// <param name="fileNames">The file names.</param>
		// Token: 0x060002C5 RID: 709 RVA: 0x0000B118 File Offset: 0x00009318
		public void Watch(IEnumerable<string> fileNames)
		{
			if (fileNames != null)
			{
				foreach (string text in fileNames)
				{
					this.Watch(text);
				}
			}
		}

		// Token: 0x060002C6 RID: 710 RVA: 0x0000B17C File Offset: 0x0000937C
		[SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "Watcher is released in Dispose()")]
		internal void Watch(string fileName)
		{
			FileSystemWatcher fileSystemWatcher = new FileSystemWatcher
			{
				Path = Path.GetDirectoryName(fileName),
				Filter = Path.GetFileName(fileName),
				NotifyFilter = (NotifyFilters.Attributes | NotifyFilters.Size | NotifyFilters.LastWrite | NotifyFilters.CreationTime | NotifyFilters.Security)
			};
			fileSystemWatcher.Created += this.OnWatcherChanged;
			fileSystemWatcher.Changed += this.OnWatcherChanged;
			fileSystemWatcher.Deleted += this.OnWatcherChanged;
			fileSystemWatcher.EnableRaisingEvents = true;
			InternalLogger.Info("Watching path '{0}' filter '{1}' for changes.", new object[] { fileSystemWatcher.Path, fileSystemWatcher.Filter });
			lock (this)
			{
				this.watchers.Add(fileSystemWatcher);
			}
		}

		// Token: 0x060002C7 RID: 711 RVA: 0x0000B264 File Offset: 0x00009464
		private void OnWatcherChanged(object source, FileSystemEventArgs e)
		{
			lock (this)
			{
				if (this.OnChange != null)
				{
					this.OnChange(source, e);
				}
			}
		}

		// Token: 0x040000BA RID: 186
		private List<FileSystemWatcher> watchers = new List<FileSystemWatcher>();
	}
}
