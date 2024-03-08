using System;
using System.Globalization;
using System.Reflection;
using System.Runtime.InteropServices;

namespace NLog.Internal
{
	/// <summary>
	/// Various helper methods for accessing state of ASP application.
	/// </summary>
	// Token: 0x02000048 RID: 72
	internal class AspHelper
	{
		// Token: 0x060001EA RID: 490 RVA: 0x000095F0 File Offset: 0x000077F0
		private AspHelper()
		{
		}

		// Token: 0x060001EB RID: 491 RVA: 0x000095FC File Offset: 0x000077FC
		public static AspHelper.ISessionObject GetSessionObject()
		{
			AspHelper.ISessionObject sessionObject = null;
			AspHelper.IObjectContext objectContext;
			if (0 == NativeMethods.CoGetObjectContext(ref AspHelper.IID_IObjectContext, out objectContext))
			{
				AspHelper.IGetContextProperties getContextProperties = (AspHelper.IGetContextProperties)objectContext;
				if (getContextProperties != null)
				{
					sessionObject = (AspHelper.ISessionObject)getContextProperties.GetProperty("Session");
					Marshal.ReleaseComObject(getContextProperties);
				}
				Marshal.ReleaseComObject(objectContext);
			}
			return sessionObject;
		}

		// Token: 0x060001EC RID: 492 RVA: 0x00009660 File Offset: 0x00007860
		public static AspHelper.IApplicationObject GetApplicationObject()
		{
			AspHelper.IApplicationObject applicationObject = null;
			AspHelper.IObjectContext objectContext;
			if (0 == NativeMethods.CoGetObjectContext(ref AspHelper.IID_IObjectContext, out objectContext))
			{
				AspHelper.IGetContextProperties getContextProperties = (AspHelper.IGetContextProperties)objectContext;
				if (getContextProperties != null)
				{
					applicationObject = (AspHelper.IApplicationObject)getContextProperties.GetProperty("Application");
					Marshal.ReleaseComObject(getContextProperties);
				}
				Marshal.ReleaseComObject(objectContext);
			}
			return applicationObject;
		}

		// Token: 0x060001ED RID: 493 RVA: 0x000096C4 File Offset: 0x000078C4
		public static AspHelper.IRequest GetRequestObject()
		{
			AspHelper.IRequest request = null;
			AspHelper.IObjectContext objectContext;
			if (0 == NativeMethods.CoGetObjectContext(ref AspHelper.IID_IObjectContext, out objectContext))
			{
				AspHelper.IGetContextProperties getContextProperties = (AspHelper.IGetContextProperties)objectContext;
				if (getContextProperties != null)
				{
					request = (AspHelper.IRequest)getContextProperties.GetProperty("Request");
					Marshal.ReleaseComObject(getContextProperties);
				}
				Marshal.ReleaseComObject(objectContext);
			}
			return request;
		}

		// Token: 0x060001EE RID: 494 RVA: 0x00009728 File Offset: 0x00007928
		public static AspHelper.IResponse GetResponseObject()
		{
			AspHelper.IResponse response = null;
			AspHelper.IObjectContext objectContext;
			if (0 == NativeMethods.CoGetObjectContext(ref AspHelper.IID_IObjectContext, out objectContext))
			{
				AspHelper.IGetContextProperties getContextProperties = (AspHelper.IGetContextProperties)objectContext;
				if (getContextProperties != null)
				{
					response = (AspHelper.IResponse)getContextProperties.GetProperty("Response");
					Marshal.ReleaseComObject(getContextProperties);
				}
				Marshal.ReleaseComObject(objectContext);
			}
			return response;
		}

		// Token: 0x060001EF RID: 495 RVA: 0x0000978C File Offset: 0x0000798C
		public static object GetComDefaultProperty(object o)
		{
			object obj;
			if (o == null)
			{
				obj = null;
			}
			else
			{
				obj = o.GetType().InvokeMember(string.Empty, BindingFlags.GetProperty, null, o, new object[0], CultureInfo.InvariantCulture);
			}
			return obj;
		}

		// Token: 0x0400009F RID: 159
		private static Guid IID_IObjectContext = new Guid("51372ae0-cae7-11cf-be81-00aa00a2fa25");

