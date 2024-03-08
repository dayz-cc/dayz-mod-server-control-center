using System;
using System.Collections.ObjectModel;
using System.Text;
using NLog.Common;
using NLog.Config;
using NLog.Internal;
using NLog.LayoutRenderers;

namespace NLog.Layouts
{
	/// <summary>
	/// Represents a string with embedded placeholders that can render contextual information.
	/// </summary>
	/// <remarks>
	/// This layout is not meant to be used explicitly. Instead you can just use a string containing layout 
	/// renderers everywhere the layout is required.
	/// </remarks>
	// Token: 0x020000E1 RID: 225
	[AppDomainFixedOutput]
	[Layout("SimpleLayout")]
	[ThreadAgnostic]
	public class SimpleLayout : Layout
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Layouts.SimpleLayout" /> class.
		/// </summary>
		// Token: 0x06000540 RID: 1344 RVA: 0x00012856 File Offset: 0x00010A56
		public SimpleLayout()
			: this(string.Empty)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Layouts.SimpleLayout" /> class.
		/// </summary>
		/// <param name="txt">The layout string to parse.</param>
		// Token: 0x06000541 RID: 1345 RVA: 0x00012866 File Offset: 0x00010A66
		public SimpleLayout(string txt)
			: this(txt, ConfigurationItemFactory.Default)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Layouts.SimpleLayout" /> class.
		/// </summary>
		/// <param name="txt">The layout string to parse.</param>
		/// <param name="configurationItemFactory">The NLog factories to use when creating references to layout renderers.</param>
		// Token: 0x06000542 RID: 1346 RVA: 0x00012877 File Offset: 0x00010A77
		public SimpleLayout(string txt, ConfigurationItemFactory configurationItemFactory)
		{
			this.configurationItemFactory = configurationItemFactory;
			this.Text = txt;
		}

		// Token: 0x06000543 RID: 1347 RVA: 0x00012891 File Offset: 0x00010A91
		internal SimpleLayout(LayoutRenderer[] renderers, string text, ConfigurationItemFactory configurationItemFactory)
		{
			this.configurationItemFactory = configurationItemFactory;
			this.SetRenderers(renderers, text);
		}

		/// <summary>
		/// Gets or sets the layout text.
		/// </summary>
		/// <docgen category="Layout Options" order="10" />
		// Token: 0x1700012A RID: 298
		// (get) Token: 0x06000544 RID: 1348 RVA: 0x000128AC File Offset: 0x00010AAC
		// (set) Token: 0x06000545 RID: 1349 RVA: 0x000128C4 File Offset: 0x00010AC4
		public string Text
		{
			get
			{
				return this.layoutText;
			}
			set
			{
				string text;
				LayoutRenderer[] array = LayoutParser.CompileLayout(this.configurationItemFactory, new SimpleStringReader(value), false, out text);
				this.SetRenderers(array, text);
			}
		}

		/// <summary>
		/// Gets a collection of <see cref="T:NLog.LayoutRenderers.LayoutRenderer" /> objects that make up this layout.
		/// </summary>
		// Token: 0x1700012B RID: 299
		// (get) Token: 0x06000546 RID: 1350 RVA: 0x000128F0 File Offset: 0x00010AF0
		// (set) Token: 0x06000547 RID: 1351 RVA: 0x00012907 File Offset: 0x00010B07
		public ReadOnlyCollection<LayoutRenderer> Renderers { get; private set; }

		/// <summary>
		/// Converts a text to a simple layout.
		/// </summary>
		/// <param name="text">Text to be converted.</param>
		/// <returns>A <see cref="T:NLog.Layouts.SimpleLayout" /> object.</returns>
		// Token: 0x06000548 RID: 1352 RVA: 0x00012910 File Offset: 0x00010B10
		public new static implicit operator SimpleLayout(string text)
		{
			return new SimpleLayout(text);
		}

		/// <summary>
		/// Escapes the passed text so that it can
		/// be used literally in all places where
		/// layout is normally expected without being
		/// treated as layout.
		/// </summary>
		/// <param name="text">The text to be escaped.</param>
		/// <returns>The escaped text.</returns>
		/// <remarks>
		/// Escaping is done by replacing all occurences of
		/// '${' with '${literal:text=${}'
		/// </remarks>
		// Token: 0x06000549 RID: 1353 RVA: 0x00012928 File Offset: 0x00010B28
		public static string Escape(string text)
		{
			return text.Replace("${", "${literal:text=${}");
		}

