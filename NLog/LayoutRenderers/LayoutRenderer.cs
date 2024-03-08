using System;
using System.Text;
using NLog.Common;
using NLog.Config;
using NLog.Internal;

namespace NLog.LayoutRenderers
{
	/// <summary>
	/// Render environmental information related to logging events.
	/// </summary>
	// Token: 0x02000095 RID: 149
	[NLogConfigurationItem]
	public abstract class LayoutRenderer : ISupportsInitialize, IRenderable, IDisposable
	{
		/// <summary>
		/// Gets the logging configuration this target is part of.
		/// </summary>
		// Token: 0x170000AB RID: 171
		// (get) Token: 0x0600036D RID: 877 RVA: 0x0000D75C File Offset: 0x0000B95C
		// (set) Token: 0x0600036E RID: 878 RVA: 0x0000D773 File Offset: 0x0000B973
		private protected LoggingConfiguration LoggingConfiguration { protected get; private set; }

		/// <summary>
		/// Returns a <see cref="T:System.String" /> that represents this instance.
		/// </summary>
		/// <returns>
		/// A <see cref="T:System.String" /> that represents this instance.
		/// </returns>
		// Token: 0x0600036F RID: 879 RVA: 0x0000D77C File Offset: 0x0000B97C
		public override string ToString()
		{
			LayoutRendererAttribute layoutRendererAttribute = (LayoutRendererAttribute)Attribute.GetCustomAttribute(base.GetType(), typeof(LayoutRendererAttribute));
			string text;
			if (layoutRendererAttribute != null)
			{
				text = "Layout Renderer: ${" + layoutRendererAttribute.Name + "}";
			}
			else
			{
				text = base.GetType().Name;
			}
			return text;
		}

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		// Token: 0x06000370 RID: 880 RVA: 0x0000D7D5 File Offset: 0x0000B9D5
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		/// <summary>
		/// Renders the the value of layout renderer in the context of the specified log event.
		/// </summary>
		/// <param name="logEvent">The log event.</param>
		/// <returns>String representation of a layout renderer.</returns>
		// Token: 0x06000371 RID: 881 RVA: 0x0000D7E8 File Offset: 0x0000B9E8
		public string Render(LogEventInfo logEvent)
		{
			int num = this.maxRenderedLength;
			if (num > 16384)
			{
				num = 16384;
			}
			StringBuilder stringBuilder = new StringBuilder(num);
			this.Render(stringBuilder, logEvent);
			if (stringBuilder.Length > this.maxRenderedLength)
			{
				this.maxRenderedLength = stringBuilder.Length;
			}
			return stringBuilder.ToString();
		}

		/// <summary>
		/// Initializes this instance.
		/// </summary>
		/// <param name="configuration">The configuration.</param>
		// Token: 0x06000372 RID: 882 RVA: 0x0000D851 File Offset: 0x0000BA51
		void ISupportsInitialize.Initialize(LoggingConfiguration configuration)
		{
			this.Initialize(configuration);
		}

		/// <summary>
		/// Closes this instance.
		/// </summary>
		// Token: 0x06000373 RID: 883 RVA: 0x0000D85C File Offset: 0x0000BA5C
		void ISupportsInitialize.Close()
		{
			this.Close();
		}

		/// <summary>
		/// Initializes this instance.
		/// </summary>
		/// <param name="configuration">The configuration.</param>
		// Token: 0x06000374 RID: 884 RVA: 0x0000D868 File Offset: 0x0000BA68
		internal void Initialize(LoggingConfiguration configuration)
		{
			if (!this.isInitialized)
			{
				this.LoggingConfiguration = configuration;
				this.isInitialized = true;
				this.InitializeLayoutRenderer();
			}
		}

		/// <summary>
		/// Closes this instance.
		/// </summary>
		// Token: 0x06000375 RID: 885 RVA: 0x0000D898 File Offset: 0x0000BA98
		internal void Close()
		{
			if (this.isInitialized)
			{
				this.LoggingConfiguration = null;
				this.isInitialized = false;
				this.CloseLayoutRenderer();
			}
		}

		// Token: 0x06000376 RID: 886 RVA: 0x0000D8CC File Offset: 0x0000BACC
		internal void Render(StringBuilder builder, LogEventInfo logEvent)
		{
			if (!this.isInitialized)
			{
				this.isInitialized = true;
				this.InitializeLayoutRenderer();
			}
			try
			{
				this.Append(builder, logEvent);
			}
			catch (Exception ex)
			{
				if (ex.MustBeRethrown())
				{
					throw;
				}
				InternalLogger.Warn("Exception in layout renderer: {0}", new object[] { ex });
			}
		}

		/// <summary>
		/// Renders the specified environmental information and appends it to the specified <see cref="T:System.Text.StringBuilder" />.
		/// </summary>
		/// <param name="builder">The <see cref="T:System.Text.StringBuilder" /> to append the rendered data to.</param>
		/// <param name="logEvent">Logging event.</param>
		// Token: 0x06000377 RID: 887
		protected abstract void Append(StringBuilder builder, LogEventInfo logEvent);

		/// <summary>
		/// Initializes the layout renderer.
		/// </summary>
		// Token: 0x06000378 RID: 888 RVA: 0x0000D940 File Offset: 0x0000BB40
		protected virtual void InitializeLayoutRenderer()
		{
		}

		/// <summary>
		/// Closes the layout renderer.
		/// </summary>      
		// Token: 0x06000379 RID: 889 RVA: 0x0000D943 File Offset: 0x0000BB43
		protected virtual void CloseLayoutRenderer()
		{
		}

		/// <summary>
		/// Releases unmanaged and - optionally - managed resources.
		/// </summary>
		/// <param name="disposing">True to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
		// Token: 0x0600037A RID: 890 RVA: 0x0000D948 File Offset: 0x0000BB48
		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				this.Close();
			}
		}

		// Token: 0x04000101 RID: 257
		private const int MaxInitialRenderBufferLength = 16384;

		// Token: 0x04000102 RID: 258
		private int maxRenderedLength;

		// Token: 0x04000103 RID: 259
		private bool isInitialized;
	}
}
