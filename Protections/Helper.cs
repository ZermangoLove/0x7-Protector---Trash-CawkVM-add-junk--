using System.Collections.Generic;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using ICore;

namespace Protections
{
	public class Helper
	{
		public static void FixProxy(ModuleDef moduleDef)
		{
			AssemblyResolver assemblyResolver = new AssemblyResolver();
			ModuleContext context = (assemblyResolver.DefaultModuleContext = new ModuleContext(assemblyResolver));
			assemblyResolver.EnableTypeDefCache = true;
			List<AssemblyRef> list = moduleDef.GetAssemblyRefs().ToList();
			moduleDef.Context = context;
			foreach (AssemblyRef item in list)
			{
				if (item != null)
				{
					AssemblyDef assemblyDef = assemblyResolver.Resolve(item.FullName, moduleDef);
					if (assemblyDef != null)
					{
						((AssemblyResolver)moduleDef.Context.AssemblyResolver).AddToCache(assemblyDef);
					}
				}
			}
		}

		public static MethodDef GenerateMethod(TypeDef declaringType, object targetMethod, bool hasThis = false, bool isVoid = false)
		{
			MemberRef memberRef = (MemberRef)targetMethod;
			MethodDef methodDef = new MethodDefUser(Utils.GenerateString(), MethodSig.CreateStatic(memberRef.ReturnType), MethodAttributes.Public | MethodAttributes.Static);
			methodDef.Body = new CilBody();
			if (hasThis)
			{
				methodDef.MethodSig.Params.Add(declaringType.Module.Import(declaringType.ToTypeSig()));
			}
			foreach (TypeSig param in memberRef.MethodSig.Params)
			{
				methodDef.MethodSig.Params.Add(param);
			}
			methodDef.Parameters.UpdateParameterTypes();
			foreach (Parameter parameter in methodDef.Parameters)
			{
				methodDef.Body.Instructions.Add(Instruction.Create(OpCodes.Ldarg, parameter));
			}
			methodDef.Body.Instructions.Add(Instruction.Create(OpCodes.Call, memberRef));
			methodDef.Body.Instructions.Add(Instruction.Create(OpCodes.Ret));
			return methodDef;
		}

		public static MethodDef GenerateMethod(IMethod targetMethod, MethodDef md)
		{
			MethodDef methodDef = new MethodDefUser(Utils.GenerateString(), MethodSig.CreateStatic(md.Module.Import(targetMethod.DeclaringType.ToTypeSig())), MethodAttributes.Public | MethodAttributes.Static);
			methodDef.ImplAttributes = MethodImplAttributes.IL;
			methodDef.IsHideBySig = true;
			methodDef.Body = new CilBody();
			for (int i = 0; i < targetMethod.MethodSig.Params.Count; i++)
			{
				methodDef.ParamDefs.Add(new ParamDefUser(Utils.GenerateString(), (ushort)(i + 1)));
				methodDef.MethodSig.Params.Add(targetMethod.MethodSig.Params[i]);
			}
			methodDef.Parameters.UpdateParameterTypes();
			for (int j = 0; j < methodDef.Parameters.Count; j++)
			{
				Parameter operand = methodDef.Parameters[j];
				methodDef.Body.Instructions.Add(new Instruction(OpCodes.Ldarg, operand));
			}
			methodDef.Body.Instructions.Add(new Instruction(OpCodes.Newobj, targetMethod));
			methodDef.Body.Instructions.Add(new Instruction(OpCodes.Ret));
			return methodDef;
		}

		public static MethodDef GenerateMethod(FieldDef targetField, MethodDef md)
		{
			MethodDef methodDef = new MethodDefUser(Utils.GenerateString(), MethodSig.CreateStatic(md.Module.Import(targetField.FieldType)), MethodAttributes.Public | MethodAttributes.Static);
			methodDef.Body = new CilBody();
			TypeDef declaringType = md.DeclaringType;
			methodDef.MethodSig.Params.Add(md.Module.Import(declaringType).ToTypeSig());
			methodDef.Body.Instructions.Add(Instruction.Create(OpCodes.Ldarg_0));
			methodDef.Body.Instructions.Add(Instruction.Create(OpCodes.Ldfld, targetField));
			methodDef.Body.Instructions.Add(Instruction.Create(OpCodes.Ret));
			md.DeclaringType.Methods.Add(methodDef);
			return methodDef;
		}
	}
}
