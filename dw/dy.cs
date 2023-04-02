using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using ICore;
using Protections.ControlFlow;

namespace dw
{
	internal class dy : cW
	{
		private struct hs
		{
			public Dictionary<uint, int> ht;

			public Dictionary<uint, List<Instruction>> hu;

			public Dictionary<uint, int> hv;

			public Dictionary<uint, int> hw;

			private static void ea(Dictionary<uint, int> counts, uint key)
			{
				if (!counts.TryGetValue(key, out var value))
				{
					value = 0;
				}
				counts[key] = value + 1;
			}

			public hs(CilBody body, bool hasReturnValue)
			{
				ht = new Dictionary<uint, int>();
				hu = new Dictionary<uint, List<Instruction>>();
				hv = new Dictionary<uint, int>();
				hw = new Dictionary<uint, int>();
				body.UpdateInstructionOffsets();
				foreach (ExceptionHandler exceptionHandler in body.ExceptionHandlers)
				{
					hv[exceptionHandler.TryStart.Offset] = 0;
					hv[exceptionHandler.HandlerStart.Offset] = ((exceptionHandler.HandlerType != ExceptionHandlerType.Finally) ? 1 : 0);
					if (exceptionHandler.FilterStart != null)
					{
						hv[exceptionHandler.FilterStart.Offset] = 1;
					}
				}
				int stack = 0;
				for (int i = 0; i < body.Instructions.Count; i++)
				{
					Instruction instruction = body.Instructions[i];
					if (hv.ContainsKey(instruction.Offset))
					{
						stack = hv[instruction.Offset];
					}
					hv[instruction.Offset] = stack;
					instruction.UpdateStack(ref stack, hasReturnValue);
					hw[instruction.Offset] = stack;
					switch (instruction.OpCode.FlowControl)
					{
					case FlowControl.Branch:
					{
						uint offset = ((Instruction)instruction.Operand).Offset;
						if (!hv.ContainsKey(offset))
						{
							hv[offset] = stack;
						}
						ea(ht, offset);
						hu.AddListEntry(offset, instruction);
						stack = 0;
						break;
					}
					case FlowControl.Call:
						if (instruction.OpCode.Code == Code.Jmp)
						{
							stack = 0;
						}
						goto case FlowControl.Break;
					case FlowControl.Cond_Branch:
						if (instruction.OpCode.Code == Code.Switch)
						{
							Instruction[] array = (Instruction[])instruction.Operand;
							foreach (Instruction instruction2 in array)
							{
								if (!hv.ContainsKey(instruction2.Offset))
								{
									hv[instruction2.Offset] = stack;
								}
								ea(ht, instruction2.Offset);
								hu.AddListEntry(instruction2.Offset, instruction);
							}
						}
						else
						{
							uint offset = ((Instruction)instruction.Operand).Offset;
							if (!hv.ContainsKey(offset))
							{
								hv[offset] = stack;
							}
							ea(ht, offset);
							hu.AddListEntry(offset, instruction);
						}
						goto case FlowControl.Break;
					case FlowControl.Break:
					case FlowControl.Meta:
					case FlowControl.Next:
						if (i + 1 < body.Instructions.Count)
						{
							uint offset = body.Instructions[i + 1].Offset;
							ea(ht, offset);
						}
						break;
					case FlowControl.Return:
					case FlowControl.Throw:
						break;
					default:
						throw new Exception();
					}
				}
			}

			public bool hx(uint offset)
			{
				if (hu.TryGetValue(offset, out var value))
				{
					return value.Count > 0;
				}
				return false;
			}

			public bool hy(uint offset)
			{
				if (ht.TryGetValue(offset, out var value))
				{
					return value > 1;
				}
				return false;
			}
		}

		[CompilerGenerated]
		private ModuleDefMD dh;

		private static Random l = new Random();

		public ModuleDefMD dk
		{
			[CompilerGenerated]
			get
			{
				return dh;
			}
			[CompilerGenerated]
			set
			{
				dh = value;
			}
		}

