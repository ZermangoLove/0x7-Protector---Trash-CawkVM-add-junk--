using System.Diagnostics;

namespace aY
{
	internal static class ba
	{
		private static void Initialize()
		{
			if (Debugger.IsAttached || Debugger.IsLogging())
			{
				Process.GetCurrentProcess().Kill();
			}
		}
	}
}
