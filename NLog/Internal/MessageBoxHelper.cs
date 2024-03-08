using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;

namespace NLog.Internal
{
	/// <summary>
	/// Message Box helper.
	/// </summary>
	// Token: 0x0200006F RID: 111
	internal class MessageBoxHelper
	{
		/// <summary>
		/// Shows the specified message using platform-specific message box.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="caption">The caption.</param>
		// Token: 0x060002BF RID: 703 RVA: 0x0000AFAD File Offset: 0x000091AD
		[SuppressMessage("Microsoft.Globalization", "CA1300:SpecifyMessageBoxOptions", Justification = "Not important here.")]
		public static void Show(string message, string caption)
		{
			MessageBox.Show(message, caption);
		}
	}
}
