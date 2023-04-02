using System.Collections.Generic;
using System.IO;
using dnlib.DotNet;
using dnlib.IO;

namespace Core.ByteEncryption
{
	internal class bytesGetter
	{
		private static byte[][] methodbodies;

		public static void CalculateEncKeys(ModuleDefMD module)
		{
			int num = 1377116248;
			int num2 = 1;
			DataReader dataReader = default(DataReader);
			ModuleDefMD moduleDefMD = default(ModuleDefMD);
			MetadataReader metadataReader = default(MetadataReader);
			int[] array = default(int[]);
			int num3 = default(int);
			BinaryReader binaryReader = default(BinaryReader);
			int num4 = default(int);
			byte b = default(byte);
			while (true)
			{
				if (num2 == (0x5215205C ^ num))
				{
					dataReader = moduleDefMD.Metadata.PEImage.CreateReader();
					num2 = 1377116253 - num;
				}
				if (num2 == 1377116256 - num)
				{
					methodbodies = new byte[metadataReader.TableLengths[-1377116242 + num]][];
					num2 = -1377116239 + num;
				}
				if (num2 != -1377116235 + num)
				{
					if (num2 == (0x52152049 ^ num))
					{
						if (array[num3] <= (0x52152058 ^ num))
						{
							goto IL_06cd;
						}
						num2 = -1377116230 + num;
					}
					if (num2 == -1377116226 + num)
					{
						array[num3] += 1377116249 - num;
						num2 = 1377116271 - num;
					}
					if (num2 == 1377116274 - num)
					{
						binaryReader.BaseStream.Position = binaryReader.BaseStream.Position + (1377116252 - num);
						num2 = -1377116221 + num;
					}
					if (num2 == 1377116276 - num)
					{
						goto IL_0274;
					}
					goto IL_02c5;
				}
				goto IL_0647;
				IL_0647:
				if (num3 >= metadataReader.TableLengths[-1377116242 + num])
				{
					break;
				}
				goto IL_0664;
				IL_0414:
				if (num2 == 1377116260 - num)
				{
					num3 = 1377116248 - num;
					num2 = 1377116261 - num;
				}
				if (num2 == 1377116259 - num)
				{
					new List<int>();
					num2 = 0x52152054 ^ num;
				}
				if (num2 == -1377116238 + num)
				{
					new List<int>();
					num2 = 0x52152053 ^ num;
				}
				if (num2 == -1377116239 + num)
				{
					array = new int[metadataReader.TableLengths[0x5215205E ^ num]];
					num2 = 0x52152052 ^ num;
				}
				if (num2 == -1377116241 + num)
				{
					if (!metadataReader.Intialize(binaryReader))
					{
						break;
					}
					num2 = 0x52152050 ^ num;
				}
				if (num2 == 1377116254 - num)
				{
					new Dictionary<int, uint>();
					num2 = -1377116241 + num;
				}
				if (num2 == -1377116243 + num)
				{
					binaryReader = new BinaryReader(new MemoryStream(dataReader.ReadBytes((int)moduleDefMD.Metadata.PEImage.CreateReader().Length)));
					num2 = 0x5215205E ^ num;
				}
				if (num2 == 1377116251 - num)
				{
					binaryReader = null;
					num2 = 1377116252 - num;
				}
				if (num2 == (0x5215205A ^ num))
				{
					metadataReader = new MetadataReader();
					num2 = 1377116251 - num;
				}
				if (num2 == -1377116247 + num)
				{
					moduleDefMD = module;
					num2 = -1377116246 + num;
				}
				if (num2 == (0x52152058 ^ num))
				{
					num2 = 1377116249 - num;
				}
				if (num2 != 1377116277 - num)
				{
					continue;
				}
				try
				{
					binaryReader.BaseStream.Position = array[num3];
					methodbodies[num3] = binaryReader.ReadBytes(num4);
				}
				catch
				{
				}
				goto IL_06cd;
				IL_020c:
				if ((b & (0x5215205B ^ num)) == (0x5215205B ^ num))
				{
					num2 = 0x52152040 ^ num;
					goto IL_025d;
				}
				goto IL_0274;
				IL_025d:
				if (num2 == -1377116227 + num)
				{
					num4 = b >> (0x5215205A ^ num);
					num2 = -1377116226 + num;
				}
				if (num2 == -1377116228 + num)
				{
					if ((b & (0x5215205B ^ num)) != (0x5215205A ^ num))
					{
						goto IL_020c;
					}
					num2 = 0x5215204D ^ num;
				}
				if (num2 == -1377116229 + num)
				{
					b = (byte)(binaryReader.ReadByte() & (-1421690098 + num + (-1058004723 - num) - (0x3E27FB44 ^ num)));
					num2 = 1377116268 - num;
				}
				if (num2 == 1377116266 - num)
				{
					binaryReader.BaseStream.Position = array[num3];
					num2 = 1377116267 - num;
				}
				if (num2 == 1377116264 - num)
				{
					array[num3] = metadataReader.Rva2Offset((int)metadataReader.tables[-1377116242 + num].members[num3][0x52152058 ^ num]);
					num2 = 1377116265 - num;
				}
				if (num2 == -1377116233 + num)
				{
					num4 = -1377116248 + num;
					num2 = 0x52152048 ^ num;
				}
				if (num2 != (0x52152056 ^ num))
				{
					goto IL_0414;
				}
				goto IL_0664;
				IL_02c5:
				if (num2 == (0x52152043 ^ num))
				{
					array[num3] += 0x52152054 ^ num;
					num2 = 1377116276 - num;
				}
				if (num2 == (0x52152041 ^ num))
				{
					num4 = binaryReader.ReadInt32();
					num2 = 0x52152042 ^ num;
				}
				if (num2 == -1377116224 + num)
				{
					binaryReader.BaseStream.Position = binaryReader.BaseStream.Position + (-1377116245 + num);
					num2 = -1377116223 + num;
				}
				if (num2 == 1377116271 - num)
				{
					goto IL_020c;
				}
				goto IL_025d;
				IL_06cd:
				num3 += 1377116249 - num;
				goto IL_0647;
				IL_0664:
				methodbodies[num3] = null;
				num2 = 0x52152057 ^ num;
				goto IL_0414;
				IL_0274:
				if (num4 > -1377116248 + num)
				{
					num2 = 1377116277 - num;
					goto IL_02c5;
				}
				goto IL_06cd;
			}
		}

