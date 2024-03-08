using System;
using System.Collections.Generic;
using System.Threading;
using NLog.Common;
using NLog.Config;
using NLog.Internal;
using NLog.Layouts;

namespace NLog.Targets
{
	/// <summary>
	/// Represents logging target.
	/// </summary>
	// Token: 0x020000FE RID: 254
	[NLogConfigurationItem]
	public abstract class Target : ISupportsInitialize, IDisposable
	{
		/// <summary>
		/// Gets or sets the name of the target.
		/// </summary>
		/// <docgen category="General Options" order="10" />
		// Token: 0x17000168 RID: 360
		// (get) Token: 0x060007B7 RID: 1975 RVA: 0x0001B1A4 File Offset: 0x000193A4
		// (set) Token: 0x060007B8 RID: 1976 RVA: 0x0001B1BB File Offset: 0x000193BB
		public string Name { get; set; }

		/// <summary>
		/// Gets the object which can be used to synchronize asynchronous operations that must rely on the .
		/// </summary>
		// Token: 0x17000169 RID: 361
		// (get) Token: 0x060007B9 RID: 1977 RVA: 0x0001B1C4 File Offset: 0x000193C4
		protected object SyncRoot
		{
			get
			{
				return this.lockObject;
			}
		}

		/// <summary>
		/// Gets the logging configuration this target is part of.
		/// </summary>
		// Token: 0x1700016A RID: 362
		// (get) Token: 0x060007BA RID: 1978 RVA: 0x0001B1DC File Offset: 0x000193DC
		// (set) Token: 0x060007BB RID: 1979 RVA: 0x0001B1F3 File Offset: 0x000193F3
		private protected LoggingConfiguration LoggingConfiguration { protected get; private set; }

		/// <summary>
		/// Gets a value indicating whether the target has been initialized.
		/// </summary>
		// Token: 0x1700016B RID: 363
		// (get) Token: 0x060007BC RID: 1980 RVA: 0x0001B1FC File Offset: 0x000193FC
		// (set) Token: 0x060007BD RID: 1981 RVA: 0x0001B213 File Offset: 0x00019413
		private protected bool IsInitialized { protected get; private set; }

		/// <summary>
		/// Initializes this instance.
		/// </summary>
		/// <param name="configuration">The configuration.</param>
		// Token: 0x060007BE RID: 1982 RVA: 0x0001B21C File Offset: 0x0001941C
		void ISupportsInitialize.Initialize(LoggingConfiguration configuration)
		{
			this.Initialize(configuration);
		}

		/// <summary>
		/// Closes this instance.
		/// </summary>
		// Token: 0x060007BF RID: 1983 RVA: 0x0001B227 File Offset: 0x00019427
		void ISupportsInitialize.Close()
		{
			this.Close();
		}

		/// <summary>
		/// Closes the target.
		/// </summary>
		// Token: 0x060007C0 RID: 1984 RVA: 0x0001B231 File Offset: 0x00019431
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// Flush any pending log messages (in case of asynchronous targets).
		/// </summary>
		/// <param name="asyncContinuation">The asynchronous continuation.</param>
		// Token: 0x060007C1 RID: 1985 RVA: 0x0001B244 File Offset: 0x00019444
		public void Flush(AsyncContinuation asyncContinuation)
		{
			if (asyncContinuation == null)
			{
				throw new ArgumentNullException("asyncContinuation");
			}
			lock (this.SyncRoot)
			{
				if (!this.IsInitialized)
				{
					asyncContinuation(null);
				}
				else
				{
					asyncContinuation = AsyncHelpers.PreventMultipleCalls(asyncContinuation);
					try
					{
						this.FlushAsync(asyncContinuation);
					}
					catch (Exception ex)
					{
						if (ex.MustBeRethrown())
						{
							throw;
						}
						asyncContinuation(ex);
					}
				}
			}
		}

		/// <summary>
		/// Calls the <see cref="M:NLog.Layouts.Layout.Precalculate(NLog.LogEventInfo)" /> on each volatile layout
		/// used by this target.
		/// </summary>
		/// <param name="logEvent">
		/// The log event.
		/// </param>
		// Token: 0x060007C2 RID: 1986 RVA: 0x0001B2F4 File Offset: 0x000194F4
		public void PrecalculateVolatileLayouts(LogEventInfo logEvent)
		{
			lock (this.SyncRoot)
			{
				if (this.IsInitialized)
				{
					foreach (Layout layout in this.allLayouts)
					{
						layout.Precalculate(logEvent);
					}
				}
			}
		}

