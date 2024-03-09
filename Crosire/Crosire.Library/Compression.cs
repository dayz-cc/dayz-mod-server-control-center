using System.IO;
using ICSharpCode.SharpZipLib.GZip;
using ICSharpCode.SharpZipLib.Tar;
using ICSharpCode.SharpZipLib.Zip;

namespace Crosire.Library {
    public class Compression {
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

        public void ExtractSubfolder(string tempPath, string destPath, string subfolder) {
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
