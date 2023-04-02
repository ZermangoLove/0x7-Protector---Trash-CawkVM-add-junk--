using aY;
using dnlib.DotNet;
using ICore;

namespace Protections
{
	public class MathHelper
	{
		public void Execute(MethodDef method, Context ctx)
		{
			new aX.Arithmetic(ctx.Module).Execute(method);
		}
	}
}
