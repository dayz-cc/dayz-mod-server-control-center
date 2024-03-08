using System;
using System.Diagnostics;
using System.Threading;

namespace Microsoft.VisualStudio.HostingProcess
{
	// Token: 0x02000002 RID: 2
	public sealed class EntryPoint
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002150 File Offset: 0x00000350
		private EntryPoint()
		{
		}

		// Token: 0x06000002 RID: 2 RVA: 0x00002158 File Offset: 0x00000358
		[DebuggerNonUserCode]
		public static void Main()
		{
			if (Synchronize.HostingProcessInitialized != null)
			{
				Synchronize.HostingProcessInitialized.Set();
				if (Synchronize.StartRunningUsersAssembly != null && Synchronize.ShutdownProcessEvent != null && Synchronize.Shutdown != null)
				{
					WaitHandle[] array = new WaitHandle[]
					{
						Synchronize.StartRunningUsersAssembly,
						Synchronize.ShutdownProcessEvent
					};
					WaitHandle.WaitAny(array);
					Synchronize.Shutdown.Invoke();
				}
			}
		}
	}
}
