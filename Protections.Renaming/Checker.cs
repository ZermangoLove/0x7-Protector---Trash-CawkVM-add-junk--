using dnlib.DotNet;

namespace Protections.Renaming
{
	public static class Checker
	{
		public static bool IsFormSubClass(TypeDef type, ModuleDef module)
		{
			bool result = false;
			if (type != null && type.BaseType != null && type.BaseType.FullName.Contains("Forms.Form"))
			{
				result = true;
			}
			return result;
		}

		public static bool IsFormSubClass(ITypeDefOrRef type, ModuleDef module)
		{
			bool result = false;
			if (type != null && type.Module.Name == module.Name)
			{
				TypeDef typeDef = type.ResolveTypeDef();
				if (typeDef != null && typeDef.BaseType != null)
				{
					result = ((!(typeDef.Module.Name == module.Name)) ? IsFormSubClass(typeDef.BaseType, module) : IsFormClass(typeDef));
				}
			}
			return result;
		}

		public static bool IsFormClass(TypeDef type)
		{
			bool result = false;
			if (type.BaseType != null)
			{
				result = type.BaseType.ToString().Contains("Forms.Form");
			}
			return result;
		}

		public static bool isForm(AssemblyDef asm)
		{
			bool result = false;
			foreach (ModuleDef module in asm.Modules)
			{
				foreach (TypeDef type in module.Types)
				{
					foreach (TypeDef nestedType in type.NestedTypes)
					{
						foreach (MethodDef method in nestedType.Methods)
						{
							if (method.Name == "InitializeComponent")
							{
								result = true;
							}
						}
					}
					foreach (MethodDef method2 in type.Methods)
					{
						if (method2.Name == "InitializeComponent")
						{
							result = true;
						}
					}
				}
			}
			return result;
		}
	}
}
