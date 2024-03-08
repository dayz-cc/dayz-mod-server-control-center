using System;
using System.Diagnostics.CodeAnalysis;

namespace NLog.Targets
{
	/// <summary>
	/// Win32 file attributes.
	/// </summary>
	/// <remarks>
	/// For more information see <a href="http://msdn.microsoft.com/library/default.asp?url=/library/en-us/fileio/fs/createfile.asp">http://msdn.microsoft.com/library/default.asp?url=/library/en-us/fileio/fs/createfile.asp</a>.
	/// </remarks>
	// Token: 0x0200012D RID: 301
	[Flags]
	[SuppressMessage("Microsoft.Usage", "CA2217:DoNotMarkEnumsWithFlags", Justification = "This set of flags matches Win32 API")]
	public enum Win32FileAttributes
	{
		/// <summary>
		/// Read-only file.
		/// </summary>
		// Token: 0x04000330 RID: 816
		ReadOnly = 1,
		/// <summary>
		/// Hidden file.
		/// </summary>
		// Token: 0x04000331 RID: 817
		Hidden = 2,
		/// <summary>
		/// System file.
		/// </summary>
		// Token: 0x04000332 RID: 818
		System = 4,
		/// <summary>
		/// File should be archived.
		/// </summary>
		// Token: 0x04000333 RID: 819
		Archive = 32,
		/// <summary>
		/// Device file.
		/// </summary>
		// Token: 0x04000334 RID: 820
		Device = 64,
		/// <summary>
		/// Normal file.
		/// </summary>
		// Token: 0x04000335 RID: 821
		Normal = 128,
		/// <summary>
		/// File is temporary (should be kept in cache and not 
		/// written to disk if possible).
		/// </summary>
		// Token: 0x04000336 RID: 822
		Temporary = 256,
		/// <summary>
		/// Sparse file.
		/// </summary>
		// Token: 0x04000337 RID: 823
		SparseFile = 512,
		/// <summary>
		/// Reparse point.
		/// </summary>
		// Token: 0x04000338 RID: 824
		ReparsePoint = 1024,
		/// <summary>
		/// Compress file contents.
		/// </summary>
		// Token: 0x04000339 RID: 825
		Compressed = 2048,
		/// <summary>
		/// File should not be indexed by the content indexing service. 
		/// </summary>
		// Token: 0x0400033A RID: 826
		NotContentIndexed = 8192,
		/// <summary>
		/// Encrypted file.
		/// </summary>
		// Token: 0x0400033B RID: 827
		Encrypted = 16384,
		/// <summary>
		/// The system writes through any intermediate cache and goes directly to disk. 
		/// </summary>
		// Token: 0x0400033C RID: 828
		WriteThrough = -2147483648,
		/// <summary>
		/// The system opens a file with no system caching.
		/// </summary>
		// Token: 0x0400033D RID: 829
		NoBuffering = 536870912,
		/// <summary>
		/// Delete file after it is closed.
		/// </summary>
		// Token: 0x0400033E RID: 830
		DeleteOnClose = 67108864,
		/// <summary>
		/// A file is accessed according to POSIX rules.
		/// </summary>
		// Token: 0x0400033F RID: 831
		PosixSemantics = 16777216
	}
}
