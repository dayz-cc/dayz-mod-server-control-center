using System;
using System.Runtime.Serialization;

namespace NLog
{
	/// <summary>
	/// Exception thrown during NLog configuration.
	/// </summary>
	// Token: 0x020000FA RID: 250
	[Serializable]
	public class NLogConfigurationException : Exception
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.NLogConfigurationException" /> class.
		/// </summary>
		// Token: 0x06000794 RID: 1940 RVA: 0x0001A9F1 File Offset: 0x00018BF1
		public NLogConfigurationException()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.NLogConfigurationException" /> class.
		/// </summary>
		/// <param name="message">The message.</param>
		// Token: 0x06000795 RID: 1941 RVA: 0x0001A9FC File Offset: 0x00018BFC
		public NLogConfigurationException(string message)
			: base(message)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.NLogConfigurationException" /> class.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="innerException">The inner exception.</param>
		// Token: 0x06000796 RID: 1942 RVA: 0x0001AA08 File Offset: 0x00018C08
		public NLogConfigurationException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.NLogConfigurationException" /> class.
		/// </summary>
		/// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object data about the exception being thrown.</param>
		/// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual information about the source or destination.</param>
		/// <exception cref="T:System.ArgumentNullException">
		/// The <paramref name="info" /> parameter is null.
		/// </exception>
		/// <exception cref="T:System.Runtime.Serialization.SerializationException">
		/// The class name is null or <see cref="P:System.Exception.HResult" /> is zero (0).
		/// </exception>
		// Token: 0x06000797 RID: 1943 RVA: 0x0001AA15 File Offset: 0x00018C15
		protected NLogConfigurationException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
}