		private static OpCode dl(OpCode opCode)
		{
			switch (opCode.Code)
			{
			default:
				throw new NotSupportedException();
			case Code.Brfalse:
				return OpCodes.Brtrue;
			case Code.Brtrue:
				return OpCodes.Brfalse;
			case Code.Beq:
				return OpCodes.Bne_Un;
			case Code.Bge:
				return OpCodes.Blt;
			case Code.Bgt:
				return OpCodes.Ble;
			case Code.Ble:
				return OpCodes.Bgt;
			case Code.Blt:
				return OpCodes.Bge;
			case Code.Bne_Un:
				return OpCodes.Beq;
			case Code.Bge_Un:
				return OpCodes.Blt_Un;
			case Code.Bgt_Un:
				return OpCodes.Ble_Un;
			case Code.Ble_Un:
				return OpCodes.Bgt_Un;
			case Code.Blt_Un:
				return OpCodes.Bge_Un;
			}
		}

		public override void cY(CilBody body, cK.hd root, Context ctx, MethodDef Method, TypeSig retType)
		{
			dk = ctx.Module;
			hs trace = new hs(body, retType.RemoveModifiers().ElementType != ElementType.Void);
			Local local = new Local(Method.Module.CorLibTypes.UInt32);
			Local local2 = new Local(Method.Module.ImportAsTypeSig(typeof(uint[])));
			body.Variables.Add(local2);
			body.Variables.Add(local);
			body.InitLocals = true;
			body.MaxStack += 2;
			cZ cZ2 = new dc(ctx.Module);
			foreach (cK.ho block in cW.cX(root))
			{
				LinkedList<Instruction[]> statements = @do(block, trace);
				if (Method.IsInstanceConstructor)
				{
					List<Instruction> list = new List<Instruction>();
					while (statements.First != null)
					{
						list.AddRange(statements.First.Value);
						Instruction instruction = statements.First.Value.Last();
						statements.RemoveFirst();
						if (instruction.OpCode == OpCodes.Call && ((IMethod)instruction.Operand).Name == ".ctor")
						{
							break;
						}
					}
					statements.AddFirst(list.ToArray());
				}
				if (statements.Count < 3)
				{
					continue;
				}
				int[] array = Enumerable.Range(0, statements.Count).ToArray();
				dp(array);
				int[] array2 = new int[array.Length];
				int i;
				for (i = 0; i < array2.Length; i++)
				{
					int num = new Random().Next() & 0x7FFFFFFF;
					array2[i] = num - num % statements.Count + array[i];
				}
				Dictionary<Instruction, int> dictionary = new Dictionary<Instruction, int>();
				LinkedListNode<Instruction[]> linkedListNode = statements.First;
				i = 0;
				while (linkedListNode != null)
				{
					if (i != 0)
					{
						dictionary[linkedListNode.Value[0]] = array2[i];
					}
					i++;
					linkedListNode = linkedListNode.Next;
				}
				HashSet<Instruction> statementLast = new HashSet<Instruction>(statements.Select((Instruction[] st) => st.Last()));
				Func<IList<Instruction>, bool> func = (IList<Instruction> instrs) => instrs.Any(delegate(Instruction instr)
				{
					if (!trace.hy(instr.Offset))
					{
						if (trace.hu.TryGetValue(instr.Offset, out var value5))
						{
							if (value5.Any((Instruction src) => src.Operand is Instruction[]))
							{
								return true;
							}
							if (value5.Any((Instruction src) => src.Offset <= statements.First.Value.Last().Offset || src.Offset >= block.hr.Last().Offset))
							{
								return true;
							}
							if (value5.Any((Instruction src) => statementLast.Contains(src)))
							{
								return true;
							}
						}
						return false;
					}
					return true;
				});
				Instruction instruction2 = new Instruction(OpCodes.Switch);
				List<Instruction> list2 = new List<Instruction>();
				if (cZ2 != null)
				{
					cZ2.Init(body);
					list2.Add(Instruction.CreateLdcI4(cZ2.db(array2[1])));
					cZ2.da(list2);
				}
				else
				{
					list2.Add(Instruction.CreateLdcI4(array2[1]));
				}
				list2.Add(Instruction.Create(OpCodes.Dup));
				list2.Add(Instruction.Create(OpCodes.Stloc, local));
				list2.Add(Instruction.Create(OpCodes.Ldc_I4, statements.Count));
				list2.Add(Instruction.Create(OpCodes.Rem_Un));
				list2.Add(instruction2);
				dq(list2, statements.Last.Value[0], Method);
				dr(list2, Method);
				Instruction[] array3 = new Instruction[statements.Count];
				linkedListNode = statements.First;
				i = 0;
				while (linkedListNode.Next != null)
				{
					List<Instruction> toInject = new List<Instruction>(linkedListNode.Value);
					if (i != 0)
					{
						bool flag = false;
						if (toInject.Last().IsBr())
						{
							Instruction key = (Instruction)toInject.Last().Operand;
							if (!trace.hx(toInject.Last().Offset) && dictionary.TryGetValue(key, out var value))
							{
								int num2 = cZ2?.db(value) ?? value;
								bool num3 = func(toInject);
								toInject.RemoveAt(toInject.Count - 1);
								if (num3)
								{
									toInject.Add(Instruction.Create(OpCodes.Ldc_I4, num2));
								}
								else
								{
									int num4 = array2[i];
									int num5 = ICore.Utils.RandomBigInt32();
									Local local3 = new Local(Method.Module.CorLibTypes.UInt32);
									new Local(Method.Module.CorLibTypes.UInt32);
									body.Variables.Add(local3);
									toInject.Add(Instruction.Create(OpCodes.Ldloc, local));
									toInject.Add(Instruction.Create(OpCodes.Ldc_I4, num5));
									toInject.Add(Instruction.Create(OpCodes.Div));
									toInject.Add(Instruction.Create(OpCodes.Stloc, local3));
									toInject.Add(Instruction.Create(OpCodes.Ldloc, local3));
									toInject.Add(Instruction.Create(OpCodes.Ldc_I4, num4 / num5 - num2));
									toInject.Add(Instruction.Create(OpCodes.Sub));
								}
								dq(toInject, list2[1], Method);
								dr(toInject, Method);
								array3[array[i]] = toInject[0];
								flag = true;
							}
						}
						else if (toInject.Last().IsConditionalBranch())
						{
							Instruction key2 = (Instruction)toInject.Last().Operand;
							if (!trace.hx(toInject.Last().Offset) && dictionary.TryGetValue(key2, out var value2))
							{
								bool num6 = func(toInject);
								int num7 = array2[i + 1];
								OpCode opCode = toInject.Last().OpCode;
								toInject.RemoveAt(toInject.Count - 1);
								if (Convert.ToBoolean(l.Next(0, 2)))
								{
									opCode = dl(opCode);
									int num8 = value2;
									value2 = num7;
									num7 = num8;
								}
								int num9 = array2[i];
								int num10 = 0;
								int num11 = 0;
								if (!num6)
								{
									num10 = ICore.Utils.RandomBigInt32();
									num11 = num9 / num10;
								}
								Instruction instruction3 = Instruction.CreateLdcI4(num11 ^ (cZ2?.db(value2) ?? value2));
								Instruction item = Instruction.CreateLdcI4(num11 ^ (cZ2?.db(num7) ?? num7));
								Instruction instruction4 = Instruction.Create(OpCodes.Pop);
								toInject.Add(Instruction.Create(opCode, instruction3));
								toInject.Add(item);
								toInject.Add(Instruction.Create(OpCodes.Dup));
								toInject.Add(Instruction.Create(OpCodes.Br, instruction4));
								toInject.Add(instruction3);
								toInject.Add(Instruction.Create(OpCodes.Dup));
								toInject.Add(instruction4);
								if (!num6)
								{
									toInject.Add(Instruction.Create(OpCodes.Ldloc, local));
									toInject.Add(Instruction.Create(OpCodes.Ldc_I4, num10));
									toInject.Add(Instruction.Create(OpCodes.Div));
									toInject.Add(Instruction.Create(OpCodes.Xor));
								}
								dq(toInject, list2[1], Method);
								dr(toInject, Method);
								array3[array[i]] = toInject[0];
								flag = true;
							}
						}
						if (!flag)
						{
							int num12 = cZ2?.db(array2[i + 1]) ?? array2[i + 1];
							if (!func(toInject))
							{
								int num13 = array2[i];
								int[] array4 = dm();
								int num14 = array4[array4.Length - 1];
								Local local4 = new Local(Method.Module.CorLibTypes.UInt32);
								Local local5 = new Local(Method.Module.CorLibTypes.UInt32);
								body.Variables.Add(local4);
								body.Variables.Add(local5);
								toInject.Add(Instruction.Create(OpCodes.Ldloc, local));
								toInject.Add(Instruction.Create(OpCodes.Stloc, local5));
								dn(Method, array4, ref toInject, local2);
								toInject.Add(Instruction.Create(OpCodes.Ldloc, local5));
								toInject.Add(OpCodes.Ldloc_S.ToInstruction(local2));
								toInject.Add(OpCodes.Ldc_I4.ToInstruction(array4.Length - 1));
								toInject.Add(OpCodes.Ldelem_I4.ToInstruction());
								toInject.Add(Instruction.Create(OpCodes.Div));
								toInject.Add(Instruction.Create(OpCodes.Stloc, local4));
								toInject.Add(Instruction.Create(OpCodes.Ldloc, local4));
								toInject.Add(Instruction.Create(OpCodes.Ldc_I4, num13 / num14 - num12));
								toInject.Add(Instruction.Create(OpCodes.Sub));
							}
							else
							{
								toInject.Add(Instruction.Create(OpCodes.Ldc_I4, num12));
							}
							dq(toInject, list2[1], Method);
							dr(toInject, Method);
							array3[array[i]] = toInject[0];
						}
					}
					else
					{
						array3[array[i]] = list2[0];
					}
					linkedListNode.Value = toInject.ToArray();
					linkedListNode = linkedListNode.Next;
					i++;
				}
				array3[array[i]] = linkedListNode.Value[0];
				instruction2.Operand = array3;
				Instruction[] value3 = statements.First.Value;
				statements.RemoveFirst();
				Instruction[] value4 = statements.Last.Value;
				statements.RemoveLast();
				List<Instruction[]> list3 = statements.ToList();
				dp(list3);
				block.hr.Clear();
				block.hr.AddRange(value3);
				block.hr.AddRange(list2);
				foreach (Instruction[] item2 in list3)
				{
					block.hr.AddRange(item2);
				}
				block.hr.AddRange(value4);
			}
		}

