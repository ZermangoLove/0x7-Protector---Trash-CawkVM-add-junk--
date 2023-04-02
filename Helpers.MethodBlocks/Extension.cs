using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using dZ;

namespace Helpers.MethodBlocks
{
	public static class Extension
	{
		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass0_0
		{
			public Trace trace;
		}

		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass0_1
		{
			public cK.ho block;

			public _003C_003Ec__DisplayClass0_0 CS_0024_003C_003E8__locals1;
		}

		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass0_2
		{
			public LinkedList<Instruction[]> statements;

			public _003C_003Ec__DisplayClass0_1 CS_0024_003C_003E8__locals2;

			public Func<Instruction, bool> _003C_003E9__6;

			internal bool _003CGetBlocks_003Eb__6(Instruction src)
			{
				if (src.Offset > statements.First.Value.Last().Offset)
				{
					return src.Offset >= CS_0024_003C_003E8__locals2.block.hr.Last().Offset;
				}
				return true;
			}
		}

		[CompilerGenerated]
		private sealed class _003C_003Ec__DisplayClass0_3
		{
			public HashSet<Instruction> statementLast;

			public _003C_003Ec__DisplayClass0_2 CS_0024_003C_003E8__locals3;

			public Func<Instruction, bool> _003C_003E9__7;

			internal bool method_0(IList<Instruction> instrs)
			{
				return instrs.Any(delegate(Instruction instr)
				{
					if (!CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.trace.HasMultipleSources(instr.Offset))
					{
						if (CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.trace.BrRefs.TryGetValue(instr.Offset, out var value))
						{
							if (value.Any((Instruction src) => src.Operand is Instruction[]))
							{
								return true;
							}
							if (value.Any((Instruction src) => src.Offset <= CS_0024_003C_003E8__locals3.statements.First.Value.Last().Offset || src.Offset >= CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.block.hr.Last().Offset))
							{
								return true;
							}
							if (value.Any((Instruction src) => statementLast.Contains(src)))
							{
								return true;
							}
						}
						return false;
					}
					return true;
				});
			}

			internal bool _003CGetBlocks_003Eb__4(Instruction instr)
			{
				if (!CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.trace.HasMultipleSources(instr.Offset))
				{
					if (CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.trace.BrRefs.TryGetValue(instr.Offset, out var value))
					{
						if (value.Any((Instruction src) => src.Operand is Instruction[]))
						{
							return true;
						}
						if (value.Any((Instruction src) => src.Offset <= CS_0024_003C_003E8__locals3.statements.First.Value.Last().Offset || src.Offset >= CS_0024_003C_003E8__locals3.CS_0024_003C_003E8__locals2.block.hr.Last().Offset))
						{
							return true;
						}
						if (value.Any((Instruction src) => statementLast.Contains(src)))
						{
							return true;
						}
					}
					return false;
				}
				return true;
			}

			internal bool _003CGetBlocks_003Eb__7(Instruction src)
			{
				return statementLast.Contains(src);
			}
		}

