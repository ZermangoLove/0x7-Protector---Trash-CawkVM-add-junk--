using System.Runtime.CompilerServices;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using ICore;
using Protections;

namespace Mutation.Stages
{
	public class IntsToMath
	{
		[CompilerGenerated]
		private MethodDef D;

		private MethodDef G
		{
			[CompilerGenerated]
			get
			{
				return D;
			}
			[CompilerGenerated]
			set
			{
				D = value;
			}
		}

		public IntsToMath(MethodDef method)
		{
			G = method;
		}

		public void Execute(ref int i)
		{
			switch (Utils.rnd.Next(0, 7))
			{
			case 0:
				N(ref i);
				break;
			case 1:
				P(ref i);
				break;
			case 2:
				R(ref i);
				break;
			case 3:
				Q(ref i);
				break;
			case 4:
				Or(ref i);
				break;
			case 5:
				O(ref i);
				break;
			case 6:
				S(ref i);
				break;
			case 7:
				K(ref i);
				break;
			case 8:
				M(ref i);
				break;
			case 9:
				L(ref i);
				break;
			}
		}

		private void K(ref int i)
		{
			int ldcI4Value = G.Body.Instructions[i].GetLdcI4Value();
			int num = Utils.RandomBigInt32();
			int num2 = ldcI4Value - num;
			G.Body.Instructions[i].OpCode = OpCodes.Ldc_I4;
			G.Body.Instructions[i].Operand = num2;
			G.Body.Instructions.Insert(++i, OpCodes.Ldc_I4.ToInstruction(num));
			G.Body.Instructions.Insert(++i, OpCodes.Add.ToInstruction());
		}

		private void L(ref int i)
		{
			int ldcI4Value = G.Body.Instructions[i].GetLdcI4Value();
			int num = Utils.RandomBigInt32();
			int num2 = ldcI4Value ^ num;
			G.Body.Instructions[i].OpCode = OpCodes.Ldc_I4;
			G.Body.Instructions[i].Operand = num2;
			G.Body.Instructions.Insert(++i, OpCodes.Ldc_I4.ToInstruction(num));
			G.Body.Instructions.Insert(++i, OpCodes.Xor.ToInstruction());
		}

		private void M(ref int i)
		{
			int ldcI4Value = G.Body.Instructions[i].GetLdcI4Value();
			int num = Utils.RandomBigInt32();
			int num2 = ldcI4Value + num;
			G.Body.Instructions[i].OpCode = OpCodes.Ldc_I4;
			G.Body.Instructions[i].Operand = num2;
			G.Body.Instructions.Insert(++i, OpCodes.Ldc_I4.ToInstruction(num));
			G.Body.Instructions.Insert(++i, OpCodes.Sub.ToInstruction());
		}

		private void N(ref int i)
		{
			int ldcI4Value = G.Body.Instructions[i].GetLdcI4Value();
			int num = Utils.RandomBigInt32();
			int value = -num;
			Calculator calculator = new Calculator(ldcI4Value, value);
			G.Body.Instructions[i].OpCode = OpCodes.Ldc_I4;
			G.Body.Instructions[i].Operand = calculator.getResult();
			G.Body.Instructions.Insert(i + 1, OpCodes.Ldc_I4.ToInstruction(num));
			G.Body.Instructions.Insert(i + 2, OpCodes.Neg.ToInstruction());
			G.Body.Instructions.Insert(i + 3, calculator.getOpCode().ToInstruction());
			i += 3;
		}

		private void O(ref int i)
		{
			int ldcI4Value = G.Body.Instructions[i].GetLdcI4Value();
			int num = Utils.RandomBigInt32();
			int num2 = Utils.RandomBigInt32();
			int value = num2 % num;
			Calculator calculator = new Calculator(ldcI4Value, value);
			G.Body.Instructions[i].OpCode = OpCodes.Ldc_I4;
			G.Body.Instructions[i].Operand = calculator.getResult();
			G.Body.Instructions.Insert(i + 1, OpCodes.Ldc_I4.ToInstruction(num2));
			G.Body.Instructions.Insert(i + 2, OpCodes.Ldc_I4.ToInstruction(num));
			G.Body.Instructions.Insert(i + 3, OpCodes.Rem.ToInstruction());
			G.Body.Instructions.Insert(i + 4, calculator.getOpCode().ToInstruction());
			i += 4;
		}

		private void P(ref int i)
		{
			int ldcI4Value = G.Body.Instructions[i].GetLdcI4Value();
			int num = Utils.RandomBigInt32();
			int value = ~num;
			Calculator calculator = new Calculator(ldcI4Value, value);
			G.Body.Instructions[i].OpCode = OpCodes.Ldc_I4;
			G.Body.Instructions[i].Operand = calculator.getResult();
			G.Body.Instructions.Insert(i + 1, OpCodes.Ldc_I4.ToInstruction(num));
			G.Body.Instructions.Insert(i + 2, OpCodes.Not.ToInstruction());
			G.Body.Instructions.Insert(i + 3, calculator.getOpCode().ToInstruction());
			i += 3;
		}

