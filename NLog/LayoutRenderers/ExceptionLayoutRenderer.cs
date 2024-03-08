using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using NLog.Common;
using NLog.Config;
using NLog.Internal;

namespace NLog.LayoutRenderers
{
	/// <summary>
	/// Exception information provided through 
	/// a call to one of the Logger.*Exception() methods.
	/// </summary>
	// Token: 0x020000A1 RID: 161
	[ThreadAgnostic]
	[LayoutRenderer("exception")]
	public class ExceptionLayoutRenderer : LayoutRenderer
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.LayoutRenderers.ExceptionLayoutRenderer" /> class.
		/// </summary>
		// Token: 0x060003C7 RID: 967 RVA: 0x0000E498 File Offset: 0x0000C698
		public ExceptionLayoutRenderer()
		{
			this.Format = "message";
			this.Separator = " ";
			this.InnerExceptionSeparator = EnvironmentHelper.NewLine;
			this.MaxInnerExceptionLevel = 0;
		}

		/// <summary>
		/// Gets or sets the format of the output. Must be a comma-separated list of exception
		/// properties: Message, Type, ShortType, ToString, Method, StackTrace.
		/// This parameter value is case-insensitive.
		/// </summary>
		/// <docgen category="Rendering Options" order="10" />
		// Token: 0x170000C5 RID: 197
		// (get) Token: 0x060003C8 RID: 968 RVA: 0x0000E4E8 File Offset: 0x0000C6E8
		// (set) Token: 0x060003C9 RID: 969 RVA: 0x0000E500 File Offset: 0x0000C700
		[DefaultParameter]
		public string Format
		{
			get
			{
				return this.format;
			}
			set
			{
				this.format = value;
				this.exceptionDataTargets = ExceptionLayoutRenderer.CompileFormat(value);
			}
		}

		/// <summary>
		/// Gets or sets the format of the output of inner exceptions. Must be a comma-separated list of exception
		/// properties: Message, Type, ShortType, ToString, Method, StackTrace.
		/// This parameter value is case-insensitive.
		/// </summary>
		/// <docgen category="Rendering Options" order="10" />
		// Token: 0x170000C6 RID: 198
		// (get) Token: 0x060003CA RID: 970 RVA: 0x0000E518 File Offset: 0x0000C718
		// (set) Token: 0x060003CB RID: 971 RVA: 0x0000E530 File Offset: 0x0000C730
		public string InnerFormat
		{
			get
			{
				return this.innerFormat;
			}
			set
			{
				this.innerFormat = value;
				this.innerExceptionDataTargets = ExceptionLayoutRenderer.CompileFormat(value);
			}
		}

		/// <summary>
		/// Gets or sets the separator used to concatenate parts specified in the Format.
		/// </summary>
		/// <docgen category="Rendering Options" order="10" />
		// Token: 0x170000C7 RID: 199
		// (get) Token: 0x060003CC RID: 972 RVA: 0x0000E548 File Offset: 0x0000C748
		// (set) Token: 0x060003CD RID: 973 RVA: 0x0000E55F File Offset: 0x0000C75F
		[DefaultValue(" ")]
		public string Separator { get; set; }

		/// <summary>
		/// Gets or sets the maximum number of inner exceptions to include in the output.
		/// By default inner exceptions are not enabled for compatibility with NLog 1.0.
		/// </summary>
		/// <docgen category="Rendering Options" order="10" />
		// Token: 0x170000C8 RID: 200
		// (get) Token: 0x060003CE RID: 974 RVA: 0x0000E568 File Offset: 0x0000C768
		// (set) Token: 0x060003CF RID: 975 RVA: 0x0000E57F File Offset: 0x0000C77F
		[DefaultValue(0)]
		public int MaxInnerExceptionLevel { get; set; }

		/// <summary>
		/// Gets or sets the separator between inner exceptions.
		/// </summary>
		/// <docgen category="Rendering Options" order="10" />
		// Token: 0x170000C9 RID: 201
		// (get) Token: 0x060003D0 RID: 976 RVA: 0x0000E588 File Offset: 0x0000C788
		// (set) Token: 0x060003D1 RID: 977 RVA: 0x0000E59F File Offset: 0x0000C79F
		public string InnerExceptionSeparator { get; set; }

		/// <summary>
		/// Renders the specified exception information and appends it to the specified <see cref="T:System.Text.StringBuilder" />.
		/// </summary>
		/// <param name="builder">The <see cref="T:System.Text.StringBuilder" /> to append the rendered data to.</param>
		/// <param name="logEvent">Logging event.</param>
		// Token: 0x060003D2 RID: 978 RVA: 0x0000E5A8 File Offset: 0x0000C7A8
		protected override void Append(StringBuilder builder, LogEventInfo logEvent)
		{
			if (logEvent.Exception != null)
			{
				StringBuilder stringBuilder = new StringBuilder(128);
				string text = string.Empty;
				foreach (ExceptionLayoutRenderer.ExceptionDataTarget exceptionDataTarget in this.exceptionDataTargets)
				{
					stringBuilder.Append(text);
					exceptionDataTarget(stringBuilder, logEvent.Exception);
					text = this.Separator;
				}
				Exception ex = logEvent.Exception.InnerException;
				int num = 0;
				while (ex != null && num < this.MaxInnerExceptionLevel)
				{
					stringBuilder.Append(this.InnerExceptionSeparator);
					text = string.Empty;
					foreach (ExceptionLayoutRenderer.ExceptionDataTarget exceptionDataTarget in this.innerExceptionDataTargets ?? this.exceptionDataTargets)
					{
						stringBuilder.Append(text);
						exceptionDataTarget(stringBuilder, ex);
						text = this.Separator;
					}
					ex = ex.InnerException;
					num++;
				}
				builder.Append(stringBuilder.ToString());
			}
		}

