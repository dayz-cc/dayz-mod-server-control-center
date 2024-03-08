using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Xml;
using Crosire.Controlcenter.Properties;
using Crosire.Library;
using Microsoft.Win32;
using MySql.Data.MySqlClient;
using NLog;

namespace Crosire.Controlcenter.Classes
{
	public class Configuration
	{
		public int confInstance = 0;

		public int confWorldId = 0;

		public string confWorld = string.Empty;

		public string confModlist = string.Empty;

		public int confAutoBackupInterval = 60;

		public bool confAutoBackupEnabled = false;

		public string confAutoBackupPath = string.Empty;

		public string confHostname = string.Empty;

		public string confPasswordServer = string.Empty;

		public string confPasswordAdmin = string.Empty;

		public int confMaxPlayers = 50;

		public bool confBattleye = true;

		public string confReportingIp = string.Empty;

		public string confMotd = string.Empty;

		public int confMotdInterval = 1;

		public bool confKickDuplicate = true;

		public int confVerifySignatures = 2;

		public string confRegularCheck = string.Empty;

		public string confRequiredBuild = string.Empty;

		public bool confVon = true;

		public int confVonQuality = 3;

		public bool confPersistent = true;

		public string confDoubleIdDetected = string.Empty;

		public string confOnUserConnected = string.Empty;

		public string confOnUserDisconnected = string.Empty;

		public string confOnUnsignedData = string.Empty;

		public string confOnHackedData = string.Empty;

		public string confOnDifferentData = string.Empty;

		public string confDifficulty = string.Empty;

		public string confTemplate = string.Empty;

		public bool confRmod = false;

		public int confTimezone = 0;

		public int confStaticHour = 12;

		public bool confDaytime = false;

		public int confSecureId = 1;

		public string confWelcome = string.Empty;

		public int confMaxCustomFileSize;

		public decimal confMinBandwidth;

		public decimal confMaxBandwidth;

		public decimal confMaxMsgSend;

		public decimal confMaxSizeGuaranteed;

		public decimal confMaxSizeNonguaranteed;

		public decimal confMinErrorToSend;

		public decimal confMinErrorToSendNear;

		public string dbHost = "127.0.0.1";

		public int dbPort = 3306;

		public string dbUser = string.Empty;

		public string dbPass = string.Empty;

		public string dbName = string.Empty;

		public string beHost = "127.0.0.1";

		public int bePort = 2302;

		public string bePass = string.Empty;

		public int beMaxPing = 300;

		public bool beWhitelistEnabled = false;

		public string beWhitelistMessage = string.Empty;

		public string beWhitelistHost = string.Empty;

		public int beWhitelistPort = 3306;

		public string beWhitelistUser = string.Empty;

		public string beWhitelistPass = string.Empty;

		public string beWhitelistName = string.Empty;

		public string pathArma = string.Empty;

		public string pathMain = string.Empty;

		public string pathConfig = string.Empty;

		public string pathConfigAdmin = string.Empty;

		public string pathConfigBasic = string.Empty;

		public string pathConfigBattleye = string.Empty;

		public string pathConfigCfg = string.Empty;

		public string pathConfigHive = string.Empty;

		public string pathConfigXml = string.Empty;

		private static Logger logger = LogManager.GetCurrentClassLogger();

		public Configuration()
		{
			if (string.IsNullOrEmpty(Settings.Default.workingDir))
			{
				RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey("SOFTWARE\\Bohemia Interactive Studio\\ArmA 2 OA");
				if (registryKey != null)
				{
					pathArma = registryKey.GetValue("MAIN").ToString();
					Settings.Default.workingDir = pathArma;
					Settings.Default.Save();
				}
			}
			else
			{
				pathArma = Settings.Default.workingDir;
			}
			if (!string.IsNullOrEmpty(pathArma))
			{
				pathMain = Path.Combine(pathArma, "@dayzcc");
				pathConfig = Path.Combine(pathArma, "@dayzcc_config");
			}
			pathConfigAdmin = string.Empty;
			pathConfigBasic = string.Empty;
			pathConfigBattleye = string.Empty;
			pathConfigCfg = string.Empty;
			pathConfigHive = string.Empty;
			pathConfigXml = string.Empty;
		}

		public Configuration(int instance)
		{
			confInstance = instance;
			if (string.IsNullOrEmpty(Settings.Default.workingDir))
			{
				RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32).OpenSubKey("SOFTWARE\\Bohemia Interactive Studio\\ArmA 2 OA");
				if (registryKey != null)
				{
					pathArma = registryKey.GetValue("MAIN").ToString();
					Settings.Default.workingDir = pathArma;
					Settings.Default.Save();
				}
			}
			else
			{
				pathArma = Settings.Default.workingDir;
			}
			if (!string.IsNullOrEmpty(pathArma))
			{
				pathMain = Path.Combine(pathArma, "@dayzcc");
				pathConfig = Path.Combine(pathArma, "@dayzcc_config", instance.ToString());
				pathConfigAdmin = Path.Combine(pathMain, "htdocs", "dayz", "config.php");
				pathConfigBasic = Path.Combine(pathConfig, "basic.cfg");
				pathConfigBattleye = CheckBattleyeConfig(Path.Combine(pathConfig, "BattlEye", "BEServer.cfg"));
				pathConfigCfg = Path.Combine(pathConfig, "config.cfg");
				pathConfigHive = Path.Combine(pathConfig, "HiveExt.ini");
				pathConfigXml = Path.Combine(pathConfig, "settings.xml");
			}
		}

		public string CheckBattleyeConfig(string path)
		{
			if (File.Exists(path))
			{
				return path;
			}
			string[] files = Directory.GetFiles(Path.GetDirectoryName(path), "*.cfg");
			foreach (string text in files)
			{
				if (Path.GetFileName(text).StartsWith("BEServer"))
				{
					return text;
				}
			}
			return string.Empty;
		}

		public bool LoadBasicConfig()
		{
			return LoadBasicConfig(pathConfigBasic);
		}

