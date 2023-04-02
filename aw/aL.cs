using System.Collections.Generic;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace aw
{
	internal class aL : aB
	{
		public void Init()
		{
		}

		public uint[] ar(uint[] a, uint[] b)
		{
			uint[] array = new uint[16];
			for (int i = 0; i < 16; i++)
			{
				switch (i % 3)
				{
				case 0:
					array[i] = a[i] ^ b[i];
					break;
				case 1:
					array[i] = a[i] * b[i];
					break;
				case 2:
					array[i] = a[i] + b[i];
					break;
				}
			}
			return array;
		}

		public IEnumerable<Instruction> aC(MethodDef method, Local dst, Local src)
		{
			for (int i = 0; i < 16; i++)
			{
				yield return Instruction.Create(OpCodes.Ldloc, dst);
				yield return Instruction.Create(OpCodes.Ldc_I4, i);
				yield return Instruction.Create(OpCodes.Ldloc, dst);
				yield return Instruction.Create(OpCodes.Ldc_I4, i);
				yield return Instruction.Create(OpCodes.Ldelem_U4);
				yield return Instruction.Create(OpCodes.Ldloc, src);
				yield return Instruction.Create(OpCodes.Ldc_I4, i);
				yield return Instruction.Create(OpCodes.Ldelem_U4);
				switch (i % 3)
				{
				case 0:
					yield return Instruction.Create(OpCodes.Xor);
					break;
				case 1:
					yield return Instruction.Create(OpCodes.Mul);
					break;
				case 2:
					yield return Instruction.Create(OpCodes.Add);
					break;
				}
				yield return Instruction.Create(OpCodes.Stelem_I4);
			}
		}
	}
}
