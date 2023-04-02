using System;
using System.Collections.Generic;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Helpers.Injection
{
	public static class DataInjector
	{
		public static void InjectByteArr(byte[] bytes, MethodDef target, FieldDef field, int i = 0)
		{
			ModuleDef module = target.Module;
			IList<Instruction> instructions = target.Body.Instructions;
			int num = 2;
			instructions.Insert(i, OpCodes.Ldc_I4.ToInstruction(bytes.Length));
			instructions.Insert(i + 1, OpCodes.Newarr.ToInstruction(module.CorLibTypes.Byte));
			instructions.Insert(i + 2, OpCodes.Dup.ToInstruction());
			for (int j = 0; j < bytes.Length; j++)
			{
				int value = Convert.ToInt32(bytes[j]);
				instructions.Insert(i + ++num, OpCodes.Ldc_I4.ToInstruction(j));
				instructions.Insert(i + ++num, OpCodes.Ldc_I4.ToInstruction(value));
				instructions.Insert(i + ++num, OpCodes.Stelem_I1.ToInstruction());
				instructions.Insert(i + ++num, OpCodes.Dup.ToInstruction());
			}
			instructions.Insert(i + ++num, OpCodes.Pop.ToInstruction());
			instructions.Insert(i + num, OpCodes.Stsfld.ToInstruction(field));
		}
	}
}
