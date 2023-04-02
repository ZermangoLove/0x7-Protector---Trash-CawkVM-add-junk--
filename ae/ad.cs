using dnlib.DotNet;
using StripMD;

namespace ae
{
	internal class ad
	{
		public static bool af(object obj)
		{
			iAnalyze iAnalyze = null;
			if (obj is TypeDef)
			{
				iAnalyze = new TypeDefAnalyzer();
			}
			else if (obj is MethodDef)
			{
				iAnalyze = new MethodDefAnalyzer();
			}
			else if (obj is EventDef)
			{
				iAnalyze = new EventDefAnalyzer();
			}
			else if (obj is FieldDef)
			{
				iAnalyze = new FieldDefAnalyzer();
			}
			return iAnalyze?.Execute(obj) ?? false;
		}

		public static void ag(ModuleDefMD module)
		{
			foreach (CustomAttribute customAttribute in module.Assembly.CustomAttributes)
			{
				if (af(customAttribute))
				{
					module.Assembly.CustomAttributes.Remove(customAttribute);
				}
			}
			module.Mvid = null;
			module.Name = null;
			foreach (TypeDef type in module.Types)
			{
				foreach (CustomAttribute customAttribute2 in type.CustomAttributes)
				{
					if (af(customAttribute2))
					{
						type.CustomAttributes.Remove(customAttribute2);
					}
				}
				foreach (MethodDef method in type.Methods)
				{
					foreach (CustomAttribute customAttribute3 in method.CustomAttributes)
					{
						if (af(customAttribute3))
						{
							method.CustomAttributes.Remove(customAttribute3);
						}
					}
				}
				foreach (PropertyDef property in type.Properties)
				{
					foreach (CustomAttribute customAttribute4 in property.CustomAttributes)
					{
						if (af(customAttribute4))
						{
							property.CustomAttributes.Remove(customAttribute4);
						}
					}
				}
				foreach (FieldDef field in type.Fields)
				{
					foreach (CustomAttribute customAttribute5 in field.CustomAttributes)
					{
						if (af(customAttribute5))
						{
							field.CustomAttributes.Remove(customAttribute5);
						}
					}
				}
				foreach (EventDef @event in type.Events)
				{
					foreach (CustomAttribute customAttribute6 in @event.CustomAttributes)
					{
						if (af(customAttribute6))
						{
							@event.CustomAttributes.Remove(customAttribute6);
						}
					}
				}
			}
		}
	}
}
