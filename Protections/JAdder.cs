using ICore;

namespace Protections
{
	public class JAdder
	{
		public static void Add(Context context, int num, string mname, string content)
		{
			Utils.CreateMethod(context.Module, num, mname, content);
		}
	}
}
