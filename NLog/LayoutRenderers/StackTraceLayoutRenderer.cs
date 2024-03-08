using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using NLog.Config;
using NLog.Internal;

namespace NLog.LayoutRenderers
{
	/// <summary>
	/// Stack trace renderer.
	/// </summary>
	// Token: 0x020000C1 RID: 193
	[LayoutRenderer("stacktrace")]
	[ThreadAgnostic]
	public class StackTraceLayoutRenderer : LayoutRenderer, IUsesStackTrace
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.LayoutRenderers.StackTraceLayoutRenderer" /> class.
		/// </summary>
		// Token: 0x06000486 RID: 1158 RVA: 0x00010720 File Offset: 0x0000E920
		public StackTraceLayoutRenderer()
		{
			this.Separator = " => ";
			this.TopFrames = 3;
			this.Format = StackTraceFormat.Flat;
		}

		/// <summary>
		/// Gets or sets the output format of the stack trace.
		/// </summary>
		/// <docgen category="Rendering Options" order="10" />
		// Token: 0x170000FD RID: 253
		// (get) Token: 0x06000487 RID: 1159 RVA: 0x00010748 File Offset: 0x0000E948
		// (set) Token: 0x06000488 RID: 1160 RVA: 0x0001075F File Offset: 0x0000E95F
		[DefaultValue("Flat")]
		public StackTraceFormat Format { get; set; }

		/// <summary>
		/// Gets or sets the number of top stack frames to be rendered.
		/// </summary>
		/// <docgen category="Rendering Options" order="10" />
		// Token: 0x170000FE RID: 254
		// (get) Token: 0x06000489 RID: 1161 RVA: 0x00010768 File Offset: 0x0000E968
		// (set) Token: 0x0600048A RID: 1162 RVA: 0x0001077F File Offset: 0x0000E97F
		[DefaultValue(3)]
		public int TopFrames { get; set; }

		/// <summary>
		/// Gets or sets the stack frame separator string.
		/// </summary>
		/// <docgen category="Rendering Options" order="10" />
		// Token: 0x170000FF RID: 255
		// (get) Token: 0x0600048B RID: 1163 RVA: 0x00010788 File Offset: 0x0000E988
		// (set) Token: 0x0600048C RID: 1164 RVA: 0x0001079F File Offset: 0x0000E99F
		[DefaultValue(" => ")]
		public string Separator { get; set; }

		/// <summary>
		/// Gets the level of stack trace information required by the implementing class.
		/// </summary>
		/// <value></value>
		// Token: 0x17000100 RID: 256
		// (get) Token: 0x0600048D RID: 1165 RVA: 0x000107A8 File Offset: 0x0000E9A8
		StackTraceUsage IUsesStackTrace.StackTraceUsage
		{
			get
			{
				return StackTraceUsage.WithoutSource;
			}
		}

		/// <summary>
		/// Renders the call site and appends it to the specified <see cref="T:System.Text.StringBuilder" />.
		/// </summary>
		/// <param name="builder">The <see cref="T:System.Text.StringBuilder" /> to append the rendered data to.</param>
		/// <param name="logEvent">Logging event.</param>
		// Token: 0x0600048E RID: 1166 RVA: 0x000107BC File Offset: 0x0000E9BC
		protected override void Append(StringBuilder builder, LogEventInfo logEvent)
		{
			bool flag = true;
			int num = logEvent.UserStackFrameNumber + this.TopFrames - 1;
			if (num >= logEvent.StackTrace.FrameCount)
			{
				num = logEvent.StackTrace.FrameCount - 1;
			}
			switch (this.Format)
			{
			case StackTraceFormat.Raw:
			{
				for (int i = num; i >= logEvent.UserStackFrameNumber; i--)
				{
					StackFrame stackFrame = logEvent.StackTrace.GetFrame(i);
					builder.Append(stackFrame.ToString());
				}
				break;
			}
			case StackTraceFormat.Flat:
			{
				for (int i = num; i >= logEvent.UserStackFrameNumber; i--)
				{
					StackFrame stackFrame = logEvent.StackTrace.GetFrame(i);
					if (!flag)
					{
						builder.Append(this.Separator);
					}
					Type declaringType = stackFrame.GetMethod().DeclaringType;
					if (declaringType != null)
					{
						builder.Append(declaringType.Name);
					}
					else
					{
						builder.Append("<no type>");
					}
					builder.Append(".");
					builder.Append(stackFrame.GetMethod().Name);
					flag = false;
				}
				break;
			}
			case StackTraceFormat.DetailedFlat:
			{
				for (int i = num; i >= logEvent.UserStackFrameNumber; i--)
				{
					StackFrame stackFrame = logEvent.StackTrace.GetFrame(i);
					if (!flag)
					{
						builder.Append(this.Separator);
					}
					builder.Append("[");
					builder.Append(stackFrame.GetMethod());
					builder.Append("]");
					flag = false;
				}
				break;
			}
			}
		}
	}
}
