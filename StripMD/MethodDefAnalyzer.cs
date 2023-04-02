using dnlib.DotNet;

namespace StripMD
{
	public class MethodDefAnalyzer : iAnalyze
	{
		public override bool Execute(object context)
		{
			MethodDef methodDef = (MethodDef)context;
			if (methodDef.IsRuntimeSpecialName)
			{
				return false;
			}
			if (methodDef.DeclaringType.IsForwarder)
			{
				return false;
			}
			return true;
		}
	}
}
