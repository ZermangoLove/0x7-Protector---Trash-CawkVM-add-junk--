using System;
using System.Collections.Generic;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace cL
{
	internal class dc : cZ
	{
		private readonly ModuleDefMD dd;

		private bool de;

		private int df;

		public dc(ModuleDefMD ctx)
		{
			dd = ctx;
		}

		public void Init(CilBody body)
		{
			if (!de)
			{
				df = new Random().Next();
				de = true;
			}
		}

		public void da(IList<Instruction> instrs)
		{
			instrs.Add(Instruction.Create(OpCodes.Ldc_I4, df));
			instrs.Add(Instruction.Create(OpCodes.Xor));
		}

		public int db(int key)
		{
			return key ^ df;
		}
	}
}
