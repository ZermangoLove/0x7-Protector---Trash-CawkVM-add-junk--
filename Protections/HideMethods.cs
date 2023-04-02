using dnlib.DotNet;
using dnlib.DotNet.Emit;
using ICore;

namespace Protections
{
	public class HideMethods
	{
		public static void Execute(Context context)
		{
			foreach (TypeDef type in context.Module.GetTypes())
			{
				foreach (MethodDef method in type.Methods)
				{
					if (method.HasBody && method.Body.HasInstructions && !method.DeclaringType.IsGlobalModuleType)
					{
						Hide(method);
					}
				}
			}
		}

		public static void Hide(MethodDef method)
		{
			if (!method.HasBody || !method.Body.HasInstructions || method.DeclaringType.IsGlobalModuleType)
			{
				method.Body.Instructions.Insert(1, new Instruction(OpCodes.Br_S, method.Body.Instructions[1]));
				method.Body.Instructions.Insert(2, new Instruction(OpCodes.Unaligned, 0));
			}
		}
	}
}
