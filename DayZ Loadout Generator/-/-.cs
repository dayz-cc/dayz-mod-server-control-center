using System;
using System.Diagnostics;
using System.Reflection;

namespace _0001
{
	internal sealed class _0001
	{
		private static Assembly m__0001 = null;

		private static string[] m__0001 = new string[0];

		internal static void _0001()
		{
			try
			{
				AppDomain.CurrentDomain.ResourceResolve += _0001;
			}
			catch (Exception)
			{
			}
		}

		private static Assembly _0001(object P_0, ResolveEventArgs P_1)
		{
			if (global::_0001._0001.m__0001 == null)
			{
				lock (global::_0001._0001.m__0001)
				{
					global::_0001._0001.m__0001 = Assembly.Load("{e7c06b11-1a11-464b-a1a7-acf23cecba1c}, PublicKeyToken=3e56350693f7355e");
					if (global::_0001._0001.m__0001 != null)
					{
						global::_0001._0001.m__0001 = global::_0001._0001.m__0001.GetManifestResourceNames();
					}
				}
			}
			string name = P_1.Name;
			for (int i = 0; i < global::_0001._0001.m__0001.Length; i++)
			{
				if (global::_0001._0001.m__0001[i] == name)
				{
					if (!_0001())
					{
						return null;
					}
					return global::_0001._0001.m__0001;
				}
			}
			return null;
		}

		private static bool _0001()
		{
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
				return false;
			}
			catch
			{
				return true;
			}
		}
	}
}
