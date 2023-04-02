using System.Collections.Generic;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using dw;
using ICore;

namespace cL
{
	internal abstract class cW
	{
		protected static IEnumerable<dw.cK.ho> cX(dw.cK.hd scope)
		{
			foreach (dw.cK.gR item in scope.hl)
			{
				if (!(item is dw.cK.ho))
				{
					foreach (dw.cK.ho item2 in cX((dw.cK.hd)item))
					{
						yield return item2;
					}
				}
				else
				{
					yield return (dw.cK.ho)item;
				}
			}
		}

		public abstract void cY(CilBody body, dw.cK.hd root, Context ctx, MethodDef method, TypeSig retType);
	}
}
