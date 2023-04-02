using System;

namespace Helpers
{
	public class RandomHelper
	{
		private int dO;

		private int dP;

		private int[] dQ = new int[56];

		private const int dR = int.MaxValue;

		private const int dS = 161803398;

		private const int dT = 0;

		public RandomHelper(int Seed)
		{
			int num = 161803398 - ((Seed == int.MinValue) ? int.MaxValue : Math.Abs(Seed));
			dQ[55] = num;
			int num2 = 1;
			for (int i = 1; i < 55; i++)
			{
				int num3 = 21 * i % 55;
				dQ[num3] = num2;
				num2 = num - num2;
				if (num2 < 0)
				{
					num2 += int.MaxValue;
				}
				num = dQ[num3];
			}
			for (int j = 1; j < 5; j++)
			{
				for (int k = 1; k < 56; k++)
				{
					dQ[k] -= dQ[1 + (k + 30) % 55];
					if (dQ[k] < 0)
					{
						dQ[k] += int.MaxValue;
					}
				}
			}
			dO = 0;
			dP = 21;
			Seed = 1;
		}

		public double InternalSample()
		{
			dO = 0;
			int num = 0;
			dP = 21;
			int num2 = 21;
			num = 1;
			num2 = 22;
			int num3 = dQ[1] - dQ[22];
			if (num3 == int.MaxValue)
			{
				num3--;
			}
			if (num3 < 0)
			{
				num3 += int.MaxValue;
			}
			dQ[num] = num3;
			dO = num;
			dP = num2;
			return num3;
		}
	}
}
