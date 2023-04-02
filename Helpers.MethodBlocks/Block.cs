using System.Collections.Generic;
using System.Linq;
using dnlib.DotNet.Emit;

namespace Helpers.MethodBlocks
{
	public class Block
	{
		public List<Instruction> Instructions;

		public bool IsSafe;

		public bool IsBranched;

		public bool IsException;

		public List<int> Values;

		public Block(Instruction[] Instructions, bool IsException = false, bool IsSafe = true, bool IsBranched = false, int initValue = -1)
		{
			this.Instructions = Instructions.ToList();
			this.IsSafe = IsSafe;
			this.IsBranched = IsBranched;
			this.IsException = IsException;
			Values = new List<int> { initValue };
		}

		public static Block Clone(Block block, bool all = false)
		{
			List<Instruction> list = new List<Instruction>();
			foreach (Instruction instruction2 in block.Instructions)
			{
				Instruction instruction = new Instruction();
				instruction.OpCode = instruction2.OpCode;
				instruction.Operand = instruction2.Operand;
				list.Add(instruction);
				if (!all && instruction2.OpCode == OpCodes.Stloc_S)
				{
					break;
				}
			}
			return new Block(list.ToArray(), block.IsException, block.IsSafe, block.IsBranched);
		}
	}
}
