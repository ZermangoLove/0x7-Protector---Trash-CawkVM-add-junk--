using System.Linq;
using System.Runtime.CompilerServices;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using ICore;

namespace Protections
{
	public class ConstantMelting
	{
		[CompilerGenerated]
		private static MethodDef D;

		private static MethodDef G
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

		public ConstantMelting(MethodDef method)
		{
			G = method;
		}

		public static void MeltStrings(Context context)
		{
			TypeDef[] array = context.Module.GetTypes().ToArray();
			foreach (TypeDef typeDef in array)
			{
				if (typeDef.IsGlobalModuleType || typeDef.Namespace == "Costura")
				{
					continue;
				}
				MethodDef[] array2 = typeDef.Methods.ToArray();
				foreach (MethodDef methodDef in array2)
				{
					ConstantMelting constantMelting = new ConstantMelting(methodDef);
					if (methodDef.HasBody && methodDef.Body.HasInstructions && !methodDef.DeclaringType.IsGlobalModuleType)
					{
						constantMelting.StringOutliner();
					}
				}
			}
		}

		public static void MeltIntegers(Context context)
		{
			TypeDef[] array = context.Module.GetTypes().ToArray();
			foreach (TypeDef typeDef in array)
			{
				if (typeDef.IsGlobalModuleType || typeDef.Namespace == "Costura")
				{
					continue;
				}
				MethodDef[] array2 = typeDef.Methods.ToArray();
				foreach (MethodDef methodDef in array2)
				{
					ConstantMelting constantMelting = new ConstantMelting(methodDef);
					if (methodDef.HasBody && methodDef.Body.HasInstructions && !methodDef.DeclaringType.IsGlobalModuleType)
					{
						constantMelting.bc();
					}
				}
			}
		}

		public void StringOutliner()
		{
			foreach (Instruction instruction in G.Body.Instructions)
			{
				if (instruction.OpCode == OpCodes.Ldstr)
				{
					MethodDef methodDef = new MethodDefUser(Utils.GenerateString(), MethodSig.CreateStatic(G.DeclaringType.Module.CorLibTypes.String), MethodImplAttributes.IL, MethodAttributes.Public | MethodAttributes.Static | MethodAttributes.HideBySig)
					{
						Body = new CilBody()
					};
					methodDef.Body.Instructions.Add(new Instruction(OpCodes.Ldstr, instruction.Operand.ToString()));
					methodDef.Body.Instructions.Add(new Instruction(OpCodes.Ret));
					G.DeclaringType.Methods.Add(methodDef);
					instruction.OpCode = OpCodes.Call;
					instruction.Operand = methodDef;
				}
			}
		}

		private void bc()
		{
			foreach (Instruction instruction in G.Body.Instructions)
			{
				if (instruction.OpCode == OpCodes.Ldc_I4)
				{
					MethodDef methodDef = new MethodDefUser(Utils.GenerateString(), MethodSig.CreateStatic(G.DeclaringType.Module.CorLibTypes.Int32), MethodImplAttributes.IL, MethodAttributes.Public | MethodAttributes.Static | MethodAttributes.HideBySig)
					{
						Body = new CilBody()
					};
					methodDef.Body.Instructions.Add(new Instruction(OpCodes.Ldc_I4, instruction.GetLdcI4Value()));
					methodDef.Body.Instructions.Add(new Instruction(OpCodes.Ret));
					G.DeclaringType.Methods.Add(methodDef);
					instruction.OpCode = OpCodes.Call;
					instruction.Operand = methodDef;
				}
			}
		}
	}
}
