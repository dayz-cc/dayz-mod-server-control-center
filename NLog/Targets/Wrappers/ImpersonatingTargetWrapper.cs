using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Principal;
using NLog.Common;
using NLog.Internal;

namespace NLog.Targets.Wrappers
{
	/// <summary>
	/// Impersonates another user for the duration of the write.
	/// </summary>
	/// <seealso href="http://nlog-project.org/wiki/ImpersonatingWrapper_target">Documentation on NLog Wiki</seealso>
	// Token: 0x02000138 RID: 312
	[Target("ImpersonatingWrapper", IsWrapper = true)]
	[SecuritySafeCritical]
	public class ImpersonatingTargetWrapper : WrapperTargetBase
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Targets.Wrappers.ImpersonatingTargetWrapper" /> class.
		/// </summary>
		// Token: 0x06000A4F RID: 2639 RVA: 0x000249DD File Offset: 0x00022BDD
		public ImpersonatingTargetWrapper()
			: this(null)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Targets.Wrappers.ImpersonatingTargetWrapper" /> class.
		/// </summary>
		/// <param name="wrappedTarget">The wrapped target.</param>
		// Token: 0x06000A50 RID: 2640 RVA: 0x000249EC File Offset: 0x00022BEC
		public ImpersonatingTargetWrapper(Target wrappedTarget)
		{
			this.Domain = ".";
			this.LogOnType = SecurityLogOnType.Interactive;
			this.LogOnProvider = LogOnProviderType.Default;
			this.ImpersonationLevel = SecurityImpersonationLevel.Impersonation;
			base.WrappedTarget = wrappedTarget;
		}

		/// <summary>
		/// Gets or sets username to change context to.
		/// </summary>
		/// <docgen category="Impersonation Options" order="10" />
		// Token: 0x17000235 RID: 565
		// (get) Token: 0x06000A51 RID: 2641 RVA: 0x00024A3C File Offset: 0x00022C3C
		// (set) Token: 0x06000A52 RID: 2642 RVA: 0x00024A53 File Offset: 0x00022C53
		public string UserName { get; set; }

		/// <summary>
		/// Gets or sets the user account password.
		/// </summary>
		/// <docgen category="Impersonation Options" order="10" />
		// Token: 0x17000236 RID: 566
		// (get) Token: 0x06000A53 RID: 2643 RVA: 0x00024A5C File Offset: 0x00022C5C
		// (set) Token: 0x06000A54 RID: 2644 RVA: 0x00024A73 File Offset: 0x00022C73
		public string Password { get; set; }

		/// <summary>
		/// Gets or sets Windows domain name to change context to.
		/// </summary>
		/// <docgen category="Impersonation Options" order="10" />
		// Token: 0x17000237 RID: 567
		// (get) Token: 0x06000A55 RID: 2645 RVA: 0x00024A7C File Offset: 0x00022C7C
		// (set) Token: 0x06000A56 RID: 2646 RVA: 0x00024A93 File Offset: 0x00022C93
		[DefaultValue(".")]
		public string Domain { get; set; }

		/// <summary>
		/// Gets or sets the Logon Type.
		/// </summary>
		/// <docgen category="Impersonation Options" order="10" />
		// Token: 0x17000238 RID: 568
		// (get) Token: 0x06000A57 RID: 2647 RVA: 0x00024A9C File Offset: 0x00022C9C
		// (set) Token: 0x06000A58 RID: 2648 RVA: 0x00024AB3 File Offset: 0x00022CB3
		public SecurityLogOnType LogOnType { get; set; }

		/// <summary>
		/// Gets or sets the type of the logon provider.
		/// </summary>
		/// <docgen category="Impersonation Options" order="10" />
		// Token: 0x17000239 RID: 569
		// (get) Token: 0x06000A59 RID: 2649 RVA: 0x00024ABC File Offset: 0x00022CBC
		// (set) Token: 0x06000A5A RID: 2650 RVA: 0x00024AD3 File Offset: 0x00022CD3
		public LogOnProviderType LogOnProvider { get; set; }

