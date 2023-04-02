using dnlib.DotNet.Emit;
using ek;
using Helpers.Emulator;

namespace eq
{
	internal class eu : ej
	{
		internal override OpCode em => OpCodes.Ldc_I4;

		internal override void en(EmuContext context, Instruction instr)
		{
			context.ee.Push(instr.Operand);
		}
	}
}
