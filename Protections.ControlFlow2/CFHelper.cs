using System;
using System.Collections.Generic;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using ICore;

namespace Protections.ControlFlow2
{
	public class CFHelper
	{
		public bool HasUnsafeInstructions(MethodDef methodDef)
		{
			if (methodDef.HasBody && methodDef.Body.HasVariables)
			{
				return methodDef.Body.Variables.Any((Local x) => x.Type.IsPointer);
			}
			return false;
		}

		public Blocks GetBlocks(MethodDef method)
		{
			Blocks blocks = new Blocks();
			Block block = new Block();
			int num = 0;
			int num2 = 0;
			foreach (Instruction instruction in method.Body.Instructions)
			{
				int pops = 0;
				instruction.CalculateStackUsage(out var pushes, out pops);
				block.instructions.Add(instruction);
				num2 += pushes - pops;
				if (pushes == 0 && instruction.OpCode != OpCodes.Nop && (num2 == 0 || instruction.OpCode == OpCodes.Ret))
				{
					block.ID = num;
					num++;
					block.nextBlock = block.ID + 1;
					blocks.blocks.Add(block);
					block = new Block();
				}
			}
			return blocks;
		}

		public List<Instruction> Calc(int value)
		{
			List<Instruction> list = new List<Instruction>();
			int num = Utils.RandomInt32() ^ Utils.RandomInt32();
			bool flag = Convert.ToBoolean(Utils.RandomInt32() ^ Utils.RandomInt32());
			int num2 = Utils.RandomInt32() ^ Utils.RandomInt32();
			list.Add(Instruction.Create(OpCodes.Ldc_I4, value - num + (flag ? (-num2) : num2)));
			list.Add(Instruction.Create(OpCodes.Ldc_I4, num));
			list.Add(Instruction.Create(OpCodes.Add));
			list.Add(Instruction.Create(OpCodes.Ldc_I4, num2));
			list.Add(Instruction.Create(flag ? OpCodes.Add : OpCodes.Sub));
			return list;
		}
	}
}
