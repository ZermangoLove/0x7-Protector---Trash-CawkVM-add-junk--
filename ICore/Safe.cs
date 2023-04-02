using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace ICore
{
	public static class Safe
	{
		private static List<string> k = new List<string>();

		public static string GenerateRandomString()
		{
			string text;
			do
			{
				text = m(p(Utils.RandomInt32()));
				if (char.IsDigit(text[0]))
				{
					char newChar = n();
					text = text.Replace(text[0], newChar);
				}
			}
			while (o(text));
			k.Add(text);
			return text;
		}

		private static string p(int size)
		{
			char[] array = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
			byte[] data = new byte[1];
			RNGCryptoServiceProvider rNGCryptoServiceProvider = new RNGCryptoServiceProvider();
			rNGCryptoServiceProvider.GetNonZeroBytes(data);
			data = new byte[size];
			rNGCryptoServiceProvider.GetNonZeroBytes(data);
			StringBuilder stringBuilder = new StringBuilder(size);
			byte[] array2 = data;
			foreach (byte b in array2)
			{
				stringBuilder.Append(array[(int)b % array.Length]);
			}
			return stringBuilder.ToString();
		}

		private static string m(string input)
		{
			StringBuilder stringBuilder = new StringBuilder();
			byte[] array = new MD5CryptoServiceProvider().ComputeHash(new UTF8Encoding().GetBytes(input));
			for (int i = 0; i < array.Length; i++)
			{
				stringBuilder.Append(array[i].ToString("X2"));
			}
			return stringBuilder.ToString();
		}

		private static char n()
		{
			int num = new Random().Next(0, 24);
			return (char)(65 + num);
		}

		private static bool o(string stringToCheck)
		{
			if (k.Contains(stringToCheck))
			{
				return true;
			}
			return false;
		}
	}
}
