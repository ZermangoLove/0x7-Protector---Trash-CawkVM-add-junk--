using System.Collections.Generic;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using Helpers.Injection;
using Helpers.Mutations;
using ICore;
using Protections;
using U;

namespace aY
{
	internal class bk
	{
		public static void bj(Context context)
		{
			IEnumerable<IDnlibDef> source = Helpers.Injection.InjectHelper.Inject(ModuleDefMD.Load(typeof(ac).Module).ResolveTypeDef(MDToken.ToRID(typeof(ac).MetadataToken)), context.Module.EntryPoint.DeclaringType, context.Module);
			MethodDef methodDef = (MethodDef)source.Single((IDnlibDef method) => method.Name == "Init");
			context.Module.EntryPoint.Body.Instructions.Insert(0, OpCodes.Call.ToInstruction(methodDef));
			MethodDef obj = (MethodDef)source.Single((IDnlibDef method) => method.Name == "DoWork");
			MutationHelper.InjectString(obj, "b", global.Status);
			methodDef.Name = Utils.GenerateString();
			obj.Name = Utils.GenerateString();
		}
	}
}
