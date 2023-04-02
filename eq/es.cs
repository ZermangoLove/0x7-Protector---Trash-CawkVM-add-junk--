using dnlib.DotNet.Emit;
using ek;
using Helpers.Emulator;

namespace eq
{
	internal class es : ej
	{
		internal override OpCode em => OpCodes.Blt;

		internal override void en(EmuContext context, Instruction instr)
		{
			int num = (int)context.ee.Pop();
			if ((int)context.ee.Pop() < num)
			{
				context.eg = context.ef.IndexOf((Instruction)instr.Operand);
			}
		}
	}
}
