using System;
using System.Collections.Generic;
using System.Text;
using bW;

namespace Protections.Xor
{
	public class EncryptionService
	{
		private readonly List<byte> bQ;

		private readonly int bR;

		private int _index;

		public int Index => _index ^ bR;

		public uint Length => (uint)bQ.Count;

		public byte[] Data => bQ.ToArray();

		public EncryptionService()
		{
			bQ = new List<byte>();
			bR = bV.bX(int.MaxValue);
			bQ.AddRange(BitConverter.GetBytes(bR));
			_index = 4;
		}

		public void Encrypt(string input)
		{
			if (_index <= 0)
			{
				throw new ArgumentOutOfRangeException("_index");
			}
			int key;
			byte[] array = bS(Encoding.UTF8.GetBytes(input), out key);
			byte[] array2 = new byte[8];
			BitConverter.GetBytes(array.Length).CopyTo(array2, 0);
			BitConverter.GetBytes(key).CopyTo(array2, 4);
			_index = bQ.Count;
			bQ.AddRange(array2);
			bQ.AddRange(array);
		}

		private byte[] bS(byte[] data, out int key)
		{
			key = bV.bX(int.MaxValue);
			int num = data.Length - 1;
			int num2 = 0;
			while (num2 < num)
			{
				data[num2] ^= data[num];
				data[num] ^= (byte)(data[num2] ^ key);
				data[num2] ^= data[num];
				num2++;
				num--;
			}
			if (data.Length % 2 != 0)
			{
				data[data.Length >> 1] ^= (byte)key;
			}
			return data;
		}
	}
}
