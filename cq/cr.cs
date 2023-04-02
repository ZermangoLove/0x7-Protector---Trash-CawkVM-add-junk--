using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace cq
{
	internal static class cr
	{
		public class AntiDebug
		{
			internal delegate int hJ();

			internal delegate int hK(IntPtr hProcess, ref int pbDebuggerPresent);

			internal delegate int hL(IntPtr wnd, IntPtr lParam);

			internal delegate int hM(hL lpEnumFunc, IntPtr lParam);

			[DllImport("kernel32.dll")]
			internal static extern int CloseHandle(IntPtr hModule);

			[DllImport("kernel32.dll")]
			internal static extern IntPtr OpenProcess(uint hModule, int procName, uint procId);

			[DllImport("kernel32.dll")]
			internal static extern uint GetCurrentProcessId();

			[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
			internal static extern IntPtr LoadLibrary(string hModule);

			[DllImport("kernel32.dll", CharSet = CharSet.Ansi)]
			internal static extern hJ GetProcAddress(IntPtr hModule, string procName);

			[DllImport("kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GetProcAddress")]
			internal static extern hK GetProcAddress_1(IntPtr hModule, string procName);

			[DllImport("kernel32.dll", CharSet = CharSet.Ansi, EntryPoint = "GetProcAddress")]
			internal static extern hM GetProcAddress_2(IntPtr hModule, string procName);

			public static void Initialize()
			{
				if (gQ())
				{
					Environment.Exit(0);
				}
			}

			internal static bool gQ()
			{
				new object();
				try
				{
					IntPtr hModule = LoadLibrary("kernel32.dll");
					if (Debugger.IsAttached)
					{
						return true;
					}
					hJ procAddress = GetProcAddress(hModule, "IsDebuggerPresent");
					if (procAddress != null && procAddress() != 0)
					{
						return true;
					}
					IntPtr intPtr = OpenProcess(1024u, 0, GetCurrentProcessId());
					if (intPtr != IntPtr.Zero)
					{
						try
						{
							hK procAddress_ = GetProcAddress_1(hModule, "CheckRemoteDebuggerPresent");
							if (procAddress_ != null)
							{
								int pbDebuggerPresent = 0;
								if (procAddress_(intPtr, ref pbDebuggerPresent) != 0 && pbDebuggerPresent != 0)
								{
									return true;
								}
							}
						}
						finally
						{
							CloseHandle(intPtr);
						}
					}
					bool flag = false;
					try
					{
						CloseHandle(new IntPtr(305419896));
					}
					catch
					{
						flag = true;
					}
					if (flag)
					{
						return true;
					}
				}
				catch
				{
				}
				return false;
			}
		}
	}
}
