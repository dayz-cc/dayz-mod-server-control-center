using System;

namespace NLog.Conditions
{
	/// <summary>
	/// Token types for condition expressions.
	/// </summary>
	// Token: 0x02000022 RID: 34
	internal enum ConditionTokenType
	{
		// Token: 0x04000037 RID: 55
		EndOfInput,
		// Token: 0x04000038 RID: 56
		BeginningOfInput,
		// Token: 0x04000039 RID: 57
		Number,
		// Token: 0x0400003A RID: 58
		String,
		// Token: 0x0400003B RID: 59
		Keyword,
		// Token: 0x0400003C RID: 60
		Whitespace,
		// Token: 0x0400003D RID: 61
		FirstPunct,
		// Token: 0x0400003E RID: 62
		LessThan,
		// Token: 0x0400003F RID: 63
		GreaterThan,
		// Token: 0x04000040 RID: 64
		LessThanOrEqualTo,
		// Token: 0x04000041 RID: 65
		GreaterThanOrEqualTo,
		// Token: 0x04000042 RID: 66
		EqualTo,
		// Token: 0x04000043 RID: 67
		NotEqual,
		// Token: 0x04000044 RID: 68
		LeftParen,
		// Token: 0x04000045 RID: 69
		RightParen,
		// Token: 0x04000046 RID: 70
		Dot,
		// Token: 0x04000047 RID: 71
		Comma,
		// Token: 0x04000048 RID: 72
		Not,
		// Token: 0x04000049 RID: 73
		And,
		// Token: 0x0400004A RID: 74
		Or,
		// Token: 0x0400004B RID: 75
		Minus,
		// Token: 0x0400004C RID: 76
		LastPunct,
		// Token: 0x0400004D RID: 77
		Invalid,
		// Token: 0x0400004E RID: 78
		ClosingCurlyBrace,
		// Token: 0x0400004F RID: 79
		Colon,
		// Token: 0x04000050 RID: 80
		Exclamation,
		// Token: 0x04000051 RID: 81
		Ampersand,
		// Token: 0x04000052 RID: 82
		Pipe
	}
}
