using System;
using System.Collections.Generic;
using dnlib.DotNet.Emit;

namespace Helpers.Emulator
{
	public class EmuContext
	{
		internal Stack<object> ee;

		internal List<Instruction> ef;

		internal int eg;

		public Dictionary<Local, object> _locals;

		public EmuContext(List<Instruction> instructions, List<Local> locals)
		{
			ee = new Stack<object>();
			ef = instructions;
			_locals = new Dictionary<Local, object>();
			foreach (Local local in locals)
			{
				_locals.Add(local, null);
			}
		}

		internal object eh(Local local)
		{
			Type type = Type.GetType(local.Type.AssemblyQualifiedName);
			return Convert.ChangeType(_locals[local], type);
		}

		internal void ei(Local local, object val)
		{
			_locals[local] = val;
		}
	}
}
