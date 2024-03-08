using System;
using System.Diagnostics.CodeAnalysis;
using NLog.Internal;

namespace NLog
{
	/// <summary>
	/// Defines available log levels.
	/// </summary>
	// Token: 0x020000E9 RID: 233
	public sealed class LogLevel : IComparable
	{
		/// <summary>
		/// Initializes a new instance of <see cref="T:NLog.LogLevel" />.
		/// </summary>
		/// <param name="name">The log level name.</param>
		/// <param name="ordinal">The log level ordinal number.</param>
		// Token: 0x060006FC RID: 1788 RVA: 0x00019472 File Offset: 0x00017672
		public LogLevel(string name, int ordinal)
		{
			this.name = name;
			this.ordinal = ordinal;
		}

		/// <summary>
		/// Gets the name of the log level.
		/// </summary>
		// Token: 0x1700014A RID: 330
		// (get) Token: 0x060006FD RID: 1789 RVA: 0x0001948C File Offset: 0x0001768C
		public string Name
		{
			get
			{
				return this.name;
			}
		}

		// Token: 0x1700014B RID: 331
		// (get) Token: 0x060006FE RID: 1790 RVA: 0x000194A4 File Offset: 0x000176A4
		internal static LogLevel MaxLevel
		{
			get
			{
				return LogLevel.Fatal;
			}
		}

		// Token: 0x1700014C RID: 332
		// (get) Token: 0x060006FF RID: 1791 RVA: 0x000194BC File Offset: 0x000176BC
		internal static LogLevel MinLevel
		{
			get
			{
				return LogLevel.Trace;
			}
		}

		/// <summary>
		/// Gets the ordinal of the log level.
		/// </summary>
		// Token: 0x1700014D RID: 333
		// (get) Token: 0x06000700 RID: 1792 RVA: 0x000194D4 File Offset: 0x000176D4
		public int Ordinal
		{
			get
			{
				return this.ordinal;
			}
		}

		/// <summary>
		/// Compares two <see cref="T:NLog.LogLevel" /> objects 
		/// and returns a value indicating whether 
		/// the first one is equal to the second one.
		/// </summary>
		/// <param name="level1">The first level.</param>
		/// <param name="level2">The second level.</param>
		/// <returns>The value of <c>level1.Ordinal == level2.Ordinal</c>.</returns>
		// Token: 0x06000701 RID: 1793 RVA: 0x000194EC File Offset: 0x000176EC
		public static bool operator ==(LogLevel level1, LogLevel level2)
		{
			bool flag;
			if (object.ReferenceEquals(level1, null))
			{
				flag = object.ReferenceEquals(level2, null);
			}
			else
			{
				flag = !object.ReferenceEquals(level2, null) && level1.Ordinal == level2.Ordinal;
			}
			return flag;
		}

		/// <summary>
		/// Compares two <see cref="T:NLog.LogLevel" /> objects 
		/// and returns a value indicating whether 
		/// the first one is not equal to the second one.
		/// </summary>
		/// <param name="level1">The first level.</param>
		/// <param name="level2">The second level.</param>
		/// <returns>The value of <c>level1.Ordinal != level2.Ordinal</c>.</returns>
		// Token: 0x06000702 RID: 1794 RVA: 0x00019538 File Offset: 0x00017738
		public static bool operator !=(LogLevel level1, LogLevel level2)
		{
			bool flag;
			if (object.ReferenceEquals(level1, null))
			{
				flag = !object.ReferenceEquals(level2, null);
			}
			else
			{
				flag = object.ReferenceEquals(level2, null) || level1.Ordinal != level2.Ordinal;
			}
			return flag;
		}

		/// <summary>
		/// Compares two <see cref="T:NLog.LogLevel" /> objects 
		/// and returns a value indicating whether 
		/// the first one is greater than the second one.
		/// </summary>
		/// <param name="level1">The first level.</param>
		/// <param name="level2">The second level.</param>
		/// <returns>The value of <c>level1.Ordinal &gt; level2.Ordinal</c>.</returns>
		// Token: 0x06000703 RID: 1795 RVA: 0x0001958C File Offset: 0x0001778C
		public static bool operator >(LogLevel level1, LogLevel level2)
		{
			ParameterUtils.AssertNotNull(level1, "level1");
			ParameterUtils.AssertNotNull(level2, "level2");
			return level1.Ordinal > level2.Ordinal;
		}

