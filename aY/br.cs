using System;
using System.Collections.Generic;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using ICore;

namespace aY
{
	internal class br
	{
		private static Random bs = new Random();

		public static void ag(Context context)
		{
			foreach (TypeDef type in context.Module.GetTypes())
			{
				foreach (MethodDef method in type.Methods)
				{
					if (!method.HasBody || method.Body == null)
					{
						continue;
					}
					IList<Instruction> instructions = method.Body.Instructions;
					for (int i = 0; i < instructions.Count; i++)
					{
						try
						{
							if (method.Body.Instructions[i].OpCode != OpCodes.Ldstr)
							{
								continue;
							}
							List<Instruction> list = new List<Instruction>();
							int num = 0;
							new Random();
							Local local = new Local(method.Module.Import(typeof(string[])).ToTypeSig(), Utils.GenerateString());
							method.Body.Variables.Add(local);
							list.Add(new Instruction(OpCodes.Ldc_I4, 256));
							list.Add(new Instruction(OpCodes.Newarr, method.Module.Import(typeof(string))));
							list.Add(new Instruction(OpCodes.Stloc_S, local));
							string text = instructions[i].Operand.ToString();
							foreach (char c in text)
							{
								list.Add(new Instruction(OpCodes.Ldloc, local));
								list.Add(new Instruction(OpCodes.Ldc_I4, num));
								switch (bs.Next(0, 2))
								{
								case 1:
									list.Add(new Instruction(OpCodes.Ldc_I4, (int)c));
									list.Add(Instruction.Create(OpCodes.Call, context.Module.Import(typeof(Convert).GetMethod("ToChar", new Type[1] { typeof(int) }))));
									break;
								case 0:
									list.Add(new Instruction(OpCodes.Ldc_I8, (long)c));
									list.Add(Instruction.Create(OpCodes.Call, context.Module.Import(typeof(Convert).GetMethod("ToChar", new Type[1] { typeof(long) }))));
									break;
								}
								list.Add(Instruction.Create(OpCodes.Call, context.Module.Import(typeof(Convert).GetMethod("ToString", new Type[1] { typeof(char) }))));
								list.Add(new Instruction(OpCodes.Stelem_Ref));
								num++;
							}
							int num2 = 0;
							foreach (Instruction item in list)
							{
								method.Body.Instructions.Insert(num2, item);
								num2++;
							}
							instructions.Insert(i + num2, new Instruction(OpCodes.Ldloc, local));
							instructions[i + num2 + 1].OpCode = OpCodes.Call;
							instructions[i + num2 + 1].Operand = context.Module.Import(typeof(string).GetMethod("Concat", new Type[1] { typeof(string[]) }));
						}
						catch (Exception)
						{
						}
					}
				}
			}
		}
	}
}
