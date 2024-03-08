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
	// Token: 0x02000002 RID: 2
	public class Configuration
	{
		// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
		public Configuration()
		{
			if (string.IsNullOrEmpty(Settings.Default.workingDir))
			{
				RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, 512).OpenSubKey("SOFTWARE\\Bohemia Interactive Studio\\ArmA 2 OA");
				if (registryKey != null)
				{
					this.pathArma = registryKey.GetValue("MAIN").ToString();
					Settings.Default.workingDir = this.pathArma;
					Settings.Default.Save();
				}
			}
			else
			{
				this.pathArma = Settings.Default.workingDir;
			}
			if (!string.IsNullOrEmpty(this.pathArma))
			{
				this.pathMain = Path.Combine(this.pathArma, "@dayzcc");
				this.pathConfig = Path.Combine(this.pathArma, "@dayzcc_config");
			}
			this.pathConfigAdmin = string.Empty;
			this.pathConfigBasic = string.Empty;
			this.pathConfigBattleye = string.Empty;
			this.pathConfigCfg = string.Empty;
			this.pathConfigHive = string.Empty;
			this.pathConfigXml = string.Empty;
		}

		// Token: 0x06000002 RID: 2 RVA: 0x000023C4 File Offset: 0x000005C4
		public Configuration(int instance)
		{
			this.confInstance = instance;
			if (string.IsNullOrEmpty(Settings.Default.workingDir))
			{
				RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, 512).OpenSubKey("SOFTWARE\\Bohemia Interactive Studio\\ArmA 2 OA");
				if (registryKey != null)
				{
					this.pathArma = registryKey.GetValue("MAIN").ToString();
					Settings.Default.workingDir = this.pathArma;
					Settings.Default.Save();
				}
			}
			else
			{
				this.pathArma = Settings.Default.workingDir;
			}
			if (!string.IsNullOrEmpty(this.pathArma))
			{
				this.pathMain = Path.Combine(this.pathArma, "@dayzcc");
				this.pathConfig = Path.Combine(this.pathArma, "@dayzcc_config", instance.ToString());
				this.pathConfigAdmin = Path.Combine(this.pathMain, "htdocs", "dayz", "config.php");
				this.pathConfigBasic = Path.Combine(this.pathConfig, "basic.cfg");
				this.pathConfigBattleye = this.CheckBattleyeConfig(Path.Combine(this.pathConfig, "BattlEye", "BEServer.cfg"));
				this.pathConfigCfg = Path.Combine(this.pathConfig, "config.cfg");
				this.pathConfigHive = Path.Combine(this.pathConfig, "HiveExt.ini");
				this.pathConfigXml = Path.Combine(this.pathConfig, "settings.xml");
			}
		}

		// Token: 0x06000003 RID: 3 RVA: 0x000027A0 File Offset: 0x000009A0
		public string CheckBattleyeConfig(string path)
		{
			string text;
			if (File.Exists(path))
			{
				text = path;
			}
			else
			{
				foreach (string text2 in Directory.GetFiles(Path.GetDirectoryName(path), "*.cfg"))
				{
					if (Path.GetFileName(text2).StartsWith("BEServer"))
					{
						return text2;
					}
				}
				text = string.Empty;
			}
			return text;
		}

		// Token: 0x06000004 RID: 4 RVA: 0x00002818 File Offset: 0x00000A18
		public bool LoadBasicConfig()
		{
			return this.LoadBasicConfig(this.pathConfigBasic);
		}

		// Token: 0x06000005 RID: 5 RVA: 0x00002838 File Offset: 0x00000A38
		public bool LoadBasicConfig(string path)
		{
			if (!string.IsNullOrEmpty(path) && File.Exists(path))
			{
				try
				{
					foreach (string text in File.ReadLines(path))
					{
						try
						{
							if (text.Trim().ToLower().StartsWith("maxcustomfilesize"))
							{
								this.confMaxCustomFileSize = Convert.ToInt32(Text.SubString(text, "=", ";").Replace(" ", ""));
							}
							else if (text.Trim().ToLower().StartsWith("minbandwidth"))
							{
								this.confMinBandwidth = decimal.Parse(Text.SubString(text, "=", ";").Replace(" ", ""), NumberStyles.Float, new CultureInfo("en-US"));
								if (this.confMinBandwidth > 9999999999m)
								{
									this.confMinBandwidth = 9999999999m;
								}
							}
							else if (text.Trim().ToLower().StartsWith("maxbandwidth"))
							{
								this.confMaxBandwidth = decimal.Parse(Text.SubString(text, "=", ";").Replace(" ", ""), NumberStyles.Float, new CultureInfo("en-US"));
								if (this.confMaxBandwidth > 9999999999m)
								{
									this.confMaxBandwidth = 9999999999m;
								}
							}
							else if (text.Trim().ToLower().StartsWith("maxmsgsend"))
							{
								this.confMaxMsgSend = decimal.Parse(Text.SubString(text, "=", ";").Replace(" ", ""), NumberStyles.Float, new CultureInfo("en-US"));
								if (this.confMaxMsgSend > 99999m)
								{
									this.confMaxMsgSend = 99999m;
								}
							}
							else if (text.Trim().ToLower().StartsWith("maxsizeguaranteed"))
							{
								this.confMaxSizeGuaranteed = decimal.Parse(Text.SubString(text, "=", ";").Replace(" ", ""), NumberStyles.Float, new CultureInfo("en-US"));
								if (this.confMaxSizeGuaranteed > 99999m)
								{
									this.confMaxSizeGuaranteed = 99999m;
								}
							}
							else if (text.Trim().ToLower().StartsWith("maxsizenonguaranteed"))
							{
								this.confMaxSizeNonguaranteed = decimal.Parse(Text.SubString(text, "=", ";").Replace(" ", ""), NumberStyles.Float, new CultureInfo("en-US"));
								if (this.confMaxSizeNonguaranteed > 99999m)
								{
									this.confMaxSizeNonguaranteed = 99999m;
								}
							}
							else if (text.Trim().ToLower().StartsWith("minerrortosend") && !text.Trim().ToLower().Contains("minerrortosendnear"))
							{
								this.confMinErrorToSend = decimal.Parse(Text.SubString(text, "=", ";").Replace(" ", ""), NumberStyles.Float, new CultureInfo("en-US"));
								decimal.Round(this.confMinErrorToSend, 10, MidpointRounding.AwayFromZero);
							}
							else if (text.Trim().ToLower().StartsWith("minerrortosendnear"))
							{
								this.confMinErrorToSendNear = decimal.Parse(Text.SubString(text, "=", ";").Replace(" ", ""), NumberStyles.Float, new CultureInfo("en-US"));
								decimal.Round(this.confMinErrorToSendNear, 10, MidpointRounding.AwayFromZero);
							}
						}
						catch (Exception ex)
						{
							Configuration.logger.Log(LogLevel.Error, string.Concat(new string[]
							{
								"LoadBasicConfig: ",
								ex.ToString(),
								"[",
								ex.Message,
								"]"
							}));
						}
					}
					return true;
				}
				catch (Exception ex)
				{
					Configuration.logger.Log(LogLevel.Fatal, string.Concat(new string[]
					{
						"LoadBasicConfig: ",
						ex.ToString(),
						"[",
						ex.Message,
						"]"
					}));
					return false;
				}
			}
			Configuration.logger.Log(LogLevel.Warn, "LoadBasicConfig: File not found: \"" + path + "\"");
			return false;
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00002DBC File Offset: 0x00000FBC
		public bool LoadBattleyeConfig()
		{
			return this.LoadBattleyeConfig(this.pathConfigBattleye);
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00002DDC File Offset: 0x00000FDC
		public bool LoadBattleyeConfig(string path)
		{
			if (!string.IsNullOrEmpty(path) && File.Exists(path))
			{
				try
				{
					foreach (string text in File.ReadLines(path))
					{
						try
						{
							if (text.Trim().ToLower().StartsWith("maxping"))
							{
								this.beMaxPing = Convert.ToInt32(text.Remove(0, 8));
								if (this.beMaxPing > 999)
								{
									this.beMaxPing = 999;
								}
							}
							else if (text.Trim().ToLower().StartsWith("rconpassword"))
							{
								this.bePass = text.Remove(0, 13);
							}
						}
						catch (Exception ex)
						{
							Configuration.logger.Log(LogLevel.Error, string.Concat(new string[]
							{
								"LoadBattleyeConfig: ",
								ex.ToString(),
								"[",
								ex.Message,
								"]"
							}));
						}
					}
					return true;
				}
				catch (Exception ex)
				{
					Configuration.logger.Log(LogLevel.Fatal, string.Concat(new string[]
					{
						"LoadBattleyeConfig: ",
						ex.ToString(),
						"[",
						ex.Message,
						"]"
					}));
					return false;
				}
			}
			Configuration.logger.Log(LogLevel.Warn, "LoadBattleyeConfig: File not found: \"" + path + "\"");
			return false;
		}

		// Token: 0x06000008 RID: 8 RVA: 0x00002FEC File Offset: 0x000011EC
		public bool LoadCfgConfig()
		{
			return this.LoadCfgConfig(this.pathConfigCfg);
		}

		// Token: 0x06000009 RID: 9 RVA: 0x0000300C File Offset: 0x0000120C
		public bool LoadCfgConfig(string path)
		{
			if (!string.IsNullOrEmpty(path) && File.Exists(path))
			{
				try
				{
					foreach (string text in File.ReadLines(path))
					{
						try
						{
							if (text.Trim().ToLower().StartsWith("hostname"))
							{
								this.confHostname = Text.SubString(text, "\"", "\"");
							}
							else if (text.Trim().ToLower().StartsWith("password") && !text.Trim().ToLower().StartsWith("passwordadmin"))
							{
								this.confPasswordServer = Text.SubString(text, "\"", "\"");
							}
							else if (text.Trim().ToLower().StartsWith("passwordadmin"))
							{
								this.confPasswordAdmin = Text.SubString(text, "\"", "\"");
							}
							else if (text.Trim().ToLower().StartsWith("maxplayers"))
							{
								this.confMaxPlayers = Convert.ToInt32(Text.SubString(text, "=", ";").Replace(" ", ""));
								if (this.confMaxPlayers > 100)
								{
									this.confMaxPlayers = 100;
								}
							}
							else if (text.Trim().ToLower().StartsWith("battleye"))
							{
								this.confBattleye = Text.SubString(text, "=", ";").Replace(" ", "") == "1";
							}
							else if (text.Trim().ToLower().StartsWith("reportingip"))
							{
								this.confReportingIp = Text.SubString(text, "\"", "\"");
							}
							else if (text.Trim().ToLower().StartsWith("motd[]"))
							{
								this.confMotd = Text.SubString(text, "{", "}");
							}
							else if (text.Trim().ToLower().StartsWith("motdinterval"))
							{
								this.confMotdInterval = Convert.ToInt32(Text.SubString(text, "=", ";").Replace(" ", ""));
								if (this.confMotdInterval > 100)
								{
									this.confMotdInterval = 100;
								}
							}
							else if (text.Trim().ToLower().StartsWith("kickduplicate"))
							{
								this.confKickDuplicate = Text.SubString(text, "=", ";").Replace(" ", "") == "1";
							}
							else if (text.Trim().ToLower().StartsWith("verifysignatures"))
							{
								this.confVerifySignatures = Convert.ToInt32(Text.SubString(text, "=", ";").Replace(" ", ""));
							}
							else if (text.Trim().ToLower().StartsWith("regularcheck"))
							{
								this.confRegularCheck = Text.SubString(text, "\"", "\"");
							}
							else if (text.Trim().ToLower().StartsWith("requiredbuild"))
							{
								this.confRequiredBuild = Text.SubString(text, "=", ";").Replace(" ", "");
							}
							else if (text.Trim().ToLower().StartsWith("voncodecquality"))
							{
								this.confVonQuality = Convert.ToInt32(Text.SubString(text, "=", ";").Replace(" ", ""));
							}
							else if (text.Trim().ToLower().StartsWith("disablevon"))
							{
								this.confVon = Text.SubString(text, "=", ";").Replace(" ", "") == "0";
							}
							else if (text.Trim().ToLower().StartsWith("persistent"))
							{
								this.confPersistent = Text.SubString(text, "=", ";").Replace(" ", "") == "1";
							}
							else if (text.Trim().ToLower().StartsWith("doubleiddetected"))
							{
								this.confDoubleIdDetected = Text.SubString(text, "\"", "\"");
							}
							else if (text.Trim().ToLower().StartsWith("onuserconnected"))
							{
								this.confOnUserConnected = Text.SubString(text, "\"", "\"");
							}
							else if (text.Trim().ToLower().StartsWith("onuserdisconnected"))
							{
								this.confOnUserDisconnected = Text.SubString(text, "\"", "\"");
							}
							else if (text.Trim().ToLower().StartsWith("onunsigneddata"))
							{
								this.confOnUnsignedData = Text.SubString(text, "\"", "\"");
							}
							else if (text.Trim().ToLower().StartsWith("onhackeddata"))
							{
								this.confOnHackedData = Text.SubString(text, "\"", "\"");
							}
							else if (text.Trim().ToLower().StartsWith("ondifferentdata"))
							{
								this.confOnHackedData = Text.SubString(text, "\"", "\"");
							}
							else if (text.Trim().ToLower().StartsWith("difficulty"))
							{
								this.confDifficulty = Text.SubString(text, "\"", "\"");
							}
							else if (text.Trim().ToLower().StartsWith("template"))
							{
								this.confTemplate = Text.SubString(text, "=", ";").Replace(" ", "").Replace("\"", "");
								this.confRmod = text.ToLower().Contains("rmod");
							}
							else if (text.Trim().ToLower().StartsWith("requiredsecureid"))
							{
								this.confSecureId = Convert.ToInt32(Text.SubString(text, "=", ";").Replace(" ", ""));
							}
						}
						catch (Exception ex)
						{
							Configuration.logger.Log(LogLevel.Error, string.Concat(new string[]
							{
								"LoadCfgConfig: ",
								ex.ToString(),
								"[",
								ex.Message,
								"]"
							}));
						}
					}
					return true;
				}
				catch (Exception ex)
				{
					Configuration.logger.Log(LogLevel.Fatal, string.Concat(new string[]
					{
						"LoadCfgConfig: ",
						ex.ToString(),
						"[",
						ex.Message,
						"]"
					}));
					return false;
				}
			}
			Configuration.logger.Log(LogLevel.Warn, "LoadCfgConfig: File not found: \"" + path + "\"");
			return false;
		}

		// Token: 0x0600000A RID: 10 RVA: 0x00003844 File Offset: 0x00001A44
		public bool LoadHiveConfig()
		{
			return this.LoadHiveConfig(this.pathConfigHive);
		}

		// Token: 0x0600000B RID: 11 RVA: 0x00003864 File Offset: 0x00001A64
		public bool LoadHiveConfig(string path)
		{
			if (!string.IsNullOrEmpty(path) && File.Exists(path))
			{
				try
				{
					if (Ini.Read(path, "Time", "Type").Replace(" ", "").ToLower() == "static")
					{
						this.confDaytime = true;
					}
					else
					{
						this.confDaytime = false;
					}
					this.confTimezone = Convert.ToInt32(Ini.Read(path, "Time", "Offset"));
					this.confStaticHour = Convert.ToInt32(Ini.Read(path, "Time", "Hour"));
					this.dbHost = Ini.Read(path, "Database", "Host");
					this.dbPort = Convert.ToInt32(Ini.Read(path, "Database", "Port"));
					this.dbUser = Ini.Read(path, "Database", "Username");
					this.dbPass = Ini.Read(path, "Database", "Password");
					this.dbName = Ini.Read(path, "Database", "Database");
					return true;
				}
				catch (Exception ex)
				{
					Configuration.logger.Log(LogLevel.Fatal, string.Concat(new string[]
					{
						"LoadHiveConfig: ",
						ex.ToString(),
						"[",
						ex.Message,
						"]"
					}));
					return false;
				}
			}
			Configuration.logger.Log(LogLevel.Warn, "LoadHiveConfig: File not found: \"" + path + "\"");
			return false;
		}

		// Token: 0x0600000C RID: 12 RVA: 0x00003A0C File Offset: 0x00001C0C
		public bool LoadXmlConfig()
		{
			return this.LoadXmlConfig(this.pathConfigXml);
		}

		// Token: 0x0600000D RID: 13 RVA: 0x00003A2C File Offset: 0x00001C2C
		public bool LoadXmlConfig(string path)
		{
			if (!string.IsNullOrEmpty(path) && File.Exists(path))
			{
				try
				{
					XmlDocument xmlDocument = new XmlDocument();
					xmlDocument.Load(path);
					foreach (object obj in xmlDocument)
					{
						XmlNode xmlNode = (XmlNode)obj;
						if (xmlNode.Name == "configuration")
						{
							foreach (object obj2 in xmlNode)
							{
								XmlNode xmlNode2 = (XmlNode)obj2;
								if (xmlNode2.Name == "section")
								{
									if (xmlNode2.Attributes.Count == 1)
									{
										string text = xmlNode2.Attributes[0].Value;
										if (text != null)
										{
											if (!(text == "General"))
											{
												if (!(text == "Backup"))
												{
													if (!(text == "Rcon"))
													{
														if (text == "Whitelist")
														{
															foreach (object obj3 in xmlNode2)
															{
																XmlNode xmlNode3 = (XmlNode)obj3;
																if (xmlNode3.Attributes.Count == 1)
																{
																	text = xmlNode3.Attributes[0].Value;
																	switch (text)
																	{
																	case "Enabled":
																		if (!string.IsNullOrEmpty(xmlNode3.InnerText))
																		{
																			this.beWhitelistEnabled = Convert.ToBoolean(xmlNode3.InnerText);
																		}
																		else
																		{
																			this.beWhitelistEnabled = false;
																		}
																		break;
																	case "Host":
																		if (!string.IsNullOrEmpty(xmlNode3.InnerText))
																		{
																			this.beWhitelistHost = xmlNode3.InnerText;
																		}
																		else
																		{
																			this.beWhitelistHost = string.Empty;
																		}
																		break;
																	case "Port":
																		if (!string.IsNullOrEmpty(xmlNode3.InnerText))
																		{
																			this.beWhitelistPort = Convert.ToInt32(xmlNode3.InnerText);
																		}
																		break;
																	case "User":
																		if (!string.IsNullOrEmpty(xmlNode3.InnerText))
																		{
																			this.beWhitelistUser = xmlNode3.InnerText;
																		}
																		else
																		{
																			this.beWhitelistUser = string.Empty;
																		}
																		break;
																	case "Pass":
																		if (!string.IsNullOrEmpty(xmlNode3.InnerText))
																		{
																			this.beWhitelistPass = xmlNode3.InnerText;
																		}
																		else
																		{
																			this.beWhitelistPass = string.Empty;
																		}
																		break;
																	case "Name":
																		if (!string.IsNullOrEmpty(xmlNode3.InnerText))
																		{
																			this.beWhitelistName = xmlNode3.InnerText;
																		}
																		else
																		{
																			this.beWhitelistName = string.Empty;
																		}
																		break;
																	case "Message":
																		if (!string.IsNullOrEmpty(xmlNode3.InnerText))
																		{
																			this.beWhitelistMessage = xmlNode3.InnerText;
																		}
																		else
																		{
																			this.beWhitelistMessage = string.Empty;
																		}
																		break;
																	}
																}
															}
														}
													}
													else
													{
														foreach (object obj4 in xmlNode2)
														{
															XmlNode xmlNode3 = (XmlNode)obj4;
															if (xmlNode3.Attributes.Count == 1)
															{
																text = xmlNode3.Attributes[0].Value;
																if (text != null)
																{
																	if (!(text == "Host"))
																	{
																		if (!(text == "Port"))
																		{
																			if (text == "Pass")
																			{
																				if (!string.IsNullOrEmpty(xmlNode3.InnerText))
																				{
																					this.bePass = xmlNode3.InnerText;
																				}
																				else
																				{
																					this.bePass = string.Empty;
																				}
																			}
																		}
																		else if (!string.IsNullOrEmpty(xmlNode3.InnerText))
																		{
																			this.bePort = Convert.ToInt32(xmlNode3.InnerText);
																		}
																	}
																	else if (!string.IsNullOrEmpty(xmlNode3.InnerText))
																	{
																		this.beHost = xmlNode3.InnerText;
																	}
																	else
																	{
																		this.beHost = string.Empty;
																	}
																}
															}
														}
													}
												}
												else
												{
													foreach (object obj5 in xmlNode2)
													{
														XmlNode xmlNode3 = (XmlNode)obj5;
														if (xmlNode3.Attributes.Count == 1)
														{
															text = xmlNode3.Attributes[0].Value;
															if (text != null)
															{
																if (!(text == "Enabled"))
																{
																	if (!(text == "Interval"))
																	{
																		if (text == "Path")
																		{
																			if (!string.IsNullOrEmpty(xmlNode3.InnerText))
																			{
																				this.confAutoBackupPath = xmlNode3.InnerText;
																			}
																			else
																			{
																				this.confAutoBackupPath = string.Empty;
																			}
																		}
																	}
																	else if (!string.IsNullOrEmpty(xmlNode3.InnerText))
																	{
																		this.confAutoBackupInterval = Convert.ToInt32(xmlNode3.InnerText);
																	}
																	else
																	{
																		this.confAutoBackupInterval = 60;
																	}
																}
																else if (!string.IsNullOrEmpty(xmlNode3.InnerText))
																{
																	this.confAutoBackupEnabled = Convert.ToBoolean(xmlNode3.InnerText);
																}
																else
																{
																	this.confAutoBackupEnabled = false;
																}
															}
														}
													}
												}
											}
											else
											{
												foreach (object obj6 in xmlNode2)
												{
													XmlNode xmlNode3 = (XmlNode)obj6;
													if (xmlNode3.Attributes.Count == 1)
													{
														text = xmlNode3.Attributes[0].Value;
														if (text != null)
														{
															if (!(text == "Mod"))
															{
																if (text == "Welcome")
																{
																	if (!string.IsNullOrEmpty(xmlNode3.InnerText))
																	{
																		this.confWelcome = xmlNode3.InnerText;
																	}
																	else
																	{
																		this.confWelcome = string.Empty;
																	}
																}
															}
															else if (!string.IsNullOrEmpty(xmlNode3.InnerText))
															{
																this.confModlist = xmlNode3.InnerText;
															}
															else
															{
																this.confModlist = string.Empty;
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
					return true;
				}
				catch (Exception ex)
				{
					Configuration.logger.Log(LogLevel.Fatal, string.Concat(new string[]
					{
						"LoadXmlConfig: ",
						ex.ToString(),
						"[",
						ex.Message,
						"]"
					}));
					return false;
				}
			}
			Configuration.logger.Log(LogLevel.Warn, "LoadXmlConfig: File not found: \"" + path + "\"");
			return false;
		}

		// Token: 0x0600000E RID: 14 RVA: 0x000042F8 File Offset: 0x000024F8
		public bool WriteBasicConfig()
		{
			return this.WriteBasicConfig(this.pathConfigBasic);
		}

		// Token: 0x0600000F RID: 15 RVA: 0x00004318 File Offset: 0x00002518
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
									array[i] = array[i].Replace(Text.SubString(array[i], "=", ";").Replace(" ", ""), this.confMaxCustomFileSize.ToString());
								}
								else
								{
									array[i] = "MaxCustomFileSize=" + this.confMaxCustomFileSize.ToString() + ";";
								}
							}
							else if (array[i].Trim().ToLower().StartsWith("minbandwidth"))
							{
								if (!string.IsNullOrEmpty(Text.SubString(array[i].Replace(" ", ""), "=", ";")))
								{
									array[i] = array[i].Replace(Text.SubString(array[i], "=", ";").Replace(" ", ""), this.confMinBandwidth.ToString().Replace(",", "."));
								}
								else
								{
									array[i] = "MinBandwidth=" + this.confMinBandwidth.ToString().Replace(",", ".") + ";";
								}
							}
							else if (array[i].Trim().ToLower().StartsWith("maxbandwidth"))
							{
								if (!string.IsNullOrEmpty(Text.SubString(array[i].Replace(" ", ""), "=", ";")))
								{
									array[i] = array[i].Replace(Text.SubString(array[i], "=", ";").Replace(" ", ""), this.confMaxBandwidth.ToString().Replace(",", "."));
								}
								else
								{
									array[i] = "MaxBandwidth=" + this.confMaxBandwidth.ToString().Replace(",", ".") + ";";
								}
							}
							else if (array[i].Trim().ToLower().StartsWith("maxmsgsend"))
							{
								if (!string.IsNullOrEmpty(Text.SubString(array[i].Replace(" ", ""), "=", ";")))
								{
									array[i] = array[i].Replace(Text.SubString(array[i], "=", ";").Replace(" ", ""), this.confMaxMsgSend.ToString().Replace(",", "."));
								}
								else
								{
									array[i] = "MaxMsgSend=" + this.confMaxMsgSend.ToString().Replace(",", ".") + ";";
								}
							}
							else if (array[i].Trim().ToLower().StartsWith("maxsizeguaranteed"))
							{
								if (!string.IsNullOrEmpty(Text.SubString(array[i].Replace(" ", ""), "=", ";")))
								{
									array[i] = array[i].Replace(Text.SubString(array[i], "=", ";").Replace(" ", ""), this.confMaxSizeGuaranteed.ToString().Replace(",", "."));
								}
								else
								{
									array[i] = "MaxSizeGuaranteed=" + this.confMaxSizeGuaranteed.ToString().Replace(",", ".") + ";";
								}
							}
							else if (array[i].Trim().ToLower().StartsWith("maxsizenonguaranteed"))
							{
								if (!string.IsNullOrEmpty(Text.SubString(array[i].Replace(" ", ""), "=", ";")))
								{
									array[i] = array[i].Replace(Text.SubString(array[i], "=", ";").Replace(" ", ""), this.confMaxSizeNonguaranteed.ToString().Replace(",", "."));
								}
								else
								{
									array[i] = "MaxSizeNonguaranteed=" + this.confMaxSizeNonguaranteed.ToString().Replace(",", ".") + ";";
								}
							}
							else if (array[i].Trim().ToLower().StartsWith("minerrortosend"))
							{
								if (!string.IsNullOrEmpty(Text.SubString(array[i].Replace(" ", ""), "=", ";")))
								{
									array[i] = array[i].Replace(Text.SubString(array[i], "=", ";").Replace(" ", ""), this.confMinErrorToSend.ToString().Replace(",", "."));
								}
								else
								{
									array[i] = "MinErrorToSend=" + this.confMinErrorToSend.ToString().Replace(",", ".") + ";";
								}
							}
							else if (array[i].Trim().ToLower().StartsWith("minerrortosendnear"))
							{
								if (!string.IsNullOrEmpty(Text.SubString(array[i].Replace(" ", ""), "=", ";")))
								{
									array[i] = array[i].Replace(Text.SubString(array[i], "=", ";").Replace(" ", ""), this.confMinErrorToSendNear.ToString().Replace(",", "."));
								}
								else
								{
									array[i] = "MinErrorToSendNear=" + this.confMinErrorToSendNear.ToString().Replace(",", ".") + ";";
								}
							}
						}
						catch (Exception ex)
						{
							Configuration.logger.Log(LogLevel.Error, string.Concat(new string[]
							{
								"WriteBasicConfig: ",
								ex.ToString(),
								"[",
								ex.Message,
								"]"
							}));
						}
					}
					File.WriteAllLines(path, array);
					return true;
				}
				catch (Exception ex)
				{
					Configuration.logger.Log(LogLevel.Fatal, string.Concat(new string[]
					{
						"WriteBasicConfig: ",
						ex.ToString(),
						"[",
						ex.Message,
						"]"
					}));
					return false;
				}
			}
			Configuration.logger.Log(LogLevel.Warn, "WriteBasicConfig: File not found: \"" + path + "\"");
			return false;
		}

		// Token: 0x06000010 RID: 16 RVA: 0x00004ACC File Offset: 0x00002CCC
		public bool WriteBattleyeConfig()
		{
			return this.WriteBattleyeConfig(this.pathConfigBattleye);
		}

		// Token: 0x06000011 RID: 17 RVA: 0x00004AEC File Offset: 0x00002CEC
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
								array[i] = "MaxPing " + this.beMaxPing.ToString();
							}
							else if (array[i].Trim().ToLower().StartsWith("rconpassword"))
							{
								array[i] = "RConPassword " + this.bePass;
							}
						}
						catch (Exception ex)
						{
							Configuration.logger.Log(LogLevel.Error, string.Concat(new string[]
							{
								"WriteBattleyeConfig: ",
								ex.ToString(),
								"[",
								ex.Message,
								"]"
							}));
						}
					}
					File.WriteAllLines(path, array);
					return true;
				}
				catch (Exception ex)
				{
					Configuration.logger.Log(LogLevel.Fatal, string.Concat(new string[]
					{
						"WriteBattleyeConfig: ",
						ex.ToString(),
						"[",
						ex.Message,
						"]"
					}));
					return false;
				}
			}
			Configuration.logger.Log(LogLevel.Warn, "WriteBattleyeConfig: File not found: \"" + path + "\"");
			return false;
		}

		// Token: 0x06000012 RID: 18 RVA: 0x00004CAC File Offset: 0x00002EAC
		public bool WriteCfgConfig()
		{
			return this.WriteCfgConfig(this.pathConfigCfg);
		}

		// Token: 0x06000013 RID: 19 RVA: 0x00004CCC File Offset: 0x00002ECC
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
									array[i] = array[i].Replace(Text.SubString(array[i], "\"", "\""), this.confHostname);
								}
								else
								{
									array[i] = "hostname=\"" + this.confHostname + "\";";
								}
							}
							else if (array[i].Trim().ToLower().StartsWith("password") && !array[i].Trim().ToLower().StartsWith("passwordadmin"))
							{
								if (!string.IsNullOrEmpty(Text.SubString(array[i].Replace(" ", ""), "\"", "\"")) || Text.SubString(array[i].Replace(" ", ""), "\"", "\"").ToLower() == "password")
								{
									array[i] = array[i].Replace(Text.SubString(array[i], "\"", "\""), this.confPasswordServer);
								}
								else
								{
									array[i] = "password=\"" + this.confPasswordServer + "\";";
								}
							}
							else if (array[i].Trim().ToLower().StartsWith("passwordadmin"))
							{
								if (!string.IsNullOrEmpty(Text.SubString(array[i].Replace(" ", ""), "\"", "\"")) || Text.SubString(array[i].Replace(" ", ""), "\"", "\"").ToLower() == "passwordadmin")
								{
									array[i] = array[i].Replace(Text.SubString(array[i], "\"", "\""), this.confPasswordAdmin);
								}
								else
								{
									array[i] = "passwordAdmin=\"" + this.confPasswordAdmin + "\";";
								}
							}
							else if (array[i].Trim().ToLower().StartsWith("maxplayers"))
							{
								if (!string.IsNullOrEmpty(Text.SubString(array[i].Replace(" ", ""), "=", ";")))
								{
									array[i] = array[i].Replace(Text.SubString(array[i], "=", ";").Replace(" ", ""), this.confMaxPlayers.ToString());
								}
								else
								{
									array[i] = "maxPlayers=" + this.confMaxPlayers.ToString() + ";";
								}
							}
							else if (array[i].Trim().ToLower().StartsWith("battleye"))
							{
								if (!string.IsNullOrEmpty(Text.SubString(array[i].Replace(" ", ""), "=", ";")))
								{
									array[i] = array[i].Replace(Text.SubString(array[i], "=", ";").Replace(" ", ""), this.confBattleye ? "1" : "0");
								}
								else
								{
									array[i] = "BattlEye=" + (this.confBattleye ? "1" : "0") + ";";
								}
							}
							else if (array[i].Trim().ToLower().StartsWith("reportingip"))
							{
								if (!string.IsNullOrEmpty(Text.SubString(array[i].Replace(" ", ""), "\"", "\"")))
								{
									array[i] = array[i].Replace(Text.SubString(array[i], "\"", "\"").Replace(" ", ""), this.confReportingIp);
								}
								else
								{
									array[i] = "reportingIP=\"" + this.confReportingIp + "\";";
								}
							}
							else if (array[i].Trim().ToLower().StartsWith("motd[]"))
							{
								if (!string.IsNullOrEmpty(Text.SubString(array[i].Replace(" ", "").Replace("\"", ""), "{", "}")) || Text.SubString(array[i].Replace("\"", ""), "{", "}").ToLower() == "motd[]")
								{
									array[i] = array[i].Replace(Text.SubString(array[i], "{", "}"), this.confMotd);
								}
								else
								{
									array[i] = "motd[]={" + this.confMotd + "};";
								}
							}
							else if (array[i].Trim().ToLower().StartsWith("motdinterval"))
							{
								if (!string.IsNullOrEmpty(Text.SubString(array[i].Replace(" ", ""), "=", ";")))
								{
									array[i] = array[i].Replace(Text.SubString(array[i], "=", ";").Replace(" ", ""), this.confMotdInterval.ToString());
								}
								else
								{
									array[i] = "motdInterval=" + this.confMotdInterval.ToString() + ";";
								}
							}
							else if (array[i].Trim().ToLower().StartsWith("kickduplicate"))
							{
								if (!string.IsNullOrEmpty(Text.SubString(array[i].Replace(" ", ""), "=", ";")))
								{
									array[i] = array[i].Replace(Text.SubString(array[i], "=", ";").Replace(" ", ""), this.confKickDuplicate ? "1" : "0");
								}
								else
								{
									array[i] = "kickduplicate=" + (this.confKickDuplicate ? "1" : "0") + ";";
								}
							}
							else if (array[i].Trim().ToLower().StartsWith("verifysignatures"))
							{
								if (!string.IsNullOrEmpty(Text.SubString(array[i].Replace(" ", ""), "=", ";")))
								{
									array[i] = array[i].Replace(Text.SubString(array[i], "=", ";").Replace(" ", ""), this.confVerifySignatures.ToString());
								}
								else
								{
									array[i] = "verifySignatures=" + this.confVerifySignatures.ToString() + ";";
								}
							}
							else if (array[i].Trim().ToLower().StartsWith("regularcheck"))
							{
								if (!string.IsNullOrEmpty(Text.SubString(array[i].Replace(" ", ""), "\"", "\"")) || Text.SubString(array[i].Replace(" ", ""), "\"", "\"").ToLower() == "regularcheck")
								{
									array[i] = array[i].Replace(Text.SubString(array[i], "\"", "\""), this.confRegularCheck);
								}
								else
								{
									array[i] = "regularCheck=\"" + this.confRegularCheck + "\";";
								}
							}
							else if (array[i].Trim().ToLower().StartsWith("requiredbuild"))
							{
								if (!string.IsNullOrEmpty(Text.SubString(array[i].Replace(" ", ""), "=", ";")))
								{
									array[i] = array[i].Replace(Text.SubString(array[i], "=", ";").Replace(" ", ""), this.confRequiredBuild);
								}
								else
								{
									array[i] = "requiredBuild=" + this.confRequiredBuild + ";";
								}
							}
							else if (array[i].Trim().ToLower().StartsWith("voncodecquality"))
							{
								if (!string.IsNullOrEmpty(Text.SubString(array[i].Replace(" ", ""), "=", ";")))
								{
									array[i] = array[i].Replace(Text.SubString(array[i], "=", ";").Replace(" ", ""), this.confVonQuality.ToString());
								}
								else
								{
									array[i] = "vonCodecQuality=" + this.confVonQuality.ToString() + ";";
								}
							}
							else if (array[i].Trim().ToLower().StartsWith("disablevon"))
							{
								if (!string.IsNullOrEmpty(Text.SubString(array[i].Replace(" ", ""), "=", ";")))
								{
									array[i] = array[i].Replace(Text.SubString(array[i], "=", ";").Replace(" ", ""), this.confVon ? "0" : "1");
								}
								else
								{
									array[i] = "disableVoN=" + (this.confVon ? "0" : "1") + ";";
								}
							}
							else if (array[i].Trim().ToLower().StartsWith("persistent"))
							{
								if (!string.IsNullOrEmpty(Text.SubString(array[i].Replace(" ", ""), "=", ";")))
								{
									array[i] = array[i].Replace(Text.SubString(array[i], "=", ";").Replace(" ", ""), this.confPersistent ? "1" : "0");
								}
								else
								{
									array[i] = "persistent=" + (this.confPersistent ? "1" : "0") + ";";
								}
							}
							else if (array[i].Trim().ToLower().StartsWith("doubleiddetected"))
							{
								if (!string.IsNullOrEmpty(Text.SubString(array[i].Replace(" ", ""), "\"", "\"")) || Text.SubString(array[i].Replace(" ", ""), "\"", "\"").ToLower() == "doubleiddetected")
								{
									array[i] = array[i].Replace(Text.SubString(array[i], "\"", "\"").Replace(" ", ""), this.confDoubleIdDetected);
								}
								else
								{
									array[i] = "doubleIdDetected=\"" + this.confDoubleIdDetected + "\";";
								}
							}
							else if (array[i].Trim().ToLower().StartsWith("onuserconnected"))
							{
								if (!string.IsNullOrEmpty(Text.SubString(array[i].Replace(" ", ""), "\"", "\"")) || Text.SubString(array[i].Replace(" ", ""), "\"", "\"").ToLower() == "onuserconnected")
								{
									array[i] = array[i].Replace(Text.SubString(array[i], "\"", "\""), this.confOnUserConnected);
								}
								else
								{
									array[i] = "onUserConnected=\"" + this.confOnUserConnected + "\";";
								}
							}
							else if (array[i].Trim().ToLower().StartsWith("onuserdisconnected"))
							{
								if (!string.IsNullOrEmpty(Text.SubString(array[i].Replace(" ", ""), "\"", "\"")) || Text.SubString(array[i].Replace(" ", ""), "\"", "\"").ToLower() == "onuserdisconnected")
								{
									array[i] = array[i].Replace(Text.SubString(array[i], "\"", "\""), this.confOnUserDisconnected);
								}
								else
								{
									array[i] = "onUserDisconnected=\"" + this.confOnUserDisconnected + "\";";
								}
							}
							else if (array[i].Trim().ToLower().StartsWith("onunsigneddata"))
							{
								if (!string.IsNullOrEmpty(Text.SubString(array[i].Replace(" ", ""), "\"", "\"")) || Text.SubString(array[i].Replace(" ", ""), "\"", "\"").ToLower() == "onunsigneddata")
								{
									array[i] = array[i].Replace(Text.SubString(array[i], "\"", "\""), this.confOnUnsignedData);
								}
								else
								{
									array[i] = "onUnsignedData=\"" + this.confOnUnsignedData + "\";";
								}
							}
							else if (array[i].Trim().ToLower().StartsWith("onhackeddata"))
							{
								if (!string.IsNullOrEmpty(Text.SubString(array[i].Replace(" ", ""), "\"", "\"")) || Text.SubString(array[i].Replace(" ", ""), "\"", "\"").ToLower() == "onhackeddata")
								{
									array[i] = array[i].Replace(Text.SubString(array[i], "\"", "\""), this.confOnHackedData);
								}
								else
								{
									array[i] = "onHackedData=\"" + this.confOnHackedData + "\";";
								}
							}
							else if (array[i].Trim().ToLower().StartsWith("ondifferentdata"))
							{
								if (!string.IsNullOrEmpty(Text.SubString(array[i].Replace(" ", ""), "\"", "\"")) || Text.SubString(array[i].Replace(" ", ""), "\"", "\"").ToLower() == "ondifferentdata")
								{
									array[i] = array[i].Replace(Text.SubString(array[i], "\"", "\""), this.confOnDifferentData);
								}
								else
								{
									array[i] = "onDifferentData=\"" + this.confOnDifferentData + "\";";
								}
							}
							else if (array[i].Trim().ToLower().StartsWith("difficulty"))
							{
								if (!string.IsNullOrEmpty(Text.SubString(array[i].Replace(" ", ""), "\"", "\"")) || Text.SubString(array[i].Replace(" ", ""), "\"", "\"").ToLower() == "difficulty")
								{
									array[i] = array[i].Replace(Text.SubString(array[i], "\"", "\""), this.confDifficulty);
								}
								else
								{
									array[i] = "difficulty=\"" + this.confDifficulty + "\";";
								}
							}
							else if (array[i].Trim().ToLower().StartsWith("template"))
							{
								if (array[i].Contains("\""))
								{
									if (!string.IsNullOrEmpty(Text.SubString(array[i].Replace(" ", ""), "\"", "\"")) || Text.SubString(array[i].Replace(" ", ""), "\"", "\"").ToLower() == "template")
									{
										array[i] = array[i].Replace(Text.SubString(array[i], "\"", "\""), this.confTemplate);
									}
									else
									{
										array[i] = "template=\"" + this.confTemplate + "\";";
									}
								}
								else if (!string.IsNullOrEmpty(Text.SubString(array[i].Replace(" ", ""), "=", ";")) || Text.SubString(array[i].Replace(" ", ""), "=", ";").ToLower() == "template")
								{
									array[i] = array[i].Replace(Text.SubString(array[i], "=", ";"), this.confTemplate);
								}
								else
								{
									array[i] = "template=" + this.confTemplate + ";";
								}
							}
							else if (array[i].Trim().ToLower().StartsWith("requiredsecureid"))
							{
								if (!string.IsNullOrEmpty(Text.SubString(array[i].Replace(" ", ""), "=", ";")))
								{
									array[i] = array[i].Replace(Text.SubString(array[i], "=", ";").Replace(" ", ""), this.confSecureId.ToString());
								}
								else
								{
									array[i] = "requireSecureId=" + this.confSecureId.ToString() + ";";
								}
							}
						}
						catch (Exception ex)
						{
							Configuration.logger.Log(LogLevel.Error, string.Concat(new string[]
							{
								"WriteCfgConfig: ",
								ex.ToString(),
								"[",
								ex.Message,
								"]"
							}));
						}
					}
					File.WriteAllLines(path, array);
					return true;
				}
				catch (Exception ex)
				{
					Configuration.logger.Log(LogLevel.Fatal, string.Concat(new string[]
					{
						"WriteCfgConfig: ",
						ex.ToString(),
						"[",
						ex.Message,
						"]"
					}));
					return false;
				}
			}
			Configuration.logger.Log(LogLevel.Warn, "WriteCfgConfig: File not found: \"" + path + "\"");
			return false;
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00006188 File Offset: 0x00004388
		public bool WriteHiveConfig()
		{
			return this.WriteHiveConfig(this.pathConfigHive);
		}

		// Token: 0x06000015 RID: 21 RVA: 0x000061A8 File Offset: 0x000043A8
		public bool WriteHiveConfig(string path)
		{
			if (!string.IsNullOrEmpty(path) && File.Exists(path))
			{
				try
				{
					if (this.confDaytime)
					{
						Ini.Write(path, "Time", "Type", "Static");
					}
					else if (this.confTimezone == 0)
					{
						Ini.Write(path, "Time", "Type", "Local");
					}
					else
					{
						Ini.Write(path, "Time", "Type", "Custom");
					}
					Ini.Write(path, "Time", "Offset", this.confTimezone.ToString());
					Ini.Write(path, "Time", "Hour", this.confStaticHour.ToString());
					Ini.Write(path, "Database", "Host", this.dbHost);
					Ini.Write(path, "Database", "Port", this.dbPort.ToString());
					Ini.Write(path, "Database", "Username", this.dbUser);
					Ini.Write(path, "Database", "Password", this.dbPass);
					Ini.Write(path, "Database", "Database", this.dbName);
					return true;
				}
				catch (Exception ex)
				{
					Configuration.logger.Log(LogLevel.Fatal, string.Concat(new string[]
					{
						"WriteHiveConfig: ",
						ex.ToString(),
						"[",
						ex.Message,
						"]"
					}));
					return false;
				}
			}
			Configuration.logger.Log(LogLevel.Warn, "WriteHiveConfig: File not found: \"" + path + "\"");
			return false;
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00006384 File Offset: 0x00004584
		public bool WriteXmlConfig()
		{
			return this.WriteXmlConfig(this.pathConfigXml);
		}

		// Token: 0x06000017 RID: 23 RVA: 0x000063A4 File Offset: 0x000045A4
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
					xmlTextWriter.WriteString(this.confModlist);
					xmlTextWriter.WriteEndElement();
					xmlTextWriter.WriteStartElement("setting");
					xmlTextWriter.WriteAttributeString("id", "Welcome");
					xmlTextWriter.WriteString(this.confWelcome);
					xmlTextWriter.WriteEndElement();
					xmlTextWriter.WriteEndElement();
					xmlTextWriter.WriteStartElement("section");
					xmlTextWriter.WriteAttributeString("id", "Backup");
					xmlTextWriter.WriteStartElement("setting");
					xmlTextWriter.WriteAttributeString("id", "Enabled");
					xmlTextWriter.WriteString(this.confAutoBackupEnabled.ToString());
					xmlTextWriter.WriteEndElement();
					xmlTextWriter.WriteStartElement("setting");
					xmlTextWriter.WriteAttributeString("id", "Interval");
					xmlTextWriter.WriteString(this.confAutoBackupInterval.ToString());
					xmlTextWriter.WriteEndElement();
					xmlTextWriter.WriteStartElement("setting");
					xmlTextWriter.WriteAttributeString("id", "Path");
					xmlTextWriter.WriteString(this.confAutoBackupPath);
					xmlTextWriter.WriteEndElement();
					xmlTextWriter.WriteEndElement();
					xmlTextWriter.WriteStartElement("section");
					xmlTextWriter.WriteAttributeString("id", "Rcon");
					xmlTextWriter.WriteStartElement("setting");
					xmlTextWriter.WriteAttributeString("id", "Host");
					xmlTextWriter.WriteString(this.beHost);
					xmlTextWriter.WriteEndElement();
					xmlTextWriter.WriteStartElement("setting");
					xmlTextWriter.WriteAttributeString("id", "Port");
					xmlTextWriter.WriteString(this.bePort.ToString());
					xmlTextWriter.WriteEndElement();
					xmlTextWriter.WriteStartElement("setting");
					xmlTextWriter.WriteAttributeString("id", "Pass");
					xmlTextWriter.WriteString(this.bePass);
					xmlTextWriter.WriteEndElement();
					xmlTextWriter.WriteEndElement();
					xmlTextWriter.WriteStartElement("section");
					xmlTextWriter.WriteAttributeString("id", "Whitelist");
					xmlTextWriter.WriteStartElement("setting");
					xmlTextWriter.WriteAttributeString("id", "Enabled");
					xmlTextWriter.WriteString(this.beWhitelistEnabled.ToString());
					xmlTextWriter.WriteEndElement();
					xmlTextWriter.WriteStartElement("setting");
					xmlTextWriter.WriteAttributeString("id", "Host");
					xmlTextWriter.WriteString(this.beWhitelistHost);
					xmlTextWriter.WriteEndElement();
					xmlTextWriter.WriteStartElement("setting");
					xmlTextWriter.WriteAttributeString("id", "Port");
					xmlTextWriter.WriteString(this.beWhitelistPort.ToString());
					xmlTextWriter.WriteEndElement();
					xmlTextWriter.WriteStartElement("setting");
					xmlTextWriter.WriteAttributeString("id", "User");
					xmlTextWriter.WriteString(this.beWhitelistUser);
					xmlTextWriter.WriteEndElement();
					xmlTextWriter.WriteStartElement("setting");
					xmlTextWriter.WriteAttributeString("id", "Pass");
					xmlTextWriter.WriteString(this.beWhitelistPass);
					xmlTextWriter.WriteEndElement();
					xmlTextWriter.WriteStartElement("setting");
					xmlTextWriter.WriteAttributeString("id", "Name");
					xmlTextWriter.WriteString(this.beWhitelistName);
					xmlTextWriter.WriteEndElement();
					xmlTextWriter.WriteStartElement("setting");
					xmlTextWriter.WriteAttributeString("id", "Message");
					xmlTextWriter.WriteString(this.beWhitelistMessage);
					xmlTextWriter.WriteEndElement();
					xmlTextWriter.WriteEndElement();
					xmlTextWriter.WriteEndElement();
					xmlTextWriter.Close();
					return true;
				}
				catch (Exception ex)
				{
					Configuration.logger.Log(LogLevel.Fatal, string.Concat(new string[]
					{
						"WriteXmlConfig: ",
						ex.ToString(),
						"[",
						ex.Message,
						"]"
					}));
					return false;
				}
			}
			Configuration.logger.Log(LogLevel.Warn, "WriteHiveXml: File not found: \"" + path + "\"");
			return false;
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00006824 File Offset: 0x00004A24
		public int GetWorldId()
		{
			return this.GetWorldId(this.confWorld);
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00006844 File Offset: 0x00004A44
		public int GetWorldId(string world)
		{
			int num = 0;
			MySqlConnection mySqlConnection = mysql.Connection;
			if (string.IsNullOrEmpty(mySqlConnection.ConnectionString))
			{
				mySqlConnection = new MySqlConnection(string.Format("server={0};port={1};user={2};password={3};", new object[]
				{
					this.dbHost,
					this.dbPort.ToString(),
					this.dbUser,
					this.dbPass
				}));
			}
			try
			{
				mysql.Open(mySqlConnection);
				mysql.ChangeDatabase(this.dbName, mySqlConnection);
				MySqlDataReader mySqlDataReader = new MySqlCommand("SELECT * FROM `world`", mySqlConnection).ExecuteReader();
				while (mySqlDataReader.Read())
				{
					if (mySqlDataReader.GetString("name").ToLower() == world.ToLower())
					{
						num = mySqlDataReader.GetInt32("id");
					}
				}
				mySqlDataReader.Close();
			}
			catch (MySqlException ex)
			{
				Configuration.logger.Log(LogLevel.Error, string.Concat(new string[]
				{
					"GetWorldId: ",
					ex.ToString(),
					"[",
					ex.Message,
					"]"
				}));
			}
			finally
			{
				mysql.Close(mySqlConnection);
			}
			return num;
		}

		// Token: 0x04000001 RID: 1
		public int confInstance = 0;

		// Token: 0x04000002 RID: 2
		public int confWorldId = 0;

		// Token: 0x04000003 RID: 3
		public string confWorld = string.Empty;

		// Token: 0x04000004 RID: 4
		public string confModlist = string.Empty;

		// Token: 0x04000005 RID: 5
		public int confAutoBackupInterval = 60;

		// Token: 0x04000006 RID: 6
		public bool confAutoBackupEnabled = false;

		// Token: 0x04000007 RID: 7
		public string confAutoBackupPath = string.Empty;

		// Token: 0x04000008 RID: 8
		public string confHostname = string.Empty;

		// Token: 0x04000009 RID: 9
		public string confPasswordServer = string.Empty;

		// Token: 0x0400000A RID: 10
		public string confPasswordAdmin = string.Empty;

		// Token: 0x0400000B RID: 11
		public int confMaxPlayers = 50;

		// Token: 0x0400000C RID: 12
		public bool confBattleye = true;

		// Token: 0x0400000D RID: 13
		public string confReportingIp = string.Empty;

		// Token: 0x0400000E RID: 14
		public string confMotd = string.Empty;

		// Token: 0x0400000F RID: 15
		public int confMotdInterval = 1;

		// Token: 0x04000010 RID: 16
		public bool confKickDuplicate = true;

		// Token: 0x04000011 RID: 17
		public int confVerifySignatures = 2;

		// Token: 0x04000012 RID: 18
		public string confRegularCheck = string.Empty;

		// Token: 0x04000013 RID: 19
		public string confRequiredBuild = string.Empty;

		// Token: 0x04000014 RID: 20
		public bool confVon = true;

		// Token: 0x04000015 RID: 21
		public int confVonQuality = 3;

		// Token: 0x04000016 RID: 22
		public bool confPersistent = true;

		// Token: 0x04000017 RID: 23
		public string confDoubleIdDetected = string.Empty;

		// Token: 0x04000018 RID: 24
		public string confOnUserConnected = string.Empty;

		// Token: 0x04000019 RID: 25
		public string confOnUserDisconnected = string.Empty;

		// Token: 0x0400001A RID: 26
		public string confOnUnsignedData = string.Empty;

		// Token: 0x0400001B RID: 27
		public string confOnHackedData = string.Empty;

		// Token: 0x0400001C RID: 28
		public string confOnDifferentData = string.Empty;

		// Token: 0x0400001D RID: 29
		public string confDifficulty = string.Empty;

		// Token: 0x0400001E RID: 30
		public string confTemplate = string.Empty;

		// Token: 0x0400001F RID: 31
		public bool confRmod = false;

		// Token: 0x04000020 RID: 32
		public int confTimezone = 0;

		// Token: 0x04000021 RID: 33
		public int confStaticHour = 12;

		// Token: 0x04000022 RID: 34
		public bool confDaytime = false;

		// Token: 0x04000023 RID: 35
		public int confSecureId = 1;

		// Token: 0x04000024 RID: 36
		public string confWelcome = string.Empty;

		// Token: 0x04000025 RID: 37
		public int confMaxCustomFileSize;

		// Token: 0x04000026 RID: 38
		public decimal confMinBandwidth;

		// Token: 0x04000027 RID: 39
		public decimal confMaxBandwidth;

		// Token: 0x04000028 RID: 40
		public decimal confMaxMsgSend;

		// Token: 0x04000029 RID: 41
		public decimal confMaxSizeGuaranteed;

		// Token: 0x0400002A RID: 42
		public decimal confMaxSizeNonguaranteed;

		// Token: 0x0400002B RID: 43
		public decimal confMinErrorToSend;

		// Token: 0x0400002C RID: 44
		public decimal confMinErrorToSendNear;

		// Token: 0x0400002D RID: 45
		public string dbHost = "127.0.0.1";

		// Token: 0x0400002E RID: 46
		public int dbPort = 3306;

		// Token: 0x0400002F RID: 47
		public string dbUser = string.Empty;

		// Token: 0x04000030 RID: 48
		public string dbPass = string.Empty;

		// Token: 0x04000031 RID: 49
		public string dbName = string.Empty;

		// Token: 0x04000032 RID: 50
		public string beHost = "127.0.0.1";

		// Token: 0x04000033 RID: 51
		public int bePort = 2302;

		// Token: 0x04000034 RID: 52
		public string bePass = string.Empty;

		// Token: 0x04000035 RID: 53
		public int beMaxPing = 300;

		// Token: 0x04000036 RID: 54
		public bool beWhitelistEnabled = false;

		// Token: 0x04000037 RID: 55
		public string beWhitelistMessage = string.Empty;

		// Token: 0x04000038 RID: 56
		public string beWhitelistHost = string.Empty;

		// Token: 0x04000039 RID: 57
		public int beWhitelistPort = 3306;

		// Token: 0x0400003A RID: 58
		public string beWhitelistUser = string.Empty;

		// Token: 0x0400003B RID: 59
		public string beWhitelistPass = string.Empty;

		// Token: 0x0400003C RID: 60
		public string beWhitelistName = string.Empty;

		// Token: 0x0400003D RID: 61
		public string pathArma = string.Empty;

		// Token: 0x0400003E RID: 62
		public string pathMain = string.Empty;

		// Token: 0x0400003F RID: 63
		public string pathConfig = string.Empty;

		// Token: 0x04000040 RID: 64
		public string pathConfigAdmin = string.Empty;

		// Token: 0x04000041 RID: 65
		public string pathConfigBasic = string.Empty;

		// Token: 0x04000042 RID: 66
		public string pathConfigBattleye = string.Empty;

		// Token: 0x04000043 RID: 67
		public string pathConfigCfg = string.Empty;

		// Token: 0x04000044 RID: 68
		public string pathConfigHive = string.Empty;

		// Token: 0x04000045 RID: 69
		public string pathConfigXml = string.Empty;

		// Token: 0x04000046 RID: 70
		private static Logger logger = LogManager.GetCurrentClassLogger();
	}
}
