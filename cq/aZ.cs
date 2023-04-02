using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace cq
{
	internal static class aZ
	{
		[DllImport("kernel32.dll")]
		private unsafe static extern bool VirtualProtect(byte* lpAddress, int dwSize, uint flNewProtect, out uint lpflOldProtect);

		private unsafe static void Initialize()
		{
			Module module = typeof(aZ).Module;
			byte* ptr = (byte*)(void*)Marshal.GetHINSTANCE(module);
			byte* ptr2 = ptr + 60;
			ptr2 = ptr + (uint)(*(int*)ptr2);
			ptr2 += 6;
			ushort num = *(ushort*)ptr2;
			ptr2 += 14;
			ushort num2 = *(ushort*)ptr2;
			ptr2 = ptr2 + 4 + (int)num2;
			byte* ptr3 = stackalloc byte[11];
			uint lpflOldProtect;
			if (module.FullyQualifiedName[0] != '<')
			{
				VirtualProtect(ptr2 - 16, 8, 64u, out lpflOldProtect);
				*(int*)(ptr2 - 12) = 0;
				byte* ptr4 = ptr + (uint)(*(int*)(ptr2 - 16));
				*(int*)(ptr2 - 16) = 0;
				if (*(uint*)(ptr2 - 120) != 0)
				{
					byte* ptr5 = ptr + (uint)(*(int*)(ptr2 - 120));
					byte* ptr6 = ptr + (uint)(*(int*)ptr5);
					byte* ptr7 = ptr + (uint)(*(int*)(ptr5 + 12));
					byte* ptr8 = ptr + (uint)(*(int*)ptr6) + 2;
					VirtualProtect(ptr7, 11, 64u, out lpflOldProtect);
					*(int*)ptr3 = 1818522734;
					*(int*)(ptr3 + 4) = 1818504812;
					*(short*)(ptr3 + 4L * 2L) = 108;
					ptr3[10] = 0;
					for (int i = 0; i < 11; i++)
					{
						ptr7[i] = ptr3[i];
					}
					VirtualProtect(ptr8, 11, 64u, out lpflOldProtect);
					*(int*)ptr3 = 1866691662;
					*(int*)(ptr3 + 4) = 1852404846;
					*(short*)(ptr3 + 4L * 2L) = 25973;
					ptr3[10] = 0;
					for (int j = 0; j < 11; j++)
					{
						ptr8[j] = ptr3[j];
					}
				}
				for (int k = 0; k < num; k++)
				{
					VirtualProtect(ptr2, 8, 64u, out lpflOldProtect);
					Marshal.Copy(new byte[8], 0, (IntPtr)ptr2, 8);
					ptr2 += 40;
				}
				VirtualProtect(ptr4, 72, 64u, out lpflOldProtect);
				byte* ptr9 = ptr + (uint)(*(int*)(ptr4 + 8));
				*(int*)ptr4 = 0;
				*(int*)(ptr4 + 4) = 0;
				*(int*)(ptr4 + 2L * 4L) = 0;
				*(int*)(ptr4 + 3L * 4L) = 0;
				VirtualProtect(ptr9, 4, 64u, out lpflOldProtect);
				*(int*)ptr9 = 0;
				ptr9 += 12;
				ptr9 += (uint)(*(int*)ptr9);
				ptr9 = (byte*)(((ulong)ptr9 + 7uL) & 0xFFFFFFFFFFFFFFFCuL);
				ptr9 += 2;
				ushort num3 = *ptr9;
				ptr9 += 2;
				for (int l = 0; l < num3; l++)
				{
					VirtualProtect(ptr9, 8, 64u, out lpflOldProtect);
					*(int*)ptr9 = 0;
					ptr9 += 4;
					ptr9 += 4;
					for (int m = 0; m < 8; m++)
					{
						VirtualProtect(ptr9, 4, 64u, out lpflOldProtect);
						*ptr9 = 0;
						ptr9++;
						if (*ptr9 != 0)
						{
							*ptr9 = 0;
							ptr9++;
							if (*ptr9 != 0)
							{
								*ptr9 = 0;
								ptr9++;
								if (*ptr9 != 0)
								{
									*ptr9 = 0;
									ptr9++;
									continue;
								}
								ptr9++;
								break;
							}
							ptr9 += 2;
							break;
						}
						ptr9 += 3;
						break;
					}
				}
				return;
			}
			VirtualProtect(ptr2 - 16, 8, 64u, out lpflOldProtect);
			*(int*)(ptr2 - 12) = 0;
			uint num4 = *(uint*)(ptr2 - 16);
			*(int*)(ptr2 - 16) = 0;
			uint num5 = *(uint*)(ptr2 - 120);
			uint[] array = new uint[num];
			uint[] array2 = new uint[num];
			uint[] array3 = new uint[num];
			for (int n = 0; n < num; n++)
			{
				VirtualProtect(ptr2, 8, 64u, out lpflOldProtect);
				Marshal.Copy(new byte[8], 0, (IntPtr)ptr2, 8);
				array[n] = *(uint*)(ptr2 + 12);
				array2[n] = *(uint*)(ptr2 + 8);
				array3[n] = *(uint*)(ptr2 + 20);
				ptr2 += 40;
			}
			if (num5 != 0)
			{
				for (int num6 = 0; num6 < num; num6++)
				{
					if (array[num6] <= num5 && num5 < array[num6] + array2[num6])
					{
						num5 = num5 - array[num6] + array3[num6];
						break;
					}
				}
				byte* ptr10 = ptr + num5;
				uint num7 = *(uint*)ptr10;
				for (int num8 = 0; num8 < num; num8++)
				{
					if (array[num8] <= num7 && num7 < array[num8] + array2[num8])
					{
						num7 = num7 - array[num8] + array3[num8];
						break;
					}
				}
				byte* ptr11 = ptr + num7;
				uint num9 = *(uint*)(ptr10 + 12);
				for (int num10 = 0; num10 < num; num10++)
				{
					if (array[num10] <= num9 && num9 < array[num10] + array2[num10])
					{
						num9 = num9 - array[num10] + array3[num10];
						break;
					}
				}
				uint num11 = *(uint*)ptr11 + 2;
				for (int num12 = 0; num12 < num; num12++)
				{
					if (array[num12] <= num11 && num11 < array[num12] + array2[num12])
					{
						num11 = num11 - array[num12] + array3[num12];
						break;
					}
				}
				VirtualProtect(ptr + num9, 11, 64u, out lpflOldProtect);
				*(int*)ptr3 = 1818522734;
				*(int*)(ptr3 + 4) = 1818504812;
				*(short*)(ptr3 + 4L * 2L) = 108;
				ptr3[10] = 0;
				for (int num13 = 0; num13 < 11; num13++)
				{
					(ptr + num9)[num13] = ptr3[num13];
				}
				VirtualProtect(ptr + num11, 11, 64u, out lpflOldProtect);
				*(int*)ptr3 = 1866691662;
				*(int*)(ptr3 + 4) = 1852404846;
				*(short*)(ptr3 + 4L * 2L) = 25973;
				ptr3[10] = 0;
				for (int num14 = 0; num14 < 11; num14++)
				{
					(ptr + num11)[num14] = ptr3[num14];
				}
			}
			for (int num15 = 0; num15 < num; num15++)
			{
				if (array[num15] <= num4 && num4 < array[num15] + array2[num15])
				{
					num4 = num4 - array[num15] + array3[num15];
					break;
				}
			}
			byte* ptr12 = ptr + num4;
			VirtualProtect(ptr12, 72, 64u, out lpflOldProtect);
			uint num16 = *(uint*)(ptr12 + 8);
			for (int num17 = 0; num17 < num; num17++)
			{
				if (array[num17] <= num16 && num16 < array[num17] + array2[num17])
				{
					num16 = num16 - array[num17] + array3[num17];
					break;
				}
			}
			*(int*)ptr12 = 0;
			*(int*)(ptr12 + 4) = 0;
			*(int*)(ptr12 + 2L * 4L) = 0;
			*(int*)(ptr12 + 3L * 4L) = 0;
			byte* ptr13 = ptr + num16;
			VirtualProtect(ptr13, 4, 64u, out lpflOldProtect);
			*(int*)ptr13 = 0;
			ptr13 += 12;
			ptr13 += (uint)(*(int*)ptr13);
			ptr13 = (byte*)(((ulong)ptr13 + 7uL) & 0xFFFFFFFFFFFFFFFCuL);
			ptr13 += 2;
			ushort num18 = *ptr13;
			ptr13 += 2;
			for (int num19 = 0; num19 < num18; num19++)
			{
				VirtualProtect(ptr13, 8, 64u, out lpflOldProtect);
				*(int*)ptr13 = 0;
				ptr13 += 4;
				*(int*)ptr13 = 0;
				ptr13 += 4;
				for (int num20 = 0; num20 < 8; num20++)
				{
					VirtualProtect(ptr13, 4, 64u, out lpflOldProtect);
					*ptr13 = 0;
					ptr13++;
					if (*ptr13 != 0)
					{
						*ptr13 = 0;
						ptr13++;
						if (*ptr13 != 0)
						{
							*ptr13 = 0;
							ptr13++;
							if (*ptr13 != 0)
							{
								*ptr13 = 0;
								ptr13++;
								continue;
							}
							ptr13++;
							break;
						}
						ptr13 += 2;
						break;
					}
					ptr13 += 3;
					break;
				}
			}
		}
	}
}
