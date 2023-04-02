using System.Collections.Generic;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using ICore;

namespace Protections
{
	public class LocalToField
	{
		public static void Execute1(Context context)
		{
			ModuleDefMD module = context.Module;
			IList<Instruction> instructions = module.GlobalType.FindOrCreateStaticConstructor().Body.Instructions;
			foreach (TypeDef type in module.GetTypes())
			{
				if (type.IsGlobalModuleType)
				{
					continue;
				}
				foreach (MethodDef method in type.Methods)
				{
					if (!method.HasBody || !method.Body.HasInstructions)
					{
						continue;
					}
					IList<Instruction> instructions2 = method.Body.Instructions;
					if (instructions2.Any((Instruction x) => x.IsLdcI4()))
					{
						Instruction instruction = instructions2.First((Instruction x) => x.IsLdcI4());
						int ldcI4Value = instruction.GetLdcI4Value();
						FieldDefUser fieldDefUser = Utils.CreateField(new FieldSig(module.CorLibTypes.Int32));
						module.GlobalType.Fields.Add(fieldDefUser);
						instructions.Insert(0, OpCodes.Ldc_I4.ToInstruction(ldcI4Value));
						instructions.Insert(1, OpCodes.Stsfld.ToInstruction(fieldDefUser));
						instruction.OpCode = OpCodes.Ldsfld;
						instruction.Operand = fieldDefUser;
					}
				}
			}
		}
	}
}
