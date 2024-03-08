using System;
using System.Security.Cryptography;

namespace BattleNET
{
	// Token: 0x02000006 RID: 6
	internal class CRC32 : HashAlgorithm
	{
		// Token: 0x0600000D RID: 13 RVA: 0x00002198 File Offset: 0x00000398
		public CRC32()
		{
			this._table = CRC32.InitializeTable(3988292384U);
			this._seed = uint.MaxValue;
			this.Initialize();
		}

		// Token: 0x0600000E RID: 14 RVA: 0x000021BD File Offset: 0x000003BD
		public CRC32(uint polynomial, uint seed)
		{
			this._table = CRC32.InitializeTable(polynomial);
			this._seed = seed;
			this.Initialize();
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x0600000F RID: 15 RVA: 0x000021DE File Offset: 0x000003DE
		public override int HashSize
		{
			get
			{
				return 32;
			}
		}

		// Token: 0x06000010 RID: 16 RVA: 0x000021E2 File Offset: 0x000003E2
		public sealed override void Initialize()
		{
			this._hash = this._seed;
		}

		// Token: 0x06000011 RID: 17 RVA: 0x000021F0 File Offset: 0x000003F0
		protected override void HashCore(byte[] buffer, int start, int length)
		{
			this._hash = CRC32.CalculateHash(this._table, this._hash, buffer, start, length);
		}

		// Token: 0x06000012 RID: 18 RVA: 0x0000220C File Offset: 0x0000040C
		protected override byte[] HashFinal()
		{
			byte[] array = this.UInt32ToBigEndianBytes(~this._hash);
			this.HashValue = array;
			return array;
		}

		// Token: 0x06000013 RID: 19 RVA: 0x0000222F File Offset: 0x0000042F
		public static uint Compute(byte[] buffer)
		{
			return ~CRC32.CalculateHash(CRC32.InitializeTable(3988292384U), uint.MaxValue, buffer, 0, buffer.Length);
		}

		// Token: 0x06000014 RID: 20 RVA: 0x00002247 File Offset: 0x00000447
		public static uint Compute(uint seed, byte[] buffer)
		{
			return ~CRC32.CalculateHash(CRC32.InitializeTable(3988292384U), seed, buffer, 0, buffer.Length);
		}

		// Token: 0x06000015 RID: 21 RVA: 0x0000225F File Offset: 0x0000045F
		public static uint Compute(uint polynomial, uint seed, byte[] buffer)
		{
			return ~CRC32.CalculateHash(CRC32.InitializeTable(polynomial), seed, buffer, 0, buffer.Length);
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00002274 File Offset: 0x00000474
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

		// Token: 0x06000017 RID: 23 RVA: 0x000022E4 File Offset: 0x000004E4
		private static uint CalculateHash(uint[] table, uint seed, byte[] buffer, int start, int size)
		{
			uint num = seed;
			for (int i = start; i < size; i++)
			{
				num = (num >> 8) ^ table[(int)((UIntPtr)((uint)buffer[i] ^ (num & 255U)))];
			}
			return num;
		}

		// Token: 0x06000018 RID: 24 RVA: 0x00002314 File Offset: 0x00000514
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

		// Token: 0x04000008 RID: 8
		public const uint DefaultPolynomial = 3988292384U;

		// Token: 0x04000009 RID: 9
		public const uint DefaultSeed = 4294967295U;

		// Token: 0x0400000A RID: 10
		private static uint[] _defaultTable;

		// Token: 0x0400000B RID: 11
		private readonly uint _seed;

		// Token: 0x0400000C RID: 12
		private readonly uint[] _table;

		// Token: 0x0400000D RID: 13
		private uint _hash;
	}
}
