using dnlib.DotNet;
using ICore;

namespace Protections
{
	public class MathMutation
	{
		public static void Execute(Context ctx)
		{
			MathHelper mathHelper = new MathHelper();
			foreach (TypeDef type in ctx.Module.GetTypes())
			{
				foreach (MethodDef method in type.Methods)
				{
					mathHelper.Execute(method, ctx);
				}
			}
		}
	}
}
