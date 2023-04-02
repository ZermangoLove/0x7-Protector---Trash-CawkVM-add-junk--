using System;
using System.Collections.Generic;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using ICore;

namespace Protections
{
	public class IntMathProtection
	{
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
					if (method.HasBody && method.Body.HasInstructions)
					{
						DoIntMath(method);
					}
				}
			}
		}

		public static void DoIntMath(MethodDef method)
		{
			INTMHelper iNTMHelper = new INTMHelper();
			for (int i = 0; i < method.Body.Instructions.Count; i++)
			{
				Instruction instruction = method.Body.Instructions[i];
				if (!(instruction.Operand is int))
				{
					continue;
				}
				List<Instruction> list = iNTMHelper.Calc(Convert.ToInt32(instruction.Operand));
				instruction.OpCode = OpCodes.Nop;
				foreach (Instruction item in list)
				{
					method.Body.Instructions.Insert(i + 1, item);
					i++;
				}
			}
		}
	}
}
