using System;
using System.Text;

namespace aY
{
	internal class be
	{
		public static string bf(string toEncode)
		{
			return Convert.ToBase64String(Encoding.ASCII.GetBytes(toEncode));
		}
	}
}
