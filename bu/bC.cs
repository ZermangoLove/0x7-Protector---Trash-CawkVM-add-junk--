using dnlib.DotNet;
using ICore;
using Protections.Renaming;

namespace bu
{
	internal class bC
	{
		public static string bD = "";

		public static void bE(Context ctx)
		{
			bD = Utils.GenerateString();
			foreach (TypeDef type in ctx.Module.GetTypes())
			{
				if (bt.af(type))
				{
					if (Checker.IsFormSubClass(type, ctx.Module))
					{
						foreach (Resource resource in type.Module.Resources)
						{
							if (resource.Name.Contains(".resources"))
							{
								resource.Name.Replace(".resources", "");
								type.Name = bD;
								resource.Name = string.Concat(type.Name, ".resources");
							}
						}
					}
					else
					{
						type.Name = Utils.GenerateString();
					}
				}
				type.Namespace = Utils.GenerateString();
			}
		}

		public static void bF(Context ctx)
		{
			foreach (TypeDef type in ctx.Module.GetTypes())
			{
				foreach (FieldDef field in type.Fields)
				{
					if (bt.af(field))
					{
						field.Name = Utils.GenerateString();
					}
				}
			}
		}

		public static void bG(Context ctx)
		{
			foreach (TypeDef type in ctx.Module.GetTypes())
			{
				foreach (EventDef @event in type.Events)
				{
					if (bt.af(@event))
					{
						@event.Name = Utils.GenerateString();
					}
				}
			}
		}

		public static void bH(Context ctx)
		{
			foreach (TypeDef type in ctx.Module.GetTypes())
			{
				foreach (PropertyDef property in type.Properties)
				{
					if (bt.af(property))
					{
						property.Name = Utils.GenerateString();
					}
				}
			}
		}

		public static void bI(Context ctx)
		{
			foreach (TypeDef type in ctx.Module.GetTypes())
			{
				foreach (MethodDef method in type.Methods)
				{
					if (bt.af(method))
					{
						method.Name = Utils.GenerateString();
					}
				}
			}
		}

		public static void bJ(Context ctx)
		{
			foreach (TypeDef type in ctx.Module.GetTypes())
			{
				foreach (MethodDef method in type.Methods)
				{
					foreach (ParamDef paramDef in method.ParamDefs)
					{
						if (bt.af(type, paramDef))
						{
							paramDef.Name = Utils.GenerateString();
						}
					}
				}
			}
		}

		public static void bK(Context ctx)
		{
			foreach (TypeDef type in ctx.Module.GetTypes())
			{
				type.Namespace = "";
			}
		}
	}
}
