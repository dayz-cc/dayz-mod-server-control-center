using System;
using BattleNET;
using MySql.Data.MySqlClient;
using NLog;

namespace Crosire.Controlcenter.Classes
{
	// Token: 0x02000007 RID: 7
	public class Whitelist
	{
		// Token: 0x0600002B RID: 43 RVA: 0x00006C08 File Offset: 0x00004E08
		public static bool VerifyPlayer(Player player, MySqlConnection connection)
		{
			bool flag = false;
			try
			{
				mysql.Open(connection);
				MySqlCommand mySqlCommand = new MySqlCommand("SELECT * FROM `whitelist` WHERE `guid` = ?guid AND `is_whitelisted` = '1'", connection);
				mySqlCommand.Parameters.AddWithValue("?guid", player.guid);
				MySqlDataReader mySqlDataReader = mySqlCommand.ExecuteReader();
				if (mySqlDataReader.HasRows)
				{
					mySqlDataReader.Close();
					flag = true;
				}
				else
				{
					mySqlDataReader.Close();
					flag = false;
				}
			}
			catch (Exception ex)
			{
				flag = true;
				Whitelist.logger.Log(LogLevel.Error, "Excpetion:" + ex.ToString() + ":" + ex.Message);
			}
			finally
			{
				mysql.Close(connection);
			}
			return flag;
		}

		// Token: 0x0600002C RID: 44 RVA: 0x00006CD8 File Offset: 0x00004ED8
		public static void LogPlayer(Player player, bool whitelisted)
		{
			if (whitelisted)
			{
				Whitelist.logger.Log(LogLevel.Info, "Player:WL:" + player.name + ":" + player.guid);
			}
			else
			{
				Whitelist.logger.Log(LogLevel.Warn, "Player:NWL:" + player.name + ":" + player.guid);
			}
		}

		// Token: 0x0600002D RID: 45 RVA: 0x00006D4A File Offset: 0x00004F4A
		public static void KickPlayer(Player player, IBattleNET client, string message)
		{
			client.SendCommandPacket(EBattlEyeCommand.Kick, player.number + " " + string.Format(message, player.name, player.number, player.guid));
		}

		// Token: 0x0600002E RID: 46 RVA: 0x00006D7D File Offset: 0x00004F7D
		public static void WelcomePlayer(Player player, IBattleNET client, string message)
		{
			client.SendCommandPacket(EBattlEyeCommand.Say, "-1 " + string.Format(message, player.name, player.number, player.guid));
		}

		// Token: 0x04000053 RID: 83
		private static Logger logger = LogManager.GetCurrentClassLogger();
	}
}
