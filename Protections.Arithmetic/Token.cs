using dnlib.DotNet.Emit;

namespace Protections.Arithmetic
{
	public class Token
	{
		private readonly OpCode dH;

		private readonly object dI;

		public Token(OpCode opCode, object Operand)
		{
			dH = opCode;
			dI = Operand;
		}

		public Token(OpCode opCode)
		{
			dH = opCode;
			dI = null;
		}

		public OpCode GetOpCode()
		{
			return dH;
		}

		public object GetOperand()
		{
			return dI;
		}
	}
}
