using System.Collections.Generic;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using ICore;

namespace aY
{
	internal class bg
	{
		public static void ag(Context context)
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
					IList<Instruction> instructions = method.Body.Instructions;
					for (int i = 0; i < instructions.Count; i++)
					{
						if (instructions[i].OpCode == OpCodes.Ldstr)
						{
							MethodDef methodDef = new MethodDefUser(Utils.GenerateString(), MethodSig.CreateStatic(method.DeclaringType.Module.CorLibTypes.String), MethodImplAttributes.NoInlining | MethodImplAttributes.NoOptimization, MethodAttributes.Public | MethodAttributes.Static | MethodAttributes.HideBySig)
							{
								Body = new CilBody()
							};
							context.Module.GlobalType.Methods.Add(methodDef);
							methodDef.Body = new CilBody();
							methodDef.Body.Variables.Add(new Local(context.Module.CorLibTypes.String));
							methodDef.Body.Instructions.Add(Instruction.Create(OpCodes.Ldstr, instructions[i].Operand.ToString()));
							methodDef.Body.Instructions.Add(Instruction.Create(OpCodes.Ret));
							instructions[i].OpCode = OpCodes.Call;
							instructions[i].Operand = methodDef;
						}
					}
				}
			}
		}
	}
}