		/// <summary>
		/// Compares two <see cref="T:NLog.LogLevel" /> objects 
		/// and returns a value indicating whether 
		/// the first one is greater than or equal to the second one.
		/// </summary>
		/// <param name="level1">The first level.</param>
		/// <param name="level2">The second level.</param>
		/// <returns>The value of <c>level1.Ordinal &gt;= level2.Ordinal</c>.</returns>
		// Token: 0x06000704 RID: 1796 RVA: 0x000195C4 File Offset: 0x000177C4
		public static bool operator >=(LogLevel level1, LogLevel level2)
		{
			ParameterUtils.AssertNotNull(level1, "level1");
			ParameterUtils.AssertNotNull(level2, "level2");
			return level1.Ordinal >= level2.Ordinal;
		}

		/// <summary>
		/// Compares two <see cref="T:NLog.LogLevel" /> objects 
		/// and returns a value indicating whether 
		/// the first one is less than the second one.
		/// </summary>
		/// <param name="level1">The first level.</param>
		/// <param name="level2">The second level.</param>
		/// <returns>The value of <c>level1.Ordinal &lt; level2.Ordinal</c>.</returns>
		// Token: 0x06000705 RID: 1797 RVA: 0x00019600 File Offset: 0x00017800
		public static bool operator <(LogLevel level1, LogLevel level2)
		{
			ParameterUtils.AssertNotNull(level1, "level1");
			ParameterUtils.AssertNotNull(level2, "level2");
			return level1.Ordinal < level2.Ordinal;
		}

		/// <summary>
		/// Compares two <see cref="T:NLog.LogLevel" /> objects 
		/// and returns a value indicating whether 
		/// the first one is less than or equal to the second one.
		/// </summary>
		/// <param name="level1">The first level.</param>
		/// <param name="level2">The second level.</param>
		/// <returns>The value of <c>level1.Ordinal &lt;= level2.Ordinal</c>.</returns>
		// Token: 0x06000706 RID: 1798 RVA: 0x00019638 File Offset: 0x00017838
		public static bool operator <=(LogLevel level1, LogLevel level2)
		{
			ParameterUtils.AssertNotNull(level1, "level1");
			ParameterUtils.AssertNotNull(level2, "level2");
			return level1.Ordinal <= level2.Ordinal;
		}

		/// <summary>
		/// Gets the <see cref="T:NLog.LogLevel" /> that corresponds to the specified ordinal.
		/// </summary>
		/// <param name="ordinal">The ordinal.</param>
		/// <returns>The <see cref="T:NLog.LogLevel" /> instance. For 0 it returns <see cref="F:NLog.LogLevel.Trace" />, 1 gives <see cref="F:NLog.LogLevel.Debug" /> and so on.</returns>
		// Token: 0x06000707 RID: 1799 RVA: 0x00019674 File Offset: 0x00017874
		public static LogLevel FromOrdinal(int ordinal)
		{
			LogLevel logLevel;
			switch (ordinal)
			{
			case 0:
				logLevel = LogLevel.Trace;
				break;
			case 1:
				logLevel = LogLevel.Debug;
				break;
			case 2:
				logLevel = LogLevel.Info;
				break;
			case 3:
				logLevel = LogLevel.Warn;
				break;
			case 4:
				logLevel = LogLevel.Error;
				break;
			case 5:
				logLevel = LogLevel.Fatal;
				break;
			case 6:
				logLevel = LogLevel.Off;
				break;
			default:
				throw new ArgumentException("Invalid ordinal.");
			}
			return logLevel;
		}

		/// <summary>
		/// Returns the <see cref="T:NLog.LogLevel" /> that corresponds to the supplied <see langword="string" />.
		/// </summary>
		/// <param name="levelName">The texual representation of the log level.</param>
		/// <returns>The enumeration value.</returns>
		// Token: 0x06000708 RID: 1800 RVA: 0x000196EC File Offset: 0x000178EC
		public static LogLevel FromString(string levelName)
		{
			if (levelName == null)
			{
				throw new ArgumentNullException("levelName");
			}
			LogLevel logLevel;
			if (levelName.Equals("Trace", StringComparison.OrdinalIgnoreCase))
			{
				logLevel = LogLevel.Trace;
			}
			else if (levelName.Equals("Debug", StringComparison.OrdinalIgnoreCase))
			{
				logLevel = LogLevel.Debug;
			}
			else if (levelName.Equals("Info", StringComparison.OrdinalIgnoreCase))
			{
				logLevel = LogLevel.Info;
			}
			else if (levelName.Equals("Warn", StringComparison.OrdinalIgnoreCase))
			{
				logLevel = LogLevel.Warn;
			}
			else if (levelName.Equals("Error", StringComparison.OrdinalIgnoreCase))
			{
				logLevel = LogLevel.Error;
			}
			else if (levelName.Equals("Fatal", StringComparison.OrdinalIgnoreCase))
			{
				logLevel = LogLevel.Fatal;
			}
			else
			{
				if (!levelName.Equals("Off", StringComparison.OrdinalIgnoreCase))
				{
					throw new ArgumentException("Unknown log level: " + levelName);
				}
				logLevel = LogLevel.Off;
			}
			return logLevel;
		}