		/// <summary>
		/// Returns a <see cref="T:System.String" /> that represents this instance.
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.String" /> that represents this instance.
		/// </returns>
		// Token: 0x060007C3 RID: 1987 RVA: 0x0001B394 File Offset: 0x00019594
		public override string ToString()
		{
			TargetAttribute targetAttribute = (TargetAttribute)Attribute.GetCustomAttribute(base.GetType(), typeof(TargetAttribute));
			string text;
			if (targetAttribute != null)
			{
				text = targetAttribute.Name + " Target[" + (this.Name ?? "(unnamed)") + "]";
			}
			else
			{
				text = base.GetType().Name;
			}
			return text;
		}

		/// <summary>
		/// Writes the log to the target.
		/// </summary>
		/// <param name="logEvent">Log event to write.</param>
		// Token: 0x060007C4 RID: 1988 RVA: 0x0001B3FC File Offset: 0x000195FC
		public void WriteAsyncLogEvent(AsyncLogEventInfo logEvent)
		{
			lock (this.SyncRoot)
			{
				if (!this.IsInitialized)
				{
					logEvent.Continuation(null);
				}
				else if (this.initializeException != null)
				{
					logEvent.Continuation(this.CreateInitException());
				}
				else
				{
					AsyncContinuation asyncContinuation = AsyncHelpers.PreventMultipleCalls(logEvent.Continuation);
					try
					{
						this.Write(logEvent.LogEvent.WithContinuation(asyncContinuation));
					}
					catch (Exception ex)
					{
						if (ex.MustBeRethrown())
						{
							throw;
						}
						if (LogManager.ThrowExceptions)
						{
							throw;
						}
						asyncContinuation(ex);
					}
				}
			}
		}

		/// <summary>
		/// Writes the array of log events.
		/// </summary>
		/// <param name="logEvents">The log events.</param>
		// Token: 0x060007C5 RID: 1989 RVA: 0x0001B4EC File Offset: 0x000196EC
		public void WriteAsyncLogEvents(params AsyncLogEventInfo[] logEvents)
		{
			if (logEvents != null)
			{
				lock (this.SyncRoot)
				{
					if (!this.IsInitialized)
					{
						foreach (AsyncLogEventInfo asyncLogEventInfo in logEvents)
						{
							asyncLogEventInfo.Continuation(null);
						}
					}
					else if (this.initializeException != null)
					{
						foreach (AsyncLogEventInfo asyncLogEventInfo in logEvents)
						{
							asyncLogEventInfo.Continuation(this.CreateInitException());
						}
					}
					else
					{
						AsyncLogEventInfo[] array = new AsyncLogEventInfo[logEvents.Length];
						for (int j = 0; j < logEvents.Length; j++)
						{
							array[j] = logEvents[j].LogEvent.WithContinuation(AsyncHelpers.PreventMultipleCalls(logEvents[j].Continuation));
						}
						try
						{
							this.Write(array);
						}
						catch (Exception ex)
						{
							if (ex.MustBeRethrown())
							{
								throw;
							}
							foreach (AsyncLogEventInfo asyncLogEventInfo in array)
							{
								asyncLogEventInfo.Continuation(ex);
							}
						}
					}
				}
			}
		}

		/// <summary>
		/// Initializes this instance.
		/// </summary>
		/// <param name="configuration">The configuration.</param>
		// Token: 0x060007C6 RID: 1990 RVA: 0x0001B6C0 File Offset: 0x000198C0
		internal void Initialize(LoggingConfiguration configuration)
		{
			lock (this.SyncRoot)
			{
				this.LoggingConfiguration = configuration;
				if (!this.IsInitialized)
				{
					PropertyHelper.CheckRequiredParameters(this);
					this.IsInitialized = true;
					try
					{
						this.InitializeTarget();
						this.initializeException = null;
					}
					catch (Exception ex)
					{
						if (ex.MustBeRethrown())
						{
							throw;
						}
						this.initializeException = ex;
						InternalLogger.Error("Error initializing target {0} {1}.", new object[] { this, ex });
						throw;
					}
				}
			}
		}

		/// <summary>
		/// Closes this instance.
		/// </summary>
		// Token: 0x060007C7 RID: 1991 RVA: 0x0001B784 File Offset: 0x00019984
		internal void Close()
		{
			lock (this.SyncRoot)
			{
				this.LoggingConfiguration = null;
				if (this.IsInitialized)
				{
					this.IsInitialized = false;
					try
					{
						if (this.initializeException == null)
						{
							this.CloseTarget();
						}
					}
					catch (Exception ex)
					{
						if (ex.MustBeRethrown())
						{
							throw;
						}
						InternalLogger.Error("Error closing target {0} {1}.", new object[] { this, ex });
						throw;
					}
				}
			}
		}

