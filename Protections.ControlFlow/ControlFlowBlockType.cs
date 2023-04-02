using System;

namespace Protections.ControlFlow
{
	[Flags]
	public enum ControlFlowBlockType
	{
		Normal = 0,
		Entry = 1,
		Exit = 2
	}
}
