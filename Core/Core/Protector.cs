using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Core.ByteEncryption;
using Core.Properties;
using Core.Protection;
using dnlib.DotNet;
using dnlib.DotNet.Writer;
using ICore;

namespace Core
{
	public class Protector
	{
		public static string path2;

		public static ModuleDefMD moduleDefMD { get; private set; }

		public static string name { get; private set; }

		public static byte[] Protect(byte[] assemblyData)
		{
			int num = 1108816741;
			int num2 = 1;
			byte[] nativeEncoderx = default(byte[]);
			EmbeddedResource item = default(EmbeddedResource);
			EmbeddedResource item2 = default(EmbeddedResource);
			byte[] data = default(byte[]);
			EmbeddedResource item3 = default(EmbeddedResource);
			EmbeddedResource item4 = default(EmbeddedResource);
			ModuleWriterOptions moduleWriterOptions = default(ModuleWriterOptions);
			MemoryStream memoryStream = default(MemoryStream);
			do
			{
				if (num2 == 1108816742 - num)
				{
					Console.WriteLine("");
					num2 = 1108816743 - num;
				}
				if (num2 == -1108816739 + num)
				{
					Console.WriteLine("");
					num2 = -1108816738 + num;
				}
				if (num2 == (0x42173366 ^ num))
				{
					Console.ForegroundColor = (ConsoleColor)(-1108816729 + num);
					num2 = 0x42173361 ^ num;
				}
				if (num2 == (0x42173361 ^ num))
				{
					Console.WriteLine("     -> IVM ( Dynamic methods VM )");
					num2 = -1108816736 + num;
				}
				if (num2 == -1108816736 + num)
				{
					Console.WriteLine("");
					num2 = 1108816747 - num;
				}
				if (num2 == -1108816735 + num)
				{
					name = Xor.XorProcess(Utils.GenerateString(), "IVM");
					num2 = 0x42173362 ^ num;
				}
				if (num2 == -1108816733 + num)
				{
					asmRefAdder();
					num2 = 0x4217336C ^ num;
				}
				if (num2 == (0x4217336C ^ num))
				{
					Console.ForegroundColor = (ConsoleColor)(-1108816727 + num);
					num2 = 0x4217336F ^ num;
				}
				if (num2 == (0x4217336F ^ num))
				{
					Console.WriteLine("     -> Processing");
					num2 = 1108816752 - num;
				}
				if (num2 == (0x4217336E ^ num))
				{
					MethodProccesor.ModuleProcessor();
					num2 = -1108816729 + num;
				}
				if (num2 == 1108816753 - num)
				{
					Console.ForegroundColor = (ConsoleColor)(1108816743 - num);
					num2 = -1108816728 + num;
				}
				if (num2 == -1108816728 + num)
				{
					Console.WriteLine("     -> Passes Processing");
					num2 = -1108816727 + num;
				}
				if (num2 == (0x4217336A ^ num))
				{
					Console.ForegroundColor = (ConsoleColor)(-1108816731 + num);
					num2 = -1108816725 + num;
				}
				if (num2 == 1108816757 - num)
				{
					nativeEncoderx = Resources.NativeEncoderx86;
					num2 = 0x42173374 ^ num;
				}
				if (num2 == -1108816724 + num)
				{
					item = new EmbeddedResource("I\u001f\u0004*q\u0011", nativeEncoderx, (ManifestResourceAttributes)(1108816743 - num));
					num2 = -1108816723 + num;
				}
				if (num2 == 1108816759 - num)
				{
					moduleDefMD.Resources.Add(item);
					num2 = 1108816760 - num;
				}
				if (num2 == 1108816760 - num)
				{
					item2 = new EmbeddedResource("I\u001f\u0004*\u007f\u001d", Resources.NativeEncoderx64, (ManifestResourceAttributes)(0x42173367u ^ (uint)num));
					num2 = 0x42173371 ^ num;
				}
				if (num2 == (0x42173371 ^ num))
				{
					moduleDefMD.Resources.Add(item2);
					num2 = 0x42173370 ^ num;
				}
				if (num2 == 1108816762 - num)
				{
					data = File.ReadAllBytes(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Runtime.dll"));
					num2 = 0x42173373 ^ num;
				}
				if (num2 == (0x42173372 ^ num))
				{
					moduleDefMD.Resources.Add(item3);
					num2 = 0x4217337D ^ num;
				}
				if (num2 == (0x4217337D ^ num))
				{
					item4 = new EmbeddedResource("I=ni", Resources.XorMethod, (ManifestResourceAttributes)(0x42173367u ^ (uint)num));
					num2 = 0x4217337C ^ num;
				}
				if (num2 == 1108816766 - num)
				{
					moduleDefMD.Resources.Add(item4);
					num2 = 1108816767 - num;
				}
				if (num2 == (0x4217337F ^ num))
				{
					moduleWriterOptions = new ModuleWriterOptions(moduleDefMD);
					num2 = 1108816768 - num;
				}
				if (num2 == 1108816768 - num)
				{
					moduleWriterOptions.MetadataOptions.Flags = (MetadataFlags)((-1085314813 ^ num) + (-1326304230 - num) - (0x2E25E879 ^ num));
					num2 = 1108816769 - num;
				}
				if (num2 == (0x42173379 ^ num))
				{
					moduleWriterOptions.MetadataLogger = DummyLogger.NoThrowInstance;
					num2 = 1108816770 - num;
				}
				if (num2 == (0x4217337B ^ num))
				{
					moduleDefMD.Write(memoryStream, moduleWriterOptions);
					num2 = 0x4217337A ^ num;
				}
				if (num2 == 1108816772 - num)
				{
					Console.WriteLine("     -> Your file has been protected, Press enter to exit !");
					num2 = -1108816709 + num;
				}
				if (num2 == (0x42173345 ^ num))
				{
					Console.ReadLine();
					num2 = 0x42173344 ^ num;
				}
				if (num2 == (0x42173378 ^ num))
				{
					memoryStream = new MemoryStream();
					num2 = -1108816711 + num;
				}
				if (num2 == (0x42173373 ^ num))
				{
					item3 = new EmbeddedResource("R\u0006", data, (ManifestResourceAttributes)(1108816743 - num));
					num2 = 1108816764 - num;
				}
				if (num2 == (0x4217336B ^ num))
				{
					Console.WriteLine("");
					num2 = 0x4217336A ^ num;
				}
				if (num2 == -1108816734 + num)
				{
					moduleDefMD = ModuleDefMD.Load(assemblyData);
					num2 = 1108816749 - num;
				}
				if (num2 == (0x42173365 ^ num))
				{
					num2 = 0x42173364 ^ num;
				}
			}
			while (num2 != 1108816774 - num);
			return memoryStream.ToArray();
		}

		private static void asmRefAdder()
		{
			int num = 1766722331;
			int num2 = 1;
			AssemblyResolver assemblyResolver = default(AssemblyResolver);
			ModuleContext moduleContext = default(ModuleContext);
			List<AssemblyRef>.Enumerator enumerator = default(List<AssemblyRef>.Enumerator);
			do
			{
				if (num2 == 1766722332 - num)
				{
					assemblyResolver = new AssemblyResolver
					{
						EnableTypeDefCache = ((byte)(0x694E0B1Au ^ (uint)num) != 0)
					};
					num2 = -1766722329 + num;
				}
				if (num2 == -1766722329 + num)
				{
					moduleContext = new ModuleContext(assemblyResolver);
					num2 = 0x694E0B18 ^ num;
				}
				if (num2 == -1766722328 + num)
				{
					assemblyResolver.DefaultModuleContext = moduleContext;
					num2 = 1766722335 - num;
				}
				if (num2 == (0x694E0B1F ^ num))
				{
					List<AssemblyRef> list = moduleDefMD.GetAssemblyRefs().ToList();
					moduleDefMD.Context = moduleContext;
					enumerator = list.GetEnumerator();
					num2 = -1766722326 + num;
				}
				if (num2 == (0x694E0B1B ^ num))
				{
					num2 = -1766722330 + num;
				}
			}
			while (num2 != (0x694E0B1E ^ num));
			try
			{
				while (enumerator.MoveNext())
				{
					AssemblyRef current = enumerator.Current;
					try
					{
						if (current != null)
						{
							AssemblyDef assemblyDef = assemblyResolver.Resolve(current.FullName, moduleDefMD);
							if (assemblyDef != null)
							{
								moduleDefMD.Context.AssemblyResolver.Resolve(assemblyDef, moduleDefMD);
							}
						}
					}
					catch
					{
					}
				}
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
		}
	}
}
