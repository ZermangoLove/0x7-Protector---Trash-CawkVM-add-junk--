using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace ExAntiTamper.Stuffs
{
	public static class Utils
	{
		private static readonly char[] aV = "0123456789abcdef".ToCharArray();

		public static TValue GetValueOrDefault<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue defValue = default(TValue))
		{
			if (dictionary.TryGetValue(key, out var value))
			{
				return value;
			}
			return defValue;
		}

		public static TValue GetValueOrDefaultLazy<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, Func<TKey, TValue> defValueFactory)
		{
			if (dictionary.TryGetValue(key, out var value))
			{
				return value;
			}
			return defValueFactory(key);
		}

		public static void AddListEntry<TKey, TValue>(this IDictionary<TKey, List<TValue>> self, TKey key, TValue value)
		{
			if (key == null)
			{
				throw new ArgumentNullException("key");
			}
			if (!self.TryGetValue(key, out var value2))
			{
				List<TValue> list2 = (self[key] = new List<TValue>());
				value2 = list2;
			}
			value2.Add(value);
		}

		public static string GetRelativePath(string fileSpec, string baseDirectory)
		{
			if (fileSpec == null)
			{
				throw new ArgumentNullException("fileSpec");
			}
			if (baseDirectory == null)
			{
				throw new ArgumentNullException("fileSpec");
			}
			return GetRelativePath(new FileInfo(fileSpec), new DirectoryInfo(baseDirectory));
		}

		public static string GetRelativePath(FileInfo fileSpec, DirectoryInfo baseDirectory)
		{
			if (fileSpec != null)
			{
				if (baseDirectory != null)
				{
					if (baseDirectory.FullName.EndsWith(Path.DirectorySeparatorChar.ToString()))
					{
						baseDirectory = new DirectoryInfo(baseDirectory.FullName.TrimEnd(Path.DirectorySeparatorChar));
					}
					string text = fileSpec.Name;
					DirectoryInfo directoryInfo = fileSpec.Directory;
					while (directoryInfo != null && !string.Equals(directoryInfo.FullName, baseDirectory.FullName, StringComparison.OrdinalIgnoreCase))
					{
						text = directoryInfo.Name + Path.DirectorySeparatorChar + text;
						directoryInfo = directoryInfo.Parent;
					}
					if (directoryInfo == null)
					{
						return null;
					}
					return text;
				}
				throw new ArgumentNullException("fileSpec");
			}
			throw new ArgumentNullException("fileSpec");
		}

		public static string NullIfEmpty(this string val)
		{
			if (string.IsNullOrEmpty(val))
			{
				return null;
			}
			return val;
		}

		public static byte[] SHA1(byte[] buffer)
		{
			return new SHA1Managed().ComputeHash(buffer);
		}

		public static byte[] Xor(byte[] buffer1, byte[] buffer2)
		{
			if (buffer1.Length != buffer2.Length)
			{
				throw new ArgumentException("Length mismatched.");
			}
			byte[] array = new byte[buffer1.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = (byte)(buffer1[i] ^ buffer2[i]);
			}
			return array;
		}

		public static byte[] SHA256(byte[] buffer)
		{
			return new SHA256Managed().ComputeHash(buffer);
		}

		public static string EncodeString(byte[] buff, char[] charset)
		{
			int num = buff[0];
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 1; i < buff.Length; i++)
			{
				num = (num << 8) + buff[i];
				while (num >= charset.Length)
				{
					num = Math.DivRem(num, charset.Length, out var result);
					stringBuilder.Append(charset[result]);
				}
			}
			if (num != 0)
			{
				stringBuilder.Append(charset[num % charset.Length]);
			}
			return stringBuilder.ToString();
		}

		public static string ToHexString(byte[] buff)
		{
			char[] array = new char[buff.Length * 2];
			int num = 0;
			foreach (byte b in buff)
			{
				array[num++] = aV[b >> 4];
				array[num++] = aV[b & 0xF];
			}
			return new string(array);
		}

		public static void RemoveWhere<T>(this IList<T> self, Predicate<T> match)
		{
			if (self is List<T> list)
			{
				list.RemoveAll(match);
				return;
			}
			for (int num = self.Count - 1; num >= 0; num--)
			{
				if (match(self[num]))
				{
					self.RemoveAt(num);
				}
			}
		}
	}
}
