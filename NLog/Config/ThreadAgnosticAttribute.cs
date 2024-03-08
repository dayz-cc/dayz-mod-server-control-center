using System;

namespace NLog.Config
{
	/// <summary>
	/// Marks the layout or layout renderer as producing correct results regardless of the thread
	/// it's running on.
	/// </summary>
	// Token: 0x0200003B RID: 59
	[AttributeUsage(AttributeTargets.Class)]
	public sealed class ThreadAgnosticAttribute : Attribute
	{
	}
}
