using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using NLog.Config;

namespace NLog.Layouts
{
	/// <summary>
	/// A specialized layout that renders CSV-formatted events.
	/// </summary>
	// Token: 0x020000DB RID: 219
	[Layout("CsvLayout")]
	[ThreadAgnostic]
	[AppDomainFixedOutput]
	public class CsvLayout : LayoutWithHeaderAndFooter
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Layouts.CsvLayout" /> class.
		/// </summary>
		// Token: 0x0600051F RID: 1311 RVA: 0x00011B38 File Offset: 0x0000FD38
		public CsvLayout()
		{
			this.Columns = new List<CsvColumn>();
			this.WithHeader = true;
			this.Delimiter = CsvColumnDelimiterMode.Auto;
			this.Quoting = CsvQuotingMode.Auto;
			this.QuoteChar = "\"";
			base.Layout = this;
			base.Header = new CsvLayout.CsvHeaderLayout(this);
			base.Footer = null;
		}

		/// <summary>
		/// Gets the array of parameters to be passed.
		/// </summary>
		/// <docgen category="CSV Options" order="10" />
		// Token: 0x17000123 RID: 291
		// (get) Token: 0x06000520 RID: 1312 RVA: 0x00011B9C File Offset: 0x0000FD9C
		// (set) Token: 0x06000521 RID: 1313 RVA: 0x00011BB3 File Offset: 0x0000FDB3
		[ArrayParameter(typeof(CsvColumn), "column")]
		public IList<CsvColumn> Columns { get; private set; }

		/// <summary>
		/// Gets or sets a value indicating whether CVS should include header.
		/// </summary>
		/// <value>A value of <c>true</c> if CVS should include header; otherwise, <c>false</c>.</value>
		/// <docgen category="CSV Options" order="10" />
		// Token: 0x17000124 RID: 292
		// (get) Token: 0x06000522 RID: 1314 RVA: 0x00011BBC File Offset: 0x0000FDBC
		// (set) Token: 0x06000523 RID: 1315 RVA: 0x00011BD3 File Offset: 0x0000FDD3
		public bool WithHeader { get; set; }

		/// <summary>
		/// Gets or sets the column delimiter.
		/// </summary>
		/// <docgen category="CSV Options" order="10" />
		// Token: 0x17000125 RID: 293
		// (get) Token: 0x06000524 RID: 1316 RVA: 0x00011BDC File Offset: 0x0000FDDC
		// (set) Token: 0x06000525 RID: 1317 RVA: 0x00011BF3 File Offset: 0x0000FDF3
		[DefaultValue("Auto")]
		public CsvColumnDelimiterMode Delimiter { get; set; }

		/// <summary>
		/// Gets or sets the quoting mode.
		/// </summary>
		/// <docgen category="CSV Options" order="10" />
		// Token: 0x17000126 RID: 294
		// (get) Token: 0x06000526 RID: 1318 RVA: 0x00011BFC File Offset: 0x0000FDFC
		// (set) Token: 0x06000527 RID: 1319 RVA: 0x00011C13 File Offset: 0x0000FE13
		[DefaultValue("Auto")]
		public CsvQuotingMode Quoting { get; set; }

		/// <summary>
		/// Gets or sets the quote Character.
		/// </summary>
		/// <docgen category="CSV Options" order="10" />
		// Token: 0x17000127 RID: 295
		// (get) Token: 0x06000528 RID: 1320 RVA: 0x00011C1C File Offset: 0x0000FE1C
		// (set) Token: 0x06000529 RID: 1321 RVA: 0x00011C33 File Offset: 0x0000FE33
		[DefaultValue("\"")]
		public string QuoteChar { get; set; }

		/// <summary>
		/// Gets or sets the custom column delimiter value (valid when ColumnDelimiter is set to 'Custom').
		/// </summary>
		/// <docgen category="CSV Options" order="10" />
		// Token: 0x17000128 RID: 296
		// (get) Token: 0x0600052A RID: 1322 RVA: 0x00011C3C File Offset: 0x0000FE3C
		// (set) Token: 0x0600052B RID: 1323 RVA: 0x00011C53 File Offset: 0x0000FE53
		public string CustomColumnDelimiter { get; set; }

		/// <summary>
		/// Initializes the layout.
		/// </summary>
		// Token: 0x0600052C RID: 1324 RVA: 0x00011C5C File Offset: 0x0000FE5C
		protected override void InitializeLayout()
		{
			base.InitializeLayout();
			if (!this.WithHeader)
			{
				base.Header = null;
			}
			switch (this.Delimiter)
			{
			case CsvColumnDelimiterMode.Auto:
				this.actualColumnDelimiter = CultureInfo.CurrentCulture.TextInfo.ListSeparator;
				break;
			case CsvColumnDelimiterMode.Comma:
				this.actualColumnDelimiter = ",";
				break;
			case CsvColumnDelimiterMode.Semicolon:
				this.actualColumnDelimiter = ";";
				break;
			case CsvColumnDelimiterMode.Tab:
				this.actualColumnDelimiter = "\t";
				break;
			case CsvColumnDelimiterMode.Pipe:
				this.actualColumnDelimiter = "|";
				break;
			case CsvColumnDelimiterMode.Space:
				this.actualColumnDelimiter = " ";
				break;
			case CsvColumnDelimiterMode.Custom:
				this.actualColumnDelimiter = this.CustomColumnDelimiter;
				break;
			}
			this.quotableCharacters = (this.QuoteChar + "\r\n" + this.actualColumnDelimiter).ToCharArray();
			this.doubleQuoteChar = this.QuoteChar + this.QuoteChar;
		}

