using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace Core.ByteEncryption
{
	internal class ByteEncryption
	{
		[DllImport("NativeEncoderx86.dll")]
		public static extern void ModifiedXOR(byte[] data, int dataLen, byte[] key, int keyLen);

		public static byte[] Encrypt(byte[] key, byte[] message)
		{
			int num = 1432280208;
			int num2 = 1;
			RijndaelManaged rijndaelManaged = default(RijndaelManaged);
			do
			{
				if (num2 == (0x555EDC91 ^ num))
				{
					rijndaelManaged = new RijndaelManaged();
					num2 = 1432280210 - num;
				}
				if (num2 == 1432280208 - num)
				{
					num2 = -1432280207 + num;
				}
			}
			while (num2 != (0x555EDC92 ^ num));
			try
			{
				rijndaelManaged.Key = key;
				rijndaelManaged.IV = key;
				return EncryptBytes(rijndaelManaged, message);
			}
			finally
			{
				((IDisposable)rijndaelManaged)?.Dispose();
			}
		}

		private static byte[] EncryptBytes(SymmetricAlgorithm alg, byte[] message)
		{
			int num = 1247809356;
			int num2 = 1;
			while (true)
			{
				if (num2 == -1247809355 + num)
				{
					if (message == null)
					{
						goto IL_00b3;
					}
					num2 = 0x4A600F4E ^ num;
				}
				if (num2 == (0x4A600F4E ^ num))
				{
					if (message.Length != 0)
					{
						break;
					}
					num2 = 1247809359 - num;
				}
				if (num2 != -1247809353 + num)
				{
					if (num2 == -1247809356 + num)
					{
						num2 = 1247809357 - num;
					}
					if (num2 == -1247809352 + num)
					{
						break;
					}
					continue;
				}
				goto IL_00b3;
				IL_00b3:
				return message;
			}
			if (alg == null)
			{
				throw new ArgumentNullException("ALG is null");
			}
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (ICryptoTransform transform = alg.CreateEncryptor())
				{
					using (CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, (CryptoStreamMode)(0x4A600F4D ^ num)))
					{
						cryptoStream.Write(message, 1247809356 - num, message.Length);
						cryptoStream.FlushFinalBlock();
						return memoryStream.ToArray();
					}
				}
			}
		}

		private static byte[] DecryptBytes(SymmetricAlgorithm alg, byte[] message)
		{
			int num = 1326017159;
			int num2 = 1;
			while (true)
			{
				if (num2 == (0x4F096A86 ^ num))
				{
					if (message == null)
					{
						goto IL_00b3;
					}
					num2 = 1326017161 - num;
				}
				if (num2 == -1326017157 + num)
				{
					if (message.Length != 0)
					{
						break;
					}
					num2 = -1326017156 + num;
				}
				if (num2 != -1326017156 + num)
				{
					if (num2 == 1326017159 - num)
					{
						num2 = 0x4F096A86 ^ num;
					}
					if (num2 == (0x4F096A83 ^ num))
					{
						break;
					}
					continue;
				}
				goto IL_00b3;
				IL_00b3:
				return message;
			}
			if (alg == null)
			{
				throw new ArgumentNullException("alg is null");
			}
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (ICryptoTransform transform = alg.CreateDecryptor())
				{
					using (CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, (CryptoStreamMode)(1326017160 - num)))
					{
						cryptoStream.Write(message, 0x4F096A87 ^ num, message.Length);
						cryptoStream.FlushFinalBlock();
						return memoryStream.ToArray();
					}
				}
			}
		}

		public static byte[] Decrypt(byte[] key, byte[] message)
		{
			int num = 1204621434;
			int num2 = 1;
			RijndaelManaged rijndaelManaged = default(RijndaelManaged);
			do
			{
				if (num2 == (0x47CD107B ^ num))
				{
					rijndaelManaged = new RijndaelManaged();
					num2 = 1204621436 - num;
				}
				if (num2 == (0x47CD107A ^ num))
				{
					num2 = 1204621435 - num;
				}
			}
			while (num2 != -1204621432 + num);
			try
			{
				rijndaelManaged.Key = key;
				rijndaelManaged.IV = key;
				return DecryptBytes(rijndaelManaged, message);
			}
			finally
			{
				((IDisposable)rijndaelManaged)?.Dispose();
			}
		}
	}
}
