using System.Collections.Generic;
using dnlib.DotNet.Emit;

namespace Protections.ControlFlow2
{
	public class Block
	{
		public int ID;

		public int nextBlock;

		public List<Instruction> instructions = new List<Instruction>();
	}
}