		// Token: 0x060007C8 RID: 1992 RVA: 0x0001B8AC File Offset: 0x00019AAC
		internal void WriteAsyncLogEvents(AsyncLogEventInfo[] logEventInfos, AsyncContinuation continuation)
		{
			if (logEventInfos.Length == 0)
			{
				continuation(null);
			}
			else
			{
				AsyncLogEventInfo[] array = new AsyncLogEventInfo[logEventInfos.Length];
				int remaining = logEventInfos.Length;
				for (int i = 0; i < logEventInfos.Length; i++)
				{
					AsyncContinuation originalContinuation = logEventInfos[i].Continuation;
					AsyncContinuation asyncContinuation = delegate(Exception ex)
					{
						originalContinuation(ex);
						if (0 == Interlocked.Decrement(ref remaining))
						{
							continuation(null);
						}
					};
					array[i] = logEventInfos[i].LogEvent.WithContinuation(asyncContinuation);
				}
				this.WriteAsyncLogEvents(array);
			}
		}

		/// <summary>
		/// Releases unmanaged and - optionally - managed resources.
		/// </summary>
		/// <param name="disposing">True to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
		// Token: 0x060007C9 RID: 1993 RVA: 0x0001B97C File Offset: 0x00019B7C
		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				this.CloseTarget();
			}
		}

		/// <summary>
		/// Initializes the target. Can be used by inheriting classes
		/// to initialize logging.
		/// </summary>
		// Token: 0x060007CA RID: 1994 RVA: 0x0001B99B File Offset: 0x00019B9B
		protected virtual void InitializeTarget()
		{
			this.GetAllLayouts();
		}

		/// <summary>
		/// Closes the target and releases any unmanaged resources.
		/// </summary>
		// Token: 0x060007CB RID: 1995 RVA: 0x0001B9A5 File Offset: 0x00019BA5
		protected virtual void CloseTarget()
		{
		}

		/// <summary>
		/// Flush any pending log messages asynchronously (in case of asynchronous targets).
		/// </summary>
		/// <param name="asyncContinuation">The asynchronous continuation.</param>
		// Token: 0x060007CC RID: 1996 RVA: 0x0001B9A8 File Offset: 0x00019BA8
		protected virtual void FlushAsync(AsyncContinuation asyncContinuation)
		{
			asyncContinuation(null);
		}

		/// <summary>
		/// Writes logging event to the log target.
		/// classes.
		/// </summary>
		/// <param name="logEvent">
		/// Logging event to be written out.
		/// </param>
		// Token: 0x060007CD RID: 1997 RVA: 0x0001B9B3 File Offset: 0x00019BB3
		protected virtual void Write(LogEventInfo logEvent)
		{
		}

		/// <summary>
		/// Writes log event to the log target. Must be overridden in inheriting
		/// classes.
		/// </summary>
		/// <param name="logEvent">Log event to be written out.</param>
		// Token: 0x060007CE RID: 1998 RVA: 0x0001B9B8 File Offset: 0x00019BB8
		protected virtual void Write(AsyncLogEventInfo logEvent)
		{
			try
			{
				this.Write(logEvent.LogEvent);
				logEvent.Continuation(null);
			}
			catch (Exception ex)
			{
				if (ex.MustBeRethrown())
				{
					throw;
				}
				logEvent.Continuation(ex);
			}
		}

		/// <summary>
		/// Writes an array of logging events to the log target. By default it iterates on all
		/// events and passes them to "Write" method. Inheriting classes can use this method to
		/// optimize batch writes.
		/// </summary>
		/// <param name="logEvents">Logging events to be written out.</param>
		// Token: 0x060007CF RID: 1999 RVA: 0x0001BA1C File Offset: 0x00019C1C
		protected virtual void Write(AsyncLogEventInfo[] logEvents)
		{
			for (int i = 0; i < logEvents.Length; i++)
			{
				this.Write(logEvents[i]);
			}
		}

		// Token: 0x060007D0 RID: 2000 RVA: 0x0001BA54 File Offset: 0x00019C54
		private Exception CreateInitException()
		{
			return new NLogRuntimeException("Target " + this + " failed to initialize.", this.initializeException);
		}

		// Token: 0x060007D1 RID: 2001 RVA: 0x0001BA84 File Offset: 0x00019C84
		private void GetAllLayouts()
		{
			this.allLayouts = new List<Layout>(ObjectGraphScanner.FindReachableObjects<Layout>(new object[] { this }));
			InternalLogger.Trace("{0} has {1} layouts", new object[]
			{
				this,
				this.allLayouts.Count
			});
		}

		// Token: 0x04000238 RID: 568
		private object lockObject = new object();

		// Token: 0x04000239 RID: 569
		private List<Layout> allLayouts;

		// Token: 0x0400023A RID: 570
		private Exception initializeException;
	}
}
