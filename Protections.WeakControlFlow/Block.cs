using System.Collections.Generic;
using System.Runtime.CompilerServices;
using dnlib.DotNet.Emit;

namespace Protections.WeakControlFlow
{
	public class Block
	{
		[CompilerGenerated]
		private List<Instruction> ds;

		[CompilerGenerated]
		private int dt;

		[CompilerGenerated]
		private int du;

		public List<Instruction> Instructions
		{
			[CompilerGenerated]
			get
			{
				return ds;
			}
			[CompilerGenerated]
			set
			{
				ds = value;
			}
		}

		public int Number
		{
			[CompilerGenerated]
			get
			{
				return dt;
			}
			[CompilerGenerated]
			set
			{
				dt = value;
			}
		}

		public int Next
		{
			[CompilerGenerated]
			get
			{
				return du;
			}
			[CompilerGenerated]
			set
			{
				du = value;
			}
		}

		public Block()
		{
			Instructions = new List<Instruction>();
		}
	}
}
