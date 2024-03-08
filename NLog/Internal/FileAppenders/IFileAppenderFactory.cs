using System;

namespace NLog.Internal.FileAppenders
{
	/// <summary>
	/// Interface implemented by all factories capable of creating file appenders.
	/// </summary>
	// Token: 0x0200005F RID: 95
	internal interface IFileAppenderFactory
	{
		/// <summary>
		/// Opens the appender for given file name and parameters.
		/// </summary>
		/// <param name="fileName">Name of the file.</param>
		/// <param name="parameters">Creation parameters.</param>
		/// <returns>Instance of <see cref="T:NLog.Internal.FileAppenders.BaseFileAppender" /> which can be used to write to the file.</returns>
		// Token: 0x0600027F RID: 639
		BaseFileAppender Open(string fileName, ICreateFileParameters parameters);
	}
}
