using System;
using System.Collections.Generic;
using System.IO;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Helpers.DynConverter
{
	public static class Emitter
	{
		public static void EmitNone(this BinaryWriter writer)
		{
			writer.Write(0);
		}

		public static void EmitString(this BinaryWriter writer, Instruction instr)
		{
			writer.Write(1);
			writer.Write(instr.Operand.ToString());
		}

		public static void EmitR(this BinaryWriter writer, Instruction instr)
		{
			writer.Write(2);
			writer.Write((double)instr.Operand);
		}

		public static void EmitI8(this BinaryWriter writer, Instruction instr)
		{
			writer.Write(3);
			writer.Write((long)instr.Operand);
		}

		public static void EmitI(this BinaryWriter writer, Instruction instr)
		{
			writer.Write(4);
			writer.Write(instr.GetLdcI4Value());
		}

		public static void EmitShortR(this BinaryWriter writer, Instruction instr)
		{
			writer.Write(5);
			writer.Write((float)instr.Operand);
		}

		public static void EmitShortI(this BinaryWriter writer, Instruction instr)
		{
			writer.Write(6);
			writer.Write((byte)instr.GetLdcI4Value());
		}

		public static void EmitType(this BinaryWriter writer, Instruction instr)
		{
			writer.Write(7);
			ITypeDefOrRef typeDefOrRef = instr.Operand as ITypeDefOrRef;
			writer.Write(typeDefOrRef.MDToken.ToInt32());
		}

		public static void EmitField(this BinaryWriter writer, Instruction instr)
		{
			writer.Write(8);
			IField field = instr.Operand as IField;
			writer.Write(field.MDToken.ToInt32());
		}

		public static void EmitMethod(this BinaryWriter writer, Instruction instr)
		{
			writer.Write(9);
			if (instr.Operand is MethodSpec methodSpec)
			{
				writer.Write(methodSpec.MDToken.ToInt32());
				return;
			}
			IMethodDefOrRef methodDefOrRef = instr.Operand as IMethodDefOrRef;
			writer.Write(methodDefOrRef.MDToken.ToInt32());
		}

		public static void EmitTok(this BinaryWriter writer, Instruction instr)
		{
			writer.Write(10);
			object operand = instr.Operand;
			if (operand is IField field)
			{
				writer.Write(field.MDToken.ToInt32());
				writer.Write(0);
			}
			else if (operand is ITypeDefOrRef typeDefOrRef)
			{
				writer.Write(typeDefOrRef.MDToken.ToInt32());
				writer.Write(1);
			}
			else
			{
				writer.Write((operand as IMethodDefOrRef).MDToken.ToInt32());
				writer.Write(2);
			}
		}

		public static void EmitBr(this BinaryWriter writer, int index)
		{
			writer.Write(11);
			writer.Write(index);
		}

		public static void EmitVar(this BinaryWriter writer, Instruction instr)
		{
			writer.Write(12);
			if (instr.Operand is Local local)
			{
				writer.Write(local.Index);
				writer.Write(0);
				return;
			}
			if (!(instr.Operand is Parameter parameter))
			{
				throw new NotSupportedException();
			}
			writer.Write(parameter.Index);
			writer.Write(1);
		}

		public static void EmitSwitch(this BinaryWriter writer, List<Instruction> instrs, Instruction instr)
		{
			writer.Write(13);
			Instruction[] array = instr.Operand as Instruction[];
			writer.Write(array.Length);
			Instruction[] array2 = array;
			foreach (Instruction item in array2)
			{
				int value = instrs.IndexOf(item);
				writer.Write(value);
			}
		}
	}
}
