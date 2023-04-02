using System;
using System.Runtime.CompilerServices;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using ICore;

namespace Mutation.Stages
{
	public class IntsConversions
	{
		[CompilerGenerated]
		private MethodDef D;

		private MethodDef G
		{
			[CompilerGenerated]
			get
			{
				return D;
			}
			[CompilerGenerated]
			set
			{
				D = value;
			}
		}

		public IntsConversions(MethodDef method)
		{
			G = method;
		}

		public void Execute()
		{
			for (int i = 0; i < G.Body.Instructions.Count; i++)
			{
				if (G.Body.Instructions[i].IsLdcI4())
				{
					int ldcI4Value = G.Body.Instructions[i].GetLdcI4Value();
					if (ldcI4Value < 10 && ldcI4Value > 0)
					{
						I(ref i);
					}
					else
					{
						H(ref i);
					}
				}
			}
		}

		private void H(ref int i)
		{
			int ldcI4Value = G.Body.Instructions[i].GetLdcI4Value();
			G.Body.Instructions[i].OpCode = OpCodes.Ldc_I4;
			G.Body.Instructions[i].Operand = ldcI4Value;
			G.Body.Instructions.Insert(i + 1, OpCodes.Call.ToInstruction(G.Module.Import(typeof(IntPtr).GetMethod("op_Explicit", new Type[1] { typeof(int) }))));
			G.Body.Instructions.Insert(i + 2, Instruction.Create(OpCodes.Conv_Ovf_I4));
			i += 2;
		}

		private void I(ref int i)
		{
			int ldcI4Value = G.Body.Instructions[i].GetLdcI4Value();
			G.Body.Instructions[i].OpCode = OpCodes.Ldstr;
			G.Body.Instructions[i].Operand = J(ldcI4Value);
			G.Body.Instructions.Insert(i + 1, OpCodes.Ldlen.ToInstruction());
			i++;
		}

		private string J(int len)
		{
			string text = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
			string text2 = "";
			for (int i = 0; i < len; i++)
			{
				text2 += text[Utils.rnd.Next(0, text.Length)];
			}
			return text2;
		}
	}
}