		private void Q(ref int i)
		{
			int ldcI4Value = G.Body.Instructions[i].GetLdcI4Value();
			int num = Utils.RandomBigInt32();
			int num2 = Utils.RandomBigInt32();
			int value = num2 << num;
			Calculator calculator = new Calculator(ldcI4Value, value);
			G.Body.Instructions[i].OpCode = OpCodes.Ldc_I4;
			G.Body.Instructions[i].Operand = calculator.getResult();
			G.Body.Instructions.Insert(i + 1, OpCodes.Ldc_I4.ToInstruction(num2));
			G.Body.Instructions.Insert(i + 2, OpCodes.Ldc_I4.ToInstruction(num));
			G.Body.Instructions.Insert(i + 3, OpCodes.Shl.ToInstruction());
			G.Body.Instructions.Insert(i + 4, calculator.getOpCode().ToInstruction());
			i += 4;
		}

		private void Or(ref int i)
		{
			int ldcI4Value = G.Body.Instructions[i].GetLdcI4Value();
			int num = Utils.RandomBigInt32();
			int num2 = Utils.RandomBigInt32();
			int value = num2 | num;
			Calculator calculator = new Calculator(ldcI4Value, value);
			G.Body.Instructions[i].OpCode = OpCodes.Ldc_I4;
			G.Body.Instructions[i].Operand = calculator.getResult();
			G.Body.Instructions.Insert(i + 1, OpCodes.Ldc_I4.ToInstruction(num2));
			G.Body.Instructions.Insert(i + 2, OpCodes.Ldc_I4.ToInstruction(num));
			G.Body.Instructions.Insert(i + 3, OpCodes.Or.ToInstruction());
			G.Body.Instructions.Insert(i + 4, calculator.getOpCode().ToInstruction());
			i += 4;
		}

		private void R(ref int i)
		{
			int ldcI4Value = G.Body.Instructions[i].GetLdcI4Value();
			int num = Utils.RandomBigInt32();
			int num2 = Utils.RandomBigInt32();
			int value = num2 >> num;
			Calculator calculator = new Calculator(ldcI4Value, value);
			G.Body.Instructions[i].OpCode = OpCodes.Ldc_I4;
			G.Body.Instructions[i].Operand = calculator.getResult();
			G.Body.Instructions.Insert(i + 1, OpCodes.Ldc_I4.ToInstruction(num2));
			G.Body.Instructions.Insert(i + 2, OpCodes.Ldc_I4.ToInstruction(num));
			G.Body.Instructions.Insert(i + 3, OpCodes.Shr.ToInstruction());
			G.Body.Instructions.Insert(i + 4, calculator.getOpCode().ToInstruction());
			i += 4;
		}

		private void S(ref int i)
		{
			Instruction instruction = G.Body.Instructions[i];
			Local local = new Local(G.Module.ImportAsTypeSig(typeof(int)));
			int ldcI4Value = instruction.GetLdcI4Value();
			int num = Utils.RandomBigInt32();
			int num2 = Utils.RandomBigInt32();
			int value;
			int value2;
			if (num > num2)
			{
				value = ldcI4Value;
				value2 = ldcI4Value + ldcI4Value / 3;
			}
			else
			{
				value2 = ldcI4Value;
				value = ldcI4Value + ldcI4Value / 3;
			}
			G.Body.Variables.Add(local);
			instruction.OpCode = OpCodes.Ldc_I4;
			instruction.Operand = num2;
			G.Body.Instructions.Insert(i + 1, Instruction.Create(OpCodes.Ldc_I4, num));
			G.Body.Instructions.Insert(i + 2, Instruction.Create(OpCodes.Nop));
			G.Body.Instructions.Insert(i + 3, Instruction.Create(OpCodes.Ldc_I4, value));
			G.Body.Instructions.Insert(i + 4, Instruction.Create(OpCodes.Nop));
			G.Body.Instructions.Insert(i + 5, Instruction.Create(OpCodes.Ldc_I4, value2));
			G.Body.Instructions.Insert(i + 6, Instruction.Create(OpCodes.Stloc, local));
			G.Body.Instructions.Insert(i + 7, Instruction.Create(OpCodes.Ldloc, local));
			G.Body.Instructions[i + 2].OpCode = OpCodes.Bgt_S;
			G.Body.Instructions[i + 2].Operand = G.Body.Instructions[i + 5];
			G.Body.Instructions[i + 4].OpCode = OpCodes.Br_S;
			G.Body.Instructions[i + 4].Operand = G.Body.Instructions[i + 6];
			i += 7;
		}
	}
}
