using System.Collections.Generic;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Helpers.Injection
{
	public static class InjectHelper
	{
		private class gy : ImportMapper
		{
			public readonly Dictionary<IDnlibDef, IDnlibDef> hz = new Dictionary<IDnlibDef, IDnlibDef>();

			public readonly ModuleDef gA;

			public readonly ModuleDef gB;

			private readonly Importer hA;

			public Importer gE => hA;

			public gy(ModuleDef module, ModuleDef target)
			{
				gA = module;
				gB = target;
				hA = new Importer(target, ImporterOptions.TryToUseTypeDefs, default(GenericParamContext), this);
			}

			public override ITypeDefOrRef Map(ITypeDefOrRef typeDefOrRef)
			{
				if (typeDefOrRef is TypeDef key && hz.ContainsKey(key))
				{
					return (TypeDef)hz[key];
				}
				return null;
			}

			public override IMethod Map(MethodDef methodDef)
			{
				if (hz.ContainsKey(methodDef))
				{
					return (MethodDef)hz[methodDef];
				}
				return null;
			}

			public override IField Map(FieldDef fieldDef)
			{
				if (hz.ContainsKey(fieldDef))
				{
					return (FieldDef)hz[fieldDef];
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
			TypeDef typeDef2;
			if (!ctx.hz.TryGetValue(typeDef, out var value))
			{
				typeDef2 = aD(typeDef);
				ctx.hz[typeDef] = typeDef2;
			}
			else
			{
				typeDef2 = (TypeDef)value;
			}
			foreach (TypeDef nestedType in typeDef.NestedTypes)
			{
				typeDef2.NestedTypes.Add(aE(nestedType, ctx));
			}
			foreach (MethodDef method in typeDef.Methods)
			{
				IList<MethodDef> methods = typeDef2.Methods;
				IDnlibDef dnlibDef2 = (ctx.hz[method] = aD(method));
				methods.Add((MethodDef)dnlibDef2);
			}
			foreach (FieldDef field in typeDef.Fields)
			{
				IList<FieldDef> fields = typeDef2.Fields;
				IDnlibDef dnlibDef2 = (ctx.hz[field] = aD(field));
				fields.Add((FieldDef)dnlibDef2);
			}
			return typeDef2;
		}

		private static void aF(TypeDef typeDef, gy ctx)
		{
			TypeDef typeDef2 = (TypeDef)ctx.hz[typeDef];
			typeDef2.BaseType = ctx.gE.Import(typeDef.BaseType);
			foreach (InterfaceImpl @interface in typeDef.Interfaces)
			{
				typeDef2.Interfaces.Add(new InterfaceImplUser(ctx.gE.Import(@interface.Interface)));
			}
		}

		private static void aG(MethodDef methodDef, gy ctx)
		{
			MethodDef methodDef2 = (MethodDef)ctx.hz[methodDef];
			methodDef2.Signature = ctx.gE.Import(methodDef.Signature);
			methodDef2.Parameters.UpdateParameterTypes();
			if (methodDef.ImplMap != null)
			{
				methodDef2.ImplMap = new ImplMapUser(new ModuleRefUser(ctx.gB, methodDef.ImplMap.Module.Name), methodDef.ImplMap.Name, methodDef.ImplMap.Attributes);
			}
			foreach (CustomAttribute customAttribute in methodDef.CustomAttributes)
			{
				methodDef2.CustomAttributes.Add(new CustomAttribute((ICustomAttributeType)ctx.gE.Import(customAttribute.Constructor)));
			}
			if (!methodDef.HasBody)
			{
				return;
			}
			methodDef2.Body = new CilBody(methodDef.Body.InitLocals, new List<Instruction>(), new List<ExceptionHandler>(), new List<Local>());
			methodDef2.Body.MaxStack = methodDef.Body.MaxStack;
			Dictionary<object, object> bodyMap = new Dictionary<object, object>();
			foreach (Local variable in methodDef.Body.Variables)
			{
				Local local = new Local(ctx.gE.Import(variable.Type));
				methodDef2.Body.Variables.Add(local);
				local.Name = variable.Name;
				bodyMap[variable] = local;
			}
			foreach (Instruction instruction2 in methodDef.Body.Instructions)
			{
				Instruction instruction = new Instruction(instruction2.OpCode, instruction2.Operand);
				instruction.SequencePoint = instruction2.SequencePoint;
				if (instruction.Operand is IType)
				{
					instruction.Operand = ctx.gE.Import((IType)instruction.Operand);
				}
				else if (instruction.Operand is IMethod)
				{
					instruction.Operand = ctx.gE.Import((IMethod)instruction.Operand);
				}
				else if (instruction.Operand is IField)
				{
					instruction.Operand = ctx.gE.Import((IField)instruction.Operand);
				}
				methodDef2.Body.Instructions.Add(instruction);
				bodyMap[instruction2] = instruction;
			}
			foreach (Instruction instruction3 in methodDef2.Body.Instructions)
			{
				if (instruction3.Operand != null && bodyMap.ContainsKey(instruction3.Operand))
				{
					instruction3.Operand = bodyMap[instruction3.Operand];
				}
				else if (instruction3.Operand is Instruction[])
				{
					instruction3.Operand = ((Instruction[])instruction3.Operand).Select((Instruction target) => (Instruction)bodyMap[target]).ToArray();
				}
			}
			foreach (ExceptionHandler exceptionHandler in methodDef.Body.ExceptionHandlers)
			{
				methodDef2.Body.ExceptionHandlers.Add(new ExceptionHandler(exceptionHandler.HandlerType)
				{
					CatchType = ((exceptionHandler.CatchType == null) ? null : ctx.gE.Import(exceptionHandler.CatchType)),
					TryStart = (Instruction)bodyMap[exceptionHandler.TryStart],
					TryEnd = (Instruction)bodyMap[exceptionHandler.TryEnd],
					HandlerStart = (Instruction)bodyMap[exceptionHandler.HandlerStart],
					HandlerEnd = (Instruction)bodyMap[exceptionHandler.HandlerEnd],
					FilterStart = ((exceptionHandler.FilterStart == null) ? null : ((Instruction)bodyMap[exceptionHandler.FilterStart]))
				});
			}
			methodDef2.Body.SimplifyMacros(methodDef2.Parameters);
		}

		private static void aI(FieldDef fieldDef, gy ctx)
		{
			((FieldDef)ctx.hz[fieldDef]).Signature = ctx.gE.Import(fieldDef.Signature);
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
			gy gy = new gy(typeDef.Module, target);
			aE(typeDef, gy);
			Copy(typeDef, gy, copySelf: true);
			return (TypeDef)gy.hz[typeDef];
		}

		public static MethodDef Inject(MethodDef methodDef, ModuleDef target)
		{
			gy gy = new gy(methodDef.Module, target);
			gy.hz[methodDef] = aD(methodDef);
			aG(methodDef, gy);
			return (MethodDef)gy.hz[methodDef];
		}

		public static IEnumerable<IDnlibDef> Inject(TypeDef typeDef, TypeDef newType, ModuleDef target)
		{
			gy gy = new gy(typeDef.Module, target);
			gy.hz[typeDef] = newType;
			aE(typeDef, gy);
			Copy(typeDef, gy, copySelf: false);
			return gy.hz.Values.Except(new TypeDef[1] { newType });
		}
	}
}
