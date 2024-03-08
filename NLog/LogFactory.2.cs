using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace NLog
{
	/// <summary>
	/// Specialized LogFactory that can return instances of custom logger types.
	/// </summary>
	/// <typeparam name="T">The type of the logger to be returned. Must inherit from <see cref="T:NLog.Logger" />.</typeparam>
	// Token: 0x020000E6 RID: 230
	public class LogFactory<T> : LogFactory where T : Logger
	{
		/// <summary>
		/// Gets the logger.
		/// </summary>
		/// <param name="name">The logger name.</param>
		/// <returns>An instance of <typeparamref name="T" />.</returns>
		// Token: 0x060005AD RID: 1453 RVA: 0x00014794 File Offset: 0x00012994
		public new T GetLogger(string name)
		{
			return (T)((object)base.GetLogger(name, typeof(T)));
		}

		/// <summary>
		/// Gets the logger named after the currently-being-initialized class.
		/// </summary>
		/// <returns>The logger.</returns>
		/// <remarks>This is a slow-running method. 
		/// Make sure you're not doing this in a loop.</remarks>
		// Token: 0x060005AE RID: 1454 RVA: 0x000147BC File Offset: 0x000129BC
		[SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Backwards compatibility")]
		[MethodImpl(MethodImplOptions.NoInlining)]
		public new T GetCurrentClassLogger()
		{
			StackFrame stackFrame = new StackFrame(1, false);
			return this.GetLogger(stackFrame.GetMethod().DeclaringType.FullName);
		}
	}
}