		// Token: 0x060003D3 RID: 979 RVA: 0x0000E6C8 File Offset: 0x0000C8C8
		private static void AppendMessage(StringBuilder sb, Exception ex)
		{
			sb.Append(ex.Message);
		}

		// Token: 0x060003D4 RID: 980 RVA: 0x0000E6D8 File Offset: 0x0000C8D8
		private static void AppendMethod(StringBuilder sb, Exception ex)
		{
			if (ex.TargetSite != null)
			{
				sb.Append(ex.TargetSite.ToString());
			}
		}

		// Token: 0x060003D5 RID: 981 RVA: 0x0000E70D File Offset: 0x0000C90D
		private static void AppendStackTrace(StringBuilder sb, Exception ex)
		{
			sb.Append(ex.StackTrace);
		}

		// Token: 0x060003D6 RID: 982 RVA: 0x0000E71D File Offset: 0x0000C91D
		private static void AppendToString(StringBuilder sb, Exception ex)
		{
			sb.Append(ex.ToString());
		}

		// Token: 0x060003D7 RID: 983 RVA: 0x0000E72D File Offset: 0x0000C92D
		private static void AppendType(StringBuilder sb, Exception ex)
		{
			sb.Append(ex.GetType().FullName);
		}

		// Token: 0x060003D8 RID: 984 RVA: 0x0000E742 File Offset: 0x0000C942
		private static void AppendShortType(StringBuilder sb, Exception ex)
		{
			sb.Append(ex.GetType().Name);
		}

		// Token: 0x060003D9 RID: 985 RVA: 0x0000E758 File Offset: 0x0000C958
		private static ExceptionLayoutRenderer.ExceptionDataTarget[] CompileFormat(string formatSpecifier)
		{
			string[] array = formatSpecifier.Replace(" ", string.Empty).Split(new char[] { ',' });
			List<ExceptionLayoutRenderer.ExceptionDataTarget> list = new List<ExceptionLayoutRenderer.ExceptionDataTarget>();
			string[] array2 = array;
			int i = 0;
			while (i < array2.Length)
			{
				string text = array2[i];
				string text2 = text.ToUpper(CultureInfo.InvariantCulture);
				if (text2 == null)
				{
					goto IL_16C;
				}
				if (<PrivateImplementationDetails>{BBCF4E57-A9FD-4325-AEE4-DEFF1302A7F6}.$$method0x60003c5-1 == null)
				{
					<PrivateImplementationDetails>{BBCF4E57-A9FD-4325-AEE4-DEFF1302A7F6}.$$method0x60003c5-1 = new Dictionary<string, int>(6)
					{
						{ "MESSAGE", 0 },
						{ "TYPE", 1 },
						{ "SHORTTYPE", 2 },
						{ "TOSTRING", 3 },
						{ "METHOD", 4 },
						{ "STACKTRACE", 5 }
					};
				}
				int num;
				if (!<PrivateImplementationDetails>{BBCF4E57-A9FD-4325-AEE4-DEFF1302A7F6}.$$method0x60003c5-1.TryGetValue(text2, out num))
				{
					goto IL_16C;
				}
				switch (num)
				{
				case 0:
					list.Add(new ExceptionLayoutRenderer.ExceptionDataTarget(ExceptionLayoutRenderer.AppendMessage));
					break;
				case 1:
					list.Add(new ExceptionLayoutRenderer.ExceptionDataTarget(ExceptionLayoutRenderer.AppendType));
					break;
				case 2:
					list.Add(new ExceptionLayoutRenderer.ExceptionDataTarget(ExceptionLayoutRenderer.AppendShortType));
					break;
				case 3:
					list.Add(new ExceptionLayoutRenderer.ExceptionDataTarget(ExceptionLayoutRenderer.AppendToString));
					break;
				case 4:
					list.Add(new ExceptionLayoutRenderer.ExceptionDataTarget(ExceptionLayoutRenderer.AppendMethod));
					break;
				case 5:
					list.Add(new ExceptionLayoutRenderer.ExceptionDataTarget(ExceptionLayoutRenderer.AppendStackTrace));
					break;
				default:
					goto IL_16C;
				}
				IL_188:
				i++;
				continue;
				IL_16C:
				InternalLogger.Warn("Unknown exception data target: {0}", new object[] { text });
				goto IL_188;
			}
			return list.ToArray();
		}

		// Token: 0x0400011F RID: 287
		private string format;

		// Token: 0x04000120 RID: 288
		private string innerFormat = string.Empty;

		// Token: 0x04000121 RID: 289
		private ExceptionLayoutRenderer.ExceptionDataTarget[] exceptionDataTargets;

		// Token: 0x04000122 RID: 290
		private ExceptionLayoutRenderer.ExceptionDataTarget[] innerExceptionDataTargets;

		// Token: 0x020000A2 RID: 162
		// (Invoke) Token: 0x060003DB RID: 987
		private delegate void ExceptionDataTarget(StringBuilder sb, Exception ex);
	}
}