		/// <summary>
		/// Evaluates the specified text by expadinging all layout renderers.
		/// </summary>
		/// <param name="text">The text to be evaluated.</param>
		/// <param name="logEvent">Log event to be used for evaluation.</param>
		/// <returns>The input text with all occurences of ${} replaced with
		/// values provided by the appropriate layout renderers.</returns>
		// Token: 0x0600054A RID: 1354 RVA: 0x0001294C File Offset: 0x00010B4C
		public static string Evaluate(string text, LogEventInfo logEvent)
		{
			SimpleLayout simpleLayout = new SimpleLayout(text);
			return simpleLayout.Render(logEvent);
		}

		/// <summary>
		/// Evaluates the specified text by expadinging all layout renderers
		/// in new <see cref="T:NLog.LogEventInfo" /> context.
		/// </summary>
		/// <param name="text">The text to be evaluated.</param>
		/// <returns>The input text with all occurences of ${} replaced with
		/// values provided by the appropriate layout renderers.</returns>
		// Token: 0x0600054B RID: 1355 RVA: 0x0001296C File Offset: 0x00010B6C
		public static string Evaluate(string text)
		{
			return SimpleLayout.Evaluate(text, LogEventInfo.CreateNullEvent());
		}

		/// <summary>
		/// Returns a <see cref="T:System.String"></see> that represents the current object.
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.String"></see> that represents the current object.
		/// </returns>
		// Token: 0x0600054C RID: 1356 RVA: 0x0001298C File Offset: 0x00010B8C
		public override string ToString()
		{
			return "'" + this.Text + "'";
		}

		// Token: 0x0600054D RID: 1357 RVA: 0x000129B4 File Offset: 0x00010BB4
		internal void SetRenderers(LayoutRenderer[] renderers, string text)
		{
			this.Renderers = new ReadOnlyCollection<LayoutRenderer>(renderers);
			if (this.Renderers.Count == 1 && this.Renderers[0] is LiteralLayoutRenderer)
			{
				this.fixedText = ((LiteralLayoutRenderer)this.Renderers[0]).Text;
			}
			else
			{
				this.fixedText = null;
			}
			this.layoutText = text;
		}

		/// <summary>
		/// Renders the layout for the specified logging event by invoking layout renderers
		/// that make up the event.
		/// </summary>
		/// <param name="logEvent">The logging event.</param>
		/// <returns>The rendered layout.</returns>
		// Token: 0x0600054E RID: 1358 RVA: 0x00012A2C File Offset: 0x00010C2C
		protected override string GetFormattedMessage(LogEventInfo logEvent)
		{
			string text;
			string text2;
			if (this.fixedText != null)
			{
				text = this.fixedText;
			}
			else if (logEvent.TryGetCachedLayoutValue(this, out text2))
			{
				text = text2;
			}
			else
			{
				int num = this.maxRenderedLength;
				if (num > 16384)
				{
					num = 16384;
				}
				StringBuilder stringBuilder = new StringBuilder(num);
				foreach (LayoutRenderer layoutRenderer in this.Renderers)
				{
					try
					{
						layoutRenderer.Render(stringBuilder, logEvent);
					}
					catch (Exception ex)
					{
						if (ex.MustBeRethrown())
						{
							throw;
						}
						if (InternalLogger.IsWarnEnabled)
						{
							InternalLogger.Warn("Exception in {0}.Append(): {1}.", new object[]
							{
								layoutRenderer.GetType().FullName,
								ex
							});
						}
					}
				}
				if (stringBuilder.Length > this.maxRenderedLength)
				{
					this.maxRenderedLength = stringBuilder.Length;
				}
				string text3 = stringBuilder.ToString();
				logEvent.AddCachedLayoutValue(this, text3);
				text = text3;
			}
			return text;
		}

		// Token: 0x040001D7 RID: 471
		private const int MaxInitialRenderBufferLength = 16384;

		// Token: 0x040001D8 RID: 472
		private int maxRenderedLength;

		// Token: 0x040001D9 RID: 473
		private string fixedText;

		// Token: 0x040001DA RID: 474
		private string layoutText;

		// Token: 0x040001DB RID: 475
		private ConfigurationItemFactory configurationItemFactory;
	}
}
