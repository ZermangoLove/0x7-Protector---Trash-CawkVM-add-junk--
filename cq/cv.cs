using System;
using System.Diagnostics;
using System.Management;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace cq
{
	internal static class cv
	{
		[DllImport("kernel32.dll")]
		internal static extern IntPtr GetModuleHandle(string x);

		[DllImport("kernel32.dll")]
		internal static extern IntPtr GetProcAddress(IntPtr a, string b);

		[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		internal static extern uint GetFileAttributes(string d);

		private static void Initialize()
		{
			if (cA())
			{
				cz("START CMD /C \"ECHO VirtualMachine Detected ! && PAUSE\" ");
				Process.GetCurrentProcess().Kill();
			}
		}

		internal static void cz(string A_0)
		{
			Process.Start(new ProcessStartInfo("cmd.exe", "/c " + A_0)
			{
				CreateNoWindow = true,
				UseShellExecute = false
			});
		}

		internal static bool cA()
		{
			if (cB("HARDWARE\\DEVICEMAP\\Scsi\\Scsi Port 0\\Scsi Bus 0\\Target Id 0\\Logical Unit Id 0", "Identifier").ToUpper().Contains("VBOX"))
			{
				return true;
			}
			if (cB("HARDWARE\\Description\\System", "SystemBiosVersion").ToUpper().Contains("VBOX"))
			{
				return true;
			}
			if (cB("HARDWARE\\Description\\System", "VideoBiosVersion").ToUpper().Contains("VIRTUALBOX"))
			{
				return true;
			}
			if (cB("SOFTWARE\\Oracle\\VirtualBox Guest Additions", "") == "noValueButYesKey")
			{
				return true;
			}
			if (GetFileAttributes("C:\\WINDOWS\\system32\\drivers\\VBoxMouse.sys") != uint.MaxValue)
			{
				return true;
			}
			if (cB("HARDWARE\\DEVICEMAP\\Scsi\\Scsi Port 0\\Scsi Bus 0\\Target Id 0\\Logical Unit Id 0", "Identifier").ToUpper().Contains("VMWARE"))
			{
				return true;
			}
			if (cB("SOFTWARE\\VMware, Inc.\\VMware Tools", "") == "noValueButYesKey")
			{
				return true;
			}
			if (cB("HARDWARE\\DEVICEMAP\\Scsi\\Scsi Port 1\\Scsi Bus 0\\Target Id 0\\Logical Unit Id 0", "Identifier").ToUpper().Contains("VMWARE"))
			{
				return true;
			}
			if (cB("HARDWARE\\DEVICEMAP\\Scsi\\Scsi Port 2\\Scsi Bus 0\\Target Id 0\\Logical Unit Id 0", "Identifier").ToUpper().Contains("VMWARE"))
			{
				return true;
			}
			if (cB("SYSTEM\\ControlSet001\\Services\\Disk\\Enum", "0").ToUpper().Contains("vmware".ToUpper()))
			{
				return true;
			}
			if (cB("SYSTEM\\ControlSet001\\Control\\Class\\{4D36E968-E325-11CE-BFC1-08002BE10318}\\0000", "DriverDesc").ToUpper().Contains("VMWARE"))
			{
				return true;
			}
			if (cB("SYSTEM\\ControlSet001\\Control\\Class\\{4D36E968-E325-11CE-BFC1-08002BE10318}\\0000\\Settings", "Device Description").ToUpper().Contains("VMWARE"))
			{
				return true;
			}
			if (cB("SOFTWARE\\VMware, Inc.\\VMware Tools", "InstallPath").ToUpper().Contains("C:\\PROGRAM FILES\\VMWARE\\VMWARE TOOLS\\"))
			{
				return true;
			}
			if (GetFileAttributes("C:\\WINDOWS\\system32\\drivers\\vmmouse.sys") != uint.MaxValue)
			{
				return true;
			}
			if (GetFileAttributes("C:\\WINDOWS\\system32\\drivers\\vmhgfs.sys") != uint.MaxValue)
			{
				return true;
			}
			if (GetProcAddress(GetModuleHandle("kernel32.dll"), "wine_get_unix_file_name") != (IntPtr)0)
			{
				return true;
			}
			if (cB("HARDWARE\\DEVICEMAP\\Scsi\\Scsi Port 0\\Scsi Bus 0\\Target Id 0\\Logical Unit Id 0", "Identifier").ToUpper().Contains("QEMU"))
			{
				return true;
			}
			if (cB("HARDWARE\\Description\\System", "SystemBiosVersion").ToUpper().Contains("QEMU"))
			{
				return true;
			}
			ManagementScope scope = new ManagementScope("\\\\.\\ROOT\\cimv2");
			ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_VideoController");
			foreach (ManagementObject item in new ManagementObjectSearcher(scope, query).Get())
			{
				if (!(item["Description"].ToString() == "VM Additions S3 Trio32/64"))
				{
					if (!(item["Description"].ToString() == "S3 Trio32/64"))
					{
						if (!(item["Description"].ToString() == "VirtualBox Graphics Adapter"))
						{
							if (!(item["Description"].ToString() == "VMware SVGA II"))
							{
								if (!item["Description"].ToString().ToUpper().Contains("VMWARE"))
								{
									if (item["Description"].ToString() == "")
									{
										return true;
									}
									continue;
								}
								return true;
							}
							return true;
						}
						return true;
					}
					return true;
				}
				return true;
			}
			return false;
		}

		internal static string cB(string A_0, string A_1)
		{
			RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(A_0, writable: false);
			if (registryKey != null)
			{
				object value = registryKey.GetValue(A_1, "noValueButYesKey");
				if (!(value.GetType() == typeof(string)))
				{
					if (registryKey.GetValueKind(A_1) != RegistryValueKind.String && registryKey.GetValueKind(A_1) != RegistryValueKind.ExpandString)
					{
						if (registryKey.GetValueKind(A_1) == RegistryValueKind.DWord)
						{
							return Convert.ToString((int)value);
						}
						if (registryKey.GetValueKind(A_1) == RegistryValueKind.QWord)
						{
							return Convert.ToString((long)value);
						}
						if (registryKey.GetValueKind(A_1) == RegistryValueKind.Binary)
						{
							return Convert.ToString((byte[])value);
						}
						if (registryKey.GetValueKind(A_1) == RegistryValueKind.MultiString)
						{
							return string.Join("", (string[])value);
						}
						return "noValueButYesKey";
					}
					return value.ToString();
				}
				return value.ToString();
			}
			return "noKey";
		}
	}
}
