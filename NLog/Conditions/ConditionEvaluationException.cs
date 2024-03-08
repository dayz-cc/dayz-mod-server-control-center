using System;
using System.Runtime.Serialization;

namespace NLog.Conditions
{
	/// <summary>
	/// Exception during evaluation of condition expression.
	/// </summary>
	// Token: 0x0200000F RID: 15
	[Serializable]
	public class ConditionEvaluationException : Exception
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Conditions.ConditionEvaluationException" /> class.
		/// </summary>
		// Token: 0x06000089 RID: 137 RVA: 0x000035BB File Offset: 0x000017BB
		public ConditionEvaluationException()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Conditions.ConditionEvaluationException" /> class.
		/// </summary>
		/// <param name="message">The message.</param>
		// Token: 0x0600008A RID: 138 RVA: 0x000035C6 File Offset: 0x000017C6
		public ConditionEvaluationException(string message)
			: base(message)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Conditions.ConditionEvaluationException" /> class.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="innerException">The inner exception.</param>
		// Token: 0x0600008B RID: 139 RVA: 0x000035D2 File Offset: 0x000017D2
		public ConditionEvaluationException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Conditions.ConditionEvaluationException" /> class.
		/// </summary>
		/// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
		/// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.</param>
		/// <exception cref="T:System.ArgumentNullException">
		/// The <paramref name="info" /> parameter is null.
		/// </exception>
		/// <exception cref="T:System.Runtime.Serialization.SerializationException">
		/// The class name is null or <see cref="P:System.Exception.HResult" /> is zero (0).
		/// </exception>
		// Token: 0x0600008C RID: 140 RVA: 0x000035DF File Offset: 0x000017DF
		protected ConditionEvaluationException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
