using System;
using System.Collections.Generic;
using System.Linq;
using dnlib.DotNet.Emit;
using ek;

namespace Helpers.Emulator
{
	public class Emulator
	{
		public EmuContext _context;

		private Dictionary<OpCode, ej> eo;

		public Emulator(List<Instruction> instructions, List<Local> locals)
		{
			_context = new EmuContext(instructions, locals);
			eo = new Dictionary<OpCode, ej>();
			foreach (ej item in (from t in typeof(ej).Assembly.GetTypes()
				where t.IsSubclassOf(typeof(ej)) && !t.IsAbstract
				select (ej)Activator.CreateInstance(t)).ToList())
			{
				eo.Add(item.em, item);
			}
		}

		internal int en()
		{
			for (int i = _context.eg; i < _context.ef.Count; i++)
			{
				Instruction instruction = _context.ef[i];
				if (instruction.OpCode == OpCodes.Stloc)
				{
					break;
				}
				if (instruction.OpCode != OpCodes.Nop)
				{
					eo[instruction.OpCode].en(_context, instruction);
				}
			}
			return (int)_context.ee.Pop();
		}
	}
}
