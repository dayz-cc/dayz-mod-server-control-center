using System;
using System.Text;
using NLog.Internal;

namespace NLog.Conditions
{
	/// <summary>
	/// Hand-written tokenizer for conditions.
	/// </summary>
	// Token: 0x02000020 RID: 32
	internal sealed class ConditionTokenizer
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Conditions.ConditionTokenizer" /> class.
		/// </summary>
		/// <param name="stringReader">The string reader.</param>
		// Token: 0x060000DB RID: 219 RVA: 0x00004AC2 File Offset: 0x00002CC2
		public ConditionTokenizer(SimpleStringReader stringReader)
		{
			this.stringReader = stringReader;
			this.TokenType = ConditionTokenType.BeginningOfInput;
			this.GetNextToken();
		}

		/// <summary>
		/// Gets the token position.
		/// </summary>
		/// <value>The token position.</value>
		// Token: 0x17000031 RID: 49
		// (get) Token: 0x060000DC RID: 220 RVA: 0x00004AE4 File Offset: 0x00002CE4
		// (set) Token: 0x060000DD RID: 221 RVA: 0x00004AFB File Offset: 0x00002CFB
		public int TokenPosition { get; private set; }

		/// <summary>
		/// Gets the type of the token.
		/// </summary>
		/// <value>The type of the token.</value>
		// Token: 0x17000032 RID: 50
		// (get) Token: 0x060000DE RID: 222 RVA: 0x00004B04 File Offset: 0x00002D04
		// (set) Token: 0x060000DF RID: 223 RVA: 0x00004B1B File Offset: 0x00002D1B
		public ConditionTokenType TokenType { get; private set; }

		/// <summary>
		/// Gets the token value.
		/// </summary>
		/// <value>The token value.</value>
		// Token: 0x17000033 RID: 51
		// (get) Token: 0x060000E0 RID: 224 RVA: 0x00004B24 File Offset: 0x00002D24
		// (set) Token: 0x060000E1 RID: 225 RVA: 0x00004B3B File Offset: 0x00002D3B
		public string TokenValue { get; private set; }

		/// <summary>
		/// Gets the value of a string token.
		/// </summary>
		/// <value>The string token value.</value>
		// Token: 0x17000034 RID: 52
		// (get) Token: 0x060000E2 RID: 226 RVA: 0x00004B44 File Offset: 0x00002D44
		public string StringTokenValue
		{
			get
			{
				string tokenValue = this.TokenValue;
				return tokenValue.Substring(1, tokenValue.Length - 2).Replace("''", "'");
			}
		}

		/// <summary>
		/// Asserts current token type and advances to the next token.
		/// </summary>
		/// <param name="tokenType">Expected token type.</param>
		/// <remarks>If token type doesn't match, an exception is thrown.</remarks>
		// Token: 0x060000E3 RID: 227 RVA: 0x00004B7C File Offset: 0x00002D7C
		public void Expect(ConditionTokenType tokenType)
		{
			if (this.TokenType != tokenType)
			{
				throw new ConditionParseException(string.Concat(new object[] { "Expected token of type: ", tokenType, ", got ", this.TokenType, " (", this.TokenValue, ")." }));
			}
			this.GetNextToken();
		}

		/// <summary>
		/// Asserts that current token is a keyword and returns its value and advances to the next token.
		/// </summary>
		/// <returns>Keyword value.</returns>
		// Token: 0x060000E4 RID: 228 RVA: 0x00004BF4 File Offset: 0x00002DF4
		public string EatKeyword()
		{
			if (this.TokenType != ConditionTokenType.Keyword)
			{
				throw new ConditionParseException("Identifier expected");
			}
			string tokenValue = this.TokenValue;
			this.GetNextToken();
			return tokenValue;
		}

		/// <summary>
		/// Gets or sets a value indicating whether current keyword is equal to the specified value.
		/// </summary>
		/// <param name="keyword">The keyword.</param>
		/// <returns>
		/// A value of <c>true</c> if current keyword is equal to the specified value; otherwise, <c>false</c>.
		/// </returns>
		// Token: 0x060000E5 RID: 229 RVA: 0x00004C30 File Offset: 0x00002E30
		public bool IsKeyword(string keyword)
		{
			return this.TokenType == ConditionTokenType.Keyword && this.TokenValue.Equals(keyword, StringComparison.OrdinalIgnoreCase);
		}

		/// <summary>
		/// Gets or sets a value indicating whether the tokenizer has reached the end of the token stream.
		/// </summary>
		/// <returns>
		/// A value of <c>true</c> if the tokenizer has reached the end of the token stream; otherwise, <c>false</c>.
		/// </returns>
		// Token: 0x060000E6 RID: 230 RVA: 0x00004C6C File Offset: 0x00002E6C
		public bool IsEOF()
		{
			return this.TokenType == ConditionTokenType.EndOfInput;
		}

