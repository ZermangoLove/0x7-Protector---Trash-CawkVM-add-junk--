using System.Collections.Generic;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace aw
{
	internal interface aB
	{
		void Init();

		uint[] ar(uint[] a, uint[] b);

		IEnumerable<Instruction> aC(MethodDef method, Local dst, Local src);
	}
}
