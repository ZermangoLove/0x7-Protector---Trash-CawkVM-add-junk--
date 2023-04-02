using dnlib.DotNet;
using ICore;

namespace w
{
	internal class v
	{
		public static void x(Context context)
		{
			TypeRef typeRef = context.Module.CorLibTypes.GetTypeRef("System.Runtime.CompilerServices", "UnsafeValueTypeAttribute");
			CustomAttribute item = new CustomAttribute(new MemberRefUser(context.Module, ".ctor", MethodSig.CreateInstance(context.Module.CorLibTypes.Void), typeRef));
			context.Module.CustomAttributes.Add(item);
			TypeRef typeRef2 = context.Module.CorLibTypes.GetTypeRef("System.Runtime.CompilerServices", "UnverifiableCodeAttribute");
			CustomAttribute item2 = new CustomAttribute(new MemberRefUser(context.Module, ".ctor", MethodSig.CreateInstance(context.Module.CorLibTypes.Void), typeRef2));
			context.Module.CustomAttributes.Add(item2);
			TypeRef typeRef3 = context.Module.CorLibTypes.GetTypeRef("System.Runtime.CompilerServices", "SuppressUnmanagedCodeSecurity");
			CustomAttribute item3 = new CustomAttribute(new MemberRefUser(context.Module, ".ctor", MethodSig.CreateInstance(context.Module.CorLibTypes.Void), typeRef3));
			context.Module.CustomAttributes.Add(item3);
		}
	}
}
