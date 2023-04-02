using dnlib.DotNet;

namespace StripMD
{
	public class FieldDefAnalyzer : iAnalyze
	{
		public override bool Execute(object context)
		{
			FieldDef fieldDef = (FieldDef)context;
			if (fieldDef.IsRuntimeSpecialName)
			{
				return false;
			}
			if (fieldDef.IsLiteral && fieldDef.DeclaringType.IsEnum)
			{
				return false;
			}
			return true;
		}
	}
}
