using System;
using BattleNET;
using MySql.Data.MySqlClient;
using NLog;

namespace Crosire.Controlcenter.Classes
{
	public class Whitelist
	{
		private static Logger logger = LogManager.GetCurrentClassLogger();

		public static bool VerifyPlayer(Player player, MySqlConnection connection)
		{
			bool result = false;
			try
			{
				mysql.Open(connection);
				MySqlCommand mySqlCommand = new MySqlCommand("SELECT * FROM `whitelist` WHERE `guid` = ?guid AND `is_whitelisted` = '1'", connection);
				mySqlCommand.Parameters.AddWithValue("?guid", player.guid);
				MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
				if (mySqlDataReader.HasRows)
				{
					mySqlDataReader.Close();
					result = true;
				}
				else
				{
					mySqlDataReader.Close();
					result = false;
				}
			}
			catch (Exception ex)
			{
				result = true;
				logger.Log(LogLevel.Error, "Excpetion:" + ex.ToString() + ":" + ex.Message);
			}
			finally
			{
				mysql.Close(connection);
			}
			return result;
		}

		public static void LogPlayer(Player player, bool whitelisted)
		{
			if (whitelisted)
			{
				logger.Log(LogLevel.Info, "Player:WL:" + player.name + ":" + player.guid);
			}
			else
			{
				logger.Log(LogLevel.Warn, "Player:NWL:" + player.name + ":" + player.guid);
			}
		}

		public static void KickPlayer(Player player, IBattleNET client, string message)
		{
			client.SendCommandPacket(EBattlEyeCommand.Kick, player.number + " " + string.Format(message, player.name, player.number, player.guid));
		}

		public static void WelcomePlayer(Player player, IBattleNET client, string message)
		{
			client.SendCommandPacket(EBattlEyeCommand.Say, "-1 " + string.Format(message, player.name, player.number, player.guid));
		}
	}
}