		public static List<Block> GetBlocks(this MethodDef method)
		{
			_003C_003Ec__DisplayClass0_0 _003C_003Ec__DisplayClass0_ = new _003C_003Ec__DisplayClass0_0();
			List<Block> list = new List<Block>();
			CilBody body = method.Body;
			body.SimplifyBranches();
			cK.hd scope = cK.cM(body);
			List<Instruction> list2 = new List<Instruction>();
			IList<ExceptionHandler> exceptionHandlers = method.Body.ExceptionHandlers;
			int num = 0;
			_003C_003Ec__DisplayClass0_.trace = new Trace(body, method.ReturnType.RemoveModifiers().ElementType != ElementType.Void);
			using (IEnumerator<cK.ho> enumerator = cX(scope).GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					_003C_003Ec__DisplayClass0_1 _003C_003Ec__DisplayClass0_2 = new _003C_003Ec__DisplayClass0_1();
					_003C_003Ec__DisplayClass0_2.CS_0024_003C_003E8__locals1 = _003C_003Ec__DisplayClass0_;
					_003C_003Ec__DisplayClass0_2.block = enumerator.Current;
					_003C_003Ec__DisplayClass0_2 _003C_003Ec__DisplayClass0_3 = new _003C_003Ec__DisplayClass0_2();
					_003C_003Ec__DisplayClass0_3.CS_0024_003C_003E8__locals2 = _003C_003Ec__DisplayClass0_2;
					_003C_003Ec__DisplayClass0_3.statements = @do(_003C_003Ec__DisplayClass0_3.CS_0024_003C_003E8__locals2.block, _003C_003Ec__DisplayClass0_3.CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.trace);
					foreach (Instruction[] statement in _003C_003Ec__DisplayClass0_3.statements)
					{
						_003C_003Ec__DisplayClass0_3 _003C_003Ec__DisplayClass0_4 = new _003C_003Ec__DisplayClass0_3();
						_003C_003Ec__DisplayClass0_4.CS_0024_003C_003E8__locals3 = _003C_003Ec__DisplayClass0_3;
						_003C_003Ec__DisplayClass0_4.statementLast = new HashSet<Instruction>(_003C_003Ec__DisplayClass0_4.CS_0024_003C_003E8__locals3.statements.Select((Instruction[] st) => st.Last()));
						int num2 = 0;
						int num3 = 0;
						Instruction[] array = statement;
						foreach (Instruction instr in array)
						{
							if (instr.Operand is Instruction)
							{
								list2.Add(instr.Operand as Instruction);
							}
							if (list2.Contains(instr))
							{
								list2.Remove(instr);
								num2++;
							}
							if (exceptionHandlers.Count <= 1)
							{
								if (exceptionHandlers.Any((ExceptionHandler x) => x.TryStart == instr))
								{
									num++;
								}
								if (exceptionHandlers.Any((ExceptionHandler x) => x.HandlerEnd == instr))
								{
									num3++;
									num--;
								}
							}
						}
						bool isException = num > 0 || num3 > 0;
						bool isBranched = list2.Count > 0 || num2 > 0;
						list.Add(new Block(statement, isException, !_003C_003Ec__DisplayClass0_4.method_0(statement), isBranched));
					}
				}
				return list;
			}
		}

		private static LinkedList<Instruction[]> @do(cK.ho block, Trace trace)
		{
			LinkedList<Instruction[]> linkedList = new LinkedList<Instruction[]>();
			List<Instruction> list = new List<Instruction>();
			HashSet<Instruction> hashSet = new HashSet<Instruction>();
			for (int i = 0; i < block.hr.Count; i++)
			{
				Instruction instruction = block.hr[i];
				list.Add(instruction);
				bool flag = i + 1 < block.hr.Count && trace.HasMultipleSources(block.hr[i + 1].Offset);
				FlowControl flowControl = instruction.OpCode.FlowControl;
				if (flowControl == FlowControl.Branch || flowControl == FlowControl.Cond_Branch || (uint)(flowControl - 7) <= 1u)
				{
					flag = true;
					if (trace.AfterStack[instruction.Offset] != 0)
					{
						if (instruction.Operand is Instruction item)
						{
							hashSet.Add(item);
						}
						else if (instruction.Operand is Instruction[] array)
						{
							Instruction[] array2 = array;
							foreach (Instruction item2 in array2)
							{
								hashSet.Add(item2);
							}
						}
					}
				}
				hashSet.Remove(instruction);
				if (instruction.OpCode.OpCodeType != OpCodeType.Prefix && trace.AfterStack[instruction.Offset] == 0 && hashSet.Count == 0 && (flag || 90.0 > new Random().NextDouble()) && (i == 0 || block.hr[i - 1].OpCode.Code != Code.Tailcall))
				{
					linkedList.AddLast(list.ToArray());
					list.Clear();
				}
			}
			if (list.Count > 0)
			{
				linkedList.AddLast(list.ToArray());
			}
			return linkedList;
		}

		private static IEnumerable<cK.ho> cX(cK.hd scope)
		{
			foreach (cK.gR item in scope.hl)
			{
				if (!(item is cK.ho))
				{
					foreach (cK.ho item2 in cX((cK.hd)item))
					{
						yield return item2;
					}
				}
				else
				{
					yield return (cK.ho)item;
				}
			}
		}
	}
}
