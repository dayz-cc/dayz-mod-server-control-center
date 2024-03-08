using System;

namespace NLog.Internal
{
	/// <summary>
	/// Simple character tokenizer.
	/// </summary>
	// Token: 0x02000085 RID: 133
	internal class SimpleStringReader
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:NLog.Internal.SimpleStringReader" /> class.
		/// </summary>
		/// <param name="text">The text to be tokenized.</param>
		// Token: 0x0600033D RID: 829 RVA: 0x0000CF04 File Offset: 0x0000B104
		public SimpleStringReader(string text)
		{
			this.text = text;
			this.Position = 0;
		}

		// Token: 0x170000A2 RID: 162
		// (get) Token: 0x0600033E RID: 830 RVA: 0x0000CF20 File Offset: 0x0000B120
		// (set) Token: 0x0600033F RID: 831 RVA: 0x0000CF37 File Offset: 0x0000B137
		internal int Position { get; set; }

		// Token: 0x170000A3 RID: 163
		// (get) Token: 0x06000340 RID: 832 RVA: 0x0000CF40 File Offset: 0x0000B140
		internal string Text
		{
			get
			{
				return this.text;
			}
		}

		// Token: 0x06000341 RID: 833 RVA: 0x0000CF58 File Offset: 0x0000B158
		internal int Peek()
		{
			int num;
			if (this.Position < this.text.Length)
			{
				num = (int)this.text[this.Position];
			}
			else
			{
				num = -1;
			}
			return num;
		}

		// Token: 0x06000342 RID: 834 RVA: 0x0000CF9C File Offset: 0x0000B19C
		internal int Read()
		{
			int num;
			if (this.Position < this.text.Length)
			{
				num = (int)this.text[this.Position++];
			}
			else
			{
				num = -1;
			}
			return num;
		}

		// Token: 0x06000343 RID: 835 RVA: 0x0000CFEC File Offset: 0x0000B1EC
		internal string Substring(int p0, int p1)
		{
			return this.text.Substring(p0, p1 - p0);
		}

		// Token: 0x040000DB RID: 219
		private readonly string text;
	}
}