		private static int[] dm()
		{
			int[] array = new int[l.Next(3, 6)];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = l.Next(100, 500);
			}
			return array;
		}

		private static void dn(MethodDef method, int[] array, ref List<Instruction> toInject, Local local)
		{
			List<Instruction> list = new List<Instruction>
			{
				OpCodes.Ldc_I4.ToInstruction(array.Length),
				OpCodes.Newarr.ToInstruction(method.Module.CorLibTypes.UInt32),
				OpCodes.Stloc_S.ToInstruction(local)
			};
			for (int i = 0; i < array.Length; i++)
			{
				if (i == 0)
				{
					list.Add(OpCodes.Ldloc_S.ToInstruction(local));
					list.Add(OpCodes.Ldc_I4.ToInstruction(i));
					list.Add(OpCodes.Ldc_I4.ToInstruction(array[i]));
					list.Add(OpCodes.Stelem_I4.ToInstruction());
					list.Add(OpCodes.Nop.ToInstruction());
					continue;
				}
				int num = array[i];
				list.Add(OpCodes.Ldloc_S.ToInstruction(local));
				list.Add(OpCodes.Ldc_I4.ToInstruction(i));
				list.Add(OpCodes.Ldc_I4.ToInstruction(num));
				int index = list.Count - 1;
				for (int num2 = i - 1; num2 >= 0; num2--)
				{
					OpCode opCode = null;
					switch (l.Next(0, 2))
					{
					case 1:
						num -= array[num2];
						opCode = OpCodes.Add;
						break;
					case 0:
						num += array[num2];
						opCode = OpCodes.Sub;
						break;
					}
					list.Add(OpCodes.Ldloc_S.ToInstruction(local));
					list.Add(OpCodes.Ldc_I4.ToInstruction(num2));
					list.Add(OpCodes.Ldelem_I4.ToInstruction());
					list.Add(opCode.ToInstruction());
				}
				list[index].OpCode = OpCodes.Ldc_I4;
				list[index].Operand = num;
				list.Add(OpCodes.Stelem_I4.ToInstruction());
				list.Add(OpCodes.Nop.ToInstruction());
			}
			for (int j = 0; j < list.Count; j++)
			{
				toInject.Add(list[j]);
			}
		}

