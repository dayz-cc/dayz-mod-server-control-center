using System;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using NLog.Config;
using NLog.Internal;
using NLog.Layouts;

namespace NLog.Conditions
{
	/// <summary>
	/// Condition parser. Turns a string representation of condition expression
	/// into an expression tree.
	/// </summary>
	// Token: 0x0200001D RID: 29
	public class ConditionParser
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Conditions.ConditionParser" /> class.
		/// </summary>
		/// <param name="stringReader">The string reader.</param>
		/// <param name="configurationItemFactory">Instance of <see cref="T:NLog.Config.ConfigurationItemFactory" /> used to resolve references to condition methods and layout renderers.</param>
		// Token: 0x060000C3 RID: 195 RVA: 0x00003DCE File Offset: 0x00001FCE
		private ConditionParser(SimpleStringReader stringReader, ConfigurationItemFactory configurationItemFactory)
		{
			this.configurationItemFactory = configurationItemFactory;
			this.tokenizer = new ConditionTokenizer(stringReader);
		}

		/// <summary>
		/// Parses the specified condition string and turns it into
		/// <see cref="T:NLog.Conditions.ConditionExpression" /> tree.
		/// </summary>
		/// <param name="expressionText">The expression to be parsed.</param>
		/// <returns>The root of the expression syntax tree which can be used to get the value of the condition in a specified context.</returns>
		// Token: 0x060000C4 RID: 196 RVA: 0x00003DEC File Offset: 0x00001FEC
		public static ConditionExpression ParseExpression(string expressionText)
		{
			return ConditionParser.ParseExpression(expressionText, ConfigurationItemFactory.Default);
		}

		/// <summary>
		/// Parses the specified condition string and turns it into
		/// <see cref="T:NLog.Conditions.ConditionExpression" /> tree.
		/// </summary>
		/// <param name="expressionText">The expression to be parsed.</param>
		/// <param name="configurationItemFactories">Instance of <see cref="T:NLog.Config.ConfigurationItemFactory" /> used to resolve references to condition methods and layout renderers.</param>
		/// <returns>The root of the expression syntax tree which can be used to get the value of the condition in a specified context.</returns>
		// Token: 0x060000C5 RID: 197 RVA: 0x00003E0C File Offset: 0x0000200C
		public static ConditionExpression ParseExpression(string expressionText, ConfigurationItemFactory configurationItemFactories)
		{
			ConditionExpression conditionExpression;
			if (expressionText == null)
			{
				conditionExpression = null;
			}
			else
			{
				ConditionParser conditionParser = new ConditionParser(new SimpleStringReader(expressionText), configurationItemFactories);
				ConditionExpression conditionExpression2 = conditionParser.ParseExpression();
				if (!conditionParser.tokenizer.IsEOF())
				{
					throw new ConditionParseException("Unexpected token: " + conditionParser.tokenizer.TokenValue);
				}
				conditionExpression = conditionExpression2;
			}
			return conditionExpression;
		}

