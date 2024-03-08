using System;
using System.Runtime.InteropServices;
using NLog.Targets;

namespace NLog.Internal
{
	// Token: 0x0200008F RID: 143
	internal static class Win32FileNativeMethods
	{
		// Token: 0x06000365 RID: 869
		[DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		public static extern IntPtr CreateFile(string lpFileName, Win32FileNativeMethods.FileAccess dwDesiredAccess, int dwShareMode, IntPtr lpSecurityAttributes, Win32FileNativeMethods.CreationDisposition dwCreationDisposition, Win32FileAttributes dwFlagsAndAttributes, IntPtr hTemplateFile);

		// Token: 0x06000366 RID: 870
		[DllImport("kernel32.dll", SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		public static extern bool GetFileInformationByHandle(IntPtr hFile, out Win32FileNativeMethods.BY_HANDLE_FILE_INFORMATION lpFileInformation);

		// Token: 0x040000E6 RID: 230
		public const int FILE_SHARE_READ = 1;

		// Token: 0x040000E7 RID: 231
		public const int FILE_SHARE_WRITE = 2;

		// Token: 0x040000E8 RID: 232
		public const int FILE_SHARE_DELETE = 4;

		// Token: 0x02000090 RID: 144
		[Flags]
		public enum FileAccess : uint
		{
			// Token: 0x040000EA RID: 234
			GenericRead = 2147483648U,
			// Token: 0x040000EB RID: 235
			GenericWrite = 1073741824U,
			// Token: 0x040000EC RID: 236
			GenericExecute = 536870912U,
			// Token: 0x040000ED RID: 237
			GenericAll = 268435456U
		}

		// Token: 0x02000091 RID: 145
		public enum CreationDisposition : uint
		{
			// Token: 0x040000EF RID: 239
			New = 1U,
			// Token: 0x040000F0 RID: 240
			CreateAlways,
			// Token: 0x040000F1 RID: 241
			OpenExisting,
			// Token: 0x040000F2 RID: 242
			OpenAlways,
			// Token: 0x040000F3 RID: 243
			TruncateExisting
		}

		// Token: 0x02000092 RID: 146
		[StructLayout(LayoutKind.Sequential, Pack = 1)]
		public struct BY_HANDLE_FILE_INFORMATION
		{
			// Token: 0x040000F4 RID: 244
			public uint dwFileAttributes;

			// Token: 0x040000F5 RID: 245
			public long ftCreationTime;

			// Token: 0x040000F6 RID: 246
			public long ftLastAccessTime;

			// Token: 0x040000F7 RID: 247
			public long ftLastWriteTime;

			// Token: 0x040000F8 RID: 248
			public uint dwVolumeSerialNumber;

			// Token: 0x040000F9 RID: 249
			public uint nFileSizeHigh;

			// Token: 0x040000FA RID: 250
			public uint nFileSizeLow;

			// Token: 0x040000FB RID: 251
			public uint nNumberOfLinks;

			// Token: 0x040000FC RID: 252
			public uint nFileIndexHigh;

			// Token: 0x040000FD RID: 253
			public uint nFileIndexLow;
		}
	}
}
