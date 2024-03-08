using System.Diagnostics;
using System.Threading;

namespace Microsoft.VisualStudio.HostingProcess
{
	public sealed class EntryPoint
	{
		private EntryPoint()
		{
		}

		[DebuggerNonUserCode]
		public static void Main()
		{
			if (Synchronize.HostingProcessInitialized != null)
			{
				((EventWaitHandle)(object)Synchronize.HostingProcessInitialized).Set();
				if (Synchronize.StartRunningUsersAssembly != null && Synchronize.ShutdownProcessEvent != null && Synchronize.Shutdown != null)
				{
					WaitHandle[] waitHandles = new WaitHandle[2]
					{
						(WaitHandle)(object)Synchronize.StartRunningUsersAssembly,
						(WaitHandle)(object)Synchronize.ShutdownProcessEvent
					};
					WaitHandle.WaitAny(waitHandles);
					Synchronize.Shutdown.Invoke();
				}
			}
		}
	}
}
