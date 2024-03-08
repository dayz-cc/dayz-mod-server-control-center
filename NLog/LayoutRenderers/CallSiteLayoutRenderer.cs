using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using NLog.Config;
using NLog.Internal;

namespace NLog.LayoutRenderers
{
	/// <summary>
	/// The call site (class name, method name and source information).
	/// </summary>
	// Token: 0x0200009B RID: 155
	[LayoutRenderer("callsite")]
	[ThreadAgnostic]
	public class CallSiteLayoutRenderer : LayoutRenderer, IUsesStackTrace
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.LayoutRenderers.CallSiteLayoutRenderer" /> class.
		/// </summary>
		// Token: 0x0600039A RID: 922 RVA: 0x0000DDF3 File Offset: 0x0000BFF3
		public CallSiteLayoutRenderer()
		{
			this.ClassName = true;
			this.MethodName = true;
			this.CleanNamesOfAnonymousDelegates = false;
			this.FileName = false;
			this.IncludeSourcePath = true;
		}

		/// <summary>
		/// Gets or sets a value indicating whether to render the class name.
		/// </summary>
		/// <docgen category="Rendering Options" order="10" />
		// Token: 0x170000B5 RID: 181
		// (get) Token: 0x0600039B RID: 923 RVA: 0x0000DE28 File Offset: 0x0000C028
		// (set) Token: 0x0600039C RID: 924 RVA: 0x0000DE3F File Offset: 0x0000C03F
		[DefaultValue(true)]
		public bool ClassName { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether to render the method name.
		/// </summary>
		/// <docgen category="Rendering Options" order="10" />
		// Token: 0x170000B6 RID: 182
		// (get) Token: 0x0600039D RID: 925 RVA: 0x0000DE48 File Offset: 0x0000C048
		// (set) Token: 0x0600039E RID: 926 RVA: 0x0000DE5F File Offset: 0x0000C05F
		[DefaultValue(true)]
		public bool MethodName { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether the method name will be cleaned up if it is detected as an anonymous delegate.
		/// </summary>
		/// <docgen category="Rendering Options" order="10" />
		// Token: 0x170000B7 RID: 183
		// (get) Token: 0x0600039F RID: 927 RVA: 0x0000DE68 File Offset: 0x0000C068
		// (set) Token: 0x060003A0 RID: 928 RVA: 0x0000DE7F File Offset: 0x0000C07F
		[DefaultValue(false)]
		public bool CleanNamesOfAnonymousDelegates { get; set; }

		/// <summary>
		/// Gets or sets the number of frames to skip.
		/// </summary>
		// Token: 0x170000B8 RID: 184
		// (get) Token: 0x060003A1 RID: 929 RVA: 0x0000DE88 File Offset: 0x0000C088
		// (set) Token: 0x060003A2 RID: 930 RVA: 0x0000DE9F File Offset: 0x0000C09F
		[DefaultValue(0)]
		public int SkipFrames { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether to render the source file name and line number.
		/// </summary>
		/// <docgen category="Rendering Options" order="10" />
		// Token: 0x170000B9 RID: 185
		// (get) Token: 0x060003A3 RID: 931 RVA: 0x0000DEA8 File Offset: 0x0000C0A8
		// (set) Token: 0x060003A4 RID: 932 RVA: 0x0000DEBF File Offset: 0x0000C0BF
		[DefaultValue(false)]
		public bool FileName { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether to include source file path.
		/// </summary>
		/// <docgen category="Rendering Options" order="10" />
		// Token: 0x170000BA RID: 186
		// (get) Token: 0x060003A5 RID: 933 RVA: 0x0000DEC8 File Offset: 0x0000C0C8
		// (set) Token: 0x060003A6 RID: 934 RVA: 0x0000DEDF File Offset: 0x0000C0DF
		[DefaultValue(true)]
		public bool IncludeSourcePath { get; set; }

		/// <summary>
		/// Gets the level of stack trace information required by the implementing class.
		/// </summary>
		// Token: 0x170000BB RID: 187
		// (get) Token: 0x060003A7 RID: 935 RVA: 0x0000DEE8 File Offset: 0x0000C0E8
		StackTraceUsage IUsesStackTrace.StackTraceUsage
		{
			get
			{
				StackTraceUsage stackTraceUsage;
				if (this.FileName)
				{
					stackTraceUsage = StackTraceUsage.WithSource;
				}
				else
				{
					stackTraceUsage = StackTraceUsage.WithoutSource;
				}
				return stackTraceUsage;
			}
		}

		/// <summary>
		/// Renders the call site and appends it to the specified <see cref="T:System.Text.StringBuilder" />.
		/// </summary>
		/// <param name="builder">The <see cref="T:System.Text.StringBuilder" /> to append the rendered data to.</param>
		/// <param name="logEvent">Logging event.</param>
		// Token: 0x060003A8 RID: 936 RVA: 0x0000DF10 File Offset: 0x0000C110
		protected override void Append(StringBuilder builder, LogEventInfo logEvent)
		{
			StackFrame stackFrame = ((logEvent.StackTrace != null) ? logEvent.StackTrace.GetFrame(logEvent.UserStackFrameNumber + this.SkipFrames) : null);
			if (stackFrame != null)
			{
				MethodBase method = stackFrame.GetMethod();
				if (this.ClassName)
				{
					if (method.DeclaringType != null)
					{
						string text = method.DeclaringType.FullName;
						if (this.CleanNamesOfAnonymousDelegates)
						{
							if (text.Contains("+<>"))
							{
								int num = text.IndexOf("+<>");
								text = text.Substring(0, num);
							}
						}
						builder.Append(text);
					}
					else
					{
						builder.Append("<no type>");
					}
				}
				if (this.MethodName)
				{
					if (this.ClassName)
					{
						builder.Append(".");
					}
					if (method != null)
					{
						string text2 = method.Name;
						if (this.CleanNamesOfAnonymousDelegates)
						{
							if (text2.Contains("__") && text2.StartsWith("<") && text2.Contains(">"))
							{
								int num2 = text2.IndexOf('<') + 1;
								int num3 = text2.IndexOf('>');
								text2 = text2.Substring(num2, num3 - num2);
							}
						}
						builder.Append(text2);
					}
					else
					{
						builder.Append("<no method>");
					}
				}
				if (this.FileName)
				{
					string fileName = stackFrame.GetFileName();
					if (fileName != null)
					{
						builder.Append("(");
						if (this.IncludeSourcePath)
						{
							builder.Append(fileName);
						}
						else
						{
							builder.Append(Path.GetFileName(fileName));
						}
						builder.Append(":");
						builder.Append(stackFrame.GetFileLineNumber());
						builder.Append(")");
					}
				}
			}
		}
	}
}