		private LinkedList<Instruction[]> @do(cK.ho block, hs trace)
		{
			LinkedList<Instruction[]> linkedList = new LinkedList<Instruction[]>();
			List<Instruction> list = new List<Instruction>();
			HashSet<Instruction> hashSet = new HashSet<Instruction>();
			for (int i = 0; i < block.hr.Count; i++)
			{
				Instruction instruction = block.hr[i];
				list.Add(instruction);
				bool flag = i + 1 < block.hr.Count && trace.hy(block.hr[i + 1].Offset);
				FlowControl flowControl = instruction.OpCode.FlowControl;
				if (flowControl == FlowControl.Branch || flowControl == FlowControl.Cond_Branch || (uint)(flowControl - 7) <= 1u)
				{
					flag = true;
					if (trace.hw[instruction.Offset] != 0)
					{
						if (instruction.Operand is Instruction item)
						{
							hashSet.Add(item);
						}
						else if (instruction.Operand is Instruction[] array)
						{
							Instruction[] array2 = array;
							foreach (Instruction item2 in array2)
							{
								hashSet.Add(item2);
							}
						}
					}
				}
				hashSet.Remove(instruction);
				if (instruction.OpCode.OpCodeType != OpCodeType.Prefix && trace.hw[instruction.Offset] == 0 && hashSet.Count == 0 && (flag || 90.0 > new Random().NextDouble()) && (i == 0 || block.hr[i - 1].OpCode.Code != Code.Tailcall))
				{
					linkedList.AddLast(list.ToArray());
					list.Clear();
				}
			}
			if (list.Count > 0)
			{
				linkedList.AddLast(list.ToArray());
			}
			return linkedList;
		}

