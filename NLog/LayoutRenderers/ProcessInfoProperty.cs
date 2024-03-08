using System;

namespace NLog.LayoutRenderers
{
	/// <summary>
	/// Property of System.Diagnostics.Process to retrieve.
	/// </summary>
	// Token: 0x020000B9 RID: 185
	public enum ProcessInfoProperty
	{
		/// <summary>
		/// Base Priority.
		/// </summary>
		// Token: 0x0400015B RID: 347
		BasePriority,
		/// <summary>
		/// Exit Code.
		/// </summary>
		// Token: 0x0400015C RID: 348
		ExitCode,
		/// <summary>
		/// Exit Time.
		/// </summary>
		// Token: 0x0400015D RID: 349
		ExitTime,
		/// <summary>
		/// Process Handle.
		/// </summary>
		// Token: 0x0400015E RID: 350
		Handle,
		/// <summary>
		/// Handle Count.
		/// </summary>
		// Token: 0x0400015F RID: 351
		HandleCount,
		/// <summary>
		/// Whether process has exited.
		/// </summary>
		// Token: 0x04000160 RID: 352
		HasExited,
		/// <summary>
		/// Process ID.
		/// </summary>
		// Token: 0x04000161 RID: 353
		Id,
		/// <summary>
		/// Machine name.
		/// </summary>
		// Token: 0x04000162 RID: 354
		MachineName,
		/// <summary>
		/// Handle of the main window.
		/// </summary>
		// Token: 0x04000163 RID: 355
		MainWindowHandle,
		/// <summary>
		/// Title of the main window.
		/// </summary>
		// Token: 0x04000164 RID: 356
		MainWindowTitle,
		/// <summary>
		/// Maximum Working Set.
		/// </summary>
		// Token: 0x04000165 RID: 357
		MaxWorkingSet,
		/// <summary>
		/// Minimum Working Set.
		/// </summary>
		// Token: 0x04000166 RID: 358
		MinWorkingSet,
		/// <summary>
		/// Non-paged System Memory Size.
		/// </summary>
		// Token: 0x04000167 RID: 359
		NonPagedSystemMemorySize,
		/// <summary>
		/// Non-paged System Memory Size (64-bit).
		/// </summary>
		// Token: 0x04000168 RID: 360
		NonPagedSystemMemorySize64,
		/// <summary>
		/// Paged Memory Size.
		/// </summary>
		// Token: 0x04000169 RID: 361
		PagedMemorySize,
		/// <summary>
		/// Paged Memory Size (64-bit)..
		/// </summary>
		// Token: 0x0400016A RID: 362
		PagedMemorySize64,
		/// <summary>
		/// Paged System Memory Size.
		/// </summary>
		// Token: 0x0400016B RID: 363
		PagedSystemMemorySize,
		/// <summary>
		/// Paged System Memory Size (64-bit).
		/// </summary>
		// Token: 0x0400016C RID: 364
		PagedSystemMemorySize64,
		/// <summary>
		/// Peak Paged Memory Size.
		/// </summary>
		// Token: 0x0400016D RID: 365
		PeakPagedMemorySize,
		/// <summary>
		/// Peak Paged Memory Size (64-bit).
		/// </summary>
		// Token: 0x0400016E RID: 366
		PeakPagedMemorySize64,
		/// <summary>
		/// Peak Vitual Memory Size.
		/// </summary>
		// Token: 0x0400016F RID: 367
		PeakVirtualMemorySize,
		/// <summary>
		/// Peak Virtual Memory Size (64-bit)..
		/// </summary>
		// Token: 0x04000170 RID: 368
		PeakVirtualMemorySize64,
		/// <summary>
		/// Peak Working Set Size.
		/// </summary>
		// Token: 0x04000171 RID: 369
		PeakWorkingSet,
		/// <summary>
		/// Peak Working Set Size (64-bit).
		/// </summary>
		// Token: 0x04000172 RID: 370
		PeakWorkingSet64,
		/// <summary>
		/// Whether priority boost is enabled.
		/// </summary>
		// Token: 0x04000173 RID: 371
		PriorityBoostEnabled,
		/// <summary>
		/// Priority Class.
		/// </summary>
		// Token: 0x04000174 RID: 372
		PriorityClass,
		/// <summary>
		/// Private Memory Size.
		/// </summary>
		// Token: 0x04000175 RID: 373
		PrivateMemorySize,
		/// <summary>
		/// Private Memory Size (64-bit).
		/// </summary>
		// Token: 0x04000176 RID: 374
		PrivateMemorySize64,
		/// <summary>
		/// Privileged Processor Time.
		/// </summary>
		// Token: 0x04000177 RID: 375
		PrivilegedProcessorTime,
		/// <summary>
		/// Process Name.
		/// </summary>
		// Token: 0x04000178 RID: 376
		ProcessName,
		/// <summary>
		/// Whether process is responding.
		/// </summary>
		// Token: 0x04000179 RID: 377
		Responding,
		/// <summary>
		/// Session ID.
		/// </summary>
		// Token: 0x0400017A RID: 378
		SessionId,
		/// <summary>
		/// Process Start Time.
		/// </summary>
		// Token: 0x0400017B RID: 379
		StartTime,
		/// <summary>
		/// Total Processor Time.
		/// </summary>
		// Token: 0x0400017C RID: 380
		TotalProcessorTime,
		/// <summary>
		/// User Processor Time.
		/// </summary>
		// Token: 0x0400017D RID: 381
		UserProcessorTime,
		/// <summary>
		/// Virtual Memory Size.
		/// </summary>
		// Token: 0x0400017E RID: 382
		VirtualMemorySize,
		/// <summary>
		/// Virtual Memory Size (64-bit).
		/// </summary>
		// Token: 0x0400017F RID: 383
		VirtualMemorySize64,
		/// <summary>
		/// Working Set Size.
		/// </summary>
		// Token: 0x04000180 RID: 384
		WorkingSet,
		/// <summary>
		/// Working Set Size (64-bit).
		/// </summary>
		// Token: 0x04000181 RID: 385
		WorkingSet64
	}
}
