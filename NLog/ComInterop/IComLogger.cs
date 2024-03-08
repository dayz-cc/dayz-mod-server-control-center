using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace NLog.ComInterop
{
	/// <summary>
	/// NLog COM Interop logger interface.
	/// </summary>
	// Token: 0x02000002 RID: 2
	[Guid("757fd55a-cc93-4b53-a7a0-18e85620704a")]
	[InterfaceType(ComInterfaceType.InterfaceIsDual)]
	[ComVisible(true)]
	public interface IComLogger
	{
		/// <summary>
		/// Writes the diagnostic message at the specified level.
		/// </summary>
		/// <param name="level">The log level.</param>
		/// <param name="message">A <see langword="string" /> to be written.</param>
		// Token: 0x06000001 RID: 1
		void Log(string level, string message);

		/// <summary>
		/// Writes the diagnostic message at the Trace level.
		/// </summary>
		/// <param name="message">A <see langword="string" /> to be written.</param>
		// Token: 0x06000002 RID: 2
		void Trace(string message);

		/// <summary>
		/// Writes the diagnostic message at the Debug level.
		/// </summary>
		/// <param name="message">A <see langword="string" /> to be written.</param>
		// Token: 0x06000003 RID: 3
		void Debug(string message);

		/// <summary>
		/// Writes the diagnostic message at the Info level.
		/// </summary>
		/// <param name="message">A <see langword="string" /> to be written.</param>
		// Token: 0x06000004 RID: 4
		void Info(string message);

		/// <summary>
		/// Writes the diagnostic message at the Warn level.
		/// </summary>
		/// <param name="message">A <see langword="string" /> to be written.</param>
		// Token: 0x06000005 RID: 5
		void Warn(string message);

		/// <summary>
		/// Writes the diagnostic message at the Error level.
		/// </summary>
		/// <param name="message">A <see langword="string" /> to be written.</param>
		// Token: 0x06000006 RID: 6
		[SuppressMessage("Microsoft.Naming", "CA1716:IdentifiersShouldNotMatchKeywords", MessageId = "Error", Justification = "That's NLog API.")]
		void Error(string message);

		/// <summary>
		/// Writes the diagnostic message at the Fatal level.
		/// </summary>
		/// <param name="message">A <see langword="string" /> to be written.</param>
		// Token: 0x06000007 RID: 7
		void Fatal(string message);

		/// <summary>
		/// Checks if the specified log level is enabled.
		/// </summary>
		/// <param name="level">The log level.</param>
		/// <returns>A value indicating whether the specified log level is enabled.</returns>
		// Token: 0x06000008 RID: 8
		bool IsEnabled(string level);

		/// <summary>
		/// Gets a value indicating whether the Trace level is enabled.
		/// </summary>
		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000009 RID: 9
		[SuppressMessage("Microsoft.StyleCop.CSharp.OrderingRules", "SA1201:ElementsMustAppearInTheCorrectOrder", Justification = "This is COM object and properties cannot be reordered")]
		bool IsTraceEnabled { get; }

		/// <summary>
		/// Gets a value indicating whether the Debug level is enabled.
		/// </summary>
		// Token: 0x17000002 RID: 2
		// (get) Token: 0x0600000A RID: 10
		[SuppressMessage("Microsoft.StyleCop.CSharp.OrderingRules", "SA1201:ElementsMustAppearInTheCorrectOrder", Justification = "This is COM object and properties cannot be reordered")]
		bool IsDebugEnabled { get; }

		/// <summary>
		/// Gets a value indicating whether the Info level is enabled.
		/// </summary>
		// Token: 0x17000003 RID: 3
		// (get) Token: 0x0600000B RID: 11
		[SuppressMessage("Microsoft.StyleCop.CSharp.OrderingRules", "SA1201:ElementsMustAppearInTheCorrectOrder", Justification = "This is COM object and properties cannot be reordered")]
		bool IsInfoEnabled { get; }

		/// <summary>
		/// Gets a value indicating whether the Warn level is enabled.
		/// </summary>
		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600000C RID: 12
		[SuppressMessage("Microsoft.StyleCop.CSharp.OrderingRules", "SA1201:ElementsMustAppearInTheCorrectOrder", Justification = "This is COM object and properties cannot be reordered")]
		bool IsWarnEnabled { get; }

		/// <summary>
		/// Gets a value indicating whether the Error level is enabled.
		/// </summary>
		// Token: 0x17000005 RID: 5
		// (get) Token: 0x0600000D RID: 13
		[SuppressMessage("Microsoft.StyleCop.CSharp.OrderingRules", "SA1201:ElementsMustAppearInTheCorrectOrder", Justification = "This is COM object and properties cannot be reordered")]
		bool IsErrorEnabled { get; }

		/// <summary>
		/// Gets a value indicating whether the Fatal level is enabled.
		/// </summary>
		// Token: 0x17000006 RID: 6
		// (get) Token: 0x0600000E RID: 14
		[SuppressMessage("Microsoft.StyleCop.CSharp.OrderingRules", "SA1201:ElementsMustAppearInTheCorrectOrder", Justification = "This is COM object and properties cannot be reordered")]
		bool IsFatalEnabled { get; }

		/// <summary>
		/// Gets or sets the logger name.
		/// </summary>
		// Token: 0x17000007 RID: 7
		// (get) Token: 0x0600000F RID: 15
		// (set) Token: 0x06000010 RID: 16
		[SuppressMessage("Microsoft.StyleCop.CSharp.OrderingRules", "SA1201:ElementsMustAppearInTheCorrectOrder", Justification = "This is COM object and properties cannot be reordered")]
		string LoggerName { get; set; }
	}
}
