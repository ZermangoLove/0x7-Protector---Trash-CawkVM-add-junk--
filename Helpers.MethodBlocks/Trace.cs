using System;
using System.Collections.Generic;
using dnlib.DotNet.Emit;

namespace Helpers.MethodBlocks
{
	public struct Trace
	{
		public Dictionary<uint, int> RefCount;

		public Dictionary<uint, List<Instruction>> BrRefs;

		public Dictionary<uint, int> BeforeStack;

		public Dictionary<uint, int> AfterStack;

		private static void ea(Dictionary<uint, int> counts, uint key)
		{
			if (!counts.TryGetValue(key, out var value))
			{
				value = 0;
			}
			counts[key] = value + 1;
		}

		public Trace(CilBody body, bool hasReturnValue)
		{
			RefCount = new Dictionary<uint, int>();
			BrRefs = new Dictionary<uint, List<Instruction>>();
			BeforeStack = new Dictionary<uint, int>();
			AfterStack = new Dictionary<uint, int>();
			body.UpdateInstructionOffsets();
			foreach (ExceptionHandler exceptionHandler in body.ExceptionHandlers)
			{
				BeforeStack[exceptionHandler.TryStart.Offset] = 0;
				BeforeStack[exceptionHandler.HandlerStart.Offset] = ((exceptionHandler.HandlerType != ExceptionHandlerType.Finally) ? 1 : 0);
				if (exceptionHandler.FilterStart != null)
				{
					BeforeStack[exceptionHandler.FilterStart.Offset] = 1;
				}
			}
			int stack = 0;
			for (int i = 0; i < body.Instructions.Count; i++)
			{
				Instruction instruction = body.Instructions[i];
				if (BeforeStack.ContainsKey(instruction.Offset))
				{
					stack = BeforeStack[instruction.Offset];
				}
				BeforeStack[instruction.Offset] = stack;
				instruction.UpdateStack(ref stack, hasReturnValue);
				AfterStack[instruction.Offset] = stack;
				switch (instruction.OpCode.FlowControl)
				{
				case FlowControl.Branch:
				{
					uint offset = ((Instruction)instruction.Operand).Offset;
					if (!BeforeStack.ContainsKey(offset))
					{
						BeforeStack[offset] = stack;
					}
					ea(RefCount, offset);
					BrRefs.AddListEntry(offset, instruction);
					stack = 0;
					break;
				}
				case FlowControl.Call:
					if (instruction.OpCode.Code == Code.Jmp)
					{
						stack = 0;
					}
					goto case FlowControl.Break;
				case FlowControl.Cond_Branch:
					if (instruction.OpCode.Code == Code.Switch)
					{
						Instruction[] array = (Instruction[])instruction.Operand;
						foreach (Instruction instruction2 in array)
						{
							if (!BeforeStack.ContainsKey(instruction2.Offset))
							{
								BeforeStack[instruction2.Offset] = stack;
							}
							ea(RefCount, instruction2.Offset);
							BrRefs.AddListEntry(instruction2.Offset, instruction);
						}
					}
					else
					{
						uint offset = ((Instruction)instruction.Operand).Offset;
						if (!BeforeStack.ContainsKey(offset))
						{
							BeforeStack[offset] = stack;
						}
						ea(RefCount, offset);
						BrRefs.AddListEntry(offset, instruction);
					}
					goto case FlowControl.Break;
				case FlowControl.Break:
				case FlowControl.Meta:
				case FlowControl.Next:
					if (i + 1 < body.Instructions.Count)
					{
						uint offset = body.Instructions[i + 1].Offset;
						ea(RefCount, offset);
					}
					break;
				case FlowControl.Return:
				case FlowControl.Throw:
					break;
				default:
					throw new NotSupportedException();
				}
			}
		}

		public bool IsBranchTarget(uint offset)
		{
			if (BrRefs.TryGetValue(offset, out var value))
			{
				return value.Count > 0;
			}
			return false;
		}

		public bool HasMultipleSources(uint offset)
		{
			if (RefCount.TryGetValue(offset, out var value))
			{
				return value > 1;
			}
			return false;
		}
	}
}
