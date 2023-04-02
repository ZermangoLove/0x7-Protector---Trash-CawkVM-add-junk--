using System;
using System.Collections.Generic;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace ExAntiTamper.Stuffs
{
	public static class MutationHelper
	{
		private const string aJ = "Mutation";

		private static readonly Dictionary<string, int> aK = new Dictionary<string, int>
		{
			{ "KeyI0", 0 },
			{ "KeyI1", 1 },
			{ "KeyI2", 2 },
			{ "KeyI3", 3 },
			{ "KeyI4", 4 },
			{ "KeyI5", 5 },
			{ "KeyI6", 6 },
			{ "KeyI7", 7 },
			{ "KeyI8", 8 },
			{ "KeyI9", 9 },
			{ "KeyI10", 10 },
			{ "KeyI11", 11 },
			{ "KeyI12", 12 },
			{ "KeyI13", 13 },
			{ "KeyI14", 14 },
			{ "KeyI15", 15 }
		};

		public static void InjectKey(MethodDef method, int keyId, int key)
		{
			foreach (Instruction instruction in method.Body.Instructions)
			{
				if (instruction.OpCode == OpCodes.Ldsfld)
				{
					IField field = (IField)instruction.Operand;
					if (field.DeclaringType.FullName == "Mutation" && aK.TryGetValue(field.Name, out var value) && value == keyId)
					{
						instruction.OpCode = OpCodes.Ldc_I4;
						instruction.Operand = key;
					}
				}
			}
		}

		public static void InjectKeys(MethodDef method, int[] keyIds, int[] keys)
		{
			foreach (Instruction instruction in method.Body.Instructions)
			{
				if (instruction.OpCode == OpCodes.Ldsfld)
				{
					IField field = (IField)instruction.Operand;
					if (field.DeclaringType.FullName == "Mutation" && aK.TryGetValue(field.Name, out var value) && (value = Array.IndexOf(keyIds, value)) != -1)
					{
						instruction.OpCode = OpCodes.Ldc_I4;
						instruction.Operand = keys[value];
					}
				}
			}
		}
	}
}
