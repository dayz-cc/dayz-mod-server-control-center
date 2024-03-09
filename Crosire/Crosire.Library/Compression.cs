using System;
using System.IO;
using System.Linq;
using SharpCompress.Archives;
using SharpCompress.Archives.Tar;
using SharpCompress.Common;
using ICSharpCode.SharpZipLib;
using ICSharpCode.SharpZipLib.GZip;
using ICSharpCode.SharpZipLib.Tar;
using ICSharpCode.SharpZipLib.Zip;
using TarArchive = ICSharpCode.SharpZipLib.Tar.TarArchive;

namespace Crosire.Library {
    public static class Compression {
        /*public static void Extract(string archivePath, string destPath, string archiveRoot = "/") {
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
                    if (!entry.IsDirectory && entry.Key != null) { // Add null check here
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
        }*/

        public static void Extract(string ArchiveName, string destFolder) {
            if (ArchiveName.EndsWith(".tar.gz")) {
                ExtractTarGz(ArchiveName, destFolder);
            } else {
                ExtractZip(ArchiveName, destFolder);
            }
        }

        public static void ExtractZip(string zipArchiveName, string destFolder) {
            FastZip fastZip = new FastZip();
            fastZip.ExtractZip(zipArchiveName, destFolder, null);
        }

        public static void ExtractTarGz(string archivePath, string tempPath) {
            using (FileStream inStream = File.OpenRead(archivePath))
            using (GZipInputStream gzipStream = new GZipInputStream(inStream)) {
                TarArchive tarArchive = TarArchive.CreateInputTarArchive(gzipStream);
                tarArchive.ExtractContents(tempPath);
                tarArchive.Close();
            }
        }

        public static void ExtractSubfolder(string tempPath, string destPath, string subfolder) {
            string subfolderPath = Path.Combine(tempPath, subfolder);
            if (Directory.Exists(subfolderPath)) {
                foreach (string dirPath in Directory.GetDirectories(subfolderPath, "*", SearchOption.AllDirectories)) {
                    Directory.CreateDirectory(dirPath.Replace(tempPath, destPath));
                }

                foreach (string filePath in Directory.GetFiles(subfolderPath, "*.*", SearchOption.AllDirectories)) {
                    File.Copy(filePath, filePath.Replace(tempPath, destPath), true);
                }
            }
        }
    }
}
