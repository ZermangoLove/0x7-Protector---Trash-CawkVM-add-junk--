using dnlib.DotNet;

namespace StripMD
{
	public class TypeDefAnalyzer : iAnalyze
	{
		public override bool Execute(object context)
		{
			TypeDef typeDef = (TypeDef)context;
			if (typeDef.IsRuntimeSpecialName)
			{
				return false;
			}
			if (typeDef.IsGlobalModuleType)
			{
				return false;
			}
			return true;
		}
	}
}
