using System.Collections.Generic;
using System.IO;
using System.Text;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using Helpers.Injection;
using ICore;
using Protections.Runtime;

namespace Protections
{
	public class StringEncryption
	{
		public static void Execute(Context context)
		{
			ModuleDefMD module = context.Module;
			MemoryStream memoryStream = new MemoryStream();
			BinaryWriter binaryWriter = new BinaryWriter(memoryStream);
			Injector injector = new Injector(module, typeof(StringEncryptionRuntime));
			MethodDef method = injector.FindMember("Initialize") as MethodDef;
			MethodDef method2 = injector.FindMember("Decrypt") as MethodDef;
			MethodDef methodDef = context.Module.GlobalType.FindOrCreateStaticConstructor();
			binaryWriter.Write(Utils.RandomByteArr(Utils.RandomSmallInt32()));
			foreach (TypeDef type in module.GetTypes())
			{
				if (type.IsGlobalModuleType || type.Namespace == "Costura")
				{
					continue;
				}
				foreach (MethodDef method3 in type.Methods)
				{
					if (!method3.HasBody || !method3.Body.HasInstructions)
					{
						continue;
					}
					method3.Body.SimplifyMacros(method3.Parameters);
					method3.Body.SimplifyBranches();
					IList<Instruction> instructions = method3.Body.Instructions;
					for (int i = 0; i < instructions.Count; i++)
					{
						if (instructions[i].OpCode == OpCodes.Ldstr && instructions[i].OpCode == OpCodes.Ldstr)
						{
							FieldDefUser fieldDefUser = Utils.CreateField(new FieldSig(module.CorLibTypes.String));
							module.GlobalType.Fields.Add(fieldDefUser);
							string text = instructions[i].Operand.ToString();
							int value = (int)binaryWriter.BaseStream.Position;
							int length = text.Length;
							byte[] bytes = Encoding.UTF8.GetBytes(text);
							binaryWriter.Write(length);
							binaryWriter.Write(bytes);
							binaryWriter.Write(Utils.RandomByteArr(Utils.RandomInt32()));
							instructions[i].OpCode = OpCodes.Ldsfld;
							instructions[i].Operand = fieldDefUser;
							methodDef.Body.Instructions.Insert(0, OpCodes.Ldc_I4.ToInstruction(value));
							methodDef.Body.Instructions.Insert(1, OpCodes.Ldnull.ToInstruction());
							methodDef.Body.Instructions.Insert(2, OpCodes.Call.ToInstruction(method2));
							methodDef.Body.Instructions.Insert(3, OpCodes.Stsfld.ToInstruction(fieldDefUser));
						}
					}
				}
			}
			string text2 = Utils.GenerateString();
			EmbeddedResource item = new EmbeddedResource(text2, memoryStream.ToArray());
			module.Resources.Add(item);
			methodDef = context.Module.GlobalType.FindOrCreateStaticConstructor();
			methodDef.Body.Instructions.Insert(0, OpCodes.Ldstr.ToInstruction(text2));
			methodDef.Body.Instructions.Insert(1, OpCodes.Call.ToInstruction(method));
			injector.Rename();
		}
	}
}
