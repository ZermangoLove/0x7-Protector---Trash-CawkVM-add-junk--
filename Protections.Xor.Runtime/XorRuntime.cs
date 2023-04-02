using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Protections.Xor.Runtime
{
	public static class XorRuntime
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private struct gI
		{
		}

		public unsafe static string Decrypt(int id, object obj)
		{
			new object();
			if (id >> 31 == 0)
			{
				byte* ptr = (byte*)1056;
				ptr += id ^ *(int*)ptr;
				byte[] array = new byte[*(int*)ptr];
				fixed (byte* ptr2 = &array[0])
				{
					void* destination = ptr2;
					XVM(destination, ptr + 8, (uint)array.Length);
				}
				int num = array.Length - 1;
				int num2 = 0;
				while (num2 < num)
				{
					array[num2] ^= array[num];
					array[num] ^= (byte)(array[num2] ^ *(int*)(ptr + 4));
					array[num2] ^= array[num];
					num2++;
					num--;
				}
				if (array.Length % 2 != 0)
				{
					array[array.Length >> 1] ^= (byte)(*(int*)(ptr + 4));
				}
				return string.Intern(Encoding.UTF8.GetString(array));
			}
			return string.Empty;
		}

		private unsafe static void XVM(void* destination, void* source, uint bytes)
		{
			throw new NotImplementedException();
		}
	}
}
