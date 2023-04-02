using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Core.ByteEncryption;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using dnlib.Utils;
using ICore;

namespace Core.Injection
{
	internal class InjectInitialise
	{
		public static MemberRef conversionInit;

		public static MemberRef convertBack;

		public static Module conversionAssembly { get; set; }

		public static ModuleDefMD conversionDef { get; set; }

		public static void initaliseMethod()
		{
			int num = 1592476945;
			int num2 = 1;
			do
			{
				if (num2 == (0x5EEB4510 ^ num))
				{
					byte[] array = File.ReadAllBytes(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Runtime.dll"));
					conversionAssembly = Assembly.Load(array).ManifestModule;
					conversionDef = ModuleDefMD.Load(array);
					num2 = -1592476943 + num;
				}
				if (num2 == 1592476945 - num)
				{
					num2 = 0x5EEB4510 ^ num;
				}
			}
			while (num2 != -1592476943 + num);
		}

		public static void injectIntoCctor(string ResName)
		{
			int num = 1279972655;
			int num2 = 1;
			IEnumerator<TypeDef> enumerator = default(IEnumerator<TypeDef>);
			do
			{
				if (num2 == 1279972656 - num)
				{
					enumerator = conversionDef.Types.GetEnumerator();
					num2 = 0x4C4AD52D ^ num;
				}
				if (num2 != 1279972657 - num)
				{
					if (num2 == 1279972655 - num)
					{
						num2 = 0x4C4AD52E ^ num;
					}
					continue;
				}
				try
				{
					while (enumerator.MoveNext())
					{
						foreach (MethodDef method in enumerator.Current.Methods)
						{
							if (method.Name == "IVME")
							{
								conversionInit = Protector.moduleDefMD.Import(method);
							}
							if (method.Name == "_")
							{
								convertBack = Protector.moduleDefMD.Import(method);
							}
						}
					}
				}
				finally
				{
					enumerator?.Dispose();
				}
				InjectHelper.Inject(ModuleDefMD.Load(typeof(Resource).Assembly.Location).GetTypes().ToArray()[-1279972642 + num], Protector.moduleDefMD.GlobalType, Protector.moduleDefMD);
				foreach (MethodDef method2 in Protector.moduleDefMD.GlobalType.Methods)
				{
					if (method2.Name == ".ctor")
					{
						Protector.moduleDefMD.GlobalType.Remove(method2);
						break;
					}
				}
				if (Protector.moduleDefMD.GlobalType.FindOrCreateStaticConstructor().Body != null)
				{
					break;
				}
				CilBody cilBody = new CilBody();
				cilBody.Instructions.Add(new Instruction(OpCodes.Call, Protector.moduleDefMD.Types[-1279972655 + num].Methods[-1279972655 + num]));
				cilBody.Instructions.Add(new Instruction(OpCodes.Ret));
				Protector.moduleDefMD.GlobalType.FindOrCreateStaticConstructor().Body = cilBody;
				return;
			}
			while (num2 != -1279972652 + num);
			CilBody body = Protector.moduleDefMD.GlobalType.FindOrCreateStaticConstructor().Body;
			body.Instructions.Insert(0x4C4AD52F ^ num, new Instruction(OpCodes.Call, Protector.moduleDefMD.Types[1279972655 - num].Methods.Where((MethodDef i) => i.Name == "setup").First()));
			if (((uint)Protector.moduleDefMD.Characteristics & (uint)((-1323487416 ^ num) + (579873670 + num) - (-1199722421 - num))) != 0)
			{
				body.Instructions.Insert(1279972656 - num, new Instruction(OpCodes.Ldstr, "TestResc"));
				body.Instructions.Insert(-1279972653 + num, new Instruction(OpCodes.Call, conversionInit));
			}
		}

		public static void InjectMethod(MethodDef meth, int pos, int id, int size)
		{
			int num = 1740728291;
			int num2 = 1;
			bool flag = default(bool);
			IEnumerable<Parameter> enumerable = default(IEnumerable<Parameter>);
			Local local = default(Local);
			Local local2 = default(Local);
			CilBody cilBody = default(CilBody);
			LazyList<Local>.Enumerator enumerator = default(LazyList<Local>.Enumerator);
			do
			{
				if (num2 == (0x67C167E2 ^ num))
				{
					Console.WriteLine("     -> Started");
					num2 = 0x67C167E1 ^ num;
				}
				if (num2 == (0x67C167E1 ^ num))
				{
					flag = (byte)(1740728291 - num) != 0;
					num2 = 1740728294 - num;
				}
				if (num2 == -1740728288 + num)
				{
					meth.Body.Instructions.Clear();
					num2 = -1740728287 + num;
				}
				if (num2 == (0x67C167E7 ^ num))
				{
					enumerable = meth.Parameters.Where((Parameter i) => i.Type.FullName.EndsWith("&"));
					num2 = 1740728296 - num;
				}
				if (num2 == -1740728286 + num)
				{
					if (enumerable.Count() == 0)
					{
						goto IL_0208;
					}
					num2 = 0x67C167E5 ^ num;
				}
				if (num2 == (0x67C167E5 ^ num))
				{
					flag = (byte)(1740728292 - num) != 0;
					num2 = 1740728298 - num;
				}
				if (num2 == -1740728283 + num)
				{
					local = new Local(Protector.moduleDefMD.CorLibTypes.Object);
					num2 = 1740728300 - num;
				}
				if (num2 == (0x67C167EA ^ num))
				{
					local2 = new Local(new SZArraySig(Protector.moduleDefMD.CorLibTypes.Object));
					num2 = -1740728281 + num;
				}
				if (num2 == (0x67C167E9 ^ num))
				{
					cilBody = new CilBody();
					num2 = 1740728302 - num;
				}
				if (num2 == (0x67C167E8 ^ num))
				{
					enumerator = meth.Body.Variables.GetEnumerator();
					num2 = 0x67C167EF ^ num;
				}
				if (num2 == (0x67C167E4 ^ num))
				{
					goto IL_0208;
				}
				goto IL_022b;
				IL_0208:
				Protector.moduleDefMD.CorLibTypes.Object.ToSZArraySig();
				num2 = 1740728299 - num;
				goto IL_022b;
				IL_022b:
				if (num2 == -1740728291 + num)
				{
					num2 = 0x67C167E2 ^ num;
				}
			}
			while (num2 != 1740728303 - num);
			try
			{
				while (enumerator.MoveNext())
				{
					Local current = enumerator.Current;
					cilBody.Variables.Add(current);
				}
			}
			finally
			{
				((IDisposable)enumerator).Dispose();
			}
			cilBody.Variables.Add(local);
			cilBody.Variables.Add(local2);
			new List<Local>();
			Dictionary<Parameter, Local> dictionary = new Dictionary<Parameter, Local>();
			if (flag)
			{
				foreach (Parameter item in enumerable)
				{
					Local local3 = new Local(item.Type.Next);
					dictionary.Add(item, local3);
					cilBody.Variables.Add(local3);
				}
			}
			int num3 = 0x67C167E3 ^ num;
			cilBody.Instructions.Add(new Instruction(OpCodes.Ldc_I4, meth.Parameters.Count));
			cilBody.Instructions.Add(new Instruction(OpCodes.Newarr, Protector.moduleDefMD.CorLibTypes.Object.ToTypeDefOrRef()));
			for (int j = -1740728291 + num; j < meth.Parameters.Count; j += -1740728290 + num)
			{
				Parameter parameter = meth.Parameters[j];
				cilBody.Instructions.Add(new Instruction(OpCodes.Dup));
				cilBody.Instructions.Add(new Instruction(OpCodes.Ldc_I4, j));
				if (flag)
				{
					if (enumerable.Contains(meth.Parameters[j]))
					{
						cilBody.Instructions.Add(new Instruction(OpCodes.Ldloc, dictionary[meth.Parameters[j]]));
						num3 += -1740728290 + num;
					}
					else
					{
						cilBody.Instructions.Add(new Instruction(OpCodes.Ldarg, meth.Parameters[j]));
					}
				}
				else
				{
					cilBody.Instructions.Add(new Instruction(OpCodes.Ldarg, meth.Parameters[j]));
				}
				cilBody.Instructions.Add(parameter.Type.FullName.EndsWith("&") ? new Instruction(OpCodes.Box, parameter.Type.Next.ToTypeDefOrRef()) : new Instruction(OpCodes.Box, parameter.Type.ToTypeDefOrRef()));
				cilBody.Instructions.Add(new Instruction(OpCodes.Stelem_Ref));
			}
			cilBody.Instructions.Add(new Instruction(OpCodes.Ldloc, local2));
			cilBody.Instructions.Add(new Instruction(OpCodes.Stloc, local2));
			IList<Instruction> instructions = cilBody.Instructions;
			OpCode ldstr = OpCodes.Ldstr;
			object[] array = new object[-1740728286 + num];
			array[1740728291 - num] = pos;
			array[0x67C167E2 ^ num] = "|";
			array[-1740728289 + num] = id;
			array[1740728294 - num] = "|";
			array[0x67C167E7 ^ num] = size;
			instructions.Add(new Instruction(ldstr, Xor.XorProcess(string.Concat(array), "IVM")));
			cilBody.Instructions.Add(new Instruction(OpCodes.Call, convertBack));
			if (meth.HasReturnType)
			{
				cilBody.Instructions.Add(new Instruction(OpCodes.Unbox_Any, meth.ReturnType.ToTypeDefOrRef()));
			}
			else
			{
				cilBody.Instructions.Add(new Instruction(OpCodes.Stloc, local));
			}
			if (flag)
			{
				foreach (Parameter item2 in enumerable)
				{
					cilBody.Instructions.Add(new Instruction(OpCodes.Ldarg, item2));
					cilBody.Instructions.Add(new Instruction(OpCodes.Ldloc, local2));
					cilBody.Instructions.Add(new Instruction(OpCodes.Ldc_I4, meth.Parameters.IndexOf(item2)));
					cilBody.Instructions.Add(new Instruction(OpCodes.Ldelem_Ref));
					cilBody.Instructions.Add(new Instruction(OpCodes.Unbox_Any, item2.Type.Next.ToTypeDefOrRef()));
					cilBody.Instructions.Add(new Instruction(OpCodes.Stind_Ref));
				}
				cilBody.Instructions.Add(new Instruction(OpCodes.Ret));
			}
			else
			{
				cilBody.Instructions.Add(new Instruction(OpCodes.Ret));
			}
			foreach (TypeDef type in Protector.moduleDefMD.GetTypes())
			{
				if (type.Name != "<Module>")
				{
					continue;
				}
				foreach (MethodDef method in type.Methods)
				{
					if (!method.IsRuntimeSpecialName && !method.IsSpecialName && !(method.Name == "Invoke"))
					{
						method.Name = Utils.GenerateString();
						method.Body.Instructions.Insert(0x67C167E2 ^ num, new Instruction(OpCodes.Br_S, method.Body.Instructions[1740728292 - num]));
						method.Body.Instructions.Insert(-1740728289 + num, new Instruction(OpCodes.Unaligned, -1740728291 + num));
					}
				}
			}
			meth.Body = cilBody;
			meth.Body.UpdateInstructionOffsets();
			CilBody body = meth.Body;
			body.MaxStack = (ushort)(body.MaxStack + (0x67C167E9 ^ num));
			meth.Body.SimplifyBranches();
			meth.Body.OptimizeBranches();
			meth.Body.OptimizeMacros();
		}
	}
}
