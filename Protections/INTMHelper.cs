using System;
using System.Collections.Generic;
using dnlib.DotNet.Emit;

namespace Protections
{
	public class INTMHelper
	{
		private Random l = new Random();

		public List<Instruction> Calc(int value)
		{
			List<Instruction> list = new List<Instruction>();
			int num = l.Next(int.MaxValue);
			bool flag = Convert.ToBoolean(l.Next(1));
			int num2 = l.Next(int.MaxValue);
			list.Add(Instruction.Create(OpCodes.Ldc_I4, value - num + (flag ? (-num2) : num2)));
			list.Add(Instruction.Create(OpCodes.Ldc_I4, num));
			list.Add(Instruction.Create(OpCodes.Add));
			list.Add(Instruction.Create(OpCodes.Ldc_I4, num2));
			list.Add(Instruction.Create(flag ? OpCodes.Add : OpCodes.Sub));
			return list;
		}
	}
}
