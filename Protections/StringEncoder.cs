using System;
using System.Text;

namespace Protections
{
	public static class StringEncoder
	{
		public static string Encryption(Tuple<string, int> values)
		{
			StringBuilder stringBuilder = new StringBuilder(values.Item1);
			StringBuilder stringBuilder2 = new StringBuilder(values.Item1.Length);
			int item = values.Item2;
			for (int i = 0; i < values.Item1.Length; i++)
			{
				char c = stringBuilder[i];
				c = (char)(c ^ item);
				stringBuilder2.Append(c);
			}
			return stringBuilder2.ToString();
		}
	}
}
