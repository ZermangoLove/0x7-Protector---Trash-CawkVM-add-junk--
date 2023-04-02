using System;
using System.Collections.Generic;
using System.Diagnostics;
using Core.Protection;

namespace Core.Injection
{
	internal class InjectMethods
	{
		public static void methodInjector()
		{
			int num = 567370464;
			int num2 = 1;
			int num3 = default(int);
			List<MethodData>.Enumerator enumerator = default(List<MethodData>.Enumerator);
			do
			{
				if (num2 == -567370463 + num)
				{
					num3 = 567370464 - num;
					num2 = -567370462 + num;
				}
				if (num2 == (0x21D162E2 ^ num))
				{
					enumerator = MethodProccesor.AllMethods.GetEnumerator();
					num2 = 0x21D162E3 ^ num;
				}
				if (num2 == -567370464 + num)
				{
					num2 = 0x21D162E1 ^ num;
				}
			}
			while (num2 != -567370461 + num);
			try
			{
				while (enumerator.MoveNext())
				{
					MethodData current = enumerator.Current;
					new Stopwatch();
					current.position = num3;
					int num4 = (current.cipherSize = (current.DecryptedBytes.Length / (-567370448 + num) + (0x21D162E1 ^ num)) * (-567370448 + num));
					Console.WriteLine("     -> Injecting");
					InjectInitialise.InjectMethod(current.Method, current.position, current.ID, current.cipherSize);
					num3 += num4;
				}
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
		}
	}
}
