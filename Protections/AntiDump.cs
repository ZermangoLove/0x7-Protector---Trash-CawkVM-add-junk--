using System.Linq;
using cq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using Helpers.Injection;
using ICore;

namespace Protections
{
	public class AntiDump
	{
		public static void Execute(Context context)
		{
			ModuleDef module = context.Module;
			MethodDef methodDef = (MethodDef)Helpers.Injection.InjectHelper.Inject(ModuleDefMD.Load(typeof(cs).Module).ResolveTypeDef(MDToken.ToRID(typeof(cs).MetadataToken)), module.EntryPoint.DeclaringType, module).Single((IDnlibDef method) => method.Name == "Initialize");
			module.EntryPoint.Body.Instructions.Insert(0, OpCodes.Call.ToInstruction(methodDef));
			methodDef.Name = Utils.GenerateString();
		}
	}
}
