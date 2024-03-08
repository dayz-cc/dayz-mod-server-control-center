using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using NLog.Config;
using NLog.Internal;

namespace NLog.LayoutRenderers
{
	/// <summary>
	/// ASP Request variable.
	/// </summary>
	// Token: 0x02000097 RID: 151
	[LayoutRenderer("asp-request")]
	public class AspRequestValueLayoutRenderer : LayoutRenderer
	{
		/// <summary>
		/// Gets or sets the item name. The QueryString, Form, Cookies, or ServerVariables collection variables having the specified name are rendered.
		/// </summary>
		/// <docgen category="Rendering Options" order="10" />
		// Token: 0x170000AD RID: 173
		// (get) Token: 0x06000380 RID: 896 RVA: 0x0000D9EC File Offset: 0x0000BBEC
		// (set) Token: 0x06000381 RID: 897 RVA: 0x0000DA03 File Offset: 0x0000BC03
		[DefaultParameter]
		public string Item { get; set; }

		/// <summary>
		/// Gets or sets the QueryString variable to be rendered.
		/// </summary>
		/// <docgen category="Rendering Options" order="10" />
		// Token: 0x170000AE RID: 174
		// (get) Token: 0x06000382 RID: 898 RVA: 0x0000DA0C File Offset: 0x0000BC0C
		// (set) Token: 0x06000383 RID: 899 RVA: 0x0000DA23 File Offset: 0x0000BC23
		public string QueryString { get; set; }

		/// <summary>
		/// Gets or sets the form variable to be rendered.
		/// </summary>
		/// <docgen category="Rendering Options" order="10" />
		// Token: 0x170000AF RID: 175
		// (get) Token: 0x06000384 RID: 900 RVA: 0x0000DA2C File Offset: 0x0000BC2C
		// (set) Token: 0x06000385 RID: 901 RVA: 0x0000DA43 File Offset: 0x0000BC43
		public string Form { get; set; }

		/// <summary>
		/// Gets or sets the cookie to be rendered.
		/// </summary>
		/// <docgen category="Rendering Options" order="10" />
		// Token: 0x170000B0 RID: 176
		// (get) Token: 0x06000386 RID: 902 RVA: 0x0000DA4C File Offset: 0x0000BC4C
		// (set) Token: 0x06000387 RID: 903 RVA: 0x0000DA63 File Offset: 0x0000BC63
		public string Cookie { get; set; }

		/// <summary>
		/// Gets or sets the ServerVariables item to be rendered.
		/// </summary>
		/// <docgen category="Rendering Options" order="10" />
		// Token: 0x170000B1 RID: 177
		// (get) Token: 0x06000388 RID: 904 RVA: 0x0000DA6C File Offset: 0x0000BC6C
		// (set) Token: 0x06000389 RID: 905 RVA: 0x0000DA83 File Offset: 0x0000BC83
		public string ServerVariable { get; set; }

		/// <summary>
		/// Renders the specified ASP Request variable and appends it to the specified <see cref="T:System.Text.StringBuilder" />.
		/// </summary>
		/// <param name="builder">The <see cref="T:System.Text.StringBuilder" /> to append the rendered data to.</param>
		/// <param name="logEvent">Logging event.</param>
		// Token: 0x0600038A RID: 906 RVA: 0x0000DA8C File Offset: 0x0000BC8C
		protected override void Append(StringBuilder builder, LogEventInfo logEvent)
		{
			AspHelper.IRequest requestObject = AspHelper.GetRequestObject();
			if (requestObject != null)
			{
				if (this.QueryString != null)
				{
					builder.Append(AspRequestValueLayoutRenderer.GetItem(requestObject.GetQueryString(), this.QueryString));
				}
				else if (this.Form != null)
				{
					builder.Append(AspRequestValueLayoutRenderer.GetItem(requestObject.GetForm(), this.Form));
				}
				else if (this.Cookie != null)
				{
					object item = requestObject.GetCookies().GetItem(this.Cookie);
					builder.Append(Convert.ToString(AspHelper.GetComDefaultProperty(item), CultureInfo.InvariantCulture));
				}
				else if (this.ServerVariable != null)
				{
					builder.Append(AspRequestValueLayoutRenderer.GetItem(requestObject.GetServerVariables(), this.ServerVariable));
				}
				else if (this.Item != null)
				{
					AspHelper.IDispatch item2 = requestObject.GetItem(this.Item);
					AspHelper.IStringList stringList = item2 as AspHelper.IStringList;
					if (stringList != null)
					{
						if (stringList.GetCount() > 0)
						{
							builder.Append(stringList.GetItem(1));
						}
						Marshal.ReleaseComObject(stringList);
					}
				}
				Marshal.ReleaseComObject(requestObject);
			}
		}

		// Token: 0x0600038B RID: 907 RVA: 0x0000DBDC File Offset: 0x0000BDDC
		private static string GetItem(AspHelper.IRequestDictionary dict, string key)
		{
			object obj = null;
			object item = dict.GetItem(key);
			AspHelper.IStringList stringList = item as AspHelper.IStringList;
			string text;
			if (stringList != null)
			{
				if (stringList.GetCount() > 0)
				{
					obj = stringList.GetItem(1);
				}
				Marshal.ReleaseComObject(stringList);
				text = Convert.ToString(obj, CultureInfo.InvariantCulture);
			}
			else
			{
				text = item.GetType().ToString();
			}
			return text;
		}
	}
}
