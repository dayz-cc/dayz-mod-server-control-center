using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using NLog.Config;
using NLog.Layouts;

namespace NLog.Targets
{
	/// <summary>
	/// Information about database command + parameters.
	/// </summary>
	// Token: 0x0200010B RID: 267
	[NLogConfigurationItem]
	public class DatabaseCommandInfo
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Targets.DatabaseCommandInfo" /> class.
		/// </summary>
		// Token: 0x0600084A RID: 2122 RVA: 0x0001D4A2 File Offset: 0x0001B6A2
		public DatabaseCommandInfo()
		{
			this.Parameters = new List<DatabaseParameterInfo>();
			this.CommandType = CommandType.Text;
		}

		/// <summary>
		/// Gets or sets the type of the command.
		/// </summary>
		/// <value>The type of the command.</value>
		/// <docgen category="Command Options" order="10" />
		// Token: 0x17000197 RID: 407
		// (get) Token: 0x0600084B RID: 2123 RVA: 0x0001D4C4 File Offset: 0x0001B6C4
		// (set) Token: 0x0600084C RID: 2124 RVA: 0x0001D4DB File Offset: 0x0001B6DB
		[DefaultValue(CommandType.Text)]
		[RequiredParameter]
		public CommandType CommandType { get; set; }

		/// <summary>
		/// Gets or sets the connection string to run the command against. If not provided, connection string from the target is used.
		/// </summary>
		/// <docgen category="Command Options" order="10" />
		// Token: 0x17000198 RID: 408
		// (get) Token: 0x0600084D RID: 2125 RVA: 0x0001D4E4 File Offset: 0x0001B6E4
		// (set) Token: 0x0600084E RID: 2126 RVA: 0x0001D4FB File Offset: 0x0001B6FB
		public Layout ConnectionString { get; set; }

		/// <summary>
		/// Gets or sets the command text.
		/// </summary>
		/// <docgen category="Command Options" order="10" />
		// Token: 0x17000199 RID: 409
		// (get) Token: 0x0600084F RID: 2127 RVA: 0x0001D504 File Offset: 0x0001B704
		// (set) Token: 0x06000850 RID: 2128 RVA: 0x0001D51B File Offset: 0x0001B71B
		[RequiredParameter]
		public Layout Text { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether to ignore failures.
		/// </summary>
		/// <docgen category="Command Options" order="10" />
		// Token: 0x1700019A RID: 410
		// (get) Token: 0x06000851 RID: 2129 RVA: 0x0001D524 File Offset: 0x0001B724
		// (set) Token: 0x06000852 RID: 2130 RVA: 0x0001D53B File Offset: 0x0001B73B
		public bool IgnoreFailures { get; set; }

		/// <summary>
		/// Gets the collection of parameters. Each parameter contains a mapping
		/// between NLog layout and a database named or positional parameter.
		/// </summary>
		/// <docgen category="Command Options" order="10" />
		// Token: 0x1700019B RID: 411
		// (get) Token: 0x06000853 RID: 2131 RVA: 0x0001D544 File Offset: 0x0001B744
		// (set) Token: 0x06000854 RID: 2132 RVA: 0x0001D55B File Offset: 0x0001B75B
		[ArrayParameter(typeof(DatabaseParameterInfo), "parameter")]
		public IList<DatabaseParameterInfo> Parameters { get; private set; }
	}
}
