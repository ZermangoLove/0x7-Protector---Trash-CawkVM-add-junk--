using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Protections.Arithmetic
{
	public abstract class iFunction
	{
		public abstract ArithmeticTypes ArithmeticTypes { get; }

		public abstract ArithmeticVT Arithmetic(Instruction instruction, ModuleDef module);
	}
}
