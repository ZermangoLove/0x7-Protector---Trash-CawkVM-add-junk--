using System;
using System.Runtime.InteropServices;

namespace cq
{
	internal static class cs
	{
		[DllImport("kernel32.dll")]
		private unsafe static extern bool VirtualProtect(byte* lpAddress, int dwSize, uint flNewProtect, out uint lpflOldProtect);

		private unsafe static void Initialize()
		{
			new object();
			byte* ptr = (byte*)(void*)Marshal.GetHINSTANCE(typeof(cs).Module);
			byte* ptr2 = ptr + 60;
			ptr2 = ptr + (uint)(*(int*)ptr2);
			ptr2 += 6;
			ushort num = *(ushort*)ptr2;
			ptr2 += 14;
			ushort num2 = *(ushort*)ptr2;
			ptr2 = ptr2 + 4 + (int)num2;
			VirtualProtect(ptr2 - 16, 8, 64u, out var lpflOldProtect);
			*(int*)(ptr2 - 12) = 0;
			byte* ptr3 = ptr + (uint)(*(int*)(ptr2 - 16));
			*(int*)(ptr2 - 16) = 0;
			VirtualProtect(ptr3, 72, 64u, out lpflOldProtect);
			byte* intPtr = ptr + (uint)(*(int*)(ptr3 + 8));
			*(int*)ptr3 = 0;
			*(int*)(ptr3 + 4) = 0;
			*(int*)(ptr3 + 2L * 4L) = 0;
			*(int*)(ptr3 + 3L * 4L) = 0;
			VirtualProtect(intPtr, 4, 64u, out lpflOldProtect);
			*(int*)intPtr = 0;
			for (int i = 0; i < num; i++)
			{
				VirtualProtect(ptr2, 8, 64u, out lpflOldProtect);
				Marshal.Copy(new byte[8], 0, (IntPtr)ptr2, 8);
				ptr2 += 40;
			}
		}
	}
}
