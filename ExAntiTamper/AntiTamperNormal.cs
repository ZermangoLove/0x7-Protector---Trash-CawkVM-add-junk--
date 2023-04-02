using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using aw;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using dnlib.DotNet.Writer;
using ExAntiTamper.Stuffs;
using ICore;

namespace ExAntiTamper
{
	public class AntiTamperNormal
	{
		private static uint c;

		private static aB ah;

		private static List<MethodDef> ai;

		private static uint aj;

		private static uint ak;

		private static RandomGenerator al;

		private static uint am;

		private static uint an;

		private static uint ao;

		public void AntiTamper(Context ctx)
		{
			al = new RandomGenerator("NUL", Guid.NewGuid().ToString());
			ao = al.NextUInt32();
			an = al.NextUInt32();
			c = al.NextUInt32();
			am = al.NextUInt32();
			aj = al.NextUInt32() & 0x7F7F7F7Fu;
			ak = al.NextUInt32() & 0x7F7F7F7Fu;
			ah = new aL();
			ah.Init();
			ai = (from x in ctx.Module.GetTypes().SelectMany((TypeDef sd) => sd.Methods).ToList()
				where x.HasBody && x.DeclaringType != x.Module.GlobalType
				select x).ToList();
			IEnumerable<IDnlibDef> source = InjectHelper.Inject(AssemblyDef.Load(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\EM.dll").ManifestModule.Find("Runtime.AntiTamperNormal", isReflectionName: false), ctx.Module.GlobalType, ctx.Module);
			MethodDef methodDef = source.OfType<MethodDef>().Single((MethodDef method) => method.Name == "Initialize");
			MethodDef methodDef2 = source.OfType<MethodDef>().Single((MethodDef method) => method.Name == "Detection");
			methodDef.Body.SimplifyMacros(methodDef.Parameters);
			List<Instruction> list = methodDef.Body.Instructions.ToList();
			for (int i = 0; i < list.Count; i++)
			{
				Instruction instruction = list[i];
				if (instruction.OpCode == OpCodes.Ldtoken)
				{
					instruction.Operand = ctx.Module.GlobalType;
				}
				else if (instruction.OpCode == OpCodes.Call)
				{
					IMethod method2 = (IMethod)instruction.Operand;
					if (method2.DeclaringType.Name == "Mutation" && method2.Name == "Crypt")
					{
						Instruction instruction2 = list[i - 2];
						Instruction instruction3 = list[i - 1];
						list.RemoveAt(i);
						list.RemoveAt(i - 1);
						list.RemoveAt(i - 2);
						list.InsertRange(i - 2, ah.aC(methodDef, (Local)instruction2.Operand, (Local)instruction3.Operand));
					}
				}
			}
			methodDef.Body.Instructions.Clear();
			foreach (Instruction item in list)
			{
				methodDef.Body.Instructions.Add(item);
			}
			MutationHelper.InjectKeys(methodDef, new int[5] { 0, 1, 2, 3, 4 }, new int[5]
			{
				(int)(aj * ak),
				(int)ao,
				(int)an,
				(int)c,
				(int)am
			});
			MethodDef methodDef3 = ctx.Module.GlobalType.FindOrCreateStaticConstructor();
			methodDef3.Body.Instructions.Insert(0, OpCodes.Ldnull.ToInstruction());
			methodDef3.Body.Instructions.Insert(1, new Instruction(OpCodes.Ldc_I4_1, true));
			methodDef3.Body.Instructions.Insert(2, Instruction.Create(OpCodes.Call, methodDef));
			methodDef.Name = ICore.Utils.GenerateString();
			methodDef2.Name = ICore.Utils.GenerateString();
		}

		private void ap(object sender, ModuleWriterEventArgs e)
		{
			switch (e.Event)
			{
			case ModuleWriterEvent.BeginStrongNameSign:
				EncryptSection(e.Writer);
				break;
			case ModuleWriterEvent.MDEndCreateTables:
				CreateSections(e.Writer);
				break;
			}
		}

		public void CreateSections(ModuleWriterBase writer)
		{
			byte[] bytes = new byte[8]
			{
				(byte)aj,
				(byte)(aj >> 8),
				(byte)(aj >> 16),
				(byte)(aj >> 24),
				(byte)ak,
				(byte)(ak >> 8),
				(byte)(ak >> 16),
				(byte)(ak >> 24)
			};
			PESection pESection = new PESection(Encoding.ASCII.GetString(bytes), 3758096448u);
			writer.Sections.Insert(0, pESection);
			uint value = writer.TextSection.Remove(writer.Metadata).Value;
			writer.TextSection.Add(writer.Metadata, value);
			value = writer.TextSection.Remove(writer.NetResources).Value;
			writer.TextSection.Add(writer.NetResources, value);
			value = writer.TextSection.Remove(writer.Constants).Value;
			pESection.Add(writer.Constants, value);
			PESection pESection2 = new PESection("NUL", 1610612768u);
			bool flag = false;
			if (writer.StrongNameSignature != null)
			{
				value = writer.TextSection.Remove(writer.StrongNameSignature).Value;
				pESection2.Add(writer.StrongNameSignature, value);
				flag = true;
			}
			if (writer is ModuleWriter moduleWriter)
			{
				if (moduleWriter.ImportAddressTable != null)
				{
					value = writer.TextSection.Remove(moduleWriter.ImportAddressTable).Value;
					pESection2.Add(moduleWriter.ImportAddressTable, value);
					flag = true;
				}
				if (moduleWriter.StartupStub != null)
				{
					value = writer.TextSection.Remove(moduleWriter.StartupStub).Value;
					pESection2.Add(moduleWriter.StartupStub, value);
					flag = true;
				}
			}
			if (flag)
			{
				writer.Sections.ax(pESection2);
			}
			MethodBodyChunks methodBodyChunks = new MethodBodyChunks(writer.TheOptions.ShareMethodBodies);
			pESection.Add(methodBodyChunks, 4u);
			foreach (MethodDef item in ai)
			{
				if (item.HasBody)
				{
					dnlib.DotNet.Writer.MethodBody methodBody = writer.Metadata.GetMethodBody(item);
					writer.MethodBodies.Remove(methodBody);
					methodBodyChunks.Add(methodBody);
				}
			}
			pESection.Add(new ByteArrayChunk(new byte[4]), 4u);
		}

		public void EncryptSection(ModuleWriterBase writer)
		{
			Stream destinationStream = writer.DestinationStream;
			BinaryReader binaryReader = new BinaryReader(writer.DestinationStream);
			destinationStream.Position = 60L;
			destinationStream.Position = binaryReader.ReadUInt32();
			destinationStream.Position += 6L;
			ushort num = binaryReader.ReadUInt16();
			destinationStream.Position += 12L;
			ushort num2 = binaryReader.ReadUInt16();
			destinationStream.Position += 2 + num2;
			uint num3 = 0u;
			uint num4 = 0u;
			int num5 = -1;
			if (writer is NativeModuleWriter && writer.Module is ModuleDefMD)
			{
				num5 = ((ModuleDefMD)writer.Module).Metadata.PEImage.ImageSectionHeaders.Count;
			}
			for (int i = 0; i < num; i++)
			{
				uint num6;
				if (num5 > 0)
				{
					num5--;
					destinationStream.Write(new byte[8], 0, 8);
					num6 = 0u;
				}
				else
				{
					num6 = binaryReader.ReadUInt32() * binaryReader.ReadUInt32();
				}
				destinationStream.Position += 8L;
				if (num6 == aj * ak)
				{
					num4 = binaryReader.ReadUInt32();
					num3 = binaryReader.ReadUInt32();
				}
				else if (num6 != 0)
				{
					uint size = binaryReader.ReadUInt32();
					uint offset = binaryReader.ReadUInt32();
					aq(destinationStream, binaryReader, offset, size);
				}
				else
				{
					destinationStream.Position += 8L;
				}
				destinationStream.Position += 16L;
			}
			uint[] array = ar();
			num4 >>= 2;
			destinationStream.Position = num3;
			uint[] array2 = new uint[num4];
			for (uint num7 = 0u; num7 < num4; num7++)
			{
				uint num8 = binaryReader.ReadUInt32();
				array2[num7] = num8 ^ array[num7 & 0xF];
				array[num7 & 0xF] = (array[num7 & 0xF] ^ num8) + 1035675673;
			}
			byte[] array3 = new byte[num4 << 2];
			Buffer.BlockCopy(array2, 0, array3, 0, array3.Length);
			destinationStream.Position = num3;
			destinationStream.Write(array3, 0, array3.Length);
		}

		private static void aq(Stream stream, BinaryReader reader, uint offset, uint size)
		{
			long position = stream.Position;
			stream.Position = offset;
			size >>= 2;
			for (uint num = 0u; num < size; num++)
			{
				uint num2 = reader.ReadUInt32();
				uint num3 = (ao ^ num2) + an + c * am;
				ao = an;
				an = c;
				an = am;
				am = num3;
			}
			stream.Position = position;
		}

		private static uint[] ar()
		{
			uint[] array = new uint[16];
			uint[] array2 = new uint[16];
			for (int i = 0; i < 16; i++)
			{
				array[i] = am;
				array2[i] = an;
				ao = (an >> 5) | (an << 27);
				an = (c >> 3) | (c << 29);
				c = (am >> 7) | (am << 25);
				am = (ao >> 11) | (ao << 21);
			}
			return ah.ar(array, array2);
		}
	}
}
