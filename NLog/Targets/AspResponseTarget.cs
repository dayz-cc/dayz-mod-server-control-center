using System;
using System.Runtime.InteropServices;
using NLog.Internal;

namespace NLog.Targets
{
	/// <summary>
	/// Outputs log messages through the ASP Response object.
	/// </summary>
	/// <seealso href="http://nlog-project.org/wiki/AspResponse_target">Documentation on NLog Wiki</seealso>
	// Token: 0x02000100 RID: 256
	[Target("AspResponse")]
	public sealed class AspResponseTarget : TargetWithLayout
	{
		/// <summary>
		/// Gets or sets a value indicating whether to add &lt;!-- --&gt; comments around all written texts.
		/// </summary>
		/// <docgen category="Layout Options" order="100" />
		// Token: 0x1700016D RID: 365
		// (get) Token: 0x060007D6 RID: 2006 RVA: 0x0001BB28 File Offset: 0x00019D28
		// (set) Token: 0x060007D7 RID: 2007 RVA: 0x0001BB3F File Offset: 0x00019D3F
		public bool AddComments { get; set; }

		/// <summary>
		/// Outputs the rendered logging event through the <c>OutputDebugString()</c> Win32 API.
		/// </summary>
		/// <param name="logEvent">The logging event.</param>
		// Token: 0x060007D8 RID: 2008 RVA: 0x0001BB48 File Offset: 0x00019D48
		protected override void Write(LogEventInfo logEvent)
		{
			AspHelper.IResponse responseObject = AspHelper.GetResponseObject();
			if (responseObject != null)
			{
				if (this.AddComments)
				{
					responseObject.Write("<!-- " + this.Layout.Render(logEvent) + "-->");
				}
				else
				{
					responseObject.Write(this.Layout.Render(logEvent));
				}
				Marshal.ReleaseComObject(responseObject);
			}
		}
	}
}
