using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using ICore;

namespace Protections.WeakControlFlow
{
	public class CFWVM
	{
		public class Block
		{
			[CompilerGenerated]
			private List<Instruction> ds;

			[CompilerGenerated]
			private int dt;

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

			public Block()
			{
				Instructions = new List<Instruction>();
			}
		}

		public static List<Block> GetMethod(MethodDef method)
		{
			List<Block> list = new List<Block>();
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
					num = (block.Number = num + 1);
					list.Add(block);
					block = new Block();
				}
			}
			return list;
		}

		public static void Execute(Context context)
		{
			foreach (TypeDef type in context.Module.Types)
			{
				foreach (MethodDef method in type.Methods)
				{
					if (method.Name.StartsWith("get_") || method.Name.StartsWith("set_") || !method.HasBody || method.IsConstructor)
					{
						continue;
					}
					method.Body.SimplifyBranches();
					method.Body.SimplifyMacros(method.Parameters);
					List<Block> blocks = GetMethod(method);
					List<Block> list = new List<Block>();
					foreach (Block item in blocks)
					{
						Random random = new Random();
						list.Insert(random.Next(0, list.Count), item);
					}
					blocks = list;
					method.Body.Instructions.Clear();
					Local local = new Local(method.Module.CorLibTypes.Int32);
					method.Body.Variables.Add(local);
					Instruction instruction = Instruction.Create(OpCodes.Nop);
					Instruction instruction2 = Instruction.Create(OpCodes.Br, instruction);
					foreach (Instruction item2 in new List<Instruction> { Instruction.Create(OpCodes.Ldc_I4, 1) })
					{
						method.Body.Instructions.Add(item2);
					}
					method.Body.Instructions.Add(Instruction.Create(OpCodes.Stloc, local));
					method.Body.Instructions.Add(Instruction.Create(OpCodes.Br, instruction2));
					method.Body.Instructions.Add(instruction);
					foreach (Block item3 in blocks.Where((Block block) => block != blocks.Single((Block x) => x.Number == blocks.Count - 1)))
					{
						method.Body.Instructions.Add(Instruction.Create(OpCodes.Ldloc, local));
						foreach (Instruction item4 in new List<Instruction> { Instruction.Create(OpCodes.Ldc_I4, item3.Number) })
						{
							method.Body.Instructions.Add(item4);
						}
						method.Body.Instructions.Add(Instruction.Create(OpCodes.Ceq));
						Instruction instruction3 = Instruction.Create(OpCodes.Nop);
						method.Body.Instructions.Add(Instruction.Create(OpCodes.Brfalse, instruction3));
						foreach (Instruction instruction4 in item3.Instructions)
						{
							method.Body.Instructions.Add(instruction4);
						}
						foreach (Instruction item5 in new List<Instruction> { Instruction.Create(OpCodes.Ldc_I4, item3.Number + 1) })
						{
							method.Body.Instructions.Add(item5);
						}
						method.Body.Instructions.Add(Instruction.Create(OpCodes.Stloc, local));
						method.Body.Instructions.Add(instruction3);
					}
					method.Body.Instructions.Add(Instruction.Create(OpCodes.Ldloc, local));
					foreach (Instruction item6 in new List<Instruction> { Instruction.Create(OpCodes.Ldc_I4, blocks.Count - 1) })
					{
						method.Body.Instructions.Add(item6);
					}
					method.Body.Instructions.Add(Instruction.Create(OpCodes.Ceq));
					method.Body.Instructions.Add(Instruction.Create(OpCodes.Brfalse, instruction2));
					method.Body.Instructions.Add(Instruction.Create(OpCodes.Br, blocks.Single((Block x) => x.Number == blocks.Count - 1).Instructions[0]));
					method.Body.Instructions.Add(instruction2);
					foreach (Instruction instruction5 in blocks.Single((Block x) => x.Number == blocks.Count - 1).Instructions)
					{
						method.Body.Instructions.Add(instruction5);
					}
				}
			}
		}
	}
}