		public bool LoadBasicConfig(string path)
		{
			if (!string.IsNullOrEmpty(path) && File.Exists(path))
			{
				try
				{
					foreach (string item in File.ReadLines(path))
					{
						try
						{
							if (item.Trim().ToLower().StartsWith("maxcustomfilesize"))
							{
								confMaxCustomFileSize = Convert.ToInt32(Text.SubString(item, "=", ";").Replace(" ", ""));
							}
							else if (item.Trim().ToLower().StartsWith("minbandwidth"))
							{
								confMinBandwidth = decimal.Parse(Text.SubString(item, "=", ";").Replace(" ", ""), NumberStyles.Float, new CultureInfo("en-US"));
								if (confMinBandwidth > 9999999999m)
								{
									confMinBandwidth = 9999999999m;
								}
							}
							else if (item.Trim().ToLower().StartsWith("maxbandwidth"))
							{
								confMaxBandwidth = decimal.Parse(Text.SubString(item, "=", ";").Replace(" ", ""), NumberStyles.Float, new CultureInfo("en-US"));
								if (confMaxBandwidth > 9999999999m)
								{
									confMaxBandwidth = 9999999999m;
								}
							}
							else if (item.Trim().ToLower().StartsWith("maxmsgsend"))
							{
								confMaxMsgSend = decimal.Parse(Text.SubString(item, "=", ";").Replace(" ", ""), NumberStyles.Float, new CultureInfo("en-US"));
								if (confMaxMsgSend > 99999m)
								{
									confMaxMsgSend = 99999m;
								}
							}
							else if (item.Trim().ToLower().StartsWith("maxsizeguaranteed"))
							{
								confMaxSizeGuaranteed = decimal.Parse(Text.SubString(item, "=", ";").Replace(" ", ""), NumberStyles.Float, new CultureInfo("en-US"));
								if (confMaxSizeGuaranteed > 99999m)
								{
									confMaxSizeGuaranteed = 99999m;
								}
							}
							else if (item.Trim().ToLower().StartsWith("maxsizenonguaranteed"))
							{
								confMaxSizeNonguaranteed = decimal.Parse(Text.SubString(item, "=", ";").Replace(" ", ""), NumberStyles.Float, new CultureInfo("en-US"));
								if (confMaxSizeNonguaranteed > 99999m)
								{
									confMaxSizeNonguaranteed = 99999m;
								}
							}
							else if (item.Trim().ToLower().StartsWith("minerrortosend") && !item.Trim().ToLower().Contains("minerrortosendnear"))
							{
								confMinErrorToSend = decimal.Parse(Text.SubString(item, "=", ";").Replace(" ", ""), NumberStyles.Float, new CultureInfo("en-US"));
								decimal.Round(confMinErrorToSend, 10, MidpointRounding.AwayFromZero);
							}
							else if (item.Trim().ToLower().StartsWith("minerrortosendnear"))
							{
								confMinErrorToSendNear = decimal.Parse(Text.SubString(item, "=", ";").Replace(" ", ""), NumberStyles.Float, new CultureInfo("en-US"));
								decimal.Round(confMinErrorToSendNear, 10, MidpointRounding.AwayFromZero);
							}
						}
						catch (Exception ex)
						{
							logger.Log(LogLevel.Error, "LoadBasicConfig: " + ex.ToString() + "[" + ex.Message + "]");
						}
					}
					return true;
				}
				catch (Exception ex)
				{
					logger.Log(LogLevel.Fatal, "LoadBasicConfig: " + ex.ToString() + "[" + ex.Message + "]");
					return false;
				}
			}
			logger.Log(LogLevel.Warn, "LoadBasicConfig: File not found: \"" + path + "\"");
			return false;
		}

		public bool LoadBattleyeConfig()
		{
			return LoadBattleyeConfig(pathConfigBattleye);
		}

		public bool LoadBattleyeConfig(string path)
		{
			if (!string.IsNullOrEmpty(path) && File.Exists(path))
			{
				try
				{
					foreach (string item in File.ReadLines(path))
					{
						try
						{
							if (item.Trim().ToLower().StartsWith("maxping"))
							{
								beMaxPing = Convert.ToInt32(item.Remove(0, 8));
								if (beMaxPing > 999)
								{
									beMaxPing = 999;
								}
							}
							else if (item.Trim().ToLower().StartsWith("rconpassword"))
							{
								bePass = item.Remove(0, 13);
							}
						}
						catch (Exception ex)
						{
							logger.Log(LogLevel.Error, "LoadBattleyeConfig: " + ex.ToString() + "[" + ex.Message + "]");
						}
					}
					return true;
				}
				catch (Exception ex)
				{
					logger.Log(LogLevel.Fatal, "LoadBattleyeConfig: " + ex.ToString() + "[" + ex.Message + "]");
					return false;
				}
			}
			logger.Log(LogLevel.Warn, "LoadBattleyeConfig: File not found: \"" + path + "\"");
			return false;
		}

		public bool LoadCfgConfig()
		{
			return LoadCfgConfig(pathConfigCfg);
		}

