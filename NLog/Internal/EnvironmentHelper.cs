using System;
using System.Security;

namespace NLog.Internal
{
	/// <summary>
	/// Safe way to get environment variables.
	/// </summary>
	// Token: 0x02000058 RID: 88
	internal static class EnvironmentHelper
	{
		// Token: 0x17000074 RID: 116
		// (get) Token: 0x06000247 RID: 583 RVA: 0x00009DD8 File Offset: 0x00007FD8
		internal static string NewLine
		{
			get
			{
				return Environment.NewLine;
			}
		}

		// Token: 0x06000248 RID: 584 RVA: 0x00009DF4 File Offset: 0x00007FF4
		internal static string GetSafeEnvironmentVariable(string name)
		{
			string text;
			try
			{
				string environmentVariable = Environment.GetEnvironmentVariable(name);
				if (environmentVariable == null || environmentVariable.Length == 0)
				{
					text = null;
				}
				else
				{
					text = environmentVariable;
				}
			}
			catch (SecurityException)
			{
				text = string.Empty;
			}
			return text;
		}
	}
}
