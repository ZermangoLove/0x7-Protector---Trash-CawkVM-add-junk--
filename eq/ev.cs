using dnlib.DotNet.Emit;
using ek;
using Helpers.Emulator;

namespace eq
{
	internal class ev : ej
	{
		internal override OpCode em => OpCodes.Ldloc;

		internal override void en(EmuContext context, Instruction instr)
		{
			context.ee.Push(context.eh((Local)instr.Operand));
		}
	}
}
