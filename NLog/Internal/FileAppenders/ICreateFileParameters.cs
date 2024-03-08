using System;
using NLog.Targets;

namespace NLog.Internal.FileAppenders
{
	/// <summary>
	/// Interface that provides parameters for create file function.
	/// </summary>
	// Token: 0x02000061 RID: 97
	internal interface ICreateFileParameters
	{
		// Token: 0x17000082 RID: 130
		// (get) Token: 0x06000282 RID: 642
		int ConcurrentWriteAttemptDelay { get; }

		// Token: 0x17000083 RID: 131
		// (get) Token: 0x06000283 RID: 643
		int ConcurrentWriteAttempts { get; }

		// Token: 0x17000084 RID: 132
		// (get) Token: 0x06000284 RID: 644
		bool ConcurrentWrites { get; }

		// Token: 0x17000085 RID: 133
		// (get) Token: 0x06000285 RID: 645
		bool CreateDirs { get; }

		// Token: 0x17000086 RID: 134
		// (get) Token: 0x06000286 RID: 646
		bool EnableFileDelete { get; }

		// Token: 0x17000087 RID: 135
		// (get) Token: 0x06000287 RID: 647
		int BufferSize { get; }

		// Token: 0x17000088 RID: 136
		// (get) Token: 0x06000288 RID: 648
		bool ForceManaged { get; }

		// Token: 0x17000089 RID: 137
		// (get) Token: 0x06000289 RID: 649
		Win32FileAttributes FileAttributes { get; }
	}
}
