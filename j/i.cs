using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace j
{
	internal class i
	{
		private static List<string> k = new List<string>();

		public static Random l = new Random();

		private static string m(string input)
		{
			StringBuilder stringBuilder = new StringBuilder();
			byte[] array = new MD5CryptoServiceProvider().ComputeHash(new UTF8Encoding().GetBytes(input));
			for (int j = 0; j < array.Length; j++)
			{
				stringBuilder.Append(array[j].ToString("x2"));
			}
			return stringBuilder.ToString();
		}

		private static char n()
		{
			int num = new Random().Next(0, 25);
			return (char)(97 + num);
		}

		private static bool o(string stringToCheck)
		{
			if (k.Contains(stringToCheck))
			{
				return true;
			}
			return false;
		}

		public static string p()
		{
			string text;
			do
			{
				text = m(p(new Random().Next(2, 24)));
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

		public static string p(int size)
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

		public static string q(int size)
		{
			char[] array = "_".ToCharArray();
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

		public static string r(int size)
		{
			char[] array = "|".ToCharArray();
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

		public static string s(int size)
		{
			char[] array = "\\/".ToCharArray();
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

		public static string t(int size)
		{
			char[] array = "0123456789".ToCharArray();
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

		public static string u(int size)
		{
			char[] array = "!@#$%^&*()_+=[]{}<>\\/".ToCharArray();
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
	}
}
