using System;
using System.Security.Cryptography;

namespace BattleNET
{
	// Token: 0x02000009 RID: 9
	internal class CRC32 : HashAlgorithm
	{
		// Token: 0x06000031 RID: 49 RVA: 0x00002BC5 File Offset: 0x00000DC5
		public CRC32()
		{
			this._table = CRC32.InitializeTable(3988292384U);
			this._seed = uint.MaxValue;
			this.Initialize();
		}

		// Token: 0x06000032 RID: 50 RVA: 0x00002BEA File Offset: 0x00000DEA
		public CRC32(uint polynomial, uint seed)
		{
			this._table = CRC32.InitializeTable(polynomial);
			this._seed = seed;
			this.Initialize();
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000033 RID: 51 RVA: 0x00002C0B File Offset: 0x00000E0B
		public override int HashSize
		{
			get
			{
				return 32;
			}
		}

		// Token: 0x06000034 RID: 52 RVA: 0x00002C0F File Offset: 0x00000E0F
		public sealed override void Initialize()
		{
			this._hash = this._seed;
		}

		// Token: 0x06000035 RID: 53 RVA: 0x00002C1D File Offset: 0x00000E1D
		protected override void HashCore(byte[] buffer, int start, int length)
		{
			this._hash = CRC32.CalculateHash(this._table, this._hash, buffer, start, length);
		}

		// Token: 0x06000036 RID: 54 RVA: 0x00002C3C File Offset: 0x00000E3C
		protected override byte[] HashFinal()
		{
			byte[] array = this.UInt32ToBigEndianBytes(~this._hash);
			this.HashValue = array;
			return array;
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00002C5F File Offset: 0x00000E5F
		public static uint Compute(byte[] buffer)
		{
			return ~CRC32.CalculateHash(CRC32.InitializeTable(3988292384U), uint.MaxValue, buffer, 0, buffer.Length);
		}

		// Token: 0x06000038 RID: 56 RVA: 0x00002C77 File Offset: 0x00000E77
		public static uint Compute(uint seed, byte[] buffer)
		{
			return ~CRC32.CalculateHash(CRC32.InitializeTable(3988292384U), seed, buffer, 0, buffer.Length);
		}

		// Token: 0x06000039 RID: 57 RVA: 0x00002C8F File Offset: 0x00000E8F
		public static uint Compute(uint polynomial, uint seed, byte[] buffer)
		{
			return ~CRC32.CalculateHash(CRC32.InitializeTable(polynomial), seed, buffer, 0, buffer.Length);
		}

		// Token: 0x0600003A RID: 58 RVA: 0x00002CA4 File Offset: 0x00000EA4
		private static uint[] InitializeTable(uint polynomial)
		{
			if (polynomial == 3988292384U && CRC32._defaultTable != null)
			{
				return CRC32._defaultTable;
			}
			uint[] array = new uint[256];
			for (int i = 0; i < 256; i++)
			{
				uint num = (uint)i;
				for (int j = 0; j < 8; j++)
				{
					if ((num & 1U) == 1U)
					{
						num = (num >> 1) ^ polynomial;
					}
					else
					{
						num >>= 1;
					}
				}
				array[i] = num;
			}
			if (polynomial == 3988292384U)
			{
				CRC32._defaultTable = array;
			}
			return array;
		}

		// Token: 0x0600003B RID: 59 RVA: 0x00002D14 File Offset: 0x00000F14
		private static uint CalculateHash(uint[] table, uint seed, byte[] buffer, int start, int size)
		{
			uint num = seed;
			for (int i = start; i < size; i++)
			{
				num = (num >> 8) ^ table[(int)((UIntPtr)((uint)buffer[i] ^ (num & 255U)))];
			}
			return num;
		}

		// Token: 0x0600003C RID: 60 RVA: 0x00002D44 File Offset: 0x00000F44
		private byte[] UInt32ToBigEndianBytes(uint x)
		{
			return new byte[]
			{
				(byte)((x >> 24) & 255U),
				(byte)((x >> 16) & 255U),
				(byte)((x >> 8) & 255U),
				(byte)(x & 255U)
			};
		}

		// Token: 0x04000015 RID: 21
		public const uint DefaultPolynomial = 3988292384U;

		// Token: 0x04000016 RID: 22
		public const uint DefaultSeed = 4294967295U;

		// Token: 0x04000017 RID: 23
		private static uint[] _defaultTable;

		// Token: 0x04000018 RID: 24
		private readonly uint _seed;

		// Token: 0x04000019 RID: 25
		private readonly uint[] _table;

		// Token: 0x0400001A RID: 26
		private uint _hash;
	}
}
