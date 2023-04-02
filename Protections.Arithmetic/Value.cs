namespace Protections.Arithmetic
{
	public class Value
	{
		private readonly double an;

		private readonly double dC;

		public Value(double x, double y)
		{
			an = x;
			dC = y;
		}

		public double GetX()
		{
			return an;
		}

		public double GetY()
		{
			return dC;
		}
	}
}
