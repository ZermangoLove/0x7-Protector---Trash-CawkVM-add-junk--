using System;
using System.Collections.Generic;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using ICore;

namespace Protections.Arithmetic
{
	public class Arithmetic
	{
		public static ModuleDef moduleDef1;

		public static List<iFunction> Tasks = new List<iFunction>
		{
			new Add(),
			new Sub(),
			new Div(),
			new Mul(),
			new Xor(),
			new Abs(),
			new Log(),
			new Log10(),
			new Sin(),
			new Cos(),
			new Floor(),
			new Round(),
			new Tan(),
			new Tanh(),
			new Sqrt(),
			new Ceiling(),
			new Truncate()
		};

		public static void Execute(Context context)
		{
			moduleDef1 = context.Module;
			Generator generator = new Generator();
			foreach (TypeDef type in moduleDef1.Types)
			{
				foreach (MethodDef method in type.Methods)
				{
					if (!method.HasBody || method.DeclaringType.IsGlobalModuleType)
					{
						continue;
					}
					for (int i = 0; i < method.Body.Instructions.Count; i++)
					{
						if (!ArithmeticUtils.CheckArithmetic(method.Body.Instructions[i]))
						{
							continue;
						}
						if (method.Body.Instructions[i].GetLdcI4Value() < 0)
						{
							List<Instruction> list = dz(Tasks[generator.Next(5)].Arithmetic(method.Body.Instructions[i], moduleDef1));
							if (list == null)
							{
								continue;
							}
							method.Body.Instructions[i].OpCode = OpCodes.Nop;
							foreach (Instruction item in list)
							{
								method.Body.Instructions.Insert(i + 1, item);
								i++;
							}
							continue;
						}
						List<Instruction> list2 = dz(Tasks[generator.Next(Tasks.Count)].Arithmetic(method.Body.Instructions[i], moduleDef1));
						if (list2 == null)
						{
							continue;
						}
						method.Body.Instructions[i].OpCode = OpCodes.Nop;
						foreach (Instruction item2 in list2)
						{
							method.Body.Instructions.Insert(i + 1, item2);
							i++;
						}
					}
				}
			}
		}

		private static List<Instruction> dz(ArithmeticVT arithmeticVTs)
		{
			List<Instruction> list = new List<Instruction>();
			if (dA(arithmeticVTs.GetArithmetic()))
			{
				list.Add(new Instruction(OpCodes.Ldc_R8, arithmeticVTs.GetValue().GetX()));
				list.Add(new Instruction(OpCodes.Ldc_R8, arithmeticVTs.GetValue().GetY()));
				if (arithmeticVTs.GetToken().GetOperand() != null)
				{
					list.Add(new Instruction(OpCodes.Call, arithmeticVTs.GetToken().GetOperand()));
				}
				list.Add(new Instruction(arithmeticVTs.GetToken().GetOpCode()));
				list.Add(new Instruction(OpCodes.Call, moduleDef1.Import(typeof(Convert).GetMethod("ToInt32", new Type[1] { typeof(double) }))));
			}
			else if (dB(arithmeticVTs.GetArithmetic()))
			{
				list.Add(new Instruction(OpCodes.Ldc_I4, (int)arithmeticVTs.GetValue().GetX()));
				list.Add(new Instruction(OpCodes.Ldc_I4, (int)arithmeticVTs.GetValue().GetY()));
				list.Add(new Instruction(arithmeticVTs.GetToken().GetOpCode()));
				list.Add(new Instruction(OpCodes.Conv_I4));
			}
			return list;
		}

		private static bool dA(ArithmeticTypes arithmetic)
		{
			if (arithmetic != 0 && arithmetic != ArithmeticTypes.Sub && arithmetic != ArithmeticTypes.Div && arithmetic != ArithmeticTypes.Mul && arithmetic != ArithmeticTypes.Abs && arithmetic != ArithmeticTypes.Log && arithmetic != ArithmeticTypes.Log10 && arithmetic != ArithmeticTypes.Truncate && arithmetic != ArithmeticTypes.Sin && arithmetic != ArithmeticTypes.Cos && arithmetic != ArithmeticTypes.Floor && arithmetic != ArithmeticTypes.Round && arithmetic != ArithmeticTypes.Tan && arithmetic != ArithmeticTypes.Tanh && arithmetic != ArithmeticTypes.Sqrt)
			{
				return arithmetic == ArithmeticTypes.Ceiling;
			}
			return true;
		}

		private static bool dB(ArithmeticTypes arithmetic)
		{
			return arithmetic == ArithmeticTypes.Xor;
		}
	}
}
