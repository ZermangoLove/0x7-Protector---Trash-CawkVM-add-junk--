using System;
using System.Collections.Generic;
using dnlib.DotNet;

namespace cj
{
	internal class ci
	{
		public static IEnumerable<IDnlibDef> ck(ModuleDef module)
		{
			yield return module;
			foreach (TypeDef type in module.GetTypes())
			{
				yield return type;
				foreach (MethodDef method in type.Methods)
				{
					yield return method;
				}
				foreach (FieldDef field in type.Fields)
				{
					yield return field;
				}
				foreach (PropertyDef property in type.Properties)
				{
					yield return property;
				}
				foreach (EventDef @event in type.Events)
				{
					yield return @event;
				}
			}
		}

		public static IEnumerable<IDnlibDef> ck(TypeDef typeDef)
		{
			yield return typeDef;
			foreach (TypeDef nestedType in typeDef.NestedTypes)
			{
				yield return nestedType;
			}
			foreach (MethodDef method in typeDef.Methods)
			{
				yield return method;
			}
			foreach (FieldDef field in typeDef.Fields)
			{
				yield return field;
			}
			foreach (PropertyDef property in typeDef.Properties)
			{
				yield return property;
			}
			foreach (EventDef @event in typeDef.Events)
			{
				yield return @event;
			}
		}

		public static bool cl(TypeDef type)
		{
			if (type.BaseType == null)
			{
				return false;
			}
			string fullName = type.BaseType.FullName;
			if (!(fullName == "System.Delegate"))
			{
				return fullName == "System.MulticastDelegate";
			}
			return true;
		}

		public static bool cm(MethodDef method)
		{
			if (method == null)
			{
				new ArgumentNullException("method is null");
			}
			if (method.Body.HasInstructions)
			{
				return true;
			}
			return false;
		}

		public static bool cn(MethodDef method)
		{
			if (method == null)
			{
				new ArgumentNullException("method is null");
			}
			if (method.Body.HasVariables)
			{
				return true;
			}
			return false;
		}

		public static bool co(MethodDef methodDef)
		{
			if (methodDef.Parameters == null)
			{
				return false;
			}
			methodDef.Body.SimplifyMacros(methodDef.Parameters);
			return true;
		}

		public static bool A(MethodDef methodDef)
		{
			if (methodDef.Body == null)
			{
				return false;
			}
			methodDef.Body.OptimizeMacros();
			methodDef.Body.OptimizeBranches();
			return true;
		}

		public static bool cp(MethodDef methodDef)
		{
			if (methodDef.Body.HasExceptionHandlers)
			{
				return true;
			}
			return false;
		}
	}
}