		/// <summary>
		/// Gets or sets a value indicating whether current token is a number.
		/// </summary>
		/// <returns>
		/// A value of <c>true</c> if current token is a number; otherwise, <c>false</c>.
		/// </returns>
		// Token: 0x060000E7 RID: 231 RVA: 0x00004C94 File Offset: 0x00002E94
		public bool IsNumber()
		{
			return this.TokenType == ConditionTokenType.Number;
		}

		/// <summary>
		/// Gets or sets a value indicating whether the specified token is of specified type.
		/// </summary>
		/// <param name="tokenType">The token type.</param>
		/// <returns>
		/// A value of <c>true</c> if current token is of specified type; otherwise, <c>false</c>.
		/// </returns>
		// Token: 0x060000E8 RID: 232 RVA: 0x00004CB0 File Offset: 0x00002EB0
		public bool IsToken(ConditionTokenType tokenType)
		{
			return this.TokenType == tokenType;
		}

		/// <summary>
		/// Gets the next token and sets <see cref="P:NLog.Conditions.ConditionTokenizer.TokenType" /> and <see cref="P:NLog.Conditions.ConditionTokenizer.TokenValue" /> properties.
		/// </summary>
		// Token: 0x060000E9 RID: 233 RVA: 0x00004CCC File Offset: 0x00002ECC
		public void GetNextToken()
		{
			if (this.TokenType == ConditionTokenType.EndOfInput)
			{
				throw new ConditionParseException("Cannot read past end of stream.");
			}
			this.SkipWhitespace();
			this.TokenPosition = this.TokenPosition;
			int num = this.PeekChar();
			if (num == -1)
			{
				this.TokenType = ConditionTokenType.EndOfInput;
			}
			else
			{
				char c = (char)num;
				if (char.IsDigit(c))
				{
					this.ParseNumber(c);
				}
				else if (c == '\'')
				{
					this.ParseSingleQuotedString(c);
				}
				else if (c == '_' || char.IsLetter(c))
				{
					this.ParseKeyword(c);
				}
				else if (c == '}' || c == ':')
				{
					this.TokenType = ConditionTokenType.EndOfInput;
				}
				else
				{
					this.TokenValue = c.ToString();
					if (c == '<')
					{
						this.ReadChar();
						int num2 = this.PeekChar();
						if (num2 == 62)
						{
							this.TokenType = ConditionTokenType.NotEqual;
							this.TokenValue = "<>";
							this.ReadChar();
						}
						else if (num2 == 61)
						{
							this.TokenType = ConditionTokenType.LessThanOrEqualTo;
							this.TokenValue = "<=";
							this.ReadChar();
						}
						else
						{
							this.TokenType = ConditionTokenType.LessThan;
							this.TokenValue = "<";
						}
					}
					else if (c == '>')
					{
						this.ReadChar();
						int num2 = this.PeekChar();
						if (num2 == 61)
						{
							this.TokenType = ConditionTokenType.GreaterThanOrEqualTo;
							this.TokenValue = ">=";
							this.ReadChar();
						}
						else
						{
							this.TokenType = ConditionTokenType.GreaterThan;
							this.TokenValue = ">";
						}
					}
					else if (c == '!')
					{
						this.ReadChar();
						int num2 = this.PeekChar();
						if (num2 == 61)
						{
							this.TokenType = ConditionTokenType.NotEqual;
							this.TokenValue = "!=";
							this.ReadChar();
						}
						else
						{
							this.TokenType = ConditionTokenType.Not;
							this.TokenValue = "!";
						}
					}
					else if (c == '&')
					{
						this.ReadChar();
						int num2 = this.PeekChar();
						if (num2 != 38)
						{
							throw new ConditionParseException("Expected '&&' but got '&'");
						}
						this.TokenType = ConditionTokenType.And;
						this.TokenValue = "&&";
						this.ReadChar();
					}
					else if (c == '|')
					{
						this.ReadChar();
						int num2 = this.PeekChar();
						if (num2 != 124)
						{
							throw new ConditionParseException("Expected '||' but got '|'");
						}
						this.TokenType = ConditionTokenType.Or;
						this.TokenValue = "||";
						this.ReadChar();
					}
					else if (c == '=')
					{
						this.ReadChar();
						int num2 = this.PeekChar();
						if (num2 == 61)
						{
							this.TokenType = ConditionTokenType.EqualTo;
							this.TokenValue = "==";
							this.ReadChar();
						}
						else
						{
							this.TokenType = ConditionTokenType.EqualTo;
							this.TokenValue = "=";
						}
					}
					else
					{
						if (c < ' ' || c >= '\u0080')
						{
							throw new ConditionParseException("Invalid token: " + c);
						}
						ConditionTokenType conditionTokenType = ConditionTokenizer.charIndexToTokenType[(int)c];
						if (conditionTokenType == ConditionTokenType.Invalid)
						{
							throw new ConditionParseException("Invalid punctuation: " + c);
						}
						this.TokenType = conditionTokenType;
						this.TokenValue = new string(c, 1);
						this.ReadChar();
					}
				}
			}
		}