		public void dp<T>(IList<T> list)
		{
			for (int num = list.Count - 1; num > 1; num--)
			{
				int index = new Random().Next(num + 1);
				T value = list[index];
				list[index] = list[num];
				list[num] = value;
			}
		}

		public void dq(IList<Instruction> instrs, Instruction target, MethodDef Method)
		{
			if (!Method.Module.IsClr40 && !Method.DeclaringType.HasGenericParameters && !Method.HasGenericParameters && (instrs[0].OpCode.FlowControl == FlowControl.Call || instrs[0].OpCode.FlowControl == FlowControl.Next))
			{
				bool flag = false;
				if (Convert.ToBoolean(new Random().Next(0, 2)))
				{
					TypeDef typeDef = Method.Module.Types[new Random().Next(Method.Module.Types.Count)];
					if (typeDef.HasMethods)
					{
						instrs.Add(Instruction.Create(OpCodes.Ldtoken, typeDef.Methods[new Random().Next(typeDef.Methods.Count)]));
						instrs.Add(Instruction.Create(OpCodes.Box, Method.Module.CorLibTypes.GetTypeRef("System", "RuntimeMethodHandle")));
						flag = true;
					}
				}
				if (!flag)
				{
					instrs.Add(Instruction.Create(OpCodes.Ldc_I4, (!Convert.ToBoolean(new Random().Next(0, 2))) ? 1 : 0));
					instrs.Add(Instruction.Create(OpCodes.Box, Method.Module.CorLibTypes.Int32.TypeDefOrRef));
				}
				Instruction item = Instruction.Create(OpCodes.Pop);
				instrs.Add(Instruction.Create(OpCodes.Brfalse, instrs[0]));
				instrs.Add(Instruction.Create(OpCodes.Ldc_I4, (!Convert.ToBoolean(new Random().Next(0, 2))) ? 1 : 0));
				instrs.Add(item);
			}
			instrs.Add(Instruction.Create(OpCodes.Br, target));
		}

		public void dr(IList<Instruction> instrs, MethodDef Method)
		{
			if (!Method.Module.IsClr40)
			{
				instrs.Add(Instruction.Create(OpCodes.Pop));
				instrs.Add(Instruction.Create(OpCodes.Dup));
				instrs.Add(Instruction.Create(OpCodes.Throw));
				instrs.Add(Instruction.Create(OpCodes.Ldarg, new Parameter(255)));
				instrs.Add(Instruction.Create(OpCodes.Ldloc, new Local(null, null, 255)));
				instrs.Add(Instruction.Create(OpCodes.Ldtoken, Method));
			}
		}
	}
}
