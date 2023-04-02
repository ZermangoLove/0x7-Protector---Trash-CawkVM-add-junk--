using dnlib.DotNet;
using ICore;

namespace bu
{
	internal class bt
	{
		public static bool bv(TypeDef type, ModuleDef module)
		{
			bool result = false;
			if (type != null && type.BaseType != null && type.BaseType.FullName.Contains("Forms.Form"))
			{
				result = true;
			}
			return result;
		}

		public static bool bv(ITypeDefOrRef type, ModuleDef module)
		{
			bool result = false;
			if (type != null && type.Module.Name == module.Name)
			{
				TypeDef typeDef = type.ResolveTypeDef();
				if (typeDef != null && typeDef.BaseType != null)
				{
					result = ((!(typeDef.Module.Name == module.Name)) ? bv(typeDef.BaseType, module) : bw(typeDef));
				}
			}
			return result;
		}

		public static bool bw(TypeDef type)
		{
			bool result = false;
			if (type.BaseType != null)
			{
				result = type.BaseType.ToString().Contains("Forms.Form");
			}
			return result;
		}

		public static bool bx(ModuleDef module)
		{
			bool result = false;
			foreach (ModuleDef module2 in module.Assembly.Modules)
			{
				foreach (TypeDef type in module2.Types)
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

		public static bool af(FieldDef field)
		{
			if (!field.Name.StartsWith("<"))
			{
				if (field.IsLiteral && field.DeclaringType.IsEnum)
				{
					return false;
				}
				if (!field.IsStatic)
				{
					if (!field.IsFamilyOrAssembly)
					{
						if (field.IsSpecialName)
						{
							return false;
						}
						if (field.IsRuntimeSpecialName)
						{
							return false;
						}
						if (field.IsFamily)
						{
							return false;
						}
						if (field.DeclaringType.IsEnum)
						{
							return false;
						}
						if (field.DeclaringType.BaseType.Name.Contains("Delegate"))
						{
							return false;
						}
						return true;
					}
					return false;
				}
				return false;
			}
			return false;
		}

		public static bool af(TypeDef type, ParamDef p)
		{
			if (type.FullName == "<Module>")
			{
				return false;
			}
			if (p.Name == string.Empty)
			{
				return false;
			}
			return true;
		}

		public static bool af(PropertyDef p)
		{
			if (p.DeclaringType.Name.Contains("AnonymousType"))
			{
				return false;
			}
			if (p.IsRuntimeSpecialName)
			{
				return false;
			}
			if (p.IsEmpty)
			{
				return false;
			}
			if (p.IsSpecialName)
			{
				return false;
			}
			return true;
		}

		public static bool af(EventDef e)
		{
			if (e.IsSpecialName)
			{
				return false;
			}
			if (e.IsRuntimeSpecialName)
			{
				return false;
			}
			return true;
		}

		public static bool af(TypeDef type)
		{
			if (type.IsGlobalModuleType)
			{
				return false;
			}
			if (type.IsInterface)
			{
				return false;
			}
			if (type.IsAbstract)
			{
				return false;
			}
			if (type.IsEnum)
			{
				return false;
			}
			if (type.IsRuntimeSpecialName)
			{
				return false;
			}
			if (type.IsSpecialName)
			{
				return false;
			}
			if (type.IsNestedFamilyOrAssembly)
			{
				return false;
			}
			if (type.IsNestedFamilyAndAssembly)
			{
				return false;
			}
			return true;
		}

		public static bool af(TypeDef type, MethodDef method)
		{
			if (!type.IsInterface)
			{
				if (!type.IsDelegate && !type.IsAbstract)
				{
					if (method.DeclaringType.BaseType != null && method.DeclaringType.BaseType.Name.Contains("Delegate"))
					{
						return false;
					}
					if (method.DeclaringType.FullName == "System.Windows.Forms.Binding" && method.Name.String == ".ctor")
					{
						return false;
					}
					if (!method.IsSetter && !method.IsGetter)
					{
						if (!method.IsSpecialName && !method.IsRuntimeSpecialName)
						{
							if (!method.IsConstructor)
							{
								if (method.IsNative)
								{
									return false;
								}
								if (!method.IsPinvokeImpl && !method.IsUnmanaged && !method.IsUnmanagedExport)
								{
									if (method != null)
									{
										if (!method.Name.StartsWith("<"))
										{
											if (method.Overrides.Count > 0)
											{
												return false;
											}
											if (method.Name == "Invoke")
											{
												return false;
											}
											if (method.IsStaticConstructor)
											{
												return false;
											}
											if (method.DeclaringType.IsGlobalModuleType)
											{
												return false;
											}
											if (method.IsVirtual)
											{
												return false;
											}
											if (method.HasImplMap)
											{
												return false;
											}
											return true;
										}
										return false;
									}
									return false;
								}
								return false;
							}
							return false;
						}
						return false;
					}
					return false;
				}
				return false;
			}
			return false;
		}

		public static bool af(MethodDef method)
		{
			if (method.HasBody && method.Body.HasInstructions)
			{
				if (method.DeclaringType.BaseType != null && method.DeclaringType.BaseType.Name.Contains("Delegate"))
				{
					return false;
				}
				if (method.DeclaringType.FullName == "System.Windows.Forms.Binding" && method.Name.String == ".ctor")
				{
					return false;
				}
				if (!method.IsSetter && !method.IsGetter)
				{
					if (!method.IsSpecialName && !method.IsRuntimeSpecialName)
					{
						if (!method.IsConstructor)
						{
							if (!method.IsNative)
							{
								if (!method.IsPinvokeImpl && !method.IsUnmanaged && !method.IsUnmanagedExport)
								{
									if (method != null)
									{
										if (!method.Name.StartsWith("<"))
										{
											if (method.Overrides.Count <= 0)
											{
												if (method.Name == "Invoke")
												{
													return false;
												}
												if (method.IsStaticConstructor)
												{
													return false;
												}
												if (method.DeclaringType.IsGlobalModuleType)
												{
													return false;
												}
												if (method.IsVirtual)
												{
													return false;
												}
												if (method.HasImplMap)
												{
													return false;
												}
												return true;
											}
											return false;
										}
										return false;
									}
									return false;
								}
								return false;
							}
							return false;
						}
						return false;
					}
					return false;
				}
				return false;
			}
			return false;
		}

		public static void by(TypeDef type, MethodDef method)
		{
			if (!method.IsConstructor && !method.IsRuntime && !method.IsRuntimeSpecialName && !method.IsSpecialName && !method.IsVirtual && !method.IsAbstract && method.Overrides.Count <= 0 && !method.Name.StartsWith("<") && method.Body != null && !method.Name.Contains("Dispose") && !method.Name.Contains("ctor") && !method.Name.Contains("Main") && method.Body.Instructions.Count - 1 == 0)
			{
				type.Methods.Remove(method);
			}
		}

		public static void bz(Context context)
		{
			foreach (TypeDef type in context.Module.GetTypes())
			{
				foreach (MethodDef method in type.Methods)
				{
					by(type, method);
				}
			}
		}
	}
}