		/// <summary>
		/// Parses the specified condition string and turns it into
		/// <see cref="T:NLog.Conditions.ConditionExpression" /> tree.
		/// </summary>
		/// <param name="stringReader">The string reader.</param>
		/// <param name="configurationItemFactories">Instance of <see cref="T:NLog.Config.ConfigurationItemFactory" /> used to resolve references to condition methods and layout renderers.</param>
		/// <returns>
		/// The root of the expression syntax tree which can be used to get the value of the condition in a specified context.
		/// </returns>
		// Token: 0x060000C6 RID: 198 RVA: 0x00003E70 File Offset: 0x00002070
		internal static ConditionExpression ParseExpression(SimpleStringReader stringReader, ConfigurationItemFactory configurationItemFactories)
		{
			ConditionParser conditionParser = new ConditionParser(stringReader, configurationItemFactories);
			return conditionParser.ParseExpression();
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x00003E94 File Offset: 0x00002094
		private ConditionMethodExpression ParsePredicate(string functionName)
		{
			List<ConditionExpression> list = new List<ConditionExpression>();
			while (!this.tokenizer.IsEOF() && this.tokenizer.TokenType != ConditionTokenType.RightParen)
			{
				list.Add(this.ParseExpression());
				if (this.tokenizer.TokenType != ConditionTokenType.Comma)
				{
					break;
				}
				this.tokenizer.GetNextToken();
			}
			this.tokenizer.Expect(ConditionTokenType.RightParen);
			ConditionMethodExpression conditionMethodExpression;
			try
			{
				MethodInfo methodInfo = this.configurationItemFactory.ConditionMethods.CreateInstance(functionName);
				conditionMethodExpression = new ConditionMethodExpression(functionName, methodInfo, list);
			}
			catch (Exception ex)
			{
				if (ex.MustBeRethrown())
				{
					throw;
				}
				throw new ConditionParseException("Cannot resolve function '" + functionName + "'", ex);
			}
			return conditionMethodExpression;
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x00003F70 File Offset: 0x00002170
		private ConditionExpression ParseLiteralExpression()
		{
			ConditionExpression conditionExpression2;
			if (this.tokenizer.IsToken(ConditionTokenType.LeftParen))
			{
				this.tokenizer.GetNextToken();
				ConditionExpression conditionExpression = this.ParseExpression();
				this.tokenizer.Expect(ConditionTokenType.RightParen);
				conditionExpression2 = conditionExpression;
			}
			else if (this.tokenizer.IsToken(ConditionTokenType.Minus))
			{
				this.tokenizer.GetNextToken();
				if (!this.tokenizer.IsNumber())
				{
					throw new ConditionParseException("Number expected, got " + this.tokenizer.TokenType);
				}
				string text = this.tokenizer.TokenValue;
				this.tokenizer.GetNextToken();
				if (text.IndexOf('.') >= 0)
				{
					conditionExpression2 = new ConditionLiteralExpression(-double.Parse(text, CultureInfo.InvariantCulture));
				}
				else
				{
					conditionExpression2 = new ConditionLiteralExpression(-int.Parse(text, CultureInfo.InvariantCulture));
				}
			}
			else if (this.tokenizer.IsNumber())
			{
				string text = this.tokenizer.TokenValue;
				this.tokenizer.GetNextToken();
				if (text.IndexOf('.') >= 0)
				{
					conditionExpression2 = new ConditionLiteralExpression(double.Parse(text, CultureInfo.InvariantCulture));
				}
				else
				{
					conditionExpression2 = new ConditionLiteralExpression(int.Parse(text, CultureInfo.InvariantCulture));
				}
			}
			else
			{
				if (this.tokenizer.TokenType != ConditionTokenType.String)
				{
					if (this.tokenizer.TokenType == ConditionTokenType.Keyword)
					{
						string text2 = this.tokenizer.EatKeyword();
						if (0 == string.Compare(text2, "level", StringComparison.OrdinalIgnoreCase))
						{
							return new ConditionLevelExpression();
						}
						if (0 == string.Compare(text2, "logger", StringComparison.OrdinalIgnoreCase))
						{
							return new ConditionLoggerNameExpression();
						}
						if (0 == string.Compare(text2, "message", StringComparison.OrdinalIgnoreCase))
						{
							return new ConditionMessageExpression();
						}
						if (0 == string.Compare(text2, "loglevel", StringComparison.OrdinalIgnoreCase))
						{
							this.tokenizer.Expect(ConditionTokenType.Dot);
							return new ConditionLiteralExpression(LogLevel.FromString(this.tokenizer.EatKeyword()));
						}
						if (0 == string.Compare(text2, "true", StringComparison.OrdinalIgnoreCase))
						{
							return new ConditionLiteralExpression(true);
						}
						if (0 == string.Compare(text2, "false", StringComparison.OrdinalIgnoreCase))
						{
							return new ConditionLiteralExpression(false);
						}
						if (0 == string.Compare(text2, "null", StringComparison.OrdinalIgnoreCase))
						{
							return new ConditionLiteralExpression(null);
						}
						if (this.tokenizer.TokenType == ConditionTokenType.LeftParen)
						{
							this.tokenizer.GetNextToken();
							return this.ParsePredicate(text2);
						}
					}
					throw new ConditionParseException("Unexpected token: " + this.tokenizer.TokenValue);
				}
				ConditionExpression conditionExpression = new ConditionLayoutExpression(Layout.FromString(this.tokenizer.StringTokenValue, this.configurationItemFactory));
				this.tokenizer.GetNextToken();
				conditionExpression2 = conditionExpression;
			}
			return conditionExpression2;
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x000042D8 File Offset: 0x000024D8
		private ConditionExpression ParseBooleanRelation()
		{
			ConditionExpression conditionExpression = this.ParseLiteralExpression();
			ConditionExpression conditionExpression2;
			if (this.tokenizer.IsToken(ConditionTokenType.EqualTo))
			{
				this.tokenizer.GetNextToken();
				conditionExpression2 = new ConditionRelationalExpression(conditionExpression, this.ParseLiteralExpression(), ConditionRelationalOperator.Equal);
			}
			else if (this.tokenizer.IsToken(ConditionTokenType.NotEqual))
			{
				this.tokenizer.GetNextToken();
				conditionExpression2 = new ConditionRelationalExpression(conditionExpression, this.ParseLiteralExpression(), ConditionRelationalOperator.NotEqual);
			}
			else if (this.tokenizer.IsToken(ConditionTokenType.LessThan))
			{
				this.tokenizer.GetNextToken();
				conditionExpression2 = new ConditionRelationalExpression(conditionExpression, this.ParseLiteralExpression(), ConditionRelationalOperator.Less);
			}
			else if (this.tokenizer.IsToken(ConditionTokenType.GreaterThan))
			{
				this.tokenizer.GetNextToken();
				conditionExpression2 = new ConditionRelationalExpression(conditionExpression, this.ParseLiteralExpression(), ConditionRelationalOperator.Greater);
			}
			else if (this.tokenizer.IsToken(ConditionTokenType.LessThanOrEqualTo))
			{
				this.tokenizer.GetNextToken();
				conditionExpression2 = new ConditionRelationalExpression(conditionExpression, this.ParseLiteralExpression(), ConditionRelationalOperator.LessOrEqual);
			}
			else if (this.tokenizer.IsToken(ConditionTokenType.GreaterThanOrEqualTo))
			{
				this.tokenizer.GetNextToken();
				conditionExpression2 = new ConditionRelationalExpression(conditionExpression, this.ParseLiteralExpression(), ConditionRelationalOperator.GreaterOrEqual);
			}
			else
			{
				conditionExpression2 = conditionExpression;
			}
			return conditionExpression2;
		}

		// Token: 0x060000CA RID: 202 RVA: 0x00004420 File Offset: 0x00002620
		private ConditionExpression ParseBooleanPredicate()
		{
			ConditionExpression conditionExpression;
			if (this.tokenizer.IsKeyword("not") || this.tokenizer.IsToken(ConditionTokenType.Not))
			{
				this.tokenizer.GetNextToken();
				conditionExpression = new ConditionNotExpression(this.ParseBooleanPredicate());
			}
			else
			{
				conditionExpression = this.ParseBooleanRelation();
			}
			return conditionExpression;
		}

		// Token: 0x060000CB RID: 203 RVA: 0x00004480 File Offset: 0x00002680
		private ConditionExpression ParseBooleanAnd()
		{
			ConditionExpression conditionExpression = this.ParseBooleanPredicate();
			while (this.tokenizer.IsKeyword("and") || this.tokenizer.IsToken(ConditionTokenType.And))
			{
				this.tokenizer.GetNextToken();
				conditionExpression = new ConditionAndExpression(conditionExpression, this.ParseBooleanPredicate());
			}
			return conditionExpression;
		}

		// Token: 0x060000CC RID: 204 RVA: 0x000044E0 File Offset: 0x000026E0
		private ConditionExpression ParseBooleanOr()
		{
			ConditionExpression conditionExpression = this.ParseBooleanAnd();
			while (this.tokenizer.IsKeyword("or") || this.tokenizer.IsToken(ConditionTokenType.Or))
			{
				this.tokenizer.GetNextToken();
				conditionExpression = new ConditionOrExpression(conditionExpression, this.ParseBooleanAnd());
			}
			return conditionExpression;
		}

		// Token: 0x060000CD RID: 205 RVA: 0x00004540 File Offset: 0x00002740
		private ConditionExpression ParseBooleanExpression()
		{
			return this.ParseBooleanOr();
		}

		// Token: 0x060000CE RID: 206 RVA: 0x00004558 File Offset: 0x00002758
		private ConditionExpression ParseExpression()
		{
			return this.ParseBooleanExpression();
		}

		// Token: 0x04000023 RID: 35
		private readonly ConditionTokenizer tokenizer;

		// Token: 0x04000024 RID: 36
		private readonly ConfigurationItemFactory configurationItemFactory;
	}
}
