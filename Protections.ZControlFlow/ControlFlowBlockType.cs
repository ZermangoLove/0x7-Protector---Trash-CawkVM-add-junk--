using System;

namespace Protections.ZControlFlow
{
	[Flags]
	public enum ControlFlowBlockType
	{
		Normal = 0,
		Entry = 1,
		Exit = 2
	}
}
