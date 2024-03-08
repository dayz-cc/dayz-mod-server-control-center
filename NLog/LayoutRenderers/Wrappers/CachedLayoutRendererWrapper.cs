using System;
using System.ComponentModel;
using NLog.Config;

namespace NLog.LayoutRenderers.Wrappers
{
	/// <summary>
	/// Applies caching to another layout output.
	/// </summary>
	/// <remarks>
	/// The value of the inner layout will be rendered only once and reused subsequently.
	/// </remarks>
	// Token: 0x020000C9 RID: 201
	[AmbientProperty("Cached")]
	[ThreadAgnostic]
	[LayoutRenderer("cached")]
	public sealed class CachedLayoutRendererWrapper : WrapperLayoutRendererBase
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.LayoutRenderers.Wrappers.CachedLayoutRendererWrapper" /> class.
		/// </summary>
		// Token: 0x060004AE RID: 1198 RVA: 0x00010D6E File Offset: 0x0000EF6E
		public CachedLayoutRendererWrapper()
		{
			this.Cached = true;
		}

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="T:NLog.LayoutRenderers.Wrappers.CachedLayoutRendererWrapper" /> is enabled.
		/// </summary>
		/// <docgen category="Caching Options" order="10" />
		// Token: 0x17000107 RID: 263
		// (get) Token: 0x060004AF RID: 1199 RVA: 0x00010D84 File Offset: 0x0000EF84
		// (set) Token: 0x060004B0 RID: 1200 RVA: 0x00010D9B File Offset: 0x0000EF9B
		[DefaultValue(true)]
		public bool Cached { get; set; }

		/// <summary>
		/// Initializes the layout renderer.
		/// </summary>
		// Token: 0x060004B1 RID: 1201 RVA: 0x00010DA4 File Offset: 0x0000EFA4
		protected override void InitializeLayoutRenderer()
		{
			base.InitializeLayoutRenderer();
			this.cachedValue = null;
		}

		/// <summary>
		/// Closes the layout renderer.
		/// </summary>
		// Token: 0x060004B2 RID: 1202 RVA: 0x00010DB5 File Offset: 0x0000EFB5
		protected override void CloseLayoutRenderer()
		{
			base.CloseLayoutRenderer();
			this.cachedValue = null;
		}

		/// <summary>
		/// Transforms the output of another layout.
		/// </summary>
		/// <param name="text">Output to be transform.</param>
		/// <returns>Transformed text.</returns>
		// Token: 0x060004B3 RID: 1203 RVA: 0x00010DC8 File Offset: 0x0000EFC8
		protected override string Transform(string text)
		{
			return text;
		}

		/// <summary>
		/// Renders the inner layout contents.
		/// </summary>
		/// <param name="logEvent">The log event.</param>
		/// <returns>Contents of inner layout.</returns>
		// Token: 0x060004B4 RID: 1204 RVA: 0x00010DDC File Offset: 0x0000EFDC
		protected override string RenderInner(LogEventInfo logEvent)
		{
			string text;
			if (this.Cached)
			{
				if (this.cachedValue == null)
				{
					this.cachedValue = base.RenderInner(logEvent);
				}
				text = this.cachedValue;
			}
			else
			{
				text = base.RenderInner(logEvent);
			}
			return text;
		}

		// Token: 0x040001A2 RID: 418
		private string cachedValue;
	}
}
