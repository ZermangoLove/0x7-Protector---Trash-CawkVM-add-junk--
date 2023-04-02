using System;
using System.Collections.Generic;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using dnlib.Utils;

public static class InjectHelper
{
	private class InjectContext : ImportMapper
	{
		public readonly Dictionary<IDnlibDef, IDnlibDef> map = new Dictionary<IDnlibDef, IDnlibDef>();

		public readonly ModuleDef OriginModule;

		public readonly ModuleDef TargetModule;

		private readonly Importer importer;

		public Importer Importer => importer;

		public InjectContext(ModuleDef module, ModuleDef target)
		{
			OriginModule = module;
			TargetModule = target;
			importer = new Importer(target, ImporterOptions.TryToUseTypeDefs, default(GenericParamContext), this);
		}

		public override ITypeDefOrRef Map(ITypeDefOrRef typeDefOrRef)
		{
			if (typeDefOrRef is TypeDef key && map.ContainsKey(key))
			{
				return (TypeDef)map[key];
			}
			return null;
		}

		public override IMethod Map(MethodDef methodDef)
		{
			if (map.ContainsKey(methodDef))
			{
				return (MethodDef)map[methodDef];
			}
			return null;
		}

		public override IField Map(FieldDef fieldDef)
		{
			if (map.ContainsKey(fieldDef))
			{
				return (FieldDef)map[fieldDef];
			}
			return null;
		}
	}

	private static TypeDefUser Clone(TypeDef origin)
	{
		int num = 607151774;
		int num2 = 1;
		TypeDefUser typeDefUser = default(TypeDefUser);
		IEnumerator<GenericParam> enumerator = default(IEnumerator<GenericParam>);
		do
		{
			if (num2 == 607151775 - num)
			{
				typeDefUser = new TypeDefUser(origin.Namespace, origin.Name);
				num2 = 0x2430669C ^ num;
			}
			if (num2 == (0x2430669C ^ num))
			{
				typeDefUser.Attributes = origin.Attributes;
				num2 = 0x2430669D ^ num;
			}
			if (num2 == 607151777 - num)
			{
				if (origin.ClassLayout == null)
				{
					goto IL_00c7;
				}
				num2 = 0x2430669A ^ num;
			}
			if (num2 == (0x2430669A ^ num))
			{
				typeDefUser.ClassLayout = new ClassLayoutUser(origin.ClassLayout.PackingSize, origin.ClassSize);
				num2 = 0x2430669B ^ num;
			}
			if (num2 == (0x2430669B ^ num))
			{
				goto IL_00c7;
			}
			goto IL_00e7;
			IL_00e7:
			if (num2 == 607151774 - num)
			{
				num2 = 0x2430669F ^ num;
			}
			continue;
			IL_00c7:
			enumerator = origin.GenericParameters.GetEnumerator();
			num2 = 0x24306698 ^ num;
			goto IL_00e7;
		}
		while (num2 != 607151780 - num);
		try
		{
			while (enumerator.MoveNext())
			{
				GenericParam current = enumerator.Current;
				typeDefUser.GenericParameters.Add(new GenericParamUser(current.Number, current.Flags, "-"));
			}
			return typeDefUser;
		}
		finally
		{
			enumerator?.Dispose();
		}
	}

	private static MethodDefUser Clone(MethodDef origin)
	{
		int num = 529260887;
		int num2 = 1;
		MethodDefUser methodDefUser = default(MethodDefUser);
		IEnumerator<GenericParam> enumerator = default(IEnumerator<GenericParam>);
		do
		{
			if (num2 == -529260886 + num)
			{
				methodDefUser = new MethodDefUser(origin.Name, null, origin.ImplAttributes, origin.Attributes);
				num2 = 0x1F8BE155 ^ num;
			}
			if (num2 == -529260885 + num)
			{
				enumerator = origin.GenericParameters.GetEnumerator();
				num2 = 529260890 - num;
			}
			if (num2 == 529260887 - num)
			{
				num2 = -529260886 + num;
			}
		}
		while (num2 != (0x1F8BE154 ^ num));
		try
		{
			while (enumerator.MoveNext())
			{
				GenericParam current = enumerator.Current;
				methodDefUser.GenericParameters.Add(new GenericParamUser(current.Number, current.Flags, "-"));
			}
			return methodDefUser;
		}
		finally
		{
			enumerator?.Dispose();
		}
	}

