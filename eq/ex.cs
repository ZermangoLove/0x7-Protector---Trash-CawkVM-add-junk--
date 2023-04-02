using dnlib.DotNet.Emit;
using ek;
using Helpers.Emulator;

namespace eq
{
	internal class ex : ej
	{
		internal override OpCode em => OpCodes.Stloc;

		internal override void en(EmuContext context, Instruction instr)
		{
			object val = context.ee.Pop();
			context.ei((Local)instr.Operand, val);
		}
	}
}
