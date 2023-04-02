using System;
using System.Reflection;
using dnlib.DotNet.Emit;

namespace Protections.Arithmetic
{
	public class ArithmeticUtils
	{
		public static bool CheckArithmetic(Instruction instruction)
		{
			if (!instruction.IsLdcI4())
			{
				return false;
			}
			if (instruction.GetLdcI4Value() == 1)
			{
				return false;
			}
			return instruction.GetLdcI4Value() != 0;
		}

		public static double GetY(double x)
		{
			return x / 2.0;
		}

		public static MethodInfo GetMethod(ArithmeticTypes mathType)
		{
			switch (mathType)
			{
			default:
				return null;
			case ArithmeticTypes.Abs:
				return typeof(Math).GetMethod("Abs", new Type[1] { typeof(double) });
			case ArithmeticTypes.Log:
				return typeof(Math).GetMethod("Log", new Type[1] { typeof(double) });
			case ArithmeticTypes.Log10:
				return typeof(Math).GetMethod("Log10", new Type[1] { typeof(double) });
			case ArithmeticTypes.Sin:
				return typeof(Math).GetMethod("Sin", new Type[1] { typeof(double) });
			case ArithmeticTypes.Cos:
				return typeof(Math).GetMethod("Cos", new Type[1] { typeof(double) });
			case ArithmeticTypes.Round:
				return typeof(Math).GetMethod("Round", new Type[1] { typeof(double) });
			case ArithmeticTypes.Sqrt:
				return typeof(Math).GetMethod("Sqrt", new Type[1] { typeof(double) });
			case ArithmeticTypes.Ceiling:
				return typeof(Math).GetMethod("Ceiling", new Type[1] { typeof(double) });
			case ArithmeticTypes.Floor:
				return typeof(Math).GetMethod("Floor", new Type[1] { typeof(double) });
			case ArithmeticTypes.Tan:
				return typeof(Math).GetMethod("Tan", new Type[1] { typeof(double) });
			case ArithmeticTypes.Tanh:
				return typeof(Math).GetMethod("Tanh", new Type[1] { typeof(double) });
			case ArithmeticTypes.Truncate:
				return typeof(Math).GetMethod("Truncate", new Type[1] { typeof(double) });
			}
		}

		public static OpCode GetOpCode(ArithmeticTypes arithmetic)
		{
			switch (arithmetic)
			{
			default:
				return null;
			case ArithmeticTypes.Sub:
				return OpCodes.Sub;
			case ArithmeticTypes.Add:
				return OpCodes.Add;
			}
		}
	}
}
