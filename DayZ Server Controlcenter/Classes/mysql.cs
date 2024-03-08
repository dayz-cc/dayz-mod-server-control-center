using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Crosire.Controlcenter.Classes
{
	// Token: 0x02000003 RID: 3
	internal class mysql
	{
		// Token: 0x0600001B RID: 27 RVA: 0x000069BC File Offset: 0x00004BBC
		public static void Open()
		{
			if (mysql.Connection.State == ConnectionState.Closed)
			{
				mysql.Connection.Open();
			}
		}

		// Token: 0x0600001C RID: 28 RVA: 0x000069EC File Offset: 0x00004BEC
		public static void Open(MySqlConnection con)
		{
			if (con.State == ConnectionState.Closed)
			{
				con.Open();
			}
		}

		// Token: 0x0600001D RID: 29 RVA: 0x00006A14 File Offset: 0x00004C14
		public static void ChangeDatabase(string name)
		{
			if (!string.IsNullOrEmpty(name))
			{
				if (mysql.Connection.State == ConnectionState.Open)
				{
					mysql.Connection.ChangeDatabase(name);
				}
				return;
			}
			throw new ArgumentNullException("Database Name can not be null", "databaseName");
		}

		// Token: 0x0600001E RID: 30 RVA: 0x00006A64 File Offset: 0x00004C64
		public static void ChangeDatabase(string name, MySqlConnection con)
		{
			if (!string.IsNullOrEmpty(name))
			{
				if (con.State == ConnectionState.Open)
				{
					con.ChangeDatabase(name);
				}
				return;
			}
			throw new ArgumentNullException("Database Name can not be null", "databaseName");
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00006AAC File Offset: 0x00004CAC
		public static void Close()
		{
			if (mysql.Connection.State == ConnectionState.Open)
			{
				mysql.Connection.Close();
			}
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00006ADC File Offset: 0x00004CDC
		public static void Close(MySqlConnection con)
		{
			if (con.State == ConnectionState.Open)
			{
				con.Close();
			}
		}

		// Token: 0x04000047 RID: 71
		public static MySqlConnection Connection = new MySqlConnection();
	}
}
