using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Crosire.Controlcenter.Classes
{
	internal class mysql
	{
		public static MySqlConnection Connection = new MySqlConnection();

		public static void Open()
		{
			if (Connection.State == ConnectionState.Closed)
			{
				Connection.Open();
			}
		}

		public static void Open(MySqlConnection con)
		{
			if (con.State == ConnectionState.Closed)
			{
				con.Open();
			}
		}

		public static void ChangeDatabase(string name)
		{
			if (!string.IsNullOrEmpty(name))
			{
				if (Connection.State == ConnectionState.Open)
				{
					Connection.ChangeDatabase(name);
				}
				return;
			}
			throw new ArgumentNullException("Database Name can not be null", "databaseName");
		}

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

		public static void Close()
		{
			if (Connection.State == ConnectionState.Open)
			{
				Connection.Close();
			}
		}

		public static void Close(MySqlConnection con)
		{
			if (con.State == ConnectionState.Open)
			{
				con.Close();
			}
		}
	}
}
