using System.Collections.Generic;
using dnlib.DotNet.Emit;

namespace cL
{
	internal interface cZ
	{
		void Init(CilBody body);

		void da(IList<Instruction> instrs);

		int db(int key);
	}
}