	private static FieldDefUser Clone(FieldDef origin)
	{
		int num = 1276495277;
		int num2 = 1;
		do
		{
			if (num2 == -1276495277 + num)
			{
				num2 = -1276495276 + num;
			}
		}
		while (num2 != (0x4C15C5AC ^ num));
		return new FieldDefUser(origin.Name, null, origin.Attributes);
	}

	private static TypeDef PopulateContext(TypeDef typeDef, InjectContext ctx)
	{
		int num = 2014880888;
		int num2 = 1;
		IDnlibDef value = default(IDnlibDef);
		TypeDef typeDef2 = default(TypeDef);
		IEnumerator<TypeDef> enumerator = default(IEnumerator<TypeDef>);
		do
		{
			if (num2 == -2014880887 + num)
			{
				if (ctx.map.TryGetValue(typeDef, out value))
				{
					goto IL_009a;
				}
				num2 = 2014880890 - num;
			}
			if (num2 == (0x7818A47A ^ num))
			{
				typeDef2 = Clone(typeDef);
				num2 = -2014880885 + num;
			}
			if (num2 == 2014880891 - num)
			{
				ctx.map[typeDef] = typeDef2;
				num2 = 0x7818A47C ^ num;
			}
			if (num2 != 2014880892 - num)
			{
				if (num2 == (0x7818A47D ^ num))
				{
					goto IL_009a;
				}
				goto IL_00b5;
			}
			goto IL_00c7;
			IL_00c7:
			enumerator = typeDef.NestedTypes.GetEnumerator();
			num2 = 2014880895 - num;
			goto IL_00e7;
			IL_00b5:
			if (num2 == -2014880882 + num)
			{
				goto IL_00c7;
			}
			goto IL_00e7;
			IL_00e7:
			if (num2 == -2014880888 + num)
			{
				num2 = -2014880887 + num;
			}
			continue;
			IL_009a:
			typeDef2 = (TypeDef)value;
			num2 = -2014880882 + num;
			goto IL_00b5;
		}
		while (num2 != 2014880895 - num);
		try
		{
			while (enumerator.MoveNext())
			{
				TypeDef current = enumerator.Current;
				typeDef2.NestedTypes.Add(PopulateContext(current, ctx));
			}
		}
		finally
		{
			enumerator?.Dispose();
		}
		foreach (MethodDef method in typeDef.Methods)
		{
			IList<MethodDef> methods = typeDef2.Methods;
			IDnlibDef dnlibDef2 = (ctx.map[method] = Clone(method));
			methods.Add((MethodDef)dnlibDef2);
		}
		foreach (FieldDef field in typeDef.Fields)
		{
			IList<FieldDef> fields = typeDef2.Fields;
			IDnlibDef dnlibDef2 = (ctx.map[field] = Clone(field));
			fields.Add((FieldDef)dnlibDef2);
		}
		return typeDef2;
	}

	private static void CopyTypeDef(TypeDef typeDef, InjectContext ctx)
	{
		int num = 1443638686;
		int num2 = 1;
		TypeDef typeDef2 = default(TypeDef);
		IEnumerator<InterfaceImpl> enumerator = default(IEnumerator<InterfaceImpl>);
		do
		{
			if (num2 == -1443638685 + num)
			{
				typeDef2 = (TypeDef)ctx.map[typeDef];
				num2 = 1443638688 - num;
			}
			if (num2 == (0x560C2D9C ^ num))
			{
				typeDef2.BaseType = ctx.Importer.Import(typeDef.BaseType);
				num2 = -1443638683 + num;
			}
			if (num2 == -1443638683 + num)
			{
				enumerator = typeDef.Interfaces.GetEnumerator();
				num2 = -1443638682 + num;
			}
			if (num2 == -1443638686 + num)
			{
				num2 = -1443638685 + num;
			}
		}
		while (num2 != -1443638682 + num);
		try
		{
			while (enumerator.MoveNext())
			{
				InterfaceImpl current = enumerator.Current;
				typeDef2.Interfaces.Add(new InterfaceImplUser(ctx.Importer.Import(current.Interface)));
			}
		}
		finally
		{
			enumerator?.Dispose();
		}
	}