		public bool LoadCfgConfig(string path)
		{
			if (!string.IsNullOrEmpty(path) && File.Exists(path))
			{
				try
				{
					foreach (string item in File.ReadLines(path))
					{
						try
						{
							if (item.Trim().ToLower().StartsWith("hostname"))
							{
								confHostname = Text.SubString(item, "\"", "\"");
							}
							else if (item.Trim().ToLower().StartsWith("password") && !item.Trim().ToLower().StartsWith("passwordadmin"))
							{
								confPasswordServer = Text.SubString(item, "\"", "\"");
							}
							else if (item.Trim().ToLower().StartsWith("passwordadmin"))
							{
								confPasswordAdmin = Text.SubString(item, "\"", "\"");
							}
							else if (item.Trim().ToLower().StartsWith("maxplayers"))
							{
								confMaxPlayers = Convert.ToInt32(Text.SubString(item, "=", ";").Replace(" ", ""));
								if (confMaxPlayers > 100)
								{
									confMaxPlayers = 100;
								}
							}
							else if (item.Trim().ToLower().StartsWith("battleye"))
							{
								confBattleye = Text.SubString(item, "=", ";").Replace(" ", "") == "1";
							}
							else if (item.Trim().ToLower().StartsWith("reportingip"))
							{
								confReportingIp = Text.SubString(item, "\"", "\"");
							}
							else if (item.Trim().ToLower().StartsWith("motd[]"))
							{
								confMotd = Text.SubString(item, "{", "}");
							}
							else if (item.Trim().ToLower().StartsWith("motdinterval"))
							{
								confMotdInterval = Convert.ToInt32(Text.SubString(item, "=", ";").Replace(" ", ""));
								if (confMotdInterval > 100)
								{
									confMotdInterval = 100;
								}
							}
							else if (item.Trim().ToLower().StartsWith("kickduplicate"))
							{
								confKickDuplicate = Text.SubString(item, "=", ";").Replace(" ", "") == "1";
							}
							else if (item.Trim().ToLower().StartsWith("verifysignatures"))
							{
								confVerifySignatures = Convert.ToInt32(Text.SubString(item, "=", ";").Replace(" ", ""));
							}
							else if (item.Trim().ToLower().StartsWith("regularcheck"))
							{
								confRegularCheck = Text.SubString(item, "\"", "\"");
							}
							else if (item.Trim().ToLower().StartsWith("requiredbuild"))
							{
								confRequiredBuild = Text.SubString(item, "=", ";").Replace(" ", "");
							}
							else if (item.Trim().ToLower().StartsWith("voncodecquality"))
							{
								confVonQuality = Convert.ToInt32(Text.SubString(item, "=", ";").Replace(" ", ""));
							}
							else if (item.Trim().ToLower().StartsWith("disablevon"))
							{
								confVon = Text.SubString(item, "=", ";").Replace(" ", "") == "0";
							}
							else if (item.Trim().ToLower().StartsWith("persistent"))
							{
								confPersistent = Text.SubString(item, "=", ";").Replace(" ", "") == "1";
							}
							else if (item.Trim().ToLower().StartsWith("doubleiddetected"))
							{
								confDoubleIdDetected = Text.SubString(item, "\"", "\"");
							}
							else if (item.Trim().ToLower().StartsWith("onuserconnected"))
							{
								confOnUserConnected = Text.SubString(item, "\"", "\"");
							}
							else if (item.Trim().ToLower().StartsWith("onuserdisconnected"))
							{
								confOnUserDisconnected = Text.SubString(item, "\"", "\"");
							}
							else if (item.Trim().ToLower().StartsWith("onunsigneddata"))
							{
								confOnUnsignedData = Text.SubString(item, "\"", "\"");
							}
							else if (item.Trim().ToLower().StartsWith("onhackeddata"))
							{
								confOnHackedData = Text.SubString(item, "\"", "\"");
							}
							else if (item.Trim().ToLower().StartsWith("ondifferentdata"))
							{
								confOnHackedData = Text.SubString(item, "\"", "\"");
							}
							else if (item.Trim().ToLower().StartsWith("difficulty"))
							{
								confDifficulty = Text.SubString(item, "\"", "\"");
							}
							else if (item.Trim().ToLower().StartsWith("template"))
							{
								confTemplate = Text.SubString(item, "=", ";").Replace(" ", "").Replace("\"", "");
								confRmod = item.ToLower().Contains("rmod");
							}
							else if (item.Trim().ToLower().StartsWith("requiredsecureid"))
							{
								confSecureId = Convert.ToInt32(Text.SubString(item, "=", ";").Replace(" ", ""));
							}
						}
						catch (Exception ex)
						{
							logger.Log(LogLevel.Error, "LoadCfgConfig: " + ex.ToString() + "[" + ex.Message + "]");
						}
					}
					return true;
				}
				catch (Exception ex)
				{
					logger.Log(LogLevel.Fatal, "LoadCfgConfig: " + ex.ToString() + "[" + ex.Message + "]");
					return false;
				}
			}
			logger.Log(LogLevel.Warn, "LoadCfgConfig: File not found: \"" + path + "\"");
			return false;
		}

		public bool LoadHiveConfig()
		{
			return LoadHiveConfig(pathConfigHive);
		}

		public bool LoadHiveConfig(string path)
		{
			if (!string.IsNullOrEmpty(path) && File.Exists(path))
			{
				try
				{
					if (Ini.Read(path, "Time", "Type").Replace(" ", "").ToLower() == "static")
					{
						confDaytime = true;
					}
					else
					{
						confDaytime = false;
					}
					confTimezone = Convert.ToInt32(Ini.Read(path, "Time", "Offset"));
					confStaticHour = Convert.ToInt32(Ini.Read(path, "Time", "Hour"));
					dbHost = Ini.Read(path, "Database", "Host");
					dbPort = Convert.ToInt32(Ini.Read(path, "Database", "Port"));
					dbUser = Ini.Read(path, "Database", "Username");
					dbPass = Ini.Read(path, "Database", "Password");
					dbName = Ini.Read(path, "Database", "Database");
					return true;
				}
				catch (Exception ex)
				{
					logger.Log(LogLevel.Fatal, "LoadHiveConfig: " + ex.ToString() + "[" + ex.Message + "]");
					return false;
				}
			}
			logger.Log(LogLevel.Warn, "LoadHiveConfig: File not found: \"" + path + "\"");
			return false;
		}

		public bool LoadXmlConfig()
		{
			return LoadXmlConfig(pathConfigXml);
		}

