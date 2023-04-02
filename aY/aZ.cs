using System.Collections.Generic;
using System.Linq;
using cq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using ICore;

namespace aY
{
	internal class aZ
	{
		public static void ag(Context ctx)
		{
			IEnumerable<IDnlibDef> source = InjectHelper.Inject(ModuleDefMD.Load(typeof(cq.aZ).Module).ResolveTypeDef(MDToken.ToRID(typeof(cq.aZ).MetadataToken)), ctx.Module.GlobalType, ctx.Module);
			MethodDef methodDef = ctx.Module.GlobalType.FindOrCreateStaticConstructor();
			MethodDef methodDef2 = (MethodDef)source.Single((IDnlibDef method) => method.Name == "Initialize");
			((MethodDef)source.Single((IDnlibDef method) => method.Name == "VP")).Name = Utils.GenerateString();
			methodDef2.Name = Utils.GenerateString();
			methodDef.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, methodDef2));
		}
	}
}
