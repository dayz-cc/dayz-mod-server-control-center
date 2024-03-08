using System;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace SmartAssembly.Zip
{
	// Token: 0x02000015 RID: 21
	public sealed class SimpleZip
	{
		// Token: 0x06000131 RID: 305 RVA: 0x00010AF0 File Offset: 0x0000ECF0
		private static bool PublicKeysMatch(Assembly executingAssembly, Assembly callingAssembly)
		{
			byte[] publicKey = executingAssembly.GetName().GetPublicKey();
			byte[] publicKey2 = callingAssembly.GetName().GetPublicKey();
			if (publicKey2 == null != (publicKey == null))
			{
				return false;
			}
			if (publicKey2 != null)
			{
				for (int i = 0; i < publicKey2.Length; i++)
				{
					if (publicKey2[i] != publicKey[i])
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x06000132 RID: 306 RVA: 0x00010B40 File Offset: 0x0000ED40
		public static byte[] Unzip(byte[] buffer)
		{
			Assembly callingAssembly = Assembly.GetCallingAssembly();
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			if (callingAssembly != executingAssembly && !SimpleZip.PublicKeysMatch(executingAssembly, callingAssembly))
			{
				return null;
			}
			SimpleZip.ZipStream zipStream = new SimpleZip.ZipStream(buffer);
			byte[] array = new byte[0];
			int num = zipStream.ReadInt();
			if (num != 67324752)
			{
				int num2 = num >> 24;
				num -= num2 << 24;
				if (num == 8223355)
				{
					if (num2 == 1)
					{
						int num3 = zipStream.ReadInt();
						array = new byte[num3];
						int num5;
						for (int i = 0; i < num3; i += num5)
						{
							int num4 = zipStream.ReadInt();
							num5 = zipStream.ReadInt();
							byte[] array2 = new byte[num4];
							zipStream.Read(array2, 0, array2.Length);
							SimpleZip.Inflater inflater = new SimpleZip.Inflater(array2);
							inflater.Inflate(array, i, num5);
						}
					}
					if (num2 == 2)
					{
						byte[] array3 = new byte[] { 33, 249, 95, 7, 81, 226, 66, 99 };
						byte[] array4 = new byte[] { 157, 207, 232, 140, 196, 158, 246, 237 };
						using (DESCryptoIndirector descryptoIndirector = new DESCryptoIndirector())
						{
							using (ICryptoTransform descryptoTransform = descryptoIndirector.GetDESCryptoTransform(array3, array4, true))
							{
								byte[] array5 = descryptoTransform.TransformFinalBlock(buffer, 4, buffer.Length - 4);
								array = SimpleZip.Unzip(array5);
							}
						}
					}
					if (num2 != 3)
					{
						goto IL_299;
					}
					byte[] array6 = new byte[]
					{
						1, 1, 1, 1, 1, 1, 1, 1, 1, 1,
						1, 1, 1, 1, 1, 1
					};
					byte[] array7 = new byte[]
					{
						2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
						2, 2, 2, 2, 2, 2
					};
					using (AESCryptoIndirector aescryptoIndirector = new AESCryptoIndirector())
					{
						using (ICryptoTransform aescryptoTransform = aescryptoIndirector.GetAESCryptoTransform(array6, array7, true))
						{
							byte[] array8 = aescryptoTransform.TransformFinalBlock(buffer, 4, buffer.Length - 4);
							array = SimpleZip.Unzip(array8);
						}
						goto IL_299;
					}
				}
				throw new FormatException("Unknown Header");
			}
			short num6 = (short)zipStream.ReadShort();
			int num7 = zipStream.ReadShort();
			int num8 = zipStream.ReadShort();
			if (num != 67324752 || num6 != 20 || num7 != 0 || num8 != 8)
			{
				throw new FormatException("Wrong Header Signature");
			}
			zipStream.ReadInt();
			zipStream.ReadInt();
			zipStream.ReadInt();
			int num9 = zipStream.ReadInt();
			int num10 = zipStream.ReadShort();
			int num11 = zipStream.ReadShort();
			if (num10 > 0)
			{
				byte[] array9 = new byte[num10];
				zipStream.Read(array9, 0, num10);
			}
			if (num11 > 0)
			{
				byte[] array10 = new byte[num11];
				zipStream.Read(array10, 0, num11);
			}
			byte[] array11 = new byte[zipStream.Length - zipStream.Position];
			zipStream.Read(array11, 0, array11.Length);
			SimpleZip.Inflater inflater2 = new SimpleZip.Inflater(array11);
			array = new byte[num9];
			inflater2.Inflate(array, 0, array.Length);
			IL_299:
			zipStream.Close();
			zipStream = null;
			return array;
		}

		// Token: 0x06000133 RID: 307 RVA: 0x00010E24 File Offset: 0x0000F024
		public static byte[] Zip(byte[] buffer)
		{
			return SimpleZip.Zip(buffer, 1, null, null);
		}

		// Token: 0x06000134 RID: 308 RVA: 0x00010E30 File Offset: 0x0000F030
		public static byte[] ZipAndEncrypt(byte[] buffer, byte[] key, byte[] iv)
		{
			return SimpleZip.Zip(buffer, 2, key, iv);
		}

		// Token: 0x06000135 RID: 309 RVA: 0x00010E3C File Offset: 0x0000F03C
		public static byte[] ZipAndAES(byte[] buffer, byte[] key, byte[] iv)
		{
			return SimpleZip.Zip(buffer, 3, key, iv);
		}

		// Token: 0x06000136 RID: 310 RVA: 0x00010E48 File Offset: 0x0000F048
		private static byte[] Zip(byte[] buffer, int version, byte[] key, byte[] iv)
		{
			byte[] array11;
			try
			{
				SimpleZip.ZipStream zipStream = new SimpleZip.ZipStream();
				if (version == 0)
				{
					SimpleZip.Deflater deflater = new SimpleZip.Deflater();
					DateTime now = DateTime.Now;
					long num = (long)((ulong)((((now.Year - 1980) & 127) << 25) | (now.Month << 21) | (now.Day << 16) | (now.Hour << 11) | (now.Minute << 5) | (int)((uint)now.Second >> 1)));
					uint[] array = new uint[]
					{
						0U, 1996959894U, 3993919788U, 2567524794U, 124634137U, 1886057615U, 3915621685U, 2657392035U, 249268274U, 2044508324U,
						3772115230U, 2547177864U, 162941995U, 2125561021U, 3887607047U, 2428444049U, 498536548U, 1789927666U, 4089016648U, 2227061214U,
						450548861U, 1843258603U, 4107580753U, 2211677639U, 325883990U, 1684777152U, 4251122042U, 2321926636U, 335633487U, 1661365465U,
						4195302755U, 2366115317U, 997073096U, 1281953886U, 3579855332U, 2724688242U, 1006888145U, 1258607687U, 3524101629U, 2768942443U,
						901097722U, 1119000684U, 3686517206U, 2898065728U, 853044451U, 1172266101U, 3705015759U, 2882616665U, 651767980U, 1373503546U,
						3369554304U, 3218104598U, 565507253U, 1454621731U, 3485111705U, 3099436303U, 671266974U, 1594198024U, 3322730930U, 2970347812U,
						795835527U, 1483230225U, 3244367275U, 3060149565U, 1994146192U, 31158534U, 2563907772U, 4023717930U, 1907459465U, 112637215U,
						2680153253U, 3904427059U, 2013776290U, 251722036U, 2517215374U, 3775830040U, 2137656763U, 141376813U, 2439277719U, 3865271297U,
						1802195444U, 476864866U, 2238001368U, 4066508878U, 1812370925U, 453092731U, 2181625025U, 4111451223U, 1706088902U, 314042704U,
						2344532202U, 4240017532U, 1658658271U, 366619977U, 2362670323U, 4224994405U, 1303535960U, 984961486U, 2747007092U, 3569037538U,
						1256170817U, 1037604311U, 2765210733U, 3554079995U, 1131014506U, 879679996U, 2909243462U, 3663771856U, 1141124467U, 855842277U,
						2852801631U, 3708648649U, 1342533948U, 654459306U, 3188396048U, 3373015174U, 1466479909U, 544179635U, 3110523913U, 3462522015U,
						1591671054U, 702138776U, 2966460450U, 3352799412U, 1504918807U, 783551873U, 3082640443U, 3233442989U, 3988292384U, 2596254646U,
						62317068U, 1957810842U, 3939845945U, 2647816111U, 81470997U, 1943803523U, 3814918930U, 2489596804U, 225274430U, 2053790376U,
						3826175755U, 2466906013U, 167816743U, 2097651377U, 4027552580U, 2265490386U, 503444072U, 1762050814U, 4150417245U, 2154129355U,
						426522225U, 1852507879U, 4275313526U, 2312317920U, 282753626U, 1742555852U, 4189708143U, 2394877945U, 397917763U, 1622183637U,
						3604390888U, 2714866558U, 953729732U, 1340076626U, 3518719985U, 2797360999U, 1068828381U, 1219638859U, 3624741850U, 2936675148U,
						906185462U, 1090812512U, 3747672003U, 2825379669U, 829329135U, 1181335161U, 3412177804U, 3160834842U, 628085408U, 1382605366U,
						3423369109U, 3138078467U, 570562233U, 1426400815U, 3317316542U, 2998733608U, 733239954U, 1555261956U, 3268935591U, 3050360625U,
						752459403U, 1541320221U, 2607071920U, 3965973030U, 1969922972U, 40735498U, 2617837225U, 3943577151U, 1913087877U, 83908371U,
						2512341634U, 3803740692U, 2075208622U, 213261112U, 2463272603U, 3855990285U, 2094854071U, 198958881U, 2262029012U, 4057260610U,
						1759359992U, 534414190U, 2176718541U, 4139329115U, 1873836001U, 414664567U, 2282248934U, 4279200368U, 1711684554U, 285281116U,
						2405801727U, 4167216745U, 1634467795U, 376229701U, 2685067896U, 3608007406U, 1308918612U, 956543938U, 2808555105U, 3495958263U,
						1231636301U, 1047427035U, 2932959818U, 3654703836U, 1088359270U, 936918000U, 2847714899U, 3736837829U, 1202900863U, 817233897U,
						3183342108U, 3401237130U, 1404277552U, 615818150U, 3134207493U, 3453421203U, 1423857449U, 601450431U, 3009837614U, 3294710456U,
						1567103746U, 711928724U, 3020668471U, 3272380065U, 1510334235U, 755167117U
					};
					uint maxValue = uint.MaxValue;
					uint num2 = maxValue;
					int num3 = 0;
					int num4 = buffer.Length;
					while (--num4 >= 0)
					{
						num2 = array[(int)((UIntPtr)((num2 ^ (uint)buffer[num3++]) & 255U))] ^ (num2 >> 8);
					}
					num2 ^= maxValue;
					zipStream.WriteInt(67324752);
					zipStream.WriteShort(20);
					zipStream.WriteShort(0);
					zipStream.WriteShort(8);
					zipStream.WriteInt((int)num);
					zipStream.WriteInt((int)num2);
					long position = zipStream.Position;
					zipStream.WriteInt(0);
					zipStream.WriteInt(buffer.Length);
					byte[] bytes = Encoding.UTF8.GetBytes("{data}");
					zipStream.WriteShort(bytes.Length);
					zipStream.WriteShort(0);
					zipStream.Write(bytes, 0, bytes.Length);
					deflater.SetInput(buffer);
					while (!deflater.IsNeedingInput)
					{
						byte[] array2 = new byte[512];
						int num5 = deflater.Deflate(array2);
						if (num5 <= 0)
						{
							break;
						}
						zipStream.Write(array2, 0, num5);
					}
					deflater.Finish();
					while (!deflater.IsFinished)
					{
						byte[] array3 = new byte[512];
						int num6 = deflater.Deflate(array3);
						if (num6 <= 0)
						{
							break;
						}
						zipStream.Write(array3, 0, num6);
					}
					long totalOut = deflater.TotalOut;
					zipStream.WriteInt(33639248);
					zipStream.WriteShort(20);
					zipStream.WriteShort(20);
					zipStream.WriteShort(0);
					zipStream.WriteShort(8);
					zipStream.WriteInt((int)num);
					zipStream.WriteInt((int)num2);
					zipStream.WriteInt((int)totalOut);
					zipStream.WriteInt(buffer.Length);
					zipStream.WriteShort(bytes.Length);
					zipStream.WriteShort(0);
					zipStream.WriteShort(0);
					zipStream.WriteShort(0);
					zipStream.WriteShort(0);
					zipStream.WriteInt(0);
					zipStream.WriteInt(0);
					zipStream.Write(bytes, 0, bytes.Length);
					zipStream.WriteInt(101010256);
					zipStream.WriteShort(0);
					zipStream.WriteShort(0);
					zipStream.WriteShort(1);
					zipStream.WriteShort(1);
					zipStream.WriteInt(46 + bytes.Length);
					zipStream.WriteInt((int)((long)(30 + bytes.Length) + totalOut));
					zipStream.WriteShort(0);
					zipStream.Seek(position, SeekOrigin.Begin);
					zipStream.WriteInt((int)totalOut);
				}
				else if (version == 1)
				{
					zipStream.WriteInt(25000571);
					zipStream.WriteInt(buffer.Length);
					byte[] array4;
					for (int i = 0; i < buffer.Length; i += array4.Length)
					{
						array4 = new byte[Math.Min(2097151, buffer.Length - i)];
						Buffer.BlockCopy(buffer, i, array4, 0, array4.Length);
						long position2 = zipStream.Position;
						zipStream.WriteInt(0);
						zipStream.WriteInt(array4.Length);
						SimpleZip.Deflater deflater2 = new SimpleZip.Deflater();
						deflater2.SetInput(array4);
						while (!deflater2.IsNeedingInput)
						{
							byte[] array5 = new byte[512];
							int num7 = deflater2.Deflate(array5);
							if (num7 <= 0)
							{
								break;
							}
							zipStream.Write(array5, 0, num7);
						}
						deflater2.Finish();
						while (!deflater2.IsFinished)
						{
							byte[] array6 = new byte[512];
							int num8 = deflater2.Deflate(array6);
							if (num8 <= 0)
							{
								break;
							}
							zipStream.Write(array6, 0, num8);
						}
						long position3 = zipStream.Position;
						zipStream.Position = position2;
						zipStream.WriteInt((int)deflater2.TotalOut);
						zipStream.Position = position3;
					}
				}
				else
				{
					if (version == 2)
					{
						zipStream.WriteInt(41777787);
						byte[] array7 = SimpleZip.Zip(buffer, 1, null, null);
						using (DESCryptoIndirector descryptoIndirector = new DESCryptoIndirector())
						{
							using (ICryptoTransform descryptoTransform = descryptoIndirector.GetDESCryptoTransform(key, iv, false))
							{
								byte[] array8 = descryptoTransform.TransformFinalBlock(array7, 0, array7.Length);
								zipStream.Write(array8, 0, array8.Length);
							}
							goto IL_47D;
						}
					}
					if (version == 3)
					{
						zipStream.WriteInt(58555003);
						byte[] array9 = SimpleZip.Zip(buffer, 1, null, null);
						using (AESCryptoIndirector aescryptoIndirector = new AESCryptoIndirector())
						{
							using (ICryptoTransform aescryptoTransform = aescryptoIndirector.GetAESCryptoTransform(key, iv, false))
							{
								byte[] array10 = aescryptoTransform.TransformFinalBlock(array9, 0, array9.Length);
								zipStream.Write(array10, 0, array10.Length);
							}
						}
					}
				}
				IL_47D:
				zipStream.Flush();
				zipStream.Close();
				array11 = zipStream.ToArray();
			}
			catch (Exception ex)
			{
				SimpleZip.ExceptionMessage = "ERR 2003: " + ex.Message;
				throw;
			}
			return array11;
		}

		// Token: 0x040000B1 RID: 177
		public static string ExceptionMessage;

		// Token: 0x02000016 RID: 22
		internal sealed class Inflater
		{
			// Token: 0x06000138 RID: 312 RVA: 0x00011388 File Offset: 0x0000F588
			public Inflater(byte[] bytes)
			{
				this.input = new SimpleZip.StreamManipulator();
				this.outputWindow = new SimpleZip.OutputWindow();
				this.mode = 2;
				this.input.SetInput(bytes, 0, bytes.Length);
			}

			// Token: 0x06000139 RID: 313 RVA: 0x000113C0 File Offset: 0x0000F5C0
			private bool DecodeHuffman()
			{
				int i = this.outputWindow.GetFreeSpace();
				while (i >= 258)
				{
					int num;
					switch (this.mode)
					{
					case 7:
						while (((num = this.litlenTree.GetSymbol(this.input)) & -256) == 0)
						{
							this.outputWindow.Write(num);
							if (--i < 258)
							{
								return true;
							}
						}
						if (num >= 257)
						{
							this.repLength = SimpleZip.Inflater.CPLENS[num - 257];
							this.neededBits = SimpleZip.Inflater.CPLEXT[num - 257];
							goto IL_B7;
						}
						if (num < 0)
						{
							return false;
						}
						this.distTree = null;
						this.litlenTree = null;
						this.mode = 2;
						return true;
					case 8:
						goto IL_B7;
					case 9:
						goto IL_106;
					case 10:
						break;
					default:
						continue;
					}
					IL_138:
					if (this.neededBits > 0)
					{
						this.mode = 10;
						int num2 = this.input.PeekBits(this.neededBits);
						if (num2 < 0)
						{
							return false;
						}
						this.input.DropBits(this.neededBits);
						this.repDist += num2;
					}
					this.outputWindow.Repeat(this.repLength, this.repDist);
					i -= this.repLength;
					this.mode = 7;
					continue;
					IL_106:
					num = this.distTree.GetSymbol(this.input);
					if (num < 0)
					{
						return false;
					}
					this.repDist = SimpleZip.Inflater.CPDIST[num];
					this.neededBits = SimpleZip.Inflater.CPDEXT[num];
					goto IL_138;
					IL_B7:
					if (this.neededBits > 0)
					{
						this.mode = 8;
						int num3 = this.input.PeekBits(this.neededBits);
						if (num3 < 0)
						{
							return false;
						}
						this.input.DropBits(this.neededBits);
						this.repLength += num3;
					}
					this.mode = 9;
					goto IL_106;
				}
				return true;
			}

			// Token: 0x0600013A RID: 314 RVA: 0x00011580 File Offset: 0x0000F780
			private bool Decode()
			{
				switch (this.mode)
				{
				case 2:
				{
					if (this.isLastBlock)
					{
						this.mode = 12;
						return false;
					}
					int num = this.input.PeekBits(3);
					if (num < 0)
					{
						return false;
					}
					this.input.DropBits(3);
					if ((num & 1) != 0)
					{
						this.isLastBlock = true;
					}
					switch (num >> 1)
					{
					case 0:
						this.input.SkipToByteBoundary();
						this.mode = 3;
						break;
					case 1:
						this.litlenTree = SimpleZip.InflaterHuffmanTree.defLitLenTree;
						this.distTree = SimpleZip.InflaterHuffmanTree.defDistTree;
						this.mode = 7;
						break;
					case 2:
						this.dynHeader = new SimpleZip.InflaterDynHeader();
						this.mode = 6;
						break;
					}
					return true;
				}
				case 3:
					if ((this.uncomprLen = this.input.PeekBits(16)) < 0)
					{
						return false;
					}
					this.input.DropBits(16);
					this.mode = 4;
					break;
				case 4:
					break;
				case 5:
					goto IL_133;
				case 6:
					if (!this.dynHeader.Decode(this.input))
					{
						return false;
					}
					this.litlenTree = this.dynHeader.BuildLitLenTree();
					this.distTree = this.dynHeader.BuildDistTree();
					this.mode = 7;
					goto IL_1B7;
				case 7:
				case 8:
				case 9:
				case 10:
					goto IL_1B7;
				case 11:
					return false;
				case 12:
					return false;
				default:
					return false;
				}
				int num2 = this.input.PeekBits(16);
				if (num2 < 0)
				{
					return false;
				}
				this.input.DropBits(16);
				this.mode = 5;
				IL_133:
				int num3 = this.outputWindow.CopyStored(this.input, this.uncomprLen);
				this.uncomprLen -= num3;
				if (this.uncomprLen == 0)
				{
					this.mode = 2;
					return true;
				}
				return !this.input.IsNeedingInput;
				IL_1B7:
				return this.DecodeHuffman();
			}

			// Token: 0x0600013B RID: 315 RVA: 0x00011750 File Offset: 0x0000F950
			public int Inflate(byte[] buf, int offset, int len)
			{
				int num = 0;
				for (;;)
				{
					if (this.mode != 11)
					{
						int num2 = this.outputWindow.CopyOutput(buf, offset, len);
						offset += num2;
						num += num2;
						len -= num2;
						if (len == 0)
						{
							break;
						}
					}
					if (!this.Decode() && (this.outputWindow.GetAvailable() <= 0 || this.mode == 11))
					{
						return num;
					}
				}
				return num;
			}

			// Token: 0x040000B2 RID: 178
			private const int DECODE_HEADER = 0;

			// Token: 0x040000B3 RID: 179
			private const int DECODE_DICT = 1;

			// Token: 0x040000B4 RID: 180
			private const int DECODE_BLOCKS = 2;

			// Token: 0x040000B5 RID: 181
			private const int DECODE_STORED_LEN1 = 3;

			// Token: 0x040000B6 RID: 182
			private const int DECODE_STORED_LEN2 = 4;

			// Token: 0x040000B7 RID: 183
			private const int DECODE_STORED = 5;

			// Token: 0x040000B8 RID: 184
			private const int DECODE_DYN_HEADER = 6;

			// Token: 0x040000B9 RID: 185
			private const int DECODE_HUFFMAN = 7;

			// Token: 0x040000BA RID: 186
			private const int DECODE_HUFFMAN_LENBITS = 8;

			// Token: 0x040000BB RID: 187
			private const int DECODE_HUFFMAN_DIST = 9;

			// Token: 0x040000BC RID: 188
			private const int DECODE_HUFFMAN_DISTBITS = 10;

			// Token: 0x040000BD RID: 189
			private const int DECODE_CHKSUM = 11;

			// Token: 0x040000BE RID: 190
			private const int FINISHED = 12;

			// Token: 0x040000BF RID: 191
			private static readonly int[] CPLENS = new int[]
			{
				3, 4, 5, 6, 7, 8, 9, 10, 11, 13,
				15, 17, 19, 23, 27, 31, 35, 43, 51, 59,
				67, 83, 99, 115, 131, 163, 195, 227, 258
			};

			// Token: 0x040000C0 RID: 192
			private static readonly int[] CPLEXT = new int[]
			{
				0, 0, 0, 0, 0, 0, 0, 0, 1, 1,
				1, 1, 2, 2, 2, 2, 3, 3, 3, 3,
				4, 4, 4, 4, 5, 5, 5, 5, 0
			};

			// Token: 0x040000C1 RID: 193
			private static readonly int[] CPDIST = new int[]
			{
				1, 2, 3, 4, 5, 7, 9, 13, 17, 25,
				33, 49, 65, 97, 129, 193, 257, 385, 513, 769,
				1025, 1537, 2049, 3073, 4097, 6145, 8193, 12289, 16385, 24577
			};

			// Token: 0x040000C2 RID: 194
			private static readonly int[] CPDEXT = new int[]
			{
				0, 0, 0, 0, 1, 1, 2, 2, 3, 3,
				4, 4, 5, 5, 6, 6, 7, 7, 8, 8,
				9, 9, 10, 10, 11, 11, 12, 12, 13, 13
			};

			// Token: 0x040000C3 RID: 195
			private int mode;

			// Token: 0x040000C4 RID: 196
			private int neededBits;

			// Token: 0x040000C5 RID: 197
			private int repLength;

			// Token: 0x040000C6 RID: 198
			private int repDist;

			// Token: 0x040000C7 RID: 199
			private int uncomprLen;

			// Token: 0x040000C8 RID: 200
			private bool isLastBlock;

			// Token: 0x040000C9 RID: 201
			private SimpleZip.StreamManipulator input;

			// Token: 0x040000CA RID: 202
			private SimpleZip.OutputWindow outputWindow;

			// Token: 0x040000CB RID: 203
			private SimpleZip.InflaterDynHeader dynHeader;

			// Token: 0x040000CC RID: 204
			private SimpleZip.InflaterHuffmanTree litlenTree;

			// Token: 0x040000CD RID: 205
			private SimpleZip.InflaterHuffmanTree distTree;
		}

		// Token: 0x02000017 RID: 23
		internal sealed class StreamManipulator
		{
			// Token: 0x0600013D RID: 317 RVA: 0x00011818 File Offset: 0x0000FA18
			public int PeekBits(int n)
			{
				if (this.bits_in_buffer < n)
				{
					if (this.window_start == this.window_end)
					{
						return -1;
					}
					this.buffer |= (uint)((uint)((int)(this.window[this.window_start++] & byte.MaxValue) | ((int)(this.window[this.window_start++] & byte.MaxValue) << 8)) << this.bits_in_buffer);
					this.bits_in_buffer += 16;
				}
				return (int)((ulong)this.buffer & (ulong)((long)((1 << n) - 1)));
			}

			// Token: 0x0600013E RID: 318 RVA: 0x000118B8 File Offset: 0x0000FAB8
			public void DropBits(int n)
			{
				this.buffer >>= n;
				this.bits_in_buffer -= n;
			}

			// Token: 0x17000076 RID: 118
			// (get) Token: 0x0600013F RID: 319 RVA: 0x000118DC File Offset: 0x0000FADC
			public int AvailableBits
			{
				get
				{
					return this.bits_in_buffer;
				}
			}

			// Token: 0x17000077 RID: 119
			// (get) Token: 0x06000140 RID: 320 RVA: 0x000118E4 File Offset: 0x0000FAE4
			public int AvailableBytes
			{
				get
				{
					return this.window_end - this.window_start + (this.bits_in_buffer >> 3);
				}
			}

			// Token: 0x06000141 RID: 321 RVA: 0x000118FC File Offset: 0x0000FAFC
			public void SkipToByteBoundary()
			{
				this.buffer >>= this.bits_in_buffer & 7;
				this.bits_in_buffer &= -8;
			}

			// Token: 0x17000078 RID: 120
			// (get) Token: 0x06000142 RID: 322 RVA: 0x00011928 File Offset: 0x0000FB28
			public bool IsNeedingInput
			{
				get
				{
					return this.window_start == this.window_end;
				}
			}

			// Token: 0x06000143 RID: 323 RVA: 0x00011938 File Offset: 0x0000FB38
			public int CopyBytes(byte[] output, int offset, int length)
			{
				int num = 0;
				while (this.bits_in_buffer > 0 && length > 0)
				{
					output[offset++] = (byte)this.buffer;
					this.buffer >>= 8;
					this.bits_in_buffer -= 8;
					length--;
					num++;
				}
				if (length == 0)
				{
					return num;
				}
				int num2 = this.window_end - this.window_start;
				if (length > num2)
				{
					length = num2;
				}
				Array.Copy(this.window, this.window_start, output, offset, length);
				this.window_start += length;
				if (((this.window_start - this.window_end) & 1) != 0)
				{
					this.buffer = (uint)(this.window[this.window_start++] & byte.MaxValue);
					this.bits_in_buffer = 8;
				}
				return num + length;
			}

			// Token: 0x06000145 RID: 325 RVA: 0x00011A2C File Offset: 0x0000FC2C
			public void Reset()
			{
				this.buffer = (uint)(this.window_start = (this.window_end = (this.bits_in_buffer = 0)));
			}

			// Token: 0x06000146 RID: 326 RVA: 0x00011A5C File Offset: 0x0000FC5C
			public void SetInput(byte[] buf, int off, int len)
			{
				if (this.window_start < this.window_end)
				{
					throw new InvalidOperationException();
				}
				int num = off + len;
				if (0 > off || off > num || num > buf.Length)
				{
					throw new ArgumentOutOfRangeException();
				}
				if ((len & 1) != 0)
				{
					this.buffer |= (uint)((uint)(buf[off++] & byte.MaxValue) << this.bits_in_buffer);
					this.bits_in_buffer += 8;
				}
				this.window = buf;
				this.window_start = off;
				this.window_end = num;
			}

			// Token: 0x040000CE RID: 206
			private byte[] window;

			// Token: 0x040000CF RID: 207
			private int window_start = 0;

			// Token: 0x040000D0 RID: 208
			private int window_end = 0;

			// Token: 0x040000D1 RID: 209
			private uint buffer = 0U;

			// Token: 0x040000D2 RID: 210
			private int bits_in_buffer = 0;
		}

		// Token: 0x02000018 RID: 24
		internal sealed class OutputWindow
		{
			// Token: 0x06000147 RID: 327 RVA: 0x00011AE4 File Offset: 0x0000FCE4
			public void Write(int abyte)
			{
				if (this.windowFilled++ == 32768)
				{
					throw new InvalidOperationException();
				}
				this.window[this.windowEnd++] = (byte)abyte;
				this.windowEnd &= 32767;
			}

			// Token: 0x06000148 RID: 328 RVA: 0x00011B3C File Offset: 0x0000FD3C
			private void SlowRepeat(int repStart, int len, int dist)
			{
				while (len-- > 0)
				{
					this.window[this.windowEnd++] = this.window[repStart++];
					this.windowEnd &= 32767;
					repStart &= 32767;
				}
			}

			// Token: 0x06000149 RID: 329 RVA: 0x00011B94 File Offset: 0x0000FD94
			public void Repeat(int len, int dist)
			{
				if ((this.windowFilled += len) > 32768)
				{
					throw new InvalidOperationException();
				}
				int num = (this.windowEnd - dist) & 32767;
				int num2 = 32768 - len;
				if (num > num2 || this.windowEnd >= num2)
				{
					this.SlowRepeat(num, len, dist);
					return;
				}
				if (len <= dist)
				{
					Array.Copy(this.window, num, this.window, this.windowEnd, len);
					this.windowEnd += len;
					return;
				}
				while (len-- > 0)
				{
					this.window[this.windowEnd++] = this.window[num++];
				}
			}

			// Token: 0x0600014A RID: 330 RVA: 0x00011C48 File Offset: 0x0000FE48
			public int CopyStored(SimpleZip.StreamManipulator input, int len)
			{
				len = Math.Min(Math.Min(len, 32768 - this.windowFilled), input.AvailableBytes);
				int num = 32768 - this.windowEnd;
				int num2;
				if (len > num)
				{
					num2 = input.CopyBytes(this.window, this.windowEnd, num);
					if (num2 == num)
					{
						num2 += input.CopyBytes(this.window, 0, len - num);
					}
				}
				else
				{
					num2 = input.CopyBytes(this.window, this.windowEnd, len);
				}
				this.windowEnd = (this.windowEnd + num2) & 32767;
				this.windowFilled += num2;
				return num2;
			}

			// Token: 0x0600014B RID: 331 RVA: 0x00011CEC File Offset: 0x0000FEEC
			public void CopyDict(byte[] dict, int offset, int len)
			{
				if (this.windowFilled > 0)
				{
					throw new InvalidOperationException();
				}
				if (len > 32768)
				{
					offset += len - 32768;
					len = 32768;
				}
				Array.Copy(dict, offset, this.window, 0, len);
				this.windowEnd = len & 32767;
			}

			// Token: 0x0600014C RID: 332 RVA: 0x00011D40 File Offset: 0x0000FF40
			public int GetFreeSpace()
			{
				return 32768 - this.windowFilled;
			}

			// Token: 0x0600014D RID: 333 RVA: 0x00011D50 File Offset: 0x0000FF50
			public int GetAvailable()
			{
				return this.windowFilled;
			}

			// Token: 0x0600014E RID: 334 RVA: 0x00011D58 File Offset: 0x0000FF58
			public int CopyOutput(byte[] output, int offset, int len)
			{
				int num = this.windowEnd;
				if (len > this.windowFilled)
				{
					len = this.windowFilled;
				}
				else
				{
					num = (this.windowEnd - this.windowFilled + len) & 32767;
				}
				int num2 = len;
				int num3 = len - num;
				if (num3 > 0)
				{
					Array.Copy(this.window, 32768 - num3, output, offset, num3);
					offset += num3;
					len = num;
				}
				Array.Copy(this.window, num - len, output, offset, len);
				this.windowFilled -= num2;
				if (this.windowFilled < 0)
				{
					throw new InvalidOperationException();
				}
				return num2;
			}

			// Token: 0x0600014F RID: 335 RVA: 0x00011DEC File Offset: 0x0000FFEC
			public void Reset()
			{
				this.windowFilled = (this.windowEnd = 0);
			}

			// Token: 0x040000D3 RID: 211
			private const int WINDOW_SIZE = 32768;

			// Token: 0x040000D4 RID: 212
			private const int WINDOW_MASK = 32767;

			// Token: 0x040000D5 RID: 213
			private byte[] window = new byte[32768];

			// Token: 0x040000D6 RID: 214
			private int windowEnd = 0;

			// Token: 0x040000D7 RID: 215
			private int windowFilled = 0;
		}

		// Token: 0x02000019 RID: 25
		internal sealed class InflaterHuffmanTree
		{
			// Token: 0x06000151 RID: 337 RVA: 0x00011E34 File Offset: 0x00010034
			static InflaterHuffmanTree()
			{
				byte[] array = new byte[288];
				int i = 0;
				while (i < 144)
				{
					array[i++] = 8;
				}
				while (i < 256)
				{
					array[i++] = 9;
				}
				while (i < 280)
				{
					array[i++] = 7;
				}
				while (i < 288)
				{
					array[i++] = 8;
				}
				SimpleZip.InflaterHuffmanTree.defLitLenTree = new SimpleZip.InflaterHuffmanTree(array);
				array = new byte[32];
				i = 0;
				while (i < 32)
				{
					array[i++] = 5;
				}
				SimpleZip.InflaterHuffmanTree.defDistTree = new SimpleZip.InflaterHuffmanTree(array);
			}

			// Token: 0x06000152 RID: 338 RVA: 0x00011EC8 File Offset: 0x000100C8
			public InflaterHuffmanTree(byte[] codeLengths)
			{
				this.BuildTree(codeLengths);
			}

			// Token: 0x06000153 RID: 339 RVA: 0x00011ED8 File Offset: 0x000100D8
			private void BuildTree(byte[] codeLengths)
			{
				int[] array = new int[16];
				int[] array2 = new int[16];
				foreach (int num in codeLengths)
				{
					if (num > 0)
					{
						int[] array3;
						IntPtr intPtr;
						(array3 = array)[(int)(intPtr = (IntPtr)num)] = array3[(int)intPtr] + 1;
					}
				}
				int num2 = 0;
				int num3 = 512;
				for (int j = 1; j <= 15; j++)
				{
					array2[j] = num2;
					num2 += array[j] << 16 - j;
					if (j >= 10)
					{
						int num4 = array2[j] & 130944;
						int num5 = num2 & 130944;
						num3 += num5 - num4 >> 16 - j;
					}
				}
				this.tree = new short[num3];
				int num6 = 512;
				for (int k = 15; k >= 10; k--)
				{
					int num7 = num2 & 130944;
					num2 -= array[k] << 16 - k;
					int num8 = num2 & 130944;
					for (int l = num8; l < num7; l += 128)
					{
						this.tree[(int)SimpleZip.DeflaterHuffman.BitReverse(l)] = (short)((-num6 << 4) | k);
						num6 += 1 << k - 9;
					}
				}
				for (int m = 0; m < codeLengths.Length; m++)
				{
					int num9 = (int)codeLengths[m];
					if (num9 != 0)
					{
						num2 = array2[num9];
						int num10 = (int)SimpleZip.DeflaterHuffman.BitReverse(num2);
						if (num9 <= 9)
						{
							do
							{
								this.tree[num10] = (short)((m << 4) | num9);
								num10 += 1 << num9;
							}
							while (num10 < 512);
						}
						else
						{
							int num11 = (int)this.tree[num10 & 511];
							int num12 = 1 << (num11 & 15);
							num11 = -(num11 >> 4);
							do
							{
								this.tree[num11 | (num10 >> 9)] = (short)((m << 4) | num9);
								num10 += 1 << num9;
							}
							while (num10 < num12);
						}
						array2[num9] = num2 + (1 << 16 - num9);
					}
				}
			}

			// Token: 0x06000154 RID: 340 RVA: 0x000120C8 File Offset: 0x000102C8
			public int GetSymbol(SimpleZip.StreamManipulator input)
			{
				int num;
				if ((num = input.PeekBits(9)) >= 0)
				{
					int num2;
					if ((num2 = (int)this.tree[num]) >= 0)
					{
						input.DropBits(num2 & 15);
						return num2 >> 4;
					}
					int num3 = -(num2 >> 4);
					int num4 = num2 & 15;
					if ((num = input.PeekBits(num4)) >= 0)
					{
						num2 = (int)this.tree[num3 | (num >> 9)];
						input.DropBits(num2 & 15);
						return num2 >> 4;
					}
					int availableBits = input.AvailableBits;
					num = input.PeekBits(availableBits);
					num2 = (int)this.tree[num3 | (num >> 9)];
					if ((num2 & 15) <= availableBits)
					{
						input.DropBits(num2 & 15);
						return num2 >> 4;
					}
					return -1;
				}
				else
				{
					int availableBits2 = input.AvailableBits;
					num = input.PeekBits(availableBits2);
					int num2 = (int)this.tree[num];
					if (num2 >= 0 && (num2 & 15) <= availableBits2)
					{
						input.DropBits(num2 & 15);
						return num2 >> 4;
					}
					return -1;
				}
			}

			// Token: 0x040000D8 RID: 216
			private const int MAX_BITLEN = 15;

			// Token: 0x040000D9 RID: 217
			private short[] tree;

			// Token: 0x040000DA RID: 218
			public static readonly SimpleZip.InflaterHuffmanTree defLitLenTree;

			// Token: 0x040000DB RID: 219
			public static readonly SimpleZip.InflaterHuffmanTree defDistTree;
		}

		// Token: 0x0200001A RID: 26
		internal sealed class InflaterDynHeader
		{
			// Token: 0x06000156 RID: 342 RVA: 0x000121A8 File Offset: 0x000103A8
			public bool Decode(SimpleZip.StreamManipulator input)
			{
				for (;;)
				{
					switch (this.mode)
					{
					case 0:
						this.lnum = input.PeekBits(5);
						if (this.lnum < 0)
						{
							return false;
						}
						this.lnum += 257;
						input.DropBits(5);
						this.mode = 1;
						goto IL_61;
					case 1:
						goto IL_61;
					case 2:
						goto IL_B9;
					case 3:
						break;
					case 4:
						goto IL_1A8;
					case 5:
						goto IL_1DE;
					default:
						continue;
					}
					IL_13B:
					while (this.ptr < this.blnum)
					{
						int num = input.PeekBits(3);
						if (num < 0)
						{
							return false;
						}
						input.DropBits(3);
						this.blLens[SimpleZip.InflaterDynHeader.BL_ORDER[this.ptr]] = (byte)num;
						this.ptr++;
					}
					this.blTree = new SimpleZip.InflaterHuffmanTree(this.blLens);
					this.blLens = null;
					this.ptr = 0;
					this.mode = 4;
					IL_1A8:
					int symbol;
					while (((symbol = this.blTree.GetSymbol(input)) & -16) == 0)
					{
						this.litdistLens[this.ptr++] = (this.lastLen = (byte)symbol);
						if (this.ptr == this.num)
						{
							return true;
						}
					}
					if (symbol < 0)
					{
						return false;
					}
					if (symbol >= 17)
					{
						this.lastLen = 0;
					}
					this.repSymbol = symbol - 16;
					this.mode = 5;
					IL_1DE:
					int num2 = SimpleZip.InflaterDynHeader.repBits[this.repSymbol];
					int num3 = input.PeekBits(num2);
					if (num3 < 0)
					{
						return false;
					}
					input.DropBits(num2);
					num3 += SimpleZip.InflaterDynHeader.repMin[this.repSymbol];
					while (num3-- > 0)
					{
						this.litdistLens[this.ptr++] = this.lastLen;
					}
					if (this.ptr == this.num)
					{
						return true;
					}
					this.mode = 4;
					continue;
					IL_B9:
					this.blnum = input.PeekBits(4);
					if (this.blnum < 0)
					{
						return false;
					}
					this.blnum += 4;
					input.DropBits(4);
					this.blLens = new byte[19];
					this.ptr = 0;
					this.mode = 3;
					goto IL_13B;
					IL_61:
					this.dnum = input.PeekBits(5);
					if (this.dnum < 0)
					{
						return false;
					}
					this.dnum++;
					input.DropBits(5);
					this.num = this.lnum + this.dnum;
					this.litdistLens = new byte[this.num];
					this.mode = 2;
					goto IL_B9;
				}
				return false;
			}

			// Token: 0x06000157 RID: 343 RVA: 0x0001240C File Offset: 0x0001060C
			public SimpleZip.InflaterHuffmanTree BuildLitLenTree()
			{
				byte[] array = new byte[this.lnum];
				Array.Copy(this.litdistLens, 0, array, 0, this.lnum);
				return new SimpleZip.InflaterHuffmanTree(array);
			}

			// Token: 0x06000158 RID: 344 RVA: 0x00012440 File Offset: 0x00010640
			public SimpleZip.InflaterHuffmanTree BuildDistTree()
			{
				byte[] array = new byte[this.dnum];
				Array.Copy(this.litdistLens, this.lnum, array, 0, this.dnum);
				return new SimpleZip.InflaterHuffmanTree(array);
			}

			// Token: 0x040000DC RID: 220
			private const int LNUM = 0;

			// Token: 0x040000DD RID: 221
			private const int DNUM = 1;

			// Token: 0x040000DE RID: 222
			private const int BLNUM = 2;

			// Token: 0x040000DF RID: 223
			private const int BLLENS = 3;

			// Token: 0x040000E0 RID: 224
			private const int LENS = 4;

			// Token: 0x040000E1 RID: 225
			private const int REPS = 5;

			// Token: 0x040000E2 RID: 226
			private static readonly int[] repMin = new int[] { 3, 3, 11 };

			// Token: 0x040000E3 RID: 227
			private static readonly int[] repBits = new int[] { 2, 3, 7 };

			// Token: 0x040000E4 RID: 228
			private byte[] blLens;

			// Token: 0x040000E5 RID: 229
			private byte[] litdistLens;

			// Token: 0x040000E6 RID: 230
			private SimpleZip.InflaterHuffmanTree blTree;

			// Token: 0x040000E7 RID: 231
			private int mode;

			// Token: 0x040000E8 RID: 232
			private int lnum;

			// Token: 0x040000E9 RID: 233
			private int dnum;

			// Token: 0x040000EA RID: 234
			private int blnum;

			// Token: 0x040000EB RID: 235
			private int num;

			// Token: 0x040000EC RID: 236
			private int repSymbol;

			// Token: 0x040000ED RID: 237
			private byte lastLen;

			// Token: 0x040000EE RID: 238
			private int ptr;

			// Token: 0x040000EF RID: 239
			private static readonly int[] BL_ORDER = new int[]
			{
				16, 17, 18, 0, 8, 7, 9, 6, 10, 5,
				11, 4, 12, 3, 13, 2, 14, 1, 15
			};
		}

		// Token: 0x0200001B RID: 27
		internal sealed class Deflater
		{
			// Token: 0x0600015A RID: 346 RVA: 0x000124C8 File Offset: 0x000106C8
			public Deflater()
			{
				this.pending = new SimpleZip.DeflaterPending();
				this.engine = new SimpleZip.DeflaterEngine(this.pending);
			}

			// Token: 0x17000079 RID: 121
			// (get) Token: 0x0600015B RID: 347 RVA: 0x000124FC File Offset: 0x000106FC
			public long TotalOut
			{
				get
				{
					return this.totalOut;
				}
			}

			// Token: 0x0600015C RID: 348 RVA: 0x00012504 File Offset: 0x00010704
			public void Finish()
			{
				this.state |= 12;
			}

			// Token: 0x1700007A RID: 122
			// (get) Token: 0x0600015D RID: 349 RVA: 0x00012518 File Offset: 0x00010718
			public bool IsFinished
			{
				get
				{
					return this.state == 30 && this.pending.IsFlushed;
				}
			}

			// Token: 0x1700007B RID: 123
			// (get) Token: 0x0600015E RID: 350 RVA: 0x00012534 File Offset: 0x00010734
			public bool IsNeedingInput
			{
				get
				{
					return this.engine.NeedsInput();
				}
			}

			// Token: 0x0600015F RID: 351 RVA: 0x00012544 File Offset: 0x00010744
			public void SetInput(byte[] buffer)
			{
				this.engine.SetInput(buffer);
			}

			// Token: 0x06000160 RID: 352 RVA: 0x00012554 File Offset: 0x00010754
			public int Deflate(byte[] output)
			{
				int num = 0;
				int num2 = output.Length;
				int num3 = num2;
				for (;;)
				{
					int num4 = this.pending.Flush(output, num, num2);
					num += num4;
					this.totalOut += (long)num4;
					num2 -= num4;
					if (num2 == 0 || this.state == 30)
					{
						goto IL_E2;
					}
					if (!this.engine.Deflate((this.state & 4) != 0, (this.state & 8) != 0))
					{
						if (this.state == 16)
						{
							break;
						}
						if (this.state == 20)
						{
							for (int i = 8 + (-this.pending.BitCount & 7); i > 0; i -= 10)
							{
								this.pending.WriteBits(2, 10);
							}
							this.state = 16;
						}
						else if (this.state == 28)
						{
							this.pending.AlignToByte();
							this.state = 30;
						}
					}
				}
				return num3 - num2;
				IL_E2:
				return num3 - num2;
			}

			// Token: 0x040000F0 RID: 240
			private const int IS_FLUSHING = 4;

			// Token: 0x040000F1 RID: 241
			private const int IS_FINISHING = 8;

			// Token: 0x040000F2 RID: 242
			private const int BUSY_STATE = 16;

			// Token: 0x040000F3 RID: 243
			private const int FLUSHING_STATE = 20;

			// Token: 0x040000F4 RID: 244
			private const int FINISHING_STATE = 28;

			// Token: 0x040000F5 RID: 245
			private const int FINISHED_STATE = 30;

			// Token: 0x040000F6 RID: 246
			private int state = 16;

			// Token: 0x040000F7 RID: 247
			private long totalOut = 0L;

			// Token: 0x040000F8 RID: 248
			private SimpleZip.DeflaterPending pending;

			// Token: 0x040000F9 RID: 249
			private SimpleZip.DeflaterEngine engine;
		}

		// Token: 0x0200001C RID: 28
		internal sealed class DeflaterHuffman
		{
			// Token: 0x06000161 RID: 353 RVA: 0x00012648 File Offset: 0x00010848
			public static short BitReverse(int toReverse)
			{
				return (short)(((int)SimpleZip.DeflaterHuffman.bit4Reverse[toReverse & 15] << 12) | ((int)SimpleZip.DeflaterHuffman.bit4Reverse[(toReverse >> 4) & 15] << 8) | ((int)SimpleZip.DeflaterHuffman.bit4Reverse[(toReverse >> 8) & 15] << 4) | (int)SimpleZip.DeflaterHuffman.bit4Reverse[toReverse >> 12]);
			}

			// Token: 0x06000162 RID: 354 RVA: 0x00012684 File Offset: 0x00010884
			static DeflaterHuffman()
			{
				int i = 0;
				while (i < 144)
				{
					SimpleZip.DeflaterHuffman.staticLCodes[i] = SimpleZip.DeflaterHuffman.BitReverse(48 + i << 8);
					SimpleZip.DeflaterHuffman.staticLLength[i++] = 8;
				}
				while (i < 256)
				{
					SimpleZip.DeflaterHuffman.staticLCodes[i] = SimpleZip.DeflaterHuffman.BitReverse(256 + i << 7);
					SimpleZip.DeflaterHuffman.staticLLength[i++] = 9;
				}
				while (i < 280)
				{
					SimpleZip.DeflaterHuffman.staticLCodes[i] = SimpleZip.DeflaterHuffman.BitReverse(-256 + i << 9);
					SimpleZip.DeflaterHuffman.staticLLength[i++] = 7;
				}
				while (i < 286)
				{
					SimpleZip.DeflaterHuffman.staticLCodes[i] = SimpleZip.DeflaterHuffman.BitReverse(-88 + i << 8);
					SimpleZip.DeflaterHuffman.staticLLength[i++] = 8;
				}
				SimpleZip.DeflaterHuffman.staticDCodes = new short[30];
				SimpleZip.DeflaterHuffman.staticDLength = new byte[30];
				for (i = 0; i < 30; i++)
				{
					SimpleZip.DeflaterHuffman.staticDCodes[i] = SimpleZip.DeflaterHuffman.BitReverse(i << 11);
					SimpleZip.DeflaterHuffman.staticDLength[i] = 5;
				}
			}

			// Token: 0x06000163 RID: 355 RVA: 0x000127C4 File Offset: 0x000109C4
			public DeflaterHuffman(SimpleZip.DeflaterPending pending)
			{
				this.pending = pending;
				this.literalTree = new SimpleZip.DeflaterHuffman.Tree(this, 286, 257, 15);
				this.distTree = new SimpleZip.DeflaterHuffman.Tree(this, 30, 1, 15);
				this.blTree = new SimpleZip.DeflaterHuffman.Tree(this, 19, 4, 7);
				this.d_buf = new short[16384];
				this.l_buf = new byte[16384];
			}

			// Token: 0x06000164 RID: 356 RVA: 0x00012838 File Offset: 0x00010A38
			public void Init()
			{
				this.last_lit = 0;
				this.extra_bits = 0;
			}

			// Token: 0x06000165 RID: 357 RVA: 0x00012848 File Offset: 0x00010A48
			private int Lcode(int len)
			{
				if (len == 255)
				{
					return 285;
				}
				int num = 257;
				while (len >= 8)
				{
					num += 4;
					len >>= 1;
				}
				return num + len;
			}

			// Token: 0x06000166 RID: 358 RVA: 0x0001287C File Offset: 0x00010A7C
			private int Dcode(int distance)
			{
				int num = 0;
				while (distance >= 4)
				{
					num += 2;
					distance >>= 1;
				}
				return num + distance;
			}

			// Token: 0x06000167 RID: 359 RVA: 0x000128A0 File Offset: 0x00010AA0
			public void SendAllTrees(int blTreeCodes)
			{
				this.blTree.BuildCodes();
				this.literalTree.BuildCodes();
				this.distTree.BuildCodes();
				this.pending.WriteBits(this.literalTree.numCodes - 257, 5);
				this.pending.WriteBits(this.distTree.numCodes - 1, 5);
				this.pending.WriteBits(blTreeCodes - 4, 4);
				for (int i = 0; i < blTreeCodes; i++)
				{
					this.pending.WriteBits((int)this.blTree.length[SimpleZip.DeflaterHuffman.BL_ORDER[i]], 3);
				}
				this.literalTree.WriteTree(this.blTree);
				this.distTree.WriteTree(this.blTree);
			}

			// Token: 0x06000168 RID: 360 RVA: 0x00012960 File Offset: 0x00010B60
			public void CompressBlock()
			{
				for (int i = 0; i < this.last_lit; i++)
				{
					int num = (int)(this.l_buf[i] & byte.MaxValue);
					int num2 = (int)this.d_buf[i];
					if (num2-- != 0)
					{
						int num3 = this.Lcode(num);
						this.literalTree.WriteSymbol(num3);
						int num4 = (num3 - 261) / 4;
						if (num4 > 0 && num4 <= 5)
						{
							this.pending.WriteBits(num & ((1 << num4) - 1), num4);
						}
						int num5 = this.Dcode(num2);
						this.distTree.WriteSymbol(num5);
						num4 = num5 / 2 - 1;
						if (num4 > 0)
						{
							this.pending.WriteBits(num2 & ((1 << num4) - 1), num4);
						}
					}
					else
					{
						this.literalTree.WriteSymbol(num);
					}
				}
				this.literalTree.WriteSymbol(256);
			}

			// Token: 0x06000169 RID: 361 RVA: 0x00012A40 File Offset: 0x00010C40
			public void FlushStoredBlock(byte[] stored, int storedOffset, int storedLength, bool lastBlock)
			{
				this.pending.WriteBits(lastBlock ? 1 : 0, 3);
				this.pending.AlignToByte();
				this.pending.WriteShort(storedLength);
				this.pending.WriteShort(~storedLength);
				this.pending.WriteBlock(stored, storedOffset, storedLength);
				this.Init();
			}

			// Token: 0x0600016A RID: 362 RVA: 0x00012A9C File Offset: 0x00010C9C
			public void FlushBlock(byte[] stored, int storedOffset, int storedLength, bool lastBlock)
			{
				short[] freqs;
				(freqs = this.literalTree.freqs)[256] = freqs[256] + 1;
				this.literalTree.BuildTree();
				this.distTree.BuildTree();
				this.literalTree.CalcBLFreq(this.blTree);
				this.distTree.CalcBLFreq(this.blTree);
				this.blTree.BuildTree();
				int num = 4;
				for (int i = 18; i > num; i--)
				{
					if (this.blTree.length[SimpleZip.DeflaterHuffman.BL_ORDER[i]] > 0)
					{
						num = i + 1;
					}
				}
				int num2 = 14 + num * 3 + this.blTree.GetEncodedLength() + this.literalTree.GetEncodedLength() + this.distTree.GetEncodedLength() + this.extra_bits;
				int num3 = this.extra_bits;
				for (int j = 0; j < 286; j++)
				{
					num3 += (int)(this.literalTree.freqs[j] * (short)SimpleZip.DeflaterHuffman.staticLLength[j]);
				}
				for (int k = 0; k < 30; k++)
				{
					num3 += (int)(this.distTree.freqs[k] * (short)SimpleZip.DeflaterHuffman.staticDLength[k]);
				}
				if (num2 >= num3)
				{
					num2 = num3;
				}
				if (storedOffset >= 0 && storedLength + 4 < num2 >> 3)
				{
					this.FlushStoredBlock(stored, storedOffset, storedLength, lastBlock);
					return;
				}
				if (num2 == num3)
				{
					this.pending.WriteBits(2 + (lastBlock ? 1 : 0), 3);
					this.literalTree.SetStaticCodes(SimpleZip.DeflaterHuffman.staticLCodes, SimpleZip.DeflaterHuffman.staticLLength);
					this.distTree.SetStaticCodes(SimpleZip.DeflaterHuffman.staticDCodes, SimpleZip.DeflaterHuffman.staticDLength);
					this.CompressBlock();
					this.Init();
					return;
				}
				this.pending.WriteBits(4 + (lastBlock ? 1 : 0), 3);
				this.SendAllTrees(num);
				this.CompressBlock();
				this.Init();
			}

			// Token: 0x0600016B RID: 363 RVA: 0x00012C60 File Offset: 0x00010E60
			public bool IsFull()
			{
				return this.last_lit >= 16384;
			}

			// Token: 0x0600016C RID: 364 RVA: 0x00012C74 File Offset: 0x00010E74
			public bool TallyLit(int lit)
			{
				this.d_buf[this.last_lit] = 0;
				this.l_buf[this.last_lit++] = (byte)lit;
				short[] freqs;
				(freqs = this.literalTree.freqs)[lit] = freqs[lit] + 1;
				return this.IsFull();
			}

			// Token: 0x0600016D RID: 365 RVA: 0x00012CC8 File Offset: 0x00010EC8
			public bool TallyDist(int dist, int len)
			{
				this.d_buf[this.last_lit] = (short)dist;
				this.l_buf[this.last_lit++] = (byte)(len - 3);
				int num = this.Lcode(len - 3);
				short[] array;
				IntPtr intPtr;
				(array = this.literalTree.freqs)[(int)(intPtr = (IntPtr)num)] = array[(int)intPtr] + 1;
				if (num >= 265 && num < 285)
				{
					this.extra_bits += (num - 261) / 4;
				}
				int num2 = this.Dcode(dist - 1);
				(array = this.distTree.freqs)[(int)(intPtr = (IntPtr)num2)] = array[(int)intPtr] + 1;
				if (num2 >= 4)
				{
					this.extra_bits += num2 / 2 - 1;
				}
				return this.IsFull();
			}

			// Token: 0x040000FA RID: 250
			private const int BUFSIZE = 16384;

			// Token: 0x040000FB RID: 251
			private const int LITERAL_NUM = 286;

			// Token: 0x040000FC RID: 252
			private const int DIST_NUM = 30;

			// Token: 0x040000FD RID: 253
			private const int BITLEN_NUM = 19;

			// Token: 0x040000FE RID: 254
			private const int REP_3_6 = 16;

			// Token: 0x040000FF RID: 255
			private const int REP_3_10 = 17;

			// Token: 0x04000100 RID: 256
			private const int REP_11_138 = 18;

			// Token: 0x04000101 RID: 257
			private const int EOF_SYMBOL = 256;

			// Token: 0x04000102 RID: 258
			private static readonly int[] BL_ORDER = new int[]
			{
				16, 17, 18, 0, 8, 7, 9, 6, 10, 5,
				11, 4, 12, 3, 13, 2, 14, 1, 15
			};

			// Token: 0x04000103 RID: 259
			private static readonly byte[] bit4Reverse = new byte[]
			{
				0, 8, 4, 12, 2, 10, 6, 14, 1, 9,
				5, 13, 3, 11, 7, 15
			};

			// Token: 0x04000104 RID: 260
			private SimpleZip.DeflaterPending pending;

			// Token: 0x04000105 RID: 261
			private SimpleZip.DeflaterHuffman.Tree literalTree;

			// Token: 0x04000106 RID: 262
			private SimpleZip.DeflaterHuffman.Tree distTree;

			// Token: 0x04000107 RID: 263
			private SimpleZip.DeflaterHuffman.Tree blTree;

			// Token: 0x04000108 RID: 264
			private short[] d_buf;

			// Token: 0x04000109 RID: 265
			private byte[] l_buf;

			// Token: 0x0400010A RID: 266
			private int last_lit;

			// Token: 0x0400010B RID: 267
			private int extra_bits;

			// Token: 0x0400010C RID: 268
			private static readonly short[] staticLCodes = new short[286];

			// Token: 0x0400010D RID: 269
			private static readonly byte[] staticLLength = new byte[286];

			// Token: 0x0400010E RID: 270
			private static readonly short[] staticDCodes;

			// Token: 0x0400010F RID: 271
			private static readonly byte[] staticDLength;

			// Token: 0x0200001D RID: 29
			public sealed class Tree
			{
				// Token: 0x0600016E RID: 366 RVA: 0x00012D88 File Offset: 0x00010F88
				public Tree(SimpleZip.DeflaterHuffman dh, int elems, int minCodes, int maxLength)
				{
					this.dh = dh;
					this.minNumCodes = minCodes;
					this.maxLength = maxLength;
					this.freqs = new short[elems];
					this.bl_counts = new int[maxLength];
				}

				// Token: 0x0600016F RID: 367 RVA: 0x00012DC0 File Offset: 0x00010FC0
				public void WriteSymbol(int code)
				{
					this.dh.pending.WriteBits((int)this.codes[code] & 65535, (int)this.length[code]);
				}

				// Token: 0x06000170 RID: 368 RVA: 0x00012DE8 File Offset: 0x00010FE8
				public void SetStaticCodes(short[] stCodes, byte[] stLength)
				{
					this.codes = stCodes;
					this.length = stLength;
				}

				// Token: 0x06000171 RID: 369 RVA: 0x00012DF8 File Offset: 0x00010FF8
				public void BuildCodes()
				{
					int num = this.freqs.Length;
					int[] array = new int[this.maxLength];
					int num2 = 0;
					this.codes = new short[this.freqs.Length];
					for (int i = 0; i < this.maxLength; i++)
					{
						array[i] = num2;
						num2 += this.bl_counts[i] << 15 - i;
					}
					for (int j = 0; j < this.numCodes; j++)
					{
						int num3 = (int)this.length[j];
						if (num3 > 0)
						{
							this.codes[j] = SimpleZip.DeflaterHuffman.BitReverse(array[num3 - 1]);
							int[] array2;
							IntPtr intPtr;
							(array2 = array)[(int)(intPtr = (IntPtr)(num3 - 1))] = array2[(int)intPtr] + (1 << 16 - num3);
						}
					}
				}

				// Token: 0x06000172 RID: 370 RVA: 0x00012EA8 File Offset: 0x000110A8
				private void BuildLength(int[] childs)
				{
					this.length = new byte[this.freqs.Length];
					int num = childs.Length / 2;
					int num2 = (num + 1) / 2;
					int num3 = 0;
					for (int i = 0; i < this.maxLength; i++)
					{
						this.bl_counts[i] = 0;
					}
					int[] array = new int[num];
					array[num - 1] = 0;
					int[] array2;
					IntPtr intPtr;
					for (int j = num - 1; j >= 0; j--)
					{
						if (childs[2 * j + 1] != -1)
						{
							int num4 = array[j] + 1;
							if (num4 > this.maxLength)
							{
								num4 = this.maxLength;
								num3++;
							}
							array[childs[2 * j]] = (array[childs[2 * j + 1]] = num4);
						}
						else
						{
							int num5 = array[j];
							(array2 = this.bl_counts)[(int)(intPtr = (IntPtr)(num5 - 1))] = array2[(int)intPtr] + 1;
							this.length[childs[2 * j]] = (byte)array[j];
						}
					}
					if (num3 == 0)
					{
						return;
					}
					int num6 = this.maxLength - 1;
					for (;;)
					{
						if (this.bl_counts[--num6] != 0)
						{
							do
							{
								(array2 = this.bl_counts)[(int)(intPtr = (IntPtr)num6)] = array2[(int)intPtr] - 1;
								(array2 = this.bl_counts)[(int)(intPtr = (IntPtr)(++num6))] = array2[(int)intPtr] + 1;
								num3 -= 1 << this.maxLength - 1 - num6;
							}
							while (num3 > 0 && num6 < this.maxLength - 1);
							if (num3 <= 0)
							{
								break;
							}
						}
					}
					(array2 = this.bl_counts)[(int)(intPtr = (IntPtr)(this.maxLength - 1))] = array2[(int)intPtr] + num3;
					(array2 = this.bl_counts)[(int)(intPtr = (IntPtr)(this.maxLength - 2))] = array2[(int)intPtr] - num3;
					int num7 = 2 * num2;
					for (int num8 = this.maxLength; num8 != 0; num8--)
					{
						int k = this.bl_counts[num8 - 1];
						while (k > 0)
						{
							int num9 = 2 * childs[num7++];
							if (childs[num9 + 1] == -1)
							{
								this.length[childs[num9]] = (byte)num8;
								k--;
							}
						}
					}
				}

				// Token: 0x06000173 RID: 371 RVA: 0x00013094 File Offset: 0x00011294
				public void BuildTree()
				{
					int num = this.freqs.Length;
					int[] array = new int[num];
					int i = 0;
					int num2 = 0;
					for (int j = 0; j < num; j++)
					{
						int num3 = (int)this.freqs[j];
						if (num3 != 0)
						{
							int num4 = i++;
							int num5;
							while (num4 > 0 && (int)this.freqs[array[num5 = (num4 - 1) / 2]] > num3)
							{
								array[num4] = array[num5];
								num4 = num5;
							}
							array[num4] = j;
							num2 = j;
						}
					}
					while (i < 2)
					{
						int num6 = ((num2 < 2) ? (++num2) : 0);
						array[i++] = num6;
					}
					this.numCodes = Math.Max(num2 + 1, this.minNumCodes);
					int num7 = i;
					int[] array2 = new int[4 * i - 2];
					int[] array3 = new int[2 * i - 1];
					int num8 = num7;
					for (int k = 0; k < i; k++)
					{
						int num9 = array[k];
						array2[2 * k] = num9;
						array2[2 * k + 1] = -1;
						array3[k] = (int)this.freqs[num9] << 8;
						array[k] = k;
					}
					do
					{
						int num10 = array[0];
						int num11 = array[--i];
						int num12 = 0;
						int l;
						for (l = 1; l < i; l = l * 2 + 1)
						{
							if (l + 1 < i && array3[array[l]] > array3[array[l + 1]])
							{
								l++;
							}
							array[num12] = array[l];
							num12 = l;
						}
						int num13 = array3[num11];
						while ((l = num12) > 0 && array3[array[num12 = (l - 1) / 2]] > num13)
						{
							array[l] = array[num12];
						}
						array[l] = num11;
						int num14 = array[0];
						num11 = num8++;
						array2[2 * num11] = num10;
						array2[2 * num11 + 1] = num14;
						int num15 = Math.Min(array3[num10] & 255, array3[num14] & 255);
						num13 = (array3[num11] = array3[num10] + array3[num14] - num15 + 1);
						num12 = 0;
						for (l = 1; l < i; l = num12 * 2 + 1)
						{
							if (l + 1 < i && array3[array[l]] > array3[array[l + 1]])
							{
								l++;
							}
							array[num12] = array[l];
							num12 = l;
						}
						while ((l = num12) > 0 && array3[array[num12 = (l - 1) / 2]] > num13)
						{
							array[l] = array[num12];
						}
						array[l] = num11;
					}
					while (i > 1);
					this.BuildLength(array2);
				}

				// Token: 0x06000174 RID: 372 RVA: 0x000132EC File Offset: 0x000114EC
				public int GetEncodedLength()
				{
					int num = 0;
					for (int i = 0; i < this.freqs.Length; i++)
					{
						num += (int)(this.freqs[i] * (short)this.length[i]);
					}
					return num;
				}

				// Token: 0x06000175 RID: 373 RVA: 0x00013324 File Offset: 0x00011524
				public void CalcBLFreq(SimpleZip.DeflaterHuffman.Tree blTree)
				{
					int num = -1;
					int i = 0;
					while (i < this.numCodes)
					{
						int num2 = 1;
						int num3 = (int)this.length[i];
						int num4;
						int num5;
						if (num3 == 0)
						{
							num4 = 138;
							num5 = 3;
						}
						else
						{
							num4 = 6;
							num5 = 3;
							if (num != num3)
							{
								short[] array;
								IntPtr intPtr;
								(array = blTree.freqs)[(int)(intPtr = (IntPtr)num3)] = array[(int)intPtr] + 1;
								num2 = 0;
							}
						}
						num = num3;
						i++;
						while (i < this.numCodes && num == (int)this.length[i])
						{
							i++;
							if (++num2 >= num4)
							{
								break;
							}
						}
						if (num2 < num5)
						{
							short[] array;
							IntPtr intPtr;
							(array = blTree.freqs)[(int)(intPtr = (IntPtr)num)] = array[(int)intPtr] + (short)num2;
						}
						else if (num != 0)
						{
							short[] array;
							(array = blTree.freqs)[16] = array[16] + 1;
						}
						else if (num2 <= 10)
						{
							short[] array;
							(array = blTree.freqs)[17] = array[17] + 1;
						}
						else
						{
							short[] array;
							(array = blTree.freqs)[18] = array[18] + 1;
						}
					}
				}

				// Token: 0x06000176 RID: 374 RVA: 0x0001341C File Offset: 0x0001161C
				public void WriteTree(SimpleZip.DeflaterHuffman.Tree blTree)
				{
					int num = -1;
					int i = 0;
					while (i < this.numCodes)
					{
						int num2 = 1;
						int num3 = (int)this.length[i];
						int num4;
						int num5;
						if (num3 == 0)
						{
							num4 = 138;
							num5 = 3;
						}
						else
						{
							num4 = 6;
							num5 = 3;
							if (num != num3)
							{
								blTree.WriteSymbol(num3);
								num2 = 0;
							}
						}
						num = num3;
						i++;
						while (i < this.numCodes && num == (int)this.length[i])
						{
							i++;
							if (++num2 >= num4)
							{
								break;
							}
						}
						if (num2 < num5)
						{
							while (num2-- > 0)
							{
								blTree.WriteSymbol(num);
							}
						}
						else if (num != 0)
						{
							blTree.WriteSymbol(16);
							this.dh.pending.WriteBits(num2 - 3, 2);
						}
						else if (num2 <= 10)
						{
							blTree.WriteSymbol(17);
							this.dh.pending.WriteBits(num2 - 3, 3);
						}
						else
						{
							blTree.WriteSymbol(18);
							this.dh.pending.WriteBits(num2 - 11, 7);
						}
					}
				}

				// Token: 0x04000110 RID: 272
				public short[] freqs;

				// Token: 0x04000111 RID: 273
				public byte[] length;

				// Token: 0x04000112 RID: 274
				public int minNumCodes;

				// Token: 0x04000113 RID: 275
				public int numCodes;

				// Token: 0x04000114 RID: 276
				private short[] codes;

				// Token: 0x04000115 RID: 277
				private int[] bl_counts;

				// Token: 0x04000116 RID: 278
				private int maxLength;

				// Token: 0x04000117 RID: 279
				private SimpleZip.DeflaterHuffman dh;
			}
		}

		// Token: 0x0200001E RID: 30
		internal sealed class DeflaterEngine
		{
			// Token: 0x06000177 RID: 375 RVA: 0x00013518 File Offset: 0x00011718
			public DeflaterEngine(SimpleZip.DeflaterPending pending)
			{
				this.pending = pending;
				this.huffman = new SimpleZip.DeflaterHuffman(pending);
				this.window = new byte[65536];
				this.head = new short[32768];
				this.prev = new short[32768];
				this.blockStart = (this.strstart = 1);
			}

			// Token: 0x06000178 RID: 376 RVA: 0x00013580 File Offset: 0x00011780
			private void UpdateHash()
			{
				this.ins_h = ((int)this.window[this.strstart] << 5) ^ (int)this.window[this.strstart + 1];
			}

			// Token: 0x06000179 RID: 377 RVA: 0x000135A8 File Offset: 0x000117A8
			private int InsertString()
			{
				int num = ((this.ins_h << 5) ^ (int)this.window[this.strstart + 2]) & 32767;
				short num2 = (this.prev[this.strstart & 32767] = this.head[num]);
				this.head[num] = (short)this.strstart;
				this.ins_h = num;
				return (int)num2 & 65535;
			}

			// Token: 0x0600017A RID: 378 RVA: 0x00013610 File Offset: 0x00011810
			private void SlideWindow()
			{
				Array.Copy(this.window, 32768, this.window, 0, 32768);
				this.matchStart -= 32768;
				this.strstart -= 32768;
				this.blockStart -= 32768;
				for (int i = 0; i < 32768; i++)
				{
					int num = (int)this.head[i] & 65535;
					this.head[i] = (short)((num >= 32768) ? (num - 32768) : 0);
				}
				for (int j = 0; j < 32768; j++)
				{
					int num2 = (int)this.prev[j] & 65535;
					this.prev[j] = (short)((num2 >= 32768) ? (num2 - 32768) : 0);
				}
			}

			// Token: 0x0600017B RID: 379 RVA: 0x000136E4 File Offset: 0x000118E4
			public void FillWindow()
			{
				if (this.strstart >= 65274)
				{
					this.SlideWindow();
				}
				while (this.lookahead < 262 && this.inputOff < this.inputEnd)
				{
					int num = 65536 - this.lookahead - this.strstart;
					if (num > this.inputEnd - this.inputOff)
					{
						num = this.inputEnd - this.inputOff;
					}
					Array.Copy(this.inputBuf, this.inputOff, this.window, this.strstart + this.lookahead, num);
					this.inputOff += num;
					this.totalIn += num;
					this.lookahead += num;
				}
				if (this.lookahead >= 3)
				{
					this.UpdateHash();
				}
			}

			// Token: 0x0600017C RID: 380 RVA: 0x000137BC File Offset: 0x000119BC
			private bool FindLongestMatch(int curMatch)
			{
				int num = 128;
				int num2 = 128;
				short[] array = this.prev;
				int num3 = this.strstart;
				int num4 = this.strstart + this.matchLen;
				int num5 = Math.Max(this.matchLen, 2);
				int num6 = Math.Max(this.strstart - 32506, 0);
				int num7 = this.strstart + 258 - 1;
				byte b = this.window[num4 - 1];
				byte b2 = this.window[num4];
				if (num5 >= 8)
				{
					num >>= 2;
				}
				if (num2 > this.lookahead)
				{
					num2 = this.lookahead;
				}
				do
				{
					if (this.window[curMatch + num5] == b2 && this.window[curMatch + num5 - 1] == b && this.window[curMatch] == this.window[num3] && this.window[curMatch + 1] == this.window[num3 + 1])
					{
						int num8 = curMatch + 2;
						num3 += 2;
						while (this.window[++num3] == this.window[++num8] && this.window[++num3] == this.window[++num8] && this.window[++num3] == this.window[++num8] && this.window[++num3] == this.window[++num8] && this.window[++num3] == this.window[++num8] && this.window[++num3] == this.window[++num8] && this.window[++num3] == this.window[++num8] && this.window[++num3] == this.window[++num8] && num3 < num7)
						{
						}
						if (num3 > num4)
						{
							this.matchStart = curMatch;
							num4 = num3;
							num5 = num3 - this.strstart;
							if (num5 >= num2)
							{
								break;
							}
							b = this.window[num4 - 1];
							b2 = this.window[num4];
						}
						num3 = this.strstart;
					}
				}
				while ((curMatch = (int)array[curMatch & 32767] & 65535) > num6 && --num != 0);
				this.matchLen = Math.Min(num5, this.lookahead);
				return this.matchLen >= 3;
			}

			// Token: 0x0600017D RID: 381 RVA: 0x00013A20 File Offset: 0x00011C20
			private bool DeflateSlow(bool flush, bool finish)
			{
				if (this.lookahead < 262 && !flush)
				{
					return false;
				}
				while (this.lookahead >= 262 || flush)
				{
					if (this.lookahead == 0)
					{
						if (this.prevAvailable)
						{
							this.huffman.TallyLit((int)(this.window[this.strstart - 1] & byte.MaxValue));
						}
						this.prevAvailable = false;
						this.huffman.FlushBlock(this.window, this.blockStart, this.strstart - this.blockStart, finish);
						this.blockStart = this.strstart;
						return false;
					}
					if (this.strstart >= 65274)
					{
						this.SlideWindow();
					}
					int num = this.matchStart;
					int num2 = this.matchLen;
					if (this.lookahead >= 3)
					{
						int num3 = this.InsertString();
						if (num3 != 0 && this.strstart - num3 <= 32506 && this.FindLongestMatch(num3) && this.matchLen <= 5 && this.matchLen == 3 && this.strstart - this.matchStart > 4096)
						{
							this.matchLen = 2;
						}
					}
					if (num2 >= 3 && this.matchLen <= num2)
					{
						this.huffman.TallyDist(this.strstart - 1 - num, num2);
						num2 -= 2;
						do
						{
							this.strstart++;
							this.lookahead--;
							if (this.lookahead >= 3)
							{
								this.InsertString();
							}
						}
						while (--num2 > 0);
						this.strstart++;
						this.lookahead--;
						this.prevAvailable = false;
						this.matchLen = 2;
					}
					else
					{
						if (this.prevAvailable)
						{
							this.huffman.TallyLit((int)(this.window[this.strstart - 1] & byte.MaxValue));
						}
						this.prevAvailable = true;
						this.strstart++;
						this.lookahead--;
					}
					if (this.huffman.IsFull())
					{
						int num4 = this.strstart - this.blockStart;
						if (this.prevAvailable)
						{
							num4--;
						}
						bool flag = finish && this.lookahead == 0 && !this.prevAvailable;
						this.huffman.FlushBlock(this.window, this.blockStart, num4, flag);
						this.blockStart += num4;
						return !flag;
					}
				}
				return true;
			}

			// Token: 0x0600017E RID: 382 RVA: 0x00013C88 File Offset: 0x00011E88
			public bool Deflate(bool flush, bool finish)
			{
				bool flag2;
				do
				{
					this.FillWindow();
					bool flag = flush && this.inputOff == this.inputEnd;
					flag2 = this.DeflateSlow(flag, finish);
				}
				while (this.pending.IsFlushed && flag2);
				return flag2;
			}

			// Token: 0x0600017F RID: 383 RVA: 0x00013CCC File Offset: 0x00011ECC
			public void SetInput(byte[] buffer)
			{
				this.inputBuf = buffer;
				this.inputOff = 0;
				this.inputEnd = buffer.Length;
			}

			// Token: 0x06000180 RID: 384 RVA: 0x00013CE8 File Offset: 0x00011EE8
			public bool NeedsInput()
			{
				return this.inputEnd == this.inputOff;
			}

			// Token: 0x04000118 RID: 280
			private const int MAX_MATCH = 258;

			// Token: 0x04000119 RID: 281
			private const int MIN_MATCH = 3;

			// Token: 0x0400011A RID: 282
			private const int WSIZE = 32768;

			// Token: 0x0400011B RID: 283
			private const int WMASK = 32767;

			// Token: 0x0400011C RID: 284
			private const int HASH_SIZE = 32768;

			// Token: 0x0400011D RID: 285
			private const int HASH_MASK = 32767;

			// Token: 0x0400011E RID: 286
			private const int HASH_SHIFT = 5;

			// Token: 0x0400011F RID: 287
			private const int MIN_LOOKAHEAD = 262;

			// Token: 0x04000120 RID: 288
			private const int MAX_DIST = 32506;

			// Token: 0x04000121 RID: 289
			private const int TOO_FAR = 4096;

			// Token: 0x04000122 RID: 290
			private int ins_h;

			// Token: 0x04000123 RID: 291
			private short[] head;

			// Token: 0x04000124 RID: 292
			private short[] prev;

			// Token: 0x04000125 RID: 293
			private int matchStart;

			// Token: 0x04000126 RID: 294
			private int matchLen;

			// Token: 0x04000127 RID: 295
			private bool prevAvailable;

			// Token: 0x04000128 RID: 296
			private int blockStart;

			// Token: 0x04000129 RID: 297
			private int strstart;

			// Token: 0x0400012A RID: 298
			private int lookahead;

			// Token: 0x0400012B RID: 299
			private byte[] window;

			// Token: 0x0400012C RID: 300
			private byte[] inputBuf;

			// Token: 0x0400012D RID: 301
			private int totalIn;

			// Token: 0x0400012E RID: 302
			private int inputOff;

			// Token: 0x0400012F RID: 303
			private int inputEnd;

			// Token: 0x04000130 RID: 304
			private SimpleZip.DeflaterPending pending;

			// Token: 0x04000131 RID: 305
			private SimpleZip.DeflaterHuffman huffman;
		}

		// Token: 0x0200001F RID: 31
		internal sealed class DeflaterPending
		{
			// Token: 0x06000181 RID: 385 RVA: 0x00013CF8 File Offset: 0x00011EF8
			public void WriteShort(int s)
			{
				this.buf[this.end++] = (byte)s;
				this.buf[this.end++] = (byte)(s >> 8);
			}

			// Token: 0x06000182 RID: 386 RVA: 0x00013D3C File Offset: 0x00011F3C
			public void WriteBlock(byte[] block, int offset, int len)
			{
				Array.Copy(block, offset, this.buf, this.end, len);
				this.end += len;
			}

			// Token: 0x1700007C RID: 124
			// (get) Token: 0x06000183 RID: 387 RVA: 0x00013D60 File Offset: 0x00011F60
			public int BitCount
			{
				get
				{
					return this.bitCount;
				}
			}

			// Token: 0x06000184 RID: 388 RVA: 0x00013D68 File Offset: 0x00011F68
			public void AlignToByte()
			{
				if (this.bitCount > 0)
				{
					this.buf[this.end++] = (byte)this.bits;
					if (this.bitCount > 8)
					{
						this.buf[this.end++] = (byte)(this.bits >> 8);
					}
				}
				this.bits = 0U;
				this.bitCount = 0;
			}

			// Token: 0x06000185 RID: 389 RVA: 0x00013DD8 File Offset: 0x00011FD8
			public void WriteBits(int b, int count)
			{
				this.bits |= (uint)((uint)b << this.bitCount);
				this.bitCount += count;
				if (this.bitCount >= 16)
				{
					this.buf[this.end++] = (byte)this.bits;
					this.buf[this.end++] = (byte)(this.bits >> 8);
					this.bits >>= 16;
					this.bitCount -= 16;
				}
			}

			// Token: 0x1700007D RID: 125
			// (get) Token: 0x06000186 RID: 390 RVA: 0x00013E74 File Offset: 0x00012074
			public bool IsFlushed
			{
				get
				{
					return this.end == 0;
				}
			}

			// Token: 0x06000187 RID: 391 RVA: 0x00013E80 File Offset: 0x00012080
			public int Flush(byte[] output, int offset, int length)
			{
				if (this.bitCount >= 8)
				{
					this.buf[this.end++] = (byte)this.bits;
					this.bits >>= 8;
					this.bitCount -= 8;
				}
				if (length > this.end - this.start)
				{
					length = this.end - this.start;
					Array.Copy(this.buf, this.start, output, offset, length);
					this.start = 0;
					this.end = 0;
				}
				else
				{
					Array.Copy(this.buf, this.start, output, offset, length);
					this.start += length;
				}
				return length;
			}

			// Token: 0x04000132 RID: 306
			protected byte[] buf = new byte[65536];

			// Token: 0x04000133 RID: 307
			private int start = 0;

			// Token: 0x04000134 RID: 308
			private int end = 0;

			// Token: 0x04000135 RID: 309
			private uint bits = 0U;

			// Token: 0x04000136 RID: 310
			private int bitCount = 0;
		}

		// Token: 0x02000020 RID: 32
		internal sealed class ZipStream : MemoryStream
		{
			// Token: 0x06000189 RID: 393 RVA: 0x00013F6C File Offset: 0x0001216C
			public void WriteShort(int value)
			{
				this.WriteByte((byte)(value & 255));
				this.WriteByte((byte)((value >> 8) & 255));
			}

			// Token: 0x0600018A RID: 394 RVA: 0x00013F8C File Offset: 0x0001218C
			public void WriteInt(int value)
			{
				this.WriteShort(value);
				this.WriteShort(value >> 16);
			}

			// Token: 0x0600018B RID: 395 RVA: 0x00013FA0 File Offset: 0x000121A0
			public int ReadShort()
			{
				return this.ReadByte() | (this.ReadByte() << 8);
			}

			// Token: 0x0600018C RID: 396 RVA: 0x00013FB4 File Offset: 0x000121B4
			public int ReadInt()
			{
				return this.ReadShort() | (this.ReadShort() << 16);
			}

			// Token: 0x0600018D RID: 397 RVA: 0x00013FC8 File Offset: 0x000121C8
			public ZipStream()
			{
			}

			// Token: 0x0600018E RID: 398 RVA: 0x00013FD0 File Offset: 0x000121D0
			public ZipStream(byte[] buffer)
				: base(buffer, false)
			{
			}
		}
	}
}
