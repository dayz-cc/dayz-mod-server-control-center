using System;
using System.Diagnostics;
using System.Reflection;

namespace \u0001
{
	// Token: 0x02000011 RID: 17
	internal sealed class \u0001
	{
		// Token: 0x06000123 RID: 291 RVA: 0x00010750 File Offset: 0x0000E950
		internal static void \u0001()
		{
			try
			{
				AppDomain.CurrentDomain.ResourceResolve += global::\u0001.\u0001.\u0001;
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06000124 RID: 292 RVA: 0x00010788 File Offset: 0x0000E988
		private static Assembly \u0001(object A_0, ResolveEventArgs A_1)
		{
			if (global::\u0001.\u0001.\u0001 == null)
			{
				lock (global::\u0001.\u0001.\u0001)
				{
					global::\u0001.\u0001.\u0001 = Assembly.Load("{e7c06b11-1a11-464b-a1a7-acf23cecba1c}, PublicKeyToken=3e56350693f7355e");
					if (global::\u0001.\u0001.\u0001 != null)
					{
						global::\u0001.\u0001.\u0001 = global::\u0001.\u0001.\u0001.GetManifestResourceNames();
					}
				}
			}
			string name = A_1.Name;
			int i = 0;
			while (i < global::\u0001.\u0001.\u0001.Length)
			{
				if (global::\u0001.\u0001.\u0001[i] == name)
				{
					if (!global::\u0001.\u0001.\u0001())
					{
						return null;
					}
					return global::\u0001.\u0001.\u0001;
				}
				else
				{
					i++;
				}
			}
			return null;
		}

		// Token: 0x06000125 RID: 293 RVA: 0x00010820 File Offset: 0x0000EA20
		private static bool \u0001()
		{
			bool flag;
			try
			{
				StackFrame[] frames = new StackTrace().GetFrames();
				for (int i = 2; i < frames.Length; i++)
				{
					StackFrame stackFrame = frames[i];
					if (stackFrame.GetMethod().Module.Assembly == Assembly.GetExecutingAssembly())
					{
						return true;
					}
				}
				flag = false;
			}
			catch
			{
				flag = true;
			}
			return flag;
		}

		// Token: 0x040000AB RID: 171
		private static Assembly \u0001 = null;

		// Token: 0x040000AC RID: 172
		private static string[] \u0001 = new string[0];
	}
}
