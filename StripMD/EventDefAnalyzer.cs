using dnlib.DotNet;

namespace StripMD
{
	public class EventDefAnalyzer : iAnalyze
	{
		public override bool Execute(object context)
		{
			if (((EventDef)context).IsRuntimeSpecialName)
			{
				return false;
			}
			return true;
		}
	}
}
