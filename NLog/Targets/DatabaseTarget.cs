using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Reflection;
using System.Text;
using NLog.Common;
using NLog.Config;
using NLog.Internal;
using NLog.Layouts;

namespace NLog.Targets
{
	/// <summary>
	/// Writes log messages to the database using an ADO.NET provider.
	/// </summary>
	/// <seealso href="http://nlog-project.org/wiki/Database_target">Documentation on NLog Wiki</seealso>
	/// <example>
	/// <para>
	/// The configuration is dependent on the database type, because
	/// there are differnet methods of specifying connection string, SQL
	/// command and command parameters.
	/// </para>
	/// <para>MS SQL Server using System.Data.SqlClient:</para>
	/// <code lang="XML" source="examples/targets/Configuration File/Database/MSSQL/NLog.config" height="450" />
	/// <para>Oracle using System.Data.OracleClient:</para>
	/// <code lang="XML" source="examples/targets/Configuration File/Database/Oracle.Native/NLog.config" height="350" />
	/// <para>Oracle using System.Data.OleDBClient:</para>
	/// <code lang="XML" source="examples/targets/Configuration File/Database/Oracle.OleDB/NLog.config" height="350" />
	/// <para>To set up the log target programmatically use code like this (an equivalent of MSSQL configuration):</para>
	/// <code lang="C#" source="examples/targets/Configuration API/Database/MSSQL/Example.cs" height="630" />
	/// </example>
	// Token: 0x0200010D RID: 269
	[Target("Database")]
	public sealed class DatabaseTarget : Target, IInstallable
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Targets.DatabaseTarget" /> class.
		/// </summary>
		// Token: 0x06000861 RID: 2145 RVA: 0x0001D62C File Offset: 0x0001B82C
		public DatabaseTarget()
		{
			this.Parameters = new List<DatabaseParameterInfo>();
			this.InstallDdlCommands = new List<DatabaseCommandInfo>();
			this.UninstallDdlCommands = new List<DatabaseCommandInfo>();
			this.DBProvider = "sqlserver";
			this.DBHost = ".";
			this.ConnectionStringsSettings = global::System.Configuration.ConfigurationManager.ConnectionStrings;
		}

		/// <summary>
		/// Gets or sets the name of the database provider.
		/// </summary>
		/// <remarks>
		/// <para>
		/// The parameter name should be a provider invariant name as registered in machine.config or app.config. Common values are:
		/// </para>
		/// <ul>
		/// <li><c>System.Data.SqlClient</c> - <see href="http://msdn.microsoft.com/en-us/library/system.data.sqlclient.aspx">SQL Sever Client</see></li>
		/// <li><c>System.Data.SqlServerCe.3.5</c> - <see href="http://www.microsoft.com/sqlserver/2005/en/us/compact.aspx">SQL Sever Compact 3.5</see></li>
		/// <li><c>System.Data.OracleClient</c> - <see href="http://msdn.microsoft.com/en-us/library/system.data.oracleclient.aspx">Oracle Client from Microsoft</see> (deprecated in .NET Framework 4)</li>
		/// <li><c>Oracle.DataAccess.Client</c> - <see href="http://www.oracle.com/technology/tech/windows/odpnet/index.html">ODP.NET provider from Oracle</see></li>
		/// <li><c>System.Data.SQLite</c> - <see href="http://sqlite.phxsoftware.com/">System.Data.SQLite driver for SQLite</see></li>
		/// <li><c>Npgsql</c> - <see href="http://npgsql.projects.postgresql.org/">Npgsql driver for PostgreSQL</see></li>
		/// <li><c>MySql.Data.MySqlClient</c> - <see href="http://www.mysql.com/downloads/connector/net/">MySQL Connector/Net</see></li>
		/// </ul>
		/// <para>(Note that provider invariant names are not supported on .NET Compact Framework).</para>
		/// <para>
		/// Alternatively the parameter value can be be a fully qualified name of the provider 
		/// connection type (class implementing <see cref="T:System.Data.IDbConnection" />) or one of the following tokens:
		/// </para>
		/// <ul>
		/// <li><c>sqlserver</c>, <c>mssql</c>, <c>microsoft</c> or <c>msde</c> - SQL Server Data Provider</li>
		/// <li><c>oledb</c> - OLEDB Data Provider</li>
		/// <li><c>odbc</c> - ODBC Data Provider</li>
		/// </ul>
		/// </remarks>
		/// <docgen category="Connection Options" order="10" />
		// Token: 0x170001A1 RID: 417
		// (get) Token: 0x06000862 RID: 2146 RVA: 0x0001D698 File Offset: 0x0001B898
		// (set) Token: 0x06000863 RID: 2147 RVA: 0x0001D6AF File Offset: 0x0001B8AF
		[DefaultValue("sqlserver")]
		[RequiredParameter]
		public string DBProvider { get; set; }

