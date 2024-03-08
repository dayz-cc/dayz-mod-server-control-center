using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;

namespace NLog.Config
{
	/// <summary>
	/// Represents simple XML element with case-insensitive attribute semantics.
	/// </summary>
	// Token: 0x02000037 RID: 55
	internal class NLogXmlElement
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Config.NLogXmlElement" /> class.
		/// </summary>
		/// <param name="inputUri">The input URI.</param>
		// Token: 0x0600017B RID: 379 RVA: 0x00007124 File Offset: 0x00005324
		public NLogXmlElement(string inputUri)
			: this()
		{
			using (XmlReader xmlReader = XmlReader.Create(inputUri))
			{
				xmlReader.MoveToContent();
				this.Parse(xmlReader);
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Config.NLogXmlElement" /> class.
		/// </summary>
		/// <param name="reader">The reader to initialize element from.</param>
		// Token: 0x0600017C RID: 380 RVA: 0x00007178 File Offset: 0x00005378
		public NLogXmlElement(XmlReader reader)
			: this()
		{
			this.Parse(reader);
		}

		/// <summary>
		/// Prevents a default instance of the <see cref="T:NLog.Config.NLogXmlElement" /> class from being created.
		/// </summary>
		// Token: 0x0600017D RID: 381 RVA: 0x0000718B File Offset: 0x0000538B
		private NLogXmlElement()
		{
			this.AttributeValues = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
			this.Children = new List<NLogXmlElement>();
		}

		/// <summary>
		/// Gets the element name.
		/// </summary>
		// Token: 0x17000054 RID: 84
		// (get) Token: 0x0600017E RID: 382 RVA: 0x000071B4 File Offset: 0x000053B4
		// (set) Token: 0x0600017F RID: 383 RVA: 0x000071CB File Offset: 0x000053CB
		public string LocalName { get; private set; }

		/// <summary>
		/// Gets the dictionary of attribute values.
		/// </summary>
		// Token: 0x17000055 RID: 85
		// (get) Token: 0x06000180 RID: 384 RVA: 0x000071D4 File Offset: 0x000053D4
		// (set) Token: 0x06000181 RID: 385 RVA: 0x000071EB File Offset: 0x000053EB
		public Dictionary<string, string> AttributeValues { get; private set; }

		/// <summary>
		/// Gets the collection of child elements.
		/// </summary>
		// Token: 0x17000056 RID: 86
		// (get) Token: 0x06000182 RID: 386 RVA: 0x000071F4 File Offset: 0x000053F4
		// (set) Token: 0x06000183 RID: 387 RVA: 0x0000720B File Offset: 0x0000540B
		public IList<NLogXmlElement> Children { get; private set; }

		/// <summary>
		/// Gets the value of the element.
		/// </summary>
		// Token: 0x17000057 RID: 87
		// (get) Token: 0x06000184 RID: 388 RVA: 0x00007214 File Offset: 0x00005414
		// (set) Token: 0x06000185 RID: 389 RVA: 0x0000722B File Offset: 0x0000542B
		public string Value { get; private set; }

		/// <summary>
		/// Returns children elements with the specified element name.
		/// </summary>
		/// <param name="elementName">Name of the element.</param>
		/// <returns>Children elements with the specified element name.</returns>
		// Token: 0x06000186 RID: 390 RVA: 0x00007234 File Offset: 0x00005434
		public IEnumerable<NLogXmlElement> Elements(string elementName)
		{
			List<NLogXmlElement> list = new List<NLogXmlElement>();
			foreach (NLogXmlElement nlogXmlElement in this.Children)
			{
				if (nlogXmlElement.LocalName.Equals(elementName, StringComparison.OrdinalIgnoreCase))
				{
					list.Add(nlogXmlElement);
				}
			}
			return list;
		}

		/// <summary>
		/// Gets the required attribute.
		/// </summary>
		/// <param name="attributeName">Name of the attribute.</param>
		/// <returns>Attribute value.</returns>
		/// <remarks>Throws if the attribute is not specified.</remarks>
		// Token: 0x06000187 RID: 391 RVA: 0x000072B8 File Offset: 0x000054B8
		public string GetRequiredAttribute(string attributeName)
		{
			string optionalAttribute = this.GetOptionalAttribute(attributeName, null);
			if (optionalAttribute == null)
			{
				throw new NLogConfigurationException(string.Concat(new string[] { "Expected ", attributeName, " on <", this.LocalName, " />" }));
			}
			return optionalAttribute;
		}

		/// <summary>
		/// Gets the optional boolean attribute value.
		/// </summary>
		/// <param name="attributeName">Name of the attribute.</param>
		/// <param name="defaultValue">Default value to return if the attribute is not found.</param>
		/// <returns>Boolean attribute value or default.</returns>
		// Token: 0x06000188 RID: 392 RVA: 0x00007318 File Offset: 0x00005518
		public bool GetOptionalBooleanAttribute(string attributeName, bool defaultValue)
		{
			string text;
			bool flag;
			if (!this.AttributeValues.TryGetValue(attributeName, out text))
			{
				flag = defaultValue;
			}
			else
			{
				flag = Convert.ToBoolean(text, CultureInfo.InvariantCulture);
			}
			return flag;
		}

		/// <summary>
		/// Gets the optional attribute value.
		/// </summary>
		/// <param name="attributeName">Name of the attribute.</param>
		/// <param name="defaultValue">The default value.</param>
		/// <returns>Value of the attribute or default value.</returns>
		// Token: 0x06000189 RID: 393 RVA: 0x0000734C File Offset: 0x0000554C
		public string GetOptionalAttribute(string attributeName, string defaultValue)
		{
			string text;
			if (!this.AttributeValues.TryGetValue(attributeName, out text))
			{
				text = defaultValue;
			}
			return text;
		}

		/// <summary>
		/// Asserts that the name of the element is among specified element names.
		/// </summary>
		/// <param name="allowedNames">The allowed names.</param>
		// Token: 0x0600018A RID: 394 RVA: 0x00007378 File Offset: 0x00005578
		public void AssertName(params string[] allowedNames)
		{
			foreach (string text in allowedNames)
			{
				if (this.LocalName.Equals(text, StringComparison.OrdinalIgnoreCase))
				{
					return;
				}
			}
			throw new InvalidOperationException(string.Concat(new string[]
			{
				"Assertion failed. Expected element name '",
				string.Join("|", allowedNames),
				"', actual: '",
				this.LocalName,
				"'."
			}));
		}

		// Token: 0x0600018B RID: 395 RVA: 0x00007404 File Offset: 0x00005604
		private void Parse(XmlReader reader)
		{
			if (reader.MoveToFirstAttribute())
			{
				do
				{
					this.AttributeValues.Add(reader.LocalName, reader.Value);
				}
				while (reader.MoveToNextAttribute());
				reader.MoveToElement();
			}
			this.LocalName = reader.LocalName;
			if (!reader.IsEmptyElement)
			{
				while (reader.Read())
				{
					if (reader.NodeType == XmlNodeType.EndElement)
					{
						break;
					}
					if (reader.NodeType == XmlNodeType.CDATA || reader.NodeType == XmlNodeType.Text)
					{
						this.Value += reader.Value;
					}
					else if (reader.NodeType == XmlNodeType.Element)
					{
						this.Children.Add(new NLogXmlElement(reader));
					}
				}
			}
		}
	}
}
