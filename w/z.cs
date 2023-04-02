using dnlib.DotNet;
using ICore;

namespace w
{
	internal static class z
	{
		internal static void A(Context context)
		{
			try
			{
				foreach (TypeDef type in context.Module.Types)
				{
					for (int i = 0; i < type.Fields.Count; i++)
					{
						FieldDef fieldDef = type.Fields[i];
						if (fieldDef.HasConstant && fieldDef.ElementType.Equals(ElementType.Object))
						{
							type.Fields.RemoveAt(i);
						}
						if (fieldDef.HasConstant && fieldDef.ElementType.Equals(ElementType.Array))
						{
							type.Fields.RemoveAt(i);
						}
						if (fieldDef.HasConstant && fieldDef.ElementType.Equals(ElementType.String))
						{
							type.Fields.RemoveAt(i);
						}
						if (fieldDef.HasConstant && fieldDef.ElementType.Equals(ElementType.Boolean))
						{
							type.Fields.RemoveAt(i);
						}
						if (fieldDef.HasConstant && fieldDef.ElementType.Equals(ElementType.Char))
						{
							type.Fields.RemoveAt(i);
						}
						if (fieldDef.HasConstant && fieldDef.ElementType.Equals(ElementType.Ptr))
						{
							type.Fields.RemoveAt(i);
						}
						if (fieldDef.HasConstant && fieldDef.ElementType.Equals(ElementType.SZArray))
						{
							type.Fields.RemoveAt(i);
						}
						if (fieldDef.HasConstant && fieldDef.ElementType.Equals(ElementType.Class))
						{
							type.Fields.RemoveAt(i);
						}
						if (fieldDef.HasConstant && fieldDef.ElementType.Equals(ElementType.I))
						{
							type.Fields.RemoveAt(i);
						}
						if (fieldDef.HasConstant && fieldDef.ElementType.Equals(ElementType.I1))
						{
							type.Fields.RemoveAt(i);
						}
						if (fieldDef.HasConstant && fieldDef.ElementType.Equals(ElementType.I2))
						{
							type.Fields.RemoveAt(i);
						}
						if (fieldDef.HasConstant && fieldDef.ElementType.Equals(ElementType.I4))
						{
							type.Fields.RemoveAt(i);
						}
						if (fieldDef.HasConstant && fieldDef.ElementType.Equals(ElementType.I8))
						{
							type.Fields.RemoveAt(i);
						}
						if (fieldDef.HasConstant && fieldDef.ElementType.Equals(ElementType.R))
						{
							type.Fields.RemoveAt(i);
						}
						if (fieldDef.HasConstant && fieldDef.ElementType.Equals(ElementType.R4))
						{
							type.Fields.RemoveAt(i);
						}
						if (fieldDef.HasConstant && fieldDef.ElementType.Equals(ElementType.R8))
						{
							type.Fields.RemoveAt(i);
						}
						if (fieldDef.HasConstant && fieldDef.ElementType.Equals(ElementType.U))
						{
							type.Fields.RemoveAt(i);
						}
						if (fieldDef.HasConstant && fieldDef.ElementType.Equals(ElementType.U1))
						{
							type.Fields.RemoveAt(i);
						}
						if (fieldDef.HasConstant && fieldDef.ElementType.Equals(ElementType.U4))
						{
							type.Fields.RemoveAt(i);
						}
						if (fieldDef.HasConstant && fieldDef.ElementType.Equals(ElementType.U8))
						{
							type.Fields.RemoveAt(i);
						}
					}
				}
			}
			catch
			{
			}
		}
	}
}
