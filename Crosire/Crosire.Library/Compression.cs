using System;
using System.IO;
using System.Linq;
using SharpCompress.Archives;
using SharpCompress.Common;

namespace Crosire.Library {
    public static class Compression {
        public static void Extract(string archivePath, string destPath, string archiveRoot = "/") {
            using (Stream stream = File.OpenRead(archivePath)) {
                var reader = ArchiveFactory.Open(stream);
                var entries = reader.Entries.ToList();
                if (entries.Count < 1) throw new ArchiveException($"Empty archive: {archivePath}");
                var firstEntry = entries.First();
                var isGithubTarball = (entries.Count == 1 && firstEntry.IsDirectory && firstEntry.Key.Contains("-"));
                Console.WriteLine($"Extracting {archivePath} to {destPath} (root: {archiveRoot}) [entries: {entries.Count}, isGithubTarball: {isGithubTarball}]");
                if (isGithubTarball && archiveRoot == "/") {
                    Extract(archivePath, destPath, archiveRoot + firstEntry.Key); return;
                }
                foreach (var entry in reader.Entries) {
                    if (!entry.IsDirectory) {
                        string entryPath = entry.Key;
                        if (entryPath.StartsWith(archiveRoot)) {
                            entryPath = entryPath.Substring(archiveRoot.Length);
                        }
                        entry.WriteToDirectory(Path.Combine(destPath, entryPath), new ExtractionOptions() {
                            ExtractFullPath = true,
                            Overwrite = true
                        });
                    }
                }
            }
        }
    }
}
