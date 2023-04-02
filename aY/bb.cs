using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using ICore;

namespace aY
{
	internal class bb
	{
		public static void ag(Context ctx)
		{
			TypeDef typeDef = ModuleDefMD.Load(typeof(ba).Module).ResolveTypeDef(MDToken.ToRID(typeof(ba).MetadataToken));
			_ = ctx.Module;
			for (int i = 0; i < 25; i++)
			{
				MethodDef methodDef = (MethodDef)InjectHelper.Inject(typeDef, ctx.Module.EntryPoint.DeclaringType, ctx.Module).Single((IDnlibDef method) => method.Name == "Initialize");
				MethodDef entryPoint = ctx.Module.EntryPoint;
				methodDef.Name = Utils.GenerateString();
				entryPoint.Body.Instructions.Insert(0, OpCodes.Call.ToInstruction(methodDef));
			}
		}
	}
}