		/// <summary>
		/// Returns a string representation of the log level.
		/// </summary>
		/// <returns>Log level name.</returns>
		// Token: 0x06000709 RID: 1801 RVA: 0x000197F0 File Offset: 0x000179F0
		public override string ToString()
		{
			return this.Name;
		}

		/// <summary>
		/// Returns a hash code for this instance.
		/// </summary>
		/// <returns>
		/// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
		/// </returns>
		// Token: 0x0600070A RID: 1802 RVA: 0x00019808 File Offset: 0x00017A08
		public override int GetHashCode()
		{
			return this.Ordinal;
		}

		/// <summary>
		/// Determines whether the specified <see cref="T:System.Object" /> is equal to this instance.
		/// </summary>
		/// <param name="obj">The <see cref="T:System.Object" /> to compare with this instance.</param>
		/// <returns>
		/// Value of <c>true</c> if the specified <see cref="T:System.Object" /> is equal to this instance; otherwise, <c>false</c>.
		/// </returns>
		/// <exception cref="T:System.NullReferenceException">
		/// The <paramref name="obj" /> parameter is null.
		/// </exception>
		// Token: 0x0600070B RID: 1803 RVA: 0x00019820 File Offset: 0x00017A20
		public override bool Equals(object obj)
		{
			LogLevel logLevel = obj as LogLevel;
			return logLevel != null && this.Ordinal == logLevel.Ordinal;
		}

		/// <summary>
		/// Compares the level to the other <see cref="T:NLog.LogLevel" /> object.
		/// </summary>
		/// <param name="obj">
		/// The object object.
		/// </param>
		/// <returns>
		/// A value less than zero when this logger's <see cref="P:NLog.LogLevel.Ordinal" /> is 
		/// less than the other logger's ordinal, 0 when they are equal and 
		/// greater than zero when this ordinal is greater than the
		/// other ordinal.
		/// </returns>
		// Token: 0x0600070C RID: 1804 RVA: 0x00019858 File Offset: 0x00017A58
		public int CompareTo(object obj)
		{
			LogLevel logLevel = (LogLevel)obj;
			return this.Ordinal - logLevel.Ordinal;
		}

		/// <summary>
		/// Trace log level.
		/// </summary>
		// Token: 0x0400020D RID: 525
		[SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "Type is immutable")]
		public static readonly LogLevel Trace = new LogLevel("Trace", 0);

		/// <summary>
		/// Debug log level.
		/// </summary>
		// Token: 0x0400020E RID: 526
		[SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "Type is immutable")]
		public static readonly LogLevel Debug = new LogLevel("Debug", 1);

		/// <summary>
		/// Info log level.
		/// </summary>
		// Token: 0x0400020F RID: 527
		[SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "Type is immutable")]
		public static readonly LogLevel Info = new LogLevel("Info", 2);

		/// <summary>
		/// Warn log level.
		/// </summary>
		// Token: 0x04000210 RID: 528
		[SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "Type is immutable")]
		public static readonly LogLevel Warn = new LogLevel("Warn", 3);

		/// <summary>
		/// Error log level.
		/// </summary>
		// Token: 0x04000211 RID: 529
		[SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "Type is immutable")]
		public static readonly LogLevel Error = new LogLevel("Error", 4);

		/// <summary>
		/// Fatal log level.
		/// </summary>
		// Token: 0x04000212 RID: 530
		[SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "Type is immutable")]
		public static readonly LogLevel Fatal = new LogLevel("Fatal", 5);

		/// <summary>
		/// Off log level.
		/// </summary>
		// Token: 0x04000213 RID: 531
		[SuppressMessage("Microsoft.Security", "CA2104:DoNotDeclareReadOnlyMutableReferenceTypes", Justification = "Type is immutable")]
		public static readonly LogLevel Off = new LogLevel("Off", 6);

		// Token: 0x04000214 RID: 532
		private readonly int ordinal;

		// Token: 0x04000215 RID: 533
		private readonly string name;
	}
}
