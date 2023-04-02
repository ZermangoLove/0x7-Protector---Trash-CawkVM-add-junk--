using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Helpers.DynConverter
{
	public class Converter
	{
		private class hB
		{
			[CompilerGenerated]
			private readonly int gS;

			[CompilerGenerated]
			private readonly int hC;

			public int gV
			{
				[CompilerGenerated]
				get
				{
					return gS;
				}
			}

			public int hE
			{
				[CompilerGenerated]
				get
				{
					return hC;
				}
			}

			public hB(int type, int action)
			{
				gS = type;
				hC = action;
			}
		}

		[CompilerGenerated]
		private readonly MethodDef D;

		[CompilerGenerated]
		private readonly BinaryWriter eA;

		public MethodDef Method
		{
			[CompilerGenerated]
			get
			{
				return D;
			}
		}

		public BinaryWriter Writer
		{
			[CompilerGenerated]
			get
			{
				return eA;
			}
		}

		public Converter(MethodDef method, BinaryWriter writer)
		{
			D = method;
			eA = writer;
			method.Body.SimplifyMacros(method.Parameters);
			method.Body.SimplifyBranches();
		}

		public void ConvertToBytes()
		{
			ExceptionMapper exceptionMapper = new ExceptionMapper(Method);
			IList<Instruction> instructions = Method.Body.Instructions;
			int count = instructions.Count;
			List<int> list = new List<int>();
			Writer.Write(count);
			for (int i = 0; i < count; i++)
			{
				switch (instructions[i].OpCode.OperandType)
				{
				case OperandType.InlineSwitch:
				{
					Instruction[] array = instructions[i].Operand as Instruction[];
					foreach (Instruction item in array)
					{
						list.Add(instructions.IndexOf(item));
					}
					break;
				}
				case OperandType.InlineBrTarget:
				case OperandType.ShortInlineBrTarget:
					list.Add(instructions.IndexOf(instructions[i].Operand as Instruction));
					break;
				}
			}
			Writer.Write(list.Count);
			foreach (int item2 in list)
			{
				Writer.Write(item2);
			}
			for (int k = 0; k < count; k++)
			{
				Instruction instruction = instructions[k];
				short value = instruction.OpCode.Value;
				OperandType operandType = instruction.OpCode.OperandType;
				object operand = instruction.Operand;
				exceptionMapper.MapAndWrite(Writer, instruction);
				Writer.Write(value);
				switch (operandType)
				{
				case OperandType.InlineField:
					Writer.EmitField(instruction);
					break;
				case OperandType.InlineI:
					Writer.EmitI(instruction);
					break;
				case OperandType.InlineI8:
					Writer.EmitI8(instruction);
					break;
				case OperandType.InlineMethod:
					Writer.EmitMethod(instruction);
					break;
				case OperandType.InlineNone:
					Writer.EmitNone();
					break;
				case OperandType.InlineR:
					Writer.EmitR(instruction);
					break;
				case OperandType.InlineString:
					Writer.EmitString(instruction);
					break;
				case OperandType.InlineSwitch:
					Writer.EmitSwitch(instructions.ToList(), instruction);
					break;
				case OperandType.InlineTok:
					Writer.EmitTok(instruction);
					break;
				case OperandType.InlineType:
					Writer.EmitType(instruction);
					break;
				case OperandType.InlineBrTarget:
				case OperandType.ShortInlineBrTarget:
					Writer.EmitBr(instructions.IndexOf(operand as Instruction));
					break;
				case OperandType.ShortInlineI:
					Writer.EmitShortI(instruction);
					break;
				case OperandType.ShortInlineR:
					Writer.EmitShortR(instruction);
					break;
				case OperandType.InlineVar:
				case OperandType.ShortInlineVar:
					Writer.EmitVar(instruction);
					break;
				}
			}
		}
	}
}
