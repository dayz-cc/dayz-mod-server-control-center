using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Xml;
using NLog.Common;
using NLog.Filters;
using NLog.Internal;
using NLog.Layouts;
using NLog.Targets;
using NLog.Targets.Wrappers;
using NLog.Time;

namespace NLog.Config
{
	/// <summary>
	/// A class for configuring NLog through an XML configuration file 
	/// (App.config style or App.nlog style).
	/// </summary>
	// Token: 0x0200003C RID: 60
	public class XmlLoggingConfiguration : LoggingConfiguration
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Config.XmlLoggingConfiguration" /> class.
		/// </summary>
		/// <param name="fileName">Configuration file to be read.</param>
		// Token: 0x06000194 RID: 404 RVA: 0x000075C0 File Offset: 0x000057C0
		public XmlLoggingConfiguration(string fileName)
		{
			using (XmlReader xmlReader = XmlReader.Create(fileName))
			{
				this.Initialize(xmlReader, fileName, false);
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Config.XmlLoggingConfiguration" /> class.
		/// </summary>
		/// <param name="fileName">Configuration file to be read.</param>
		/// <param name="ignoreErrors">Ignore any errors during configuration.</param>
		// Token: 0x06000195 RID: 405 RVA: 0x00007638 File Offset: 0x00005838
		public XmlLoggingConfiguration(string fileName, bool ignoreErrors)
		{
			using (XmlReader xmlReader = XmlReader.Create(fileName))
			{
				this.Initialize(xmlReader, fileName, ignoreErrors);
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Config.XmlLoggingConfiguration" /> class.
		/// </summary>
		/// <param name="reader"><see cref="T:System.Xml.XmlReader" /> containing the configuration section.</param>
		/// <param name="fileName">Name of the file that contains the element (to be used as a base for including other files).</param>
		// Token: 0x06000196 RID: 406 RVA: 0x000076B0 File Offset: 0x000058B0
		public XmlLoggingConfiguration(XmlReader reader, string fileName)
		{
			this.Initialize(reader, fileName, false);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Config.XmlLoggingConfiguration" /> class.
		/// </summary>
		/// <param name="reader"><see cref="T:System.Xml.XmlReader" /> containing the configuration section.</param>
		/// <param name="fileName">Name of the file that contains the element (to be used as a base for including other files).</param>
		/// <param name="ignoreErrors">Ignore any errors during configuration.</param>
		// Token: 0x06000197 RID: 407 RVA: 0x000076F0 File Offset: 0x000058F0
		public XmlLoggingConfiguration(XmlReader reader, string fileName, bool ignoreErrors)
		{
			this.Initialize(reader, fileName, ignoreErrors);
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Config.XmlLoggingConfiguration" /> class.
		/// </summary>
		/// <param name="element">The XML element.</param>
		/// <param name="fileName">Name of the XML file.</param>
		// Token: 0x06000198 RID: 408 RVA: 0x00007730 File Offset: 0x00005930
		internal XmlLoggingConfiguration(XmlElement element, string fileName)
		{
			using (StringReader stringReader = new StringReader(element.OuterXml))
			{
				XmlReader xmlReader = XmlReader.Create(stringReader);
				this.Initialize(xmlReader, fileName, false);
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Config.XmlLoggingConfiguration" /> class.
		/// </summary>
		/// <param name="element">The XML element.</param>
		/// <param name="fileName">Name of the XML file.</param>
		/// <param name="ignoreErrors">If set to <c>true</c> errors will be ignored during file processing.</param>
		// Token: 0x06000199 RID: 409 RVA: 0x000077B4 File Offset: 0x000059B4
		internal XmlLoggingConfiguration(XmlElement element, string fileName, bool ignoreErrors)
		{
			using (StringReader stringReader = new StringReader(element.OuterXml))
			{
				XmlReader xmlReader = XmlReader.Create(stringReader);
				this.Initialize(xmlReader, fileName, ignoreErrors);
			}
		}

		/// <summary>
		/// Gets the default <see cref="T:NLog.Config.LoggingConfiguration" /> object by parsing 
		/// the application configuration file (<c>app.exe.config</c>).
		/// </summary>
		// Token: 0x17000058 RID: 88
		// (get) Token: 0x0600019A RID: 410 RVA: 0x00007838 File Offset: 0x00005A38
		public static LoggingConfiguration AppConfig
		{
			get
			{
				object section = global::System.Configuration.ConfigurationManager.GetSection("nlog");
				return section as LoggingConfiguration;
			}
		}

		/// <summary>
		/// Gets or sets a value indicating whether the configuration files
		/// should be watched for changes and reloaded automatically when changed.
		/// </summary>
		// Token: 0x17000059 RID: 89
		// (get) Token: 0x0600019B RID: 411 RVA: 0x0000785C File Offset: 0x00005A5C
		// (set) Token: 0x0600019C RID: 412 RVA: 0x00007873 File Offset: 0x00005A73
		public bool AutoReload { get; set; }

		/// <summary>
		/// Gets the collection of file names which should be watched for changes by NLog.
		/// This is the list of configuration files processed.
		/// If the <c>autoReload</c> attribute is not set it returns empty collection.
		/// </summary>
		// Token: 0x1700005A RID: 90
		// (get) Token: 0x0600019D RID: 413 RVA: 0x0000787C File Offset: 0x00005A7C
		public override IEnumerable<string> FileNamesToWatch
		{
			get
			{
				IEnumerable<string> enumerable;
				if (this.AutoReload)
				{
					enumerable = this.visitedFile.Keys;
				}
				else
				{
					enumerable = new string[0];
				}
				return enumerable;
			}
		}

		/// <summary>
		/// Re-reads the original configuration file and returns the new <see cref="T:NLog.Config.LoggingConfiguration" /> object.
		/// </summary>
		/// <returns>The new <see cref="T:NLog.Config.XmlLoggingConfiguration" /> object.</returns>
		// Token: 0x0600019E RID: 414 RVA: 0x000078B0 File Offset: 0x00005AB0
		public override LoggingConfiguration Reload()
		{
			return new XmlLoggingConfiguration(this.originalFileName);
		}

		// Token: 0x0600019F RID: 415 RVA: 0x000078D0 File Offset: 0x00005AD0
		private static bool IsTargetElement(string name)
		{
			return name.Equals("target", StringComparison.OrdinalIgnoreCase) || name.Equals("wrapper", StringComparison.OrdinalIgnoreCase) || name.Equals("wrapper-target", StringComparison.OrdinalIgnoreCase) || name.Equals("compound-target", StringComparison.OrdinalIgnoreCase);
		}

		// Token: 0x060001A0 RID: 416 RVA: 0x0000791C File Offset: 0x00005B1C
		private static bool IsTargetRefElement(string name)
		{
			return name.Equals("target-ref", StringComparison.OrdinalIgnoreCase) || name.Equals("wrapper-target-ref", StringComparison.OrdinalIgnoreCase) || name.Equals("compound-target-ref", StringComparison.OrdinalIgnoreCase);
		}

		// Token: 0x060001A1 RID: 417 RVA: 0x0000795C File Offset: 0x00005B5C
		private static string CleanWhitespace(string s)
		{
			s = s.Replace(" ", string.Empty);
			return s;
		}

		// Token: 0x060001A2 RID: 418 RVA: 0x00007984 File Offset: 0x00005B84
		private static string StripOptionalNamespacePrefix(string attributeValue)
		{
			string text;
			if (attributeValue == null)
			{
				text = null;
			}
			else
			{
				int num = attributeValue.IndexOf(':');
				if (num < 0)
				{
					text = attributeValue;
				}
				else
				{
					text = attributeValue.Substring(num + 1);
				}
			}
			return text;
		}

		// Token: 0x060001A3 RID: 419 RVA: 0x000079C8 File Offset: 0x00005BC8
		[SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "Target is disposed elsewhere.")]
		private static Target WrapWithAsyncTargetWrapper(Target target)
		{
			AsyncTargetWrapper asyncTargetWrapper = new AsyncTargetWrapper();
			asyncTargetWrapper.WrappedTarget = target;
			asyncTargetWrapper.Name = target.Name;
			target.Name += "_wrapped";
			InternalLogger.Debug("Wrapping target '{0}' with AsyncTargetWrapper and renaming to '{1}", new object[] { asyncTargetWrapper.Name, target.Name });
			target = asyncTargetWrapper;
			return target;
		}

		/// <summary>
		/// Initializes the configuration.
		/// </summary>
		/// <param name="reader"><see cref="T:System.Xml.XmlReader" /> containing the configuration section.</param>
		/// <param name="fileName">Name of the file that contains the element (to be used as a base for including other files).</param>
		/// <param name="ignoreErrors">Ignore any errors during configuration.</param>
		// Token: 0x060001A4 RID: 420 RVA: 0x00007A38 File Offset: 0x00005C38
		private void Initialize(XmlReader reader, string fileName, bool ignoreErrors)
		{
			try
			{
				reader.MoveToContent();
				NLogXmlElement nlogXmlElement = new NLogXmlElement(reader);
				if (fileName != null)
				{
					string fullPath = Path.GetFullPath(fileName);
					this.visitedFile[fullPath] = true;
					this.originalFileName = fileName;
					this.ParseTopLevel(nlogXmlElement, Path.GetDirectoryName(fileName));
					InternalLogger.Info("Configured from an XML element in {0}...", new object[] { fileName });
				}
				else
				{
					this.ParseTopLevel(nlogXmlElement, null);
				}
			}
			catch (Exception ex)
			{
				if (ex.MustBeRethrown())
				{
					throw;
				}
				NLogConfigurationException ex2 = new NLogConfigurationException("Exception occurred when loading configuration from " + fileName, ex);
				if (!ignoreErrors)
				{
					if (LogManager.ThrowExceptions)
					{
						throw ex2;
					}
					InternalLogger.Error("Error in Parsing Configuration File. Exception : {0}", new object[] { ex2 });
				}
				else
				{
					InternalLogger.Error("Error in Parsing Configuration File. Exception : {0}", new object[] { ex2 });
				}
			}
		}

		// Token: 0x060001A5 RID: 421 RVA: 0x00007B44 File Offset: 0x00005D44
		private void ConfigureFromFile(string fileName)
		{
			string fullPath = Path.GetFullPath(fileName);
			if (!this.visitedFile.ContainsKey(fullPath))
			{
				this.visitedFile[fullPath] = true;
				this.ParseTopLevel(new NLogXmlElement(fileName), Path.GetDirectoryName(fileName));
			}
		}

		// Token: 0x060001A6 RID: 422 RVA: 0x00007B90 File Offset: 0x00005D90
		private void ParseTopLevel(NLogXmlElement content, string baseDirectory)
		{
			content.AssertName(new string[] { "nlog", "configuration" });
			string text = content.LocalName.ToUpper(CultureInfo.InvariantCulture);
			if (text != null)
			{
				if (!(text == "CONFIGURATION"))
				{
					if (text == "NLOG")
					{
						this.ParseNLogElement(content, baseDirectory);
					}
				}
				else
				{
					this.ParseConfigurationElement(content, baseDirectory);
				}
			}
		}

		// Token: 0x060001A7 RID: 423 RVA: 0x00007C04 File Offset: 0x00005E04
		private void ParseConfigurationElement(NLogXmlElement configurationElement, string baseDirectory)
		{
			InternalLogger.Trace("ParseConfigurationElement");
			configurationElement.AssertName(new string[] { "configuration" });
			foreach (NLogXmlElement nlogXmlElement in configurationElement.Elements("nlog"))
			{
				this.ParseNLogElement(nlogXmlElement, baseDirectory);
			}
		}

		// Token: 0x060001A8 RID: 424 RVA: 0x00007C88 File Offset: 0x00005E88
		private void ParseNLogElement(NLogXmlElement nlogElement, string baseDirectory)
		{
			InternalLogger.Trace("ParseNLogElement");
			nlogElement.AssertName(new string[] { "nlog" });
			if (nlogElement.GetOptionalBooleanAttribute("useInvariantCulture", false))
			{
				base.DefaultCultureInfo = CultureInfo.InvariantCulture;
			}
			this.AutoReload = nlogElement.GetOptionalBooleanAttribute("autoReload", false);
			LogManager.ThrowExceptions = nlogElement.GetOptionalBooleanAttribute("throwExceptions", LogManager.ThrowExceptions);
			InternalLogger.LogToConsole = nlogElement.GetOptionalBooleanAttribute("internalLogToConsole", InternalLogger.LogToConsole);
			InternalLogger.LogToConsoleError = nlogElement.GetOptionalBooleanAttribute("internalLogToConsoleError", InternalLogger.LogToConsoleError);
			InternalLogger.LogFile = nlogElement.GetOptionalAttribute("internalLogFile", InternalLogger.LogFile);
			InternalLogger.LogLevel = LogLevel.FromString(nlogElement.GetOptionalAttribute("internalLogLevel", InternalLogger.LogLevel.Name));
			LogManager.GlobalThreshold = LogLevel.FromString(nlogElement.GetOptionalAttribute("globalThreshold", LogManager.GlobalThreshold.Name));
			foreach (NLogXmlElement nlogXmlElement in nlogElement.Children)
			{
				string text = nlogXmlElement.LocalName.ToUpper(CultureInfo.InvariantCulture);
				if (text == null)
				{
					goto IL_207;
				}
				if (<PrivateImplementationDetails>{BBCF4E57-A9FD-4325-AEE4-DEFF1302A7F6}.$$method0x60001a2-1 == null)
				{
					<PrivateImplementationDetails>{BBCF4E57-A9FD-4325-AEE4-DEFF1302A7F6}.$$method0x60001a2-1 = new Dictionary<string, int>(7)
					{
						{ "EXTENSIONS", 0 },
						{ "INCLUDE", 1 },
						{ "APPENDERS", 2 },
						{ "TARGETS", 3 },
						{ "VARIABLE", 4 },
						{ "RULES", 5 },
						{ "TIME", 6 }
					};
				}
				int num;
				if (!<PrivateImplementationDetails>{BBCF4E57-A9FD-4325-AEE4-DEFF1302A7F6}.$$method0x60001a2-1.TryGetValue(text, out num))
				{
					goto IL_207;
				}
				switch (num)
				{
				case 0:
					this.ParseExtensionsElement(nlogXmlElement, baseDirectory);
					break;
				case 1:
					this.ParseIncludeElement(nlogXmlElement, baseDirectory);
					break;
				case 2:
				case 3:
					this.ParseTargetsElement(nlogXmlElement);
					break;
				case 4:
					this.ParseVariableElement(nlogXmlElement);
					break;
				case 5:
					this.ParseRulesElement(nlogXmlElement, base.LoggingRules);
					break;
				case 6:
					this.ParseTimeElement(nlogXmlElement);
					break;
				default:
					goto IL_207;
				}
				continue;
				IL_207:
				InternalLogger.Warn("Skipping unknown node: {0}", new object[] { nlogXmlElement.LocalName });
			}
		}

		// Token: 0x060001A9 RID: 425 RVA: 0x00007EFC File Offset: 0x000060FC
		private void ParseRulesElement(NLogXmlElement rulesElement, IList<LoggingRule> rulesCollection)
		{
			InternalLogger.Trace("ParseRulesElement");
			rulesElement.AssertName(new string[] { "rules" });
			foreach (NLogXmlElement nlogXmlElement in rulesElement.Elements("logger"))
			{
				this.ParseLoggerElement(nlogXmlElement, rulesCollection);
			}
		}

		// Token: 0x060001AA RID: 426 RVA: 0x00007F80 File Offset: 0x00006180
		private void ParseLoggerElement(NLogXmlElement loggerElement, IList<LoggingRule> rulesCollection)
		{
			loggerElement.AssertName(new string[] { "logger" });
			string optionalAttribute = loggerElement.GetOptionalAttribute("name", "*");
			if (!loggerElement.GetOptionalBooleanAttribute("enabled", true))
			{
				InternalLogger.Debug("The logger named '{0}' are disabled");
			}
			else
			{
				LoggingRule loggingRule = new LoggingRule();
				string text = loggerElement.GetOptionalAttribute("appendTo", null);
				if (text == null)
				{
					text = loggerElement.GetOptionalAttribute("writeTo", null);
				}
				loggingRule.LoggerNamePattern = optionalAttribute;
				if (text != null)
				{
					foreach (string text2 in text.Split(new char[] { ',' }))
					{
						string text3 = text2.Trim();
						Target target = base.FindTargetByName(text3);
						if (target == null)
						{
							throw new NLogConfigurationException("Target " + text3 + " not found.");
						}
						loggingRule.Targets.Add(target);
					}
				}
				loggingRule.Final = loggerElement.GetOptionalBooleanAttribute("final", false);
				string text4;
				if (loggerElement.AttributeValues.TryGetValue("level", out text4))
				{
					LogLevel logLevel = LogLevel.FromString(text4);
					loggingRule.EnableLoggingForLevel(logLevel);
				}
				else if (loggerElement.AttributeValues.TryGetValue("levels", out text4))
				{
					text4 = XmlLoggingConfiguration.CleanWhitespace(text4);
					string[] array2 = text4.Split(new char[] { ',' });
					foreach (string text5 in array2)
					{
						if (!string.IsNullOrEmpty(text5))
						{
							LogLevel logLevel = LogLevel.FromString(text5);
							loggingRule.EnableLoggingForLevel(logLevel);
						}
					}
				}
				else
				{
					int num = 0;
					int num2 = LogLevel.MaxLevel.Ordinal;
					string text6;
					if (loggerElement.AttributeValues.TryGetValue("minLevel", out text6))
					{
						num = LogLevel.FromString(text6).Ordinal;
					}
					string text7;
					if (loggerElement.AttributeValues.TryGetValue("maxLevel", out text7))
					{
						num2 = LogLevel.FromString(text7).Ordinal;
					}
					for (int j = num; j <= num2; j++)
					{
						loggingRule.EnableLoggingForLevel(LogLevel.FromOrdinal(j));
					}
				}
				foreach (NLogXmlElement nlogXmlElement in loggerElement.Children)
				{
					string text8 = nlogXmlElement.LocalName.ToUpper(CultureInfo.InvariantCulture);
					if (text8 != null)
					{
						if (!(text8 == "FILTERS"))
						{
							if (text8 == "LOGGER")
							{
								this.ParseLoggerElement(nlogXmlElement, loggingRule.ChildRules);
							}
						}
						else
						{
							this.ParseFilters(loggingRule, nlogXmlElement);
						}
					}
				}
				rulesCollection.Add(loggingRule);
			}
		}

		// Token: 0x060001AB RID: 427 RVA: 0x000082B8 File Offset: 0x000064B8
		private void ParseFilters(LoggingRule rule, NLogXmlElement filtersElement)
		{
			filtersElement.AssertName(new string[] { "filters" });
			foreach (NLogXmlElement nlogXmlElement in filtersElement.Children)
			{
				string localName = nlogXmlElement.LocalName;
				Filter filter = this.configurationItemFactory.Filters.CreateInstance(localName);
				this.ConfigureObjectFromAttributes(filter, nlogXmlElement, false);
				rule.Filters.Add(filter);
			}
		}

		// Token: 0x060001AC RID: 428 RVA: 0x0000835C File Offset: 0x0000655C
		private void ParseVariableElement(NLogXmlElement variableElement)
		{
			variableElement.AssertName(new string[] { "variable" });
			string requiredAttribute = variableElement.GetRequiredAttribute("name");
			string text = this.ExpandVariables(variableElement.GetRequiredAttribute("value"));
			this.variables[requiredAttribute] = text;
		}

		// Token: 0x060001AD RID: 429 RVA: 0x000083B0 File Offset: 0x000065B0
		private void ParseTargetsElement(NLogXmlElement targetsElement)
		{
			targetsElement.AssertName(new string[] { "targets", "appenders" });
			bool optionalBooleanAttribute = targetsElement.GetOptionalBooleanAttribute("async", false);
			NLogXmlElement nlogXmlElement = null;
			Dictionary<string, NLogXmlElement> dictionary = new Dictionary<string, NLogXmlElement>();
			foreach (NLogXmlElement nlogXmlElement2 in targetsElement.Children)
			{
				string localName = nlogXmlElement2.LocalName;
				string text = XmlLoggingConfiguration.StripOptionalNamespacePrefix(nlogXmlElement2.GetOptionalAttribute("type", null));
				string text2 = localName.ToUpper(CultureInfo.InvariantCulture);
				switch (text2)
				{
				case "DEFAULT-WRAPPER":
					nlogXmlElement = nlogXmlElement2;
					break;
				case "DEFAULT-TARGET-PARAMETERS":
					if (text == null)
					{
						throw new NLogConfigurationException("Missing 'type' attribute on <" + localName + "/>.");
					}
					dictionary[text] = nlogXmlElement2;
					break;
				case "TARGET":
				case "APPENDER":
				case "WRAPPER":
				case "WRAPPER-TARGET":
				case "COMPOUND-TARGET":
				{
					if (text == null)
					{
						throw new NLogConfigurationException("Missing 'type' attribute on <" + localName + "/>.");
					}
					Target target = this.configurationItemFactory.Targets.CreateInstance(text);
					NLogXmlElement nlogXmlElement3;
					if (dictionary.TryGetValue(text, out nlogXmlElement3))
					{
						this.ParseTargetElement(target, nlogXmlElement3);
					}
					this.ParseTargetElement(target, nlogXmlElement2);
					if (optionalBooleanAttribute)
					{
						target = XmlLoggingConfiguration.WrapWithAsyncTargetWrapper(target);
					}
					if (nlogXmlElement != null)
					{
						target = this.WrapWithDefaultWrapper(target, nlogXmlElement);
					}
					InternalLogger.Info("Adding target {0}", new object[] { target });
					base.AddTarget(target.Name, target);
					break;
				}
				}
			}
		}

		// Token: 0x060001AE RID: 430 RVA: 0x00008628 File Offset: 0x00006828
		private void ParseTargetElement(Target target, NLogXmlElement targetElement)
		{
			CompoundTargetBase compoundTargetBase = target as CompoundTargetBase;
			WrapperTargetBase wrapperTargetBase = target as WrapperTargetBase;
			this.ConfigureObjectFromAttributes(target, targetElement, true);
			foreach (NLogXmlElement nlogXmlElement in targetElement.Children)
			{
				string localName = nlogXmlElement.LocalName;
				if (compoundTargetBase != null)
				{
					if (XmlLoggingConfiguration.IsTargetRefElement(localName))
					{
						string text = nlogXmlElement.GetRequiredAttribute("name");
						Target target2 = base.FindTargetByName(text);
						if (target2 == null)
						{
							throw new NLogConfigurationException("Referenced target '" + text + "' not found.");
						}
						compoundTargetBase.Targets.Add(target2);
						continue;
					}
					else if (XmlLoggingConfiguration.IsTargetElement(localName))
					{
						string text2 = XmlLoggingConfiguration.StripOptionalNamespacePrefix(nlogXmlElement.GetRequiredAttribute("type"));
						Target target2 = this.configurationItemFactory.Targets.CreateInstance(text2);
						if (target2 != null)
						{
							this.ParseTargetElement(target2, nlogXmlElement);
							if (target2.Name != null)
							{
								base.AddTarget(target2.Name, target2);
							}
							compoundTargetBase.Targets.Add(target2);
						}
						continue;
					}
				}
				if (wrapperTargetBase != null)
				{
					if (XmlLoggingConfiguration.IsTargetRefElement(localName))
					{
						string text = nlogXmlElement.GetRequiredAttribute("name");
						Target target2 = base.FindTargetByName(text);
						if (target2 == null)
						{
							throw new NLogConfigurationException("Referenced target '" + text + "' not found.");
						}
						wrapperTargetBase.WrappedTarget = target2;
						continue;
					}
					else if (XmlLoggingConfiguration.IsTargetElement(localName))
					{
						string text2 = XmlLoggingConfiguration.StripOptionalNamespacePrefix(nlogXmlElement.GetRequiredAttribute("type"));
						Target target2 = this.configurationItemFactory.Targets.CreateInstance(text2);
						if (target2 != null)
						{
							this.ParseTargetElement(target2, nlogXmlElement);
							if (target2.Name != null)
							{
								base.AddTarget(target2.Name, target2);
							}
							if (wrapperTargetBase.WrappedTarget != null)
							{
								throw new NLogConfigurationException("Wrapped target already defined.");
							}
							wrapperTargetBase.WrappedTarget = target2;
						}
						continue;
					}
				}
				this.SetPropertyFromElement(target, nlogXmlElement);
			}
		}

		// Token: 0x060001AF RID: 431 RVA: 0x000088B4 File Offset: 0x00006AB4
		[SuppressMessage("Microsoft.Reliability", "CA2001:AvoidCallingProblematicMethods", MessageId = "System.Reflection.Assembly.LoadFrom", Justification = "Need to load external assembly.")]
		private void ParseExtensionsElement(NLogXmlElement extensionsElement, string baseDirectory)
		{
			extensionsElement.AssertName(new string[] { "extensions" });
			foreach (NLogXmlElement nlogXmlElement in extensionsElement.Elements("add"))
			{
				string text = nlogXmlElement.GetOptionalAttribute("prefix", null);
				if (text != null)
				{
					text += ".";
				}
				string text2 = XmlLoggingConfiguration.StripOptionalNamespacePrefix(nlogXmlElement.GetOptionalAttribute("type", null));
				if (text2 != null)
				{
					this.configurationItemFactory.RegisterType(Type.GetType(text2, true), text);
				}
				string optionalAttribute = nlogXmlElement.GetOptionalAttribute("assemblyFile", null);
				if (optionalAttribute != null)
				{
					try
					{
						string text3 = Path.Combine(baseDirectory, optionalAttribute);
						InternalLogger.Info("Loading assembly file: {0}", new object[] { text3 });
						Assembly assembly = Assembly.LoadFrom(text3);
						this.configurationItemFactory.RegisterItemsFromAssembly(assembly, text);
					}
					catch (Exception ex)
					{
						if (ex.MustBeRethrown())
						{
							throw;
						}
						InternalLogger.Error("Error loading extensions: {0}", new object[] { ex });
						if (LogManager.ThrowExceptions)
						{
							throw new NLogConfigurationException("Error loading extensions: " + optionalAttribute, ex);
						}
					}
				}
				else
				{
					string optionalAttribute2 = nlogXmlElement.GetOptionalAttribute("assembly", null);
					if (optionalAttribute2 != null)
					{
						try
						{
							InternalLogger.Info("Loading assembly name: {0}", new object[] { optionalAttribute2 });
							Assembly assembly = Assembly.Load(optionalAttribute2);
							this.configurationItemFactory.RegisterItemsFromAssembly(assembly, text);
						}
						catch (Exception ex)
						{
							if (ex.MustBeRethrown())
							{
								throw;
							}
							InternalLogger.Error("Error loading extensions: {0}", new object[] { ex });
							if (LogManager.ThrowExceptions)
							{
								throw new NLogConfigurationException("Error loading extensions: " + optionalAttribute2, ex);
							}
						}
					}
				}
			}
		}

		// Token: 0x060001B0 RID: 432 RVA: 0x00008B30 File Offset: 0x00006D30
		private void ParseIncludeElement(NLogXmlElement includeElement, string baseDirectory)
		{
			includeElement.AssertName(new string[] { "include" });
			string text = includeElement.GetRequiredAttribute("file");
			try
			{
				text = this.ExpandVariables(text);
				text = SimpleLayout.Evaluate(text);
				if (baseDirectory != null)
				{
					text = Path.Combine(baseDirectory, text);
				}
				if (!File.Exists(text))
				{
					throw new FileNotFoundException("Included file not found: " + text);
				}
				InternalLogger.Debug("Including file '{0}'", new object[] { text });
				this.ConfigureFromFile(text);
			}
			catch (Exception ex)
			{
				if (ex.MustBeRethrown())
				{
					throw;
				}
				InternalLogger.Error("Error when including '{0}' {1}", new object[] { text, ex });
				if (!includeElement.GetOptionalBooleanAttribute("ignoreErrors", false))
				{
					throw new NLogConfigurationException("Error when including: " + text, ex);
				}
			}
		}

		// Token: 0x060001B1 RID: 433 RVA: 0x00008C38 File Offset: 0x00006E38
		private void ParseTimeElement(NLogXmlElement timeElement)
		{
			timeElement.AssertName(new string[] { "time" });
			string requiredAttribute = timeElement.GetRequiredAttribute("type");
			TimeSource timeSource = this.configurationItemFactory.TimeSources.CreateInstance(requiredAttribute);
			this.ConfigureObjectFromAttributes(timeSource, timeElement, true);
			InternalLogger.Info("Selecting time source {0}", new object[] { timeSource });
			TimeSource.Current = timeSource;
		}

		// Token: 0x060001B2 RID: 434 RVA: 0x00008CA4 File Offset: 0x00006EA4
		private void SetPropertyFromElement(object o, NLogXmlElement element)
		{
			if (!this.AddArrayItemFromElement(o, element))
			{
				if (!this.SetLayoutFromElement(o, element))
				{
					PropertyHelper.SetPropertyFromString(o, element.LocalName, this.ExpandVariables(element.Value), this.configurationItemFactory);
				}
			}
		}

		// Token: 0x060001B3 RID: 435 RVA: 0x00008CF8 File Offset: 0x00006EF8
		private bool AddArrayItemFromElement(object o, NLogXmlElement element)
		{
			string localName = element.LocalName;
			PropertyInfo propertyInfo;
			bool flag;
			if (!PropertyHelper.TryGetPropertyInfo(o, localName, out propertyInfo))
			{
				flag = false;
			}
			else
			{
				Type arrayItemType = PropertyHelper.GetArrayItemType(propertyInfo);
				if (arrayItemType != null)
				{
					IList list = (IList)propertyInfo.GetValue(o, null);
					object obj = FactoryHelper.CreateInstance(arrayItemType);
					this.ConfigureObjectFromAttributes(obj, element, true);
					this.ConfigureObjectFromElement(obj, element);
					list.Add(obj);
					flag = true;
				}
				else
				{
					flag = false;
				}
			}
			return flag;
		}

		// Token: 0x060001B4 RID: 436 RVA: 0x00008D7C File Offset: 0x00006F7C
		private void ConfigureObjectFromAttributes(object targetObject, NLogXmlElement element, bool ignoreType)
		{
			foreach (KeyValuePair<string, string> keyValuePair in element.AttributeValues)
			{
				string key = keyValuePair.Key;
				string value = keyValuePair.Value;
				if (!ignoreType || !key.Equals("type", StringComparison.OrdinalIgnoreCase))
				{
					PropertyHelper.SetPropertyFromString(targetObject, key, this.ExpandVariables(value), this.configurationItemFactory);
				}
			}
		}

		// Token: 0x060001B5 RID: 437 RVA: 0x00008E18 File Offset: 0x00007018
		private bool SetLayoutFromElement(object o, NLogXmlElement layoutElement)
		{
			string localName = layoutElement.LocalName;
			PropertyInfo propertyInfo;
			if (PropertyHelper.TryGetPropertyInfo(o, localName, out propertyInfo))
			{
				if (typeof(Layout).IsAssignableFrom(propertyInfo.PropertyType))
				{
					string text = XmlLoggingConfiguration.StripOptionalNamespacePrefix(layoutElement.GetOptionalAttribute("type", null));
					if (text != null)
					{
						Layout layout = this.configurationItemFactory.Layouts.CreateInstance(this.ExpandVariables(text));
						this.ConfigureObjectFromAttributes(layout, layoutElement, true);
						this.ConfigureObjectFromElement(layout, layoutElement);
						propertyInfo.SetValue(o, layout, null);
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x060001B6 RID: 438 RVA: 0x00008EC0 File Offset: 0x000070C0
		private void ConfigureObjectFromElement(object targetObject, NLogXmlElement element)
		{
			foreach (NLogXmlElement nlogXmlElement in element.Children)
			{
				this.SetPropertyFromElement(targetObject, nlogXmlElement);
			}
		}

		// Token: 0x060001B7 RID: 439 RVA: 0x00008F1C File Offset: 0x0000711C
		private Target WrapWithDefaultWrapper(Target t, NLogXmlElement defaultParameters)
		{
			string text = XmlLoggingConfiguration.StripOptionalNamespacePrefix(defaultParameters.GetRequiredAttribute("type"));
			Target target = this.configurationItemFactory.Targets.CreateInstance(text);
			WrapperTargetBase wrapperTargetBase = target as WrapperTargetBase;
			if (wrapperTargetBase == null)
			{
				throw new NLogConfigurationException("Target type specified on <default-wrapper /> is not a wrapper.");
			}
			this.ParseTargetElement(target, defaultParameters);
			while (wrapperTargetBase.WrappedTarget != null)
			{
				wrapperTargetBase = wrapperTargetBase.WrappedTarget as WrapperTargetBase;
				if (wrapperTargetBase == null)
				{
					throw new NLogConfigurationException("Child target type specified on <default-wrapper /> is not a wrapper.");
				}
			}
			wrapperTargetBase.WrappedTarget = t;
			target.Name = t.Name;
			t.Name += "_wrapped";
			InternalLogger.Debug("Wrapping target '{0}' with '{1}' and renaming to '{2}", new object[]
			{
				target.Name,
				target.GetType().Name,
				t.Name
			});
			return target;
		}

		// Token: 0x060001B8 RID: 440 RVA: 0x0000901C File Offset: 0x0000721C
		private string ExpandVariables(string input)
		{
			string text = input;
			foreach (KeyValuePair<string, string> keyValuePair in this.variables)
			{
				text = text.Replace("${" + keyValuePair.Key + "}", keyValuePair.Value);
			}
			return text;
		}

		// Token: 0x04000087 RID: 135
		private readonly ConfigurationItemFactory configurationItemFactory = ConfigurationItemFactory.Default;

		// Token: 0x04000088 RID: 136
		private readonly Dictionary<string, bool> visitedFile = new Dictionary<string, bool>(StringComparer.OrdinalIgnoreCase);

		// Token: 0x04000089 RID: 137
		private readonly Dictionary<string, string> variables = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

		// Token: 0x0400008A RID: 138
		private string originalFileName;
	}
}
