using System.Collections.Generic;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using ICore;

namespace Protections
{
	public class BasicReferenceProxy
	{
		private static List<MethodDef> bd = new List<MethodDef>();

		public static void Execute(Context ctx)
		{
			Helper.FixProxy(ctx.Module);
			TypeDef[] array = ctx.Module.Types.ToArray();
			for (int i = 0; i < array.Length; i++)
			{
				MethodDef[] array2 = array[i].Methods.ToArray();
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
						else if (instruction.OpCode == OpCodes.Stfld && instruction.Operand is FieldDef fieldDef)
						{
							CilBody cilBody = new CilBody();
							cilBody.Instructions.Add(OpCodes.Nop.ToInstruction());
							cilBody.Instructions.Add(OpCodes.Ldarg_0.ToInstruction());
							cilBody.Instructions.Add(OpCodes.Ldarg_1.ToInstruction());
							cilBody.Instructions.Add(OpCodes.Stfld.ToInstruction(fieldDef));
							cilBody.Instructions.Add(OpCodes.Ret.ToInstruction());
							MethodSig methodSig = MethodSig.CreateInstance(ctx.Module.CorLibTypes.Void, fieldDef.FieldSig.GetFieldType());
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
				}
			}
		}
	}
}