		/// <summary>
		/// Formats the log event for write.
		/// </summary>
		/// <param name="logEvent">The log event to be formatted.</param>
		/// <returns>A string representation of the log event.</returns>
		// Token: 0x0600052D RID: 1325 RVA: 0x00011D50 File Offset: 0x0000FF50
		protected override string GetFormattedMessage(LogEventInfo logEvent)
		{
			string text;
			string text2;
			if (logEvent.TryGetCachedLayoutValue(this, out text))
			{
				text2 = text;
			}
			else
			{
				StringBuilder stringBuilder = new StringBuilder();
				bool flag = true;
				foreach (CsvColumn csvColumn in this.Columns)
				{
					if (!flag)
					{
						stringBuilder.Append(this.actualColumnDelimiter);
					}
					flag = false;
					string text3 = csvColumn.Layout.Render(logEvent);
					bool flag2;
					switch (this.Quoting)
					{
					case CsvQuotingMode.All:
						flag2 = true;
						break;
					case CsvQuotingMode.Nothing:
						flag2 = false;
						break;
					case CsvQuotingMode.Auto:
						goto IL_8D;
					default:
						goto IL_8D;
					}
					IL_B1:
					if (flag2)
					{
						stringBuilder.Append(this.QuoteChar);
					}
					if (flag2)
					{
						stringBuilder.Append(text3.Replace(this.QuoteChar, this.doubleQuoteChar));
					}
					else
					{
						stringBuilder.Append(text3);
					}
					if (flag2)
					{
						stringBuilder.Append(this.QuoteChar);
					}
					continue;
					IL_8D:
					flag2 = text3.IndexOfAny(this.quotableCharacters) >= 0;
					goto IL_B1;
				}
				text2 = logEvent.AddCachedLayoutValue(this, stringBuilder.ToString());
			}
			return text2;
		}

		// Token: 0x0600052E RID: 1326 RVA: 0x00011EC4 File Offset: 0x000100C4
		private string GetHeader()
		{
			StringBuilder stringBuilder = new StringBuilder();
			bool flag = true;
			foreach (CsvColumn csvColumn in this.Columns)
			{
				if (!flag)
				{
					stringBuilder.Append(this.actualColumnDelimiter);
				}
				flag = false;
				string name = csvColumn.Name;
				bool flag2;
				switch (this.Quoting)
				{
				case CsvQuotingMode.All:
					flag2 = true;
					break;
				case CsvQuotingMode.Nothing:
					flag2 = false;
					break;
				case CsvQuotingMode.Auto:
					goto IL_6A;
				default:
					goto IL_6A;
				}
				IL_8C:
				if (flag2)
				{
					stringBuilder.Append(this.QuoteChar);
				}
				if (flag2)
				{
					stringBuilder.Append(name.Replace(this.QuoteChar, this.doubleQuoteChar));
				}
				else
				{
					stringBuilder.Append(name);
				}
				if (flag2)
				{
					stringBuilder.Append(this.QuoteChar);
				}
				continue;
				IL_6A:
				flag2 = name.IndexOfAny(this.quotableCharacters) >= 0;
				goto IL_8C;
			}
			return stringBuilder.ToString();
		}

		// Token: 0x040001C8 RID: 456
		private string actualColumnDelimiter;

		// Token: 0x040001C9 RID: 457
		private string doubleQuoteChar;

		// Token: 0x040001CA RID: 458
		private char[] quotableCharacters;

		/// <summary>
		/// Header for CSV layout.
		/// </summary>
		// Token: 0x020000DC RID: 220
		[ThreadAgnostic]
		private class CsvHeaderLayout : Layout
		{
			/// <summary>
			/// Initializes a new instance of the <see cref="T:NLog.Layouts.CsvLayout.CsvHeaderLayout" /> class.
			/// </summary>
			/// <param name="parent">The parent.</param>
			// Token: 0x0600052F RID: 1327 RVA: 0x00012008 File Offset: 0x00010208
			public CsvHeaderLayout(CsvLayout parent)
			{
				this.parent = parent;
			}

			/// <summary>
			/// Renders the layout for the specified logging event by invoking layout renderers.
			/// </summary>
			/// <param name="logEvent">The logging event.</param>
			/// <returns>The rendered layout.</returns>
			// Token: 0x06000530 RID: 1328 RVA: 0x0001201C File Offset: 0x0001021C
			protected override string GetFormattedMessage(LogEventInfo logEvent)
			{
				string text;
				string text2;
				if (logEvent.TryGetCachedLayoutValue(this, out text))
				{
					text2 = text;
				}
				else
				{
					text2 = logEvent.AddCachedLayoutValue(this, this.parent.GetHeader());
				}
				return text2;
			}

			// Token: 0x040001D1 RID: 465
			private CsvLayout parent;
		}
	}
}
