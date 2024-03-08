using System;
using System.Reflection;

namespace NLog.Targets
{
	/// <summary>
	/// Calls the specified static method on each log message and passes contextual parameters to it.
	/// </summary>
	/// <seealso href="http://nlog-project.org/wiki/MethodCall_target">Documentation on NLog Wiki</seealso>
	/// <example>
	/// <p>
	/// To set up the target in the <a href="config.html">configuration file</a>, 
	/// use the following syntax:
	/// </p>
	/// <code lang="XML" source="examples/targets/Configuration File/MethodCall/NLog.config" />
	/// <p>
	/// This assumes just one target and a single rule. More configuration
	/// options are described <a href="config.html">here</a>.
	/// </p>
	/// <p>
	/// To set up the log target programmatically use code like this:
	/// </p>
	/// <code lang="C#" source="examples/targets/Configuration API/MethodCall/Simple/Example.cs" />
	/// </example>
	// Token: 0x0200011D RID: 285
	[Target("MethodCall")]
	public sealed class MethodCallTarget : MethodCallTargetBase
	{
		/// <summary>
		/// Gets or sets the class name.
		/// </summary>
		/// <docgen category="Invocation Options" order="10" />
		// Token: 0x170001F5 RID: 501
		// (get) Token: 0x06000971 RID: 2417 RVA: 0x00021C54 File Offset: 0x0001FE54
		// (set) Token: 0x06000972 RID: 2418 RVA: 0x00021C6B File Offset: 0x0001FE6B
		public string ClassName { get; set; }

		/// <summary>
		/// Gets or sets the method name. The method must be public and static.
		/// </summary>
		/// <docgen category="Invocation Options" order="10" />
		// Token: 0x170001F6 RID: 502
		// (get) Token: 0x06000973 RID: 2419 RVA: 0x00021C74 File Offset: 0x0001FE74
		// (set) Token: 0x06000974 RID: 2420 RVA: 0x00021C8B File Offset: 0x0001FE8B
		public string MethodName { get; set; }

		// Token: 0x170001F7 RID: 503
		// (get) Token: 0x06000975 RID: 2421 RVA: 0x00021C94 File Offset: 0x0001FE94
		// (set) Token: 0x06000976 RID: 2422 RVA: 0x00021CAB File Offset: 0x0001FEAB
		private MethodInfo Method { get; set; }

		/// <summary>
		/// Initializes the target.
		/// </summary>
		// Token: 0x06000977 RID: 2423 RVA: 0x00021CB4 File Offset: 0x0001FEB4
		protected override void InitializeTarget()
		{
			base.InitializeTarget();
			if (this.ClassName != null && this.MethodName != null)
			{
				Type type = Type.GetType(this.ClassName);
				this.Method = type.GetMethod(this.MethodName);
			}
			else
			{
				this.Method = null;
			}
		}

		/// <summary>
		/// Calls the specified Method.
		/// </summary>
		/// <param name="parameters">Method parameters.</param>
		// Token: 0x06000978 RID: 2424 RVA: 0x00021D10 File Offset: 0x0001FF10
		protected override void DoInvoke(object[] parameters)
		{
			if (this.Method != null)
			{
				this.Method.Invoke(null, parameters);
			}
		}
	}
}
