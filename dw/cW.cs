using System.Collections.Generic;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using ICore;

namespace dw
{
	internal abstract class cW
	{
		protected static IEnumerable<cK.ho> cX(cK.hd scope)
		{
			foreach (cK.gR item in scope.hl)
			{
				if (!(item is cK.ho))
				{
					foreach (cK.ho item2 in cX((cK.hd)item))
					{
						yield return item2;
					}
				}
				else
				{
					yield return (cK.ho)item;
				}
			}
		}

		public abstract void cY(CilBody body, cK.hd root, Context ctx, MethodDef method, TypeSig retType);
	}
}
