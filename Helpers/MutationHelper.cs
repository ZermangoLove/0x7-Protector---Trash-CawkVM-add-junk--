using System.Collections.Generic;
using System.Runtime.CompilerServices;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Helpers
{
	public class MutationHelper
	{
		public class Block
		{
			[CompilerGenerated]
			private List<Instruction> ds;

			[CompilerGenerated]
			private int dt;

			[CompilerGenerated]
			private int du;

			public List<Instruction> Instructions
			{
				[CompilerGenerated]
				get
				{
					return ds;
				}
				[CompilerGenerated]
				set
				{
					ds = value;
				}
			}

			public int Number
			{
				[CompilerGenerated]
				get
				{
					return dt;
				}
				[CompilerGenerated]
				set
				{
					dt = value;
				}
			}

			public int Next
			{
				[CompilerGenerated]
				get
				{
					return du;
				}
				[CompilerGenerated]
				set
				{
					du = value;
				}
			}

			public Block()
			{
				Instructions = new List<Instruction>();
			}
		}

		public static bool CanObfuscate(IList<Instruction> instructions, int i)
		{
			if (instructions[i + 1].GetOperand() != null && instructions[i + 1].Operand.ToString().Contains("bool"))
			{
				return false;
			}
			if (instructions[i + 1].GetOpCode() == OpCodes.Newobj)
			{
				return false;
			}
			return instructions[i].GetLdcI4Value() != 0 && instructions[i].GetLdcI4Value() != 1;
		}

		public static List<Block> ParseMethod(MethodDef method)
		{
			List<Block> list = new List<Block>();
			new List<Instruction>(method.Body.Instructions);
			Block block = new Block();
			int num = 0;
			int num2 = 0;
			block.Number = 0;
			block.Instructions.Add(Instruction.Create(OpCodes.Nop));
			list.Add(block);
			block = new Block();
			Stack<ExceptionHandler> stack = new Stack<ExceptionHandler>();
			foreach (Instruction instruction in method.Body.Instructions)
			{
				foreach (ExceptionHandler exceptionHandler in method.Body.ExceptionHandlers)
				{
					if (exceptionHandler.HandlerStart == instruction || exceptionHandler.TryStart == instruction || exceptionHandler.FilterStart == instruction)
					{
						stack.Push(exceptionHandler);
					}
				}
				foreach (ExceptionHandler exceptionHandler2 in method.Body.ExceptionHandlers)
				{
					if (exceptionHandler2.HandlerEnd == instruction || exceptionHandler2.TryEnd == instruction)
					{
						stack.Pop();
					}
				}
				instruction.CalculateStackUsage(out var pushes, out var pops);
				block.Instructions.Add(instruction);
				num2 += pushes - pops;
				if (pushes == 0 && instruction.OpCode != OpCodes.Nop && (num2 == 0 || instruction.OpCode == OpCodes.Ret) && stack.Count == 0)
				{
					int num4 = (block.Number = num + 1);
					num = num4;
					list.Add(block);
					block = new Block();
				}
			}
			return list;
		}
	}
}