		public bool LoadXmlConfig(string path)
		{
			if (!string.IsNullOrEmpty(path) && File.Exists(path))
			{
				try
				{
					XmlDocument xmlDocument = new XmlDocument();
					xmlDocument.Load(path);
					foreach (XmlNode item in xmlDocument)
					{
						if (item.Name == "configuration")
						{
							foreach (XmlNode item2 in item)
							{
								if (item2.Name == "section" && item2.Attributes.Count == 1)
								{
									switch (item2.Attributes[0].Value)
									{
									case "General":
										foreach (XmlNode item3 in item2)
										{
											if (item3.Attributes.Count == 1)
											{
												switch (item3.Attributes[0].Value)
												{
												case "Mod":
													if (!string.IsNullOrEmpty(item3.InnerText))
													{
														confModlist = item3.InnerText;
													}
													else
													{
														confModlist = string.Empty;
													}
													break;
												case "Welcome":
													if (!string.IsNullOrEmpty(item3.InnerText))
													{
														confWelcome = item3.InnerText;
													}
													else
													{
														confWelcome = string.Empty;
													}
													break;
												}
											}
										}
										break;
									case "Backup":
										foreach (XmlNode item4 in item2)
										{
											if (item4.Attributes.Count == 1)
											{
												switch (item4.Attributes[0].Value)
												{
												case "Enabled":
													if (!string.IsNullOrEmpty(item4.InnerText))
													{
														confAutoBackupEnabled = Convert.ToBoolean(item4.InnerText);
													}
													else
													{
														confAutoBackupEnabled = false;
													}
													break;
												case "Interval":
													if (!string.IsNullOrEmpty(item4.InnerText))
													{
														confAutoBackupInterval = Convert.ToInt32(item4.InnerText);
													}
													else
													{
														confAutoBackupInterval = 60;
													}
													break;
												case "Path":
													if (!string.IsNullOrEmpty(item4.InnerText))
													{
														confAutoBackupPath = item4.InnerText;
													}
													else
													{
														confAutoBackupPath = string.Empty;
													}
													break;
												}
											}
										}
										break;
									case "Rcon":
										foreach (XmlNode item5 in item2)
										{
											if (item5.Attributes.Count == 1)
											{
												switch (item5.Attributes[0].Value)
												{
												case "Host":
													if (!string.IsNullOrEmpty(item5.InnerText))
													{
														beHost = item5.InnerText;
													}
													else
													{
														beHost = string.Empty;
													}
													break;
												case "Port":
													if (!string.IsNullOrEmpty(item5.InnerText))
													{
														bePort = Convert.ToInt32(item5.InnerText);
													}
													break;
												case "Pass":
													if (!string.IsNullOrEmpty(item5.InnerText))
													{
														bePass = item5.InnerText;
													}
													else
													{
														bePass = string.Empty;
													}
													break;
												}
											}
										}
										break;
									case "Whitelist":
										foreach (XmlNode item6 in item2)
										{
											if (item6.Attributes.Count == 1)
											{
												switch (item6.Attributes[0].Value)
												{
												case "Enabled":
													if (!string.IsNullOrEmpty(item6.InnerText))
													{
														beWhitelistEnabled = Convert.ToBoolean(item6.InnerText);
													}
													else
													{
														beWhitelistEnabled = false;
													}
													break;
												case "Host":
													if (!string.IsNullOrEmpty(item6.InnerText))
													{
														beWhitelistHost = item6.InnerText;
													}
													else
													{
														beWhitelistHost = string.Empty;
													}
													break;
												case "Port":
													if (!string.IsNullOrEmpty(item6.InnerText))
													{
														beWhitelistPort = Convert.ToInt32(item6.InnerText);
													}
													break;
												case "User":
													if (!string.IsNullOrEmpty(item6.InnerText))
													{
														beWhitelistUser = item6.InnerText;
													}
													else
													{
														beWhitelistUser = string.Empty;
													}
													break;
												case "Pass":
													if (!string.IsNullOrEmpty(item6.InnerText))
													{
														beWhitelistPass = item6.InnerText;
													}
													else
													{
														beWhitelistPass = string.Empty;
													}
													break;
												case "Name":
													if (!string.IsNullOrEmpty(item6.InnerText))
													{
														beWhitelistName = item6.InnerText;
													}
													else
													{
														beWhitelistName = string.Empty;
													}
													break;
												case "Message":
													if (!string.IsNullOrEmpty(item6.InnerText))
													{
														beWhitelistMessage = item6.InnerText;
													}
													else
													{
														beWhitelistMessage = string.Empty;
													}
													break;
												}
											}
										}
										break;
									}
								}
							}
						}
					}
					return true;
				}
				catch (Exception ex)
				{
					logger.Log(LogLevel.Fatal, "LoadXmlConfig: " + ex.ToString() + "[" + ex.Message + "]");
					return false;
				}
			}
			logger.Log(LogLevel.Warn, "LoadXmlConfig: File not found: \"" + path + "\"");
			return false;
		}

		public bool WriteBasicConfig()
		{
			return WriteBasicConfig(pathConfigBasic);
		}

