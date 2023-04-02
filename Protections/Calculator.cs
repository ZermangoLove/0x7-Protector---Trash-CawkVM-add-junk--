using System;
using dnlib.DotNet.Emit;

namespace Protections
{
	public class Calculator
	{
		public static Random rnd = new Random();

		private OpCode bm;

		private int bn;

		public Calculator(int value, int value2)
		{
			bn = bo(value, value2);
		}

		public int getResult()
		{
			return bn;
		}

		public OpCode getOpCode()
		{
			return bm;
		}

		private int bo(int num, int num2)
		{
			int result = 0;
			switch (rnd.Next(0, 3))
			{
			case 0:
				result = num + num2;
				bm = OpCodes.Sub;
				break;
			case 1:
				result = num ^ num2;
				bm = OpCodes.Xor;
				break;
			case 2:
				result = num - num2;
				bm = OpCodes.Add;
				break;
			}
			return result;
		}
	}
}