		public static byte[] tester(int token)
		{
			int num = 835299885;
			int num2 = 1;
			int num3 = default(int);
			byte[] result = default(byte[]);
			int num4 = default(int);
			byte[][] array = default(byte[][]);
			while (true)
			{
				if (num2 != -835299881 + num)
				{
					if (num2 != -835299877 + num)
					{
						if (num2 == -835299878 + num)
						{
							if (num3 != token)
							{
								goto IL_0141;
							}
							num2 = 835299893 - num;
						}
						if (num2 == (0x31C9AA2B ^ num))
						{
							num3 += 0x31C9AA2C ^ num;
							num2 = -835299878 + num;
						}
						if (num2 == (0x31C9AA28 ^ num))
						{
							goto IL_0160;
						}
						goto IL_019e;
					}
					return result;
				}
				goto IL_0154;
				IL_019e:
				if (num2 == (0x31C9AA2E ^ num))
				{
					num4 = 0x31C9AA2D ^ num;
					num2 = 835299889 - num;
				}
				if (num2 == (0x31C9AA2F ^ num))
				{
					array = methodbodies;
					num2 = 835299888 - num;
				}
				if (num2 == (0x31C9AA2C ^ num))
				{
					num3 = -779210694 + num + (-1599821086 - num) - (-1644395191 - num);
					num2 = 0x31C9AA2F ^ num;
				}
				if (num2 == -835299885 + num)
				{
					num2 = -835299884 + num;
				}
				if (num2 != 835299894 - num)
				{
					continue;
				}
				goto IL_0141;
				IL_0160:
				result = array[num4];
				num2 = -835299879 + num;
				goto IL_019e;
				IL_0141:
				num4 += -835299884 + num;
				goto IL_0154;
				IL_0154:
				if (num4 >= array.Length)
				{
					break;
				}
				goto IL_0160;
			}
			return null;
		}
	}
}