		public bool WriteBasicConfig(string path)
		{
			if (!string.IsNullOrEmpty(path) && File.Exists(path))
			{
				try
				{
					string[] array = File.ReadAllLines(path);
					for (int i = 0; i < array.Length; i++)
					{
						try
						{
							if (array[i].Trim().ToLower().StartsWith("maxcustomfilesize"))
							{
								if (!string.IsNullOrEmpty(Text.SubString(array[i].Replace(" ", ""), "=", ";")))
								{
									array[i] = array[i].Replace(Text.SubString(array[i], "=", ";").Replace(" ", ""), confMaxCustomFileSize.ToString());
								}
								else
								{
									array[i] = "MaxCustomFileSize=" + confMaxCustomFileSize + ";";
								}
							}
							else if (array[i].Trim().ToLower().StartsWith("minbandwidth"))
							{
								if (!string.IsNullOrEmpty(Text.SubString(array[i].Replace(" ", ""), "=", ";")))
								{
									array[i] = array[i].Replace(Text.SubString(array[i], "=", ";").Replace(" ", ""), confMinBandwidth.ToString().Replace(",", "."));
								}
								else
								{
									array[i] = "MinBandwidth=" + confMinBandwidth.ToString().Replace(",", ".") + ";";
								}
							}
							else if (array[i].Trim().ToLower().StartsWith("maxbandwidth"))
							{
								if (!string.IsNullOrEmpty(Text.SubString(array[i].Replace(" ", ""), "=", ";")))
								{
									array[i] = array[i].Replace(Text.SubString(array[i], "=", ";").Replace(" ", ""), confMaxBandwidth.ToString().Replace(",", "."));
								}
								else
								{
									array[i] = "MaxBandwidth=" + confMaxBandwidth.ToString().Replace(",", ".") + ";";
								}
							}
							else if (array[i].Trim().ToLower().StartsWith("maxmsgsend"))
							{
								if (!string.IsNullOrEmpty(Text.SubString(array[i].Replace(" ", ""), "=", ";")))
								{
									array[i] = array[i].Replace(Text.SubString(array[i], "=", ";").Replace(" ", ""), confMaxMsgSend.ToString().Replace(",", "."));
								}
								else
								{
									array[i] = "MaxMsgSend=" + confMaxMsgSend.ToString().Replace(",", ".") + ";";
								}
							}
							else if (array[i].Trim().ToLower().StartsWith("maxsizeguaranteed"))
							{
								if (!string.IsNullOrEmpty(Text.SubString(array[i].Replace(" ", ""), "=", ";")))
								{
									array[i] = array[i].Replace(Text.SubString(array[i], "=", ";").Replace(" ", ""), confMaxSizeGuaranteed.ToString().Replace(",", "."));
								}
								else
								{
									array[i] = "MaxSizeGuaranteed=" + confMaxSizeGuaranteed.ToString().Replace(",", ".") + ";";
								}
							}
							else if (array[i].Trim().ToLower().StartsWith("maxsizenonguaranteed"))
							{
								if (!string.IsNullOrEmpty(Text.SubString(array[i].Replace(" ", ""), "=", ";")))
								{
									array[i] = array[i].Replace(Text.SubString(array[i], "=", ";").Replace(" ", ""), confMaxSizeNonguaranteed.ToString().Replace(",", "."));
								}
								else
								{
									array[i] = "MaxSizeNonguaranteed=" + confMaxSizeNonguaranteed.ToString().Replace(",", ".") + ";";
								}
							}
							else if (array[i].Trim().ToLower().StartsWith("minerrortosend"))
							{
								if (!string.IsNullOrEmpty(Text.SubString(array[i].Replace(" ", ""), "=", ";")))
								{
									array[i] = array[i].Replace(Text.SubString(array[i], "=", ";").Replace(" ", ""), confMinErrorToSend.ToString().Replace(",", "."));
								}
								else
								{
									array[i] = "MinErrorToSend=" + confMinErrorToSend.ToString().Replace(",", ".") + ";";
								}
							}
							else if (array[i].Trim().ToLower().StartsWith("minerrortosendnear"))
							{
								if (!string.IsNullOrEmpty(Text.SubString(array[i].Replace(" ", ""), "=", ";")))
								{
									array[i] = array[i].Replace(Text.SubString(array[i], "=", ";").Replace(" ", ""), confMinErrorToSendNear.ToString().Replace(",", "."));
								}
								else
								{
									array[i] = "MinErrorToSendNear=" + confMinErrorToSendNear.ToString().Replace(",", ".") + ";";
								}
							}
						}
						catch (Exception ex)
						{
							logger.Log(LogLevel.Error, "WriteBasicConfig: " + ex.ToString() + "[" + ex.Message + "]");
						}
					}
					File.WriteAllLines(path, array);
					return true;
				}
				catch (Exception ex)
				{
					logger.Log(LogLevel.Fatal, "WriteBasicConfig: " + ex.ToString() + "[" + ex.Message + "]");
					return false;
				}
			}
			logger.Log(LogLevel.Warn, "WriteBasicConfig: File not found: \"" + path + "\"");
			return false;
		}

		public bool WriteBattleyeConfig()
		{
			return WriteBattleyeConfig(pathConfigBattleye);
		}

		public bool WriteBattleyeConfig(string path)
		{
			if (!string.IsNullOrEmpty(path) && File.Exists(path))
			{
				try
				{
					string[] array = File.ReadAllLines(path);
					for (int i = 0; i < array.Length; i++)
					{
						try
						{
							if (array[i].Trim().ToLower().StartsWith("maxping"))
							{
								array[i] = "MaxPing " + beMaxPing;
							}
							else if (array[i].Trim().ToLower().StartsWith("rconpassword"))
							{
								array[i] = "RConPassword " + bePass;
							}
						}
						catch (Exception ex)
						{
							logger.Log(LogLevel.Error, "WriteBattleyeConfig: " + ex.ToString() + "[" + ex.Message + "]");
						}
					}
					File.WriteAllLines(path, array);
					return true;
				}
				catch (Exception ex)
				{
					logger.Log(LogLevel.Fatal, "WriteBattleyeConfig: " + ex.ToString() + "[" + ex.Message + "]");
					return false;
				}
			}
			logger.Log(LogLevel.Warn, "WriteBattleyeConfig: File not found: \"" + path + "\"");
			return false;
		}

		public bool WriteCfgConfig()
		{
			return WriteCfgConfig(pathConfigCfg);
		}

