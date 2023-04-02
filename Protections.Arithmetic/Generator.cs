using System;

namespace Protections.Arithmetic
{
	public class Generator
	{
		private readonly Random al;

		public Generator()
		{
			al = new Random(Guid.NewGuid().GetHashCode());
		}

		public int Next()
		{
			return al.Next(int.MaxValue);
		}

		public int Next(int value)
		{
			return al.Next(value);
		}

		public int Next(int min, int max)
		{
			return al.Next(min, max);
		}
	}
}