		// Token: 0x060000EA RID: 234 RVA: 0x000050B8 File Offset: 0x000032B8
		private static ConditionTokenType[] BuildCharIndexToTokenType()
		{
			ConditionTokenizer.CharToTokenType[] array = new ConditionTokenizer.CharToTokenType[]
			{
				new ConditionTokenizer.CharToTokenType('(', ConditionTokenType.LeftParen),
				new ConditionTokenizer.CharToTokenType(')', ConditionTokenType.RightParen),
				new ConditionTokenizer.CharToTokenType('.', ConditionTokenType.Dot),
				new ConditionTokenizer.CharToTokenType(',', ConditionTokenType.Comma),
				new ConditionTokenizer.CharToTokenType('!', ConditionTokenType.Not),
				new ConditionTokenizer.CharToTokenType('-', ConditionTokenType.Minus)
			};
			ConditionTokenType[] array2 = new ConditionTokenType[128];
			for (int i = 0; i < 128; i++)
			{
				array2[i] = ConditionTokenType.Invalid;
			}
			foreach (ConditionTokenizer.CharToTokenType charToTokenType in array)
			{
				array2[(int)charToTokenType.Character] = charToTokenType.TokenType;
			}
			return array2;
		}

		// Token: 0x060000EB RID: 235 RVA: 0x000051C4 File Offset: 0x000033C4
		private void ParseSingleQuotedString(char ch)
		{
			this.TokenType = ConditionTokenType.String;
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(ch);
			this.ReadChar();
			int num;
			while ((num = this.PeekChar()) != -1)
			{
				ch = (char)num;
				stringBuilder.Append((char)this.ReadChar());
				if (ch == '\'')
				{
					if (this.PeekChar() != 39)
					{
						break;
					}
					stringBuilder.Append('\'');
					this.ReadChar();
				}
			}
			if (num == -1)
			{
				throw new ConditionParseException("String literal is missing a closing quote character.");
			}
			this.TokenValue = stringBuilder.ToString();
		}

		// Token: 0x060000EC RID: 236 RVA: 0x00005274 File Offset: 0x00003474
		private void ParseKeyword(char ch)
		{
			this.TokenType = ConditionTokenType.Keyword;
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(ch);
			this.ReadChar();
			int num;
			while ((num = this.PeekChar()) != -1)
			{
				if ((ushort)num != 95 && (ushort)num != 45 && !char.IsLetterOrDigit((char)num))
				{
					break;
				}
				stringBuilder.Append((char)this.ReadChar());
			}
			this.TokenValue = stringBuilder.ToString();
		}

		// Token: 0x060000ED RID: 237 RVA: 0x000052F8 File Offset: 0x000034F8
		private void ParseNumber(char ch)
		{
			this.TokenType = ConditionTokenType.Number;
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(ch);
			this.ReadChar();
			int num;
			while ((num = this.PeekChar()) != -1)
			{
				ch = (char)num;
				if (!char.IsDigit(ch) && ch != '.')
				{
					break;
				}
				stringBuilder.Append((char)this.ReadChar());
			}
			this.TokenValue = stringBuilder.ToString();
		}

		// Token: 0x060000EE RID: 238 RVA: 0x00005378 File Offset: 0x00003578
		private void SkipWhitespace()
		{
			int num;
			while ((num = this.PeekChar()) != -1)
			{
				if (!char.IsWhiteSpace((char)num))
				{
					break;
				}
				this.ReadChar();
			}
		}

		// Token: 0x060000EF RID: 239 RVA: 0x000053B4 File Offset: 0x000035B4
		private int PeekChar()
		{
			return this.stringReader.Peek();
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x000053D4 File Offset: 0x000035D4
		private int ReadChar()
		{
			return this.stringReader.Read();
		}

		// Token: 0x0400002F RID: 47
		private static readonly ConditionTokenType[] charIndexToTokenType = ConditionTokenizer.BuildCharIndexToTokenType();

		// Token: 0x04000030 RID: 48
		private readonly SimpleStringReader stringReader;

		/// <summary>
		/// Mapping between characters and token types for punctuations.
		/// </summary>
		// Token: 0x02000021 RID: 33
		private struct CharToTokenType
		{
			/// <summary>
			/// Initializes a new instance of the CharToTokenType struct.
			/// </summary>
			/// <param name="character">The character.</param>
			/// <param name="tokenType">Type of the token.</param>
			// Token: 0x060000F2 RID: 242 RVA: 0x000053FD File Offset: 0x000035FD
			public CharToTokenType(char character, ConditionTokenType tokenType)
			{
				this.Character = character;
				this.TokenType = tokenType;
			}

			// Token: 0x04000034 RID: 52
			public readonly char Character;

			// Token: 0x04000035 RID: 53
			public readonly ConditionTokenType TokenType;
		}
	}
}
