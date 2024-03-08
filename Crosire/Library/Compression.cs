using System;
using System.IO;
using ICSharpCode.SharpZipLib.GZip;
using ICSharpCode.SharpZipLib.Tar;
using ICSharpCode.SharpZipLib.Zip;

namespace Crosire.Library
{
	// Token: 0x02000003 RID: 3
	public class Compression
	{
		// Token: 0x06000005 RID: 5 RVA: 0x000020F0 File Offset: 0x000002F0
		public static void Extract(string ArchiveName, string destFolder)
		{
			if (ArchiveName.EndsWith(".tar.gz"))
			{
				Compression.ExtractTarGz(ArchiveName, destFolder);
				return;
			}
			Compression.ExtractZip(ArchiveName, destFolder);
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00002110 File Offset: 0x00000310
		public static void ExtractZip(string zipArchiveName, string destFolder)
		{
			FastZip fastZip = new FastZip();
			fastZip.ExtractZip(zipArchiveName, destFolder, null);
		}

		// Token: 0x06000007 RID: 7 RVA: 0x0000212C File Offset: 0x0000032C
		public static void ExtractTarGz(string gzArchiveName, string destFolder)
		{
			Stream stream = File.OpenRead(gzArchiveName);
			Stream stream2 = new GZipInputStream(stream);
			TarArchive tarArchive = TarArchive.CreateInputTarArchive(stream2);
			tarArchive.ExtractContents(destFolder);
			tarArchive.Close();
			stream2.Close();
			stream.Close();
		}
	}
}