		public bool WriteCfgConfig(string path)
		{
			if (!string.IsNullOrEmpty(path) && File.Exists(path))
			{
				try
				{
					string[] array = File.ReadAllLines(path);
					for (int i = 0; i < array.Length; i++)
					{
						try
						{
							if (array[i].Trim().ToLower().StartsWith("hostname"))
							{
								if (!string.IsNullOrEmpty(Text.SubString(array[i].Replace(" ", ""), "\"", "\"")) || Text.SubString(array[i].Replace(" ", ""), "\"", "\"").ToLower() == "hostname")
								{
									array[i] = array[i].Replace(Text.SubString(array[i], "\"", "\""), confHostname);
								}
								else
								{
									array[i] = "hostname=\"" + confHostname + "\";";
								}
							}
							else if (array[i].Trim().ToLower().StartsWith("password") && !array[i].Trim().ToLower().StartsWith("passwordadmin"))
							{
								if (!string.IsNullOrEmpty(Text.SubString(array[i].Replace(" ", ""), "\"", "\"")) || Text.SubString(array[i].Replace(" ", ""), "\"", "\"").ToLower() == "password")
								{
									array[i] = array[i].Replace(Text.SubString(array[i], "\"", "\""), confPasswordServer);
								}
								else
								{
									array[i] = "password=\"" + confPasswordServer + "\";";
								}
							}
							else if (array[i].Trim().ToLower().StartsWith("passwordadmin"))
							{
								if (!string.IsNullOrEmpty(Text.SubString(array[i].Replace(" ", ""), "\"", "\"")) || Text.SubString(array[i].Replace(" ", ""), "\"", "\"").ToLower() == "passwordadmin")
								{
									array[i] = array[i].Replace(Text.SubString(array[i], "\"", "\""), confPasswordAdmin);
								}
								else
								{
									array[i] = "passwordAdmin=\"" + confPasswordAdmin + "\";";
								}
							}
							else if (array[i].Trim().ToLower().StartsWith("maxplayers"))
							{
								if (!string.IsNullOrEmpty(Text.SubString(array[i].Replace(" ", ""), "=", ";")))
								{
									array[i] = array[i].Replace(Text.SubString(array[i], "=", ";").Replace(" ", ""), confMaxPlayers.ToString());
								}
								else
								{
									array[i] = "maxPlayers=" + confMaxPlayers + ";";
								}
							}
							else if (array[i].Trim().ToLower().StartsWith("battleye"))
							{
								if (!string.IsNullOrEmpty(Text.SubString(array[i].Replace(" ", ""), "=", ";")))
								{
									array[i] = array[i].Replace(Text.SubString(array[i], "=", ";").Replace(" ", ""), confBattleye ? "1" : "0");
								}
								else
								{
									array[i] = "BattlEye=" + (confBattleye ? "1" : "0") + ";";
								}
							}
							else if (array[i].Trim().ToLower().StartsWith("reportingip"))
							{
								if (!string.IsNullOrEmpty(Text.SubString(array[i].Replace(" ", ""), "\"", "\"")))
								{
									array[i] = array[i].Replace(Text.SubString(array[i], "\"", "\"").Replace(" ", ""), confReportingIp);
								}
								else
								{
									array[i] = "reportingIP=\"" + confReportingIp + "\";";
								}
							}
							else if (array[i].Trim().ToLower().StartsWith("motd[]"))
							{
								if (!string.IsNullOrEmpty(Text.SubString(array[i].Replace(" ", "").Replace("\"", ""), "{", "}")) || Text.SubString(array[i].Replace("\"", ""), "{", "}").ToLower() == "motd[]")
								{
									array[i] = array[i].Replace(Text.SubString(array[i], "{", "}"), confMotd);
								}
								else
								{
									array[i] = "motd[]={" + confMotd + "};";
								}
							}
							else if (array[i].Trim().ToLower().StartsWith("motdinterval"))
							{
								if (!string.IsNullOrEmpty(Text.SubString(array[i].Replace(" ", ""), "=", ";")))
								{
									array[i] = array[i].Replace(Text.SubString(array[i], "=", ";").Replace(" ", ""), confMotdInterval.ToString());
								}
								else
								{
									array[i] = "motdInterval=" + confMotdInterval + ";";
								}
							}
							else if (array[i].Trim().ToLower().StartsWith("kickduplicate"))
							{
								if (!string.IsNullOrEmpty(Text.SubString(array[i].Replace(" ", ""), "=", ";")))
								{
									array[i] = array[i].Replace(Text.SubString(array[i], "=", ";").Replace(" ", ""), confKickDuplicate ? "1" : "0");
								}
								else
								{
									array[i] = "kickduplicate=" + (confKickDuplicate ? "1" : "0") + ";";
								}
							}
							else if (array[i].Trim().ToLower().StartsWith("verifysignatures"))
							{
								if (!string.IsNullOrEmpty(Text.SubString(array[i].Replace(" ", ""), "=", ";")))
								{
									array[i] = array[i].Replace(Text.SubString(array[i], "=", ";").Replace(" ", ""), confVerifySignatures.ToString());
								}
								else
								{
									array[i] = "verifySignatures=" + confVerifySignatures + ";";
								}
							}
							else if (array[i].Trim().ToLower().StartsWith("regularcheck"))
							{
								if (!string.IsNullOrEmpty(Text.SubString(array[i].Replace(" ", ""), "\"", "\"")) || Text.SubString(array[i].Replace(" ", ""), "\"", "\"").ToLower() == "regularcheck")
								{
									array[i] = array[i].Replace(Text.SubString(array[i], "\"", "\""), confRegularCheck);
								}
								else
								{
									array[i] = "regularCheck=\"" + confRegularCheck + "\";";
								}
							}
							else if (array[i].Trim().ToLower().StartsWith("requiredbuild"))
							{
								if (!string.IsNullOrEmpty(Text.SubString(array[i].Replace(" ", ""), "=", ";")))
								{
									array[i] = array[i].Replace(Text.SubString(array[i], "=", ";").Replace(" ", ""), confRequiredBuild);
								}
								else
								{
									array[i] = "requiredBuild=" + confRequiredBuild + ";";
								}
							}
							else if (array[i].Trim().ToLower().StartsWith("voncodecquality"))
							{
								if (!string.IsNullOrEmpty(Text.SubString(array[i].Replace(" ", ""), "=", ";")))
								{
									array[i] = array[i].Replace(Text.SubString(array[i], "=", ";").Replace(" ", ""), confVonQuality.ToString());
								}
								else
								{
									array[i] = "vonCodecQuality=" + confVonQuality + ";";
								}
							}
							else if (array[i].Trim().ToLower().StartsWith("disablevon"))
							{
								if (!string.IsNullOrEmpty(Text.SubString(array[i].Replace(" ", ""), "=", ";")))
								{
									array[i] = array[i].Replace(Text.SubString(array[i], "=", ";").Replace(" ", ""), confVon ? "0" : "1");
								}
								else
								{
									array[i] = "disableVoN=" + (confVon ? "0" : "1") + ";";
								}
							}
							else if (array[i].Trim().ToLower().StartsWith("persistent"))
							{
								if (!string.IsNullOrEmpty(Text.SubString(array[i].Replace(" ", ""), "=", ";")))
								{
									array[i] = array[i].Replace(Text.SubString(array[i], "=", ";").Replace(" ", ""), confPersistent ? "1" : "0");
								}
								else
								{
									array[i] = "persistent=" + (confPersistent ? "1" : "0") + ";";
								}
							}
							else if (array[i].Trim().ToLower().StartsWith("doubleiddetected"))
							{
								if (!string.IsNullOrEmpty(Text.SubString(array[i].Replace(" ", ""), "\"", "\"")) || Text.SubString(array[i].Replace(" ", ""), "\"", "\"").ToLower() == "doubleiddetected")
								{
									array[i] = array[i].Replace(Text.SubString(array[i], "\"", "\"").Replace(" ", ""), confDoubleIdDetected);
								}
								else
								{
									array[i] = "doubleIdDetected=\"" + confDoubleIdDetected + "\";";
								}
							}
							else if (array[i].Trim().ToLower().StartsWith("onuserconnected"))
							{
								if (!string.IsNullOrEmpty(Text.SubString(array[i].Replace(" ", ""), "\"", "\"")) || Text.SubString(array[i].Replace(" ", ""), "\"", "\"").ToLower() == "onuserconnected")
								{
									array[i] = array[i].Replace(Text.SubString(array[i], "\"", "\""), confOnUserConnected);
								}
								else
								{
									array[i] = "onUserConnected=\"" + confOnUserConnected + "\";";
								}
							}
							else if (array[i].Trim().ToLower().StartsWith("onuserdisconnected"))
							{
								if (!string.IsNullOrEmpty(Text.SubString(array[i].Replace(" ", ""), "\"", "\"")) || Text.SubString(array[i].Replace(" ", ""), "\"", "\"").ToLower() == "onuserdisconnected")
								{
									array[i] = array[i].Replace(Text.SubString(array[i], "\"", "\""), confOnUserDisconnected);
								}
								else
								{
									array[i] = "onUserDisconnected=\"" + confOnUserDisconnected + "\";";
								}
							}
							else if (array[i].Trim().ToLower().StartsWith("onunsigneddata"))
							{
								if (!string.IsNullOrEmpty(Text.SubString(array[i].Replace(" ", ""), "\"", "\"")) || Text.SubString(array[i].Replace(" ", ""), "\"", "\"").ToLower() == "onunsigneddata")
								{
									array[i] = array[i].Replace(Text.SubString(array[i], "\"", "\""), confOnUnsignedData);
								}
								else
								{
									array[i] = "onUnsignedData=\"" + confOnUnsignedData + "\";";
								}
							}
							else if (array[i].Trim().ToLower().StartsWith("onhackeddata"))
							{
								if (!string.IsNullOrEmpty(Text.SubString(array[i].Replace(" ", ""), "\"", "\"")) || Text.SubString(array[i].Replace(" ", ""), "\"", "\"").ToLower() == "onhackeddata")
								{
									array[i] = array[i].Replace(Text.SubString(array[i], "\"", "\""), confOnHackedData);
								}
								else
								{
									array[i] = "onHackedData=\"" + confOnHackedData + "\";";
								}
							}
							else if (array[i].Trim().ToLower().StartsWith("ondifferentdata"))
							{
								if (!string.IsNullOrEmpty(Text.SubString(array[i].Replace(" ", ""), "\"", "\"")) || Text.SubString(array[i].Replace(" ", ""), "\"", "\"").ToLower() == "ondifferentdata")
								{
									array[i] = array[i].Replace(Text.SubString(array[i], "\"", "\""), confOnDifferentData);
								}
								else
								{
									array[i] = "onDifferentData=\"" + confOnDifferentData + "\";";
								}
							}
							else if (array[i].Trim().ToLower().StartsWith("difficulty"))
							{
								if (!string.IsNullOrEmpty(Text.SubString(array[i].Replace(" ", ""), "\"", "\"")) || Text.SubString(array[i].Replace(" ", ""), "\"", "\"").ToLower() == "difficulty")
								{
									array[i] = array[i].Replace(Text.SubString(array[i], "\"", "\""), confDifficulty);
								}
								else
								{
									array[i] = "difficulty=\"" + confDifficulty + "\";";
								}
							}
							else if (array[i].Trim().ToLower().StartsWith("template"))
							{
								if (array[i].Contains("\""))
								{
									if (!string.IsNullOrEmpty(Text.SubString(array[i].Replace(" ", ""), "\"", "\"")) || Text.SubString(array[i].Replace(" ", ""), "\"", "\"").ToLower() == "template")
									{
										array[i] = array[i].Replace(Text.SubString(array[i], "\"", "\""), confTemplate);
									}
									else
									{
										array[i] = "template=\"" + confTemplate + "\";";
									}
								}
								else if (!string.IsNullOrEmpty(Text.SubString(array[i].Replace(" ", ""), "=", ";")) || Text.SubString(array[i].Replace(" ", ""), "=", ";").ToLower() == "template")
								{
									array[i] = array[i].Replace(Text.SubString(array[i], "=", ";"), confTemplate);
								}
								else
								{
									array[i] = "template=" + confTemplate + ";";
								}
							}
							else if (array[i].Trim().ToLower().StartsWith("requiredsecureid"))
							{
								if (!string.IsNullOrEmpty(Text.SubString(array[i].Replace(" ", ""), "=", ";")))
								{
									array[i] = array[i].Replace(Text.SubString(array[i], "=", ";").Replace(" ", ""), confSecureId.ToString());
								}
								else
								{
									array[i] = "requireSecureId=" + confSecureId + ";";
								}
							}
						}
						catch (Exception ex)
						{
							logger.Log(LogLevel.Error, "WriteCfgConfig: " + ex.ToString() + "[" + ex.Message + "]");
						}
					}
					File.WriteAllLines(path, array);
					return true;
				}
				catch (Exception ex)
				{
					logger.Log(LogLevel.Fatal, "WriteCfgConfig: " + ex.ToString() + "[" + ex.Message + "]");
					return false;
				}
			}
			logger.Log(LogLevel.Warn, "WriteCfgConfig: File not found: \"" + path + "\"");
			return false;
		}

