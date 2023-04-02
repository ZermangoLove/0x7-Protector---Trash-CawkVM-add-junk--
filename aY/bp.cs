using System.Linq;
using cq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using Helpers.Injection;
using ICore;

namespace aY
{
	internal class bp
	{
		public static void bj(Context context)
		{
			ModuleDef module = context.Module;
			MethodDef methodDef = (MethodDef)Helpers.Injection.InjectHelper.Inject(ModuleDefMD.Load(typeof(cv).Module).ResolveTypeDef(MDToken.ToRID(typeof(cv).MetadataToken)), module.EntryPoint.DeclaringType, module).Single((IDnlibDef method) => method.Name == "Initialize");
			module.EntryPoint.Body.Instructions.Insert(0, OpCodes.Call.ToInstruction(methodDef));
			methodDef.Name = Utils.GenerateString();
		}

		public static void bq(Context context)
		{
			ModuleDef module = context.Module;
			MethodDef methodDef = (MethodDef)Helpers.Injection.InjectHelper.Inject(ModuleDefMD.Load(typeof(cC).Module).ResolveTypeDef(MDToken.ToRID(typeof(cC).MetadataToken)), module.EntryPoint.DeclaringType, module).Single((IDnlibDef method) => method.Name == "Initialize");
			module.EntryPoint.Body.Instructions.Insert(0, OpCodes.Call.ToInstruction(methodDef));
			methodDef.Name = Utils.GenerateString();
		}
	}
}
