using System.IO;
using ICSharpCode.SharpZipLib.GZip;
using ICSharpCode.SharpZipLib.Tar;
using ICSharpCode.SharpZipLib.Zip;

namespace Crosire.Library
{
	public class Compression
	{
		public static void Extract(string ArchiveName, string destFolder)
		{
			if (ArchiveName.EndsWith(".tar.gz"))
			{
				ExtractTarGz(ArchiveName, destFolder);
			}
			else
			{
				ExtractZip(ArchiveName, destFolder);
			}
		}

		public static void ExtractZip(string zipArchiveName, string destFolder)
		{
			FastZip fastZip = new FastZip();
			fastZip.ExtractZip(zipArchiveName, destFolder, null);
		}

		public static void ExtractTarGz(string gzArchiveName, string destFolder)
		{
			Stream stream = File.OpenRead(gzArchiveName);
			Stream stream2 = (Stream)(object)new GZipInputStream((Stream)(object)stream);
			TarArchive tarArchive = TarArchive.CreateInputTarArchive((Stream)(object)stream2);
			tarArchive.ExtractContents(destFolder);
			tarArchive.Close();
			stream2.Close();
			stream.Close();
		}
	}
}
