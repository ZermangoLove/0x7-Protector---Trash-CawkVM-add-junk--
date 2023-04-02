using System.Collections;
using System.Collections.Generic;
using dnlib.DotNet.Emit;

namespace Protections.ControlFlow
{
	public class ControlFlowGraph : IEnumerable<ControlFlowBlock>, IEnumerable
	{
		private readonly List<ControlFlowBlock> cN;

		private readonly CilBody cO;

		private readonly int[] cP;

		private readonly Dictionary<Instruction, int> cQ;

		public int Count => cN.Count;

		public ControlFlowBlock this[int id] => cN[id];

		public CilBody Body => cO;

		private ControlFlowGraph(CilBody body)
		{
			cO = body;
			cP = new int[body.Instructions.Count];
			cN = new List<ControlFlowBlock>();
			cQ = new Dictionary<Instruction, int>();
			for (int i = 0; i < body.Instructions.Count; i++)
			{
				cQ.Add(body.Instructions[i], i);
			}
		}

		IEnumerator<ControlFlowBlock> IEnumerable<ControlFlowBlock>.GetEnumerator()
		{
			return cN.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return cN.GetEnumerator();
		}

		public ControlFlowBlock GetContainingBlock(int instrIndex)
		{
			return cN[cP[instrIndex]];
		}

		public int IndexOf(Instruction instr)
		{
			return cQ[instr];
		}

		private void cR(HashSet<Instruction> blockHeaders, HashSet<Instruction> entryHeaders)
		{
			for (int i = 0; i < cO.Instructions.Count; i++)
			{
				Instruction instruction = cO.Instructions[i];
				if (instruction.Operand is Instruction)
				{
					blockHeaders.Add((Instruction)instruction.Operand);
					if (i + 1 < cO.Instructions.Count)
					{
						blockHeaders.Add(cO.Instructions[i + 1]);
					}
				}
				else if (instruction.Operand is Instruction[])
				{
					Instruction[] array = (Instruction[])instruction.Operand;
					foreach (Instruction item in array)
					{
						blockHeaders.Add(item);
					}
					if (i + 1 < cO.Instructions.Count)
					{
						blockHeaders.Add(cO.Instructions[i + 1]);
					}
				}
				else if ((instruction.OpCode.FlowControl == FlowControl.Throw || instruction.OpCode.FlowControl == FlowControl.Return) && i + 1 < cO.Instructions.Count)
				{
					blockHeaders.Add(cO.Instructions[i + 1]);
				}
			}
			blockHeaders.Add(cO.Instructions[0]);
			foreach (ExceptionHandler exceptionHandler in cO.ExceptionHandlers)
			{
				blockHeaders.Add(exceptionHandler.TryStart);
				blockHeaders.Add(exceptionHandler.HandlerStart);
				blockHeaders.Add(exceptionHandler.FilterStart);
				entryHeaders.Add(exceptionHandler.HandlerStart);
				entryHeaders.Add(exceptionHandler.FilterStart);
			}
		}

		private void cS(HashSet<Instruction> blockHeaders, HashSet<Instruction> entryHeaders)
		{
			int num = 0;
			int num2 = -1;
			Instruction instruction = null;
			for (int i = 0; i < cO.Instructions.Count; i++)
			{
				Instruction instruction2 = cO.Instructions[i];
				if (blockHeaders.Contains(instruction2))
				{
					if (instruction != null)
					{
						Instruction instruction3 = cO.Instructions[i - 1];
						ControlFlowBlockType controlFlowBlockType = ControlFlowBlockType.Normal;
						if (entryHeaders.Contains(instruction) || instruction == cO.Instructions[0])
						{
							controlFlowBlockType |= ControlFlowBlockType.Entry;
						}
						if (instruction3.OpCode.FlowControl == FlowControl.Return || instruction3.OpCode.FlowControl == FlowControl.Throw)
						{
							controlFlowBlockType |= ControlFlowBlockType.Exit;
						}
						cN.Add(new ControlFlowBlock(num2, controlFlowBlockType, instruction, instruction3));
					}
					num2 = num++;
					instruction = instruction2;
				}
				cP[i] = num2;
			}
			if (cN.Count == 0 || cN[cN.Count - 1].Id != num2)
			{
				Instruction instruction4 = cO.Instructions[cO.Instructions.Count - 1];
				ControlFlowBlockType controlFlowBlockType2 = ControlFlowBlockType.Normal;
				if (entryHeaders.Contains(instruction) || instruction == cO.Instructions[0])
				{
					controlFlowBlockType2 |= ControlFlowBlockType.Entry;
				}
				if (instruction4.OpCode.FlowControl == FlowControl.Return || instruction4.OpCode.FlowControl == FlowControl.Throw)
				{
					controlFlowBlockType2 |= ControlFlowBlockType.Exit;
				}
				cN.Add(new ControlFlowBlock(num2, controlFlowBlockType2, instruction, instruction4));
			}
		}

		private void cT()
		{
			for (int i = 0; i < cO.Instructions.Count; i++)
			{
				Instruction instruction = cO.Instructions[i];
				if (!(instruction.Operand is Instruction))
				{
					if (instruction.Operand is Instruction[])
					{
						Instruction[] array = (Instruction[])instruction.Operand;
						foreach (Instruction key in array)
						{
							ControlFlowBlock controlFlowBlock = cN[cP[i]];
							ControlFlowBlock controlFlowBlock2 = cN[cP[cQ[key]]];
							controlFlowBlock2.Sources.Add(controlFlowBlock);
							controlFlowBlock.Targets.Add(controlFlowBlock2);
						}
					}
				}
				else
				{
					ControlFlowBlock controlFlowBlock3 = cN[cP[i]];
					ControlFlowBlock controlFlowBlock4 = cN[cP[cQ[(Instruction)instruction.Operand]]];
					controlFlowBlock4.Sources.Add(controlFlowBlock3);
					controlFlowBlock3.Targets.Add(controlFlowBlock4);
				}
			}
			for (int k = 0; k < cN.Count; k++)
			{
				if (cN[k].Footer.OpCode.FlowControl != 0 && cN[k].Footer.OpCode.FlowControl != FlowControl.Return && cN[k].Footer.OpCode.FlowControl != FlowControl.Throw)
				{
					cN[k].Targets.Add(cN[k + 1]);
					cN[k + 1].Sources.Add(cN[k]);
				}
			}
		}

		public static ControlFlowGraph Construct(CilBody body)
		{
			ControlFlowGraph controlFlowGraph = new ControlFlowGraph(body);
			if (body.Instructions.Count == 0)
			{
				return controlFlowGraph;
			}
			HashSet<Instruction> blockHeaders = new HashSet<Instruction>();
			HashSet<Instruction> entryHeaders = new HashSet<Instruction>();
			controlFlowGraph.cR(blockHeaders, entryHeaders);
			controlFlowGraph.cS(blockHeaders, entryHeaders);
			controlFlowGraph.cT();
			return controlFlowGraph;
		}
	}
}
