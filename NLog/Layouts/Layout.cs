using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using NLog.Config;
using NLog.Internal;

namespace NLog.Layouts
{
	/// <summary>
	/// Abstract interface that layouts must implement.
	/// </summary>
	// Token: 0x020000D9 RID: 217
	[NLogConfigurationItem]
	[SuppressMessage("Microsoft.Naming", "CA1724:TypeNamesShouldNotMatchNamespaces", Justification = "Few people will see this conflict.")]
	public abstract class Layout : ISupportsInitialize, IRenderable
	{
		/// <summary>
		/// Gets a value indicating whether this layout is thread-agnostic (can be rendered on any thread).
		/// </summary>
		/// <remarks>
		/// Layout is thread-agnostic if it has been marked with [ThreadAgnostic] attribute and all its children are
		/// like that as well.
		/// Thread-agnostic layouts only use contents of <see cref="T:NLog.LogEventInfo" /> for its output.
		/// </remarks>
		// Token: 0x1700011E RID: 286
		// (get) Token: 0x06000507 RID: 1287 RVA: 0x000118E8 File Offset: 0x0000FAE8
		internal bool IsThreadAgnostic
		{
			get
			{
				return this.threadAgnostic;
			}
		}

		/// <summary>
		/// Gets the logging configuration this target is part of.
		/// </summary>
		// Token: 0x1700011F RID: 287
		// (get) Token: 0x06000508 RID: 1288 RVA: 0x00011900 File Offset: 0x0000FB00
		// (set) Token: 0x06000509 RID: 1289 RVA: 0x00011917 File Offset: 0x0000FB17
		private protected LoggingConfiguration LoggingConfiguration { protected get; private set; }

		/// <summary>
		/// Converts a given text to a <see cref="T:NLog.Layouts.Layout" />.
		/// </summary>
		/// <param name="text">Text to be converted.</param>
		/// <returns><see cref="T:NLog.Layouts.SimpleLayout" /> object represented by the text.</returns>
		// Token: 0x0600050A RID: 1290 RVA: 0x00011920 File Offset: 0x0000FB20
		public static implicit operator Layout([Localizable(false)] string text)
		{
			return Layout.FromString(text);
		}

		/// <summary>
		/// Implicitly converts the specified string to a <see cref="T:NLog.Layouts.SimpleLayout" />.
		/// </summary>
		/// <param name="layoutText">The layout string.</param>
		/// <returns>Instance of <see cref="T:NLog.Layouts.SimpleLayout" />.</returns>
		// Token: 0x0600050B RID: 1291 RVA: 0x00011938 File Offset: 0x0000FB38
		public static Layout FromString(string layoutText)
		{
			return Layout.FromString(layoutText, ConfigurationItemFactory.Default);
		}

		/// <summary>
		/// Implicitly converts the specified string to a <see cref="T:NLog.Layouts.SimpleLayout" />.
		/// </summary>
		/// <param name="layoutText">The layout string.</param>
		/// <param name="configurationItemFactory">The NLog factories to use when resolving layout renderers.</param>
		/// <returns>Instance of <see cref="T:NLog.Layouts.SimpleLayout" />.</returns>
		// Token: 0x0600050C RID: 1292 RVA: 0x00011958 File Offset: 0x0000FB58
		public static Layout FromString(string layoutText, ConfigurationItemFactory configurationItemFactory)
		{
			return new SimpleLayout(layoutText, configurationItemFactory);
		}

		/// <summary>
		/// Precalculates the layout for the specified log event and stores the result
		/// in per-log event cache.
		/// </summary>
		/// <param name="logEvent">The log event.</param>
		/// <remarks>
		/// Calling this method enables you to store the log event in a buffer
		/// and/or potentially evaluate it in another thread even though the 
		/// layout may contain thread-dependent renderer.
		/// </remarks>
		// Token: 0x0600050D RID: 1293 RVA: 0x00011974 File Offset: 0x0000FB74
		public virtual void Precalculate(LogEventInfo logEvent)
		{
			if (!this.threadAgnostic)
			{
				this.Render(logEvent);
			}
		}

		/// <summary>
		/// Renders the event info in layout.
		/// </summary>
		/// <param name="logEvent">The event info.</param>
		/// <returns>String representing log event.</returns>
		// Token: 0x0600050E RID: 1294 RVA: 0x00011998 File Offset: 0x0000FB98
		public string Render(LogEventInfo logEvent)
		{
			if (!this.isInitialized)
			{
				this.isInitialized = true;
				this.InitializeLayout();
			}
			return this.GetFormattedMessage(logEvent);
		}

		/// <summary>
		/// Initializes this instance.
		/// </summary>
		/// <param name="configuration">The configuration.</param>
		// Token: 0x0600050F RID: 1295 RVA: 0x000119CB File Offset: 0x0000FBCB
		void ISupportsInitialize.Initialize(LoggingConfiguration configuration)
		{
			this.Initialize(configuration);
		}

		/// <summary>
		/// Closes this instance.
		/// </summary>
		// Token: 0x06000510 RID: 1296 RVA: 0x000119D6 File Offset: 0x0000FBD6
		void ISupportsInitialize.Close()
		{
			this.Close();
		}

		/// <summary>
		/// Initializes this instance.
		/// </summary>
		/// <param name="configuration">The configuration.</param>
		// Token: 0x06000511 RID: 1297 RVA: 0x000119E0 File Offset: 0x0000FBE0
		internal void Initialize(LoggingConfiguration configuration)
		{
			if (!this.isInitialized)
			{
				this.LoggingConfiguration = configuration;
				this.isInitialized = true;
				this.threadAgnostic = true;
				foreach (object obj in ObjectGraphScanner.FindReachableObjects<object>(new object[] { this }))
				{
					if (!obj.GetType().IsDefined(typeof(ThreadAgnosticAttribute), true))
					{
						this.threadAgnostic = false;
						break;
					}
				}
				this.InitializeLayout();
			}
		}

		/// <summary>
		/// Closes this instance.
		/// </summary>
		// Token: 0x06000512 RID: 1298 RVA: 0x00011A6C File Offset: 0x0000FC6C
		internal void Close()
		{
			if (this.isInitialized)
			{
				this.LoggingConfiguration = null;
				this.isInitialized = false;
				this.CloseLayout();
			}
		}

		/// <summary>
		/// Initializes the layout.
		/// </summary>
		// Token: 0x06000513 RID: 1299 RVA: 0x00011A9F File Offset: 0x0000FC9F
		protected virtual void InitializeLayout()
		{
		}

		/// <summary>
		/// Closes the layout.
		/// </summary>
		// Token: 0x06000514 RID: 1300 RVA: 0x00011AA2 File Offset: 0x0000FCA2
		protected virtual void CloseLayout()
		{
		}

		/// <summary>
		/// Renders the layout for the specified logging event by invoking layout renderers.
		/// </summary>
		/// <param name="logEvent">The logging event.</param>
		/// <returns>The rendered layout.</returns>
		// Token: 0x06000515 RID: 1301
		protected abstract string GetFormattedMessage(LogEventInfo logEvent);

		// Token: 0x040001C2 RID: 450
		private bool isInitialized;

		// Token: 0x040001C3 RID: 451
		private bool threadAgnostic;
	}
}