		/// <summary>
		/// Gets or sets the name of the connection string (as specified in <see href="http://msdn.microsoft.com/en-us/library/bf7sd233.aspx">&lt;connectionStrings&gt; configuration section</see>.
		/// </summary>
		/// <docgen category="Connection Options" order="10" />
		// Token: 0x170001A2 RID: 418
		// (get) Token: 0x06000864 RID: 2148 RVA: 0x0001D6B8 File Offset: 0x0001B8B8
		// (set) Token: 0x06000865 RID: 2149 RVA: 0x0001D6CF File Offset: 0x0001B8CF
		public string ConnectionStringName { get; set; }

		/// <summary>
		/// Gets or sets the connection string. When provided, it overrides the values
		/// specified in DBHost, DBUserName, DBPassword, DBDatabase.
		/// </summary>
		/// <docgen category="Connection Options" order="10" />
		// Token: 0x170001A3 RID: 419
		// (get) Token: 0x06000866 RID: 2150 RVA: 0x0001D6D8 File Offset: 0x0001B8D8
		// (set) Token: 0x06000867 RID: 2151 RVA: 0x0001D6EF File Offset: 0x0001B8EF
		public Layout ConnectionString { get; set; }

		/// <summary>
		/// Gets or sets the connection string using for installation and uninstallation. If not provided, regular ConnectionString is being used.
		/// </summary>
		/// <docgen category="Installation Options" order="10" />
		// Token: 0x170001A4 RID: 420
		// (get) Token: 0x06000868 RID: 2152 RVA: 0x0001D6F8 File Offset: 0x0001B8F8
		// (set) Token: 0x06000869 RID: 2153 RVA: 0x0001D70F File Offset: 0x0001B90F
		public Layout InstallConnectionString { get; set; }

		/// <summary>
		/// Gets the installation DDL commands.
		/// </summary>
		/// <docgen category="Installation Options" order="10" />
		// Token: 0x170001A5 RID: 421
		// (get) Token: 0x0600086A RID: 2154 RVA: 0x0001D718 File Offset: 0x0001B918
		// (set) Token: 0x0600086B RID: 2155 RVA: 0x0001D72F File Offset: 0x0001B92F
		[ArrayParameter(typeof(DatabaseCommandInfo), "install-command")]
		public IList<DatabaseCommandInfo> InstallDdlCommands { get; private set; }

		/// <summary>
		/// Gets the uninstallation DDL commands.
		/// </summary>
		/// <docgen category="Installation Options" order="10" />
		// Token: 0x170001A6 RID: 422
		// (get) Token: 0x0600086C RID: 2156 RVA: 0x0001D738 File Offset: 0x0001B938
		// (set) Token: 0x0600086D RID: 2157 RVA: 0x0001D74F File Offset: 0x0001B94F
		[ArrayParameter(typeof(DatabaseCommandInfo), "uninstall-command")]
		public IList<DatabaseCommandInfo> UninstallDdlCommands { get; private set; }