		public bool WriteHiveConfig()
		{
			return WriteHiveConfig(pathConfigHive);
		}

		public bool WriteHiveConfig(string path)
		{
			if (!string.IsNullOrEmpty(path) && File.Exists(path))
			{
				try
				{
					if (confDaytime)
					{
						Ini.Write(path, "Time", "Type", "Static");
					}
					else if (confTimezone == 0)
					{
						Ini.Write(path, "Time", "Type", "Local");
					}
					else
					{
						Ini.Write(path, "Time", "Type", "Custom");
					}
					Ini.Write(path, "Time", "Offset", confTimezone.ToString());
					Ini.Write(path, "Time", "Hour", confStaticHour.ToString());
					Ini.Write(path, "Database", "Host", dbHost);
					Ini.Write(path, "Database", "Port", dbPort.ToString());
					Ini.Write(path, "Database", "Username", dbUser);
					Ini.Write(path, "Database", "Password", dbPass);
					Ini.Write(path, "Database", "Database", dbName);
					return true;
				}
				catch (Exception ex)
				{
					logger.Log(LogLevel.Fatal, "WriteHiveConfig: " + ex.ToString() + "[" + ex.Message + "]");
					return false;
				}
			}
			logger.Log(LogLevel.Warn, "WriteHiveConfig: File not found: \"" + path + "\"");
			return false;
		}

		public bool WriteXmlConfig()
		{
			return WriteXmlConfig(pathConfigXml);
		}

