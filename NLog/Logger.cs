using System;
using System.ComponentModel;
using NLog.Internal;

namespace NLog
{
	/// <summary>
	/// Provides logging interface and utility functions.
	/// </summary>
	/// <content>
	/// Auto-generated Logger members for binary compatibility with NLog 1.0.
	/// </content>
	// Token: 0x020000E7 RID: 231
	[CLSCompliant(true)]
	public class Logger
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Logger" /> class.
		/// </summary>
		// Token: 0x060005B0 RID: 1456 RVA: 0x000147F4 File Offset: 0x000129F4
		protected internal Logger()
		{
		}

		/// <summary>
		/// Occurs when logger configuration changes.
		/// </summary>
		// Token: 0x14000008 RID: 8
		// (add) Token: 0x060005B1 RID: 1457 RVA: 0x00014810 File Offset: 0x00012A10
		// (remove) Token: 0x060005B2 RID: 1458 RVA: 0x0001484C File Offset: 0x00012A4C
		public event EventHandler<EventArgs> LoggerReconfigured;

		/// <summary>
		/// Gets the name of the logger.
		/// </summary>
		// Token: 0x17000142 RID: 322
		// (get) Token: 0x060005B3 RID: 1459 RVA: 0x00014888 File Offset: 0x00012A88
		// (set) Token: 0x060005B4 RID: 1460 RVA: 0x0001489F File Offset: 0x00012A9F
		public string Name { get; private set; }

		/// <summary>
		/// Gets the factory that created this logger.
		/// </summary>
		// Token: 0x17000143 RID: 323
		// (get) Token: 0x060005B5 RID: 1461 RVA: 0x000148A8 File Offset: 0x00012AA8
		// (set) Token: 0x060005B6 RID: 1462 RVA: 0x000148BF File Offset: 0x00012ABF
		public LogFactory Factory { get; private set; }

		/// <summary>
		/// Gets a value indicating whether logging is enabled for the <c>Trace</c> level.
		/// </summary>
		/// <returns>A value of <see langword="true" /> if logging is enabled for the <c>Trace</c> level, otherwise it returns <see langword="false" />.</returns>
		// Token: 0x17000144 RID: 324
		// (get) Token: 0x060005B7 RID: 1463 RVA: 0x000148C8 File Offset: 0x00012AC8
		public bool IsTraceEnabled
		{
			get
			{
				return this.isTraceEnabled;
			}
		}

		/// <summary>
		/// Gets a value indicating whether logging is enabled for the <c>Debug</c> level.
		/// </summary>
		/// <returns>A value of <see langword="true" /> if logging is enabled for the <c>Debug</c> level, otherwise it returns <see langword="false" />.</returns>
		// Token: 0x17000145 RID: 325
		// (get) Token: 0x060005B8 RID: 1464 RVA: 0x000148E4 File Offset: 0x00012AE4
		public bool IsDebugEnabled
		{
			get
			{
				return this.isDebugEnabled;
			}
		}

		/// <summary>
		/// Gets a value indicating whether logging is enabled for the <c>Info</c> level.
		/// </summary>
		/// <returns>A value of <see langword="true" /> if logging is enabled for the <c>Info</c> level, otherwise it returns <see langword="false" />.</returns>
		// Token: 0x17000146 RID: 326
		// (get) Token: 0x060005B9 RID: 1465 RVA: 0x00014900 File Offset: 0x00012B00
		public bool IsInfoEnabled
		{
			get
			{
				return this.isInfoEnabled;
			}
		}

		/// <summary>
		/// Gets a value indicating whether logging is enabled for the <c>Warn</c> level.
		/// </summary>
		/// <returns>A value of <see langword="true" /> if logging is enabled for the <c>Warn</c> level, otherwise it returns <see langword="false" />.</returns>
		// Token: 0x17000147 RID: 327
		// (get) Token: 0x060005BA RID: 1466 RVA: 0x0001491C File Offset: 0x00012B1C
		public bool IsWarnEnabled
		{
			get
			{
				return this.isWarnEnabled;
			}
		}

		/// <summary>
		/// Gets a value indicating whether logging is enabled for the <c>Error</c> level.
		/// </summary>
		/// <returns>A value of <see langword="true" /> if logging is enabled for the <c>Error</c> level, otherwise it returns <see langword="false" />.</returns>
		// Token: 0x17000148 RID: 328
		// (get) Token: 0x060005BB RID: 1467 RVA: 0x00014938 File Offset: 0x00012B38
		public bool IsErrorEnabled
		{
			get
			{
				return this.isErrorEnabled;
			}
		}

		/// <summary>
		/// Gets a value indicating whether logging is enabled for the <c>Fatal</c> level.
		/// </summary>
		/// <returns>A value of <see langword="true" /> if logging is enabled for the <c>Fatal</c> level, otherwise it returns <see langword="false" />.</returns>
		// Token: 0x17000149 RID: 329
		// (get) Token: 0x060005BC RID: 1468 RVA: 0x00014954 File Offset: 0x00012B54
		public bool IsFatalEnabled
		{
			get
			{
				return this.isFatalEnabled;
			}
		}

		/// <summary>
		/// Gets a value indicating whether logging is enabled for the specified level.
		/// </summary>
		/// <param name="level">Log level to be checked.</param>
		/// <returns>A value of <see langword="true" /> if logging is enabled for the specified level, otherwise it returns <see langword="false" />.</returns>
		// Token: 0x060005BD RID: 1469 RVA: 0x00014970 File Offset: 0x00012B70
		public bool IsEnabled(LogLevel level)
		{
			return this.GetTargetsForLevel(level) != null;
		}

		/// <summary>
		/// Writes the specified diagnostic message.
		/// </summary>
		/// <param name="logEvent">Log event.</param>
		// Token: 0x060005BE RID: 1470 RVA: 0x00014990 File Offset: 0x00012B90
		public void Log(LogEventInfo logEvent)
		{
			if (this.IsEnabled(logEvent.Level))
			{
				this.WriteToTargets(logEvent);
			}
		}

		/// <summary>
		/// Writes the specified diagnostic message.
		/// </summary>
		/// <param name="wrapperType">The name of the type that wraps Logger.</param>
		/// <param name="logEvent">Log event.</param>
		// Token: 0x060005BF RID: 1471 RVA: 0x000149BC File Offset: 0x00012BBC
		public void Log(Type wrapperType, LogEventInfo logEvent)
		{
			if (this.IsEnabled(logEvent.Level))
			{
				this.WriteToTargets(wrapperType, logEvent);
			}
		}

