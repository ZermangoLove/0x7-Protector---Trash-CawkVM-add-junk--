using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using Core.Protection;
using dnlib.DotNet;
using dnlib.DotNet.Writer;
using dnlib.IO;

namespace Core.ByteEncryption
{
	internal class Process
	{
		public delegate void abc(byte[] bytes, int len, byte[] key, int keylen);

		public static EBytes eBytes = new EBytes("IVM");

		[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern IntPtr LoadLibrary(string dllToLoad);

		[DllImport("kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GetProcAddress", ExactSpelling = true)]
		private static extern IntPtr e(IntPtr intptr, string str);

		[DllImport("kernel32.dll", CharSet = CharSet.Auto, EntryPoint = "GetModuleHandle")]
		private static extern IntPtr ab(string str);

		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern IntPtr LoadLibraryEx(string dllToLoad, IntPtr hFile, uint flags);

		public static byte[] tester(MethodDef methodDef, ModuleDefMD updated)
		{
			int num = 1834513280;
			int num2 = 1;
			DataReader dataReader = default(DataReader);
			FileOffset fileOffset = default(FileOffset);
			int num3 = default(int);
			MethodDef methodDef2 = default(MethodDef);
			byte[] array = default(byte[]);
			uint num4 = default(uint);
			byte b = default(byte);
			while (true)
			{
				if (num2 == (0x6D587384 ^ num))
				{
					dataReader.Position = (uint)fileOffset;
					num2 = 0x6D587385 ^ num;
				}
				if (num2 == -1834513272 + num)
				{
					switch (num3 - (0x6D587382 ^ num))
					{
					case 1:
						goto IL_017f;
					case 0:
					case 4:
						goto IL_01cc;
					case 2:
					case 3:
						goto IL_0234;
					}
					num2 = 0x6D587389 ^ num;
				}
				if (num2 == -1834513267 + num)
				{
					dataReader.ReadUInt16();
					num2 = 0x6D58738E ^ num;
				}
				if (num2 == (0x6D587391 ^ num))
				{
					dataReader.Position = (uint)((ulong)fileOffset + (ulong)methodDef2.Body.HeaderSize);
					num2 = -1834513262 + num;
				}
				if (num2 != -1834513261 + num)
				{
					if (num2 == -1834513262 + num)
					{
						dataReader.ReadBytes(array, 1834513280 - num, array.Length);
						num2 = -1834513261 + num;
					}
					if (num2 == 1834513296 - num)
					{
						array = new byte[num4];
						num2 = -1834513263 + num;
					}
					if (num2 != -1834513265 + num)
					{
						goto IL_0158;
					}
					goto IL_0234;
				}
				return array;
				IL_0234:
				if (num4 == 0)
				{
					break;
				}
				num2 = -1834513264 + num;
				goto IL_0158;
				IL_01ed:
				if (num2 == -1834513271 + num)
				{
					goto IL_0234;
				}
				if (num2 == (0x6D587387 ^ num))
				{
					num3 = b & (0x6D587387 ^ num);
					num2 = 1834513288 - num;
				}
				if (num2 == 1834513286 - num)
				{
					num4 = (uint)(1834513280 - num);
					num2 = 0x6D587387 ^ num;
				}
				if (num2 == (0x6D587385 ^ num))
				{
					b = dataReader.ReadByte();
					num2 = 0x6D587386 ^ num;
				}
				if (num2 == -1834513277 + num)
				{
					fileOffset = updated.Metadata.PEImage.ToFileOffset(methodDef2.RVA);
					num2 = 1834513284 - num;
				}
				if (num2 == (0x6D587382 ^ num))
				{
					methodDef2 = updated.ResolveToken(methodDef.MDToken.ToInt32()) as MethodDef;
					num2 = 1834513283 - num;
				}
				if (num2 == -1834513279 + num)
				{
					dataReader = updated.Metadata.PEImage.CreateReader();
					num2 = -1834513278 + num;
				}
				if (num2 == (0x6D587380 ^ num))
				{
					num2 = -1834513279 + num;
				}
				if (num2 == 1834513300 - num)
				{
					break;
				}
				continue;
				IL_0158:
				if (num2 == -1834513266 + num)
				{
					num4 = dataReader.ReadUInt32();
					num2 = 1834513295 - num;
				}
				if (num2 == -1834513268 + num)
				{
					goto IL_017f;
				}
				goto IL_01a8;
				IL_01cc:
				num4 = (uint)(b >> -1834513278 + num);
				num2 = 1834513291 - num;
				goto IL_01ed;
				IL_017f:
				_ = (ushort)((dataReader.ReadByte() << 1834513288 - num) | b);
				num2 = 0x6D58738D ^ num;
				goto IL_01a8;
				IL_01a8:
				if (num2 != -1834513269 + num)
				{
					if (num2 == (0x6D58738A ^ num))
					{
						goto IL_01cc;
					}
					goto IL_01ed;
				}
				goto IL_0234;
			}
			return null;
		}

		[DllImport("NativePRo.dll")]
		public static extern void a(byte[] bytes, int len, byte[] key, int keylen);

		public static void processConvertedMethods(List<MethodData> allMethodDatas)
		{
			int num = 1716747102;
			int num2 = 1;
			ModuleWriterOptions moduleWriterOptions = default(ModuleWriterOptions);
			List<MethodData>.Enumerator enumerator = default(List<MethodData>.Enumerator);
			ModuleDefMD updated = default(ModuleDefMD);
			Stream stream = default(Stream);
			int num3 = default(int);
			do
			{
				if (num2 == -1716747098 + num)
				{
					moduleWriterOptions.MetadataOptions.Flags = (MetadataFlags)((-1693769416 ^ num) + (-718373869 - num) - (98525118 + num));
					num2 = -1716747097 + num;
				}
				if (num2 == -1716747094 + num)
				{
					enumerator = allMethodDatas.GetEnumerator();
					num2 = -1716747093 + num;
				}
				if (num2 == -1716747095 + num)
				{
					updated = ModuleDefMD.Load(stream);
					num2 = 1716747110 - num;
				}
				if (num2 == 1716747108 - num)
				{
					Protector.moduleDefMD.Write(stream, moduleWriterOptions);
					num2 = -1716747095 + num;
				}
				if (num2 == 1716747107 - num)
				{
					moduleWriterOptions.Logger = DummyLogger.NoThrowInstance;
					num2 = -1716747096 + num;
				}
				if (num2 == -1716747099 + num)
				{
					moduleWriterOptions = new ModuleWriterOptions(Protector.moduleDefMD);
					num2 = 0x66537B5A ^ num;
				}
				if (num2 == -1716747100 + num)
				{
					stream = new MemoryStream();
					num2 = 1716747105 - num;
				}
				if (num2 == 1716747103 - num)
				{
					num3 = -1716747102 + num;
					num2 = 1716747104 - num;
				}
				if (num2 == (0x66537B5E ^ num))
				{
					num2 = 1716747103 - num;
				}
			}
			while (num2 != (0x66537B57 ^ num));
			try
			{
				while (enumerator.MoveNext())
				{
					MethodData current = enumerator.Current;
					byte[] decryptedBytes = current.DecryptedBytes;
					MethodDef method = current.Method;
					MD5 mD = MD5.Create();
					byte[] array = tester(method, updated);
					byte[] data = mD.ComputeHash(Encoding.ASCII.GetBytes(method.Name));
					byte[] array2 = ByteEncryption.Encrypt(eBytes.Encrypt(data), decryptedBytes);
					array2 = aMethod2(array2, array2.Length, array, array.Length);
					current.EncryptedBytes = array2;
					current.Encrypted = (byte)(-1716747101 + num) != 0;
					current.size = current.EncryptedBytes.Length;
					current.position = num3;
					num3 += current.EncryptedBytes.Length;
				}
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
		}

		[Obfuscation(Feature = "virtualization", Exclude = false)]
		private static byte[] b(byte[] toEncrypt, int len)
		{
			int num = 475424675;
			int num2 = 1;
			int num3 = default(int);
			byte[] array = default(byte[]);
			string text = default(string);
			do
			{
				if (num2 == 475424679 - num || num2 == (0x1C5667A4 ^ num))
				{
					if (num3 < len)
					{
						goto IL_0082;
					}
					num2 = 475424683 - num;
				}
				if (num2 == -475424669 + num)
				{
					num3 += 0x1C5667A2 ^ num;
					num2 = 475424682 - num;
				}
				if (num2 == (0x1C5667A6 ^ num))
				{
					goto IL_0082;
				}
				goto IL_00bb;
				IL_00bb:
				if (num2 == (0x1C5667A0 ^ num))
				{
					num3 = 475424675 - num;
					num2 = 475424679 - num;
				}
				if (num2 == -475424673 + num)
				{
					array = toEncrypt;
					num2 = 0x1C5667A0 ^ num;
				}
				if (num2 == 475424676 - num)
				{
					text = "HCP";
					num2 = 0x1C5667A1 ^ num;
				}
				if (num2 == -475424675 + num)
				{
					num2 = -475424674 + num;
				}
				continue;
				IL_0082:
				array[num3] = (byte)(toEncrypt[num3] ^ text[num3 % text.Length]);
				num2 = 0x1C5667A5 ^ num;
				goto IL_00bb;
			}
			while (num2 != (0x1C5667AB ^ num));
			return array;
		}

		[Obfuscation(Feature = "virtualization", Exclude = false)]
		private static byte[] aMethod2(byte[] data, int datalen, byte[] key, int keylen)
		{
			int num = 329489021;
			int num2 = 1;
			int num3 = default(int);
			int num5 = default(int);
			int num4 = default(int);
			int num6 = default(int);
			while (true)
			{
				if (num2 == (0x13A39A79 ^ num))
				{
					num3 = 0x13A39A7D ^ num;
					num2 = -329489016 + num;
				}
				if (num2 == (0x13A39A75 ^ num))
				{
					num3 += -329489020 + num;
					num2 = 329489030 - num;
				}
				if (num2 == 329489034 - num)
				{
					num5 = (num4 + (329489026 - num)) * (num5 & (-1336762978 + num + (0x7620D1EC ^ num) - (0x3ADA18D0 ^ num))) + (num5 >> (0x13A39A75 ^ num));
					num2 = 329489035 - num;
				}
				if (num2 == 329489038 - num)
				{
					num3 += -329489020 + num;
					num2 = 0x13A39A6F ^ num;
				}
				if (num2 == (0x13A39A6F ^ num))
				{
					goto IL_01d2;
				}
				goto IL_0250;
				IL_01dc:
				num4 = key[num3 % keylen] + num4;
				num2 = 0x13A39A70 ^ num;
				goto IL_0201;
				IL_0250:
				if (num2 == (0x13A39A6D ^ num))
				{
					data[num3] = (byte)(data[num3] ^ num4);
					num2 = 329489038 - num;
				}
				if (num2 == 329489036 - num)
				{
					num4 = ((num5 << -329489013 + num) + num6) & (-2011645233 + num + (1750108191 + num) - (0x413EC94 ^ num));
					num2 = 0x13A39A6D ^ num;
				}
				if (num2 == 329489035 - num)
				{
					num6 = (num4 + (329489028 - num)) * (num6 & (-1644197863 + num + (0x783BCA21 ^ num) - (819924080 - num))) + (num6 >> (0x13A39A75 ^ num));
					num2 = 0x13A39A72 ^ num;
				}
				if (num2 == 329489033 - num)
				{
					goto IL_01dc;
				}
				goto IL_0201;
				IL_0303:
				if (num2 == 329489028 - num)
				{
					goto IL_02b1;
				}
				goto IL_02e1;
				IL_01d2:
				if (num3 < datalen)
				{
					goto IL_01dc;
				}
				num2 = 0x13A39A6E ^ num;
				goto IL_0250;
				IL_02e1:
				if (num2 == (0x13A39A7B ^ num))
				{
					goto IL_02a7;
				}
				if (num2 == -329489016 + num)
				{
					num3 = 0x13A39A7D ^ num;
					num2 = -329489015 + num;
				}
				if (num2 == -329489018 + num)
				{
					num4 = (-285982444 ^ num) + (-2105631950 - num) - (2144761241 - num);
					num2 = 329489025 - num;
				}
				if (num2 == 329489023 - num)
				{
					num6 = 329489035 - num;
					num2 = 0x13A39A7E ^ num;
				}
				if (num2 == (0x13A39A7C ^ num))
				{
					num5 = -329489009 + num;
					num2 = 0x13A39A7F ^ num;
				}
				if (num2 == (0x13A39A7D ^ num))
				{
					num2 = -329489020 + num;
				}
				if (num2 == 329489040 - num)
				{
					break;
				}
				continue;
				IL_02b1:
				num4 += num4 % (key[num3] + (-329489020 + num));
				num2 = -329489013 + num;
				goto IL_02e1;
				IL_0201:
				if (num2 == -329489010 + num)
				{
					goto IL_01d2;
				}
				if (num2 == (0x13A39A77 ^ num))
				{
					num3 = -329489021 + num;
					num2 = 0x13A39A76 ^ num;
				}
				if (num2 == 329489030 - num)
				{
					goto IL_02a7;
				}
				goto IL_0303;
				IL_02a7:
				if (num3 < keylen)
				{
					goto IL_02b1;
				}
				num2 = -329489011 + num;
				goto IL_0303;
			}
			return b(data, datalen);
		}

		public static byte[] aMethod(byte[] data, int datalen, byte[] key, int keylen)
		{
			int num = 670753783;
			int num2 = 1;
			int num3 = default(int);
			int num5 = default(int);
			int num4 = default(int);
			int num6 = default(int);
			while (true)
			{
				if (num2 == -670753779 + num)
				{
					num3 = 0x27FAE3F7 ^ num;
					num2 = 670753788 - num;
				}
				if (num2 == 670753791 - num)
				{
					num3 += 0x27FAE3F6 ^ num;
					num2 = -670753774 + num;
				}
				if (num2 == -670753770 + num)
				{
					num5 = (num4 + (-670753778 + num)) * (num5 & (-336520174 - num + (0x4279A866 ^ num) - (25075382 + num))) + (num5 >> 670753791 - num);
					num2 = 0x27FAE3F9 ^ num;
				}
				if (num2 == 670753800 - num)
				{
					num3 += 670753784 - num;
					num2 = 0x27FAE3E5 ^ num;
				}
				if (num2 == 670753801 - num)
				{
					goto IL_01d2;
				}
				goto IL_0250;
				IL_01dc:
				num4 = key[num3 % keylen] + num4;
				num2 = -670753770 + num;
				goto IL_0201;
				IL_0250:
				if (num2 == (0x27FAE3E7 ^ num))
				{
					data[num3] = (byte)(data[num3] ^ num4);
					num2 = -670753766 + num;
				}
				if (num2 == -670753768 + num)
				{
					num4 = ((num5 << (0x27FAE3FF ^ num)) + num6) & (-1011402429 - num + (0x5C0EC16B ^ num) - (-273313038 + num));
					num2 = 0x27FAE3E7 ^ num;
				}
				if (num2 == -670753769 + num)
				{
					num6 = (num4 + (0x27FAE3F0 ^ num)) * (num6 & (-643955059 - num + (-1819069357 - num) - (0x3AC19204 ^ num))) + (num6 >> (0x27FAE3FF ^ num));
					num2 = 670753798 - num;
				}
				if (num2 == -670753771 + num)
				{
					goto IL_01dc;
				}
				goto IL_0201;
				IL_0303:
				if (num2 == 670753790 - num)
				{
					goto IL_02b1;
				}
				goto IL_02e1;
				IL_01d2:
				if (num3 < datalen)
				{
					goto IL_01dc;
				}
				num2 = 670753802 - num;
				goto IL_0250;
				IL_02e1:
				if (num2 == (0x27FAE3F1 ^ num))
				{
					goto IL_02a7;
				}
				if (num2 == 670753788 - num)
				{
					num3 = 670753783 - num;
					num2 = -670753777 + num;
				}
				if (num2 == -670753780 + num)
				{
					num4 = 626179936 - num + (1189092542 + num) - (-1808941293 - num);
					num2 = 670753787 - num;
				}
				if (num2 == -670753781 + num)
				{
					num6 = -670753769 + num;
					num2 = 670753786 - num;
				}
				if (num2 == 670753784 - num)
				{
					num5 = 0x27FAE3FB ^ num;
					num2 = -670753781 + num;
				}
				if (num2 == -670753783 + num)
				{
					num2 = 670753784 - num;
				}
				if (num2 == (0x27FAE3E4 ^ num))
				{
					break;
				}
				continue;
				IL_02b1:
				num4 += num4 % (key[num3] + (-670753782 + num));
				num2 = 0x27FAE3FF ^ num;
				goto IL_02e1;
				IL_0201:
				if (num2 == 670753794 - num)
				{
					goto IL_01d2;
				}
				if (num2 == (0x27FAE3FD ^ num))
				{
					num3 = 0x27FAE3F7 ^ num;
					num2 = 670753794 - num;
				}
				if (num2 == 670753792 - num)
				{
					goto IL_02a7;
				}
				goto IL_0303;
				IL_02a7:
				if (num3 < keylen)
				{
					goto IL_02b1;
				}
				num2 = 0x27FAE3FD ^ num;
				goto IL_0303;
			}
			return Bmethod(data, data.Length);
		}

		public static byte[] Bmethod(byte[] toEncrypt, int len)
		{
			int num = 48670742;
			int num2 = 1;
			int num3 = default(int);
			byte[] array = default(byte[]);
			char[] array3 = default(char[]);
			do
			{
				if (num2 == -48670738 + num || num2 == -48670735 + num)
				{
					if (num3 < len)
					{
						goto IL_0082;
					}
					num2 = 48670750 - num;
				}
				if (num2 == 48670748 - num)
				{
					num3 += 0x2E6A817 ^ num;
					num2 = -48670735 + num;
				}
				if (num2 == 48670747 - num)
				{
					goto IL_0082;
				}
				goto IL_00b8;
				IL_00b8:
				if (num2 == 48670745 - num)
				{
					num3 = -48670742 + num;
					num2 = -48670738 + num;
				}
				if (num2 == (0x2E6A814 ^ num))
				{
					array = toEncrypt;
					num2 = -48670739 + num;
				}
				if (num2 == (0x2E6A817 ^ num))
				{
					char[] array2 = new char[0x2E6A815 ^ num];
					RuntimeHelpers.InitializeArray(array2, (RuntimeFieldHandle)/*OpCode not supported: LdMemberToken*/);
					array3 = array2;
					num2 = -48670740 + num;
				}
				if (num2 == 48670742 - num)
				{
					num2 = 48670743 - num;
				}
				continue;
				IL_0082:
				array[num3] = (byte)(toEncrypt[num3] ^ array3[num3 % (0x2E6A817 ^ num)]);
				num2 = 48670748 - num;
				goto IL_00b8;
			}
			while (num2 != (0x2E6A81E ^ num));
			return array;
		}
	}
}
