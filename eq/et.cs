using dnlib.DotNet.Emit;
using ek;
using Helpers.Emulator;

namespace eq
{
	internal class et : ej
	{
		internal override OpCode em => OpCodes.Br;

		internal override void en(EmuContext context, Instruction instr)
		{
			context.eg = context.ef.IndexOf((Instruction)instr.Operand);
		}
	}
}
