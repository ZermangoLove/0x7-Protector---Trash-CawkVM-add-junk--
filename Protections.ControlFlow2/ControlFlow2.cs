using cj;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using ICore;

namespace Protections.ControlFlow2
{
	public class ControlFlow2
	{
		public static void Execute(Context context)
		{
			CFHelper cFHelper = new CFHelper();
			foreach (ModuleDef module in context.Module.Assembly.Modules)
			{
				foreach (TypeDef type in module.Types)
				{
					foreach (MethodDef method in type.Methods)
					{
						if (!method.HasBody || method.Body.Instructions.Count <= 0 || method.IsConstructor || cFHelper.HasUnsafeInstructions(method) || ci.cp(method) || !ci.co(method))
						{
							continue;
						}
						Blocks incGroups = cFHelper.GetBlocks(method);
						if (incGroups.blocks.Count != 1)
						{
							incGroups.Scramble(out incGroups);
							method.Body.Instructions.Clear();
							Local local = new Local(module.CorLibTypes.Int32);
							method.Body.Variables.Add(local);
							Instruction instruction = Instruction.Create(OpCodes.Nop);
							Instruction instruction2 = Instruction.Create(OpCodes.Br, instruction);
							foreach (Instruction item in cFHelper.Calc(0))
							{
								method.Body.Instructions.Add(item);
							}
							method.Body.Instructions.Add(Instruction.Create(OpCodes.Stloc, local));
							method.Body.Instructions.Add(Instruction.Create(OpCodes.Br, instruction2));
							method.Body.Instructions.Add(instruction);
							foreach (Block block in incGroups.blocks)
							{
								if (block == incGroups.getBlock(incGroups.blocks.Count - 1))
								{
									continue;
								}
								method.Body.Instructions.Add(Instruction.Create(OpCodes.Ldloc, local));
								foreach (Instruction item2 in cFHelper.Calc(block.ID))
								{
									method.Body.Instructions.Add(item2);
								}
								method.Body.Instructions.Add(Instruction.Create(OpCodes.Ceq));
								Instruction instruction3 = Instruction.Create(OpCodes.Nop);
								method.Body.Instructions.Add(Instruction.Create(OpCodes.Brfalse, instruction3));
								foreach (Instruction instruction4 in block.instructions)
								{
									method.Body.Instructions.Add(instruction4);
								}
								foreach (Instruction item3 in cFHelper.Calc(block.nextBlock))
								{
									method.Body.Instructions.Add(item3);
								}
								method.Body.Instructions.Add(Instruction.Create(OpCodes.Stloc, local));
								method.Body.Instructions.Add(instruction3);
							}
							method.Body.Instructions.Add(Instruction.Create(OpCodes.Ldloc, local));
							foreach (Instruction item4 in cFHelper.Calc(incGroups.blocks.Count - 1))
							{
								method.Body.Instructions.Add(item4);
							}
							method.Body.Instructions.Add(Instruction.Create(OpCodes.Ceq));
							method.Body.Instructions.Add(Instruction.Create(OpCodes.Brfalse, instruction2));
							method.Body.Instructions.Add(Instruction.Create(OpCodes.Br, incGroups.getBlock(incGroups.blocks.Count - 1).instructions[0]));
							method.Body.Instructions.Add(instruction2);
							foreach (Instruction instruction5 in incGroups.getBlock(incGroups.blocks.Count - 1).instructions)
							{
								method.Body.Instructions.Add(instruction5);
							}
						}
						ci.A(method);
					}
				}
			}
		}
	}
}
