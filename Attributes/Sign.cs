using dnlib.DotNet;
using dnlib.DotNet.Emit;
using ICore;
using j;

namespace Attributes
{
	public static class Sign
	{
		public static void Add(Context context)
		{
			TypeRef typeRef = context.Module.CorLibTypes.GetTypeRef("System", "Attribute");
			TypeDefUser typeDefUser = new TypeDefUser("", i.p(), typeRef);
			context.Module.Types.Add(typeDefUser);
			MethodDefUser methodDefUser = new MethodDefUser(".ctor", MethodSig.CreateInstance(context.Module.CorLibTypes.Void, context.Module.CorLibTypes.String), MethodImplAttributes.IL, MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName);
			methodDefUser.Body = new CilBody();
			methodDefUser.Body.MaxStack = 1;
			methodDefUser.Body.Instructions.Add(OpCodes.Ldarg_0.ToInstruction());
			methodDefUser.Body.Instructions.Add(OpCodes.Call.ToInstruction(new MemberRefUser(context.Module, ".ctor", MethodSig.CreateInstance(context.Module.CorLibTypes.Void), typeRef)));
			methodDefUser.Body.Instructions.Add(OpCodes.Ret.ToInstruction());
			typeDefUser.Methods.Add(methodDefUser);
			CustomAttribute customAttribute = new CustomAttribute(methodDefUser);
			customAttribute.ConstructorArguments.Add(new CAArgument(context.Module.CorLibTypes.String, "0x7 Protector"));
			context.Module.CustomAttributes.Add(customAttribute);
		}
	}
}
