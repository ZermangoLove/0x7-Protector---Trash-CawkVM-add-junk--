using System.Collections.Generic;
using dnlib.DotNet.Emit;
using Helpers.Emulator;
using Helpers.MethodBlocks;
using ICore;

namespace Protections.Mutation
{
	public static class BlockHandler
	{
		public static Block GenerateBlock(Int32Local local, BlockType type)
		{
			List<Instruction> list = new List<Instruction>();
			bool isSafe = true;
			bool isBranched = false;
			switch (type)
			{
			case BlockType.FakeIf:
			{
				int value = Utils.RandomBigInt32();
				Code code = Utils.GetCode(supported: true);
				Instruction instruction = OpCodes.Nop.ToInstruction();
				list.Add(OpCodes.Ldloc.ToInstruction(local.Local));
				list.Add(OpCodes.Ldc_I4.ToInstruction(value));
				list.Add(code.ToOpCode().ToInstruction());
				list.Add(OpCodes.Ldc_I4.ToInstruction(Utils.RandomBigInt32()));
				list.Add(OpCodes.Ceq.ToInstruction());
				list.Add(OpCodes.Brfalse.ToInstruction(instruction));
				list.Add(OpCodes.Ldloc.ToInstruction(local.Local));
				list.Add(OpCodes.Ldc_I4.ToInstruction(Utils.RandomBigInt32()));
				list.Add(Utils.GetCode().ToOpCode().ToInstruction());
				list.Add(OpCodes.Stloc.ToInstruction(local.Local));
				list.Add(instruction);
				isSafe = false;
				isBranched = true;
				break;
			}
			case BlockType.Arithmethic:
				list.Add(OpCodes.Nop.ToInstruction());
				list.Add(OpCodes.Ldloc.ToInstruction(local.Local));
				list.Add(OpCodes.Ldc_I4.ToInstruction(Utils.RandomBigInt32()));
				list.Add(Utils.GetCode().ToOpCode().ToInstruction());
				list.Add(OpCodes.Stloc.ToInstruction(local.Local));
				local.Value = Emulate(list, local);
				break;
			}
			return new Block(list.ToArray(), IsException: false, isSafe, isBranched, local.Value);
		}

		public static int Emulate(List<Instruction> instructions, Int32Local local)
		{
			Emulator emulator = new Emulator(instructions, new List<Local> { local.Local });
			emulator._context.ei(local.Local, local.Value);
			return emulator.en();
		}

		public static List<Instruction> GenerateBranch(int value, Local local, Instruction target)
		{
			bool fake = Utils.RandomBoolean();
			switch (Utils.rnd.Next(0, 2))
			{
			default:
				return null;
			case 1:
				return GenerateBrTrue(value, local, target, fake);
			case 0:
				return GenerateBrFalse(value, local, target, fake);
			}
		}

		public static List<Instruction> GenerateBrFalse(int value, Local local, Instruction target, bool fake)
		{
			int num = Utils.RandomBigInt32();
			Code code = Utils.GetCode(supported: true);
			int value2 = Calculate(value, num, code, reverse: false);
			List<Instruction> list = new List<Instruction>();
			Instruction instruction = OpCodes.Nop.ToInstruction();
			list.Add(OpCodes.Ldloc.ToInstruction(local));
			list.Add(OpCodes.Ldc_I4.ToInstruction(num));
			list.Add(code.ToOpCode().ToInstruction());
			list.Add(OpCodes.Ldc_I4.ToInstruction(value2));
			list.Add(OpCodes.Ceq.ToInstruction());
			list.Add(OpCodes.Brfalse.ToInstruction(instruction));
			list.Add(OpCodes.Br.ToInstruction(target));
			list.Add(instruction);
			return list;
		}

		public static List<Instruction> GenerateBrTrue(int value, Local local, Instruction target, bool fake)
		{
			int num = Utils.RandomBigInt32();
			Code code = Utils.GetCode(supported: true);
			int value2 = Calculate(value, num, code, reverse: false);
			List<Instruction> list = new List<Instruction>();
			Instruction instruction = OpCodes.Nop.ToInstruction();
			Instruction instruction2 = OpCodes.Nop.ToInstruction();
			list.Add(OpCodes.Ldloc.ToInstruction(local));
			list.Add(OpCodes.Ldc_I4.ToInstruction(num));
			list.Add(code.ToOpCode().ToInstruction());
			list.Add(OpCodes.Ldc_I4.ToInstruction(value2));
			list.Add(OpCodes.Ceq.ToInstruction());
			list.Add(OpCodes.Brtrue.ToInstruction(instruction));
			list.Add(OpCodes.Br.ToInstruction(instruction2));
			list.Add(instruction);
			list.Add(OpCodes.Br.ToInstruction(target));
			list.Add(instruction2);
			return list;
		}

		public static Block GenerateBrBlock(Instruction target)
		{
			return new Block(new List<Instruction> { OpCodes.Br.ToInstruction(target) }.ToArray(), IsException: false, IsSafe: true, IsBranched: true);
		}

		public static int Calculate(int n1, int n2, Code code, bool reverse = true)
		{
			switch (code)
			{
			default:
				return 0;
			case Code.Xor:
				return n1 ^ n2;
			case Code.Sub:
				if (!reverse)
				{
					return n1 - n2;
				}
				return n1 + n2;
			case Code.Add:
				if (!reverse)
				{
					return n1 + n2;
				}
				return n1 - n2;
			}
		}
	}
}
