using System;
using System.Runtime.Serialization;

namespace NLog.Conditions
{
	/// <summary>
	/// Exception during parsing of condition expression.
	/// </summary>
	// Token: 0x0200001C RID: 28
	[Serializable]
	public class ConditionParseException : Exception
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Conditions.ConditionParseException" /> class.
		/// </summary>
		// Token: 0x060000BF RID: 191 RVA: 0x00003D9D File Offset: 0x00001F9D
		public ConditionParseException()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Conditions.ConditionParseException" /> class.
		/// </summary>
		/// <param name="message">The message.</param>
		// Token: 0x060000C0 RID: 192 RVA: 0x00003DA8 File Offset: 0x00001FA8
		public ConditionParseException(string message)
			: base(message)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Conditions.ConditionParseException" /> class.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="innerException">The inner exception.</param>
		// Token: 0x060000C1 RID: 193 RVA: 0x00003DB4 File Offset: 0x00001FB4
		public ConditionParseException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Conditions.ConditionParseException" /> class.
		/// </summary>
		/// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
		/// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.</param>
		/// <exception cref="T:System.ArgumentNullException">
		/// The <paramref name="info" /> parameter is null.
		/// </exception>
		/// <exception cref="T:System.Runtime.Serialization.SerializationException">
		/// The class name is null or <see cref="P:System.Exception.HResult" /> is zero (0).
		/// </exception>
		// Token: 0x060000C2 RID: 194 RVA: 0x00003DC1 File Offset: 0x00001FC1
		protected ConditionParseException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
