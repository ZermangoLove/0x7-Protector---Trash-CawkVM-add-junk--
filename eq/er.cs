using dnlib.DotNet.Emit;
using ek;
using Helpers.Emulator;

namespace eq
{
	internal class er : ej
	{
		internal override OpCode em => OpCodes.And;

		internal override void en(EmuContext context, Instruction instr)
		{
			int num = (int)context.ee.Pop();
			int num2 = (int)context.ee.Pop();
			context.ee.Push(num2 & num);
		}
	}
}
