using System.Collections.Generic;
using System.Management;

namespace LEncoder
{
	public static class HWID
	{
		public static string GetSerial()
		{
			try
			{
				ManagementObjectCollection instances = new ManagementClass("Win32_DiskDrive").GetInstances();
				string empty = string.Empty;
				List<string> list = new List<string>(instances.Count);
				foreach (ManagementObject item in instances)
				{
					try
					{
						if (item["InterfaceType"].ToString().Replace(" ", string.Empty) == "USB")
						{
							continue;
						}
					}
					catch
					{
					}
					try
					{
						empty = item["SerialNumber"].ToString().Replace(" ", string.Empty);
						list.Add(empty);
						if (item["DeviceID"].ToString().Replace(" ", string.Empty).Contains("0") && !string.IsNullOrWhiteSpace(empty))
						{
							return empty;
						}
					}
					catch
					{
					}
				}
				empty = list[0];
				if (!string.IsNullOrWhiteSpace(empty))
				{
					return empty;
				}
			}
			catch
			{
			}
			return string.Empty;
		}
	}
}
