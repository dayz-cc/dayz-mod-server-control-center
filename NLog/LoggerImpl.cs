using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Threading;
using NLog.Common;
using NLog.Config;
using NLog.Filters;
using NLog.Internal;
using NLog.Targets;

namespace NLog
{
	/// <summary>
	/// Implementation of logging engine.
	/// </summary>
	// Token: 0x020000E8 RID: 232
	internal static class LoggerImpl
	{
		// Token: 0x060006F6 RID: 1782 RVA: 0x00019120 File Offset: 0x00017320
		[SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", Justification = "Using 'NLog' in message.")]
		internal static void Write(Type loggerType, TargetWithFilterChain targets, LogEventInfo logEvent, LogFactory factory)
		{
			if (targets != null)
			{
				StackTraceUsage stackTraceUsage = targets.GetStackTraceUsage();
				if (stackTraceUsage != StackTraceUsage.None && !logEvent.HasStackTrace)
				{
					StackTrace stackTrace = new StackTrace(0, stackTraceUsage == StackTraceUsage.WithSource);
					int num = LoggerImpl.FindCallingMethodOnStackTrace(stackTrace, loggerType);
					logEvent.SetStackTrace(stackTrace, num);
				}
				int originalThreadId = Thread.CurrentThread.ManagedThreadId;
				AsyncContinuation asyncContinuation = delegate(Exception ex)
				{
					if (ex != null)
					{
						if (factory.ThrowExceptions && Thread.CurrentThread.ManagedThreadId == originalThreadId)
						{
							throw new NLogRuntimeException("Exception occurred in NLog", ex);
						}
					}
				};
				for (TargetWithFilterChain targetWithFilterChain = targets; targetWithFilterChain != null; targetWithFilterChain = targetWithFilterChain.NextInChain)
				{
					if (!LoggerImpl.WriteToTargetWithFilterChain(targetWithFilterChain, logEvent, asyncContinuation))
					{
						break;
					}
				}
			}
		}

		// Token: 0x060006F7 RID: 1783 RVA: 0x000191D8 File Offset: 0x000173D8
		private static int FindCallingMethodOnStackTrace(StackTrace stackTrace, Type loggerType)
		{
			int num = 0;
			for (int i = 0; i < stackTrace.FrameCount; i++)
			{
				StackFrame frame = stackTrace.GetFrame(i);
				MethodBase method = frame.GetMethod();
				Assembly assembly = null;
				if (method.DeclaringType != null)
				{
					assembly = method.DeclaringType.Assembly;
				}
				if ((loggerType == null && LoggerImpl.SkipAssembly(assembly)) || method.DeclaringType == loggerType)
				{
					num = i + 1;
				}
				else if (num != 0)
				{
					break;
				}
			}
			return num;
		}

		// Token: 0x060006F8 RID: 1784 RVA: 0x00019284 File Offset: 0x00017484
		private static bool SkipAssembly(Assembly assembly)
		{
			return assembly == LoggerImpl.nlogAssembly || assembly == LoggerImpl.mscorlibAssembly || assembly == LoggerImpl.systemAssembly;
		}

		// Token: 0x060006F9 RID: 1785 RVA: 0x000192DC File Offset: 0x000174DC
		private static bool WriteToTargetWithFilterChain(TargetWithFilterChain targetListHead, LogEventInfo logEvent, AsyncContinuation onException)
		{
			Target target = targetListHead.Target;
			FilterResult filterResult = LoggerImpl.GetFilterResult(targetListHead.FilterChain, logEvent);
			bool flag;
			if (filterResult == FilterResult.Ignore || filterResult == FilterResult.IgnoreFinal)
			{
				if (InternalLogger.IsDebugEnabled)
				{
					InternalLogger.Debug("{0}.{1} Rejecting message because of a filter.", new object[] { logEvent.LoggerName, logEvent.Level });
				}
				flag = filterResult != FilterResult.IgnoreFinal;
			}
			else
			{
				target.WriteAsyncLogEvent(logEvent.WithContinuation(onException));
				flag = filterResult != FilterResult.LogFinal;
			}
			return flag;
		}

		/// <summary>
		/// Gets the filter result.
		/// </summary>
		/// <param name="filterChain">The filter chain.</param>
		/// <param name="logEvent">The log event.</param>
		/// <returns>The result of the filter.</returns>
		// Token: 0x060006FA RID: 1786 RVA: 0x00019380 File Offset: 0x00017580
		private static FilterResult GetFilterResult(IEnumerable<Filter> filterChain, LogEventInfo logEvent)
		{
			FilterResult filterResult = FilterResult.Neutral;
			FilterResult filterResult2;
			try
			{
				foreach (Filter filter in filterChain)
				{
					filterResult = filter.GetFilterResult(logEvent);
					if (filterResult != FilterResult.Neutral)
					{
						break;
					}
				}
				filterResult2 = filterResult;
			}
			catch (Exception ex)
			{
				if (ex.MustBeRethrown())
				{
					throw;
				}
				InternalLogger.Warn("Exception during filter evaluation: {0}", new object[] { ex });
				filterResult2 = FilterResult.Ignore;
			}
			return filterResult2;
		}

		// Token: 0x04000209 RID: 521
		private const int StackTraceSkipMethods = 0;

		// Token: 0x0400020A RID: 522
		private static readonly Assembly nlogAssembly = typeof(LoggerImpl).Assembly;

		// Token: 0x0400020B RID: 523
		private static readonly Assembly mscorlibAssembly = typeof(string).Assembly;

		// Token: 0x0400020C RID: 524
		private static readonly Assembly systemAssembly = typeof(Debug).Assembly;
	}
}
