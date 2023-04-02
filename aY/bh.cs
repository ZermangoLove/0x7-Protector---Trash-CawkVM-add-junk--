using dnlib.DotNet;
using ICore;

namespace aY
{
	internal class bh
	{
		public static void ag(Context context, int length)
		{
			int num = context.Module.Assembly.Modules.Count - 1;
			for (int i = 0; i <= num; i++)
			{
				for (int j = 0; j <= length; j++)
				{
					new TypeDefUser(Utils.GenerateString(), context.Module.CorLibTypes.Object.TypeDefOrRef).Attributes = TypeAttributes.Public;
					TypeDef item = new TypeDefUser(Utils.GenerateString(), Utils.GenerateString(), context.Module.CorLibTypes.Object.TypeDefOrRef)
					{
						Attributes = TypeAttributes.Public
					};
					TypeDef item2 = new TypeDefUser(Utils.GenerateString(), Utils.GenerateString(), context.Module.CorLibTypes.Object.TypeDefOrRef)
					{
						Attributes = TypeAttributes.Public
					};
					context.Module.Types.Add(item);
					context.Module.Types.Add(item2);
				}
			}
		}
	}
}
