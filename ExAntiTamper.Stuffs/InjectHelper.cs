using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace ExAntiTamper.Stuffs
{
	public static class InjectHelper
	{
		private class gy : ImportMapper
		{
			public readonly Dictionary<IMemberRef, IMemberRef> gz = new Dictionary<IMemberRef, IMemberRef>();

			public readonly ModuleDef gA;

			public readonly ModuleDef gB;

			[CompilerGenerated]
			private readonly Importer gC;

			public Importer gE
			{
				[CompilerGenerated]
				get
				{
					return gC;
				}
			}

			public gy(ModuleDef module, ModuleDef target)
			{
				gA = module;
				gB = target;
				gC = new Importer(target, ImporterOptions.TryToUseTypeDefs, default(GenericParamContext), this);
			}

			public override ITypeDefOrRef Map(ITypeDefOrRef source)
			{
				if (!gz.TryGetValue(source, out var value))
				{
					if (source is TypeRef typeRef)
					{
						AssemblyRef assemblyRef = gB.GetAssemblyRef(typeRef.DefinitionAssembly.Name);
						if (assemblyRef != null && !string.Equals(assemblyRef.FullName, source.DefinitionAssembly.FullName, StringComparison.Ordinal))
						{
							TypeRefUser type = new TypeRefUser(typeRef.Module, typeRef.Namespace, typeRef.Name, assemblyRef);
							return gE.Import(type);
						}
					}
					return null;
				}
				return value as ITypeDefOrRef;
			}

			public override IMethod Map(MethodDef source)
			{
				if (gz.TryGetValue(source, out var value))
				{
					return value as IMethod;
				}
				return null;
			}

			public override IField Map(FieldDef source)
			{
				if (gz.TryGetValue(source, out var value))
				{
					return value as IField;
				}
				return null;
			}

			public override MemberRef Map(MemberRef source)
			{
				if (gz.TryGetValue(source, out var value))
				{
					return value as MemberRef;
				}
				return null;
			}
		}

		private static TypeDefUser aD(TypeDef origin)
		{
			TypeDefUser typeDefUser = new TypeDefUser(origin.Namespace, origin.Name);
			typeDefUser.Attributes = origin.Attributes;
			if (origin.ClassLayout != null)
			{
				typeDefUser.ClassLayout = new ClassLayoutUser(origin.ClassLayout.PackingSize, origin.ClassSize);
			}
			foreach (GenericParam genericParameter in origin.GenericParameters)
			{
				typeDefUser.GenericParameters.Add(new GenericParamUser(genericParameter.Number, genericParameter.Flags, "-"));
			}
			return typeDefUser;
		}

		private static MethodDefUser aD(MethodDef origin)
		{
			MethodDefUser methodDefUser = new MethodDefUser(origin.Name, null, origin.ImplAttributes, origin.Attributes);
			foreach (GenericParam genericParameter in origin.GenericParameters)
			{
				methodDefUser.GenericParameters.Add(new GenericParamUser(genericParameter.Number, genericParameter.Flags, "-"));
			}
			return methodDefUser;
		}

		private static FieldDefUser aD(FieldDef origin)
		{
			return new FieldDefUser(origin.Name, null, origin.Attributes);
		}

		private static TypeDef aE(TypeDef typeDef, gy ctx)
		{
			TypeDef typeDef2 = ctx.Map(typeDef)?.ResolveTypeDef();
			if (typeDef2 == null)
			{
				typeDef2 = aD(typeDef);
				ctx.gz[typeDef] = typeDef2;
			}
			foreach (TypeDef nestedType in typeDef.NestedTypes)
			{
				typeDef2.NestedTypes.Add(aE(nestedType, ctx));
			}
			foreach (MethodDef method in typeDef.Methods)
			{
				IList<MethodDef> methods = typeDef2.Methods;
				IMemberRef memberRef2 = (ctx.gz[method] = aD(method));
				methods.Add((MethodDef)memberRef2);
			}
			foreach (FieldDef field in typeDef.Fields)
			{
				IList<FieldDef> fields = typeDef2.Fields;
				IMemberRef memberRef2 = (ctx.gz[field] = aD(field));
				fields.Add((FieldDef)memberRef2);
			}
			return typeDef2;
		}

		private static void aF(TypeDef typeDef, gy ctx)
		{
			TypeDef typeDef2 = ctx.Map(typeDef)?.ResolveTypeDefThrow();
			typeDef2.BaseType = ctx.gE.Import(typeDef.BaseType);
			foreach (InterfaceImpl @interface in typeDef.Interfaces)
			{
				typeDef2.Interfaces.Add(new InterfaceImplUser(ctx.gE.Import(@interface.Interface)));
			}
		}

		private static void aG(MethodDef methodDef, gy ctx)
		{
			MethodDef methodDef2 = ctx.Map(methodDef)?.ResolveMethodDefThrow();
			methodDef2.Signature = ctx.gE.Import(methodDef.Signature);
			methodDef2.Parameters.UpdateParameterTypes();
			foreach (ParamDef paramDef in methodDef.ParamDefs)
			{
				methodDef2.ParamDefs.Add(new ParamDefUser(paramDef.Name, paramDef.Sequence, paramDef.Attributes));
			}
			if (methodDef.ImplMap != null)
			{
				methodDef2.ImplMap = new ImplMapUser(new ModuleRefUser(ctx.gB, methodDef.ImplMap.Module.Name), methodDef.ImplMap.Name, methodDef.ImplMap.Attributes);
			}
			foreach (CustomAttribute customAttribute in methodDef.CustomAttributes)
			{
				methodDef2.CustomAttributes.Add(new CustomAttribute((ICustomAttributeType)ctx.gE.Import(customAttribute.Constructor)));
			}
			if (methodDef.HasBody)
			{
				aH(methodDef, ctx, methodDef2);
			}
		}

		private static void aH(MethodDef methodDef, gy ctx, MethodDef newMethodDef)
		{
			newMethodDef.Body = new CilBody(methodDef.Body.InitLocals, new List<Instruction>(), new List<ExceptionHandler>(), new List<Local>())
			{
				MaxStack = methodDef.Body.MaxStack
			};
			Dictionary<object, object> bodyMap = new Dictionary<object, object>();
			foreach (Local variable in methodDef.Body.Variables)
			{
				Local local = new Local(ctx.gE.Import(variable.Type));
				newMethodDef.Body.Variables.Add(local);
				local.Name = variable.Name;
				bodyMap[variable] = local;
			}
			foreach (Instruction instruction2 in methodDef.Body.Instructions)
			{
				Instruction instruction = new Instruction(instruction2.OpCode, instruction2.Operand)
				{
					SequencePoint = instruction2.SequencePoint
				};
				object operand = instruction.Operand;
				if (operand != null)
				{
					if (!(operand is IType type))
					{
						if (!(operand is IMethod method))
						{
							if (operand is IField field)
							{
								IField field2 = field;
								instruction.Operand = ctx.gE.Import(field2);
							}
						}
						else
						{
							IMethod method2 = method;
							instruction.Operand = ctx.gE.Import(method2);
						}
					}
					else
					{
						IType type2 = type;
						instruction.Operand = ctx.gE.Import(type2);
					}
				}
				newMethodDef.Body.Instructions.Add(instruction);
				bodyMap[instruction2] = instruction;
			}
			foreach (Instruction instruction3 in newMethodDef.Body.Instructions)
			{
				if (instruction3.Operand != null && bodyMap.ContainsKey(instruction3.Operand))
				{
					instruction3.Operand = bodyMap[instruction3.Operand];
				}
				else if (instruction3.Operand is Instruction[] source)
				{
					instruction3.Operand = source.Select((Instruction target) => (Instruction)bodyMap[target]).ToArray();
				}
			}
			foreach (ExceptionHandler exceptionHandler in methodDef.Body.ExceptionHandlers)
			{
				newMethodDef.Body.ExceptionHandlers.Add(new ExceptionHandler(exceptionHandler.HandlerType)
				{
					CatchType = ((exceptionHandler.CatchType == null) ? null : ctx.gE.Import(exceptionHandler.CatchType)),
					TryStart = (Instruction)bodyMap[exceptionHandler.TryStart],
					TryEnd = (Instruction)bodyMap[exceptionHandler.TryEnd],
					HandlerStart = (Instruction)bodyMap[exceptionHandler.HandlerStart],
					HandlerEnd = (Instruction)bodyMap[exceptionHandler.HandlerEnd],
					FilterStart = ((exceptionHandler.FilterStart == null) ? null : ((Instruction)bodyMap[exceptionHandler.FilterStart]))
				});
			}
			newMethodDef.Body.SimplifyMacros(newMethodDef.Parameters);
		}

		private static void aI(FieldDef fieldDef, gy ctx)
		{
			ctx.Map(fieldDef).ResolveFieldDefThrow().Signature = ctx.gE.Import(fieldDef.Signature);
		}

		private static void Copy(TypeDef typeDef, gy ctx, bool copySelf)
		{
			if (copySelf)
			{
				aF(typeDef, ctx);
			}
			foreach (TypeDef nestedType in typeDef.NestedTypes)
			{
				Copy(nestedType, ctx, copySelf: true);
			}
			foreach (MethodDef method in typeDef.Methods)
			{
				aG(method, ctx);
			}
			foreach (FieldDef field in typeDef.Fields)
			{
				aI(field, ctx);
			}
		}

		public static TypeDef Inject(TypeDef typeDef, ModuleDef target)
		{
			gy ctx = new gy(typeDef.Module, target);
			TypeDef result = aE(typeDef, ctx);
			Copy(typeDef, ctx, copySelf: true);
			return result;
		}

		public static MethodDef Inject(MethodDef methodDef, ModuleDef target)
		{
			gy gy = new gy(methodDef.Module, target);
			MethodDef result = (MethodDef)(gy.gz[methodDef] = aD(methodDef));
			aG(methodDef, gy);
			return result;
		}

		public static IEnumerable<IDnlibDef> Inject(TypeDef typeDef, TypeDef newType, ModuleDef target)
		{
			gy gy = new gy(typeDef.Module, target);
			gy.gz[typeDef] = newType;
			aE(typeDef, gy);
			Copy(typeDef, gy, copySelf: false);
			return gy.gz.Values.Except(new TypeDef[1] { newType }).OfType<IDnlibDef>();
		}
	}
}
