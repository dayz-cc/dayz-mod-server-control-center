using System;
using System.Runtime.Serialization;

namespace NLog
{
	/// <summary>
	/// Exception thrown during log event processing.
	/// </summary>
	// Token: 0x020000FB RID: 251
	[Serializable]
	public class NLogRuntimeException : Exception
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.NLogRuntimeException" /> class.
		/// </summary>
		// Token: 0x06000798 RID: 1944 RVA: 0x0001AA22 File Offset: 0x00018C22
		public NLogRuntimeException()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.NLogRuntimeException" /> class.
		/// </summary>
		/// <param name="message">The message.</param>
		// Token: 0x06000799 RID: 1945 RVA: 0x0001AA2D File Offset: 0x00018C2D
		public NLogRuntimeException(string message)
			: base(message)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.NLogRuntimeException" /> class.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="innerException">The inner exception.</param>
		// Token: 0x0600079A RID: 1946 RVA: 0x0001AA39 File Offset: 0x00018C39
		public NLogRuntimeException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.NLogRuntimeException" /> class.
		/// </summary>
		/// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
		/// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.</param>
		/// <exception cref="T:System.ArgumentNullException">
		/// The <paramref name="info" /> parameter is null.
		/// </exception>
		/// <exception cref="T:System.Runtime.Serialization.SerializationException">
		/// The class name is null or <see cref="P:System.Exception.HResult" /> is zero (0).
		/// </exception>
		// Token: 0x0600079B RID: 1947 RVA: 0x0001AA46 File Offset: 0x00018C46
		protected NLogRuntimeException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
