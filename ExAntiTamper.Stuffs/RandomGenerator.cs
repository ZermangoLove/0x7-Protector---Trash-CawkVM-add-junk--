using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using dnlib.DotNet.Writer;

namespace ExAntiTamper.Stuffs
{
	public class RandomGenerator
	{
		private static readonly byte[] aM = new byte[7] { 7, 11, 23, 37, 43, 59, 71 };

		private readonly SHA256Managed aN = new SHA256Managed();

		private int aO;

		private byte[] aP;

		private int aQ;

		private readonly byte[] aR;

		[CompilerGenerated]
		private readonly string aS;

		public string SeedString
		{
			[CompilerGenerated]
			get
			{
				return aS;
			}
		}

		internal RandomGenerator(string id, string seed)
		{
			aS = (string.IsNullOrEmpty(seed) ? Guid.NewGuid().ToString() : seed);
			aR = aT(SeedString);
			if (string.IsNullOrEmpty(id))
			{
				throw new ArgumentNullException("id");
			}
			byte[] array = aR;
			byte[] array2 = Utils.SHA256(Encoding.UTF8.GetBytes(id));
			for (int i = 0; i < 32; i++)
			{
				array[i] ^= array2[i];
			}
			aP = (byte[])aR.Clone();
			aQ = 32;
			aO = 0;
		}

		internal static byte[] aT(string seed)
		{
			byte[] array = Utils.SHA256((!string.IsNullOrEmpty(seed)) ? Encoding.UTF8.GetBytes(seed) : Guid.NewGuid().ToByteArray());
			for (int i = 0; i < 32; i++)
			{
				array[i] *= aM[i % aM.Length];
				array = Utils.SHA256(array);
			}
			return array;
		}

		private void aU()
		{
			for (int i = 0; i < 32; i++)
			{
				aP[i] ^= aM[aO = (aO + 1) % aM.Length];
			}
			aP = aN.ComputeHash(aP);
			aQ = 32;
		}

		public void NextBytes(byte[] buffer, int offset, int length)
		{
			if (buffer != null)
			{
				if (offset >= 0)
				{
					if (length < 0)
					{
						throw new ArgumentOutOfRangeException("length");
					}
					if (buffer.Length - offset >= length)
					{
						while (length > 0)
						{
							if (length >= aQ)
							{
								Buffer.BlockCopy(aP, 32 - aQ, buffer, offset, aQ);
								offset += aQ;
								length -= aQ;
								aQ = 0;
							}
							else
							{
								Buffer.BlockCopy(aP, 32 - aQ, buffer, offset, length);
								aQ -= length;
								length = 0;
							}
							if (aQ == 0)
							{
								aU();
							}
						}
						return;
					}
					throw new ArgumentException("Invalid offset or length.");
				}
				throw new ArgumentOutOfRangeException("offset");
			}
			throw new ArgumentNullException("buffer");
		}

		public byte NextByte()
		{
			byte result = aP[32 - aQ];
			aQ--;
			if (aQ == 0)
			{
				aU();
			}
			return result;
		}

		public byte[] NextBytes(int length)
		{
			byte[] array = new byte[length];
			NextBytes(array, 0, length);
			return array;
		}

		public int NextInt32()
		{
			return BitConverter.ToInt32(NextBytes(4), 0);
		}

		public int NextInt32(int max)
		{
			return (int)((long)NextUInt32() % (long)max);
		}

		public int NextInt32(int min, int max)
		{
			if (max <= min)
			{
				return min;
			}
			return min + (int)((long)NextUInt32() % (long)(max - min));
		}

		public uint NextUInt32()
		{
			return BitConverter.ToUInt32(NextBytes(4), 0);
		}

		public uint NextUInt32(uint max)
		{
			return NextUInt32() % max;
		}

		public double NextDouble()
		{
			return (double)NextUInt32() / 4294967296.0;
		}

		public bool NextBoolean()
		{
			byte num = aP[32 - aQ];
			aQ--;
			if (aQ == 0)
			{
				aU();
			}
			return (int)num % 2 == 0;
		}

		public void Shuffle<T>(IList<T> list)
		{
			for (int num = list.Count - 1; num > 1; num--)
			{
				int index = NextInt32(num + 1);
				T value = list[index];
				list[index] = list[num];
				list[num] = value;
			}
		}

		public void Shuffle<T>(MDTable<T> table) where T : struct
		{
			if (!table.IsEmpty)
			{
				for (uint num = (uint)table.Rows; num > 2; num--)
				{
					uint rid = NextUInt32(num - 1) + 1;
					T value = table[rid];
					table[rid] = table[num];
					table[num] = value;
				}
			}
		}
	}
}
