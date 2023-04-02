using System.Linq;
using cq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using Helpers.Injection;
using ICore;

namespace Protections
{
	public class AntiDebug
	{
		public static void Execute(Context context)
		{
			MethodDef methodDef = (MethodDef)Helpers.Injection.InjectHelper.Inject(ModuleDefMD.Load(typeof(cr).Module).ResolveTypeDef(MDToken.ToRID(typeof(cr).MetadataToken)), context.Module.EntryPoint.DeclaringType, context.Module).Single((IDnlibDef method) => method.Name == "Initialize");
			context.Module.EntryPoint.Body.Instructions.Insert(0, OpCodes.Call.ToInstruction(methodDef));
			methodDef.Name = Utils.GenerateString();
		}
	}
}