		public bool WriteXmlConfig(string path)
		{
			if (!string.IsNullOrEmpty(path))
			{
				try
				{
					XmlTextWriter xmlTextWriter = new XmlTextWriter(path, Encoding.Unicode);
					xmlTextWriter.Formatting = Formatting.Indented;
					xmlTextWriter.Indentation = 4;
					xmlTextWriter.WriteStartDocument();
					xmlTextWriter.WriteStartElement("configuration");
					xmlTextWriter.WriteStartElement("section");
					xmlTextWriter.WriteAttributeString("id", "General");
					xmlTextWriter.WriteStartElement("setting");
					xmlTextWriter.WriteAttributeString("id", "Mod");
					xmlTextWriter.WriteString(confModlist);
					xmlTextWriter.WriteEndElement();
					xmlTextWriter.WriteStartElement("setting");
					xmlTextWriter.WriteAttributeString("id", "Welcome");
					xmlTextWriter.WriteString(confWelcome);
					xmlTextWriter.WriteEndElement();
					xmlTextWriter.WriteEndElement();
					xmlTextWriter.WriteStartElement("section");
					xmlTextWriter.WriteAttributeString("id", "Backup");
					xmlTextWriter.WriteStartElement("setting");
					xmlTextWriter.WriteAttributeString("id", "Enabled");
					xmlTextWriter.WriteString(confAutoBackupEnabled.ToString());
					xmlTextWriter.WriteEndElement();
					xmlTextWriter.WriteStartElement("setting");
					xmlTextWriter.WriteAttributeString("id", "Interval");
					xmlTextWriter.WriteString(confAutoBackupInterval.ToString());
					xmlTextWriter.WriteEndElement();
					xmlTextWriter.WriteStartElement("setting");
					xmlTextWriter.WriteAttributeString("id", "Path");
					xmlTextWriter.WriteString(confAutoBackupPath);
					xmlTextWriter.WriteEndElement();
					xmlTextWriter.WriteEndElement();
					xmlTextWriter.WriteStartElement("section");
					xmlTextWriter.WriteAttributeString("id", "Rcon");
					xmlTextWriter.WriteStartElement("setting");
					xmlTextWriter.WriteAttributeString("id", "Host");
					xmlTextWriter.WriteString(beHost);
					xmlTextWriter.WriteEndElement();
					xmlTextWriter.WriteStartElement("setting");
					xmlTextWriter.WriteAttributeString("id", "Port");
					xmlTextWriter.WriteString(bePort.ToString());
					xmlTextWriter.WriteEndElement();
					xmlTextWriter.WriteStartElement("setting");
					xmlTextWriter.WriteAttributeString("id", "Pass");
					xmlTextWriter.WriteString(bePass);
					xmlTextWriter.WriteEndElement();
					xmlTextWriter.WriteEndElement();
					xmlTextWriter.WriteStartElement("section");
					xmlTextWriter.WriteAttributeString("id", "Whitelist");
					xmlTextWriter.WriteStartElement("setting");
					xmlTextWriter.WriteAttributeString("id", "Enabled");
					xmlTextWriter.WriteString(beWhitelistEnabled.ToString());
					xmlTextWriter.WriteEndElement();
					xmlTextWriter.WriteStartElement("setting");
					xmlTextWriter.WriteAttributeString("id", "Host");
					xmlTextWriter.WriteString(beWhitelistHost);
					xmlTextWriter.WriteEndElement();
					xmlTextWriter.WriteStartElement("setting");
					xmlTextWriter.WriteAttributeString("id", "Port");
					xmlTextWriter.WriteString(beWhitelistPort.ToString());
					xmlTextWriter.WriteEndElement();
					xmlTextWriter.WriteStartElement("setting");
					xmlTextWriter.WriteAttributeString("id", "User");
					xmlTextWriter.WriteString(beWhitelistUser);
					xmlTextWriter.WriteEndElement();
					xmlTextWriter.WriteStartElement("setting");
					xmlTextWriter.WriteAttributeString("id", "Pass");
					xmlTextWriter.WriteString(beWhitelistPass);
					xmlTextWriter.WriteEndElement();
					xmlTextWriter.WriteStartElement("setting");
					xmlTextWriter.WriteAttributeString("id", "Name");
					xmlTextWriter.WriteString(beWhitelistName);
					xmlTextWriter.WriteEndElement();
					xmlTextWriter.WriteStartElement("setting");
					xmlTextWriter.WriteAttributeString("id", "Message");
					xmlTextWriter.WriteString(beWhitelistMessage);
					xmlTextWriter.WriteEndElement();
					xmlTextWriter.WriteEndElement();
					xmlTextWriter.WriteEndElement();
					xmlTextWriter.Close();
					return true;
				}
				catch (Exception ex)
				{
					logger.Log(LogLevel.Fatal, "WriteXmlConfig: " + ex.ToString() + "[" + ex.Message + "]");
					return false;
				}
			}
			logger.Log(LogLevel.Warn, "WriteHiveXml: File not found: \"" + path + "\"");
			return false;
		}

		public int GetWorldId()
		{
			return GetWorldId(confWorld);
		}

		public int GetWorldId(string world)
		{
			int result = 0;
			MySqlConnection mySqlConnection = mysql.Connection;
			if (string.IsNullOrEmpty(mySqlConnection.ConnectionString))
			{
				mySqlConnection = new MySqlConnection($"server={dbHost};port={dbPort.ToString()};user={dbUser};password={dbPass};");
			}
			try
			{
				mysql.Open(mySqlConnection);
				mysql.ChangeDatabase(dbName, mySqlConnection);
				MySqlDataReader mySqlDataReader = new MySqlCommand("SELECT * FROM `world`", mySqlConnection).ExecuteReader();
				while (mySqlDataReader.Read())
				{
					if (mySqlDataReader.GetString("name").ToLower() == world.ToLower())
					{
						result = mySqlDataReader.GetInt32("id");
					}
				}
				mySqlDataReader.Close();
			}
			catch (MySqlException ex)
			{
				logger.Log(LogLevel.Error, "GetWorldId: " + ex.ToString() + "[" + ex.Message + "]");
			}
			finally
			{
				mysql.Close(mySqlConnection);
			}
			return result;
		}
	}
}
