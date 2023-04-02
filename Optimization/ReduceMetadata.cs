using System.Collections.Generic;
using System.Runtime.CompilerServices;
using dnlib.DotNet;
using ICore;

namespace Optimization
{
	public static class ReduceMetadata
	{
		[CompilerGenerated]
		private static readonly IList<IDnlibDef> B;

		public static IList<IDnlibDef> Targets
		{
			[CompilerGenerated]
			get
			{
				return B;
			}
		}

		public static void Execute(Context context)
		{
			IMemberDef memberDef = Targets as IMemberDef;
			foreach (TypeDef type2 in context.Module.GetTypes())
			{
				TypeDef typeDef = type2;
				if (memberDef is TypeDef type && !C(type))
				{
					if (!type2.IsEnum)
					{
						continue;
					}
					int num = 0;
					while (type2.Fields.Count != 1)
					{
						if (type2.Fields[num].Name != "value__")
						{
							type2.Fields.RemoveAt(num);
						}
						else
						{
							num++;
						}
					}
					break;
				}
				if (memberDef is EventDef)
				{
					if (memberDef.DeclaringType != null)
					{
						memberDef.DeclaringType.Events.Remove(memberDef as EventDef);
						break;
					}
				}
				else if (memberDef is PropertyDef && memberDef.DeclaringType != null)
				{
					memberDef.DeclaringType.Properties.Remove(memberDef as PropertyDef);
				}
			}
		}

		private static bool C(TypeDef type)
		{
			do
			{
				if (type.IsPublic || type.IsNestedFamily || type.IsNestedFamilyAndAssembly || type.IsNestedFamilyOrAssembly || type.IsNestedPublic || type.IsPublic)
				{
					type = type.DeclaringType;
					continue;
				}
				return false;
			}
			while (type != null);
			return true;
		}
	}
}
