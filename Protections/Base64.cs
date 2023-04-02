using System;
using System.Text;
using aY;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using ICore;

namespace Protections
{
	public class Base64
	{
		public static void FAC(MethodDef method)
		{
			for (int i = 0; i < method.Body.Instructions.Count; i++)
			{
				if (method.Body.Instructions[i].OpCode == OpCodes.Ldstr)
				{
					string operand = be.bf(method.Body.Instructions[i].Operand.ToString());
					method.Body.Instructions[i].OpCode = OpCodes.Nop;
					method.Body.Instructions.Insert(i + 1, new Instruction(OpCodes.Call, method.Module.Import(typeof(Encoding).GetMethod("get_UTF8", new Type[0]))));
					method.Body.Instructions.Insert(i + 2, new Instruction(OpCodes.Ldstr, operand));
					method.Body.Instructions.Insert(i + 3, new Instruction(OpCodes.Call, method.Module.Import(typeof(Convert).GetMethod("FromBase64String", new Type[1] { typeof(string) }))));
					method.Body.Instructions.Insert(i + 4, new Instruction(OpCodes.Callvirt, method.Module.Import(typeof(Encoding).GetMethod("GetString", new Type[1] { typeof(byte[]) }))));
					i += 4;
				}
			}
		}

		public static void Execute(Context context)
		{
			foreach (TypeDef type in context.Module.GetTypes())
			{
				if (type.IsGlobalModuleType || type.Namespace == "Costura")
				{
					continue;
				}
				foreach (MethodDef method in type.Methods)
				{
					if (!method.HasBody || !method.Body.HasInstructions)
					{
						continue;
					}
					method.Body.SimplifyMacros(method.Parameters);
					method.Body.SimplifyBranches();
					for (int i = 0; i < method.Body.Instructions.Count; i++)
					{
						if (method.Body.Instructions[i].OpCode == OpCodes.Ldstr)
						{
							string operand = be.bf(method.Body.Instructions[i].Operand.ToString());
							method.Body.Instructions[i].OpCode = OpCodes.Nop;
							method.Body.Instructions.Insert(i + 1, new Instruction(OpCodes.Call, method.Module.Import(typeof(Encoding).GetMethod("get_UTF8", new Type[0]))));
							method.Body.Instructions.Insert(i + 2, new Instruction(OpCodes.Ldstr, operand));
							method.Body.Instructions.Insert(i + 3, new Instruction(OpCodes.Call, method.Module.Import(typeof(Convert).GetMethod("FromBase64String", new Type[1] { typeof(string) }))));
							method.Body.Instructions.Insert(i + 4, new Instruction(OpCodes.Callvirt, method.Module.Import(typeof(Encoding).GetMethod("GetString", new Type[1] { typeof(byte[]) }))));
							i += 4;
						}
					}
				}
			}
		}
	}
}
