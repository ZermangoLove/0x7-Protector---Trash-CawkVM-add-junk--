using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using ICore;

namespace Protections.WeakControlFlow
{
	public class WeakControlFlow
	{
		[CompilerGenerated]
		private ModuleDef dv;

		public ModuleDef Module
		{
			[CompilerGenerated]
			get
			{
				return dv;
			}
			[CompilerGenerated]
			set
			{
				dv = value;
			}
		}

		public void Execute(Context context)
		{
			Module = context.Module;
			for (int i = 0; i < Module.Types.Count; i++)
			{
				TypeDef typeDef = Module.Types[i];
				if (typeDef == Module.GlobalType)
				{
					continue;
				}
				for (int j = 0; j < typeDef.Methods.Count; j++)
				{
					MethodDef methodDef = typeDef.Methods[j];
					if (!methodDef.Name.StartsWith("get_") && !methodDef.Name.StartsWith("set_") && methodDef.HasBody && !methodDef.IsConstructor)
					{
						methodDef.Body.SimplifyBranches();
						ExecuteMethod(methodDef);
					}
				}
			}
		}

		public void ExecuteMethod(MethodDef method)
		{
			method.Body.SimplifyMacros(method.Parameters);
			List<Block> blocks = BlockParser.ParseMethod(method);
			blocks = Randomize(blocks);
			method.Body.Instructions.Clear();
			Local local = new Local(Module.CorLibTypes.Int32);
			method.Body.Variables.Add(local);
			Instruction instruction = Instruction.Create(OpCodes.Nop);
			Instruction instruction2 = Instruction.Create(OpCodes.Br, instruction);
			foreach (Instruction item in Calc(0))
			{
				method.Body.Instructions.Add(item);
			}
			method.Body.Instructions.Add(Instruction.Create(OpCodes.Stloc, local));
			method.Body.Instructions.Add(Instruction.Create(OpCodes.Br, instruction2));
			method.Body.Instructions.Add(instruction);
			foreach (Block item2 in blocks)
			{
				if (item2 == blocks.Single((Block x) => x.Number == blocks.Count - 1))
				{
					continue;
				}
				method.Body.Instructions.Add(Instruction.Create(OpCodes.Ldloc, local));
				foreach (Instruction item3 in Calc(item2.Number))
				{
					method.Body.Instructions.Add(item3);
				}
				method.Body.Instructions.Add(Instruction.Create(OpCodes.Ceq));
				Instruction instruction3 = Instruction.Create(OpCodes.Nop);
				method.Body.Instructions.Add(Instruction.Create(OpCodes.Brfalse, instruction3));
				foreach (Instruction instruction4 in item2.Instructions)
				{
					method.Body.Instructions.Add(instruction4);
				}
				foreach (Instruction item4 in Calc(item2.Number + 1))
				{
					method.Body.Instructions.Add(item4);
				}
				method.Body.Instructions.Add(Instruction.Create(OpCodes.Stloc, local));
				method.Body.Instructions.Add(instruction3);
			}
			method.Body.Instructions.Add(Instruction.Create(OpCodes.Ldloc, local));
			foreach (Instruction item5 in Calc(blocks.Count - 1))
			{
				method.Body.Instructions.Add(item5);
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

		public List<Block> Randomize(List<Block> input)
		{
			List<Block> list = new List<Block>();
			foreach (Block item in input)
			{
				list.Insert(Utils.rnd.Next(0, list.Count), item);
			}
			return list;
		}

		public List<Instruction> Calc(int value)
		{
			return new List<Instruction> { Instruction.Create(OpCodes.Ldc_I4, value) };
		}

		public void AddJump(IList<Instruction> instrs, Instruction target)
		{
			instrs.Add(Instruction.Create(OpCodes.Br, target));
		}
	}
}
