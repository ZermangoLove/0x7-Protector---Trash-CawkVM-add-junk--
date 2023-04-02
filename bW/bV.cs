using System;
using System.Security.Cryptography;

namespace bW
{
	internal static class bV
	{
		internal static RNGCryptoServiceProvider bs = new RNGCryptoServiceProvider();

		internal static int bX(int maxValue)
		{
			byte[] array = new byte[4];
			int num;
			if ((maxValue & -maxValue) == maxValue)
			{
				bs.GetBytes(array);
				num = BitConverter.ToInt32(array, 0);
				return num & (maxValue - 1);
			}
			int num2;
			do
			{
				bs.GetBytes(array);
				num = BitConverter.ToInt32(array, 0) & 0x7FFFFFFF;
				num2 = num % maxValue;
			}
			while (num - num2 + (maxValue - 1) < 0);
			return num2;
		}
	}
}
