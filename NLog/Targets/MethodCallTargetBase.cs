using System;
using System.Collections.Generic;
using NLog.Common;
using NLog.Config;
using NLog.Internal;

namespace NLog.Targets
{
	/// <summary>
	/// The base class for all targets which call methods (local or remote). 
	/// Manages parameters and type coercion.
	/// </summary>
	// Token: 0x0200011C RID: 284
	public abstract class MethodCallTargetBase : Target
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Targets.MethodCallTargetBase" /> class.
		/// </summary>
		// Token: 0x0600096B RID: 2411 RVA: 0x00021B3A File Offset: 0x0001FD3A
		protected MethodCallTargetBase()
		{
			this.Parameters = new List<MethodCallParameter>();
		}

		/// <summary>
		/// Gets the array of parameters to be passed.
		/// </summary>
		/// <docgen category="Parameter Options" order="10" />
		// Token: 0x170001F4 RID: 500
		// (get) Token: 0x0600096C RID: 2412 RVA: 0x00021B54 File Offset: 0x0001FD54
		// (set) Token: 0x0600096D RID: 2413 RVA: 0x00021B6B File Offset: 0x0001FD6B
		[ArrayParameter(typeof(MethodCallParameter), "parameter")]
		public IList<MethodCallParameter> Parameters { get; private set; }

		/// <summary>
		/// Prepares an array of parameters to be passed based on the logging event and calls DoInvoke().
		/// </summary>
		/// <param name="logEvent">
		/// The logging event.
		/// </param>
		// Token: 0x0600096E RID: 2414 RVA: 0x00021B74 File Offset: 0x0001FD74
		protected override void Write(AsyncLogEventInfo logEvent)
		{
			object[] array = new object[this.Parameters.Count];
			int num = 0;
			foreach (MethodCallParameter methodCallParameter in this.Parameters)
			{
				array[num++] = methodCallParameter.GetValue(logEvent.LogEvent);
			}
			this.DoInvoke(array, logEvent.Continuation);
		}

		/// <summary>
		/// Calls the target method. Must be implemented in concrete classes.
		/// </summary>
		/// <param name="parameters">Method call parameters.</param>
		/// <param name="continuation">The continuation.</param>
		// Token: 0x0600096F RID: 2415 RVA: 0x00021C04 File Offset: 0x0001FE04
		protected virtual void DoInvoke(object[] parameters, AsyncContinuation continuation)
		{
			try
			{
				this.DoInvoke(parameters);
				continuation(null);
			}
			catch (Exception ex)
			{
				if (ex.MustBeRethrown())
				{
					throw;
				}
				continuation(ex);
			}
		}

		/// <summary>
		/// Calls the target method. Must be implemented in concrete classes.
		/// </summary>
		/// <param name="parameters">Method call parameters.</param>
		// Token: 0x06000970 RID: 2416
		protected abstract void DoInvoke(object[] parameters);
	}
}
