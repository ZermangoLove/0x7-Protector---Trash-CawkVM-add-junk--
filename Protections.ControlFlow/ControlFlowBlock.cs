using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using dnlib.DotNet.Emit;

namespace Protections.ControlFlow
{
	public class ControlFlowBlock
	{
		public readonly Instruction Footer;

		public readonly Instruction Header;

		public readonly int Id;

		public readonly ControlFlowBlockType Type;

		[CompilerGenerated]
		private IList<ControlFlowBlock> cU;

		[CompilerGenerated]
		private IList<ControlFlowBlock> B;

		public IList<ControlFlowBlock> Sources
		{
			[CompilerGenerated]
			get
			{
				return cU;
			}
			[CompilerGenerated]
			private set
			{
				cU = value;
			}
		}

		public IList<ControlFlowBlock> Targets
		{
			[CompilerGenerated]
			get
			{
				return B;
			}
			[CompilerGenerated]
			private set
			{
				B = value;
			}
		}

		internal ControlFlowBlock(int id, ControlFlowBlockType type, Instruction header, Instruction footer)
		{
			Id = id;
			Type = type;
			Header = header;
			Footer = footer;
			Sources = new List<ControlFlowBlock>();
			Targets = new List<ControlFlowBlock>();
		}

		public override string ToString()
		{
			return string.Format("Block {0} => {1} {2}", Id, Type, string.Join(", ", Targets.Select((ControlFlowBlock block) => block.Id.ToString()).ToArray()));
		}
	}
}
