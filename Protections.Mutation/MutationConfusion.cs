using System.Collections.Generic;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using Helpers.MethodBlocks;
using ICore;
using Mutation.Stages;
using Protections.Arithmetic;

namespace Protections.Mutation
{
	public class MutationConfusion
	{
		public static void InjectStrings(Context context)
		{
			foreach (TypeDef type in context.Module.GetTypes())
			{
				if (type.IsGlobalModuleType || type.Namespace == "Costura")
				{
					continue;
				}
				foreach (MethodDef method in type.Methods)
				{
					IntsConversions intsConversions = new IntsConversions(method);
					if (method.HasBody && method.Body.HasInstructions)
					{
						intsConversions.Execute();
					}
				}
			}
		}

		public static void InjectMath(Context context)
		{
			foreach (TypeDef type in context.Module.GetTypes())
			{
				if (type.IsGlobalModuleType || type.Namespace == "Costura")
				{
					continue;
				}
				foreach (MethodDef method in type.Methods)
				{
					IntsToMath intsToMath = new IntsToMath(method);
					if (!method.HasBody || !method.Body.HasInstructions)
					{
						continue;
					}
					for (int i = 0; i < method.Body.Instructions.Count; i++)
					{
						if (method.Body.Instructions[i].IsLdcI4())
						{
							intsToMath.Execute(ref i);
						}
					}
				}
			}
		}

		public static void FakeIf(Context context)
		{
			foreach (TypeDef type in context.Module.GetTypes())
			{
				if (type.IsGlobalModuleType || type.Namespace == "Costura")
				{
					continue;
				}
				foreach (MethodDef method in type.Methods)
				{
					if (method.HasBody && method.Body.HasInstructions)
					{
						FakeIfOperation(method);
					}
				}
			}
		}

		public static void Arithmetic(Context context)
		{
			foreach (TypeDef type in context.Module.GetTypes())
			{
				if (type.IsGlobalModuleType || type.Namespace == "Costura")
				{
					continue;
				}
				foreach (MethodDef method in type.Methods)
				{
					if (method.HasBody && method.Body.HasInstructions)
					{
						Protections.Arithmetic.Arithmetic.Execute(context);
						ArithmeticOperation(method);
					}
				}
			}
		}

		public static void FakeIfOperation(MethodDef method)
		{
			List<Instruction> list = new List<Instruction>();
			List<Block> blocks = method.GetBlocks();
			List<Block> list2 = new List<Block>();
			List<Block> list3 = new List<Block>();
			Local local = new Local(method.Module.CorLibTypes.Int32);
			int value = Utils.RandomBigInt32();
			Int32Local int32Local = new Int32Local(local, value);
			method.Body.Variables.Add(local);
			list.Add(OpCodes.Nop.ToInstruction());
			list.Add(OpCodes.Ldc_I4.ToInstruction(value));
			list.Add(OpCodes.Stloc.ToInstruction(local));
			Block item = new Block(list.ToArray());
			list2.Add(item);
			foreach (Block item5 in blocks)
			{
				if (item5.IsSafe && !item5.IsBranched && !item5.IsException)
				{
					bool flag = false;
					if (Utils.RandomBoolean() || list3.Count == 0 || flag)
					{
						if (!Utils.RandomBoolean())
						{
							for (int i = 0; i < Utils.rnd.Next(2, 5); i++)
							{
								Block item2 = BlockHandler.GenerateBlock(int32Local, BlockType.FakeIf);
								list2.Add(item2);
							}
						}
						else
						{
							Block item3 = BlockHandler.GenerateBlock(int32Local, BlockType.FakeIf);
							list2.Add(item3);
						}
					}
					else
					{
						Block item4 = BlockHandler.GenerateBlock(int32Local, BlockType.FakeIf);
						list2.Add(item4);
					}
				}
				for (int j = 0; j < item5.Instructions.Count; j++)
				{
					Instruction instruction = item5.Instructions[j];
					if (instruction.IsLdcI4())
					{
						int ldcI4Value = instruction.GetLdcI4Value();
						int value2 = int32Local.Value;
						Code code = Utils.GetCode(supported: true);
						int num = BlockHandler.Calculate(ldcI4Value, value2, code);
						instruction.OpCode = OpCodes.Ldc_I4;
						instruction.Operand = num;
						item5.Instructions.Insert(j + 1, OpCodes.Ldloc.ToInstruction(local));
						item5.Instructions.Insert(j + 2, code.ToOpCode().ToInstruction());
						j += 2;
					}
				}
				list2.Add(item5);
			}
			method.Body.Instructions.Clear();
			foreach (Block item6 in list2)
			{
				foreach (Instruction instruction2 in item6.Instructions)
				{
					method.Body.Instructions.Add(instruction2);
				}
			}
		}

		public static void ArithmeticOperation(MethodDef method)
		{
			List<Instruction> list = new List<Instruction>();
			List<Block> blocks = method.GetBlocks();
			List<Block> list2 = new List<Block>();
			List<Block> list3 = new List<Block>();
			Local local = new Local(method.Module.CorLibTypes.Int32);
			int value = Utils.RandomBigInt32();
			Int32Local int32Local = new Int32Local(local, value);
			method.Body.Variables.Add(local);
			list.Add(OpCodes.Nop.ToInstruction());
			list.Add(OpCodes.Ldc_I4.ToInstruction(value));
			list.Add(OpCodes.Stloc.ToInstruction(local));
			Block item = new Block(list.ToArray());
			list2.Add(item);
			foreach (Block item5 in blocks)
			{
				if (item5.IsSafe && !item5.IsBranched && !item5.IsException)
				{
					bool flag = false;
					if (Utils.RandomBoolean() || list3.Count == 0 || flag)
					{
						if (!Utils.RandomBoolean())
						{
							for (int i = 0; i < Utils.rnd.Next(2, 5); i++)
							{
								Block item2 = BlockHandler.GenerateBlock(int32Local, BlockType.Arithmethic);
								list2.Add(item2);
								list3.Add(item2);
							}
						}
						else
						{
							Block item3 = BlockHandler.GenerateBlock(int32Local, BlockType.Arithmethic);
							list2.Add(item3);
							list3.Add(item3);
						}
					}
					else
					{
						Block item4 = BlockHandler.GenerateBlock(int32Local, BlockType.Arithmethic);
						list2.Add(item4);
						list3.Add(item4);
					}
				}
				for (int j = 0; j < item5.Instructions.Count; j++)
				{
					Instruction instruction = item5.Instructions[j];
					if (instruction.IsLdcI4())
					{
						int ldcI4Value = instruction.GetLdcI4Value();
						int value2 = int32Local.Value;
						Code code = Utils.GetCode(supported: true);
						int num = BlockHandler.Calculate(ldcI4Value, value2, code);
						instruction.OpCode = OpCodes.Ldc_I4;
						instruction.Operand = num;
						item5.Instructions.Insert(j + 1, OpCodes.Ldloc.ToInstruction(local));
						item5.Instructions.Insert(j + 2, code.ToOpCode().ToInstruction());
						j += 2;
					}
				}
				list2.Add(item5);
			}
			method.Body.Instructions.Clear();
			foreach (Block item6 in list2)
			{
				foreach (Instruction instruction2 in item6.Instructions)
				{
					method.Body.Instructions.Add(instruction2);
				}
			}
		}
	}
}
