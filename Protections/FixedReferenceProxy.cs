using System.Collections.Generic;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using ICore;

namespace Protections
{
	public class FixedReferenceProxy
	{
		private static List<MethodDef> bd = new List<MethodDef>();

		public static void Execute(Context lib)
		{
			Helper.FixProxy(lib.Module);
			TypeDef[] array = lib.Module.Types.ToArray();
			foreach (TypeDef typeDef in array)
			{
				MethodDef[] array2 = typeDef.Methods.ToArray();
				foreach (MethodDef methodDef in array2)
				{
					if (bd.Contains(methodDef) || !methodDef.HasBody || !methodDef.Body.HasInstructions || methodDef.DeclaringType.IsGlobalModuleType)
					{
						continue;
					}
					Instruction[] array3 = methodDef.Body.Instructions.ToArray();
					foreach (Instruction instruction in array3)
					{
						if (instruction.OpCode == OpCodes.Newobj)
						{
							IMethodDefOrRef methodDefOrRef = instruction.Operand as IMethodDefOrRef;
							if (!methodDefOrRef.IsMethodSpec && methodDefOrRef != null)
							{
								MethodDef methodDef2 = Helper.GenerateMethod(methodDefOrRef, methodDef);
								if (methodDef2 != null)
								{
									methodDef.DeclaringType.Methods.Add(methodDef2);
									bd.Add(methodDef2);
									instruction.OpCode = OpCodes.Call;
									instruction.Operand = methodDef2;
									bd.Add(methodDef2);
								}
							}
						}
						else if (instruction.OpCode == OpCodes.Stfld)
						{
							if (instruction.Operand is FieldDef fieldDef)
							{
								CilBody cilBody = new CilBody();
								cilBody.Instructions.Add(OpCodes.Nop.ToInstruction());
								cilBody.Instructions.Add(OpCodes.Ldarg_0.ToInstruction());
								cilBody.Instructions.Add(OpCodes.Ldarg_1.ToInstruction());
								cilBody.Instructions.Add(OpCodes.Stfld.ToInstruction(fieldDef));
								cilBody.Instructions.Add(OpCodes.Ret.ToInstruction());
								MethodSig methodSig = MethodSig.CreateInstance(lib.Module.CorLibTypes.Void, fieldDef.FieldSig.GetFieldType());
								methodSig.HasThis = true;
								MethodDefUser methodDefUser = new MethodDefUser(Utils.GenerateString(), methodSig)
								{
									Body = cilBody,
									IsHideBySig = true
								};
								bd.Add(methodDefUser);
								methodDef.DeclaringType.Methods.Add(methodDefUser);
								instruction.Operand = methodDefUser;
								instruction.OpCode = OpCodes.Call;
							}
						}
						else if (instruction.OpCode == OpCodes.Ldfld)
						{
							if (instruction.Operand is FieldDef targetField)
							{
								MethodDef methodDef3 = Helper.GenerateMethod(targetField, methodDef);
								instruction.OpCode = OpCodes.Call;
								instruction.Operand = methodDef3;
								bd.Add(methodDef3);
							}
						}
						else
						{
							if (instruction.OpCode != OpCodes.Call || !(instruction.Operand is MemberRef))
							{
								continue;
							}
							MemberRef memberRef = (MemberRef)instruction.Operand;
							if (!memberRef.FullName.Contains("Collections.Generic") && !memberRef.Name.Contains("ToString") && !memberRef.FullName.Contains("Thread::Start") && !memberRef.FullName.Contains("System.Boolean"))
							{
								MethodDef methodDef4 = Helper.GenerateMethod(typeDef, memberRef, memberRef.HasThis, memberRef.FullName.StartsWith("System.Void"));
								if (methodDef4 != null)
								{
									bd.Add(methodDef4);
									typeDef.Methods.Add(methodDef4);
									instruction.Operand = methodDef4;
									methodDef4.Body.Instructions.Add(new Instruction(OpCodes.Ret));
								}
							}
						}
					}
				}
			}
		}
	}
}
