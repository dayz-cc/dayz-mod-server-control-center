using System;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace NLog.LogReceiverService
{
	/// <summary>
	/// List of strings annotated for more terse serialization.
	/// </summary>
	// Token: 0x020000F3 RID: 243
	[CollectionDataContract(ItemName = "l", Namespace = "http://nlog-project.org/ws/")]
	public class StringCollection : Collection<string>
	{
	}
}