	private static void CopyMethodDef(MethodDef methodDef, InjectContext ctx)
	{
		int num = 305821427;
		int num2 = 1;
		MethodDef methodDef2 = default(MethodDef);
		LazyList<CustomAttribute>.Enumerator enumerator = default(LazyList<CustomAttribute>.Enumerator);
		do
		{
			if (num2 == 305821428 - num)
			{
				methodDef2 = (MethodDef)ctx.map[methodDef];
				num2 = 0x123A76F1 ^ num;
			}
			if (num2 == -305821425 + num)
			{
				methodDef2.Signature = ctx.Importer.Import(methodDef.Signature);
				num2 = -305821424 + num;
			}
			if (num2 == 305821430 - num)
			{
				methodDef2.Parameters.UpdateParameterTypes();
				num2 = 0x123A76F7 ^ num;
			}
			if (num2 == 305821431 - num)
			{
				if (methodDef.ImplMap == null)
				{
					goto IL_0134;
				}
				num2 = 0x123A76F6 ^ num;
			}
			if (num2 == -305821422 + num)
			{
				methodDef2.ImplMap = new ImplMapUser(new ModuleRefUser(ctx.TargetModule, methodDef.ImplMap.Module.Name), methodDef.ImplMap.Name, methodDef.ImplMap.Attributes);
				num2 = 305821433 - num;
			}
			if (num2 == (0x123A76F5 ^ num))
			{
				goto IL_0134;
			}
			goto IL_0154;
			IL_0134:
			enumerator = methodDef.CustomAttributes.GetEnumerator();
			num2 = 305821434 - num;
			goto IL_0154;
			IL_0154:
			if (num2 == -305821427 + num)
			{
				num2 = -305821426 + num;
			}
		}
		while (num2 != 305821434 - num);
		try
		{
			while (enumerator.MoveNext())
			{
				CustomAttribute current = enumerator.Current;
				methodDef2.CustomAttributes.Add(new CustomAttribute((ICustomAttributeType)ctx.Importer.Import(current.Constructor)));
			}
		}
		finally
		{
			((IDisposable)enumerator).Dispose();
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
			Local local = new Local(ctx.Importer.Import(variable.Type));
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
				instruction.Operand = ctx.Importer.Import((IType)instruction.Operand);
			}
			else if (instruction.Operand is IMethod)
			{
				instruction.Operand = ctx.Importer.Import((IMethod)instruction.Operand);
			}
			else if (instruction.Operand is IField)
			{
				instruction.Operand = ctx.Importer.Import((IField)instruction.Operand);
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
				CatchType = ((exceptionHandler.CatchType == null) ? null : ctx.Importer.Import(exceptionHandler.CatchType)),
				TryStart = (Instruction)bodyMap[exceptionHandler.TryStart],
				TryEnd = (Instruction)bodyMap[exceptionHandler.TryEnd],
				HandlerStart = (Instruction)bodyMap[exceptionHandler.HandlerStart],
				HandlerEnd = (Instruction)bodyMap[exceptionHandler.HandlerEnd],
				FilterStart = ((exceptionHandler.FilterStart == null) ? null : ((Instruction)bodyMap[exceptionHandler.FilterStart]))
			});
		}
		methodDef2.Body.SimplifyMacros(methodDef2.Parameters);
	}

	private static void CopyFieldDef(FieldDef fieldDef, InjectContext ctx)
	{
		int num = 1846620371;
		int num2 = 1;
		do
		{
			if (num2 == 1846620372 - num)
			{
				((FieldDef)ctx.map[fieldDef]).Signature = ctx.Importer.Import(fieldDef.Signature);
				num2 = 1846620373 - num;
			}
			if (num2 == -1846620371 + num)
			{
				num2 = 0x6E1130D2 ^ num;
			}
		}
		while (num2 != -1846620369 + num);
	}

	private static void Copy(TypeDef typeDef, InjectContext ctx, bool copySelf)
	{
		int num = 1546691562;
		int num2 = 1;
		IEnumerator<TypeDef> enumerator = default(IEnumerator<TypeDef>);
		do
		{
			if (num2 == -1546691561 + num)
			{
				if (!copySelf)
				{
					goto IL_0052;
				}
				num2 = 1546691564 - num;
			}
			if (num2 == (0x5C30A3E8 ^ num))
			{
				CopyTypeDef(typeDef, ctx);
				num2 = -1546691559 + num;
			}
			if (num2 == (0x5C30A3E9 ^ num))
			{
				goto IL_0052;
			}
			goto IL_0072;
			IL_0072:
			if (num2 == 1546691562 - num)
			{
				num2 = -1546691561 + num;
			}
			continue;
			IL_0052:
			enumerator = typeDef.NestedTypes.GetEnumerator();
			num2 = -1546691558 + num;
			goto IL_0072;
		}
		while (num2 != 1546691566 - num);
		try
		{
			while (enumerator.MoveNext())
			{
				Copy(enumerator.Current, ctx, (byte)(0x5C30A3EBu ^ (uint)num) != 0);
			}
		}
		finally
		{
			enumerator?.Dispose();
		}
		foreach (MethodDef method in typeDef.Methods)
		{
			CopyMethodDef(method, ctx);
		}
		foreach (FieldDef field in typeDef.Fields)
		{
			CopyFieldDef(field, ctx);
		}
	}

	public static TypeDef Inject(TypeDef typeDef, ModuleDef target)
	{
		int num = 281788338;
		int num2 = 1;
		InjectContext injectContext = default(InjectContext);
		do
		{
			if (num2 == 281788339 - num)
			{
				injectContext = new InjectContext(typeDef.Module, target);
				num2 = 0x10CBBFB0 ^ num;
			}
			if (num2 == (0x10CBBFB0 ^ num))
			{
				PopulateContext(typeDef, injectContext);
				num2 = 0x10CBBFB1 ^ num;
			}
			if (num2 == -281788335 + num)
			{
				Copy(typeDef, injectContext, (byte)(-281788337 + num) != 0);
				num2 = -281788334 + num;
			}
			if (num2 == (0x10CBBFB2 ^ num))
			{
				num2 = 281788339 - num;
			}
		}
		while (num2 != 281788342 - num);
		return (TypeDef)injectContext.map[typeDef];
	}

	public static MethodDef Inject(MethodDef methodDef, ModuleDef target)
	{
		int num = 1679496781;
		int num2 = 1;
		InjectContext injectContext = default(InjectContext);
		do
		{
			if (num2 == (0x641B164C ^ num))
			{
				injectContext = new InjectContext(methodDef.Module, target);
				num2 = 1679496783 - num;
			}
			if (num2 == (0x641B164F ^ num))
			{
				injectContext.map[methodDef] = Clone(methodDef);
				num2 = 1679496784 - num;
			}
			if (num2 == 1679496784 - num)
			{
				CopyMethodDef(methodDef, injectContext);
				num2 = 0x641B1649 ^ num;
			}
			if (num2 == 1679496781 - num)
			{
				num2 = 0x641B164C ^ num;
			}
		}
		while (num2 != (0x641B1649 ^ num));
		return (MethodDef)injectContext.map[methodDef];
	}

	public static IEnumerable<IDnlibDef> Inject(TypeDef typeDef, TypeDef newType, ModuleDef target)
	{
		int num = 2067851425;
		int num2 = 1;
		InjectContext injectContext = default(InjectContext);
		do
		{
			if (num2 == (0x7B40E8A0 ^ num))
			{
				injectContext = new InjectContext(typeDef.Module, target);
				num2 = 0x7B40E8A3 ^ num;
			}
			if (num2 == -2067851423 + num)
			{
				injectContext.map[typeDef] = newType;
				num2 = 2067851428 - num;
			}
			if (num2 == 2067851428 - num)
			{
				PopulateContext(typeDef, injectContext);
				num2 = -2067851421 + num;
			}
			if (num2 == (0x7B40E8A5 ^ num))
			{
				Copy(typeDef, injectContext, (byte)(0x7B40E8A1u ^ (uint)num) != 0);
				num2 = -2067851420 + num;
			}
			if (num2 == 2067851425 - num)
			{
				num2 = -2067851424 + num;
			}
		}
		while (num2 != -2067851420 + num);
		Dictionary<IDnlibDef, IDnlibDef>.ValueCollection values = injectContext.map.Values;
		TypeDef[] array = new TypeDef[2067851426 - num];
		array[0x7B40E8A1 ^ num] = newType;
		return values.Except(array);
	}
}
