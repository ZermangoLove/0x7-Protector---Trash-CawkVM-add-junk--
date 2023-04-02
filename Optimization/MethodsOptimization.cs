using System.Linq;
using dnlib.DotNet;
using ICore;

namespace Optimization
{
	public class MethodsOptimization
	{
		private static void attr()
		{
		}

		private static MethodDef y()
		{
			return ModuleDefMD.Load(typeof(MethodsOptimization).Module).Types.First((TypeDef s) => s.Name == "MethodsOptimization").FindMethod("attr");
		}

		public static void Optimize(Context context)
		{
			foreach (ModuleDef module in context.Module.Assembly.Modules)
			{
				foreach (TypeDef type in module.Types)
				{
					foreach (MethodDef method in type.Methods)
					{
						foreach (CustomAttribute customAttribute in y().CustomAttributes)
						{
							method.CustomAttributes.Add(customAttribute);
						}
					}
				}
			}
		}
	}
}
