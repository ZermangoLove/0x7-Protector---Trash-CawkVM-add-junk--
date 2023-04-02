using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Core.Protection
{
	internal class ConvertToBytes
	{
		private BinaryWriter _binWriter;

		public byte[] ConvertedBytes;

		private readonly MethodDef _methods;

		public bool Successful;

		public ConvertToBytes(MethodDef methodDef)
		{
			_methods = methodDef;
			ConvertedBytes = null;
			Successful = false;
		}

		[Obfuscation(Feature = "virtualization", Exclude = false)]
		public void ConversionMethod()
		{
			int num = 809530430;
			int num2 = 1;
			IEnumerator<Instruction> enumerator = default(IEnumerator<Instruction>);
			do
			{
				if (num2 == -809530429 + num)
				{
					_binWriter = new BinaryWriter(new MemoryStream());
					num2 = -809530428 + num;
				}
				if (num2 == (0x3040743C ^ num))
				{
					ExceptionStarter();
					num2 = 809530433 - num;
				}
				if (num2 == (0x3040743D ^ num))
				{
					_binWriter.Write(_methods.Body.Instructions.Count);
					num2 = 0x3040743A ^ num;
				}
				if (num2 == (0x3040743A ^ num))
				{
					enumerator = _methods.Body.Instructions.GetEnumerator();
					num2 = 809530435 - num;
				}
				if (num2 == (0x3040743E ^ num))
				{
					num2 = 0x3040743F ^ num;
				}
			}
			while (num2 != -809530425 + num);
			try
			{
				while (enumerator.MoveNext())
				{
					Instruction current = enumerator.Current;
					OpcodeWriter(current.OpCode);
					OperandType operandType = current.OpCode.OperandType;
					if (current.Operand == null || (!current.Operand.ToString().Contains("StackTrace") && !current.Operand.ToString().Contains("Assembly") && !current.Operand.ToString().Contains("GetMethodFromHandle")))
					{
						switch (operandType)
						{
						case OperandType.InlineBrTarget:
							InlineBrTarget(_methods.Body.Instructions, current);
							break;
						case OperandType.InlineField:
							InlineField(current);
							break;
						case OperandType.InlineI:
							InlineI(current);
							break;
						case OperandType.InlineI8:
							InlineI8(current);
							break;
						case OperandType.InlineMethod:
							InlineMethod(current);
							break;
						case OperandType.InlineNone:
							InlineNone(current);
							break;
						case OperandType.InlineR:
							InlineR(current);
							break;
						case OperandType.InlineString:
							InlineString(current);
							break;
						case OperandType.InlineSwitch:
							InlineSwitch(_methods.Body.Instructions, current);
							break;
						case OperandType.InlineTok:
							InlineTok(current);
							break;
						case OperandType.InlineType:
							InlineType(current);
							break;
						case OperandType.InlineVar:
							InlineVar(current);
							break;
						case OperandType.ShortInlineBrTarget:
							ShortInlineBrTarget(_methods.Body.Instructions, current);
							break;
						case OperandType.ShortInlineI:
							ShortInlineI(current);
							break;
						case OperandType.ShortInlineR:
							ShortInlineR(current);
							break;
						case OperandType.ShortInlineVar:
							ShortInlineVar(current);
							break;
						default:
							throw new Exception($"OperandType {operandType} Not Supported");
						}
						continue;
					}
					throw new Exception();
				}
			}
			finally
			{
				enumerator?.Dispose();
			}
			Successful = (byte)(809530431 - num) != 0;
			byte[] array = new byte[_binWriter.BaseStream.Length];
			_binWriter.BaseStream.Position = 0x3040743E ^ num;
			_binWriter.BaseStream.Read(array, 0x3040743E ^ num, array.Length);
			ConvertedBytes = array;
		}

		private void OpcodeWriter(OpCode opcode)
		{
			int num = 1591483244;
			int num2 = 1;
			do
			{
				if (num2 == -1591483243 + num)
				{
					_binWriter.Write(opcode.Value);
					num2 = 1591483246 - num;
				}
				if (num2 == (0x5EDC1B6C ^ num))
				{
					num2 = 0x5EDC1B6D ^ num;
				}
			}
			while (num2 != (0x5EDC1B6E ^ num));
		}

		[Obfuscation(Feature = "virtualization", Exclude = false)]
		private void ExceptionStarter()
		{
			int num = 1630320039;
			int num2 = 1;
			MDToken mDToken = default(MDToken);
			IList<Instruction> instructions = default(IList<Instruction>);
			IEnumerator<ExceptionHandler> enumerator = default(IEnumerator<ExceptionHandler>);
			do
			{
				if (num2 == 1630320040 - num)
				{
					mDToken = _methods.MDToken;
					num2 = 0x612CB5A5 ^ num;
				}
				if (num2 == (0x612CB5A5 ^ num))
				{
					mDToken.ToInt32();
					num2 = 0x612CB5A4 ^ num;
				}
				if (num2 == -1630320036 + num)
				{
					instructions = _methods.Body.Instructions;
					num2 = 0x612CB5A3 ^ num;
				}
				if (num2 == (0x612CB5A3 ^ num))
				{
					_binWriter.Write(_methods.Body.ExceptionHandlers.Count);
					num2 = 0x612CB5A2 ^ num;
				}
				if (num2 == -1630320034 + num)
				{
					enumerator = _methods.Body.ExceptionHandlers.GetEnumerator();
					num2 = -1630320033 + num;
				}
				if (num2 == -1630320039 + num)
				{
					num2 = -1630320038 + num;
				}
			}
			while (num2 != -1630320033 + num);
			try
			{
				while (enumerator.MoveNext())
				{
					ExceptionHandler current = enumerator.Current;
					ITypeDefOrRef catchType = current.CatchType;
					Instruction filterStart = current.FilterStart;
					Instruction handlerEnd = current.HandlerEnd;
					Instruction handlerStart = current.HandlerStart;
					ExceptionHandlerType handlerType = current.HandlerType;
					Instruction tryEnd = current.TryEnd;
					Instruction tryStart = current.TryStart;
					TypeDef type = catchType.ResolveTypeDef();
					TypeDef typeDef = Protector.moduleDefMD.Import(type).ResolveTypeDef();
					if (catchType == null)
					{
						_binWriter.Write(-1630320040 + num);
					}
					else if (typeDef.Module != _methods.Module)
					{
						_binWriter.Write(catchType.MDToken.ToInt32());
					}
					else
					{
						_binWriter.Write(typeDef.MDToken.ToInt32());
					}
					int num3 = instructions.IndexOf(filterStart);
					if (num3 == -1630320040 + num)
					{
						_binWriter.Write(-1630320040 + num);
					}
					else
					{
						_binWriter.Write(num3);
					}
					int num4 = instructions.IndexOf(handlerEnd);
					if (num4 == (-1630320040 ^ num))
					{
						_binWriter.Write(1630320038 - num);
					}
					else
					{
						_binWriter.Write(num4);
					}
					int num5 = instructions.IndexOf(handlerStart);
					if (num5 == (-1630320040 ^ num))
					{
						_binWriter.Write(-1630320040 ^ num);
					}
					else
					{
						_binWriter.Write(num5);
					}
					switch (handlerType)
					{
					case ExceptionHandlerType.Catch:
						_binWriter.Write((byte)(0x612CB5A6u ^ (uint)num));
						break;
					case ExceptionHandlerType.Filter:
						_binWriter.Write((byte)(0x612CB5A3u ^ (uint)num));
						break;
					case ExceptionHandlerType.Finally:
						_binWriter.Write((byte)(1630320044 - num));
						break;
					case ExceptionHandlerType.Fault:
						_binWriter.Write((byte)(1630320042 - num));
						break;
					case ExceptionHandlerType.Duplicated:
						_binWriter.Write((byte)(0x612CB5A5u ^ (uint)num));
						break;
					}
					int num6 = instructions.IndexOf(tryEnd);
					if (num6 == (-1630320040 ^ num))
					{
						_binWriter.Write(-1630320040 ^ num);
					}
					else
					{
						_binWriter.Write(num6);
					}
					int num7 = instructions.IndexOf(tryStart);
					if (num7 == (-1630320040 ^ num))
					{
						_binWriter.Write(1630320038 - num);
					}
					else
					{
						_binWriter.Write(num7);
					}
				}
			}
			finally
			{
				enumerator?.Dispose();
			}
		}

		private void InlineNone(Instruction instruction)
		{
			int num = 481489492;
			int num2 = 1;
			do
			{
				if (num2 == 481489493 - num)
				{
					_binWriter.Write((byte)(0x1CB2F254u ^ (uint)num));
					num2 = 0x1CB2F256 ^ num;
				}
				if (num2 == 481489492 - num)
				{
					num2 = -481489491 + num;
				}
			}
			while (num2 != 481489494 - num);
		}

		private void InlineMethod(Instruction instruction)
		{
			int num = 354722062;
			int num2 = 1;
			MDToken mDToken = default(MDToken);
			int value = default(int);
			int value2 = default(int);
			while (true)
			{
				if (num2 == 354722063 - num)
				{
					_binWriter.Write((byte)(0x1524A10Fu ^ (uint)num));
					num2 = -354722060 + num;
				}
				if (num2 == (0x1524A10C ^ num))
				{
					if (!(instruction.Operand is MethodSpec))
					{
						goto IL_0168;
					}
					num2 = 354722065 - num;
				}
				if (num2 == 354722065 - num)
				{
					mDToken = ((instruction.Operand as MethodSpec) ?? throw new Exception("Check the instruction. This should not happen")).MDToken;
					num2 = 354722066 - num;
				}
				if (num2 == (0x1524A10A ^ num))
				{
					value = mDToken.ToInt32();
					num2 = -354722057 + num;
				}
				if (num2 == -354722057 + num)
				{
					_binWriter.Write(value);
					num2 = 0x1524A108 ^ num;
				}
				if (num2 != -354722056 + num)
				{
					if (num2 == (0x1524A106 ^ num))
					{
						value2 = mDToken.ToInt32();
						num2 = 0x1524A107 ^ num;
					}
					if (num2 == 354722071 - num)
					{
						_binWriter.Write(value2);
						num2 = 0x1524A104 ^ num;
					}
					if (num2 == -354722055 + num)
					{
						goto IL_0168;
					}
					goto IL_0193;
				}
				return;
				IL_0193:
				if (num2 == (0x1524A10E ^ num))
				{
					num2 = 0x1524A10F ^ num;
				}
				if (num2 == (0x1524A104 ^ num))
				{
					return;
				}
				continue;
				IL_0168:
				IMethodDefOrRef obj = instruction.Operand as IMethodDefOrRef;
				if (obj == null)
				{
					break;
				}
				mDToken = obj.MDToken;
				num2 = -354722054 + num;
				goto IL_0193;
			}
			throw new Exception("Check the instruction. This should not happen");
		}

		private void InlineString(Instruction instruction)
		{
			int num = 509826130;
			int num2 = 1;
			string value = default(string);
			do
			{
				if (num2 == -509826129 + num)
				{
					_binWriter.Write((byte)(0x1E635450u ^ (uint)num));
					num2 = 509826132 - num;
				}
				if (num2 == -509826128 + num)
				{
					value = instruction.Operand.ToString();
					num2 = 509826133 - num;
				}
				if (num2 == (0x1E635451 ^ num))
				{
					_binWriter.Write(value);
					num2 = -509826126 + num;
				}
				if (num2 == 509826130 - num)
				{
					num2 = 0x1E635453 ^ num;
				}
			}
			while (num2 != (0x1E635456 ^ num));
		}

		private void InlineI(Instruction instruction)
		{
			int num = 359840007;
			int num2 = 1;
			int ldcI4Value = default(int);
			do
			{
				if (num2 == (0x1572B906 ^ num))
				{
					_binWriter.Write((byte)(0x1572B904u ^ (uint)num));
					num2 = 359840009 - num;
				}
				if (num2 == -359840005 + num)
				{
					ldcI4Value = instruction.GetLdcI4Value();
					num2 = 0x1572B904 ^ num;
				}
				if (num2 == (0x1572B904 ^ num))
				{
					_binWriter.Write(ldcI4Value);
					num2 = 359840011 - num;
				}
				if (num2 == (0x1572B907 ^ num))
				{
					num2 = -359840006 + num;
				}
			}
			while (num2 != -359840003 + num);
		}

		private void ShortInlineVar(Instruction instruction)
		{
			int num = 439812323;
			int num2 = 1;
			Local local = default(Local);
			Parameter parameter = default(Parameter);
			do
			{
				if (num2 == 439812324 - num)
				{
					_binWriter.Write((byte)(0x1A3700E7u ^ (uint)num));
					num2 = 0x1A3700E1 ^ num;
				}
				if (num2 == 439812325 - num)
				{
					if (!(instruction.Operand is Local))
					{
						goto IL_01af;
					}
					num2 = 439812326 - num;
				}
				if (num2 == -439812320 + num)
				{
					local = instruction.Operand as Local;
					num2 = 439812327 - num;
				}
				if (num2 == 439812327 - num)
				{
					_binWriter.Write(local.Index);
					num2 = 0x1A3700E6 ^ num;
				}
				if (num2 == (0x1A3700E6 ^ num))
				{
					_binWriter.Write((byte)(-439812323 + num));
					num2 = 439812329 - num;
				}
				if (num2 != -439812317 + num)
				{
					if (num2 == (0x1A3700EB ^ num))
					{
						parameter = instruction.Operand as Parameter;
						num2 = 0x1A3700EA ^ num;
					}
					if (num2 == -439812314 + num)
					{
						_binWriter.Write(parameter.Index);
						num2 = 0x1A3700E9 ^ num;
					}
					if (num2 == 439812333 - num)
					{
						_binWriter.Write((byte)(0x1A3700E2u ^ (uint)num));
						num2 = 439812334 - num;
					}
					if (num2 == (0x1A3700E4 ^ num))
					{
						goto IL_01af;
					}
					goto IL_01d0;
				}
				break;
				IL_01af:
				if (instruction.Operand is Parameter)
				{
					num2 = -439812315 + num;
					goto IL_01d0;
				}
				break;
				IL_01d0:
				if (num2 == (0x1A3700E3 ^ num))
				{
					num2 = 439812324 - num;
				}
			}
			while (num2 != 439812334 - num);
		}

		private void InlineField(Instruction instruction)
		{
			int num = 2081217786;
			int num2 = 1;
			MDToken mDToken = default(MDToken);
			int value = default(int);
			int value2 = default(int);
			while (true)
			{
				if (num2 == (0x7C0CDCFB ^ num))
				{
					_binWriter.Write((byte)(-2081217781 + num));
					num2 = 0x7C0CDCF8 ^ num;
				}
				if (num2 == (0x7C0CDCF8 ^ num))
				{
					if (!(instruction.Operand is MemberRef))
					{
						goto IL_0168;
					}
					num2 = 2081217789 - num;
				}
				if (num2 == (0x7C0CDCF9 ^ num))
				{
					mDToken = ((instruction.Operand as MemberRef) ?? throw new Exception("Check the instruction. This should not happen")).MDToken;
					num2 = 0x7C0CDCFE ^ num;
				}
				if (num2 == 2081217790 - num)
				{
					value = mDToken.ToInt32();
					num2 = 0x7C0CDCFF ^ num;
				}
				if (num2 == (0x7C0CDCFF ^ num))
				{
					_binWriter.Write(value);
					num2 = 0x7C0CDCFC ^ num;
				}
				if (num2 != -2081217780 + num)
				{
					if (num2 == 2081217794 - num)
					{
						value2 = mDToken.ToInt32();
						num2 = 0x7C0CDCF3 ^ num;
					}
					if (num2 == -2081217777 + num)
					{
						_binWriter.Write(value2);
						num2 = 0x7C0CDCF0 ^ num;
					}
					if (num2 == -2081217779 + num)
					{
						goto IL_0168;
					}
					goto IL_0193;
				}
				return;
				IL_0193:
				if (num2 == -2081217786 + num)
				{
					num2 = -2081217785 + num;
				}
				if (num2 == -2081217776 + num)
				{
					return;
				}
				continue;
				IL_0168:
				FieldDef obj = instruction.Operand as FieldDef;
				if (obj == null)
				{
					break;
				}
				mDToken = obj.MDToken;
				num2 = 0x7C0CDCF2 ^ num;
				goto IL_0193;
			}
			throw new Exception("Check the instruction. This should not happen");
		}

		private void InlineType(Instruction instruction)
		{
			int num = 177160837;
			int num2 = 1;
			MDToken mDToken = default(MDToken);
			int value = default(int);
			while (true)
			{
				if (num2 == 177160838 - num)
				{
					_binWriter.Write((byte)(-177160831 + num));
					num2 = -177160835 + num;
				}
				if (num2 == -177160835 + num)
				{
					ITypeDefOrRef obj = instruction.Operand as ITypeDefOrRef;
					if (obj == null)
					{
						break;
					}
					mDToken = obj.MDToken;
					num2 = 0xA8F4286 ^ num;
				}
				if (num2 == 177160840 - num)
				{
					value = mDToken.ToInt32();
					num2 = 0xA8F4281 ^ num;
				}
				if (num2 == 177160841 - num)
				{
					_binWriter.Write(value);
					num2 = 177160842 - num;
				}
				if (num2 == 177160837 - num)
				{
					num2 = -177160836 + num;
				}
				if (num2 == -177160832 + num)
				{
					return;
				}
			}
			throw new Exception("Check the instruction. This should not happen");
		}

		private void ShortInlineBrTarget(IList<Instruction> allInstructions, Instruction instruction)
		{
			int num = 890940896;
			int num2 = 1;
			int value = default(int);
			do
			{
				if (num2 == (0x351AADE1 ^ num))
				{
					_binWriter.Write((byte)(-890940889 + num));
					num2 = 0x351AADE2 ^ num;
				}
				if (num2 == (0x351AADE2 ^ num))
				{
					value = allInstructions.IndexOf((Instruction)instruction.Operand);
					num2 = 0x351AADE3 ^ num;
				}
				if (num2 == 890940899 - num)
				{
					_binWriter.Write(value);
					num2 = -890940892 + num;
				}
				if (num2 == 890940896 - num)
				{
					num2 = 890940897 - num;
				}
			}
			while (num2 != -890940892 + num);
		}

		private void ShortInlineI(Instruction instruction)
		{
			int num = 1426894008;
			int num2 = 1;
			int ldcI4Value = default(int);
			do
			{
				if (num2 == 1426894009 - num)
				{
					_binWriter.Write((byte)(1426894016 - num));
					num2 = -1426894006 + num;
				}
				if (num2 == 1426894010 - num)
				{
					ldcI4Value = instruction.GetLdcI4Value();
					num2 = 0x550CACBB ^ num;
				}
				if (num2 == 1426894011 - num)
				{
					_binWriter.Write((byte)ldcI4Value);
					num2 = -1426894004 + num;
				}
				if (num2 == -1426894008 + num)
				{
					num2 = -1426894007 + num;
				}
			}
			while (num2 != -1426894004 + num);
		}

		private void InlineSwitch(IList<Instruction> allInstructions, Instruction instruction)
		{
			int num = 505718190;
			int num2 = 1;
			Instruction[] array = default(Instruction[]);
			Instruction[] array2 = default(Instruction[]);
			int num3 = default(int);
			int value = default(int);
			Instruction item = default(Instruction);
			do
			{
				if (num2 == 505718191 - num)
				{
					_binWriter.Write((byte)(0x1E24A5A7u ^ (uint)num));
					num2 = 505718192 - num;
				}
				if (num2 == (0x1E24A5AC ^ num))
				{
					array = instruction.Operand as Instruction[];
					num2 = -505718187 + num;
				}
				if (num2 == -505718187 + num)
				{
					_binWriter.Write(array.Count());
					num2 = 505718194 - num;
				}
				if (num2 == 505718194 - num)
				{
					array2 = array;
					num2 = 505718195 - num;
				}
				if (num2 == -505718185 + num)
				{
					num3 = 505718190 - num;
					num2 = 505718196 - num;
				}
				if (num2 != (0x1E24A5A8 ^ num))
				{
					if (num2 == -505718182 + num)
					{
						value = allInstructions.IndexOf(item);
						num2 = 505718199 - num;
					}
					if (num2 == 505718199 - num)
					{
						_binWriter.Write(value);
						num2 = 505718200 - num;
					}
					if (num2 == (0x1E24A5A4 ^ num))
					{
						num3 += 505718191 - num;
						num2 = -505718179 + num;
					}
					if (num2 != 505718201 - num)
					{
						goto IL_01a9;
					}
				}
				if (num3 >= array2.Length)
				{
					num2 = 0x1E24A5A2 ^ num;
					goto IL_01a9;
				}
				goto IL_01bb;
				IL_01bb:
				item = array2[num3];
				num2 = 505718198 - num;
				goto IL_01d6;
				IL_01a9:
				if (num2 == -505718183 + num)
				{
					goto IL_01bb;
				}
				goto IL_01d6;
				IL_01d6:
				if (num2 == 505718190 - num)
				{
					num2 = 505718191 - num;
				}
			}
			while (num2 != -505718178 + num);
		}

		private void InlineBrTarget(IList<Instruction> allInstructions, Instruction instruction)
		{
			int num = 1836092916;
			int num2 = 1;
			int value = default(int);
			do
			{
				if (num2 == -1836092915 + num)
				{
					_binWriter.Write((byte)(0x6D708DFEu ^ (uint)num));
					num2 = -1836092914 + num;
				}
				if (num2 == 1836092918 - num)
				{
					value = allInstructions.IndexOf((Instruction)instruction.Operand);
					num2 = 0x6D708DF7 ^ num;
				}
				if (num2 == 1836092919 - num)
				{
					_binWriter.Write(value);
					num2 = 0x6D708DF0 ^ num;
				}
				if (num2 == 1836092916 - num)
				{
					num2 = -1836092915 + num;
				}
			}
			while (num2 != (0x6D708DF0 ^ num));
		}

		private void InlineTok(Instruction instruction)
		{
			int num = 2062734163;
			int num2 = 1;
			MDToken mDToken = default(MDToken);
			int value = default(int);
			int value2 = default(int);
			int value3 = default(int);
			while (true)
			{
				if (num2 == -2062734162 + num)
				{
					_binWriter.Write((byte)(-2062734152 + num));
					num2 = -2062734161 + num;
				}
				if (num2 == (0x7AF2D351 ^ num))
				{
					if (!(instruction.Operand is FieldDef))
					{
						goto IL_0126;
					}
					num2 = 0x7AF2D350 ^ num;
				}
				if (num2 == -2062734160 + num)
				{
					mDToken = (instruction.Operand as FieldDef).MDToken;
					num2 = 2062734167 - num;
				}
				if (num2 == 2062734167 - num)
				{
					value = mDToken.ToInt32();
					num2 = -2062734158 + num;
				}
				if (num2 == -2062734158 + num)
				{
					_binWriter.Write(value);
					num2 = 0x7AF2D355 ^ num;
				}
				if (num2 == (0x7AF2D355 ^ num))
				{
					_binWriter.Write((byte)(-2062734163 + num));
					num2 = 0x7AF2D354 ^ num;
				}
				if (num2 == (0x7AF2D35B ^ num))
				{
					goto IL_0126;
				}
				goto IL_0147;
				IL_031f:
				if (instruction.Operand is IMethodDefOrRef)
				{
					num2 = -2062734148 + num;
					goto IL_0340;
				}
				goto IL_03cd;
				IL_0340:
				if (num2 != -2062734156 + num)
				{
					if (num2 == 2062734163 - num)
					{
						num2 = 2062734164 - num;
					}
					if (num2 != -2062734143 + num)
					{
						continue;
					}
					goto IL_03cd;
				}
				break;
				IL_03cd:
				throw new Exception("Check the instruction. This should not happen");
				IL_0147:
				if (num2 == 2062734172 - num)
				{
					mDToken = (instruction.Operand as ITypeDefOrRef).MDToken;
					num2 = 2062734173 - num;
				}
				if (num2 == -2062734153 + num)
				{
					value2 = mDToken.ToInt32();
					num2 = -2062734152 + num;
				}
				if (num2 == (0x7AF2D358 ^ num))
				{
					_binWriter.Write(value2);
					num2 = -2062734151 + num;
				}
				if (num2 == 2062734175 - num)
				{
					_binWriter.Write((byte)(2062734164 - num));
					num2 = 2062734176 - num;
				}
				if (num2 != 2062734176 - num)
				{
					if (num2 == (0x7AF2D35C ^ num))
					{
						mDToken = (instruction.Operand as IMethodDefOrRef).MDToken;
						num2 = 0x7AF2D343 ^ num;
					}
					if (num2 == (0x7AF2D343 ^ num))
					{
						value3 = mDToken.ToInt32();
						num2 = 2062734180 - num;
					}
					if (num2 == -2062734146 + num)
					{
						_binWriter.Write(value3);
						num2 = 2062734181 - num;
					}
					if (num2 == (0x7AF2D341 ^ num))
					{
						_binWriter.Write((byte)(2062734165 - num));
						num2 = -2062734144 + num;
					}
					if (num2 != (0x7AF2D340 ^ num))
					{
						if (num2 == -2062734149 + num)
						{
							goto IL_031f;
						}
						goto IL_0340;
					}
					break;
				}
				break;
				IL_0126:
				if (instruction.Operand is ITypeDefOrRef)
				{
					num2 = -2062734154 + num;
					goto IL_0147;
				}
				goto IL_031f;
			}
		}

		private void InlineVar(Instruction instruction)
		{
			int num = 275454878;
			int num2 = 1;
			Local local = default(Local);
			Parameter parameter = default(Parameter);
			do
			{
				if (num2 == (0x106B1B9F ^ num))
				{
					_binWriter.Write((byte)(-275454866 + num));
					num2 = 0x106B1B9C ^ num;
				}
				if (num2 == (0x106B1B9C ^ num))
				{
					if (!(instruction.Operand is Local))
					{
						goto IL_01db;
					}
					num2 = 275454881 - num;
				}
				if (num2 == 275454881 - num)
				{
					local = instruction.Operand as Local;
					num2 = -275454874 + num;
				}
				if (num2 == (0x106B1B9A ^ num))
				{
					_binWriter.Write(local.Index);
					num2 = -275454873 + num;
				}
				if (num2 == -275454873 + num)
				{
					_binWriter.Write((byte)(275454878 - num));
					num2 = -275454872 + num;
				}
				if (num2 != -275454872 + num)
				{
					if (num2 == 275454886 - num)
					{
						parameter = instruction.Operand as Parameter;
						num2 = 0x106B1B97 ^ num;
					}
					if (num2 == 275454887 - num)
					{
						_binWriter.Write(parameter.Index);
						num2 = 275454888 - num;
					}
					if (num2 == 275454888 - num)
					{
						_binWriter.Write((byte)(0x106B1B9Fu ^ (uint)num));
						num2 = 0x106B1B95 ^ num;
					}
					if (num2 != (0x106B1B95 ^ num))
					{
						if (num2 == -275454866 + num)
						{
							goto IL_01eb;
						}
						goto IL_023b;
					}
					break;
				}
				break;
				IL_01eb:
				_binWriter.Write(-275454878 + num);
				num2 = 0x106B1B93 ^ num;
				goto IL_023b;
				IL_023b:
				if (num2 == (0x106B1B93 ^ num))
				{
					_binWriter.Write((byte)(275454878 - num));
					num2 = -275454864 + num;
				}
				if (num2 == -275454871 + num)
				{
					goto IL_01db;
				}
				goto IL_0260;
				IL_0260:
				if (num2 == 275454878 - num)
				{
					num2 = 0x106B1B9F ^ num;
				}
				continue;
				IL_01db:
				if (!(instruction.Operand is Parameter))
				{
					goto IL_01eb;
				}
				num2 = -275454870 + num;
				goto IL_0260;
			}
			while (num2 != 275454892 - num);
		}

		private void ShortInlineR(Instruction instruction)
		{
			int num = 137226507;
			int num2 = 1;
			object operand = default(object);
			do
			{
				if (num2 == 137226508 - num)
				{
					_binWriter.Write((byte)(0x82DE906u ^ (uint)num));
					num2 = 0x82DE909 ^ num;
				}
				if (num2 == 137226509 - num)
				{
					operand = instruction.Operand;
					num2 = -137226504 + num;
				}
				if (num2 == 137226510 - num)
				{
					_binWriter.Write((float)operand);
					num2 = 0x82DE90F ^ num;
				}
				if (num2 == -137226507 + num)
				{
					num2 = 137226508 - num;
				}
			}
			while (num2 != (0x82DE90F ^ num));
		}

		private void InlineR(Instruction instruction)
		{
			int num = 1158809465;
			int num2 = 1;
			object operand = default(object);
			do
			{
				if (num2 == 1158809466 - num)
				{
					_binWriter.Write((byte)(0x45120777u ^ (uint)num));
					num2 = -1158809463 + num;
				}
				if (num2 == (0x4512077B ^ num))
				{
					operand = instruction.Operand;
					num2 = 1158809468 - num;
				}
				if (num2 == 1158809468 - num)
				{
					_binWriter.Write((double)operand);
					num2 = 0x4512077D ^ num;
				}
				if (num2 == -1158809465 + num)
				{
					num2 = -1158809464 + num;
				}
			}
			while (num2 != -1158809461 + num);
		}

		private void InlineI8(Instruction instruction)
		{
			int num = 1648077915;
			int num2 = 1;
			object operand = default(object);
			do
			{
				if (num2 == -1648077914 + num)
				{
					_binWriter.Write((byte)(1648077930 - num));
					num2 = -1648077913 + num;
				}
				if (num2 == 1648077917 - num)
				{
					operand = instruction.Operand;
					num2 = -1648077912 + num;
				}
				if (num2 == (0x623BAC58 ^ num))
				{
					_binWriter.Write((long)operand);
					num2 = 1648077919 - num;
				}
				if (num2 == (0x623BAC5B ^ num))
				{
					num2 = 0x623BAC5A ^ num;
				}
			}
			while (num2 != -1648077911 + num);
		}
	}
}