		/// <summary>
		/// Gets or sets the required impersonation level.
		/// </summary>
		/// <docgen category="Impersonation Options" order="10" />
		// Token: 0x1700023A RID: 570
		// (get) Token: 0x06000A5B RID: 2651 RVA: 0x00024ADC File Offset: 0x00022CDC
		// (set) Token: 0x06000A5C RID: 2652 RVA: 0x00024AF3 File Offset: 0x00022CF3
		public SecurityImpersonationLevel ImpersonationLevel { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether to revert to the credentials of the process instead of impersonating another user.
		/// </summary>
		/// <docgen category="Impersonation Options" order="10" />
		// Token: 0x1700023B RID: 571
		// (get) Token: 0x06000A5D RID: 2653 RVA: 0x00024AFC File Offset: 0x00022CFC
		// (set) Token: 0x06000A5E RID: 2654 RVA: 0x00024B13 File Offset: 0x00022D13
		[DefaultValue(false)]
		public bool RevertToSelf { get; set; }

		/// <summary>
		/// Initializes the impersonation context.
		/// </summary>
		// Token: 0x06000A5F RID: 2655 RVA: 0x00024B1C File Offset: 0x00022D1C
		protected override void InitializeTarget()
		{
			if (!this.RevertToSelf)
			{
				this.newIdentity = this.CreateWindowsIdentity(out this.duplicateTokenHandle);
			}
			using (this.DoImpersonate())
			{
				base.InitializeTarget();
			}
		}

		/// <summary>
		/// Closes the impersonation context.
		/// </summary>
		// Token: 0x06000A60 RID: 2656 RVA: 0x00024B7C File Offset: 0x00022D7C
		protected override void CloseTarget()
		{
			using (this.DoImpersonate())
			{
				base.CloseTarget();
			}
			if (this.duplicateTokenHandle != IntPtr.Zero)
			{
				NativeMethods.CloseHandle(this.duplicateTokenHandle);
				this.duplicateTokenHandle = IntPtr.Zero;
			}
			if (this.newIdentity != null)
			{
				this.newIdentity.Dispose();
				this.newIdentity = null;
			}
		}

		/// <summary>
		/// Changes the security context, forwards the call to the <see cref="P:NLog.Targets.Wrappers.WrapperTargetBase.WrappedTarget" />.Write()
		/// and switches the context back to original.
		/// </summary>
		/// <param name="logEvent">The log event.</param>
		// Token: 0x06000A61 RID: 2657 RVA: 0x00024C10 File Offset: 0x00022E10
		protected override void Write(AsyncLogEventInfo logEvent)
		{
			using (this.DoImpersonate())
			{
				base.WrappedTarget.WriteAsyncLogEvent(logEvent);
			}
		}

		/// <summary>
		/// Changes the security context, forwards the call to the <see cref="P:NLog.Targets.Wrappers.WrapperTargetBase.WrappedTarget" />.Write()
		/// and switches the context back to original.
		/// </summary>
		/// <param name="logEvents">Log events.</param>
		// Token: 0x06000A62 RID: 2658 RVA: 0x00024C58 File Offset: 0x00022E58
		protected override void Write(AsyncLogEventInfo[] logEvents)
		{
			using (this.DoImpersonate())
			{
				base.WrappedTarget.WriteAsyncLogEvents(logEvents);
			}
		}

		/// <summary>
		/// Flush any pending log messages (in case of asynchronous targets).
		/// </summary>
		/// <param name="asyncContinuation">The asynchronous continuation.</param>
		// Token: 0x06000A63 RID: 2659 RVA: 0x00024CA0 File Offset: 0x00022EA0
		protected override void FlushAsync(AsyncContinuation asyncContinuation)
		{
			using (this.DoImpersonate())
			{
				base.WrappedTarget.Flush(asyncContinuation);
			}
		}

		// Token: 0x06000A64 RID: 2660 RVA: 0x00024CE8 File Offset: 0x00022EE8
		private IDisposable DoImpersonate()
		{
			IDisposable disposable;
			if (this.RevertToSelf)
			{
				disposable = new ImpersonatingTargetWrapper.ContextReverter(WindowsIdentity.Impersonate(IntPtr.Zero));
			}
			else
			{
				disposable = new ImpersonatingTargetWrapper.ContextReverter(this.newIdentity.Impersonate());
			}
			return disposable;
		}

		// Token: 0x06000A65 RID: 2661 RVA: 0x00024D2C File Offset: 0x00022F2C
		private WindowsIdentity CreateWindowsIdentity(out IntPtr handle)
		{
			IntPtr intPtr;
			if (!NativeMethods.LogonUser(this.UserName, this.Domain, this.Password, (int)this.LogOnType, (int)this.LogOnProvider, out intPtr))
			{
				throw Marshal.GetExceptionForHR(Marshal.GetHRForLastWin32Error());
			}
			if (!NativeMethods.DuplicateToken(intPtr, (int)this.ImpersonationLevel, out handle))
			{
				NativeMethods.CloseHandle(intPtr);
				throw Marshal.GetExceptionForHR(Marshal.GetHRForLastWin32Error());
			}
			NativeMethods.CloseHandle(intPtr);
			return new WindowsIdentity(handle);
		}

		// Token: 0x0400035D RID: 861
		private WindowsIdentity newIdentity;

		// Token: 0x0400035E RID: 862
		private IntPtr duplicateTokenHandle = IntPtr.Zero;

		/// <summary>
		/// Helper class which reverts the given <see cref="T:System.Security.Principal.WindowsImpersonationContext" /> 
		/// to its original value as part of <see cref="M:System.IDisposable.Dispose" />.
		/// </summary>
		// Token: 0x02000139 RID: 313
		internal class ContextReverter : IDisposable
		{
			/// <summary>
			/// Initializes a new instance of the <see cref="T:NLog.Targets.Wrappers.ImpersonatingTargetWrapper.ContextReverter" /> class.
			/// </summary>
			/// <param name="windowsImpersonationContext">The windows impersonation context.</param>
			// Token: 0x06000A66 RID: 2662 RVA: 0x00024DA9 File Offset: 0x00022FA9
			public ContextReverter(WindowsImpersonationContext windowsImpersonationContext)
			{
				this.wic = windowsImpersonationContext;
			}

			/// <summary>
			/// Reverts the impersonation context.
			/// </summary>
			// Token: 0x06000A67 RID: 2663 RVA: 0x00024DBB File Offset: 0x00022FBB
			public void Dispose()
			{
				this.wic.Undo();
			}

			// Token: 0x04000366 RID: 870
			private WindowsImpersonationContext wic;
		}
	}
}
