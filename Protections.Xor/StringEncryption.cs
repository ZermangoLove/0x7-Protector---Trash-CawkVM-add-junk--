using System;
using System.Collections.Generic;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using Helpers.Injection;
using ICore;
using Protections.Xor.Runtime;

namespace Protections.Xor
{
	public class StringEncryption
	{
		private readonly EncryptionService ca;

		private FieldDef cb;

		private MethodDef cc;

		private MethodDef cd;

		public StringEncryption()
		{
			ca = new EncryptionService();
		}

		public void Run(Context context)
		{
			ce(context);
			cf(context);
			cg();
			ch();
		}

		private void ce(Context context)
		{
			Injector injector = new Injector(context.Module, typeof(XorRuntime));
			cd = injector.FindMember("XVM") as MethodDef;
			cc = injector.FindMember("Decrypt") as MethodDef;
			injector.Rename();
		}

		private void cf(Context context)
		{
			foreach (TypeDef item in context.Module.Types.Where((TypeDef t) => t.Methods.Count > 0))
			{
				if (item == cc.DeclaringType || item.IsGlobalModuleType || item.Namespace == "Costura")
				{
					continue;
				}
				foreach (MethodDef method in item.Methods)
				{
					if (method.Body == null || !method.HasBody || !method.Body.HasInstructions)
					{
						continue;
					}
					method.Body.SimplifyMacros(method.Parameters);
					method.Body.SimplifyBranches();
					IList<Instruction> instructions = method.Body.Instructions;
					for (int i = 0; i < instructions.Count; i++)
					{
						if (instructions[i].OpCode == OpCodes.Ldstr && instructions[i].Operand != null)
						{
							if ((string)instructions[i].Operand == string.Empty)
							{
								instructions[i].OpCode = OpCodes.Ldc_I4;
								instructions[i].Operand = -ca.Index;
								instructions.Insert(i + 1, new Instruction(OpCodes.Ldnull));
								instructions.Insert(i + 2, new Instruction(OpCodes.Call, cc));
							}
							else
							{
								ca.Encrypt((string)instructions[i].Operand);
								instructions[i].OpCode = OpCodes.Ldc_I4;
								instructions[i].Operand = ca.Index;
								instructions.Insert(i + 1, new Instruction(OpCodes.Ldnull));
								instructions.Insert(i + 2, new Instruction(OpCodes.Call, cc));
							}
						}
					}
					instructions.OptimizeMacros();
				}
			}
		}

		private void cg()
		{
			TypeDef typeDef = cc.DeclaringType?.NestedTypes[0];
			typeDef.Attributes = TypeAttributes.NestedPrivate | TypeAttributes.ExplicitLayout | TypeAttributes.BeforeFieldInit;
			typeDef.Name = Utils.GenerateString();
			FieldDefUser fieldDefUser = new FieldDefUser(Utils.GenerateString(), new FieldSig(typeDef.ToTypeSig()), FieldAttributes.Private | FieldAttributes.Static | FieldAttributes.HasFieldRVA);
			cc.DeclaringType?.Fields.Add(fieldDefUser);
			cb = fieldDefUser;
			typeDef.ClassLayout = new ClassLayoutUser(1, ca.Length);
			fieldDefUser.InitialValue = ca.Data;
		}

		private void ch()
		{
			CilBody body = cc.Body;
			object obj;
			if (body == null)
			{
				obj = null;
			}
			else
			{
				obj = body.Instructions;
				if (obj != null)
				{
					Instruction obj2 = ((IEnumerable<Instruction>)obj)?.First((Instruction i) => i.IsLdcI4() && i.GetLdcI4Value() == 1056);
					obj2.OpCode = OpCodes.Ldsflda;
					obj2.Operand = cb;
					(((IEnumerable<Instruction>)obj)?.First((Instruction i) => i.Operand == cd)).OpCode = OpCodes.Cpblk;
					cc.DeclaringType.Methods.Remove(cd);
					return;
				}
			}
			throw new ArgumentNullException();
		}
	}
}
