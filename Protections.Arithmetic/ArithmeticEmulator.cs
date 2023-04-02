using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Protections.Arithmetic
{
	public class ArithmeticEmulator
	{
		private readonly double an;

		private readonly double dC;

		private readonly ArithmeticTypes dD;

		[CompilerGenerated]
		private ArithmeticTypes dE;

		public new ArithmeticTypes GetType
		{
			[CompilerGenerated]
			get
			{
				return dE;
			}
			[CompilerGenerated]
			private set
			{
				dE = value;
			}
		}

		public ArithmeticEmulator(double x, double y, ArithmeticTypes arithmeticTypes)
		{
			an = x;
			dC = y;
			dD = arithmeticTypes;
		}

		public double GetValue()
		{
			switch (dD)
			{
			default:
				return -1.0;
			case ArithmeticTypes.Add:
				return an - dC;
			case ArithmeticTypes.Sub:
				return an + dC;
			case ArithmeticTypes.Div:
				return an * dC;
			case ArithmeticTypes.Mul:
				return an / dC;
			case ArithmeticTypes.Xor:
				return (int)an ^ (int)dC;
			}
		}

		public double GetValue(List<ArithmeticTypes> arithmetics)
		{
			Generator generator = new Generator();
			ArithmeticTypes arithmeticTypes2 = (GetType = arithmetics[generator.Next(arithmetics.Count)]);
			switch (dD)
			{
			default:
				return -1.0;
			case ArithmeticTypes.Abs:
				switch (arithmeticTypes2)
				{
				default:
					return -1.0;
				case ArithmeticTypes.Sub:
					return an - Math.Abs(dC) * -1.0;
				case ArithmeticTypes.Add:
					return an + Math.Abs(dC) * -1.0;
				}
			case ArithmeticTypes.Log:
				switch (arithmeticTypes2)
				{
				default:
					return -1.0;
				case ArithmeticTypes.Sub:
					return an + Math.Log(dC);
				case ArithmeticTypes.Add:
					return an - Math.Log(dC);
				}
			case ArithmeticTypes.Log10:
				switch (arithmeticTypes2)
				{
				default:
					return -1.0;
				case ArithmeticTypes.Sub:
					return an + Math.Log10(dC);
				case ArithmeticTypes.Add:
					return an - Math.Log10(dC);
				}
			case ArithmeticTypes.Sin:
				switch (arithmeticTypes2)
				{
				default:
					return -1.0;
				case ArithmeticTypes.Sub:
					return an + Math.Sin(dC);
				case ArithmeticTypes.Add:
					return an - Math.Sin(dC);
				}
			case ArithmeticTypes.Cos:
				switch (arithmeticTypes2)
				{
				default:
					return -1.0;
				case ArithmeticTypes.Sub:
					return an + Math.Cos(dC);
				case ArithmeticTypes.Add:
					return an - Math.Cos(dC);
				}
			case ArithmeticTypes.Round:
				switch (arithmeticTypes2)
				{
				default:
					return -1.0;
				case ArithmeticTypes.Sub:
					return an + Math.Round(dC);
				case ArithmeticTypes.Add:
					return an - Math.Round(dC);
				}
			case ArithmeticTypes.Sqrt:
				switch (arithmeticTypes2)
				{
				default:
					return -1.0;
				case ArithmeticTypes.Sub:
					return an + Math.Sqrt(dC);
				case ArithmeticTypes.Add:
					return an - Math.Sqrt(dC);
				}
			case ArithmeticTypes.Ceiling:
				switch (arithmeticTypes2)
				{
				default:
					return -1.0;
				case ArithmeticTypes.Sub:
					return an + Math.Ceiling(dC);
				case ArithmeticTypes.Add:
					return an - Math.Ceiling(dC);
				}
			case ArithmeticTypes.Floor:
				switch (arithmeticTypes2)
				{
				default:
					return -1.0;
				case ArithmeticTypes.Sub:
					return an + Math.Floor(dC);
				case ArithmeticTypes.Add:
					return an - Math.Floor(dC);
				}
			case ArithmeticTypes.Tan:
				switch (arithmeticTypes2)
				{
				default:
					return -1.0;
				case ArithmeticTypes.Sub:
					return an + Math.Tan(dC);
				case ArithmeticTypes.Add:
					return an - Math.Tan(dC);
				}
			case ArithmeticTypes.Tanh:
				switch (arithmeticTypes2)
				{
				default:
					return -1.0;
				case ArithmeticTypes.Sub:
					return an + Math.Tanh(dC);
				case ArithmeticTypes.Add:
					return an - Math.Tanh(dC);
				}
			case ArithmeticTypes.Truncate:
				switch (arithmeticTypes2)
				{
				default:
					return -1.0;
				case ArithmeticTypes.Sub:
					return an + Math.Truncate(dC);
				case ArithmeticTypes.Add:
					return an - Math.Truncate(dC);
				}
			}
		}

		public double GetY()
		{
			return dC;
		}
	}
}
