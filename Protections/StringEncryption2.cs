using System;
using System.Collections.Generic;
using System.Text;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using Helpers.Injection;
using ICore;

namespace Protections
{
	public class StringEncryption2
	{
		public static void Execute(Context context)
		{
			Injector injector = new Injector(context.Module, typeof(ExtractStrings));
			MethodDef method = injector.FindMember("Extraction") as MethodDef;
			Injector injector2 = new Injector(context.Module, typeof(StringDecoder));
			MethodDef method2 = injector2.FindMember("Decryption") as MethodDef;
			foreach (TypeDef type in context.Module.Types)
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
					for (int i = 0; i < method3.Body.Instructions.Count; i++)
					{
						if (method3.Body.Instructions[i].OpCode == OpCodes.Ldstr)
						{
							int length = method3.Name.Length;
							string operand = StringEncoder.Encryption(new Tuple<string, int>(method3.Body.Instructions[i].Operand.ToString(), length));
							method3.Body.Instructions[i].OpCode = OpCodes.Ldstr;
							method3.Body.Instructions[i].Operand = operand;
							method3.Body.Instructions.Insert(i + 1, OpCodes.Ldc_I4.ToInstruction(length));
							method3.Body.Instructions.Insert(i + 2, OpCodes.Ldnull.ToInstruction());
							method3.Body.Instructions.Insert(i + 3, OpCodes.Call.ToInstruction(method2));
							i += 3;
						}
					}
				}
				injector.Rename();
				injector2.Rename();
			}
			foreach (TypeDef type2 in context.Module.GetTypes())
			{
				foreach (MethodDef method4 in type2.Methods)
				{
					if (!method4.HasBody || method4.Body == null)
					{
						continue;
					}
					IList<Instruction> instructions = method4.Body.Instructions;
					for (int j = 0; j < instructions.Count; j++)
					{
						if (method4.Body.Instructions[j].OpCode == OpCodes.Ldstr)
						{
							string text = Utils.GenerateString();
							byte[] bytes = Encoding.UTF8.GetBytes(method4.Body.Instructions[j].Operand.ToString());
							context.Module.Resources.Add(new EmbeddedResource(text, bytes));
							method4.Body.Instructions[j].Operand = text;
							method4.Body.Instructions.Insert(j + 1, Instruction.Create(OpCodes.Call, method));
						}
					}
				}
			}
		}
	}
}