		// Token: 0x02000049 RID: 73
		[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		[Guid("51372ae0-cae7-11cf-be81-00aa00a2fa25")]
		[ComImport]
		public interface IObjectContext
		{
		}

		// Token: 0x0200004A RID: 74
		[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		[Guid("51372af4-cae7-11cf-be81-00aa00a2fa25")]
		[ComImport]
		public interface IGetContextProperties
		{
			// Token: 0x060001F1 RID: 497
			int Count();

			// Token: 0x060001F2 RID: 498
			object GetProperty(string name);
		}

		// Token: 0x0200004B RID: 75
		[InterfaceType(ComInterfaceType.InterfaceIsDual)]
		[Guid("D97A6DA0-A865-11cf-83AF-00A0C90C2BD8")]
		[ComImport]
		public interface ISessionObject
		{
			// Token: 0x060001F3 RID: 499
			string GetSessionID();

			// Token: 0x060001F4 RID: 500
			object GetValue(string name);

			// Token: 0x060001F5 RID: 501
			void PutValue(string name, object val);

			// Token: 0x060001F6 RID: 502
			int GetTimeout();

			// Token: 0x060001F7 RID: 503
			void PutTimeout(int t);

			// Token: 0x060001F8 RID: 504
			void Abandon();

			// Token: 0x060001F9 RID: 505
			int GetCodePage();

			// Token: 0x060001FA RID: 506
			void PutCodePage(int cp);

			// Token: 0x060001FB RID: 507
			int GetLCID();

			// Token: 0x060001FC RID: 508
			void PutLCID();
		}

		// Token: 0x0200004C RID: 76
		[Guid("D97A6DA0-A866-11cf-83AE-10A0C90C2BD8")]
		[InterfaceType(ComInterfaceType.InterfaceIsDual)]
		[ComImport]
		public interface IApplicationObject
		{
			// Token: 0x060001FD RID: 509
			object GetValue(string name);

			// Token: 0x060001FE RID: 510
			void PutValue(string name, object val);
		}

		// Token: 0x0200004D RID: 77
		[InterfaceType(ComInterfaceType.InterfaceIsDual)]
		[Guid("D97A6DA0-A85D-11cf-83AE-00A0C90C2BD8")]
		[ComImport]
		public interface IStringList
		{
			// Token: 0x060001FF RID: 511
			object GetItem(object key);

			// Token: 0x06000200 RID: 512
			int GetCount();

			// Token: 0x06000201 RID: 513
			object NewEnum();
		}

		// Token: 0x0200004E RID: 78
		[InterfaceType(ComInterfaceType.InterfaceIsDual)]
		[Guid("D97A6DA0-A85F-11df-83AE-00A0C90C2BD8")]
		[ComImport]
		public interface IRequestDictionary
		{
			// Token: 0x06000202 RID: 514
			object GetItem(object var);

			// Token: 0x06000203 RID: 515
			object NewEnum();

			// Token: 0x06000204 RID: 516
			int GetCount();

			// Token: 0x06000205 RID: 517
			object Key(object varKey);
		}

		// Token: 0x0200004F RID: 79
		[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
		[Guid("00020400-0000-0000-C000-000000000046")]
		[ComImport]
		public interface IDispatch
		{
		}

		// Token: 0x02000050 RID: 80
		[Guid("D97A6DA0-A861-11cf-93AE-00A0C90C2BD8")]
		[InterfaceType(ComInterfaceType.InterfaceIsDual)]
		[ComImport]
		public interface IRequest
		{
			// Token: 0x06000206 RID: 518
			AspHelper.IDispatch GetItem(string name);

			// Token: 0x06000207 RID: 519
			AspHelper.IRequestDictionary GetQueryString();

			// Token: 0x06000208 RID: 520
			AspHelper.IRequestDictionary GetForm();

			// Token: 0x06000209 RID: 521
			AspHelper.IRequestDictionary GetBody();

			// Token: 0x0600020A RID: 522
			AspHelper.IRequestDictionary GetServerVariables();

			// Token: 0x0600020B RID: 523
			AspHelper.IRequestDictionary GetClientCertificates();

			// Token: 0x0600020C RID: 524
			AspHelper.IRequestDictionary GetCookies();

			// Token: 0x0600020D RID: 525
			int GetTotalBytes();

			// Token: 0x0600020E RID: 526
			void BinaryRead();
		}

		// Token: 0x02000051 RID: 81
		[InterfaceType(ComInterfaceType.InterfaceIsDual)]
		[Guid("D97A6DA0-A864-11cf-83BE-00A0C90C2BD8")]
		[ComImport]
		public interface IResponse
		{
			// Token: 0x0600020F RID: 527
			void GetBuffer();

			// Token: 0x06000210 RID: 528
			void PutBuffer();

			// Token: 0x06000211 RID: 529
			void GetContentType();

			// Token: 0x06000212 RID: 530
			void PutContentType();

			// Token: 0x06000213 RID: 531
			void GetExpires();

			// Token: 0x06000214 RID: 532
			void PutExpires();

			// Token: 0x06000215 RID: 533
			void GetExpiresAbsolute();

			// Token: 0x06000216 RID: 534
			void PutExpiresAbsolute();

			// Token: 0x06000217 RID: 535
			void GetCookies();

			// Token: 0x06000218 RID: 536
			void GetStatus();

			// Token: 0x06000219 RID: 537
			void PutStatus();

			// Token: 0x0600021A RID: 538
			void Add();

			// Token: 0x0600021B RID: 539
			void AddHeader();

			// Token: 0x0600021C RID: 540
			void AppendToLog();

			// Token: 0x0600021D RID: 541
			void BinaryWrite();

			// Token: 0x0600021E RID: 542
			void Clear();

			// Token: 0x0600021F RID: 543
			void End();

			// Token: 0x06000220 RID: 544
			void Flush();

			// Token: 0x06000221 RID: 545
			void Redirect();

			// Token: 0x06000222 RID: 546
			void Write(object text);
		}

		// Token: 0x02000052 RID: 82
		[InterfaceType(ComInterfaceType.InterfaceIsDual)]
		[Guid("71EAF260-0CE0-11D0-A53E-00A0C90C2091")]
		[ComImport]
		public interface IReadCookie
		{
			// Token: 0x06000223 RID: 547
			void GetItem(object key, out object val);

			// Token: 0x06000224 RID: 548
			object HasKeys();

			// Token: 0x06000225 RID: 549
			void GetNewEnum();

			// Token: 0x06000226 RID: 550
			void GetCount(out int count);

			// Token: 0x06000227 RID: 551
			object GetKey(object key);
		}
	}
}
