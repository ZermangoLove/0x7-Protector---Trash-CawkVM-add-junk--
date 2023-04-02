using System.Collections.Generic;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Protections.Arithmetic
{
	public class Sin : iFunction
	{
		public override ArithmeticTypes ArithmeticTypes => ArithmeticTypes.Sin;

		public override ArithmeticVT Arithmetic(Instruction instruction, ModuleDef module)
		{
			if (!ArithmeticUtils.CheckArithmetic(instruction))
			{
				return null;
			}
			List<ArithmeticTypes> arithmetics = new List<ArithmeticTypes>
			{
				ArithmeticTypes.Add,
				ArithmeticTypes.Sub
			};
			ArithmeticEmulator arithmeticEmulator = new ArithmeticEmulator(instruction.GetLdcI4Value(), ArithmeticUtils.GetY(instruction.GetLdcI4Value()), ArithmeticTypes);
			return new ArithmeticVT(new Value(arithmeticEmulator.GetValue(arithmetics), arithmeticEmulator.GetY()), new Token(ArithmeticUtils.GetOpCode(arithmeticEmulator.GetType), module.Import(ArithmeticUtils.GetMethod(ArithmeticTypes))), ArithmeticTypes);
		}
	}
}