		/// <overloads>
		/// Writes the diagnostic message at the specified level using the specified format provider and format parameters.
		/// </overloads>
		/// <summary>
		/// Writes the diagnostic message at the specified level.
		/// </summary>
		/// <typeparam name="T">Type of the value.</typeparam>
		/// <param name="level">The log level.</param>
		/// <param name="value">The value to be written.</param>
		// Token: 0x060005C0 RID: 1472 RVA: 0x000149E8 File Offset: 0x00012BE8
		public void Log<T>(LogLevel level, T value)
		{
			if (this.IsEnabled(level))
			{
				this.WriteToTargets<T>(level, null, value);
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the specified level.
		/// </summary>
		/// <typeparam name="T">Type of the value.</typeparam>
		/// <param name="level">The log level.</param>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="value">The value to be written.</param>
		// Token: 0x060005C1 RID: 1473 RVA: 0x00014A10 File Offset: 0x00012C10
		public void Log<T>(LogLevel level, IFormatProvider formatProvider, T value)
		{
			if (this.IsEnabled(level))
			{
				this.WriteToTargets<T>(level, formatProvider, value);
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the specified level.
		/// </summary>
		/// <param name="level">The log level.</param>
		/// <param name="messageFunc">A function returning message to be written. Function is not evaluated if logging is not enabled.</param>
		// Token: 0x060005C2 RID: 1474 RVA: 0x00014A38 File Offset: 0x00012C38
		public void Log(LogLevel level, LogMessageGenerator messageFunc)
		{
			if (this.IsEnabled(level))
			{
				if (messageFunc == null)
				{
					throw new ArgumentNullException("messageFunc");
				}
				this.WriteToTargets<string>(level, null, messageFunc());
			}
		}

		/// <summary>
		/// Writes the diagnostic message and exception at the specified level.
		/// </summary>
		/// <param name="level">The log level.</param>
		/// <param name="message">A <see langword="string" /> to be written.</param>
		/// <param name="exception">An exception to be logged.</param>
		// Token: 0x060005C3 RID: 1475 RVA: 0x00014A7C File Offset: 0x00012C7C
		public void LogException(LogLevel level, [Localizable(false)] string message, Exception exception)
		{
			if (this.IsEnabled(level))
			{
				this.WriteToTargets(level, message, exception);
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the specified level using the specified parameters and formatting them with the supplied format provider.
		/// </summary>
		/// <param name="level">The log level.</param>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing format items.</param>
		/// <param name="args">Arguments to format.</param>
		// Token: 0x060005C4 RID: 1476 RVA: 0x00014AA4 File Offset: 0x00012CA4
		public void Log(LogLevel level, IFormatProvider formatProvider, [Localizable(false)] string message, params object[] args)
		{
			if (this.IsEnabled(level))
			{
				this.WriteToTargets(level, formatProvider, message, args);
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the specified level.
		/// </summary>
		/// <param name="level">The log level.</param>
		/// <param name="message">Log message.</param>
		// Token: 0x060005C5 RID: 1477 RVA: 0x00014AD0 File Offset: 0x00012CD0
		public void Log(LogLevel level, [Localizable(false)] string message)
		{
			if (this.IsEnabled(level))
			{
				this.WriteToTargets<string>(level, null, message);
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the specified level using the specified parameters.
		/// </summary>
		/// <param name="level">The log level.</param>
		/// <param name="message">A <see langword="string" /> containing format items.</param>
		/// <param name="args">Arguments to format.</param>
		// Token: 0x060005C6 RID: 1478 RVA: 0x00014AF8 File Offset: 0x00012CF8
		public void Log(LogLevel level, [Localizable(false)] string message, params object[] args)
		{
			if (this.IsEnabled(level))
			{
				this.WriteToTargets(level, message, args);
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the specified level using the specified parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <typeparam name="TArgument">The type of the argument.</typeparam>
		/// <param name="level">The log level.</param>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060005C7 RID: 1479 RVA: 0x00014B20 File Offset: 0x00012D20
		public void Log<TArgument>(LogLevel level, IFormatProvider formatProvider, [Localizable(false)] string message, TArgument argument)
		{
			if (this.IsEnabled(level))
			{
				this.WriteToTargets(level, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the specified level using the specified parameter.
		/// </summary>
		/// <typeparam name="TArgument">The type of the argument.</typeparam>
		/// <param name="level">The log level.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060005C8 RID: 1480 RVA: 0x00014B5C File Offset: 0x00012D5C
		public void Log<TArgument>(LogLevel level, [Localizable(false)] string message, TArgument argument)
		{
			if (this.IsEnabled(level))
			{
				this.WriteToTargets(level, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the specified level using the specified arguments formatting it with the supplied format provider.
		/// </summary>
		/// <typeparam name="TArgument1">The type of the first argument.</typeparam>
		/// <typeparam name="TArgument2">The type of the second argument.</typeparam>
		/// <param name="level">The log level.</param>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument1">The first argument to format.</param>
		/// <param name="argument2">The second argument to format.</param>
		// Token: 0x060005C9 RID: 1481 RVA: 0x00014B94 File Offset: 0x00012D94
		public void Log<TArgument1, TArgument2>(LogLevel level, IFormatProvider formatProvider, [Localizable(false)] string message, TArgument1 argument1, TArgument2 argument2)
		{
			if (this.IsEnabled(level))
			{
				this.WriteToTargets(level, formatProvider, message, new object[] { argument1, argument2 });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the specified level using the specified parameters.
		/// </summary>
		/// <typeparam name="TArgument1">The type of the first argument.</typeparam>
		/// <typeparam name="TArgument2">The type of the second argument.</typeparam>
		/// <param name="level">The log level.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument1">The first argument to format.</param>
		/// <param name="argument2">The second argument to format.</param>
		// Token: 0x060005CA RID: 1482 RVA: 0x00014BD8 File Offset: 0x00012DD8
		public void Log<TArgument1, TArgument2>(LogLevel level, [Localizable(false)] string message, TArgument1 argument1, TArgument2 argument2)
		{
			if (this.IsEnabled(level))
			{
				this.WriteToTargets(level, message, new object[] { argument1, argument2 });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the specified level using the specified arguments formatting it with the supplied format provider.
		/// </summary>
		/// <typeparam name="TArgument1">The type of the first argument.</typeparam>
		/// <typeparam name="TArgument2">The type of the second argument.</typeparam>
		/// <typeparam name="TArgument3">The type of the third argument.</typeparam>
		/// <param name="level">The log level.</param>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument1">The first argument to format.</param>
		/// <param name="argument2">The second argument to format.</param>
		/// <param name="argument3">The third argument to format.</param>
		// Token: 0x060005CB RID: 1483 RVA: 0x00014C1C File Offset: 0x00012E1C
		public void Log<TArgument1, TArgument2, TArgument3>(LogLevel level, IFormatProvider formatProvider, [Localizable(false)] string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
		{
			if (this.IsEnabled(level))
			{
				this.WriteToTargets(level, formatProvider, message, new object[] { argument1, argument2, argument3 });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the specified level using the specified parameters.
		/// </summary>
		/// <typeparam name="TArgument1">The type of the first argument.</typeparam>
		/// <typeparam name="TArgument2">The type of the second argument.</typeparam>
		/// <typeparam name="TArgument3">The type of the third argument.</typeparam>
		/// <param name="level">The log level.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument1">The first argument to format.</param>
		/// <param name="argument2">The second argument to format.</param>
		/// <param name="argument3">The third argument to format.</param>
		// Token: 0x060005CC RID: 1484 RVA: 0x00014C6C File Offset: 0x00012E6C
		public void Log<TArgument1, TArgument2, TArgument3>(LogLevel level, [Localizable(false)] string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
		{
			if (this.IsEnabled(level))
			{
				this.WriteToTargets(level, message, new object[] { argument1, argument2, argument3 });
			}
		}

		/// <overloads>
		/// Writes the diagnostic message at the <c>Trace</c> level using the specified format provider and format parameters.
		/// </overloads>
		/// <summary>
		/// Writes the diagnostic message at the <c>Trace</c> level.
		/// </summary>
		/// <typeparam name="T">Type of the value.</typeparam>
		/// <param name="value">The value to be written.</param>
		// Token: 0x060005CD RID: 1485 RVA: 0x00014CB8 File Offset: 0x00012EB8
		public void Trace<T>(T value)
		{
			if (this.IsTraceEnabled)
			{
				this.WriteToTargets<T>(LogLevel.Trace, null, value);
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Trace</c> level.
		/// </summary>
		/// <typeparam name="T">Type of the value.</typeparam>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="value">The value to be written.</param>
		// Token: 0x060005CE RID: 1486 RVA: 0x00014CE4 File Offset: 0x00012EE4
		public void Trace<T>(IFormatProvider formatProvider, T value)
		{
			if (this.IsTraceEnabled)
			{
				this.WriteToTargets<T>(LogLevel.Trace, formatProvider, value);
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Trace</c> level.
		/// </summary>
		/// <param name="messageFunc">A function returning message to be written. Function is not evaluated if logging is not enabled.</param>
		// Token: 0x060005CF RID: 1487 RVA: 0x00014D10 File Offset: 0x00012F10
		public void Trace(LogMessageGenerator messageFunc)
		{
			if (this.IsTraceEnabled)
			{
				if (messageFunc == null)
				{
					throw new ArgumentNullException("messageFunc");
				}
				this.WriteToTargets<string>(LogLevel.Trace, null, messageFunc());
			}
		}

		/// <summary>
		/// Writes the diagnostic message and exception at the <c>Trace</c> level.
		/// </summary>
		/// <param name="message">A <see langword="string" /> to be written.</param>
		/// <param name="exception">An exception to be logged.</param>
		// Token: 0x060005D0 RID: 1488 RVA: 0x00014D58 File Offset: 0x00012F58
		public void TraceException([Localizable(false)] string message, Exception exception)
		{
			if (this.IsTraceEnabled)
			{
				this.WriteToTargets(LogLevel.Trace, message, exception);
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Trace</c> level using the specified parameters and formatting them with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing format items.</param>
		/// <param name="args">Arguments to format.</param>
		// Token: 0x060005D1 RID: 1489 RVA: 0x00014D84 File Offset: 0x00012F84
		public void Trace(IFormatProvider formatProvider, [Localizable(false)] string message, params object[] args)
		{
			if (this.IsTraceEnabled)
			{
				this.WriteToTargets(LogLevel.Trace, formatProvider, message, args);
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Trace</c> level.
		/// </summary>
		/// <param name="message">Log message.</param>
		// Token: 0x060005D2 RID: 1490 RVA: 0x00014DB0 File Offset: 0x00012FB0
		public void Trace([Localizable(false)] string message)
		{
			if (this.IsTraceEnabled)
			{
				this.WriteToTargets<string>(LogLevel.Trace, null, message);
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Trace</c> level using the specified parameters.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing format items.</param>
		/// <param name="args">Arguments to format.</param>
		// Token: 0x060005D3 RID: 1491 RVA: 0x00014DDC File Offset: 0x00012FDC
		public void Trace([Localizable(false)] string message, params object[] args)
		{
			if (this.IsTraceEnabled)
			{
				this.WriteToTargets(LogLevel.Trace, message, args);
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Trace</c> level using the specified parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <typeparam name="TArgument">The type of the argument.</typeparam>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060005D4 RID: 1492 RVA: 0x00014E08 File Offset: 0x00013008
		public void Trace<TArgument>(IFormatProvider formatProvider, [Localizable(false)] string message, TArgument argument)
		{
			if (this.IsTraceEnabled)
			{
				this.WriteToTargets(LogLevel.Trace, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Trace</c> level using the specified parameter.
		/// </summary>
		/// <typeparam name="TArgument">The type of the argument.</typeparam>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060005D5 RID: 1493 RVA: 0x00014E44 File Offset: 0x00013044
		public void Trace<TArgument>([Localizable(false)] string message, TArgument argument)
		{
			if (this.IsTraceEnabled)
			{
				this.WriteToTargets(LogLevel.Trace, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Trace</c> level using the specified arguments formatting it with the supplied format provider.
		/// </summary>
		/// <typeparam name="TArgument1">The type of the first argument.</typeparam>
		/// <typeparam name="TArgument2">The type of the second argument.</typeparam>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument1">The first argument to format.</param>
		/// <param name="argument2">The second argument to format.</param>
		// Token: 0x060005D6 RID: 1494 RVA: 0x00014E80 File Offset: 0x00013080
		public void Trace<TArgument1, TArgument2>(IFormatProvider formatProvider, [Localizable(false)] string message, TArgument1 argument1, TArgument2 argument2)
		{
			if (this.IsTraceEnabled)
			{
				this.WriteToTargets(LogLevel.Trace, formatProvider, message, new object[] { argument1, argument2 });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Trace</c> level using the specified parameters.
		/// </summary>
		/// <typeparam name="TArgument1">The type of the first argument.</typeparam>
		/// <typeparam name="TArgument2">The type of the second argument.</typeparam>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument1">The first argument to format.</param>
		/// <param name="argument2">The second argument to format.</param>
		// Token: 0x060005D7 RID: 1495 RVA: 0x00014EC8 File Offset: 0x000130C8
		public void Trace<TArgument1, TArgument2>([Localizable(false)] string message, TArgument1 argument1, TArgument2 argument2)
		{
			if (this.IsTraceEnabled)
			{
				this.WriteToTargets(LogLevel.Trace, message, new object[] { argument1, argument2 });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Trace</c> level using the specified arguments formatting it with the supplied format provider.
		/// </summary>
		/// <typeparam name="TArgument1">The type of the first argument.</typeparam>
		/// <typeparam name="TArgument2">The type of the second argument.</typeparam>
		/// <typeparam name="TArgument3">The type of the third argument.</typeparam>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument1">The first argument to format.</param>
		/// <param name="argument2">The second argument to format.</param>
		/// <param name="argument3">The third argument to format.</param>
		// Token: 0x060005D8 RID: 1496 RVA: 0x00014F0C File Offset: 0x0001310C
		public void Trace<TArgument1, TArgument2, TArgument3>(IFormatProvider formatProvider, [Localizable(false)] string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
		{
			if (this.IsTraceEnabled)
			{
				this.WriteToTargets(LogLevel.Trace, formatProvider, message, new object[] { argument1, argument2, argument3 });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Trace</c> level using the specified parameters.
		/// </summary>
		/// <typeparam name="TArgument1">The type of the first argument.</typeparam>
		/// <typeparam name="TArgument2">The type of the second argument.</typeparam>
		/// <typeparam name="TArgument3">The type of the third argument.</typeparam>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument1">The first argument to format.</param>
		/// <param name="argument2">The second argument to format.</param>
		/// <param name="argument3">The third argument to format.</param>
		// Token: 0x060005D9 RID: 1497 RVA: 0x00014F5C File Offset: 0x0001315C
		public void Trace<TArgument1, TArgument2, TArgument3>([Localizable(false)] string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
		{
			if (this.IsTraceEnabled)
			{
				this.WriteToTargets(LogLevel.Trace, message, new object[] { argument1, argument2, argument3 });
			}
		}

		/// <overloads>
		/// Writes the diagnostic message at the <c>Debug</c> level using the specified format provider and format parameters.
		/// </overloads>
		/// <summary>
		/// Writes the diagnostic message at the <c>Debug</c> level.
		/// </summary>
		/// <typeparam name="T">Type of the value.</typeparam>
		/// <param name="value">The value to be written.</param>
		// Token: 0x060005DA RID: 1498 RVA: 0x00014FAC File Offset: 0x000131AC
		public void Debug<T>(T value)
		{
			if (this.IsDebugEnabled)
			{
				this.WriteToTargets<T>(LogLevel.Debug, null, value);
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Debug</c> level.
		/// </summary>
		/// <typeparam name="T">Type of the value.</typeparam>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="value">The value to be written.</param>
		// Token: 0x060005DB RID: 1499 RVA: 0x00014FD8 File Offset: 0x000131D8
		public void Debug<T>(IFormatProvider formatProvider, T value)
		{
			if (this.IsDebugEnabled)
			{
				this.WriteToTargets<T>(LogLevel.Debug, formatProvider, value);
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Debug</c> level.
		/// </summary>
		/// <param name="messageFunc">A function returning message to be written. Function is not evaluated if logging is not enabled.</param>
		// Token: 0x060005DC RID: 1500 RVA: 0x00015004 File Offset: 0x00013204
		public void Debug(LogMessageGenerator messageFunc)
		{
			if (this.IsDebugEnabled)
			{
				if (messageFunc == null)
				{
					throw new ArgumentNullException("messageFunc");
				}
				this.WriteToTargets<string>(LogLevel.Debug, null, messageFunc());
			}
		}

		/// <summary>
		/// Writes the diagnostic message and exception at the <c>Debug</c> level.
		/// </summary>
		/// <param name="message">A <see langword="string" /> to be written.</param>
		/// <param name="exception">An exception to be logged.</param>
		// Token: 0x060005DD RID: 1501 RVA: 0x0001504C File Offset: 0x0001324C
		public void DebugException([Localizable(false)] string message, Exception exception)
		{
			if (this.IsDebugEnabled)
			{
				this.WriteToTargets(LogLevel.Debug, message, exception);
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Debug</c> level using the specified parameters and formatting them with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing format items.</param>
		/// <param name="args">Arguments to format.</param>
		// Token: 0x060005DE RID: 1502 RVA: 0x00015078 File Offset: 0x00013278
		public void Debug(IFormatProvider formatProvider, [Localizable(false)] string message, params object[] args)
		{
			if (this.IsDebugEnabled)
			{
				this.WriteToTargets(LogLevel.Debug, formatProvider, message, args);
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Debug</c> level.
		/// </summary>
		/// <param name="message">Log message.</param>
		// Token: 0x060005DF RID: 1503 RVA: 0x000150A4 File Offset: 0x000132A4
		public void Debug([Localizable(false)] string message)
		{
			if (this.IsDebugEnabled)
			{
				this.WriteToTargets<string>(LogLevel.Debug, null, message);
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Debug</c> level using the specified parameters.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing format items.</param>
		/// <param name="args">Arguments to format.</param>
		// Token: 0x060005E0 RID: 1504 RVA: 0x000150D0 File Offset: 0x000132D0
		public void Debug([Localizable(false)] string message, params object[] args)
		{
			if (this.IsDebugEnabled)
			{
				this.WriteToTargets(LogLevel.Debug, message, args);
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Debug</c> level using the specified parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <typeparam name="TArgument">The type of the argument.</typeparam>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060005E1 RID: 1505 RVA: 0x000150FC File Offset: 0x000132FC
		public void Debug<TArgument>(IFormatProvider formatProvider, [Localizable(false)] string message, TArgument argument)
		{
			if (this.IsDebugEnabled)
			{
				this.WriteToTargets(LogLevel.Debug, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Debug</c> level using the specified parameter.
		/// </summary>
		/// <typeparam name="TArgument">The type of the argument.</typeparam>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060005E2 RID: 1506 RVA: 0x00015138 File Offset: 0x00013338
		public void Debug<TArgument>([Localizable(false)] string message, TArgument argument)
		{
			if (this.IsDebugEnabled)
			{
				this.WriteToTargets(LogLevel.Debug, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Debug</c> level using the specified arguments formatting it with the supplied format provider.
		/// </summary>
		/// <typeparam name="TArgument1">The type of the first argument.</typeparam>
		/// <typeparam name="TArgument2">The type of the second argument.</typeparam>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument1">The first argument to format.</param>
		/// <param name="argument2">The second argument to format.</param>
		// Token: 0x060005E3 RID: 1507 RVA: 0x00015174 File Offset: 0x00013374
		public void Debug<TArgument1, TArgument2>(IFormatProvider formatProvider, [Localizable(false)] string message, TArgument1 argument1, TArgument2 argument2)
		{
			if (this.IsDebugEnabled)
			{
				this.WriteToTargets(LogLevel.Debug, formatProvider, message, new object[] { argument1, argument2 });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Debug</c> level using the specified parameters.
		/// </summary>
		/// <typeparam name="TArgument1">The type of the first argument.</typeparam>
		/// <typeparam name="TArgument2">The type of the second argument.</typeparam>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument1">The first argument to format.</param>
		/// <param name="argument2">The second argument to format.</param>
		// Token: 0x060005E4 RID: 1508 RVA: 0x000151BC File Offset: 0x000133BC
		public void Debug<TArgument1, TArgument2>([Localizable(false)] string message, TArgument1 argument1, TArgument2 argument2)
		{
			if (this.IsDebugEnabled)
			{
				this.WriteToTargets(LogLevel.Debug, message, new object[] { argument1, argument2 });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Debug</c> level using the specified arguments formatting it with the supplied format provider.
		/// </summary>
		/// <typeparam name="TArgument1">The type of the first argument.</typeparam>
		/// <typeparam name="TArgument2">The type of the second argument.</typeparam>
		/// <typeparam name="TArgument3">The type of the third argument.</typeparam>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument1">The first argument to format.</param>
		/// <param name="argument2">The second argument to format.</param>
		/// <param name="argument3">The third argument to format.</param>
		// Token: 0x060005E5 RID: 1509 RVA: 0x00015200 File Offset: 0x00013400
		public void Debug<TArgument1, TArgument2, TArgument3>(IFormatProvider formatProvider, [Localizable(false)] string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
		{
			if (this.IsDebugEnabled)
			{
				this.WriteToTargets(LogLevel.Debug, formatProvider, message, new object[] { argument1, argument2, argument3 });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Debug</c> level using the specified parameters.
		/// </summary>
		/// <typeparam name="TArgument1">The type of the first argument.</typeparam>
		/// <typeparam name="TArgument2">The type of the second argument.</typeparam>
		/// <typeparam name="TArgument3">The type of the third argument.</typeparam>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument1">The first argument to format.</param>
		/// <param name="argument2">The second argument to format.</param>
		/// <param name="argument3">The third argument to format.</param>
		// Token: 0x060005E6 RID: 1510 RVA: 0x00015250 File Offset: 0x00013450
		public void Debug<TArgument1, TArgument2, TArgument3>([Localizable(false)] string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
		{
			if (this.IsDebugEnabled)
			{
				this.WriteToTargets(LogLevel.Debug, message, new object[] { argument1, argument2, argument3 });
			}
		}

		/// <overloads>
		/// Writes the diagnostic message at the <c>Info</c> level using the specified format provider and format parameters.
		/// </overloads>
		/// <summary>
		/// Writes the diagnostic message at the <c>Info</c> level.
		/// </summary>
		/// <typeparam name="T">Type of the value.</typeparam>
		/// <param name="value">The value to be written.</param>
		// Token: 0x060005E7 RID: 1511 RVA: 0x000152A0 File Offset: 0x000134A0
		public void Info<T>(T value)
		{
			if (this.IsInfoEnabled)
			{
				this.WriteToTargets<T>(LogLevel.Info, null, value);
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Info</c> level.
		/// </summary>
		/// <typeparam name="T">Type of the value.</typeparam>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="value">The value to be written.</param>
		// Token: 0x060005E8 RID: 1512 RVA: 0x000152CC File Offset: 0x000134CC
		public void Info<T>(IFormatProvider formatProvider, T value)
		{
			if (this.IsInfoEnabled)
			{
				this.WriteToTargets<T>(LogLevel.Info, formatProvider, value);
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Info</c> level.
		/// </summary>
		/// <param name="messageFunc">A function returning message to be written. Function is not evaluated if logging is not enabled.</param>
		// Token: 0x060005E9 RID: 1513 RVA: 0x000152F8 File Offset: 0x000134F8
		public void Info(LogMessageGenerator messageFunc)
		{
			if (this.IsInfoEnabled)
			{
				if (messageFunc == null)
				{
					throw new ArgumentNullException("messageFunc");
				}
				this.WriteToTargets<string>(LogLevel.Info, null, messageFunc());
			}
		}

		/// <summary>
		/// Writes the diagnostic message and exception at the <c>Info</c> level.
		/// </summary>
		/// <param name="message">A <see langword="string" /> to be written.</param>
		/// <param name="exception">An exception to be logged.</param>
		// Token: 0x060005EA RID: 1514 RVA: 0x00015340 File Offset: 0x00013540
		public void InfoException([Localizable(false)] string message, Exception exception)
		{
			if (this.IsInfoEnabled)
			{
				this.WriteToTargets(LogLevel.Info, message, exception);
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Info</c> level using the specified parameters and formatting them with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing format items.</param>
		/// <param name="args">Arguments to format.</param>
		// Token: 0x060005EB RID: 1515 RVA: 0x0001536C File Offset: 0x0001356C
		public void Info(IFormatProvider formatProvider, [Localizable(false)] string message, params object[] args)
		{
			if (this.IsInfoEnabled)
			{
				this.WriteToTargets(LogLevel.Info, formatProvider, message, args);
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Info</c> level.
		/// </summary>
		/// <param name="message">Log message.</param>
		// Token: 0x060005EC RID: 1516 RVA: 0x00015398 File Offset: 0x00013598
		public void Info([Localizable(false)] string message)
		{
			if (this.IsInfoEnabled)
			{
				this.WriteToTargets<string>(LogLevel.Info, null, message);
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Info</c> level using the specified parameters.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing format items.</param>
		/// <param name="args">Arguments to format.</param>
		// Token: 0x060005ED RID: 1517 RVA: 0x000153C4 File Offset: 0x000135C4
		public void Info([Localizable(false)] string message, params object[] args)
		{
			if (this.IsInfoEnabled)
			{
				this.WriteToTargets(LogLevel.Info, message, args);
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Info</c> level using the specified parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <typeparam name="TArgument">The type of the argument.</typeparam>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060005EE RID: 1518 RVA: 0x000153F0 File Offset: 0x000135F0
		public void Info<TArgument>(IFormatProvider formatProvider, [Localizable(false)] string message, TArgument argument)
		{
			if (this.IsInfoEnabled)
			{
				this.WriteToTargets(LogLevel.Info, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Info</c> level using the specified parameter.
		/// </summary>
		/// <typeparam name="TArgument">The type of the argument.</typeparam>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060005EF RID: 1519 RVA: 0x0001542C File Offset: 0x0001362C
		public void Info<TArgument>([Localizable(false)] string message, TArgument argument)
		{
			if (this.IsInfoEnabled)
			{
				this.WriteToTargets(LogLevel.Info, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Info</c> level using the specified arguments formatting it with the supplied format provider.
		/// </summary>
		/// <typeparam name="TArgument1">The type of the first argument.</typeparam>
		/// <typeparam name="TArgument2">The type of the second argument.</typeparam>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument1">The first argument to format.</param>
		/// <param name="argument2">The second argument to format.</param>
		// Token: 0x060005F0 RID: 1520 RVA: 0x00015468 File Offset: 0x00013668
		public void Info<TArgument1, TArgument2>(IFormatProvider formatProvider, [Localizable(false)] string message, TArgument1 argument1, TArgument2 argument2)
		{
			if (this.IsInfoEnabled)
			{
				this.WriteToTargets(LogLevel.Info, formatProvider, message, new object[] { argument1, argument2 });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Info</c> level using the specified parameters.
		/// </summary>
		/// <typeparam name="TArgument1">The type of the first argument.</typeparam>
		/// <typeparam name="TArgument2">The type of the second argument.</typeparam>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument1">The first argument to format.</param>
		/// <param name="argument2">The second argument to format.</param>
		// Token: 0x060005F1 RID: 1521 RVA: 0x000154B0 File Offset: 0x000136B0
		public void Info<TArgument1, TArgument2>([Localizable(false)] string message, TArgument1 argument1, TArgument2 argument2)
		{
			if (this.IsInfoEnabled)
			{
				this.WriteToTargets(LogLevel.Info, message, new object[] { argument1, argument2 });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Info</c> level using the specified arguments formatting it with the supplied format provider.
		/// </summary>
		/// <typeparam name="TArgument1">The type of the first argument.</typeparam>
		/// <typeparam name="TArgument2">The type of the second argument.</typeparam>
		/// <typeparam name="TArgument3">The type of the third argument.</typeparam>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument1">The first argument to format.</param>
		/// <param name="argument2">The second argument to format.</param>
		/// <param name="argument3">The third argument to format.</param>
		// Token: 0x060005F2 RID: 1522 RVA: 0x000154F4 File Offset: 0x000136F4
		public void Info<TArgument1, TArgument2, TArgument3>(IFormatProvider formatProvider, [Localizable(false)] string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
		{
			if (this.IsInfoEnabled)
			{
				this.WriteToTargets(LogLevel.Info, formatProvider, message, new object[] { argument1, argument2, argument3 });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Info</c> level using the specified parameters.
		/// </summary>
		/// <typeparam name="TArgument1">The type of the first argument.</typeparam>
		/// <typeparam name="TArgument2">The type of the second argument.</typeparam>
		/// <typeparam name="TArgument3">The type of the third argument.</typeparam>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument1">The first argument to format.</param>
		/// <param name="argument2">The second argument to format.</param>
		/// <param name="argument3">The third argument to format.</param>
		// Token: 0x060005F3 RID: 1523 RVA: 0x00015544 File Offset: 0x00013744
		public void Info<TArgument1, TArgument2, TArgument3>([Localizable(false)] string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
		{
			if (this.IsInfoEnabled)
			{
				this.WriteToTargets(LogLevel.Info, message, new object[] { argument1, argument2, argument3 });
			}
		}

		/// <overloads>
		/// Writes the diagnostic message at the <c>Warn</c> level using the specified format provider and format parameters.
		/// </overloads>
		/// <summary>
		/// Writes the diagnostic message at the <c>Warn</c> level.
		/// </summary>
		/// <typeparam name="T">Type of the value.</typeparam>
		/// <param name="value">The value to be written.</param>
		// Token: 0x060005F4 RID: 1524 RVA: 0x00015594 File Offset: 0x00013794
		public void Warn<T>(T value)
		{
			if (this.IsWarnEnabled)
			{
				this.WriteToTargets<T>(LogLevel.Warn, null, value);
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Warn</c> level.
		/// </summary>
		/// <typeparam name="T">Type of the value.</typeparam>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="value">The value to be written.</param>
		// Token: 0x060005F5 RID: 1525 RVA: 0x000155C0 File Offset: 0x000137C0
		public void Warn<T>(IFormatProvider formatProvider, T value)
		{
			if (this.IsWarnEnabled)
			{
				this.WriteToTargets<T>(LogLevel.Warn, formatProvider, value);
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Warn</c> level.
		/// </summary>
		/// <param name="messageFunc">A function returning message to be written. Function is not evaluated if logging is not enabled.</param>
		// Token: 0x060005F6 RID: 1526 RVA: 0x000155EC File Offset: 0x000137EC
		public void Warn(LogMessageGenerator messageFunc)
		{
			if (this.IsWarnEnabled)
			{
				if (messageFunc == null)
				{
					throw new ArgumentNullException("messageFunc");
				}
				this.WriteToTargets<string>(LogLevel.Warn, null, messageFunc());
			}
		}

		/// <summary>
		/// Writes the diagnostic message and exception at the <c>Warn</c> level.
		/// </summary>
		/// <param name="message">A <see langword="string" /> to be written.</param>
		/// <param name="exception">An exception to be logged.</param>
		// Token: 0x060005F7 RID: 1527 RVA: 0x00015634 File Offset: 0x00013834
		public void WarnException([Localizable(false)] string message, Exception exception)
		{
			if (this.IsWarnEnabled)
			{
				this.WriteToTargets(LogLevel.Warn, message, exception);
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Warn</c> level using the specified parameters and formatting them with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing format items.</param>
		/// <param name="args">Arguments to format.</param>
		// Token: 0x060005F8 RID: 1528 RVA: 0x00015660 File Offset: 0x00013860
		public void Warn(IFormatProvider formatProvider, [Localizable(false)] string message, params object[] args)
		{
			if (this.IsWarnEnabled)
			{
				this.WriteToTargets(LogLevel.Warn, formatProvider, message, args);
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Warn</c> level.
		/// </summary>
		/// <param name="message">Log message.</param>
		// Token: 0x060005F9 RID: 1529 RVA: 0x0001568C File Offset: 0x0001388C
		public void Warn([Localizable(false)] string message)
		{
			if (this.IsWarnEnabled)
			{
				this.WriteToTargets<string>(LogLevel.Warn, null, message);
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Warn</c> level using the specified parameters.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing format items.</param>
		/// <param name="args">Arguments to format.</param>
		// Token: 0x060005FA RID: 1530 RVA: 0x000156B8 File Offset: 0x000138B8
		public void Warn([Localizable(false)] string message, params object[] args)
		{
			if (this.IsWarnEnabled)
			{
				this.WriteToTargets(LogLevel.Warn, message, args);
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Warn</c> level using the specified parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <typeparam name="TArgument">The type of the argument.</typeparam>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060005FB RID: 1531 RVA: 0x000156E4 File Offset: 0x000138E4
		public void Warn<TArgument>(IFormatProvider formatProvider, [Localizable(false)] string message, TArgument argument)
		{
			if (this.IsWarnEnabled)
			{
				this.WriteToTargets(LogLevel.Warn, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Warn</c> level using the specified parameter.
		/// </summary>
		/// <typeparam name="TArgument">The type of the argument.</typeparam>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060005FC RID: 1532 RVA: 0x00015720 File Offset: 0x00013920
		public void Warn<TArgument>([Localizable(false)] string message, TArgument argument)
		{
			if (this.IsWarnEnabled)
			{
				this.WriteToTargets(LogLevel.Warn, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Warn</c> level using the specified arguments formatting it with the supplied format provider.
		/// </summary>
		/// <typeparam name="TArgument1">The type of the first argument.</typeparam>
		/// <typeparam name="TArgument2">The type of the second argument.</typeparam>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument1">The first argument to format.</param>
		/// <param name="argument2">The second argument to format.</param>
		// Token: 0x060005FD RID: 1533 RVA: 0x0001575C File Offset: 0x0001395C
		public void Warn<TArgument1, TArgument2>(IFormatProvider formatProvider, [Localizable(false)] string message, TArgument1 argument1, TArgument2 argument2)
		{
			if (this.IsWarnEnabled)
			{
				this.WriteToTargets(LogLevel.Warn, formatProvider, message, new object[] { argument1, argument2 });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Warn</c> level using the specified parameters.
		/// </summary>
		/// <typeparam name="TArgument1">The type of the first argument.</typeparam>
		/// <typeparam name="TArgument2">The type of the second argument.</typeparam>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument1">The first argument to format.</param>
		/// <param name="argument2">The second argument to format.</param>
		// Token: 0x060005FE RID: 1534 RVA: 0x000157A4 File Offset: 0x000139A4
		public void Warn<TArgument1, TArgument2>([Localizable(false)] string message, TArgument1 argument1, TArgument2 argument2)
		{
			if (this.IsWarnEnabled)
			{
				this.WriteToTargets(LogLevel.Warn, message, new object[] { argument1, argument2 });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Warn</c> level using the specified arguments formatting it with the supplied format provider.
		/// </summary>
		/// <typeparam name="TArgument1">The type of the first argument.</typeparam>
		/// <typeparam name="TArgument2">The type of the second argument.</typeparam>
		/// <typeparam name="TArgument3">The type of the third argument.</typeparam>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument1">The first argument to format.</param>
		/// <param name="argument2">The second argument to format.</param>
		/// <param name="argument3">The third argument to format.</param>
		// Token: 0x060005FF RID: 1535 RVA: 0x000157E8 File Offset: 0x000139E8
		public void Warn<TArgument1, TArgument2, TArgument3>(IFormatProvider formatProvider, [Localizable(false)] string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
		{
			if (this.IsWarnEnabled)
			{
				this.WriteToTargets(LogLevel.Warn, formatProvider, message, new object[] { argument1, argument2, argument3 });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Warn</c> level using the specified parameters.
		/// </summary>
		/// <typeparam name="TArgument1">The type of the first argument.</typeparam>
		/// <typeparam name="TArgument2">The type of the second argument.</typeparam>
		/// <typeparam name="TArgument3">The type of the third argument.</typeparam>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument1">The first argument to format.</param>
		/// <param name="argument2">The second argument to format.</param>
		/// <param name="argument3">The third argument to format.</param>
		// Token: 0x06000600 RID: 1536 RVA: 0x00015838 File Offset: 0x00013A38
		public void Warn<TArgument1, TArgument2, TArgument3>([Localizable(false)] string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
		{
			if (this.IsWarnEnabled)
			{
				this.WriteToTargets(LogLevel.Warn, message, new object[] { argument1, argument2, argument3 });
			}
		}

		/// <overloads>
		/// Writes the diagnostic message at the <c>Error</c> level using the specified format provider and format parameters.
		/// </overloads>
		/// <summary>
		/// Writes the diagnostic message at the <c>Error</c> level.
		/// </summary>
		/// <typeparam name="T">Type of the value.</typeparam>
		/// <param name="value">The value to be written.</param>
		// Token: 0x06000601 RID: 1537 RVA: 0x00015888 File Offset: 0x00013A88
		public void Error<T>(T value)
		{
			if (this.IsErrorEnabled)
			{
				this.WriteToTargets<T>(LogLevel.Error, null, value);
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Error</c> level.
		/// </summary>
		/// <typeparam name="T">Type of the value.</typeparam>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="value">The value to be written.</param>
		// Token: 0x06000602 RID: 1538 RVA: 0x000158B4 File Offset: 0x00013AB4
		public void Error<T>(IFormatProvider formatProvider, T value)
		{
			if (this.IsErrorEnabled)
			{
				this.WriteToTargets<T>(LogLevel.Error, formatProvider, value);
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Error</c> level.
		/// </summary>
		/// <param name="messageFunc">A function returning message to be written. Function is not evaluated if logging is not enabled.</param>
		// Token: 0x06000603 RID: 1539 RVA: 0x000158E0 File Offset: 0x00013AE0
		public void Error(LogMessageGenerator messageFunc)
		{
			if (this.IsErrorEnabled)
			{
				if (messageFunc == null)
				{
					throw new ArgumentNullException("messageFunc");
				}
				this.WriteToTargets<string>(LogLevel.Error, null, messageFunc());
			}
		}

		/// <summary>
		/// Writes the diagnostic message and exception at the <c>Error</c> level.
		/// </summary>
		/// <param name="message">A <see langword="string" /> to be written.</param>
		/// <param name="exception">An exception to be logged.</param>
		// Token: 0x06000604 RID: 1540 RVA: 0x00015928 File Offset: 0x00013B28
		public void ErrorException([Localizable(false)] string message, Exception exception)
		{
			if (this.IsErrorEnabled)
			{
				this.WriteToTargets(LogLevel.Error, message, exception);
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Error</c> level using the specified parameters and formatting them with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing format items.</param>
		/// <param name="args">Arguments to format.</param>
		// Token: 0x06000605 RID: 1541 RVA: 0x00015954 File Offset: 0x00013B54
		public void Error(IFormatProvider formatProvider, [Localizable(false)] string message, params object[] args)
		{
			if (this.IsErrorEnabled)
			{
				this.WriteToTargets(LogLevel.Error, formatProvider, message, args);
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Error</c> level.
		/// </summary>
		/// <param name="message">Log message.</param>
		// Token: 0x06000606 RID: 1542 RVA: 0x00015980 File Offset: 0x00013B80
		public void Error([Localizable(false)] string message)
		{
			if (this.IsErrorEnabled)
			{
				this.WriteToTargets<string>(LogLevel.Error, null, message);
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Error</c> level using the specified parameters.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing format items.</param>
		/// <param name="args">Arguments to format.</param>
		// Token: 0x06000607 RID: 1543 RVA: 0x000159AC File Offset: 0x00013BAC
		public void Error([Localizable(false)] string message, params object[] args)
		{
			if (this.IsErrorEnabled)
			{
				this.WriteToTargets(LogLevel.Error, message, args);
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Error</c> level using the specified parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <typeparam name="TArgument">The type of the argument.</typeparam>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x06000608 RID: 1544 RVA: 0x000159D8 File Offset: 0x00013BD8
		public void Error<TArgument>(IFormatProvider formatProvider, [Localizable(false)] string message, TArgument argument)
		{
			if (this.IsErrorEnabled)
			{
				this.WriteToTargets(LogLevel.Error, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Error</c> level using the specified parameter.
		/// </summary>
		/// <typeparam name="TArgument">The type of the argument.</typeparam>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x06000609 RID: 1545 RVA: 0x00015A14 File Offset: 0x00013C14
		public void Error<TArgument>([Localizable(false)] string message, TArgument argument)
		{
			if (this.IsErrorEnabled)
			{
				this.WriteToTargets(LogLevel.Error, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Error</c> level using the specified arguments formatting it with the supplied format provider.
		/// </summary>
		/// <typeparam name="TArgument1">The type of the first argument.</typeparam>
		/// <typeparam name="TArgument2">The type of the second argument.</typeparam>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument1">The first argument to format.</param>
		/// <param name="argument2">The second argument to format.</param>
		// Token: 0x0600060A RID: 1546 RVA: 0x00015A50 File Offset: 0x00013C50
		public void Error<TArgument1, TArgument2>(IFormatProvider formatProvider, [Localizable(false)] string message, TArgument1 argument1, TArgument2 argument2)
		{
			if (this.IsErrorEnabled)
			{
				this.WriteToTargets(LogLevel.Error, formatProvider, message, new object[] { argument1, argument2 });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Error</c> level using the specified parameters.
		/// </summary>
		/// <typeparam name="TArgument1">The type of the first argument.</typeparam>
		/// <typeparam name="TArgument2">The type of the second argument.</typeparam>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument1">The first argument to format.</param>
		/// <param name="argument2">The second argument to format.</param>
		// Token: 0x0600060B RID: 1547 RVA: 0x00015A98 File Offset: 0x00013C98
		public void Error<TArgument1, TArgument2>([Localizable(false)] string message, TArgument1 argument1, TArgument2 argument2)
		{
			if (this.IsErrorEnabled)
			{
				this.WriteToTargets(LogLevel.Error, message, new object[] { argument1, argument2 });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Error</c> level using the specified arguments formatting it with the supplied format provider.
		/// </summary>
		/// <typeparam name="TArgument1">The type of the first argument.</typeparam>
		/// <typeparam name="TArgument2">The type of the second argument.</typeparam>
		/// <typeparam name="TArgument3">The type of the third argument.</typeparam>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument1">The first argument to format.</param>
		/// <param name="argument2">The second argument to format.</param>
		/// <param name="argument3">The third argument to format.</param>
		// Token: 0x0600060C RID: 1548 RVA: 0x00015ADC File Offset: 0x00013CDC
		public void Error<TArgument1, TArgument2, TArgument3>(IFormatProvider formatProvider, [Localizable(false)] string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
		{
			if (this.IsErrorEnabled)
			{
				this.WriteToTargets(LogLevel.Error, formatProvider, message, new object[] { argument1, argument2, argument3 });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Error</c> level using the specified parameters.
		/// </summary>
		/// <typeparam name="TArgument1">The type of the first argument.</typeparam>
		/// <typeparam name="TArgument2">The type of the second argument.</typeparam>
		/// <typeparam name="TArgument3">The type of the third argument.</typeparam>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument1">The first argument to format.</param>
		/// <param name="argument2">The second argument to format.</param>
		/// <param name="argument3">The third argument to format.</param>
		// Token: 0x0600060D RID: 1549 RVA: 0x00015B2C File Offset: 0x00013D2C
		public void Error<TArgument1, TArgument2, TArgument3>([Localizable(false)] string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
		{
			if (this.IsErrorEnabled)
			{
				this.WriteToTargets(LogLevel.Error, message, new object[] { argument1, argument2, argument3 });
			}
		}

		/// <overloads>
		/// Writes the diagnostic message at the <c>Fatal</c> level using the specified format provider and format parameters.
		/// </overloads>
		/// <summary>
		/// Writes the diagnostic message at the <c>Fatal</c> level.
		/// </summary>
		/// <typeparam name="T">Type of the value.</typeparam>
		/// <param name="value">The value to be written.</param>
		// Token: 0x0600060E RID: 1550 RVA: 0x00015B7C File Offset: 0x00013D7C
		public void Fatal<T>(T value)
		{
			if (this.IsFatalEnabled)
			{
				this.WriteToTargets<T>(LogLevel.Fatal, null, value);
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Fatal</c> level.
		/// </summary>
		/// <typeparam name="T">Type of the value.</typeparam>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="value">The value to be written.</param>
		// Token: 0x0600060F RID: 1551 RVA: 0x00015BA8 File Offset: 0x00013DA8
		public void Fatal<T>(IFormatProvider formatProvider, T value)
		{
			if (this.IsFatalEnabled)
			{
				this.WriteToTargets<T>(LogLevel.Fatal, formatProvider, value);
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Fatal</c> level.
		/// </summary>
		/// <param name="messageFunc">A function returning message to be written. Function is not evaluated if logging is not enabled.</param>
		// Token: 0x06000610 RID: 1552 RVA: 0x00015BD4 File Offset: 0x00013DD4
		public void Fatal(LogMessageGenerator messageFunc)
		{
			if (this.IsFatalEnabled)
			{
				if (messageFunc == null)
				{
					throw new ArgumentNullException("messageFunc");
				}
				this.WriteToTargets<string>(LogLevel.Fatal, null, messageFunc());
			}
		}

		/// <summary>
		/// Writes the diagnostic message and exception at the <c>Fatal</c> level.
		/// </summary>
		/// <param name="message">A <see langword="string" /> to be written.</param>
		/// <param name="exception">An exception to be logged.</param>
		// Token: 0x06000611 RID: 1553 RVA: 0x00015C1C File Offset: 0x00013E1C
		public void FatalException([Localizable(false)] string message, Exception exception)
		{
			if (this.IsFatalEnabled)
			{
				this.WriteToTargets(LogLevel.Fatal, message, exception);
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Fatal</c> level using the specified parameters and formatting them with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing format items.</param>
		/// <param name="args">Arguments to format.</param>
		// Token: 0x06000612 RID: 1554 RVA: 0x00015C48 File Offset: 0x00013E48
		public void Fatal(IFormatProvider formatProvider, [Localizable(false)] string message, params object[] args)
		{
			if (this.IsFatalEnabled)
			{
				this.WriteToTargets(LogLevel.Fatal, formatProvider, message, args);
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Fatal</c> level.
		/// </summary>
		/// <param name="message">Log message.</param>
		// Token: 0x06000613 RID: 1555 RVA: 0x00015C74 File Offset: 0x00013E74
		public void Fatal([Localizable(false)] string message)
		{
			if (this.IsFatalEnabled)
			{
				this.WriteToTargets<string>(LogLevel.Fatal, null, message);
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Fatal</c> level using the specified parameters.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing format items.</param>
		/// <param name="args">Arguments to format.</param>
		// Token: 0x06000614 RID: 1556 RVA: 0x00015CA0 File Offset: 0x00013EA0
		public void Fatal([Localizable(false)] string message, params object[] args)
		{
			if (this.IsFatalEnabled)
			{
				this.WriteToTargets(LogLevel.Fatal, message, args);
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Fatal</c> level using the specified parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <typeparam name="TArgument">The type of the argument.</typeparam>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x06000615 RID: 1557 RVA: 0x00015CCC File Offset: 0x00013ECC
		public void Fatal<TArgument>(IFormatProvider formatProvider, [Localizable(false)] string message, TArgument argument)
		{
			if (this.IsFatalEnabled)
			{
				this.WriteToTargets(LogLevel.Fatal, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Fatal</c> level using the specified parameter.
		/// </summary>
		/// <typeparam name="TArgument">The type of the argument.</typeparam>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x06000616 RID: 1558 RVA: 0x00015D08 File Offset: 0x00013F08
		public void Fatal<TArgument>([Localizable(false)] string message, TArgument argument)
		{
			if (this.IsFatalEnabled)
			{
				this.WriteToTargets(LogLevel.Fatal, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Fatal</c> level using the specified arguments formatting it with the supplied format provider.
		/// </summary>
		/// <typeparam name="TArgument1">The type of the first argument.</typeparam>
		/// <typeparam name="TArgument2">The type of the second argument.</typeparam>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument1">The first argument to format.</param>
		/// <param name="argument2">The second argument to format.</param>
		// Token: 0x06000617 RID: 1559 RVA: 0x00015D44 File Offset: 0x00013F44
		public void Fatal<TArgument1, TArgument2>(IFormatProvider formatProvider, [Localizable(false)] string message, TArgument1 argument1, TArgument2 argument2)
		{
			if (this.IsFatalEnabled)
			{
				this.WriteToTargets(LogLevel.Fatal, formatProvider, message, new object[] { argument1, argument2 });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Fatal</c> level using the specified parameters.
		/// </summary>
		/// <typeparam name="TArgument1">The type of the first argument.</typeparam>
		/// <typeparam name="TArgument2">The type of the second argument.</typeparam>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument1">The first argument to format.</param>
		/// <param name="argument2">The second argument to format.</param>
		// Token: 0x06000618 RID: 1560 RVA: 0x00015D8C File Offset: 0x00013F8C
		public void Fatal<TArgument1, TArgument2>([Localizable(false)] string message, TArgument1 argument1, TArgument2 argument2)
		{
			if (this.IsFatalEnabled)
			{
				this.WriteToTargets(LogLevel.Fatal, message, new object[] { argument1, argument2 });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Fatal</c> level using the specified arguments formatting it with the supplied format provider.
		/// </summary>
		/// <typeparam name="TArgument1">The type of the first argument.</typeparam>
		/// <typeparam name="TArgument2">The type of the second argument.</typeparam>
		/// <typeparam name="TArgument3">The type of the third argument.</typeparam>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument1">The first argument to format.</param>
		/// <param name="argument2">The second argument to format.</param>
		/// <param name="argument3">The third argument to format.</param>
		// Token: 0x06000619 RID: 1561 RVA: 0x00015DD0 File Offset: 0x00013FD0
		public void Fatal<TArgument1, TArgument2, TArgument3>(IFormatProvider formatProvider, [Localizable(false)] string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
		{
			if (this.IsFatalEnabled)
			{
				this.WriteToTargets(LogLevel.Fatal, formatProvider, message, new object[] { argument1, argument2, argument3 });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Fatal</c> level using the specified parameters.
		/// </summary>
		/// <typeparam name="TArgument1">The type of the first argument.</typeparam>
		/// <typeparam name="TArgument2">The type of the second argument.</typeparam>
		/// <typeparam name="TArgument3">The type of the third argument.</typeparam>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument1">The first argument to format.</param>
		/// <param name="argument2">The second argument to format.</param>
		/// <param name="argument3">The third argument to format.</param>
		// Token: 0x0600061A RID: 1562 RVA: 0x00015E20 File Offset: 0x00014020
		public void Fatal<TArgument1, TArgument2, TArgument3>([Localizable(false)] string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3)
		{
			if (this.IsFatalEnabled)
			{
				this.WriteToTargets(LogLevel.Fatal, message, new object[] { argument1, argument2, argument3 });
			}
		}

		// Token: 0x0600061B RID: 1563 RVA: 0x00015E6E File Offset: 0x0001406E
		internal void Initialize(string name, LoggerConfiguration loggerConfiguration, LogFactory factory)
		{
			this.Name = name;
			this.Factory = factory;
			this.SetConfiguration(loggerConfiguration);
		}

		// Token: 0x0600061C RID: 1564 RVA: 0x00015E89 File Offset: 0x00014089
		internal void WriteToTargets(LogLevel level, IFormatProvider formatProvider, [Localizable(false)] string message, object[] args)
		{
			LoggerImpl.Write(this.loggerType, this.GetTargetsForLevel(level), LogEventInfo.Create(level, this.Name, formatProvider, message, args), this.Factory);
		}

		// Token: 0x0600061D RID: 1565 RVA: 0x00015EB5 File Offset: 0x000140B5
		internal void WriteToTargets<T>(LogLevel level, IFormatProvider formatProvider, T value)
		{
			LoggerImpl.Write(this.loggerType, this.GetTargetsForLevel(level), LogEventInfo.Create(level, this.Name, formatProvider, value), this.Factory);
		}

		// Token: 0x0600061E RID: 1566 RVA: 0x00015EE4 File Offset: 0x000140E4
		internal void WriteToTargets(LogLevel level, [Localizable(false)] string message, Exception ex)
		{
			LoggerImpl.Write(this.loggerType, this.GetTargetsForLevel(level), LogEventInfo.Create(level, this.Name, message, ex), this.Factory);
		}

		// Token: 0x0600061F RID: 1567 RVA: 0x00015F0E File Offset: 0x0001410E
		internal void WriteToTargets(LogLevel level, [Localizable(false)] string message, object[] args)
		{
			this.WriteToTargets(level, null, message, args);
		}

		// Token: 0x06000620 RID: 1568 RVA: 0x00015F1C File Offset: 0x0001411C
		internal void WriteToTargets(LogEventInfo logEvent)
		{
			LoggerImpl.Write(this.loggerType, this.GetTargetsForLevel(logEvent.Level), logEvent, this.Factory);
		}

		// Token: 0x06000621 RID: 1569 RVA: 0x00015F3E File Offset: 0x0001413E
		internal void WriteToTargets(Type wrapperType, LogEventInfo logEvent)
		{
			LoggerImpl.Write(wrapperType, this.GetTargetsForLevel(logEvent.Level), logEvent, this.Factory);
		}

		// Token: 0x06000622 RID: 1570 RVA: 0x00015F5C File Offset: 0x0001415C
		internal void SetConfiguration(LoggerConfiguration newConfiguration)
		{
			this.configuration = newConfiguration;
			this.isTraceEnabled = newConfiguration.IsEnabled(LogLevel.Trace);
			this.isDebugEnabled = newConfiguration.IsEnabled(LogLevel.Debug);
			this.isInfoEnabled = newConfiguration.IsEnabled(LogLevel.Info);
			this.isWarnEnabled = newConfiguration.IsEnabled(LogLevel.Warn);
			this.isErrorEnabled = newConfiguration.IsEnabled(LogLevel.Error);
			this.isFatalEnabled = newConfiguration.IsEnabled(LogLevel.Fatal);
			EventHandler<EventArgs> loggerReconfigured = this.LoggerReconfigured;
			if (loggerReconfigured != null)
			{
				loggerReconfigured(this, new EventArgs());
			}
		}

		// Token: 0x06000623 RID: 1571 RVA: 0x00016004 File Offset: 0x00014204
		private TargetWithFilterChain GetTargetsForLevel(LogLevel level)
		{
			return this.configuration.GetTargetsForLevel(level);
		}

		/// <summary>
		/// Writes the diagnostic message at the specified level.
		/// </summary>
		/// <param name="level">The log level.</param>
		/// <param name="value">A <see langword="object" /> to be written.</param>
		// Token: 0x06000624 RID: 1572 RVA: 0x00016024 File Offset: 0x00014224
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Log(LogLevel level, object value)
		{
			if (this.IsEnabled(level))
			{
				this.WriteToTargets(level, "{0}", new object[] { value });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the specified level.
		/// </summary>
		/// <param name="level">The log level.</param>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="value">A <see langword="object" /> to be written.</param>
		// Token: 0x06000625 RID: 1573 RVA: 0x0001605C File Offset: 0x0001425C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Log(LogLevel level, IFormatProvider formatProvider, object value)
		{
			if (this.IsEnabled(level))
			{
				this.WriteToTargets(level, formatProvider, "{0}", new object[] { value });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the specified level using the specified parameters.
		/// </summary>
		/// <param name="level">The log level.</param>
		/// <param name="message">A <see langword="string" /> containing format items.</param>
		/// <param name="arg1">First argument to format.</param>
		/// <param name="arg2">Second argument to format.</param>
		// Token: 0x06000626 RID: 1574 RVA: 0x00016094 File Offset: 0x00014294
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Log(LogLevel level, string message, object arg1, object arg2)
		{
			if (this.IsEnabled(level))
			{
				this.WriteToTargets(level, message, new object[] { arg1, arg2 });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the specified level using the specified parameters.
		/// </summary>
		/// <param name="level">The log level.</param>
		/// <param name="message">A <see langword="string" /> containing format items.</param>
		/// <param name="arg1">First argument to format.</param>
		/// <param name="arg2">Second argument to format.</param>
		/// <param name="arg3">Third argument to format.</param>
		// Token: 0x06000627 RID: 1575 RVA: 0x000160CC File Offset: 0x000142CC
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Log(LogLevel level, string message, object arg1, object arg2, object arg3)
		{
			if (this.IsEnabled(level))
			{
				this.WriteToTargets(level, message, new object[] { arg1, arg2, arg3 });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the specified level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="level">The log level.</param>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x06000628 RID: 1576 RVA: 0x0001610C File Offset: 0x0001430C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Log(LogLevel level, IFormatProvider formatProvider, string message, bool argument)
		{
			if (this.IsEnabled(level))
			{
				this.WriteToTargets(level, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the specified level using the specified value as a parameter.
		/// </summary>
		/// <param name="level">The log level.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x06000629 RID: 1577 RVA: 0x00016148 File Offset: 0x00014348
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Log(LogLevel level, string message, bool argument)
		{
			if (this.IsEnabled(level))
			{
				this.WriteToTargets(level, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the specified level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="level">The log level.</param>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x0600062A RID: 1578 RVA: 0x00016180 File Offset: 0x00014380
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Log(LogLevel level, IFormatProvider formatProvider, string message, char argument)
		{
			if (this.IsEnabled(level))
			{
				this.WriteToTargets(level, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the specified level using the specified value as a parameter.
		/// </summary>
		/// <param name="level">The log level.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x0600062B RID: 1579 RVA: 0x000161BC File Offset: 0x000143BC
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Log(LogLevel level, string message, char argument)
		{
			if (this.IsEnabled(level))
			{
				this.WriteToTargets(level, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the specified level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="level">The log level.</param>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x0600062C RID: 1580 RVA: 0x000161F4 File Offset: 0x000143F4
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Log(LogLevel level, IFormatProvider formatProvider, string message, byte argument)
		{
			if (this.IsEnabled(level))
			{
				this.WriteToTargets(level, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the specified level using the specified value as a parameter.
		/// </summary>
		/// <param name="level">The log level.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x0600062D RID: 1581 RVA: 0x00016230 File Offset: 0x00014430
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Log(LogLevel level, string message, byte argument)
		{
			if (this.IsEnabled(level))
			{
				this.WriteToTargets(level, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the specified level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="level">The log level.</param>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x0600062E RID: 1582 RVA: 0x00016268 File Offset: 0x00014468
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Log(LogLevel level, IFormatProvider formatProvider, string message, string argument)
		{
			if (this.IsEnabled(level))
			{
				this.WriteToTargets(level, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the specified level using the specified value as a parameter.
		/// </summary>
		/// <param name="level">The log level.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x0600062F RID: 1583 RVA: 0x000162A0 File Offset: 0x000144A0
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Log(LogLevel level, string message, string argument)
		{
			if (this.IsEnabled(level))
			{
				this.WriteToTargets(level, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the specified level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="level">The log level.</param>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x06000630 RID: 1584 RVA: 0x000162D4 File Offset: 0x000144D4
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Log(LogLevel level, IFormatProvider formatProvider, string message, int argument)
		{
			if (this.IsEnabled(level))
			{
				this.WriteToTargets(level, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the specified level using the specified value as a parameter.
		/// </summary>
		/// <param name="level">The log level.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x06000631 RID: 1585 RVA: 0x00016310 File Offset: 0x00014510
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Log(LogLevel level, string message, int argument)
		{
			if (this.IsEnabled(level))
			{
				this.WriteToTargets(level, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the specified level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="level">The log level.</param>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x06000632 RID: 1586 RVA: 0x00016348 File Offset: 0x00014548
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Log(LogLevel level, IFormatProvider formatProvider, string message, long argument)
		{
			if (this.IsEnabled(level))
			{
				this.WriteToTargets(level, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the specified level using the specified value as a parameter.
		/// </summary>
		/// <param name="level">The log level.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x06000633 RID: 1587 RVA: 0x00016384 File Offset: 0x00014584
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Log(LogLevel level, string message, long argument)
		{
			if (this.IsEnabled(level))
			{
				this.WriteToTargets(level, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the specified level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="level">The log level.</param>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x06000634 RID: 1588 RVA: 0x000163BC File Offset: 0x000145BC
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Log(LogLevel level, IFormatProvider formatProvider, string message, float argument)
		{
			if (this.IsEnabled(level))
			{
				this.WriteToTargets(level, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the specified level using the specified value as a parameter.
		/// </summary>
		/// <param name="level">The log level.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x06000635 RID: 1589 RVA: 0x000163F8 File Offset: 0x000145F8
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Log(LogLevel level, string message, float argument)
		{
			if (this.IsEnabled(level))
			{
				this.WriteToTargets(level, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the specified level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="level">The log level.</param>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x06000636 RID: 1590 RVA: 0x00016430 File Offset: 0x00014630
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Log(LogLevel level, IFormatProvider formatProvider, string message, double argument)
		{
			if (this.IsEnabled(level))
			{
				this.WriteToTargets(level, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the specified level using the specified value as a parameter.
		/// </summary>
		/// <param name="level">The log level.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x06000637 RID: 1591 RVA: 0x0001646C File Offset: 0x0001466C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Log(LogLevel level, string message, double argument)
		{
			if (this.IsEnabled(level))
			{
				this.WriteToTargets(level, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the specified level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="level">The log level.</param>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x06000638 RID: 1592 RVA: 0x000164A4 File Offset: 0x000146A4
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Log(LogLevel level, IFormatProvider formatProvider, string message, decimal argument)
		{
			if (this.IsEnabled(level))
			{
				this.WriteToTargets(level, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the specified level using the specified value as a parameter.
		/// </summary>
		/// <param name="level">The log level.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x06000639 RID: 1593 RVA: 0x000164E0 File Offset: 0x000146E0
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Log(LogLevel level, string message, decimal argument)
		{
			if (this.IsEnabled(level))
			{
				this.WriteToTargets(level, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the specified level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="level">The log level.</param>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x0600063A RID: 1594 RVA: 0x00016518 File Offset: 0x00014718
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Log(LogLevel level, IFormatProvider formatProvider, string message, object argument)
		{
			if (this.IsEnabled(level))
			{
				this.WriteToTargets(level, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the specified level using the specified value as a parameter.
		/// </summary>
		/// <param name="level">The log level.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x0600063B RID: 1595 RVA: 0x00016550 File Offset: 0x00014750
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Log(LogLevel level, string message, object argument)
		{
			if (this.IsEnabled(level))
			{
				this.WriteToTargets(level, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the specified level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="level">The log level.</param>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x0600063C RID: 1596 RVA: 0x00016584 File Offset: 0x00014784
		[CLSCompliant(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Log(LogLevel level, IFormatProvider formatProvider, string message, sbyte argument)
		{
			if (this.IsEnabled(level))
			{
				this.WriteToTargets(level, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the specified level using the specified value as a parameter.
		/// </summary>
		/// <param name="level">The log level.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x0600063D RID: 1597 RVA: 0x000165C0 File Offset: 0x000147C0
		[EditorBrowsable(EditorBrowsableState.Never)]
		[CLSCompliant(false)]
		public void Log(LogLevel level, string message, sbyte argument)
		{
			if (this.IsEnabled(level))
			{
				this.WriteToTargets(level, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the specified level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="level">The log level.</param>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x0600063E RID: 1598 RVA: 0x000165F8 File Offset: 0x000147F8
		[CLSCompliant(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Log(LogLevel level, IFormatProvider formatProvider, string message, uint argument)
		{
			if (this.IsEnabled(level))
			{
				this.WriteToTargets(level, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the specified level using the specified value as a parameter.
		/// </summary>
		/// <param name="level">The log level.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x0600063F RID: 1599 RVA: 0x00016634 File Offset: 0x00014834
		[EditorBrowsable(EditorBrowsableState.Never)]
		[CLSCompliant(false)]
		public void Log(LogLevel level, string message, uint argument)
		{
			if (this.IsEnabled(level))
			{
				this.WriteToTargets(level, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the specified level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="level">The log level.</param>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x06000640 RID: 1600 RVA: 0x0001666C File Offset: 0x0001486C
		[CLSCompliant(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Log(LogLevel level, IFormatProvider formatProvider, string message, ulong argument)
		{
			if (this.IsEnabled(level))
			{
				this.WriteToTargets(level, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the specified level using the specified value as a parameter.
		/// </summary>
		/// <param name="level">The log level.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x06000641 RID: 1601 RVA: 0x000166A8 File Offset: 0x000148A8
		[EditorBrowsable(EditorBrowsableState.Never)]
		[CLSCompliant(false)]
		public void Log(LogLevel level, string message, ulong argument)
		{
			if (this.IsEnabled(level))
			{
				this.WriteToTargets(level, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Trace</c> level.
		/// </summary>
		/// <param name="value">A <see langword="object" /> to be written.</param>
		// Token: 0x06000642 RID: 1602 RVA: 0x000166E0 File Offset: 0x000148E0
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Trace(object value)
		{
			if (this.IsTraceEnabled)
			{
				this.WriteToTargets(LogLevel.Trace, "{0}", new object[] { value });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Trace</c> level.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="value">A <see langword="object" /> to be written.</param>
		// Token: 0x06000643 RID: 1603 RVA: 0x0001671C File Offset: 0x0001491C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Trace(IFormatProvider formatProvider, object value)
		{
			if (this.IsTraceEnabled)
			{
				this.WriteToTargets(LogLevel.Trace, formatProvider, "{0}", new object[] { value });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Trace</c> level using the specified parameters.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing format items.</param>
		/// <param name="arg1">First argument to format.</param>
		/// <param name="arg2">Second argument to format.</param>
		// Token: 0x06000644 RID: 1604 RVA: 0x00016758 File Offset: 0x00014958
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Trace(string message, object arg1, object arg2)
		{
			if (this.IsTraceEnabled)
			{
				this.WriteToTargets(LogLevel.Trace, message, new object[] { arg1, arg2 });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Trace</c> level using the specified parameters.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing format items.</param>
		/// <param name="arg1">First argument to format.</param>
		/// <param name="arg2">Second argument to format.</param>
		/// <param name="arg3">Third argument to format.</param>
		// Token: 0x06000645 RID: 1605 RVA: 0x00016794 File Offset: 0x00014994
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Trace(string message, object arg1, object arg2, object arg3)
		{
			if (this.IsTraceEnabled)
			{
				this.WriteToTargets(LogLevel.Trace, message, new object[] { arg1, arg2, arg3 });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Trace</c> level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x06000646 RID: 1606 RVA: 0x000167D4 File Offset: 0x000149D4
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Trace(IFormatProvider formatProvider, string message, bool argument)
		{
			if (this.IsTraceEnabled)
			{
				this.WriteToTargets(LogLevel.Trace, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Trace</c> level using the specified value as a parameter.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x06000647 RID: 1607 RVA: 0x00016810 File Offset: 0x00014A10
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Trace(string message, bool argument)
		{
			if (this.IsTraceEnabled)
			{
				this.WriteToTargets(LogLevel.Trace, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Trace</c> level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x06000648 RID: 1608 RVA: 0x0001684C File Offset: 0x00014A4C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Trace(IFormatProvider formatProvider, string message, char argument)
		{
			if (this.IsTraceEnabled)
			{
				this.WriteToTargets(LogLevel.Trace, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Trace</c> level using the specified value as a parameter.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x06000649 RID: 1609 RVA: 0x00016888 File Offset: 0x00014A88
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Trace(string message, char argument)
		{
			if (this.IsTraceEnabled)
			{
				this.WriteToTargets(LogLevel.Trace, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Trace</c> level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x0600064A RID: 1610 RVA: 0x000168C4 File Offset: 0x00014AC4
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Trace(IFormatProvider formatProvider, string message, byte argument)
		{
			if (this.IsTraceEnabled)
			{
				this.WriteToTargets(LogLevel.Trace, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Trace</c> level using the specified value as a parameter.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x0600064B RID: 1611 RVA: 0x00016900 File Offset: 0x00014B00
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Trace(string message, byte argument)
		{
			if (this.IsTraceEnabled)
			{
				this.WriteToTargets(LogLevel.Trace, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Trace</c> level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x0600064C RID: 1612 RVA: 0x0001693C File Offset: 0x00014B3C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Trace(IFormatProvider formatProvider, string message, string argument)
		{
			if (this.IsTraceEnabled)
			{
				this.WriteToTargets(LogLevel.Trace, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Trace</c> level using the specified value as a parameter.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x0600064D RID: 1613 RVA: 0x00016974 File Offset: 0x00014B74
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Trace(string message, string argument)
		{
			if (this.IsTraceEnabled)
			{
				this.WriteToTargets(LogLevel.Trace, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Trace</c> level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x0600064E RID: 1614 RVA: 0x000169AC File Offset: 0x00014BAC
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Trace(IFormatProvider formatProvider, string message, int argument)
		{
			if (this.IsTraceEnabled)
			{
				this.WriteToTargets(LogLevel.Trace, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Trace</c> level using the specified value as a parameter.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x0600064F RID: 1615 RVA: 0x000169E8 File Offset: 0x00014BE8
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Trace(string message, int argument)
		{
			if (this.IsTraceEnabled)
			{
				this.WriteToTargets(LogLevel.Trace, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Trace</c> level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x06000650 RID: 1616 RVA: 0x00016A24 File Offset: 0x00014C24
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Trace(IFormatProvider formatProvider, string message, long argument)
		{
			if (this.IsTraceEnabled)
			{
				this.WriteToTargets(LogLevel.Trace, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Trace</c> level using the specified value as a parameter.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x06000651 RID: 1617 RVA: 0x00016A60 File Offset: 0x00014C60
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Trace(string message, long argument)
		{
			if (this.IsTraceEnabled)
			{
				this.WriteToTargets(LogLevel.Trace, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Trace</c> level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x06000652 RID: 1618 RVA: 0x00016A9C File Offset: 0x00014C9C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Trace(IFormatProvider formatProvider, string message, float argument)
		{
			if (this.IsTraceEnabled)
			{
				this.WriteToTargets(LogLevel.Trace, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Trace</c> level using the specified value as a parameter.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x06000653 RID: 1619 RVA: 0x00016AD8 File Offset: 0x00014CD8
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Trace(string message, float argument)
		{
			if (this.IsTraceEnabled)
			{
				this.WriteToTargets(LogLevel.Trace, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Trace</c> level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x06000654 RID: 1620 RVA: 0x00016B14 File Offset: 0x00014D14
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Trace(IFormatProvider formatProvider, string message, double argument)
		{
			if (this.IsTraceEnabled)
			{
				this.WriteToTargets(LogLevel.Trace, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Trace</c> level using the specified value as a parameter.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x06000655 RID: 1621 RVA: 0x00016B50 File Offset: 0x00014D50
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Trace(string message, double argument)
		{
			if (this.IsTraceEnabled)
			{
				this.WriteToTargets(LogLevel.Trace, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Trace</c> level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x06000656 RID: 1622 RVA: 0x00016B8C File Offset: 0x00014D8C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Trace(IFormatProvider formatProvider, string message, decimal argument)
		{
			if (this.IsTraceEnabled)
			{
				this.WriteToTargets(LogLevel.Trace, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Trace</c> level using the specified value as a parameter.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x06000657 RID: 1623 RVA: 0x00016BC8 File Offset: 0x00014DC8
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Trace(string message, decimal argument)
		{
			if (this.IsTraceEnabled)
			{
				this.WriteToTargets(LogLevel.Trace, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Trace</c> level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x06000658 RID: 1624 RVA: 0x00016C04 File Offset: 0x00014E04
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Trace(IFormatProvider formatProvider, string message, object argument)
		{
			if (this.IsTraceEnabled)
			{
				this.WriteToTargets(LogLevel.Trace, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Trace</c> level using the specified value as a parameter.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x06000659 RID: 1625 RVA: 0x00016C3C File Offset: 0x00014E3C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Trace(string message, object argument)
		{
			if (this.IsTraceEnabled)
			{
				this.WriteToTargets(LogLevel.Trace, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Trace</c> level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x0600065A RID: 1626 RVA: 0x00016C74 File Offset: 0x00014E74
		[EditorBrowsable(EditorBrowsableState.Never)]
		[CLSCompliant(false)]
		public void Trace(IFormatProvider formatProvider, string message, sbyte argument)
		{
			if (this.IsTraceEnabled)
			{
				this.WriteToTargets(LogLevel.Trace, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Trace</c> level using the specified value as a parameter.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x0600065B RID: 1627 RVA: 0x00016CB0 File Offset: 0x00014EB0
		[EditorBrowsable(EditorBrowsableState.Never)]
		[CLSCompliant(false)]
		public void Trace(string message, sbyte argument)
		{
			if (this.IsTraceEnabled)
			{
				this.WriteToTargets(LogLevel.Trace, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Trace</c> level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x0600065C RID: 1628 RVA: 0x00016CEC File Offset: 0x00014EEC
		[CLSCompliant(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Trace(IFormatProvider formatProvider, string message, uint argument)
		{
			if (this.IsTraceEnabled)
			{
				this.WriteToTargets(LogLevel.Trace, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Trace</c> level using the specified value as a parameter.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x0600065D RID: 1629 RVA: 0x00016D28 File Offset: 0x00014F28
		[EditorBrowsable(EditorBrowsableState.Never)]
		[CLSCompliant(false)]
		public void Trace(string message, uint argument)
		{
			if (this.IsTraceEnabled)
			{
				this.WriteToTargets(LogLevel.Trace, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Trace</c> level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x0600065E RID: 1630 RVA: 0x00016D64 File Offset: 0x00014F64
		[CLSCompliant(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Trace(IFormatProvider formatProvider, string message, ulong argument)
		{
			if (this.IsTraceEnabled)
			{
				this.WriteToTargets(LogLevel.Trace, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Trace</c> level using the specified value as a parameter.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x0600065F RID: 1631 RVA: 0x00016DA0 File Offset: 0x00014FA0
		[CLSCompliant(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Trace(string message, ulong argument)
		{
			if (this.IsTraceEnabled)
			{
				this.WriteToTargets(LogLevel.Trace, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Debug</c> level.
		/// </summary>
		/// <param name="value">A <see langword="object" /> to be written.</param>
		// Token: 0x06000660 RID: 1632 RVA: 0x00016DDC File Offset: 0x00014FDC
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Debug(object value)
		{
			if (this.IsDebugEnabled)
			{
				this.WriteToTargets(LogLevel.Debug, "{0}", new object[] { value });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Debug</c> level.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="value">A <see langword="object" /> to be written.</param>
		// Token: 0x06000661 RID: 1633 RVA: 0x00016E18 File Offset: 0x00015018
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Debug(IFormatProvider formatProvider, object value)
		{
			if (this.IsDebugEnabled)
			{
				this.WriteToTargets(LogLevel.Debug, formatProvider, "{0}", new object[] { value });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Debug</c> level using the specified parameters.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing format items.</param>
		/// <param name="arg1">First argument to format.</param>
		/// <param name="arg2">Second argument to format.</param>
		// Token: 0x06000662 RID: 1634 RVA: 0x00016E54 File Offset: 0x00015054
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Debug(string message, object arg1, object arg2)
		{
			if (this.IsDebugEnabled)
			{
				this.WriteToTargets(LogLevel.Debug, message, new object[] { arg1, arg2 });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Debug</c> level using the specified parameters.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing format items.</param>
		/// <param name="arg1">First argument to format.</param>
		/// <param name="arg2">Second argument to format.</param>
		/// <param name="arg3">Third argument to format.</param>
		// Token: 0x06000663 RID: 1635 RVA: 0x00016E90 File Offset: 0x00015090
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Debug(string message, object arg1, object arg2, object arg3)
		{
			if (this.IsDebugEnabled)
			{
				this.WriteToTargets(LogLevel.Debug, message, new object[] { arg1, arg2, arg3 });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Debug</c> level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x06000664 RID: 1636 RVA: 0x00016ED0 File Offset: 0x000150D0
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Debug(IFormatProvider formatProvider, string message, bool argument)
		{
			if (this.IsDebugEnabled)
			{
				this.WriteToTargets(LogLevel.Debug, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Debug</c> level using the specified value as a parameter.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x06000665 RID: 1637 RVA: 0x00016F0C File Offset: 0x0001510C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Debug(string message, bool argument)
		{
			if (this.IsDebugEnabled)
			{
				this.WriteToTargets(LogLevel.Debug, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Debug</c> level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x06000666 RID: 1638 RVA: 0x00016F48 File Offset: 0x00015148
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Debug(IFormatProvider formatProvider, string message, char argument)
		{
			if (this.IsDebugEnabled)
			{
				this.WriteToTargets(LogLevel.Debug, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Debug</c> level using the specified value as a parameter.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x06000667 RID: 1639 RVA: 0x00016F84 File Offset: 0x00015184
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Debug(string message, char argument)
		{
			if (this.IsDebugEnabled)
			{
				this.WriteToTargets(LogLevel.Debug, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Debug</c> level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x06000668 RID: 1640 RVA: 0x00016FC0 File Offset: 0x000151C0
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Debug(IFormatProvider formatProvider, string message, byte argument)
		{
			if (this.IsDebugEnabled)
			{
				this.WriteToTargets(LogLevel.Debug, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Debug</c> level using the specified value as a parameter.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x06000669 RID: 1641 RVA: 0x00016FFC File Offset: 0x000151FC
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Debug(string message, byte argument)
		{
			if (this.IsDebugEnabled)
			{
				this.WriteToTargets(LogLevel.Debug, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Debug</c> level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x0600066A RID: 1642 RVA: 0x00017038 File Offset: 0x00015238
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Debug(IFormatProvider formatProvider, string message, string argument)
		{
			if (this.IsDebugEnabled)
			{
				this.WriteToTargets(LogLevel.Debug, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Debug</c> level using the specified value as a parameter.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x0600066B RID: 1643 RVA: 0x00017070 File Offset: 0x00015270
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Debug(string message, string argument)
		{
			if (this.IsDebugEnabled)
			{
				this.WriteToTargets(LogLevel.Debug, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Debug</c> level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x0600066C RID: 1644 RVA: 0x000170A8 File Offset: 0x000152A8
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Debug(IFormatProvider formatProvider, string message, int argument)
		{
			if (this.IsDebugEnabled)
			{
				this.WriteToTargets(LogLevel.Debug, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Debug</c> level using the specified value as a parameter.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x0600066D RID: 1645 RVA: 0x000170E4 File Offset: 0x000152E4
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Debug(string message, int argument)
		{
			if (this.IsDebugEnabled)
			{
				this.WriteToTargets(LogLevel.Debug, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Debug</c> level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x0600066E RID: 1646 RVA: 0x00017120 File Offset: 0x00015320
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Debug(IFormatProvider formatProvider, string message, long argument)
		{
			if (this.IsDebugEnabled)
			{
				this.WriteToTargets(LogLevel.Debug, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Debug</c> level using the specified value as a parameter.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x0600066F RID: 1647 RVA: 0x0001715C File Offset: 0x0001535C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Debug(string message, long argument)
		{
			if (this.IsDebugEnabled)
			{
				this.WriteToTargets(LogLevel.Debug, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Debug</c> level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x06000670 RID: 1648 RVA: 0x00017198 File Offset: 0x00015398
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Debug(IFormatProvider formatProvider, string message, float argument)
		{
			if (this.IsDebugEnabled)
			{
				this.WriteToTargets(LogLevel.Debug, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Debug</c> level using the specified value as a parameter.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x06000671 RID: 1649 RVA: 0x000171D4 File Offset: 0x000153D4
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Debug(string message, float argument)
		{
			if (this.IsDebugEnabled)
			{
				this.WriteToTargets(LogLevel.Debug, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Debug</c> level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x06000672 RID: 1650 RVA: 0x00017210 File Offset: 0x00015410
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Debug(IFormatProvider formatProvider, string message, double argument)
		{
			if (this.IsDebugEnabled)
			{
				this.WriteToTargets(LogLevel.Debug, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Debug</c> level using the specified value as a parameter.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x06000673 RID: 1651 RVA: 0x0001724C File Offset: 0x0001544C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Debug(string message, double argument)
		{
			if (this.IsDebugEnabled)
			{
				this.WriteToTargets(LogLevel.Debug, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Debug</c> level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x06000674 RID: 1652 RVA: 0x00017288 File Offset: 0x00015488
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Debug(IFormatProvider formatProvider, string message, decimal argument)
		{
			if (this.IsDebugEnabled)
			{
				this.WriteToTargets(LogLevel.Debug, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Debug</c> level using the specified value as a parameter.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x06000675 RID: 1653 RVA: 0x000172C4 File Offset: 0x000154C4
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Debug(string message, decimal argument)
		{
			if (this.IsDebugEnabled)
			{
				this.WriteToTargets(LogLevel.Debug, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Debug</c> level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x06000676 RID: 1654 RVA: 0x00017300 File Offset: 0x00015500
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Debug(IFormatProvider formatProvider, string message, object argument)
		{
			if (this.IsDebugEnabled)
			{
				this.WriteToTargets(LogLevel.Debug, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Debug</c> level using the specified value as a parameter.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x06000677 RID: 1655 RVA: 0x00017338 File Offset: 0x00015538
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Debug(string message, object argument)
		{
			if (this.IsDebugEnabled)
			{
				this.WriteToTargets(LogLevel.Debug, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Debug</c> level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x06000678 RID: 1656 RVA: 0x00017370 File Offset: 0x00015570
		[EditorBrowsable(EditorBrowsableState.Never)]
		[CLSCompliant(false)]
		public void Debug(IFormatProvider formatProvider, string message, sbyte argument)
		{
			if (this.IsDebugEnabled)
			{
				this.WriteToTargets(LogLevel.Debug, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Debug</c> level using the specified value as a parameter.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x06000679 RID: 1657 RVA: 0x000173AC File Offset: 0x000155AC
		[EditorBrowsable(EditorBrowsableState.Never)]
		[CLSCompliant(false)]
		public void Debug(string message, sbyte argument)
		{
			if (this.IsDebugEnabled)
			{
				this.WriteToTargets(LogLevel.Debug, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Debug</c> level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x0600067A RID: 1658 RVA: 0x000173E8 File Offset: 0x000155E8
		[EditorBrowsable(EditorBrowsableState.Never)]
		[CLSCompliant(false)]
		public void Debug(IFormatProvider formatProvider, string message, uint argument)
		{
			if (this.IsDebugEnabled)
			{
				this.WriteToTargets(LogLevel.Debug, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Debug</c> level using the specified value as a parameter.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x0600067B RID: 1659 RVA: 0x00017424 File Offset: 0x00015624
		[CLSCompliant(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Debug(string message, uint argument)
		{
			if (this.IsDebugEnabled)
			{
				this.WriteToTargets(LogLevel.Debug, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Debug</c> level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x0600067C RID: 1660 RVA: 0x00017460 File Offset: 0x00015660
		[CLSCompliant(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Debug(IFormatProvider formatProvider, string message, ulong argument)
		{
			if (this.IsDebugEnabled)
			{
				this.WriteToTargets(LogLevel.Debug, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Debug</c> level using the specified value as a parameter.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x0600067D RID: 1661 RVA: 0x0001749C File Offset: 0x0001569C
		[CLSCompliant(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Debug(string message, ulong argument)
		{
			if (this.IsDebugEnabled)
			{
				this.WriteToTargets(LogLevel.Debug, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Info</c> level.
		/// </summary>
		/// <param name="value">A <see langword="object" /> to be written.</param>
		// Token: 0x0600067E RID: 1662 RVA: 0x000174D8 File Offset: 0x000156D8
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Info(object value)
		{
			if (this.IsInfoEnabled)
			{
				this.WriteToTargets(LogLevel.Info, "{0}", new object[] { value });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Info</c> level.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="value">A <see langword="object" /> to be written.</param>
		// Token: 0x0600067F RID: 1663 RVA: 0x00017514 File Offset: 0x00015714
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Info(IFormatProvider formatProvider, object value)
		{
			if (this.IsInfoEnabled)
			{
				this.WriteToTargets(LogLevel.Info, formatProvider, "{0}", new object[] { value });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Info</c> level using the specified parameters.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing format items.</param>
		/// <param name="arg1">First argument to format.</param>
		/// <param name="arg2">Second argument to format.</param>
		// Token: 0x06000680 RID: 1664 RVA: 0x00017550 File Offset: 0x00015750
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Info(string message, object arg1, object arg2)
		{
			if (this.IsInfoEnabled)
			{
				this.WriteToTargets(LogLevel.Info, message, new object[] { arg1, arg2 });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Info</c> level using the specified parameters.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing format items.</param>
		/// <param name="arg1">First argument to format.</param>
		/// <param name="arg2">Second argument to format.</param>
		/// <param name="arg3">Third argument to format.</param>
		// Token: 0x06000681 RID: 1665 RVA: 0x0001758C File Offset: 0x0001578C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Info(string message, object arg1, object arg2, object arg3)
		{
			if (this.IsInfoEnabled)
			{
				this.WriteToTargets(LogLevel.Info, message, new object[] { arg1, arg2, arg3 });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Info</c> level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x06000682 RID: 1666 RVA: 0x000175CC File Offset: 0x000157CC
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Info(IFormatProvider formatProvider, string message, bool argument)
		{
			if (this.IsInfoEnabled)
			{
				this.WriteToTargets(LogLevel.Info, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Info</c> level using the specified value as a parameter.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x06000683 RID: 1667 RVA: 0x00017608 File Offset: 0x00015808
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Info(string message, bool argument)
		{
			if (this.IsInfoEnabled)
			{
				this.WriteToTargets(LogLevel.Info, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Info</c> level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x06000684 RID: 1668 RVA: 0x00017644 File Offset: 0x00015844
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Info(IFormatProvider formatProvider, string message, char argument)
		{
			if (this.IsInfoEnabled)
			{
				this.WriteToTargets(LogLevel.Info, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Info</c> level using the specified value as a parameter.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x06000685 RID: 1669 RVA: 0x00017680 File Offset: 0x00015880
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Info(string message, char argument)
		{
			if (this.IsInfoEnabled)
			{
				this.WriteToTargets(LogLevel.Info, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Info</c> level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x06000686 RID: 1670 RVA: 0x000176BC File Offset: 0x000158BC
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Info(IFormatProvider formatProvider, string message, byte argument)
		{
			if (this.IsInfoEnabled)
			{
				this.WriteToTargets(LogLevel.Info, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Info</c> level using the specified value as a parameter.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x06000687 RID: 1671 RVA: 0x000176F8 File Offset: 0x000158F8
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Info(string message, byte argument)
		{
			if (this.IsInfoEnabled)
			{
				this.WriteToTargets(LogLevel.Info, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Info</c> level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x06000688 RID: 1672 RVA: 0x00017734 File Offset: 0x00015934
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Info(IFormatProvider formatProvider, string message, string argument)
		{
			if (this.IsInfoEnabled)
			{
				this.WriteToTargets(LogLevel.Info, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Info</c> level using the specified value as a parameter.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x06000689 RID: 1673 RVA: 0x0001776C File Offset: 0x0001596C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Info(string message, string argument)
		{
			if (this.IsInfoEnabled)
			{
				this.WriteToTargets(LogLevel.Info, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Info</c> level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x0600068A RID: 1674 RVA: 0x000177A4 File Offset: 0x000159A4
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Info(IFormatProvider formatProvider, string message, int argument)
		{
			if (this.IsInfoEnabled)
			{
				this.WriteToTargets(LogLevel.Info, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Info</c> level using the specified value as a parameter.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x0600068B RID: 1675 RVA: 0x000177E0 File Offset: 0x000159E0
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Info(string message, int argument)
		{
			if (this.IsInfoEnabled)
			{
				this.WriteToTargets(LogLevel.Info, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Info</c> level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x0600068C RID: 1676 RVA: 0x0001781C File Offset: 0x00015A1C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Info(IFormatProvider formatProvider, string message, long argument)
		{
			if (this.IsInfoEnabled)
			{
				this.WriteToTargets(LogLevel.Info, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Info</c> level using the specified value as a parameter.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x0600068D RID: 1677 RVA: 0x00017858 File Offset: 0x00015A58
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Info(string message, long argument)
		{
			if (this.IsInfoEnabled)
			{
				this.WriteToTargets(LogLevel.Info, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Info</c> level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x0600068E RID: 1678 RVA: 0x00017894 File Offset: 0x00015A94
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Info(IFormatProvider formatProvider, string message, float argument)
		{
			if (this.IsInfoEnabled)
			{
				this.WriteToTargets(LogLevel.Info, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Info</c> level using the specified value as a parameter.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x0600068F RID: 1679 RVA: 0x000178D0 File Offset: 0x00015AD0
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Info(string message, float argument)
		{
			if (this.IsInfoEnabled)
			{
				this.WriteToTargets(LogLevel.Info, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Info</c> level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x06000690 RID: 1680 RVA: 0x0001790C File Offset: 0x00015B0C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Info(IFormatProvider formatProvider, string message, double argument)
		{
			if (this.IsInfoEnabled)
			{
				this.WriteToTargets(LogLevel.Info, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Info</c> level using the specified value as a parameter.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x06000691 RID: 1681 RVA: 0x00017948 File Offset: 0x00015B48
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Info(string message, double argument)
		{
			if (this.IsInfoEnabled)
			{
				this.WriteToTargets(LogLevel.Info, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Info</c> level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x06000692 RID: 1682 RVA: 0x00017984 File Offset: 0x00015B84
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Info(IFormatProvider formatProvider, string message, decimal argument)
		{
			if (this.IsInfoEnabled)
			{
				this.WriteToTargets(LogLevel.Info, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Info</c> level using the specified value as a parameter.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x06000693 RID: 1683 RVA: 0x000179C0 File Offset: 0x00015BC0
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Info(string message, decimal argument)
		{
			if (this.IsInfoEnabled)
			{
				this.WriteToTargets(LogLevel.Info, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Info</c> level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x06000694 RID: 1684 RVA: 0x000179FC File Offset: 0x00015BFC
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Info(IFormatProvider formatProvider, string message, object argument)
		{
			if (this.IsInfoEnabled)
			{
				this.WriteToTargets(LogLevel.Info, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Info</c> level using the specified value as a parameter.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x06000695 RID: 1685 RVA: 0x00017A34 File Offset: 0x00015C34
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Info(string message, object argument)
		{
			if (this.IsInfoEnabled)
			{
				this.WriteToTargets(LogLevel.Info, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Info</c> level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x06000696 RID: 1686 RVA: 0x00017A6C File Offset: 0x00015C6C
		[EditorBrowsable(EditorBrowsableState.Never)]
		[CLSCompliant(false)]
		public void Info(IFormatProvider formatProvider, string message, sbyte argument)
		{
			if (this.IsInfoEnabled)
			{
				this.WriteToTargets(LogLevel.Info, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Info</c> level using the specified value as a parameter.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x06000697 RID: 1687 RVA: 0x00017AA8 File Offset: 0x00015CA8
		[EditorBrowsable(EditorBrowsableState.Never)]
		[CLSCompliant(false)]
		public void Info(string message, sbyte argument)
		{
			if (this.IsInfoEnabled)
			{
				this.WriteToTargets(LogLevel.Info, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Info</c> level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x06000698 RID: 1688 RVA: 0x00017AE4 File Offset: 0x00015CE4
		[CLSCompliant(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Info(IFormatProvider formatProvider, string message, uint argument)
		{
			if (this.IsInfoEnabled)
			{
				this.WriteToTargets(LogLevel.Info, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Info</c> level using the specified value as a parameter.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x06000699 RID: 1689 RVA: 0x00017B20 File Offset: 0x00015D20
		[CLSCompliant(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Info(string message, uint argument)
		{
			if (this.IsInfoEnabled)
			{
				this.WriteToTargets(LogLevel.Info, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Info</c> level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x0600069A RID: 1690 RVA: 0x00017B5C File Offset: 0x00015D5C
		[EditorBrowsable(EditorBrowsableState.Never)]
		[CLSCompliant(false)]
		public void Info(IFormatProvider formatProvider, string message, ulong argument)
		{
			if (this.IsInfoEnabled)
			{
				this.WriteToTargets(LogLevel.Info, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Info</c> level using the specified value as a parameter.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x0600069B RID: 1691 RVA: 0x00017B98 File Offset: 0x00015D98
		[CLSCompliant(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Info(string message, ulong argument)
		{
			if (this.IsInfoEnabled)
			{
				this.WriteToTargets(LogLevel.Info, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Warn</c> level.
		/// </summary>
		/// <param name="value">A <see langword="object" /> to be written.</param>
		// Token: 0x0600069C RID: 1692 RVA: 0x00017BD4 File Offset: 0x00015DD4
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Warn(object value)
		{
			if (this.IsWarnEnabled)
			{
				this.WriteToTargets(LogLevel.Warn, "{0}", new object[] { value });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Warn</c> level.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="value">A <see langword="object" /> to be written.</param>
		// Token: 0x0600069D RID: 1693 RVA: 0x00017C10 File Offset: 0x00015E10
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Warn(IFormatProvider formatProvider, object value)
		{
			if (this.IsWarnEnabled)
			{
				this.WriteToTargets(LogLevel.Warn, formatProvider, "{0}", new object[] { value });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Warn</c> level using the specified parameters.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing format items.</param>
		/// <param name="arg1">First argument to format.</param>
		/// <param name="arg2">Second argument to format.</param>
		// Token: 0x0600069E RID: 1694 RVA: 0x00017C4C File Offset: 0x00015E4C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Warn(string message, object arg1, object arg2)
		{
			if (this.IsWarnEnabled)
			{
				this.WriteToTargets(LogLevel.Warn, message, new object[] { arg1, arg2 });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Warn</c> level using the specified parameters.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing format items.</param>
		/// <param name="arg1">First argument to format.</param>
		/// <param name="arg2">Second argument to format.</param>
		/// <param name="arg3">Third argument to format.</param>
		// Token: 0x0600069F RID: 1695 RVA: 0x00017C88 File Offset: 0x00015E88
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Warn(string message, object arg1, object arg2, object arg3)
		{
			if (this.IsWarnEnabled)
			{
				this.WriteToTargets(LogLevel.Warn, message, new object[] { arg1, arg2, arg3 });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Warn</c> level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060006A0 RID: 1696 RVA: 0x00017CC8 File Offset: 0x00015EC8
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Warn(IFormatProvider formatProvider, string message, bool argument)
		{
			if (this.IsWarnEnabled)
			{
				this.WriteToTargets(LogLevel.Warn, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Warn</c> level using the specified value as a parameter.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060006A1 RID: 1697 RVA: 0x00017D04 File Offset: 0x00015F04
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Warn(string message, bool argument)
		{
			if (this.IsWarnEnabled)
			{
				this.WriteToTargets(LogLevel.Warn, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Warn</c> level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060006A2 RID: 1698 RVA: 0x00017D40 File Offset: 0x00015F40
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Warn(IFormatProvider formatProvider, string message, char argument)
		{
			if (this.IsWarnEnabled)
			{
				this.WriteToTargets(LogLevel.Warn, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Warn</c> level using the specified value as a parameter.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060006A3 RID: 1699 RVA: 0x00017D7C File Offset: 0x00015F7C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Warn(string message, char argument)
		{
			if (this.IsWarnEnabled)
			{
				this.WriteToTargets(LogLevel.Warn, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Warn</c> level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060006A4 RID: 1700 RVA: 0x00017DB8 File Offset: 0x00015FB8
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Warn(IFormatProvider formatProvider, string message, byte argument)
		{
			if (this.IsWarnEnabled)
			{
				this.WriteToTargets(LogLevel.Warn, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Warn</c> level using the specified value as a parameter.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060006A5 RID: 1701 RVA: 0x00017DF4 File Offset: 0x00015FF4
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Warn(string message, byte argument)
		{
			if (this.IsWarnEnabled)
			{
				this.WriteToTargets(LogLevel.Warn, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Warn</c> level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060006A6 RID: 1702 RVA: 0x00017E30 File Offset: 0x00016030
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Warn(IFormatProvider formatProvider, string message, string argument)
		{
			if (this.IsWarnEnabled)
			{
				this.WriteToTargets(LogLevel.Warn, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Warn</c> level using the specified value as a parameter.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060006A7 RID: 1703 RVA: 0x00017E68 File Offset: 0x00016068
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Warn(string message, string argument)
		{
			if (this.IsWarnEnabled)
			{
				this.WriteToTargets(LogLevel.Warn, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Warn</c> level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060006A8 RID: 1704 RVA: 0x00017EA0 File Offset: 0x000160A0
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Warn(IFormatProvider formatProvider, string message, int argument)
		{
			if (this.IsWarnEnabled)
			{
				this.WriteToTargets(LogLevel.Warn, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Warn</c> level using the specified value as a parameter.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060006A9 RID: 1705 RVA: 0x00017EDC File Offset: 0x000160DC
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Warn(string message, int argument)
		{
			if (this.IsWarnEnabled)
			{
				this.WriteToTargets(LogLevel.Warn, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Warn</c> level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060006AA RID: 1706 RVA: 0x00017F18 File Offset: 0x00016118
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Warn(IFormatProvider formatProvider, string message, long argument)
		{
			if (this.IsWarnEnabled)
			{
				this.WriteToTargets(LogLevel.Warn, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Warn</c> level using the specified value as a parameter.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060006AB RID: 1707 RVA: 0x00017F54 File Offset: 0x00016154
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Warn(string message, long argument)
		{
			if (this.IsWarnEnabled)
			{
				this.WriteToTargets(LogLevel.Warn, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Warn</c> level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060006AC RID: 1708 RVA: 0x00017F90 File Offset: 0x00016190
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Warn(IFormatProvider formatProvider, string message, float argument)
		{
			if (this.IsWarnEnabled)
			{
				this.WriteToTargets(LogLevel.Warn, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Warn</c> level using the specified value as a parameter.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060006AD RID: 1709 RVA: 0x00017FCC File Offset: 0x000161CC
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Warn(string message, float argument)
		{
			if (this.IsWarnEnabled)
			{
				this.WriteToTargets(LogLevel.Warn, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Warn</c> level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060006AE RID: 1710 RVA: 0x00018008 File Offset: 0x00016208
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Warn(IFormatProvider formatProvider, string message, double argument)
		{
			if (this.IsWarnEnabled)
			{
				this.WriteToTargets(LogLevel.Warn, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Warn</c> level using the specified value as a parameter.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060006AF RID: 1711 RVA: 0x00018044 File Offset: 0x00016244
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Warn(string message, double argument)
		{
			if (this.IsWarnEnabled)
			{
				this.WriteToTargets(LogLevel.Warn, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Warn</c> level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060006B0 RID: 1712 RVA: 0x00018080 File Offset: 0x00016280
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Warn(IFormatProvider formatProvider, string message, decimal argument)
		{
			if (this.IsWarnEnabled)
			{
				this.WriteToTargets(LogLevel.Warn, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Warn</c> level using the specified value as a parameter.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060006B1 RID: 1713 RVA: 0x000180BC File Offset: 0x000162BC
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Warn(string message, decimal argument)
		{
			if (this.IsWarnEnabled)
			{
				this.WriteToTargets(LogLevel.Warn, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Warn</c> level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060006B2 RID: 1714 RVA: 0x000180F8 File Offset: 0x000162F8
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Warn(IFormatProvider formatProvider, string message, object argument)
		{
			if (this.IsWarnEnabled)
			{
				this.WriteToTargets(LogLevel.Warn, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Warn</c> level using the specified value as a parameter.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060006B3 RID: 1715 RVA: 0x00018130 File Offset: 0x00016330
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Warn(string message, object argument)
		{
			if (this.IsWarnEnabled)
			{
				this.WriteToTargets(LogLevel.Warn, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Warn</c> level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060006B4 RID: 1716 RVA: 0x00018168 File Offset: 0x00016368
		[EditorBrowsable(EditorBrowsableState.Never)]
		[CLSCompliant(false)]
		public void Warn(IFormatProvider formatProvider, string message, sbyte argument)
		{
			if (this.IsWarnEnabled)
			{
				this.WriteToTargets(LogLevel.Warn, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Warn</c> level using the specified value as a parameter.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060006B5 RID: 1717 RVA: 0x000181A4 File Offset: 0x000163A4
		[EditorBrowsable(EditorBrowsableState.Never)]
		[CLSCompliant(false)]
		public void Warn(string message, sbyte argument)
		{
			if (this.IsWarnEnabled)
			{
				this.WriteToTargets(LogLevel.Warn, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Warn</c> level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060006B6 RID: 1718 RVA: 0x000181E0 File Offset: 0x000163E0
		[EditorBrowsable(EditorBrowsableState.Never)]
		[CLSCompliant(false)]
		public void Warn(IFormatProvider formatProvider, string message, uint argument)
		{
			if (this.IsWarnEnabled)
			{
				this.WriteToTargets(LogLevel.Warn, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Warn</c> level using the specified value as a parameter.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060006B7 RID: 1719 RVA: 0x0001821C File Offset: 0x0001641C
		[CLSCompliant(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Warn(string message, uint argument)
		{
			if (this.IsWarnEnabled)
			{
				this.WriteToTargets(LogLevel.Warn, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Warn</c> level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060006B8 RID: 1720 RVA: 0x00018258 File Offset: 0x00016458
		[CLSCompliant(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Warn(IFormatProvider formatProvider, string message, ulong argument)
		{
			if (this.IsWarnEnabled)
			{
				this.WriteToTargets(LogLevel.Warn, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Warn</c> level using the specified value as a parameter.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060006B9 RID: 1721 RVA: 0x00018294 File Offset: 0x00016494
		[EditorBrowsable(EditorBrowsableState.Never)]
		[CLSCompliant(false)]
		public void Warn(string message, ulong argument)
		{
			if (this.IsWarnEnabled)
			{
				this.WriteToTargets(LogLevel.Warn, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Error</c> level.
		/// </summary>
		/// <param name="value">A <see langword="object" /> to be written.</param>
		// Token: 0x060006BA RID: 1722 RVA: 0x000182D0 File Offset: 0x000164D0
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Error(object value)
		{
			if (this.IsErrorEnabled)
			{
				this.WriteToTargets(LogLevel.Error, "{0}", new object[] { value });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Error</c> level.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="value">A <see langword="object" /> to be written.</param>
		// Token: 0x060006BB RID: 1723 RVA: 0x0001830C File Offset: 0x0001650C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Error(IFormatProvider formatProvider, object value)
		{
			if (this.IsErrorEnabled)
			{
				this.WriteToTargets(LogLevel.Error, formatProvider, "{0}", new object[] { value });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Error</c> level using the specified parameters.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing format items.</param>
		/// <param name="arg1">First argument to format.</param>
		/// <param name="arg2">Second argument to format.</param>
		// Token: 0x060006BC RID: 1724 RVA: 0x00018348 File Offset: 0x00016548
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Error(string message, object arg1, object arg2)
		{
			if (this.IsErrorEnabled)
			{
				this.WriteToTargets(LogLevel.Error, message, new object[] { arg1, arg2 });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Error</c> level using the specified parameters.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing format items.</param>
		/// <param name="arg1">First argument to format.</param>
		/// <param name="arg2">Second argument to format.</param>
		/// <param name="arg3">Third argument to format.</param>
		// Token: 0x060006BD RID: 1725 RVA: 0x00018384 File Offset: 0x00016584
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Error(string message, object arg1, object arg2, object arg3)
		{
			if (this.IsErrorEnabled)
			{
				this.WriteToTargets(LogLevel.Error, message, new object[] { arg1, arg2, arg3 });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Error</c> level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060006BE RID: 1726 RVA: 0x000183C4 File Offset: 0x000165C4
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Error(IFormatProvider formatProvider, string message, bool argument)
		{
			if (this.IsErrorEnabled)
			{
				this.WriteToTargets(LogLevel.Error, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Error</c> level using the specified value as a parameter.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060006BF RID: 1727 RVA: 0x00018400 File Offset: 0x00016600
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Error(string message, bool argument)
		{
			if (this.IsErrorEnabled)
			{
				this.WriteToTargets(LogLevel.Error, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Error</c> level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060006C0 RID: 1728 RVA: 0x0001843C File Offset: 0x0001663C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Error(IFormatProvider formatProvider, string message, char argument)
		{
			if (this.IsErrorEnabled)
			{
				this.WriteToTargets(LogLevel.Error, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Error</c> level using the specified value as a parameter.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060006C1 RID: 1729 RVA: 0x00018478 File Offset: 0x00016678
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Error(string message, char argument)
		{
			if (this.IsErrorEnabled)
			{
				this.WriteToTargets(LogLevel.Error, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Error</c> level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060006C2 RID: 1730 RVA: 0x000184B4 File Offset: 0x000166B4
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Error(IFormatProvider formatProvider, string message, byte argument)
		{
			if (this.IsErrorEnabled)
			{
				this.WriteToTargets(LogLevel.Error, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Error</c> level using the specified value as a parameter.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060006C3 RID: 1731 RVA: 0x000184F0 File Offset: 0x000166F0
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Error(string message, byte argument)
		{
			if (this.IsErrorEnabled)
			{
				this.WriteToTargets(LogLevel.Error, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Error</c> level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060006C4 RID: 1732 RVA: 0x0001852C File Offset: 0x0001672C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Error(IFormatProvider formatProvider, string message, string argument)
		{
			if (this.IsErrorEnabled)
			{
				this.WriteToTargets(LogLevel.Error, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Error</c> level using the specified value as a parameter.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060006C5 RID: 1733 RVA: 0x00018564 File Offset: 0x00016764
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Error(string message, string argument)
		{
			if (this.IsErrorEnabled)
			{
				this.WriteToTargets(LogLevel.Error, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Error</c> level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060006C6 RID: 1734 RVA: 0x0001859C File Offset: 0x0001679C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Error(IFormatProvider formatProvider, string message, int argument)
		{
			if (this.IsErrorEnabled)
			{
				this.WriteToTargets(LogLevel.Error, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Error</c> level using the specified value as a parameter.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060006C7 RID: 1735 RVA: 0x000185D8 File Offset: 0x000167D8
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Error(string message, int argument)
		{
			if (this.IsErrorEnabled)
			{
				this.WriteToTargets(LogLevel.Error, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Error</c> level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060006C8 RID: 1736 RVA: 0x00018614 File Offset: 0x00016814
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Error(IFormatProvider formatProvider, string message, long argument)
		{
			if (this.IsErrorEnabled)
			{
				this.WriteToTargets(LogLevel.Error, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Error</c> level using the specified value as a parameter.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060006C9 RID: 1737 RVA: 0x00018650 File Offset: 0x00016850
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Error(string message, long argument)
		{
			if (this.IsErrorEnabled)
			{
				this.WriteToTargets(LogLevel.Error, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Error</c> level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060006CA RID: 1738 RVA: 0x0001868C File Offset: 0x0001688C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Error(IFormatProvider formatProvider, string message, float argument)
		{
			if (this.IsErrorEnabled)
			{
				this.WriteToTargets(LogLevel.Error, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Error</c> level using the specified value as a parameter.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060006CB RID: 1739 RVA: 0x000186C8 File Offset: 0x000168C8
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Error(string message, float argument)
		{
			if (this.IsErrorEnabled)
			{
				this.WriteToTargets(LogLevel.Error, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Error</c> level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060006CC RID: 1740 RVA: 0x00018704 File Offset: 0x00016904
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Error(IFormatProvider formatProvider, string message, double argument)
		{
			if (this.IsErrorEnabled)
			{
				this.WriteToTargets(LogLevel.Error, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Error</c> level using the specified value as a parameter.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060006CD RID: 1741 RVA: 0x00018740 File Offset: 0x00016940
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Error(string message, double argument)
		{
			if (this.IsErrorEnabled)
			{
				this.WriteToTargets(LogLevel.Error, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Error</c> level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060006CE RID: 1742 RVA: 0x0001877C File Offset: 0x0001697C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Error(IFormatProvider formatProvider, string message, decimal argument)
		{
			if (this.IsErrorEnabled)
			{
				this.WriteToTargets(LogLevel.Error, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Error</c> level using the specified value as a parameter.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060006CF RID: 1743 RVA: 0x000187B8 File Offset: 0x000169B8
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Error(string message, decimal argument)
		{
			if (this.IsErrorEnabled)
			{
				this.WriteToTargets(LogLevel.Error, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Error</c> level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060006D0 RID: 1744 RVA: 0x000187F4 File Offset: 0x000169F4
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Error(IFormatProvider formatProvider, string message, object argument)
		{
			if (this.IsErrorEnabled)
			{
				this.WriteToTargets(LogLevel.Error, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Error</c> level using the specified value as a parameter.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060006D1 RID: 1745 RVA: 0x0001882C File Offset: 0x00016A2C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Error(string message, object argument)
		{
			if (this.IsErrorEnabled)
			{
				this.WriteToTargets(LogLevel.Error, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Error</c> level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060006D2 RID: 1746 RVA: 0x00018864 File Offset: 0x00016A64
		[CLSCompliant(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Error(IFormatProvider formatProvider, string message, sbyte argument)
		{
			if (this.IsErrorEnabled)
			{
				this.WriteToTargets(LogLevel.Error, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Error</c> level using the specified value as a parameter.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060006D3 RID: 1747 RVA: 0x000188A0 File Offset: 0x00016AA0
		[EditorBrowsable(EditorBrowsableState.Never)]
		[CLSCompliant(false)]
		public void Error(string message, sbyte argument)
		{
			if (this.IsErrorEnabled)
			{
				this.WriteToTargets(LogLevel.Error, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Error</c> level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060006D4 RID: 1748 RVA: 0x000188DC File Offset: 0x00016ADC
		[CLSCompliant(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Error(IFormatProvider formatProvider, string message, uint argument)
		{
			if (this.IsErrorEnabled)
			{
				this.WriteToTargets(LogLevel.Error, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Error</c> level using the specified value as a parameter.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060006D5 RID: 1749 RVA: 0x00018918 File Offset: 0x00016B18
		[CLSCompliant(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Error(string message, uint argument)
		{
			if (this.IsErrorEnabled)
			{
				this.WriteToTargets(LogLevel.Error, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Error</c> level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060006D6 RID: 1750 RVA: 0x00018954 File Offset: 0x00016B54
		[CLSCompliant(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Error(IFormatProvider formatProvider, string message, ulong argument)
		{
			if (this.IsErrorEnabled)
			{
				this.WriteToTargets(LogLevel.Error, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Error</c> level using the specified value as a parameter.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060006D7 RID: 1751 RVA: 0x00018990 File Offset: 0x00016B90
		[CLSCompliant(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Error(string message, ulong argument)
		{
			if (this.IsErrorEnabled)
			{
				this.WriteToTargets(LogLevel.Error, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Fatal</c> level.
		/// </summary>
		/// <param name="value">A <see langword="object" /> to be written.</param>
		// Token: 0x060006D8 RID: 1752 RVA: 0x000189CC File Offset: 0x00016BCC
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Fatal(object value)
		{
			if (this.IsFatalEnabled)
			{
				this.WriteToTargets(LogLevel.Fatal, "{0}", new object[] { value });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Fatal</c> level.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="value">A <see langword="object" /> to be written.</param>
		// Token: 0x060006D9 RID: 1753 RVA: 0x00018A08 File Offset: 0x00016C08
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Fatal(IFormatProvider formatProvider, object value)
		{
			if (this.IsFatalEnabled)
			{
				this.WriteToTargets(LogLevel.Fatal, formatProvider, "{0}", new object[] { value });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Fatal</c> level using the specified parameters.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing format items.</param>
		/// <param name="arg1">First argument to format.</param>
		/// <param name="arg2">Second argument to format.</param>
		// Token: 0x060006DA RID: 1754 RVA: 0x00018A44 File Offset: 0x00016C44
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Fatal(string message, object arg1, object arg2)
		{
			if (this.IsFatalEnabled)
			{
				this.WriteToTargets(LogLevel.Fatal, message, new object[] { arg1, arg2 });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Fatal</c> level using the specified parameters.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing format items.</param>
		/// <param name="arg1">First argument to format.</param>
		/// <param name="arg2">Second argument to format.</param>
		/// <param name="arg3">Third argument to format.</param>
		// Token: 0x060006DB RID: 1755 RVA: 0x00018A80 File Offset: 0x00016C80
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Fatal(string message, object arg1, object arg2, object arg3)
		{
			if (this.IsFatalEnabled)
			{
				this.WriteToTargets(LogLevel.Fatal, message, new object[] { arg1, arg2, arg3 });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Fatal</c> level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060006DC RID: 1756 RVA: 0x00018AC0 File Offset: 0x00016CC0
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Fatal(IFormatProvider formatProvider, string message, bool argument)
		{
			if (this.IsFatalEnabled)
			{
				this.WriteToTargets(LogLevel.Fatal, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Fatal</c> level using the specified value as a parameter.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060006DD RID: 1757 RVA: 0x00018AFC File Offset: 0x00016CFC
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Fatal(string message, bool argument)
		{
			if (this.IsFatalEnabled)
			{
				this.WriteToTargets(LogLevel.Fatal, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Fatal</c> level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060006DE RID: 1758 RVA: 0x00018B38 File Offset: 0x00016D38
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Fatal(IFormatProvider formatProvider, string message, char argument)
		{
			if (this.IsFatalEnabled)
			{
				this.WriteToTargets(LogLevel.Fatal, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Fatal</c> level using the specified value as a parameter.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060006DF RID: 1759 RVA: 0x00018B74 File Offset: 0x00016D74
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Fatal(string message, char argument)
		{
			if (this.IsFatalEnabled)
			{
				this.WriteToTargets(LogLevel.Fatal, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Fatal</c> level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060006E0 RID: 1760 RVA: 0x00018BB0 File Offset: 0x00016DB0
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Fatal(IFormatProvider formatProvider, string message, byte argument)
		{
			if (this.IsFatalEnabled)
			{
				this.WriteToTargets(LogLevel.Fatal, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Fatal</c> level using the specified value as a parameter.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060006E1 RID: 1761 RVA: 0x00018BEC File Offset: 0x00016DEC
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Fatal(string message, byte argument)
		{
			if (this.IsFatalEnabled)
			{
				this.WriteToTargets(LogLevel.Fatal, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Fatal</c> level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060006E2 RID: 1762 RVA: 0x00018C28 File Offset: 0x00016E28
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Fatal(IFormatProvider formatProvider, string message, string argument)
		{
			if (this.IsFatalEnabled)
			{
				this.WriteToTargets(LogLevel.Fatal, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Fatal</c> level using the specified value as a parameter.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060006E3 RID: 1763 RVA: 0x00018C60 File Offset: 0x00016E60
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Fatal(string message, string argument)
		{
			if (this.IsFatalEnabled)
			{
				this.WriteToTargets(LogLevel.Fatal, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Fatal</c> level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060006E4 RID: 1764 RVA: 0x00018C98 File Offset: 0x00016E98
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Fatal(IFormatProvider formatProvider, string message, int argument)
		{
			if (this.IsFatalEnabled)
			{
				this.WriteToTargets(LogLevel.Fatal, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Fatal</c> level using the specified value as a parameter.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060006E5 RID: 1765 RVA: 0x00018CD4 File Offset: 0x00016ED4
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Fatal(string message, int argument)
		{
			if (this.IsFatalEnabled)
			{
				this.WriteToTargets(LogLevel.Fatal, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Fatal</c> level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060006E6 RID: 1766 RVA: 0x00018D10 File Offset: 0x00016F10
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Fatal(IFormatProvider formatProvider, string message, long argument)
		{
			if (this.IsFatalEnabled)
			{
				this.WriteToTargets(LogLevel.Fatal, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Fatal</c> level using the specified value as a parameter.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060006E7 RID: 1767 RVA: 0x00018D4C File Offset: 0x00016F4C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Fatal(string message, long argument)
		{
			if (this.IsFatalEnabled)
			{
				this.WriteToTargets(LogLevel.Fatal, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Fatal</c> level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060006E8 RID: 1768 RVA: 0x00018D88 File Offset: 0x00016F88
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Fatal(IFormatProvider formatProvider, string message, float argument)
		{
			if (this.IsFatalEnabled)
			{
				this.WriteToTargets(LogLevel.Fatal, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Fatal</c> level using the specified value as a parameter.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060006E9 RID: 1769 RVA: 0x00018DC4 File Offset: 0x00016FC4
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Fatal(string message, float argument)
		{
			if (this.IsFatalEnabled)
			{
				this.WriteToTargets(LogLevel.Fatal, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Fatal</c> level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060006EA RID: 1770 RVA: 0x00018E00 File Offset: 0x00017000
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Fatal(IFormatProvider formatProvider, string message, double argument)
		{
			if (this.IsFatalEnabled)
			{
				this.WriteToTargets(LogLevel.Fatal, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Fatal</c> level using the specified value as a parameter.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060006EB RID: 1771 RVA: 0x00018E3C File Offset: 0x0001703C
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Fatal(string message, double argument)
		{
			if (this.IsFatalEnabled)
			{
				this.WriteToTargets(LogLevel.Fatal, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Fatal</c> level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060006EC RID: 1772 RVA: 0x00018E78 File Offset: 0x00017078
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Fatal(IFormatProvider formatProvider, string message, decimal argument)
		{
			if (this.IsFatalEnabled)
			{
				this.WriteToTargets(LogLevel.Fatal, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Fatal</c> level using the specified value as a parameter.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060006ED RID: 1773 RVA: 0x00018EB4 File Offset: 0x000170B4
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Fatal(string message, decimal argument)
		{
			if (this.IsFatalEnabled)
			{
				this.WriteToTargets(LogLevel.Fatal, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Fatal</c> level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060006EE RID: 1774 RVA: 0x00018EF0 File Offset: 0x000170F0
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Fatal(IFormatProvider formatProvider, string message, object argument)
		{
			if (this.IsFatalEnabled)
			{
				this.WriteToTargets(LogLevel.Fatal, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Fatal</c> level using the specified value as a parameter.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060006EF RID: 1775 RVA: 0x00018F28 File Offset: 0x00017128
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Fatal(string message, object argument)
		{
			if (this.IsFatalEnabled)
			{
				this.WriteToTargets(LogLevel.Fatal, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Fatal</c> level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060006F0 RID: 1776 RVA: 0x00018F60 File Offset: 0x00017160
		[CLSCompliant(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Fatal(IFormatProvider formatProvider, string message, sbyte argument)
		{
			if (this.IsFatalEnabled)
			{
				this.WriteToTargets(LogLevel.Fatal, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Fatal</c> level using the specified value as a parameter.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060006F1 RID: 1777 RVA: 0x00018F9C File Offset: 0x0001719C
		[CLSCompliant(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Fatal(string message, sbyte argument)
		{
			if (this.IsFatalEnabled)
			{
				this.WriteToTargets(LogLevel.Fatal, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Fatal</c> level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060006F2 RID: 1778 RVA: 0x00018FD8 File Offset: 0x000171D8
		[EditorBrowsable(EditorBrowsableState.Never)]
		[CLSCompliant(false)]
		public void Fatal(IFormatProvider formatProvider, string message, uint argument)
		{
			if (this.IsFatalEnabled)
			{
				this.WriteToTargets(LogLevel.Fatal, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Fatal</c> level using the specified value as a parameter.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060006F3 RID: 1779 RVA: 0x00019014 File Offset: 0x00017214
		[EditorBrowsable(EditorBrowsableState.Never)]
		[CLSCompliant(false)]
		public void Fatal(string message, uint argument)
		{
			if (this.IsFatalEnabled)
			{
				this.WriteToTargets(LogLevel.Fatal, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Fatal</c> level using the specified value as a parameter and formatting it with the supplied format provider.
		/// </summary>
		/// <param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060006F4 RID: 1780 RVA: 0x00019050 File Offset: 0x00017250
		[CLSCompliant(false)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void Fatal(IFormatProvider formatProvider, string message, ulong argument)
		{
			if (this.IsFatalEnabled)
			{
				this.WriteToTargets(LogLevel.Fatal, formatProvider, message, new object[] { argument });
			}
		}

		/// <summary>
		/// Writes the diagnostic message at the <c>Fatal</c> level using the specified value as a parameter.
		/// </summary>
		/// <param name="message">A <see langword="string" /> containing one format item.</param>
		/// <param name="argument">The argument to format.</param>
		// Token: 0x060006F5 RID: 1781 RVA: 0x0001908C File Offset: 0x0001728C
		[EditorBrowsable(EditorBrowsableState.Never)]
		[CLSCompliant(false)]
		public void Fatal(string message, ulong argument)
		{
			if (this.IsFatalEnabled)
			{
				this.WriteToTargets(LogLevel.Fatal, message, new object[] { argument });
			}
		}

		// Token: 0x040001FE RID: 510
		private readonly Type loggerType = typeof(Logger);

		// Token: 0x040001FF RID: 511
		private volatile LoggerConfiguration configuration;

		// Token: 0x04000200 RID: 512
		private volatile bool isTraceEnabled;

		// Token: 0x04000201 RID: 513
		private volatile bool isDebugEnabled;

		// Token: 0x04000202 RID: 514
		private volatile bool isInfoEnabled;

		// Token: 0x04000203 RID: 515
		private volatile bool isWarnEnabled;

		// Token: 0x04000204 RID: 516
		private volatile bool isErrorEnabled;

		// Token: 0x04000205 RID: 517
		private volatile bool isFatalEnabled;
	}
}