		/// <summary>
		/// Gets or sets a value indicating whether to keep the 
		/// database connection open between the log events.
		/// </summary>
		/// <docgen category="Connection Options" order="10" />
		// Token: 0x170001A7 RID: 423
		// (get) Token: 0x0600086E RID: 2158 RVA: 0x0001D758 File Offset: 0x0001B958
		// (set) Token: 0x0600086F RID: 2159 RVA: 0x0001D76F File Offset: 0x0001B96F
		[DefaultValue(true)]
		public bool KeepConnection { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether to use database transactions. 
		/// Some data providers require this.
		/// </summary>
		/// <docgen category="Connection Options" order="10" />
		// Token: 0x170001A8 RID: 424
		// (get) Token: 0x06000870 RID: 2160 RVA: 0x0001D778 File Offset: 0x0001B978
		// (set) Token: 0x06000871 RID: 2161 RVA: 0x0001D78F File Offset: 0x0001B98F
		[DefaultValue(false)]
		public bool UseTransactions { get; set; }

		/// <summary>
		/// Gets or sets the database host name. If the ConnectionString is not provided
		/// this value will be used to construct the "Server=" part of the
		/// connection string.
		/// </summary>
		/// <docgen category="Connection Options" order="10" />
		// Token: 0x170001A9 RID: 425
		// (get) Token: 0x06000872 RID: 2162 RVA: 0x0001D798 File Offset: 0x0001B998
		// (set) Token: 0x06000873 RID: 2163 RVA: 0x0001D7AF File Offset: 0x0001B9AF
		public Layout DBHost { get; set; }

		/// <summary>
		/// Gets or sets the database user name. If the ConnectionString is not provided
		/// this value will be used to construct the "User ID=" part of the
		/// connection string.
		/// </summary>
		/// <docgen category="Connection Options" order="10" />
		// Token: 0x170001AA RID: 426
		// (get) Token: 0x06000874 RID: 2164 RVA: 0x0001D7B8 File Offset: 0x0001B9B8
		// (set) Token: 0x06000875 RID: 2165 RVA: 0x0001D7CF File Offset: 0x0001B9CF
		public Layout DBUserName { get; set; }

		/// <summary>
		/// Gets or sets the database password. If the ConnectionString is not provided
		/// this value will be used to construct the "Password=" part of the
		/// connection string.
		/// </summary>
		/// <docgen category="Connection Options" order="10" />
		// Token: 0x170001AB RID: 427
		// (get) Token: 0x06000876 RID: 2166 RVA: 0x0001D7D8 File Offset: 0x0001B9D8
		// (set) Token: 0x06000877 RID: 2167 RVA: 0x0001D7EF File Offset: 0x0001B9EF
		public Layout DBPassword { get; set; }

		/// <summary>
		/// Gets or sets the database name. If the ConnectionString is not provided
		/// this value will be used to construct the "Database=" part of the
		/// connection string.
		/// </summary>
		/// <docgen category="Connection Options" order="10" />
		// Token: 0x170001AC RID: 428
		// (get) Token: 0x06000878 RID: 2168 RVA: 0x0001D7F8 File Offset: 0x0001B9F8
		// (set) Token: 0x06000879 RID: 2169 RVA: 0x0001D80F File Offset: 0x0001BA0F
		public Layout DBDatabase { get; set; }

		/// <summary>
		/// Gets or sets the text of the SQL command to be run on each log level.
		/// </summary>
		/// <remarks>
		/// Typically this is a SQL INSERT statement or a stored procedure call. 
		/// It should use the database-specific parameters (marked as <c>@parameter</c>
		/// for SQL server or <c>:parameter</c> for Oracle, other data providers
		/// have their own notation) and not the layout renderers, 
		/// because the latter is prone to SQL injection attacks.
		/// The layout renderers should be specified as &lt;parameter /&gt; elements instead.
		/// </remarks>
		/// <docgen category="SQL Statement" order="10" />
		// Token: 0x170001AD RID: 429
		// (get) Token: 0x0600087A RID: 2170 RVA: 0x0001D818 File Offset: 0x0001BA18
		// (set) Token: 0x0600087B RID: 2171 RVA: 0x0001D82F File Offset: 0x0001BA2F
		[RequiredParameter]
		public Layout CommandText { get; set; }

		/// <summary>
		/// Gets the collection of parameters. Each parameter contains a mapping
		/// between NLog layout and a database named or positional parameter.
		/// </summary>
		/// <docgen category="SQL Statement" order="11" />
		// Token: 0x170001AE RID: 430
		// (get) Token: 0x0600087C RID: 2172 RVA: 0x0001D838 File Offset: 0x0001BA38
		// (set) Token: 0x0600087D RID: 2173 RVA: 0x0001D84F File Offset: 0x0001BA4F
		[ArrayParameter(typeof(DatabaseParameterInfo), "parameter")]
		public IList<DatabaseParameterInfo> Parameters { get; private set; }

		// Token: 0x170001AF RID: 431
		// (get) Token: 0x0600087E RID: 2174 RVA: 0x0001D858 File Offset: 0x0001BA58
		// (set) Token: 0x0600087F RID: 2175 RVA: 0x0001D86F File Offset: 0x0001BA6F
		internal DbProviderFactory ProviderFactory { get; set; }

		// Token: 0x170001B0 RID: 432
		// (get) Token: 0x06000880 RID: 2176 RVA: 0x0001D878 File Offset: 0x0001BA78
		// (set) Token: 0x06000881 RID: 2177 RVA: 0x0001D88F File Offset: 0x0001BA8F
		internal ConnectionStringSettingsCollection ConnectionStringsSettings { get; set; }

		// Token: 0x170001B1 RID: 433
		// (get) Token: 0x06000882 RID: 2178 RVA: 0x0001D898 File Offset: 0x0001BA98
		// (set) Token: 0x06000883 RID: 2179 RVA: 0x0001D8AF File Offset: 0x0001BAAF
		internal Type ConnectionType { get; set; }

		/// <summary>
		/// Performs installation which requires administrative permissions.
		/// </summary>
		/// <param name="installationContext">The installation context.</param>
		// Token: 0x06000884 RID: 2180 RVA: 0x0001D8B8 File Offset: 0x0001BAB8
		public void Install(InstallationContext installationContext)
		{
			this.RunInstallCommands(installationContext, this.InstallDdlCommands);
		}

		/// <summary>
		/// Performs uninstallation which requires administrative permissions.
		/// </summary>
		/// <param name="installationContext">The installation context.</param>
		// Token: 0x06000885 RID: 2181 RVA: 0x0001D8C9 File Offset: 0x0001BAC9
		public void Uninstall(InstallationContext installationContext)
		{
			this.RunInstallCommands(installationContext, this.UninstallDdlCommands);
		}

		/// <summary>
		/// Determines whether the item is installed.
		/// </summary>
		/// <param name="installationContext">The installation context.</param>
		/// <returns>
		/// Value indicating whether the item is installed or null if it is not possible to determine.
		/// </returns>
		// Token: 0x06000886 RID: 2182 RVA: 0x0001D8DC File Offset: 0x0001BADC
		public bool? IsInstalled(InstallationContext installationContext)
		{
			return null;
		}

		// Token: 0x06000887 RID: 2183 RVA: 0x0001D8F8 File Offset: 0x0001BAF8
		internal IDbConnection OpenConnection(string connectionString)
		{
			IDbConnection dbConnection;
			if (this.ProviderFactory != null)
			{
				dbConnection = this.ProviderFactory.CreateConnection();
			}
			else
			{
				dbConnection = (IDbConnection)Activator.CreateInstance(this.ConnectionType);
			}
			dbConnection.ConnectionString = connectionString;
			dbConnection.Open();
			return dbConnection;
		}

		/// <summary>
		/// Initializes the target. Can be used by inheriting classes
		/// to initialize logging.
		/// </summary>
		// Token: 0x06000888 RID: 2184 RVA: 0x0001D94C File Offset: 0x0001BB4C
		[SuppressMessage("Microsoft.Naming", "CA2204:Literals should be spelled correctly", MessageId = "connectionStrings", Justification = "Name of the config file section.")]
		protected override void InitializeTarget()
		{
			base.InitializeTarget();
			bool flag = false;
			if (!string.IsNullOrEmpty(this.ConnectionStringName))
			{
				ConnectionStringSettings connectionStringSettings = this.ConnectionStringsSettings[this.ConnectionStringName];
				if (connectionStringSettings == null)
				{
					throw new NLogConfigurationException("Connection string '" + this.ConnectionStringName + "' is not declared in <connectionStrings /> section.");
				}
				this.ConnectionString = SimpleLayout.Escape(connectionStringSettings.ConnectionString);
				this.ProviderFactory = DbProviderFactories.GetFactory(connectionStringSettings.ProviderName);
				flag = true;
			}
			if (!flag)
			{
				foreach (object obj in DbProviderFactories.GetFactoryClasses().Rows)
				{
					DataRow dataRow = (DataRow)obj;
					if ((string)dataRow["InvariantName"] == this.DBProvider)
					{
						this.ProviderFactory = DbProviderFactories.GetFactory(this.DBProvider);
						flag = true;
					}
				}
			}
			if (!flag)
			{
				string text = this.DBProvider.ToUpper(CultureInfo.InvariantCulture);
				switch (text)
				{
				case "SQLSERVER":
				case "MSSQL":
				case "MICROSOFT":
				case "MSDE":
					this.ConnectionType = DatabaseTarget.systemDataAssembly.GetType("System.Data.SqlClient.SqlConnection", true);
					goto IL_220;
				case "OLEDB":
					this.ConnectionType = DatabaseTarget.systemDataAssembly.GetType("System.Data.OleDb.OleDbConnection", true);
					goto IL_220;
				case "ODBC":
					this.ConnectionType = DatabaseTarget.systemDataAssembly.GetType("System.Data.Odbc.OdbcConnection", true);
					goto IL_220;
				}
				this.ConnectionType = Type.GetType(this.DBProvider, true);
				IL_220:;
			}
		}

		/// <summary>
		/// Closes the target and releases any unmanaged resources.
		/// </summary>
		// Token: 0x06000889 RID: 2185 RVA: 0x0001DB8C File Offset: 0x0001BD8C
		protected override void CloseTarget()
		{
			base.CloseTarget();
			this.CloseConnection();
		}

		/// <summary>
		/// Writes the specified logging event to the database. It creates
		/// a new database command, prepares parameters for it by calculating
		/// layouts and executes the command.
		/// </summary>
		/// <param name="logEvent">The logging event.</param>
		// Token: 0x0600088A RID: 2186 RVA: 0x0001DBA0 File Offset: 0x0001BDA0
		protected override void Write(LogEventInfo logEvent)
		{
			try
			{
				this.WriteEventToDatabase(logEvent);
			}
			catch (Exception ex)
			{
				if (ex.MustBeRethrown())
				{
					throw;
				}
				InternalLogger.Error("Error when writing to database {0}", new object[] { ex });
				this.CloseConnection();
				throw;
			}
			finally
			{
				if (!this.KeepConnection)
				{
					this.CloseConnection();
				}
			}
		}

		/// <summary>
		/// Writes an array of logging events to the log target. By default it iterates on all
		/// events and passes them to "Write" method. Inheriting classes can use this method to
		/// optimize batch writes.
		/// </summary>
		/// <param name="logEvents">Logging events to be written out.</param>
		// Token: 0x0600088B RID: 2187 RVA: 0x0001DC44 File Offset: 0x0001BE44
		protected override void Write(AsyncLogEventInfo[] logEvents)
		{
			Dictionary<string, List<AsyncLogEventInfo>> dictionary = logEvents.BucketSort((AsyncLogEventInfo c) => this.BuildConnectionString(c.LogEvent));
			try
			{
				foreach (KeyValuePair<string, List<AsyncLogEventInfo>> keyValuePair in dictionary)
				{
					foreach (AsyncLogEventInfo asyncLogEventInfo in keyValuePair.Value)
					{
						try
						{
							this.WriteEventToDatabase(asyncLogEventInfo.LogEvent);
							asyncLogEventInfo.Continuation(null);
						}
						catch (Exception ex)
						{
							if (ex.MustBeRethrown())
							{
								throw;
							}
							InternalLogger.Error("Error when writing to database {0}", new object[] { ex });
							this.CloseConnection();
							asyncLogEventInfo.Continuation(ex);
						}
					}
				}
			}
			finally
			{
				if (!this.KeepConnection)
				{
					this.CloseConnection();
				}
			}
		}

		// Token: 0x0600088C RID: 2188 RVA: 0x0001DD94 File Offset: 0x0001BF94
		[SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities", Justification = "It's up to the user to ensure proper quoting.")]
		private void WriteEventToDatabase(LogEventInfo logEvent)
		{
			this.EnsureConnectionOpen(this.BuildConnectionString(logEvent));
			IDbCommand dbCommand = this.activeConnection.CreateCommand();
			dbCommand.CommandText = this.CommandText.Render(logEvent);
			InternalLogger.Trace("Executing {0}: {1}", new object[] { dbCommand.CommandType, dbCommand.CommandText });
			foreach (DatabaseParameterInfo databaseParameterInfo in this.Parameters)
			{
				IDbDataParameter dbDataParameter = dbCommand.CreateParameter();
				dbDataParameter.Direction = ParameterDirection.Input;
				if (databaseParameterInfo.Name != null)
				{
					dbDataParameter.ParameterName = databaseParameterInfo.Name;
				}
				if (databaseParameterInfo.Size != 0)
				{
					dbDataParameter.Size = databaseParameterInfo.Size;
				}
				if (databaseParameterInfo.Precision != 0)
				{
					dbDataParameter.Precision = databaseParameterInfo.Precision;
				}
				if (databaseParameterInfo.Scale != 0)
				{
					dbDataParameter.Scale = databaseParameterInfo.Scale;
				}
				string text = databaseParameterInfo.Layout.Render(logEvent);
				dbDataParameter.Value = text;
				dbCommand.Parameters.Add(dbDataParameter);
				InternalLogger.Trace("  Parameter: '{0}' = '{1}' ({2})", new object[] { dbDataParameter.ParameterName, dbDataParameter.Value, dbDataParameter.DbType });
			}
			int num = dbCommand.ExecuteNonQuery();
			InternalLogger.Trace("Finished execution, result = {0}", new object[] { num });
		}

		// Token: 0x0600088D RID: 2189 RVA: 0x0001DF68 File Offset: 0x0001C168
		private string BuildConnectionString(LogEventInfo logEvent)
		{
			string text;
			if (this.ConnectionString != null)
			{
				text = this.ConnectionString.Render(logEvent);
			}
			else
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append("Server=");
				stringBuilder.Append(this.DBHost.Render(logEvent));
				stringBuilder.Append(";");
				if (this.DBUserName == null)
				{
					stringBuilder.Append("Trusted_Connection=SSPI;");
				}
				else
				{
					stringBuilder.Append("User id=");
					stringBuilder.Append(this.DBUserName.Render(logEvent));
					stringBuilder.Append(";Password=");
					stringBuilder.Append(this.DBPassword.Render(logEvent));
					stringBuilder.Append(";");
				}
				if (this.DBDatabase != null)
				{
					stringBuilder.Append("Database=");
					stringBuilder.Append(this.DBDatabase.Render(logEvent));
				}
				text = stringBuilder.ToString();
			}
			return text;
		}

		// Token: 0x0600088E RID: 2190 RVA: 0x0001E06C File Offset: 0x0001C26C
		private void EnsureConnectionOpen(string connectionString)
		{
			if (this.activeConnection != null)
			{
				if (this.activeConnectionString != connectionString)
				{
					this.CloseConnection();
				}
			}
			if (this.activeConnection == null)
			{
				this.activeConnection = this.OpenConnection(connectionString);
				this.activeConnectionString = connectionString;
			}
		}

		// Token: 0x0600088F RID: 2191 RVA: 0x0001E0CC File Offset: 0x0001C2CC
		private void CloseConnection()
		{
			if (this.activeConnection != null)
			{
				this.activeConnection.Close();
				this.activeConnection = null;
				this.activeConnectionString = null;
			}
		}

		// Token: 0x06000890 RID: 2192 RVA: 0x0001E104 File Offset: 0x0001C304
		[SuppressMessage("Microsoft.Security", "CA2100:Review SQL queries for security vulnerabilities", Justification = "It's up to the user to ensure proper quoting.")]
		private void RunInstallCommands(InstallationContext installationContext, IEnumerable<DatabaseCommandInfo> commands)
		{
			LogEventInfo logEventInfo = installationContext.CreateLogEvent();
			try
			{
				foreach (DatabaseCommandInfo databaseCommandInfo in commands)
				{
					string text;
					if (databaseCommandInfo.ConnectionString != null)
					{
						text = databaseCommandInfo.ConnectionString.Render(logEventInfo);
					}
					else if (this.InstallConnectionString != null)
					{
						text = this.InstallConnectionString.Render(logEventInfo);
					}
					else
					{
						text = this.BuildConnectionString(logEventInfo);
					}
					this.EnsureConnectionOpen(text);
					IDbCommand dbCommand = this.activeConnection.CreateCommand();
					dbCommand.CommandType = databaseCommandInfo.CommandType;
					dbCommand.CommandText = databaseCommandInfo.Text.Render(logEventInfo);
					try
					{
						installationContext.Trace("Executing {0} '{1}'", new object[] { dbCommand.CommandType, dbCommand.CommandText });
						dbCommand.ExecuteNonQuery();
					}
					catch (Exception ex)
					{
						if (ex.MustBeRethrown())
						{
							throw;
						}
						if (!databaseCommandInfo.IgnoreFailures && !installationContext.IgnoreFailures)
						{
							installationContext.Error(ex.Message, new object[0]);
							throw;
						}
						installationContext.Warning(ex.Message, new object[0]);
					}
				}
			}
			finally
			{
				this.CloseConnection();
			}
		}

		// Token: 0x0400027E RID: 638
		private static Assembly systemDataAssembly = typeof(IDbConnection).Assembly;

		// Token: 0x0400027F RID: 639
		private IDbConnection activeConnection = null;

		// Token: 0x04000280 RID: 640
		private string activeConnectionString;
	}
}
