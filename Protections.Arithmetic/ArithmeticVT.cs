namespace Protections.Arithmetic
{
	public class ArithmeticVT
	{
		private readonly Value dF;

		private readonly Token dG;

		private readonly ArithmeticTypes dD;

		public ArithmeticVT(Value value, Token token, ArithmeticTypes arithmeticTypes)
		{
			dF = value;
			dG = token;
			dD = arithmeticTypes;
		}

		public Value GetValue()
		{
			return dF;
		}

		public Token GetToken()
		{
			return dG;
		}

		public ArithmeticTypes GetArithmetic()
		{
			return dD;
		}
	}
}
